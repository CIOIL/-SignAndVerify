Public Class P_ErrorTemplate

#Region "class members"

    ''' <summary>
    ''' This member contains  the error message header.
    ''' </summary>
    Private m_sHeader As String = String.Empty

    ''' <summary>
    ''' This member containst the error body message .
    ''' </summary>
    Private m_sMessage As String = String.Empty

    ''' <summary>
    ''' The label of the first button.
    ''' </summary>
    Private m_sFirstButtonLabel As String = String.Empty

    ''' <summary>
    ''' The label of the second button.
    ''' </summary>
    Private m_sSecondButtonLabel As String = String.Empty

    ''' <summary>
    ''' show the ok button or not.
    ''' </summary>
    Private m_bShowOKButtons As Boolean = False
#End Region

#Region "Ctor"

    ''' <summary>
    ''' class ctor
    ''' </summary>
    ''' <param name="p_sHeader">This member contains  the error message header.</param>
    ''' <param name="p_sMessage">This member containst the error body message .</param>
    ''' <param name="p_sFirstButtonLabel">The label of the first button.</param>
    ''' <param name="p_sSecondButtonLabel">The label of the second button.</param>
    ''' <param name="p_bShowOKButtons">Show ok button.</param>
    Public Sub New(ByVal p_sHeader As String, ByVal p_sMessage As String, Optional ByVal p_sFirstButtonLabel As String = "אשר", Optional ByVal p_sSecondButtonLabel As String = "בטל", Optional ByVal p_bShowOKButtons As Boolean = True)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        m_sHeader = p_sHeader
        m_sMessage = p_sMessage
        m_sFirstButtonLabel = p_sFirstButtonLabel
        m_sSecondButtonLabel = p_sSecondButtonLabel
        m_bShowOKButtons = p_bShowOKButtons
    End Sub
#End Region

#Region "private methods"
    ''' <summary>
    ''' Load the error message with defined header and message.
    ''' </summary>
    Private Sub P_ErrorTemplate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.lblMessage.Text = m_sMessage
        Me.Text = m_sHeader
        Me.OK_Button.Text = m_sFirstButtonLabel
        Me.Cancel_Button.Text = m_sSecondButtonLabel
        Me.OK_Button.Visible = m_bShowOKButtons
    End Sub
#End Region

    
End Class