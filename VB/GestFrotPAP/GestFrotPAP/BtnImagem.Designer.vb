<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BtnImagem
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.LblTexto = New System.Windows.Forms.Label()
        Me.Imagem = New System.Windows.Forms.PictureBox()
        CType(Me.Imagem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblTexto
        '
        Me.LblTexto.AutoSize = True
        Me.LblTexto.Location = New System.Drawing.Point(47, 15)
        Me.LblTexto.Name = "LblTexto"
        Me.LblTexto.Size = New System.Drawing.Size(34, 13)
        Me.LblTexto.TabIndex = 0
        Me.LblTexto.Text = "Texto"
        '
        'Imagem
        '
        Me.Imagem.BackColor = System.Drawing.Color.Transparent
        Me.Imagem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Imagem.Location = New System.Drawing.Point(3, 3)
        Me.Imagem.Name = "Imagem"
        Me.Imagem.Size = New System.Drawing.Size(38, 38)
        Me.Imagem.TabIndex = 1
        Me.Imagem.TabStop = False
        '
        'BtnImagem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Imagem)
        Me.Controls.Add(Me.LblTexto)
        Me.Name = "BtnImagem"
        Me.Size = New System.Drawing.Size(200, 44)
        CType(Me.Imagem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents LblTexto As System.Windows.Forms.Label
    Public WithEvents Imagem As System.Windows.Forms.PictureBox

End Class
