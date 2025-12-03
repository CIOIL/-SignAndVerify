Imports SignVerify.Common
Imports SignVerify.MainComponent
Imports SignVerify.Profils
Imports SignVerify.GUI.SignVerfiy
Imports System.IO
Imports System.Text

Public Module Main

    <Runtime.InteropServices.DllImport("kernel32.dll")> _
    Private Function AttachConsole(dwProcessId As Integer) As Boolean
    End Function

    'The main entry point for the application.
    <STAThread()> _
    Public Sub Main(ByVal Args() As String)

        Try
            Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)
            'create an instance of a form
            'if an argument was sepcified then
            If Args.GetLength(0) = 1 Then
                'display the file in the form, or do some action on the file
                Dim sSignedFileName As String = Args(0)
                If Path.GetExtension(sSignedFileName).ToLower = ".signed" Then
                    SignedFileDoubleClicked(sSignedFileName)
                Else
                    AttachConsole(-1)
                    OpenedWithArguments(Args, False)
                End If
            ElseIf Args.GetLength(0) > 1 Then
                AttachConsole(-1)
                OpenedWithArguments(Args, True)
            Else
                'continue to run the application
                Application.Run(New SignVerfiy())
            End If
        Catch ex As Exception
            Logger.Instance.Error(ex)
            Throw ex
        Finally
            'CardServices.Close()
            Logger.Instance.Error("finish")
        End Try
    End Sub
    Dim provider As New SignVerifyProvider()
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

    'This method handels the case a signed file is double clicked and opens the succes dialog.
    Public Sub SignedFileDoubleClicked(ByVal SignedFileName As String)
        Dim filename As String = SignedFileName
        Dim oRes As CryptoSignedObject(Of Byte()) = verifyDoubleClicked(filename)
        If oRes Is Nothing Then
            Dim errorDiag As New errorDiag(My.Resources.ErrorMessages.NotAVerifiedFile, My.Resources.ErrorMessages.VerifyHeader)
            errorDiag.ShowDialog()
            Exit Sub
        End If
        Dim oSuccessDiag As New successDiag(oRes, SignedFileName, SuccessOrVerify_Enum.Verify, myOptionsProfil.DisplayTimeStamp)
        oSuccessDiag.ShowInTaskbar = True
        oSuccessDiag.Icon = Global.SignVerify.GUI.My.Resources.icon_paper
        oSuccessDiag.StartPosition = FormStartPosition.CenterScreen
        oSuccessDiag.TopMost = True
        oSuccessDiag.IsOnTop = True
        oSuccessDiag.ShowDialog()
    End Sub

    'verify signed file 
    Private Function verifyDoubleClicked(ByVal filename As String) As CryptoSignedObject(Of Byte())



        provider.registryProfil.load()
        Dim success As Boolean = False
        Dim verifiedObject As CryptoSignedObject(Of Byte()) = Nothing
        Dim verifInfos As New VerifyParameters()

        'get verfy options
        verifInfos.checkCRL = myOptionsProfil.CheckCRL
        verifInfos.CheckTrustChain = myOptionsProfil.CheckCertificationPath

        Dim obj() As Byte = File.ReadAllBytes(filename)


        Try
            verifiedObject = Utils.ProvidersHelper.verify(obj, verifInfos, provider.pluginsDirectory)
        Catch ex As SignatureValidationException
            Logger.Instance.Error("verifyDoubleClicked failed", ex)
        End Try

        Return verifiedObject

    End Function

    Private Sub OpenedWithArguments(Args As String(), onlyOneFile As Boolean)

        Dim arguments As String() = Args
        'Dim oRes As List(Of CryptoSignedObject(Of Byte())) = signWithArguments(arguments)
        'If oRes Is Nothing Then
        If NeedHelp(arguments) Then
            Dim helpText As String = GetHelpText()
            Console.WriteLine(helpText)
        ElseIf IsQuietMoade(arguments) Then
            Try
                Console.WriteLine("Start siging file..")
                Dim signCl As New SignVerfiyCL(Args, True)
                Console.WriteLine("File signed successfuly.")
                Environment.Exit(1)
            Catch ex As CLException
                Console.WriteLine("SignVerifyCL failed:" + ex.Message)
                Logger.Instance.Error("SignVerifyCL failed:", ex)
                Environment.Exit(CInt(ex.StatusCode))
            Catch ex As Exception
                Console.WriteLine("SignVerifyCL Unknow error details:" + ex.Message)
                Logger.Instance.Error("SignVerifyCL Unknow error:", ex)
                Environment.Exit(CInt(StatusCodes.UnExpectedError))
            End Try
        Else
            Application.Run(New SignVerfiyCL(Args))
        End If



        Exit Sub
        'End If
    End Sub

    Private Function IsQuietMoade(arguments As String()) As Boolean
        For i As Integer = 1 To arguments.Length - 1
            If arguments(i).Equals("-q") Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Function NeedHelp(arguments As String()) As Boolean
        For i As Integer = 0 To arguments.Length - 1
            If arguments(i).Equals("-h") Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Function GetHelpText() As String
        Dim helpText As StringBuilder = New StringBuilder()
        helpText.AppendLine(Environment.NewLine)
        helpText.Append("signandverify [-h] | [fileName [-q] [-p Provider name] [-c Certificate thumbprint] [-d Destination path]]")
        helpText.AppendLine(Environment.NewLine)
        helpText.AppendLine("-h     " + " Display this help.")
        helpText.AppendLine("-q     " + " Quiet mode.")
        helpText.AppendLine("-p     " + " Choose the provider to sign with. Xades (default) Xmldsig pdf or pkcs7.")
        helpText.AppendLine("-c     " + " The certificate thumbprint in the current user store to sign with.If empty the last used will be taken.")
        helpText.AppendLine("-d     " + " The destination folder for saving the signed file.")
        Return helpText.ToString()
    End Function




End Module