Imports SignVerify.GUI.SignVerfiy
Imports SignVerify.Common

'This class handles the progress of operations (sign, verify, cosign)
Public Class frmProgressBar
    'The type of action running in background (sign, verify or cosign)
    Private m_eSingOrVerify As ActionTypes

    Friend IsCanceled As Boolean = False

    'Initialize the progress bar label and header.
    Public Sub New(ByVal p_eSingOrVerify As ActionTypes, ByVal p_sMessage As String)
        InitializeComponent()
        m_eSingOrVerify = p_eSingOrVerify
        ProgressBar1.Style = ProgressBarStyle.Marquee


        Select Case p_eSingOrVerify
            Case ActionTypes.Cosign
                Me.Text = My.Resources.ControlStrings.progressCoSign
            Case ActionTypes.Sign
                Me.Text = My.Resources.ControlStrings.progressSign
            Case ActionTypes.Verify
                Me.Text = My.Resources.ControlStrings.progressVerify
        End Select
        SetLabel(p_sMessage)
    End Sub

    'If the user press cancel button
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        IsCanceled = True
        If m_eSingOrVerify = ActionTypes.Cosign Then 'cosign action canceled
            SetLabel(My.Resources.ControlStrings.CancelCosign)
            Logger.Instance.Error("coSign Canceled")
            Throw New ApplicationException(My.Resources.ErrorMessages.coSignCanceled)
        ElseIf m_eSingOrVerify = ActionTypes.Sign Then 'sign action canceled
            SetLabel(My.Resources.ControlStrings.CancelSign)
            Logger.Instance.Error("Sign Canceled")
            Throw New ApplicationException(My.Resources.ErrorMessages.SignCanceled)
        ElseIf m_eSingOrVerify = ActionTypes.Verify Then 'verify action canceled
            SetLabel(My.Resources.ControlStrings.CancelVerify)
            Logger.Instance.Error("Verify Canceled")
            Throw New ApplicationException(My.Resources.ErrorMessages.VerifyCanceled2)
        Else 'Other issue concered with cancellation 
            SetLabel(My.Resources.ControlStrings.Cancelation)
            Logger.Instance.Error("CancelAction")
            Throw New ApplicationException(My.Resources.ErrorMessages.CancelAction)
        End If
    End Sub

    'Set the progress label (in UI thread)
    Friend Sub SetLabel(ByVal p_sMessage As String)
        lblProgress.Text = p_sMessage
        lblProgress.Location = New Point(lblProgress.Location.X - lblProgress.Width + 53, lblProgress.Location.Y)
    End Sub
End Class