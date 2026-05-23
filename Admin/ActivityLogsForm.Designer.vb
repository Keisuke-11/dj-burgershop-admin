<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ActivityLogsForm
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
        Me.dgvActivityLogs = New System.Windows.Forms.DataGridView()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.cboUserType = New System.Windows.Forms.ComboBox()
        Me.cboActionCategory = New System.Windows.Forms.ComboBox()
        Me.cboSourceSystem = New System.Windows.Forms.ComboBox()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.btnApplyFilters = New System.Windows.Forms.Button()
        Me.btnResetFilters = New System.Windows.Forms.Button()
        Me.btnExportCSV = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.btnClearLogs = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblPageInfo = New System.Windows.Forms.Label()
        Me.btnNextPage = New System.Windows.Forms.Button()
        Me.btnPrevPage = New System.Windows.Forms.Button()
        Me.lblTotalLogs = New System.Windows.Forms.Label()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.lblUserType = New System.Windows.Forms.Label()
        Me.lblCategory = New System.Windows.Forms.Label()
        Me.lblSource = New System.Windows.Forms.Label()
        Me.lblStatusFilter = New System.Windows.Forms.Label()
        Me.pnlFilters = New System.Windows.Forms.Panel()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        CType(Me.dgvActivityLogs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.pnlFilters.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvActivityLogs
        '
        Me.dgvActivityLogs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvActivityLogs.BackgroundColor = System.Drawing.Color.White
        Me.dgvActivityLogs.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvActivityLogs.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvActivityLogs.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvActivityLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvActivityLogs.Location = New System.Drawing.Point(12, 180)
        Me.dgvActivityLogs.Name = "dgvActivityLogs"
        Me.dgvActivityLogs.RowHeadersWidth = 51
        Me.dgvActivityLogs.Size = New System.Drawing.Size(1176, 450)
        Me.dgvActivityLogs.TabIndex = 0
        '
        'dtpStartDate
        '
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpStartDate.Location = New System.Drawing.Point(667, 91)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(150, 27)
        Me.dtpStartDate.TabIndex = 1
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(836, 91)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(150, 27)
        Me.dtpEndDate.TabIndex = 3
        '
        'cboUserType
        '
        Me.cboUserType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUserType.FormattingEnabled = True
        Me.cboUserType.Location = New System.Drawing.Point(345, 90)
        Me.cboUserType.Name = "cboUserType"
        Me.cboUserType.Size = New System.Drawing.Size(150, 28)
        Me.cboUserType.TabIndex = 5
        '
        'cboActionCategory
        '
        Me.cboActionCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboActionCategory.FormattingEnabled = True
        Me.cboActionCategory.Location = New System.Drawing.Point(511, 90)
        Me.cboActionCategory.Name = "cboActionCategory"
        Me.cboActionCategory.Size = New System.Drawing.Size(150, 28)
        Me.cboActionCategory.TabIndex = 7
        '
        'cboSourceSystem
        '
        Me.cboSourceSystem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSourceSystem.FormattingEnabled = True
        Me.cboSourceSystem.Location = New System.Drawing.Point(15, 90)
        Me.cboSourceSystem.Name = "cboSourceSystem"
        Me.cboSourceSystem.Size = New System.Drawing.Size(150, 28)
        Me.cboSourceSystem.TabIndex = 9
        '
        'cboStatus
        '
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Location = New System.Drawing.Point(180, 90)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(150, 28)
        Me.cboStatus.TabIndex = 11
        '
        'btnApplyFilters
        '
        Me.btnApplyFilters.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnApplyFilters.FlatAppearance.BorderSize = 0
        Me.btnApplyFilters.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnApplyFilters.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnApplyFilters.ForeColor = System.Drawing.Color.White
        Me.btnApplyFilters.Location = New System.Drawing.Point(15, 130)
        Me.btnApplyFilters.Name = "btnApplyFilters"
        Me.btnApplyFilters.Size = New System.Drawing.Size(100, 30)
        Me.btnApplyFilters.TabIndex = 14
        Me.btnApplyFilters.Text = "Apply Filters"
        Me.btnApplyFilters.UseVisualStyleBackColor = False
        '
        'btnResetFilters
        '
        Me.btnResetFilters.BackColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.btnResetFilters.FlatAppearance.BorderSize = 0
        Me.btnResetFilters.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnResetFilters.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnResetFilters.ForeColor = System.Drawing.Color.White
        Me.btnResetFilters.Location = New System.Drawing.Point(125, 130)
        Me.btnResetFilters.Name = "btnResetFilters"
        Me.btnResetFilters.Size = New System.Drawing.Size(100, 30)
        Me.btnResetFilters.TabIndex = 15
        Me.btnResetFilters.Text = "Reset Filters"
        Me.btnResetFilters.UseVisualStyleBackColor = False
        '
        'btnExportCSV
        '
        Me.btnExportCSV.BackColor = System.Drawing.Color.Green
        Me.btnExportCSV.FlatAppearance.BorderSize = 0
        Me.btnExportCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExportCSV.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnExportCSV.ForeColor = System.Drawing.Color.White
        Me.btnExportCSV.Location = New System.Drawing.Point(235, 130)
        Me.btnExportCSV.Name = "btnExportCSV"
        Me.btnExportCSV.Size = New System.Drawing.Size(100, 30)
        Me.btnExportCSV.TabIndex = 16
        Me.btnExportCSV.Text = "Export"
        Me.btnExportCSV.UseVisualStyleBackColor = False
        '
        'btnRefresh
        '
        Me.btnRefresh.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnRefresh.FlatAppearance.BorderSize = 0
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnRefresh.ForeColor = System.Drawing.Color.White
        Me.btnRefresh.Location = New System.Drawing.Point(345, 130)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(100, 30)
        Me.btnRefresh.TabIndex = 17
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'btnClearLogs
        '
        Me.btnClearLogs.BackColor = System.Drawing.Color.Red
        Me.btnClearLogs.FlatAppearance.BorderSize = 0
        Me.btnClearLogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClearLogs.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnClearLogs.ForeColor = System.Drawing.Color.White
        Me.btnClearLogs.Location = New System.Drawing.Point(455, 130)
        Me.btnClearLogs.Name = "btnClearLogs"
        Me.btnClearLogs.Size = New System.Drawing.Size(100, 30)
        Me.btnClearLogs.TabIndex = 18
        Me.btnClearLogs.Text = "Clear"
        Me.btnClearLogs.UseVisualStyleBackColor = False
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.Controls.Add(Me.lblPageInfo)
        Me.Panel4.Controls.Add(Me.btnNextPage)
        Me.Panel4.Controls.Add(Me.btnPrevPage)
        Me.Panel4.Controls.Add(Me.lblTotalLogs)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 640)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1200, 50)
        Me.Panel4.TabIndex = 2
        '
        'lblPageInfo
        '
        Me.lblPageInfo.AutoSize = True
        Me.lblPageInfo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblPageInfo.Location = New System.Drawing.Point(541, 18)
        Me.lblPageInfo.Name = "lblPageInfo"
        Me.lblPageInfo.Size = New System.Drawing.Size(88, 20)
        Me.lblPageInfo.TabIndex = 5
        Me.lblPageInfo.Text = "Page 1 of 1"
        '
        'btnNextPage
        '
        Me.btnNextPage.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.btnNextPage.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNextPage.FlatAppearance.BorderSize = 0
        Me.btnNextPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNextPage.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnNextPage.ForeColor = System.Drawing.Color.Black
        Me.btnNextPage.Location = New System.Drawing.Point(635, 10)
        Me.btnNextPage.Name = "btnNextPage"
        Me.btnNextPage.Size = New System.Drawing.Size(70, 30)
        Me.btnNextPage.TabIndex = 3
        Me.btnNextPage.Text = "Next"
        Me.btnNextPage.UseVisualStyleBackColor = False
        '
        'btnPrevPage
        '
        Me.btnPrevPage.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.btnPrevPage.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrevPage.FlatAppearance.BorderSize = 0
        Me.btnPrevPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrevPage.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnPrevPage.ForeColor = System.Drawing.Color.Black
        Me.btnPrevPage.Location = New System.Drawing.Point(465, 10)
        Me.btnPrevPage.Name = "btnPrevPage"
        Me.btnPrevPage.Size = New System.Drawing.Size(70, 30)
        Me.btnPrevPage.TabIndex = 2
        Me.btnPrevPage.Text = "Prev"
        Me.btnPrevPage.UseVisualStyleBackColor = False
        '
        'lblTotalLogs
        '
        Me.lblTotalLogs.AutoSize = True
        Me.lblTotalLogs.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalLogs.Location = New System.Drawing.Point(12, 18)
        Me.lblTotalLogs.Name = "lblTotalLogs"
        Me.lblTotalLogs.Size = New System.Drawing.Size(98, 20)
        Me.lblTotalLogs.TabIndex = 0
        Me.lblTotalLogs.Text = "Total Logs: 0"
        '
        'lblStartDate
        '
        Me.lblStartDate.AutoSize = True
        Me.lblStartDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblStartDate.Location = New System.Drawing.Point(667, 71)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(79, 20)
        Me.lblStartDate.TabIndex = 0
        Me.lblStartDate.Text = "Start Date:"
        '
        'lblEndDate
        '
        Me.lblEndDate.AutoSize = True
        Me.lblEndDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblEndDate.Location = New System.Drawing.Point(836, 71)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(73, 20)
        Me.lblEndDate.TabIndex = 2
        Me.lblEndDate.Text = "End Date:"
        '
        'lblUserType
        '
        Me.lblUserType.AutoSize = True
        Me.lblUserType.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblUserType.Location = New System.Drawing.Point(345, 70)
        Me.lblUserType.Name = "lblUserType"
        Me.lblUserType.Size = New System.Drawing.Size(76, 20)
        Me.lblUserType.TabIndex = 4
        Me.lblUserType.Text = "User Type:"
        '
        'lblCategory
        '
        Me.lblCategory.AutoSize = True
        Me.lblCategory.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblCategory.Location = New System.Drawing.Point(511, 70)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(72, 20)
        Me.lblCategory.TabIndex = 6
        Me.lblCategory.Text = "Category:"
        '
        'lblSource
        '
        Me.lblSource.AutoSize = True
        Me.lblSource.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblSource.Location = New System.Drawing.Point(15, 70)
        Me.lblSource.Name = "lblSource"
        Me.lblSource.Size = New System.Drawing.Size(57, 20)
        Me.lblSource.TabIndex = 8
        Me.lblSource.Text = "Source:"
        '
        'lblStatusFilter
        '
        Me.lblStatusFilter.AutoSize = True
        Me.lblStatusFilter.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblStatusFilter.Location = New System.Drawing.Point(180, 70)
        Me.lblStatusFilter.Name = "lblStatusFilter"
        Me.lblStatusFilter.Size = New System.Drawing.Size(52, 20)
        Me.lblStatusFilter.TabIndex = 10
        Me.lblStatusFilter.Text = "Status:"
        '
        'pnlFilters
        '
        Me.pnlFilters.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.pnlFilters.Controls.Add(Me.lblSearch)
        Me.pnlFilters.Controls.Add(Me.txtSearch)
        Me.pnlFilters.Controls.Add(Me.btnSearch)
        Me.pnlFilters.Controls.Add(Me.lblStartDate)
        Me.pnlFilters.Controls.Add(Me.dtpStartDate)
        Me.pnlFilters.Controls.Add(Me.lblEndDate)
        Me.pnlFilters.Controls.Add(Me.dtpEndDate)
        Me.pnlFilters.Controls.Add(Me.lblUserType)
        Me.pnlFilters.Controls.Add(Me.cboUserType)
        Me.pnlFilters.Controls.Add(Me.lblCategory)
        Me.pnlFilters.Controls.Add(Me.cboActionCategory)
        Me.pnlFilters.Controls.Add(Me.lblSource)
        Me.pnlFilters.Controls.Add(Me.cboSourceSystem)
        Me.pnlFilters.Controls.Add(Me.lblStatusFilter)
        Me.pnlFilters.Controls.Add(Me.cboStatus)
        Me.pnlFilters.Controls.Add(Me.btnApplyFilters)
        Me.pnlFilters.Controls.Add(Me.btnResetFilters)
        Me.pnlFilters.Controls.Add(Me.btnExportCSV)
        Me.pnlFilters.Controls.Add(Me.btnRefresh)
        Me.pnlFilters.Controls.Add(Me.btnClearLogs)
        Me.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFilters.Location = New System.Drawing.Point(0, 0)
        Me.pnlFilters.Name = "pnlFilters"
        Me.pnlFilters.Size = New System.Drawing.Size(1200, 170)
        Me.pnlFilters.TabIndex = 1
        '
        'lblSearch
        '
        Me.lblSearch.AutoSize = True
        Me.lblSearch.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblSearch.Location = New System.Drawing.Point(19, 17)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(56, 20)
        Me.lblSearch.TabIndex = 21
        Me.lblSearch.Text = "Search:"
        '
        'txtSearch
        '
        Me.txtSearch.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtSearch.Location = New System.Drawing.Point(19, 37)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(798, 30)
        Me.txtSearch.TabIndex = 19
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.Blue
        Me.btnSearch.FlatAppearance.BorderSize = 0
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnSearch.ForeColor = System.Drawing.Color.White
        Me.btnSearch.Location = New System.Drawing.Point(836, 37)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(150, 28)
        Me.btnSearch.TabIndex = 20
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'ActivityLogsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1200, 690)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.dgvActivityLogs)
        Me.Controls.Add(Me.pnlFilters)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.MinimumSize = New System.Drawing.Size(1000, 600)
        Me.Name = "ActivityLogsForm"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Activity Logs"
        CType(Me.dgvActivityLogs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.pnlFilters.ResumeLayout(False)
        Me.pnlFilters.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvActivityLogs As DataGridView
    Friend WithEvents dtpStartDate As DateTimePicker
    Friend WithEvents dtpEndDate As DateTimePicker
    Friend WithEvents cboUserType As ComboBox
    Friend WithEvents cboActionCategory As ComboBox
    Friend WithEvents cboSourceSystem As ComboBox
    Friend WithEvents cboStatus As ComboBox
    Friend WithEvents btnApplyFilters As Button
    Friend WithEvents btnResetFilters As Button
    Friend WithEvents btnExportCSV As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents btnClearLogs As Button
    Friend WithEvents lblStartDate As Label
    Friend WithEvents lblEndDate As Label
    Friend WithEvents lblUserType As Label
    Friend WithEvents lblCategory As Label
    Friend WithEvents lblSource As Label
    Friend WithEvents lblStatusFilter As Label
    Friend WithEvents pnlFilters As Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents btnPrevPage As System.Windows.Forms.Button
    Friend WithEvents btnNextPage As System.Windows.Forms.Button
    Friend WithEvents lblPageInfo As System.Windows.Forms.Label
    Friend WithEvents lblTotalLogs As System.Windows.Forms.Label
    Friend WithEvents lblSearch As Label
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents btnSearch As Button
End Class
