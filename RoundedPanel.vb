Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports System.Drawing

Public Class RoundedPanel
    Inherits Panel

    Private _cornerRadius As Integer = 20

    ' Constructor with double buffering
    Public Sub New()
        ' Enable double buffering to reduce flickering
        Me.DoubleBuffered = True
        Me.SetStyle(ControlStyles.UserPaint Or
                    ControlStyles.AllPaintingInWmPaint Or
                    ControlStyles.OptimizedDoubleBuffer, True)
        Me.UpdateStyles()
    End Sub

    <Browsable(True), Category("Appearance")>
    Public Property CornerRadius As Integer
        Get
            Return _cornerRadius
        End Get
        Set(value As Integer)
            _cornerRadius = value
            Me.Invalidate() ' Redraw panel when radius changes
        End Set
    End Property

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

        Dim rect As Rectangle = Me.ClientRectangle
        rect.Width -= 1
        rect.Height -= 1

        Using path As New GraphicsPath()
            path.AddArc(rect.X, rect.Y, _cornerRadius, _cornerRadius, 180, 90)
            path.AddArc(rect.Right - _cornerRadius, rect.Y, _cornerRadius, _cornerRadius, 270, 90)
            path.AddArc(rect.Right - _cornerRadius, rect.Bottom - _cornerRadius, _cornerRadius, _cornerRadius, 0, 90)
            path.AddArc(rect.X, rect.Bottom - _cornerRadius, _cornerRadius, _cornerRadius, 90, 90)
            path.CloseAllFigures()

            Me.Region = New Region(path)

            Using brush As New SolidBrush(Me.BackColor)
                e.Graphics.FillPath(brush, path)
            End Using
        End Using
    End Sub
End Class