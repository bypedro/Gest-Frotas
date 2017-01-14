Imports System.Text
Imports System.Security.Cryptography
Module Password
    Public Function HashPassword(ByVal Password As String) As String
        Dim pwd As String = Password
        Dim hasher As New Security.Cryptography.SHA256Managed()
        Dim pwdb As Byte() = System.Text.Encoding.ASCII.GetBytes(pwd)
        Dim pwdh As Byte() = hasher.ComputeHash(pwdb)
        Return BitConverter.ToString(pwdh).Replace("-", "")
    End Function
End Module
