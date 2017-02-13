Imports System.Windows.Forms
<System.ComponentModel.DefaultEventAttribute("Click")> _
Public Class BtnMenu
    <System.ComponentModel.Category("BtnMenu")> _
    Public Property zEstadoBotao As Boolean = False
    Public Sub resetbtn()
        If zEstadoBotao = False Then
            Me.BackgroundImage = My.Resources.Menu1
            zEstadoBotao = True
        ElseIf zEstadoBotao = True Then
            Me.BackgroundImage = My.Resources.Menu
            zEstadoBotao = False
        End If
    End Sub
    Public Sub BtnMenu_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Click
        If zEstadoBotao = False Then
            Me.BackgroundImage = My.Resources.Menu1
            zEstadoBotao = True
        ElseIf zEstadoBotao = True Then
            Me.BackgroundImage = My.Resources.Menu
            zEstadoBotao = False
        End If
    End Sub

    Private Sub BtnMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub


End Class
