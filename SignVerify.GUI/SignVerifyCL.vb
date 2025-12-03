Imports SignVerify.MainComponent
Imports SignVerify.Common
Imports System.Security.Cryptography.X509Certificates
Imports System.IO
Imports SignVerify.Profils
Imports System.Configuration
Imports System.Threading
Imports System.ComponentModel
Imports SignVerify.Common.Utils


Public Class SignVerfiyCL

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
    'SuccesOrVerify_Enum option
    Public Enum PathType_Enum As Integer
        file = 0
        directory = 1
        web = 2
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
    Private paramsDic As New Dictionary(Of String, String)
    Private SavedResults As Hashtable
    Private _downloadFile As Byte()
    Private m_isQuiet As Boolean
    Private m_OnlyOneFile As Boolean = False

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

    Private m_Ags() As String
#End Region

#Region "Form constructor"
    'ctor
    Public Sub New(ByVal Args() As String, Optional ByVal isQuiet As Boolean = False)
        m_Ags = Args
        Me.m_isQuiet = isQuiet
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
        provider.registryProfil.load()
        SetFiles()
        StartSign()
    End Sub


    'This method binds all the textual values according to the selected language
    Private Sub BindLangTextualValues()
        'Form Header
        Me.Text = My.Resources.ControlStrings.SignVerifyHeader


        ' Me.btnVerify.Text = My.Resources.ControlStrings.SignVerifybtnVerify
    End Sub

    'Enable disable the buttons according to the selected file.


#End Region

#Region "Files browsing "

    'on brownsing file to sign
    Private Sub GlassButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.SuspendLayout()
            gvFiles.clear()
            filenames = New ArrayList(OpenFileDialog1.FileNames)
            For Each elem As String In filenames
                gvFiles.addRow(elem)
            Next
            Me.ResumeLayout()
        End If
    End Sub

#End Region

#Region "Get options  data"

    'check if we need to show the sign diag , and get the options
    Private Function GetSignOptions() As Boolean
        'Check for showing the sign option dialog
        'TODO:for single file ,verify first the file and pass it to the option diag for signature history

        Dim signDiag As SignOptionsDiag = Nothing
        If Action = ActionTypes.Sign Then
            'if we don't want to show the sign diag, just take the saved profile
            If SetSingleCertificate() AndAlso Not Me.selectedCertificate Is Nothing AndAlso Not Me.provider.registryProfil.ShowSignOption Then
                Me.mySelectedProfil = Me.myOptionsProfil
            ElseIf Not m_isQuiet Then
                signDiag = New SignOptionsDiag(provider, False)
            ElseIf Me.selectedCertificate Is Nothing AndAlso m_isQuiet Then
                Me.selectedCertificate = Common.Certificate.GetSignCertificate(True, False)
                Me.mySelectedProfil = Me.myOptionsProfil
            Else
                Me.mySelectedProfil = Me.myOptionsProfil
            End If
        ElseIf Action = ActionTypes.Cosign Then
            selectedCoSignType = CLHelper.GetCosignType(m_Ags)
            If SetSingleCertificate() AndAlso Not Me.selectedCertificate Is Nothing AndAlso Not Me.provider.registryProfil.ShowSignOption Then
                Me.mySelectedProfil = Me.myOptionsProfil
            ElseIf Not m_isQuiet Then
                signDiag = New SignOptionsDiag(provider, True)
            Else
                Me.mySelectedProfil = Me.myOptionsProfil
            End If
        End If
        'show the sign option dialog
        If Not signDiag Is Nothing Then
            If signDiag.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Me.selectedCertificate = signDiag.selectedCertificate
                Me.mySelectedProfil = signDiag.selectedProfil
                selectedCoSignType = signDiag.selectedCoSignType
            Else
                Return False
            End If
        End If
        Return True
    End Function

    'get the path to save the signed files to
    Private Function GetSavePath() As Boolean

        'get the signed files path( folder or filename)
        Dim initialDirectory As String = ""
        'If filenames.Count = 1 Then
        initialDirectory = Common.Utils.CLHelper.GetParam(m_Ags, "d")
        'End If
        If initialDirectory.Equals(String.Empty) Then
            'get the intial category
            If filenames.Count = 1 Then
                If initialDirectory.Equals(String.Empty) Then
                    'get the filename or the directory path
                    If provider.registryProfil.AutoDestinationFolder OrElse provider.registryProfil.DestinationFolder = "" Then
                        initialDirectory = IO.Path.GetDirectoryName(filenames(0))
                    Else
                        initialDirectory = provider.registryProfil.DestinationFolder
                    End If
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
                    'ElseIf Not m_isQuiet Then
                    '    If SaveFolderDiag.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    '        Me.selectedSavingPath = SaveFolderDiag.SelectedPath
                    '        Me.provider.registryProfil.DestinationFolder = SaveFolderDiag.SelectedPath
                    '        Me.provider.registryProfil.save()
                    '    End If
                    '    End

                End If

            Else
                If Me.provider.registryProfil.SavingType = SavingTypes.SeparateAndZip Then
                    SaveFileDiag.InitialDirectory = initialDirectory
                    SaveFileDiag.Filter = "compressed files (*.zip)|*.zip"
                    SaveFileDiag.DefaultExt = "*.zip"
                    SaveFileDiag.FileName = "SignedFiles_" & DateTime.Now.ToString("yyyy-MM-dd") & ".zip"
                    SaveFileDiag.Title = My.Resources.ControlStrings.SignVerifySaveDialogTitle

                ElseIf Me.provider.registryProfil.SavingType = SavingTypes.Zip Then
                    SaveFileDiag.InitialDirectory = initialDirectory
                    SaveFileDiag.Filter = "signed files (*.signed)|*.signed"
                    SaveFileDiag.DefaultExt = "*.signed"
                    SaveFileDiag.FileName = "SignedFiles_" & DateTime.Now.ToString("yyyy-MM-dd") & ".signed"
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
        Else
            Me.selectedSavingPath = initialDirectory
        End If

        'If Me.selectedSavingPath = "" Then Return False
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
            SetExitCode(StatusCodes.NoCertificate)
            Throw New ApplicationException(My.Resources.ErrorMessages.MissingCertificatePrivateKey)
        End If


        Return cert
    End Function

    'get the user selected provider
    Private Function getUserProvider(providerName As String) As ICryptoProviderBinary

        If providerName.Trim = "" Then
            providerName = mySelectedProfil.ProviderName
        ElseIf providerName.StartsWith("xm") Then
            providerName = Constants.XmlDigSigFriendlyName
        ElseIf providerName.StartsWith("pd") Then
            providerName = Constants.PDFFriendlyName
        ElseIf providerName.StartsWith("pk") Then
            providerName = Constants.PKCS7FriendlyName
        Else
            providerName = Constants.XadesFriendlyName
        End If
        'check for null provider
        If providerName.Trim = "" Then
            Logger.Instance.Warn(My.Resources.ErrorMessages.SelectProvider)
            SetExitCode(StatusCodes.ProviderMissing)
            Throw New Exception(My.Resources.ErrorMessages.SelectProvider)
        End If

        'search the choosed signing provider
        Dim prov As ICryptoProviderBinary
        Try
            prov = provider.LoadedPlugins(providerName)
        Catch ex As Exception
            Logger.Instance.Warn(ex.ToString(), ex)
            If prov Is Nothing Then
                Logger.Instance.Warn(My.Resources.ErrorMessages.SelectProvider)
                SetExitCode(StatusCodes.ProviderMissing)
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
    Private Sub StartSign()

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

        If m_isQuiet Then
            Me.CreateHandle()
            ExecuteFiles(Me, New DoWorkEventArgs(New Object()))
            SetExitCode()
        Else
            If Not BgWorker.IsBusy Then
                Me.BgWorker.RunWorkerAsync()
            End If
        End If
        'CardServices.ClearAllCardsPinCode()
        'AfterSign()


    End Sub

    'on verify button clicked
    Private Sub btnVerify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
                Dim pparam = Utils.CLHelper.GetParam(m_Ags, "p").ToLower()
                prov = getUserProvider(pparam)

                    'get saving type
                    selectedSavingType = getUserSavingType()
            Catch ex As CLException
                Throw ex
            Catch ex As Exception
                Logger.Instance.Error(ex.ToString, ex)
                If m_isQuiet Then
                    Throw ex
                End If
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
                        If IsUrl(file) Then
                            content = DownloadFile(file)
                        Else
                            Try
                                content = IO.File.ReadAllBytes(file)
                            Catch ex As Exception
                                SetExitCode(StatusCodes.ReadFileError)
                            End Try

                        End If

                    End If
                    verfiedObj = verify(sign(content, file, cert, prov), prov)

                Else

                    'verify the file
                    Dim signedObject As CryptoSignedObject(Of Byte()) = verify(file)

                    'check if it's sign with a same provider that the one selected
                    If signedObject.ProviderFriendlyName <> prov.ProviderFriendlyName Then
                        SetExitCode(StatusCodes.CosignDifferentProvider)
                        Throw New Exception(My.Resources.ErrorMessages.CosignDifferentProvider)
                    End If

                    'check for cosign with pkcs7
                    If signedObject.ProviderFriendlyName = Constants.PKCS7FriendlyName Then
                        SetExitCode(StatusCodes.CosignPKCS7NotAllowed)
                        Throw New Exception(My.Resources.ErrorMessages.CosignPKCS7NotAllowed)
                    End If
                    If signedObject.ProviderFriendlyName = Constants.XadesFriendlyName Then
                        SetExitCode(StatusCodes.CosignXadesNotAllowed)
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

                If Not saveToPath.Equals(String.Empty) Then
                    If IsFolder(saveToPath) Then
                        If IsUrl(file) Then 
                            saveToPath = Path.Combine(saveToPath, GetFileNameByUrl(file))
                        Else
                            saveToPath = Path.ChangeExtension(Path.Combine(saveToPath, Path.GetFileName(file)), ".signed")
                        End If
                    Else
                        saveToPath = Path.ChangeExtension(saveToPath, ".signed")
                    End If
                ElseIf SavingType = SavingTypes.Separate And Me.provider.registryProfil.AutoDestinationFolder Then
                    saveToPath = Path.ChangeExtension(file, ".signed")
                End If

                If Path.GetExtension(saveToPath).Length = 0 Then
                    saveToPath = Path.Combine(saveToPath, Path.GetFileNameWithoutExtension(file) & ".signed")
                End If
                Me.Invoke(New SaveFileDelegate(AddressOf SaveFile), New Object() {saveToPath, verfiedObj.ContentInfo.signedContent})
                SavedResults.Add(file, saveToPath)


            End If

            If Action = ActionTypes.Verify Then
                SavedResults.Add(file, file)
            End If
            Results.Add(file, verfiedObj)

            'set the row status to "Verified"
            Me.Invoke(New changeRowStatusDelegate(AddressOf changeRowStatus), New Object() {i, RowStatus.Verified, ""})
        Catch ex As CLException
            If m_OnlyOneFile Then
                Throw ex
            End If

        Catch ex As Exception
            If m_isQuiet AndAlso m_OnlyOneFile Then
                SetExitCode(StatusCodes.UnExpectedError)
            End If
            Logger.Instance.Error(ex.ToString, ex)
            Me.Invoke(New changeRowStatusDelegate(AddressOf changeRowStatus), New Object() {i, RowStatus.Error, GetExceptionMessage(ex)})
        End Try
    End Sub

    'on execution completed
    Private Sub FilesExecutionCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles BgWorker.RunWorkerCompleted
        'hide progress
        Me.Invoke(New toogleProgressDelegate(AddressOf hideProgress), New Object() {})
        SetExitCode()

        'in case of signing on only one file - open the result dialog
        If filenames.Count = 1 Or (Action <> ActionTypes.Verify And selectedSavingType = SavingTypes.Zip) Then
            Dim savedPath As String = SavedResults(gvFiles.Rows(gvFiles.Rows.Count - 1).FilePath)
            If Not gvFiles.Rows(gvFiles.Rows.Count - 1).SignedObject Is Nothing Then
                If Not CLHelper.IsQuietMoade(m_Ags) Then
                    Dim successDiag As New successDiag(gvFiles.Rows(gvFiles.Rows.Count - 1).SignedObject, savedPath, SuccessOrVerify_Enum.Success, myOptionsProfil.DisplayTimeStamp)
                    successDiag.ShowDialog()
                End If

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
            signParam.pdfSignatureAppearanceParameters = SignVerfiy.GetPdfParams(mySelectedProfil.PdfParameters)
        End If
        Dim obj As CryptoSignedObject(Of Byte())
        obj = prov.Sign(content, signParam)
        result = obj.ContentInfo.signedContent

        If result Is Nothing Then
            SetExitCode(StatusCodes.SignError)
            Throw New Exception(My.Resources.ErrorMessages.SignFailed)
        End If

        Return result

    End Function

    'coSign file
    Private Function coSign(ByVal coSignType As CoSignType, ByVal filepath As String, ByVal cert As X509Certificate2, ByVal prov As ICryptoProviderBinary) As Byte()

        Dim result() As Byte = Nothing
        Dim sObj() As Byte = Nothing
        'set the signature 
        Dim signInfo As New CryptoSignatureInfo(cert, DateTime.Now)
        signInfo.fileName = filepath

        'Set the time stamp URL
        signInfo.TimeStampURL = mySelectedProfil.TimeStampURL

        'set the signature options
        Dim signParam As New CoSignParameters(signInfo, coSignType)
        signParam.detached = False
        signParam.timeStamped = mySelectedProfil.CheckTimeStamp
        gvFiles.DisplayTS = mySelectedProfil.DisplayTimeStamp
        Dim obj As CryptoSignedObject(Of Byte())
        Dim ProviderCounter As Integer = 1


        If IsUrl(filepath) Then
            sObj = DownloadFile(filepath)
        Else
            Try
                sObj = File.ReadAllBytes(filepath)
            Catch
                SetExitCode(StatusCodes.ReadFileError)
            End Try
        End If
        Try
            obj = prov.CoSign(sObj, signParam)
            result = obj.ContentInfo.signedContent

        Catch ex As SignVerify.Common.SignatureValidationException
            SetExitCode(StatusCodes.SignError)
            Throw New Exception(My.Resources.ErrorMessages.CoSigningFailed)
        End Try

        If result Is Nothing Then
            SetExitCode(StatusCodes.SignError)
            Throw New Exception(My.Resources.ErrorMessages.SignFailed)
        End If

        Return result

    End Function

    'verify signed file 
    Private Function verify(ByVal filePath As String) As CryptoSignedObject(Of Byte())
        provider.registryProfil.load()
        Dim success As Boolean = False
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
            SetExitCode(StatusCodes.SignatureNotValid)
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
            SetExitCode(StatusCodes.SignatureNotValid)
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
            plFiles.VerticalScroll.Value = Math.Min((rowIndex) * 40, plFiles.VerticalScroll.Maximum)
        End If
    End Sub

    Private Sub showErrorDiag(ByVal errorMessage As String)
        Dim errorDiag As New errorDiag(errorMessage, My.Resources.ErrorMessages.GeneralError)
        errorDiag.ShowDialog()
    End Sub

    Private Sub OnRowClicked(ByVal sender As Object, ByVal e As EventArgs) Handles gvFiles.RowClicked


        If Not TryCast(sender, FileRow) Is Nothing Then

            Dim row As FileRow = TryCast(sender, FileRow)
            Select Case row.Status

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
    Private Sub btnSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim optionsDiag As New OptionsDiag(provider)
            optionsDiag.ShowDialog()
            provider.registryProfil.load()
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

#End Region

#Region "Show card details"
    'This method open the user certificate details
    Private Sub BtnShowDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Certificate.GetMySignCertificateDetails(False)
        If Certificate.GetMySignCertificateDetails(False) = False Then
            NoCardDetailsMessageDiag.ShowDialog() 'in case no certificate exists
        End If
    End Sub
#End Region

#Region "Split button help"
    'This method shows help in chm file
    Private Sub btnHelp_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ShowHelp()
    End Sub
    'This method shows help in chm file
    Private Sub ToolItemHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
    Private Sub ToolItemAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmAbout.ShowDialog()
    End Sub

#End Region

#Region "Language transition"
    'This method change the language settings

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

   

    ''' <summary>
    ''' This method sets the certeficate if only one exists.
    ''' </summary>
    ''' <returns>True - if their is only one certeficate, False - otherwise.</returns>
    Private Function SetSingleCertificate() As Boolean
        Dim CertCount As Integer = 0
        selectedCertificateSN = Common.Utils.CLHelper.GetParam(m_Ags, "c").ToUpper().Trim()
        
        If Not selectedCertificateSN = String.Empty Then
            Me.selectedCertificate = Certificate.GetSignCertificateBySerialNumber(selectedCertificateSN, provider.registryProfil.ShowOnlyNonRepudiation)
            If Not Me.selectedCertificate Is Nothing Then CertCount = 1
            'get the certificates collection
        ElseIf Not provider.registryProfil Is Nothing AndAlso Not provider.registryProfil.LastCertificateSN = String.Empty Then
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
            If IsUrl(filepath) Then
                UploadFile(filepath, content)
            Else
                File.WriteAllBytes(filepath, content)
            End If
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



    Private Function SetCLSavePath(ByVal filePath As String) As String
        If m_Ags.Length > 1 AndAlso Not m_Ags(1).StartsWith("-") Then
            If m_Ags(1).ToLower().Equals("/dd") Then

                If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Me.SuspendLayout()
                    gvFiles.clear()
                    filenames = New ArrayList(OpenFileDialog1.FileNames)
                    For Each elem As String In filenames
                        gvFiles.addRow(elem)
                    Next
                    Me.ResumeLayout()
                    Return String.Empty
                End If
            ElseIf m_Ags(1).ToLower().Equals("/as") Then
                Return String.Empty
            Else
                Return m_Ags(1)
            End If
        ElseIf IsUrl(filePath) Then
            If SaveFolderDiag.ShowDialog() = Windows.Forms.DialogResult.OK Then

                'Me.selectedSavingPath = SaveFolderDiag.SelectedPath
                'Me.provider.registryProfil.DestinationFolder = SaveFolderDiag.SelectedPath
                'Me.provider.registryProfil.save()
                Return SaveFolderDiag.SelectedPath
            End If
        End If
        Return String.Empty
    End Function

    Private Sub SetFiles()
        If IsFolder(m_Ags(0)) Then
            filenames.AddRange(Directory.GetFiles(m_Ags(0)))
        Else
            filenames.Add(m_Ags(0))
        End If
        If filenames.Count = 1 Then
            m_OnlyOneFile = True
        End If
        BindLangTextualValues()
        For Each elem As String In filenames
            gvFiles.addRow(elem)
        Next
        Me.ResumeLayout()
    End Sub


    Private Function DownloadFile(Uri As String) As Byte()
        Try
            Return Common.Utils.CLHelper.DownloadFile(Uri)
        Catch ex As Exception
            Logger.Instance.Error(String.Format("Error on downloading file from {0}.", Uri), ex)
            SetExitCode(StatusCodes.DownloadError)
            Throw New Exception(My.Resources.ErrorMessages.DownloadFailed)
        End Try
    End Function


    Private Function UploadFile(filepath As String, content As Byte()) As String
        Try
            Return Common.Utils.CLHelper.UploadFile(filepath, content)
        Catch ex As Exception
            Logger.Instance.Error(String.Format("Error on sending signed file to destination {0}.", filepath), ex)
            SetExitCode(StatusCodes.UploadError)
            Throw New Exception(My.Resources.ErrorMessages.UploadFailed)
        End Try
    End Function

    Private Sub GetOpacity()
        If CLHelper.IsQuietMoade(m_Ags) Then
            Me.Opacity = 0
        End If
    End Sub


    Private Sub SetExitCode()
        For Each Row As FileRow In gvFiles.Rows
            If IsFailed(Row.SignedObject) Then
                'Throw New CLException(StatusCodes.SignError)
            End If
        Next
       
    End Sub
    Private Sub SetExitCode(ByVal statusCode As StatusCodes)
        If m_isQuiet Then
            Throw New CLException(statusCode)
        End If
    End Sub

    Private Function IsFailed(cryptoSignedObject As CryptoSignedObject(Of Byte())) As Boolean
        If cryptoSignedObject Is Nothing Then
            Return True
        Else
            For Each info As CryptoSignatureInfo In cryptoSignedObject.signatureInfos
                If info.EndSignatureState = EndSignatureStateType.CertificateExpired Or info.EndSignatureState = EndSignatureStateType.SignatureUnvalid Then
                    Return True
                End If
            Next
        End If
        Return False
    End Function

   


End Class

