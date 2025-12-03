Imports LipingShare.LCLib.Asn1Processor
Imports System.Security.Cryptography.Pkcs
Imports System.Security.Cryptography
Imports System.Security.Cryptography.X509Certificates
Imports SignVerify.Common
Imports System.Collections.Generic
Imports System

Namespace SignVerify.Common.TimeStamp


    Public Class TimeStampResponseState
        Friend CRLState As CRLSignatureStateType
        Friend ChainState As ChainSignatureStateType
        Friend CertificateState As EndSignatureStateType

        Public ResponseStatus As TimeStampResponseStatus
        Public ResponseFailureType As TimeStampFailures

        Public ValidationErrors As List(Of TimeStampResponseValidationErrors)
        Public ValidationWarnings As List(Of TimeStampResponseValidationWarnings)

        Public Sub New()
            CRLState = CRLSignatureStateType.Unchecked
            ChainState = ChainSignatureStateType.Unchecked
            CertificateState = EndSignatureStateType.Unchecked
            ResponseStatus = TimeStampResponseStatus.Unchecked
            ResponseFailureType = TimeStampFailures.None
            ValidationWarnings = New List(Of TimeStampResponseValidationWarnings)
            ValidationErrors = New List(Of TimeStampResponseValidationErrors)
        End Sub

    End Class

    Public Class TimeStampResponse

        Public ReadOnly Response() As Byte
        Public ReadOnly Data As TimeStampResponseData
        Public ReadOnly DataAsn1 As Asn1Node
        Private _ValidationResult As TimeStampResponseState

        Public ReadOnly Property ValidationResult() As TimeStampResponseState
            Get
                Return _ValidationResult
            End Get
        End Property

        Public Sub New(ByVal Response() As Byte)
            'load bytes
            Me.Response = Response

            'decode asn1
            Me.DataAsn1 = New Asn1Node
            If Not DataAsn1.LoadData(Response) Then
                Me.DataAsn1 = Nothing
                Return
            End If

            Me.Data = New TimeStampResponseData(Utils.GetBytes(GetData))

        End Sub



#Region "Response validation"

        Public Function Validate(ByVal OriginalContent As Byte(), ByVal OriginalNonce As Guid) As TimeStampResponseState

            _ValidationResult = New TimeStampResponseState

            'unvalid asn1 
            If Response Is Nothing OrElse DataAsn1 Is Nothing Then
                _ValidationResult.ValidationErrors.Add(TimeStampResponseValidationErrors.UnvalidData)
                Return _ValidationResult
            End If


            'get the response status
            _ValidationResult.ResponseStatus = GetTimeStampResponseStatus()
            If _ValidationResult.ResponseStatus <> TimeStampResponseStatus.Granted Then
                _ValidationResult.ResponseFailureType = GetTimeStampResponseFailure()
                Return _ValidationResult
            End If


            'validate the data
            Dim _DataValidation As TimeStampResponseState = Me.Data.Validate(OriginalContent, OriginalNonce)
            _DataValidation.ResponseStatus = _ValidationResult.ResponseStatus
            _DataValidation.ResponseFailureType = _ValidationResult.ResponseFailureType
            _ValidationResult = _DataValidation


            Return _ValidationResult
        End Function
 

#End Region

#Region "Response navigation"
        ''' <summary>
        ''' This method retrives the TimeStampStatus from the response.
        ''' </summary>
        ''' <returns>The <see cref="TimeStampResponseStatus">TimeStampResponseStatus</see> which indicates if the request is granted or not (if not the reason)</returns>
        Private Function GetTimeStampResponseStatus() As TimeStampResponseStatus
            Dim Node As Asn1Node = DataAsn1.GetChildNode(0).GetChildNode(0)
            If Not Node Is Nothing Then
                Return CType(CUInt(Node.Data(0)), TimeStampResponseStatus)
            End If
            Return TimeStampResponseStatus.Rejection
        End Function

        ''' <summary>
        ''' This method return from the rersponse the PKIFailureInfo_Enum
        ''' </summary>
        ''' <returns>The <see cref="TimeStampFailures">TimeStampFailures</see> which indicates if the request is granted or not (if not the reason)</returns>
        Private Function GetTimeStampResponseFailure() As TimeStampFailures
            Dim Node As Asn1Node = DataAsn1.GetChildNode(0).GetChildNode(2)
            If Not Node Is Nothing Then
                Return CType(CUInt(Node.Data(0)), TimeStampFailures)
            End If
            Return Nothing
        End Function

        
        Private Function GetData() As Asn1Node
            Return DataAsn1.GetChildNode(1)
        End Function

       
#End Region

    End Class
End Namespace