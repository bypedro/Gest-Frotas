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



    Public Sub l1()
        'Menu do topo com titulo / Por aqui o butão fechar
        Form1.LabelNomeProjeto.Text = "Nome Genérico 1"
        Form1.LabelNomeProjeto.Font = Fonte.GetInstance(10, FontStyle.Bold)
        Form1.LabelNomeProjeto.Top = (Form1.PnlMenuTop.Height - Form1.LabelNomeProjeto.Height) / 2
        Form1.LabelNomeProjeto.Left = 5

        'Login
        Form1.LoginPanel.Left = 0
        Form1.LoginPanel.Top = Form1.PnlMenuTop.Bottom
        Form1.LoginPanel.Height = Form1.Height - Form1.PnlMenuTop.Height
        Form1.LoginPanel.Width = Form1.Width
        'Talvez Criar outro botão ou mudar o atual
        Form1.BtnImagemLogin.Left = CentroEcranX - Form1.BtnImagemLogin.Width - 5
        Form1.BtnImagemRegister.Left = CentroEcranX + 5
        Form1.BtnImagemLogin.Top = CentroEcranY + Form1.BtnImagemLogin.Height
        Form1.BtnImagemRegister.Top = CentroEcranY + Form1.BtnImagemRegister.Height
        Form1.TxtUser.Font = Fonte.GetInstance(12, FontStyle.Bold)
        Form1.TxtPwd.Font = Fonte.GetInstance(12, FontStyle.Bold)
        Form1.TxtUser.ForeColor = Color.White
        Form1.TxtPwd.ForeColor = Color.White
        Form1.TxtUser.Left = CentroEcranX - (Form1.TxtUser.Width / 2)
        Form1.TxtPwd.Left = CentroEcranX - (Form1.TxtPwd.Width / 2)
        Form1.TxtUser.Top = Form1.PnlMenuTop.Bottom + 150
        Form1.TxtPwd.Top = Form1.TxtUser.Bottom + 10
        SendMessage(Form1.TxtUser.Handle, &H1501, 0, "Utilizador ou Email")
        SendMessage(Form1.TxtPwd.Handle, &H1501, 0, "Password")

    End Sub

    Public Sub l2() 'Depois do Login
        'User
        'Ao clickar abre um menu??
        Form1.LblUserName.Visible = True
        Form1.LblUserName.Text = Form1.TxtUser.Text + "MUDAR" 'nome do Utilizador/ email/ idk possivelmente buscar nome e apelido á bd
        Form1.LblUserName.Font = Fonte.GetInstance(9, FontStyle.Bold)
        Form1.LblUserName.ForeColor = Color.White 'No futuro Opção para mudar?
        Form1.LblUserName.Top = (Form1.PnlMenuTop.Height - Form1.LblUserName.Height) / 2
        Form1.LblUserName.Left = Form1.Fechar.Right - Form1.LblUserName.Width - 20

        '
        'IDK
        Form1.LoginPanel.Hide()
    End Sub

End Module
