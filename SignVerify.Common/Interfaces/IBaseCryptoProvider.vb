Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Collections

Namespace SignVerify.Common
    ''' <summary>
    ''' Base interface
    ''' </summary>
    Public Interface IBaseCryptoProvider
        ''' <summary>
        ''' Gets the frendly name of the provider.
        ''' </summary>
        ''' <value>The Provider Friendly Name 
        ''' is either using <see cref="System.Security.Cryptography.Xml">XML Digital Signature </see>Provider
        ''' or <see cref="System.Security.Cryptography.Pkcs">PKCS7</see> provider.</value>
        ReadOnly Property ProviderFriendlyName() As String


    End Interface
End Namespace
