Imports MySqlConnector

Public Class CreateAccount
    Public Property LinkedEmployeeID As Integer = 0

    Private Sub CreateAccount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RoundButton(btnCreate)
        RoundButton(btnCancel)
        chkShowPass.Checked = True

        ' Ensure "Admin" is available in the role dropdown
        If Not cmbRole.Items.Contains("Admin") Then
            cmbRole.Items.Add("Admin")
        End If
    End Sub

    Private Sub lblAlreadyHave_Click(sender As Object, e As EventArgs) Handles lblAlreadyHave.Click
        Dim loginForm As New Adminlogin()
        loginForm.StartPosition = FormStartPosition.CenterScreen
        loginForm.Show()
        Me.Hide()
    End Sub

    Public Sub LoadEmployeeData(id As Integer, name As String, role As String, email As String)
        LinkedEmployeeID = id
        txtFullName.Text = name

        ' Use email as username, fallback to EmployeeID if no email is provided
        txtUsername.Text = If(Not String.IsNullOrEmpty(email), email.Trim(), "user_" & id)

        ' Show username as read-only so the user knows the login username
        LabelUser.Visible = True
        txtUsername.Visible = True
        txtUsername.Enabled = False

        ' No longer shifting controls since username is now visible

        ' Ensure the "Admin" role is dynamically loaded before attempting to select it
        If Not cmbRole.Items.Contains("Admin") Then
            cmbRole.Items.Add("Admin")
        End If

        If role = "Admin" Then
            cmbRole.SelectedItem = "Admin"
        ElseIf role = "Staff" OrElse role = "Employee" Then
            cmbRole.SelectedItem = role
        Else
            cmbRole.SelectedItem = "Employee"
        End If

        ' Lock name as it comes from employee record
        txtFullName.Enabled = False
    End Sub

    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        ' Validation
        Dim name As String = txtFullName.Text.Trim()
        Dim username As String = txtUsername.Text.Trim()
        Dim password As String = txtPassword.Text.Trim()
        Dim role As String = If(cmbRole.SelectedItem IsNot Nothing, cmbRole.SelectedItem.ToString(), "")

        If String.IsNullOrEmpty(name) OrElse String.IsNullOrEmpty(username) OrElse String.IsNullOrEmpty(password) OrElse String.IsNullOrEmpty(role) Then
            MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            openConn()

            ' Check duplicate username
            Dim checkSql As String = "SELECT COUNT(*) FROM user_accounts WHERE username = @user"
            Dim checkCmd As New MySqlCommand(checkSql, conn)
            checkCmd.Parameters.AddWithValue("@user", username)
            Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

            If count > 0 Then
                MessageBox.Show("Username already exists. Please choose another.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Insert
            ' Type mapping: 1 = Admin, 2 = Staff/Employee
            Dim userType As Integer
            Select Case role
                Case "Admin"
                    userType = 1  ' ✅ Admin = type 1
                Case "Staff"
                    userType = 2  ' ✅ Staff = type 2
                Case "Employee"
                    userType = 2  ' ✅ Employee = type 2
                Case Else
                    userType = 2  ' Default to Staff
            End Select
            Dim loginPass As String = password

            Dim sql As String = "INSERT INTO user_accounts (employee_id, name, username, password, type, position, status, created_at) " &
                                "VALUES (@eid, @name, @user, @pass, @type, @position, 'Active', NOW())"

            Dim cmd As New MySqlCommand(sql, conn)
            cmd.Parameters.AddWithValue("@eid", LinkedEmployeeID)
            cmd.Parameters.AddWithValue("@name", name)
            cmd.Parameters.AddWithValue("@user", username)
            cmd.Parameters.AddWithValue("@pass", loginPass)
            cmd.Parameters.AddWithValue("@type", userType)
            cmd.Parameters.AddWithValue("@position", role)

            cmd.ExecuteNonQuery()

            Dim loginDestination As String = If(userType = 1, "Admin Panel", "POS system")
            MessageBox.Show("Account created successfully!" & vbCrLf & vbCrLf &
                           "Login Credentials:" & vbCrLf &
                           "Username: " & username & vbCrLf &
                           "Password: " & password & vbCrLf & vbCrLf &
                           "Use these credentials to log in to the " & loginDestination & ".",
                           "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DialogResult = DialogResult.OK
            Close()

        Catch ex As Exception
            MessageBox.Show("Error creating account: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            closeConn()
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub

    Private Sub chkShowPass_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowPass.CheckedChanged
        If chkShowPass.Checked Then
            txtPassword.PasswordChar = ControlChars.NullChar
        Else
            txtPassword.PasswordChar = "*"c
        End If
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

    Private Sub cmbRole_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRole.SelectedIndexChanged

    End Sub
End Class