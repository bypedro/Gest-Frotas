<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.PnlMenu = New System.Windows.Forms.Panel()
        Me.TmrSlide1 = New System.Windows.Forms.Timer(Me.components)
        Me.TmrSlide2 = New System.Windows.Forms.Timer(Me.components)
        Me.PnlMenuTop = New System.Windows.Forms.Panel()
        Me.LblUserName = New System.Windows.Forms.Label()
        Me.Fechar = New System.Windows.Forms.Label()
        Me.LabelNomeProjeto = New System.Windows.Forms.Label()
        Me.LoginPanel = New System.Windows.Forms.Panel()
        Me.TxtPwdReg2 = New System.Windows.Forms.TextBox()
        Me.TxtPwdReg1 = New System.Windows.Forms.TextBox()
        Me.TxtEmail = New System.Windows.Forms.TextBox()
        Me.TxtUserReg = New System.Windows.Forms.TextBox()
        Me.TxtFirstName = New System.Windows.Forms.TextBox()
        Me.TxtLastName = New System.Windows.Forms.TextBox()
        Me.TxtPwd = New System.Windows.Forms.TextBox()
        Me.TxtUser = New System.Windows.Forms.TextBox()
        Me.BtnImagemRegister = New GestFrotPAP.BtnImagem()
        Me.BtnImagemLogin = New GestFrotPAP.BtnImagem()
        Me.BtnMenu1 = New GestFrotPAP.BtnMenu()
        Me.BtnImagem1 = New GestFrotPAP.BtnImagem()
        Me.BtnImagem2 = New GestFrotPAP.BtnImagem()
        Me.BtnImagem4 = New GestFrotPAP.BtnImagem()
        Me.BtnImagem3 = New GestFrotPAP.BtnImagem()
        Me.BtnImagem5 = New GestFrotPAP.BtnImagem()
        Me.PnlMenu.SuspendLayout()
        Me.PnlMenuTop.SuspendLayout()
        Me.LoginPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlMenu
        '
        Me.PnlMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(39, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.PnlMenu.Controls.Add(Me.BtnMenu1)
        Me.PnlMenu.Controls.Add(Me.BtnImagem1)
        Me.PnlMenu.Controls.Add(Me.BtnImagem2)
        Me.PnlMenu.Controls.Add(Me.BtnImagem4)
        Me.PnlMenu.Controls.Add(Me.BtnImagem3)
        Me.PnlMenu.Location = New System.Drawing.Point(0, 24)
        Me.PnlMenu.Name = "PnlMenu"
        Me.PnlMenu.Size = New System.Drawing.Size(82, 476)
        Me.PnlMenu.TabIndex = 5
        '
        'TmrSlide1
        '
        Me.TmrSlide1.Interval = 10
        '
        'TmrSlide2
        '
        Me.TmrSlide2.Interval = 10
        '
        'PnlMenuTop
        '
        Me.PnlMenuTop.BackColor = System.Drawing.Color.SlateGray
        Me.PnlMenuTop.Controls.Add(Me.LblUserName)
        Me.PnlMenuTop.Controls.Add(Me.Fechar)
        Me.PnlMenuTop.Controls.Add(Me.LabelNomeProjeto)
        Me.PnlMenuTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlMenuTop.Location = New System.Drawing.Point(0, 0)
        Me.PnlMenuTop.Name = "PnlMenuTop"
        Me.PnlMenuTop.Size = New System.Drawing.Size(1000, 30)
        Me.PnlMenuTop.TabIndex = 6
        '
        'LblUserName
        '
        Me.LblUserName.AutoSize = True
        Me.LblUserName.Location = New System.Drawing.Point(854, 8)
        Me.LblUserName.Name = "LblUserName"
        Me.LblUserName.Size = New System.Drawing.Size(39, 13)
        Me.LblUserName.TabIndex = 2
        Me.LblUserName.Text = "Label3"
        Me.LblUserName.Visible = False
        '
        'Fechar
        '
        Me.Fechar.AutoSize = True
        Me.Fechar.Location = New System.Drawing.Point(949, 8)
        Me.Fechar.Name = "Fechar"
        Me.Fechar.Size = New System.Drawing.Size(39, 13)
        Me.Fechar.TabIndex = 1
        Me.Fechar.Text = "Label2"
        '
        'LabelNomeProjeto
        '
        Me.LabelNomeProjeto.AutoSize = True
        Me.LabelNomeProjeto.Location = New System.Drawing.Point(12, 8)
        Me.LabelNomeProjeto.Name = "LabelNomeProjeto"
        Me.LabelNomeProjeto.Size = New System.Drawing.Size(71, 13)
        Me.LabelNomeProjeto.TabIndex = 0
        Me.LabelNomeProjeto.Text = "Nome Projeto"
        '
        'LoginPanel
        '
        Me.LoginPanel.Controls.Add(Me.TxtPwdReg2)
        Me.LoginPanel.Controls.Add(Me.TxtPwdReg1)
        Me.LoginPanel.Controls.Add(Me.TxtEmail)
        Me.LoginPanel.Controls.Add(Me.TxtUserReg)
        Me.LoginPanel.Controls.Add(Me.TxtFirstName)
        Me.LoginPanel.Controls.Add(Me.TxtLastName)
        Me.LoginPanel.Controls.Add(Me.TxtPwd)
        Me.LoginPanel.Controls.Add(Me.TxtUser)
        Me.LoginPanel.Controls.Add(Me.BtnImagemRegister)
        Me.LoginPanel.Controls.Add(Me.BtnImagemLogin)
        Me.LoginPanel.ForeColor = System.Drawing.Color.White
        Me.LoginPanel.Location = New System.Drawing.Point(88, 36)
        Me.LoginPanel.Name = "LoginPanel"
        Me.LoginPanel.Size = New System.Drawing.Size(830, 396)
        Me.LoginPanel.TabIndex = 7
        '
        'TxtPwdReg2
        '
        Me.TxtPwdReg2.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.TxtPwdReg2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPwdReg2.Location = New System.Drawing.Point(415, 202)
        Me.TxtPwdReg2.Name = "TxtPwdReg2"
        Me.TxtPwdReg2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtPwdReg2.Size = New System.Drawing.Size(200, 13)
        Me.TxtPwdReg2.TabIndex = 17
        '
        'TxtPwdReg1
        '
        Me.TxtPwdReg1.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.TxtPwdReg1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPwdReg1.Location = New System.Drawing.Point(209, 202)
        Me.TxtPwdReg1.Name = "TxtPwdReg1"
        Me.TxtPwdReg1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtPwdReg1.Size = New System.Drawing.Size(200, 13)
        Me.TxtPwdReg1.TabIndex = 16
        '
        'TxtEmail
        '
        Me.TxtEmail.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.TxtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtEmail.Location = New System.Drawing.Point(415, 183)
        Me.TxtEmail.Name = "TxtEmail"
        Me.TxtEmail.Size = New System.Drawing.Size(200, 13)
        Me.TxtEmail.TabIndex = 15
        '
        'TxtUserReg
        '
        Me.TxtUserReg.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.TxtUserReg.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtUserReg.Location = New System.Drawing.Point(209, 183)
        Me.TxtUserReg.Name = "TxtUserReg"
        Me.TxtUserReg.Size = New System.Drawing.Size(200, 13)
        Me.TxtUserReg.TabIndex = 14
        '
        'TxtFirstName
        '
        Me.TxtFirstName.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.TxtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtFirstName.Location = New System.Drawing.Point(209, 164)
        Me.TxtFirstName.Name = "TxtFirstName"
        Me.TxtFirstName.Size = New System.Drawing.Size(200, 13)
        Me.TxtFirstName.TabIndex = 13
        '
        'TxtLastName
        '
        Me.TxtLastName.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.TxtLastName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtLastName.Location = New System.Drawing.Point(415, 164)
        Me.TxtLastName.Name = "TxtLastName"
        Me.TxtLastName.Size = New System.Drawing.Size(200, 13)
        Me.TxtLastName.TabIndex = 12
        '
        'TxtPwd
        '
        Me.TxtPwd.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.TxtPwd.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPwd.Location = New System.Drawing.Point(209, 57)
        Me.TxtPwd.Name = "TxtPwd"
        Me.TxtPwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtPwd.Size = New System.Drawing.Size(200, 13)
        Me.TxtPwd.TabIndex = 11
        Me.TxtPwd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtUser
        '
        Me.TxtUser.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.TxtUser.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtUser.Location = New System.Drawing.Point(3, 57)
        Me.TxtUser.Name = "TxtUser"
        Me.TxtUser.Size = New System.Drawing.Size(200, 13)
        Me.TxtUser.TabIndex = 9
        Me.TxtUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BtnImagemRegister
        '
        Me.BtnImagemRegister.BackColor = System.Drawing.Color.SlateGray
        Me.BtnImagemRegister.Location = New System.Drawing.Point(409, 3)
        Me.BtnImagemRegister.Name = "BtnImagemRegister"
        Me.BtnImagemRegister.Size = New System.Drawing.Size(200, 44)
        Me.BtnImagemRegister.TabIndex = 6
        Me.BtnImagemRegister.zAlturaImagem = 38
        Me.BtnImagemRegister.zComprimentoImagem = 38
        Me.BtnImagemRegister.zCorFundo = System.Drawing.Color.SlateGray
        Me.BtnImagemRegister.zCorHover = System.Drawing.Color.LightSlateGray
        Me.BtnImagemRegister.zCorSelecionado = System.Drawing.Color.SteelBlue
        Me.BtnImagemRegister.zEstadoBotao = False
        Me.BtnImagemRegister.zImagem = Nothing
        Me.BtnImagemRegister.zTamanhoLetra = 10
        Me.BtnImagemRegister.zTexto = "Register"
        '
        'BtnImagemLogin
        '
        Me.BtnImagemLogin.BackColor = System.Drawing.Color.SlateGray
        Me.BtnImagemLogin.Location = New System.Drawing.Point(3, 3)
        Me.BtnImagemLogin.Name = "BtnImagemLogin"
        Me.BtnImagemLogin.Size = New System.Drawing.Size(200, 44)
        Me.BtnImagemLogin.TabIndex = 5
        Me.BtnImagemLogin.zAlturaImagem = 38
        Me.BtnImagemLogin.zComprimentoImagem = 38
        Me.BtnImagemLogin.zCorFundo = System.Drawing.Color.SlateGray
        Me.BtnImagemLogin.zCorHover = System.Drawing.Color.LightSlateGray
        Me.BtnImagemLogin.zCorSelecionado = System.Drawing.Color.SteelBlue
        Me.BtnImagemLogin.zEstadoBotao = False
        Me.BtnImagemLogin.zImagem = Nothing
        Me.BtnImagemLogin.zTamanhoLetra = 10
        Me.BtnImagemLogin.zTexto = "Login"
        '
        'BtnMenu1
        '
        Me.BtnMenu1.BackColor = System.Drawing.Color.Transparent
        Me.BtnMenu1.BackgroundImage = CType(resources.GetObject("BtnMenu1.BackgroundImage"), System.Drawing.Image)
        Me.BtnMenu1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnMenu1.Location = New System.Drawing.Point(168, 3)
        Me.BtnMenu1.Name = "BtnMenu1"
        Me.BtnMenu1.Size = New System.Drawing.Size(32, 32)
        Me.BtnMenu1.TabIndex = 4
        Me.BtnMenu1.zEstadoBotao = False
        '
        'BtnImagem1
        '
        Me.BtnImagem1.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnImagem1.Location = New System.Drawing.Point(0, 45)
        Me.BtnImagem1.Name = "BtnImagem1"
        Me.BtnImagem1.Size = New System.Drawing.Size(200, 44)
        Me.BtnImagem1.TabIndex = 0
        Me.BtnImagem1.zAlturaImagem = 38
        Me.BtnImagem1.zComprimentoImagem = 38
        Me.BtnImagem1.zCorFundo = System.Drawing.Color.SlateGray
        Me.BtnImagem1.zCorHover = System.Drawing.Color.LightSlateGray
        Me.BtnImagem1.zCorSelecionado = System.Drawing.Color.SteelBlue
        Me.BtnImagem1.zEstadoBotao = True
        Me.BtnImagem1.zImagem = Nothing
        Me.BtnImagem1.zTamanhoLetra = 10
        Me.BtnImagem1.zTexto = "Home"
        '
        'BtnImagem2
        '
        Me.BtnImagem2.BackColor = System.Drawing.Color.SlateGray
        Me.BtnImagem2.Location = New System.Drawing.Point(0, 95)
        Me.BtnImagem2.Name = "BtnImagem2"
        Me.BtnImagem2.Size = New System.Drawing.Size(200, 44)
        Me.BtnImagem2.TabIndex = 1
        Me.BtnImagem2.zAlturaImagem = 38
        Me.BtnImagem2.zComprimentoImagem = 38
        Me.BtnImagem2.zCorFundo = System.Drawing.Color.SlateGray
        Me.BtnImagem2.zCorHover = System.Drawing.Color.LightSlateGray
        Me.BtnImagem2.zCorSelecionado = System.Drawing.Color.SteelBlue
        Me.BtnImagem2.zEstadoBotao = False
        Me.BtnImagem2.zImagem = Nothing
        Me.BtnImagem2.zTamanhoLetra = 10
        Me.BtnImagem2.zTexto = "COISA"
        '
        'BtnImagem4
        '
        Me.BtnImagem4.BackColor = System.Drawing.Color.SlateGray
        Me.BtnImagem4.Location = New System.Drawing.Point(0, 195)
        Me.BtnImagem4.Name = "BtnImagem4"
        Me.BtnImagem4.Size = New System.Drawing.Size(200, 44)
        Me.BtnImagem4.TabIndex = 3
        Me.BtnImagem4.zAlturaImagem = 38
        Me.BtnImagem4.zComprimentoImagem = 38
        Me.BtnImagem4.zCorFundo = System.Drawing.Color.SlateGray
        Me.BtnImagem4.zCorHover = System.Drawing.Color.LightSlateGray
        Me.BtnImagem4.zCorSelecionado = System.Drawing.Color.SteelBlue
        Me.BtnImagem4.zEstadoBotao = False
        Me.BtnImagem4.zImagem = Nothing
        Me.BtnImagem4.zTamanhoLetra = 10
        Me.BtnImagem4.zTexto = "COISA"
        '
        'BtnImagem3
        '
        Me.BtnImagem3.BackColor = System.Drawing.Color.SlateGray
        Me.BtnImagem3.Location = New System.Drawing.Point(0, 145)
        Me.BtnImagem3.Name = "BtnImagem3"
        Me.BtnImagem3.Size = New System.Drawing.Size(200, 44)
        Me.BtnImagem3.TabIndex = 2
        Me.BtnImagem3.zAlturaImagem = 38
        Me.BtnImagem3.zComprimentoImagem = 38
        Me.BtnImagem3.zCorFundo = System.Drawing.Color.SlateGray
        Me.BtnImagem3.zCorHover = System.Drawing.Color.LightSlateGray
        Me.BtnImagem3.zCorSelecionado = System.Drawing.Color.SteelBlue
        Me.BtnImagem3.zEstadoBotao = False
        Me.BtnImagem3.zImagem = Nothing
        Me.BtnImagem3.zTamanhoLetra = 10
        Me.BtnImagem3.zTexto = "COISA"
        '
        'BtnImagem5
        '
        Me.BtnImagem5.BackColor = System.Drawing.Color.SlateGray
        Me.BtnImagem5.Location = New System.Drawing.Point(924, 185)
        Me.BtnImagem5.Name = "BtnImagem5"
        Me.BtnImagem5.Size = New System.Drawing.Size(400, 300)
        Me.BtnImagem5.TabIndex = 4
        Me.BtnImagem5.zAlturaImagem = 38
        Me.BtnImagem5.zComprimentoImagem = 38
        Me.BtnImagem5.zCorFundo = System.Drawing.Color.SlateGray
        Me.BtnImagem5.zCorHover = System.Drawing.Color.LightSlateGray
        Me.BtnImagem5.zCorSelecionado = System.Drawing.Color.SteelBlue
        Me.BtnImagem5.zEstadoBotao = False
        Me.BtnImagem5.zImagem = Nothing
        Me.BtnImagem5.zTamanhoLetra = 10
        Me.BtnImagem5.zTexto = "X"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1000, 500)
        Me.Controls.Add(Me.LoginPanel)
        Me.Controls.Add(Me.PnlMenuTop)
        Me.Controls.Add(Me.PnlMenu)
        Me.Controls.Add(Me.BtnImagem5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GestFrot"
        Me.PnlMenu.ResumeLayout(False)
        Me.PnlMenuTop.ResumeLayout(False)
        Me.PnlMenuTop.PerformLayout()
        Me.LoginPanel.ResumeLayout(False)
        Me.LoginPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnImagem1 As GestFrotPAP.BtnImagem
    Friend WithEvents BtnImagem2 As GestFrotPAP.BtnImagem
    Friend WithEvents BtnImagem3 As GestFrotPAP.BtnImagem
    Friend WithEvents BtnImagem4 As GestFrotPAP.BtnImagem
    Friend WithEvents BtnImagem5 As GestFrotPAP.BtnImagem
    Friend WithEvents PnlMenu As System.Windows.Forms.Panel
    Friend WithEvents TmrSlide1 As System.Windows.Forms.Timer
    Friend WithEvents TmrSlide2 As System.Windows.Forms.Timer
    Friend WithEvents BtnMenu1 As GestFrotPAP.BtnMenu
    Friend WithEvents PnlMenuTop As System.Windows.Forms.Panel
    Friend WithEvents LabelNomeProjeto As System.Windows.Forms.Label
    Friend WithEvents Fechar As System.Windows.Forms.Label
    Friend WithEvents LoginPanel As System.Windows.Forms.Panel
    Friend WithEvents BtnImagemRegister As GestFrotPAP.BtnImagem
    Friend WithEvents BtnImagemLogin As GestFrotPAP.BtnImagem
    Friend WithEvents LblUserName As System.Windows.Forms.Label
    Friend WithEvents TxtUser As System.Windows.Forms.TextBox
    Friend WithEvents TxtPwd As System.Windows.Forms.TextBox
    Friend WithEvents TxtEmail As System.Windows.Forms.TextBox
    Friend WithEvents TxtUserReg As System.Windows.Forms.TextBox
    Friend WithEvents TxtFirstName As System.Windows.Forms.TextBox
    Friend WithEvents TxtLastName As System.Windows.Forms.TextBox
    Friend WithEvents TxtPwdReg2 As System.Windows.Forms.TextBox
    Friend WithEvents TxtPwdReg1 As System.Windows.Forms.TextBox

End Class
