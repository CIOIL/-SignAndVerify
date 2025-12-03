Imports SignVerify.Common
Imports System.Xml
Imports System.Security.Cryptography
Imports System.Security.Cryptography.Xml
Imports System.Security.Cryptography.X509Certificates
Imports System.Security.Cryptography.Pkcs
Imports System.Text
Imports System.IO
Imports System.Reflection
Imports SignVerify.Common.TimeStamp



Public Class XmlDigSig
    Implements ICryptoProviderBinary
    Private Const SDK_VERSION As String = "1.0.2"
    Private Const XML_VERSION As String = "3.0.0"
    Private Const NS_GOVIL As String = "http://www.gov.il/xmldigsig/v_1_0_0"
    Private Const NS_GOVIL_OLD As String = "http://www.gov.il/xmldigsig"
    Private Const NS_XADES As String = "http://uri.etsi.org/01903/v1.3.2#"
    Private Const NS_XMLDSIG As String = "http://www.w3.org/2000/09/xmldsig#"

#Region "Constructor"


    'constructor
    Public Sub New()

    End Sub

#End Region

#Region "Properties"

    Public ReadOnly Property ProviderFriendlyName() As String Implements IBaseCryptoProvider.ProviderFriendlyName
        Get
            Return "XmlDigSig crypto provider."
        End Get
    End Property

#End Region

#Region "ICryptoProvider<byte[]> public methodes"


    Public Function Sign(ByVal objectToSign() As Byte, ByVal signingParameters As SignParameters) As CryptoSignedObject(Of Byte()) Implements SignVerify.Common.ICryptoProvider(Of Byte()).Sign

        Logger.Instance.Info(String.Format("Sign started." & "Parameters: File name:{0}, Certificate:{1}, ALGO:{2}, TS:{3}", signingParameters.signatureInfo.fileName, signingParameters.signatureInfo.certificate.FriendlyName, signingParameters.signatureInfo.signatureAlgorithm, signingParameters.timeStamped))
        Dim filePath As String = signingParameters.signatureInfo.fileName
        Dim dataID As String = "il-" & Guid.NewGuid.ToString

        If Not signingParameters.signatureInfo.certificate.HasPrivateKey Then
            Logger.Instance.Info("The certificate cannot contains private key to sign with")
            Throw New ApplicationException(My.Resources.ErrorMessges.NotContainingPrivateKey)
        End If

        'Create xml document
        Dim xmlDoc As New XmlDocument()
        xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", "utf-8", ""))

        'Namespaces and prefixs declarations
        Dim namespaceManager As New System.Xml.XmlNamespaceManager(xmlDoc.NameTable)
        namespaceManager.AddNamespace(String.Empty, SignedXml.XmlDsigNamespaceUrl)
        'same as the above use this constants Xml.SignedXml.XmlDsigNamespaceUrl

        'Add the root element 
        Dim root As XmlNode = xmlDoc.CreateNode(XmlNodeType.Element, "gov.il", "SignedRoot", NS_GOVIL)
        'define used namespaces
        'XADES
        Dim msAtt As XmlAttribute = xmlDoc.CreateAttribute("xmlns:xa")
        msAtt.Value = NS_XADES
        'root.Attributes.Append(msAtt)
        'XMLDSIG
        msAtt = xmlDoc.CreateAttribute("xmlns:ds")
        msAtt.Value = NS_XMLDSIG
        'root.Attributes.Append(msAtt)

        'set version attributes
        Dim versAtt As XmlAttribute = xmlDoc.CreateAttribute("version")
        versAtt.Value = SDK_VERSION
        root.Attributes.Append(versAtt)

        xmlDoc.AppendChild(root)

        'Add SigningAppInfo node(application name , application version)
        Dim SigningAppInfo As XmlNode = xmlDoc.CreateNode(XmlNodeType.Element, "gov.il", "SigningAppInfo", NS_GOVIL)

        Dim AppName As XmlNode = xmlDoc.CreateNode(XmlNodeType.Element, "gov.il", "ApplicationName", NS_GOVIL)
        AppName.InnerText = signingParameters.appName
        Dim AppVersion As XmlNode = xmlDoc.CreateNode(XmlNodeType.Element, "gov.il", "ApplicationVersion", NS_GOVIL)
        AppVersion.InnerText = XML_VERSION
        SigningAppInfo.AppendChild(AppName)
        SigningAppInfo.AppendChild(AppVersion)
        xmlDoc.DocumentElement.AppendChild(SigningAppInfo)


        'Create SignedObject node ( contains data )
        Dim SignedObject As XmlNode = xmlDoc.CreateNode(XmlNodeType.Element, "gov.il", "SignedObject", NS_GOVIL)
        Dim SignedObjectMimeType As XmlAttribute = xmlDoc.CreateAttribute("MimeType")
        SignedObjectMimeType.Value = defineMime(filePath)
        Dim idAtt As XmlAttribute = xmlDoc.CreateAttribute("Id")
        idAtt.Value = "il-" & Guid.NewGuid.ToString
        SignedObject.Attributes.Append(SignedObjectMimeType)
        SignedObject.Attributes.Append(idAtt)


        'Create  SignedInfo to SignedObject  (contains data and additional to be signed)
        Dim SignedInfo As XmlNode = xmlDoc.CreateNode(XmlNodeType.Element, "gov.il", "SignedInfo", NS_GOVIL)
        idAtt = xmlDoc.CreateAttribute("Id")
        idAtt.Value = dataID
        ' SignedInfo.Attributes.Append(idAtt)

        'Create and add data node(contains data to be signed)
        Dim data As XmlNode = xmlDoc.CreateNode(XmlNodeType.Element, "gov.il", "Data", NS_GOVIL)
        Dim mimeType As XmlAttribute = xmlDoc.CreateAttribute("MimeType")
        mimeType.Value = defineMime(filePath)
        data.Attributes.Append(mimeType)

        Dim dataEncodingType As XmlAttribute = xmlDoc.CreateAttribute("DataEncodingType")

        Try
            'XML encoding 
            Dim doc As New XmlDocument()
            Using ms As New MemoryStream(objectToSign)
                ms.Position = 0
                Dim reader As New StreamReader(ms)
                doc.LoadXml(reader.ReadToEnd)
                If doc.FirstChild.NodeType = XmlNodeType.XmlDeclaration Then
                    doc.RemoveChild(doc.FirstChild)
                End If
                data.InnerXml = doc.OuterXml
                dataEncodingType.Value = "xml"
            End Using
        Catch ex As Exception

            'BASE64 encoding
            dataEncodingType.Value = "base64"
            data.InnerText = Convert.ToBase64String(objectToSign)
        End Try

        data.Attributes.Append(dataEncodingType)
        SignedInfo.Attributes.Append(idAtt)
        SignedInfo.AppendChild(data)

        'Create and add optionalData node( contains additional data)
        Dim optionalDataParam As XmlNode = xmlDoc.CreateNode(XmlNodeType.Element, "gov.il", "OptionalDataParams", NS_GOVIL)
        Dim filename As XmlNode = xmlDoc.CreateNode(XmlNodeType.Element, "gov.il", "FileName", NS_GOVIL)
        filename.InnerText = filePath.Substring(filePath.LastIndexOf("\") + 1)
        optionalDataParam.AppendChild(filename)

        Dim ContentCreationTime As XmlNode = xmlDoc.CreateNode(XmlNodeType.Element, "gov.il", "ContentCreationTime", NS_GOVIL)

        If filePath <> "" Then
            ContentCreationTime.InnerText = IO.File.GetCreationTime(filePath).ToUniversalTime.ToString("yyyy-MM-ddThh:mm:ssZ")
        Else
            ContentCreationTime.InnerText = DateTime.Now.ToUniversalTime.ToString("yyyy-MM-ddThh:mm:ssZ")
        End If

        optionalDataParam.AppendChild(ContentCreationTime)
        SignedInfo.AppendChild(optionalDataParam)

        'Add SignedInfo node
        SignedObject.AppendChild(SignedInfo)

        'Add SignedObject node
        xmlDoc.DocumentElement.AppendChild(SignedObject)

        Logger.Instance.Info("Before compute signature.")
        ' Get the XML representation of the signature and save
        ' it to an XmlElement object.
        Dim references As New ArrayList
        references.Add(dataID)
        Dim xmlDigitalSignature As XmlElement = createSignature(xmlDoc, signingParameters, references)

        ' Append the element to the XML document.
        xmlDoc.DocumentElement.AppendChild(xmlDoc.ImportNode(xmlDigitalSignature, True))
        Logger.Instance.Info("After compute signature.")
        Dim content As New CryptoContentInfo(Of Byte())(System.Text.Encoding.UTF8.GetBytes(xmlDoc.OuterXml))
        content.originalContent = objectToSign
        content.originalFileName = signingParameters.signatureInfo.fileName
        Dim ret As CryptoSignedObject(Of Byte()) = New CryptoSignedObject(Of Byte())(content, Me.ProviderFriendlyName)
        ret.SdkVersion = SDK_VERSION
        ret.AppVersion = XML_VERSION
        ret.signatureInfos.Add(signingParameters.signatureInfo)

        'return the CryptoSignedObject
        Return ret

    End Function

    Public Function CoSign(ByVal objectToSign() As Byte, ByVal signingParameters As CoSignParameters) As CryptoSignedObject(Of Byte()) Implements SignVerify.Common.ICryptoProvider(Of Byte()).CoSign

        If Not signingParameters.signatureInfo.certificate.HasPrivateKey Then
            Throw New ApplicationException(My.Resources.ErrorMessges.NotContainingPrivateKey)
        End If

        'Create xml document
        Dim ns As XmlNamespaceManager
        Dim xmlDoc As XmlDocument
        Try
            xmlDoc = Common.Utils.XmlHelper.LoadXmlFromBytes(objectToSign)
            ns = GetNamespaceManager(xmlDoc)
        Catch ex As XmlException
            Logger.Instance.Error(My.Resources.ErrorMessges.OtherProvider, ex)
            Throw (New SignatureException(My.Resources.ErrorMessges.OtherProvider))
        End Try

        'cleanDoc(xmlDoc)
        ' Load an XML file into the XmlDocument object.

        'if the file not signed 
        'If xmlDoc.SelectNodes("/gov.il:Signature", ns).Count = 0 Then
        If xmlDoc.GetElementsByTagName("gov.il:Signature").Count = 0 Then
            If xmlDoc.GetElementsByTagName("ds:Signature").Count = 0 Then
                Logger.Instance.Error(My.Resources.ErrorMessges.NoCerteficateFound)
                Throw (New SignatureValidationException(My.Resources.ErrorMessges.NoCerteficateFound))
            End If
        End If


        Dim cryptoObj As CryptoSignedObject(Of Byte()) = getCryptoSignedObject(xmlDoc)
        Dim lastSignaturesLevel As List(Of CryptoSignatureInfo) = cryptoObj.signatureInfos.getLastSignaturesLevel()
        Dim references As New ArrayList

        'parallel signature
        If signingParameters.CoSignType = CoSignType.Parallel Then

            'if it the root level of signatures
            If lastSignaturesLevel(0).parent Is Nothing Then

                Dim datanode As XmlNode = xmlDoc.GetElementsByTagName("gov.il:SignedInfo")(0)
                Dim dataID As String = ""

                If Not datanode Is Nothing AndAlso Not datanode.Attributes("Id") Is Nothing Then
                    dataID = datanode.Attributes("Id").Value
                Else
                    Logger.Instance.Error(My.Resources.ErrorMessges.EmptyData)
                    Throw (New SignatureException(My.Resources.ErrorMessges.EmptyData))
                End If

                references.Add(dataID)

                'if it the second level of signatures
            ElseIf lastSignaturesLevel(0).parent.parent Is Nothing Then
                For Each sign As CryptoSignatureInfo In cryptoObj.signatureInfos
                    references.Add(sign.id)
                Next

                'if it at least a third level of signatures
            Else
                For Each sign As CryptoSignatureInfo In lastSignaturesLevel(0).parent.parent.counterSignatures
                    references.Add(sign.id)
                Next
            End If

            'serial signature
        Else

            For Each sign As CryptoSignatureInfo In lastSignaturesLevel
                references.Add(sign.id)
            Next
        End If

        Dim xmlDigitalSignature As XmlElement = createSignature(xmlDoc, signingParameters, references)

        ' Append the element to the XML document.
        xmlDoc.DocumentElement.AppendChild(xmlDoc.ImportNode(xmlDigitalSignature, True))

        Return getCryptoSignedObject(xmlDoc)

    End Function
    ''' <summary>
    ''' This method verifies  the signature.
    ''' </summary>
    ''' <param name="signedObject">The signed object.</param>
    ''' <param name="verifyParametersInfo">The verify parameters info.</param>
    ''' <returns>The crypto signed object if the verification is successful, otherwise exception is thrown.</returns>
    Public Function VerifySignature(ByVal signedObject() As Byte, ByVal verifyParametersInfo As VerifyParameters) As CryptoSignedObject(Of Byte()) Implements ICryptoProvider(Of Byte()).VerifySignature
        ' Load an XML file into the XmlDocument object.
        Dim xmlDoc As XmlDocument = Common.Utils.XmlHelper.LoadXmlFromBytes(signedObject)



        If IsMashkonotSignature(xmlDoc) Then
            Return VerifyMashkonot(xmlDoc, verifyParametersInfo)
        End If

        Dim ns As XmlNamespaceManager = GetNamespaceManager(xmlDoc)

        Dim nodeList As XmlNodeList = xmlDoc.GetElementsByTagName("gov.il:Signature")

        If nodeList.Count = 0 Then
            nodeList = xmlDoc.GetElementsByTagName("ds:Signature")
        End If

        If nodeList.Count = 0 Then
            nodeList = xmlDoc.GetElementsByTagName("Signature")
        End If

        ' Throw an exception if no signature was found.
        If nodeList.Count = 0 Then
            Logger.Instance.Error(My.Resources.ErrorMessges.VeiifyNoCerteficate)
            Throw New SignVerify.Common.SignatureValidationException(My.Resources.ErrorMessges.VeiifyNoCerteficate)
        End If

        Return getCryptoSignedObject(xmlDoc, verifyParametersInfo)

    End Function

#End Region

#Region "private methods"

#Region "object to xml(sign)"

    'create signature method
    Private Function createSignature(ByVal xmlDoc As XmlDocument, ByVal SignParameter As SignParameters, ByVal referencesID As ArrayList)

        'removed by gili
        cleanDoc(xmlDoc)


        ' Create a SignedXml object.
        Logger.Instance.Info("createSignature start.")
        Dim signedXml As New SignedXml(xmlDoc)
        '  signedXml.
        Logger.Instance.Info("createSignature. Assign signing key.")
        ' Add the key to the SignedXml document.

        signedXml.SigningKey = SignParameter.signatureInfo.certificate.PrivateKey

        'add the signature id
        signedXml.Signature.Id = "il-" & Guid.NewGuid.ToString

        Logger.Instance.Info("createSignature. KeyInfoX509Data.")
        'Add the certificate to the  keyinfo node of the SignedXml document.
        Dim info As New KeyInfoX509Data(SignParameter.signatureInfo.certificate)
        info.AddSubjectName(SignParameter.signatureInfo.certificate.SubjectName.Name)
        Logger.Instance.Info("createSignature. AddClause.")
        signedXml.KeyInfo.AddClause(info)
        'CryptoConfig.AddAlgorithm(GetType(RSAPKCS1SHA256SignatureDescription), "http://www.w3.org/2000/09/xmldsig-more#rsa-sha256")
        Logger.Instance.Info("createSignature. Before add reference.")
        'add references
        For Each ref As String In referencesID

            ' Create a reference to the data element to be signed.
            Dim reference As New Reference()
            reference.Uri = "#" & ref

            ' Add an enveloped transformation to the reference.
            Dim env As New XmlDsigEnvelopedSignatureTransform()
            reference.AddTransform(env)

            ' Add the reference to the SignedXml object.
            signedXml.AddReference(reference)

        Next
        Logger.Instance.Info("createSignature. After add reference.")

        Logger.Instance.Info("createSignature. Before ComputeSignature.")
        ' Compute the signature.
        Try

            signedXml.ComputeSignature()
        Catch ex As Exception
            Logger.Instance.Error("createSignature. Exception ComputeSignature.", ex)
            If ex.Message.ToLower().Contains("wrong pin") Then
                Throw New Exception(My.Resources.ErrorMessges.WrongPinCode)
            ElseIf ex.Message.ToLower().Contains("the action was cancelled by the user.") Then
                Throw New Exception(My.Resources.ErrorMessges.SignCanceled)
            Else
                Throw New Exception("Failed ComputeSignature", ex)
            End If

        End Try

        Logger.Instance.Info("createSignature. After ComputeSignature.")

        'Add qualifying properties if time stamp flag is on (signed and unsigned properties)
        If SignParameter.timeStamped AndAlso Not String.IsNullOrEmpty(SignParameter.signatureInfo.TimeStampURL) Then
            AddQualifyingProperties(signedXml, xmlDoc, SignParameter)
        End If

        'added by gili
        fix1(signedXml)
        'return the signature node xml
        Dim result As XmlElement = signedXml.GetXml()
        fixeDoc(xmlDoc)
        fixeElement(result)

        Return result
    End Function

    'this method adds the SignedProperties Node ti the XMLDSIG  (when the user created the signature) along with the signature 
    Private Sub AddQualifyingProperties(ByVal SignedXml As SignedXml, ByRef XmlDoc As XmlDocument, ByVal SignParameters As SignParameters)

        'add qualifying properties
        Dim oObjectElem As XmlElement = XmlDoc.CreateElement("ds:Object", NS_XMLDSIG)
        Dim oPropElem As XmlElement = XmlDoc.CreateElement("xa:QualifyingProperties", NS_XADES)
        oObjectElem.AppendChild(oPropElem)

        'Add signed properties
        'AddSignedProperties(XmlDoc, oPropElem, SignParameters)

        'Add unsigned properties with time stamp.
        Dim unsignedPropNode As XmlNode = CreateUnsignedProperties(SignedXml, SignParameters, XmlDoc)
        oPropElem.AppendChild(unsignedPropNode)

        'add "object" node to the signature
        Dim oPropObject As New DataObject()
        oPropObject.LoadXml(oObjectElem)

        SignedXml.AddObject(oPropObject)

    End Sub

    'This method add unsigned properties to signed xml
    'The unsigned properties contains (among other) the time stamp token received from the TSA server.
    Private Function CreateUnsignedProperties(ByVal SignedXml As SignedXml, ByVal SignParameters As SignParameters, ByRef XmlDoc As XmlDocument) As XmlNode


        'Add UnsignedProperties
        Dim UnsignedPropNode As XmlNode = XmlDoc.CreateElement("xa:UnsignedProperties", NS_XADES)

        'add UnsignedSignatureProperties
        Dim UnsignedSignaturePropertiesNode As XmlNode = XmlDoc.CreateElement("xa:UnsignedSignatureProperties", NS_XADES)
        UnsignedPropNode.AppendChild(UnsignedSignaturePropertiesNode)

        'Add SignatureTimeStamp
        Dim oSignatureTimeStamp As XmlNode = XmlDoc.CreateElement("xa:SignatureTimeStamp", NS_XADES)
        UnsignedSignaturePropertiesNode.AppendChild(oSignatureTimeStamp)

        'Get the signature value
        'not use the signedXml.signatureValue because it return only the innerText, we need the OuterXml
        Dim SignatureValue As Byte() = GetSignatureValue(SignedXml.GetXml) 'SignedXml.SignatureValue

        'send tsa request
        Dim response As TimeStampResponse = GetTimeStamp(SignParameters, SignatureValue)

        'The signed data as created by the TSA saved as base64 string
        Dim oEncapsulateTimeStamp As XmlNode = XmlDoc.CreateElement("xa:EncapsulateTimeStamp", NS_XADES)

        'if valid add timestamp
        If response.ValidationResult.ResponseStatus = TimeStampResponseStatus.Granted And response.ValidationResult.ValidationErrors.Count = 0 Then
            oEncapsulateTimeStamp.InnerText = Convert.ToBase64String(response.Data.DataBytes)
        End If
        UnsignedPropNode.AppendChild(oEncapsulateTimeStamp)

        Return UnsignedPropNode
    End Function


    ''this method adds the SignedProperties Node ti the XMLDSIG  (when the user created the signature) along with the signature 
    'Private Sub AddSignedProperties(ByRef p_oXmlDoc As XmlDocument, ByVal p_oPropElem As XmlElement, ByVal p_oSignParameters As SignParameters)

    '    'Add SignedProperties
    '    Dim oSignedPropNode As XmlNode = p_oXmlDoc.CreateNode(XmlNodeType.Element, String.Empty, "SignedProperties", "http://uri.etsi.org/01903#SignedProperties")
    '    Dim oSignedPropNodeIDAtt As XmlAttribute = p_oXmlDoc.CreateAttribute("Id")
    '    oSignedPropNodeIDAtt.Value = "SignedProperties"
    '    oSignedPropNode.Attributes.Append(oSignedPropNodeIDAtt)
    '    p_oPropElem.AppendChild(oSignedPropNode)

    '    'Add SignedSignatureProperties
    '    Dim oSignedSignaturePropertiesNode As XmlNode = p_oXmlDoc.CreateNode(XmlNodeType.Element, String.Empty, "SignedSignatureProperties", String.Empty)
    '    oSignedPropNode.AppendChild(oSignedSignaturePropertiesNode)

    '    'Add SigningTime
    '    Dim oSigningTimeNode As XmlNode = p_oXmlDoc.CreateNode(XmlNodeType.Element, String.Empty, "SigningTime", String.Empty)
    '    oSigningTimeNode.InnerText = TSACommon.GetTimeStampAsString(m_oTSAData)
    '    oSignedSignaturePropertiesNode.AppendChild(oSigningTimeNode)

    '    'Add SigningCertificate
    '    Dim oSigningCertificate As XmlNode = p_oXmlDoc.CreateNode(XmlNodeType.Element, "SigningCertificate", String.Empty)
    '    Dim oCert As XmlNode = p_oXmlDoc.CreateNode(XmlNodeType.Element, String.Empty, "Cert", String.Empty)
    '    oSigningCertificate.AppendChild(oCert)

    '    Dim oCertDigest As XmlNode = p_oXmlDoc.CreateNode(XmlNodeType.Element, String.Empty, "CertDigest", String.Empty)
    '    oCert.AppendChild(oCertDigest)
    '    'Add digest method 
    '    Dim oDigestMethod As XmlNode = p_oXmlDoc.CreateNode(XmlNodeType.Element, String.Empty, "DigestMethod", String.Empty)
    '    Dim oAlgorithm As XmlAttribute = p_oXmlDoc.CreateAttribute(String.Empty, "Algorithm", String.Empty)
    '    oAlgorithm.Value = GetAlgorithm(p_oSignParameters.signatureInfo.certificate)
    '    oDigestMethod.Attributes.Append(oAlgorithm)
    '    oCertDigest.AppendChild(oDigestMethod)

    '    'add digest value 
    '    Dim oDigestValue As XmlNode = p_oXmlDoc.CreateNode(XmlNodeType.Element, String.Empty, "DigestValue", String.Empty)
    '    oDigestValue.InnerText = p_oSignParameters.signatureInfo.certificate.GetCertHashString()
    '    oCertDigest.AppendChild(oDigestValue)

    '    'Add issuer serial
    '    Dim oIssuerSerial As XmlNode = p_oXmlDoc.CreateNode(XmlNodeType.Element, "ds", "IssuerSerial", String.Empty)
    '    oCert.AppendChild(oIssuerSerial)
    '    'Add issuer name
    '    Dim oIssuerName As XmlNode = p_oXmlDoc.CreateNode(XmlNodeType.Element, "ds", "IssuerName", String.Empty)
    '    oIssuerName.InnerText = p_oSignParameters.signatureInfo.certificate.Issuer
    '    oIssuerSerial.AppendChild(oIssuerName)
    '    'Add serial number
    '    Dim oSerialNumber As XmlNode = p_oXmlDoc.CreateNode(XmlNodeType.Element, "ds", "X509SerialNumber", String.Empty)
    '    oSerialNumber.InnerText = p_oSignParameters.signatureInfo.certificate.SerialNumber
    '    oIssuerSerial.AppendChild(oSerialNumber)
    '    ' add User's Certificate
    '    oSignedSignaturePropertiesNode.AppendChild(oSigningCertificate)

    'End Sub


#End Region

#Region "xml to object(verify)"

    'create CryptoSignedObject from SignedCms
    Private Function getCryptoSignedObject(ByVal xmlDoc As XmlDocument, Optional ByVal verifyParameters As VerifyParameters = Nothing) As CryptoSignedObject(Of Byte())
        Dim ns As XmlNamespaceManager = GetNamespaceManager(xmlDoc)
        Dim verifCertificate As Boolean = True
        Dim dataID As String = ""

        'minimum verfication by default
        If verifyParameters Is Nothing Then
            verifyParameters = New VerifyParameters()
            verifCertificate = False
        End If
        Logger.Instance.Info("Start getCryptoSignedObject")
        Dim content As New CryptoContentInfo(Of Byte())(System.Text.Encoding.UTF8.GetBytes(xmlDoc.OuterXml))

        Logger.Instance.Info("Start getCryptoSignedObject, OuterXml: " & xmlDoc.OuterXml)
        Dim man As New XmlNamespaceManager(xmlDoc.NameTable)

        'get filename
        Dim fileNameNode As XmlNode = xmlDoc.SelectSingleNode("//gov.il:FileName", ns)
        If Not fileNameNode Is Nothing Then
            content.originalFileName = fileNameNode.InnerText
        End If

        'get versions
        Dim appVersionNode As XmlNode = xmlDoc.SelectSingleNode("//gov.il:ApplicationVersion", ns)
        Dim sdkVersionNode As String = xmlDoc.DocumentElement.Attributes("version").Value

        'get originalContent
        Dim originalContentNode As XmlNode = xmlDoc.SelectSingleNode("//gov.il:SignedObject/gov.il:SignedInfo/gov.il:Data", ns)
        If Not originalContentNode Is Nothing Then
            'get from text encoding
            If Not originalContentNode.Attributes("DataEncodingType") Is Nothing AndAlso _
               (originalContentNode.Attributes("DataEncodingType").Value.Equals("text", StringComparison.OrdinalIgnoreCase) _
               OrElse originalContentNode.Attributes("DataEncodingType").Value.Equals("xml", StringComparison.OrdinalIgnoreCase)) Then

                content.originalContent = Text.Encoding.UTF8.GetBytes(originalContentNode.InnerXml)
            Else
                'get from default encoding (base64)
                content.originalContent = Convert.FromBase64String(originalContentNode.InnerText)
            End If

        End If
        Logger.Instance.Info("Start getCryptoSignedObject, OuterXml: " & xmlDoc.OuterXml)

        dataID = xmlDoc.SelectNodes("//gov.il:SignedInfo", ns)(0).Attributes("Id").Value
        Dim ret As CryptoSignedObject(Of Byte()) = New CryptoSignedObject(Of Byte())(content, Me.ProviderFriendlyName)
        ret.AppVersion = appVersionNode.InnerText
        ret.SdkVersion = sdkVersionNode
        'get signatures

        ' Dim xmlDocTemp As New XmlDocument()
        'xmlDocTemp.PreserveWhitespace = True
        'xmlDocTemp = xmlDoc.Clone()
        cleanDoc(xmlDoc)
      
        Dim signedXmlList As New List(Of SignedXml)
        Dim signNodeList As XmlNodeList = xmlDoc.GetElementsByTagName("Signature")

        'fill the signedXml list
        For Each signNode As XmlNode In signNodeList

            'Create a SignedXml object.
            Dim item As New SignedXml(xmlDoc.DocumentElement)

            'Load the <signature> node.
            item.LoadXml(CType(signNode, XmlElement))

            'Add to the signedXml list
            signedXmlList.Add(item)

        Next

        For Each signedXml As SignedXml In signedXmlList
            'check signature
            If CType(signedXml.SignedInfo.References(0), Reference).Uri = "#" & dataID Then
                ret.signatureInfos.Add(getSignatureInfoFromSigner(signedXml, signedXmlList, Nothing, verifyParameters, verifCertificate))
            End If
        Next
        fixeDoc(xmlDoc)
        'cleanDoc2(xmlDoc)
        Return ret
    End Function

    'get signatureInfo from SignerInfo instance
    Private Function getSignatureInfoFromSigner(ByVal signedXml As SignedXml, ByVal signedXmlList As List(Of SignedXml), ByVal parent As CryptoSignatureInfo, ByVal verifyParameters As VerifyParameters, ByVal verifCertificate As Boolean) As CryptoSignatureInfo

        'get the certificate
        Dim certificate As New System.Security.Cryptography.X509Certificates.X509Certificate2(Convert.FromBase64String(signedXml.KeyInfo.GetXml.GetElementsByTagName("X509Certificate")(0).InnerText))

        'get the signature informations
        Dim item As CryptoSignatureInfo = New CryptoSignatureInfo(certificate)
        item.SignatureStandard = SignatureStandard.XmlDsig
        item.id = signedXml.Signature.Id
        item.parent = parent

        'TODO:add signature algo

        If verifCertificate Then
            'check the signature only
            '  cleanSignedXml(signedXml)
            If Not signedXml.CheckSignature() Then
                item.EndSignatureState = EndSignatureStateType.SignatureUnvalid
            Else
                'check end certificate state
                Dim cert As New System.Security.Cryptography.X509Certificates.X509Certificate2(Convert.FromBase64String(signedXml.KeyInfo.GetXml.GetElementsByTagName("X509Certificate")(0).InnerText))
                item.EndSignatureState = SignVerify.Common.Certificate.getEndCertificateState(cert)
            End If


            'check certificates chain
            If item.EndSignatureState <> EndSignatureStateType.SignatureUnvalid Then
                If verifyParameters.CheckTrustChain Then item.ChainSignatureState = SignVerify.Common.Certificate.getCertificateChainState(certificate)
                item.CRLstate = SignVerify.Common.Certificate.getCertificateCRLState(certificate, verifyParameters)
            End If
        End If

        'check timestamp
        Dim ns As XmlNamespaceManager = GetNamespaceManager(signedXml.GetXml.OwnerDocument)
        Dim oSignatureTimeStampNode As XmlNode = signedXml.GetXml().SelectSingleNode("//xa:EncapsulateTimeStamp", ns)

        'verify time stamp if exists 
        If Not oSignatureTimeStampNode Is Nothing Then

            'create timestampeResponse object
            Dim response As New TimeStampResponseData(Convert.FromBase64String(oSignatureTimeStampNode.InnerText))

            'validate it
            item.TimeStampState = response.Validate(GetSignatureValue(signedXml.GetXml), Guid.Empty)
            item.TimeStamp = response.TimeStamp
            item.TimeStampCertificate = response.Certificate
        End If

        'get the counters signatures
        For Each signedXml1 As SignedXml In signedXmlList

            For Each reference As Reference In signedXml1.SignedInfo.References
                If reference.Uri = "#" & signedXml.Signature.Id Then
                    item.counterSignatures.Add(getSignatureInfoFromSigner(signedXml1, signedXmlList, item, verifyParameters, verifCertificate))
                End If
            Next

        Next
        Return item

    End Function


    'get signatureInfo from SignerInfo instance
    Private Function getMashkonotSignatureInfoFromSigner(ByVal signedXml As SignedXml, ByVal fileContent As Byte(), ByVal signedXmlList As List(Of SignedXml), ByVal parent As CryptoSignatureInfo, ByVal verifyParameters As VerifyParameters, ByVal verifCertificate As Boolean) As CryptoSignatureInfo

        'get the certificate
        Dim certificate As New System.Security.Cryptography.X509Certificates.X509Certificate2(Convert.FromBase64String(signedXml.KeyInfo.GetXml.GetElementsByTagName("X509Certificate")(0).InnerText))

        'get the signature informations
        Dim item As CryptoSignatureInfo = New CryptoSignatureInfo(certificate)
        item.SignatureStandard = SignatureStandard.XmlDsig
        item.id = signedXml.Signature.Id
        item.parent = parent

        Dim arrSignature As Byte() = Nothing

        Dim ns As XmlNamespaceManager = GetNamespaceManager(signedXml.GetXml.OwnerDocument)
        'TODO:add signature algo

        If verifCertificate Then
            'check the signature only
            '  cleanSignedXml(signedXml)

            Dim bValidSig As Boolean = True
            Dim ci As ContentInfo = New ContentInfo(fileContent)
            Dim verifyCms As SignedCms = New SignedCms(ci, True)
            Dim sSig As String = signedXml.GetXml().ChildNodes(1).InnerText
            verifyCms.Decode(Convert.FromBase64String(sSig))

            Try
                verifyCms.CheckSignature(True)
            Catch ex As Exception
                bValidSig = False
            End Try

            If Not bValidSig = True Then
                item.EndSignatureState = EndSignatureStateType.SignatureUnvalid
            Else
                'check end certificate state
                Dim cert As New System.Security.Cryptography.X509Certificates.X509Certificate2(Convert.FromBase64String(signedXml.KeyInfo.GetXml.GetElementsByTagName("X509Certificate")(0).InnerText))
                item.EndSignatureState = SignVerify.Common.Certificate.getEndCertificateState(cert)
            End If

        End If
        'check certificates chain
        If item.EndSignatureState <> EndSignatureStateType.SignatureUnvalid Then
            If verifyParameters.CheckTrustChain Then item.ChainSignatureState = SignVerify.Common.Certificate.getCertificateChainState(certificate)
            item.CRLstate = SignVerify.Common.Certificate.getCertificateCRLState(certificate, verifyParameters)
        End If


        Return item

    End Function
#End Region

#Region "helper methods"

    'clean the signature node for added prefix or namespace
    Private Sub cleanDoc(ByVal xmlDoc As XmlDocument)
        Dim ns As XmlNamespaceManager = GetNamespaceManager(xmlDoc)
        For Each signNode As XmlNode In xmlDoc.GetElementsByTagName("gov.il:Signature")
            signNode.Prefix = ""
            For i As Integer = signNode.Attributes.Count - 1 To 0 Step -1
                Dim att As XmlAttribute = signNode.Attributes(i)
                If att.Name.StartsWith("xmlns:") AndAlso att.LocalName <> "" Then
                    signNode.Attributes.RemoveAt(i)
                End If
            Next
        Next
        For Each signNode As XmlNode In xmlDoc.GetElementsByTagName("ds:Signature")
            signNode.Prefix = ""
            For i As Integer = signNode.Attributes.Count - 1 To 0 Step -1
                Dim att As XmlAttribute = signNode.Attributes(i)
                If att.Name.StartsWith("xmlns:") AndAlso att.LocalName <> "" Then
                    signNode.Attributes.RemoveAt(i)
                End If
            Next
        Next
    End Sub
    Private Sub FixcleanDoc(ByVal xmlDoc As XmlDocument)
        Dim ns As XmlNamespaceManager = GetNamespaceManager(xmlDoc)
        For Each signNode As XmlNode In xmlDoc.GetElementsByTagName("Signature")
            signNode.Prefix = "gov.il"
            For i As Integer = signNode.Attributes.Count - 1 To 0 Step -1
                Dim att As XmlAttribute = signNode.Attributes(i)
                If att.Name.StartsWith("xmlns:") AndAlso att.LocalName <> "" Then
                    signNode.Attributes.RemoveAt(i)
                End If
            Next
        Next
    End Sub

    Private Sub cleanDoc1(ByVal xmlDoc As XmlDocument)
        Dim ns As XmlNamespaceManager = GetNamespaceManager(xmlDoc)
        For Each signNode As XmlNode In xmlDoc.GetElementsByTagName("gov.il:Signature")
            signNode.Prefix = ""
            If signNode.Name = "SignedInfo" Then
                '  signNode.Attributes.Append(New XmlAttribute())
            End If

            For Each signNode1 As XmlNode In signNode.SelectNodes("*", ns)
                signNode1.Prefix = ""

                For i As Integer = signNode1.Attributes.Count - 1 To 0 Step -1
                    Dim att As XmlAttribute = signNode1.Attributes(i)
                    If att.Name.StartsWith("xmlns:") AndAlso att.LocalName <> "" Then
                        signNode1.Attributes.RemoveAt(i)
                    End If
                Next
                For Each signNode2 As XmlNode In signNode1.SelectNodes("*", ns)
                    signNode2.Prefix = ""

                    For i As Integer = signNode2.Attributes.Count - 1 To 0 Step -1
                        Dim att As XmlAttribute = signNode2.Attributes(i)
                        If att.Name.StartsWith("xmlns:") AndAlso att.LocalName <> "" Then
                            signNode2.Attributes.RemoveAt(i)
                        End If
                    Next
                    For Each signNode3 As XmlNode In signNode2.SelectNodes("*", ns)
                        signNode3.Prefix = ""

                        For i As Integer = signNode3.Attributes.Count - 1 To 0 Step -1
                            Dim att As XmlAttribute = signNode3.Attributes(i)
                            If att.Name.StartsWith("xmlns:") AndAlso att.LocalName <> "" Then
                                signNode3.Attributes.RemoveAt(i)
                            End If
                        Next
                    Next
                Next

            Next
        Next

    End Sub

    
    'add gov.il prefix to signature for backward compatibility
    Private Sub fixeDoc(ByVal xmlDoc As XmlDocument)
        Dim ns As XmlNamespaceManager = GetNamespaceManager(xmlDoc)
        For Each signNode As XmlNode In xmlDoc.GetElementsByTagName("Signature")
            'changed from gov.il to ds by gili
            signNode.Prefix = "gov.il"
        Next

    End Sub

    Private Sub fix1(ByVal signedXml As SignedXml)
        Dim signature As XmlElement = signedXml.GetXml
        For Each node As XmlNode In signature.SelectNodes("descendant-or-self::*[namespace-uri()='http://www.w3.org/2000/09/xmldsig#']")
            node.Prefix = "gov.il"
        Next
    End Sub

    'add gov.il prefix to signature for backward compatibility
    Private Sub fixeElement(ByVal xmlElement As XmlElement)
        'changed from gov.il to ds by gili
        xmlElement.Prefix = "gov.il"
    End Sub

    'This method returns the URI according to the user certificate algorithm friendly name
    Private Function GetAlgorithm(ByVal Cert As X509Certificate2) As String
        Dim sFriendlyName As String = Cert.SignatureAlgorithm.FriendlyName
        sFriendlyName = sFriendlyName.ToLower()
        Select Case sFriendlyName
            Case "sha1"
                Return SignedXml.XmlDsigSHA1Url
            Case "sha1rsa"
                Return SignedXml.XmlDsigRSASHA1Url
            Case Else
                Return String.Empty
        End Select
    End Function

    'define the MIME type
    Private Function defineMime(ByVal filepath As String) As String
        Dim ext As String = filepath.Substring(filepath.LastIndexOf(".") + 1)
        Select Case ext.ToLower.Trim
            Case "doc"
                Return "application/msword"
            Case "dot"
                Return "application/msword"
            Case "bin"
                Return "application /octet-stream"
            Case "exe"
                Return "application /octet-stream"
            Case "com"
                Return "application /octet-stream"
            Case "dll"
                Return "application /octet-stream"
            Case "class"
                Return "application /octet-stream"
            Case "pdf"
                Return "application/pdf"

            Case "php"
                Return "application/x-httpd-php"
            Case "phtml"
                Return "application/x-httpd-php"
            Case "js"
                Return "application/x-javascript"
            Case "gif"
                Return "image/gif"
            Case "jpeg"
                Return "image/jpeg"
            Case "jpg"
                Return "image/jpeg"
            Case "tiff"
                Return "image/tiff"
            Case "tif"
                Return "image/tiff"
            Case "xml"
                Return "text/xml"
            Case "css"
                Return "text/css"
            Case "txt"
                Return "text/plain"
            Case "rtf"
                Return "text/rtf"
            Case "tif"
                Return "image/tiff"

            Case Else
                Return "multipart/form-data"
        End Select
    End Function


    ''' <summary>
    ''' Thie method extract the signatur value from the signature.
    ''' </summary>
    ''' <param name="Xml">The XmlDSig signature node.</param>
    ''' <returns>The signature value.</returns>
    Private Function GetSignatureValue1(ByVal Xml As XmlElement) As Byte()

        Dim aoXmlNode As XmlNodeList = Xml.GetElementsByTagName("SignatureValue")

        If aoXmlNode.Count > 0 Then
            Dim oLastValue As XmlNode = aoXmlNode(aoXmlNode.Count - 1)
            Dim oSigValue As String = oLastValue.OuterXml
            Return Encoding.Unicode.GetBytes(oSigValue)
        End If
        Return Nothing
    End Function

    ''' <summary>
    ''' Thie method extract the signatur value from the signature.
    ''' </summary>
    ''' <param name="Xml">The XmlDSig signature node.</param>
    ''' <returns>The signature value.</returns>
    Private Function GetSignatureValue(ByVal Xml As XmlElement) As Byte()

        Dim aoXmlNode As XmlNodeList = Xml.GetElementsByTagName("SignatureValue")

        If aoXmlNode.Count > 0 Then
            Dim oLastValue As XmlNode = aoXmlNode(aoXmlNode.Count - 1)
            Dim oSigValue As String = String.Format("<{0}:{1}>{2}</{0}:{1}>", "ds", oLastValue.Name, oLastValue.InnerXml)
            Return Encoding.Unicode.GetBytes(oSigValue)
        End If
        Return Nothing
    End Function


    Private Function GetNamespaceManager(ByVal xmlDoc As XmlDocument) As XmlNamespaceManager
        Dim ns As New XmlNamespaceManager(xmlDoc.NameTable)
        AddUsedNamespaces(ns)
        If xmlDoc.DocumentElement IsNot Nothing Then
            'fixe gov.il namespace for backward compatibility
            Dim govilns As String = xmlDoc.DocumentElement.GetNamespaceOfPrefix("gov.il")
            If Not String.IsNullOrEmpty(govilns) Then
                If Not String.Equals(govilns, ns.LookupNamespace("gov.il"), StringComparison.OrdinalIgnoreCase) Then
                    ns.RemoveNamespace("gov.il", ns.LookupNamespace("gov.il"))
                    ns.AddNamespace("gov.il", govilns)
                End If
            End If

        End If

        Return ns
    End Function

    Private Function IsMashkonotSignature(ByVal xmlDoc As XmlDocument) As Boolean

        If xmlDoc.DocumentElement IsNot Nothing Then
            'fixe gov.il namespace for backward compatibility
            Dim govilns As String = xmlDoc.DocumentElement.GetNamespaceOfPrefix("gov.il")
            If govilns = "http://www.gov.il/xmldigsig" Then
                Return True
            Else
                Return False
            End If

        End If

    End Function

    Private Sub AddUsedNamespaces(ByVal ns As XmlNamespaceManager)
        ns.AddNamespace("ds", NS_XMLDSIG)
        ns.AddNamespace("gov.il", NS_GOVIL)

        ns.AddNamespace("xa", NS_XADES)
    End Sub
#End Region

#Region "Time stamp"

    ''' <summary>
    ''' This method build user request (as ASN1Node formated to byte array) to the time stamp authority server 
    ''' and get a response (as ASN1Node formated to byte array).
    ''' </summary>
    ''' <param name="SignParameters">The signing parameters.</param>
    ''' <param name="OriginalMessage">The origianl hash message.</param>
    Private Function GetTimeStamp(ByVal SignParameters As SignParameters, ByVal OriginalMessage() As Byte) As TimeStampResponse
        'Comute has for the message
        Dim HashedOriginalMessage = SignVerify.Common.TimeStamp.Utils.ConvertToHashedMessage(OriginalMessage)

        'Build the client request
        Dim Request As New TimeStampRequest(HashedOriginalMessage)

        'Get the response from the server 
        Dim response As TimeStampResponse = Request.GetResponse(SignParameters.signatureInfo.TimeStampURL)


        'validate the time stamp response(format,certificate,crl...)
        response.Validate(OriginalMessage, Request.Nonce)

        Return response

    End Function

    'Returns the signing time which appear in the signature 
    'as recieved from the time stamp authority
    Private Function GetSigningTime(ByVal signer As SignedXml) As String
        Dim oElem As XmlElement = signer.GetXml()

        Dim aoSignTimeNodes As XmlNodeList = oElem.GetElementsByTagName("SigningTime")

        If Not aoSignTimeNodes Is Nothing AndAlso aoSignTimeNodes.Count = 1 Then
            Dim oSignTimeNode As XmlNode = aoSignTimeNodes.ItemOf(0)

            If oSignTimeNode.InnerText.Length = 19 Then
                Dim sYear As String = oSignTimeNode.InnerText.Substring(0, 4)
                Dim sMonth As String = oSignTimeNode.InnerText.Substring(4, 2)
                Dim sDay As String = oSignTimeNode.InnerText.Substring(6, 2)
                Dim sHour As String = oSignTimeNode.InnerText.Substring(8, 2)
                Dim sMinute As String = oSignTimeNode.InnerText.Substring(10, 2)
                Dim sSecond As String = oSignTimeNode.InnerText.Substring(12, 2)
                Dim sMili As String = oSignTimeNode.InnerText.Substring(15, 3)
                Dim oDate As New DateTime(sYear, sMonth, sDay, sHour, sMinute, sSecond, sMili, DateTimeKind.Utc)
                Dim sStringDateFormat As String = oDate.ToString("yyyy-MM-dd hh:mm:ss.fffZ")
                ''sYear & "-" & sMonth & "-" & sDay & " " & sHour & ":" & sMinute & ":" & sSecond & "." & sMili & "Z"
                Return sStringDateFormat
            Else
                Dim sYear As String = oSignTimeNode.InnerText.Substring(0, 4)
                Dim sMonth As String = oSignTimeNode.InnerText.Substring(5, 2)
                Dim sDay As String = oSignTimeNode.InnerText.Substring(8, 2)
                Dim sHour As String = oSignTimeNode.InnerText.Substring(11, 2)
                Dim sMinute As String = oSignTimeNode.InnerText.Substring(14, 2)
                Dim sSecond As String = oSignTimeNode.InnerText.Substring(17, 2)
                Dim sMili As String = oSignTimeNode.InnerText.Substring(20, 3)
                Dim oDate As New DateTime(sYear, sMonth, sDay, sHour, sMinute, sSecond, sMili, DateTimeKind.Utc)
                Dim sStringDateFormat As String = oDate.ToString("yyyy-MM-dd hh:mm:ss.fffZ")
                ''sYear & "-" & sMonth & "-" & sDay & " " & sHour & ":" & sMinute & ":" & sSecond & "." & sMili & "Z"
                Return sStringDateFormat
            End If
        End If

        Return String.Empty
    End Function


#End Region

#Region "Mashkonot"
    Private Function VerifyMashkonot(ByVal xmlDoc As XmlDocument, Optional ByVal verifyParameters As VerifyParameters = Nothing) As CryptoSignedObject(Of Byte())

        Dim ns As XmlNamespaceManager = GetNamespaceManager(xmlDoc)
        Dim verifCertificate As Boolean = True
        Dim dataID As String = ""

        Dim nlData As XmlNodeList = xmlDoc.GetElementsByTagName("gov.il:Data")
        Dim sData As String = nlData(0).InnerText

        Dim nlSig As XmlNodeList = xmlDoc.GetElementsByTagName("SignatureValue")
        Dim sSig As String = nlSig(0).InnerText

        'minimum verfication by default
        If verifyParameters Is Nothing Then
            verifyParameters = New VerifyParameters()
            verifCertificate = False
        End If
        Logger.Instance.Info("Start VerifyMashkonot")
        Dim content As New CryptoContentInfo(Of Byte())(System.Text.Encoding.UTF8.GetBytes(xmlDoc.OuterXml))

        Logger.Instance.Info("Start VerifyMashkonot, OuterXml: " & xmlDoc.OuterXml)
        Dim man As New XmlNamespaceManager(xmlDoc.NameTable)

        'get filename
        Dim fileNameNode As XmlNode = xmlDoc.SelectSingleNode("//gov.il:FileName", ns)
        If Not fileNameNode Is Nothing Then
            content.originalFileName = fileNameNode.InnerText
        End If

        'get versions
        Dim appVersionNode As XmlNode = xmlDoc.SelectSingleNode("//gov.il:ApplicationVersion", ns)
        Dim sdkVersionNode As String = xmlDoc.DocumentElement.Attributes("version").Value

        'get originalContent
        Dim originalContentNode As XmlNode = xmlDoc.SelectSingleNode("//gov.il:SignedObject/gov.il:SignedInfo/gov.il:Data", ns)
        If Not originalContentNode Is Nothing Then
            'get from text encoding
            If Not originalContentNode.Attributes("DataEncodingType") Is Nothing AndAlso _
               (originalContentNode.Attributes("DataEncodingType").Value.Equals("text", StringComparison.OrdinalIgnoreCase) _
               OrElse originalContentNode.Attributes("DataEncodingType").Value.Equals("xml", StringComparison.OrdinalIgnoreCase)) Then
                content.originalContent = Text.Encoding.UTF8.GetBytes(originalContentNode.InnerXml)
            Else
                'get from default encoding (base64)
                content.originalContent = Convert.FromBase64String(originalContentNode.InnerText)
            End If

        End If
        Logger.Instance.Info("Start VerifyMashkonot, OuterXml: " & xmlDoc.OuterXml)

        dataID = xmlDoc.SelectNodes("//gov.il:SignedInfo", ns)(0).Attributes("Id").Value
        Dim ret As CryptoSignedObject(Of Byte()) = New CryptoSignedObject(Of Byte())(content, Me.ProviderFriendlyName)
        ret.AppVersion = appVersionNode.InnerText
        ret.SdkVersion = sdkVersionNode


        Dim xmlDocTemp As New XmlDocument()
        xmlDocTemp.PreserveWhitespace = True
        xmlDocTemp = xmlDoc.Clone()

        'cleanDoc(xmlDocTemp)
        Dim signedXmlList As New List(Of SignedXml)
        Dim signNodeList As XmlNodeList = xmlDocTemp.GetElementsByTagName("Signature")


        'fill the signedXml list
        For Each signNode As XmlNode In signNodeList

            'Create a SignedXml object.
            Dim item As New SignedXml(xmlDocTemp.DocumentElement)

            'Load the <signature> node.
            item.LoadXml(CType(signNode, XmlElement))

            'Add to the signedXml list
            signedXmlList.Add(item)

        Next

        For Each signedXml As SignedXml In signedXmlList
            'check signature
            If CType(signedXml.SignedInfo.References(0), Reference).Uri = "#" & dataID Then
                ret.signatureInfos.Add(getMashkonotSignatureInfoFromSigner(signedXml, content.originalContent, signedXmlList, Nothing, verifyParameters, verifCertificate))
            End If
        Next



        Return ret
    End Function
#End Region
#End Region

End Class
