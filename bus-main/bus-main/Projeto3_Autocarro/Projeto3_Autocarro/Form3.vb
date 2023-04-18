Imports System.Runtime.InteropServices
Public Class Form3
    Dim BtnLugares(8, 3) As Button
    Dim BtnVoltar As New Button
    Dim BtnMarcarLugIndis As New Button
    Dim BtnTotalFaturado As New Button
    Dim BtnAlterarPass As New Button
    Private Sub Form3_closed(sender As Object, e As EventArgs) Handles MyBase.Closed
        Application.Exit()
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(390, 390)

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
                AddHandler BtnLugares(i, j).Click, AddressOf selecionar
            Next
            y += 40
        Next

        BtnMarcarLugIndis.Text = "Marcar lugares indisponiveis"
        BtnMarcarLugIndis.BackColor = Color.LightGray
        BtnMarcarLugIndis.Font = New Font("Arial", 12)
        BtnMarcarLugIndis.Location = New Point(220, 80)
        BtnMarcarLugIndis.Size = New Size(150, 50)
        BtnMarcarLugIndis.TextAlign = ContentAlignment.MiddleCenter
        Me.Controls.Add(BtnMarcarLugIndis)

        BtnTotalFaturado.Text = "Total Faturado"
        BtnTotalFaturado.BackColor = Color.LightGray
        BtnTotalFaturado.Font = New Font("Arial", 12)
        BtnTotalFaturado.Location = New Point(220, 140)
        BtnTotalFaturado.Size = New Size(150, 50)
        BtnTotalFaturado.TextAlign = ContentAlignment.MiddleCenter
        Me.Controls.Add(BtnTotalFaturado)

        BtnVoltar.Text = "Voltar"
        BtnVoltar.BackColor = Color.LightGray
        BtnVoltar.Font = New Font("Arial", 10)
        BtnVoltar.Location = New Point(310, 345)
        BtnVoltar.Size = New Size(60, 30)
        BtnVoltar.TextAlign = ContentAlignment.MiddleCenter
        Me.Controls.Add(BtnVoltar)

        BtnAlterarPass.Text = "Alterar password"
        BtnAlterarPass.BackColor = Color.LightGray
        BtnAlterarPass.Font = New Font("Arial", 12)
        BtnAlterarPass.Location = New Point(220, 200)
        BtnAlterarPass.Size = New Size(150, 50)
        BtnAlterarPass.TextAlign = ContentAlignment.MiddleCenter
        Me.Controls.Add(BtnAlterarPass)

        AddHandler BtnMarcarLugIndis.Click, AddressOf comprar
        AddHandler BtnTotalFaturado.Click, AddressOf Vendas
        AddHandler BtnVoltar.Click, AddressOf Voltar
        AddHandler BtnAlterarPass.Click, AddressOf pass
    End Sub

    Sub comprar()
        Dim linha As String
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
        FileClose(1)
        MsgBox("Confirmado")
    End Sub

    Sub selecionar(ByVal sender As Object, e As EventArgs)
        If sender.tag = 0 Then
            sender.image = Image.FromFile("C:\Users\vkras\OneDrive\Ambiente de Trabalho\bus-main\bus-main\Projeto3_Autocarro\Projeto3_Autocarro\bin\Debug\seat4.png")
            sender.tag = 3
        ElseIf sender.tag = 3 Then
            sender.image = Image.FromFile("C:\Users\vkras\OneDrive\Ambiente de Trabalho\bus-main\bus-main\Projeto3_Autocarro\Projeto3_Autocarro\bin\Debug\seat.png")
            sender.tag = 0
        End If
    End Sub

    Sub Vendas(ByVal sender As Object, e As EventArgs)
        Dim compra As Integer = 0
        Dim compras As String = ""
        Dim total2 As Integer = 0
        Dim totalStr As String = ""
        Dim linha As String
        Dim aux, aux2 As Integer
        Dim total As Integer = 0
        For i = 0 To 8
            For j = 0 To 3
                If BtnLugares(i, j).Tag = 1 Then
                    compra += 1
                End If
            Next
        Next
        FileOpen(1, "vendas.txt", OpenMode.Input)
        While Not EOF(1)
            linha = LineInput(1)
            compras = ""
            totalStr = ""
            For i = 0 To Len(linha) - 1
                If linha(i) = "," Then
                    aux = i
                    Exit For
                End If
            Next
            For i = aux + 1 To Len(linha) - 1
                If linha(i) = "," Then
                    aux2 = i
                    Exit For
                End If
                compras &= linha(i)
            Next
            total += Val(compras)
            For i = aux2 + 1 To Len(linha) - 1
                totalStr &= linha(i)
            Next
            total2 += Val(totalStr)
        End While
        FileClose(1)
        MsgBox("Lugares: " & compra & vbCrLf & "Total faturado: " & total & vbCrLf & "Dinheiro faturado: " & total2)
    End Sub

    Sub Voltar(ByVal sender As Object, e As EventArgs)
        Dim op As Integer
        op = MsgBox("Deseja mesmo voltar ao menu inicial?", MsgBoxStyle.Information + MsgBoxStyle.YesNo)
        If op = vbYes Then
            Me.Hide()
            Login.Show()
            For Each lugar In BtnLugares
                lugar.Enabled = True
            Next
        End If
    End Sub

    Sub pass(ByVal sender As Object, e As EventArgs)
        Me.Hide()
        Form4.Show()
    End Sub
End Class