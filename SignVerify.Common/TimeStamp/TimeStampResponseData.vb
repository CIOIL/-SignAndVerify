Imports LipingShare.LCLib.Asn1Processor
Imports System.Security.Cryptography.Pkcs
Imports System.Security.Cryptography
Imports System.Security.Cryptography.X509Certificates
Imports SignVerify.Common
Imports System.Collections.Generic
Imports System

Namespace SignVerify.Common.TimeStamp


    

    Public Class TimeStampResponseData

        Public ReadOnly DataBytes() As Byte
        Public ReadOnly DataAsn1 As Asn1Node
        Public ReadOnly SignedData As SignedCms
        Public ReadOnly Certificate As X509Certificate2
        Public ReadOnly TimeStamp As DateTime
        Private _ValidationResult As TimeStampResponseState
        Public ReadOnly Property ValidationResult() As TimeStampResponseState
            Get
                Return _ValidationResult
            End Get
        End Property

        Public Sub New(ByVal Data() As Byte)
            'load bytes
            Me.DataBytes = Data

            'decode asn1
            Me.DataAsn1 = New Asn1Node
            If Not DataAsn1.LoadData(Data) Then
                Me.DataAsn1 = Nothing
                Return
            End If

            'decode pkcs7
            SignedData = New SignedCms()
            Try
                SignedData.Decode(Me.DataBytes)
                If SignedData.SignerInfos.Count < 1 Then Throw New Exception
            Catch ex As Exception
                SignedData = Nothing
                Return
            End Try

            'get certificate
            Certificate = SignedData.SignerInfos(0).Certificate

            'get time
            TimeStamp = DateTime.ParseExact(GetTimeStamp, "yyyyMMddhhmmss.fffZ", Threading.Thread.CurrentThread.CurrentUICulture)
        End Sub



#Region "Response validation"

        Public Function Validate(ByVal OriginalContent As Byte(), ByVal OriginalNonce As Guid) As TimeStampResponseState

            _ValidationResult = New TimeStampResponseState
            _ValidationResult.ResponseStatus = TimeStampResponseStatus.Granted

            'unvalid asn1 
            If DataBytes Is Nothing OrElse DataAsn1 Is Nothing Then
                _ValidationResult.ValidationErrors.Add(TimeStampResponseValidationErrors.UnvalidData)
                Return _ValidationResult
            End If

            'unvalid pkcs7
            If SignedData Is Nothing Then
                _ValidationResult.ValidationErrors.Add(TimeStampResponseValidationErrors.UnvalidSignedData)
                Return _ValidationResult
            End If

            'verify the response signature
            If Not IsSignatureValid() Then
                _ValidationResult.ValidationErrors.Add(TimeStampResponseValidationErrors.UnvalidSignature)
                Return _ValidationResult
            End If


            'verify signedcertificate has the same that the one in TS token
            Dim TSAcert As X509Certificate2 = GetTSACertficate()
            If TSAcert Is Nothing OrElse TSAcert.SerialNumber <> Certificate.SerialNumber Then
                _ValidationResult.ValidationErrors.Add(TimeStampResponseValidationErrors.CertificateNotMatch)
            End If

            'get the certificate state
            _ValidationResult.CertificateState = SignVerify.Common.Certificate.getEndCertificateState(Certificate)
            _ValidationResult.ChainState = SignVerify.Common.Certificate.getCertificateChainState(Certificate)
            _ValidationResult.CRLState = SignVerify.Common.Certificate.getCertificateCRLState(Certificate)
            If _ValidationResult.CertificateState = EndSignatureStateType.CertificateExpired Or _ValidationResult.CRLState = CRLSignatureStateType.Revoked Then
                _ValidationResult.ValidationErrors.Add(TimeStampResponseValidationErrors.CertificateRevoked)
            End If
            If _ValidationResult.ChainState <> ChainSignatureStateType.Valid Then
                _ValidationResult.ValidationWarnings.Add(TimeStampResponseValidationWarnings.TrustChainUnvalid)
            End If
            If _ValidationResult.CRLState <> CRLSignatureStateType.Valid Then
                _ValidationResult.ValidationWarnings.Add(TimeStampResponseValidationWarnings.CRLUnchecked)
            End If

            'check original message hash Equal to the timestamped one
            If Not IsOriginalContent(OriginalContent) Then
                _ValidationResult.ValidationErrors.Add(TimeStampResponseValidationErrors.UnvalidHashContent)
            End If


            'check original guid as Equal that the timestamped one
            If Not OriginalNonce = Guid.Empty AndAlso Not IsOriginalNonce(OriginalNonce) Then
                _ValidationResult.ValidationErrors.Add(TimeStampResponseValidationErrors.UnvalidGuid)
            End If

            Return _ValidationResult
        End Function

        Private Function IsSignatureValid() As Boolean
            'check signature
            Try
                SignedData.SignerInfos(0).CheckSignature(True)
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Private Function IsOriginalContent(ByVal OrignalContent As Byte()) As Boolean
            'hash the original content
            Dim OriginalContentHash As Byte() = Utils.ConvertToHashedMessage(OrignalContent)

            'compare the hash strings
            Return Utils.GetStringHex(OriginalContentHash) = Utils.GetStringHex(GetResponseHashedContent)
        End Function

        ''' <summary>
        ''' This method retrives the nonce from the rersponse.
        ''' </summary>
        ''' <param name="OriginalNonce">The nonce, if included, allows the client to verify the timeliness of
        ''' the response when no local clock is available.</param>
        ''' <returns>True - If the nonce is equal, otherwise - false. </returns>
        Private Function IsOriginalNonce(ByVal OriginalNonce As Guid) As Boolean
            Dim Node As Asn1Node = GetNonce()
            If Node Is Nothing Then
                Return False
            End If
            Dim oTSANonce As String = Utils.ConvertByteArraytoString(Node.Data)
            Dim oOriginalNonce As String = Utils.ConvertByteArraytoString(OriginalNonce.ToByteArray)

            Return oTSANonce = oOriginalNonce
        End Function

#End Region

#Region "Response navigation"
        ''' <summary>
        ''' This method returns the hash messge from the response.
        ''' </summary>
        ''' <returns>The hash message from the response as hex decimal string</returns>
        Private Function GetResponseHashedContent() As Byte()
            'FR:Dim HashMessage As Asn1Node = DataAsn1.GetChildNode(1).GetChildNode(1).GetChildNode(0).GetChildNode(2).GetChildNode(1).GetChildNode(0).GetChildNode(0).GetChildNode(2).GetChildNode(1)
            Dim HashMessage As Asn1Node = DataAsn1.GetChildNode(1).GetChildNode(0).GetChildNode(2).GetChildNode(1).GetChildNode(0).GetChildNode(2).GetChildNode(1)
            Return HashMessage.Data
        End Function

        Private Function GetNonce() As Asn1Node
            'FR: Return DataAsn1.GetChildNode(1).GetChildNode(1).GetChildNode(0).GetChildNode(2).GetChildNode(1).GetChildNode(0).GetChildNode(0).GetChildNode(5)
            Return DataAsn1.GetChildNode(1).GetChildNode(0).GetChildNode(2).GetChildNode(1).GetChildNode(0).GetChildNode(5)

        End Function


        ''' <summary>
        ''' This method return from the rersponse the certificate according to details.
        ''' </summary>
        ''' <returns>The <see cref="X509Certificate2">certificate</see> which was used by the TSA.</returns>
        Private Function GetTSACertficate() As X509Certificate2

            Dim Node As Asn1Node = DataAsn1.GetChildNode(1).GetChildNode(0).GetChildNode(3).GetChildNode(0)
            If Not Node Is Nothing Then
                Dim oCert As New X509Certificate2(Node.Data)
                Return oCert
            End If

            Return Nothing
        End Function


        ''' <summary>
        ''' This method returns the time stamp from the response as String 
        ''' </summary>
        ''' <returns>The time stamp as date time </returns>
        Public Function GetTimeStamp() As String
            'FR:Dim TSNode As Asn1Node = DataAsn1.GetChildNode(1).GetChildNode(1).GetChildNode(0).GetChildNode(2).GetChildNode(1).GetChildNode(0).GetChildNode(0).GetChildNode(4)
            Dim TSNode As Asn1Node = DataAsn1.GetChildNode(1).GetChildNode(0).GetChildNode(2).GetChildNode(1).GetChildNode(0).GetChildNode(4)

            If Not TSNode Is Nothing Then
                Dim str As String = Asn1Util.BytesToString(Utils.GetBytes(TSNode))
                str = str.Substring(2, str.Length - 2)

                Return str
            End If
            Return String.Empty

        End Function
#End Region

    End Class
End Namespace