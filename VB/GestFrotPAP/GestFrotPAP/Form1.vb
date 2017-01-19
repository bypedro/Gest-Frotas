Public Class Form1
    Dim N As Integer = 3 'Nº butões
    Dim BtnImagem(N) As BtnImagem

    Private Sub check(ByVal c As Integer)
        Dim a As Integer
        For a = 0 To N
            If BtnImagem(a).zEstadoBotao = True And a <> c Then
                BtnImagem(a).zEstadoBotao = False
                BtnImagem(a).VerificarEstadoBotao()
            End If
        Next
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Fade(1) 'VEr
    End Sub
    ' VEr


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtFirstName.Hide()
        TxtLastName.Hide()
        TxtUserReg.Hide()
        TxtEmail.Hide()
        TxtPwdReg1.Hide()
        TxtPwdReg2.Hide()

        '???? modulo aparencia?   
        Dim CentroEcranX As Integer = Me.Width / 2
        Dim CentroEcranY As Integer = Me.Height / 2

        'Registar
        'Talvez outro panel?
        TxtFirstName.Font = Fonte.GetInstance(12, FontStyle.Bold)
        TxtFirstName.Left = CentroEcranX - TxtFirstName.Width - 5
        TxtFirstName.Top = PnlMenuTop.Bottom + 150
        TxtLastName.Font = Fonte.GetInstance(12, FontStyle.Bold)
        TxtLastName.Left = CentroEcranX + 5
        TxtLastName.Top = PnlMenuTop.Bottom + 150

        TxtUserReg.Font = Fonte.GetInstance(12, FontStyle.Bold)
        TxtUserReg.Left = CentroEcranX - TxtUserReg.Width - 5
        TxtUserReg.Top = TxtFirstName.Bottom + 10
        TxtEmail.Font = Fonte.GetInstance(12, FontStyle.Bold)
        TxtEmail.Left = CentroEcranX + 5
        TxtEmail.Top = TxtLastName.Bottom + 10

        TxtPwdReg1.Font = Fonte.GetInstance(12, FontStyle.Bold)
        TxtPwdReg1.Left = CentroEcranX - TxtPwdReg1.Width - 5
        TxtPwdReg1.Top = TxtUserReg.Bottom + 10
        TxtPwdReg2.Font = Fonte.GetInstance(12, FontStyle.Bold)
        TxtPwdReg2.Left = CentroEcranX + 5
        TxtPwdReg2.Top = TxtEmail.Bottom + 10








        'MENU e Barra
        PnlMenu.Left = 0
        PnlMenu.Top = PnlMenuTop.Bottom
        PnlMenu.Height = Me.Height - PnlMenuTop.Height
        PnlMenu.Width = 200
        BtnMenu1.Left = PnlMenu.Right - 36




        'IDK yet
        Fechar.Font = Fonte.GetInstance(12, FontStyle.Bold)
        Fechar.Text = "X"
        Fechar.ForeColor = Color.White
        Fechar.Left = PnlMenuTop.Right - 25
        Fechar.Top = (PnlMenuTop.Height - Fechar.Height) / 2

        '???? automatização?
        BtnImagem(0) = BtnImagem1
        BtnImagem(1) = BtnImagem2
        BtnImagem(2) = BtnImagem3
        BtnImagem(3) = BtnImagem4

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

    Private Sub TmrSlide1_Tick(sender As Object, e As EventArgs) Handles TmrSlide1.Tick
        PnlMenu.Left = PnlMenu.Left - 2
        If PnlMenu.Right = 36 Then
            TmrSlide1.Enabled = False
            BtnImagem1.Hide()
            BtnImagem2.Hide()
            BtnImagem3.Hide()
            BtnImagem4.Hide()
        End If
    End Sub

    Private Sub TmrSlide2_Tick(sender As Object, e As EventArgs) Handles TmrSlide2.Tick
        PnlMenu.Left = PnlMenu.Left + 2
        If PnlMenu.Right = 200 Then
            TmrSlide2.Enabled = False
            BtnImagem1.Show()
            BtnImagem2.Show()
            BtnImagem3.Show()
            BtnImagem4.Show()
        End If
    End Sub

    Private Sub BtnMenu1_Click(sender As Object, e As EventArgs) Handles BtnMenu1.Click
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


    Private Sub BtnImagem5_ButtonClickMasterRace(sender As Object, e As EventArgs) Handles BtnImagem5.ButtonClickMasterRace
        Close()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Fechar.Click
        Close()
    End Sub

    Private Sub BtnImagemLogin_ButtonClickMasterRace(sender As Object, e As EventArgs) Handles BtnImagemLogin.ButtonClickMasterRace
        If Login(TxtUser.Text, HashPassword(TxtPwd.Text)) = True Then
            LoadOrder.MenuPrincipalPage()
        End If
        'LoadOrder.l2()
    End Sub


    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles PnlMenuTop.Paint
        'Por o programa a mexer pelo rato
    End Sub

    Private Sub BtnImagemRegistarEntrar_ButtonClickMasterRace(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImagemRegistarEntrar.ButtonClickMasterRace
        LoadOrder.RegistarPage()
    End Sub

    Private Sub BtnImagemCancelar_ButtonClickMasterRace_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImagemCancelar.ButtonClickMasterRace
        LoadOrder.LoginPage()
        TxtFirstName.Text = ""
        TxtLastName.Text = ""
        TxtEmail.Text = ""
        TxtUserReg.Text = ""
        TxtPwdReg1.Text = ""
        TxtPwdReg2.Text = ""


    End Sub

    Private Sub BtnImagemRegistar_ButtonClickMasterRace(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImagemRegistar.ButtonClickMasterRace
        'Por codigo
        Registar(TxtUserReg.Text, TxtPwdReg1.Text, TxtPwdReg2.Text, TxtEmail.Text, "MORADA POR AQUI COISAS", TxtFirstName.Text, TxtLastName.Text)

    End Sub
End Class
