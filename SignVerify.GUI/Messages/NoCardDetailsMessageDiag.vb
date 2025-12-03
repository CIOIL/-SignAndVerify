Imports System.Windows.Forms

Public Class ShowSignOptionDiag
    'Ctor
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub


    'form load
    Private Sub AlreadySignMessageDiag_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitControlsStrings()
    End Sub

    'This method initializes the form string according to current culture info
    Private Sub InitControlsStrings()
        'init labels

        'Set Form text
        Me.Text = My.Resources.InfoMessages.ShowSignOptionDiagHeader

        'Set label
        Me.lblMessage.Text = My.Resources.InfoMessages.ShowSignOptionDiag

        'Set Button text
        Me.OK_Button.Text = My.Resources.ControlStrings.SuccessDiagOK_Button

        'close the form
        Me.ToolTip1.SetToolTip(Me.OK_Button, My.Resources.InfoMessages.CloseForm)
    End Sub
End Class
