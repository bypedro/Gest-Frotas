Imports System.Runtime.InteropServices
Public Module LoadOrder
    Private CentroEcranX As Integer = Form1.Width / 2
    Private CentroEcranY As Integer = Form1.Height / 2

    <DllImport("user32.dll", CharSet:=CharSet.Auto)> _
    Public Function SendMessage(ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wParam As Integer, <MarshalAs(UnmanagedType.LPWStr)> ByVal lParam As String) As Int32
    End Function

    Public Sub Fade(ByVal Tipo As Integer) ' 0 para entrar 1 para sair Por em outro sitio? 
        Dim fade As Double
        If Tipo = 0 Then
            For fade = 0.0 To 1.1 Step 0.2
                Form1.Opacity = fade
                Form1.Refresh()
                Threading.Thread.Sleep(50)

            Next
        ElseIf Tipo = 1 Then
            For fade = 1.1 To 0.0 Step -0.3
                Form1.Opacity = fade
                Form1.Refresh()
                Threading.Thread.Sleep(50)
            Next
        End If

    End Sub



    Public Sub LoginPage()
        'MENU
        Form1.PnlMenu.Left = 0
        Form1.PnlMenu.Top = Form1.PnlBarraTop.Bottom
        Form1.PnlMenu.Height = Form1.Height - Form1.PnlBarraTop.Height
        Form1.PnlMenu.Width = 200
        Form1.BtnMenu1.Left = Form1.PnlMenu.Right - 35

        'Barra do topo com titulo / Por aqui o butão fechar
        Form1.LblNomeProjeto.Text = "VecXP"
        Form1.LblNomeProjeto.ForeColor = Color.White
        Form1.LblNomeProjeto.Font = Fonte.GetInstance(10, FontStyle.Bold)
        Form1.LblNomeProjeto.Top = (Form1.PnlBarraTop.Height - Form1.LblNomeProjeto.Height) / 2
        Form1.LblNomeProjeto.Left = 5

        'Login

        Form1.PnlLogin.Left = 0
        Form1.PnlLogin.Top = Form1.PnlBarraTop.Bottom
        Form1.PnlLogin.Height = Form1.Height - Form1.PnlBarraTop.Height
        Form1.PnlLogin.Width = Form1.Width

        'Talvez Criar outro botão ou mudar o atual
        Form1.BtnImagemLogin.Left = CentroEcranX - Form1.BtnImagemLogin.Width - 5
        Form1.BtnImagemRegistarEntrar.Left = CentroEcranX + 5
        Form1.BtnImagemLogin.Top = CentroEcranY + Form1.BtnImagemLogin.Height
        Form1.BtnImagemRegistarEntrar.Top = CentroEcranY + Form1.BtnImagemRegistarEntrar.Height

        Form1.TxtUserLogin.Font = Fonte.GetInstance(12, FontStyle.Bold)
        Form1.TxtPwdLogin.Font = Fonte.GetInstance(12, FontStyle.Bold)
        Form1.TxtUserLogin.ForeColor = Color.White
        Form1.TxtPwdLogin.ForeColor = Color.White



        Form1.TxtUserLogin.Left = CentroEcranX - (Form1.TxtUserLogin.Width / 2)
        Form1.TxtPwdLogin.Left = CentroEcranX - (Form1.TxtPwdLogin.Width / 2)
        Form1.TxtUserLogin.Top = Form1.PnlBarraTop.Bottom + 150
        Form1.TxtPwdLogin.Top = Form1.TxtUserLogin.Bottom + 12
        SendMessage(Form1.TxtUserLogin.Handle, &H1501, 0, "Utilizador ou Email")
        SendMessage(Form1.TxtPwdLogin.Handle, &H1501, 0, "Password")

        Form1.LblUtilizadorLogin.Left = Form1.TxtUserLogin.Left
        Form1.LblPasswordLogin.Left = Form1.TxtPwdLogin.Left
        Form1.LblUtilizadorLogin.Top = Form1.TxtUserLogin.Bottom
        Form1.LblPasswordLogin.Top = Form1.TxtPwdLogin.Bottom
        Form1.LblUtilizadorLogin.ForeColor = Color.Red
        Form1.LblPasswordLogin.ForeColor = Color.Red
        Form1.LblUtilizadorLogin.Hide()
        Form1.LblPasswordLogin.Hide()


        Form1.TxtEmailReg.ForeColor = Color.White
        Form1.TxtUserReg.ForeColor = Color.White
        Form1.TxtPwdReg1.ForeColor = Color.White
        Form1.TxtPwdReg2.ForeColor = Color.White

        SendMessage(Form1.TxtEmailReg.Handle, &H1501, 0, "Email")
        SendMessage(Form1.TxtPwdReg1.Handle, &H1501, 0, "Password")
        SendMessage(Form1.TxtPwdReg2.Handle, &H1501, 0, "Repetir Password")
        SendMessage(Form1.TxtUserReg.Handle, &H1501, 0, "Utilizador")

        'Registar
        'Talvez outro panel?



        Form1.TxtUserReg.Font = Fonte.GetInstance(12, FontStyle.Bold)
        Form1.TxtUserReg.Left = CentroEcranX - Form1.TxtUserReg.Width - 5
        Form1.TxtUserReg.Top = Form1.PnlBarraTop.Bottom + 150
        Form1.TxtEmailReg.Font = Fonte.GetInstance(12, FontStyle.Bold)
        Form1.TxtEmailReg.Left = CentroEcranX + 5
        Form1.TxtEmailReg.Top = Form1.PnlBarraTop.Bottom + 150


        Form1.TxtPwdReg1.Font = Fonte.GetInstance(12, FontStyle.Bold)
        Form1.TxtPwdReg1.Left = CentroEcranX - Form1.TxtPwdReg1.Width - 5
        Form1.TxtPwdReg1.Top = Form1.TxtUserReg.Bottom + 12
        Form1.TxtPwdReg2.Font = Fonte.GetInstance(12, FontStyle.Bold)
        Form1.TxtPwdReg2.Left = CentroEcranX + 5
        Form1.TxtPwdReg2.Top = Form1.TxtEmailReg.Bottom + 12


        Form1.LblUtilizadorReg.ForeColor = Color.Red
        Form1.LblUtilizadorReg.Left = Form1.TxtUserReg.Left
        Form1.LblUtilizadorReg.Top = Form1.TxtUserReg.Bottom

        Form1.LblPasswordReg.ForeColor = Color.Red
        Form1.LblPasswordReg.Left = Form1.TxtPwdReg1.Left
        Form1.LblPasswordReg.Top = Form1.TxtPwdReg1.Bottom
        Form1.LblEmailReg.ForeColor = Color.Red
        Form1.LblEmailReg.Left = Form1.TxtEmailReg.Left
        Form1.LblEmailReg.Top = Form1.TxtEmailReg.Bottom
        Form1.LblUtilizadorReg.Hide()
        Form1.LblPasswordReg.Hide()
        Form1.LblEmailReg.Hide()

        Form1.BtnImagemCancelar.Hide()
        Form1.BtnImagemRegistar.Hide()
        Form1.TxtEmailReg.Hide()
        Form1.TxtPwdReg1.Hide()
        Form1.TxtPwdReg2.Hide()
        Form1.TxtUserReg.Hide()
        Form1.LblEmailReg.Hide()
        Form1.LblPasswordReg.Hide()
        Form1.LblUtilizadorReg.Hide()

        Form1.TxtUserLogin.Show()
        Form1.TxtPwdLogin.Show()


    End Sub



    Public Sub MenuPrincipalPage() 'Depois do Login
        'Utilizador(Label)
        'Esconde Pagina de Login
        Form1.PnlLogin.Hide()

        'Mostra Pagina Principal
        Form1.PnlHome.Show()

        'Paginas
        Form1.PnlHome.Left = Form1.PnlMenu.Right
        Form1.PnlHome.Top = Form1.PnlBarraTop.Bottom
        Form1.PnlHome.Width = Form1.Width - Form1.PnlMenu.Width
        Form1.PnlHome.Height = Form1.Height - Form1.PnlBarraTop.Height

        Form1.Panel2.Left = Form1.PnlMenu.Right - 164
        Form1.Panel2.Top = Form1.PnlBarraTop.Bottom
        Form1.Panel2.Width = Form1.Width - Form1.PnlMenu.Width + 164
        Form1.Panel2.Height = Form1.Height - Form1.PnlBarraTop.Height
        Form1.Panel2.SendToBack()

        Form1.Panel3.Left = Form1.PnlMenu.Right - 164
        Form1.Panel3.Top = Form1.PnlBarraTop.Bottom
        Form1.Panel3.Width = Form1.Width - Form1.PnlMenu.Width + 164
        Form1.Panel3.Height = Form1.Height - Form1.PnlBarraTop.Height
        Form1.Panel3.SendToBack()

        Form1.Panel4.Left = Form1.PnlMenu.Right - 164
        Form1.Panel4.Top = Form1.PnlBarraTop.Bottom
        Form1.Panel4.Width = Form1.Width - Form1.PnlMenu.Width + 164
        Form1.Panel4.Height = Form1.Height - Form1.PnlBarraTop.Height
        Form1.Panel4.SendToBack()


        'IDK
        Form1.PnlLogin.Hide()

        'Menu Utilizador
        Form1.LblUtilzadorMenu.Text = DetalhesUtilizador.NomeRegisto 'Form1.TxtUser.Text + "MUDAR" 'nome do Utilizador/ email/ idk possivelmente buscar nome e apelido á bd
        Form1.LblUtilzadorMenu.Visible = True
        Form1.LblUtilzadorMenu.Font = Fonte.GetInstance(9, FontStyle.Bold)
        Form1.LblUtilzadorMenu.ForeColor = Color.DarkGray 'No futuro Opção para mudar?
        Form1.LblUtilzadorMenu.Top = (Form1.PnlBarraTop.Height - Form1.LblUtilzadorMenu.Height) / 2
        Form1.LblUtilzadorMenu.Left = Form1.Fechar.Right - Form1.LblUtilzadorMenu.Width - 20
        Form1.Label1.Top = (Form1.PnlUser.Height - Form1.PnlUser.Height)
        Form1.Label1.Left = (Form1.PnlUser.Width - Form1.PnlUser.Width) / 2 + 2
        Form1.Label2.Top = (Form1.PnlUser.Height - Form1.PnlUser.Height) + Form1.Label2.Height
        Form1.Label2.Left = (Form1.PnlUser.Width - Form1.PnlUser.Width) / 2 + 2
        Form1.Label3.Top = (Form1.PnlUser.Height - Form1.PnlUser.Height) + Form1.Label2.Height + Form1.Label3.Height
        Form1.Label3.Left = (Form1.PnlUser.Width - Form1.PnlUser.Width) / 2 + 2
        Form1.PnlUser.Height = (Form1.PnlUser.Height - Form1.PnlUser.Height) + Form1.Label1.Height + Form1.Label2.Height + Form1.Label3.Height
        Form1.PnlUser.Left = Form1.LblUtilzadorMenu.Left - Form1.PnlUser.Width + Form1.LblUtilzadorMenu.Width
        Form1.PnlUser.Top = Form1.LblUtilzadorMenu.Bottom + 7
        Form1.PnlUser.Width = 200 'Ver qual a label maior?
        Form1.PnlUser.Height = Form1.Label1.Height + Form1.Label2.Height + Form1.Label3.Height
        Form1.PnlUser.Width = 90



        'Panel utilizador
        Form1.PnlDefUtilizador.Left = 0
        Form1.PnlDefUtilizador.Top = Form1.PnlBarraTop.Bottom
        Form1.PnlDefUtilizador.Height = Form1.Height - Form1.PnlBarraTop.Height
        Form1.PnlDefUtilizador.Width = Form1.Width


    End Sub

    Public Sub RegistarPage()
        Form1.TxtUserReg.Show()
        Form1.TxtEmailReg.Show()
        Form1.TxtPwdReg1.Show()
        Form1.TxtPwdReg2.Show()
        Form1.TxtUserLogin.Hide()
        Form1.TxtPwdLogin.Hide()
        Form1.LblUtilizadorLogin.Hide()
        Form1.LblPasswordLogin.Hide()
        Form1.BtnImagemCancelar.Show()
        Form1.BtnImagemRegistar.Show()

        Form1.BtnImagemRegistar.Left = CentroEcranX - Form1.BtnImagemRegistar.Width - 5
        Form1.BtnImagemCancelar.Left = CentroEcranX + 5
        Form1.BtnImagemRegistar.Top = CentroEcranY + Form1.BtnImagemRegistar.Height
        Form1.BtnImagemCancelar.Top = CentroEcranY + Form1.BtnImagemCancelar.Height



        'Mudar txt para as de registo
        'mudar butoes registar e cancelar
        'etc
    End Sub

    Public Sub MenuUtilizador()
        'Informação Utilizador
        'Fonte
        Form1.LblUtilizadorUserDef.Font = GetInstance(10, FontStyle.Bold)
        Form1.LblUtilizadorNomePDef.Font = GetInstance(10, FontStyle.Bold)
        Form1.LblUtilizadorApelidoDef.Font = GetInstance(10, FontStyle.Bold)
        Form1.LblUtilizadorDataNascDef.Font = GetInstance(10, FontStyle.Bold)
        Form1.LblUtilizadorDataContratDef.Font = GetInstance(10, FontStyle.Bold)
        Form1.LblUtilizadorHabilitacoesDef.Font = GetInstance(10, FontStyle.Bold)
        Form1.LblUtilizadorNotasDef.Font = GetInstance(10, FontStyle.Bold)
        Form1.LblUtilizadorPagmentoDef.Font = GetInstance(10, FontStyle.Bold)
        Form1.LblUtilizadorGeneroDef.Font = GetInstance(10, FontStyle.Bold)

        Form1.TxtUtilizadorUserDef.Font = GetInstance(10, FontStyle.Bold)
        Form1.TxtUtilizadorNomePDef.Font = GetInstance(10, FontStyle.Bold)
        Form1.TxtUtilizadorApelidoDef.Font = GetInstance(10, FontStyle.Bold)
        Form1.TxtUtilizadorDataNascDef.Font = GetInstance(10, FontStyle.Bold)
        Form1.TxtUtilizadorDataContratDef.Font = GetInstance(10, FontStyle.Bold)
        Form1.TxtUtilizadorHabilitacoesDef.Font = GetInstance(10, FontStyle.Bold)
        Form1.TxtUtilizadorNotasDef.Font = GetInstance(10, FontStyle.Bold)
        Form1.TxtUtilizadorPagmentoDef.Font = GetInstance(10, FontStyle.Bold)
        Form1.TxtUtilizadorGeneroDef.Font = GetInstance(10, FontStyle.Bold)

        'Cor

        Form1.LblUtilizadorUserDef.ForeColor = Color.White
        Form1.LblUtilizadorNomePDef.ForeColor = Color.White
        Form1.LblUtilizadorApelidoDef.ForeColor = Color.White
        Form1.LblUtilizadorDataNascDef.ForeColor = Color.White
        Form1.LblUtilizadorDataContratDef.ForeColor = Color.White
        Form1.LblUtilizadorHabilitacoesDef.ForeColor = Color.White
        Form1.LblUtilizadorNotasDef.ForeColor = Color.White
        Form1.LblUtilizadorPagmentoDef.ForeColor = Color.White
        Form1.LblUtilizadorGeneroDef.ForeColor = Color.White

        Form1.TxtUtilizadorUserDef.ForeColor = Color.White
        Form1.TxtUtilizadorNomePDef.ForeColor = Color.White
        Form1.TxtUtilizadorApelidoDef.ForeColor = Color.White
        Form1.TxtUtilizadorDataNascDef.ForeColor = Color.White
        Form1.TxtUtilizadorDataContratDef.ForeColor = Color.White
        Form1.TxtUtilizadorHabilitacoesDef.ForeColor = Color.White
        Form1.TxtUtilizadorNotasDef.ForeColor = Color.White
        Form1.TxtUtilizadorPagmentoDef.ForeColor = Color.White
        Form1.TxtUtilizadorGeneroDef.ForeColor = Color.White

        'Lado Esquerdo
        Form1.LblUtilizadorUserDef.Left = Form1.PnlDefUtilizadorInfo.Left + 10
        Form1.LblUtilizadorNomePDef.Left = Form1.PnlDefUtilizadorInfo.Left + 10
        Form1.LblUtilizadorApelidoDef.Left = Form1.PnlDefUtilizadorInfo.Left + 10
        Form1.LblUtilizadorDataNascDef.Left = Form1.PnlDefUtilizadorInfo.Left + 10

        Form1.LblUtilizadorUserDef.Top = 5
        Form1.LblUtilizadorNomePDef.Top = Form1.LblUtilizadorUserDef.Bottom + 5
        Form1.LblUtilizadorApelidoDef.Top = Form1.LblUtilizadorNomePDef.Bottom + 5
        Form1.LblUtilizadorDataNascDef.Top = Form1.LblUtilizadorApelidoDef.Bottom + 5

        Form1.TxtUtilizadorUserDef.Left = Form1.LblUtilizadorDataNascDef.Right + 10
        Form1.TxtUtilizadorNomePDef.Left = Form1.LblUtilizadorDataNascDef.Right + 10
        Form1.TxtUtilizadorApelidoDef.Left = Form1.LblUtilizadorDataNascDef.Right + 10
        Form1.TxtUtilizadorDataNascDef.Left = Form1.LblUtilizadorDataNascDef.Right + 10

        Form1.TxtUtilizadorUserDef.Top = 5
        Form1.TxtUtilizadorNomePDef.Top = Form1.LblUtilizadorUserDef.Bottom + 5
        Form1.TxtUtilizadorApelidoDef.Top = Form1.LblUtilizadorNomePDef.Bottom + 5
        Form1.TxtUtilizadorDataNascDef.Top = Form1.LblUtilizadorApelidoDef.Bottom + 5

        'Lado Direito
        Form1.LblUtilizadorGeneroDef.Left = Form1.TxtUtilizadorUserDef.Right + 10
        Form1.LblUtilizadorDataContratDef.Left = Form1.TxtUtilizadorUserDef.Right + 10
        Form1.LblUtilizadorPagmentoDef.Left = Form1.TxtUtilizadorUserDef.Right + 10

        Form1.LblUtilizadorDataContratDef.Top = 5
        Form1.LblUtilizadorPagmentoDef.Top = Form1.LblUtilizadorDataContratDef.Bottom + 5
        Form1.LblUtilizadorGeneroDef.Top = Form1.LblUtilizadorPagmentoDef.Bottom + 5

        Form1.TxtUtilizadorDataContratDef.Left = Form1.LblUtilizadorDataContratDef.Right + 10
        Form1.TxtUtilizadorPagmentoDef.Left = Form1.LblUtilizadorDataContratDef.Right + 10
        Form1.TxtUtilizadorGeneroDef.Left = Form1.LblUtilizadorDataContratDef.Right + 10

        Form1.TxtUtilizadorDataContratDef.Top = 5
        Form1.TxtUtilizadorPagmentoDef.Top = Form1.TxtUtilizadorDataContratDef.Bottom + 5
        Form1.TxtUtilizadorGeneroDef.Top = Form1.TxtUtilizadorPagmentoDef.Bottom + 5


        'Notas
        Form1.LblUtilizadorHabilitacoesDef.Left = Form1.PnlDefUtilizadorInfo.Left + 10
        Form1.LblUtilizadorHabilitacoesDef.Top = Form1.TxtUtilizadorDataNascDef.Bottom + 25

        Form1.TxtUtilizadorHabilitacoesDef.Left = Form1.PnlDefUtilizadorInfo.Left + 10
        Form1.TxtUtilizadorHabilitacoesDef.Top = Form1.LblUtilizadorHabilitacoesDef.Bottom + 5

        Form1.LblUtilizadorNotasDef.Left = Form1.TxtUtilizadorHabilitacoesDef.Right + 10
        Form1.LblUtilizadorNotasDef.Top = Form1.TxtUtilizadorDataNascDef.Bottom + 25

        Form1.TxtUtilizadorNotasDef.Left = Form1.TxtUtilizadorHabilitacoesDef.Right + 10
        Form1.TxtUtilizadorNotasDef.Top = Form1.LblUtilizadorNotasDef.Bottom + 5

        'Contato Utilizador
        'Fonte
        Form1.LblEmailUserCon.Font = GetInstance(10, FontStyle.Bold)
        Form1.LblTelemovelUserCon.Font = GetInstance(10, FontStyle.Bold)
        Form1.LblTelefoneUserCon.Font = GetInstance(10, FontStyle.Bold)
        Form1.LblPaisUserCon.Font = GetInstance(10, FontStyle.Bold)
        Form1.LblCidadeUserCon.Font = GetInstance(10, FontStyle.Bold)
        Form1.LblRuaUserCon.Font = GetInstance(10, FontStyle.Bold)
        Form1.LblNotasUserCon.Font = GetInstance(10, FontStyle.Bold)

        Form1.TxtEmailUserCon.Font = GetInstance(10, FontStyle.Bold)
        Form1.TxtTelemovelUserCon.Font = GetInstance(10, FontStyle.Bold)
        Form1.TxtTelefoneUserCon.Font = GetInstance(10, FontStyle.Bold)
        Form1.TxtPaisUserCon.Font = GetInstance(10, FontStyle.Bold)
        Form1.TxtCidadeUserCon.Font = GetInstance(10, FontStyle.Bold)
        Form1.TxtRuaUserCon.Font = GetInstance(10, FontStyle.Bold)
        Form1.TxtNotasUserCon.Font = GetInstance(10, FontStyle.Bold)

        'Cor
        Form1.LblEmailUserCon.ForeColor = Color.White
        Form1.LblTelemovelUserCon.ForeColor = Color.White
        Form1.LblTelefoneUserCon.ForeColor = Color.White
        Form1.LblPaisUserCon.ForeColor = Color.White
        Form1.LblCidadeUserCon.ForeColor = Color.White
        Form1.LblRuaUserCon.ForeColor = Color.White
        Form1.LblNotasUserCon.ForeColor = Color.White

        Form1.TxtEmailUserCon.ForeColor = Color.White
        Form1.TxtTelemovelUserCon.ForeColor = Color.White
        Form1.TxtTelefoneUserCon.ForeColor = Color.White
        Form1.TxtPaisUserCon.ForeColor = Color.White
        Form1.TxtCidadeUserCon.ForeColor = Color.White
        Form1.TxtRuaUserCon.ForeColor = Color.White
        Form1.TxtNotasUserCon.ForeColor = Color.White

        'Lado Esquerdo
        Form1.LblEmailUserCon.Left = Form1.PnlDefUtilizadorContato.Left + 10
        Form1.LblTelemovelUserCon.Left = Form1.PnlDefUtilizadorContato.Left + 10
        Form1.LblTelefoneUserCon.Left = Form1.PnlDefUtilizadorContato.Left + 10

        Form1.LblEmailUserCon.Top = 5
        Form1.LblTelemovelUserCon.Top = Form1.LblUtilizadorUserDef.Bottom + 5
        Form1.LblTelefoneUserCon.Top = Form1.LblUtilizadorNomePDef.Bottom + 5

        Form1.TxtEmailUserCon.Left = Form1.LblTelemovelUserCon.Right + 10
        Form1.TxtTelemovelUserCon.Left = Form1.LblTelemovelUserCon.Right + 10
        Form1.TxtTelefoneUserCon.Left = Form1.LblTelemovelUserCon.Right + 10

        Form1.TxtEmailUserCon.Top = 5
        Form1.TxtTelemovelUserCon.Top = Form1.LblUtilizadorUserDef.Bottom + 5
        Form1.TxtTelefoneUserCon.Top = Form1.LblUtilizadorNomePDef.Bottom + 5

        'Lado Direito
        Form1.LblUtilizadorGeneroDef.Left = Form1.TxtUtilizadorUserDef.Right + 10
        Form1.LblUtilizadorDataContratDef.Left = Form1.TxtUtilizadorUserDef.Right + 10
        Form1.LblUtilizadorPagmentoDef.Left = Form1.TxtUtilizadorUserDef.Right + 10

        Form1.LblUtilizadorDataContratDef.Top = 5
        Form1.LblUtilizadorPagmentoDef.Top = Form1.LblUtilizadorDataContratDef.Bottom + 5
        Form1.LblUtilizadorGeneroDef.Top = Form1.LblUtilizadorPagmentoDef.Bottom + 5

        Form1.TxtUtilizadorDataContratDef.Left = Form1.LblUtilizadorDataContratDef.Right + 10
        Form1.TxtUtilizadorPagmentoDef.Left = Form1.LblUtilizadorDataContratDef.Right + 10
        Form1.TxtUtilizadorGeneroDef.Left = Form1.LblUtilizadorDataContratDef.Right + 10

        Form1.TxtUtilizadorDataContratDef.Top = 5
        Form1.TxtUtilizadorPagmentoDef.Top = Form1.TxtUtilizadorDataContratDef.Bottom + 5
        Form1.TxtUtilizadorGeneroDef.Top = Form1.TxtUtilizadorPagmentoDef.Bottom + 5


        '
        Form1.LblUtilizadorHabilitacoesDef.Left = Form1.PnlDefUtilizadorInfo.Left + 10
        Form1.LblUtilizadorHabilitacoesDef.Top = Form1.TxtUtilizadorDataNascDef.Bottom + 25

        Form1.TxtUtilizadorHabilitacoesDef.Left = Form1.PnlDefUtilizadorInfo.Left + 10
        Form1.TxtUtilizadorHabilitacoesDef.Top = Form1.LblUtilizadorHabilitacoesDef.Bottom + 5

        Form1.LblUtilizadorNotasDef.Left = Form1.TxtUtilizadorHabilitacoesDef.Right + 10
        Form1.LblUtilizadorNotasDef.Top = Form1.TxtUtilizadorDataNascDef.Bottom + 25

        Form1.TxtUtilizadorNotasDef.Left = Form1.TxtUtilizadorHabilitacoesDef.Right + 10
        Form1.TxtUtilizadorNotasDef.Top = Form1.LblUtilizadorNotasDef.Bottom + 5




        'DADOS Utilizador
        Form1.TxtUtilizadorUserDef.Text = DetalhesUtilizador.NomeRegisto
        Form1.TxtUtilizadorNomePDef.Text = DetalhesUtilizador.NomeProprio
        Form1.TxtUtilizadorApelidoDef.Text = DetalhesUtilizador.Apelido
        Form1.TxtUtilizadorDataNascDef.Text = DetalhesUtilizador.DataNasc
        Form1.TxtUtilizadorDataContratDef.Text = DetalhesUtilizador.DataContrat
        Form1.TxtUtilizadorHabilitacoesDef.Text = DetalhesUtilizador.Habilitações
        Form1.TxtUtilizadorNotasDef.Text = DetalhesUtilizador.NotasContrato
        Form1.TxtUtilizadorPagmentoDef.Text = DetalhesUtilizador.PagamentoHora
        Form1.TxtUtilizadorGeneroDef.Text = DetalhesUtilizador.Genero

    End Sub

End Module
