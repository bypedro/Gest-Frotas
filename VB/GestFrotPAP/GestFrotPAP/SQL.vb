Imports MySql.Data.MySqlClient
Imports System.Net.Mail
Module SQL
    Dim DB As String = "frotas"
    Dim ligacao As New MySqlConnection("Server=localhost;Database=" + DB + ";Uid=root;Pwd=;Connect timeout=30;Convert Zero Datetime=True;") 'MUDAR TALVEZ
    Dim adapter As New MySqlDataAdapter
    Public DetalhesUtilizador As New UtilizadorDetalhes

    Public Function Login(ByVal Utilizador As String, ByVal Password As String) As Boolean
        Dim max As MySqlCommand
        Dim User As Object
        Dim str As String
        Dim str1 As String = ""
        If Utilizador = "" Then
            Form1.LblUtilizadorLogin.Show()
            Form1.LblUtilizadorLogin.Text = "*Necessita  de Utilizador"
            'MsgBox("FALTA UTILIZADOR")
            Return False
            Exit Function
        Else
            If LCase(Utilizador).Contains(LCase("@")) Then
                Try 'Isto dáa
                    max = New MySqlCommand("select Email from Utilizador where Email ='" + Utilizador + "'", ligacao)
                    ligacao.Open()
                    User = max.ExecuteScalar
                    str = CType(User, String)
                    ligacao.Close()
                    If str <> "" Then
                        max = New MySqlCommand("select Senha from Utilizador where Email ='" + Utilizador + "'", ligacao)
                        ligacao.Open()
                        User = max.ExecuteScalar
                        str = CType(User, String)
                        ligacao.Close()
                        If str = Password Then
                            max = New MySqlCommand("select Nome_Registo from Utilizador where Email ='" + Utilizador + "'", ligacao)
                            ligacao.Open()
                            User = max.ExecuteScalar
                            str = CType(User, String)
                            ligacao.Close()
                            BuscarDadosUtilizador(str)
                            Return (True)
                            Exit Function
                        Else
                            Form1.LblPasswordLogin.Show()
                            Form1.LblPasswordLogin.Text = "*Password Incorreta"
                            ' MsgBox("Password errada label")
                            Return (False)
                            Exit Function
                        End If
                    Else
                        Form1.LblUtilizadorLogin.Show()
                        Form1.LblUtilizadorLogin.Text = "*Utilizador Inválido"
                        ' MsgBox("Utilizador não existe")
                        Return (False)
                        Exit Function
                    End If
                Catch ex As Exception
                    MsgBox("ERRO 0")
                    Return (False)
                End Try
            Else
                Try 'Isto dáa
                    max = New MySqlCommand("select Nome_Registo from Utilizador where Nome_Registo ='" + Utilizador + "'", ligacao)
                    ligacao.Open()
                    User = max.ExecuteScalar
                    str = CType(User, String)
                    ligacao.Close()
                    If str <> "" Then
                        max = New MySqlCommand("select Senha from Utilizador where Nome_Registo='" + Utilizador + "'", ligacao)
                        ligacao.Open()
                        User = max.ExecuteScalar
                        str = CType(User, String)
                        ligacao.Close()
                        If str = Password Then
                            BuscarDadosUtilizador(Utilizador)
                            Return (True)
                            Exit Function
                        Else
                            Form1.LblPasswordLogin.Show()
                            Form1.LblPasswordLogin.Text = "*Password Incorreta"
                            'MsgBox("Password errada label") 'Label
                            Return (False)
                            Exit Function
                        End If
                    Else
                        Form1.LblUtilizadorLogin.Show()
                        Form1.LblUtilizadorLogin.Text = "*Utilizador Inválido"
                        'MsgBox("Utilizador não existe")
                        Return (False)
                        Exit Function
                    End If
                Catch ex As Exception
                    MsgBox("ERRO 1")
                End Try
            End If
            Return (False)
        End If

    End Function

    Public Function RegistarUtilizador(ByVal Utilizador As String, ByVal Password1 As String, ByVal Password2 As String, ByVal Email As String) As Boolean
        Dim Comando As MySqlCommand
        Dim Objecto As Object

        Dim UtilizadorBD As String = ""
        Dim EmailBD As String = ""
        Dim Validar(3) As Boolean

        'Verificar Email
        If Email = "" Then
            Form1.LblEmailReg.Show()
            Form1.LblEmailReg.Text = "*Necessita de um email"
            Validar(1) = True
        Else
            Try 'Testa se o é email valido
                Dim testAddress = New MailAddress(Email)
            Catch ex As FormatException
                Form1.LblEmailReg.Show()
                Form1.LblEmailReg.Text = "*Email invalido"
                Validar(1) = True
            End Try
            Try 'Vê se o email já exist
                Comando = New MySqlCommand("select email from Utilizador where email='" + Email + "'", ligacao)
                ligacao.Open()
                Objecto = Comando.ExecuteScalar
                EmailBD = CType(Objecto, String)
                ligacao.Close()
            Catch ex As Exception
                MsgBox("ERRO SQL EMAIL 1")
                Return False
                Exit Function
            End Try
            If Email = EmailBD Then 'IDK
                Form1.LblEmailReg.Show()
                Form1.LblEmailReg.Text = "*Email já existe"
                Validar(1) = True
            End If
        End If

        'Verificar Utilizador
        If Utilizador = "" Then
            Form1.LblUtilizadorReg.Show()
            Form1.LblUtilizadorReg.Text = "*Necessita de um Utilizador"
            Validar(2) = True
        Else
            Try
                Comando = New MySqlCommand("select Nome_Registo from Utilizador where Nome_Registo='" + Utilizador + "'", ligacao)
                ligacao.Open()
                Objecto = Comando.ExecuteScalar
                UtilizadorBD = CType(Objecto, String)
                ligacao.Close()
            Catch ex As Exception
                MsgBox("ERRO SQL UTILIZADOR")
                Return False
                Exit Function
            End Try
            If Utilizador = UtilizadorBD Then
                Form1.LblUtilizadorReg.Show()
                Form1.LblUtilizadorReg.Text = "*Utilizador já existe"
                Validar(2) = True
            End If
        End If

        If Password1 = "" Then
            Form1.LblPasswordReg.Show()
            Form1.LblPasswordReg.Text = "*Necessita de Password"
            Validar(3) = True
        Else
            If Password1 <> Password2 Then
                'loadorderchangecolor???
                Form1.LblPasswordReg.Show()
                Form1.LblPasswordReg.Text = "*Passwords Não são iguais"
                Validar(3) = True
            End If
        End If

        If Validar(1) = True Or Validar(2) = True Or Validar(3) = True Then
            Return False
            Exit Function
        End If

        Try
            Comando = New MySqlCommand("insert into utilizador (Nome_Registo, Senha,Email) values ('" + Utilizador + "', '" + HashPassword(Password1) + "', '" + Email + "')", ligacao)
            ligacao.Open()
            Comando.ExecuteNonQuery()
            ligacao.Close()
            Return (True)
            Exit Function
        Catch ex As Exception
            MsgBox("ERRO SQL INSERT")
        End Try
        Return (False)
    End Function


    Public Function EditarUtilizador(ByVal Utilizador As String, ByVal NomeProprio As String, ByVal Apelido As String, ByVal DataNasc As String, ByVal DataContrat As String, ByVal PagamentoHora As String, ByVal Genero As String, ByVal Habilitacoes As String, ByVal Notas As String)
        Dim Comando As MySqlCommand
        Try

            'Comando = New MySqlCommand("update Utilizador set Nome_Registo='" + Utilizador + "'where CodUser='" + DetalhesUtilizador.CodUser + "'", ligacao)
            'update utilizador set Nome="LOL", Apelido="1" where cout="1"
            Comando = New MySqlCommand("update Utilizador set Nome_Registo='" + Utilizador + "', Nome_Proprio='" + NomeProprio + "', Apelido='" + Apelido + "', Data_Nascimento='" + DataNasc + "', Data_Contratacao='" + DataContrat + "', Pagamentos_Hora='" + PagamentoHora + "', Genero='" + Genero + "', Habilitacoes='" + Habilitacoes + "', Notas_Contracto='" + Notas + "'where CodUser='" + DetalhesUtilizador.CodUser + "'", ligacao)
            ligacao.Open()
            Comando.ExecuteNonQuery()
            ligacao.Close()
            BuscarDadosUtilizador(Utilizador)
            Return (True)
            Exit Function
        Catch ex As Exception
            MsgBox("ERRO SQL INSERT")
            ligacao.Close()
            Return (False)
            Exit Function
        End Try
    End Function








    'Buscar Dados
    Public Sub BuscarDadosUtilizador(ByVal Utilizador As String)
        Dim Comando As MySqlCommand
        Dim Objecto As Object
        Try
            Comando = New MySqlCommand("select CodUser from Utilizador where Nome_Registo='" + Utilizador + "'", ligacao)
            ligacao.Open()
            Objecto = Comando.ExecuteScalar
            If IsDBNull(Objecto) Then
                DetalhesUtilizador.CodUser = "Não tem" 'Mudar
                MsgBox("ERRO CODUSER")
                ligacao.Close()
            Else
                DetalhesUtilizador.CodUser = CType(Objecto, String)
                ligacao.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            ligacao.Close()
        End Try
        Try
            Comando = New MySqlCommand("select Nome_Registo from Utilizador where Nome_Registo='" + Utilizador + "'", ligacao)
            ligacao.Open()
            Objecto = Comando.ExecuteScalar
            If IsDBNull(Objecto) Then
                DetalhesUtilizador.NomeRegisto = "Não tem" 'Mudar
                MsgBox("ERRO Nome Registo")
                ligacao.Close()
            Else
                DetalhesUtilizador.NomeRegisto = CType(Objecto, String)
                ligacao.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            ligacao.Close()
        End Try
        Try
            Comando = New MySqlCommand("select Senha from Utilizador where Nome_Registo='" + Utilizador + "'", ligacao)
            ligacao.Open()
            Objecto = Comando.ExecuteScalar
            If IsDBNull(Objecto) Then
                DetalhesUtilizador.Senha = "Não tem" 'Mudar
                MsgBox("ERRO Senha")
                ligacao.Close()
            Else
                DetalhesUtilizador.Senha = CType(Objecto, String)
                ligacao.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            ligacao.Close()
        End Try
        Try
            Comando = New MySqlCommand("select Nome_Proprio from Utilizador where Nome_Registo='" + Utilizador + "'", ligacao)
            ligacao.Open()
            Objecto = Comando.ExecuteScalar
            If IsDBNull(Objecto) Then
                DetalhesUtilizador.NomeProprio = "Não tem" 'Mudar
                MsgBox("ERRO Nome_Proprio")
                ligacao.Close()
            Else
                DetalhesUtilizador.NomeProprio = CType(Objecto, String)
                ligacao.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            ligacao.Close()
        End Try
        Try
            Comando = New MySqlCommand("select Apelido from Utilizador where Nome_Registo='" + Utilizador + "'", ligacao)
            ligacao.Open()
            Objecto = Comando.ExecuteScalar
            If IsDBNull(Objecto) Then
                DetalhesUtilizador.Apelido = "Não tem" 'Mudar
                MsgBox("ERRO Apelido")
                ligacao.Close()
            Else
                DetalhesUtilizador.Apelido = CType(Objecto, String)
                ligacao.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            ligacao.Close()
        End Try
        Try
            Comando = New MySqlCommand("select Genero from Utilizador where Nome_Registo='" + Utilizador + "'", ligacao)
            ligacao.Open()
            Objecto = Comando.ExecuteScalar
            If IsDBNull(Objecto) Then
                DetalhesUtilizador.Genero = "Não tem"
                MsgBox("ERRO Genero")
                ligacao.Close()
            Else
                DetalhesUtilizador.Genero = CType(Objecto, String)
                ligacao.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            ligacao.Close()
        End Try
        Try
            Comando = New MySqlCommand("select Data_Nascimento from Utilizador where Nome_Registo='" + Utilizador + "'", ligacao)
            ligacao.Open()
            Objecto = Comando.ExecuteScalar
            If IsDBNull(Objecto) Then
                DetalhesUtilizador.DataNasc = "Não tem"
                MsgBox("ERRO Data Nascimento")
                ligacao.Close()
            Else
                DetalhesUtilizador.DataNasc = CType(Objecto, String)
                ligacao.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            ligacao.Close()
        End Try
        Try
            Comando = New MySqlCommand("select Data_Contratacao from Utilizador where Nome_Registo='" + Utilizador + "'", ligacao)
            ligacao.Open()
            Objecto = Comando.ExecuteScalar
            If IsDBNull(Objecto) Then
                DetalhesUtilizador.DataContrat = "Não tem"
                MsgBox("ERRO Data Contratacao")
                ligacao.Close()
            Else
                DetalhesUtilizador.DataContrat = CType(Objecto, String)
                ligacao.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            ligacao.Close()
        End Try
        Try
            Comando = New MySqlCommand("select Pagamentos_Hora from Utilizador where Nome_Registo='" + Utilizador + "'", ligacao)
            ligacao.Open()
            Objecto = Comando.ExecuteScalar
            If IsDBNull(Objecto) Then
                DetalhesUtilizador.PagamentoHora = "Não tem"
                MsgBox("ERRO Pagamentos Hora")
                ligacao.Close()
            Else
                DetalhesUtilizador.PagamentoHora = CType(Objecto, String)
                ligacao.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            ligacao.Close()
        End Try
        Try
            Comando = New MySqlCommand("select Habilitacoes from Utilizador where Nome_Registo='" + Utilizador + "'", ligacao)
            ligacao.Open()
            Objecto = Comando.ExecuteScalar
            If IsDBNull(Objecto) Then
                DetalhesUtilizador.Habilitações = "Não tem"
                MsgBox("ERRO Habilitacoes")
                ligacao.Close()
            Else
                DetalhesUtilizador.Habilitações = CType(Objecto, String)
                ligacao.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            ligacao.Close()
        End Try
        Try
            Comando = New MySqlCommand("select Rua from Utilizador where Nome_Registo='" + Utilizador + "'", ligacao)
            ligacao.Open()
            Objecto = Comando.ExecuteScalar
            If IsDBNull(Objecto) Then
                DetalhesUtilizador.Rua = "Não tem"
                MsgBox("ERRO Rua")
                ligacao.Close()
            Else
                DetalhesUtilizador.Rua = CType(Objecto, String)
                ligacao.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            ligacao.Close()
        End Try
        Try
            Comando = New MySqlCommand("select N_Telemovel from Utilizador where Nome_Registo='" + Utilizador + "'", ligacao)
            ligacao.Open()
            Objecto = Comando.ExecuteScalar
            If IsDBNull(Objecto) Then
                DetalhesUtilizador.NTelemovel = "Não tem"
                MsgBox("ERRO N_Telemovel")
                ligacao.Close()
            Else
                DetalhesUtilizador.NTelemovel = CType(Objecto, String)
                ligacao.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            ligacao.Close()
        End Try
        Try
            Comando = New MySqlCommand("select N_Telefone from Utilizador where Nome_Registo='" + Utilizador + "'", ligacao)
            ligacao.Open()
            Objecto = Comando.ExecuteScalar
            If IsDBNull(Objecto) Then
                DetalhesUtilizador.NTelefone = "Não tem"
                MsgBox("ERRO N_Telefone")
                ligacao.Close()
            Else
                DetalhesUtilizador.NTelefone = CType(Objecto, String)
                ligacao.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            ligacao.Close()
        End Try
        Try
            Comando = New MySqlCommand("select Email from Utilizador where Nome_Registo='" + Utilizador + "'", ligacao)
            ligacao.Open()
            Objecto = Comando.ExecuteScalar
            If IsDBNull(Objecto) Then
                DetalhesUtilizador.Email = "Não tem"
                MsgBox("ERRO Email")
                ligacao.Close()
            Else
                DetalhesUtilizador.Email = CType(Objecto, String)
                ligacao.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            ligacao.Close()
        End Try
        Try
            Comando = New MySqlCommand("select Notas_Contacto from Utilizador where Nome_Registo='" + Utilizador + "'", ligacao)
            ligacao.Open()
            Objecto = Comando.ExecuteScalar
            If IsDBNull(Objecto) Then
                DetalhesUtilizador.NotasContacto = "Não tem"
                MsgBox("ERRO Notas Contacto")
                ligacao.Close()
            Else
                DetalhesUtilizador.NotasContacto = CType(Objecto, String)
                ligacao.Close()
            End If
        Catch ex As Exception
            ligacao.Close()
        End Try
        Try
            Comando = New MySqlCommand("select Notas_Contracto from Utilizador where Nome_Registo='" + Utilizador + "'", ligacao)
            ligacao.Open()
            Objecto = Comando.ExecuteScalar
            If IsDBNull(Objecto) Then
                DetalhesUtilizador.NotasContrato = "Não tem"
                MsgBox("ERRO Notas Contracto")
                ligacao.Close()
            Else
                DetalhesUtilizador.NotasContrato = CType(Objecto, String)
                ligacao.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            ligacao.Close()
        End Try
        Try
            Comando = New MySqlCommand("select CodTipoU from Utilizador where Nome_Registo='" + Utilizador + "'", ligacao)
            ligacao.Open()
            Objecto = Comando.ExecuteScalar
            If IsDBNull(Objecto) Then
                DetalhesUtilizador.TipoUtilizadorCod = 0
                MsgBox("ERRO Tipo Utilizador Cod")
                ligacao.Close()

            Else
                DetalhesUtilizador.TipoUtilizadorCod = CType(Objecto, String)
                ligacao.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            ligacao.Close()
        End Try

        Try
            Comando = New MySqlCommand("select Codci from Utilizador where Nome_Registo='" + Utilizador + "'", ligacao)
            ligacao.Open()
            Objecto = Comando.ExecuteScalar
            If IsDBNull(Objecto) Then
                DetalhesUtilizador.CidadeCod = 0
                MsgBox("ERRO Cidade Cod")
                ligacao.Close()
            Else
                DetalhesUtilizador.CidadeCod = CType(Objecto, Integer)
                ligacao.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            ligacao.Close()
        End Try
        Try
            If DetalhesUtilizador.CidadeCod <> 0 Then
                Comando = New MySqlCommand("select nome from cidade where codci='" + DetalhesUtilizador.CidadeCod.ToString + "'", ligacao)
                ligacao.Open()
                Objecto = Comando.ExecuteScalar
                If IsDBNull(Objecto) Then
                    DetalhesUtilizador.Cidade = "Não tem"
                    MsgBox("ERRO Cidade nome")
                    ligacao.Close()
                Else
                    DetalhesUtilizador.Cidade = CType(Objecto, String)
                    ligacao.Close()
                End If
            Else
                DetalhesUtilizador.Cidade = "Não tem"
                MsgBox("ERRO Cidade nome")
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
            ligacao.Close()
        End Try

        Try
            If DetalhesUtilizador.CidadeCod <> 0 Then
                Comando = New MySqlCommand("select codpais from cidade where codci='" + DetalhesUtilizador.CidadeCod.ToString + "'", ligacao)
                ligacao.Open()
                Objecto = Comando.ExecuteScalar
                If IsDBNull(Objecto) Then
                    DetalhesUtilizador.PaisCod = "Não tem"
                    MsgBox("ERRO codpais")
                    ligacao.Close()
                Else
                    DetalhesUtilizador.PaisCod = CType(Objecto, String)
                    ligacao.Close()
                End If
            Else
                DetalhesUtilizador.PaisCod = "Não tem"
                MsgBox("ERRO codpais")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            ligacao.Close()
        End Try
        Try
            If DetalhesUtilizador.CidadeCod <> 0 Then
                Comando = New MySqlCommand("select nome from pais where codpais='" + DetalhesUtilizador.PaisCod + "'", ligacao)
                ligacao.Open()
                Objecto = Comando.ExecuteScalar
                If IsDBNull(Objecto) Then
                    DetalhesUtilizador.Pais = "Não tem"
                    MsgBox("ERRO Pais nome")
                    ligacao.Close()
                Else
                    DetalhesUtilizador.Pais = CType(Objecto, String)
                    ligacao.Close()
                End If
            Else
                DetalhesUtilizador.Pais = "Não tem"
                MsgBox("ERRO Pais nome")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            ligacao.Close()
        End Try

        'Carro
        Try
            If DetalhesUtilizador.CodUser <> 0 Then
                Comando = New MySqlCommand("select CodVei from Veicondu where coduser='" + DetalhesUtilizador.CodUser + "' and emuso='sim'", ligacao)
                ligacao.Open()
                Objecto = Comando.ExecuteScalar
                If IsDBNull(Objecto) Then
                    DetalhesUtilizador.CodVeiculo = "Não tem"
                    MsgBox("ERRO CodVei nome")
                    ligacao.Close()
                Else
                    DetalhesUtilizador.CodVeiculo = CType(Objecto, String)
                    ligacao.Close()
                End If
            Else
                DetalhesUtilizador.CodVeiculo = "Não tem"
                MsgBox("ERRO CodVei nome")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            ligacao.Close()
        End Try

        Try
            If DetalhesUtilizador.CodVeiculo <> 0 Then
                Comando = New MySqlCommand("select cor from veiculos where codvei='" + DetalhesUtilizador.CodVeiculo.ToString + "'", ligacao)
                ligacao.Open()
                Objecto = Comando.ExecuteScalar
                If IsDBNull(Objecto) Then
                    DetalhesUtilizador.VeiCor = "Não tem"
                    MsgBox("ERRO VeiCor nome")
                    ligacao.Close()
                Else
                    DetalhesUtilizador.VeiCor = CType(Objecto, String)
                    ligacao.Close()
                End If
            Else
                DetalhesUtilizador.VeiCor = "Não tem"
                MsgBox("ERRO VeiCor nome")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            ligacao.Close()
        End Try

        Try
            If DetalhesUtilizador.CodVeiculo <> 0 Then
                Comando = New MySqlCommand("select marca from veiculos where codvei='" + DetalhesUtilizador.CodVeiculo.ToString + "'", ligacao)
                ligacao.Open()
                Objecto = Comando.ExecuteScalar
                If IsDBNull(Objecto) Then
                    DetalhesUtilizador.VeiMarca = "Não tem"
                    MsgBox("ERRO Marca")
                    ligacao.Close()
                Else
                    DetalhesUtilizador.VeiMarca = CType(Objecto, String)
                    ligacao.Close()
                End If
            Else
                DetalhesUtilizador.VeiMarca = "Não tem"
                MsgBox("ERRO Marca")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            ligacao.Close()
        End Try

        Try
            If DetalhesUtilizador.CodVeiculo <> 0 Then
                Comando = New MySqlCommand("select modelo from veiculos where codvei='" + DetalhesUtilizador.CodVeiculo.ToString + "'", ligacao)
                ligacao.Open()
                Objecto = Comando.ExecuteScalar
                If IsDBNull(Objecto) Then
                    DetalhesUtilizador.VeiModelo = "Não tem"
                    MsgBox("ERRO Modelo")
                    ligacao.Close()
                Else
                    DetalhesUtilizador.VeiModelo = CType(Objecto, String)
                    ligacao.Close()
                End If
            Else
                DetalhesUtilizador.VeiModelo = "Não tem"
                MsgBox("ERRO Modelo")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            ligacao.Close()
        End Try

        Try
            If DetalhesUtilizador.CodVeiculo <> 0 Then
                Comando = New MySqlCommand("select matricula from veiculos where codvei='" + DetalhesUtilizador.CodVeiculo.ToString + "'", ligacao)
                ligacao.Open()
                Objecto = Comando.ExecuteScalar
                If IsDBNull(Objecto) Then
                    DetalhesUtilizador.VeiMatricula = "Não tem"
                    MsgBox("ERRO matricula")
                    ligacao.Close()
                Else
                    DetalhesUtilizador.VeiMatricula = CType(Objecto, String)
                    ligacao.Close()
                End If
            Else
                DetalhesUtilizador.VeiMatricula = "Não tem"
                MsgBox("ERRO matricula")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            ligacao.Close()
        End Try

        'Agenda
        Try
            If DetalhesUtilizador.CodVeiculo <> 0 Then
                Comando = New MySqlCommand("select Proxima_Inspecao from veiculos where codvei='" + DetalhesUtilizador.CodVeiculo.ToString + "'", ligacao)
                ligacao.Open()
                Objecto = Comando.ExecuteScalar
                If IsDBNull(Objecto) Then
                    DetalhesUtilizador.VeiProxInspecao = "Não tem"
                    MsgBox("ERRO VeiProxInspecao")
                    ligacao.Close()
                Else
                    DetalhesUtilizador.VeiProxInspecao = CType(Objecto, String)
                    ligacao.Close()
                End If
            Else
                DetalhesUtilizador.VeiProxInspecao = "Não tem"
                MsgBox("ERRO VeiProxInspecao")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            ligacao.Close()
        End Try

    End Sub


    ' SELECT * FROM veicondu where emuso="sim" and coduser="1"

    '  Comando = New MySqlCommand("select CodVei from pais where ='" + DetalhesUtilizador.CodUser + "'codpais='" + DetalhesUtilizador.CodUser + "'", ligacao)

    Public Sub AbastecimentoVer()
        Dim Tabelas As DataSet = New DataSet
        adapter.SelectCommand = New MySqlCommand
        adapter.SelectCommand.Connection = ligacao
        adapter.SelectCommand.CommandText = ("select CodVeiAbast,Data,Veiculo_km,quantidade,valor,notas,concat(Marca, ' ', Modelo,' ',Ano,' Matricula:',Matricula) as veiculo,Nome as Fornecedor,concat(Nome_Proprio, ' ', Apelido) as Utilizador ,Nome as Fornecedor from veiabast,veiculos,fornecedores,Utilizador where Veiculos.Codvei=Veiabast.CodVei and fornecedores.Codforn=Veiabast.Codforn and Utilizador.CodUser=Veiabast.Coduser")
        Try
            ligacao.Open()
            adapter.Fill(Tabelas, "Abastecimento")
            ligacao.Close()
        Catch ex As Exception
            ligacao.Close()
            MsgBox("ERRO abastecimento")
            Exit Sub
        End Try
       
        Form1.LstAbastCarro.DataSource = Tabelas.Tables(0)
        Form1.LstAbastFornecedor.DataSource = Tabelas.Tables(0)
        Form1.LstAbastUtilizador.DataSource = Tabelas.Tables(0)
        Form1.LstAbastData.DataSource = Tabelas.Tables(0)
        Form1.LstAbastQuantidade.DataSource = Tabelas.Tables(0)
        Form1.LstAbastValor.DataSource = Tabelas.Tables(0)
        Form1.LstAbastKM.DataSource = Tabelas.Tables(0)

        Form1.LstAbastCarro.DisplayMember = "veiculo"
        Form1.LstAbastFornecedor.DisplayMember = "Fornecedor"
        Form1.LstAbastUtilizador.DisplayMember = "Utilizador"
        Form1.LstAbastData.DisplayMember = "Data"
        Form1.LstAbastQuantidade.DisplayMember = "quantidade"
        Form1.LstAbastValor.DisplayMember = "valor"
        Form1.LstAbastKM.DisplayMember = "Veiculo_km"

        Form1.LstAbastCarro.ValueMember = "CodVeiAbast"
        Form1.LstAbastFornecedor.ValueMember = "CodVeiAbast"
        Form1.LstAbastUtilizador.ValueMember = "CodVeiAbast"
        Form1.LstAbastData.ValueMember = "CodVeiAbast"
        Form1.LstAbastValor.ValueMember = "CodVeiAbast"
        Form1.LstAbastKM.ValueMember = "CodVeiAbast"

    End Sub

    Public Sub ManutencaoVer()
        Dim Tabelas As DataSet = New DataSet
        adapter.SelectCommand = New MySqlCommand
        adapter.SelectCommand.Connection = ligacao
        adapter.SelectCommand.CommandText = ("select Codmanu,Data_Efetuada,Veiculo_km,valor,nota,concat(Marca, ' ', Modelo,' ',Ano,' Matricula:',Matricula) as veiculo,tipoManu.Nome as TipoManu,fornecedores.Nome as Fornecedor from Manutencao,veiculos,fornecedores,tipomanu where Veiculos.Codvei=manutencao.CodVei and fornecedores.Codforn=manutencao.Codforn and tipomanu.CodtipoM=manutencao.codtipom and efetuada='Sim'")
        Try
            ligacao.Open()
            adapter.Fill(Tabelas, "Manutencao")
            ligacao.Close()
        Catch ex As Exception
            ligacao.Close()
            MsgBox("ERRO Manutencao")
            Exit Sub
        End Try

        Form1.LstManuCarro.DataSource = Tabelas.Tables(0)
        Form1.LstManuFornecedor.DataSource = Tabelas.Tables(0)
        Form1.LstManuTipo.DataSource = Tabelas.Tables(0)
        Form1.LstManuData.DataSource = Tabelas.Tables(0)
        Form1.LstManuValor.DataSource = Tabelas.Tables(0)
        Form1.LstManuKm.DataSource = Tabelas.Tables(0)

        Form1.LstManuCarro.DisplayMember = "veiculo"
        Form1.LstManuFornecedor.DisplayMember = "Fornecedor"
        Form1.LstManuTipo.DisplayMember = "Tipomanu"
        Form1.LstManuData.DisplayMember = "Data_efetuada"
        Form1.LstManuValor.DisplayMember = "valor"
        Form1.LstManuKm.DisplayMember = "Veiculo_km"

        Form1.LstManuCarro.ValueMember = "Codmanu"
        Form1.LstManuFornecedor.ValueMember = "Codmanu"
        Form1.LstManuTipo.ValueMember = "Codmanu"
        Form1.LstManuData.ValueMember = "Codmanu"
        Form1.LstManuValor.ValueMember = "Codmanu"
        Form1.LstManuKm.ValueMember = "Codmanu"

    End Sub

    Public Sub DespesasVer()
        Dim Tabelas As DataSet = New DataSet
        adapter.SelectCommand = New MySqlCommand
        adapter.SelectCommand.Connection = ligacao
        adapter.SelectCommand.CommandText = ("select Coddesp,Data_Efetuada,Veiculo_Km,Valor,Nota,concat(Marca, ' ', Modelo,' ',Ano,' Matricula:',Matricula) as veiculo,fornecedores.Nome as Fornecedor,concat(Nome_Proprio, ' ', Apelido) as Utilizador,tipodesp.nome as Tipodesp from despesas,Veiculos,Fornecedores,Utilizador,TipoDesp where Despesas.codvei=veiculos.codvei and Despesas.codforn=Fornecedores.codforn and Despesas.coduser=Utilizador.coduser and Despesas.codtipod=tipodesp.codtipod and efetuada='Sim'")
        Try
            ligacao.Open()
            adapter.Fill(Tabelas, "Despesas")
            ligacao.Close()
        Catch ex As Exception
            ligacao.Close()
            MsgBox("ERRO Despesas")
            Exit Sub
        End Try

        Form1.LstDespCarro.DataSource = Tabelas.Tables(0)
        Form1.LstDespFornecedor.DataSource = Tabelas.Tables(0)
        Form1.LstDespUtilizador.DataSource = Tabelas.Tables(0)
        Form1.LstDespTipo.DataSource = Tabelas.Tables(0)
        Form1.LstDespData.DataSource = Tabelas.Tables(0)
        Form1.LstDespValor.DataSource = Tabelas.Tables(0)
        Form1.LstDespKM.DataSource = Tabelas.Tables(0)

        Form1.LstDespCarro.DisplayMember = "veiculo"
        Form1.LstDespFornecedor.DisplayMember = "Fornecedor"
        Form1.LstDespUtilizador.DisplayMember = "Utilizador"
        Form1.LstDespTipo.DisplayMember = "Tipodesp"
        Form1.LstDespData.DisplayMember = "Data_efetuada"
        Form1.LstDespValor.DisplayMember = "valor"
        Form1.LstDespKM.DisplayMember = "Veiculo_km"


        Form1.LstDespCarro.ValueMember = "Coddesp"
        Form1.LstDespFornecedor.ValueMember = "Coddesp"
        Form1.LstDespUtilizador.ValueMember = "Coddesp"
        Form1.LstDespTipo.ValueMember = "Coddesp"
        Form1.LstDespData.ValueMember = "Coddesp"
        Form1.LstDespValor.ValueMember = "Coddesp"
        Form1.LstDespKM.ValueMember = "Coddesp"

    End Sub


End Module
