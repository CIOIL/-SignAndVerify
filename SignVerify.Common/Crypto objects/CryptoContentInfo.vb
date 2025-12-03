Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Xml

Namespace SignVerify.Common

    ''' <summary>
    ''' <list type="number">
    ''' <listheader><description>This class contains the crypto content info before and after the signature:</description></listheader>
    ''' <item> signed content - the signed content type can be from any type (xml, string, binary etc.).</item>
    ''' <item> Original content - the original content of the file can be from any type (xml, string, binary etc.).</item>
    ''' <item> Content type - can be from any type (xml, string, binary etc.).</item>
    ''' <item>Original file name - The original file as selected by the user to be signed.</item>
    ''' </list>
    ''' </summary>
    ''' <typeparam name="R">The type of the encrypted file (xml, binary, string etc.)</typeparam>
    Public Class CryptoContentInfo(Of R)

#Region "Private members"

        Private _signedContent As R
        Private _originalContent As R
        Private _contentType As Type
        Private _originalFileName As String = String.Empty

#End Region

#Region "Public members"

        ''' <summary>
        ''' This property gets the signed content, The signed content can be 
        ''' any type of data (xml, binary, string etc.).
        ''' </summary>
        ''' <returns>The signed content.</returns>
        Public ReadOnly Property signedContent() As R
            Get
                Return _signedContent
            End Get
        End Property

        ''' <summary>
        ''' This property gets or sets the file original content 
        ''' </summary>
        ''' <returns>The file original content</returns>
        Public Property originalContent() As R
            Get
                Return _originalContent
            End Get
            Set(ByVal value As R)
                _originalContent = value
            End Set

        End Property

        ''' <summary>
        ''' This property gets the content type (binary, string, xml)
        ''' </summary>
        ''' <returns>The content type (binary, string, xml)</returns>
        Public ReadOnly Property contentType() As Type
            Get
                Return _contentType
            End Get
        End Property

        ''' <summary>
        ''' This property gets or sets the original file name
        ''' </summary>
        ''' <returns>The origianl file name </returns>
        Public Property originalFileName() As String
            Get
                Return _originalFileName
            End Get
            Set(ByVal value As String)
                _originalFileName = value
            End Set
        End Property


#End Region

#Region "Constructor"
        ''' <summary>
        ''' Initializes a new instance of the CryptoContentInfo class 
        ''' with the signed content.
        ''' The ctor also initialize the content type according to the signed content type.
        ''' </summary>
        ''' <param name="signedContent">The signed content.</param>
        Public Sub New(ByVal signedContent As R)
            _signedContent = signedContent
            _contentType = signedContent.GetType
        End Sub
        ''' <summary>
        ''' Initializes a new instance of the CryptoContentInfo class 
        ''' with the signed content and the original file name.
        ''' The ctor also initialize the content type according to the signed content type.
        ''' </summary>
        ''' <param name="signedContent">The signed content.</param>
        ''' <param name="originalFileName">The origianl file name.</param>
        Public Sub New(ByVal signedContent As R, ByVal originalFileName As String)
            _signedContent = signedContent
            _contentType = signedContent.GetType
            _originalFileName = originalFileName
        End Sub

#End Region


    End Class

End Namespace
