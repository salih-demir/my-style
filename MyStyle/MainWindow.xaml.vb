Imports WindowsInput
Imports System.Windows.Media.Animation
Class MainWindow
    Private konum As Point
    Private kontrol As Boolean = False
    Public Sub New()
        InitializeComponent()
        InputSimulator.SimulateKeyDown(VirtualKeyCode.SNAPSHOT)
        Me.Background = New ImageBrush(System.Windows.Clipboard.GetImage())
    End Sub
    Dim x, y As Integer
    Sub Tik()
        Randomize()
        Dim sayı1 As Integer = (Rnd() * 1000) + 1
        Dim sayı2 As Integer = (Rnd() * 3) + 1
        Dim a As Storyboard = TryCast(Me.Resources("Storyboard" & sayı2), Storyboard)
        a.Begin()
    End Sub
    Sub mousekontrol()
        If kontrol = False Then
            konum = New Point(Mouse.GetPosition(Me).X, Mouse.GetPosition(Me).Y)
            kontrol = True
        Else
            If Math.Abs(Mouse.GetPosition(Me).X - konum.X) > 5 OrElse Math.Abs(Mouse.GetPosition(Me).Y - konum.Y) > 5 Then
                Me.Close()
            End If
        End If
    End Sub
    Private Sub MainWindow_KeyDown(sender As Object, e As System.Windows.Input.KeyEventArgs) Handles Me.KeyDown
        Me.Close()
    End Sub
    Private Sub MainWindow_MouseDown(sender As Object, e As System.Windows.Input.MouseButtonEventArgs) Handles Me.MouseDown
        Me.Close()
    End Sub
    Private Sub MainWindow_MouseMove(sender As Object, e As System.Windows.Input.MouseEventArgs) Handles Me.MouseMove
        mousekontrol()
    End Sub
    Private Sub MainWindow_TouchDown(sender As Object, e As System.Windows.Input.TouchEventArgs) Handles Me.TouchDown
        Me.Close()
    End Sub
    Private Sub MainWindow_TouchMove(sender As Object, e As System.Windows.Input.TouchEventArgs) Handles Me.TouchMove
        mousekontrol()
    End Sub
End Class