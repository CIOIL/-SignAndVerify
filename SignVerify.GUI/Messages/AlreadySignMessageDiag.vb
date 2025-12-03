Imports System.Windows.Forms

Public Class AlreadySignMessageDiag
    'when button ok is clicked set the dialog result to ok.
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    'Load
    Private Sub AlreadySignMessageDiag_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitControlsStrings()
        SetToolTipConstrols()
    End Sub

    'Initialize the form string according to current culture info
    Private Sub InitControlsStrings()
        'init labels

        'Set Form text
        Me.Text = My.Resources.ControlStrings.AlreadySignMessageDiagForm

        'Set label
        Me.lblMessage.Text = My.Resources.ControlStrings.AlreadySignMessageDiaglblMessage

        'Set Button text
        Me.Cancel_Button.Text = My.Resources.ControlStrings.AlreadySignMessageDiagCancel_Button
        Me.OK_Button.Text = My.Resources.ControlStrings.AlreadySignMessageDiagOK_Button
    End Sub

    'Close the from
    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    'Set tool tip over controls
    Private Sub SetToolTipConstrols()
        Me.ToolTip1.SetToolTip(Me.OK_Button, My.Resources.InfoMessages.SignOptionSign)
        Me.ToolTip1.SetToolTip(Me.Cancel_Button, My.Resources.InfoMessages.SignOptionCancel)
    End Sub
End Class
