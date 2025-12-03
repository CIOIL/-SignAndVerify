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
    Public Class SignatureException
        Inherits ApplicationException

        Public SignatureError As SignatureErrorTypes

        ''' <summary>
        ''' Initializes a new instance of the SignatureException class with a specified error message.
        ''' </summary>
        ''' <param name="message">The error message that explains the reason for the exception.</param>
        ''' <remarks>This constructor initializes the Message property of the new 
        ''' instance to a system-supplied message that describes the error</remarks>
        Public Sub New(ByVal message As String)
            MyBase.New(message)
        End Sub

        Public Sub New(ByVal SignatureError As SignatureErrorTypes)
            MyBase.New()
            Me.SignatureError = SignatureError
        End Sub
    End Class


    Public Enum SignatureErrorTypes
        Unknow = 0
        NoCertificateSelected = 1
        ProvidersNotFound = 2
    End Enum
End Namespace
