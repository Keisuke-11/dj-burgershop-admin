Imports MySqlConnector

Public Class ActivityLogger
    Public Shared Sub LogActivity(userType As String, userID As Integer?, username As String,
                                   action As String, actionCategory As String, description As String,
                                   sourceSystem As String, Optional referenceID As String = Nothing,
                                   Optional referenceTable As String = Nothing,
                                   Optional oldValue As String = Nothing, Optional newValue As String = Nothing,
                                   Optional status As String = "Success")
        Try
            Using conn As New MySqlConnection(modDB.strConnection)
                conn.Open()

                ' Align with burger_system schema: LogID, UserID, Action, TableName, RecordID, LogDate, Details
                Dim query As String = "INSERT INTO activity_logs (UserID, Action, TableName, RecordID, LogDate, Details) " &
                                      "VALUES (@UserID, @Action, @TableName, @RecordID, NOW(), @Details)"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@UserID", If(userID.HasValue, CObj(userID.Value), DBNull.Value))
                    cmd.Parameters.AddWithValue("@Action", action)
                    cmd.Parameters.AddWithValue("@TableName", If(String.IsNullOrEmpty(referenceTable), DBNull.Value, CObj(referenceTable)))
                    cmd.Parameters.AddWithValue("@RecordID", If(String.IsNullOrEmpty(referenceID), DBNull.Value, CObj(referenceID)))
                    cmd.Parameters.AddWithValue("@Details", description)

                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            ' Silent fail - don't interrupt operations
            Try
                System.IO.File.AppendAllText("activity_log_errors.txt",
                    $"{DateTime.Now}: {ex.Message}{Environment.NewLine}")
            Catch
                ' Ignore file write errors
            End Try
        End Try
    End Sub

    ' Simplified method using current logged user from modDB
    Public Shared Sub LogUserActivity(action As String, actionCategory As String, description As String,
                                      sourceSystem As String, Optional referenceID As String = Nothing,
                                      Optional referenceTable As String = Nothing,
                                      Optional oldValue As String = Nothing, Optional newValue As String = Nothing,
                                      Optional status As String = "Success")
        Try
            Dim userType As String = "Staff" ' Default
            Dim userID As Integer? = modDB.CurrentLoggedUser.id
            Dim username As String = modDB.CurrentLoggedUser.name

            ' ✅ FIX: Determine user type based on the type field from user_accounts table
            ' type = 1 means Admin
            ' type = 2 means Staff
            Select Case modDB.CurrentLoggedUser.type
                Case 1
                    userType = "Admin"   ' ✅ Admin user
                Case 2
                    userType = "Staff"   ' ✅ Staff user
                Case Else
                    userType = "Staff"   ' Default to Staff for unknown types
            End Select

            LogActivity(userType, userID, username, action, actionCategory, description,
                       sourceSystem, referenceID, referenceTable, oldValue, newValue, status)
        Catch ex As Exception
            ' Silent fail
            Try
                System.IO.File.AppendAllText("activity_log_errors.txt",
                    $"{DateTime.Now}: LogUserActivity Error - {ex.Message}{Environment.NewLine}")
            Catch
                ' Ignore
            End Try
        End Try
    End Sub
End Class