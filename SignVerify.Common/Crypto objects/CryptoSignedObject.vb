Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Xml
Imports System.Collections
Imports System.IO

Namespace SignVerify.Common
    ''' <summary>
    ''' This class contains data about the <see cref="SignVerify.Common.CryptoContentInfo">signed content </see>, the <see cref="SignVerify.Common.CryptoContentInfo">collection of signatures</see> <br />
    ''' which signed on the content info as well.<br />
    ''' The content can be in any format (for example xml, string, binary etc.) 
    ''' </summary>
    ''' <typeparam name="R">The content can be in any format (for example xml, string, binary etc.)</typeparam>
    ''' <remarks>This class is used for passing data to the 
    ''' different types of Crypto Priveder used for
    ''' sign, verify and cosign actions. </remarks>

    Public Class CryptoSignedObject(Of R)

#Region "Private members"

        Private _ContentInfo As CryptoContentInfo(Of R) = Nothing
        Private _ProviderFriendlyName As String = String.Empty
        Private _detached As Boolean = False
        Private _timeStamped As Boolean = False
        Private _signatureInfos As CryptoSignatureInfoCollection = Nothing
        Private _sdk_versiom As String
        Private _app_versiom As String
        Private _hashInfo As CryptoHashInfo(Of R) = Nothing

#End Region

#Region "Public members"

        ''' <summary>
        ''' This property gets or sets a value of the
        ''' sdk version
        ''' </summary>
        ''' <value>True to use time stamp false otherwise</value>
        ''' <returns>Indication of time stamp usage.</returns>
        Public Property SdkVersion() As String
            Get
                Return _sdk_versiom
            End Get
            Set(ByVal value As String)
                _sdk_versiom = value
            End Set
        End Property

        ''' <summary>
        ''' This property gets or sets a value of the
        ''' xml version
        ''' </summary>
        ''' <value>True to use time stamp false otherwise</value>
        ''' <returns>Indication of time stamp usage.</returns>
        Public Property AppVersion() As String
            Get
                Return _app_versiom
            End Get
            Set(ByVal value As String)
                _app_versiom = value
            End Set
        End Property

        ''' <summary>
        ''' This property gets the signed <see cref="SignVerify.Common.CryptoContentInfo"> content info</see>.
        ''' </summary>
        ''' <returns>The content info.</returns>
        ''' <remarks>The content can be in any format (for example xml, string, binary etc.)</remarks>
        Public ReadOnly Property ContentInfo() As CryptoContentInfo(Of R)
            Get
                Return _ContentInfo
            End Get
        End Property


        ''' <summary>
        ''' This property gets the signed <see cref="SignVerify.Common.CryptoHashInfo"> hash info</see>.
        ''' </summary>
        ''' <returns>The hash info.</returns>
        ''' <remarks>The content can be in any format (for example xml, string, binary etc.)</remarks>
        Public ReadOnly Property HashInfo() As CryptoHashInfo(Of R)
            Get
                Return _hashInfo
            End Get
        End Property

        ''' <summary>
        ''' This property gets the Provider Friendly Name 
        ''' Either using <see cref="System.Security.Cryptography.Xml">XML Digital Signature</see> Provider
        ''' or <see cref="System.Security.Cryptography.Pkcs">PKCS7</see> Provider.
        ''' </summary>
        ''' <returns>The Provider Friendly Name (<see cref="System.Security.Cryptography.Xml">XML Digital Signature</see> Provider or <see cref="System.Security.Cryptography.Pkcs">PKCS7</see> Provider)</returns>
        Public ReadOnly Property ProviderFriendlyName() As String
            Get
                Return _ProviderFriendlyName
            End Get
        End Property

        ''' <summary>
        ''' This property gets the detached option
        ''' </summary>
        ''' <returns>the detached option</returns>
        Public Property detached() As Boolean
            Get
                Return _detached
            End Get
            Set(ByVal value As Boolean)
                _detached = value
            End Set
        End Property

        ''' <summary>
        ''' This property gets the time Stamped option
        ''' </summary>
        ''' <returns>the time Stamped option</returns>
        'Public Property timeStamped() As Boolean
        '    Get
        '        Return _timeStamped
        '    End Get
        '    Set(ByVal value As Boolean)
        '        _timeStamped = value
        '    End Set
        'End Property

        ''' <summary>
        ''' This property gets and sets all the <see cref="SignVerify.Common.CryptoContentInfo">signatures collections </see>
        ''' which contains all the signatures on the content.
        ''' </summary>
        ''' <returns>The signatures collections Infos</returns>
        Public Property signatureInfos() As CryptoSignatureInfoCollection
            Get
                Return _signatureInfos
            End Get
            Set(ByVal value As CryptoSignatureInfoCollection)
                _signatureInfos = value
            End Set
        End Property

      


#End Region

#Region "Constructor"
        ''' <summary>
        ''' Initializes a new instance of the CryptoSignedObject class 
        ''' with the <see cref="SignVerify.Common.CryptoSignatureInfo">content info </see>
        ''' and <see cref="SignVerify.Common.CoSignType">.CoSignType </see>(Parallel or Serial) 
        '''</summary>
        ''' <param name="contentInfo"><see cref="SignVerify.Common.CryptoSignatureInfo">content info </see></param>
        ''' <param name="providerFriendlyName">The Provider Friendly Name (XML Digital Signature Provider or PKCS7)</param>
        ''' <remarks>Initializes a new instance of <see cref="CryptoSignatureInfoCollection">CryptoSignatureInfoCollection</see>.</remarks>
        Public Sub New(ByVal contentInfo As CryptoContentInfo(Of R), ByVal providerFriendlyName As String)
            _ContentInfo = contentInfo
            _ProviderFriendlyName = providerFriendlyName
            _signatureInfos = New CryptoSignatureInfoCollection

        End Sub

        ''' <summary>
        ''' Initializes a new instance of the CryptoSignedObject class 
        ''' with the <see cref="SignVerify.Common.CryptoSignatureInfo">content info </see>
        ''' and <see cref="SignVerify.Common.CoSignType">.CoSignType </see>(Parallel or Serial) 
        '''</summary>
        ''' <param name="hashInfo"><see cref="SignVerify.Common.CryptoHashInfo">hash info </see></param>
        ''' <param name="providerFriendlyName">The Provider Friendly Name (XML Digital Signature Provider or PKCS7)</param>
        ''' <remarks>Initializes a new instance of <see cref="CryptoSignatureInfoCollection">CryptoSignatureInfoCollection</see>.</remarks>
        Public Sub New(ByVal hashInfo As CryptoHashInfo(Of R), ByVal providerFriendlyName As String)
            _hashInfo = hashInfo
            _ProviderFriendlyName = providerFriendlyName
            _signatureInfos = New CryptoSignatureInfoCollection

        End Sub
#End Region



    End Class
End Namespace
