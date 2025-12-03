Imports System.Windows.Forms

Public Class FileExistDialog
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
        Me.Text = header
        Me.lblMessage.Text = message
        lblHeader.Text = header
        SetLabels()
    End Sub

    ''' <summary>
    ''' this method sets the labels according to current culture.
    ''' </summary>
    Private Sub SetLabels()
        Me.btnReplace.Text = My.Resources.ControlStrings.fileExistReplaceBtn
        Me.btnCopy.Text = My.Resources.ControlStrings.fileExistCopyBtn
    End Sub
#End Region



End Class
