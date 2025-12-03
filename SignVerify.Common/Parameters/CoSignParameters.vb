Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Security.Cryptography.X509Certificates
Imports System.Runtime.InteropServices

Namespace SignVerify.Common
    ''' <summary>
    ''' This class contains the cosign parameters that are passed to the cryptographic <br />
    ''' service provider that performs cryptographic computations.<br />
    ''' </summary>
    ''' <remarks>The CoSignParameters class represents parameters that <br />
    ''' you can pass to managed Cryptographic Service Providers from the <br />
    ''' the interfaces: 
    ''' <list type="bullet">
    ''' <item><see cref="SignVerify.Common.ICryptoProvider"> ICryptoProvider</see></item>
    ''' <item><see cref="SignVerify.Common.IBaseCryptoProvider"> IBaseCryptoProvider</see>.</item>
    ''' Classes with names starting with "ICryptoProvider" 
    ''' <item><see cref="SignVerify.Common.ICryptoProviderBinary">Binary provider</see></item>
    ''' <item><see cref="SignVerify.Common.ICryptoProviderString">String provider</see></item>
    ''' <item><see cref="SignVerify.Common.ICryptoProviderXml">XML provider</see></item>
    ''' </list>
    ''' are managed code wrappers for the corresponding crypto signature provider.<br />
    ''' Inherit from <see cref=" SignVerify.Common.SignParameters">SignParameters.</see></remarks>

    Public Class CoSignParameters
        Inherits SignParameters
#Region "Private members"

        'coSign options
        Private _coSignType As CoSignType = CoSignType.OverSignature

#End Region

#Region "Public members"

        ''' <summary>
        ''' Gets or sets a CoSignType object that 
        ''' represents the type of cosigning (Parallel or Serial) 
        ''' <see cref="SignVerify.Common.CoSignType"/>
        ''' </summary>
        ''' <value>The type of the cosign <see cref="SignVerify.Common.CoSignType"/> (Parallel or Serial).</value>
        Public Property CoSignType() As CoSignType
            Get
                Return _coSignType
            End Get
            Set(ByVal value As CoSignType)
                _coSignType = value
            End Set
        End Property

#End Region

#Region "Constructor"

        ''' <summary>
        ''' Initializes a new instance of the CoSignParameters class 
        ''' with the specified signatureInfo <see cref="SignVerify.Common.CryptoSignatureInfo"/> 
        ''' and <see cref="CoSignType">CoSignType</see> (Parallel or Serial) <see cref="SignVerify.Common.CoSignType"/>.
        ''' </summary>
        ''' <param name="signatureInfo">signature info <see cref="SignVerify.Common.CryptoSignatureInfo"/> </param>
        ''' <param name="CoSignType"><see cref="CoSignType">CoSignType</see> Parallel or Serial <see cref="SignVerify.Common.CoSignType"/></param>
        ''' <remarks></remarks>
        Public Sub New(ByVal signatureInfo As CryptoSignatureInfo, ByVal CoSignType As CoSignType)
            MyBase.New(signatureInfo)
            Me.CoSignType = CoSignType
        End Sub


#End Region


    End Class
End Namespace
