Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Runtime.Serialization

Namespace SignVerify.Common
    ''' <summary>
    ''' The exception that is thrown when when no node SignObject was not found in the signed file.
    ''' <seealso cref="System.ApplicationException">ApplicationException</seealso>
    ''' </summary>
    Public Class CLException
        Inherits ApplicationException

        Public StatusCode As StatusCodes

        ''' <summary>
        ''' Initializes a new instance of the SignatureException class with a specified error message.
        ''' </summary>
        ''' <param name="message">The error message that explains the reason for the exception.</param>
        ''' <remarks>This constructor initializes the Message property of the new 
        ''' instance to a system-supplied message that describes the error</remarks>
        Public Sub New(ByVal message As String)
            MyBase.New(message)
        End Sub

        Public Sub New(ByVal StatusCode As StatusCodes)
            MyBase.New(StatusCode.ToString())
            Me.StatusCode = StatusCode
        End Sub
    End Class


    Public Enum StatusCodes As Integer
        ok = 1
        UnExpectedError = -1
        InvalidDestination = -2
        NoCertificate = -3
        InvalidSource = -4
        InvalidPath = -5
        ReadFileError = -6
        DownloadError = -7
        SignError = -8
        UploadError = -9
        SaveFileError = -10
        InvalidParameters = -11
        SignatureNotValid = -12
        ProviderMissing = -13
        CosignDifferentProvider = -14
        CosignPKCS7NotAllowed = -15
        CosignXadesNotAllowed = -16
    End Enum
End Namespace
