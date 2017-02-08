Imports MySql.Data.MySqlClient
Imports System.Net.Mail

Module SQL
    Dim DB As String = "frotas"

    Dim ligacao As New MySqlConnection("Server=localhost;Database=" + DB + ";Uid=root;Pwd=" + Form1.bdpass + ";Connect timeout=30;") 'MUDAR TALVEZ
    Dim adapter As New MySqlDataAdapter
    Public Function Login(ByVal Utilizador As String, ByVal Password As String) As Boolean
        Dim max As MySqlCommand
        Dim User As Object
        Dim str As String
        If LCase(Utilizador).Contains(LCase("@")) Then
            Try 'Isto dáa
                If Utilizador.ToString <> "" Or Password.ToString <> "" Then
                    max = New MySqlCommand("select Senha from Utilizador where Email='" + Utilizador + "'", ligacao)
                    ligacao.Open()
                    User = max.ExecuteScalar
                    str = CType(User, String)
                    ligacao.Close()
                    If str = Password.ToLower Or str = Password.ToUpper Then
                        MsgBox("Password correta")
                        Return (True)
                        Exit Function
                    Else
                        MsgBox("Password errada")
                        Return (True)
                        Exit Function
                    End If
                End If
            Catch ex As Exception
                MsgBox("ERRO 0")
            End Try
        Else
            Try 'Isto dáa
                If Utilizador.ToString <> "" Or Password.ToString <> "" Then
                    max = New MySqlCommand("select Senha from Utilizador where Nome_Registo='" + Utilizador + "'", ligacao)
                    ligacao.Open()
                    User = max.ExecuteScalar
                    str = CType(User, String)
                    ligacao.Close()
                    If str = Password.ToLower Or str = Password.ToUpper Then
                        MsgBox("Password correta")
                        MsgBox(Password + "||||||||||" + str)
                        Return (True)
                        Exit Function
                    Else
                        MsgBox("Password errada")

                        Return (False)
                        Exit Function
                    End If
                End If
            Catch ex As Exception
                MsgBox("ERRO 1")
            End Try
        End If
        Return (False)
    End Function



    Public Function Registar(ByVal Utilizador As String, ByVal Password1 As String, ByVal Password2 As String, ByVal Email As String) As Boolean
        Dim Comando As MySqlCommand
        Dim Objecto As Object
        Dim UtilizadorBD As String = ""
        Dim EmailBD As String = ""

        'Fazer isto para todos
        If Email = "" Then
            MsgBox("Necessita de um email")
            Return False
            Exit Function
        Else
            Try
                Dim testAddress = New MailAddress(Email)
            Catch ex As FormatException
                MsgBox("Email invalido")
                Return False
                Exit Function
            End Try
        End If

        'VEr?


        'Procurar utilizador na base de dados
        Try
            Comando = New MySqlCommand("select Nome_Registo from Utilizador where Nome_Registo='" + Utilizador + "'", ligacao)
            ligacao.Open()
            Objecto = Comando.ExecuteScalar
            UtilizadorBD = CType(Objecto, String)
            ligacao.Close()
        Catch ex As Exception
            MsgBox("ERRO UTILIZADOR 0")
        End Try
        'Procurar email na base de dados
        Try
            Comando = New MySqlCommand("select email from Utilizador where email='" + Email + "'", ligacao)
            ligacao.Open()
            Objecto = Comando.ExecuteScalar
            EmailBD = CType(Objecto, String)
            ligacao.Close()
        Catch ex As Exception
            MsgBox("ERRO UTILIZADOR 1")
        End Try



        If Password1 = "" Then
            MsgBox("Necessita de Password")
            Return False
            Exit Function
        End If

        If Password1 <> Password2 Then
            MsgBox("Passwords Não são iguais")
            Return False
            Exit Function
        End If

        'BUGS AHEAD
        If EmailBD <> "" Then
            If Email = EmailBD Then 'IDK
                MsgBox("Email já existe")
                Return False
                Exit Function
            End If
        Else
        End If

        If UtilizadorBD <> "" Then
            If Utilizador = UtilizadorBD Then
                MsgBox("Utilizador já existe")
                Return False
                Exit Function
            End If

        End If
        'BUGS AHEAD






        Try
            Comando = New MySqlCommand("insert into utilizador (Nome_Registo, Senha,Email) values ('" + Utilizador + "', '" + HashPassword(Password1) + "', '" + Email + "')", ligacao)
            ligacao.Open()
            Comando.ExecuteNonQuery()
            ligacao.Close()
            Return (True)
        Catch ex As Exception
            MsgBox("ERRO INSERT 1")
        End Try
        Return (False)
    End Function

End Module
