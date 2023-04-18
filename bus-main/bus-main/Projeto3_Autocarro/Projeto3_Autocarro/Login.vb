Imports System.Drawing.Drawing2D

Public Class Login
    Dim LblTit As New Label
    Dim BtnComprarBilhete As New Button
    Dim BtnAdmin As New Button
    Dim BackGround As New PictureBox

    Private Sub Login_closed(sender As Object, e As EventArgs) Handles MyBase.Closed
        Application.Exit()
    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(300, 300)
        Me.Icon = New Icon("C:\Users\vkras\OneDrive\Ambiente de Trabalho\bus-main\bus-main\Projeto3_Autocarro\Projeto3_Autocarro\bin\Debug\login.ico")

        LblTit.Text = "Bonecos BUS"
        LblTit.Font = New Font("Algerian", 18)
        LblTit.Location = New Point(50, 10)
        LblTit.Size = New Size(200, 50)
        LblTit.TextAlign = ContentAlignment.MiddleCenter
        Me.Controls.Add(LblTit)

        BackGround.Image = Image.FromFile("C:\Users\vkras\OneDrive\Ambiente de Trabalho\bus-main\bus-main\Projeto3_Autocarro\Projeto3_Autocarro\bin\Debug\bus.png")
        BackGround.SizeMode = PictureBoxSizeMode.StretchImage
        BackGround.Location = New Point(100, 60)
        BackGround.Size = New Size(100, 100)
        Me.Controls.Add(BackGround)

        BtnComprarBilhete.Text = "Comprar Bilhete"
        BtnComprarBilhete.BackColor = Color.LightGray
        BtnComprarBilhete.Font = New Font("Arial", 12)
        BtnComprarBilhete.Location = New Point(75, 170)
        BtnComprarBilhete.Size = New Size(150, 50)
        BtnComprarBilhete.TextAlign = ContentAlignment.MiddleCenter
        Me.Controls.Add(BtnComprarBilhete)

        BtnAdmin.Text = "Administração"
        BtnAdmin.BackColor = Color.LightGray
        BtnAdmin.Font = New Font("Arial", 12)
        BtnAdmin.Location = New Point(75, 230)
        BtnAdmin.Size = New Size(150, 50)
        BtnAdmin.TextAlign = ContentAlignment.MiddleCenter
        Me.Controls.Add(BtnAdmin)

        AddHandler BtnComprarBilhete.Click, AddressOf ComprarBilhete
        AddHandler BtnAdmin.Click, AddressOf Administracao
    End Sub

    Sub ComprarBilhete(ByVal sender As Object, e As EventArgs)
        Form1.Show()
        Me.Hide()
    End Sub

    Sub Administracao(ByVal sender As Object, e As EventArgs)
        Form2.Show()
        Me.Hide()
    End Sub
End Class