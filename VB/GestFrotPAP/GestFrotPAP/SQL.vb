Imports MySql.Data.MySqlClient
Module SQL
    Dim DB As String = "gestfrot"
    Dim ligacao As New MySqlConnection("Server=localhost;Database=" + DB + ";Uid=root;Pwd=;Connect timeout=30;") 'Criar form para configurar?
    Dim adapter As New MySqlDataAdapter
    Public Sub Login(ByVal Utilizador As String, ByVal Password As String)
        Dim max As MySqlCommand
        Dim User As Object
        Dim str As String
        If LCase(Utilizador).Contains(LCase("@")) Then
            Try 'Isto dáa
                If Utilizador.ToString <> "" Or Password.ToString <> "" Then
                    max = New MySqlCommand("select Password from Utilizador where Email='" + Utilizador + "'", ligacao)
                    ligacao.Open()
                    User = max.ExecuteScalar
                    str = CType(User, String)
                    ligacao.Close()
                    If str = Password Then
                        MsgBox("Password correta")
                    Else
                        MsgBox("Password errada")
                    End If
                End If
            Catch ex As Exception
                MsgBox("ERRO")
            End Try
        Else
            Try 'Isto dáa
                If Utilizador.ToString <> "" Or Password.ToString <> "" Then
                    max = New MySqlCommand("select Password from Utilizador where Username='" + Utilizador + "'", ligacao)
                    ligacao.Open()
                    User = max.ExecuteScalar
                    str = CType(User, String)
                    ligacao.Close()
                    If str = Password Then
                        MsgBox("Password correta")
                    Else
                        MsgBox("Password errada")
                    End If
                End If
            Catch ex As Exception
                MsgBox("ERRO")
            End Try
        End If
    End Sub
End Module
