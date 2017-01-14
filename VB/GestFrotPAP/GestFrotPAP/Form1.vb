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

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '???? modulo aparencia?
        Dim CentroEcranX As Integer = Me.Width / 2
        Dim CentroEcranY As Integer = Me.Height / 2

        BtnImagemLogin.Left = CentroEcranX - BtnImagemLogin.Width - 5
        BtnImagemRegister.Left = CentroEcranX + 5
        BtnImagemLogin.Top = CentroEcranY + BtnImagemLogin.Height
        BtnImagemRegister.Top = CentroEcranY + BtnImagemRegister.Height

        LoginPanel.Left = 0
        LoginPanel.Top = Panel2.Bottom
        LoginPanel.Height = Me.Height - Panel2.Height
        LoginPanel.Width = Me.Width

        TxtUser.Font = Fonte.GetInstance(12, FontStyle.Bold)
        TxtPwd.Font = Fonte.GetInstance(12, FontStyle.Bold)
        TxtUser.Left = CentroEcranX - (TxtUser.Width / 2)
        TxtPwd.Left = CentroEcranX - (TxtPwd.Width / 2)
        TxtUser.Top = Panel2.Bottom + 150
        TxtPwd.Top = TxtUser.Bottom + 10




        'Registar
        TxtFirstName.Font = Fonte.GetInstance(12, FontStyle.Bold)
        TxtFirstName.Left = CentroEcranX - TxtFirstName.Width - 5
        TxtFirstName.Top = Panel2.Bottom + 150
        TxtLastName.Font = Fonte.GetInstance(12, FontStyle.Bold)
        TxtLastName.Left = CentroEcranX + 5
        TxtLastName.Top = Panel2.Bottom + 150

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
        'Just to see
        TxtFirstName.Hide()
        TxtLastName.Hide()
        TxtUserReg.Hide()
        TxtEmail.Hide()
        TxtPwdReg1.Hide()
        TxtPwdReg2.Hide()





        'User
        'Ao clickar abre um menu??
        'pôr isto a refazer sempre que se dá login
        LblUserName.Text = "byp3dr0 "
        LblUserName.Font = Fonte.GetInstance(9, FontStyle.Bold)
        LblUserName.ForeColor = Color.White
        LblUserName.Top = (Panel2.Height - LblUserName.Height) / 2
        LblUserName.Left = Fechar.Right - LblUserName.Width - 20


        'MENU e Barra
        Panel1.Left = 0
        Panel1.Top = Panel2.Bottom
        Panel1.Height = Me.Height - Panel2.Height
        Panel1.Width = 200
        BtnMenu1.Left = Panel1.Right - 36
        LabelNomeProjeto.Text = "Nome Genérico 1"
        LabelNomeProjeto.Font = Fonte.GetInstance(10, FontStyle.Bold)
        LabelNomeProjeto.Top = (Panel2.Height - LabelNomeProjeto.Height) / 2
        LabelNomeProjeto.Left = 5
        'IDK yet
        Fechar.Font = Fonte.GetInstance(12, FontStyle.Bold)
        Fechar.Text = "X"
        Fechar.ForeColor = Color.White
        Fechar.Left = Panel2.Right - 25
        Fechar.Top = (Panel2.Height - Fechar.Height) / 2

        '???? automatização?
        BtnImagem(0) = BtnImagem1
        BtnImagem(1) = BtnImagem2
        BtnImagem(2) = BtnImagem3
        BtnImagem(3) = BtnImagem4
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
        Panel1.Left = Panel1.Left - 2
        If Panel1.Right = 36 Then
            TmrSlide1.Enabled = False
            BtnImagem1.Hide()
            BtnImagem2.Hide()
            BtnImagem3.Hide()
            BtnImagem4.Hide()
        End If
    End Sub

    Private Sub TmrSlide2_Tick(sender As Object, e As EventArgs) Handles TmrSlide2.Tick
        Panel1.Left = Panel1.Left + 2
        If Panel1.Right = 200 Then
            TmrSlide2.Enabled = False
            BtnImagem1.Show()
            BtnImagem2.Show()
            BtnImagem3.Show()
            BtnImagem4.Show()
        End If
    End Sub

    Private Sub BtnMenu1_Click(sender As Object, e As EventArgs) Handles BtnMenu1.Click
        If BtnMenu1.zEstadoBotao = True Then
            If Panel1.Right = 200 Then
                TmrSlide1.Enabled = True
            ElseIf Panel1.Right = 36 Then
                TmrSlide2.Enabled = True
            End If
        ElseIf BtnMenu1.zEstadoBotao = False Then
            If Panel1.Right = 200 Then
                TmrSlide1.Enabled = True
            ElseIf Panel1.Right = 36 Then
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
        LoginPanel.Hide()
        TxtPwd.Hide()
    End Sub

    Private Sub BtnImagemRegister_ButtonClickMasterRace(sender As Object, e As EventArgs) Handles BtnImagemRegister.ButtonClickMasterRace
        'Mudar txt para as de registo
        'mudar butoes registar e cancelar
        'etc
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint
        'Por o programa a mexer pelo rato
    End Sub
End Class
