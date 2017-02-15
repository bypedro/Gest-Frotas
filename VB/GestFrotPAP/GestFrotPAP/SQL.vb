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

    Public Function Registar(ByVal Utilizador As String, ByVal Password1 As String, ByVal Password2 As String, ByVal Email As String) As Boolean
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
    End Sub





End Module
