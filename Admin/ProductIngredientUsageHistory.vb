Imports MySqlConnector

Public Class ProductIngredientUsageHistory

    ' Pagination variables
    Private currentPage As Integer = 1
    Private pageSize As Integer = 50
    Private totalRecords As Integer = 0
    Private totalPages As Integer = 0
    Private orderProductsCache As New Dictionary(Of Integer, String)
    Private reservationProductsCache As New Dictionary(Of Integer, String)

    ' Tab toggle state: "USAGE" or "DISCARD"
    Private currentView As String = "USAGE"

    ' Dynamically created controls
    Private dgvDiscardHistory As New DataGridView()
    Private btnTabUsage As New Button()
    Private btnTabDiscards As New Button()

    Public Sub New()
        InitializeComponent()
    End Sub
    Private Sub LoadProductCaches()
        orderProductsCache.Clear()
        reservationProductsCache.Clear()

        ' --- Orders ---
        Dim sqlOrders As String = "
        SELECT od.OrderID, p.ProductName, od.Quantity
        FROM orderdetails od
        JOIN products p ON od.ProductID = p.ProductID
        ORDER BY od.OrderID, od.OrderDetailID
    "

        Using cmd As New MySqlCommand(sqlOrders, conn)
            Using r = cmd.ExecuteReader()
                While r.Read()
                    Dim id = CInt(r("OrderID"))
                    Dim line = $"• {r("ProductName")} (x{r("Quantity")})"

                    If Not orderProductsCache.ContainsKey(id) Then
                        orderProductsCache(id) = line
                    Else
                        orderProductsCache(id) &= vbCrLf & line
                    End If
                End While
            End Using
        End Using

        ' --- Reservations ---
        Dim sqlRes As String = "
        SELECT ReservationID, ProductName, Quantity
        FROM reservation_items
        ORDER BY ReservationID, ReservationItemID
    "

        Using cmd As New MySqlCommand(sqlRes, conn)
            Using r = cmd.ExecuteReader()
                While r.Read()
                    Dim id = CInt(r("ReservationID"))
                    Dim line = $"• {r("ProductName")} (x{r("Quantity")})"

                    If Not reservationProductsCache.ContainsKey(id) Then
                        reservationProductsCache(id) = line
                    Else
                        reservationProductsCache(id) &= vbCrLf & line
                    End If
                End While
            End Using
        End Using
    End Sub

    Private Sub ProductIngredientUsageHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Set form size
            Me.Size = New Size(1200, 700)
            Me.StartPosition = FormStartPosition.CenterScreen
            dgvUsageHistory.Dock = DockStyle.Fill
            InitializeFilters()
            InitializePagination()
            InitializeTabButtons()
            InitializeDiscardGrid()

        Catch ex As Exception
            MessageBox.Show("Error loading form: " & ex.Message,
                          "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' -------------------------------------------------------
    ' TAB TOGGLE SETUP
    ' -------------------------------------------------------
    Private Sub InitializeTabButtons()
        ' Usage History tab button
        btnTabUsage.Text = "📋 Usage History (Orders)"
        btnTabUsage.Size = New Size(220, 34)
        btnTabUsage.Location = New Point(800, 38)
        btnTabUsage.FlatStyle = FlatStyle.Flat
        btnTabUsage.FlatAppearance.BorderSize = 0
        btnTabUsage.BackColor = Color.FromArgb(26, 38, 50)
        btnTabUsage.ForeColor = Color.White
        btnTabUsage.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        btnTabUsage.Cursor = Cursors.Hand
        btnTabUsage.Name = "btnTabUsage"
        AddHandler btnTabUsage.Click, AddressOf BtnTabUsage_Click
        grpFilters.Controls.Add(btnTabUsage)

        ' Discard Logs tab button
        btnTabDiscards.Text = "🗑️ Discard Logs"
        btnTabDiscards.Size = New Size(160, 34)
        btnTabDiscards.Location = New Point(1030, 38)
        btnTabDiscards.FlatStyle = FlatStyle.Flat
        btnTabDiscards.FlatAppearance.BorderSize = 0
        btnTabDiscards.BackColor = Color.FromArgb(180, 60, 60)
        btnTabDiscards.ForeColor = Color.White
        btnTabDiscards.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        btnTabDiscards.Cursor = Cursors.Hand
        btnTabDiscards.Name = "btnTabDiscards"
        AddHandler btnTabDiscards.Click, AddressOf BtnTabDiscards_Click
        grpFilters.Controls.Add(btnTabDiscards)
    End Sub

    Private Sub InitializeDiscardGrid()
        dgvDiscardHistory.Dock = DockStyle.Fill
        dgvDiscardHistory.AllowUserToAddRows = False
        dgvDiscardHistory.AllowUserToDeleteRows = False
        dgvDiscardHistory.ReadOnly = True
        dgvDiscardHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvDiscardHistory.BackgroundColor = Color.White
        dgvDiscardHistory.BorderStyle = BorderStyle.None
        dgvDiscardHistory.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgvDiscardHistory.GridColor = Color.FromArgb(222, 226, 230)
        dgvDiscardHistory.RowHeadersVisible = False
        dgvDiscardHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvDiscardHistory.RowTemplate.Height = 38
        dgvDiscardHistory.DefaultCellStyle.Font = New Font("Segoe UI", 9)
        dgvDiscardHistory.ColumnHeadersHeight = 38
        Dim hdrStyle As New DataGridViewCellStyle()
        hdrStyle.BackColor = Color.FromArgb(139, 0, 0)
        hdrStyle.ForeColor = Color.White
        hdrStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        hdrStyle.Padding = New Padding(8)
        dgvDiscardHistory.ColumnHeadersDefaultCellStyle = hdrStyle
        dgvDiscardHistory.EnableHeadersVisualStyles = False
        dgvDiscardHistory.Visible = False
        pnlGrid.Controls.Add(dgvDiscardHistory)
    End Sub

    Private Sub BtnTabUsage_Click(sender As Object, e As EventArgs)
        currentView = "USAGE"
        dgvUsageHistory.Visible = True
        dgvDiscardHistory.Visible = False
        btnTabUsage.BackColor = Color.FromArgb(26, 38, 50)
        btnTabDiscards.BackColor = Color.FromArgb(180, 60, 60)
        lblTitle.Text = "Ingredient Usage Record"
        ' Hide pagination — it only applies to usage
        pnlPagination.Visible = True
        LoadUsageHistory()
    End Sub

    Private Sub BtnTabDiscards_Click(sender As Object, e As EventArgs)
        currentView = "DISCARD"
        dgvUsageHistory.Visible = False
        dgvDiscardHistory.Visible = True
        btnTabDiscards.BackColor = Color.FromArgb(220, 53, 69)
        btnTabUsage.BackColor = Color.FromArgb(80, 80, 80)
        lblTitle.Text = "🗑️ Discard Log"
        pnlPagination.Visible = False
        LoadDiscardHistory()
    End Sub

    Private Sub InitializeFilters()
        Try
            ' Date filters - default to last 30 days
            dtpStartDate.Value = Date.Now.AddDays(-30)
            dtpEndDate.Value = Date.Now

            ' Source filter
            cmbSource.Items.Clear()
            cmbSource.Items.Add("All Sources")
            cmbSource.Items.Add("POS")
            cmbSource.Items.Add("WEBSITE")
            cmbSource.Items.Add("ADMIN")
            cmbSource.SelectedIndex = 0

            ' Page size selector
            If cmbPageSize IsNot Nothing Then
                cmbPageSize.Items.Clear()
                cmbPageSize.Items.AddRange(New Object() {25, 50, 100, 200})
                cmbPageSize.SelectedItem = 50
            End If
        Catch ex As Exception
            MessageBox.Show("Error initializing filters: " & ex.Message,
                          "Initialization Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InitializePagination()
        ' Initialize pagination controls
        currentPage = 1
        UpdatePaginationControls()
    End Sub

    Private Sub LoadUsageHistory()
        Dim dt As New DataTable()

        Try
            ' Show loading indicator
            Me.Cursor = Cursors.WaitCursor
            If lblSubtitle IsNot Nothing Then
                lblSubtitle.Text = "Loading records..."
            End If

            openConn()
            LoadProductCaches()
            ' Get ALL the data first (we'll paginate after aggregation)
            Dim sql As String = BuildDataQuery()
            Dim cmd As New MySqlCommand(sql, conn)
            AddQueryParameters(cmd)

            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(dt)

            ' Process and aggregate the data FIRST
            Dim aggregatedData As DataTable = AggregateOrderData(dt)

            ' NOW apply pagination to the aggregated results
            totalRecords = aggregatedData.Rows.Count
            totalPages = Math.Ceiling(totalRecords / pageSize)

            ' Get only the current page of aggregated data
            Dim pagedData As DataTable = aggregatedData.Clone()
            Dim startIndex As Integer = (currentPage - 1) * pageSize
            Dim endIndex As Integer = Math.Min(startIndex + pageSize, aggregatedData.Rows.Count)

            For i As Integer = startIndex To endIndex - 1
                pagedData.ImportRow(aggregatedData.Rows(i))
            Next

            dgvUsageHistory.DataSource = pagedData
            FormatGrid()
            ColorCodeGrid()

            UpdatePaginationInfo()

        Catch ex As Exception
            MessageBox.Show("Error loading usage history: " & ex.Message,
                          "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            closeConn()
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Function BuildCountQuery() As String
        Dim sql As String = "
            SELECT COUNT(DISTINCT CONCAT(
                COALESCE(iml.OrderID, ''), 
                '-', 
                COALESCE(iml.ReservationID, ''),
                '-',
                DATE(iml.MovementDate)
            ))
            FROM inventory_movement iml
            INNER JOIN ingredients i ON iml.IngredientID = i.IngredientID
            LEFT JOIN ingredient_categories ic ON i.CategoryID = ic.CategoryID
            WHERE iml.ChangeType = 'DEDUCT'
            AND DATE(iml.MovementDate) BETWEEN @startDate AND @endDate
        "

        ' Add source filter
        If cmbSource.SelectedIndex > 0 Then
            sql &= " AND (
                (iml.OrderID IS NOT NULL AND EXISTS (
                    SELECT 1 FROM `orders` o WHERE o.OrderID = iml.OrderID AND o.OrderSource = @source
                ))
                OR (iml.ReservationID IS NOT NULL AND @source = 'WEBSITE')
                OR (iml.OrderID IS NULL AND iml.ReservationID IS NULL AND iml.Source = @source)
            )"
        End If

        ' Add search filter
        If Not String.IsNullOrWhiteSpace(txtSearch.Text) Then
            sql &= " AND (i.IngredientName LIKE @search 
                     OR ic.CategoryName LIKE @search)"
        End If

        Return sql
    End Function

    Private Function BuildDataQuery() As String
        Dim sql As String = "
            SELECT 
                iml.MovementDate,
                iml.OrderID,
                iml.ReservationID,
                CASE 
                    WHEN iml.OrderID IS NOT NULL THEN 
                        COALESCE((SELECT o.OrderSource FROM `orders` o WHERE o.OrderID = iml.OrderID), iml.Source)
                    WHEN iml.ReservationID IS NOT NULL THEN 'WEBSITE'
                    ELSE iml.Source
                END AS Source,
                i.IngredientName,
                ic.CategoryName,
                iml.QuantityChanged,
                iml.UnitType,
                iml.Reason
            FROM inventory_movement iml
            INNER JOIN ingredients i ON iml.IngredientID = i.IngredientID
            LEFT JOIN ingredient_categories ic ON i.CategoryID = ic.CategoryID
            WHERE iml.ChangeType = 'DEDUCT'
            AND DATE(iml.MovementDate) BETWEEN @startDate AND @endDate
        "

        ' Add source filter
        If cmbSource.SelectedIndex > 0 Then
            sql &= " AND (
                (iml.OrderID IS NOT NULL AND EXISTS (
                    SELECT 1 FROM `orders` o WHERE o.OrderID = iml.OrderID AND o.OrderSource = @source
                ))
                OR (iml.ReservationID IS NOT NULL AND @source = 'WEBSITE')
                OR (iml.OrderID IS NULL AND iml.ReservationID IS NULL AND iml.Source = @source)
            )"
        End If

        ' Add search filter
        If Not String.IsNullOrWhiteSpace(txtSearch.Text) Then
            sql &= " AND (i.IngredientName LIKE @search 
                     OR ic.CategoryName LIKE @search)"
        End If

        sql &= " ORDER BY iml.MovementDate DESC"

        Return sql
    End Function

    Private Sub AddQueryParameters(cmd As MySqlCommand)
        cmd.Parameters.AddWithValue("@startDate", dtpStartDate.Value.Date)
        cmd.Parameters.AddWithValue("@endDate", dtpEndDate.Value.Date)

        If cmbSource.SelectedIndex > 0 Then
            cmd.Parameters.AddWithValue("@source", cmbSource.Text)
        End If

        If Not String.IsNullOrWhiteSpace(txtSearch.Text) Then
            cmd.Parameters.AddWithValue("@search", "%" & txtSearch.Text & "%")
        End If
    End Sub

    Private Function AggregateOrderData(sourceData As DataTable) As DataTable
        Dim aggregatedTable As New DataTable()

        aggregatedTable.Columns.Add("Date & Time", GetType(DateTime))

        aggregatedTable.Columns.Add("Products", GetType(String))
        aggregatedTable.Columns.Add("Ingredients Used", GetType(String))
        aggregatedTable.Columns.Add("Total Quant...", GetType(String))
        aggregatedTable.Columns.Add("Source", GetType(String))

        ' ✅ GROUP BY ONE STABLE KEY PER ORDER / RESERVATION / ADMIN ACTION
        Dim groupedData = From row In sourceData.AsEnumerable()
                          Let orderKey =
                          If(Not IsDBNull(row("OrderID")) AndAlso row("OrderID").ToString() <> "",
                             "ORDER-" & row("OrderID").ToString(),
                             If(Not IsDBNull(row("ReservationID")) AndAlso row("ReservationID").ToString() <> "",
                                "RES-" & row("ReservationID").ToString(),
                                "ADMIN-" & CDate(row("MovementDate")).ToString("yyyyMMddHHmmss")))
                          Group row By orderKey Into Group

        For Each orderGroup In groupedData
            Dim newRow As DataRow = aggregatedTable.NewRow()

            ' Latest movement date
            Dim latestRow = orderGroup.Group _
            .OrderByDescending(Function(r) CDate(r("MovementDate"))) _
            .First()

            newRow("Date & Time") = CDate(latestRow("MovementDate"))
            newRow("Source") = latestRow("Source").ToString()

            Dim products As String

            If orderGroup.orderKey.StartsWith("ORDER-") Then
                Dim idStr As String = orderGroup.orderKey.Replace("ORDER-", "")
                If Integer.TryParse(idStr, Nothing) Then
                    Dim orderId As Integer = CInt(idStr)
                    products = GetOrderProducts(orderId)
                Else
                    products = "N/A"
                End If
            ElseIf orderGroup.orderKey.StartsWith("RES-") Then
                Dim idStr As String = orderGroup.orderKey.Replace("RES-", "")
                If Integer.TryParse(idStr, Nothing) Then
                    Dim resId As Integer = CInt(idStr)
                    products = GetReservationProducts(resId)
                Else
                    products = "N/A"
                End If
            Else
                ' ADMIN / SYSTEM manual adjustment - no order/reservation
                products = "Manual Adjustment"
            End If

            Dim ingredientCount As Integer = 0
            Dim ingredients As String =
            GetIngredientsUsedBulletList(orderGroup.Group, ingredientCount)

            newRow("Products") = products
            newRow("Ingredients Used") = ingredients
            newRow("Total Quant...") = $"{ingredientCount} items"

            aggregatedTable.Rows.Add(newRow)
        Next

        Dim view As DataView = aggregatedTable.DefaultView
        view.Sort = "[Date & Time] DESC"
        Return view.ToTable()
    End Function

    Private Function GetOrderProducts(orderID As Integer) As String
        If orderProductsCache.ContainsKey(orderID) Then
            Return orderProductsCache(orderID)
        End If
        Return "N/A"
    End Function

    Private Function GetReservationProducts(reservationID As Integer) As String
        If reservationProductsCache.ContainsKey(reservationID) Then
            Return reservationProductsCache(reservationID)
        End If
        Return "N/A"
    End Function

    Private Function GetIngredientsUsedBulletList(ingredientsData As IEnumerable(Of DataRow), ByRef totalCount As Integer) As String
        Dim ingredientsList As New List(Of String)

        ' Group ingredients by name to combine quantities if same ingredient appears multiple times
        Dim groupedIngredients = From row In ingredientsData
                                 Group row By IngredientName = row("IngredientName").ToString() Into Group
                                 Select New With {
                                     .Name = IngredientName,
                                     .TotalQty = Group.Sum(Function(r) Math.Abs(CDec(r("QuantityChanged")))),
                                     .Unit = Group.First()("UnitType").ToString(),
                                     .Category = If(IsDBNull(Group.First()("CategoryName")), "Uncategorized", Group.First()("CategoryName").ToString())
                                 }

        For Each ingredient In groupedIngredients
            ' Format: • Ingredient Name (Quantity Unit) [Category]
            ingredientsList.Add($"• {ingredient.Name} ({ingredient.TotalQty} {ingredient.Unit}) [{ingredient.Category}]")
            totalCount += 1
        Next

        Return If(ingredientsList.Count > 0, String.Join(vbCrLf, ingredientsList), "N/A")
    End Function

    Private Sub FormatGrid()
        Try
            With dgvUsageHistory
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                .RowTemplate.Height = 45
                .DefaultCellStyle.Font = New Font("Segoe UI", 9)
                .DefaultCellStyle.Padding = New Padding(8, 4, 8, 4)
                .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
                .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250)
                .ReadOnly = True
                .AllowUserToAddRows = False
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

                ' Set column widths
                If .Columns.Contains("Date & Time") Then
                    .Columns("Date & Time").FillWeight = 15
                End If

                If .Columns.Contains("Products") Then
                    .Columns("Products").FillWeight = 30
                End If

                If .Columns.Contains("Ingredients Used") Then
                    .Columns("Ingredients Used").FillWeight = 35
                End If

                If .Columns.Contains("Total Quant...") Then
                    .Columns("Total Quant...").FillWeight = 10
                End If

                If .Columns.Contains("Source") Then
                    .Columns("Source").FillWeight = 10
                End If

            End With

        Catch ex As Exception
            ' Silent fail
        End Try
    End Sub

    Private Sub ColorCodeGrid()
        Try
            For Each row As DataGridViewRow In dgvUsageHistory.Rows
                If Not row.IsNewRow Then
                    If row.Cells("Source").Value IsNot Nothing Then
                        Dim source As String = row.Cells("Source").Value.ToString()

                        Select Case source.ToUpper()
                            Case "POS"
                                row.Cells("Source").Style.BackColor = Color.FromArgb(23, 162, 184)
                                row.Cells("Source").Style.ForeColor = Color.White

                            Case "WEBSITE"
                                row.Cells("Source").Style.BackColor = Color.FromArgb(111, 66, 193)
                                row.Cells("Source").Style.ForeColor = Color.White

                            Case "ADMIN"
                                row.Cells("Source").Style.BackColor = Color.FromArgb(253, 126, 20)
                                row.Cells("Source").Style.ForeColor = Color.White
                        End Select
                    End If
                End If
            Next

        Catch ex As Exception
            ' Silent fail
        End Try
    End Sub

    Private Sub UpdatePaginationInfo()
        If lblSubtitle IsNot Nothing Then
            Dim startRecord As Integer = (currentPage - 1) * pageSize + 1
            Dim endRecord As Integer = Math.Min(currentPage * pageSize, totalRecords)

            lblSubtitle.Text = $"Showing {startRecord}-{endRecord} of {totalRecords} records (Page {currentPage} of {totalPages})"
        End If

        UpdatePaginationControls()
    End Sub

    Private Sub UpdatePaginationControls()
        ' Enable/disable navigation buttons
        If btnFirstPage IsNot Nothing Then btnFirstPage.Enabled = (currentPage > 1)
        If btnPreviousPage IsNot Nothing Then btnPreviousPage.Enabled = (currentPage > 1)
        If btnNextPage IsNot Nothing Then btnNextPage.Enabled = (currentPage < totalPages)
        If btnLastPage IsNot Nothing Then btnLastPage.Enabled = (currentPage < totalPages)

        If lblPageInfo IsNot Nothing Then
            lblPageInfo.Text = $"Page {currentPage} of {totalPages}"
        End If
    End Sub

    Private Sub btnFirstPage_Click(sender As Object, e As EventArgs) Handles btnFirstPage.Click
        currentPage = 1
        LoadUsageHistory()
    End Sub

    Private Sub btnPreviousPage_Click(sender As Object, e As EventArgs) Handles btnPreviousPage.Click
        If currentPage > 1 Then
            currentPage -= 1
            LoadUsageHistory()
        End If
    End Sub

    Private Sub btnNextPage_Click(sender As Object, e As EventArgs) Handles btnNextPage.Click
        If currentPage < totalPages Then
            currentPage += 1
            LoadUsageHistory()
        End If
    End Sub

    Private Sub btnLastPage_Click(sender As Object, e As EventArgs) Handles btnLastPage.Click
        currentPage = totalPages
        LoadUsageHistory()
    End Sub

    Private Sub cmbPageSize_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPageSize.SelectedIndexChanged
        If cmbPageSize.SelectedItem IsNot Nothing Then
            pageSize = CInt(cmbPageSize.SelectedItem)
            currentPage = 1
            LoadUsageHistory()
        End If
    End Sub

    Private Sub btnApplyFilters_Click(sender As Object, e As EventArgs) Handles btnApplyFilters.Click
        currentPage = 1
        LoadUsageHistory()
    End Sub

    Private Sub btnResetFilters_Click(sender As Object, e As EventArgs) Handles btnResetFilters.Click
        dtpStartDate.Value = Date.Now.AddDays(-7)
        dtpEndDate.Value = Date.Now
        cmbSource.SelectedIndex = 0
        txtSearch.Clear()
        currentPage = 1
        LoadUsageHistory()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadUsageHistory()
    End Sub

    Private Sub btnClearHistory_Click(sender As Object, e As EventArgs) Handles btnClearHistory.Click
        Try
            Dim result As DialogResult = MessageBox.Show(
                "Are you sure you want to clear the ingredient usage history?" & vbCrLf & vbCrLf &
                "This will permanently delete all deduction records from the inventory movement log." & vbCrLf &
                "This action CANNOT be undone!" & vbCrLf & vbCrLf &
                "Note: This only clears the usage history log. Your current inventory levels will NOT be affected.",
                "Confirm Clear History",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning)

            If result <> DialogResult.Yes Then Return

            Dim confirmResult As DialogResult = MessageBox.Show(
                "FINAL CONFIRMATION" & vbCrLf & vbCrLf &
                "This will delete ALL ingredient usage records!" & vbCrLf &
                "Are you absolutely sure?",
                "Final Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation)

            If confirmResult <> DialogResult.Yes Then Return

            openConn()

            Dim sql As String = "DELETE FROM inventory_movement WHERE ChangeType = 'DEDUCT'"
            Dim cmd As New MySqlCommand(sql, conn)
            Dim rowsDeleted As Integer = cmd.ExecuteNonQuery()

            MessageBox.Show(
                rowsDeleted & " usage records cleared successfully!" & vbCrLf & vbCrLf &
                "Your current inventory levels remain unchanged.",
                "History Cleared",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)

            currentPage = 1
            LoadUsageHistory()

        Catch ex As Exception
            MessageBox.Show("Error clearing history: " & ex.Message,
                          "Clear Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            closeConn()
        End Try
    End Sub
    Private Async Sub ProductIngredientUsageHistory_Shown(
    sender As Object, e As EventArgs
) Handles Me.Shown

        lblSubtitle.Text = "Loading usage history..."
        Me.Cursor = Cursors.WaitCursor

        Await Task.Run(Sub() LoadUsageHistorySafe())

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LoadUsageHistorySafe()
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf LoadUsageHistory))
        Else
            LoadUsageHistory()
        End If
    End Sub

    ' -------------------------------------------------------
    ' DISCARD LOG LOADER
    ' -------------------------------------------------------
    Private Sub LoadDiscardHistory()
        Try
            Me.Cursor = Cursors.WaitCursor
            lblSubtitle.Text = "Loading discard records..."

            openConn()

            Dim sql As String = "
                SELECT
                    iml.MovementDate        AS 'Date & Time',
                    i.IngredientName        AS 'Ingredient',
                    iml.ReferenceNumber     AS 'Batch No.',
                    ABS(iml.QuantityChanged) AS 'Qty Discarded',
                    iml.UnitType            AS 'Unit',
                    iml.Reason              AS 'Reason',
                    iml.Source              AS 'Source',
                    iml.Notes               AS 'Notes'
                FROM inventory_movement iml
                INNER JOIN ingredients i ON iml.IngredientID = i.IngredientID
                WHERE iml.ChangeType = 'DISCARD'
                  AND DATE(iml.MovementDate) BETWEEN @startDate AND @endDate
            "

            ' Source filter
            If cmbSource.SelectedIndex > 0 Then
                sql &= " AND iml.Source = @source"
            End If

            ' Ingredient search filter
            If Not String.IsNullOrWhiteSpace(txtSearch.Text) Then
                sql &= " AND (i.IngredientName LIKE @search OR iml.ReferenceNumber LIKE @search OR iml.Reason LIKE @search)"
            End If

            sql &= " ORDER BY iml.MovementDate DESC"

            Dim cmd As New MySqlCommand(sql, conn)
            cmd.Parameters.AddWithValue("@startDate", dtpStartDate.Value.Date)
            cmd.Parameters.AddWithValue("@endDate", dtpEndDate.Value.Date)
            If cmbSource.SelectedIndex > 0 Then
                cmd.Parameters.AddWithValue("@source", cmbSource.Text)
            End If
            If Not String.IsNullOrWhiteSpace(txtSearch.Text) Then
                cmd.Parameters.AddWithValue("@search", "%" & txtSearch.Text & "%")
            End If

            Dim da As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable()
            da.Fill(dt)

            dgvDiscardHistory.DataSource = dt
            FormatDiscardGrid()

            Dim count As Integer = dt.Rows.Count
            lblSubtitle.Text = $"{count} discard record(s) — {dtpStartDate.Value:MMM dd} to {dtpEndDate.Value:MMM dd, yyyy}"

        Catch ex As Exception
            MessageBox.Show("Error loading discard history: " & ex.Message,
                          "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            closeConn()
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub FormatDiscardGrid()
        Try
            With dgvDiscardHistory
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                .RowTemplate.Height = 38
                .DefaultCellStyle.Font = New Font("Segoe UI", 9)
                .DefaultCellStyle.Padding = New Padding(6, 3, 6, 3)
                .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(255, 245, 245)
                .ReadOnly = True
                .AllowUserToAddRows = False
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

                If .Columns.Contains("Date & Time") Then
                    .Columns("Date & Time").FillWeight = 15
                    .Columns("Date & Time").DefaultCellStyle.Format = "MMM dd, yyyy HH:mm"
                End If
                If .Columns.Contains("Ingredient") Then .Columns("Ingredient").FillWeight = 20
                If .Columns.Contains("Batch No.") Then .Columns("Batch No.").FillWeight = 12
                If .Columns.Contains("Qty Discarded") Then
                    .Columns("Qty Discarded").FillWeight = 10
                    .Columns("Qty Discarded").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns("Qty Discarded").DefaultCellStyle.Format = "0.##"
                End If
                If .Columns.Contains("Unit") Then .Columns("Unit").FillWeight = 8
                If .Columns.Contains("Reason") Then .Columns("Reason").FillWeight = 20
                If .Columns.Contains("Source") Then .Columns("Source").FillWeight = 8
                If .Columns.Contains("Notes") Then .Columns("Notes").FillWeight = 15
            End With

            ' Color-code rows: red for discard
            For Each row As DataGridViewRow In dgvDiscardHistory.Rows
                If Not row.IsNewRow Then
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(139, 0, 0)
                    If row.Cells("Source") IsNot Nothing AndAlso row.Cells("Source").Value IsNot Nothing Then
                        Dim src = row.Cells("Source").Value.ToString().ToUpper()
                        Select Case src
                            Case "ADMIN"
                                row.Cells("Source").Style.BackColor = Color.FromArgb(253, 126, 20)
                                row.Cells("Source").Style.ForeColor = Color.White
                            Case "SYSTEM"
                                row.Cells("Source").Style.BackColor = Color.FromArgb(108, 117, 125)
                                row.Cells("Source").Style.ForeColor = Color.White
                        End Select
                    End If
                End If
            Next

        Catch ex As Exception
            ' Silent fail
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        ' Optional: Add auto-search with debouncing
    End Sub
End Class