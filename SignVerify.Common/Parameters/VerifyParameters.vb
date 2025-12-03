Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Runtime.InteropServices

Namespace SignVerify.Common
    ''' <summary>
    '''  This class contains the veify parameters that are passed to the cryptographic <br />
    ''' service provider that performs verification.<br />
    ''' The class contains either to check <see cref="Common.ChainSignatureStateType">trust chain </see> (if all the signatures in the chain are valid) unchecked (default),<br />
    ''' and either checking <see cref="Common.CRLSignatureStateType">CRL</see> (if sinature is revoked,valid or invalid) or unchecked (default).<br />
    ''' </summary>
    ''' <remarks>The <see cref="VerifyParameters">VerifyParameters</see> class represents parameters that <br />
    ''' you can pass to managed Cryptographic Service Providers from the <br />
    ''' the interfaces: <see cref="SignVerify.Common.ICryptoProvider">ICryptoProvider</see><br />
    ''' <see cref="SignVerify.Common.IBaseCryptoProvider"></see>
    ''' <list type="bullet">
    '''  <listheader><description>Classes with names starting with "ICryptoProvider"</description> </listheader>
    ''' <item><see cref="SignVerify.Common.ICryptoProviderBinary">Binary provider</see></item>
    ''' <item><see cref="SignVerify.Common.ICryptoProviderString">String provider</see></item>
    ''' <item><see cref="SignVerify.Common.ICryptoProviderXml">XML provider</see></item>
    ''' </list>
    ''' are managed code wrappers for the corresponding crypto signature provider.
    '''</remarks>
    Public Class VerifyParameters
        Private _CheckTrustChain As Boolean = True
        Private _checkCRL As Boolean = False
        Private _AuthorizedCA As Dictionary(Of String, List(Of String))

        ''' <summary>
        ''' This property gets and sets either to check <see cref="Common.ChainSignatureStateType">trust chain</see> if all the signatures in the chain are valid) unchecked (default).
        ''' </summary>
        ''' <returns>True - to check the if chain is trusted, false otherwise</returns>
        Public Property CheckTrustChain() As Boolean
            Get
                Return _CheckTrustChain
            End Get
            Set(ByVal value As Boolean)
                _CheckTrustChain = value
            End Set
        End Property

        ''' <summary>
        ''' This property gets and sets either to check <see cref="Common.CRLSignatureStateType">CRL</see> (if sinature is revoked,valid or invalid) or unchecked (default).
        ''' </summary>
        ''' <returns>True - To check <see cref="Common.CRLSignatureStateType">CRL</see>, false otherwise</returns>
        Public Property checkCRL() As Boolean
            Get
                Return _checkCRL
            End Get
            Set(ByVal value As Boolean)
                _checkCRL = value
            End Set
        End Property

        ''' <summary>
        ''' This property contains a list of authorized CA as specified 
        ''' by the user.
        ''' key - The CA (as base64 string)
        ''' value - List of certificates which belong to the key CA.
        ''' </summary>
        ''' <value>The list of CA and the intermidate certificates.</value>
        ''' <returns>The list of CA and the intermidate certificates.</returns>
        Public Property AuthorizedCA() As Dictionary(Of String, List(Of String))
            Get
                Return _AuthorizedCA
            End Get
            Set(ByVal value As Dictionary(Of String, List(Of String)))
                _AuthorizedCA = value
            End Set
        End Property
    End Class
End Namespace
