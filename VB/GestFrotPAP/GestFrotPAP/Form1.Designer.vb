﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.LblUtilzadorMenu = New System.Windows.Forms.Label()
        Me.Fechar = New System.Windows.Forms.Label()
        Me.LabelNomeProjeto = New System.Windows.Forms.Label()
        Me.LoginPanel = New System.Windows.Forms.Panel()
        Me.LblUtilizadorReg = New System.Windows.Forms.Label()
        Me.LblEmailReg = New System.Windows.Forms.Label()
        Me.LblPasswordReg = New System.Windows.Forms.Label()
        Me.TxtPwdReg2 = New System.Windows.Forms.TextBox()
        Me.TxtPwdReg1 = New System.Windows.Forms.TextBox()
        Me.TxtEmail = New System.Windows.Forms.TextBox()
        Me.TxtUserReg = New System.Windows.Forms.TextBox()
        Me.TxtPwd = New System.Windows.Forms.TextBox()
        Me.TxtUser = New System.Windows.Forms.TextBox()
        Me.PnlUser = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnImagemCancelar = New GestFrotPAP.BtnImagem()
        Me.BtnImagemRegistar = New GestFrotPAP.BtnImagem()
        Me.BtnImagemRegistarEntrar = New GestFrotPAP.BtnImagem()
        Me.BtnImagemLogin = New GestFrotPAP.BtnImagem()
        Me.BtnMenu1 = New GestFrotPAP.BtnMenu()
        Me.BtnImagem1 = New GestFrotPAP.BtnImagem()
        Me.BtnImagem2 = New GestFrotPAP.BtnImagem()
        Me.BtnImagem4 = New GestFrotPAP.BtnImagem()
        Me.BtnImagem3 = New GestFrotPAP.BtnImagem()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.PnlMenu.SuspendLayout()
        Me.PnlMenuTop.SuspendLayout()
        Me.LoginPanel.SuspendLayout()
        Me.PnlUser.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
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
        Me.PnlMenu.Size = New System.Drawing.Size(201, 476)
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
        Me.PnlMenuTop.Controls.Add(Me.LblUtilzadorMenu)
        Me.PnlMenuTop.Controls.Add(Me.Fechar)
        Me.PnlMenuTop.Controls.Add(Me.LabelNomeProjeto)
        Me.PnlMenuTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlMenuTop.Location = New System.Drawing.Point(0, 0)
        Me.PnlMenuTop.Name = "PnlMenuTop"
        Me.PnlMenuTop.Size = New System.Drawing.Size(1000, 30)
        Me.PnlMenuTop.TabIndex = 6
        '
        'LblUtilzadorMenu
        '
        Me.LblUtilzadorMenu.AutoSize = True
        Me.LblUtilzadorMenu.Location = New System.Drawing.Point(854, 8)
        Me.LblUtilzadorMenu.Name = "LblUtilzadorMenu"
        Me.LblUtilzadorMenu.Size = New System.Drawing.Size(39, 13)
        Me.LblUtilzadorMenu.TabIndex = 2
        Me.LblUtilzadorMenu.Text = "Label3"
        Me.LblUtilzadorMenu.Visible = False
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
        Me.LoginPanel.Controls.Add(Me.LblUtilizadorReg)
        Me.LoginPanel.Controls.Add(Me.LblEmailReg)
        Me.LoginPanel.Controls.Add(Me.LblPasswordReg)
        Me.LoginPanel.Controls.Add(Me.BtnImagemCancelar)
        Me.LoginPanel.Controls.Add(Me.BtnImagemRegistar)
        Me.LoginPanel.Controls.Add(Me.TxtPwdReg2)
        Me.LoginPanel.Controls.Add(Me.TxtPwdReg1)
        Me.LoginPanel.Controls.Add(Me.TxtEmail)
        Me.LoginPanel.Controls.Add(Me.TxtUserReg)
        Me.LoginPanel.Controls.Add(Me.TxtPwd)
        Me.LoginPanel.Controls.Add(Me.TxtUser)
        Me.LoginPanel.Controls.Add(Me.BtnImagemRegistarEntrar)
        Me.LoginPanel.Controls.Add(Me.BtnImagemLogin)
        Me.LoginPanel.ForeColor = System.Drawing.Color.White
        Me.LoginPanel.Location = New System.Drawing.Point(325, 138)
        Me.LoginPanel.Name = "LoginPanel"
        Me.LoginPanel.Size = New System.Drawing.Size(320, 178)
        Me.LoginPanel.TabIndex = 7
        '
        'LblUtilizadorReg
        '
        Me.LblUtilizadorReg.AutoSize = True
        Me.LblUtilizadorReg.BackColor = System.Drawing.Color.Transparent
        Me.LblUtilizadorReg.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblUtilizadorReg.Location = New System.Drawing.Point(399, 230)
        Me.LblUtilizadorReg.Name = "LblUtilizadorReg"
        Me.LblUtilizadorReg.Size = New System.Drawing.Size(80, 12)
        Me.LblUtilizadorReg.TabIndex = 20
        Me.LblUtilizadorReg.Text = "*Utilizador em uso"
        '
        'LblEmailReg
        '
        Me.LblEmailReg.AutoSize = True
        Me.LblEmailReg.BackColor = System.Drawing.Color.Transparent
        Me.LblEmailReg.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEmailReg.Location = New System.Drawing.Point(415, 192)
        Me.LblEmailReg.Name = "LblEmailReg"
        Me.LblEmailReg.Size = New System.Drawing.Size(64, 12)
        Me.LblEmailReg.TabIndex = 22
        Me.LblEmailReg.Text = "*Email em uso"
        '
        'LblPasswordReg
        '
        Me.LblPasswordReg.AutoSize = True
        Me.LblPasswordReg.BackColor = System.Drawing.Color.Transparent
        Me.LblPasswordReg.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPasswordReg.Location = New System.Drawing.Point(207, 218)
        Me.LblPasswordReg.Name = "LblPasswordReg"
        Me.LblPasswordReg.Size = New System.Drawing.Size(111, 12)
        Me.LblPasswordReg.TabIndex = 21
        Me.LblPasswordReg.Text = "*Password não são iguais"
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
        'PnlUser
        '
        Me.PnlUser.BackColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(39, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.PnlUser.Controls.Add(Me.Label3)
        Me.PnlUser.Controls.Add(Me.Label2)
        Me.PnlUser.Controls.Add(Me.Label1)
        Me.PnlUser.Location = New System.Drawing.Point(772, 46)
        Me.PnlUser.Name = "PnlUser"
        Me.PnlUser.Size = New System.Drawing.Size(200, 100)
        Me.PnlUser.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(16, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Sign Out"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(16, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Acount Setting"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(16, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "LOLZ"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Red
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Location = New System.Drawing.Point(622, 104)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(799, 471)
        Me.Panel1.TabIndex = 10
        Me.Panel1.Visible = False
        '
        'BtnImagemCancelar
        '
        Me.BtnImagemCancelar.BackColor = System.Drawing.Color.SlateGray
        Me.BtnImagemCancelar.Location = New System.Drawing.Point(333, 327)
        Me.BtnImagemCancelar.Name = "BtnImagemCancelar"
        Me.BtnImagemCancelar.Size = New System.Drawing.Size(200, 44)
        Me.BtnImagemCancelar.TabIndex = 19
        Me.BtnImagemCancelar.zAlturaImagem = 38
        Me.BtnImagemCancelar.zComprimentoImagem = 38
        Me.BtnImagemCancelar.zCorFundo = System.Drawing.Color.SlateGray
        Me.BtnImagemCancelar.zCorHover = System.Drawing.Color.LightSlateGray
        Me.BtnImagemCancelar.zCorSelecionado = System.Drawing.Color.SteelBlue
        Me.BtnImagemCancelar.zEstadoBotao = False
        Me.BtnImagemCancelar.zImagem = Nothing
        Me.BtnImagemCancelar.zTamanhoLetra = 10
        Me.BtnImagemCancelar.zTexto = "Cancelar"
        '
        'BtnImagemRegistar
        '
        Me.BtnImagemRegistar.BackColor = System.Drawing.Color.SlateGray
        Me.BtnImagemRegistar.Location = New System.Drawing.Point(106, 327)
        Me.BtnImagemRegistar.Name = "BtnImagemRegistar"
        Me.BtnImagemRegistar.Size = New System.Drawing.Size(200, 44)
        Me.BtnImagemRegistar.TabIndex = 18
        Me.BtnImagemRegistar.zAlturaImagem = 38
        Me.BtnImagemRegistar.zComprimentoImagem = 38
        Me.BtnImagemRegistar.zCorFundo = System.Drawing.Color.SlateGray
        Me.BtnImagemRegistar.zCorHover = System.Drawing.Color.LightSlateGray
        Me.BtnImagemRegistar.zCorSelecionado = System.Drawing.Color.SteelBlue
        Me.BtnImagemRegistar.zEstadoBotao = False
        Me.BtnImagemRegistar.zImagem = Nothing
        Me.BtnImagemRegistar.zTamanhoLetra = 10
        Me.BtnImagemRegistar.zTexto = "Registar"
        '
        'BtnImagemRegistarEntrar
        '
        Me.BtnImagemRegistarEntrar.BackColor = System.Drawing.Color.SlateGray
        Me.BtnImagemRegistarEntrar.Location = New System.Drawing.Point(209, 0)
        Me.BtnImagemRegistarEntrar.Name = "BtnImagemRegistarEntrar"
        Me.BtnImagemRegistarEntrar.Size = New System.Drawing.Size(200, 44)
        Me.BtnImagemRegistarEntrar.TabIndex = 6
        Me.BtnImagemRegistarEntrar.zAlturaImagem = 38
        Me.BtnImagemRegistarEntrar.zComprimentoImagem = 38
        Me.BtnImagemRegistarEntrar.zCorFundo = System.Drawing.Color.SlateGray
        Me.BtnImagemRegistarEntrar.zCorHover = System.Drawing.Color.LightSlateGray
        Me.BtnImagemRegistarEntrar.zCorSelecionado = System.Drawing.Color.SteelBlue
        Me.BtnImagemRegistarEntrar.zEstadoBotao = False
        Me.BtnImagemRegistarEntrar.zImagem = Nothing
        Me.BtnImagemRegistarEntrar.zTamanhoLetra = 10
        Me.BtnImagemRegistarEntrar.zTexto = "Registar"
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
        Me.BtnImagemLogin.zTexto = "Entrar"
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
        Me.BtnImagem1.Location = New System.Drawing.Point(0, 56)
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
        Me.BtnImagem2.Location = New System.Drawing.Point(0, 101)
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
        Me.BtnImagem4.Location = New System.Drawing.Point(0, 191)
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
        Me.BtnImagem3.Location = New System.Drawing.Point(0, 146)
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
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Lime
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Location = New System.Drawing.Point(8, 8)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(799, 471)
        Me.Panel2.TabIndex = 11
        Me.Panel2.Visible = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.DodgerBlue
        Me.Panel3.Location = New System.Drawing.Point(8, 8)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(799, 471)
        Me.Panel3.TabIndex = 11
        Me.Panel3.Visible = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1000, 500)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PnlUser)
        Me.Controls.Add(Me.LoginPanel)
        Me.Controls.Add(Me.PnlMenuTop)
        Me.Controls.Add(Me.PnlMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GestFrot"
        Me.PnlMenu.ResumeLayout(False)
        Me.PnlMenuTop.ResumeLayout(False)
        Me.PnlMenuTop.PerformLayout()
        Me.LoginPanel.ResumeLayout(False)
        Me.LoginPanel.PerformLayout()
        Me.PnlUser.ResumeLayout(False)
        Me.PnlUser.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnImagem1 As GestFrotPAP.BtnImagem
    Friend WithEvents BtnImagem2 As GestFrotPAP.BtnImagem
    Friend WithEvents BtnImagem3 As GestFrotPAP.BtnImagem
    Friend WithEvents BtnImagem4 As GestFrotPAP.BtnImagem
    Friend WithEvents PnlMenu As System.Windows.Forms.Panel
    Friend WithEvents TmrSlide1 As System.Windows.Forms.Timer
    Friend WithEvents TmrSlide2 As System.Windows.Forms.Timer
    Friend WithEvents BtnMenu1 As GestFrotPAP.BtnMenu
    Friend WithEvents PnlMenuTop As System.Windows.Forms.Panel
    Friend WithEvents LabelNomeProjeto As System.Windows.Forms.Label
    Friend WithEvents Fechar As System.Windows.Forms.Label
    Friend WithEvents LoginPanel As System.Windows.Forms.Panel
    Friend WithEvents BtnImagemRegistarEntrar As GestFrotPAP.BtnImagem
    Friend WithEvents BtnImagemLogin As GestFrotPAP.BtnImagem
    Friend WithEvents LblUtilzadorMenu As System.Windows.Forms.Label
    Friend WithEvents TxtUser As System.Windows.Forms.TextBox
    Friend WithEvents TxtPwd As System.Windows.Forms.TextBox
    Friend WithEvents TxtEmail As System.Windows.Forms.TextBox
    Friend WithEvents TxtUserReg As System.Windows.Forms.TextBox
    Friend WithEvents TxtPwdReg2 As System.Windows.Forms.TextBox
    Friend WithEvents TxtPwdReg1 As System.Windows.Forms.TextBox
    Friend WithEvents BtnImagemCancelar As GestFrotPAP.BtnImagem
    Friend WithEvents BtnImagemRegistar As GestFrotPAP.BtnImagem
    Friend WithEvents LblPasswordReg As System.Windows.Forms.Label
    Friend WithEvents LblEmailReg As System.Windows.Forms.Label
    Friend WithEvents LblUtilizadorReg As System.Windows.Forms.Label
    Friend WithEvents PnlUser As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel

End Class
