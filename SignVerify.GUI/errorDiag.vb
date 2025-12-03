Imports System.Windows.Forms

Public Class errorDiag
#Region "privates members"
    'the error message,.
    Private message As String
#End Region

#Region "constructor"
    ''' <summary>
    ''' Constructor, initialize the error message dialog. 
    ''' </summary>
    ''' <param name="message">The error message body</param>
    ''' <param name="header">The error message header</param>
    Public Sub New(ByVal message As String, ByVal header As String)
        InitializeComponent()

        Me.lblMessage.Text = message
        lblHeader.Text = header
        SetLabels()
    End Sub

    ''' <summary>
    ''' this method sets the labels according to current culture.
    ''' </summary>
    Private Sub SetLabels()
        Me.Text = My.Resources.ControlStrings.errorDiagForm
        Me.btnOk.Text = My.Resources.ControlStrings.errorDiagOK_Button
    End Sub
#End Region

#Region "ok"

    ''' <summary>
    ''' Close error dialog.
    ''' </summary>
    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

#End Region

End Class
