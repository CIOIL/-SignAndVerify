Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Xml
Imports System.Security.Cryptography.X509Certificates

Namespace SignVerify.Common
    Public Class CryptoHashInfo(Of R)

        Private _modifiedContent As R
        Private _hashValue As Byte()
        Private _contentType As Type
        Private _signatureInfo As CryptoSignatureInfo

#Region "Constructor"


        ''' <summary>
        ''' Initializes a new instance of the CryptoContentInfo class 
        ''' with the signed content.
        ''' The ctor also initialize the content type according to the signed content type.
        ''' </summary>
        ''' <param name="signedContent">The content for whom the hash have been calculated.</param>
        Public Sub New(ByVal modifiedContent As R, Optional ByVal hashValue As Byte() = Nothing)
            _modifiedContent = modifiedContent
            _contentType = modifiedContent.GetType
            _hashValue = hashValue
        End Sub


        Public Sub New(ByVal modifiedContent As R, ByVal signatureInfo As CryptoSignatureInfo, Optional ByVal hashValue As Byte() = Nothing)
            _modifiedContent = modifiedContent
            _contentType = modifiedContent.GetType
            _hashValue = hashValue
            _signatureInfo = SignatureInfo
        End Sub
#End Region


        Public Property ModifiedContent() As R
            Get
                Return _modifiedContent
            End Get
            Set(ByVal value As R)
                _modifiedContent = value
            End Set

        End Property

        Public ReadOnly Property ContentType() As Type
            Get
                Return _contentType
            End Get
        End Property

        Public Property SignatureInfo() As CryptoSignatureInfo
            Get
                Return _signatureInfo
            End Get
            Set(ByVal value As CryptoSignatureInfo)
                _signatureInfo = value
            End Set

        End Property

        Public Property HashValue() As Byte()
            Get
                Return _hashValue
            End Get
            Set(ByVal value As Byte())
                _hashValue = value
            End Set

        End Property

      
    End Class

End Namespace

