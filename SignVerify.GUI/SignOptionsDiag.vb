Imports System.Windows.Forms
Imports System.Security.Cryptography.X509Certificates
Imports SignVerify.MainComponent
Imports SignVerify.Common
Imports SignVerify.Profils
Imports System.IO
Imports System.ComponentModel

Public Class SignOptionsDiag

#Region "privates members"

    'the general sign&verify provider
    Private provider As SignVerifyProvider

    'the temp destination folder
    Private tempDestinationFolder As String = ""

    'the registy options handle
    Private myCustomProfil As RegistryProfil

    'The last picture box selected for getting info
    Private LastSelectedPicture As PictureBox

    Private originalProvider As String


    'the selected profil 
    Private ReadOnly Property myProfil() As Profil
        Get
            If provider.registryProfil.SelectedProfil <> "" AndAlso provider.LoadedProfils.ContainsKey(provider.registryProfil.SelectedProfil) Then
                Return provider.LoadedProfils(provider.registryProfil.SelectedProfil)
            Else
                Return provider.registryProfil
            End If
        End Get
    End Property

    'the selected certificate
    Public selectedCertificate As X509Certificate2

    'the selected profil
    Public selectedProfil As Profil

    'the selected coSignType
    Public selectedCoSignType As CoSignType

    'the signed object
    Private signedObject As CryptoSignedObject(Of Byte())

    'if the diag for cosign
    Private isCosign As Boolean

    'the custom profile name
    Private customProfileName As String = "My Profile"

    Private cbShowSignOptionsEnabled As Boolean = True
#End Region

#Region "Constructor"

    'diag constructor for signing
    Public Sub New(ByVal provider As SignVerifyProvider, Optional ByVal isCosign As Boolean = False)

        'init variables
        InitializeComponent()

        InitLocalTextual()

        Me.provider = provider
        Me.myCustomProfil = provider.registryProfil
        Me.isCosign = isCosign
        Me.signedObject = Nothing



        If isCosign Then
            Dim iHeight As Integer = Screen.PrimaryScreen.WorkingArea.Height
            Dim iWidth As Integer = Screen.PrimaryScreen.WorkingArea.Width

            If iHeight < 650 AndAlso iWidth < 900 Then
                Me.Size = New Point(Me.Width, iHeight - 40)
                Me.AutoScroll = True
            Else
                Me.AutoScroll = False
            End If

            'display the cosigning options
            pnlCosignOptions.Visible = True
            Me.Height = Me.Height
        Else
            'hide the cosigning options
            Me.Height = Me.Height - pnlCosignOptions.Size.Height
            pnlCosignOptions.Visible = isCosign
        End If
    End Sub

    'diag constructor for cosigning
    Public Sub New(ByVal provider As SignVerifyProvider, ByVal signedObject As CryptoSignedObject(Of Byte()))

        Me.New(provider, True)
        Me.signedObject = signedObject



    End Sub

    'on diag load
    Private Sub SignOptionsDiag_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RemoveHandler ddlProfils.SelectedIndexChanged, AddressOf ddlProfils_SelectedIndexChanged
        'bind the folders options
        bindFolder()
        bindSavingType()

        Me.cbShowSignOptions.Visible = Not Me.isCosign

        'bind show the sign option
        cbShowSignOptionsEnabled = False
        cbShowSignOptions.Checked = Not (myCustomProfil.ShowSignOption)
        cbShowSignOptionsEnabled = True

        'bind the certificate list
        bindCertificates()

        'bind the profils list
        bindProfils()

        'bind the cosign options
        bindCosignOptions()

        SetTooltiControls()

        AddHandler ddlProfils.SelectedIndexChanged, AddressOf ddlProfils_SelectedIndexChanged

    End Sub

#End Region

#Region "controls binding"

    'bind the set tooltip controls
    Private Sub SetTooltiControls()

        Me.ToolTip1.SetToolTip(Me.Cancel_Button, My.Resources.InfoMessages.SignOptionCancel)
        Me.ToolTip1.SetToolTip(Me.OK_Button, My.Resources.InfoMessages.SignOptionSign)
        Me.ToolTip1.SetToolTip(Me.btnBrowseDestinationFile, My.Resources.InfoMessages.SaveFileBrowse)
        Me.ToolTip1.SetToolTip(Me.btnOpenCertDiag, My.Resources.InfoMessages.SignOptionOpenCert)
        Me.ToolTip1.SetToolTip(Me.lnklblProfile, My.Resources.InfoMessages.ShowProfile)
        Me.ToolTip1.SetToolTip(Me.lnklblHistory, My.Resources.InfoMessages.successOpenSignatureStatus)
        Me.ToolTip1.SetToolTip(Me.lnkOpenOriginalFile, My.Resources.InfoMessages.successOpenOriginalFile)
        Me.ToolTip1.SetToolTip(Me.picboxCertificateIcon, My.Resources.InfoMessages.OptionShowCerteficate)
        Me.ToolTip1.SetToolTip(Me.lblCertificateName, My.Resources.InfoMessages.OptionShowCerteficate)
    End Sub

    'bind the folders options
    Private Sub bindFolder()
        RadioSame.Checked = myCustomProfil.AutoDestinationFolder
        RadioDifferent.Checked = Not RadioSame.Checked
        tempDestinationFolder = myCustomProfil.DestinationFolder
        checkRadio()
    End Sub

    'bind the saving type options
    Private Sub bindSavingType()
        'if the saving type doesn't part of the selected profil use the registry option
        If myProfil.SavingType Is Nothing Or myProfil.GetType Is GetType(RegistryProfil) Then
            ddlSavingType.SelectedIndex = CType(myCustomProfil.SavingType, Integer)
            ddlSavingType.Enabled = True
        Else
            'if the saving type is part of the selected profil use it and lock the option
            ddlSavingType.SelectedIndex = CType(myProfil.SavingType, Integer)
            ddlSavingType.Enabled = False
        End If

    End Sub

    'bind the certificate controls
    Private Sub bindCertificates()
        Dim CertCount As Integer = 0

        'get the certificates collection
        Dim certColl As X509Certificate2Collection = Certificate.GetSignCertificateCollection(myProfil.ShowOnlyNonRepudiation)
        CertCount = certColl.Count


        'if is the first load
        If Me.selectedCertificate Is Nothing Then
            If certColl.Count = 1 Then
                Me.selectedCertificate = certColl(0)

                If Not IsCardConnected() Then
                    Me.selectedCertificate = Nothing
                End If

            End If
        End If


        If Not Me.selectedCertificate Is Nothing Then
            'one certificate found or the certificate already selected
            lblCertificateName.Text = Certificate.getSignCertificateName(Me.selectedCertificate)
            lblCertificateName.RightToLeft = Windows.Forms.RightToLeft.No
            plCertificateName.Visible = True
            plCertificateName.Location = New Point(128, 53)
            lblManyCertificates.Visible = False
            lblNoCertificate.Visible = False
            pnlErrorMessage.Visible = False
            btnOpenCertDiag.Visible = CertCount > 1
            If CertCount > 1 Then
                lblChooseCert.Text = My.Resources.ControlStrings.SignOptionOneCertificate
            End If
            lblCertificateName.Location = New Point(picboxCertificateIcon.Location.X - lblCertificateName.Width - 5, picBoxCertificate.Location.Y + 5)
            OK_Button.Enabled = True
        ElseIf CertCount > 1 Then
            'many certificates found
            If Not myCustomProfil.LastCertificateSN = String.Empty Then
                pnlErrorMessage.Visible = False
                Me.selectedCertificate = Certificate.GetSignCertificateBySerialNumber(myCustomProfil.LastCertificateSN, myCustomProfil.ShowOnlyNonRepudiation)
                If Not IsCardConnected() Then
                    myCustomProfil.LastCertificateSN = String.Empty
                    bindCertificates()
                    Exit Sub
                End If
                lblCertificateName.Text = Certificate.getSignCertificateName(selectedCertificate)
                plCertificateName.Visible = True
                plCertificateName.Location = New Point(128, 53)
                lblManyCertificates.Visible = False
                lblNoCertificate.Visible = False
                btnOpenCertDiag.Visible = CertCount > 1
                lblChooseCert.Text = My.Resources.ControlStrings.SignOptionlblChooseCert
                lblCertificateName.Location = New Point(picboxCertificateIcon.Location.X - lblCertificateName.Width - 5, picBoxCertificate.Location.Y + 5)
                OK_Button.Enabled = True
            Else
                pnlErrorMessage.Visible = True
                pnlErrorMessage.Location = New Point(142, 53)
                plCertificateName.Visible = False
                lblManyCertificates.Visible = True
                lblNoCertificate.Visible = False
                btnOpenCertDiag.Visible = True
                OK_Button.Enabled = False
                lblChooseCert.Text = My.Resources.ControlStrings.SignOptionlblChooseCert
            End If
        ElseIf CertCount = 0 Then
            'no certificate found
            pnlErrorMessage.Visible = True
            pnlErrorMessage.Location = New Point(pnlErrorMessage.Location.X, 53)
            plCertificateName.Visible = False
            lblManyCertificates.Visible = False
            lblNoCertificate.Visible = True
            btnOpenCertDiag.Visible = False
            OK_Button.Enabled = False
            lblChooseCert.Text = My.Resources.ControlStrings.SignOptionlblChooseCert
        End If
        Me.Refresh()
    End Sub

    'bind the profils list
    Private Sub bindProfils()
        If provider.LoadedProfils.Count = 0 Then
            Dim defaultProf As New XmlProfil
            defaultProf.FriendlyName = "Default"
            defaultProf.Save(provider.profilsDirectory & "\default.xml")
            provider.LoadedProfils.Add(defaultProf.FriendlyName, defaultProf)
        End If

        Dim dataProfils As New List(Of DictionaryEntry)
        For Each prof As Profil In provider.LoadedProfils.Values
            dataProfils.Add(New DictionaryEntry(prof.FriendlyName, prof))
        Next
        dataProfils.Add(New DictionaryEntry(customProfileName, myCustomProfil))
        ddlProfils.DataSource = dataProfils

        ddlProfils.DisplayMember = "key"
        ddlProfils.ValueMember = "Value"
        originalProvider = myProfil.ProviderName
        If myProfil.FriendlyName = customProfileName Then ' .isEqual(myCustomProfil) Then
            ddlProfils.SelectedIndex = (ddlProfils.FindStringExact(customProfileName))
        Else
            ddlProfils.SelectedIndex = (ddlProfils.FindStringExact(myCustomProfil.SelectedProfil))
        End If

        'select the default if no one selected
        If ddlProfils.SelectedIndex = -1 Then
            ddlProfils.SelectedIndex = 0
        End If
        If Me.myProfil.ProviderName = Constants.PDFFriendlyName Then
            btnAdvancedSettings.Visible = True
        Else
            btnAdvancedSettings.Visible = False

        End If

    End Sub


    'bind the cosign options
    Public Sub bindCosignOptions()
        If Me.isCosign Then
            lnklblHistory.Visible = Not Me.signedObject Is Nothing
            lnkOpenOriginalFile.Visible = Not Me.signedObject Is Nothing
            lblSep.Visible = Not Me.signedObject Is Nothing
        End If
    End Sub

#End Region

#Region "folder options"

    'on folder radio change
    Private Sub RadioDifferent_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioDifferent.CheckedChanged
        checkRadio()
    End Sub

    'on folder radio same folder.
    Private Sub RadioSame_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioSame.CheckedChanged
        checkRadio()
    End Sub

    'on browse for destionation folder clicked
    Private Sub btnBrowseDestinationFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowseDestinationFile.Click
        If FolderBrowserSaveSigned.ShowDialog() = Windows.Forms.DialogResult.OK Then
            tbDestinationFolder.Text = FolderBrowserSaveSigned.SelectedPath
            tempDestinationFolder = FolderBrowserSaveSigned.SelectedPath
        End If
    End Sub

    'check the radio state and ste the label and text box accordingly 
    Private Sub checkRadio()
        btnBrowseDestinationFile.Enabled = RadioDifferent.Checked
        If RadioDifferent.Checked Then
            tbDestinationFolder.BackColor = Color.White
            tbDestinationFolder.Text = tempDestinationFolder
        Else
            tbDestinationFolder.BackColor = Color.LightGray
            tbDestinationFolder.Text = ""
        End If
    End Sub

#End Region

#Region "certificate options"

    'on refresh list clicked
    Private Sub btnOpenCertDiag_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenCertDiag.Click
        'open certificates dialog
        Me.selectedCertificate = Certificate.GetSignCertificate(True, myProfil.ShowOnlyNonRepudiation)

        'bind the certificate controls
        bindCertificates()
    End Sub

    'on certificate double click ( view it )
    Private Sub picboxCertificateIcon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxCertificateIcon.Click
        Certificate.showSelectedCertificate(Me.selectedCertificate.SerialNumber)
    End Sub
    'on certificate double click ( view it )
    Private Sub lblCertificateName_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCertificateName.Click
        Certificate.showSelectedCertificate(Me.selectedCertificate.SerialNumber)
    End Sub

    'show mouse hand when mouse hover the certificate picture box 
    Private Sub picboxCertificateIcon_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxCertificateIcon.MouseHover
        Me.picboxCertificateIcon.Cursor = Cursors.Hand
    End Sub

    'show mouse hand when mouse hover the certificate label
    Private Sub lblCertificateName_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCertificateName.MouseHover
        Me.lblCertificateName.Cursor = Cursors.Hand
    End Sub

    'hide mouse hand when mouse leaves the certificate picture box 
    Private Sub picboxCertificateIcon_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxCertificateIcon.MouseLeave
        Me.picboxCertificateIcon.Cursor = Cursors.Default
    End Sub

    'hide mouse hand when mouse leaves the certificate label
    Private Sub lblCertificateName_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCertificateName.MouseLeave
        Me.lblCertificateName.Cursor = Cursors.Default
    End Sub

    ''' <summary>
    ''' check if the selected card is connected.
    ''' </summary>
    ''' <returns>True - if the card is connected. False - otherwise.</returns>
    Private Function IsCardConnected() As Boolean
        Dim bIsCardConnected As Boolean = False
        If selectedCertificate Is Nothing Then
            myCustomProfil.LastCertificateSN = String.Empty
            myCustomProfil.save()
            Return False
        End If
        If selectedCertificate.HasPrivateKey Then
            Try
                Dim sAlg As String = selectedCertificate.PrivateKey.SignatureAlgorithm 'CardServices.CheckIfOnlyCardInReader()
                bIsCardConnected = True
            Catch ex As Exception
                Logger.Instance.Error("IsCardConnected failed", ex)
                myCustomProfil.LastCertificateSN = String.Empty
                myCustomProfil.save()
                bIsCardConnected = False
            End Try
        End If
        Return bIsCardConnected
    End Function
#End Region

#Region "Cosigning options"

    'view original file
    Private Sub lnkOpenOriginalFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkOpenOriginalFile.Click
        Dim filename As String = signedObject.ContentInfo.originalFileName
        Try
            Dim signedOjb As CryptoSignedObject(Of Byte()) = CType(signedObject, CryptoSignedObject(Of Byte()))
            Dim sSavedFile As String = Path.GetFullPath(Path.GetDirectoryName(Path.GetTempPath()))
            sSavedFile += "\" & filename
            File.WriteAllBytes(sSavedFile, signedOjb.ContentInfo.originalContent)
            Dim oInfo As ProcessStartInfo = New ProcessStartInfo()
            oInfo.FileName = sSavedFile
            oInfo.ErrorDialog = True
            Process.Start(oInfo)
        Catch ex As Exception
            Logger.Instance.Error(ex)
        End Try
    End Sub

    'this method show hand when the mouse hovers the label
    Private Sub lnkOpenOriginalFile_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkOpenOriginalFile.MouseHover
        Me.lnkOpenOriginalFile.Cursor = Cursors.Hand
    End Sub

    'show the signatures history
    Private Sub lnklblHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnklblHistory.Click
        Dim signHistoryDiag As New SignaturesHistory(signedObject, selectedProfil.DisplayTimeStamp)
        signHistoryDiag.ShowDialog()
    End Sub

    'this method show hand when the mouse hovers the label
    Private Sub lnklblHistory_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnklblHistory.MouseHover
        Me.lnklblHistory.Cursor = Cursors.Hand
    End Sub
#End Region

#Region "ok cancel buttons"

    'on ok button clicked
    Private Sub OK_Button_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim canContinue As Boolean = True
        'Check CSP version
        ' CheckCSPVersionExists()
        If originalProvider <> Constants.PDFFriendlyName AndAlso CType(ddlProfils.SelectedValue, Profil).ProviderName = Constants.PDFFriendlyName Then
            Dim diag As ChangeToPdf = New ChangeToPdf(My.Resources.ControlStrings.MoveToPdfQuestion, My.Resources.ControlStrings.MoveToPdfTitle)
            If diag.ShowDialog() <> Windows.Forms.DialogResult.Yes Then
                canContinue = False
            End If
        End If

        If canContinue Then

            'Check if the selected certeficate has private key if not and check if we can access it (if not the card is disconnnected)
            Dim bIsCardConnected As Boolean = False
            If selectedCertificate.HasPrivateKey Then
                Try
                    Dim sAlg As String = selectedCertificate.PrivateKey.SignatureAlgorithm 'CardServices.CheckIfOnlyCardInReader()
                    bIsCardConnected = True
                Catch ex As Exception
                    Logger.Instance.Error("certeficate private key does not exist", ex)
                    myCustomProfil.LastCertificateSN = String.Empty
                    myCustomProfil.save()
                    bIsCardConnected = False
                End Try
            End If
            ''if no certificate selected
            If selectedCertificate Is Nothing OrElse Not bIsCardConnected Then
                Dim errorDiag As New errorDiag(My.Resources.ErrorMessages.selectCertificate, My.Resources.ErrorMessages.CertificateHeader)
                errorDiag.ShowDialog()
                Exit Sub
            End If

            myCustomProfil.DestinationFolder = tempDestinationFolder
            myCustomProfil.AutoDestinationFolder = RadioSame.Checked
            myCustomProfil.LastCertificateSN = Me.selectedCertificate.SerialNumber
            myCustomProfil.ShowSignOption = Not (cbShowSignOptions.Checked)
            If ddlSavingType.Enabled Then
                myCustomProfil.SavingType = SavingTypes.Parse(GetType(SavingTypes), ddlSavingType.SelectedIndex)
            End If
            myCustomProfil.save()

            Me.DialogResult = System.Windows.Forms.DialogResult.OK

            'set the selected profil
            Me.selectedProfil = ddlProfils.SelectedValue


            'set the cosign type 
            If isCosign Then
                If radioParallel.Checked Then
                    selectedCoSignType = CoSignType.Parallel
                ElseIf radioSerial.Checked Then
                    selectedCoSignType = CoSignType.OverSignature
                End If
            End If
        End If

    End Sub

    'on cancel button clicked
    Private Sub Cancel_Button_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
#End Region

#Region "Show option dialog"

    ''' <summary>
    ''' This method activate the option to see or hide the sign option screen.
    ''' </summary>
    Private Sub cbShowSignOptions_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbShowSignOptions.CheckedChanged
        If cbShowSignOptionsEnabled Then
            If cbShowSignOptions.Checked Then
                Dim oShowSignOption As New ShowSignOptionDiag()
                oShowSignOption.ShowDialog()
            End If
            myCustomProfil.ShowSignOption = Not (cbShowSignOptions.Checked)
        End If
    End Sub

#End Region

#Region "NOT IN USE : Check CSP"
    ''' <summary>
    ''' Checks if the correct CSP version is installed.
    ''' Not IN USE
    ''' </summary>
    Public Shared Function CheckCSPVersionExists() As Boolean
        Dim bIsInstalled As Boolean = False

        If File.Exists("C:\WINDOWS\system32\SC2CSP.dll") Then
            Dim oFileVersionInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo("C:\WINDOWS\system32\SC2CSP.dll")
            Dim iMajor As Integer = oFileVersionInfo.FileMajorPart
            Dim iMajorVersion As Integer = oFileVersionInfo.FileMinorPart
            Dim iMinor As Integer = oFileVersionInfo.FileBuildPart
            Dim iMinorVersion As Integer = oFileVersionInfo.FilePrivatePart

            If iMajor = 0 AndAlso iMajorVersion = 4 AndAlso ((iMinor = 3 AndAlso iMinorVersion >= 0) OrElse (iMinor = 2 AndAlso iMinorVersion >= 7)) Then
                Return True 'Version OK
            Else
                bIsInstalled = True 'the CSP version is from an old version need to upgrade
            End If
        Else
            bIsInstalled = False 'the CSP version is not installed
        End If

        Dim oCSPVersion As New InstallCSP(bIsInstalled)
        oCSPVersion.ShowDialog()
        Return False
    End Function

#End Region

#Region "Init Textual"
    'this method sets the label according to the selected language
    Private Sub InitLocalTextual()

        'set form header 
        Me.Text = My.Resources.ControlStrings.SignOptionForm

        ' Set labels
        Me.lblChooseCert.Text = My.Resources.ControlStrings.SignOptionlblChooseCert
        Me.lblChooseCosign.Text = My.Resources.ControlStrings.SignOptionlblChooseCosign
        Me.lblChooseHeader.Text = My.Resources.ControlStrings.SignOptionlblChooseHeader
        Me.lblHeader.Text = My.Resources.ControlStrings.SignOptionlblHeader
        Me.lblManyCertificates.Text = My.Resources.ControlStrings.SignOptionlblManyCertificates
        Me.lblNoCertificate.Text = My.Resources.ControlStrings.SignOptionlblNoCertificate
        Me.lblSelectProfile.Text = My.Resources.ControlStrings.SignOptionlblSelectProfile
        Me.lblParallel.Text = My.Resources.ControlStrings.SignOptionlblParallel
        Me.lblSerial.Text = My.Resources.ControlStrings.SignOptionlblSerial
        Me.lnklblProfile.Text = My.Resources.ControlStrings.OptionDiaglblProfile
        Me.lblSavingType.Text = My.Resources.ControlStrings.SignOptionlblSavingType

        ' set radio button text
        Me.RadioDifferent.Text = My.Resources.ControlStrings.SignOptionRadioDifferent
        Me.RadioSame.Text = My.Resources.ControlStrings.SignOptionRadioSame
        Me.radioSerial.Text = My.Resources.ControlStrings.SignOptionradioSerial
        Me.radioParallel.Text = My.Resources.ControlStrings.SignOptionradioParallel

        ' set button text
        Me.btnBrowseDestinationFile.Text = My.Resources.ControlStrings.SignOptionbtnBrowseDestinationFile
        Me.btnOpenCertDiag.Text = My.Resources.ControlStrings.SignOptionbtnOpenCertDiag
        Me.lnkOpenOriginalFile.Text = My.Resources.ControlStrings.SignOptionbtnOpenOriginalFile
        Me.lnklblHistory.Text = My.Resources.ControlStrings.SignOptionbtnbtnSignsHistory
        Me.Cancel_Button.Text = My.Resources.ControlStrings.SignOptionCancel_Buttone
        Me.OK_Button.Text = My.Resources.ControlStrings.SignOptionOK_Button
        Me.btnAdvancedSettings.Text = My.Resources.ControlStrings.btnAdvancedSettings_Button
        'Set check box
        Me.cbShowSignOptions.Text = My.Resources.ControlStrings.DontShowSignOption

        ''Set tool tip messages
        Me.tipQuestionMark.SetToolTip(Me.picboxSaveFile, My.Resources.InfoMessages.picboxSaveFile)
        Me.tipQuestionMark.SetToolTip(Me.picBoxCertificate, My.Resources.InfoMessages.picBoxCertificate)
        Me.tipQuestionMark.SetToolTip(Me.picBoxCosign, My.Resources.InfoMessages.picBoxCosign)
        Me.tipQuestionMark.SetToolTip(Me.picBoxProfile, My.Resources.InfoMessages.picBoxProfile)

    End Sub
#End Region

#Region "Tool tip events"
    'tool tip message when save file picture box is clicked
    Private Sub picboxSaveFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxSaveFile.Click
        LastSelectedPicture = picboxSaveFile
        tipQuestionMark.Hide(LastSelectedPicture)
        tipQuestionMark.Show(My.Resources.InfoMessages.picboxSaveFile, picboxSaveFile, _
                             picboxSaveFile.Location.X + picboxSaveFile.Size.Width - 3, _
                             picboxSaveFile.Location.Y + picboxSaveFile.Size.Height - 3, 5000)

    End Sub

    'tool tip message hidden when mouse leaves the control
    Private Sub picboxSaveFile_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxSaveFile.MouseLeave
        tipQuestionMark.Hide(picboxSaveFile)
    End Sub

    'tool tip message when certificate picture box is clicked
    Private Sub picBoxCertificate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picBoxCertificate.Click
        LastSelectedPicture = picBoxCertificate
        tipQuestionMark.Hide(LastSelectedPicture)
        tipQuestionMark.Show(My.Resources.InfoMessages.picBoxCertificate, picBoxCertificate, _
                             New Point(picBoxCertificate.Location.X + picBoxCertificate.Size.Width - 3, _
                                       picBoxCertificate.Location.Y + picBoxCertificate.Size.Height - 3), 5000)
    End Sub

    'tool tip message hidden when mouse leaves the control
    Private Sub picBoxCertificate_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picBoxCertificate.MouseLeave
        tipQuestionMark.Hide(picBoxCertificate)
    End Sub

    'tool tip  message when profile picture box is clicked
    Private Sub picBoxProfile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picBoxProfile.Click
        LastSelectedPicture = picBoxProfile
        tipQuestionMark.Hide(LastSelectedPicture)
        tipQuestionMark.Show(My.Resources.InfoMessages.picBoxProfile, picBoxProfile, _
                             New Point(picBoxProfile.Location.X + picBoxProfile.Size.Width - 3, _
                                       picBoxProfile.Location.Y + picBoxProfile.Size.Height - 3), 5000)
    End Sub

    'tool tip  message when profile picture box is clicked
    Private Sub picBoxProfile_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picBoxProfile.MouseLeave
        tipQuestionMark.Hide(picBoxProfile)
    End Sub

    'tool tip message when cosign picture box is clicked
    Private Sub picBoxCosign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picBoxCosign.Click
        LastSelectedPicture = picBoxCosign
        tipQuestionMark.Hide(LastSelectedPicture)
        tipQuestionMark.Show(My.Resources.InfoMessages.picBoxCosign, picBoxCosign, _
                             New Point(picBoxCosign.Location.X + picBoxCosign.Size.Width - 3, _
                                       picBoxCosign.Location.Y + picBoxCosign.Size.Height - 3), 5000)
    End Sub

    'tool tip message when cosign picture box is clicked
    Private Sub picBoxCosign_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picBoxCosign.MouseLeave
        tipQuestionMark.Hide(picBoxCosign)
    End Sub
#End Region

#Region "Help"
    'show help file
    Private Sub HelpToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HelpToolStripButton.Click
        Dim Dir As New IO.DirectoryInfo(System.IO.Path.GetDirectoryName(Application.ExecutablePath))
        Dim Files() As FileInfo = Dir.GetFiles("SignVerifyUserGuide.chm", SearchOption.AllDirectories)
        If Files.Length = 1 Then
            Dim sCHMPath As String = Files(0).FullName
            If Me.isCosign Then
                Help.ShowHelp(Me, sCHMPath, "advanced_cosign.html")
            Else 'unsigned file
                Help.ShowHelp(Me, sCHMPath, "sign.html")
            End If

        End If
    End Sub
#End Region

#Region "Profile"
    'When changeing the regisitry profile
    Private Sub ddlProfils_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlProfils.SelectedIndexChanged
        provider.registryProfil.SelectedProfil = CType(ddlProfils.SelectedItem, DictionaryEntry).Key.ToString
        If provider.registryProfil.SelectedProfil <> customProfileName AndAlso provider.LoadedProfils().Item(provider.registryProfil.SelectedProfil).ProviderName = Constants.PDFFriendlyName Then
            btnAdvancedSettings.Visible = True
        Else
            btnAdvancedSettings.Visible = False
        End If
        bindSavingType()
        bindCertificates()
    End Sub
    'this method opens the selected profile in  the option dialog
    Private Sub lnklblProfile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnklblProfile.Click
        Dim oOptionDiag As New OptionsDiag(provider)

        If oOptionDiag.ShowDialog() = Windows.Forms.DialogResult.OK Then
            'need to relaod the profile
            myCustomProfil = oOptionDiag.GetRegistryProfile
            customProfileName = myCustomProfil.SelectedProfil
            If myProfil.FriendlyName = "My Profile" Then
                ddlProfils.SelectedIndex = (ddlProfils.FindStringExact(customProfileName))
            Else
                ddlProfils.SelectedIndex = (ddlProfils.FindStringExact(myCustomProfil.SelectedProfil))
            End If
        End If
    End Sub

    'this method show hand when the mouse hovers the label
    Private Sub lnklblProfile_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnklblProfile.MouseHover
        Me.lnklblProfile.Cursor = Cursors.Hand
    End Sub
#End Region

    
    Private Sub btnAdvancedSettings_Click(sender As System.Object, e As System.EventArgs) Handles btnAdvancedSettings.Click
        Dim signDiag As PdfAdvancedSettingsDiag = New PdfAdvancedSettingsDiag(myCustomProfil)
        If signDiag.ShowDialog(Me) = DialogResult.OK Then

        End If
    End Sub
End Class
