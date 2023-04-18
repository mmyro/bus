Public Class Form2
    Dim TxtBoxPassword As New TextBox
    Dim BtnConfirmar As New Button


    Private Sub Form2_closed(sender As Object, e As EventArgs) Handles MyBase.Closed
        Application.Exit()
    End Sub
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(140, 90)

        TxtBoxPassword.BackColor = Color.LightGray
        TxtBoxPassword.Font = New Font("Arial", 12)
        TxtBoxPassword.Location = New Point(20, 22)
        TxtBoxPassword.PasswordChar = "*"
        Me.Controls.Add(TxtBoxPassword)

        BtnConfirmar.Text = "Confirmar"
        BtnConfirmar.BackColor = Color.LightGray
        BtnConfirmar.Font = New Font("Arial", 10)
        BtnConfirmar.Location = New Point(40, 58)
        BtnConfirmar.Size = New Size(80, 25)
        BtnConfirmar.TextAlign = ContentAlignment.MiddleCenter
        Me.Controls.Add(BtnConfirmar)

        AddHandler BtnConfirmar.Click, AddressOf confirmar
    End Sub

    Sub confirmar()
        Dim passFic As String
        FileOpen(1, "admin.txt", OpenMode.Input)
        passFic = LineInput(1)
        FileClose(1)
        MsgBox(encrypted(passFic))
        If TxtBoxPassword.Text = desencrypted(passFic) Then
            MsgBox("Confirmado")
            Me.Hide()
            Form3.Show()
        Else
            MsgBox("Errado")
        End If
    End Sub

    Public Function encrypted(pass) As String
        Dim NewPass As String = ""
        For Each letra As Char In pass
            NewPass += Chr(Asc(letra) + 2)
        Next
        Return NewPass
    End Function

    Public Function desencrypted(pass) As String
        Dim NewPass As String = ""
        For Each letra As Char In pass
            NewPass += Chr(Asc(letra) - 2)
        Next
        Return NewPass
    End Function
End Class