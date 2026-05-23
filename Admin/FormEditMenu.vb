Imports MySqlConnector
Imports System.IO
Imports System.Drawing.Imaging

Public Class FormEditMenu

    Public SelectedProductID As Integer
    Private SelectedImageBytes As Byte() = Nothing
    Private OriginalImagePath As String = ""
    Private IsNewImageSelected As Boolean = False

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

    Private Sub FormEditMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeForm()
    End Sub

    ' =======================================================
    ' INITIALIZE FORM
    ' =======================================================
    Private Sub InitializeForm()
        Availability.Items.Clear()
        Availability.Items.Add("Available")
        Availability.Items.Add("Not Available")
        Availability.SelectedIndex = 0

        cmbCategory.Items.Clear()
        ' Load categories from DB so any existing product category is always found
        Try
            openConn()
            Dim catCmd As New MySqlCommand(
                "SELECT DISTINCT Category FROM products WHERE Category IS NOT NULL AND Category <> '' ORDER BY Category ASC",
                conn)
            Dim catReader As MySqlDataReader = catCmd.ExecuteReader()
            While catReader.Read()
                cmbCategory.Items.Add(catReader("Category").ToString())
            End While
            catReader.Close()
        Catch
            ' Fallback to hardcoded list
            cmbCategory.Items.AddRange({"Burgers", "Sides", "Silog Meals", "Drinks"})
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
        cmbCategory.SelectedIndex = -1

        cmbMealTime.Items.Clear()
        cmbMealTime.Items.AddRange({"All Day", "Breakfast", "Lunch", "Dinner"})
        cmbMealTime.SelectedIndex = 0

        numericPrice.Value = 0
        numericPrice.DecimalPlaces = 2
        numericPrice.Minimum = 0
        numericPrice.Maximum = 999999

        ProductID.ReadOnly = True
        OrderCount.ReadOnly = True

        PictureBox1.Image = Nothing
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.BorderStyle = BorderStyle.FixedSingle
        PictureBox1.Cursor = Cursors.Hand

        SelectedImageBytes = Nothing
        OriginalImagePath = ""
        IsNewImageSelected = False
    End Sub

    ' =======================================================
    ' LOAD PRODUCT DATA
    ' =======================================================
    Public Sub LoadProductData(id As Integer)
        SelectedProductID = id
        Try
            openConn()
            Dim sql As String = "SELECT * FROM products WHERE ProductID = @id"
            Dim cmd As New MySqlCommand(sql, conn)
            cmd.Parameters.AddWithValue("@id", id)
            Dim rd = cmd.ExecuteReader()

            If rd.Read() Then
                ProductID.Text = rd("ProductID").ToString()
                txtProductName.Text = rd("ProductName").ToString()
                Description.Text = rd("Description").ToString()
                numericPrice.Value = Convert.ToDecimal(rd("Price"))
                ServingSize.Text = rd("ServingSize").ToString()
                ProductCode.Text = rd("ProductCode").ToString()
                PrepTime.Text = If(IsDBNull(rd("PrepTime")), "", rd("PrepTime").ToString())
                OrderCount.Text = rd("OrderCount").ToString()
                Availability.Text = rd("Availability").ToString()
                cmbCategory.Text = rd("Category").ToString()
                cmbMealTime.Text = If(IsDBNull(rd("MealTime")), "All Day", rd("MealTime").ToString())

                ' ===== LOAD EXISTING IMAGE =====
                If Not IsDBNull(rd("Image")) AndAlso rd("Image").ToString() <> "" Then
                    OriginalImagePath = rd("Image").ToString()
                    LoadImageFromPath(OriginalImagePath)
                Else
                    PictureBox1.Image = Nothing
                    OriginalImagePath = ""
                End If

                Me.Text = $"✏️ Edit Product - {txtProductName.Text}"
            End If
            rd.Close()

        Catch ex As Exception
            MessageBox.Show("❌ Error loading product: " & ex.Message,
                          "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    ' =======================================================
    ' LOAD IMAGE - TRIES FILE SYSTEM FIRST, THEN URL
    ' =======================================================
    Private Sub LoadImageFromPath(imagePath As String)
        Try
            If String.IsNullOrEmpty(imagePath) Then
                PictureBox1.Image = Nothing
                Return
            End If

            ' Try loading directly from file system first (faster)
            Dim uploadsFolder As String = GetUploadsFolder()
            If uploadsFolder IsNot Nothing Then
                Dim filename As String = Path.GetFileName(imagePath)
                Dim fullFilePath As String = Path.Combine(uploadsFolder, filename)

                If File.Exists(fullFilePath) Then
                    Dim imageBytes() As Byte = File.ReadAllBytes(fullFilePath)
                    SelectedImageBytes = imageBytes
                    Using ms As New MemoryStream(imageBytes)
                        PictureBox1.Image = Image.FromStream(ms)
                    End Using
                    Return
                End If
            End If

            ' Fallback: load from localhost web URL
            Dim fullUrl As String = "http://localhost/TrialWorkIM-main/" & imagePath.Replace("\", "/")
            Dim webClient As New System.Net.WebClient()
            Dim webImageBytes() As Byte = webClient.DownloadData(fullUrl)
            SelectedImageBytes = webImageBytes

            Using ms As New MemoryStream(webImageBytes)
                PictureBox1.Image = Image.FromStream(ms)
            End Using

        Catch ex As Exception
            Console.WriteLine($"Failed to load image: {ex.Message}")
            PictureBox1.Image = Nothing
            SelectedImageBytes = Nothing
        End Try
    End Sub

    ' =======================================================
    ' LEGACY METHOD
    ' =======================================================
    Public Sub LoadProduct(id As Integer)
        LoadProductData(id)
    End Sub

    ' =======================================================
    ' BROWSE NEW IMAGE - CLICK PICTUREBOX
    ' =======================================================
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim ofd As New OpenFileDialog()
        ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif"
        ofd.Title = "Select Product Image"

        If ofd.ShowDialog() = DialogResult.OK Then
            Try
                SelectedImageBytes = File.ReadAllBytes(ofd.FileName)
                IsNewImageSelected = True

                ' Display immediately in PictureBox
                Using ms As New MemoryStream(SelectedImageBytes)
                    PictureBox1.Image = Image.FromStream(ms)
                End Using

                MessageBox.Show("✓ New image selected. Click 'Update Item' to save.",
                              "Image Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("❌ Error loading image: " & ex.Message,
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    ' =======================================================
    ' UPDATE ITEM BUTTON
    ' =======================================================
    Private Sub btnUpdateItem_Click(sender As Object, e As EventArgs) Handles btnUpdateItem.Click

        If String.IsNullOrWhiteSpace(txtProductName.Text) Then
            MessageBox.Show("⚠️ Product Name is required!", "Validation Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtProductName.Focus()
            Return
        End If

        If cmbCategory.SelectedIndex = -1 Then
            MessageBox.Show("⚠️ Please select a Category!", "Validation Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbCategory.Focus()
            Return
        End If

        If numericPrice.Value <= 0 Then
            MessageBox.Show("⚠️ Price must be greater than 0!", "Validation Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            numericPrice.Focus()
            Return
        End If

        Try
            openConn()

            Dim imagePath As String = OriginalImagePath ' Default: keep existing

            ' ===== SAVE NEW IMAGE IF SELECTED =====
            If IsNewImageSelected AndAlso SelectedImageBytes IsNot Nothing Then
                Dim uploadsFolder As String = GetUploadsFolder()

                If String.IsNullOrEmpty(uploadsFolder) Then
                    MessageBox.Show("❌ XAMPP htdocs folder not found. Check your XAMPP installation.",
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If

                If Not Directory.Exists(uploadsFolder) Then
                    Directory.CreateDirectory(uploadsFolder)
                End If

                ' Generate unique filename
                Dim fileName As String = $"product_{SelectedProductID}_{DateTime.Now:yyyyMMddHHmmss}.jpg"
                Dim fullPath As String = Path.Combine(uploadsFolder, fileName)

                File.WriteAllBytes(fullPath, SelectedImageBytes)

                ' Relative path stored in DB - accessible via localhost
                imagePath = $"docs/OrderPicture/{fileName}"

                ' Reload into PictureBox from saved file to confirm
                LoadImageFromPath(imagePath)
            End If

            ' ===== UPDATE DATABASE =====
            Dim sql As String =
                "UPDATE products SET
                    ProductName=@ProductName,
                    Category=@Category,
                    Description=@Description,
                    Price=@Price,
                    Availability=@Availability,
                    ServingSize=@ServingSize,
                    ProductCode=@ProductCode,
                    PrepTime=@PrepTime,
                    MealTime=@MealTime,
                    LastUpdated=NOW(),
                    Image=@Image
                 WHERE ProductID=@id"

            Dim cmd As New MySqlCommand(sql, conn)
            cmd.Parameters.AddWithValue("@ProductName", txtProductName.Text.Trim())
            cmd.Parameters.AddWithValue("@Category", cmbCategory.Text.Trim())
            cmd.Parameters.AddWithValue("@Description", Description.Text.Trim())
            cmd.Parameters.AddWithValue("@Price", numericPrice.Value)
            cmd.Parameters.AddWithValue("@Availability", Availability.Text)
            cmd.Parameters.AddWithValue("@ServingSize", ServingSize.Text.Trim())
            cmd.Parameters.AddWithValue("@ProductCode", ProductCode.Text.Trim())
            cmd.Parameters.AddWithValue("@PrepTime", PrepTime.Text.Trim())
            cmd.Parameters.AddWithValue("@MealTime", cmbMealTime.Text)
            cmd.Parameters.AddWithValue("@id", SelectedProductID)
            cmd.Parameters.AddWithValue("@Image",
                If(String.IsNullOrEmpty(imagePath), DBNull.Value, CObj(imagePath)))

            cmd.ExecuteNonQuery()

            MessageBox.Show("✓ Menu item updated successfully!" & vbCrLf &
                          "Product: " & txtProductName.Text,
                          "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("❌ Error updating item: " & ex.Message & vbCrLf &
                          "Stack Trace: " & ex.StackTrace,
                          "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    ' =======================================================
    ' CLOSE BUTTON
    ' =======================================================
    'Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
    '    Dim result As DialogResult = MessageBox.Show(
    '        "Are you sure you want to close without saving changes?",
    '        "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

    '    If result = DialogResult.Yes Then
    '        Me.DialogResult = DialogResult.Cancel
    '        Me.Close()
    '    End If
    'End Sub

    ' =======================================================
    ' FORM CLOSING - CLEANUP
    ' =======================================================
    Private Sub FormEditMenu_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If PictureBox1.Image IsNot Nothing Then
            PictureBox1.Image.Dispose()
            PictureBox1.Image = Nothing
        End If
    End Sub

End Class