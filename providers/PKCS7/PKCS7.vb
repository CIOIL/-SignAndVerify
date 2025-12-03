Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports SignVerify.Common
Imports System.Security.Cryptography.X509Certificates
Imports System.IO
Imports System.Security.Cryptography.Pkcs
Imports System.Security.Cryptography


Namespace PKCS7Provider


    Public Class PKCS7
        Implements ICryptoProviderBinary

        Public Sub New()

        End Sub


#Region "ICryptoProvider<byte[]> public methodes"

        ' Gets the frendly name of the provider.
        Public ReadOnly Property ProviderFriendlyName() As String Implements IBaseCryptoProvider.ProviderFriendlyName
            Get
                Return "PKCS7 crypto provider."
            End Get
        End Property

        Public Function Sign(ByVal objectToSign As Byte(), ByVal signingParameters As SignParameters) As CryptoSignedObject(Of Byte()) Implements ICryptoProvider(Of Byte()).Sign
            Logger.Instance.Info("Start signing ")
            If (Not signingParameters.signatureInfo.certificate.HasPrivateKey) Then
                Logger.Instance.Error("Certificate does not contain private key and can not be used for signing")
                Throw New ApplicationException(My.Resources.ErrorMessages.NotContainingPrivateKey)
            End If

            Dim signer As CmsSigner = New CmsSigner(signingParameters.signatureInfo.certificate)
            signer.IncludeOption = X509IncludeOption.EndCertOnly
            Logger.Instance.Info(String.Format("Certificate:{0} ", signingParameters.signatureInfo.certificate.IssuerName))

            'add signed attributes

            Try
                Dim documentName As Pkcs9DocumentName = Nothing
                Dim documentDescription As Pkcs9DocumentDescription = Nothing
                Dim signingTime As Pkcs9SigningTime = New Pkcs9SigningTime(DateTime.Parse(signingParameters.signatureInfo.signingTime))
                If signingParameters.signatureInfo.fileName.Length > 0 Then
                    documentName = New Pkcs9DocumentName(signingParameters.signatureInfo.fileName)
                    documentDescription = New Pkcs9DocumentDescription(Path.GetExtension(signingParameters.signatureInfo.fileName).Trim("."))

                    Logger.Instance.Info(String.Format("document name:{0} ", documentName))
                    Logger.Instance.Info(String.Format("document description:{0} ", documentDescription))
                End If

                signer.SignedAttributes.Add(signingTime)
                signer.SignerIdentifierType = SubjectIdentifierType.IssuerAndSerialNumber
                If Not documentName Is Nothing Then
                    signer.SignedAttributes.Add(documentName)
                    signer.SignedAttributes.Add(documentDescription)
                End If
            Catch ex As Exception
                Logger.Instance.Error(ex)
            End Try

            'Dim OID As New Oid(Guid.NewGuid().ToString(), "MY guid")
            'Dim asn As New AsnEncodedData(OID, objectToSign)
            'signer.SignedAttributes.Add(asn)
            'create new signedCms
            Dim info As ContentInfo = New ContentInfo(objectToSign)
            Dim cms As SignedCms = New SignedCms(info, signingParameters.detached)
          
            'sign the file
            cms.ComputeSignature(signer, False)
           
            Logger.Instance.Info("finish signing")
            'create the CryptoSignedObject

            Return getCryptoSignedObject(cms)

        End Function

        Public Function CoSign(ByVal objectToSign As Byte(), ByVal signingParameters As CoSignParameters) As CryptoSignedObject(Of Byte()) Implements ICryptoProvider(Of Byte()).CoSign
            'not support siging with this provider 
            Throw New ApplicationException(My.Resources.ErrorMessages.CosignNotSupported)

            If (Not signingParameters.signatureInfo.certificate.HasPrivateKey) Then
                Throw New ApplicationException(My.Resources.ErrorMessages.NotContainingPrivateKey) '"Certificate does not contain private key and can not be used for signing")
            End If

            'create new signedCms
            Dim info As ContentInfo = New ContentInfo(objectToSign)
            Dim cms As SignedCms = New SignedCms()
            cms.Decode(objectToSign)

            'create new signer
            Dim signer As CmsSigner = New CmsSigner(signingParameters.signatureInfo.certificate)
            signer.IncludeOption = X509IncludeOption.EndCertOnly

            'add signed attributes

            'for signverify backward compatibily if the cosign type is parrallel then the filename 
            'of the signature , and the filedescription was the originals ones
            Try
                Dim signingTime As Pkcs9SigningTime = New Pkcs9SigningTime(Date.Parse(signingParameters.signatureInfo.signingTime))
                Dim documentName As Pkcs9DocumentName = New Pkcs9DocumentName(getOriginalFileName(cms))
                Dim documentDescription As Pkcs9DocumentDescription = New Pkcs9DocumentDescription(Path.GetExtension(documentName.DocumentName).TrimStart("."))
                signer.SignedAttributes.Add(signingTime)
                signer.SignedAttributes.Add(documentName)
                signer.SignedAttributes.Add(documentDescription)

            Catch ex As Exception

            End Try


            'check the previous signatures
            cms.CheckSignature(True)

            'sign the file
            If signingParameters.CoSignType = CoSignType.OverSignature Then
                For Each signerInfo As SignerInfo In cms.SignerInfos
                    signerInfo.ComputeCounterSignature(signer)
                Next
            Else
                cms.ComputeSignature(signer, False)
            End If

            'create the CryptoSignedObject
            Return getCryptoSignedObject(cms)
        End Function

        Public Function VerifySignature(ByVal signedObject As Byte(), ByVal verifyParameters As VerifyParameters) As CryptoSignedObject(Of Byte()) Implements ICryptoProvider(Of Byte()).VerifySignature
            Logger.Instance.Info(String.Format("verify parameters: checkCRL: {0}, CheckTrustChain:{1}", verifyParameters.checkCRL, verifyParameters.CheckTrustChain))
            Logger.Instance.Info("start verifying")

            Try
                Dim cms As SignedCms = New SignedCms()

                Try
                    cms.Decode(signedObject)
                Catch ex As Exception
                    Logger.Instance.Info(String.Format("failed verifying, trying parsing. {0}", ex.ToString(), ex))
                    Dim oBytes() As Byte = ConvertByBase64(signedObject)
                    cms.Decode(oBytes)
                End Try
                Logger.Instance.Info("finish verifying")

                Return getCryptoSignedObject(cms, verifyParameters)
            Catch ex As Exception
                Logger.Instance.Info("failed verifying:" & ex.ToString)
                Throw ex
            End Try
        End Function


#End Region


#Region "helper methodes"

        'create CryptoSignedObject from SignedCms
        Private Function getCryptoSignedObject(ByVal cms As SignedCms, Optional ByVal verifyParameters As VerifyParameters = Nothing) As CryptoSignedObject(Of Byte())

            Dim verifCertificate As Boolean = True

            'minimum verfication by default
            If verifyParameters Is Nothing Then
                verifyParameters = New VerifyParameters()
                verifCertificate = False
            End If

            Dim content As New CryptoContentInfo(Of Byte())(cms.Encode)
            content.originalFileName = getOriginalFileName(cms)
            content.originalContent = cms.ContentInfo.Content
            Dim ret As CryptoSignedObject(Of Byte()) = New CryptoSignedObject(Of Byte())(content, Me.ProviderFriendlyName)
            ret.detached = cms.Detached

            For Each signer As SignerInfo In cms.SignerInfos
                'add signature informations
                ret.signatureInfos.Add(getSignatureInfoFromSigner(signer, verifyParameters, verifCertificate))
            Next

            Return ret
        End Function

        'get signatureInfo from SignerInfo instance
        Private Function getSignatureInfoFromSigner(ByVal signer As SignerInfo, ByVal verifyParameters As VerifyParameters, ByVal verifCertificate As Boolean) As CryptoSignatureInfo

            'get the signature informations

            Dim item As CryptoSignatureInfo = New CryptoSignatureInfo(signer.Certificate)
            'item.signatureAlgorithm = signer.DigestAlgorithm
            item.SignatureStandard = SignatureStandard.pkcs7
            Dim signingTime As Pkcs9SigningTime = New Pkcs9SigningTime()
            Dim documentName As Pkcs9DocumentName = New Pkcs9DocumentName()
            Dim documentDescription As Pkcs9DocumentDescription = New Pkcs9DocumentDescription()

            'add custom attributes ( signing time and filename )
            For Each attribute As CryptographicAttributeObject In signer.SignedAttributes

                If signingTime.Oid.Value = attribute.Oid.Value Then
                    signingTime.CopyFrom(attribute.Values(0))
                    item.signingTime = signingTime.SigningTime.ToString()

                ElseIf documentName.Oid.Value = attribute.Oid.Value Then
                    documentName.CopyFrom(attribute.Values(0))
                    item.fileName = documentName.DocumentName
                End If
            Next

            If verifCertificate Then
                item.EndSignatureState = verifyEndSignature(signer)
                If item.EndSignatureState <> EndSignatureStateType.SignatureUnvalid Then
                    If verifyParameters.CheckTrustChain Then item.ChainSignatureState = Certificate.getCertificateChainState(signer.Certificate)
                    item.CRLstate = Certificate.getCertificateCRLState(signer.Certificate, verifyParameters)
                End If
            End If

            'add the counter signatures
            For Each counterSigner As SignerInfo In signer.CounterSignerInfos
                item.counterSignatures.Add(getSignatureInfoFromSigner(counterSigner, verifyParameters, verifCertificate))
            Next

            Return item
        End Function

        'verify cerificate and return his status
        Private Function verifyEndSignature(ByVal signer As SignerInfo) As EndSignatureStateType
            'check the signature only
            Try
                signer.CheckSignature(True)
            Catch ex As Exception
                Logger.Instance.Error("verifyEndSignature failed", ex)
                Return EndSignatureStateType.SignatureUnvalid
            End Try

            'check the signature chain
            Return Certificate.getEndCertificateState(signer.Certificate)

        End Function

        'get the original filename 
        '(the filename of the first signature)
        Private Function getOriginalFileName(ByVal cms As SignedCms) As String
            Dim signer As SignerInfo = cms.SignerInfos(cms.SignerInfos.Count - 1)

            Dim item As CryptoSignatureInfo = New CryptoSignatureInfo(signer.Certificate)
            item.SignatureStandard = SignatureStandard.pkcs7
            Dim documentName As New Pkcs9DocumentName()
            Dim documentDescription As New Pkcs9DocumentDescription()


            'add custom attributes ( signing time and filename )
            For Each attribute As CryptographicAttributeObject In signer.SignedAttributes
                If documentName.Oid.Value = attribute.Oid.Value Then documentName.CopyFrom(attribute.Values(0))

                'get extension from documentdescription attribute (?)
                'capicomhandler (old sign verify dll) save the extension here
                If documentDescription.Oid.Value = attribute.Oid.Value Then documentDescription.CopyFrom(attribute.Values(0))

            Next

            'return the filename if it isn't nothing
            If Not documentName Is Nothing And Not documentName.DocumentName Is Nothing And Not documentDescription Is Nothing Then
                Dim docName As String = Path.GetFileNameWithoutExtension(getCleanSignedAttributeString(documentName.RawData))
                Dim extension As String = getCleanSignedAttributeString(documentDescription.RawData).Trim(".")
                Return docName & "." & extension
            End If

            'return empty string 
            Return ""

        End Function

        'return a clean string wihtout control chars
        Private Function getCleanSignedAttributeString(ByRef arrayToClean As Byte()) As String
            Dim invalidFilenameChars As New Collections.ArrayList
            For Each elem As Char In Path.GetInvalidFileNameChars
                invalidFilenameChars.Add(elem)
            Next
            Dim result As New StringBuilder
            Dim asChars() As Char = Encoding.Unicode.GetChars(arrayToClean, 2, arrayToClean.Length - 2)
            For Each sChar As Char In asChars
                If Not Char.IsControl(sChar) AndAlso Not invalidFilenameChars.Contains(sChar) Then
                    result.Append(sChar)
                End If
            Next

            Return result.ToString

        End Function



        'this method convert the bytes array to base64 (for older version signed with capicom)
        Private Function ConvertByBase64(ByVal signedObject() As Byte) As Byte()

            Try
                Return Utils.EncodingHelper.ConvertFromBase64(signedObject)
            Catch ex As FormatException
                Logger.Instance.Warn("can not verify converting to base 64")
                Return signedObject
            Catch InnerEx As Exception
                Return signedObject

            End Try
        End Function


#End Region
    End Class
End Namespace
