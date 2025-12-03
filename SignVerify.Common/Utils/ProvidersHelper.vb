Imports SignVerify.Common
Imports SignVerify
Imports System.IO
Imports System.Reflection
Imports System.Collections.Generic
Imports System
Imports System.Security.Cryptography.X509Certificates
Imports System.Collections


Namespace SignVerify.Common.Utils

    Public Enum ProviderName As Integer
        XmlDigSig
        PKCS7 = 1
        Xades = 2
        PDF = 3
    End Enum

    Public Class ProvidersHelper

#Region "Public methodes"



        Public Shared Function verify(ByVal signedObject As Byte(), ByVal verifyParametersInfo As VerifyParameters, ByVal providerFolderPath As String) As CryptoSignedObject(Of Byte())
            'load providers from directory
            Dim loadedPlugins As Dictionary(Of String, IBaseCryptoProvider)
            loadedPlugins = getProvidersFromDirectory(providerFolderPath)

            Dim verifiedObject As CryptoSignedObject(Of Byte()) = Nothing
            Dim ProviderCounter As Integer = 1

            'Dim isXml As Boolean = IsSignedFileIsXML(signedObject)
            
            'iterate over all loaded provider
            For Each loadedType As Object In loadedPlugins.Values
                If Not verifiedObject Is Nothing Then Exit For
                For Each providerInterface As Type In loadedType.GetType.GetInterfaces
                    Try
                        Select Case providerInterface.Name

                            Case "ICryptoProviderBinary"

                                ProviderCounter += 1

                                'If isXml AndAlso Not loadedType.ToString().EndsWith("XmlDigSig") Then
                                '    Continue For
                                'ElseIf Not isXml And loadedType.ToString().EndsWith("XmlDigSig") Then
                                '    Continue For
                                'End If

                                Dim result As CryptoSignedObject(Of Byte()) = CType(loadedType, ICryptoProviderBinary).VerifySignature(signedObject, verifyParametersInfo)
                                verifiedObject = result
                                
                                Exit For

                        End Select

                    Catch ex As Exception
                    End Try
                Next
            Next

            'check for a valid signature
            If verifiedObject Is Nothing OrElse verifiedObject.signatureInfos.Count <= 0 OrElse verifiedObject.ContentInfo.originalContent Is Nothing Then
                Throw New SignatureValidationException("Valid signed content not found.")
            End If

            Return verifiedObject
        End Function

        Public Shared Function verify(ByVal signedObject As Byte(), ByVal verifyParametersInfo As VerifyParameters) As CryptoSignedObject(Of Byte())
            Return verify(signedObject, verifyParametersInfo, getCurrentDirectory)
        End Function

        Public Shared Function coSign(ByVal objectToSign() As Byte, ByVal signingParameters As CoSignParameters, ByVal providerFolderPath As String) As CryptoSignedObject(Of Byte())

            'load providers from directory
            Dim loadedPlugins As Dictionary(Of String, IBaseCryptoProvider)
            loadedPlugins = getProvidersFromDirectory(providerFolderPath)

            'verify the content first
            Dim verifyParam As New VerifyParameters()
            verifyParam.checkCRL = False
            verifyParam.CheckTrustChain = False
            Dim verifiedObject As CryptoSignedObject(Of Byte()) = verify(objectToSign, verifyParam, providerFolderPath)

            'retrive the provider 
            Dim prov As ICryptoProviderBinary = DirectCast(loadedPlugins.Item(verifiedObject.ProviderFriendlyName), ICryptoProviderBinary)

            'cosign 
            Return prov.CoSign(objectToSign, signingParameters)

        End Function

        Public Shared Function coSign(ByVal objectToSign() As Byte, ByVal signingParameters As CoSignParameters) As CryptoSignedObject(Of Byte())
            Return coSign(objectToSign, signingParameters, getCurrentDirectory)
        End Function

        Public Shared Function Sign(fileToSign As String, Optional ByVal providerName As ProviderName = Utils.ProviderName.Xades, Optional destination As String = "", Optional certificateSN As String = "", Optional ByVal providerFolderPath As String = "") As String

            Dim providerFName As String = Constants.XadesFriendlyName
            If providerName = Utils.ProviderName.PKCS7 Then
                providerFName = Constants.PKCS7FriendlyName
            ElseIf providerName = Utils.ProviderName.XmlDigSig Then
                providerFName = Constants.XmlDigSigFriendlyName
            ElseIf providerName = Utils.ProviderName.PDF Then
                providerFName = Constants.PDFFriendlyName
            End If


            If providerFolderPath = "" Then
                providerFolderPath = getCurrentDirectory()
            End If

            Dim loadedPlugins As Dictionary(Of String, IBaseCryptoProvider)
            loadedPlugins = getProvidersFromDirectory(providerFolderPath)
            Dim prov As ICryptoProviderBinary = DirectCast(loadedPlugins.Item(providerFName), ICryptoProviderBinary)

            Dim cert As X509Certificate2 = Nothing
            If certificateSN <> "" Then
                cert = Certificate.GetSignCertificateBySerialNumber(certificateSN, False)
            End If
            If cert Is Nothing Then
                cert = Certificate.GetSignCertificate(True, False)
            End If

            Return ExecuteFile(fileToSign, destination, cert, prov)


        End Function

        Public Shared Function Sign(ByVal content As Byte(), Optional ByVal signingParameters As SignParameters = Nothing, Optional ByVal providerName As ProviderName = Utils.ProviderName.Xades, Optional ByVal providerFolderPath As String = "") As Byte()
            If signingParameters Is Nothing Then
                Dim cert As X509Certificate2 = Certificate.GetSignCertificate(True, False)
                Dim signInfo As New CryptoSignatureInfo(cert, DateTime.Now)
                signingParameters = New SignParameters(signInfo)
            End If

            Dim providerFName As String = Constants.XadesFriendlyName
            If providerName = Utils.ProviderName.PKCS7 Then
                providerFName = Constants.PKCS7FriendlyName
            ElseIf providerName = Utils.ProviderName.XmlDigSig Then
                providerFName = Constants.XmlDigSigFriendlyName
            ElseIf providerName = Utils.ProviderName.PDF Then
                providerFName = Constants.PDFFriendlyName
            End If

            Dim result() As Byte = Nothing

            Dim loadedPlugins As Dictionary(Of String, IBaseCryptoProvider)
            loadedPlugins = getProvidersFromDirectory(providerFolderPath)
            Dim prov As ICryptoProviderBinary = DirectCast(loadedPlugins.Item(providerFName), ICryptoProviderBinary)

            Dim obj As CryptoSignedObject(Of Byte())
            obj = prov.Sign(content, signingParameters)
            result = obj.ContentInfo.signedContent

            If result Is Nothing Then
                Throw New Exception("Error On sign")
            End If

            Return result
        End Function

#End Region

#Region "Private methodes"

        'This method determine if the signed file is signed in xmldsig (return true, otherwise - false)
        Public Shared Function IsSignedFileIsXML(ByVal content As Byte()) As Boolean
            Dim oFile As New Xml.XmlDocument()
            Dim ms As New MemoryStream
            ms.Write(content, 0, content.Length)
            ms.Position = 0
            Try
                oFile.Load(ms)
            Catch ex As Exception
                Return False
            End Try
            Return True
        End Function

        Public Shared Function getProvidersFromDirectory(ByVal providerFolderPath As String) As Dictionary(Of String, IBaseCryptoProvider)
            If Not Path.IsPathRooted(providerFolderPath) Then
                '#If DEBUG Then
                '                providerFolderPath = Path.Combine("C:\", providerFolderPath)
                '#Else
                '                providerFolderPath = Path.Combine(getCurrentDirectory(), providerFolderPath)
                '#End If
                providerFolderPath = Path.Combine(getCurrentDirectory(), providerFolderPath)
            End If

            Dim loader As New ProvidersLoader(providerFolderPath)

            'check for "no provider found" error
            If loader.LoadedPlugins.Count = 0 Then
                Throw New ProvidersNotFoundException(providerFolderPath)
            End If

            Return loader.LoadedPlugins
        End Function

        Public Shared Function getCurrentDirectory() As String
            Return Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location)
        End Function

        Private Shared Function ExecuteFile(ByVal sourceFile As String, ByVal destination As String, ByVal cert As X509Certificate2, ByVal prov As ICryptoProviderBinary) As String
            Dim verfiedObj As CryptoSignedObject(Of Byte()) = Nothing
            Dim content() As Byte = Nothing
            Dim result() As Byte = Nothing

            If IsUrl(sourceFile) Then
                content = DownloadFile(sourceFile)
            Else
                content = IO.File.ReadAllBytes(sourceFile)
            End If

            Dim signInfo As New CryptoSignatureInfo(cert, DateTime.Now)
            signInfo.fileName = IO.Path.GetFileName(sourceFile)

            'set the signature options


            If Path.GetExtension(sourceFile).ToLower <> ".signed" Then
                Dim obj As CryptoSignedObject(Of Byte())
                Dim signParam As New SignParameters(signInfo)
                signParam.detached = False
                obj = prov.Sign(content, signParam)
                result = obj.ContentInfo.signedContent
                If result Is Nothing Then
                    Throw New Exception("Sign failed")
                End If
            Else

                Dim csp As New CoSignParameters(signInfo, CoSignType.Parallel)
                Dim obj As CryptoSignedObject(Of Byte())
                obj = prov.CoSign(content, csp)
                result = obj.ContentInfo.signedContent
              
                If result Is Nothing Then
                    Throw New Exception("CoSign failed")
                End If

            End If

            Dim saveToPath As String = destination

            If IsUrl(sourceFile) Then
                If saveToPath = "" Then
                    Throw New Exception("Destination path is mendatory for downloaded files.")
                End If
                If IsFolder(saveToPath) Then
                    saveToPath = Path.Combine(saveToPath, GetFileNameByUrl(sourceFile))
                End If
            Else
                If saveToPath = "" Then
                    saveToPath = Path.GetDirectoryName(sourceFile)
                End If
                If Path.GetExtension(saveToPath).Length = 0 Then
                    saveToPath = Path.Combine(saveToPath, Path.GetFileNameWithoutExtension(sourceFile) & ".signed")
                End If
            End If

            If IsUrl(saveToPath) Then
                Return UploadFile(saveToPath, result)
            Else
                File.WriteAllBytes(saveToPath, result)
                Return "Success"
            End If

        End Function

#End Region

    End Class
End Namespace