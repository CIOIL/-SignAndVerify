Public Class InstallCSP
#Region "Class members"
    Private m_bIsInstaslled As Boolean = False
#End Region

#Region "class ctor"
    Public Sub New(ByVal p_bIsInstaslled As Boolean)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        m_bIsInstaslled = p_bIsInstaslled
    End Sub

#End Region

#Region "private members"

    ''' <summary>
    ''' This method loads the screen 
    ''' </summary>
    Public Sub InstallCSP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If m_bIsInstaslled Then
            Me.Text = My.Resources.InfoMessages.UpgradeCSPHeader
            Me.lblCSP.Text = My.Resources.InfoMessages.UpgradeCSP
        Else
            Me.Text = My.Resources.InfoMessages.InstallCSPHeader
            Me.lblCSP.Text = My.Resources.InfoMessages.InstallCSP
        End If
        Me.lblSupport.Text = My.Resources.InfoMessages.CallForSuport
    End Sub

    ''' <summary>
    ''' Open the link.
    ''' </summary>
    Private Sub lnkCSP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkCSP.LinkClicked
        Dim sLink As String = lnkCSP.Text
        e.Link.Visited = True

        Dim oLinkLabelProc As Process = New Process()
        oLinkLabelProc.StartInfo.FileName = "iexplore.exe"
        oLinkLabelProc.StartInfo.Arguments = sLink
        oLinkLabelProc.Start()
    End Sub
#End Region

End Class