Imports System.Drawing
Imports System.Drawing.Drawing2D





Public Class Form1
    Dim N As Integer = 3 'Nº butões
    Dim BtnImagem(N) As BtnImagem
    Dim panel(N) As Panel

    Private Sub check(ByVal c As Integer, Optional ByVal MenuDefault As Boolean = False, Optional ByVal MenuHome As Boolean = False)
        Dim a As Integer
        For a = 0 To N
            If BtnImagem(a).EstadoBotao = True And a <> c Then
                BtnImagem(a).EstadoBotao = False
                BtnImagem(a).VerificarEstadoBotao()
                panel(a).Hide()
            End If
            panel(c).Show()
        Next
        If MenuDefault = True Then
            If PnlMenu.Right = 200 Then
                BtnMenu1.resetbtn()
                For a = 0 To N
                    BtnImagem(a).Hide()
                Next
                TmrSlide1.Enabled = True
            End If
        End If
        If MenuHome = True Then
            If PnlMenu.Right = 36 Then
                BtnMenu1.resetbtn()
                For a = 0 To N
                    BtnImagem(a).Hide()
                Next
                TmrSlide2.Enabled = True
                BtnMenu1.zEstadoBotao = False
                BtnMenu1.resetbtn()
            End If
        End If
    End Sub

    Private Sub Botao(ByVal c As BtnImagem)
        If c.EstadoBotao = True Then
            c.EstadoBotao = False
            c.VerificarEstadoBotao()
        End If
    End Sub


   


    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
        Fade(1) 'VEr
    End Sub
    ' VEr

    Public Sub c_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        If sender Is LblUtilzadorMenu And PnlUser.Visible = True Then
            PnlUser.Hide()
        Else
            If sender Is LblUtilzadorMenu Or sender Is PnlUser Then
                PnlUser.Show()
            Else
                PnlUser.Hide()
            End If
        End If

    End Sub


    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        'Adiciona evento a todos os objetos do programa(Só os da microsoft)
        AddHandler Me.MouseDown, AddressOf c_MouseDown
        For Each c As Control In Me.Controls
            AddHandler c.MouseDown, AddressOf c_MouseDown
        Next
        For Each c As Control In PnlLogin.Controls
            AddHandler c.MouseDown, AddressOf c_MouseDown
        Next
        For Each c As Control In PnlMenu.Controls
            AddHandler c.MouseDown, AddressOf c_MouseDown
        Next
        AddHandler LblNomeProjeto.MouseDown, AddressOf c_MouseDown
        'Adiciona evento a todos os objetos do programa(Só os da microsoft)

        'Arrays de Objetos
        panel(0) = PnlHome
        panel(1) = Panel2
        panel(2) = Panel3
        panel(3) = Panel4
        BtnImagem(0) = BtnImagem1
        BtnImagem(1) = BtnImagem2
        BtnImagem(2) = BtnImagem3
        BtnImagem(3) = BtnImagem4
        'Arrays de Objetos


        'Panel1.Location = New Point((Me.DisplayRectangle.Width - Panel1.Width) / 2 + 100, (Me.DisplayRectangle.Height - Panel1.Height) / 2) 'Código para por no centro do ecrâ














        'IDK yet
        Fechar.Font = Fonte.GetInstance(12, FontStyle.Bold)
        Fechar.Text = "X"
        Fechar.ForeColor = Color.White
        Fechar.Left = PnlBarraTop.Right - 25
        Fechar.Top = (PnlBarraTop.Height - Fechar.Height) / 2

        LoadOrder.LoginPage() 'é tipo o modulo aparencia
        Fade(0)
    End Sub



    Private Sub BtnImagem1_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImagem1.ButtonClickMasterRace
        check(0, False, True)
    End Sub
    Private Sub BtnImagem2_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImagem2.ButtonClickMasterRace
        check(1, True)
    End Sub
    Private Sub BtnImagem3_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImagem3.ButtonClickMasterRace
        check(2, True)
    End Sub
    Private Sub BtnImagem4_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImagem4.ButtonClickMasterRace
        check(3, True)
    End Sub

    Private Sub TmrSlide1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles TmrSlide1.Tick
        PnlMenu.Left = PnlMenu.Left - 2
        For a = 0 To N
            BtnImagem(a).Left = BtnImagem(a).Left + 2
        Next
        If PnlMenu.Right = 36 Then
            TmrSlide1.Enabled = False
            For a = 0 To N
                BtnImagem(a).Show()
            Next
        End If
        BtnMenu1.zEstadoBotao = True
        BtnMenu1.resetbtn()
    End Sub

    Private Sub TmrSlide2_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles TmrSlide2.Tick
        PnlMenu.Left = PnlMenu.Left + 2
        Dim a As Integer
        For a = 0 To N
            BtnImagem(a).Left = BtnImagem(a).Left - 2
        Next
        If PnlMenu.Right = 200 Then
            TmrSlide2.Enabled = False
            For a = 0 To N
                BtnImagem(a).Show()
            Next
        End If
        BtnMenu1.zEstadoBotao = False
        BtnMenu1.resetbtn()
    End Sub

    Private Sub BtnMenu1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnMenu1.Click

        If BtnImagem(0).EstadoBotao <> True Then
            BtnMenu1.resetbtn()
            For a = 0 To N
                BtnImagem(a).Hide()
            Next
            If PnlMenu.Right = 200 Then
                TmrSlide1.Enabled = True
            ElseIf PnlMenu.Right = 36 Then
                TmrSlide2.Enabled = True
            End If
        End If
    End Sub

    Private Sub fechar_click(ByVal sender As Object, ByVal e As EventArgs) Handles Fechar.Click
        Close()
    End Sub

    Private Sub BtnImagemLogin_ButtonClickMasterRace(ByVal sender As Object, ByVal e As EventArgs) Handles BtnImagemLogin.ButtonClickMasterRace
        Botao(BtnImagemLogin)
        If Login(TxtUserLogin.Text, HashPassword(TxtPwdLogin.Text)) = True Then
            'If DetalhesUtilizador.TipoUtilizadorCod = 1 Then 'Só Admin
            LoadOrder.MenuPrincipalPage()
            check(0)
            ' If


        Else

        End If

        'LoadOrder.l2()
    End Sub

    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Private Sub Panel2_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PnlBarraTop.MouseDown
        drag = True
        mousex = Windows.Forms.Cursor.Position.X - Me.Left
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub
    Private Sub Panel2_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PnlBarraTop.MouseMove
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub
    Private Sub Panel2_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PnlBarraTop.MouseUp
        drag = False
    End Sub


    Private Sub BtnImagemRegistarEntrar_ButtonClickMasterRace(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImagemRegistarEntrar.ButtonClickMasterRace
        Botao(BtnImagemRegistarEntrar)
        LoadOrder.RegistarPage()
    End Sub

    Private Sub BtnImagemCancelar_ButtonClickMasterRace_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImagemCancelar.ButtonClickMasterRace
        Botao(BtnImagemCancelar)
        LoadOrder.LoginPage()
        TxtEmailReg.Text = ""
        TxtUserReg.Text = ""
        TxtPwdReg1.Text = ""
        TxtPwdReg2.Text = ""


    End Sub

    Private Sub BtnImagemRegistar_ButtonClickMasterRace(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImagemRegistar.ButtonClickMasterRace
        Botao(BtnImagemRegistar)
        'Por codigo
        If RegistarUtilizador(TxtUserReg.Text, TxtPwdReg1.Text, TxtPwdReg2.Text, TxtEmailReg.Text) = True Then
            MsgBox("INSERIDO COM SUCESSO")
        End If

    End Sub

    Private Sub LblUserName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblUtilzadorMenu.Click
        If PnlUser.Visible = True Then
            PnlUser.Hide()
        Else
            PnlUser.Show()
            PnlUser.BringToFront()
        End If
    End Sub

    Private Sub LblUserName_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblUtilzadorMenu.MouseEnter
        LblUtilzadorMenu.ForeColor = Color.White 'No futuro Opção para mudar?
    End Sub

    Private Sub LblUserName_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblUtilzadorMenu.MouseLeave
        LblUtilzadorMenu.ForeColor = Color.DarkGray 'No futuro Opção para mudar?
    End Sub

    Sub Label1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Label1.Click
        MsgBox("LOL")
    End Sub

    Private Sub Label3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Label3.Click
        LoadOrder.LoginPage()
        PnlLogin.Show()
        PnlHome.Hide()
        LblUtilzadorMenu.Hide()
        PnlUser.Hide()
        PnlDefUtilizador.Hide()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        If PnlDefUtilizador.Visible = False Then
            MenuUtilizador()
            PnlDefUtilizador.Visible = True
            PnlDefUtilizador.BringToFront()
            PnlUser.Hide()
        Else
            PnlDefUtilizador.Visible = False
        End If
    End Sub

    Private Sub BtnDefUtilizadorInfoEdit_ButtonClickMasterRace(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDefUtilizadorInfoEdit.ButtonClickMasterRace
        Botao(BtnDefUtilizadorInfoEdit)

        If TxtUtilizadorUserDef.Enabled = False Then
            TxtUtilizadorUserDef.Enabled = True
            TxtUtilizadorNomePDef.Enabled = True
            TxtUtilizadorApelidoDef.Enabled = True
            TxtUtilizadorDataNascDef.Enabled = True
            TxtUtilizadorDataContratDef.Enabled = True
            TxtUtilizadorGeneroDef.Enabled = True
            TxtUtilizadorPagmentoDef.Enabled = True
            TxtUtilizadorHabilitacoesDef.Enabled = True
            TxtUtilizadorNotasDef.Enabled = True
            BtnDefUtilizadorInfoEdit.Texto = "Guardar"
        Else
            TxtUtilizadorUserDef.Enabled = False
            TxtUtilizadorNomePDef.Enabled = False
            TxtUtilizadorApelidoDef.Enabled = False
            TxtUtilizadorDataNascDef.Enabled = False
            TxtUtilizadorDataContratDef.Enabled = False
            TxtUtilizadorGeneroDef.Enabled = False
            TxtUtilizadorPagmentoDef.Enabled = False
            TxtUtilizadorHabilitacoesDef.Enabled = False
            TxtUtilizadorNotasDef.Enabled = False
            EditarUtilizador(TxtUtilizadorUserDef.Text.ToString, TxtUtilizadorNomePDef.Text.ToString, TxtUtilizadorApelidoDef.Text.ToString, TxtUtilizadorDataNascDef.Text.ToString, TxtUtilizadorDataContratDef.Text.ToString, TxtUtilizadorPagmentoDef.Text.ToString, TxtUtilizadorGeneroDef.Text.ToString, TxtUtilizadorHabilitacoesDef.Text.ToString, TxtUtilizadorNotasDef.Text.ToString)
            LoadOrder.MenuPrincipalPage()
            BtnDefUtilizadorInfoEdit.Texto = "Editar"
        End If

    End Sub
End Class
