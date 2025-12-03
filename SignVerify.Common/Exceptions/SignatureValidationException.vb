Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Runtime.Serialization

Namespace SignVerify.Common
    ''' <summary>
    ''' The exception that is thrown when signature is not found when trying to sign.
    ''' <seealso cref="System.ApplicationException">ApplicationException</seealso>
    ''' </summary>
    Public Class SignatureValidationException
        Inherits ApplicationException

        ''' <summary>
        ''' Initializes a new instance of the SignatureValidationException class with a specified error message.
        ''' </summary>
        ''' <param name="message">The error message that explains the reason for the exception.</param>
        ''' <remarks>This constructor initializes the Message property of the new 
        ''' instance to a system-supplied message that describes the error
        ''' This class inherit from<seealso cref="System.ApplicationException">ApplicationException</seealso></remarks>
        Public Sub New(ByVal message As String)
            MyBase.New(message)
        End Sub

        ''' <summary>
        ''' Initializes a new instance of the SignatureValidationException class with a specified error message.
        ''' </summary>
        ''' <param name="message">The error message that explains the reason for the exception.</param>
        ''' <param name="innerException">InnerException parameter obtain the set of exceptions that led to the current exception.</param>
        ''' <remarks>This constructor initializes the Message and InnerException properties of the new 
        ''' instance to a system-supplied message that describes the error</remarks>
        Public Sub New(ByVal message As String, ByVal innerException As Exception)
            MyBase.New(message, innerException)
        End Sub

        ''' <summary>
        ''' Initializes a new instance of the SignatureValidationException class with serialized data.  
        ''' </summary>
        ''' <param name="info">The object that holds the serialized object data.
        ''' <see cref="System.Runtime.Serialization.SerializationInfo">SerializationInfo</see></param>
        ''' <param name="context">The contextual information about the source or destination.
        ''' <see cref="System.Runtime.Serialization.StreamingContext">StreamingContext</see></param>
        ''' <remarks>This constructor is called during deserialization to reconstitute the exception object transmitted over a stream.</remarks>
        Public Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
            MyBase.New(info, context)
        End Sub
    End Class
End Namespace
