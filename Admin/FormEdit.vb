Imports MySqlConnector

Public Class FormEdit
    Public Property UserID As Integer = 0
    Public Property LinkedEmployeeID As Integer = 0

    Private Sub FormEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RoundButton(btnCancel)
        chkShowPass.Checked = True
    End Sub
    

    Public Sub LoadUserData(empId As Integer, username As String, role As String)
        LinkedEmployeeID = empId
        txtUsername.Text = username
        
        If UserID > 0 Then
             LoadEmployeeDetails(empId)
             
             ' Fetch and decrypt password
             Try
                 openConn()
                 Dim passQuery As String = "SELECT password FROM user_accounts WHERE id = @uid"
                 Dim passCmd As New MySqlCommand(passQuery, conn)
                 passCmd.Parameters.AddWithValue("@uid", UserID)
                 Dim cipherPass As Object = passCmd.ExecuteScalar()
                 
                 If cipherPass IsNot Nothing AndAlso cipherPass IsNot DBNull.Value Then
                     txtCurrentPassword.Text = Decrypt(cipherPass.ToString())
                 End If
             Catch ex As Exception
                 ' Ignore
             Finally
                 closeConn()
             End Try
        End If
    End Sub

    Private Sub LoadEmployeeDetails(empId As Integer)
        ' Fixed query to use CONCAT
        Try
            openConn()
            Dim sql As String = "SELECT CONCAT(FirstName, ' ', LastName) as Name FROM employee WHERE EmployeeID = @eid"
            Dim subCmd As New MySqlCommand(sql, conn)
            subCmd.Parameters.AddWithValue("@eid", empId)
            Dim result = subCmd.ExecuteScalar()
            
            If result IsNot Nothing Then
                txtFullName.Text = result.ToString()
            End If
        Catch ex As Exception
            MsgBox("Error loading details: " & ex.Message)
        Finally
            closeConn()
        End Try
    End Sub

    Private Sub chkShowPass_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowPass.CheckedChanged
        If chkShowPass.Checked Then
            txtCurrentPassword.PasswordChar = ControlChars.NullChar
            txtNewPassword.PasswordChar = ControlChars.NullChar
        Else
            txtCurrentPassword.PasswordChar = "*"c
            txtNewPassword.PasswordChar = "*"c
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub

    Private Sub RoundButton(btn As Button)
        Dim radius As Integer = 10
        Dim path As New Drawing2D.GraphicsPath()
        path.StartFigure()
        path.AddArc(New Rectangle(0, 0, radius, radius), 180, 90)
        path.AddArc(New Rectangle(btn.Width - radius, 0, radius, radius), 270, 90)
        path.AddArc(New Rectangle(btn.Width - radius, btn.Height - radius, radius, radius), 0, 90)
        path.AddArc(New Rectangle(0, btn.Height - radius, radius, radius), 90, 90)
        path.CloseFigure()
        btn.Region = New Region(path)
    End Sub
End Class
