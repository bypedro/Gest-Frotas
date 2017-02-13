Public Class UtilizadorDetalhes
    Private _CodUser As Integer
    Private _NomeRegisto As String
    Private _Senha As String
    Private _NomeProprio As String
    Private _Apelido As String
    Private _Genero As String
    Private _DataNasc As String
    Private _DataContrat As String
    Private _PagamentoHora As String
    Private _Habilitações As String
    Private _Rua As String
    Private _NTelemovel As String
    Private _NTelefone As String
    Private _Email As String
    Private _NotasContacto As String
    Private _NotasContrato As String
    Private _TipoUtilizador As Integer
    Private _Cidade As String
    Private _Pais As String

    Public Property CodUser As String
        Get
            Return _CodUser
        End Get
        Set(ByVal value As String)
            _CodUser = value
        End Set
    End Property

    Public Property NomeRegisto As String
        Get
            Return _NomeRegisto
        End Get
        Set(ByVal value As String)
            _NomeRegisto = value
        End Set
    End Property
End Class
