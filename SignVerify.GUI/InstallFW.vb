Imports System.Windows.Forms

Public Class InstallFW
#Region "privates members"


#End Region

#Region "constructor"
    ''' <summary>
    ''' Constructor, initialize the error message dialog. 
    ''' </summary>

    Public Sub New()
        InitializeComponent()
        SetLabels()
    End Sub

    ''' <summary>
    ''' this method sets the labels according to current culture.
    ''' </summary>
    Private Sub SetLabels()
       
    End Sub
#End Region



    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim sLink As String = "http://www.microsoft.com/he-il/download/details.aspx?id=21"
        Dim oLinkLabelProc As Process = New Process()
        oLinkLabelProc.StartInfo.FileName = "iexplore.exe"
        oLinkLabelProc.StartInfo.Arguments = sLink
        oLinkLabelProc.Start()
    End Sub
End Class
