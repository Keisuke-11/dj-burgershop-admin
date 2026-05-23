Partial Class EditBatch
    Inherits System.Windows.Forms.Form

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    Private Sub InitializeComponent()
        Me.SaveChanges = New System.Windows.Forms.Button()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.RoundedTextBox1 = New InformationManagement.RoundedTextBox()
        Me.Unit = New System.Windows.Forms.ComboBox()
        Me.Quantity = New InformationManagement.RoundedTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtItemName = New InformationManagement.RoundedTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDown2 = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtBatchNumber = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtOriginalQty = New System.Windows.Forms.TextBox()
        Me.cmbStorageLocation = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SaveChanges
        '
        Me.SaveChanges.BackColor = System.Drawing.Color.Red
        Me.SaveChanges.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SaveChanges.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.SaveChanges.Location = New System.Drawing.Point(553, 668)
        Me.SaveChanges.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SaveChanges.Name = "SaveChanges"
        Me.SaveChanges.Size = New System.Drawing.Size(150, 47)
        Me.SaveChanges.TabIndex = 61
        Me.SaveChanges.Text = "Save"
        Me.SaveChanges.UseVisualStyleBackColor = False
        '
        'Cancel
        '
        Me.Cancel.BackColor = System.Drawing.Color.Gray
        Me.Cancel.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Cancel.Location = New System.Drawing.Point(397, 668)
        Me.Cancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(150, 47)
        Me.Cancel.TabIndex = 60
        Me.Cancel.Text = "Cancel"
        Me.Cancel.UseVisualStyleBackColor = False
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CalendarFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.DateTimePicker1.Location = New System.Drawing.Point(395, 447)
        Me.DateTimePicker1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(271, 34)
        Me.DateTimePicker1.TabIndex = 54
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(389, 418)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(148, 28)
        Me.Label8.TabIndex = 53
        Me.Label8.Text = "Purchase Date "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(24, 418)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(132, 28)
        Me.Label7.TabIndex = 52
        Me.Label7.Text = "Cost per Unit"
        '
        'RoundedTextBox1
        '
        Me.RoundedTextBox1.BackColor = System.Drawing.Color.Transparent
        Me.RoundedTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.RoundedTextBox1.FocusBorderColor = System.Drawing.Color.DarkGray
        Me.RoundedTextBox1.Location = New System.Drawing.Point(29, 448)
        Me.RoundedTextBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RoundedTextBox1.MaxLength = 32767
        Me.RoundedTextBox1.MinimumSize = New System.Drawing.Size(67, 25)
        Me.RoundedTextBox1.Multiline = False
        Me.RoundedTextBox1.Name = "RoundedTextBox1"
        Me.RoundedTextBox1.NormalBorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.RoundedTextBox1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.RoundedTextBox1.ReadOnly = False
        Me.RoundedTextBox1.Size = New System.Drawing.Size(307, 44)
        Me.RoundedTextBox1.TabIndex = 48
        Me.RoundedTextBox1.TextBoxBackColor = System.Drawing.Color.WhiteSmoke
        Me.RoundedTextBox1.TextColor = System.Drawing.Color.Black
        Me.RoundedTextBox1.TextFont = New System.Drawing.Font("Segoe UI", 10.0!)
        '
        'Unit
        '
        Me.Unit.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Unit.FormattingEnabled = True
        Me.Unit.ItemHeight = 26
        Me.Unit.Items.AddRange(New Object() {"kg", "liters", "pieces", "boxes", "grams", "bottles"})
        Me.Unit.Location = New System.Drawing.Point(395, 250)
        Me.Unit.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Unit.Name = "Unit"
        Me.Unit.Size = New System.Drawing.Size(249, 32)
        Me.Unit.TabIndex = 51
        '
        'Quantity
        '
        Me.Quantity.BackColor = System.Drawing.Color.Transparent
        Me.Quantity.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Quantity.FocusBorderColor = System.Drawing.Color.DarkGray
        Me.Quantity.Location = New System.Drawing.Point(29, 250)
        Me.Quantity.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Quantity.MaxLength = 32767
        Me.Quantity.MinimumSize = New System.Drawing.Size(67, 25)
        Me.Quantity.Multiline = False
        Me.Quantity.Name = "Quantity"
        Me.Quantity.NormalBorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.Quantity.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.Quantity.ReadOnly = False
        Me.Quantity.Size = New System.Drawing.Size(307, 44)
        Me.Quantity.TabIndex = 45
        Me.Quantity.TextBoxBackColor = System.Drawing.Color.WhiteSmoke
        Me.Quantity.TextColor = System.Drawing.Color.Black
        Me.Quantity.TextFont = New System.Drawing.Font("Segoe UI", 10.0!)
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(24, 217)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(173, 28)
        Me.Label6.TabIndex = 50
        Me.Label6.Text = "Current Stock Qty"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(392, 217)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 28)
        Me.Label5.TabIndex = 49
        Me.Label5.Text = "Unit"
        '
        'txtItemName
        '
        Me.txtItemName.BackColor = System.Drawing.Color.Transparent
        Me.txtItemName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtItemName.FocusBorderColor = System.Drawing.Color.DarkGray
        Me.txtItemName.Location = New System.Drawing.Point(29, 150)
        Me.txtItemName.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtItemName.MaxLength = 32767
        Me.txtItemName.MinimumSize = New System.Drawing.Size(67, 25)
        Me.txtItemName.Multiline = False
        Me.txtItemName.Name = "txtItemName"
        Me.txtItemName.NormalBorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.txtItemName.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtItemName.ReadOnly = True
        Me.txtItemName.Size = New System.Drawing.Size(307, 44)
        Me.txtItemName.TabIndex = 43
        Me.txtItemName.TextBoxBackColor = System.Drawing.Color.Gainsboro
        Me.txtItemName.TextColor = System.Drawing.Color.Black
        Me.txtItemName.TextFont = New System.Drawing.Font("Segoe UI", 10.0!)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(24, 118)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 28)
        Me.Label3.TabIndex = 42
        Me.Label3.Text = "Item Name "
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.DateTimePicker2.Location = New System.Drawing.Point(395, 603)
        Me.DateTimePicker2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(271, 34)
        Me.DateTimePicker2.TabIndex = 63
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(389, 578)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(156, 28)
        Me.Label11.TabIndex = 62
        Me.Label11.Text = "Expiration Date "
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(36, 327)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(155, 28)
        Me.Label9.TabIndex = 55
        Me.Label9.Text = "Min Stock Level"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(392, 327)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(158, 28)
        Me.Label10.TabIndex = 56
        Me.Label10.Text = "Max Stock Level"
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NumericUpDown1.Font = New System.Drawing.Font("Segoe UI", 13.0!)
        Me.NumericUpDown1.Location = New System.Drawing.Point(29, 359)
        Me.NumericUpDown1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(240, 36)
        Me.NumericUpDown1.TabIndex = 57
        Me.NumericUpDown1.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'NumericUpDown2
        '
        Me.NumericUpDown2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NumericUpDown2.Font = New System.Drawing.Font("Segoe UI", 13.0!)
        Me.NumericUpDown2.Location = New System.Drawing.Point(395, 359)
        Me.NumericUpDown2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.NumericUpDown2.Name = "NumericUpDown2"
        Me.NumericUpDown2.Size = New System.Drawing.Size(240, 36)
        Me.NumericUpDown2.TabIndex = 58
        Me.NumericUpDown2.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(392, 118)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(143, 28)
        Me.Label4.TabIndex = 44
        Me.Label4.Text = "Batch Number"
        '
        'txtBatchNumber
        '
        Me.txtBatchNumber.BackColor = System.Drawing.Color.Gainsboro
        Me.txtBatchNumber.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtBatchNumber.Location = New System.Drawing.Point(395, 150)
        Me.txtBatchNumber.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtBatchNumber.Multiline = True
        Me.txtBatchNumber.Name = "txtBatchNumber"
        Me.txtBatchNumber.ReadOnly = True
        Me.txtBatchNumber.Size = New System.Drawing.Size(251, 44)
        Me.txtBatchNumber.TabIndex = 64
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(24, 517)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(167, 28)
        Me.Label12.TabIndex = 65
        Me.Label12.Text = "Original Quantity"
        '
        'txtOriginalQty
        '
        Me.txtOriginalQty.BackColor = System.Drawing.Color.Gainsboro
        Me.txtOriginalQty.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtOriginalQty.Location = New System.Drawing.Point(29, 546)
        Me.txtOriginalQty.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtOriginalQty.Multiline = True
        Me.txtOriginalQty.Name = "txtOriginalQty"
        Me.txtOriginalQty.ReadOnly = True
        Me.txtOriginalQty.Size = New System.Drawing.Size(307, 44)
        Me.txtOriginalQty.TabIndex = 66
        '
        'cmbStorageLocation
        '
        Me.cmbStorageLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStorageLocation.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmbStorageLocation.FormattingEnabled = True
        Me.cmbStorageLocation.Items.AddRange(New Object() {"Freezer-Meat", "Freezer-Seafood", "Freezer-Processed", "Refrigerator-Dairy", "Refrigerator-Vegetables", "Refrigerator-Condiments", "Pantry-Dry-Goods", "Pantry-Canned", "Pantry-Condiments", "Pantry-Spices", "Pantry-Beverages"})
        Me.cmbStorageLocation.Location = New System.Drawing.Point(395, 546)
        Me.cmbStorageLocation.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbStorageLocation.Name = "cmbStorageLocation"
        Me.cmbStorageLocation.Size = New System.Drawing.Size(271, 31)
        Me.cmbStorageLocation.TabIndex = 67
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(389, 517)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(164, 28)
        Me.Label13.TabIndex = 68
        Me.Label13.Text = "Storage Location"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Red
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(715, 80)
        Me.Panel1.TabIndex = 69
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(22, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(306, 41)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "Edit Inventory Batch"
        '
        'EditBatch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(715, 726)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtOriginalQty)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtBatchNumber)
        Me.Controls.Add(Me.DateTimePicker2)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.SaveChanges)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.NumericUpDown2)
        Me.Controls.Add(Me.NumericUpDown1)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.RoundedTextBox1)
        Me.Controls.Add(Me.Unit)
        Me.Controls.Add(Me.Quantity)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtItemName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.cmbStorageLocation)
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "EditBatch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SaveChanges As Button
    Friend WithEvents Cancel As Button
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents RoundedTextBox1 As InformationManagement.RoundedTextBox
    Friend WithEvents Unit As ComboBox
    Friend WithEvents Quantity As InformationManagement.RoundedTextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtItemName As InformationManagement.RoundedTextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents Label11 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents NumericUpDown1 As NumericUpDown
    Friend WithEvents NumericUpDown2 As NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents txtBatchNumber As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtOriginalQty As TextBox
    Friend WithEvents cmbStorageLocation As ComboBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
End Class
