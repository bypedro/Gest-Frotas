Imports System.Drawing.Text
Imports System.Drawing
'Define evento primário->
<System.ComponentModel.DefaultEventAttribute("ButtonClickMasterRace")> _
Public Class BtnImagem
    <System.ComponentModel.Category("BtnImagem")> _
    Public Property zCorSelecionado As Color = Color.SteelBlue
    <System.ComponentModel.Category("BtnImagem")> _
    Public Property zCorFundo As Color = Color.SlateGray
    '    Get
    '        zCorFundo = Me.BackColor
    '    End Get
    '    Set(ByVal value As Color)
    '        Me.BackColor = value
    '    End Set
    'End Property
    'Ver outra solução
    <System.ComponentModel.Category("BtnImagem")> _
    Public Property zCorHover As Color = Color.LightSlateGray
    Dim corfundo As Color = zCorFundo
    Dim corselecionado As Color = zCorSelecionado

    <System.ComponentModel.Category("BtnImagem")> _
    Public Property zTamanhoLetra As Integer
        Get
            zTamanhoLetra = LblTexto.Font.Size
        End Get
        Set(ByVal value As Integer)
            LblTexto.Font = Fonte.GetInstance(value, FontStyle.Bold)
        End Set
    End Property
    <System.ComponentModel.Category("BtnImagem")> _
    Public Property zTexto As String
        Get
            zTexto = LblTexto.Text
        End Get
        Set(ByVal value As String)
            LblTexto.Text = value
        End Set
    End Property
    <System.ComponentModel.Category("BtnImagem")> _
    Public Property zImagem As System.Drawing.Bitmap
        Get
            zImagem = Imagem.Image
        End Get
        Set(ByVal value As System.Drawing.Bitmap)
            Imagem.Image = value
        End Set
    End Property
    <System.ComponentModel.Category("BtnImagem")> _
    Public Property zComprimentoImagem As Integer
        Get
            zComprimentoImagem = Imagem.Width
        End Get
        Set(ByVal value As Integer)
            Imagem.Width = value
        End Set
    End Property
    <System.ComponentModel.Category("BtnImagem")> _
    Public Property zAlturaImagem As Integer
        Get
            zAlturaImagem = Imagem.Height
        End Get
        Set(ByVal value As Integer)
            Imagem.Height = value
        End Set
    End Property
    <System.ComponentModel.Category("BtnImagem")> _
    Public Property zEstadoBotao As Boolean = False

    Private Sub BtnImagem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LblTexto.Font = Fonte.GetInstance(zTamanhoLetra, FontStyle.Bold)
        If zEstadoBotao = False Then
            Me.BackColor = zCorFundo
        Else
            Me.BackColor = corselecionado
        End If
    End Sub

    Public Sub VerificarEstadoBotao()
        If zEstadoBotao = False Then
            Me.BackColor = corfundo
            zEstadoBotao = False
        End If
        If zEstadoBotao = True Then
            Me.BackColor = corselecionado
            zEstadoBotao = True
        End If
    End Sub

    Public Sub EventoClick()
        If zEstadoBotao = False Then
            Me.BackColor = corselecionado
            Me.zEstadoBotao = True
        End If
        VerificarEstadoBotao()
    End Sub

    Public Event ButtonClickMasterRace(ByVal sender As System.Object, ByVal e As System.EventArgs)

    Private Sub Objetos(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Imagem.Click, LblTexto.Click, Me.Click
        EventoClick()
        RaiseEvent ButtonClickMasterRace(Me, EventArgs.Empty)
    End Sub


    Private Sub Btnhover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.MouseEnter, LblTexto.MouseEnter, Imagem.MouseEnter 'Mousehover tem delay
        If zEstadoBotao = False Then
            Me.BackColor = zCorHover
        End If
    End Sub
    Private Sub Btnleave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.MouseLeave, Imagem.MouseLeave, LblTexto.MouseLeave
        If zEstadoBotao = False Then
            Me.BackColor = corfundo
        End If
    End Sub
End Class