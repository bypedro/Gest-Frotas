Imports MySql.Data.MySqlClient
Imports System.Net.Mail
Module SQL
    Dim DB As String = "frotas"
    Dim ligacao As New MySqlConnection("Server=localhost;Database=" + DB + ";Uid=root;Pwd=;Connect timeout=30;Convert Zero Datetime=True;") 'MUDAR TALVEZ
    Dim adapter As New MySqlDataAdapter
    Dim Comando As MySqlCommand
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

    Public Function UltimoKM() As Integer
        Dim Max As Integer = 0
        Dim KMDespesas As Integer = 0
        Dim KMManutencao As Integer = 0
        Dim KMAbastecimento As Integer = 0
        Dim KM4 As String = 0

        Dim Comando As MySqlCommand
        Dim Objecto As Object
        Try
            Comando = New MySqlCommand("select Max(Veiculo_KM) from despesas where efetuada='sim' and Codvei='" + DetalhesUtilizador.CodVeiculo.ToString + "'", ligacao)
            ligacao.Open()
            Objecto = Comando.ExecuteScalar
            If IsDBNull(Objecto) Then
                KMDespesas = 0
                ligacao.Close()
            Else
                KMDespesas = CType(Objecto, Integer)
                ligacao.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            ligacao.Close()
        End Try

        Try
            Comando = New MySqlCommand("select Max(Veiculo_KM) from manutencao where efetuada='sim' and Codvei='" + DetalhesUtilizador.CodVeiculo.ToString + "'", ligacao)
            ligacao.Open()
            Objecto = Comando.ExecuteScalar
            If IsDBNull(Objecto) Then
                KMManutencao = 0
                ligacao.Close()
            Else
                KMManutencao = CType(Objecto, Integer)
                ligacao.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            ligacao.Close()
        End Try

        Try
            Comando = New MySqlCommand("select Max(Veiculo_KM) from veiabast where Codvei='" + DetalhesUtilizador.CodVeiculo.ToString + "'", ligacao)
            ligacao.Open()
            Objecto = Comando.ExecuteScalar
            If IsDBNull(Objecto) Then
                KMAbastecimento = 0
                ligacao.Close()
            Else
                KMAbastecimento = CType(Objecto, Integer)
                ligacao.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            ligacao.Close()
        End Try

        If KMDespesas > KMManutencao And KMDespesas > KMAbastecimento Then
            Max = KMDespesas
            Return Max
            Exit Function
        ElseIf KMManutencao > KMDespesas And KMManutencao > KMAbastecimento Then
            Max = KMManutencao
            Return Max
            Exit Function
        ElseIf KMAbastecimento > KMDespesas And KMAbastecimento > KMManutencao Then
            Max = KMAbastecimento
            Return Max
            Exit Function
        End If

        Return 0
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
        

    End Sub


    ' SELECT * FROM veicondu where emuso="sim" and coduser="1"

    '  Comando = New MySqlCommand("select CodVei from pais where ='" + DetalhesUtilizador.CodUser + "'codpais='" + DetalhesUtilizador.CodUser + "'", ligacao)

    Public Sub AbastecimentoVer()
        Dim Tabelas As DataSet = New DataSet
        adapter.SelectCommand = New MySqlCommand
        adapter.SelectCommand.Connection = ligacao
        Dim itemcoll(100) As String
        'Trocar KM nas definições do programa..->
        adapter.SelectCommand.CommandText = ("select CodVeiAbast,Data,Nome as Fornecedor,Quantidade,Valor,concat(Veiculo_km,' KM') as '" + "QuilometrosMUDAR" + "' ,concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as veiculo,Nome_Registo as Utilizador  from VeiCondu,veiabast,veiculos,fornecedores,Utilizador where VeiCondu.Codvei=Veiculos.Codvei and Veiculos.Codvei=Veiabast.CodVei and fornecedores.Codforn=Veiabast.Codforn and Utilizador.CodUser=Veiabast.Coduser and VeiCondu.EmUso='Sim' and Utilizador.CodUser='" + DetalhesUtilizador.CodUser + "'order by CodVeiAbast DESC")
        Try
            ligacao.Open()
            adapter.Fill(Tabelas, "Abastecimento")
            ligacao.Close()
        Catch ex As Exception
            ligacao.Close()
            MsgBox("ERRO abastecimento")
            Exit Sub
        End Try
        Form1.LstVAbastecimento.Font = GetInstance(8, FontStyle.Bold)
        Form1.LstVAbastecimento.Clear()
        Dim i As Integer = 0
        Dim j As Integer = 0
        ' adding the columns in ListView
        For i = 0 To Tabelas.Tables(0).Columns.Count - 1
            Form1.LstVAbastecimento.Columns.Add(Tabelas.Tables(0).Columns(i).ColumnName.ToString())
        Next
        'Now adding the Items in Listview
        For i = 0 To Tabelas.Tables(0).Rows.Count - 1
            For j = 0 To Tabelas.Tables(0).Columns.Count - 1
                itemcoll(j) = Tabelas.Tables(0).Rows(i)(j)
            Next
            Dim lvi As New ListViewItem(itemcoll)
            Form1.LstVAbastecimento.Items.Add(lvi)
        Next
        ListViewSize("LstVAbastecimento")
    End Sub

    Public Sub ManutencaoVer()
        Dim Tabelas As DataSet = New DataSet
        adapter.SelectCommand = New MySqlCommand
        adapter.SelectCommand.Connection = ligacao
        Dim itemcoll(100) As String
        adapter.SelectCommand.CommandText = ("select Codmanu,Data_Efetuada as Data,fornecedores.Nome as Fornecedor,tipoManu.Nome as Tipo,Valor,concat(Veiculo_km,' KM') as '" + "QuilometrosMUDAR" + "',concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veiculo from VeiCondu,Manutencao,veiculos,fornecedores,tipomanu where VeiCondu.Codvei=Veiculos.Codvei and Veiculos.Codvei=manutencao.CodVei and fornecedores.Codforn=manutencao.Codforn and tipomanu.CodtipoM=manutencao.codtipom and efetuada='Sim' and EmUso='Sim' and Manutencao.CodUser='" + DetalhesUtilizador.CodUser + "'")
        Try
            ligacao.Open()
            adapter.Fill(Tabelas, "Manutencao")
            ligacao.Close()
        Catch ex As Exception
            ligacao.Close()
            MsgBox(ex.ToString)
            Exit Sub
        End Try
        Form1.LstVManu.Font = GetInstance(8, FontStyle.Bold)
        Form1.LstVManu.Clear()
        Dim i As Integer = 0
        Dim j As Integer = 0
        ' adding the columns in ListView
        For i = 0 To Tabelas.Tables(0).Columns.Count - 1
            Form1.LstVManu.Columns.Add(Tabelas.Tables(0).Columns(i).ColumnName.ToString())
        Next
        'Now adding the Items in Listview
        For i = 0 To Tabelas.Tables(0).Rows.Count - 1
            For j = 0 To Tabelas.Tables(0).Columns.Count - 1
                itemcoll(j) = Tabelas.Tables(0).Rows(i)(j)
            Next
            Dim lvi As New ListViewItem(itemcoll)
            Form1.LstVManu.Items.Add(lvi)
        Next
        ListViewSize("LstVManu")
    End Sub

    Public Sub DespesasVer()
        Dim Tabelas As DataSet = New DataSet
        adapter.SelectCommand = New MySqlCommand
        adapter.SelectCommand.Connection = ligacao
        Dim itemcoll(100) As String
        '"select CodVeiAbast,Data,Nome as Fornecedor,Quantidade,Valor,concat(Veiculo_km,' KM') as Quilometros ,concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as veiculo,Nome_Registo as Utilizador  from veiabast,veiculos,fornecedores,Utilizador where Veiculos.Codvei=Veiabast.CodVei and fornecedores.Codforn=Veiabast.Codforn and Utilizador.CodUser=Veiabast.Coduser and Utilizador.CodUser='" + DetalhesUtilizador.CodUser + "'"
        adapter.SelectCommand.CommandText = ("select Coddesp,Data_Efetuada as Data,fornecedores.Nome as Fornecedor,tipodesp.nome as Tipo ,Valor,concat(Veiculo_km,' KM') as '" + "QuilometrosMUDAR" + "',concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as veiculo,Nome_Registo as Utilizador from despesas,Veiculos,Fornecedores,Utilizador,TipoDesp where Despesas.codvei=veiculos.codvei and Despesas.codforn=Fornecedores.codforn and Despesas.coduser=Utilizador.coduser and Despesas.codtipod=tipodesp.codtipod and efetuada='Sim'  and Veiculos.CodVei='" + DetalhesUtilizador.CodVeiculo.ToString + "'")
        Try
            ligacao.Open()
            adapter.Fill(Tabelas, "Despesas")
            ligacao.Close()
        Catch ex As Exception
            ligacao.Close()
            MsgBox("ERRO Despesas")
            Exit Sub
        End Try
        Form1.LstVDesp.Font = GetInstance(8, FontStyle.Bold)
        Form1.LstVDesp.Clear()
        Dim i As Integer = 0
        Dim j As Integer = 0
        ' adding the columns in ListView
        For i = 0 To Tabelas.Tables(0).Columns.Count - 1
            Form1.LstVDesp.Columns.Add(Tabelas.Tables(0).Columns(i).ColumnName.ToString())
        Next
        'Now adding the Items in Listview
        For i = 0 To Tabelas.Tables(0).Rows.Count - 1
            For j = 0 To Tabelas.Tables(0).Columns.Count - 1
                itemcoll(j) = Tabelas.Tables(0).Rows(i)(j)
            Next
            Dim lvi As New ListViewItem(itemcoll)
            Form1.LstVDesp.Items.Add(lvi)
        Next
        ListViewSize("LstVDesp")
    End Sub

    Public Sub AgendaVer()
        Dim Manutencao As DataSet = New DataSet
        adapter.SelectCommand = New MySqlCommand
        adapter.SelectCommand.Connection = ligacao
        adapter.SelectCommand.CommandText = ("select Codmanu,Data_agendada as Data,Veiculo_km,valor,nota,concat(Marca, ' ', Modelo,' ',Ano,' Matricula:',Matricula) as veiculo,tipoManu.Nome as TipoManu,fornecedores.Nome as Fornecedor from Manutencao,veiculos,fornecedores,tipomanu where Veiculos.Codvei=manutencao.CodVei and fornecedores.Codforn=manutencao.Codforn and tipomanu.CodtipoM=manutencao.codtipom and efetuada='Nao'")
        Try
            ligacao.Open()
            adapter.Fill(Manutencao, "AgendaManu")
            ligacao.Close()
        Catch ex As Exception
            ligacao.Close()
            MsgBox("ERRO AgendaManu")
            Exit Sub
        End Try
        Form1.LstAgendaManuCarro.DataSource = Manutencao.Tables(0)
        Form1.LstAgendaManuTipo.DataSource = Manutencao.Tables(0)
        Form1.LstAgendaManuData.DataSource = Manutencao.Tables(0)
        Form1.LstAgendaManuKm.DataSource = Manutencao.Tables(0)

        Form1.LstAgendaManuCarro.DisplayMember = "veiculo"
        Form1.LstAgendaManuTipo.DisplayMember = "TipoManu"
        Form1.LstAgendaManuData.DisplayMember = "Data_agendada"
        Form1.LstAgendaManuKm.DisplayMember = "Veiculo_km"


        Form1.LstAgendaManuCarro.ValueMember = "Codmanu"
        Form1.LstAgendaManuTipo.ValueMember = "Codmanu"
        Form1.LstAgendaManuData.ValueMember = "Codmanu"
        Form1.LstAgendaManuKm.ValueMember = "Codmanu"


        '
        'Desp
        Dim Despesa As DataSet = New DataSet
        adapter.SelectCommand = New MySqlCommand
        adapter.SelectCommand.Connection = ligacao
        adapter.SelectCommand.CommandText = ("select Coddesp,Data_Agendada,Veiculo_Km,Valor,Nota,concat(Marca, ' ', Modelo,' ',Ano,' Matricula:',Matricula) as veiculo,fornecedores.Nome as Fornecedor,concat(Nome_Proprio, ' ', Apelido) as Utilizador,tipodesp.nome as Tipodesp from despesas,Veiculos,Fornecedores,Utilizador,TipoDesp where Despesas.codvei=veiculos.codvei and Despesas.codforn=Fornecedores.codforn and Despesas.coduser=Utilizador.coduser and Despesas.codtipod=tipodesp.codtipod and efetuada='Nao'")
        Try
            ligacao.Open()
            adapter.Fill(Despesa, "AgendaDesp")
            ligacao.Close()
        Catch ex As Exception
            ligacao.Close()
            MsgBox("ERRO AgendaDesp")
            Exit Sub
        End Try

        Form1.LstAgendaDespesaCarro.DataSource = Despesa.Tables(0)
        Form1.LstAgendaDespesaTipo.DataSource = Despesa.Tables(0)
        Form1.LstAgendaDespesaData.DataSource = Despesa.Tables(0)

        Form1.LstAgendaDespesaCarro.DisplayMember = "veiculo"
        Form1.LstAgendaDespesaTipo.DisplayMember = "Tipodesp"
        Form1.LstAgendaDespesaData.DisplayMember = "Data_Agendada"

        Form1.LstAgendaDespesaCarro.ValueMember = "Coddesp"
        Form1.LstAgendaDespesaTipo.ValueMember = "Coddesp"
        Form1.LstAgendaDespesaData.ValueMember = "Coddesp"
    End Sub

    Public Sub DetalhesAbast(ByVal Cod As String) 'Mudar Metodo
        Dim Comando As MySqlCommand
        Dim Objecto As Object
        Form1.LblAbastCOD.Text = "Codigo: " + Cod
        Try
            Comando = New MySqlCommand("select data from veiabast where CodVeiAbast='" + Cod + "'", ligacao)
            ligacao.Open()
            Objecto = Comando.ExecuteScalar
            If IsDBNull(Objecto) Then
                Form1.LblAbastData.Text = "Data:" 'Mudar
                MsgBox("ERRO Data")
                ligacao.Close()
            Else
                Form1.LblAbastData.Text = "Data: " + CType(Objecto, String)
                ligacao.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            ligacao.Close()
        End Try

        Try
            Comando = New MySqlCommand("select notas from veiabast where CodVeiAbast='" + Cod + "'", ligacao)
            ligacao.Open()
            Objecto = Comando.ExecuteScalar
            If IsDBNull(Objecto) Then
                Form1.TxtAbastNota.Text = "" 'Mudar
                MsgBox("ERRO Nota")
                ligacao.Close()
            Else
                Form1.TxtAbastNota.Text = CType(Objecto, String)
                ligacao.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            ligacao.Close()
        End Try


        Try
            Comando = New MySqlCommand("select concat(Nome_Proprio,' ',Apelido) from veiabast,Utilizador where utilizador.coduser=Veiabast.CoDuser and CodVeiAbast='" + Cod + "'", ligacao)
            ligacao.Open()
            Objecto = Comando.ExecuteScalar
            If IsDBNull(Objecto) Then
                Form1.LblAbastUtilizador.Text = "Utilizador:" 'Mudar
                MsgBox("ERRO Data")
                ligacao.Close()
            Else
                Form1.LblAbastUtilizador.Text = "Utilizador: " + CType(Objecto, String)
                ligacao.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            ligacao.Close()
        End Try

        Try
            Comando = New MySqlCommand("select concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) from Veiculos,Veiabast where Veiculos.CodVei=Veiabast.CodVei and CodVeiAbast='" + Cod + "'", ligacao)
            ligacao.Open()
            Objecto = Comando.ExecuteScalar
            If IsDBNull(Objecto) Then
                Form1.LblAbastVeiculo.Text = "Veiculo:" 'Mudar
                MsgBox("ERRO Data")
                ligacao.Close()
            Else
                Form1.LblAbastVeiculo.Text = "Veiculo: " + CType(Objecto, String)
                ligacao.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            ligacao.Close()
        End Try

        Try
            Comando = New MySqlCommand("select Veiculo_KM from Veiabast where  CodVeiAbast='" + Cod + "'", ligacao)
            ligacao.Open()
            Objecto = Comando.ExecuteScalar
            If IsDBNull(Objecto) Then
                Form1.LblAbastKM.Text = "KM:" 'Mudar
                MsgBox("ERRO Data")
                ligacao.Close()
            Else
                Form1.LblAbastKM.Text = "KM: " + CType(Objecto, String)
                ligacao.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            ligacao.Close()
        End Try

        Try
            Comando = New MySqlCommand("select Quantidade from Veiabast where  CodVeiAbast='" + Cod + "'", ligacao)
            ligacao.Open()
            Objecto = Comando.ExecuteScalar
            If IsDBNull(Objecto) Then
                Form1.LblAbastQuantidade.Text = "Quantidade:"
                MsgBox("ERRO Quantidade")
                ligacao.Close()
            Else
                Form1.LblAbastQuantidade.Text = "Quantidade: " + CType(Objecto, String)
                ligacao.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            ligacao.Close()
        End Try

        Try
            Comando = New MySqlCommand("select Valor from Veiabast where  CodVeiAbast='" + Cod + "'", ligacao)
            ligacao.Open()
            Objecto = Comando.ExecuteScalar
            If IsDBNull(Objecto) Then
                Form1.LblAbastValor.Text = "Valor:"
                MsgBox("ERRO Quantidade")
                ligacao.Close()
            Else
                Form1.LblAbastValor.Text = "Valor: " + CType(Objecto, String)
                ligacao.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            ligacao.Close()
        End Try

        Try
            Comando = New MySqlCommand("select nome from Veiabast,fornecedores where  fornecedores.codforn=Veiabast.codforn and CodVeiAbast='" + Cod + "'", ligacao)
            ligacao.Open()
            Objecto = Comando.ExecuteScalar
            If IsDBNull(Objecto) Then
                Form1.LblAbastFornecedor.Text = "Fornecedores:"
                MsgBox("ERRO Quantidade")
                ligacao.Close()
            Else
                Form1.LblAbastFornecedor.Text = "Fornecedores: " + CType(Objecto, String)
                ligacao.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            ligacao.Close()
        End Try
    End Sub

    Public Sub DetalhesDesp(ByVal Cod As String)
        Dim Comando As MySqlCommand
        Dim reader As MySqlDataReader
        Form1.LblDespCod.Text = "Código: " + Cod
        Comando = New MySqlCommand
        lComando = New MySqlCommand
        Comando.Connection = ligacao
        Comando.CommandText = ("select CodDesp,nota,Data_Efetuada as Data,tipodesp.Nome as Tipo,Valor,concat(Veiculo_km,' KM') as '" + "QuilometrosMUDAR" + "',concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veiculo,fornecedores.Nome as Fornecedor from despesas,Veiculos,Fornecedores,Utilizador,TipoDesp where Despesas.codvei=veiculos.codvei and Despesas.codforn=Fornecedores.codforn and Despesas.coduser=Utilizador.coduser and Despesas.codtipod=tipodesp.codtipod and efetuada='Sim' and CodDesp=" + Cod + " ")
        Try
            ligacao.Open()
            reader = Comando.ExecuteReader
            While reader.Read
                Form1.LblDespData.Text = "Data: " + reader("Data")
                Form1.LblDespTipo.Text = "Tipo: " + reader.GetString("Tipo")
                Form1.LblDespValor.Text = "Valor: " + reader.GetString("Valor")
                Form1.LblDespKM.Text = "KM: " + reader.GetString("QuilometrosMUDAR")
                Form1.LblDespVeiculo.Text = "Veiculo: " + reader.GetString("Veiculo")
                Form1.Label7.Text = "Fornecedor: " + reader.GetString("Fornecedor")
                Form1.TxtDespNota.Text = reader.GetString("Nota")
            End While
            ligacao.Close()
        Catch ex As Exception
            ligacao.Close()
            MsgBox(ex.ToString)
            Exit Sub
        End Try
    End Sub

    Public Sub DetalhesManu(ByVal Cod As String)
        Dim Comando As MySqlCommand
        Dim reader As MySqlDataReader
        Form1.LblManuCOD.Text = "Código: " + Cod
            Comando = New MySqlCommand
            lComando = New MySqlCommand
            Comando.Connection = ligacao
        Comando.CommandText = ("select Codmanu,Nota,Data_Efetuada as Data,tipoManu.Nome as Tipo,Valor,concat(Veiculo_km,' KM') as '" + "QuilometrosMUDAR" + "',concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veiculo,fornecedores.Nome as Fornecedor from VeiCondu,Manutencao,veiculos,fornecedores,tipomanu where VeiCondu.Codvei=Veiculos.Codvei and Veiculos.Codvei=manutencao.CodVei and fornecedores.Codforn=manutencao.Codforn and tipomanu.CodtipoM=manutencao.codtipom and efetuada='Sim' and EmUso='Sim' and CodManu=" + Cod + " ")
            Try
                ligacao.Open()
                reader = Comando.ExecuteReader
                While reader.Read
                Form1.LblManuData.Text = "Data: " + reader("Data")
                Form1.LblManuTipo.Text = "Tipo: " + reader.GetString("Tipo")
                Form1.LblManuValor.Text = "Valor: " + reader.GetString("Valor")
                Form1.LblManuKM.Text = "KM: " + reader.GetString("QuilometrosMUDAR")
                Form1.LblManuVeiculo.Text = "Veiculo: " + reader.GetString("Veiculo")
                Form1.LblManuFornecedor.Text = "Fornecedor: " + reader.GetString("Fornecedor")
                Form1.TxtManuNota.Text = reader.GetString("Nota")
                End While
                ligacao.Close()
            Catch ex As Exception
                ligacao.Close()
                MsgBox(ex.ToString)
                Exit Sub
            End Try
    End Sub

    Public TabelaSelecionada As String = ""
    Public IDSelecionado As String = ""

    Public Sub Inserir_EditarTabelaSQL(ByVal Tabela As String, Optional ByVal Id As String = "")
        Dim Manutencao As DataSet = New DataSet
        Dim reader As MySqlDataReader
        adapter.SelectCommand = New MySqlCommand
        adapter.SelectCommand.Connection = ligacao
        If Tabela = "ManuInsert" Or Tabela = "ManuEdit" Then
            Dim Tipo As DataSet = New DataSet
            adapter.SelectCommand = New MySqlCommand
            adapter.SelectCommand.Connection = ligacao
            adapter.SelectCommand.CommandText = ("Select CodTipoM, Nome from TipoManu")
            Try
                ligacao.Open()
                adapter.Fill(Tipo, "TIPOMANU")
                ligacao.Close()
            Catch ex As Exception
                ligacao.Close()
                MsgBox("ERRO Fornecedor")
                Exit Sub
            End Try
            Form1.LstInserirTipo.DataSource = Tipo.Tables(0)
            Form1.LstInserirTipo.DisplayMember = "Nome"
            Form1.LstInserirTipo.ValueMember = "CodTipoM"
        Else
            Dim Tipo As DataSet = New DataSet
            adapter.SelectCommand = New MySqlCommand
            adapter.SelectCommand.Connection = ligacao
            adapter.SelectCommand.CommandText = ("Select CodTipoD, Nome from Tipodesp")
            Try
                ligacao.Open()
                adapter.Fill(Tipo, "TIPODESP")
                ligacao.Close()
            Catch ex As Exception
                ligacao.Close()
                MsgBox("ERRO Fornecedor")
                Exit Sub
            End Try
            Form1.LstInserirTipo.DataSource = Tipo.Tables(0)
            Form1.LstInserirTipo.DisplayMember = "Nome"
            Form1.LstInserirTipo.ValueMember = "CodTipoD"
        End If


        adapter.SelectCommand.CommandText = ("Select CodForn, Nome from Fornecedores")
        Try
            ligacao.Open()
            adapter.Fill(Manutencao, "Fornecedor")
            ligacao.Close()
        Catch ex As Exception
            ligacao.Close()
            MsgBox("ERRO Fornecedor")
            Exit Sub
        End Try
        Form1.LstInserirFornecedor.DataSource = Manutencao.Tables(0)
        Form1.LstInserirFornecedor.DisplayMember = "Nome"
        Form1.LstInserirFornecedor.ValueMember = "CodForn"

        If Tabela = "AbastEdit" Then
            Comando = New MySqlCommand
            Comando.Connection = ligacao
            Comando.CommandText = "select * from veiabast,veiculos,fornecedores,Utilizador where Veiculos.Codvei=Veiabast.CodVei and fornecedores.Codforn=Veiabast.Codforn and Utilizador.CodUser=Veiabast.Coduser and CodVeiAbast=" + Id + ""
            Try
                ligacao.Open()
                reader = Comando.ExecuteReader
                While reader.Read
                    Form1.TxtInserirQuantidade.Text = reader.GetString("Quantidade")
                    Form1.TxtInserirValor.Text = reader.GetString("Valor")
                    Form1.TxtInserirQuilometros.Text = reader.GetString("Veiculo_KM")
                    Form1.TxtInserirNota.Text = reader.GetString("Notas")
                    Form1.LstInserirFornecedor.SelectedValue = reader.GetString("CodForn")
                End While
                ligacao.Close()
            Catch ex As Exception
                ligacao.Close()
                MsgBox(ex.ToString)
                Exit Sub
            End Try
        End If

        If Tabela = "ManuEdit" Then
            Comando = New MySqlCommand
            Comando.Connection = ligacao
            Comando.CommandText = "select * from Manutencao,veiculos,fornecedores,tipomanu where Veiculos.Codvei=manutencao.CodVei and fornecedores.Codforn=manutencao.Codforn and tipomanu.CodtipoM=manutencao.codtipom and CodManu=" + Id + ""
            Try
                ligacao.Open()
                reader = Comando.ExecuteReader
                While reader.Read
                    Form1.TxtInserirValor.Text = reader.GetString("Valor")
                    Form1.TxtInserirQuilometros.Text = reader.GetString("Veiculo_KM")
                    Form1.TxtInserirNota.Text = reader.GetString("Nota")
                    Form1.LstInserirFornecedor.SelectedValue = reader.GetString("CodForn")
                    Form1.LstInserirTipo.SelectedValue = reader.GetString("CodTipoM")
                End While
                ligacao.Close()
            Catch ex As Exception
                ligacao.Close()
                MsgBox(ex.ToString)
                Exit Sub
            End Try
        End If

        If Tabela = "DespEdit" Then
            Comando = New MySqlCommand
            Comando.Connection = ligacao
            Comando.CommandText = "select * from Manutencao,veiculos,fornecedores,tipomanu where Veiculos.Codvei=manutencao.CodVei and fornecedores.Codforn=manutencao.Codforn and tipomanu.CodtipoM=manutencao.codtipom and CodManu=" + Id + ""
            Try
                ligacao.Open()
                reader = Comando.ExecuteReader
                While reader.Read
                    Form1.TxtInserirValor.Text = reader.GetString("Valor")
                    Form1.TxtInserirQuilometros.Text = reader.GetString("Veiculo_KM")
                    Form1.TxtInserirNota.Text = reader.GetString("Nota")
                    Form1.LstInserirFornecedor.SelectedValue = reader.GetString("CodForn")
                    Form1.LstInserirTipo.SelectedValue = reader.GetString("CodTipoM")
                End While
                ligacao.Close()
            Catch ex As Exception
                ligacao.Close()
                MsgBox(ex.ToString)
                Exit Sub
            End Try
        End If
        MenuInserir_Editar(Tabela)
        TabelaSelecionada = Tabela
        IDSelecionado = Id
    End Sub



    Public Sub InserirDados(ByVal Tabela As String)
        Dim todaysdate As String = String.Format("{0:yyyy/MM/dd}", DateTime.Now)
        If Tabela = "AbastInsert" Then
            Try
                'insert into veiabast(Veiculo_KM,Quantidade,Valor,Notas,Codforn,Data,Codvei,Coduser) values (10,12,12,"TESTE 4",1,'1997-12-12',1,1)
                Comando = New MySqlCommand("insert into veiabast(Veiculo_KM,Quantidade,Valor,Notas,Codforn,Data,Codvei,Coduser) values ('" + Val(Form1.TxtInserirQuilometros.Text).ToString + "', '" + Val(Form1.TxtInserirQuantidade.Text).ToString + "', '" + Val(Form1.TxtInserirValor.Text).ToString + "', '" + Form1.TxtInserirNota.Text.ToString + "','" + Form1.LstInserirFornecedor.SelectedValue.ToString + "', '" + todaysdate + "', '" + DetalhesUtilizador.CodVeiculo.ToString + "', '" + DetalhesUtilizador.CodUser.ToString + "')", ligacao)
                ligacao.Open()
                Comando.ExecuteNonQuery()
                ligacao.Close()
                MsgBox("Inserido com sucesso")
                Form1.Panel1.Hide()
                Exit Sub
            Catch ex As Exception
                MsgBox(ex.ToString)
                ligacao.Close()
                Exit Sub
            End Try
        End If

        If Tabela = "ManuInsert" Then
            Try
                'insert into veiabast(Veiculo_KM,Quantidade,Valor,Notas,Codforn,Data,Codvei,Coduser) values (10,12,12,"TESTE 4",1,'1997-12-12',1,1)
                Comando = New MySqlCommand("insert into manutencao(Veiculo_KM,CodTipoM,Valor,Nota,Codforn,Data_Efetuada,Efetuada,Codvei,CodUser) values ('" + Val(Form1.TxtInserirQuilometros.Text).ToString + "', '" + Form1.LstInserirTipo.SelectedValue.ToString + "', '" + Val(Form1.TxtInserirValor.Text).ToString + "', '" + Form1.TxtInserirNota.Text.ToString + "', '" + Form1.LstInserirFornecedor.SelectedValue.ToString + "', '" + todaysdate + "', '" + "Sim" + "', '" + DetalhesUtilizador.CodVeiculo.ToString + "', '" + DetalhesUtilizador.CodUser.ToString + "')", ligacao)
                ligacao.Open()
                Comando.ExecuteNonQuery()
                ligacao.Close()
                MsgBox("manutencao com sucesso")
                Form1.Panel1.Hide()
                Exit Sub
            Catch ex As Exception
                MsgBox(ex.ToString)
                ligacao.Close()
                Exit Sub
            End Try
        End If

        If Tabela = "DespInsert" Then
            Try
                'insert into veiabast(Veiculo_KM,Quantidade,Valor,Notas,Codforn,Data,Codvei,Coduser) values (10,12,12,"TESTE 4",1,'1997-12-12',1,1)
                Comando = New MySqlCommand("insert into Despesa(Veiculo_KM,CodTipoM,Valor,Nota,Codforn,Data_Efetuada,Efetuada,Codvei) values ('" + Val(Form1.TxtInserirQuilometros.Text).ToString + "', '" + Form1.LstInserirTipo.SelectedValue.ToString + "', '" + Val(Form1.TxtInserirValor.Text).ToString + "', '" + Form1.TxtInserirNota.Text.ToString + "', '" + Form1.LstInserirFornecedor.SelectedValue.ToString + "', '" + todaysdate + "', '" + "Sim" + "', '" + DetalhesUtilizador.CodVeiculo.ToString + "')", ligacao)
                ligacao.Open()
                Comando.ExecuteNonQuery()
                ligacao.Close()
                MsgBox("manutencao com sucesso")
                Form1.Panel1.Hide()
                Exit Sub
            Catch ex As Exception
                MsgBox(ex.ToString)
                ligacao.Close()
                Exit Sub
            End Try
        End If
    End Sub

    Public Sub EditarDados(ByVal Tabela As String)
        If Tabela = "AbastEdit" Then
            Try
                Comando = New MySqlCommand("Update veiabast set Veiculo_KM='" + Val(Form1.TxtInserirQuilometros.Text).ToString + "',Quantidade='" + Val(Form1.TxtInserirQuantidade.Text).ToString + "',Valor='" + Val(Form1.TxtInserirValor.Text).ToString + "',Notas='" + Form1.TxtInserirNota.Text.ToString + "',Codforn='" + Form1.LstInserirFornecedor.SelectedValue.ToString + "' where CodveiAbast='" + IDSelecionado + "'", ligacao)
                ligacao.Open()
                Comando.ExecuteNonQuery()
                ligacao.Close()
                MsgBox("Editado com sucesso")
                Exit Sub
            Catch ex As Exception
                MsgBox(ex.ToString)
                ligacao.Close()
                Exit Sub
            End Try
        End If

        If Tabela = "ManuEdit" Then
            Try
                Comando = New MySqlCommand("Update Manutencao set Veiculo_KM='" + Val(Form1.TxtInserirQuilometros.Text).ToString + "',CodTipoM='" + Form1.LstInserirTipo.SelectedValue.ToString + "',Valor='" + Val(Form1.TxtInserirValor.Text).ToString + "',Nota='" + Form1.TxtInserirNota.Text.ToString + "',Codforn='" + Form1.LstInserirFornecedor.SelectedValue.ToString + "' where Codmanu='" + IDSelecionado + "'", ligacao)
                ligacao.Open()
                Comando.ExecuteNonQuery()
                ligacao.Close()
                MsgBox("Editado com sucesso")
                Exit Sub
            Catch ex As Exception
                MsgBox(ex.ToString)
                ligacao.Close()
                Exit Sub
            End Try
        End If

    End Sub


End Module
