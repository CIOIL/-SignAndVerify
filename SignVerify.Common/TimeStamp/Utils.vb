Imports System.IO
Imports LipingShare.LCLib.Asn1Processor
Imports System
Imports System.Security.Cryptography.X509Certificates
Namespace SignVerify.Common.TimeStamp


    ''' <summary>
    ''' This class contains contains ASN1 services for parsing and building the
    ''' ASN1 request and response.
    ''' </summary>
    Public Class Utils

#Region "Casting methodes"

        ''' <summary>
        ''' This method gets asn1 node and convert it to hexadecimal string
        ''' </summary>
        ''' <param name="RootNode">The node to convert.</param>
        ''' <returns>The converted  hexadecimal string</returns>
        Public Shared Function GetStringHex(ByVal RootNode As Asn1Node) As String
            Return Asn1Util.ToHexString(GetBytes(RootNode))
        End Function

        ''' <summary>
        ''' This method gets data and convert it to hexadecimal string
        ''' </summary>
        ''' <param name="Data">The data to convert.</param>
        ''' <returns>The converted  hexadecimal string</returns>
        Public Shared Function GetStringHex(ByVal Data() As Byte) As String
            Return Asn1Util.ToHexString(Data)
        End Function

        ''' <summary>
        ''' This method gets asn1 node and convert it to byte array.
        ''' </summary>
        ''' <param name="RootNode">The node to convert.</param>
        ''' <returns>The converted byte array.</returns>
        Public Shared Function GetBytes(ByVal RootNode As Asn1Node) As Byte()

            Dim ms As MemoryStream = GetStream(RootNode)
            Dim data() As Byte = Array.CreateInstance(Type.GetType("System.Byte"), ms.Length)
            ms.Read(data, 0, CInt(ms.Length))
            ms.Close()
            Return data
        End Function

        ''' <summary>
        ''' This method gets asn1 node and convert it to memory stream.
        ''' </summary>
        ''' <param name="RootNode">The node to convert.</param>
        ''' <returns>The converted memory stream.</returns>
        Public Shared Function GetStream(ByVal RootNode As Asn1Node) As MemoryStream
            Dim ms As New MemoryStream
            RootNode.SaveData(ms)
            ms.Position = 0
            Return ms
        End Function



        ''' <summary>
        ''' This method returns the byte array as string.
        ''' </summary>
        ''' <param name="p_oArr">The byte array to convert</param>
        ''' <returns>The convert array to string</returns>
        Public Shared Function ConvertByteArraytoString(ByVal p_oArr() As Byte) As String
            Dim str As String
            Dim enc As New System.Text.ASCIIEncoding()
            str = enc.GetString(p_oArr)
            Return str
        End Function

        ''' <summary>
        ''' This method returns the string as byte array.
        ''' </summary>
        ''' <param name="p_sStr">The stringto convert</param>
        ''' <returns>The convert string to Byte array</returns>
        Public Shared Function ConvertStringToByteArray(ByVal p_sStr As String) As Byte()
            Return System.Text.Encoding.UTF8.GetBytes(p_sStr)
        End Function

#End Region

#Region "Hashing methods"
        ''' <summary>
        ''' This method get data and hash it uing sha1
        ''' </summary>
        ''' <param name="p_oOriginalMessage">The original message as byte array</param>
        ''' <returns>The hash of the origianl message using sha1 provider.</returns>
        Public Shared Function ConvertToHashedMessage(ByVal p_oOriginalMessage() As Byte) As Byte()
            Dim sha1Prov As System.Security.Cryptography.SHA1CryptoServiceProvider = System.Security.Cryptography.SHA1CryptoServiceProvider.Create()
            sha1Prov.ComputeHash(p_oOriginalMessage)
            Return sha1Prov.Hash()
        End Function

#End Region

#Region "ASN1 methods"
        ''' <summary>
        ''' This method returns sequence node
        ''' </summary>
        ''' <returns>The sequence node.</returns>
        Public Shared Function GetSequenceNode() As Asn1Node
            'The root asn node which contains the request
            Dim SequenceNode As New Asn1Node()
            SequenceNode.Tag = Asn1Tag.SEQUENCE
            Return SequenceNode
        End Function

        ''' <summary>
        ''' This method returns PKI State node
        ''' </summary>
        ''' <param name="p_ePKIState">The pki status to insert to the asn1 node as integer.</param>
        ''' <returns>The PKI State node.</returns>
        Public Shared Function GetPKIStateNode(ByVal p_ePKIState As TimeStampResponseStatus) As Asn1Node
            'The PKIState node contains the state of the requesr/response
            Dim PKIStatusNode As New Asn1Node()
            PKIStatusNode.Tag = Asn1Tag.INTEGER
            PKIStatusNode.Data = New Byte() {CByte(p_ePKIState)}
            Return PKIStatusNode
        End Function


        ''' <summary>
        ''' This method returns the statusString field of <see cref="PKIFailureInfo_Enum"> PKIStatusInfo.</see>
        '''  PKIStatusInfo be used to include reason text such as "messageImprint field is not correctly formatted".
        ''' </summary>
        ''' <param name="p_sStatusString"> The error free string message .</param>
        ''' <returns>The failure info status string node.</returns>
        Public Shared Function GetPKIFreeTextNode(ByVal p_sStatusString As String) As Asn1Node
            'The PKIState node contains the state of the requesr/response
            Dim PKIStatusNode As New Asn1Node()
            PKIStatusNode.Tag = Asn1Tag.BIT_STRING
            PKIStatusNode.Data = New Byte() {CByte(p_sStatusString)}
            Return PKIStatusNode
        End Function

        ''' <summary>
        ''' This method returns PKI failure info node
        ''' </summary>
        ''' <param name="p_ePKIFailureInfo">The failure info message as appear in the PKIStatusInfo</param>
        ''' <returns>The failure info node.</returns>
        Public Shared Function GetPKIFailureInfoNode(ByVal p_ePKIFailureInfo As TimeStampFailures) As Asn1Node
            'The PKIState node contains the state of the request/response
            Dim PKIStatusNode As New Asn1Node()
            PKIStatusNode.Tag = Asn1Tag.BIT_STRING
            PKIStatusNode.Data = New Byte() {CByte(p_ePKIFailureInfo)}
            Return PKIStatusNode
        End Function

        ''' <summary>
        ''' The method returns serial number node the node is a unique id.
        ''' </summary>
        ''' <returns>The serial number field.</returns>
        Public Shared Function GetSerialNumberNode() As Asn1Node
            Dim oSerialNumber As New Asn1Node
            oSerialNumber.Tag = Asn1Tag.INTEGER
            oSerialNumber.Data = Guid.NewGuid().ToByteArray()
            Return oSerialNumber
        End Function

        ''' <summary>
        ''' The version field (currently v1) describes the version of the Time-Stamp request.
        ''' </summary>
        ''' <returns>The version field.</returns>
        Public Shared Function GetVersionNode() As Asn1Node
            Dim oVersion As New Asn1Node
            oVersion.Tag = Asn1Tag.INTEGER
            oVersion.Data = New Byte() {1}
            Return oVersion
        End Function


        ''' <summary>
        ''' This method returns the TSAPolicyId.
        ''' </summary>
        ''' <returns>The TSAPolicyId field.</returns>
        Public Shared Function GetTSAPolicyIdNode() As Asn1Node
            Dim oTSAPolicyId As New Asn1Node
            oTSAPolicyId.Tag = Asn1Tag.OBJECT_IDENTIFIER
            oTSAPolicyId.Data = Asn1Util.StringToBytes("1.2.3.4.5")
            Return oTSAPolicyId
        End Function


        ''' <summary>
        ''' This method create the message imprint node which contains the hash algorithm (sha1)
        ''' and the user's hashed message
        ''' </summary>
        ''' <param name="p_oOriginalHashMessage">the original user's message (hashed) as byte array</param>
        ''' <returns>The message imprint as ASN1 node</returns>
        Public Shared Function GetMessageImprintNode(ByVal p_oOriginalHashMessage() As Byte) As Asn1Node
            'The messageImprint field 
            Dim oMessageImprint As Asn1Node = GetSequenceNode()

            'The hash algorithm field
            Dim oHashAlgorithmSequence As Asn1Node = GetSequenceNode()

            ' The hash algorithm oid field
            Dim oHashAlgorithmOID As Asn1Node = GetHashAlgorithmNode()

            oHashAlgorithmSequence.AddChild(oHashAlgorithmOID)
            oMessageImprint.AddChild(oHashAlgorithmSequence)

            'Add the hash is represented as an OCTET STRING
            oMessageImprint.AddChild(GetHashMessageNode(p_oOriginalHashMessage))

            Dim s As String = GetStringHex(oMessageImprint)
            Return oMessageImprint
        End Function

        ''' <summary>
        ''' The hash algorithm indicated in the hashAlgorithm field SHOULD be a
        ''' known hash algorithm (one-way and collision resistant).  That means
        ''' that it SHOULD be one-way and collision resistant.  The Time Stamp
        ''' Authority SHOULD check whether or not the given hash algorithm is
        ''' known to be "sufficient" (based on the current state of knowledge in
        ''' cryptanalysis and the current state of the art in computational
        ''' resources, for example).  If the TSA does not recognize the hash
        ''' algorithm or knows that the hash algorithm is weak (a decision left
        ''' to the discretion of each individual TSA), then the TSA SHOULD refuse
        ''' to provide the time-stamp token by returning a pkiStatusInfo of
        ''' bad_alg'.
        ''' </summary>
        ''' <returns>The hash algoritmn asn1 node</returns>
        Public Shared Function GetHashAlgorithmNode() As Asn1Node
            Dim oHashAlgoOID As New Asn1Node
            oHashAlgoOID.Tag = Asn1Tag.OBJECT_IDENTIFIER
            Dim oSha1oid As New Security.Cryptography.Oid
            oSha1oid.FriendlyName = "sha1"
            Dim TempOid As New Oid
            oHashAlgoOID.Data = TempOid.Encode(oSha1oid.Value)
            Return oHashAlgoOID
        End Function

        ''' <summary>
        ''' The hash is represented as an OCTET STRING.  Its
        ''' length MUST match the length of the hash value for that algorithm
        ''' (e.g., 20 bytes for SHA-1 or 16 bytes for MD5).
        ''' </summary>
        ''' <param name="OriginalHashMessage">The original hash message as send by the user.</param>
        ''' <returns>The hash message node</returns>
        Public Shared Function GetHashMessageNode(ByVal OriginalHashMessage() As Byte) As Asn1Node
            Dim oHashedMessage As New Asn1Node
            oHashedMessage.Tag = Asn1Tag.OCTET_STRING
            oHashedMessage.Data = OriginalHashMessage
            Return oHashedMessage
        End Function

        ''' <summary>
        '''  If the certificate required field is present and set to true, the TSA's public key
        ''' certificate that is referenced by the ESSCertID identifier inside a
        ''' SigningCertificate attribute in the response MUST be provided by the
        ''' TSA in the certificates field from the SignedData structure in that
        ''' response.  That field may also contain other certificates.
        ''' </summary>
        ''' <returns>The node containing the certificate required node.</returns>
        Public Shared Function GetCertificateRequiredNode() As Asn1Node
            Dim oRequesCertificate As New Asn1Node
            oRequesCertificate.Tag = Asn1Tag.BOOLEAN
            oRequesCertificate.Data = New Byte() {255} 'Change to true

            Return oRequesCertificate
        End Function

        ''' <summary>
        ''' This method returns the nonce, if included, allows the client to verify the timeliness of
        ''' the response when no local clock is available.  The nonce is a large
        ''' random number with a high probability that the client generates it
        '''  only once (e.g., a 64 bit integer).  In such a case the same nonce
        ''' value MUST be included in the response, otherwise the response shall
        ''' be rejected.
        ''' </summary>
        ''' <param name="p_oNonce">The nonce guid unique integer</param>
        ''' <returns>The node containing the nonce node </returns>
        Public Shared Function GetNonceNode(ByVal p_oNonce As Guid) As Asn1Node
            Dim oNonce As New Asn1Node
            oNonce.Tag = Asn1Tag.INTEGER
            oNonce.Data = p_oNonce.ToByteArray()

            Return oNonce
        End Function

        Public Shared Function GetTSCertGlobalStatus(TimeStampState As TimeStamp.TimeStampResponseState) As SignaturesStateType

            If TimeStampState Is Nothing Then
                Return SignaturesStateType.Unchecked
            ElseIf TimeStampState.CertificateState = EndSignatureStateType.SignatureUnvalid Or _
                   TimeStampState.CertificateState = EndSignatureStateType.CertificateExpired Or _
                   TimeStampState.CRLState = CRLSignatureStateType.Revoked Or _
                   TimeStampState.ChainState = ChainSignatureStateType.Unvalid Then
                Return SignaturesStateType.UnValid
            ElseIf TimeStampState.CRLState = CRLSignatureStateType.Unchecked Or _
               TimeStampState.ChainState = ChainSignatureStateType.Unchecked Or _
                TimeStampState.CertificateState = EndSignatureStateType.Unchecked Then
                Return SignaturesStateType.Unchecked
            ElseIf TimeStampState.CRLState = CRLSignatureStateType.Unknown Then
                Return SignaturesStateType.Unknow
            Else 'valid
                Return SignaturesStateType.Valid
            End If

        End Function

        Public Shared Function GetTSCrlGlobalStatus(TimeStampState As TimeStamp.TimeStampResponseState) As CRLSignatureStateType

            If TimeStampState Is Nothing Then
                Return CRLSignatureStateType.Unchecked
            End If
            Return TimeStampState.CRLState

        End Function

#End Region

    End Class
End Namespace