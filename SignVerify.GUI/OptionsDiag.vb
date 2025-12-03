Imports System.Windows.Forms
Imports System.Security.Cryptography.X509Certificates
Imports SignVerify.MainComponent
Imports SignVerify.Common
Imports SignVerify.Profils
Imports System.IO
Imports SignVerify.Profils.Profil

Public Class OptionsDiag

#Region "privates members"

    'the general sign&verify provider
    Private provider As SignVerifyProvider

    'the registy options handle
    Private myCustomProfil As RegistryProfil

    'the temp destination folder
    Private tempDestinationFolder As String = ""

    'if the form rendering ended
    Private renderingEnded As Boolean = False

    'the custom profile name
    Private customProfileName As String = "My Profile"

    'The selected help picture box
    Private LastSelectedPicture As PictureBox

    Private startProviderName As String

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

#End Region

#Region "Property"
    ''' <summary>
    ''' returns the registry profile.
    ''' </summary>
    ''' <returns>the  registry profile.</returns>
    Friend ReadOnly Property GetRegistryProfile() As RegistryProfil
        Get
            Return myCustomProfil
        End Get
    End Property

#End Region

#Region "constructor"

    'diag constructor
    Public Sub New(ByVal provider As SignVerifyProvider)

        'init variables
        InitializeComponent()
        InitRegionTextual()

        Me.provider = provider
        Me.myCustomProfil = provider.registryProfil

    End Sub
    'Loading the labels and profiles
    Public Sub OptionsSignDiag_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        renderingEnded = False

        Dim iHeight As Integer = Screen.PrimaryScreen.WorkingArea.Height
        Dim iWidth As Integer = Screen.PrimaryScreen.WorkingArea.Width

        If iHeight < 650 AndAlso iWidth < 900 Then
            Me.Size = New Point(Me.Width + 17, iHeight - 40)
            Me.AutoScroll = True
        Else
            Me.AutoScroll = False
        End If

        SetTooltipButton()

        'bind profils
        bindProfils()

        'bind options
        bindOptions()

        renderingEnded = True
    End Sub

#End Region

#Region "controls binding"

    'bind all options
    Private Sub bindOptions()

        'general
        bindFolder()
        bindSavingType()

        'sign
        bindProviders()
        bindHashAlgo()
        bindTSURL()

        RemoveHandler cbShowOnlyNonRepudiation.CheckedChanged, AddressOf cbShowOnlyNonRepudiation_CheckedChanged
        cbShowOnlyNonRepudiation.Checked = myProfil.ShowOnlyNonRepudiation
        AddHandler cbShowOnlyNonRepudiation.CheckedChanged, AddressOf cbShowOnlyNonRepudiation_CheckedChanged

        cbCheckTimeStamp.Checked = myProfil.CheckTimeStamp


        'verify
        cbVerifySignatureOnly.Checked = myProfil.CheckCertificationPath
        cbCheckCRL.Checked = myProfil.CheckCRL
        cbShowSignOptions.Checked = myCustomProfil.ShowSignOption
        cbDisplayTimeStamp.Checked = myProfil.DisplayTimeStamp

        Dim sFriendlyName As String = CType(ddlProfils.SelectedItem, DictionaryEntry).Key
        If sFriendlyName = customProfileName Then
            unlockOptions()
        Else
            lockOptions()
        End If

    End Sub

    'bind the set tooltip button
    Private Sub SetTooltipButton()

        Me.ToolTip1.SetToolTip(Me.Cancel_Button, My.Resources.InfoMessages.OptionNotSaveSetting)
        Me.ToolTip1.SetToolTip(Me.OK_Button, My.Resources.InfoMessages.OptionSaveSetting)
        Me.ToolTip1.SetToolTip(Me.btnBrowseDestinationFile, My.Resources.InfoMessages.SaveFileBrowse)

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

    'bind providers
    Private Sub bindProviders()
        Dim dataProviders As New List(Of DictionaryEntry)
        For Each prov As Common.IBaseCryptoProvider In provider.LoadedPlugins.Values
            dataProviders.Add(New DictionaryEntry(prov.ProviderFriendlyName, prov))
        Next
        ddlProviders.DataSource = dataProviders
        ddlProviders.DisplayMember = "key"
        ddlProviders.ValueMember = "Value"
        ddlProviders.SelectedIndex = (ddlProviders.FindStringExact(myProfil.ProviderName))

        If myProfil.ProviderName.Equals(Constants.PDFFriendlyName) Then
            btnAdvancedSettings.Visible = True
        Else
            btnAdvancedSettings.Visible = False
        End If
    End Sub

    'bind hash algorithms
    Private Sub bindHashAlgo()
        ddlSignAlgo.SelectedIndex = (ddlSignAlgo.FindStringExact(myProfil.SignAlgorithm))
    End Sub

    'this method binds the url address from the profile into the label
    Private Sub bindTSURL()
        lblURL.Text = myProfil.TimeStampURL
    End Sub

    'lock options for pre defined profils
    Private Sub lockOptions()
        ddlProviders.Enabled = False
        ddlSignAlgo.Enabled = False
        cbShowOnlyNonRepudiation.Enabled = False
        cbVerifySignatureOnly.Enabled = False
        cbCheckCRL.Enabled = False
        cbCheckTimeStamp.Enabled = False
        cbDisplayTimeStamp.Enabled = False
        lblURL.Enabled = False
    End Sub

    'unlock options for pre defined profils
    Private Sub unlockOptions()
        ddlProviders.Enabled = True
        ddlSignAlgo.Enabled = True
        cbShowOnlyNonRepudiation.Enabled = True
        cbVerifySignatureOnly.Enabled = True
        cbCheckCRL.Enabled = True
        cbCheckTimeStamp.Enabled = True
        cbDisplayTimeStamp.Enabled = True
        lblURL.Enabled = True

    End Sub

#End Region

#Region "profils options"

    'bind profils
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
        startProviderName = myProfil.ProviderName
        If myProfil.FriendlyName = customProfileName Then
            ddlProfils.SelectedIndex = (ddlProfils.FindStringExact(customProfileName))
        Else
            ddlProfils.SelectedIndex = (ddlProfils.FindStringExact(myCustomProfil.SelectedProfil))
        End If

        'select the default if no one selected
        If ddlProfils.SelectedIndex = -1 Then
            ddlProfils.SelectedIndex = 0
        End If
    End Sub



#End Region

#Region "folder options"

    'on folder radio change
    Private Sub RadioDifferent_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioDifferent.CheckedChanged
        checkRadio()
    End Sub
    'on folder radio same folder
    Private Sub RadioSame_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioSame.CheckedChanged
        checkRadio()
    End Sub

    'on browse for destionation folder clicked
    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowseDestinationFile.Click
        If FolderBrowserSaveSigned.ShowDialog() = Windows.Forms.DialogResult.OK Then
            tbDestinationFolder.Text = FolderBrowserSaveSigned.SelectedPath
            tempDestinationFolder = FolderBrowserSaveSigned.SelectedPath
        End If
    End Sub

    'this method checks the radio state and change the text box accordingly
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

#Region "saving"

    'save options to registry
    Private Function saveProfil() As Boolean
        If startProviderName <> Constants.PDFFriendlyName AndAlso CType(ddlProviders.SelectedItem, DictionaryEntry).Key = Constants.PDFFriendlyName Then
            If DontContinue() Then
                Return False
            End If
        End If

        myCustomProfil.AutoDestinationFolder = RadioSame.Checked
        myCustomProfil.ShowSignOption = cbShowSignOptions.Checked

        If ddlSavingType.Enabled Then
            myCustomProfil.SavingType = SavingTypes.Parse(GetType(SavingTypes), ddlSavingType.SelectedIndex)
        End If

        If Not RadioSame.Checked Then
            myCustomProfil.DestinationFolder = tbDestinationFolder.Text
        End If
        Dim sSelectedProfil As String = myCustomProfil.SelectedProfil
        If sSelectedProfil = customProfileName Or myCustomProfil.SelectedProfil = "" Then
            myCustomProfil.ProviderName = CType(ddlProviders.SelectedItem, DictionaryEntry).Key
            myCustomProfil.SignAlgorithm = ddlSignAlgo.Text
            myCustomProfil.ShowOnlyNonRepudiation = cbShowOnlyNonRepudiation.Checked
            myCustomProfil.CheckCertificationPath = cbVerifySignatureOnly.Checked
            myCustomProfil.CheckCRL = cbCheckCRL.Checked
            myCustomProfil.CheckTimeStamp = cbCheckTimeStamp.Checked
            myCustomProfil.DisplayTimeStamp = cbDisplayTimeStamp.Checked
            myCustomProfil.TimeStampURL = lblURL.Text

        End If
        myCustomProfil.save()
        Return True
    End Function

#End Region

#Region "Dialog events (ok,cancel,browse destionation,check autodestionation)"

    'on OK clicked
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If saveProfil() Then
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        End If

    End Sub

    'on CANCEL clicked
    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


    'on profile selected change
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlProfils.SelectedIndexChanged
        If renderingEnded Then
            myCustomProfil.SelectedProfil = CType(ddlProfils.SelectedItem, DictionaryEntry).Key
            bindOptions()
        End If
        

    End Sub


    'on Show only non repudiation certificates checked change
    Private Sub cbShowOnlyNonRepudiation_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbShowOnlyNonRepudiation.CheckedChanged
        If Not cbShowOnlyNonRepudiation.Checked Then

            If RepudiationMessageDiag.ShowDialog = Windows.Forms.DialogResult.OK Then
                cbShowOnlyNonRepudiation.Checked = False
            Else
                cbShowOnlyNonRepudiation.Checked = True
            End If

        End If
    End Sub
#End Region

#Region "Init Region Textual"
    'this method initialzed the textual labels and controls according to the selected language.
    Private Sub InitRegionTextual()

        'set form header 
        Me.Text = My.Resources.ControlStrings.OptionDiagForm

        ' Set labels
        Me.lblAdvancedSeetingsSign.Text = My.Resources.ControlStrings.OptionDiaglblAdvancedSeetingsSign
        Me.lblAdvanceSettingVerify.Text = My.Resources.ControlStrings.OptionDiaglblAdvancedSeetingsVerify
        Me.lblChooseHeader.Text = My.Resources.ControlStrings.OptionDiaglblChooseHeader
        Me.lblFormat.Text = My.Resources.ControlStrings.OptionDiaglblFormat
        Me.lblHeader.Text = My.Resources.ControlStrings.OptionDiaglblHeader
        Me.lblSelectProfile.Text = My.Resources.ControlStrings.OptionDiaglblSelectProfile
        Me.lblSigingAlgorithm.Text = My.Resources.ControlStrings.OptionDiaglblSigingAlgorithm
        Me.lblProfile.Text = My.Resources.ControlStrings.OptionDiaglblProfile
        Me.lblPathExplain.Text = My.Resources.ControlStrings.OptionDiaglblPathExplain
        Me.lblPathExplain.Location = New Point(cbVerifySignatureOnly.Location.X - lblPathExplain.Width + 133, lblPathExplain.Location.Y)
        Me.lblCRLExplain.Text = My.Resources.ControlStrings.OptionDiaglblCRLExplain
        Me.lblCRLExplain.Location = New Point(cbVerifySignatureOnly.Location.X - lblCRLExplain.Width + 133, lblCRLExplain.Location.Y)
        Me.lblSavingType.Text = My.Resources.ControlStrings.SignOptionlblSavingType
        Me.lblTSExplain.Text = My.Resources.ControlStrings.OptionDiaglblTSExplain

        ' set radio button text
        Me.RadioDifferent.Text = My.Resources.ControlStrings.SignOptionRadioDifferent
        Me.RadioSame.Text = My.Resources.ControlStrings.SignOptionRadioSame

        ' set chack boxes text
        Me.cbCheckTimeStamp.Text = My.Resources.ControlStrings.OptionDiagcbCheckTimeStamp
        Me.cbCheckCRL.Text = My.Resources.ControlStrings.OptionDiagcbCRL
        Me.cbVerifySignatureOnly.Text = My.Resources.ControlStrings.OptionDiagcbPath
        Me.cbShowOnlyNonRepudiation.Text = My.Resources.ControlStrings.OptionDiagcbShowOnlyNonRepudiation
        Me.cbShowSignOptions.Text = My.Resources.ControlStrings.ShowSignOptionDialog
        Me.cbDisplayTimeStamp.Text = My.Resources.ControlStrings.OptionDiagcbDisplayTimeStamp
        ' set button text
        Me.btnBrowseDestinationFile.Text = My.Resources.ControlStrings.SignOptionbtnBrowseDestinationFile
        Me.Cancel_Button.Text = My.Resources.ControlStrings.SignOptionCancel_Buttone
        Me.OK_Button.Text = My.Resources.ControlStrings.OptionDiagOK_Button
        Me.btnAdvancedSettings.Text = My.Resources.ControlStrings.btnAdvancedSettings_Button

        ''Set tool tip messages
        Me.tipQuestionMark.SetToolTip(Me.picboxSaveFile, My.Resources.InfoMessages.picboxSaveFile)
        Me.tipQuestionMark.SetToolTip(Me.picboxAdvanceSettingSign, My.Resources.InfoMessages.picBoxSignSetting)
        Me.tipQuestionMark.SetToolTip(Me.picboxAdvanceSettingsVerify, My.Resources.InfoMessages.picBoxVerifySetting)
        Me.tipQuestionMark.SetToolTip(Me.picBoxProfile, My.Resources.InfoMessages.picBoxProfile)

    End Sub
#End Region

#Region "Tool tip events"

    'tool tip message when save file picture box is clicked
    Private Sub picboxSaveFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxSaveFile.Click
        LastSelectedPicture = picboxSaveFile
        tipQuestionMark.Hide(LastSelectedPicture)
        tipQuestionMark.Show(My.Resources.InfoMessages.picboxSaveFile, picboxSaveFile, _
                             New Point(picboxSaveFile.Location.X, _
                                       picboxSaveFile.Location.Y), 5000)
    End Sub

    'tool tip message hidden when mouse leaves the control
    Private Sub picboxSaveFile_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxSaveFile.MouseLeave
        tipQuestionMark.Hide(picboxSaveFile)
    End Sub

    'tool tip message when profile picture box is clicked
    Private Sub picBoxProfile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picBoxProfile.Click
        LastSelectedPicture = picBoxProfile
        tipQuestionMark.Hide(LastSelectedPicture)
        tipQuestionMark.Show(My.Resources.InfoMessages.picBoxProfile, picBoxProfile, _
                             New Point(picBoxProfile.Location.X + picBoxProfile.Size.Width - 3, _
                                       picBoxProfile.Location.Y + picBoxProfile.Size.Height - 3), 5000)
    End Sub

    'tool tip message hidden when mouse leaves the control
    Private Sub picBoxProfile_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picBoxProfile.MouseLeave
        tipQuestionMark.Hide(picBoxProfile)
    End Sub

    'tool tip message when advance setting sign picture box is clicked
    Private Sub picboxAdvanceSettingSign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxAdvanceSettingSign.Click
        LastSelectedPicture = picboxAdvanceSettingSign
        tipQuestionMark.Hide(LastSelectedPicture)
        tipQuestionMark.Show(My.Resources.InfoMessages.picBoxSignSetting, picboxAdvanceSettingSign, _
                             New Point(picboxAdvanceSettingSign.Location.X + picboxAdvanceSettingSign.Size.Width - 3, _
                                       picboxAdvanceSettingSign.Location.Y + picboxAdvanceSettingSign.Size.Height - 3), 5000)
    End Sub

    'tool tip message hidden when mouse leaves the control
    Private Sub picboxAdvanceSettingSign_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxAdvanceSettingSign.MouseLeave
        tipQuestionMark.Hide(picboxAdvanceSettingSign)
    End Sub

    'tool tip message when advance setting verify picture box is clicked
    Private Sub picboxAdvanceSettingsVerify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxAdvanceSettingsVerify.Click
        LastSelectedPicture = picboxAdvanceSettingsVerify
        tipQuestionMark.Hide(LastSelectedPicture)
        tipQuestionMark.Show(My.Resources.InfoMessages.picBoxVerifySetting, picboxAdvanceSettingsVerify, _
                             New Point(picboxAdvanceSettingsVerify.Location.X + picboxAdvanceSettingsVerify.Size.Width - 3, _
                                       picboxAdvanceSettingsVerify.Location.Y + picboxAdvanceSettingsVerify.Size.Height - 3), 5000)
    End Sub

    'tool tip message hidden when mouse leaves the control
    Private Sub picboxAdvanceSettingsVerify_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxAdvanceSettingsVerify.MouseLeave
        tipQuestionMark.Hide(picboxAdvanceSettingsVerify)
    End Sub
#End Region

#Region "Help"
    'show the help form.
    Private Sub HelpButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HelpButton.Click
        Dim Dir As New IO.DirectoryInfo(System.IO.Path.GetDirectoryName(Application.ExecutablePath))
        Dim Files() As FileInfo = Dir.GetFiles("SignVerifyUserGuide.chm", SearchOption.AllDirectories)
        If Files.Length = 1 Then
            Dim sCHMPath As String = Files(0).FullName
            Help.ShowHelp(Me, sCHMPath, "advanced_options.html")
        End If
    End Sub

#End Region

#Region "Time stamp"
    'hide or show time stamp. layout.
    Private Sub cbCheckTimeStamp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCheckTimeStamp.CheckedChanged
        If Not cbCheckTimeStamp.Checked Then
            layoutTSURL.Hide()
        Else
            layoutTSURL.Show()
        End If
    End Sub
#End Region


   
    Private Sub btnAdvancedSettings_Click(sender As System.Object, e As System.EventArgs) Handles btnAdvancedSettings.Click
        Dim signDiag As PdfAdvancedSettingsDiag = New PdfAdvancedSettingsDiag(myCustomProfil)
        If signDiag.ShowDialog(Me) = DialogResult.OK Then

        End If

    End Sub

    Private Sub ddlProviders_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ddlProviders.SelectedIndexChanged
        If ddlProfils.SelectedValue.Equals(Constants.PDFFriendlyName) Then
            btnAdvancedSettings.Visible = True
        Else
            btnAdvancedSettings.Visible = False
        End If


        If DirectCast(ddlProviders.SelectedItem, System.Collections.DictionaryEntry).Key.ToString().Equals(Constants.XadesFriendlyName) Then
            cbCheckTimeStamp.Enabled = True
        Else
            cbCheckTimeStamp.Enabled = False
            cbCheckTimeStamp.Checked = False
        End If
    End Sub

    Private Function DontContinue() As Boolean
        Dim diag As ChangeToPdf = New ChangeToPdf(My.Resources.ControlStrings.MoveToPdfQuestion, My.Resources.ControlStrings.MoveToPdfTitle)
        If diag.ShowDialog() = Windows.Forms.DialogResult.Yes Then
            Return False
        End If
        Return True
    End Function

End Class




