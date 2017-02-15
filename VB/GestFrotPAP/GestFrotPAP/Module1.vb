Imports System.Data.Sql
Imports System.IO
Imports System.Drawing

Module Module1

    Private Const _ConnectString As String = ("Server=localhost;Database=LOL;Uid=root;Pwd=;Connect timeout=30;Convert Zero Datetime=True;")

    Sub Main()
        Dim MyImage As Image = Image.FromFile("RandomImage.jpg")
        Dim Id As Long = 1
        SaveDrinkImage(MyImage, Id)
    End Sub

    Sub SaveDrinkImage(ByVal MyImage As Image, ByVal Id As Long)

        Dim ImageBytes(0) As Byte
        Using mStream As New MemoryStream()
            MyImage.Save(mStream, MyImage.RawFormat)
            ImageBytes = mStream.ToArray()
        End Using

        Dim adoConnect = New SqlClient.SqlConnection(_ConnectString)
        Dim adoCommand = New SqlClient.SqlCommand("UPDATE [drink] SET [image]=@MyNewImage WHERE [id]=@id", adoConnect)

        With adoCommand.Parameters.Add("@MyNewImage", SqlDbType.Image)
            .Value = ImageBytes
            .Size = ImageBytes.Length
        End With
        With adoCommand.Parameters.Add("@id", SqlDbType.BigInt)
            .Value = Id
        End With

        adoConnect.Open()
        adoCommand.ExecuteNonQuery()
        adoConnect.close()

    End Sub

End Module