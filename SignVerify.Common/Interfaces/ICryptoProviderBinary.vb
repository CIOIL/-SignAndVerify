Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text

Namespace SignVerify.Common
    Public Interface ICryptoProviderBinary
        Inherits ICryptoProvider(Of Byte())
    End Interface
End Namespace
