Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography
Imports Microsoft.VisualBasic.Devices
Imports Microsoft.Win32

Public Class Form1
    Dim BtnLugares(8, 3) As Button
    Dim BtnCompra As New Button
    Dim BtnVoltar As New Button
    Dim LblLugComprados As New Label
    Dim LblPrecoLugar As New Label
    Dim BtnPagar As New Button
    Dim num, preco, cont As Integer

    Private Sub Form1_closed(sender As Object, e As EventArgs) Handles MyBase.Closed
        Application.Exit()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(390, 390)
        Me.Icon = New Icon("C:\Users\vkras\OneDrive\Ambiente de Trabalho\bus-main\bus-main\Projeto3_Autocarro\Projeto3_Autocarro\bin\Debug\login.ico")
        Dim x, y, i, j, aux As Integer
        Dim strOcup(8) As String
        aux = 0
        FileOpen(1, "ocupacao.txt", OpenMode.Input)
        While Not EOF(1)
            strOcup(aux) = LineInput(1)
            aux += 1
        End While
        FileClose(1)
        y = 20
        For i = 0 To 8
            x = 20
            For j = 0 To 3
                BtnLugares(i, j) = New Button
                BtnLugares(i, j).Enabled = False
                BtnLugares(i, j).Image = Image.FromFile("C:\Users\vkras\OneDrive\Ambiente de Trabalho\bus-main\bus-main\Projeto3_Autocarro\Projeto3_Autocarro\bin\Debug\seat.png")
                BtnLugares(i, j).Size = New Size(30, 30)
                BtnLugares(i, j).Location = New Point(x, y)
                BtnLugares(i, j).Tag = 1
                Me.Controls.Add(BtnLugares(i, j))
                x += 40
                If strOcup(i)(j) = "1" Then
                    BtnLugares(i, j).Image = Image.FromFile("C:\Users\vkras\OneDrive\Ambiente de Trabalho\bus-main\bus-main\Projeto3_Autocarro\Projeto3_Autocarro\bin\Debug\seat1.png")
                    BtnLugares(i, j).Tag = 1
                ElseIf strOcup(i)(j) = "0" Then
                    BtnLugares(i, j).Image = Image.FromFile("C:\Users\vkras\OneDrive\Ambiente de Trabalho\bus-main\bus-main\Projeto3_Autocarro\Projeto3_Autocarro\bin\Debug\seat.png")
                    BtnLugares(i, j).Tag = 0
                ElseIf strOcup(i)(j) = "2" Then
                    BtnLugares(i, j).Image = Image.FromFile("C:\Users\vkras\OneDrive\Ambiente de Trabalho\bus-main\bus-main\Projeto3_Autocarro\Projeto3_Autocarro\bin\Debug\seat3.png")
                    BtnLugares(i, j).Tag = 2
                ElseIf strOcup(i)(j) = "3" Then
                    BtnLugares(i, j).Image = Image.FromFile("C:\Users\vkras\OneDrive\Ambiente de Trabalho\bus-main\bus-main\Projeto3_Autocarro\Projeto3_Autocarro\bin\Debug\seat4.png")
                    BtnLugares(i, j).Tag = 3
                End If
                If j = 1 Then
                    x += 30
                End If
                If j > 1 And i = 5 Then
                    BtnLugares(i, j).Visible = False
                End If
                AddHandler BtnLugares(i, j).Click, AddressOf Janela
                AddHandler BtnLugares(i, j).Click, AddressOf Selecionar
            Next
            y += 40
        Next
        BtnCompra.Text = "Iniciar compra"
        BtnCompra.BackColor = Color.LightGray
        BtnCompra.Font = New Font("Arial", 12)
        BtnCompra.Location = New Point(220, 80)
        BtnCompra.Size = New Size(150, 50)
        BtnCompra.TextAlign = ContentAlignment.MiddleCenter
        Me.Controls.Add(BtnCompra)

        LblLugComprados.Font = New Font("Arial", 12)
        LblLugComprados.BorderStyle = BorderStyle.FixedSingle
        LblLugComprados.Location = New Point(220, 140)
        LblLugComprados.Size = New Size(150, 50)
        LblLugComprados.TextAlign = ContentAlignment.MiddleCenter
        LblLugComprados.Visible = False
        Me.Controls.Add(LblLugComprados)

        LblPrecoLugar.Font = New Font("Arial", 12)
        LblPrecoLugar.BorderStyle = BorderStyle.FixedSingle
        LblPrecoLugar.Location = New Point(220, 190)
        LblPrecoLugar.Size = New Size(150, 50)
        LblPrecoLugar.TextAlign = ContentAlignment.MiddleCenter
        LblPrecoLugar.Visible = False
        Me.Controls.Add(LblPrecoLugar)

        BtnPagar.Text = "Efetuar pagamento e Sair"
        BtnPagar.BackColor = Color.LightGray
        BtnPagar.Font = New Font("Arial", 12)
        BtnPagar.Location = New Point(220, 250)
        BtnPagar.Size = New Size(150, 50)
        BtnPagar.TextAlign = ContentAlignment.MiddleCenter
        BtnPagar.Visible = False
        Me.Controls.Add(BtnPagar)

        BtnVoltar.Text = "Voltar"
        BtnVoltar.BackColor = Color.LightGray
        BtnVoltar.Font = New Font("Arial", 10)
        BtnVoltar.Location = New Point(310, 345)
        BtnVoltar.Size = New Size(60, 30)
        BtnVoltar.TextAlign = ContentAlignment.MiddleCenter
        BtnVoltar.Visible = False
        Me.Controls.Add(BtnVoltar)

        AddHandler BtnCompra.Click, AddressOf ComprarLugares
        AddHandler BtnPagar.Click, AddressOf Pagamento
        AddHandler BtnVoltar.Click, AddressOf Voltar
    End Sub

    Sub ComprarLugares(ByVal sender As Object, e As EventArgs)
        LblLugComprados.Visible = True
        LblPrecoLugar.Visible = True
        BtnPagar.Visible = True
        BtnVoltar.Visible = True
        For Each lugar In BtnLugares
            lugar.Enabled = True
        Next
    End Sub

    Sub Selecionar(ByVal sender As Object, e As EventArgs)
        If sender.tag = 1 Then
            MsgBox("Lugar já se encontra ocupado!", MsgBoxStyle.Information)
            sender.tag = 1
        ElseIf sender.tag = 0 Then
            sender.image = Image.FromFile("C:\Users\vkras\OneDrive\Ambiente de Trabalho\bus-main\bus-main\Projeto3_Autocarro\Projeto3_Autocarro\bin\Debug\seat3.png")
            sender.tag = 2
            LblLugComprados.Text = num & " lugar(es)"
            LblPrecoLugar.Text = preco & "€"
        ElseIf sender.tag = 2 Then
            sender.tag = 0
            sender.image = Image.FromFile("C:\Users\vkras\OneDrive\Ambiente de Trabalho\bus-main\bus-main\Projeto3_Autocarro\Projeto3_Autocarro\bin\Debug\seat.png")
            LblLugComprados.Text = num & " lugar(es)"
            LblPrecoLugar.Text = preco & "€"
        ElseIf sender.tag = 3 Then
            MsgBox("Lugar no momento esta indisponivel!", MsgBoxStyle.Information)
            sender.tag = 3
        End If
    End Sub

    Sub Pagamento(ByVal sender As Object, e As EventArgs)
        Dim nif As Integer
        Dim linha As String
        Dim total As Integer = 0
        nif = InputBox("Insira o seu NIF: ")
        FileOpen(2, "vendas.txt", OpenMode.Append)
        PrintLine(2, nif & "," & cont & "," & preco)
        FileClose(2)
        FileOpen(1, "ocupacao.txt", OpenMode.Output)
        For i = 0 To 8
            linha = ""
            For j = 0 To 3
                If BtnLugares(i, j).Tag = 2 Or BtnLugares(i, j).Tag = 1 Then
                    linha &= "1"
                ElseIf BtnLugares(i, j).Tag = 3 Then
                    linha &= "3"
                Else
                    linha &= "0"
                End If
            Next
            PrintLine(1, linha)
        Next
        preco = 0
        num = 0
        FileClose(1)
        Me.Close()
    End Sub

    Sub Janela(ByVal sender As Object, e As EventArgs)
        If sender.tag = 0 Then
            If sender.left = 20 Or sender.left = 170 Then
                preco += 15
                num += 1
                cont += 1
                LblPrecoLugar.Text = preco & "€"
            Else
                cont += 1
                num += 1
                preco += 12
                LblPrecoLugar.Text = preco & "€"
            End If
        ElseIf sender.tag = 2 Then

            If sender.left = 20 Or sender.left = 170 Then
                cont -= 1
                num -= 1
                preco -= 15
                LblPrecoLugar.Text = preco & "€"
            Else
                cont -= 1
                num -= 1
                preco -= 12
                LblPrecoLugar.Text = preco & "€"
            End If
        End If
    End Sub

    Sub Voltar(ByVal sender As Object, e As EventArgs)
        Dim op As Integer
        op = MsgBox("Deseja mesmo voltar ao menu inicial?", MsgBoxStyle.Information + MsgBoxStyle.YesNo)
        If op = vbYes Then
            Me.Hide()
            Login.Show()
            LblLugComprados.Visible = False
            LblPrecoLugar.Visible = False
            BtnPagar.Visible = False
            BtnVoltar.Visible = False
            For Each lugar In BtnLugares
                lugar.Enabled = False
            Next
        End If
    End Sub
End Class
