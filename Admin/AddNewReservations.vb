
Imports System.Drawing.Drawing2D

Public Class PanelCreateReservation

    Private Sub AddNewReservations_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With NumericUpDown1
            .BorderStyle = BorderStyle.FixedSingle
            .BackColor = Color.FromArgb(245, 245, 245) ' Light gray background
            .ForeColor = Color.FromArgb(50, 50, 50)
            .Font = New Font("Segoe UI", 10.0F)
            .TextAlign = HorizontalAlignment.Left


            ' Set min/max values
            .Minimum = 0
            .Maximum = 100
            .Value = 2
            .DecimalPlaces = 0
        End With

        ' Remove the border and customize appearance
        StyleNumericUpDown(NumericUpDown1)
        RoundButton(btnCreateReservation, 8)
        RoundButton(btnCancel, 8)
        RoundFormCorners(20)

    End Sub



    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnCreateReservation_Click(sender As Object, e As EventArgs) Handles btnCreateReservation.Click

        If String.IsNullOrWhiteSpace(txtFullName.Text) Then
            MessageBox.Show("Please enter full name", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFullName.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(txtEmail.Text) Then
            MessageBox.Show("Please enter email address", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtEmail.Focus()
            Return
        End If


        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub



    Private Sub btnClose_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub
    Private Sub StyleNumericUpDown(nud As NumericUpDown)

        For Each ctrl As Control In nud.Controls
            If TypeOf ctrl Is TextBox Then
                Dim tb As TextBox = DirectCast(ctrl, TextBox)
                tb.BorderStyle = BorderStyle.None
                tb.BackColor = Color.FromArgb(245, 245, 245)
                tb.Font = New Font("Segoe UI", 10.0F)
            End If
        Next
    End Sub

    Private Sub NumericUpDown1_Paint(sender As Object, e As PaintEventArgs) Handles NumericUpDown1.Paint
        Dim nud As NumericUpDown = DirectCast(sender, NumericUpDown)

        ' Draw a subtle border
        Using pen As New Pen(Color.FromArgb(200, 200, 200), 1)
            e.Graphics.DrawRectangle(pen, 0, 0, nud.Width - 1, nud.Height - 1)
        End Using
    End Sub
    Private Sub RoundFormCorners(radius As Integer)
        Dim gp As New Drawing.Drawing2D.GraphicsPath()
        gp.AddArc(0, 0, radius, radius, 180, 90)
        gp.AddArc(Me.Width - radius, 0, radius, radius, 270, 90)
        gp.AddArc(Me.Width - radius, Me.Height - radius, radius, radius, 0, 90)
        gp.AddArc(0, Me.Height - radius, radius, radius, 90, 90)
        gp.CloseFigure()
        Me.Region = New Region(gp)
    End Sub
    Private Sub RoundButton(btn As Button, radius As Integer)
        Dim path As New GraphicsPath()
        path.StartFigure()
        path.AddArc(New Rectangle(0, 0, radius, radius), 180, 90)
        path.AddArc(New Rectangle(btn.Width - radius, 0, radius, radius), 270, 90)
        path.AddArc(New Rectangle(btn.Width - radius, btn.Height - radius, radius, radius), 0, 90)
        path.AddArc(New Rectangle(0, btn.Height - radius, radius, radius), 90, 90)
        path.CloseFigure()
        btn.Region = New Region(path)
    End Sub

    Private Sub ComboBox_DrawItem(sender As Object, e As DrawItemEventArgs) _
        Handles cmbEventType.DrawItem

        If e.Index < 0 Then Return
        Dim cmb As ComboBox = DirectCast(sender, ComboBox)
        e.DrawBackground()
        e.Graphics.DrawString(cmb.Items(e.Index).ToString(), cmb.Font, Brushes.Black, e.Bounds)
        e.DrawFocusRectangle()
    End Sub
    Private Sub FormAddNewReservations_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        Me.Close()
    End Sub

End Class