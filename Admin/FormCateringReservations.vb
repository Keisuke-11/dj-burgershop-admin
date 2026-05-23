Imports MySqlConnector
Imports System.Threading.Tasks
Imports System.Collections.Generic

Public Class FormCateringReservations
    ' Database connection string using global modDB
    Private connectionString As String = modDB.strConnection

    ' Pagination state
    Private _currentPage As Integer = 1
    Private ReadOnly _pageSize As Integer = 10
    Private _totalRecords As Integer = 0
    Private _totalPages As Integer = 1

    Private Async Sub FormCateringReservations_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load initial data asynchronously
        Await RefreshAnalyticsAsync()
    End Sub

    Private Async Function RefreshAnalyticsAsync() As Task
        Try
            ' Run database queries concurrently
            Dim summaryTask As Task = LoadReservationSummaryAsync()
            Dim breakdownTask As Task = LoadReservationBreakdownAsync()

            Await Task.WhenAll(summaryTask, breakdownTask)

        Catch ex As Exception
            MessageBox.Show("Error refreshing analytics: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Async Function LoadReservationSummaryAsync() As Task
        Try
            Dim totalReservations As Integer = 0
            Dim totalEvents As Integer = 0
            Dim totalRevenue As Decimal = 0

            Await Task.Run(Sub()
                               Using conn As New MySqlConnection(connectionString)
                                   conn.Open()

                                    ' Build period filter for summary
                                    Dim periodFilter As String = ""
                                    Dim selectedYear As Integer = Reports.SelectedYear
                                    Dim selectedMonth As Integer = Reports.SelectedMonth

                                    Select Case Reports.SelectedPeriod
                                        Case "Daily"
                                            periodFilter = $" WHERE DATE(ReservationDate) = '{Reports.GlobalFilterDate:yyyy-MM-dd}' "
                                        Case "Weekly"
                                            periodFilter = $" WHERE YEARWEEK(ReservationDate, 1) = YEARWEEK('{Reports.GlobalFilterDate:yyyy-MM-dd}', 1) "
                                        Case "Monthly"
                                            If selectedMonth = 0 Then
                                                periodFilter = $" WHERE YEAR(ReservationDate) = {selectedYear} "
                                            Else
                                                periodFilter = $" WHERE YEAR(ReservationDate) = {selectedYear} AND MONTH(ReservationDate) = {selectedMonth} "
                                            End If
                                        Case "Yearly"
                                            periodFilter = $" WHERE YEAR(ReservationDate) = {selectedYear} "
                                    End Select

                                   ' Get Total Reservations count
                                   Dim cmdTotalReservations As New MySqlCommand("SELECT COUNT(*) FROM reservation" & periodFilter, conn)
                                   totalReservations = Convert.ToInt32(cmdTotalReservations.ExecuteScalar())

                                   ' Get Total Events (Confirmed)
                                   Dim statusFilter = If(String.IsNullOrEmpty(periodFilter), " WHERE ", periodFilter & " AND ")
                                   Dim cmdTotalEvents As New MySqlCommand("SELECT COUNT(*) FROM reservation " & statusFilter & " ReservationStatus = 'Confirmed'", conn)
                                   totalEvents = Convert.ToInt32(cmdTotalEvents.ExecuteScalar())

                                   ' Calculate Total Revenue from payment table
                                   ' We need to join with reservation to apply the period filter
                                   Dim cmdTotalRevenue As New MySqlCommand("
                        SELECT COALESCE(SUM(p.AmountPaid), 0)
                        FROM reservation r
                        INNER JOIN reservationpayment p ON r.ReservationID = p.ReservationID
                        " & periodFilter & "
                        AND p.PaymentStatus IN ('Paid', 'Completed')
                    ", conn)

                                   Dim result As Object = cmdTotalRevenue.ExecuteScalar()
                                   totalRevenue = If(result IsNot Nothing AndAlso Not IsDBNull(result), Convert.ToDecimal(result), 0D)
                               End Using
                           End Sub)

            ' Update UI on UI thread
            Me.Invoke(Sub()
                          Label5.Text = totalReservations.ToString("N0")
                          Label6.Text = totalEvents.ToString("N0")
                          Label3.Text = "Total Revenue"
                          LabelSubtitle3.Text = "Total collections"
                          Label7.Text = "₱" & totalRevenue.ToString("N2")
                      End Sub)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Async Function LoadReservationBreakdownAsync() As Task
        Try
            Dim dt As New DataTable()
            Dim selectedFilter As String = Reports.SelectedPeriod

            ' Get total count first to update pagination
            _totalRecords = Await Task.Run(Function() FetchTotalReservationCount(selectedFilter))
            _totalPages = Math.Max(1, Math.Ceiling(_totalRecords / _pageSize))

            If _currentPage > _totalPages Then _currentPage = _totalPages
            If _currentPage < 1 Then _currentPage = 1

            Dim offset As Integer = (_currentPage - 1) * _pageSize

            Await Task.Run(Sub()
                               Using conn As New MySqlConnection(connectionString)
                                   conn.Open()

                                    Dim yearFilter As String = $" WHERE YEAR(r.ReservationDate) = {Reports.SelectedYear} "
                                    Dim query As String = ""
                                    Select Case selectedFilter
                                         Case "Daily"
                                            query = "
                                 SELECT 
                                     DATE(r.ReservationDate) AS Period, 
                                     COUNT(*) AS ReservationCount, 
                                     SUM(r.NumberOfGuests) AS TotalGuests, 
                                     COALESCE(SUM(p.TotalPaid), 0) AS TotalAmount 
                                 FROM reservation r
                                 LEFT JOIN (
                                     SELECT ReservationID, SUM(AmountPaid) AS TotalPaid
                                     FROM reservationpayment
                                     WHERE PaymentStatus IN ('Paid', 'Completed')
                                     GROUP BY ReservationID
                                 ) AS p ON p.ReservationID = r.ReservationID
                                 " & yearFilter & "
                                 GROUP BY DATE(r.ReservationDate)
                                 ORDER BY Period DESC 
                                 LIMIT @limit OFFSET @offset"

                                         Case "Weekly"
                                            query = "
                                 SELECT 
                                     CONCAT(YEAR(r.ReservationDate), '-W', LPAD(WEEK(r.ReservationDate), 2, '0')) AS Period, 
                                     COUNT(*) AS ReservationCount, 
                                     SUM(r.NumberOfGuests) AS TotalGuests, 
                                     COALESCE(SUM(p.TotalPaid), 0) AS TotalAmount
                                 FROM reservation r
                                 LEFT JOIN (
                                     SELECT ReservationID, SUM(AmountPaid) AS TotalPaid
                                     FROM reservationpayment
                                     WHERE PaymentStatus IN ('Paid', 'Completed')
                                     GROUP BY ReservationID
                                 ) AS p ON p.ReservationID = r.ReservationID
                                 " & yearFilter & "
                                 GROUP BY YEAR(r.ReservationDate), WEEK(r.ReservationDate)
                                 ORDER BY YEAR(r.ReservationDate) DESC, WEEK(r.ReservationDate) DESC 
                                 LIMIT @limit OFFSET @offset"

                                         Case "Monthly"
                                            query = "
                                 SELECT 
                                     DATE_FORMAT(r.ReservationDate, '%Y-%m') AS Period, 
                                     COUNT(*) AS ReservationCount, 
                                     SUM(r.NumberOfGuests) AS TotalGuests, 
                                     COALESCE(SUM(p.TotalPaid), 0) AS TotalAmount
                                 FROM reservation r
                                 LEFT JOIN (
                                     SELECT ReservationID, SUM(AmountPaid) AS TotalPaid
                                     FROM reservationpayment
                                     WHERE PaymentStatus IN ('Paid', 'Completed')
                                     GROUP BY ReservationID
                                 ) AS p ON p.ReservationID = r.ReservationID
                                 " & yearFilter & "
                                 GROUP BY YEAR(r.ReservationDate), MONTH(r.ReservationDate)
                                 ORDER BY Period DESC 
                                 LIMIT @limit OFFSET @offset"

                                         Case "Yearly"
                                            query = "
                                 SELECT 
                                     YEAR(r.ReservationDate) AS Period, 
                                     COUNT(*) AS ReservationCount, 
                                     SUM(r.NumberOfGuests) AS TotalGuests, 
                                     COALESCE(SUM(p.TotalPaid), 0) AS TotalAmount
                                 FROM reservation r
                                 LEFT JOIN (
                                     SELECT ReservationID, SUM(AmountPaid) AS TotalPaid
                                     FROM reservationpayment
                                     WHERE PaymentStatus IN ('Paid', 'Completed')
                                     GROUP BY ReservationID
                                 ) AS p ON p.ReservationID = r.ReservationID
                                 GROUP BY YEAR(r.ReservationDate)
                                 ORDER BY Period DESC 
                                 LIMIT @limit OFFSET @offset"
                                    End Select

                                   Using cmd As New MySqlCommand(query, conn)
                                       cmd.Parameters.AddWithValue("@limit", _pageSize)
                                       cmd.Parameters.AddWithValue("@offset", offset)
                                       Using adapter As New MySqlDataAdapter(cmd)
                                           adapter.Fill(dt)
                                       End Using
                                   End Using
                               End Using
                           End Sub)

            ' Update UI on UI thread
            Me.Invoke(Sub()
                          DataGridView1.Rows.Clear()
                          For Each row As DataRow In dt.Rows
                              Dim period As String = row("Period").ToString()
                              Dim count As Integer = Convert.ToInt32(row("ReservationCount"))
                              Dim guests As Integer = Convert.ToInt32(row("TotalGuests"))
                              Dim amount As Decimal = Convert.ToDecimal(row("TotalAmount"))

                              DataGridView1.Rows.Add(period, count, guests, "₱" & amount.ToString("N2"))
                          Next
                          UpdatePaginationUI()
                      End Sub)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function FetchTotalReservationCount(filter As String) As Integer
        Dim yearFilter As String = $" WHERE YEAR(ReservationDate) = {Reports.SelectedYear} "
        Dim groupClause As String = ""
        Select Case filter
            Case "Daily" : groupClause = "GROUP BY DATE(ReservationDate)"
            Case "Weekly" : groupClause = "GROUP BY YEARWEEK(ReservationDate, 1)"
            Case "Monthly" : groupClause = "GROUP BY YEAR(ReservationDate), MONTH(ReservationDate)"
            Case "Yearly" : groupClause = "GROUP BY YEAR(ReservationDate)"
        End Select

        ' We need to count the groups (periods)
        Dim query As String = $"SELECT COUNT(*) FROM (SELECT 1 FROM reservation {yearFilter} {groupClause}) AS t"

        Using conn As New MySqlConnection(connectionString)
            conn.Open()
            Using cmd As New MySqlCommand(query, conn)
                Return Convert.ToInt32(cmd.ExecuteScalar())
            End Using
        End Using
    End Function

    Private Sub UpdatePaginationUI()
        lblPageStatus.Text = $"Page {_currentPage} of {_totalPages}"
        btnPrev.Enabled = (_currentPage > 1)
        btnNext.Enabled = (_currentPage < _totalPages)
    End Sub

    Private Async Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        If _currentPage > 1 Then
            _currentPage -= 1
            Await LoadReservationBreakdownAsync()
        End If
    End Sub

    Private Async Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If _currentPage < _totalPages Then
            _currentPage += 1
            Await LoadReservationBreakdownAsync()
        End If
    End Sub


    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
    ' =======================================================================
    ' REFRESH DATA
    ' =======================================================================
    Public Async Sub RefreshData()
        _currentPage = 1
        Await RefreshAnalyticsAsync()
    End Sub

End Class