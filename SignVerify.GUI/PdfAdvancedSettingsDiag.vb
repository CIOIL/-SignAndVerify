Imports System.Windows.Forms
Imports System.Security.Cryptography.X509Certificates
Imports SignVerify.MainComponent
Imports SignVerify.Common
Imports SignVerify.Profils
Imports System.IO
Imports SignVerify.Profils.Profil

Public Class PdfAdvancedSettingsDiag

#Region "privates members"


    'the registy options handle
    Private myPdfSignatureSettings As PDFSignatureAppearanceParameters
    Private myRegistryProfil As RegistryProfil

#End Region

#Region "Property"
    Friend ReadOnly Property GetPdfSignatureSettings() As PDFSignatureAppearanceParameters
        Get
            Return myPdfSignatureSettings
        End Get
    End Property
#End Region

#Region "constructor"
    Dim LastSelectedPicture As PictureBox

    'diag constructor
    Public Sub New(ByVal p_registryProfil As RegistryProfil)

        'init variables
        InitializeComponent()
        InitRegionTextual()

        myRegistryProfil = p_registryProfil

    End Sub
    'Loading the labels and profiles
    Public Sub AdvancedOptionsDiag_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load


        Dim iHeight As Integer = Screen.PrimaryScreen.WorkingArea.Height
        Dim iWidth As Integer = Screen.PrimaryScreen.WorkingArea.Width

        If iHeight < 650 AndAlso iWidth < 900 Then
            Me.Size = New Point(Me.Width + 17, iHeight - 40)
            Me.AutoScroll = True
        Else
            Me.AutoScroll = False
        End If

        SetTooltipButton()

        BindOptions()

        EnableOptions()

    End Sub

#End Region

#Region "controls binding"


    'bind the set tooltip button
    Private Sub SetTooltipButton()

        Me.ToolTip1.SetToolTip(Me.Cancel_Button, My.Resources.InfoMessages.OptionNotSaveSetting)
        Me.ToolTip1.SetToolTip(Me.OK_Button, My.Resources.InfoMessages.OptionSaveSetting)
        Me.ToolTip1.SetToolTip(Me.btnBrowseDestinationFile, My.Resources.InfoMessages.SaveFileBrowse)

    End Sub






#End Region

#Region "profils options"



#End Region

#Region "folder options"

    'on folder radio change


#End Region

#Region "saving"

    'save options to registry
    Private Sub saveParameters()
        myRegistryProfil.savePdfParamsValues()

    End Sub

#End Region

#Region "Dialog events (ok,cancel,browse destionation,check autodestionation)"

    'on OK clicked
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim params As Profils.PdfParams = GetParams()
        If Not myRegistryProfil.PdfParameters.isEqual(params) Then
            myRegistryProfil.PdfParameters = params
            saveParameters()
        End If
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    'on CANCEL clicked
    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


#End Region

#Region "Init Region Textual"
    'this method initialzed the textual labels and controls according to the selected language.
    Private Sub InitRegionTextual()

        'set form header 
        Me.Text = My.Resources.ControlStrings.OptionDiagForm

        ' Set labels
        Me.lblAppearanceHeader.Text = My.Resources.ControlStrings.PdfOptionDiaglblAppearanceHeader
        Me.lblHeader.Text = My.Resources.ControlStrings.PdfOptionDiaglblHeader
        Me.cbShowSig.Text = My.Resources.ControlStrings.PdfOptionDiagcbShowSig
        Me.lblShowImage.Text = My.Resources.ControlStrings.PdfOptionDiagcbShowImage
        Me.lblUseDefaultImage.Text = My.Resources.ControlStrings.PdfOptionDiagcbUseDefaultImage
        Me.lblImagePath.Text = My.Resources.ControlStrings.PdfOptionDiaglblImagePath
        'Me.lblPositionForTitle.Text = My.Resources.ControlStrings.PdfSignOptionlblPositionForTitle
        Me.lblPosition.Text = My.Resources.ControlStrings.PdfSignOptionlblPosition
        Me.lblPositionForTitle.Text = My.Resources.ControlStrings.PdfSignOptionlblPositionForTitle
        Me.lblPositionForAlign.Text = My.Resources.ControlStrings.PdfSignOptionlblPositionForAlign
        Me.lblDataHeader.Text = My.Resources.ControlStrings.PdfSignOptionlblDataHeader
        Me.lblDataEx.Text = My.Resources.ControlStrings.PdfSignOptionlblDataEx
        Me.lblDataEx2.Text = My.Resources.ControlStrings.PdfSignOptionlblDataEx2
        Me.lblDataEx3.Text = My.Resources.ControlStrings.PdfSignOptionlblDataEx3
        Me.lblReason.Text = My.Resources.ControlStrings.PdfSignOptionlblReason
        Me.lblLocation.Text = My.Resources.ControlStrings.PdfSignOptionlblLocation
        Me.lblContact.Text = My.Resources.ControlStrings.PdfSignOptionlblContact
        Me.lblText.Text = My.Resources.ControlStrings.PdfSignOptionlblText
        Me.lblShowName.Text = My.Resources.ControlStrings.PdfSignOptionlblShowName
        ' set chack boxes text
        ' set button text
        Me.btnBrowseDestinationFile.Text = My.Resources.ControlStrings.SignOptionbtnBrowseDestinationFile
        Me.Cancel_Button.Text = My.Resources.ControlStrings.SignOptionCancel_Buttone
        Me.OK_Button.Text = My.Resources.ControlStrings.OptionDiagOK_Button

        ''Set tool tip messages
        Me.tipQuestionMark.SetToolTip(Me.picboxAppareance, My.Resources.InfoMessages.picboxAppearance)
        Me.tipQuestionMark.SetToolTip(Me.PictureBox1, My.Resources.InfoMessages.picboxDataAppearance)

    End Sub
#End Region

#Region "Tool tip events"

    'tool tip message when save file picture box is clicked
    Private Sub picboxSaveFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LastSelectedPicture = picboxAppareance
        tipQuestionMark.Hide(LastSelectedPicture)
        tipQuestionMark.Show(My.Resources.InfoMessages.picboxSaveFile, picboxAppareance, _
                             New Point(picboxAppareance.Location.X, _
                                       picboxAppareance.Location.Y), 5000)
    End Sub

    'tool tip message hidden when mouse leaves the control
    Private Sub picboxSaveFile_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        tipQuestionMark.Hide(picboxAppareance)
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

    Private Sub BindOptions()
        myRegistryProfil.loadPdfValues()
        cbShowSig.Checked = myRegistryProfil.PdfParameters.IsVisible
        cbShowImage.Checked = myRegistryProfil.PdfParameters.ShowImage
        cbUseDefaultImage.Checked = myRegistryProfil.PdfParameters.UseDefaultImage
        ' RadioInvisible.Checked = Not RadioVisible.Checked
        txtText.Text = myRegistryProfil.PdfParameters.Text
        cbShowName.Checked = myRegistryProfil.PdfParameters.ShowName
        rtbLocation.Text = myRegistryProfil.PdfParameters.Location
        rtbReason.Text = myRegistryProfil.PdfParameters.Reason
        tbImagePath.Text = myRegistryProfil.PdfParameters.ImagePath
        rtbContact.Text = myRegistryProfil.PdfParameters.Contact
        BindPosition()
    End Sub

    Private Sub EnableOptions()

        EnableFields(cbShowSig.Checked)
        If cbShowSig.Checked Then
            tbImagePath.Enabled = Not cbUseDefaultImage.Checked
            btnBrowseDestinationFile.Enabled = Not cbUseDefaultImage.Checked
        End If

    End Sub



    Private Function GetParams() As Profils.PdfParams
        Dim pdfParams As New Profils.PdfParams
        pdfParams.Text = txtText.Text
        pdfParams.Contact = rtbContact.Text
        pdfParams.IsVisible = cbShowSig.Checked
        pdfParams.ShowImage = cbShowImage.Checked
        pdfParams.UseDefaultImage = cbUseDefaultImage.Checked
        pdfParams.ImagePath = tbImagePath.Text
        pdfParams.Location = rtbLocation.Text
        pdfParams.Position = GetPosition()
        pdfParams.Reason = rtbReason.Text
        pdfParams.ShowName = cbShowName.Checked
        Return pdfParams
    End Function

    Private Function GetPosition() As PositionTypes?
        Dim value As Integer
        If ddlAlignType.SelectedIndex = -1 Or ddlTopType.SelectedIndex = -1 Then
            Return -1
        End If
        If ddlTopType.SelectedIndex = 1 Then
            value = 10
        End If
        Return value + ddlAlignType.SelectedIndex
    End Function

    Private Sub BindPosition()
        Dim positionValue = Convert.ToInt32(myRegistryProfil.PdfParameters.Position)
        If positionValue = -1 Then
            ddlAlignType.SelectedIndex = -1
            ddlTopType.SelectedIndex = -1
        End If
        If positionValue < 10 Then
            ddlTopType.SelectedIndex = 0
            ddlAlignType.SelectedIndex = positionValue
        Else
            ddlTopType.SelectedIndex = 1
            ddlAlignType.SelectedIndex = positionValue - 10
        End If
    End Sub

    Private Sub cbShowSig_CheckedChanged(sender As System.Object, e As System.EventArgs)
        EnableOptions()
    End Sub

    Private Sub EnableOptions(sender As System.Object, e As System.EventArgs) Handles cbShowSig.CheckedChanged
        EnableOptions()
    End Sub

    Private Sub cbShowImage_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cbShowImage.CheckedChanged
        EnableOptions()
    End Sub

    Private Sub cbUseDefaultImage_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cbUseDefaultImage.CheckedChanged
        EnableOptions()
    End Sub

    Private Sub btnBrowseDestinationFile_Click_1(sender As System.Object, e As System.EventArgs) Handles btnBrowseDestinationFile.Click
        If fileImage.ShowDialog() = Windows.Forms.DialogResult.OK Then
            tbImagePath.Text = fileImage.FileName
        End If
    End Sub

    Private Sub EnableFields(enable As Boolean)
        txtText.Enabled = enable
        cbShowName.Enabled = enable
        cbShowImage.Enabled = enable
        cbUseDefaultImage.Enabled = enable
        tbImagePath.Enabled = enable
        btnBrowseDestinationFile.Enabled = enable
        ddlTopType.Enabled = enable
        ddlAlignType.Enabled = enable
        rtbReason.Enabled = enable
        rtbLocation.Enabled = enable
        rtbContact.Enabled = enable
    End Sub

End Class




