<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddNewItems
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddNewItems))
        Me.AddItem = New System.Windows.Forms.Button()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.RoundedTextBox1 = New InformationManagement.RoundedTextBox()
        Me.Unit = New System.Windows.Forms.ComboBox()
        Me.Quantity = New InformationManagement.RoundedTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtFullName = New InformationManagement.RoundedTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDown2 = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Category = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'AddItem
        '
        Me.AddItem.BackColor = System.Drawing.Color.Green
        Me.AddItem.FlatAppearance.BorderSize = 0
        Me.AddItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.AddItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AddItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.AddItem.Image = CType(resources.GetObject("AddItem.Image"), System.Drawing.Image)
        Me.AddItem.Location = New System.Drawing.Point(544, 581)
        Me.AddItem.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.AddItem.Name = "AddItem"
        Me.AddItem.Size = New System.Drawing.Size(175, 47)
        Me.AddItem.TabIndex = 61
        Me.AddItem.Text = " Add Item"
        Me.AddItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.AddItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.AddItem.UseVisualStyleBackColor = False
        '
        'Cancel
        '
        Me.Cancel.BackColor = System.Drawing.Color.Gray
        Me.Cancel.FlatAppearance.BorderSize = 0
        Me.Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Cancel.Location = New System.Drawing.Point(363, 581)
        Me.Cancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(175, 47)
        Me.Cancel.TabIndex = 60
        Me.Cancel.Text = "Cancel"
        Me.Cancel.UseVisualStyleBackColor = False
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.DateTimePicker1.Location = New System.Drawing.Point(394, 418)
        Me.DateTimePicker1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(271, 34)
        Me.DateTimePicker1.TabIndex = 54
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label8.Location = New System.Drawing.Point(404, 386)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(147, 28)
        Me.Label8.TabIndex = 53
        Me.Label8.Text = "Last Restocked"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label7.Location = New System.Drawing.Point(34, 386)
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
        Me.RoundedTextBox1.Location = New System.Drawing.Point(35, 418)
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
        Me.Unit.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Unit.FormattingEnabled = True
        Me.Unit.Items.AddRange(New Object() {"kg", "liters", "pieces", "boxes", "grams", "bottles"})
        Me.Unit.Location = New System.Drawing.Point(395, 250)
        Me.Unit.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Unit.Name = "Unit"
        Me.Unit.Size = New System.Drawing.Size(249, 36)
        Me.Unit.TabIndex = 51
        '
        'Quantity
        '
        Me.Quantity.BackColor = System.Drawing.Color.Transparent
        Me.Quantity.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Quantity.FocusBorderColor = System.Drawing.Color.DarkGray
        Me.Quantity.Location = New System.Drawing.Point(39, 241)
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
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label6.Location = New System.Drawing.Point(33, 210)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(151, 28)
        Me.Label6.TabIndex = 50
        Me.Label6.Text = "Stock Quantity "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label5.Location = New System.Drawing.Point(395, 220)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 28)
        Me.Label5.TabIndex = 49
        Me.Label5.Text = "Unit"
        '
        'txtFullName
        '
        Me.txtFullName.BackColor = System.Drawing.SystemColors.Window
        Me.txtFullName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtFullName.FocusBorderColor = System.Drawing.Color.DarkGray
        Me.txtFullName.Location = New System.Drawing.Point(39, 144)
        Me.txtFullName.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtFullName.MaxLength = 32767
        Me.txtFullName.MinimumSize = New System.Drawing.Size(67, 25)
        Me.txtFullName.Multiline = False
        Me.txtFullName.Name = "txtFullName"
        Me.txtFullName.NormalBorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.txtFullName.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtFullName.ReadOnly = False
        Me.txtFullName.Size = New System.Drawing.Size(307, 44)
        Me.txtFullName.TabIndex = 43
        Me.txtFullName.TextBoxBackColor = System.Drawing.Color.WhiteSmoke
        Me.txtFullName.TextColor = System.Drawing.Color.Black
        Me.txtFullName.TextFont = New System.Drawing.Font("Segoe UI", 10.0!)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label3.Location = New System.Drawing.Point(33, 111)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(114, 28)
        Me.Label3.TabIndex = 42
        Me.Label3.Text = "Item Name"
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.CalendarForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.DateTimePicker2.CalendarTitleForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.DateTimePicker2.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.DateTimePicker2.Location = New System.Drawing.Point(395, 506)
        Me.DateTimePicker2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(271, 34)
        Me.DateTimePicker2.TabIndex = 63
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label11.Location = New System.Drawing.Point(395, 476)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(156, 28)
        Me.Label11.TabIndex = 62
        Me.Label11.Text = "Expiration Date "
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label9.Location = New System.Drawing.Point(34, 304)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(161, 28)
        Me.Label9.TabIndex = 55
        Me.Label9.Text = "Min Stock Level "
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label10.Location = New System.Drawing.Point(395, 305)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(158, 28)
        Me.Label10.TabIndex = 56
        Me.Label10.Text = "Max Stock Level"
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NumericUpDown1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumericUpDown1.Location = New System.Drawing.Point(39, 336)
        Me.NumericUpDown1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(240, 34)
        Me.NumericUpDown1.TabIndex = 57
        Me.NumericUpDown1.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'NumericUpDown2
        '
        Me.NumericUpDown2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NumericUpDown2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumericUpDown2.Location = New System.Drawing.Point(395, 337)
        Me.NumericUpDown2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.NumericUpDown2.Name = "NumericUpDown2"
        Me.NumericUpDown2.Size = New System.Drawing.Size(240, 34)
        Me.NumericUpDown2.TabIndex = 58
        Me.NumericUpDown2.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label4.Location = New System.Drawing.Point(389, 111)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(107, 28)
        Me.Label4.TabIndex = 44
        Me.Label4.Text = "Catergory "
        '
        'Category
        '
        Me.Category.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Category.FormattingEnabled = True
        Me.Category.Items.AddRange(New Object() {"Meat & Poultry", "Vegetables", "Dairy", "Dry Goods", "Oils & Condiments", "Herbs & Spices", "Beverages", "Seafood"})
        Me.Category.Location = New System.Drawing.Point(395, 144)
        Me.Category.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Category.Name = "Category"
        Me.Category.Size = New System.Drawing.Size(249, 36)
        Me.Category.TabIndex = 47
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Red
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(731, 80)
        Me.Panel1.TabIndex = 64
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(32, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(343, 38)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "Add New Inventory Item"
        '
        'AddNewItems
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(731, 639)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.DateTimePicker2)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.AddItem)
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
        Me.Controls.Add(Me.Category)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtFullName)
        Me.Controls.Add(Me.Label3)
        Me.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "AddNewItems"
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents AddItem As Button
    Friend WithEvents Cancel As Button
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents RoundedTextBox1 As InformationManagement.RoundedTextBox
    Friend WithEvents Unit As ComboBox
    Friend WithEvents Quantity As InformationManagement.RoundedTextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtFullName As InformationManagement.RoundedTextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents Label11 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents NumericUpDown1 As NumericUpDown
    Friend WithEvents NumericUpDown2 As NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents Category As ComboBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
End Class
