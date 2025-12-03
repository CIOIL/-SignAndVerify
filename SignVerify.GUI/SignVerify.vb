Imports SignVerify.MainComponent
Imports SignVerify.Common
Imports System.Security.Cryptography.X509Certificates
Imports System.IO
Imports SignVerify.Profils
Imports System.Configuration
Imports System.Threading
Imports System.ComponentModel
Imports SignVerify.Common.Utils


Public Class SignVerfiy

#Region "Enum"

    'Sign and verify actions option
    Public Enum ActionTypes As Integer
        Sign = 0
        Verify = 1
        Cosign = 2
    End Enum

    'SuccesOrVerify_Enum option
    Public Enum SuccessOrVerify_Enum As Integer
        Success = 0
        Verify = 1
    End Enum

#End Region

#Region "internals members"

    'the general sign&verify provider
    Private provider As SignVerifyProvider

    'the choosen filename (also after sign)
    Private filenames As ArrayList

    ' The action type (sign, verify or cosign)
    Private Action As ActionTypes

    'the resulted signed files 
    Private Results As Hashtable

    'the resulted signed files 
    Private SavedResults As Hashtable

    'Private NewSplitButton As New SplitButtonDemo.SplitButton()
    'the selected profil (from options)
    Private ReadOnly Property myOptionsProfil() As Profil
        Get
            If provider.registryProfil.SelectedProfil <> "" AndAlso provider.LoadedProfils.ContainsKey(provider.registryProfil.SelectedProfil) Then
                Return provider.LoadedProfils(provider.registryProfil.SelectedProfil)
            Else
                Return provider.registryProfil
            End If
        End Get
    End Property

    'the selected profil 
    Private mySelectedProfil As Profil

    'selected certificate name
    Private selectedCertificateSN As String

    'selected certificate
    Private selectedCertificate As X509Certificate2

    'selected cosign type
    Private selectedCoSignType As CoSignType

    'selected path for saving
    Private selectedSavingPath As String

    'select saving type
    Private selectedSavingType As SavingTypes

    'the zipper util
    Private Zipper As ZipProvider

    Private Delegate Sub AddRowDelegate(ByVal filepath As String)
    Private Delegate Sub RemoveRowDelegate(ByVal rowIndex As Integer)
    Private Delegate Sub SaveFileDelegate(ByVal filepath As String, ByVal content As Byte())
    Private Delegate Sub SaveFileFromStreamDelegate(ByVal filepath As String, ByVal contentStream As MemoryStream)
    Private Delegate Sub changeRowStatusDelegate(ByVal rowIndex As Integer, ByVal status As RowStatus, ByVal details As String)
    Private Delegate Sub showErrorDiagDelegate(ByVal errorMessage As String)
    Private Delegate Sub toogleProgressDelegate()
    Private Delegate Sub updateProgressDelegate(ByVal totalSteps As Integer, ByVal currentStep As Integer, ByVal message As String)
#End Region

#Region "Form constructor"
    'ctor
    Public Sub New()
        'Check if writing to log is enabled
        Dim bWriteToLog As Boolean = False
        If Not Boolean.TryParse(System.Configuration.ConfigurationManager.AppSettings("WriteToLog"), bWriteToLog) Then
            Logger.Instance.Error("can not open configuration")
        End If
        Logger.SetState(bWriteToLog)
        'set the current culture
        Threading.Thread.CurrentThread.CurrentUICulture = New Globalization.CultureInfo("he-IL")
        InitializeComponent()
        provider = New SignVerifyProvider()
        filenames = New ArrayList
        Results = New Hashtable
        SavedResults = New Hashtable
        btnSign.Enabled = False
        pnlSign.Enabled = False
        pnlSign.Cursor = Cursors.Arrow
        btnVerify.Enabled = False
        pnlVerify.Enabled = False
        pnlVerify.Cursor = Cursors.Arrow
        provider.registryProfil.load()
        SetTooltiControls()
        BindLangTextualValues()

    End Sub

    'bind the set tooltip controls
    Private Sub SetTooltiControls()


        Me.ToolTip1.SetToolTip(Me.btnSign, My.Resources.InfoMessages.SignOptionSign)
        Me.ToolTip1.SetToolTip(Me.btnVerify, My.Resources.InfoMessages.SignOptionVerify)

    End Sub

    'This method binds all the textual values according to the selected language
    Private Sub BindLangTextualValues()
        'Form Header
        Me.Text = My.Resources.ControlStrings.SignVerifyHeader + " " + GetType(SignVerfiy).Assembly.GetName().Version().Major.ToString + "." + GetType(SignVerfiy).Assembly.GetName().Version().Minor.ToString

        'Labels
        'Me.lblSignExplanation.Text = My.Resources.ControlStrings.SignVerifylblSignExplanation
        'Me.lblSignHeader.Text = My.Resources.ControlStrings.SignVerifylblSignHeader
        ' Me.lblVerifyExplanation.Text = My.Resources.ControlStrings.SignVerifylblVerifyExplanation
        'Me.lblVerifyHeader.Text = My.Resources.ControlStrings.SignVerifylblVerifyHeader

        'Button
        Me.btnChangeLanguage.Text = My.Resources.ControlStrings.SignVerifybtnChangeLanguage
        Me.btnHelp.Text = My.Resources.ControlStrings.SignVerifybtnHelp
        Me.ToolItemHelp.Text = My.Resources.ControlStrings.SignVerifybtnHelp
        Me.ToolItemAbout.Text = My.Resources.ControlStrings.SignVerifysplButtonAbout
        Me.btnShowCardDetails.Text = My.Resources.ControlStrings.SignVerifybtnShowCardDetails
        ' Me.btnSign.Text = My.Resources.ControlStrings.SignVerifybtnSign
        Me.btnSystemSettings.Text = My.Resources.ControlStrings.SignVerifybtnSystemSettings
        ' Me.btnVerify.Text = My.Resources.ControlStrings.SignVerifybtnVerify
    End Sub

    'Enable disable the buttons according to the selected file.
    Private Sub bindButtons()
        btnVerify.Enabled = False
        pnlVerify.Enabled = False
        pnlVerify.Cursor = Cursors.Arrow
        btnSign.Enabled = filenames.Count > 0
        pnlSign.Enabled = filenames.Count > 0
        If (filenames.Count > 0) Then
            pnlSign.Cursor = Cursors.Hand
        Else
            pnlSign.Cursor = Cursors.Arrow
        End If

        For Each elem As String In filenames
            If Path.GetExtension(elem).ToLower = ".signed" Or Path.GetExtension(elem).ToLower = ".pdf" Then
                btnVerify.Enabled = True
                pnlVerify.Enabled = True
                pnlVerify.Cursor = Cursors.Hand
                Exit For
            End If
        Next


    End Sub

#End Region

#Region "Files browsing "

    'on brownsing file to sign
    Private Sub GlassButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFiles.Click

        If Me.myOptionsProfil.ProviderName.Equals(Constants.PDFFriendlyName) Then
            OpenFileDialog1.Filter = "Pdf files|*.pdf"
        Else
            OpenFileDialog1.Filter = "All files|*.*|Signed files|*.signed"

        End If


        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.SuspendLayout()
            ''gvFiles.clear()
            If filenames Is Nothing Then
                filenames = New ArrayList
            End If
            For Each elem As String In New ArrayList(OpenFileDialog1.FileNames)
                If gvFiles.addRow(elem) Then
                    filenames.Add(elem)
                End If
            Next
            bindButtons()
            Me.ResumeLayout()
        End If
    End Sub

#End Region

#Region "Get options  data"

    'check if we need to show the sign diag , and get the options
    Private Function GetSignOptions() As Boolean
        'Check for showing the sign option dialog
        'TODO:for single file ,verify first the file and pass it to the option diag for signature history
        Dim oldProvider As String = Me.myOptionsProfil.ProviderName
        Dim signDiag As SignOptionsDiag = Nothing
        If Action = ActionTypes.Sign Then
            'if we don't want to show the sign diag, just take the saved profile
            If SetSingleCertificate() AndAlso Not Me.selectedCertificate Is Nothing AndAlso Not Me.provider.registryProfil.ShowSignOption Then
                Me.mySelectedProfil = Me.myOptionsProfil
            Else
                signDiag = New SignOptionsDiag(provider, False)
            End If
        ElseIf Action = ActionTypes.Cosign Then
            signDiag = New SignOptionsDiag(provider, True)
        End If

        'show the sign option dialog
        If Not signDiag Is Nothing Then
            If signDiag.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Me.selectedCertificate = signDiag.selectedCertificate
                If signDiag.selectedProfil.ProviderName = Constants.PDFFriendlyName AndAlso oldProvider <> Constants.PDFFriendlyName Then
                    RemoveNotPdfFiles()
                    If gvFiles.Rows.Count = 0 Then
                        Return False
                    End If
                End If
                Me.mySelectedProfil = signDiag.selectedProfil
                selectedCoSignType = signDiag.selectedCoSignType
            Else
                Return False
            End If
        End If
        If Me.mySelectedProfil.ProviderName = Constants.PDFFriendlyName Then
            Me.mySelectedProfil.PdfParameters = provider.registryProfil.PdfParameters
        End If
        'TODO:if change to pdf provider check for not pdf file and show msg

        Return True
    End Function

    'get the path to save the signed files to
    Private Function GetSavePath() As Boolean

        'get the signed files path( folder or filename)
        Dim initialDirectory As String = ""

        'get the intial category
        If filenames.Count = 1 Then

            'get the filename or the directory path
            If provider.registryProfil.AutoDestinationFolder OrElse provider.registryProfil.DestinationFolder = "" Then
                initialDirectory = IO.Path.GetDirectoryName(filenames(0))
            Else
                initialDirectory = provider.registryProfil.DestinationFolder
            End If


        Else
            'get the directory path
            If Not provider.registryProfil.AutoDestinationFolder And provider.registryProfil.DestinationFolder <> "" Then
                initialDirectory = provider.registryProfil.DestinationFolder
            Else
                initialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            End If

        End If

        'open the diag and save the result
        If Me.provider.registryProfil.SavingType = SavingTypes.Separate Then
            If Directory.Exists(initialDirectory) Then
                selectedSavingPath = initialDirectory
            Else
                If SaveFolderDiag.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Me.selectedSavingPath = SaveFolderDiag.SelectedPath
                    Me.provider.registryProfil.DestinationFolder = SaveFolderDiag.SelectedPath
                    Me.provider.registryProfil.save()
                End If
            End If

        Else
            If Me.provider.registryProfil.SavingType = SavingTypes.SeparateAndZip Then
                SaveFileDiag.InitialDirectory = initialDirectory
                SaveFileDiag.Filter = "compressed files (*.zip)|*.zip"
                SaveFileDiag.DefaultExt = "*.zip"
                SaveFileDiag.FileName = "SignedFiles-" & DateTime.Now.ToString("yyyy-MM-dd") & ".zip"
                SaveFileDiag.Title = My.Resources.ControlStrings.SignVerifySaveDialogTitle

            ElseIf Me.provider.registryProfil.SavingType = SavingTypes.Zip Then
                SaveFileDiag.InitialDirectory = initialDirectory
                SaveFileDiag.Filter = "signed files (*.signed)|*.signed"
                SaveFileDiag.DefaultExt = "*.signed"
                SaveFileDiag.FileName = "SignedFiles-" & DateTime.Now.ToString("yyyy-MM-dd") & ".signed"
                SaveFileDiag.Title = My.Resources.ControlStrings.SignVerifySaveDialogTitle
            End If

            'open the save file dialog
            If SaveFileDiag.CheckPathExists() Then
                If SaveFileDiag.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Me.selectedSavingPath = SaveFileDiag.FileName
                Else
                    Me.selectedSavingPath = ""
                End If
            End If
        End If

        If Me.selectedSavingPath = "" Then Return False
        Return True
    End Function

    'get the user selected certificate
    Private Function getUserCertificate() As X509Certificate2

        Dim cert As X509Certificate2

        'get selected certificate
        cert = Me.selectedCertificate

        selectedCertificateSN = cert.SerialNumber

        'check if the certificate as private key
        If Not cert.HasPrivateKey Then
            Logger.Instance.Warn(My.Resources.ErrorMessages.MissingCertificatePrivateKey)
            Throw New ApplicationException(My.Resources.ErrorMessages.MissingCertificatePrivateKey)
        End If


        Return cert
    End Function

    'get the user selected provider
    Private Function getUserProvider() As ICryptoProviderBinary

        'check for null provider
        If mySelectedProfil.ProviderName.Trim = "" Then
            Logger.Instance.Warn(My.Resources.ErrorMessages.SelectProvider)
            Throw New Exception(My.Resources.ErrorMessages.SelectProvider)
        End If

        'search the choosed signing provider
        Dim prov As ICryptoProviderBinary
        Try
            prov = provider.LoadedPlugins(mySelectedProfil.ProviderName)
        Catch ex As Exception
            Logger.Instance.Warn(ex.ToString(), ex)
            If prov Is Nothing Then
                If mySelectedProfil.ProviderName = Constants.PDFFriendlyName Or
                    mySelectedProfil.ProviderName = Constants.XadesFriendlyName Then
                    Throw New Exception(My.Resources.ErrorMessages.SelectProvider)
                End If
                Logger.Instance.Warn(My.Resources.ErrorMessages.SelectProvider)
                Throw New Exception(My.Resources.ErrorMessages.SelectProvider)
            End If
        End Try

        Return prov

    End Function

    'get the user saving type
    Private Function getUserSavingType() As SavingTypes

        If Me.mySelectedProfil.SavingType Is Nothing Then
            Return Me.provider.registryProfil.SavingType
        Else
            Return Me.mySelectedProfil.SavingType
        End If

    End Function
#End Region

#Region "Sign / verfiy / cancel buttons clicked"

    'on sign button clicked
    Private Sub btnSign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSign.Click
        Try

            'check if one file is for cosigning
            Me.Action = ActionTypes.Sign
            For Each elem As String In filenames
                If Path.GetExtension(elem).ToLower = ".signed" Then
                    Me.Action = ActionTypes.Cosign
                    Exit For
                End If
            Next

            'Check for showing the sign option dialog and get the options
            If Not GetSignOptions() Then Return

            'get the saving options
            If Not GetSavePath() Then Return


            If Not BgWorker.IsBusy Then
                Me.BgWorker.RunWorkerAsync()
            End If

            'CardServices.ClearAllCardsPinCode()
            'AfterSign()

        Catch ex As Exception
            Logger.Instance.Error(ex.ToString(), ex)

        End Try
    End Sub

    'on verify button clicked
    Private Sub btnVerify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerify.Click, pnlVerify.Click, PictureBox2.Click, Label6.Click, Label5.Click
        Action = ActionTypes.Verify
        Me.BgWorker.RunWorkerAsync()
    End Sub

    'on cancel button clicked
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.BgWorker.CancelAsync()
    End Sub

#End Region

#Region "Execute files Async Worker"

    'sign or verify files
    Private Sub ExecuteFiles(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles BgWorker.DoWork
        If Me.BgWorker.CancellationPending Then Return

        'show progress
        Me.Invoke(New toogleProgressDelegate(AddressOf showProgress), New Object() {})


        Dim cert As X509Certificate2 = Nothing
        Dim prov As ICryptoProviderBinary = Nothing

        If Action <> ActionTypes.Verify Then
            Try
                'get user profils details
                provider.registryProfil.load()

                'get user certificate
                cert = getUserCertificate()

                'get user selected provider
                prov = getUserProvider()

                'get saving type
                selectedSavingType = getUserSavingType()

            Catch ex As Exception
                Logger.Instance.Error(ex.ToString, ex)
                Me.Invoke(New showErrorDiagDelegate(AddressOf showErrorDiag), New Object() {GetExceptionMessage(ex)})
                Return
            End Try
        End If

        'report progress
        BgWorker.ReportProgress(1)

        'clear the results hashtable
        Results.Clear()
        SavedResults.Clear()

        'remove the zipped and signed file(temporary file)
        If filenames.Count > 0 AndAlso (gvFiles.Rows(0).Status = RowStatus.Zipped Or gvFiles.Rows(gvFiles.RowCount - 1).Status = RowStatus.ZipResult) Then
            filenames.RemoveAt(filenames.Count - 1)
            Me.Invoke(New RemoveRowDelegate(AddressOf gvFiles.removeRow), New Object() {gvFiles.Rows.Count - 1})
        End If

        'VERIFY
        If Me.Action = ActionTypes.Verify Then
            'execute (and save each files if need)
            For i As Integer = 0 To filenames.Count - 1
                If Me.BgWorker.CancellationPending Then Return
                ExecuteFile(i, cert, prov, selectedSavingType, False)
                BgWorker.ReportProgress(i + 1)
            Next


            'SIGN
        Else

            Zipper = New ZipProvider

            'sign and verify files
            If selectedSavingType = SavingTypes.Separate Then
                'execute (and save each files if need)
                For i As Integer = 0 To filenames.Count - 1
                    If Me.BgWorker.CancellationPending Then Return
                    Dim saveResult As Boolean = (selectedSavingType = SavingTypes.Separate)
                    ExecuteFile(i, cert, prov, selectedSavingType, saveResult)
                    BgWorker.ReportProgress(i + 1)
                Next

                'create archive with the signed files
            ElseIf selectedSavingType = SavingTypes.SeparateAndZip Then

                'execute (and save each files if need)
                For i As Integer = 0 To filenames.Count - 1
                    If Me.BgWorker.CancellationPending Then Return
                    Dim saveResult As Boolean = (selectedSavingType = SavingTypes.Separate)
                    ExecuteFile(i, cert, prov, selectedSavingType, saveResult)
                    BgWorker.ReportProgress(i + selectedSavingType)
                Next

                'create the list of files to archive
                Dim archiveStream As New MemoryStream
                Dim files As New ArrayList
                Dim fileBytes As New ArrayList
                For Each elem As DictionaryEntry In Results
                    files.Add(Path.GetFileNameWithoutExtension(elem.Key) & ".signed")
                    fileBytes.Add(CType(elem.Value, CryptoSignedObject(Of Byte())).ContentInfo.signedContent)
                Next

                'create the archive
                Zipper.archivesFiles(archiveStream, files, fileBytes)

                'save the archive
                Me.Invoke(New SaveFileFromStreamDelegate(AddressOf SaveFile), New Object() {Me.selectedSavingPath, archiveStream})

                'when saving the zip -change the signed path to point to the zipped file
                For Each f As String In filenames
                    SavedResults.Add(f, Me.selectedSavingPath)
                Next

                'add the archive to the file list
                'add archive to file list
                filenames.Add(Me.selectedSavingPath)
                Me.Invoke(New AddRowDelegate(AddressOf gvFiles.addRow), New Object() {Me.selectedSavingPath})

                'set the row status to "ZippedResult"
                Me.Invoke(New changeRowStatusDelegate(AddressOf changeRowStatus), New Object() {gvFiles.RowCount - 1, RowStatus.ZipResult, ""})

                'report progress
                BgWorker.ReportProgress(Me.filenames.Count + 2)

                'create archive with the files and sign it
            ElseIf selectedSavingType = SavingTypes.Zip Then

                'create the archive
                Dim archiveStream As New MemoryStream

                'TODO:update progress for each file
                Zipper.archivesFiles(archiveStream, filenames)
                For i As Integer = 0 To filenames.Count - 1
                    'set the row status to "Zipped"
                    Me.Invoke(New changeRowStatusDelegate(AddressOf changeRowStatus), New Object() {i, RowStatus.Zipped, ""})
                Next

                'add archive to file list
                Dim filepath As String = Path.ChangeExtension(selectedSavingPath, "zip")

                filenames.Add(filepath)
                Me.Invoke(New AddRowDelegate(AddressOf gvFiles.addRow), New Object() {filepath})

                'sign the archive
                Dim buffer As Byte() = Array.CreateInstance(GetType(Byte), archiveStream.Length)
                archiveStream.Position = 0
                archiveStream.Read(buffer, 0, buffer.Length)
                ExecuteFile(gvFiles.RowCount - 1, cert, prov, selectedSavingType, True, buffer)
                archiveStream.Dispose()

                'report progress
                BgWorker.ReportProgress(Me.filenames.Count + 2)
            End If

            'clear pin code
            Logger.Instance.Info("Clear pin code.")
            CardServices.ClearPIN(cert)

        End If

    End Sub

    'execute file
    Private Sub ExecuteFile(ByVal i As Integer, ByVal cert As X509Certificate2, ByVal prov As ICryptoProviderBinary, ByVal SavingType As SavingTypes, ByVal saveResult As Boolean, Optional ByVal content As Byte() = Nothing)
        Try
            Dim file As String = filenames(i)
            Dim verfiedObj As CryptoSignedObject(Of Byte()) = Nothing

            'activate the row
            Me.Invoke(New changeRowStatusDelegate(AddressOf changeRowStatus), New Object() {i, RowStatus.Active, ""})

            If Me.Action = ActionTypes.Verify Then
                'verify the file
                verfiedObj = verify(file)

            Else

                If Path.GetExtension(file).ToLower <> ".signed" Then
                    'sign the file and verify it
                    If content Is Nothing Then
                        content = IO.File.ReadAllBytes(file)
                    End If
                    verfiedObj = verify(sign(content, file, cert, prov), prov)

                Else

                    'verify the file
                    Dim signedObject As CryptoSignedObject(Of Byte()) = verify(file)

                    'check if it's sign with a same provider that the one selected
                    If signedObject.ProviderFriendlyName <> prov.ProviderFriendlyName Then
                        Throw New Exception(My.Resources.ErrorMessages.CosignDifferentProvider)
                    End If

                    'check for cosign with pkcs7
                    If signedObject.ProviderFriendlyName = Constants.PKCS7FriendlyName Then
                        Throw New Exception(My.Resources.ErrorMessages.CosignPKCS7NotAllowed)
                    End If
                    If signedObject.ProviderFriendlyName = Constants.XadesFriendlyName Then
                        Throw New Exception(My.Resources.ErrorMessages.CosignXadesNotAllowed)
                    End If
                    'TODO: check for already signed with the same certificate

                    'cosign the file and verify it
                    verfiedObj = verify(coSign(selectedCoSignType, file, cert, prov), prov)

                End If
            End If

            'save the file if saving mode is "separate"
            If saveResult Then
                Dim saveToPath As String = Me.selectedSavingPath
                Dim extension As String = ".signed"
                If SavingType = SavingTypes.Separate And Me.provider.registryProfil.AutoDestinationFolder And prov.ProviderFriendlyName.Contains("PDF") Then
                    extension = ".pdf"
                    saveToPath = file.Replace(extension, "-signed.pdf")
                ElseIf SavingType = SavingTypes.Separate And Me.provider.registryProfil.AutoDestinationFolder Then
                    saveToPath = Path.ChangeExtension(file, extension)
                End If

                If Path.GetExtension(saveToPath).Length = 0 Then
                    saveToPath = Path.Combine(saveToPath, Path.GetFileNameWithoutExtension(file) & ".signed")
                End If
                saveToPath = ExistHandling(saveToPath, extension)

                Me.Invoke(New SaveFileDelegate(AddressOf SaveFile), New Object() {saveToPath, verfiedObj.ContentInfo.signedContent})
                SavedResults.Add(file, saveToPath)


            End If

            If Action = ActionTypes.Verify Then
                SavedResults.Add(file, file)
            End If
            Results.Add(file, verfiedObj)

            'set the row status to "Verified"
            Me.Invoke(New changeRowStatusDelegate(AddressOf changeRowStatus), New Object() {i, RowStatus.Verified, ""})

        Catch ex As Exception
            If ex.Message.StartsWith("Could not load file or assembly 'System.Core, Version=3.5.0.0") Then
                Dim instalFwDialog As InstallFW = New InstallFW()
                instalFwDialog.ShowDialog()
            End If
            Logger.Instance.Error(ex.ToString, ex)
            Me.Invoke(New changeRowStatusDelegate(AddressOf changeRowStatus), New Object() {i, RowStatus.Error, GetExceptionMessage(ex)})
        End Try
    End Sub

    'on execution completed
    Private Sub FilesExecutionCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles BgWorker.RunWorkerCompleted
        'hide progress
        Me.Invoke(New toogleProgressDelegate(AddressOf hideProgress), New Object() {})

        'in case of signing on only one file - open the result dialog
        If filenames.Count = 1 Or (Action <> ActionTypes.Verify And selectedSavingType = SavingTypes.Zip) Then
            Dim savedPath As String = SavedResults(gvFiles.Rows(gvFiles.Rows.Count - 1).FilePath)
            If Not gvFiles.Rows(gvFiles.Rows.Count - 1).SignedObject Is Nothing Then
                Dim successDiag As New successDiag(gvFiles.Rows(gvFiles.Rows.Count - 1).SignedObject, savedPath, SuccessOrVerify_Enum.Success, myOptionsProfil.DisplayTimeStamp)
                successDiag.ShowDialog()
            End If
        End If


    End Sub

    'on execution progress changed
    Private Sub FilesExecutionProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs) Handles BgWorker.ProgressChanged
        'update progress
        ' 1 step for gettings provider
        ' 1 step for saving files
        Dim totalSteps As Integer = Me.filenames.Count + 2

        Me.Invoke(New updateProgressDelegate(AddressOf updateProgress), New Object() {totalSteps, e.ProgressPercentage, ""})

    End Sub

#End Region

#Region "sign & verify methodes"

    'sign file
    Private Function sign(ByVal content As Byte(), ByVal filepath As String, ByVal cert As X509Certificate2, ByVal prov As ICryptoProviderBinary) As Byte()
        Dim result() As Byte = Nothing

        'set the signature 
        Dim signInfo As New CryptoSignatureInfo(cert, DateTime.Now)
        signInfo.fileName = IO.Path.GetFileName(filepath)

        'Set the time stamp URL
        signInfo.TimeStampURL = mySelectedProfil.TimeStampURL

        'set the signature options
        Dim signParam As New SignParameters(signInfo)
        signParam.detached = False
        signParam.timeStamped = mySelectedProfil.CheckTimeStamp
        signParam.appName = "Sign and Verify"
        gvFiles.DisplayTS = mySelectedProfil.DisplayTimeStamp
        If prov.ProviderFriendlyName = Constants.PDFFriendlyName Then
            signParam.pdfSignatureAppearanceParameters = GetPdfParams(mySelectedProfil.PdfParameters)
        End If
        Dim obj As CryptoSignedObject(Of Byte())
        obj = prov.Sign(content, signParam)
        result = obj.ContentInfo.signedContent

        If result Is Nothing Then
            Throw New Exception(My.Resources.ErrorMessages.SignFailed)
        End If

        Return result
    End Function

    'coSign file
    Private Function coSign(ByVal coSignType As CoSignType, ByVal filepath As String, ByVal cert As X509Certificate2, ByVal prov As ICryptoProviderBinary) As Byte()

        Dim result() As Byte = Nothing

        'set the signature 
        Dim signInfo As New CryptoSignatureInfo(cert, DateTime.Now)
        signInfo.fileName = filepath

        'Set the time stamp URL
        signInfo.TimeStampURL = mySelectedProfil.TimeStampURL
        gvFiles.DisplayTS = mySelectedProfil.DisplayTimeStamp
        'set the signature options
        Dim signParam As New CoSignParameters(signInfo, coSignType)
        signParam.detached = False
        signParam.timeStamped = mySelectedProfil.CheckTimeStamp

        Dim obj As CryptoSignedObject(Of Byte())
        Dim ProviderCounter As Integer = 1

        Try

            Dim sObj() As Byte = File.ReadAllBytes(filepath)
            obj = prov.CoSign(sObj, signParam)
            result = obj.ContentInfo.signedContent

        Catch ex As SignVerify.Common.SignatureValidationException
            Throw New Exception(My.Resources.ErrorMessages.CoSigningFailed)
        End Try

        If result Is Nothing Then
            Throw New Exception(My.Resources.ErrorMessages.SignFailed)
        End If

        Return result

    End Function

    'verify signed file 
    Private Function verify(ByVal filePath As String) As CryptoSignedObject(Of Byte())
        provider.registryProfil.load()
        'Dim success As Boolean = False
        Dim verifiedObject As CryptoSignedObject(Of Byte()) = Nothing
        Dim verifInfos As New VerifyParameters()

        'get verfy options
        verifInfos.checkCRL = myOptionsProfil.CheckCRL
        verifInfos.CheckTrustChain = myOptionsProfil.CheckCertificationPath
        gvFiles.DisplayTS = myOptionsProfil.DisplayTimeStamp

        Dim obj() As Byte = File.ReadAllBytes(filePath)

        Try
            verifiedObject = Utils.ProvidersHelper.verify(obj, verifInfos, provider.pluginsDirectory)
        Catch ex As SignatureValidationException
            If ex.Message.StartsWith("Could not load file or assembly 'System.Core, Version=3.5.0.0") Then
                Dim instalFwDialog As InstallFW = New InstallFW()
                instalFwDialog.ShowDialog()
            End If
            Throw New Exception(My.Resources.ErrorMessages.NotAVerifiedFile)
        End Try

        Return verifiedObject

    End Function

    'verify signed file 
    Private Function verify(ByVal signedContent As Byte(), ByVal prov As ICryptoProviderBinary) As CryptoSignedObject(Of Byte())
        Dim verifiedObject As CryptoSignedObject(Of Byte()) = Nothing
        Dim success As Boolean = False
        Dim verifInfos As New VerifyParameters()

        'get verfy options
        verifInfos.checkCRL = myOptionsProfil.CheckCRL
        verifInfos.CheckTrustChain = myOptionsProfil.CheckCertificationPath

        verifiedObject = prov.VerifySignature(signedContent, verifInfos)

        'check for a valid signature
        If verifiedObject Is Nothing OrElse verifiedObject.signatureInfos.Count <= 0 OrElse verifiedObject.ContentInfo.originalContent Is Nothing Then
            Throw New Exception(My.Resources.ErrorMessages.NotAVerifiedFile)
        End If

        Return verifiedObject
    End Function


#End Region

#Region "Progress management (progress bar, label)"

    Private Sub showProgress()
        ProgressBar1.Visible = True
        btnCancel.Visible = True
        ProgressBar1.Value = 0
    End Sub

    Private Sub hideProgress()
        ProgressBar1.Visible = False
        btnCancel.Visible = False
    End Sub

    Private Sub updateProgress(ByVal totalSteps As Integer, ByVal currentStep As Integer, ByVal message As String)

        ProgressBar1.Value = currentStep * 100 / totalSteps
        ProgressBar1.Refresh()

    End Sub

#End Region

#Region "Rows events"

    Private Sub changeRowStatus(ByVal rowIndex As Integer, ByVal status As RowStatus, ByVal details As String)
        If rowIndex < 0 OrElse rowIndex > gvFiles.RowCount Then Return

        gvFiles.Rows(rowIndex).ErrorText = details
        gvFiles.Rows(rowIndex).Status = status
        gvFiles.Rows(rowIndex).SignedObject = Results(filenames(rowIndex))


        'scroll the filelist to the active file
        If rowIndex > 2 Then
            plFiles.VerticalScroll.Value = (rowIndex) * 40
        End If
    End Sub

    Private Sub showErrorDiag(ByVal errorMessage As String)
        Dim errorDiag As New errorDiag(errorMessage, My.Resources.ErrorMessages.GeneralError)
        errorDiag.ShowDialog()
    End Sub

    Private Sub OnRowDeleted(ByVal sender As Object, ByVal e As EventArgs) Handles gvFiles.RowDeleted
        If Not TryCast(sender, FileRow) Is Nothing Then

            Dim row As FileRow = TryCast(sender, FileRow)
            gvFiles.removeRow(gvFiles.Rows.FindIndex(Function(r) (row.FilePath.Equals(r.FilePath))))
            filenames.Remove(row.FilePath)
            btnSign.Enabled = (gvFiles.Rows.Count <> 0)
            pnlSign.Enabled = filenames.Count > 0
            If (filenames.Count > 0) Then
                pnlSign.Cursor = Cursors.Hand
            Else
                pnlSign.Cursor = Cursors.Arrow
            End If

            btnVerify.Enabled = (gvFiles.Rows.Count <> 0)
            pnlVerify.Enabled = (gvFiles.Rows.Count <> 0)
            If (gvFiles.Rows.Count <> 0) Then
                pnlVerify.Cursor = Cursors.Hand
            Else
                pnlVerify.Cursor = Cursors.Arrow
            End If
        End If

    End Sub

    Private Sub OnRowClicked(ByVal sender As Object, ByVal e As EventArgs) Handles gvFiles.RowClicked


        If Not TryCast(sender, FileRow) Is Nothing Then

            Dim row As FileRow = TryCast(sender, FileRow)
            Select Case row.Status
                Case RowStatus.None
                    '  Me.Invoke(New RemoveRowDelegate(AddressOf gvFiles.removeRow), New Object() {gvFiles.Rows.Count - 1})
                Case RowStatus.Verified
                    Dim savedPath As String = SavedResults(row.FilePath)
                    Dim successDiag As New successDiag(row.SignedObject, savedPath, SuccessOrVerify_Enum.Success, myOptionsProfil.DisplayTimeStamp)
                    successDiag.ShowDialog()

                Case RowStatus.Error
                    Dim errorDiag As New errorDiag(row.ErrorText, My.Resources.ErrorMessages.GeneralError)
                    errorDiag.ShowDialog()

                Case RowStatus.ZipResult
                    'open the explorer
                    Dim proc As New Diagnostics.Process
                    proc.StartInfo.FileName = "explorer.exe"
                    proc.StartInfo.Arguments = "/select," & row.FilePath
                    proc.Start()


                Case RowStatus.Zipped
                    'open the explorer
                    Dim proc As New Diagnostics.Process
                    proc.StartInfo.FileName = "explorer.exe"
                    proc.StartInfo.Arguments = "/select," & row.FilePath
                    proc.Start()

            End Select

        End If

    End Sub

#End Region

#Region "Menu events"

#Region "options dialog"

    'on sign options clicked
    Private Sub btnSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSystemSettings.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim oldProv As String = Me.myOptionsProfil.ProviderName

            Dim optionsDiag As New OptionsDiag(provider)
            If optionsDiag.ShowDialog() = Windows.Forms.DialogResult.OK Then
                provider.registryProfil.load()
                'TODO: check if change to pdf and show msg
                If oldProv <> Constants.PDFFriendlyName AndAlso Me.myOptionsProfil.ProviderName.Equals(Constants.PDFFriendlyName) Then
                    RemoveNotPdfFiles()
                End If
            End If

        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

#End Region

#Region "Show card details"
    'This method open the user certificate details
    Private Sub BtnShowDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowCardDetails.Click
        ' Certificate.GetMySignCertificateDetails(False)
        If Certificate.GetMySignCertificateDetails(False) = False Then
            NoCardDetailsMessageDiag.ShowDialog() 'in case no certificate exists
        End If
    End Sub
#End Region

#Region "Split button help"
    'This method shows help in chm file
    Private Sub btnHelp_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHelp.ButtonClick
        ShowHelp()
    End Sub
    'This method shows help in chm file
    Private Sub ToolItemHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolItemHelp.Click
        ShowHelp()
    End Sub
    'This method open help in chm file
    Private Sub ShowHelp()
        Dim Dir As New IO.DirectoryInfo(System.IO.Path.GetDirectoryName(Application.ExecutablePath))
        Dim Files() As FileInfo = Dir.GetFiles("SignVerifyUserGuide.chm", SearchOption.AllDirectories)
        If Files.Length = 1 Then
            System.Diagnostics.Process.Start(Files(0).FullName)
        End If
    End Sub
    'show about form
    Private Sub ToolItemAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolItemAbout.Click
        frmAbout.ShowDialog()
    End Sub

#End Region

#Region "Language transition"
    'This method change the language settings
    Private Sub btnSetLang_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeLanguage.Click
        btnChangeLanguage.Text = My.Resources.ControlStrings.SignVerifybtnChangeLanguage
        System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("en-US")
        'CultureInfo.GetCultureInfo("he-IL")
    End Sub
#End Region

#End Region

#Region "Utils methodes"

    'return the most inner exception
    Private Function GetExceptionMessage(ByVal Ex As Exception) As String
        While Not Ex.InnerException Is Nothing
            Ex = Ex.InnerException
        End While

        Return Ex.Message
    End Function

    'This method determine if the signed file is signed in xmldsig (return true, otherwise - false)



    ''' <summary>
    ''' This method sets the certeficate if only one exists.
    ''' </summary>
    ''' <returns>True - if their is only one certeficate, False - otherwise.</returns>
    Private Function SetSingleCertificate() As Boolean
        Dim CertCount As Integer = 0

        'get the certificates collection
        If Not provider.registryProfil Is Nothing AndAlso Not provider.registryProfil.LastCertificateSN = String.Empty Then
            Me.selectedCertificate = Certificate.GetSignCertificateBySerialNumber(provider.registryProfil.LastCertificateSN, provider.registryProfil.ShowOnlyNonRepudiation)
            If Not Me.selectedCertificate Is Nothing Then CertCount = 1
        Else
            Dim certColl As X509Certificate2Collection = Certificate.GetSignCertificateCollection(Me.provider.registryProfil.ShowOnlyNonRepudiation)
            CertCount = certColl.Count
            If certColl.Count = 1 Then
                If Me.selectedCertificate Is Nothing Then
                    'if is the first load
                    Me.selectedCertificate = certColl(0)
                End If
            End If
        End If
        Return CertCount = 1
    End Function


    ''' <summary>
    ''' This method check before cosigning if the certificate is already been used.
    ''' </summary>
    ''' <param name="p_oSignedObject">The signed object which contains the previous signatures.</param>
    ''' <returns>True - if the file is already sign with the sekected certificate, false- otherwise.</returns>
    Private Function IsAlreadySignWithSameCerteficate(ByVal p_oSignedObject As CryptoSignedObject(Of Byte()))
        For Each oCryptoSignatureInfo As CryptoSignatureInfo In p_oSignedObject.signatureInfos
            If Me.selectedCertificate.SubjectName.Name = oCryptoSignatureInfo.certificate.SubjectName.Name Then
                Return True
            End If
        Next

        Return False
    End Function


    'The save file dialog fot selecting the signed file name
    Private Sub SaveFile(ByVal filepath As String, ByVal content As Byte())
        'TODO:warn user if the file already exist
        If Not content Is Nothing Then
            File.WriteAllBytes(filepath, content)
        Else
            Logger.Instance.Warn("Save Signed File failed, no result to save")
        End If
    End Sub

    Private Sub SaveFile(ByVal filepath As String, ByVal contentStream As MemoryStream)
        'TODO:warn user if the file already exist
        Dim fs As New FileStream(filepath, FileMode.Create)
        fs.Write(contentStream.GetBuffer(), 0, contentStream.Position)
        fs.Close()
    End Sub


#End Region

    Friend Shared Function GetPdfParams(PdfParameters As PdfParams) As PDFSignatureAppearanceParameters
        If PdfParameters Is Nothing Then
            Return Nothing
        End If
        If Not PdfParameters.IsVisible Then
            Return Nothing
        End If
        Dim retValue As New PDFSignatureAppearanceParameters
        retValue.contact = PdfParameters.Contact
        retValue.text = PdfParameters.Text

        If PdfParameters.ShowImage Then
            retValue.useDefaultImage = PdfParameters.UseDefaultImage
            If Not String.IsNullOrEmpty(PdfParameters.ImagePath) Then
                retValue.image = File.ReadAllBytes(PdfParameters.ImagePath)
            ElseIf Not retValue.useDefaultImage Then
                Using stream As New System.IO.MemoryStream
                    My.Resources.Signature.Save(stream, My.Resources.Signature.RawFormat)
                    retValue.image = stream.ToArray
                End Using
            End If
        End If
        retValue.location = PdfParameters.Location
        retValue.position = PdfParameters.Position
        retValue.reason = PdfParameters.Reason
        retValue.showName = PdfParameters.ShowName
        Return retValue

    End Function

    Private Function ExistHandling(saveToPath As String, extension As String) As String
        Dim tempName As String = saveToPath
        Dim number As Integer = 0
        While IO.File.Exists(tempName)
            number = number + 1
            Dim lastIndexOf As Integer = tempName.LastIndexOf(extension)
            extension = " (" & number & ")" & extension
            tempName = tempName.Substring(0, lastIndexOf) & extension
        End While

        If tempName <> saveToPath Then
            Dim dialog As FileExistDialog = New FileExistDialog(My.Resources.InfoMessages.FileExist.Replace("XX", Path.GetFileName(saveToPath)), My.Resources.InfoMessages.FileExistTitleBar)
            If dialog.ShowDialog() = DialogResult.Yes Then
                saveToPath = tempName
            End If

        End If
        Return saveToPath

    End Function

    Private Sub RemoveNotPdfFiles()
        Dim files As List(Of FileRow) = gvFiles.Rows.FindAll(AddressOf IsPdf)


        gvFiles.clear()
        For Each File As FileRow In files
            gvFiles.addRow(File.FilePath)
        Next
        If gvFiles.Rows.Count = 0 Then
            btnSign.Enabled = False
        End If

    End Sub

    Private Function IsPdf(ByVal r As FileRow) As Boolean
        Return Path.GetExtension(r.FilePath).Equals(".pdf")
    End Function




    Private Sub GlassButton2_Click(sender As System.Object, e As System.EventArgs) Handles GlassButton2.Click
        gvFiles.clear()
        filenames.Clear()
    End Sub

    Private Sub pnlSign_Click(sender As Object, e As EventArgs) Handles pnlSign.Click, PictureBox1.Click, Label4.Click, Label1.Click
        Try

            'check if one file is for cosigning
            Me.Action = ActionTypes.Sign
            For Each elem As String In filenames
                If Path.GetExtension(elem).ToLower = ".signed" Then
                    Me.Action = ActionTypes.Cosign
                    Exit For
                End If
            Next

            'Check for showing the sign option dialog and get the options
            If Not GetSignOptions() Then Return

            'get the saving options
            If Not GetSavePath() Then Return


            If Not BgWorker.IsBusy Then
                Me.BgWorker.RunWorkerAsync()
            End If

            'CardServices.ClearAllCardsPinCode()
            'AfterSign()

        Catch ex As Exception
            Logger.Instance.Error(ex.ToString(), ex)

        End Try

    End Sub
End Class

