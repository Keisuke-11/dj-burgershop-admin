Imports System.Drawing.Drawing2D

Public Class RoundedButton
    Inherits Button

    ' Constructor with double buffering
    Public Sub New()
        ' Enable double buffering to reduce flickering
        Me.SetStyle(ControlStyles.UserPaint Or
                    ControlStyles.AllPaintingInWmPaint Or
                    ControlStyles.OptimizedDoubleBuffer Or
                    ControlStyles.SupportsTransparentBackColor, True)
        Me.UpdateStyles()
    End Sub

    Protected Overrides Sub OnPaint(pevent As PaintEventArgs)
        MyBase.OnPaint(pevent)

        pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias

        ' Create rounded rectangle path
        Using path As New GraphicsPath()
            Dim radius As Integer = 13
            path.AddArc(0, 0, radius, radius, 180, 90)
            path.AddArc(Me.Width - radius, 0, radius, radius, 270, 90)
            path.AddArc(Me.Width - radius, Me.Height - radius, radius, radius, 0, 90)
            path.AddArc(0, Me.Height - radius, radius, radius, 90, 90)
            path.CloseAllFigures()

            ' Apply rounded region
            Me.Region = New Region(path)

            ' Optional: Draw border
            Using pen As New Pen(Color.FromArgb(44, 62, 80), 2)
                pevent.Graphics.DrawPath(pen, path)
            End Using
        End Using
    End Sub
End Class