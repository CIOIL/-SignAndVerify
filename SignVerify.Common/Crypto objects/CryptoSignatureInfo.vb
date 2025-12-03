Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Xml
Imports System.Security.Cryptography.X509Certificates
Imports System.Runtime.InteropServices
Imports SignVerify.Common.TimeStamp
Namespace SignVerify.Common
    ''' <summary>
    ''' This class contains all signature info which anables to sign the documents.<br />
    ''' The signing uses <see cref="System.Security.Cryptography.X509Certificates">X509Certificate2</see> certificate, <br />
    ''' the signature algorithm to use (either <see cref="System.Security.Cryptography.RSA">RSA</see> algorithm or <see cref="System.Security.Cryptography.DSA">DSA</see> algorithm),<br />
    ''' the signature checks after signing the documents:
    ''' <list type="number">
    '''  <item><see cref="SignVerify.Common.EndSignatureStateType"> end signuture state</see>.</item>
    '''  <item><see cref="SignVerify.Common.ChainSignatureStateType">chain signuture state</see>.</item>
    '''  <item><see cref="SignVerify.Common.CRLSignatureStateType">CRL state</see>.</item>
    ''' </list>
    ''' </summary>
    ''' 
    Public Class CryptoSignatureInfo

#Region "Private members"
        Private _certificate As X509Certificate2 = Nothing
        Private _signatureAlgorithm As Integer = SignAlgorithmType.RSA_SHA1
        Private _signingTime As String
        Private _timeStampURL As String
        Private _fileName As String = String.Empty
        Private _EndSignatureState As EndSignatureStateType = EndSignatureStateType.Unchecked
        Private _ChainSignatureState As ChainSignatureStateType = ChainSignatureStateType.Unchecked
        Private _CRLstate As CRLSignatureStateType = CRLSignatureStateType.Unchecked
        Private _counterSignatures As CryptoSignatureInfoCollection
        Private _id As String
        Private _timeStampState As TimeStampResponseState
        Private _timeStampCertificate As X509Certificate2
        Private _timeStamp As DateTime
        Private _parent As CryptoSignatureInfo
        Private _signatureStandard As SignatureStandard
        Private _XadesState As EndSignatureStateType = EndSignatureStateType.Unchecked
#End Region

#Region "Public members"
        ''' <summary>
        ''' This property gets the certificate type of type <see cref="System.Security.Cryptography.X509Certificates">X509Certificate2</see>e 
        ''' </summary>
        ''' <returns>The signer certificate</returns>
        Public ReadOnly Property certificate() As X509Certificate2
            Get
                Return _certificate
            End Get
        End Property


        ''' <summary>
        ''' This property gets or sets the signature algorithm. 
        ''' the signature algorithm can be either <see cref="System.Security.Cryptography.RSA">RSA</see> algorithm or <see cref="System.Security.Cryptography.DSA">DSA</see> algorithm. 
        ''' </summary>
        ''' <returns>The signature algorithm (<see cref="System.Security.Cryptography.RSA">RSA</see> algorithm or <see cref="System.Security.Cryptography.DSA">DSA</see> algorithm). </returns>
        Public Property signatureAlgorithm() As Integer
            Get
                Return _signatureAlgorithm
            End Get
            Set(ByVal value As Integer)
                _signatureAlgorithm = value
            End Set
        End Property

        ''' <summary>
        ''' This property gets the signing time on the file.
        ''' </summary>
        ''' <returns>The signature time </returns>
        Public Property signingTime() As String
            Get
                Return _signingTime
            End Get
            Set(ByVal value As String)
                _signingTime = value
            End Set
        End Property

        ''' <summary>
        ''' This property gets and sets the time stamp authority URL.
        ''' </summary>
        ''' <returns>The TimeStampURL </returns>
        Public Property TimeStampURL() As String
            Get
                Return _timeStampURL
            End Get
            Set(ByVal value As String)
                _timeStampURL = value
            End Set
        End Property

        ''' <summary>
        ''' This property gets or sets the original file name. 
        ''' </summary>
        ''' <value>Set the original file name as selected by the user</value>
        ''' <returns>The original file name</returns>
        Public Property fileName() As String
            Get
                Return _fileName
            End Get
            Set(ByVal value As String)
                _fileName = value
            End Set
        End Property

        ''' <summary>
        ''' This property gets or sets the  <see cref="SignVerify.Common.EndSignatureStateType"> end signuture state </see> 
        ''' after signing the document (before signing the value is unchecked).
        ''' </summary>
        ''' <returns>The <see cref="SignVerify.Common.EndSignatureStateType"> end signuture state </see></returns>
        Public Property EndSignatureState() As EndSignatureStateType
            Get
                Return _EndSignatureState
            End Get
            Set(ByVal value As EndSignatureStateType)
                _EndSignatureState = value
            End Set
        End Property

        Public Property XadesSignatureState() As EndSignatureStateType
            Get
                Return _XadesState
            End Get
            Set(ByVal value As EndSignatureStateType)
                _XadesState = value
            End Set
        End Property
        Public Property SignatureStandard() As SignatureStandard
            Get
                Return _signatureStandard
            End Get
            Set(ByVal value As SignatureStandard)
                _signatureStandard = value
            End Set
        End Property

        ''' <summary>
        ''' This property gets or sets the <see cref="SignVerify.Common.ChainSignatureStateType">chain signuture state</see> 
        ''' after signing the document(before signing the value is unchecked).
        ''' </summary>
        ''' <returns>the <see cref="SignVerify.Common.ChainSignatureStateType">chain signuture state</see></returns>
        Public Property ChainSignatureState() As ChainSignatureStateType
            Get
                Return _ChainSignatureState
            End Get
            Set(ByVal value As ChainSignatureStateType)
                _ChainSignatureState = value
            End Set
        End Property

        ''' <summary>
        ''' This property gets or sets the <see cref="SignVerify.Common.CRLSignatureStateType">CRL state</see> 
        ''' after signing the document(before signing the value is unchecked).
        ''' </summary>
        ''' <returns>The <see cref="SignVerify.Common.CRLSignatureStateType">CRL state</see> </returns>
        Public Property CRLstate() As CRLSignatureStateType
            Get
                Return _CRLstate
            End Get
            Set(ByVal value As CRLSignatureStateType)
                _CRLstate = value
            End Set
        End Property

        ''' <summary>
        ''' This property gets or sets the counter signatures list i.e.
        ''' Counter sinature determine the <see cref="CryptoSignatureInfo">CryptoSignatureInfo</see> on the file.
        ''' </summary>
        ''' <returns>The counter signatures list</returns>
        Public Property counterSignatures() As CryptoSignatureInfoCollection
            Get
                Return _counterSignatures
            End Get
            Set(ByVal value As CryptoSignatureInfoCollection)
                _counterSignatures = value
            End Set
        End Property

        ''' <summary>
        ''' This property gets or sets the unique id to identify the signature.
        ''' </summary>
        ''' <returns>The signature Id</returns>
        Public Property id() As String
            Get
                Return _id
            End Get
            Set(ByVal value As String)
                _id = value
            End Set
        End Property


        ''' <summary>
        ''' This property gets or sets the timestamp status  
        ''' </summary>
        ''' <returns>time stamp status indicates if the request to the time stamp server succeeded </returns>
        Public Property TimeStampState() As TimeStampResponseState
            Get
                Return _timeStampState
            End Get
            Set(ByVal value As TimeStampResponseState)
                _timeStampState = value
            End Set
        End Property

        Public Property TimeStampCertificate() As X509Certificate2
            Get
                Return _timeStampCertificate
            End Get
            Set(ByVal value As X509Certificate2)
                _timeStampCertificate = value
            End Set
        End Property

        Public Property TimeStamp() As DateTime
            Get
                Return _timeStamp
            End Get
            Set(ByVal value As DateTime)
                _timeStamp = value
            End Set
        End Property


        ''' <summary>
        ''' This property gets or sets the The parent 
        ''' (if exists) which signed (serial) on the file before the current signature
        ''' </summary>
        ''' <returns>The signature of the parent data</returns>
        Public Property parent() As CryptoSignatureInfo
            Get
                Return _parent
            End Get
            Set(ByVal value As CryptoSignatureInfo)
                _parent = value
            End Set
        End Property

#End Region

#Region "Constructor"
        ''' <summary>
        ''' Initializes a new instance of the CryptoSignatureInfo class 
        ''' with the  <see cref="System.Security.Cryptography.X509Certificates">X509Certificate2</see> certificate.
        ''' </summary>
        ''' <param name="certificate">The <see cref="System.Security.Cryptography.X509Certificates">X509Certificate2</see> certificate.</param>
        Public Sub New(ByVal certificate As X509Certificate2)
            Me.New(certificate, DateTime.Now)
        End Sub

        ''' <summary>
        ''' Initializes a new instance of the CryptoSignatureInfo class 
        ''' with the  <see cref="System.Security.Cryptography.X509Certificates">X509Certificate2</see> certificate
        ''' and the signing time on the file.
        ''' </summary>
        ''' <param name="certificate">The <see cref="System.Security.Cryptography.X509Certificates">X509Certificate2</see> certificate.</param>
        ''' <param name="signingTime">The signing time on the file.</param>
        Public Sub New(ByVal certificate As X509Certificate2, ByVal signingTime As DateTime)
            _certificate = certificate
            _counterSignatures = New CryptoSignatureInfoCollection
            _id = Guid.NewGuid.ToString
            _fileName = ""
            _signingTime = signingTime.ToLongDateString
            _timeStampState = New TimeStampResponseState
        End Sub

#End Region

    End Class

End Namespace
