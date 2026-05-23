Imports MySqlConnector   ' ✔ Correct library for your modDB module

Public Class Adminlogin

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        ' Optional
    End Sub

    Private Sub Back1_Click(sender As Object, e As EventArgs)
        ' Close the application when Back is clicked
        Application.Exit()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        ' Optional
    End Sub

    Private Sub Adminlogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize database tables
        CheckAndCreateTables()
    End Sub

    Private Sub lblNoAccount_Click(sender As Object, e As EventArgs) Handles lblNoAccount.Click
        Dim createAcc As New CreateAccount()
        createAcc.StartPosition = FormStartPosition.CenterScreen
        createAcc.Show()
        Me.Hide()
    End Sub

    ' 🔐 ADMIN LOGIN BUTTON
    Private Sub adminlog_Click(sender As Object, e As EventArgs) Handles adminlog.Click
        ' ---- VALIDATION ----
        If txtUsername.Text.Trim() = "" Then
            MessageBox.Show("Please enter your username.", "Missing Field",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUsername.Focus()
            Exit Sub
        End If

        If txtPassword.Text.Trim() = "" Then
            MessageBox.Show("Please enter your password.", "Missing Field",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPassword.Focus()
            Exit Sub
        End If

        Dim user As String = txtUsername.Text.Trim()
        Dim pass As String = txtPassword.Text.Trim()

        ' Try plain-text first, then encrypted (handles both storage formats)
        Dim encryptedPass As String = ""
        Try
            encryptedPass = Encrypt(pass)
        Catch
            encryptedPass = pass
        End Try

        ' Query fetches the row by username only, then we verify password in code
        Dim query As String = "SELECT * FROM user_accounts WHERE username=@user AND status = 'Active' AND type=1 LIMIT 1"

        Try
            openConn()
            cmd = New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@user", user)

            Dim reader = cmd.ExecuteReader()

            If reader.Read() Then
                ' Read the stored password and verify
                Dim storedPassword As String = reader("password").ToString()

                ' Accept if plain-text match OR encrypted match
                Dim passwordMatches As Boolean = (pass = storedPassword) OrElse (encryptedPass = storedPassword)

                ' Also try decrypting stored password and comparing (legacy fallback)
                If Not passwordMatches Then
                    Try
                        Dim decrypted As String = Decrypt(storedPassword)
                        If pass = decrypted Then passwordMatches = True
                    Catch
                        ' Ignore decryption error
                    End Try
                End If

                If Not passwordMatches Then
                    reader.Close()
                    conn.Close()
                    GoTo LoginFailed
                End If

                ' Store logged user using original schema columns
                CurrentLoggedUser.id = reader("id")
                CurrentLoggedUser.name = reader("name").ToString()
                CurrentLoggedUser.username = reader("username").ToString()
                CurrentLoggedUser.password = storedPassword
                CurrentLoggedUser.type = reader("type")

                ' Check status
                Dim status As String = "Active"
                Try
                    If Not IsDBNull(reader("status")) Then
                        status = reader("status").ToString()
                    End If
                Catch
                    ' Column might not exist yet or error reading it
                End Try

                If status = "Resigned" OrElse status = "InActive" Then
                    MessageBox.Show("Your account is deactivated or resigned. Access denied.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    reader.Close()
                    conn.Close()
                    Exit Sub
                End If

                reader.Close()
                conn.Close()

                ' ✅ OLD LOGGING SYSTEM (Keep this if you want)
                Logs("Admin logged in", "Login")

                ' ✅✅ NEW ACTIVITY LOGGING SYSTEM
                ActivityLogger.LogUserActivity(
                    "User Login",
                    "Login",
                    $"{CurrentLoggedUser.name} successfully logged into the Admin Panel",
                    "Admin Panel"
                )

                ' Open dashboard
                Dim dashboard As New AdminDashboard()
                dashboard.StartPosition = FormStartPosition.CenterScreen
                dashboard.WindowState = FormWindowState.Maximized
                dashboard.Show()
                Me.Hide()
                Exit Sub
            End If

            reader.Close()
            conn.Close()

LoginFailed:
            ' ❌ LOG FAILED LOGIN ATTEMPT
            ActivityLogger.LogActivity(
                "Admin",
                Nothing,
                user,
                "Failed Login Attempt",
                "Login",
                $"Failed admin login attempt for username: {user}",
                "Admin Panel",
                Nothing,
                Nothing,
                Nothing,
                Nothing,
                "Failed"
            )

            MessageBox.Show("Invalid username or password.",
                            "Login Failed",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)

        Catch ex As Exception
            ' ❌ LOG EXCEPTION/ERROR
            ActivityLogger.LogActivity(
                "Admin",
                Nothing,
                user,
                "Login Error",
                "Login",
                $"Admin login error occurred: {ex.Message}",
                "Admin Panel",
                Nothing, Nothing, Nothing, Nothing,
                "Failed"
            )

            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub AdminLogin_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Application.Exit()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)
    End Sub

    ' ⚙ DB CONFIGURATION BUTTON
    Private Sub btnConfig_Click(sender As Object, e As EventArgs) Handles btnConfig.Click
        Try
            Dim configPage As New ConfigurationPage()
            configPage.StartPosition = FormStartPosition.CenterScreen
            configPage.Show()
            Me.Hide()
        Catch ex As Exception
            MessageBox.Show("Error opening configuration: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class