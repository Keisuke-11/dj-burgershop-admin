<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ConfigurationPage
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConfigurationPage))
        Me.RoundedPane21 = New Global.InformationManagement.RoundedPane2()
        Me.lblServerStatus = New System.Windows.Forms.Label()
        Me.txtServer = New InformationManagement.RoundedTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtDatabasename = New InformationManagement.RoundedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPassword = New InformationManagement.RoundedTextBox()
        Me.btnTestConnection = New System.Windows.Forms.Button()
        Me.txtUsername = New InformationManagement.RoundedTextBox()
        Me.btnSaveAndContinue = New System.Windows.Forms.Button()
        Me.RoundedPane21.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RoundedPane21
        '
        Me.RoundedPane21.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.RoundedPane21.BackColor = System.Drawing.Color.Transparent
        Me.RoundedPane21.BorderColor = System.Drawing.Color.Transparent
        Me.RoundedPane21.BorderThickness = 1
        Me.RoundedPane21.Controls.Add(Me.lblServerStatus)
        Me.RoundedPane21.Controls.Add(Me.txtServer)
        Me.RoundedPane21.Controls.Add(Me.Label2)
        Me.RoundedPane21.Controls.Add(Me.Label6)
        Me.RoundedPane21.Controls.Add(Me.Label4)
        Me.RoundedPane21.Controls.Add(Me.Label5)
        Me.RoundedPane21.Controls.Add(Me.PictureBox1)
        Me.RoundedPane21.Controls.Add(Me.txtDatabasename)
        Me.RoundedPane21.Controls.Add(Me.Label1)
        Me.RoundedPane21.Controls.Add(Me.txtPassword)
        Me.RoundedPane21.Controls.Add(Me.btnTestConnection)
        Me.RoundedPane21.Controls.Add(Me.txtUsername)
        Me.RoundedPane21.Controls.Add(Me.btnSaveAndContinue)
        Me.RoundedPane21.CornerRadius = 12
        Me.RoundedPane21.FillColor = System.Drawing.Color.Red
        Me.RoundedPane21.Location = New System.Drawing.Point(157, 22)
        Me.RoundedPane21.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RoundedPane21.Name = "RoundedPane21"
        Me.RoundedPane21.Size = New System.Drawing.Size(850, 600)
        Me.RoundedPane21.TabIndex = 11
        '
        'lblServerStatus
        '
        Me.lblServerStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(134, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblServerStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
        Me.lblServerStatus.ForeColor = System.Drawing.Color.Gray
        Me.lblServerStatus.Location = New System.Drawing.Point(207, 402)
        Me.lblServerStatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblServerStatus.Name = "lblServerStatus"
        Me.lblServerStatus.Size = New System.Drawing.Size(419, 43)
        Me.lblServerStatus.TabIndex = 12
        Me.lblServerStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtServer
        '
        Me.txtServer.BackColor = System.Drawing.Color.Transparent
        Me.txtServer.FocusBorderColor = System.Drawing.Color.LightCoral
        Me.txtServer.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.txtServer.Location = New System.Drawing.Point(55, 249)
        Me.txtServer.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtServer.MaxLength = 32767
        Me.txtServer.MinimumSize = New System.Drawing.Size(67, 25)
        Me.txtServer.Multiline = False
        Me.txtServer.Name = "txtServer"
        Me.txtServer.NormalBorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.txtServer.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtServer.ReadOnly = False
        Me.txtServer.Size = New System.Drawing.Size(350, 43)
        Me.txtServer.TabIndex = 1
        Me.txtServer.TextBoxBackColor = System.Drawing.Color.White
        Me.txtServer.TextColor = System.Drawing.Color.Black
        Me.txtServer.TextFont = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(254, Byte))
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(51, 220)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 28)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Server IP"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(435, 305)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(97, 28)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Password"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(51, 305)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(155, 28)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Database Name"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(435, 220)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 28)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Username"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(347, 22)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(150, 144)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 10
        Me.PictureBox1.TabStop = False
        '
        'txtDatabasename
        '
        Me.txtDatabasename.BackColor = System.Drawing.Color.Transparent
        Me.txtDatabasename.FocusBorderColor = System.Drawing.Color.LightCoral
        Me.txtDatabasename.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.txtDatabasename.Location = New System.Drawing.Point(53, 334)
        Me.txtDatabasename.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtDatabasename.MaxLength = 32767
        Me.txtDatabasename.MinimumSize = New System.Drawing.Size(67, 25)
        Me.txtDatabasename.Multiline = False
        Me.txtDatabasename.Name = "txtDatabasename"
        Me.txtDatabasename.NormalBorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.txtDatabasename.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtDatabasename.ReadOnly = False
        Me.txtDatabasename.Size = New System.Drawing.Size(350, 43)
        Me.txtDatabasename.TabIndex = 3
        Me.txtDatabasename.TextBoxBackColor = System.Drawing.Color.White
        Me.txtDatabasename.TextColor = System.Drawing.Color.Black
        Me.txtDatabasename.TextFont = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(254, Byte))
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(263, 171)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(292, 38)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Server Configuration"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtPassword
        '
        Me.txtPassword.BackColor = System.Drawing.Color.Transparent
        Me.txtPassword.FocusBorderColor = System.Drawing.Color.LightCoral
        Me.txtPassword.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.txtPassword.Location = New System.Drawing.Point(439, 335)
        Me.txtPassword.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtPassword.MaxLength = 32767
        Me.txtPassword.MinimumSize = New System.Drawing.Size(67, 25)
        Me.txtPassword.Multiline = False
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.NormalBorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.ReadOnly = False
        Me.txtPassword.Size = New System.Drawing.Size(350, 43)
        Me.txtPassword.TabIndex = 5
        Me.txtPassword.TextBoxBackColor = System.Drawing.Color.White
        Me.txtPassword.TextColor = System.Drawing.Color.Black
        Me.txtPassword.TextFont = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(254, Byte))
        '
        'btnTestConnection
        '
        Me.btnTestConnection.BackColor = System.Drawing.Color.Green
        Me.btnTestConnection.FlatAppearance.BorderSize = 0
        Me.btnTestConnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTestConnection.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold)
        Me.btnTestConnection.ForeColor = System.Drawing.Color.White
        Me.btnTestConnection.Location = New System.Drawing.Point(320, 464)
        Me.btnTestConnection.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnTestConnection.Name = "btnTestConnection"
        Me.btnTestConnection.Size = New System.Drawing.Size(199, 47)
        Me.btnTestConnection.TabIndex = 6
        Me.btnTestConnection.Text = "Test Connection"
        Me.btnTestConnection.UseVisualStyleBackColor = False
        '
        'txtUsername
        '
        Me.txtUsername.BackColor = System.Drawing.Color.Transparent
        Me.txtUsername.FocusBorderColor = System.Drawing.Color.LightCoral
        Me.txtUsername.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.txtUsername.Location = New System.Drawing.Point(440, 249)
        Me.txtUsername.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtUsername.MaxLength = 32767
        Me.txtUsername.MinimumSize = New System.Drawing.Size(67, 25)
        Me.txtUsername.Multiline = False
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.NormalBorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.txtUsername.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtUsername.ReadOnly = False
        Me.txtUsername.Size = New System.Drawing.Size(350, 43)
        Me.txtUsername.TabIndex = 4
        Me.txtUsername.TextBoxBackColor = System.Drawing.Color.White
        Me.txtUsername.TextColor = System.Drawing.Color.Black
        Me.txtUsername.TextFont = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(254, Byte))
        '
        'btnSaveAndContinue
        '
        Me.btnSaveAndContinue.BackColor = System.Drawing.Color.Gray
        Me.btnSaveAndContinue.FlatAppearance.BorderSize = 0
        Me.btnSaveAndContinue.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue
        Me.btnSaveAndContinue.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveAndContinue.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveAndContinue.ForeColor = System.Drawing.Color.White
        Me.btnSaveAndContinue.Location = New System.Drawing.Point(320, 528)
        Me.btnSaveAndContinue.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnSaveAndContinue.Name = "btnSaveAndContinue"
        Me.btnSaveAndContinue.Size = New System.Drawing.Size(199, 47)
        Me.btnSaveAndContinue.TabIndex = 10
        Me.btnSaveAndContinue.Text = "Continue"
        Me.btnSaveAndContinue.UseVisualStyleBackColor = False
        '
        'ConfigurationPage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.GhostWhite
        Me.ClientSize = New System.Drawing.Size(1197, 643)
        Me.Controls.Add(Me.RoundedPane21)
        Me.DoubleBuffered = True
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ConfigurationPage"
        Me.ShowIcon = False
        Me.Text = "Configuration Page"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.RoundedPane21.ResumeLayout(False)
        Me.RoundedPane21.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtServer As InformationManagement.RoundedTextBox
    Friend WithEvents txtUsername As InformationManagement.RoundedTextBox
    Friend WithEvents txtDatabasename As InformationManagement.RoundedTextBox
    Friend WithEvents txtPassword As InformationManagement.RoundedTextBox
    Friend WithEvents btnTestConnection As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents RoundedPane21 As Global.InformationManagement.RoundedPane2
    Friend WithEvents btnSaveAndContinue As Button
    Friend WithEvents lblServerStatus As Label
End Class
