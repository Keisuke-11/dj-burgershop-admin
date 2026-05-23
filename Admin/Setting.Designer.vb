<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Setting
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

    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
    
    ' VIEW SWITCHING
    Friend WithEvents btnViewAdmin As Button
    Friend WithEvents btnViewDB As Button

    ' ADMIN INFO PANEL
    Friend WithEvents pnlAdminInfo As Panel
    Friend WithEvents lblName As Label
    Friend WithEvents txtName As InformationManagement.RoundedTextBox
    Friend WithEvents lblUsername As Label
    Friend WithEvents txtUsername As InformationManagement.RoundedTextBox
    Friend WithEvents lblCurrentPassword As Label
    Friend WithEvents txtCurrentPassword As InformationManagement.RoundedTextBox
    Friend WithEvents lblNewPassword As Label
    Friend WithEvents txtNewPassword As InformationManagement.RoundedTextBox
    Friend WithEvents chkShowPassword As CheckBox

    ' DB CONFIG PANEL
    Friend WithEvents pnlDBConfig As Panel
    Friend WithEvents lblServerIP As Label
    Friend WithEvents lblDBName As Label
    Friend WithEvents lblDBUser As Label
    Friend WithEvents lblDBPass As Label

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnViewDB = New System.Windows.Forms.Button()
        Me.btnViewAdmin = New System.Windows.Forms.Button()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pnlDBConfig = New System.Windows.Forms.Panel()
        Me.txtDBUser = New InformationManagement.RoundedTextBox()
        Me.txtDBPass = New InformationManagement.RoundedTextBox()
        Me.txtDBName = New InformationManagement.RoundedTextBox()
        Me.txtServerIP = New InformationManagement.RoundedTextBox()
        Me.lblDBPass = New System.Windows.Forms.Label()
        Me.lblDBUser = New System.Windows.Forms.Label()
        Me.lblDBName = New System.Windows.Forms.Label()
        Me.lblServerIP = New System.Windows.Forms.Label()
        Me.pnlAdminInfo = New System.Windows.Forms.Panel()
        Me.chkShowPassword = New System.Windows.Forms.CheckBox()
        Me.txtNewPassword = New InformationManagement.RoundedTextBox()
        Me.lblNewPassword = New System.Windows.Forms.Label()
        Me.txtCurrentPassword = New InformationManagement.RoundedTextBox()
        Me.lblCurrentPassword = New System.Windows.Forms.Label()
        Me.txtUsername = New InformationManagement.RoundedTextBox()
        Me.lblUsername = New System.Windows.Forms.Label()
        Me.txtName = New InformationManagement.RoundedTextBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlDBConfig.SuspendLayout()
        Me.pnlAdminInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Red
        Me.Panel1.Controls.Add(Me.btnViewDB)
        Me.Panel1.Controls.Add(Me.btnViewAdmin)
        Me.Panel1.Controls.Add(Me.lblTitle)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(800, 77)
        Me.Panel1.TabIndex = 0
        '
        'btnViewDB
        '
        Me.btnViewDB.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnViewDB.BackColor = System.Drawing.Color.White
        Me.btnViewDB.Cursor = System.Windows.Forms.Cursors.Hand
'         Me.btnViewDB.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnViewDB.FlatAppearance.BorderSize = 0
        Me.btnViewDB.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnViewDB.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.btnViewDB.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewDB.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnViewDB.ForeColor = System.Drawing.Color.Black
        Me.btnViewDB.Location = New System.Drawing.Point(587, 18)
        Me.btnViewDB.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnViewDB.Name = "btnViewDB"
        Me.btnViewDB.Size = New System.Drawing.Size(187, 37)
        Me.btnViewDB.TabIndex = 2
        Me.btnViewDB.Text = "Database Config"
        Me.btnViewDB.UseVisualStyleBackColor = False
        '
        'btnViewAdmin
        '
        Me.btnViewAdmin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnViewAdmin.BackColor = System.Drawing.Color.White
        Me.btnViewAdmin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnViewAdmin.FlatAppearance.BorderSize = 0
        Me.btnViewAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewAdmin.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnViewAdmin.ForeColor = System.Drawing.Color.Black
        Me.btnViewAdmin.Location = New System.Drawing.Point(387, 18)
        Me.btnViewAdmin.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnViewAdmin.Name = "btnViewAdmin"
        Me.btnViewAdmin.Size = New System.Drawing.Size(187, 37)
        Me.btnViewAdmin.TabIndex = 1
        Me.btnViewAdmin.Text = "Admin Info"
        Me.btnViewAdmin.UseVisualStyleBackColor = False
        '
        'lblTitle
        '
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(29, 13)
        Me.lblTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(156, 49)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Settings"
        '
        'Panel2
        '
        Me.Panel2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.pnlDBConfig)
        Me.Panel2.Controls.Add(Me.pnlAdminInfo)
        Me.Panel2.Controls.Add(Me.btnCancel)
        Me.Panel2.Controls.Add(Me.btnSave)
        Me.Panel2.Location = New System.Drawing.Point(0, 74)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(40, 37, 40, 37)
        Me.Panel2.Size = New System.Drawing.Size(800, 542)
        Me.Panel2.TabIndex = 1
        '
        'pnlDBConfig
        '
        Me.pnlDBConfig.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pnlDBConfig.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlDBConfig.Controls.Add(Me.txtDBUser)
        Me.pnlDBConfig.Controls.Add(Me.txtDBPass)
        Me.pnlDBConfig.Controls.Add(Me.txtDBName)
        Me.pnlDBConfig.Controls.Add(Me.txtServerIP)
        Me.pnlDBConfig.Controls.Add(Me.lblDBPass)
        Me.pnlDBConfig.Controls.Add(Me.lblDBUser)
        Me.pnlDBConfig.Controls.Add(Me.lblDBName)
        Me.pnlDBConfig.Controls.Add(Me.lblServerIP)
        Me.pnlDBConfig.Location = New System.Drawing.Point(40, 37)
        Me.pnlDBConfig.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pnlDBConfig.Name = "pnlDBConfig"
        Me.pnlDBConfig.Size = New System.Drawing.Size(720, 394)
        Me.pnlDBConfig.TabIndex = 1
        Me.pnlDBConfig.Visible = False
        '
        'txtDBUser
        '
        Me.txtDBUser.BackColor = System.Drawing.Color.Transparent
        Me.txtDBUser.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtDBUser.FocusBorderColor = System.Drawing.Color.DarkGray
        Me.txtDBUser.Location = New System.Drawing.Point(29, 231)
        Me.txtDBUser.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtDBUser.MaxLength = 32767
        Me.txtDBUser.MinimumSize = New System.Drawing.Size(67, 25)
        Me.txtDBUser.Multiline = False
        Me.txtDBUser.Name = "txtDBUser"
        Me.txtDBUser.NormalBorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.txtDBUser.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtDBUser.ReadOnly = False
        Me.txtDBUser.Size = New System.Drawing.Size(655, 44)
        Me.txtDBUser.TabIndex = 11
        Me.txtDBUser.TextBoxBackColor = System.Drawing.Color.White
        Me.txtDBUser.TextColor = System.Drawing.Color.Black
        Me.txtDBUser.TextFont = New System.Drawing.Font("Segoe UI", 10.0!)
        '
        'txtDBPass
        '
        Me.txtDBPass.BackColor = System.Drawing.Color.Transparent
        Me.txtDBPass.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtDBPass.FocusBorderColor = System.Drawing.Color.DarkGray
        Me.txtDBPass.Location = New System.Drawing.Point(29, 316)
        Me.txtDBPass.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtDBPass.MaxLength = 32767
        Me.txtDBPass.MinimumSize = New System.Drawing.Size(67, 25)
        Me.txtDBPass.Multiline = False
        Me.txtDBPass.Name = "txtDBPass"
        Me.txtDBPass.NormalBorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.txtDBPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtDBPass.ReadOnly = False
        Me.txtDBPass.Size = New System.Drawing.Size(655, 44)
        Me.txtDBPass.TabIndex = 10
        Me.txtDBPass.TextBoxBackColor = System.Drawing.Color.White
        Me.txtDBPass.TextColor = System.Drawing.Color.Black
        Me.txtDBPass.TextFont = New System.Drawing.Font("Segoe UI", 10.0!)
        '
        'txtDBName
        '
        Me.txtDBName.BackColor = System.Drawing.Color.Transparent
        Me.txtDBName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtDBName.FocusBorderColor = System.Drawing.Color.DarkGray
        Me.txtDBName.Location = New System.Drawing.Point(29, 144)
        Me.txtDBName.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtDBName.MaxLength = 32767
        Me.txtDBName.MinimumSize = New System.Drawing.Size(67, 25)
        Me.txtDBName.Multiline = False
        Me.txtDBName.Name = "txtDBName"
        Me.txtDBName.NormalBorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.txtDBName.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtDBName.ReadOnly = False
        Me.txtDBName.Size = New System.Drawing.Size(655, 44)
        Me.txtDBName.TabIndex = 9
        Me.txtDBName.TextBoxBackColor = System.Drawing.Color.White
        Me.txtDBName.TextColor = System.Drawing.Color.Black
        Me.txtDBName.TextFont = New System.Drawing.Font("Segoe UI", 10.0!)
        '
        'txtServerIP
        '
        Me.txtServerIP.BackColor = System.Drawing.Color.Transparent
        Me.txtServerIP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtServerIP.FocusBorderColor = System.Drawing.Color.DarkGray
        Me.txtServerIP.Location = New System.Drawing.Point(29, 58)
        Me.txtServerIP.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtServerIP.MaxLength = 32767
        Me.txtServerIP.MinimumSize = New System.Drawing.Size(67, 25)
        Me.txtServerIP.Multiline = False
        Me.txtServerIP.Name = "txtServerIP"
        Me.txtServerIP.NormalBorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.txtServerIP.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtServerIP.ReadOnly = False
        Me.txtServerIP.Size = New System.Drawing.Size(655, 44)
        Me.txtServerIP.TabIndex = 8
        Me.txtServerIP.TextBoxBackColor = System.Drawing.Color.White
        Me.txtServerIP.TextColor = System.Drawing.Color.Black
        Me.txtServerIP.TextFont = New System.Drawing.Font("Segoe UI", 10.0!)
        '
        'lblDBPass
        '
        Me.lblDBPass.AutoSize = True
        Me.lblDBPass.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblDBPass.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblDBPass.Location = New System.Drawing.Point(25, 289)
        Me.lblDBPass.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDBPass.Name = "lblDBPass"
        Me.lblDBPass.Size = New System.Drawing.Size(90, 23)
        Me.lblDBPass.TabIndex = 6
        Me.lblDBPass.Text = "Password:"
        '
        'lblDBUser
        '
        Me.lblDBUser.AutoSize = True
        Me.lblDBUser.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblDBUser.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblDBUser.Location = New System.Drawing.Point(25, 202)
        Me.lblDBUser.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDBUser.Name = "lblDBUser"
        Me.lblDBUser.Size = New System.Drawing.Size(94, 23)
        Me.lblDBUser.TabIndex = 4
        Me.lblDBUser.Text = "Username:"
        '
        'lblDBName
        '
        Me.lblDBName.AutoSize = True
        Me.lblDBName.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblDBName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblDBName.Location = New System.Drawing.Point(25, 117)
        Me.lblDBName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDBName.Name = "lblDBName"
        Me.lblDBName.Size = New System.Drawing.Size(141, 23)
        Me.lblDBName.TabIndex = 2
        Me.lblDBName.Text = "Database Name:"
        '
        'lblServerIP
        '
        Me.lblServerIP.AutoSize = True
        Me.lblServerIP.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblServerIP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblServerIP.Location = New System.Drawing.Point(25, 31)
        Me.lblServerIP.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblServerIP.Name = "lblServerIP"
        Me.lblServerIP.Size = New System.Drawing.Size(87, 23)
        Me.lblServerIP.TabIndex = 0
        Me.lblServerIP.Text = "Server IP:"
        '
        'pnlAdminInfo
        '
        Me.pnlAdminInfo.Controls.Add(Me.chkShowPassword)
        Me.pnlAdminInfo.Controls.Add(Me.txtNewPassword)
        Me.pnlAdminInfo.Controls.Add(Me.lblNewPassword)
        Me.pnlAdminInfo.Controls.Add(Me.txtCurrentPassword)
        Me.pnlAdminInfo.Controls.Add(Me.lblCurrentPassword)
        Me.pnlAdminInfo.Controls.Add(Me.txtUsername)
        Me.pnlAdminInfo.Controls.Add(Me.lblUsername)
        Me.pnlAdminInfo.Controls.Add(Me.txtName)
        Me.pnlAdminInfo.Controls.Add(Me.lblName)
        Me.pnlAdminInfo.Location = New System.Drawing.Point(40, 37)
        Me.pnlAdminInfo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pnlAdminInfo.Name = "pnlAdminInfo"
        Me.pnlAdminInfo.Size = New System.Drawing.Size(720, 394)
        Me.pnlAdminInfo.TabIndex = 0
        '
        'chkShowPassword
        '
        Me.chkShowPassword.AutoSize = True
        Me.chkShowPassword.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkShowPassword.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.chkShowPassword.Location = New System.Drawing.Point(29, 369)
        Me.chkShowPassword.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkShowPassword.Name = "chkShowPassword"
        Me.chkShowPassword.Size = New System.Drawing.Size(132, 24)
        Me.chkShowPassword.TabIndex = 14
        Me.chkShowPassword.Text = "Show Password"
        Me.chkShowPassword.UseVisualStyleBackColor = True
        '
        'txtNewPassword
        '
        Me.txtNewPassword.BackColor = System.Drawing.Color.Transparent
        Me.txtNewPassword.FocusBorderColor = System.Drawing.Color.DarkGray
        Me.txtNewPassword.Location = New System.Drawing.Point(29, 316)
        Me.txtNewPassword.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtNewPassword.MaxLength = 32767
        Me.txtNewPassword.MinimumSize = New System.Drawing.Size(67, 25)
        Me.txtNewPassword.Multiline = False
        Me.txtNewPassword.Name = "txtNewPassword"
        Me.txtNewPassword.NormalBorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.txtNewPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtNewPassword.ReadOnly = False
        Me.txtNewPassword.Size = New System.Drawing.Size(655, 44)
        Me.txtNewPassword.TabIndex = 13
        Me.txtNewPassword.TextBoxBackColor = System.Drawing.Color.White
        Me.txtNewPassword.TextColor = System.Drawing.Color.Black
        Me.txtNewPassword.TextFont = New System.Drawing.Font("Segoe UI", 10.0!)
        '
        'lblNewPassword
        '
        Me.lblNewPassword.AutoSize = True
        Me.lblNewPassword.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblNewPassword.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblNewPassword.Location = New System.Drawing.Point(4, 289)
        Me.lblNewPassword.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNewPassword.Name = "lblNewPassword"
        Me.lblNewPassword.Size = New System.Drawing.Size(368, 23)
        Me.lblNewPassword.TabIndex = 0
        Me.lblNewPassword.Text = "New Password (leave blank to keep current):"
        '
        'txtCurrentPassword
        '
        Me.txtCurrentPassword.BackColor = System.Drawing.Color.Transparent
        Me.txtCurrentPassword.FocusBorderColor = System.Drawing.Color.DarkGray
        Me.txtCurrentPassword.Location = New System.Drawing.Point(29, 231)
        Me.txtCurrentPassword.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCurrentPassword.MaxLength = 32767
        Me.txtCurrentPassword.MinimumSize = New System.Drawing.Size(67, 25)
        Me.txtCurrentPassword.Multiline = False
        Me.txtCurrentPassword.Name = "txtCurrentPassword"
        Me.txtCurrentPassword.NormalBorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.txtCurrentPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtCurrentPassword.ReadOnly = False
        Me.txtCurrentPassword.Size = New System.Drawing.Size(655, 44)
        Me.txtCurrentPassword.TabIndex = 12
        Me.txtCurrentPassword.TextBoxBackColor = System.Drawing.Color.White
        Me.txtCurrentPassword.TextColor = System.Drawing.Color.Black
        Me.txtCurrentPassword.TextFont = New System.Drawing.Font("Segoe UI", 10.0!)
        '
        'lblCurrentPassword
        '
        Me.lblCurrentPassword.AutoSize = True
        Me.lblCurrentPassword.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblCurrentPassword.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblCurrentPassword.Location = New System.Drawing.Point(3, 202)
        Me.lblCurrentPassword.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCurrentPassword.Name = "lblCurrentPassword"
        Me.lblCurrentPassword.Size = New System.Drawing.Size(156, 23)
        Me.lblCurrentPassword.TabIndex = 0
        Me.lblCurrentPassword.Text = "Current Password:"
        '
        'txtUsername
        '
        Me.txtUsername.BackColor = System.Drawing.Color.Transparent
        Me.txtUsername.FocusBorderColor = System.Drawing.Color.DarkGray
        Me.txtUsername.Location = New System.Drawing.Point(29, 144)
        Me.txtUsername.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtUsername.MaxLength = 32767
        Me.txtUsername.MinimumSize = New System.Drawing.Size(67, 25)
        Me.txtUsername.Multiline = False
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.NormalBorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.txtUsername.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtUsername.ReadOnly = False
        Me.txtUsername.Size = New System.Drawing.Size(655, 44)
        Me.txtUsername.TabIndex = 11
        Me.txtUsername.TextBoxBackColor = System.Drawing.Color.White
        Me.txtUsername.TextColor = System.Drawing.Color.Black
        Me.txtUsername.TextFont = New System.Drawing.Font("Segoe UI", 10.0!)
        '
        'lblUsername
        '
        Me.lblUsername.AutoSize = True
        Me.lblUsername.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblUsername.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblUsername.Location = New System.Drawing.Point(4, 117)
        Me.lblUsername.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(94, 23)
        Me.lblUsername.TabIndex = 0
        Me.lblUsername.Text = "Username:"
        '
        'txtName
        '
        Me.txtName.BackColor = System.Drawing.Color.Transparent
        Me.txtName.FocusBorderColor = System.Drawing.Color.DarkGray
        Me.txtName.Location = New System.Drawing.Point(29, 58)
        Me.txtName.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtName.MaxLength = 32767
        Me.txtName.MinimumSize = New System.Drawing.Size(67, 25)
        Me.txtName.Multiline = False
        Me.txtName.Name = "txtName"
        Me.txtName.NormalBorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.txtName.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtName.ReadOnly = True
        Me.txtName.Size = New System.Drawing.Size(655, 44)
        Me.txtName.TabIndex = 10
        Me.txtName.TextBoxBackColor = System.Drawing.Color.White
        Me.txtName.TextColor = System.Drawing.Color.Black
        Me.txtName.TextFont = New System.Drawing.Font("Segoe UI", 10.0!)
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblName.Location = New System.Drawing.Point(5, 31)
        Me.lblName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(62, 23)
        Me.lblName.TabIndex = 0
        Me.lblName.Text = "Name:"
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.Red
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(440, 479)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(160, 49)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.Green
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(627, 479)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(160, 49)
        Me.btnSave.TabIndex = 5
        Me.btnSave.Text = "Save Changes"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'Setting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 615)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Setting"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Account Settings"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.pnlDBConfig.ResumeLayout(False)
        Me.pnlDBConfig.PerformLayout()
        Me.pnlAdminInfo.ResumeLayout(False)
        Me.pnlAdminInfo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents txtDBUser As InformationManagement.RoundedTextBox
    Friend WithEvents txtDBPass As InformationManagement.RoundedTextBox
    Friend WithEvents txtDBName As InformationManagement.RoundedTextBox
    Friend WithEvents txtServerIP As InformationManagement.RoundedTextBox
End Class
