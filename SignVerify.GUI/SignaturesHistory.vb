Imports System.Windows.Forms
Imports SignVerify.Common
Imports System.IO

Public Class SignaturesHistory

#Region "Private members"

    'the sign object
    Private SignedObject As CryptoSignedObject(Of Byte())
    Private m_DisplayTS As Boolean = False
#End Region

#Region "Constructor"

    'constructor
    Public Sub New(ByVal SignedObject As CryptoSignedObject(Of Byte()), ByVal DisplayTS As Boolean)
        m_DisplayTS = DisplayTS
       
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

       
        'get the signed object
        Me.SignedObject = SignedObject

        'set the signatures to display into the treeGrid control
        SetSignatureTree()

        Me.Text = My.Resources.ControlStrings.SignaturesHistoryFormHeader
        Me.OK_Button.Text = My.Resources.ControlStrings.SuccessDiagOK_Button

        SetTooltiControls()
        Me.Refresh()
    End Sub

    'Set the tree data and position
    Private Sub SetSignatureTree()

        Dim LevelCount As Integer = 0

        'set the signatures to display into the treeGrid control
        SignaturesTreeGrid1.signatures = SignedObject.signatureInfos
       
        LevelCount = SignedObject.signatureInfos.getLevelCount()
        If LevelCount = 1 AndAlso SignedObject.signatureInfos.Count = 1 Then 'decrease form size
            pnlHistory.Size = New Size(pnlHistory.Size.Width, SignaturesTreeGrid1.ExpandedRowHeight + SignaturesTreeGrid1.HeaderHeight)
            Me.Size = New Size(Me.Size.Width, Me.Size.Height - SignaturesTreeGrid1.ExpandedRowHeight + SignaturesTreeGrid1.HeaderHeight + 40)
        End If

        If LevelCount > 1 OrElse SignedObject.signatureInfos.Count > 1 Then
            pnlHistory.Size = New Size(pnlHistory.Size.Width, pnlHistory.Size.Height + (LevelCount - 1) * SignaturesTreeGrid1.HeaderHeight)
            Me.Size = New Size(Me.Size.Width, Me.Size.Height + (LevelCount - 1) * SignaturesTreeGrid1.HeaderHeight - 15)
        End If
        SignaturesTreeGrid1.InitialState = PanelStateType.Expanded

    End Sub

    'bind the set tooltip controls
    Private Sub SetTooltiControls()

        Me.ToolTip1.SetToolTip(Me.lnkExpandAll, My.Resources.InfoMessages.SignatureTreeExpand)
        Me.ToolTip1.SetToolTip(Me.lnkCollopseAll, My.Resources.InfoMessages.SignatureTreeCollapse)
        Me.ToolTip1.SetToolTip(Me.OK_Button, My.Resources.InfoMessages.CloseForm)

    End Sub
#End Region

#Region "User events"

    'on ok button clicked
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

#End Region

#Region "History panel"
    'set the expand collopse link label according to the initialize state (all expanded)
    Private Sub SignaturesHistory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lnkCollopseAll.Enabled = True
        lnkExpandAll.Enabled = False
    End Sub

    'checks if all the tree state (collopse or expanded)
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        EnableCloseOpen()
    End Sub

    'this method collopses all the levels in signature history tree.
    Private Sub lnkCollopseAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkCollopseAll.Click
        SignaturesTreeGrid1.CollapseAll()
        EnableCloseOpen()
    End Sub

    'when mouse hovers cursur hand is shown
    Private Sub lnkCollopseAll_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkCollopseAll.MouseHover
        Me.lnkCollopseAll.Cursor = Cursors.Hand
    End Sub

    'when the label enabled/diabled reomve/add the underline
    Private Sub lnkCollopseAll_EnabledChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkCollopseAll.EnabledChanged
        Dim oFont As Font = Nothing
        If Me.lnkCollopseAll.Enabled Then
            oFont = New Font(Me.lnkCollopseAll.Font, FontStyle.Underline)
        Else
            oFont = New Font(Me.lnkCollopseAll.Font, FontStyle.Regular)
        End If
        Me.lnkCollopseAll.Font = oFont
    End Sub

    'this method expand all the levels in signature history tree.
    Private Sub lnkExpandAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkExpandAll.Click
        SignaturesTreeGrid1.ExpandAll()
        EnableCloseOpen()
    End Sub

    'when mouse hovers cursur hand is shown
    Private Sub lnkExpandAll_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkExpandAll.MouseHover
        Me.lnkExpandAll.Cursor = Cursors.Hand
    End Sub

    'when the label enabled/diabled reomve/add the underline
    Private Sub lnkExpandAll_EnabledChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkExpandAll.EnabledChanged
        Dim oFont As Font = Nothing
        If Me.lnkExpandAll.Enabled Then
            oFont = New Font(Me.lnkExpandAll.Font, FontStyle.Underline)
        Else
            oFont = New Font(Me.lnkExpandAll.Font, FontStyle.Regular)
        End If
        Me.lnkExpandAll.Font = oFont
    End Sub
    'this method checks if the tree is fully closed or open and enable/disable accordingly
    Private Sub EnableCloseOpen()
        If SignaturesTreeGrid1.IsAllClosed Then
            lnkCollopseAll.Enabled = False
            lnkExpandAll.Enabled = True
        End If

        If SignaturesTreeGrid1.IsAllOpen Then
            lnkCollopseAll.Enabled = True
            lnkExpandAll.Enabled = False
        End If
    End Sub
#End Region

#Region "Help"
    'Show the help
    Private Sub HelpToolStripButton_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HelpToolStripButton.Click

        Dim Dir As New IO.DirectoryInfo(System.IO.Path.GetDirectoryName(Application.ExecutablePath))
        Dim Files() As FileInfo = Dir.GetFiles("SignVerifyUserGuide.chm", SearchOption.AllDirectories)
        If Files.Length = 1 Then
            Dim sCHMPath As String = Files(0).FullName
            Help.ShowHelp(Me, sCHMPath, "confirm.html")
        End If
    End Sub
#End Region


End Class
