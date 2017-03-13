Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Imports System.Runtime.InteropServices



Public Class Form1
    'ListBox
    Private Declare Function LockWindowUpdate Lib "user32" (ByVal hwndLock As IntPtr) As Int32
    Private Declare Function ShowScrollBar Lib "user32" (ByVal hwnd As IntPtr, ByVal wBar As Int32, ByVal bShow As Int32) As Int32
    Private Const SB_VERT = 1

    Dim NMenuPrincipal As Integer = 6 'Nº butões
    Dim BtnImagemMenuPrincipal(NMenuPrincipal) As BtnImagem
    Dim panelMenuPrincipal(NMenuPrincipal) As Panel

    Dim NMenuDefutilizador As Integer = 1 '  'Nº butões
    Dim BtnImagemMenuDefUtilizador1(NMenuDefutilizador) As BtnImagem
    Dim panelMenuDefUtilizador(NMenuDefutilizador) As Panel

    Dim NMenuAgenda As Integer = 1 '  'Nº butões
    Dim BtnImagemMenuAgenda(NMenuAgenda) As BtnImagem
    Dim panelMenuAgenda(NMenuAgenda) As Panel

    Private Sub MenuPrincipal(ByVal c As Integer, Optional ByVal MenuDefault As Boolean = False, Optional ByVal MenuHome As Boolean = False)
        Dim a As Integer
        For a = 0 To NMenuPrincipal
            If BtnImagemMenuPrincipal(a).EstadoBotao = True And a <> c Then
                BtnImagemMenuPrincipal(a).EstadoBotao = False
                BtnImagemMenuPrincipal(a).VerificarEstadoBotao()
                panelMenuPrincipal(a).Hide()
            End If
            panelMenuPrincipal(c).Show()
        Next
        If MenuDefault = True Then
            If PnlMenu.Right = 200 Then
                BtnMenu1.resetbtn()
                For a = 0 To NMenuPrincipal
                    BtnImagemMenuPrincipal(a).Hide()
                Next
                TmrSlide1.Enabled = True
            End If
        End If
        If MenuHome = True Then
            If PnlMenu.Right = 36 Then
                BtnMenu1.resetbtn()
                For a = 0 To NMenuPrincipal
                    BtnImagemMenuPrincipal(a).Hide()
                Next
                TmrSlide2.Enabled = True
                BtnMenu1.zEstadoBotao = False
                BtnMenu1.resetbtn()
            End If
        End If
    End Sub

    Private Sub MenuDefUtilizador(ByVal d As Integer)
        Dim a As Integer
        For a = 0 To NMenuDefutilizador
            If BtnImagemMenuDefUtilizador1(a).EstadoBotao = True And a <> d Then
                BtnImagemMenuDefUtilizador1(a).EstadoBotao = False
                BtnImagemMenuDefUtilizador1(a).VerificarEstadoBotao()
                panelMenuDefUtilizador(a).Hide()
            End If
            panelMenuDefUtilizador(d).Show()
        Next
    End Sub

    Private Sub MenuAgenda(ByVal d As Integer)
        Dim a As Integer
        For a = 0 To NMenuAgenda
            If BtnImagemMenuAgenda(a).EstadoBotao = True And a <> d Then
                BtnImagemMenuAgenda(a).EstadoBotao = False
                BtnImagemMenuAgenda(a).VerificarEstadoBotao()
                panelMenuAgenda(a).Hide()
            End If
            panelMenuAgenda(d).Show()
        Next
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


        'Adiciona evento a todos os objetos do programa(Associados ao form1)(Objetos dentro de paneis necessitao de ser adicionados)
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
        '
        'Menu definições 
        '
        panelMenuDefUtilizador(0) = PnlDefUtilizadorInfo
        panelMenuDefUtilizador(1) = PnlDefUtilizadorContato
        BtnImagemMenuDefUtilizador1(0) = BtnImagemDefUtilizadorInfo
        BtnImagemMenuDefUtilizador1(1) = BtnImagemDefUtilizadorContato
        '
        'Menu Principal
        '
        panelMenuPrincipal(0) = PnlHome
        panelMenuPrincipal(1) = Panel2
        panelMenuPrincipal(2) = Panel3
        panelMenuPrincipal(3) = Panel4
        panelMenuPrincipal(4) = Panel5
        panelMenuPrincipal(5) = Panel6
        panelMenuPrincipal(6) = Panel7
        BtnImagemMenuPrincipal(0) = BtnImagem1
        BtnImagemMenuPrincipal(1) = BtnImagem2
        BtnImagemMenuPrincipal(2) = BtnImagem3
        BtnImagemMenuPrincipal(3) = BtnImagem4
        BtnImagemMenuPrincipal(4) = BtnImagem5
        BtnImagemMenuPrincipal(5) = BtnImagem6
        BtnImagemMenuPrincipal(6) = BtnImagem7
        '
        'Menu Agenda
        '
        BtnImagemMenuAgenda(0) = BtnImagemAgendaManu
        BtnImagemMenuAgenda(1) = BtnImagemAgendaDesp
        panelMenuAgenda(0) = PnlAgendaManu
        panelMenuAgenda(1) = PnlAgendaDesp

        'Arrays de Objetos

        'Panel1.Location = New Point((Me.DisplayRectangle.Width - Panel1.Width) / 2 + 100, (Me.DisplayRectangle.Height - Panel1.Height) / 2) 'Código para por no centro do ecrâ



        LblPnlHome.Font = Fonte.GetInstance(15, FontStyle.Bold)
        LblPnlHome.ForeColor = Color.White



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
        MenuPrincipal(0, False, True)
    End Sub
    Private Sub BtnImagem2_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImagem2.ButtonClickMasterRace
        MenuPrincipal(1, True)
        AbastecimentoVer()
        LblAbast.Font = GetInstance(12, FontStyle.Bold)
        GrpAbast.Font = GetInstance(12, FontStyle.Bold)
        GrpAbastNotas.Font = GetInstance(8, FontStyle.Bold)
    End Sub
    Private Sub BtnImagem3_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImagem3.ButtonClickMasterRace
        MenuPrincipal(2, True)
        ManutencaoVer()
        LblManu.Font = GetInstance(12, FontStyle.Bold)
        GrpManu.Font = GetInstance(12, FontStyle.Bold)
        GrpManuNota.Font = GetInstance(8, FontStyle.Bold)
    End Sub
    Private Sub BtnImagem4_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImagem4.ButtonClickMasterRace
        MenuPrincipal(3, True)
        DespesasVer()

    End Sub

    Private Sub BtnImagem5_ButtonClickMasterRace(sender As Object, e As EventArgs) Handles BtnImagem5.ButtonClickMasterRace
        MenuPrincipal(4, True)
        LstAgendaManuCarro.SelectedItems.Clear()
        AgendaVer()
        Try
            LstAgendaManuCarro.SelectedIndex = 0
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        BtnImagemAgendaManu.EstadoBotao = True
        MenuAgenda(0)

    End Sub

    Private Sub BtnImagem6_ButtonClickMasterRace(sender As Object, e As EventArgs) Handles BtnImagem6.ButtonClickMasterRace
        MenuPrincipal(5, True)
    End Sub

    Private Sub BtnImagem7_ButtonClickMasterRace(sender As Object, e As EventArgs) Handles BtnImagem7.ButtonClickMasterRace
        MenuPrincipal(6, True)
    End Sub

    Private Sub TmrSlide1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles TmrSlide1.Tick
        PnlMenu.Left = PnlMenu.Left - 2
        For a = 0 To NMenuPrincipal
            BtnImagemMenuPrincipal(a).Left = BtnImagemMenuPrincipal(a).Left + 2
        Next
        If PnlMenu.Right = 36 Then
            TmrSlide1.Enabled = False
            For a = 0 To NMenuPrincipal
                BtnImagemMenuPrincipal(a).Show()
            Next
        End If
        BtnMenu1.zEstadoBotao = True
        BtnMenu1.resetbtn()
    End Sub

    Private Sub TmrSlide2_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles TmrSlide2.Tick
        PnlMenu.Left = PnlMenu.Left + 2
        Dim a As Integer
        For a = 0 To NMenuPrincipal
            BtnImagemMenuPrincipal(a).Left = BtnImagemMenuPrincipal(a).Left - 2
        Next
        If PnlMenu.Right = 200 Then
            TmrSlide2.Enabled = False
            For a = 0 To NMenuPrincipal
                BtnImagemMenuPrincipal(a).Show()
            Next
        End If
        BtnMenu1.zEstadoBotao = False
        BtnMenu1.resetbtn()
    End Sub

    Private Sub BtnMenu1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnMenu1.Click

        If BtnImagemMenuPrincipal(0).EstadoBotao <> True Then
            BtnMenu1.resetbtn()
            For a = 0 To NMenuPrincipal
                BtnImagemMenuPrincipal(a).Hide()
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
            MenuPrincipal(0)
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
        AboutBox1.Show()
    End Sub

    Private Sub Label3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Label3.Click
        If PnlMenu.Right = 36 Then
            PnlMenu.Left = 200
            For a = 0 To NMenuPrincipal
                BtnImagemMenuPrincipal(a).Left = 0

            Next
            BtnMenu1.zEstadoBotao = False
            BtnMenu1.resetbtn()
        End If
        BtnImagem1.EstadoBotao = True
        LoadOrder.LoginPage()
        PnlLogin.Show()
        PnlHome.Hide()
        LblUtilzadorMenu.Hide()
        PnlUser.Hide()
        PnlDefUtilizador.Hide()
    End Sub


    'Menu Utilizaqdor
    Private Sub Label2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Label2.Click
        If PnlDefUtilizador.Visible = False Then
            MenuUtilizador()
            PnlDefUtilizador.Visible = True
            PnlDefUtilizador.BringToFront()
            PnlUser.Hide()
        Else
            PnlDefUtilizador.Visible = False
        End If
    End Sub


    'Editar Utilizador
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







    'SubMenus
    '
    'Definições de Utilizador
    '
    Private Sub BtnImagemDefUtilizadorInfo_ButtonClickMasterRace(ByVal sender As Object, ByVal e As EventArgs) Handles BtnImagemDefUtilizadorInfo.ButtonClickMasterRace
        MenuDefUtilizador(0)
    End Sub

    Private Sub BtnImagemDefUtilizadorContato_ButtonClickMasterRace(ByVal sender As Object, ByVal e As EventArgs) Handles BtnImagemDefUtilizadorContato.ButtonClickMasterRace
        MenuDefUtilizador(1)
    End Sub
    '
    'Agenda
    '
    Private Sub BtnImagemAgendaManu_ButtonClickMasterRace(sender As Object, e As EventArgs) Handles BtnImagemAgendaManu.ButtonClickMasterRace
        MenuAgenda(0)
    End Sub

    Private Sub BtnImagemAgendaDesp_ButtonClickMasterRace(sender As Object, e As EventArgs) Handles BtnImagemAgendaDesp.ButtonClickMasterRace
        MenuAgenda(1)
    End Sub






    Private Sub LstVAbastecimento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstVAbastecimento.Click
        DetalhesAbast(LstVAbastecimento.SelectedItems(0).Text)
    End Sub

    Private Sub LstVManu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstVManu.Click
        DetalhesManu(LstVManu.SelectedItems(0).Text)
    End Sub


    Private Sub BtnImagemInserirCancelar_ButtonClickMasterRace(sender As Object, e As EventArgs) Handles BtnImagemInserirCancelar.ButtonClickMasterRace
        Botao(BtnImagemInserirCancelar)
        TxtInserirQuilometros.Text = ""
        TxtInserirQuantidade.Text = ""
        TxtInserirValor.Text = ""
        TxtInserirNota.Text = ""
        TxtInserirQuilometros.Enabled = True
        Panel1.Hide()
    End Sub

    Private Sub BtnImagemAbastInsert_ButtonClickMasterRace(sender As Object, e As EventArgs) Handles BtnImagemAbastInsert.ButtonClickMasterRace
        Botao(BtnImagemAbastInsert)
        Panel1.Show()
        Panel1.BringToFront()
        Inserir_EditarTabelaSQL("AbastInsert")
    End Sub

    Private Sub BtnImagemAbastEdit_ButtonClickMasterRace(sender As Object, e As EventArgs) Handles BtnImagemAbastEdit.ButtonClickMasterRace
        Botao(BtnImagemAbastEdit)
        Try
            LstVAbastecimento.SelectedItems(0).Text.ToString()
        Catch ex As Exception
            MsgBox("Selecione um abastecimento")
            Exit Sub
        End Try
        Panel1.Show()
        Panel1.BringToFront()
        Inserir_EditarTabelaSQL("AbastEdit", LstVAbastecimento.SelectedItems(0).Text.ToString)

    End Sub




    Private Sub BtnImagemInserirInserir_ButtonClickMasterRace(sender As Object, e As EventArgs) Handles BtnImagemInserirInserir.ButtonClickMasterRace
        Botao(BtnImagemInserirInserir)
        If TabelaSelecionada = "AbastInsert" Then
            If CheckForAlphaCharacters(TxtInserirQuilometros.Text.ToString) Then
                MsgBox("Dados Invalidos")
                Exit Sub
            End If
            If Val(TxtInserirQuilometros.Text) <= UltimoKM() Then
                MsgBox("Quilometros não podem ser inferiores aos já registados")
                Exit Sub
            Else
                If Val(TxtInserirQuantidade.Text) = 0 Or Val(TxtInserirValor.Text) = 0 Then
                    MsgBox("Quantidade ou valor não podem ser 0")
                    Exit Sub
                Else
                    If CheckForAlphaCharacters(TxtInserirQuantidade.Text.ToString) = True Or CheckForAlphaCharacters(TxtInserirValor.Text.ToString) = True Then
                        MsgBox("Dados Invalidos")
                        Exit Sub
                    End If
                    InserirDados("Abast")
                End If
            End If
        ElseIf TabelaSelecionada = "AbastEdit" Then
            EditarDados("AbastEdit")
        End If
        AbastecimentoVer()
        Panel1.Hide()
        TxtInserirQuilometros.Enabled = True
    End Sub

    Private Sub BtnImagemManuInsert_ButtonClickMasterRace(sender As Object, e As EventArgs) Handles BtnImagemManuInsert.ButtonClickMasterRace
        Botao(BtnImagemManuInsert)
        Panel1.Show()
        Panel1.BringToFront()
        Inserir_EditarTabelaSQL("ManuInsert")
    End Sub

    Private Sub BtnImagemManuEdit_ButtonClickMasterRace(sender As Object, e As EventArgs) Handles BtnImagemManuEdit.ButtonClickMasterRace
        Botao(BtnImagemManuEdit)
        Try
            LstVManu.SelectedItems(0).Text.ToString()
        Catch ex As Exception
            MsgBox("Selecione um abastecimento")
            Exit Sub
        End Try
        'VER ORDEM DISTO
        Panel1.Show()
        Panel1.BringToFront()
        Inserir_EditarTabelaSQL("ManuEdit", LstVManu.SelectedItems(0).Text.ToString)
    End Sub

End Class
