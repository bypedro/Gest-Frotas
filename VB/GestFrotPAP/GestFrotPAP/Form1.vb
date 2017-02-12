Imports System.Drawing
Imports System.Drawing.Drawing2D





Public Class Form1
    Dim N As Integer = 3 'Nº butões
    Dim BtnImagem(N) As BtnImagem
    Dim panel(N) As Panel

    Private Sub check(ByVal c As Integer)
        Dim a As Integer
        For a = 0 To N
            If BtnImagem(a).EstadoBotao = True And a <> c Then
                BtnImagem(a).EstadoBotao = False
                BtnImagem(a).VerificarEstadoBotao()
                panel(a).Hide()
            End If
            Panel(c).Show()
        Next
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












        PnlUser.Width = 200 'Ver qual a label maior?
        PnlUser.Height = Label1.Height + Label2.Height + Label3.Height + 20




        PnlUser.Hide()





        '???? modulo aparencia?   
        Dim CentroEcranX As Integer = Me.Width / 2
        Dim CentroEcranY As Integer = Me.Height / 2






        




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
        check(0)
    End Sub
    Private Sub BtnImagem2_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImagem2.ButtonClickMasterRace
        check(1)
    End Sub
    Private Sub BtnImagem3_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImagem3.ButtonClickMasterRace
        check(2)
    End Sub
    Private Sub BtnImagem4_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImagem4.ButtonClickMasterRace
        check(3)
    End Sub

    Private Sub TmrSlide1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles TmrSlide1.Tick
        PnlMenu.Left = PnlMenu.Left - 2
        If PnlMenu.Right = 36 Then
            TmrSlide1.Enabled = False
            BtnImagem1.Hide()
            BtnImagem2.Hide()
            BtnImagem3.Hide()
            BtnImagem4.Hide()
        End If
    End Sub

    Private Sub TmrSlide2_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles TmrSlide2.Tick
        PnlMenu.Left = PnlMenu.Left + 2
        If PnlMenu.Right = 200 Then
            TmrSlide2.Enabled = False
            BtnImagem1.Show()
            BtnImagem2.Show()
            BtnImagem3.Show()
            BtnImagem4.Show()
        End If
    End Sub

    Private Sub BtnMenu1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnMenu1.Click
        If BtnMenu1.zEstadoBotao = True Then
            If PnlMenu.Right = 200 Then
                TmrSlide1.Enabled = True
            ElseIf PnlMenu.Right = 36 Then
                TmrSlide2.Enabled = True
            End If
        ElseIf BtnMenu1.zEstadoBotao = False Then
            If PnlMenu.Right = 200 Then
                TmrSlide1.Enabled = True
            ElseIf PnlMenu.Right = 36 Then
                TmrSlide2.Enabled = True
            End If
        End If
    End Sub


    Private Sub BtnImagem5_ButtonClickMasterRace(ByVal sender As Object, ByVal e As EventArgs)
        Close()
    End Sub

    Private Sub Label2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Fechar.Click
        Close()
    End Sub

    Private Sub BtnImagemLogin_ButtonClickMasterRace(ByVal sender As Object, ByVal e As EventArgs) Handles BtnImagemLogin.ButtonClickMasterRace
        If Login(TxtUser.Text, HashPassword(TxtPwd.Text)) = True Then
            LoadOrder.MenuPrincipalPage()
            check(0)
        Else

        End If
        


        PnlUser.Left = LblUtilzadorMenu.Left
        PnlUser.Top = LblUtilzadorMenu.Bottom + 7
        PnlUser.Width = 90
        PnlUser.BringToFront()
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

    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PnlBarraTop.MouseMove
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub


    Private Sub Panel2_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PnlBarraTop.MouseUp
        drag = False
    End Sub


    Private Sub BtnImagemRegistarEntrar_ButtonClickMasterRace(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImagemRegistarEntrar.ButtonClickMasterRace
        LoadOrder.RegistarPage()
    End Sub

    Private Sub BtnImagemCancelar_ButtonClickMasterRace_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImagemCancelar.ButtonClickMasterRace
        LoadOrder.LoginPage()
        TxtEmail.Text = ""
        TxtUserReg.Text = ""
        TxtPwdReg1.Text = ""
        TxtPwdReg2.Text = ""
        LblEmailReg.Hide()
        LblPasswordReg.Hide()
        LblUtilizadorReg.Hide()


    End Sub

    Private Sub BtnImagemRegistar_ButtonClickMasterRace(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImagemRegistar.ButtonClickMasterRace
        'Por codigo
        If Registar(TxtUserReg.Text, TxtPwdReg1.Text, TxtPwdReg2.Text, TxtEmail.Text) = True Then
            MsgBox("INSERIDO COM SUCESSO")
        End If

    End Sub

    Private Sub LblUserName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblUtilzadorMenu.Click
        PnlUser.BringToFront()
        Label1.Top = (PnlUser.Height - PnlUser.Height)
        Label1.Left = (PnlUser.Width - PnlUser.Width) / 2 + 2

        Label2.Top = (PnlUser.Height - PnlUser.Height) + Label2.Height
        Label2.Left = (PnlUser.Width - PnlUser.Width) / 2 + 2

        Label3.Top = (PnlUser.Height - PnlUser.Height) + Label2.Height + Label3.Height
        Label3.Left = (PnlUser.Width - PnlUser.Width) / 2 + 2

        PnlUser.Height = (PnlUser.Height - PnlUser.Height) + Label1.Height + Label2.Height + Label3.Height

        If PnlUser.Visible = True Then
            PnlUser.Hide()
        Else
            PnlUser.Show()
        End If

    End Sub

    Private Sub LblUserName_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblUtilzadorMenu.MouseEnter
        LblUtilzadorMenu.ForeColor = Color.White 'No futuro Opção para mudar?
    End Sub

    Private Sub LblUserName_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblUtilzadorMenu.MouseLeave
        LblUtilzadorMenu.ForeColor = Color.DarkGray 'No futuro Opção para mudar?
    End Sub

    Private Sub PnlMenu_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PnlMenu.Paint

    End Sub

    Private Sub TxtEmail_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtEmail.TextChanged

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        MsgBox("LOL")
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        LoadOrder.LoginPage()
        LoginPanel.Show()
        PnlHome.Hide()
        LblUtilzadorMenu.Hide()
        PnlUser.Hide()

    End Sub

    Private Sub LoginPanel_Paint(sender As Object, e As PaintEventArgs) Handles LoginPanel.Paint

    End Sub
End Class
