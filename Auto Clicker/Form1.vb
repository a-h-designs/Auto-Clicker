Public Class Form1
    Declare Sub mouse_event Lib "user32" Alias "mouse_event" (ByVal dwFlags As Long, ByVal dx As Long, ByVal dy As Long, ByVal cButtons As Long, ByVal dwExtraInfo As Long)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        KeyPreview = True
        Top = 0
    End Sub

    Private Sub MyMethod()
        Windows.Forms.Cursor.Position = New System.Drawing.Point(Windows.Forms.Cursor.Position)
        mouse_event(&H2, 0, 0, 0, 1) 'cursor will go down (like a click)
        mouse_event(&H4, 0, 0, 0, 1) ' cursor goes up again
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        MyMethod()
        Label2.Text += 1
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Timer1.Start()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Timer1.Stop()
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F3 Then
            Timer1.Start()
        Else
            If e.KeyCode = Keys.F4 Then
                Timer1.Stop()
            End If
        End If
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
    End Sub
End Class
