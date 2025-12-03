Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Runtime.InteropServices

Namespace SignVerify.Common
    ''' <summary>
    ''' This class contains the sign parameters that are passed to the cryptographic <br />
    ''' service provider that performs sign oction.<br />
    ''' The class also contains detach option and timestamp for the signature.<br />
    ''' </summary>
    ''' <remarks>The SignParameters class represents parameters that <br />
    ''' you can pass to managed Cryptographic Service Providers from the <br />
    ''' the interfaces: <see cref="SignVerify.Common.ICryptoProvider">ICryptoProvider</see>.<br />
    ''' <see cref="SignVerify.Common.IBaseCryptoProvider">IBaseCryptoProvider</see>.
    ''' <list type="bullet">
    '''  <listheader><description>Classes with names starting with "ICryptoProvider" </description></listheader>
    ''' <item><see cref="SignVerify.Common.ICryptoProviderBinary">Binary provider</see></item>
    ''' <item><see cref="SignVerify.Common.ICryptoProviderString">String provider</see></item>
    ''' <item><see cref="SignVerify.Common.ICryptoProviderXml">XML provider</see></item>
    ''' </list>
    ''' are managed code wrappers for the corresponding cryptographic 
    ''' service provider .</remarks>

    Public Class SignParameters
#Region "Private members"

        Private _detached As Boolean = False
        Private _timeStamped As Boolean = False
        Private _signatureInfo As CryptoSignatureInfo = Nothing
        Private _pdfSignatureAppearanceParameters As PDFSignatureAppearanceParameters = Nothing
        Private _appName As String = "SDK"
#End Region

#Region "Public members"

        ''' <summary>
        ''' This property gets the <see cref="SignVerify.Common.CryptoSignatureInfo">signature Info.</see>
        ''' </summary>
        ''' <returns>The <see cref="SignVerify.Common.CryptoSignatureInfo">signature Info.</see></returns>
        Public ReadOnly Property signatureInfo() As CryptoSignatureInfo
            Get
                Return _signatureInfo
            End Get
        End Property


        ''' <summary>
        ''' This property gets the detached option
        ''' </summary>
        ''' <returns>The detached option</returns>
        Public Property pdfSignatureAppearanceParameters() As PDFSignatureAppearanceParameters
            Get
                Return _pdfSignatureAppearanceParameters
            End Get
            Set(ByVal value As PDFSignatureAppearanceParameters)
                _pdfSignatureAppearanceParameters = value
            End Set
        End Property

        Public Property detached() As Boolean
            Get
                Return _detached
            End Get
            Set(ByVal value As Boolean)
                _detached = value
            End Set
        End Property

        ''' <summary>
        ''' This property gets or sets a value indicating if to use 
        ''' time stamped option or not.
        ''' </summary>
        ''' <value>True to use time stamp false otherwise</value>
        ''' <returns>Indication of time stamp usage.</returns>
        Public Property timeStamped() As Boolean
            Get
                Return _timeStamped
            End Get
            Set(ByVal value As Boolean)
                _timeStamped = value
            End Set
        End Property


        ''' <summary>
        ''' This property gets or sets a value of the
        ''' signing application
        ''' </summary>
        ''' <value>True to use time stamp false otherwise</value>
        ''' <returns>Indication of time stamp usage.</returns>
        Public Property appName() As String
            Get
                Return _appName
            End Get
            Set(ByVal value As String)
                _appName = value
            End Set
        End Property

#End Region

#Region "Constructor"
        ''' <summary>
        ''' Initializes a new instance of the SignParameters class 
        ''' with the <see cref="SignVerify.Common.CryptoSignatureInfo"> specified signature Info </see>
        ''' </summary>
        ''' <param name="signatureInfo"><see cref="SignVerify.Common.CryptoSignatureInfo"> specified signature Info </see></param>
        Public Sub New(ByVal signatureInfo As CryptoSignatureInfo)
            _signatureInfo = signatureInfo
        End Sub
#End Region
    End Class
End Namespace
