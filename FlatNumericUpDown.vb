Imports System.Drawing
Imports System.Windows.Forms
Imports System.ComponentModel

<DefaultEvent("ValueChanged")>
Public Class FlatNumericUpDown
    Inherits Control

    Private _value As Decimal = 0
    Private _minimum As Decimal = 0
    Private _maximum As Decimal = 100
    Private _increment As Decimal = 1
    Private _decimalPlaces As Integer = 0
    Private txtValue As TextBox
    Private pnlButtons As Panel
    Private _isFocused As Boolean = False
    Private _borderRadius As Integer = 6
    Private _buttonBackColor As Color = Color.FromArgb(60, 60, 60)
    Private _buttonForeColor As Color = Color.White
    Private _borderColor As Color = Color.FromArgb(190, 190, 190)
    Private _focusedBorderColor As Color = Color.FromArgb(80, 80, 80)

    Public Sub New()
        Me.Size = New Size(180, 30)
        Me.BackColor = Color.FromArgb(245, 245, 245)
        Me.DoubleBuffered = True
        Me.SetStyle(ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw Or ControlStyles.SupportsTransparentBackColor, True)
        InitializeControls()
    End Sub

    Private Sub InitializeControls()
        ' Panel for buttons (dark background on right side)
        pnlButtons = New Panel()
        pnlButtons.BackColor = _buttonBackColor
        UpdateButtonPanelSize()

        ' Up button
        Dim btnUp As New Button()
        btnUp.FlatStyle = FlatStyle.Flat
        btnUp.FlatAppearance.BorderSize = 0
        btnUp.FlatAppearance.MouseOverBackColor = Color.FromArgb(80, 80, 80)
        btnUp.BackColor = Color.Transparent
        btnUp.Text = "▲"
        btnUp.Font = New Font("Segoe UI Symbol", 9, FontStyle.Regular)
        btnUp.ForeColor = _buttonForeColor
        btnUp.Cursor = Cursors.Hand
        AddHandler btnUp.Click, Sub() IncrementValue()
        AddHandler btnUp.Paint, AddressOf DrawUpButton
        pnlButtons.Controls.Add(btnUp)

        ' Down button
        Dim btnDown As New Button()
        btnDown.FlatStyle = FlatStyle.Flat
        btnDown.FlatAppearance.BorderSize = 0
        btnDown.FlatAppearance.MouseOverBackColor = Color.FromArgb(80, 80, 80)
        btnDown.BackColor = Color.Transparent
        btnDown.Text = "▼"
        btnDown.Font = New Font("Segoe UI Symbol", 9, FontStyle.Regular)
        btnDown.ForeColor = _buttonForeColor
        btnDown.Cursor = Cursors.Hand
        AddHandler btnDown.Click, Sub() DecrementValue()
        AddHandler btnDown.Paint, AddressOf DrawDownButton
        pnlButtons.Controls.Add(btnDown)

        UpdateButtonSizes()

        Me.Controls.Add(pnlButtons)

        ' TextBox for value
        txtValue = New TextBox()
        txtValue.BorderStyle = BorderStyle.None
        txtValue.BackColor = Me.BackColor
        txtValue.Font = Me.Font
        txtValue.ForeColor = Me.ForeColor
        txtValue.TextAlign = HorizontalAlignment.Left
        txtValue.Text = FormatValue(_value)
        AddHandler txtValue.KeyPress, AddressOf TxtValue_KeyPress
        AddHandler txtValue.Leave, AddressOf TxtValue_Leave
        AddHandler txtValue.KeyDown, AddressOf TxtValue_KeyDown
        AddHandler txtValue.GotFocus, AddressOf TxtValue_GotFocus
        AddHandler txtValue.LostFocus, AddressOf TxtValue_LostFocus
        Me.Controls.Add(txtValue)

        UpdateTextBoxPosition()
    End Sub

    Private Sub UpdateButtonPanelSize()
        If pnlButtons Is Nothing Then Return
        Dim buttonWidth As Integer = Math.Max(25, CInt(Me.Height * 0.8))
        pnlButtons.Size = New Size(buttonWidth, Me.Height - 4)
        pnlButtons.Location = New Point(Me.Width - buttonWidth - 2, 2)
    End Sub

    Private Sub UpdateButtonSizes()
        If pnlButtons Is Nothing OrElse pnlButtons.Controls.Count < 2 Then Return
        Dim btnHeight As Integer = (pnlButtons.Height - 1) \ 2

        ' Update up button
        pnlButtons.Controls(0).Size = New Size(pnlButtons.Width, btnHeight)
        pnlButtons.Controls(0).Location = New Point(0, 0)

        ' Update down button
        pnlButtons.Controls(1).Size = New Size(pnlButtons.Width, btnHeight)
        pnlButtons.Controls(1).Location = New Point(0, btnHeight + 1)
    End Sub

    Private Sub UpdateTextBoxPosition()
        If txtValue Is Nothing Then Return
        Dim leftPadding As Integer = Math.Max(8, CInt(Me.Height * 0.3))
        Dim topPadding As Integer = (Me.Height - txtValue.Height) \ 2
        Dim buttonWidth As Integer = If(pnlButtons IsNot Nothing, pnlButtons.Width + 6, 35)

        txtValue.Location = New Point(leftPadding, topPadding)
        txtValue.Size = New Size(Me.Width - buttonWidth - leftPadding, txtValue.Height)
    End Sub

    Private Function FormatValue(val As Decimal) As String
        Return val.ToString("F" & _decimalPlaces)
    End Function

    Private Sub TxtValue_GotFocus(sender As Object, e As EventArgs)
        _isFocused = True
        Me.Invalidate()
    End Sub

    Private Sub TxtValue_LostFocus(sender As Object, e As EventArgs)
        _isFocused = False
        Me.Invalidate()
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)

        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

        ' Draw rounded rectangle background
        Using path As New Drawing2D.GraphicsPath()
            path.AddArc(0, 0, _borderRadius, _borderRadius, 180, 90)
            path.AddArc(Me.Width - _borderRadius - 1, 0, _borderRadius, _borderRadius, 270, 90)
            path.AddArc(Me.Width - _borderRadius - 1, Me.Height - _borderRadius - 1, _borderRadius, _borderRadius, 0, 90)
            path.AddArc(0, Me.Height - _borderRadius - 1, _borderRadius, _borderRadius, 90, 90)
            path.CloseFigure()

            Me.Region = New Region(path)

            ' Draw border
            Dim borderColor As Color = If(_isFocused, _focusedBorderColor, _borderColor)
            Using pen As New Pen(borderColor, 1)
                e.Graphics.DrawPath(pen, path)
            End Using
        End Using
    End Sub

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        UpdateButtonPanelSize()
        UpdateButtonSizes()
        UpdateTextBoxPosition()
        Me.Invalidate()
    End Sub

    Protected Overrides Sub OnFontChanged(e As EventArgs)
        MyBase.OnFontChanged(e)
        If txtValue IsNot Nothing Then
            txtValue.Font = Me.Font
            UpdateTextBoxPosition()
        End If
    End Sub

    Protected Overrides Sub OnForeColorChanged(e As EventArgs)
        MyBase.OnForeColorChanged(e)
        If txtValue IsNot Nothing Then
            txtValue.ForeColor = Me.ForeColor
        End If
    End Sub

    Private Sub IncrementValue()
        If _value + _increment <= _maximum Then
            Value = _value + _increment
        End If
    End Sub

    Private Sub DecrementValue()
        If _value - _increment >= _minimum Then
            Value = _value - _increment
        End If
    End Sub

    Private Sub TxtValue_KeyPress(sender As Object, e As KeyPressEventArgs)
        ' Allow only numbers, negative sign, decimal point, and control keys
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "."c AndAlso e.KeyChar <> "-"c Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtValue_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Up Then
            IncrementValue()
            e.Handled = True
        ElseIf e.KeyCode = Keys.Down Then
            DecrementValue()
            e.Handled = True
        End If
    End Sub

    Private Sub TxtValue_Leave(sender As Object, e As EventArgs)
        Dim newValue As Decimal
        If Decimal.TryParse(txtValue.Text, newValue) Then
            Value = newValue
        Else
            txtValue.Text = FormatValue(_value)
        End If
    End Sub

    Private Sub DrawUpButton(sender As Object, e As PaintEventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

        ' Calculate arrow size based on button size
        Dim arrowSize As Integer = Math.Min(btn.Width, btn.Height) \ 3
        Dim centerX As Integer = btn.Width \ 2
        Dim centerY As Integer = btn.Height \ 2

        ' Draw triangle pointing up
        Dim points As Point() = {
            New Point(centerX, centerY - arrowSize \ 2),
            New Point(centerX - arrowSize, centerY + arrowSize \ 2),
            New Point(centerX + arrowSize, centerY + arrowSize \ 2)
        }

        Using brush As New SolidBrush(_buttonForeColor)
            e.Graphics.FillPolygon(brush, points)
        End Using
    End Sub

    Private Sub DrawDownButton(sender As Object, e As PaintEventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

        ' Calculate arrow size based on button size
        Dim arrowSize As Integer = Math.Min(btn.Width, btn.Height) \ 3
        Dim centerX As Integer = btn.Width \ 2
        Dim centerY As Integer = btn.Height \ 2

        ' Draw triangle pointing down
        Dim points As Point() = {
            New Point(centerX, centerY + arrowSize \ 2),
            New Point(centerX - arrowSize, centerY - arrowSize \ 2),
            New Point(centerX + arrowSize, centerY - arrowSize \ 2)
        }

        Using brush As New SolidBrush(_buttonForeColor)
            e.Graphics.FillPolygon(brush, points)
        End Using
    End Sub

    Protected Overrides Sub OnBackColorChanged(e As EventArgs)
        MyBase.OnBackColorChanged(e)
        If txtValue IsNot Nothing Then
            txtValue.BackColor = Me.BackColor
        End If
    End Sub

    ' ===== CUSTOMIZABLE PROPERTIES =====

    <Category("Appearance")>
    <Description("The border radius for rounded corners")>
    Public Property BorderRadius As Integer
        Get
            Return _borderRadius
        End Get
        Set(value As Integer)
            _borderRadius = value
            Me.Invalidate()
        End Set
    End Property

    <Category("Appearance")>
    <Description("The background color of the up/down buttons")>
    Public Property ButtonBackColor As Color
        Get
            Return _buttonBackColor
        End Get
        Set(value As Color)
            _buttonBackColor = value
            If pnlButtons IsNot Nothing Then
                pnlButtons.BackColor = value
            End If
        End Set
    End Property

    <Category("Appearance")>
    <Description("The foreground color of the up/down arrow symbols")>
    Public Property ButtonForeColor As Color
        Get
            Return _buttonForeColor
        End Get
        Set(value As Color)
            _buttonForeColor = value
            If pnlButtons IsNot Nothing Then
                For Each ctrl As Control In pnlButtons.Controls
                    ctrl.ForeColor = value
                Next
            End If
        End Set
    End Property

    <Category("Appearance")>
    <Description("The border color when not focused")>
    Public Property BorderColor As Color
        Get
            Return _borderColor
        End Get
        Set(value As Color)
            _borderColor = value
            Me.Invalidate()
        End Set
    End Property

    <Category("Appearance")>
    <Description("The border color when focused")>
    Public Property FocusedBorderColor As Color
        Get
            Return _focusedBorderColor
        End Get
        Set(value As Color)
            _focusedBorderColor = value
            Me.Invalidate()
        End Set
    End Property

    <Category("Data")>
    <Description("The current numeric value")>
    Public Property Value As Decimal
        Get
            Return _value
        End Get
        Set(value As Decimal)
            If value < _minimum Then value = _minimum
            If value > _maximum Then value = _maximum
            _value = value
            If txtValue IsNot Nothing Then
                txtValue.Text = FormatValue(_value)
            End If
            RaiseEvent ValueChanged(Me, EventArgs.Empty)
        End Set
    End Property

    <Category("Data")>
    <Description("The minimum allowed value")>
    Public Property Minimum As Decimal
        Get
            Return _minimum
        End Get
        Set(value As Decimal)
            _minimum = value
            If _value < _minimum Then Me.Value = _minimum
        End Set
    End Property

    <Category("Data")>
    <Description("The maximum allowed value")>
    Public Property Maximum As Decimal
        Get
            Return _maximum
        End Get
        Set(value As Decimal)
            _maximum = value
            If _value > _maximum Then Me.Value = _maximum
        End Set
    End Property

    <Category("Data")>
    <Description("The amount to increment/decrement")>
    Public Property Increment As Decimal
        Get
            Return _increment
        End Get
        Set(value As Decimal)
            _increment = value
        End Set
    End Property

    <Category("Data")>
    <Description("The number of decimal places to display")>
    Public Property DecimalPlaces As Integer
        Get
            Return _decimalPlaces
        End Get
        Set(value As Integer)
            _decimalPlaces = value
            If txtValue IsNot Nothing Then
                txtValue.Text = FormatValue(_value)
            End If
        End Set
    End Property

    <Category("Action")>
    <Description("Occurs when the Value property changes")>
    Public Event ValueChanged As EventHandler

End Class

' ===== HOW TO USE =====
' 
' 1. Create a new class file in your project (Project -> Add Class)
' 2. Name it "FlatNumericUpDown.vb"
' 3. Paste this entire code into that file
' 4. Build your project (Build -> Build Solution)
' 5. The control will appear in your Toolbox under "YourProjectName Components"
' 6. Drag it onto your form from the Toolbox
' 7. Customize it in the Properties window!
'
' Available Properties in Designer:
' - Value: Current number value
' - Minimum: Minimum allowed value
' - Maximum: Maximum allowed value
' - Increment: Step amount for up/down buttons
' - DecimalPlaces: Number of decimal places
' - BorderRadius: Roundness of corners (default 6)
' - ButtonBackColor: Color of the button panel (default dark gray)
' - ButtonForeColor: Color of the arrows (default white)
' - BorderColor: Normal border color
' - FocusedBorderColor: Border color when clicked
' - BackColor: Background color of the control
' - Font: Text font
' - ForeColor: Text color