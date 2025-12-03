Imports System.Windows.Forms
Imports System.IO
Imports SignVerify.Common
Imports System.ComponentModel


Public Class successDiag

#Region "Private members"
    'the signed object
    Private signedObject As CryptoSignedObject(Of Byte())

    'the signe filePath
    Private signedFilePath As String

    ''Indicate if the dialog oppened for success or for verify
    Private m_eSuccesOrVerify As SignVerify.GUI.SignVerfiy.SuccessOrVerify_Enum

    'Indicate the signature state
    Private SignatureState As SignaturesStateType

    Private TimeStampState As SignaturesStateType
    'Detremine if the siganture is fixed.
    Private SignatureStateArr As New List(Of SignaturesStateType)

    'Set the window state on top when loaded.
    Public IsOnTop As Boolean = False

    Private m_DisplayTS As Boolean = False
#End Region

#Region "constructor"

    'constructor
    Public Sub New(ByVal signedObject As CryptoSignedObject(Of Byte()), ByVal signedFilePath As String, ByVal SuccesOrVerify As SignVerify.GUI.SignVerfiy.SuccessOrVerify_Enum, ByVal DisplayTS As Boolean)

        InitializeComponent()
        m_eSuccesOrVerify = SuccesOrVerify
        
        m_DisplayTS = DisplayTS
        Me.signedObject = signedObject
        Me.signedFilePath = signedFilePath
        SetLabels()
        If Not signedObject Is Nothing Then
            SignatureState = Me.signedObject.signatureInfos.getGlobalSignatureState()

            bindFileNameLabels()
            SetVerificationStatus()
        End If


        SetTooltiControls()
    End Sub


#End Region

#Region "controls binding"


    'bind the set tooltip controls
    Private Sub SetTooltiControls()

        Me.ToolTip1.SetToolTip(Me.btnPicture, My.Resources.InfoMessages.successOpenSignatureStatus)
        Me.ToolTip1.SetToolTip(Me.lnkOpenDirectory, My.Resources.InfoMessages.successOpenFolder)
        Me.ToolTip1.SetToolTip(Me.lnkEmail, My.Resources.InfoMessages.successSendFileByEMAIL)
        Me.ToolTip1.SetToolTip(Me.lnkSignaturesStatus, My.Resources.InfoMessages.successOpenSignatureStatus)
        Me.ToolTip1.SetToolTip(Me.lnkSaveFile, My.Resources.InfoMessages.successSaveOrigianlFile)
        Me.ToolTip1.SetToolTip(Me.btnOpenOriginalFile, My.Resources.InfoMessages.successOpenOriginalFile)
        Me.ToolTip1.SetToolTip(Me.OK_Button, My.Resources.InfoMessages.CloseForm)

    End Sub

    'bind original file name and the 
    Private Sub bindFileNameLabels()
        If Not signedObject Is Nothing Then

            If signedObject.ProviderFriendlyName.Equals(Constants.PDFFriendlyName) Then
                lblOriginalFilePath.Text = Path.GetFileName(signedFilePath)
                lblOriginalFileHeader.Text = My.Resources.ControlStrings.SuccessDiaglblFileLocationPdf
                btnOpenOriginalFile.Text = My.Resources.ControlStrings.SuccessDiaglnkOpenOriginalFilePdf
                Dim newPosition As Point = New Point(lblOriginalFilePath.Location.X - 50, lblOriginalFilePath.Location.Y + 25)
                lblOriginalFilePath.Location = newPosition
                lblOriginalFilePath.Margin = New Padding(3, 5, 3, 0)
                pbPdf.Visible = True
            Else
                lblOriginalFilePath.Text = signedObject.ContentInfo.originalFileName
            End If
                lblFilePathName.Text = signedFilePath
            End If
    End Sub

    ''' <summary>
    ''' This method set labels from the resources file.
    ''' </summary>
    Private Sub SetLabels()
        'header text
        Me.Text = My.Resources.ControlStrings.SuccessVerifyDialogForm
        Me.lblVerifyResultHeader.Text = My.Resources.ControlStrings.successDiagblbVeriflHeader

        'Set labels
        Me.lblFileLocation.Text = My.Resources.ControlStrings.lVerifyDialoglblSignedFileLocation
        Me.lblWhat.Text = My.Resources.ControlStrings.SuccessDiaglblWhat
        Me.lblOriginalFileHeader.Text = My.Resources.ControlStrings.SuccessDiaglblFileLocation

        'Set links
        Me.lnkEmail.Text = My.Resources.ControlStrings.SuccessDiaglnkEmail
        Me.btnOpenOriginalFile.Text = My.Resources.ControlStrings.SuccessDiaglnkOpenOriginalFile
        Me.lnkSignaturesStatus.Text = My.Resources.ControlStrings.SuccessDiaglnkViewSignatureHistory
        Me.lnkOpenDirectory.Text = My.Resources.ControlStrings.SuccessDiaglnkOpenDirectory

        If String.IsNullOrEmpty(signedFilePath) Then
            Me.lnkOpenDirectory.Enabled = False
        End If

        'Set buttons
        Me.OK_Button.Text = My.Resources.ControlStrings.SuccessDiagOK_Button
    End Sub

    ''' <summary>
    ''' This method set the label and picture according the verification status as follows:
    ''' Green - Success - Verified
    ''' Yellow - Unchecked
    ''' Red - Unverified
    ''' </summary>
    Private Sub SetVerificationStatus()
        Dim IsSingular As Boolean = True
        If signedObject.signatureInfos.Count > 1 OrElse signedObject.signatureInfos.getLevelCount() > 1 Then
            IsSingular = False
        End If
        If SignatureState = SignaturesStateType.Valid Then 'Valid
            If IsSingular Then
                Me.lblSignStatus.Text = My.Resources.ControlStrings.successDiaglblVerificationStatusGreenSignular
            Else
                Me.lblSignStatus.Text = My.Resources.ControlStrings.successDiaglblVerificationStatusGreenplural
            End If
            Me.lblSignStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(83, Byte), Integer))
            btnPicture.Image = My.Resources.SignGreen

        ElseIf SignatureState = SignaturesStateType.Unknow Then 'Unknow
            If IsSingular Then
                Me.lblSignStatus.Text = My.Resources.ControlStrings.successDiaglblVerificationStatusUnknowSingular
            Else
                Me.lblSignStatus.Text = My.Resources.ControlStrings.successDiaglblVerificationStatusUnknowPlural
            End If
            Me.btnPicture.Image = My.Resources.SignYellow
            Me.lblSignStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(228, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(2, Byte), Integer))


        ElseIf SignatureState = SignaturesStateType.UnValid Then 'Unvalid
            If IsSingular Then
                Me.lblSignStatus.Text = My.Resources.ControlStrings.successDiaglblVerificationStatusUnvalidSingular
            Else
                Me.lblSignStatus.Text = My.Resources.ControlStrings.successDiaglblVerificationStatusUnvalidPlural
            End If

            Me.btnPicture.Image = My.Resources.SignRed
            Me.lblSignStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(186, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(70, Byte), Integer))

        ElseIf SignatureState = SignaturesStateType.Unchecked Then 'Unchecked
            If IsSingular Then
                Me.lblSignStatus.Text = My.Resources.ControlStrings.successDiaglblVerificationStatusUncheckedSingular
            Else
                Me.lblSignStatus.Text = My.Resources.ControlStrings.successDiaglblVerificationStatusUncheckedPlural
            End If

            Me.btnPicture.Image = My.Resources.SignYellow
            Me.lblSignStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(228, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(2, Byte), Integer))
        End If

        TimeStampState = Me.signedObject.signatureInfos.getGlobalTimeStampState()

        Me.lblSignStatus.Text += Environment.NewLine
        'timestamp check
        If TimeStampState = SignaturesStateType.Valid Then 'Valid
            If IsSingular Then
                Me.lblSignStatus.Text += My.Resources.ControlStrings.successDiaglblVerificationTimeStampStatusGreenSingular
            Else
                Me.lblSignStatus.Text += My.Resources.ControlStrings.successDiaglblVerificationTimeStampStatusGreenPlural
            End If
            'Me.lblSignStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(83, Byte), Integer))
            'btnPicture.Image = My.Resources.SignGreen

        ElseIf TimeStampState = SignaturesStateType.Unknow Then 'Unknow

            If IsSingular Then
                Me.lblSignStatus.Text += My.Resources.ControlStrings.successDiaglblVerificationTimeStampStatusUnknowSingular
            Else
                Me.lblSignStatus.Text += My.Resources.ControlStrings.successDiaglblVerificationTimeStampStatusUnknowPlural
            End If
            Me.btnPicture.Image = My.Resources.SignYellow
            Me.lblSignStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(228, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(2, Byte), Integer))


        ElseIf TimeStampState = SignaturesStateType.UnValid Then 'Unvalid
            If IsSingular Then
                Me.lblSignStatus.Text += My.Resources.ControlStrings.successDiaglblVerificationTimeStampStatusUnvalidSingular
            Else
                Me.lblSignStatus.Text += My.Resources.ControlStrings.successDiaglblVerificationTimeStampStatusUnvalidPlural
            End If

            Me.btnPicture.Image = My.Resources.SignRed
            Me.lblSignStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(186, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(70, Byte), Integer))

        ElseIf TimeStampState = SignaturesStateType.Unchecked Then 'Unchecked
            If m_DisplayTS = True Then
                If IsSingular Then
                    Me.lblSignStatus.Text += My.Resources.ControlStrings.successDiaglblVerificationTimeStampStatusEmptySingular
                Else
                    Me.lblSignStatus.Text += My.Resources.ControlStrings.successDiaglblVerificationTimeStampStatusEmptyPlural
                End If

                Me.btnPicture.Image = My.Resources.SignYellow
                Me.lblSignStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(228, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(2, Byte), Integer))
            End If

        End If

    End Sub
#End Region

#Region "user events"

    'on click on the status description label, open the signature detailed status
    Private Sub lblSignStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblSignStatus.Click
        FormNotOnTop()
        Dim signHistoryDiag As New SignaturesHistory(signedObject, m_DisplayTS)
        signHistoryDiag.ShowDialog()
    End Sub

    'this method shows the full original file path.
    Private Sub lblOriginalFilePath_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblOriginalFilePath.MouseHover
        ToolTip1.Show(Me.lblOriginalFilePath.Text, Me.lblOriginalFilePath)
        lblOriginalFilePath.Cursor = Cursors.Hand
    End Sub

    'this method hides the full original file path.
    Private Sub lblOriginalFilePath_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblOriginalFilePath.MouseLeave
        ToolTip1.Hide(Me.lblOriginalFilePath)
        lblOriginalFilePath.Cursor = Cursors.Default
    End Sub

    'this method shows the full signed file name.
    Private Sub lblFilePathName_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblFilePathName.MouseHover
        ToolTip1.Show(lblFilePathName.Text, Me.lblFilePathName)
    End Sub

    'this method hides the full signed file name.
    Private Sub lblFilePathName_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblFilePathName.MouseLeave
        ToolTip1.Hide(Me.lblFilePathName)
    End Sub

    'on ok clicked
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    'when mouse hovers the label hand cursur is shown.
    Private Sub lnkSaveFile_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkSaveFile.MouseHover
        Me.lnkSaveFile.Cursor = Cursors.Hand
    End Sub


    'when mouse leaves the label default cursur is shown.
    Private Sub lnkSignaturesStatus_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkSignaturesStatus.MouseLeave
        lnkSignaturesStatus.Cursor = Cursors.Default
    End Sub

    'when mouse hovers the label hand cursur is shown.
    Private Sub btnOpenOriginalFile_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenOriginalFile.MouseHover
        btnOpenOriginalFile.Cursor = Cursors.Hand
    End Sub

    'when mouse leaves the label default cursur is shown.
    Private Sub btnOpenOriginalFile_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenOriginalFile.MouseLeave
        btnOpenOriginalFile.Cursor = Cursors.Default
    End Sub

    'when mouse hovers the label hand cursur is shown.
    Private Sub lnkSignaturesStatus_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkSignaturesStatus.MouseHover
        Me.lnkSignaturesStatus.Cursor = Cursors.Hand
    End Sub

    ''on open folder clicked
    Private Sub lnkOpenDirectory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkOpenDirectory.Click
        FormNotOnTop()
        Dim proc As New Diagnostics.Process
        proc.StartInfo.FileName = "explorer.exe"
        proc.StartInfo.Arguments = "/select," & signedFilePath
        proc.Start()
    End Sub

    'when mouse hovers the label hand cursur is shown.
    Private Sub lnkOpenDirectory_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkOpenDirectory.MouseHover
        Me.lnkOpenDirectory.Cursor = Cursors.Hand
    End Sub



    'on send by mail clicked
    Private Sub lnkEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkEmail.Click
        FormNotOnTop()
        Dim proc As New Diagnostics.Process
        proc.StartInfo.FileName = "Outlook.exe"
        proc.StartInfo.Arguments = "/a """ + Me.signedFilePath + """"
        proc.Start()
    End Sub

    'when mouse hovers the label hand cursur is shown.
    Private Sub lnkEmail_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkEmail.MouseHover
        Me.lnkEmail.Cursor = Cursors.Hand
    End Sub

    'this method opens the signature history (status) dialog.
    Private Sub btnPicture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPicture.Click
        FormNotOnTop()
        Dim signHistoryDiag As New SignaturesHistory(signedObject, m_DisplayTS)
        signHistoryDiag.ShowDialog()
    End Sub

    'this method open the save dialog to save the original file.
    Private Sub lnkSaveFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkSaveFile.Click
        FormNotOnTop()
        Dim filename As String = Path.GetTempFileName()

        Try
            Dim signedOjb As CryptoSignedObject(Of Byte()) = CType(signedObject, CryptoSignedObject(Of Byte()))
            filename = Path.ChangeExtension(filename, Path.GetExtension(signedOjb.ContentInfo.originalFileName))
            File.WriteAllBytes(filename, signedOjb.ContentInfo.originalContent)

            SaveOrigianlFile.FileName = signedObject.ContentInfo.originalFileName
            SaveOrigianlFile.Title = "Save original file"
            If SaveOrigianlFile.CheckPathExists Then
                SaveOrigianlFile.InitialDirectory = "My documents"
                ' If the file name is not an empty string open it for saving.

                If SaveOrigianlFile.FileName <> "" Then
                    If SaveOrigianlFile.ShowDialog() = DialogResult.OK Then
                        My.Computer.FileSystem.CopyFile(filename, SaveOrigianlFile.FileName)
                    End If
                End If
            End If
        Catch ex As Exception
            Logger.Instance.Error(ex)
        End Try
    End Sub

    'view Signatures history
    Private Sub lnkSignaturesStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkSignaturesStatus.Click
        FormNotOnTop()
        Dim signHistoryDiag As New SignaturesHistory(signedObject, m_DisplayTS)
        signHistoryDiag.ShowDialog()
    End Sub

    'on open original file clicked
    Private Sub btnOpenOriginalFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenOriginalFile.Click
        OpenOrigianlFile()
    End Sub

    ''' <summary>
    ''' This method opens the origianl file.
    ''' </summary>
    Private Sub OpenOrigianlFile()
        FormNotOnTop()

        Try
            Dim filename As String = Path.GetTempFileName()
            Dim signedOjb As CryptoSignedObject(Of Byte()) = CType(signedObject, CryptoSignedObject(Of Byte()))
            filename = Path.ChangeExtension(filename, Path.GetExtension(signedOjb.ContentInfo.originalFileName))
            File.WriteAllBytes(filename, signedOjb.ContentInfo.originalContent)
            Dim oInfo As ProcessStartInfo = New ProcessStartInfo()
            oInfo.FileName = filename
            oInfo.ErrorDialog = True
            Process.Start(oInfo)
        Catch ex As Exception
            Logger.Instance.Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' When link is clicked the origianl file is opened
    ''' </summary>
    Private Sub lblOriginalFilePath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblOriginalFilePath.Click
        OpenOrigianlFile()
    End Sub

#Region "Help"
    'this method oppens the help dialog.
    Private Sub HelpToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HelpToolStripButton.Click
        FormNotOnTop()

        Dim Dir As New IO.DirectoryInfo(System.IO.Path.GetDirectoryName(Application.ExecutablePath))
        Dim Files() As FileInfo = Dir.GetFiles("SignVerifyUserGuide.chm", SearchOption.AllDirectories)
        If Files.Length = 1 Then
            Dim sCHMPath As String = Files(0).FullName
            Help.ShowHelp(Me, sCHMPath, "confirm.html")
        End If
    End Sub
#End Region

#End Region

#Region "private method"



    'set the form on top
    Private Sub FormNotOnTop()
        If IsOnTop = True Then
            IsOnTop = False
            Me.TopMost = False
            Me.SendToBack()
        End If
    End Sub
#End Region

   
End Class
