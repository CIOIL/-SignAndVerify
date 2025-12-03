Namespace SignVerify.Common.TimeStamp

    ''' <summary>
    ''' When the TimeStampToken is not present
    ''' failInfo indicates the reason why the
    ''' time-stamp request was rejected and
    ''' may be one of the following values.
    ''' <B><h4>These are the only values of TimeStampStatus that SHALL be supported.</h4></B>
    ''' </summary>
    Public Enum TimeStampResponseStatus
        ''' <summary>
        ''' when the PKIStatus contains the value zero a TimeStampToken, as
        ''' requested, is present.
        ''' </summary>
        Granted = 0
        ''' <summary>
        ''' when the PKIStatus contains the value one a TimeStampToken,
        ''' with modifications, is present.
        ''' </summary>
        GrantedwithMods = 1

        ''' <summary>
        ''' This status indicates that the request is rejected. 
        ''' </summary>
        Rejection = 2

        ''' <summary>
        ''' This status indicates that the request is waiting. 
        ''' </summary>
        Waiting = 3

        ''' <summary>
        ''' this message contains a warning that a revocation is
        ''' imminent
        ''' </summary>
        RevocationWarning = 4

        ''' <summary>
        ''' notification that a revocation has occurred 
        ''' </summary>
        RevocationNotification = 5

        Unchecked = 6
    End Enum


    ''' <summary>
    ''' When the TimeStampToken is not present, the failure Info indicates the
    ''' reason why the time-stamp request was rejected and may be one of the
    ''' following values.
    ''' <B><h4>These are the only values of PKIFailureInfo that SHALL be supported.</h4></B>
    ''' Compliant servers SHOULD NOT produce any other values. Compliant
    ''' clients MUST generate an error if values it does not understand are
    ''' present.
    ''' </summary>
    Public Enum TimeStampFailures
        ''' <summary>
        ''' unrecognized or unsupported Algorithm Identifier
        ''' </summary>
        BadAlg = 0

        ''' <summary>
        ''' transaction not permitted or supported
        ''' </summary>
        BadRequest = 2

        ''' <summary>
        ''' the data submitted has the wrong format
        ''' </summary>
        BadDataFormat = 5

        ''' <summary>
        ''' the TSA's time source is not available
        ''' </summary>
        TimeNotAvailable = 14

        ''' <summary>
        ''' the requested TSA policy is not supported by the TSA
        ''' </summary>
        UnAcceptedPolicy = 15

        ''' <summary>
        ''' the requested extension is not supported by the TSA
        ''' </summary>
        UnAcceptedExtention = 16

        ''' <summary>
        ''' the additional information requested could not be understood
        ''' or is not available
        ''' </summary>
        AddInfoNotAvaliable = 17

        ''' <summary>
        ''' the request cannot be handled due to system failure
        ''' </summary>
        SystemFailure = 25

        None = 100
    End Enum


    Public Enum TimeStampResponseValidationErrors
        'the data isn't valid asn1
        UnvalidData

        'the data isn't valid pkcs7 
        UnvalidSignedData

        'signature not valid
        UnvalidSignature

        'Stamped content is differen that the sended one
        UnvalidHashContent

        'Stamped guid is different that the sended one
        UnvalidGuid

        'The certificate in the TS token in the one used for signing
        CertificateNotMatch

        'certificate revoked
        CertificateRevoked

    End Enum


    Public Enum TimeStampResponseValidationWarnings

        CRLUnchecked

        TrustChainUnvalid


    End Enum



End Namespace