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
        Me.BtnImagem2 = New GestFrotPAP.BtnImagem()
        Me.BtnImagem1 = New GestFrotPAP.BtnImagem()
        Me.SuspendLayout()
        '
        'BtnImagem2
        '
        Me.BtnImagem2.BackColor = System.Drawing.Color.SlateGray
        Me.BtnImagem2.Location = New System.Drawing.Point(12, 62)
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
        Me.BtnImagem2.zTamanhoLetra = 8
        Me.BtnImagem2.zTexto = "Texto"
        '
        'BtnImagem1
        '
        Me.BtnImagem1.BackColor = System.Drawing.Color.SlateGray
        Me.BtnImagem1.Location = New System.Drawing.Point(12, 12)
        Me.BtnImagem1.Name = "BtnImagem1"
        Me.BtnImagem1.Size = New System.Drawing.Size(200, 44)
        Me.BtnImagem1.TabIndex = 0
        Me.BtnImagem1.zAlturaImagem = 38
        Me.BtnImagem1.zComprimentoImagem = 38
        Me.BtnImagem1.zCorFundo = System.Drawing.Color.SlateGray
        Me.BtnImagem1.zCorHover = System.Drawing.Color.LightSlateGray
        Me.BtnImagem1.zCorSelecionado = System.Drawing.Color.SteelBlue
        Me.BtnImagem1.zEstadoBotao = False
        Me.BtnImagem1.zImagem = Nothing
        Me.BtnImagem1.zTamanhoLetra = 8
        Me.BtnImagem1.zTexto = "Texto"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(667, 261)
        Me.Controls.Add(Me.BtnImagem2)
        Me.Controls.Add(Me.BtnImagem1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnImagem1 As GestFrotPAP.BtnImagem
    Friend WithEvents BtnImagem2 As GestFrotPAP.BtnImagem

End Class
