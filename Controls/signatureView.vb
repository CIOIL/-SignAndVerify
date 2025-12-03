Imports System.Security.Cryptography.X509Certificates
Imports SignVerify.Common
Imports System.ComponentModel 
Imports System.Globalization


Public Class signatureView

#Region "Variables and Enumerations"

    'the certificate to display
    Private _signInfo As CryptoSignatureInfo

    'the Signer sequence number
    Private _signerNumber As Integer

    'the Signer validity icon
    Private _signerOk As Drawing.Image

    Private m_DisplayTS As Boolean = False
#End Region

#Region "Control Properties"

    'the certificate to display
    Public Property signInfo() As CryptoSignatureInfo
        Get
            Return _signInfo
        End Get
        Set(ByVal value As CryptoSignatureInfo)
            _signInfo = value
        End Set
    End Property
    'the Signer sequence number
    <Category("Header")> _
    Public Property SignerNumber() As Integer
        Get
            Return _signerNumber
        End Get
        Set(ByVal value As Integer)
            _signerNumber = value
        End Set
    End Property

    'the Signer is valid or not
    <Category("Header")> _
    Public Property SignerOk() As Drawing.Image
        Get
            Return _signerOk
        End Get
        Set(ByVal value As Drawing.Image)
            _signerOk = value
        End Set
    End Property
#End Region

#Region "Constructor"

    'constructor
    Public Sub New(ByVal signInfo As CryptoSignatureInfo, ByVal SignatureNum As Integer, ByVal DisplayTS As Boolean)
        Me.m_DisplayTS = DisplayTS
        Me._signInfo = signInfo
        InitializeComponent()
        Me._signerNumber = SignatureNum

    End Sub

    Private Sub SetInitLabelsText()
        'set header name
        Me.lblHeader.Text = My.Resources.ControlStrings.signatureViewlblHeader + " " + _signerNumber.ToString
        Me.lblIsSignOk.Text = GetStateLabel()

        'Set labels
        Me.lblNameLabel.Text = My.Resources.ControlStrings.signatureViewlblNameLabel
        Me.lblTSLabel.Text = My.Resources.ControlStrings.signatureViewlblTSLabel
        Me.lblTSStateLabel.Text = My.Resources.ControlStrings.signatureViewlblTSStateLabel
        Me.lblasdfeLabel.Text = My.Resources.ControlStrings.signatureViewlblasdfe
        Me.lblExpirationDateLabel.Text = My.Resources.ControlStrings.signatureViewlblexpirationDateLabel
        Me.lblasdfeLabel.Text = My.Resources.ControlStrings.signatureViewlblasdfe
        Me.lblChainLabel.Text = My.Resources.ControlStrings.signatureViewlblChainLabel
        Me.lblTSNameLabel.Text = My.Resources.ControlStrings.signatureViewlblTsNameLabel
        Me.lblTSCertLabel.Text = My.Resources.ControlStrings.signatureViewlblTSCertLabel
        Me.lblStandardLabel.Text = My.Resources.ControlStrings.signatureViewlblStandard

    End Sub
#End Region

#Region "Set state labels"
    'this method get the signature state label (valid, unchecked or unavlid)
    Private Function GetStateLabel() As String
        If _signInfo.ChainSignatureState = ChainSignatureStateType.Unvalid Or _
            _signInfo.EndSignatureState = EndSignatureStateType.SignatureUnvalid Then 'Or _
            ' _signInfo.TimeStausStatus <> PKIStatus_Enum.Granted Then
            GetStateLabel = My.Resources.ControlStrings.signatureViewlblIsSignNotValid
        ElseIf _signInfo.ChainSignatureState = ChainSignatureStateType.Unchecked Or _
            _signInfo.CRLstate = CRLSignatureStateType.Unchecked Or _
            _signInfo.CRLstate = CRLSignatureStateType.Unknown Or _
            _signInfo.EndSignatureState = EndSignatureStateType.Unchecked Then 'Or _
            '_signInfo.TimeStausStatus = TimeStausStatus_Enum.Unchecked Then
            GetStateLabel = My.Resources.ControlStrings.signatureViewlblIsSignNoCheck
        Else
            GetStateLabel = My.Resources.ControlStrings.signatureViewlblIsSignOk
        End If
    End Function
    'the method sets the state image according to signature state
    Private Sub SetImage()
        Dim StatusImage As Drawing.Image
        If _signInfo.ChainSignatureState = ChainSignatureStateType.Unvalid Or _
            _signInfo.EndSignatureState = EndSignatureStateType.SignatureUnvalid Then ' Or _
            '_signInfo.TimeStausStatus = PKIStatus_Enum.Rejection Then
            StatusImage = My.Resources.XErroMessagesmall1
        ElseIf _signInfo.ChainSignatureState = ChainSignatureStateType.Unchecked Or _
        _signInfo.CRLstate = CRLSignatureStateType.Unchecked Or _
        _signInfo.CRLstate = CRLSignatureStateType.Unknown Or _
        _signInfo.EndSignatureState = EndSignatureStateType.CertificateExpired Or _
        _signInfo.EndSignatureState = EndSignatureStateType.Unchecked Then 'Or _
            '_signInfo.TimeStausStatus <> PKIStatus_Enum.Granted Then
            StatusImage = My.Resources.unknownSmall1
        Else
            StatusImage = My.Resources.ViIconSmall
        End If
        pixBoxIsVerifyed.Image = StatusImage
    End Sub
#End Region

#Region "Drawing Functions"

    Private Sub Fill()
        lblExpire.Text = _signInfo.certificate.GetExpirationDateString
        lblName.Text = Common.Certificate.getSignCertificateName(_signInfo.certificate)
        lblIssuer.Text = Common.Certificate.getIssuerName(_signInfo.certificate)
        lblStandard.Text = _signInfo.SignatureStandard.ToString
        If Not signInfo.TimeStampCertificate Is Nothing Then
            lblTSName.Text = Common.Certificate.getSignCertificateName(_signInfo.TimeStampCertificate)
            SetCertStatus(signInfo.TimeStampState)
        End If
        lblEndCertificate.Text = GetEndSignatureStateName()
        lblCRL.Text = GetCRLstateName()
        lblChain.Text = GetChainSignatureStateName()
        lblTS.Text = GetSigningTime()
        lblTSState.Text = GetTimeStampStatus()
        SetInitLabelsText()
        SetImage()
    End Sub


    'on control created
    Protected Overrides Sub OnCreateControl()
        Fill()
        MyBase.OnCreateControl()
    End Sub

#End Region

#Region "Private methods"
    'Return the EndSignatureStateName name according to the language
    Private Function GetEndSignatureStateName() As String
        If signInfo.EndSignatureState = EndSignatureStateType.CertificateExpired Then
            lblEndCertificate.ForeColor = GetColorAccordingToState(SignaturesStateType.UnValid)
            Return My.Resources.InfoMessages.signatureViewlblTitleCertificateExpired
        ElseIf signInfo.EndSignatureState = EndSignatureStateType.SignatureUnvalid Then
            lblEndCertificate.ForeColor = GetColorAccordingToState(SignaturesStateType.UnValid)
            Return My.Resources.ControlStrings.signatureViewlbladUnValid
        ElseIf signInfo.EndSignatureState = EndSignatureStateType.Unchecked Then
            lblEndCertificate.ForeColor = GetColorAccordingToState(SignaturesStateType.Unchecked)
            Return My.Resources.ControlStrings.signatureViewlbllUnChecked
        ElseIf signInfo.EndSignatureState = EndSignatureStateType.NotCoverWholeDocument Then
            lblEndCertificate.ForeColor = GetColorAccordingToState(SignaturesStateType.Unchecked)
            lblEndCertificate.Font = New Font(lblEndCertificate.Font, FontStyle.Underline)
            Return My.Resources.ControlStrings.NotCoverWholeDocument
        Else 'Valid
            lblEndCertificate.ForeColor = GetColorAccordingToState(SignaturesStateType.Valid)
            Return My.Resources.ControlStrings.signatureViewlblChecked
        End If
    End Function

    'Return the CRL state name according to the language
    Private Function GetCRLstateName() As String
        If signInfo.CRLstate = CRLSignatureStateType.Revoked Then 'Revoked
            lblCRL.ForeColor = GetColorAccordingToState(SignaturesStateType.UnValid)
            Return My.Resources.ControlStrings.signatureViewlbladRevoked
        ElseIf signInfo.CRLstate = CRLSignatureStateType.Unknown Then 'Unvalid
            lblCRL.ForeColor = GetColorAccordingToState(SignaturesStateType.UnValid)
            Return My.Resources.InfoMessages.signatureViewlblTitleUnknown
        ElseIf signInfo.CRLstate = CRLSignatureStateType.Unchecked Then 'Unchecked
            lblCRL.ForeColor = GetColorAccordingToState(SignaturesStateType.Unchecked)
            Return My.Resources.ControlStrings.signatureViewlbllUnChecked
        Else 'Valid
            lblCRL.ForeColor = GetColorAccordingToState(SignaturesStateType.Valid)
            Return My.Resources.ControlStrings.signatureViewlblChecked
        End If
    End Function

    'Return the CRL state name according to the language
    Private Function GetChainSignatureStateName() As String
        If signInfo.ChainSignatureState = ChainSignatureStateType.Unvalid Then 'Unvalid
            lblChain.ForeColor = GetColorAccordingToState(SignaturesStateType.UnValid)
            Return My.Resources.ControlStrings.signatureViewlbladUnValid
        ElseIf signInfo.ChainSignatureState = ChainSignatureStateType.Unchecked Then 'Unchecked
            lblChain.ForeColor = GetColorAccordingToState(SignaturesStateType.Unchecked)
            Return My.Resources.ControlStrings.signatureViewlbllUnChecked
        Else 'Valid
            lblChain.ForeColor = GetColorAccordingToState(SignaturesStateType.Valid)
            Return My.Resources.ControlStrings.signatureViewlblChecked
        End If
    End Function



    'Return the time stamp status according to the status
    Private Function GetTimeStampStatus() As String
        If Not signInfo.TimeStampState Is Nothing AndAlso signInfo.TimeStampState.ResponseStatus = TimeStamp.TimeStampResponseStatus.Granted AndAlso signInfo.TimeStampState.ValidationErrors.Count = 0 Then
            lblTSState.ForeColor = GetColorAccordingToState(SignaturesStateType.Valid)
            Return My.Resources.InfoMessages.signatureViewlblTSGranted
        ElseIf signInfo.TimeStampState Is Nothing OrElse signInfo.TimeStampState.ResponseStatus = TimeStamp.TimeStampResponseStatus.Unchecked Then
            lblTSState.ForeColor = GetColorAccordingToState(SignaturesStateType.Unchecked)
            HideLabelsIfNeed()
            Return My.Resources.InfoMessages.signatureViewlblTSNotAdded
        Else
            lblTSState.ForeColor = GetColorAccordingToState(SignaturesStateType.UnValid)
            HideLabelsIfNeed()
            Return My.Resources.InfoMessages.signatureViewlblTSRejected
        End If
    End Function

    'Return the time stamp status according to the status
    Private Function GetSigningTime() As String
        If Not signInfo.TimeStampState Is Nothing AndAlso signInfo.TimeStampState.ResponseStatus = TimeStamp.TimeStampResponseStatus.Granted AndAlso signInfo.TimeStampState.ValidationErrors.Count = 0 Then
            Dim currentOffset As Integer = TimeZone.CurrentTimeZone.GetUtcOffset(signInfo.TimeStamp).Hours
            If currentOffset > 0 Then
                Return signInfo.TimeStamp.ToString + " (GMT+" + currentOffset.ToString() + ")"
            Else
                Return signInfo.TimeStamp.ToString + " (GMT" + currentOffset.ToString() + ")"
            End If

        Else
            Return String.Empty
        End If
    End Function

    Private Function GetColorAccordingToState(ByVal p_eSignaturesStateType As SignaturesStateType) As Color

        Select Case p_eSignaturesStateType
            Case SignaturesStateType.UnValid 'Red
                Return System.Drawing.Color.FromArgb(CType(CType(186, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(70, Byte), Integer))
            Case SignaturesStateType.Unchecked 'Yellow
                Return System.Drawing.Color.FromArgb(CType(CType(228, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(2, Byte), Integer))
                '                Return System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(68, Byte), Integer))
            Case SignaturesStateType.Valid 'Green
                Return System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(83, Byte), Integer))
        End Select

    End Function

#Region "Tool tip events"
    'Raise the tool tip for the EndCertificate
    Private Sub lblEndCertificate_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblEndCertificate.MouseHover
        SetEndCerificateToolTipMessage(lblEndCertificate, signInfo.EndSignatureState)
    End Sub


    'Hide the tool tip for the EndCertificate
    Private Sub lblEndCertificate_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblEndCertificate.MouseLeave
        toolTipState.Hide(lblEndCertificate)
    End Sub

    'Set the tool tip for the EndCertificate
    Private Sub SetEndCerificateToolTipMessage(control As Windows.Forms.Control, endSignatureState As EndSignatureStateType)
        Dim sMessage As String = String.Empty

        If endSignatureState = EndSignatureStateType.CertificateExpired Then
            sMessage = My.Resources.InfoMessages.signatureViewlblEndCertDate
            toolTipState.ToolTipTitle = My.Resources.InfoMessages.signatureViewlblTitleCertificateExpired
            toolTipState.ToolTipIcon = ToolTipIcon.Error
        ElseIf endSignatureState = EndSignatureStateType.SignatureUnvalid Then
            sMessage = My.Resources.InfoMessages.signatureViewlblEndCerUnvalid
            toolTipState.ToolTipTitle = My.Resources.InfoMessages.signatureViewlblTitleUnvalid
            toolTipState.ToolTipIcon = ToolTipIcon.Error
        ElseIf endSignatureState = EndSignatureStateType.Unchecked Then
            sMessage = My.Resources.InfoMessages.signatureViewlblEndCerUncheckd
            toolTipState.ToolTipTitle = My.Resources.InfoMessages.signatureViewlblTitleUnchecked
            toolTipState.ToolTipIcon = ToolTipIcon.Warning
        ElseIf endSignatureState = EndSignatureStateType.NotCoverWholeDocument Then
            sMessage = My.Resources.InfoMessages.signatureViewlblNotCoverWholeDocument
            toolTipState.ToolTipTitle = My.Resources.InfoMessages.signatureViewlblTitleNotCoverWholeDocument
            toolTipState.ToolTipIcon = ToolTipIcon.Warning
        Else 'Valid
            sMessage = My.Resources.InfoMessages.signatureViewlblEndCerValid
            toolTipState.ToolTipTitle = My.Resources.InfoMessages.signatureViewlblTitleValid
            toolTipState.ToolTipIcon = ToolTipIcon.Info
        End If

        toolTipState.SetToolTip(control, sMessage)

    End Sub


    'Raise the tool tip for the Chain state
    Private Sub lblChain_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblChain.MouseHover
        SetChainToolTipMessage()
    End Sub

    'Hide the tool tip for the CRL state
    Private Sub lblChain_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblChain.MouseLeave
        toolTipState.Hide(lblChain)
    End Sub


    'Set the tool tip for the Chain state
    Private Sub SetChainToolTipMessage()
        Dim sMessage As String = String.Empty

        If signInfo.ChainSignatureState = ChainSignatureStateType.Unvalid Then 'Unvalid
            sMessage = My.Resources.InfoMessages.signatureViewlblChainUnvalid
            toolTipState.ToolTipTitle = My.Resources.InfoMessages.signatureViewlblTitleUnvalid
            toolTipState.ToolTipIcon = ToolTipIcon.Error
        ElseIf signInfo.ChainSignatureState = ChainSignatureStateType.Unchecked Then 'Unchecked
            sMessage = My.Resources.InfoMessages.signatureViewlblChainUncheckd
            toolTipState.ToolTipTitle = My.Resources.InfoMessages.signatureViewlblTitleUnchecked
            toolTipState.ToolTipIcon = ToolTipIcon.Warning
        Else 'Valid
            sMessage = My.Resources.InfoMessages.signatureViewlblChainValid
            toolTipState.ToolTipTitle = My.Resources.InfoMessages.signatureViewlblTitleValid
            toolTipState.ToolTipIcon = ToolTipIcon.Info
        End If
        toolTipState.SetToolTip(lblChain, sMessage)

    End Sub


    'Raise the tool tip for the CRL state
    Private Sub lblCRL_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCRL.MouseHover
        SetCRLToolTipMessage(lblCRL, signInfo.CRLstate)
    End Sub


    'Hide the tool tip for the CRL state
    Private Sub lblCRL_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCRL.MouseLeave
        toolTipState.Hide(lblCRL)
    End Sub

    'Set the tool tip for the CRL state
    Private Sub SetCRLToolTipMessage(control As Windows.Forms.Control, cRLstate As CRLSignatureStateType)
        Dim sMessage As String = String.Empty

        If cRLstate = CRLSignatureStateType.Revoked Then 'Revoked
            sMessage = My.Resources.InfoMessages.signatureViewlblCRLUnvalid
            toolTipState.ToolTipTitle = My.Resources.ControlStrings.signatureViewlbladRevoked
            toolTipState.ToolTipIcon = ToolTipIcon.Error
        ElseIf cRLstate = CRLSignatureStateType.Unknown Then 'Unknown
            sMessage = My.Resources.InfoMessages.signatureViewlblCRLNotAbleToCheck
            toolTipState.ToolTipTitle = My.Resources.InfoMessages.signatureViewlblTitleUnknown
            toolTipState.ToolTipIcon = ToolTipIcon.Error
        ElseIf cRLstate = CRLSignatureStateType.Unchecked Then 'Unchecked
            sMessage = My.Resources.InfoMessages.signatureViewlblCRLUncheckd
            toolTipState.ToolTipTitle = My.Resources.InfoMessages.signatureViewlblTitleUnchecked
            toolTipState.ToolTipIcon = ToolTipIcon.Warning
        Else 'Valid
            sMessage = My.Resources.InfoMessages.signatureViewlblCRLValid
            toolTipState.ToolTipTitle = My.Resources.InfoMessages.signatureViewlblTitleValid
            toolTipState.ToolTipIcon = ToolTipIcon.Info
        End If
        toolTipState.SetToolTip(control, sMessage)

    End Sub

    'Raise the tool tip for the CRL state
    Private Sub lblTSState_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblTSState.MouseHover
        'SetTimeStampToolTipMessage()
    End Sub

    'Hide the tool tip for the CRL state
    Private Sub lblTSState_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblTSState.MouseLeave
        'toolTipState.Hide(lblTSState)
    End Sub


    'Set the tool tip for the timestamp state
    Private Sub SetTimeStampToolTipMessage()
        Dim sMessage As String = String.Empty
        If Not signInfo.TimeStampState Is Nothing AndAlso signInfo.TimeStampState.ResponseStatus = TimeStamp.TimeStampResponseStatus.Granted AndAlso signInfo.TimeStampState.ValidationErrors.Count = 0 Then
            sMessage = My.Resources.InfoMessages.signatureViewlblTSStateGranted
            toolTipState.ToolTipTitle = My.Resources.InfoMessages.signatureViewlblTSGranted
            toolTipState.ToolTipIcon = ToolTipIcon.Info
        ElseIf signInfo.TimeStampState Is Nothing OrElse signInfo.TimeStampState.ResponseStatus = TimeStamp.TimeStampResponseStatus.Unchecked Then
            sMessage = My.Resources.InfoMessages.signatureViewlblTSStateUnChecked
            toolTipState.ToolTipTitle = My.Resources.InfoMessages.signatureViewlblTSNotAdded
            toolTipState.ToolTipIcon = ToolTipIcon.Warning
        Else
            sMessage = My.Resources.InfoMessages.signatureViewlblTSStateRejection
            toolTipState.ToolTipTitle = My.Resources.InfoMessages.signatureViewlblTSRejected
            toolTipState.ToolTipIcon = ToolTipIcon.Error
        End If
        toolTipState.SetToolTip(lblTSState, sMessage)

    End Sub
#End Region




#End Region

#Region "Certeficate details"
    ''' <summary>
    ''' Show signer certeficate details.
    ''' </summary>
    Private Sub lblName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblName.Click
        Me.lblName.Cursor = Cursors.Default
        If Me.lblName.Text.Length > 0 Then
            If Not Certificate.DisplayCertificate(signInfo.certificate) Then
                Dim oErr As New P_ErrorTemplate(My.Resources.ErrorMessages.ShowCertHeader, My.Resources.ErrorMessages.ShowCert, False)
                oErr.ShowDialog()
            End If
        Else
            Dim oErr As New P_ErrorTemplate(My.Resources.ErrorMessages.ShowCertHeader, My.Resources.ErrorMessages.ShowCert, False)
            oErr.ShowDialog()
        End If
    End Sub

    ''' <summary>
    ''' This method shows hand cursur when mouse hovers the signature name.
    ''' </summary>
    Private Sub lblName_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblName.MouseHover
        Me.lblName.Cursor = Cursors.Hand
    End Sub

    ''' <summary>
    ''' This method hides the hand cursur when mouse leaves the signature name.
    ''' </summary>
    Private Sub lblName_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblName.MouseLeave
        Me.lblName.Cursor = Cursors.Default
    End Sub

#End Region

    Private Sub HideLabelsIfNeed()
        If m_DisplayTS = False Then
            lblTS.Visible = False
            lblTSLabel.Visible = False
            lblTSState.Visible = False
            lblTSStateLabel.Visible = False
            lblTSNameLabel.Visible = False
            lblTSName.Visible = False
            lblTSCert.Visible = False
            lblTSCertLabel.Visible = False
        End If
    End Sub

    Private Sub lblEndCertificate_Click(sender As System.Object, e As System.EventArgs) Handles lblEndCertificate.Click
        If lblEndCertificate.Text.Equals(My.Resources.ControlStrings.NotCoverWholeDocument) Then
            MessageBox.Show(My.Resources.ControlStrings.NotCoverWholeDocumentExplaination, My.Resources.InfoMessages.signatureViewlblTitleNotCoverWholeDocument, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub lblTSName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblTSName.Click
        Me.lblName.Cursor = Cursors.Default
        If Me.lblName.Text.Length > 0 Then
            If Not Certificate.DisplayCertificate(signInfo.TimeStampCertificate) Then
                Dim oErr As New P_ErrorTemplate(My.Resources.ErrorMessages.ShowCertHeader, My.Resources.ErrorMessages.ShowCert, False)
                oErr.ShowDialog()
            End If
        Else
            Dim oErr As New P_ErrorTemplate(My.Resources.ErrorMessages.ShowCertHeader, My.Resources.ErrorMessages.ShowCert, False)
            oErr.ShowDialog()
        End If
    End Sub

    Private Sub SetCertStatus(TimeStampState As TimeStamp.TimeStampResponseState)

        Dim state As SignaturesStateType = TimeStamp.Utils.GetTSCertGlobalStatus(TimeStampState)

        Select Case state
            Case SignaturesStateType.Unchecked
                lblTSCert.Text = My.Resources.ControlStrings.signatureViewlblIsSignNoCheck
                lblTSCert.ForeColor = GetColorAccordingToState(SignaturesStateType.Unchecked)
            Case SignaturesStateType.UnValid
                lblTSCert.Text = My.Resources.InfoMessages.signatureViewlblTSRejected
                lblTSCert.ForeColor = GetColorAccordingToState(SignaturesStateType.UnValid)
            Case SignaturesStateType.Unknow
                lblTSCert.Text = My.Resources.InfoMessages.signatureViewlblTitleUnknown
                lblTSCert.ForeColor = GetColorAccordingToState(SignaturesStateType.Unknow)
            Case SignaturesStateType.Valid
                lblTSCert.Text = My.Resources.ControlStrings.signatureViewlblChecked
                lblTSCert.ForeColor = GetColorAccordingToState(SignaturesStateType.Valid)
        End Select
        Dim crlState As CRLSignatureStateType = TimeStamp.Utils.GetTSCrlGlobalStatus(TimeStampState)
        If state <> SignaturesStateType.Valid AndAlso crlState = CRLSignatureStateType.Valid Then
            toolTipState.SetToolTip(lblTSCert, My.Resources.InfoMessages.certificateNotValidOrUnchecked)
        ElseIf crlState <> CRLSignatureStateType.Valid Then
            SetCRLToolTipMessage(lblTSCert, crlState)
        Else
            toolTipState.SetToolTip(lblTSCert, My.Resources.ControlStrings.signatureViewlblChecked)
        End If

    End Sub

End Class
