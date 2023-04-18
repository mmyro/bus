Imports System.IO

Public Class Form4
    Dim TxtNewPass As New TextBox
    Dim TxtNewConfirmPass As New TextBox
    Dim LblNewPasss As New Label
    Dim LblNewConfirmPass As New Label
    Dim BtnConfirmar As New Button

    Private Sub Form4_closed(sender As Object, e As EventArgs) Handles MyBase.Closed
        Application.Exit()
    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(250, 120)

        LblNewPasss.Text = "New Password"
        LblNewPasss.Font = New Font("Arial", 10)
        LblNewPasss.BorderStyle = BorderStyle.FixedSingle
        LblNewPasss.Location = New Point(20, 22)
        LblNewPasss.Size = New Size(110, 20)
        LblNewPasss.TextAlign = ContentAlignment.MiddleCenter
        Me.Controls.Add(LblNewPasss)

        LblNewConfirmPass.Text = "Confirm Pass"
        LblNewConfirmPass.Font = New Font("Arial", 10)
        LblNewConfirmPass.BorderStyle = BorderStyle.FixedSingle
        LblNewConfirmPass.Location = New Point(20, 52)
        LblNewConfirmPass.Size = New Size(110, 20)
        LblNewConfirmPass.TextAlign = ContentAlignment.MiddleCenter
        Me.Controls.Add(LblNewConfirmPass)

        TxtNewPass.BackColor = Color.LightGray
        TxtNewPass.Font = New Font("Arial", 10)
        TxtNewPass.Location = New Point(140, 20)
        TxtNewPass.PasswordChar = "*"
        Me.Controls.Add(TxtNewPass)

        TxtNewConfirmPass.BackColor = Color.LightGray
        TxtNewConfirmPass.Font = New Font("Arial", 10)
        TxtNewConfirmPass.Location = New Point(140, 50)
        TxtNewConfirmPass.PasswordChar = "*"
        Me.Controls.Add(TxtNewConfirmPass)

        BtnConfirmar.Text = "Confirmar"
        BtnConfirmar.BackColor = Color.LightGray
        BtnConfirmar.Font = New Font("Arial", 10)
        BtnConfirmar.Location = New Point(150, 80)
        BtnConfirmar.Size = New Size(90, 30)
        BtnConfirmar.TextAlign = ContentAlignment.MiddleCenter
        Me.Controls.Add(BtnConfirmar)

        AddHandler BtnConfirmar.Click, AddressOf novaPass
    End Sub

    Sub novaPass(ByVal sender As Object, e As EventArgs)
        Dim novaPass, ConfirmarPass As String
        novaPass = TxtNewPass.Text
            ConfirmarPass = TxtNewConfirmPass.Text
        If novaPass <> ConfirmarPass Then
            MsgBox("As palavras passes nao coincidem")
        Else
            Me.Hide()
            Form3.Show()
            If File.Exists("admin.txt") = True Then
                Dim escrever As New StreamWriter("admin.txt")
                escrever.Write(Form2.encrypted(novaPass))
                escrever.Close()
            Else
                MsgBox("Ficheiro nao existe")
            End If
        End If


    End Sub
End Class