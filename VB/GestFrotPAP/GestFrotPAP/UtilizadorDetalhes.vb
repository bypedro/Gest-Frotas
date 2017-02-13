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

    Public Property Senha As String
        Get
            Return _Senha
        End Get
        Set(ByVal value As String)
            _Senha = value
        End Set
    End Property

    Public Property NomeProprio As String
        Get
            Return _NomeProprio
        End Get
        Set(ByVal value As String)
            _NomeProprio = value
        End Set
    End Property

    Public Property Apelido As String
        Get
            Return _Apelido
        End Get
        Set(ByVal value As String)
            _Apelido = value
        End Set
    End Property

    Public Property Genero As String
        Get
            Return _Genero
        End Get
        Set(ByVal value As String)
            _Genero = value
        End Set
    End Property

    Public Property DataNasc As String
        Get
            Return _DataNasc
        End Get
        Set(ByVal value As String)
            _DataNasc = value
        End Set
    End Property

    Public Property DataContrat As String
        Get
            Return _DataContrat
        End Get
        Set(ByVal value As String)
            _DataContrat = value
        End Set
    End Property
    Public Property PagamentoHora As String
        Get
            Return _PagamentoHora
        End Get
        Set(ByVal value As String)
            _PagamentoHora = value
        End Set
    End Property

    Public Property Habilitações As String
        Get
            Return _Habilitações
        End Get
        Set(ByVal value As String)
            _Habilitações = value
        End Set
    End Property

    Public Property Rua As String
        Get
            Return _Rua
        End Get
        Set(ByVal value As String)
            _Rua = value
        End Set
    End Property

    Public Property NTelemovel As String
        Get
            Return _NTelemovel
        End Get
        Set(ByVal value As String)
            _NTelemovel = value
        End Set
    End Property

    Public Property NTelefone As String
        Get
            Return _NTelefone
        End Get
        Set(ByVal value As String)
            _NTelefone = value
        End Set
    End Property

    Public Property Email As String
        Get
            Return _Email
        End Get
        Set(ByVal value As String)
            _Email = value
        End Set
    End Property

    Public Property NotasContacto As String
        Get
            Return _NotasContacto
        End Get
        Set(ByVal value As String)
            _NotasContacto = value
        End Set
    End Property

    Public Property NotasContrato As String
        Get
            Return _NotasContrato
        End Get
        Set(ByVal value As String)
            _NotasContrato = value
        End Set
    End Property

    Public Property TipoUtilizador As Integer 'Talvez Mudar para string
        Get
            Return _NotasContrato
        End Get
        Set(ByVal value As Integer)
            _NotasContrato = value
        End Set
    End Property

    Public Property Cidade As Integer
        Get
            Return _Cidade
        End Get
        Set(ByVal value As Integer)
            _Cidade = value
        End Set
    End Property

    Public Property Pais As Integer
        Get
            Return _Pais
        End Get
        Set(ByVal value As Integer)
            _Pais = value
        End Set
    End Property



End Class
