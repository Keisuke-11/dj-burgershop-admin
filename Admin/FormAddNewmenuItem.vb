Imports System.IO
Imports System.Net
Imports MySqlConnector

Public Class FormAddNewmenuItem

    ' ========== CONSTANTS ==========
    Private Const WEB_BASE_PATH As String = "uploads/products/"
    Private Const WEB_BASE_URL As String = "http://localhost/TrialWorkIM-main/docs/OrderPicture/"

    ' ========== VARIABLES ==========
    Private SelectedImagePath As String = Nothing
    Private SelectedImageBytes As Byte() = Nothing

    ' ========== DYNAMIC UPLOAD FOLDER ==========
    Private Function GetUploadsFolder() As String
        Dim possibleRoots As String() = {
            "C:\xampp", "C:\XAMPP",
            "D:\xampp", "D:\XAMPP",
            "E:\xampp", "E:\XAMPP"
        }
        For Each root As String In possibleRoots
            If Directory.Exists(root) Then
                Return Path.Combine(root, "htdocs\TrialWorkIM-main\docs\OrderPicture\")
            End If
        Next
        Return Nothing
    End Function

    Private Sub FormAddNewmenuItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeForm()
        EnsureUploadFolderExists()
    End Sub

    ' ================================
    ' ENSURE UPLOAD FOLDER EXISTS
    ' ================================
    Private Sub EnsureUploadFolderExists()
        Try
            Dim folder As String = GetUploadsFolder()
            If folder IsNot Nothing AndAlso Not Directory.Exists(folder) Then
                Directory.CreateDirectory(folder)
            End If
        Catch ex As Exception
            MessageBox.Show("Warning: Could not create upload folder." & vbCrLf & ex.Message,
                          "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    ' ================================
    ' FORM INIT
    ' ================================
    Private Sub InitializeForm()
        Availability.Items.Clear()
        Availability.Items.Add("Available")
        Availability.Items.Add("Unavailable")
        Availability.SelectedIndex = 0

        cmbCategory.Items.Clear()
        cmbCategory.Items.AddRange({"Burgers", "Sides", "Silog Meals", "Drinks"})
        cmbCategory.SelectedIndex = -1

        cmbMealTime.Items.Clear()
        cmbMealTime.Items.AddRange({"All Day", "Breakfast", "Lunch", "Dinner"})
        cmbMealTime.SelectedIndex = 0

        numericPrice.DecimalPlaces = 2
        numericPrice.Maximum = 999999

        ProductID.ReadOnly = True
        ProductID.BackColor = Color.LightGray

        DateTimePicker1.Value = DateTime.Now
        DateTimePicker1.Enabled = False

        OrderCount.Text = "0"
        OrderCount.ReadOnly = True
        OrderCount.BackColor = Color.LightGray

        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.Image = Nothing
        PictureBox1.BorderStyle = BorderStyle.FixedSingle
        PictureBox1.Cursor = Cursors.Hand

        SelectedImagePath = Nothing
        SelectedImageBytes = Nothing
    End Sub

    ' ================================
    ' GENERATE NEXT PRODUCT ID
    ' ================================
    Private Function GenerateNextProductID() As String
        Try
            openConn()
            Dim query As String = "SELECT COALESCE(MAX(ProductID), 0) + 1 AS NextID FROM products"
            Dim cmd As New MySqlCommand(query, conn)
            Return cmd.ExecuteScalar().ToString()
        Catch ex As Exception
            Return "1"
        Finally
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Function

    ' ================================
    ' VALIDATE FORM
    ' ================================
    Private Function ValidateForm() As Boolean
        If txtProductName.Text.Trim() = "" Then
            Return ShowError(txtProductName, "Please enter a product name.")
        End If
        If cmbCategory.SelectedIndex = -1 Then
            Return ShowError(cmbCategory, "Please select a category.")
        End If
        If Description.Text.Trim() = "" Then
            Return ShowError(Description, "Please enter a description.")
        End If
        If numericPrice.Value <= 0 Then
            Return ShowError(numericPrice, "Price must be greater than 0.")
        End If
        If Availability.SelectedIndex = -1 Then
            Return ShowError(Availability, "Please select availability.")
        End If
        If ServingSize.Text.Trim() = "" Then
            Return ShowError(ServingSize, "Please enter serving size.")
        End If
        If PrepTime.Text.Trim() = "" Then
            Return ShowError(PrepTime, "Please enter preparation time.")
        End If
        If cmbMealTime.SelectedIndex = -1 Then
            Return ShowError(cmbMealTime, "Please select meal time.")
        End If
        Return True
    End Function

    Private Function ShowError(ctrl As Control, msg As String) As Boolean
        MessageBox.Show(msg, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ctrl.Focus()
        Return False
    End Function

    ' ================================
    ' BROWSE AND LOAD IMAGE
    ' ================================
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim ofd As New OpenFileDialog()
        ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif"
        ofd.Title = "Select Product Image"

        If ofd.ShowDialog() = DialogResult.OK Then
            Try
                SelectedImagePath = ofd.FileName
                SelectedImageBytes = File.ReadAllBytes(ofd.FileName)

                ' Display in PictureBox immediately
                Using ms As New MemoryStream(SelectedImageBytes)
                    Dim img As Image = Image.FromStream(ms)
                    PictureBox1.Image = img
                End Using

                MessageBox.Show("✓ Image selected! Click 'Add Item' to save.",
                              "Image Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Error loading image: " & ex.Message,
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                SelectedImagePath = Nothing
                SelectedImageBytes = Nothing
            End Try
        End If
    End Sub

    ' ================================
    ' SAVE IMAGE TO FILE SYSTEM
    ' ================================
    Private Function SaveImageToFileSystem(productId As String) As String
        If SelectedImageBytes Is Nothing Then Return Nothing

        Try
            Dim uploadsFolder As String = GetUploadsFolder()

            If String.IsNullOrEmpty(uploadsFolder) Then
                MessageBox.Show("❌ XAMPP htdocs folder not found.", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return Nothing
            End If

            ' Ensure folder exists
            If Not Directory.Exists(uploadsFolder) Then
                Directory.CreateDirectory(uploadsFolder)
            End If

            Dim timestamp As String = DateTime.Now.ToString("yyyyMMddHHmmss")
            Dim ext As String = If(String.IsNullOrEmpty(SelectedImagePath), ".jpg",
                                   Path.GetExtension(SelectedImagePath))

            Dim filename As String = $"product_{productId}_{timestamp}{ext}"
            Dim fullPath As String = Path.Combine(uploadsFolder, filename)

            File.WriteAllBytes(fullPath, SelectedImageBytes)

            ' Return relative web path for DB storage
            Return "docs/OrderPicture/" & filename

        Catch ex As Exception
            MessageBox.Show("Error saving image: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function

    ' ================================
    ' LOAD IMAGE FROM WEB URL INTO PICTUREBOX
    ' ================================
    Private Sub LoadProductImageFromUrl(imagePath As String)
        Try
            If String.IsNullOrEmpty(imagePath) Then
                PictureBox1.Image = Nothing
                Return
            End If

            Dim fullUrl As String = "http://localhost/TrialWorkIM-main/" & imagePath
            Dim webClient As New System.Net.WebClient()
            Dim imageBytes() As Byte = webClient.DownloadData(fullUrl)

            Using ms As New MemoryStream(imageBytes)
                PictureBox1.Image = Image.FromStream(ms)
            End Using

        Catch ex As Exception
            Console.WriteLine($"Failed to load image from URL: {ex.Message}")
            PictureBox1.Image = Nothing
        End Try
    End Sub

    ' ================================
    ' ADD ITEM BUTTON CLICK
    ' ================================
    Private Sub btnAddItem_Click(sender As Object, e As EventArgs) Handles btnAddItem.Click
        If Not ValidateForm() Then Exit Sub

        Try
            openConn()

            ' Insert product without image first
            Dim sql As String = "INSERT INTO products " &
                "(ProductName, Category, Description, Price, Availability, ServingSize, " &
                "DateAdded, LastUpdated, ProductCode, OrderCount, PrepTime, MealTime) " &
                "VALUES " &
                "(@ProductName, @Category, @Description, @Price, @Availability, @ServingSize, " &
                "NOW(), NOW(), @ProductCode, 0, @PrepTime, @MealTime)"

            Dim cmd As New MySqlCommand(sql, conn)
            cmd.Parameters.AddWithValue("@ProductName", txtProductName.Text.Trim())
            cmd.Parameters.AddWithValue("@Category", cmbCategory.Text.Trim())
            cmd.Parameters.AddWithValue("@Description", Description.Text.Trim())
            cmd.Parameters.AddWithValue("@Price", numericPrice.Value)
            cmd.Parameters.AddWithValue("@Availability", Availability.Text)
            cmd.Parameters.AddWithValue("@ServingSize", ServingSize.Text.Trim())
            cmd.Parameters.AddWithValue("@PrepTime", PrepTime.Text.Trim())
            cmd.Parameters.AddWithValue("@MealTime", cmbMealTime.Text)
            cmd.Parameters.AddWithValue("@ProductCode",
                If(ProductCode.Text.Trim() = "", DBNull.Value, ProductCode.Text.Trim()))

            cmd.ExecuteNonQuery()

            ' Get inserted ID
            Dim insertedId As Long = cmd.LastInsertedId

            ' Save image and update DB
            Dim savedImagePath As String = Nothing
            If SelectedImageBytes IsNot Nothing Then
                savedImagePath = SaveImageToFileSystem(insertedId.ToString())

                If savedImagePath IsNot Nothing Then
                    Dim updateSql As String = "UPDATE products SET Image = @Image WHERE ProductID = @ProductID"
                    Dim updateCmd As New MySqlCommand(updateSql, conn)
                    updateCmd.Parameters.AddWithValue("@Image", savedImagePath)
                    updateCmd.Parameters.AddWithValue("@ProductID", insertedId)
                    updateCmd.ExecuteNonQuery()

                    ' Reload image from web URL to confirm it works
                    LoadProductImageFromUrl(savedImagePath)
                End If
            End If

            MessageBox.Show("✓ Menu item saved successfully!" & vbCrLf &
                          "Product: " & txtProductName.Text & vbCrLf &
                          "Product ID: " & insertedId,
                          "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ActivityLogger.LogUserActivity(
                "Added New Menu Item",
                "Product",
                $"Added new menu item: {txtProductName.Text.Trim()} (ID: {insertedId})",
                "Admin Panel"
            )

            ClearForm()
            Me.DialogResult = DialogResult.OK

        Catch ex As Exception
            MessageBox.Show("❌ Error adding item: " & ex.Message & vbCrLf &
                          "Stack Trace: " & ex.StackTrace,
                          "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub

    ' ================================
    ' CLEAR FORM
    ' ================================
    Private Sub ClearForm()
        txtProductName.Text = ""
        cmbCategory.SelectedIndex = -1
        Description.Text = ""
        numericPrice.Value = 0
        ServingSize.Text = ""
        ProductCode.Text = ""
        PrepTime.Text = ""
        cmbMealTime.SelectedIndex = 0
        PictureBox1.Image = Nothing
        SelectedImageBytes = Nothing
        SelectedImagePath = Nothing
        ProductID.Text = GenerateNextProductID()
        txtProductName.Focus()
    End Sub

    ' ================================
    ' CLOSE BUTTON
    ' ================================
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dim result As DialogResult = MessageBox.Show(
            "Are you sure you want to close without saving?",
            "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    ' ================================
    ' FORM CLOSING - CLEANUP
    ' ================================
    Private Sub FormAddNewmenuItem_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If PictureBox1 IsNot Nothing AndAlso PictureBox1.Image IsNot Nothing Then
            PictureBox1.Image.Dispose()
            PictureBox1.Image = Nothing
        End If
    End Sub

End Class