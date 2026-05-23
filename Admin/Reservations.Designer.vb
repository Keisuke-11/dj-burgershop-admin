<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Reservations
    Inherits System.Windows.Forms.Form

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

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnUpdateStatus = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.txtSearch = New Global.InformationManagement.RoundedPane2()
        Me.TextBoxSearch = New System.Windows.Forms.TextBox()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.btnViewCalendar = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnFilterWebsite = New System.Windows.Forms.Button()
        Me.btnFilterPOS = New System.Windows.Forms.Button()
        Me.btnFilterAll = New System.Windows.Forms.Button()
        Me.lblSourceFilter = New System.Windows.Forms.Label()
        Me.btnViewCompleted = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboRecordsPerPage = New System.Windows.Forms.ComboBox()
        Me.btnViewAll = New System.Windows.Forms.Button()
        Me.btnViewCancelled = New System.Windows.Forms.Button()
        Me.btnViewConfirmed = New System.Windows.Forms.Button()
        Me.btnViewPending = New System.Windows.Forms.Button()
        Me.lblFilter = New System.Windows.Forms.Label()
        Me.btnLastPage = New System.Windows.Forms.Button()
        Me.btnNextPage = New System.Windows.Forms.Button()
        Me.btnPrevPage = New System.Windows.Forms.Button()
        Me.btnFirstPage = New System.Windows.Forms.Button()
        Me.Reservation = New System.Windows.Forms.DataGridView()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblPageInfo = New System.Windows.Forms.Label()
        Me.lblTotalReservations = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.txtSearch.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.Reservation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Red
        Me.Panel1.Controls.Add(Me.lblTitle)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1461, 80)
        Me.Panel1.TabIndex = 0
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 21.75!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(30, 15)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(482, 50)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Reservations Management"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.GhostWhite
        Me.Panel2.Controls.Add(Me.btnUpdateStatus)
        Me.Panel2.Controls.Add(Me.btnDelete)
        Me.Panel2.Controls.Add(Me.btnRefresh)
        Me.Panel2.Controls.Add(Me.txtSearch)
        Me.Panel2.Controls.Add(Me.lblSearch)
        Me.Panel2.Controls.Add(Me.btnViewCalendar)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel2.Location = New System.Drawing.Point(0, 80)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(15, 14, 15, 14)
        Me.Panel2.Size = New System.Drawing.Size(1461, 79)
        Me.Panel2.TabIndex = 1
        '
        'btnUpdateStatus
        '
        Me.btnUpdateStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUpdateStatus.BackColor = System.Drawing.Color.Green
        Me.btnUpdateStatus.FlatAppearance.BorderSize = 0
        Me.btnUpdateStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdateStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnUpdateStatus.ForeColor = System.Drawing.Color.White
        Me.btnUpdateStatus.Location = New System.Drawing.Point(969, 18)
        Me.btnUpdateStatus.Margin = New System.Windows.Forms.Padding(4)
        Me.btnUpdateStatus.Name = "btnUpdateStatus"
        Me.btnUpdateStatus.Size = New System.Drawing.Size(157, 43)
        Me.btnUpdateStatus.TabIndex = 9
        Me.btnUpdateStatus.Text = "Update Status"
        Me.btnUpdateStatus.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.BackColor = System.Drawing.Color.Red
        Me.btnDelete.FlatAppearance.BorderSize = 0
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnDelete.ForeColor = System.Drawing.Color.White
        Me.btnDelete.Location = New System.Drawing.Point(1135, 18)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(133, 43)
        Me.btnDelete.TabIndex = 4
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.BackColor = System.Drawing.Color.Blue
        Me.btnRefresh.FlatAppearance.BorderSize = 0
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnRefresh.ForeColor = System.Drawing.Color.White
        Me.btnRefresh.Location = New System.Drawing.Point(829, 20)
        Me.btnRefresh.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(133, 43)
        Me.btnRefresh.TabIndex = 2
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.BackColor = System.Drawing.Color.Transparent
        Me.txtSearch.BorderColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtSearch.BorderThickness = 1
        Me.txtSearch.Controls.Add(Me.TextBoxSearch)
        Me.txtSearch.CornerRadius = 10
        Me.txtSearch.FillColor = System.Drawing.Color.Snow
        Me.txtSearch.Location = New System.Drawing.Point(136, 14)
        Me.txtSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(637, 47)
        Me.txtSearch.TabIndex = 1
        '
        'TextBoxSearch
        '
        Me.TextBoxSearch.BackColor = System.Drawing.Color.Snow
        Me.TextBoxSearch.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxSearch.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.TextBoxSearch.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.TextBoxSearch.Location = New System.Drawing.Point(20, 12)
        Me.TextBoxSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxSearch.Name = "TextBoxSearch"
        Me.TextBoxSearch.Size = New System.Drawing.Size(600, 23)
        Me.TextBoxSearch.TabIndex = 0
        Me.TextBoxSearch.Text = "Search reservations..."
        '
        'lblSearch
        '
        Me.lblSearch.AutoSize = True
        Me.lblSearch.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblSearch.Location = New System.Drawing.Point(33, 30)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(59, 20)
        Me.lblSearch.TabIndex = 0
        Me.lblSearch.Text = "Search:"
        '
        'btnViewCalendar
        '
        Me.btnViewCalendar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnViewCalendar.BackColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(162, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.btnViewCalendar.FlatAppearance.BorderSize = 0
        Me.btnViewCalendar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewCalendar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnViewCalendar.ForeColor = System.Drawing.Color.White
        Me.btnViewCalendar.Location = New System.Drawing.Point(1276, 18)
        Me.btnViewCalendar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnViewCalendar.Name = "btnViewCalendar"
        Me.btnViewCalendar.Size = New System.Drawing.Size(149, 43)
        Me.btnViewCalendar.TabIndex = 10
        Me.btnViewCalendar.Text = "View Calendar"
        Me.btnViewCalendar.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.GhostWhite
        Me.Panel3.Controls.Add(Me.btnFilterWebsite)
        Me.Panel3.Controls.Add(Me.btnFilterPOS)
        Me.Panel3.Controls.Add(Me.btnFilterAll)
        Me.Panel3.Controls.Add(Me.lblSourceFilter)
        Me.Panel3.Controls.Add(Me.btnViewCompleted)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.cboRecordsPerPage)
        Me.Panel3.Controls.Add(Me.btnViewAll)
        Me.Panel3.Controls.Add(Me.btnViewCancelled)
        Me.Panel3.Controls.Add(Me.btnViewConfirmed)
        Me.Panel3.Controls.Add(Me.btnViewPending)
        Me.Panel3.Controls.Add(Me.lblFilter)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 159)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(15, 14, 15, 14)
        Me.Panel3.Size = New System.Drawing.Size(1461, 80)
        Me.Panel3.TabIndex = 2
        '
        'btnFilterWebsite
        '
        Me.btnFilterWebsite.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFilterWebsite.BackColor = System.Drawing.Color.Green
        Me.btnFilterWebsite.FlatAppearance.BorderSize = 0
        Me.btnFilterWebsite.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFilterWebsite.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.btnFilterWebsite.ForeColor = System.Drawing.Color.White
        Me.btnFilterWebsite.Location = New System.Drawing.Point(929, 30)
        Me.btnFilterWebsite.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnFilterWebsite.Name = "btnFilterWebsite"
        Me.btnFilterWebsite.Size = New System.Drawing.Size(85, 37)
        Me.btnFilterWebsite.TabIndex = 17
        Me.btnFilterWebsite.Text = "Website"
        Me.btnFilterWebsite.UseVisualStyleBackColor = False
        '
        'btnFilterPOS
        '
        Me.btnFilterPOS.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFilterPOS.BackColor = System.Drawing.Color.Blue
        Me.btnFilterPOS.FlatAppearance.BorderSize = 0
        Me.btnFilterPOS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFilterPOS.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.btnFilterPOS.ForeColor = System.Drawing.Color.White
        Me.btnFilterPOS.Location = New System.Drawing.Point(869, 30)
        Me.btnFilterPOS.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnFilterPOS.Name = "btnFilterPOS"
        Me.btnFilterPOS.Size = New System.Drawing.Size(55, 37)
        Me.btnFilterPOS.TabIndex = 16
        Me.btnFilterPOS.Text = "POS"
        Me.btnFilterPOS.UseVisualStyleBackColor = False
        '
        'btnFilterAll
        '
        Me.btnFilterAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFilterAll.BackColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.btnFilterAll.FlatAppearance.BorderSize = 0
        Me.btnFilterAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFilterAll.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.btnFilterAll.ForeColor = System.Drawing.Color.White
        Me.btnFilterAll.Location = New System.Drawing.Point(809, 30)
        Me.btnFilterAll.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnFilterAll.Name = "btnFilterAll"
        Me.btnFilterAll.Size = New System.Drawing.Size(55, 37)
        Me.btnFilterAll.TabIndex = 15
        Me.btnFilterAll.Text = "All"
        Me.btnFilterAll.UseVisualStyleBackColor = False
        '
        'lblSourceFilter
        '
        Me.lblSourceFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSourceFilter.AutoSize = True
        Me.lblSourceFilter.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblSourceFilter.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblSourceFilter.Location = New System.Drawing.Point(799, 9)
        Me.lblSourceFilter.Name = "lblSourceFilter"
        Me.lblSourceFilter.Size = New System.Drawing.Size(60, 20)
        Me.lblSourceFilter.TabIndex = 14
        Me.lblSourceFilter.Text = "Source:"
        '
        'btnViewCompleted
        '
        Me.btnViewCompleted.BackColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(162, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.btnViewCompleted.FlatAppearance.BorderSize = 0
        Me.btnViewCompleted.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewCompleted.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnViewCompleted.ForeColor = System.Drawing.Color.White
        Me.btnViewCompleted.Location = New System.Drawing.Point(363, 31)
        Me.btnViewCompleted.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnViewCompleted.Name = "btnViewCompleted"
        Me.btnViewCompleted.Size = New System.Drawing.Size(115, 37)
        Me.btnViewCompleted.TabIndex = 13
        Me.btnViewCompleted.Text = "Completed"
        Me.btnViewCompleted.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(1099, 31)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(134, 20)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Records per page:"
        '
        'cboRecordsPerPage
        '
        Me.cboRecordsPerPage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboRecordsPerPage.BackColor = System.Drawing.Color.Snow
        Me.cboRecordsPerPage.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboRecordsPerPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRecordsPerPage.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cboRecordsPerPage.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cboRecordsPerPage.FormattingEnabled = True
        Me.cboRecordsPerPage.ItemHeight = 24
        Me.cboRecordsPerPage.Location = New System.Drawing.Point(1241, 28)
        Me.cboRecordsPerPage.Margin = New System.Windows.Forms.Padding(4)
        Me.cboRecordsPerPage.Name = "cboRecordsPerPage"
        Me.cboRecordsPerPage.Size = New System.Drawing.Size(120, 30)
        Me.cboRecordsPerPage.TabIndex = 11
        '
        'btnViewAll
        '
        Me.btnViewAll.BackColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.btnViewAll.FlatAppearance.BorderSize = 0
        Me.btnViewAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewAll.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnViewAll.ForeColor = System.Drawing.Color.White
        Me.btnViewAll.Location = New System.Drawing.Point(39, 31)
        Me.btnViewAll.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnViewAll.Name = "btnViewAll"
        Me.btnViewAll.Size = New System.Drawing.Size(75, 37)
        Me.btnViewAll.TabIndex = 4
        Me.btnViewAll.Text = "All"
        Me.btnViewAll.UseVisualStyleBackColor = False
        '
        'btnViewCancelled
        '
        Me.btnViewCancelled.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.btnViewCancelled.FlatAppearance.BorderSize = 0
        Me.btnViewCancelled.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewCancelled.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnViewCancelled.ForeColor = System.Drawing.Color.White
        Me.btnViewCancelled.Location = New System.Drawing.Point(484, 31)
        Me.btnViewCancelled.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnViewCancelled.Name = "btnViewCancelled"
        Me.btnViewCancelled.Size = New System.Drawing.Size(115, 37)
        Me.btnViewCancelled.TabIndex = 3
        Me.btnViewCancelled.Text = "Cancelled"
        Me.btnViewCancelled.UseVisualStyleBackColor = False
        '
        'btnViewConfirmed
        '
        Me.btnViewConfirmed.BackColor = System.Drawing.Color.Green
        Me.btnViewConfirmed.FlatAppearance.BorderSize = 0
        Me.btnViewConfirmed.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewConfirmed.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnViewConfirmed.ForeColor = System.Drawing.Color.White
        Me.btnViewConfirmed.Location = New System.Drawing.Point(241, 31)
        Me.btnViewConfirmed.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnViewConfirmed.Name = "btnViewConfirmed"
        Me.btnViewConfirmed.Size = New System.Drawing.Size(115, 37)
        Me.btnViewConfirmed.TabIndex = 2
        Me.btnViewConfirmed.Text = "Confirmed"
        Me.btnViewConfirmed.UseVisualStyleBackColor = False
        '
        'btnViewPending
        '
        Me.btnViewPending.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(7, Byte), Integer))
        Me.btnViewPending.FlatAppearance.BorderSize = 0
        Me.btnViewPending.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewPending.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnViewPending.ForeColor = System.Drawing.Color.White
        Me.btnViewPending.Location = New System.Drawing.Point(120, 31)
        Me.btnViewPending.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnViewPending.Name = "btnViewPending"
        Me.btnViewPending.Size = New System.Drawing.Size(115, 37)
        Me.btnViewPending.TabIndex = 1
        Me.btnViewPending.Text = "Pending"
        Me.btnViewPending.UseVisualStyleBackColor = False
        '
        'lblFilter
        '
        Me.lblFilter.AutoSize = True
        Me.lblFilter.BackColor = System.Drawing.Color.Transparent
        Me.lblFilter.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblFilter.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblFilter.Location = New System.Drawing.Point(35, 6)
        Me.lblFilter.Name = "lblFilter"
        Me.lblFilter.Size = New System.Drawing.Size(93, 20)
        Me.lblFilter.TabIndex = 0
        Me.lblFilter.Text = "Filter Status:"
        '
        'btnLastPage
        '
        Me.btnLastPage.BackColor = System.Drawing.Color.Silver
        Me.btnLastPage.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLastPage.FlatAppearance.BorderSize = 0
        Me.btnLastPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLastPage.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnLastPage.ForeColor = System.Drawing.Color.Black
        Me.btnLastPage.Location = New System.Drawing.Point(893, 7)
        Me.btnLastPage.Margin = New System.Windows.Forms.Padding(4)
        Me.btnLastPage.Name = "btnLastPage"
        Me.btnLastPage.Size = New System.Drawing.Size(93, 37)
        Me.btnLastPage.TabIndex = 10
        Me.btnLastPage.Text = "Last"
        Me.btnLastPage.UseVisualStyleBackColor = False
        '
        'btnNextPage
        '
        Me.btnNextPage.BackColor = System.Drawing.Color.Silver
        Me.btnNextPage.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNextPage.FlatAppearance.BorderSize = 0
        Me.btnNextPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNextPage.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnNextPage.ForeColor = System.Drawing.Color.Black
        Me.btnNextPage.Location = New System.Drawing.Point(787, 7)
        Me.btnNextPage.Margin = New System.Windows.Forms.Padding(4)
        Me.btnNextPage.Name = "btnNextPage"
        Me.btnNextPage.Size = New System.Drawing.Size(93, 37)
        Me.btnNextPage.TabIndex = 9
        Me.btnNextPage.Text = "Next"
        Me.btnNextPage.UseVisualStyleBackColor = False
        '
        'btnPrevPage
        '
        Me.btnPrevPage.BackColor = System.Drawing.Color.Silver
        Me.btnPrevPage.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrevPage.FlatAppearance.BorderSize = 0
        Me.btnPrevPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrevPage.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnPrevPage.ForeColor = System.Drawing.Color.Black
        Me.btnPrevPage.Location = New System.Drawing.Point(560, 7)
        Me.btnPrevPage.Margin = New System.Windows.Forms.Padding(4)
        Me.btnPrevPage.Name = "btnPrevPage"
        Me.btnPrevPage.Size = New System.Drawing.Size(93, 37)
        Me.btnPrevPage.TabIndex = 8
        Me.btnPrevPage.Text = "Prev"
        Me.btnPrevPage.UseVisualStyleBackColor = False
        '
        'btnFirstPage
        '
        Me.btnFirstPage.BackColor = System.Drawing.Color.Silver
        Me.btnFirstPage.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnFirstPage.FlatAppearance.BorderSize = 0
        Me.btnFirstPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFirstPage.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnFirstPage.ForeColor = System.Drawing.Color.Black
        Me.btnFirstPage.Location = New System.Drawing.Point(453, 7)
        Me.btnFirstPage.Margin = New System.Windows.Forms.Padding(4)
        Me.btnFirstPage.Name = "btnFirstPage"
        Me.btnFirstPage.Size = New System.Drawing.Size(93, 37)
        Me.btnFirstPage.TabIndex = 7
        Me.btnFirstPage.Text = "First"
        Me.btnFirstPage.UseVisualStyleBackColor = False
        '
        'Reservation
        '
        Me.Reservation.AllowUserToAddRows = False
        Me.Reservation.AllowUserToDeleteRows = False
        Me.Reservation.AllowUserToResizeRows = False
        Me.Reservation.BackgroundColor = System.Drawing.Color.White
        Me.Reservation.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Reservation.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.Reservation.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(50, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Reservation.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Reservation.ColumnHeadersHeight = 40
        Me.Reservation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.Reservation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Reservation.EnableHeadersVisualStyles = False
        Me.Reservation.Location = New System.Drawing.Point(0, 239)
        Me.Reservation.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Reservation.Name = "Reservation"
        Me.Reservation.ReadOnly = True
        Me.Reservation.RowHeadersVisible = False
        Me.Reservation.RowHeadersWidth = 51
        Me.Reservation.RowTemplate.Height = 35
        Me.Reservation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Reservation.Size = New System.Drawing.Size(1461, 403)
        Me.Reservation.TabIndex = 3
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.Controls.Add(Me.btnLastPage)
        Me.Panel4.Controls.Add(Me.btnNextPage)
        Me.Panel4.Controls.Add(Me.btnPrevPage)
        Me.Panel4.Controls.Add(Me.btnFirstPage)
        Me.Panel4.Controls.Add(Me.lblPageInfo)
        Me.Panel4.Controls.Add(Me.lblTotalReservations)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 642)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1461, 62)
        Me.Panel4.TabIndex = 4
        '
        'lblPageInfo
        '
        Me.lblPageInfo.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPageInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblPageInfo.Location = New System.Drawing.Point(667, 15)
        Me.lblPageInfo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPageInfo.Name = "lblPageInfo"
        Me.lblPageInfo.Size = New System.Drawing.Size(107, 21)
        Me.lblPageInfo.TabIndex = 8
        Me.lblPageInfo.Text = "Page 1 of 1"
        Me.lblPageInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalReservations
        '
        Me.lblTotalReservations.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTotalReservations.AutoSize = True
        Me.lblTotalReservations.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalReservations.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblTotalReservations.Location = New System.Drawing.Point(13, 15)
        Me.lblTotalReservations.Name = "lblTotalReservations"
        Me.lblTotalReservations.Size = New System.Drawing.Size(156, 20)
        Me.lblTotalReservations.TabIndex = 0
        Me.lblTotalReservations.Text = "Total Reservations: 0"
        '
        'Reservations
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1461, 704)
        Me.Controls.Add(Me.Reservation)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MinimumSize = New System.Drawing.Size(909, 632)
        Me.Name = "Reservations"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reservations Management"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.txtSearch.ResumeLayout(False)
        Me.txtSearch.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.Reservation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    ' ============================================================
    ' ADD THIS LINE at the very bottom of the Designer.vb file
    ' Right after the last "Friend WithEvents" declaration
    ' ============================================================

    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents txtSearch As Global.InformationManagement.RoundedPane2
    Friend WithEvents TextBoxSearch As TextBox
    Friend WithEvents lblSearch As Label
    Friend WithEvents btnRefresh As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents lblFilter As Label
    Friend WithEvents btnViewPending As Button
    Friend WithEvents btnViewConfirmed As Button
    Friend WithEvents btnViewCancelled As Button
    Friend WithEvents btnViewAll As Button
    Friend WithEvents Reservation As DataGridView
    Friend WithEvents Panel4 As Panel
    Friend WithEvents lblTotalReservations As Label
    Friend WithEvents btnUpdateStatus As Button
    Friend WithEvents btnLastPage As Button
    Friend WithEvents btnNextPage As Button
    Friend WithEvents btnPrevPage As Button
    Friend WithEvents btnFirstPage As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents cboRecordsPerPage As ComboBox
    Friend WithEvents lblPageInfo As Label
    Friend WithEvents btnViewCalendar As Button
    Friend WithEvents btnViewCompleted As Button
    Friend WithEvents lblSourceFilter As Label
    Friend WithEvents btnFilterAll As Button
    Friend WithEvents btnFilterPOS As Button
    Friend WithEvents btnFilterWebsite As Button
End Class
