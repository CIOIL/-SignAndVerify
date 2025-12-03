Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Security.Cryptography.X509Certificates
Imports System.Runtime.InteropServices

Namespace SignVerify.Common


    Public Class PDFSignatureAppearanceParameters
#Region "Private members"
        Private _text As String
        Private _reason As String
        Private _image As Byte()
        Private _useDefaultImage As Boolean
        Private _location As String
        Private _contact As String
        Private _signatureHeight As Single = 80
        Private _signatureWidth As Single = 80
        Private _page As Integer = 1
        Private _showName As Boolean = True
        Private _position As SignaturePositionTypes = SignaturePositionTypes.TopLeft
#End Region
        Public Property text() As String
            Get
                Return _text
            End Get
            Set(ByVal value As String)
                _text = value
            End Set
        End Property
        Public Property reason() As String
            Get
                Return _reason
            End Get
            Set(ByVal value As String)
                _reason = value
            End Set
        End Property
        Public Property image() As Byte()
            Get
                Return _image
            End Get
            Set(ByVal value As Byte())
                _image = value
            End Set
        End Property
        Public Property useDefaultImage() As Boolean
            Get
                Return _useDefaultImage
            End Get
            Set(ByVal value As Boolean)
                _useDefaultImage = value
            End Set
        End Property
        Public Property showName() As Boolean
            Get
                Return _showName
            End Get
            Set(ByVal value As Boolean)
                _showName = value
            End Set
        End Property
       
        Public Property location() As String
            Get
                Return _location
            End Get
            Set(ByVal value As String)
                _location = value
            End Set
        End Property
        Public Property contact() As String
            Get
                Return _contact
            End Get
            Set(ByVal value As String)
                _contact = value
            End Set
        End Property
        Public Property signatureHeight() As Single
            Get
                Return _signatureHeight
            End Get
            Set(ByVal value As Single)
                _signatureHeight = value
            End Set
        End Property
        Public Property signatureWidth() As Single
            Get
                Return _signatureWidth
            End Get
            Set(ByVal value As Single)
                _signatureWidth = value
            End Set
        End Property
        Public Property page() As Integer
            Get
                Return _page
            End Get
            Set(ByVal value As Integer)
                _page = value
            End Set
        End Property
        Public Property position() As SignaturePositionTypes
            Get
                Return _position
            End Get
            Set(ByVal value As SignaturePositionTypes)
                _position = value
            End Set
        End Property
    End Class
End Namespace