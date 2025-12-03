Namespace SignVerify.Common
    ''' <summary>
    ''' The signature algorithm for signing purpose (either <see cref="System.Security.Cryptography.RSA">RSA</see> algorithm or <see cref="System.Security.Cryptography.DSA">DSA</see> algorithm).
    ''' </summary>
    Public Enum SignAlgorithmType As Integer
        ''' <summary>
        ''' using <see cref="System.Security.Cryptography.RSA">RSA</see> algorithm. 
        ''' </summary>
        RSA_SHA1 = 0
        ''' <summary>
        ''' The signature is added parallel to the signature/s list in the same level (sign on the content)
        ''' </summary>
        DSA_SHA1 = 1
    End Enum

    Public Enum SignaturePositionTypes As Integer
        NotDefined = -1
        TopRight = 0
        TopMiddle = 1
        TopLeft = 2
        BottomRight = 10
        BottomMiddle = 11
        BottomLeft = 12
    End Enum


    ''' <summary>
    ''' <list type="number">
    ''' <listheader> Sign over siganture. The cosing types: </listheader>
    ''' <item> Parallel.</item>
    ''' <item>  Serial.</item>
    ''' </list>
    ''' </summary>
    Public Enum CoSignType As Integer
        ''' <summary>
        ''' The signature is added parallel to the signature/s list in the same level (sign on the content)
        ''' </summary>
        Parallel = 0
        ''' <summary>
        ''' The signature is added serial to the the signature/s list in the same last level (sign on the previous signatures)
        ''' </summary>
        OverSignature = 1
    End Enum

    ''' <summary>
    ''' The end signature state type - indicates the current validity of the signature. 
    ''' </summary>
    Public Enum EndSignatureStateType As Integer
        ''' <summary>
        '''  (default) The signature is not checked.
        ''' </summary>
        Unchecked = 0

        ''' <summary>
        '''   The sinature is unvalid.
        ''' </summary>
        SignatureUnvalid = 1

        ''' <summary>
        '''   The certificate is expired.
        ''' </summary>
        CertificateExpired = 2

        ''' <summary>
        '''  The signature is valid.
        ''' </summary>
        Valid = 3
        ''' <summary>
        '''  The signature does not cover the whole document.
        ''' </summary>
        NotCoverWholeDocument = 4


    End Enum

    ''' <summary>
    ''' The chain signature state type - indicates the current validity of the signatures in the chain <br />
    ''' (if one of the signatures is unvalid the chain signature is unvalid). 
    ''' </summary>
    Public Enum ChainSignatureStateType As Integer
        ''' <summary>
        ''' (default) The chain signatures are not checked. 
        ''' </summary>
        Unchecked = 0
        ''' <summary>
        '''   The chain signatures are unvalid (one of the signatures from the chain is unvalid).
        ''' </summary>
        Unvalid = 1
        ''' <summary>
        '''   The chain signatures are valid.
        ''' </summary>
        Valid = 2

    End Enum

    ''' <summary>
    ''' This enum indicate if the check of authorized CA's.
    ''' </summary>
    Public Enum AuthorizedCAListStateType As Integer
        ''' <summary>
        ''' (default) The chain signatures are not checked. 
        ''' </summary>
        Unchecked = 0
        ''' <summary>
        '''   The chain signatures are unvalid (one of the signatures from the chain is unvalid).
        ''' </summary>
        Unvalid = 1
        ''' <summary>
        '''   The chain signatures are valid.
        ''' </summary>
        Valid = 2
        ''' <summary>
        ''' The user didn't define any list of authorized CA.
        ''' </summary>
        Undefined = 3
    End Enum


    ''' <summary>
    ''' The CRL signature state type, Uses <seealso cref="System.Security.Cryptography.X509Certificates.X509ChainStatusFlags">X509Certificates.X509ChainStatusFlags</seealso>
    ''' </summary>
    Public Enum CRLSignatureStateType As Integer

        ''' <summary>
        ''' (default) The chain signatures are not checked.
        ''' </summary>
        Unchecked = 0
        ''' <summary>
        '''  Specifies that it is not possible to determine whether the certificate has been revoked.
        '''  This can be due to the certificate revocation list (CRL) being offline or unavailable.
        ''' </summary>
        Unknown = 1
        ''' <summary>
        '''  Specifies signature is invalid due to a revoked certificate.
        ''' </summary>
        Revoked = 2
        ''' <summary>
        '''  The signature has no errors.
        ''' </summary>
        Valid = 3
    End Enum

    ''' <summary>
    ''' The signatures state type checks the validity of the signature.
    ''' </summary>
    Public Enum SignaturesStateType As Integer

        ''' <summary>The signatures are not checked if one of the following is unchecked:
        '''  <list type="bullet"> 
        '''     <item> <see cref="CRLSignatureStateType">CRLSignatureStateType</see> is unchecked. </item>
        '''     <item> <see cref="ChainSignatureStateType">ChainSignatureStateType</see> is unchecked. </item>
        '''     <item> <see cref="EndSignatureStateType">EndSignatureStateType</see> is unchecked. </item>
        '''  </list> 
        ''' </summary>
        Unchecked = 0

        ''' <summary>
        ''' The signatures are not valid if one of the following is unvalid:
        ''' <list type="bullet"> 
        '''     <item><see cref="CRLSignatureStateType">CRLSignatureStateType</see> is unvalid or revoked.  </item>
        '''     <item><see cref="ChainSignatureStateType">ChainSignatureStateType</see> is unvalid. </item>
        '''      <item><see cref="EndSignatureStateType">EndSignatureStateType</see> is unvalid or CertificateExpired. </item>
        '''  </list> 
        ''' </summary>
        UnValid = 1

        ''' <summary>
        ''' The signatures is unknow if one of the following is unknow:
        ''' <list type="bullet"> 
        '''     <item><see cref="CRLSignatureStateType">CRLSignatureStateType</see> is unknow.</item>
        '''  </list> 
        ''' </summary>
        Unknow = 3

        ''' <summary>
        ''' The signature has no errors, all the following is valid:
        '''   <list type="bullet"> 
        '''     <item><see cref="CRLSignatureStateType">CRLSignatureStateType</see> is valid. </item>
        '''     <item><see cref="ChainSignatureStateType">ChainSignatureStateType</see> valid. </item>
        '''    <item><see cref="EndSignatureStateType">EndSignatureStateType</see> is valid.  </item>
        '''  </list> 
        ''' </summary>
        Valid = 2
    End Enum
    Public Enum SignatureStandard As Integer
        pkcs7 = 0
        XmlDsig = 1
        xades = 2
        pdf = 3
    End Enum

End Namespace