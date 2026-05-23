Imports System.Drawing.Drawing2D

Public Class Login
    Private Sub FormLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Center the panel horizontally and vertically

    End Sub
    Public Sub New()
        InitializeComponent()
        Me.DoubleBuffered = True
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer Or
                    ControlStyles.AllPaintingInWmPaint, True)
        Me.UpdateStyles()
    End Sub

    Private Sub AdminBot_Click(sender As Object, e As EventArgs) Handles AdminBot.Click
        ' Show the Admin login form
        Dim adminForm As New Adminlogin()

        ' Match the current Login form's state and size
        adminForm.WindowState = Me.WindowState
        adminForm.Size = Me.Size
        adminForm.Location = Me.Location

        adminForm.Show()
        Me.Hide()
    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Optional: open Login in normal state (not forced fullscreen)
        ' You can leave this empty or force fullscreen if you want:
        ' Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)
        Dim radius As Integer = 20 ' Adjust the corner radius
        Dim path As New GraphicsPath()

        ' Create a rounded rectangle path
        Dim rect As Rectangle = RoundedPanel1.ClientRectangle
        path.AddArc(rect.X, rect.Y, radius, radius, 180, 90)
        path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90)
        path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90)
        path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90)
        path.CloseFigure()

        ' Apply the path as the panel's region
        RoundedPanel1.Region = New Region(path)
    End Sub

End Class