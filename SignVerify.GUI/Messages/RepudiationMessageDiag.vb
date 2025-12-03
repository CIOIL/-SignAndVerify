Imports System.Windows.Forms

Public Class RepudiationMessageDiag
    'when button ok is clicked set the dialog result to ok.
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    'this method close the form
    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    'form loading initializes the lables
    Private Sub RepudiationMessageDiag_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitControlsStrings()
        SetTooltiControls()
    End Sub

    'This method initializes the form string according to current culture info
    Private Sub InitControlsStrings()
        'init labels

        'Set Form text
        Me.Text = My.Resources.ControlStrings.RepudiationMessageDiagForm

        'Set label
        Me.lblMessage.Text = My.Resources.ControlStrings.RepudiationMessageDiaglblMessage

        'Set Button text
        Me.Cancel_Button.Text = My.Resources.ControlStrings.RepudiationMessageDiagCancel_Button
        Me.OK_Button.Text = My.Resources.ControlStrings.RepudiationMessageDiagOK_Button

    End Sub


    'bind the set tooltip controls
    Private Sub SetTooltiControls()

        Me.ToolTip1.SetToolTip(Me.Cancel_Button, My.Resources.InfoMessages.RepudiationMessageCancel)
        Me.ToolTip1.SetToolTip(Me.OK_Button, My.Resources.InfoMessages.RepudiationMessageOK)
    End Sub
End Class
