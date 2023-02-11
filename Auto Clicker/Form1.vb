Imports System.Runtime.InteropServices

Public Class Form1
    Declare Sub mouse_event Lib "user32" Alias "mouse_event" (ByVal dwFlags As Long, ByVal dx As Long, ByVal dy As Long, ByVal cButtons As Long, ByVal dwExtraInfo As Long)

    Public Const KEY_ALT As Integer = &H1
    Public Const _HOTKEY As Integer = &H312

    <DllImport("User32.dll")>
    Public Shared Function RegisterHotKey(ByVal hwnd As IntPtr,
                        ByVal id As Integer, ByVal fsModifiers As Integer,
                        ByVal vk As Integer) As Integer
    End Function

    <DllImport("User32.dll")>
    Public Shared Function UnregisterHotKey(ByVal hwnd As IntPtr,
                        ByVal id As Integer) As Integer
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'KeyPreview = True
        Me.Hide()
        Top = 0

        RegisterHotKey(Me.Handle, 1, KEY_ALT, Keys.F2)
        RegisterHotKey(Me.Handle, 2, KEY_ALT, Keys.F3)
        RegisterHotKey(Me.Handle, 3, KEY_ALT, Keys.F5)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        MyMethod()
        Label2.Text += 1
    End Sub

    Private Sub MyMethod()
        Windows.Forms.Cursor.Position = New System.Drawing.Point(Windows.Forms.Cursor.Position)
        mouse_event(&H2, 0, 0, 0, 1) 'cursor will go down (like a click)
        mouse_event(&H4, 0, 0, 0, 1) ' cursor goes up again
    End Sub

    'Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
    '    If e.KeyCode = Keys.F3 Then
    '        Timer1.Start()
    '    Else
    '        If e.KeyCode = Keys.F4 Then
    '            Timer1.Stop()
    '        End If
    '    End If
    '    If e.KeyCode = Keys.Escape Then
    '        Me.Close()
    '    End If
    'End Sub

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If m.Msg = _HOTKEY Then
            Dim id As IntPtr = m.WParam
            Select Case (id.ToString)
                Case "1"
                    Timer1.Start()
                Case "2"
                    Timer1.Stop()
                Case "3"
                    Me.Close()
            End Select
        End If
        MyBase.WndProc(m)
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As System.Object,
                        ByVal e As System.Windows.Forms.FormClosingEventArgs) _
                        Handles MyBase.FormClosing
        UnregisterHotKey(Me.Handle, 1)
        UnregisterHotKey(Me.Handle, 2)
        UnregisterHotKey(Me.Handle, 3)
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        Me.Close()
    End Sub
End Class
