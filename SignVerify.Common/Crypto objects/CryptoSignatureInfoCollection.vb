Imports System.Collections.Generic
Imports System.Security.Cryptography.X509Certificates
Imports System.Collections
Namespace SignVerify.Common
    ''' <summary>
    ''' This class provides services to handle <see cref="CryptoSignatureInfoCollection"> CryptoSignatureInfoCollection </see>
    ''' </summary>
    ''' <remarks>This class implements <see cref="System.Collections.Generic.List">List</see> which contains 
    ''' <see cref="CryptoSignatureInfo">CryptoSignatureInfo</see> objects.
    ''' Each <see cref="CryptoSignatureInfo">CryptoSignatureInfo</see> contains  <see cref="CryptoSignatureInfoCollection"> CryptoSignatureInfoCollection </see>.</remarks>
    Public Class CryptoSignatureInfoCollection
        Inherits List(Of CryptoSignatureInfo)

#Region "Private members"

        'Detremine if the siganture is fixed.
        Private SignatureStateArr As List(Of SignaturesStateType)
        Private TimeStampStateArr As List(Of SignaturesStateType)
#End Region

#Region "constructor"

        ''' <summary>
        ''' Class default ctor.
        ''' Initializes a new instance of the <see cref="CryptoSignatureInfoCollection"> CryptoSignatureInfoCollection </see> class.
        ''' </summary>
        Public Sub New()
            SignatureStateArr = New List(Of SignaturesStateType)
            TimeStampStateArr = New List(Of SignaturesStateType)
        End Sub

#End Region

#Region "Public methodes"

        ''' <summary>
        ''' This method returns the inner crypto signature info collection 
        ''' according to index value.
        ''' </summary>
        ''' <param name="Index">The searched index.</param>
        ''' <returns> <see cref="CryptoSignatureInfoCollection"> CryptoSignatureInfoCollection </see> according to the index parameter.</returns>
        Public Function getLevel(ByVal Index As Long) As CryptoSignatureInfoCollection
            Dim tempSign As CryptoSignatureInfoCollection = Me
            Dim deepLenght As Long = 0

            'find index
            While deepLenght < Index
                If tempSign.Count > 0 Then
                    tempSign = tempSign(0).counterSignatures
                    deepLenght = deepLenght + 1
                Else
                    Exit While
                End If
            End While

            'return found index or new list
            If deepLenght = Index Then
                Return tempSign
            Else
                Return New CryptoSignatureInfoCollection
            End If

        End Function

        ''' <summary>
        ''' This method gets the number of levels actually exists in the collection.
        ''' </summary>
        ''' <returns>The level count in the collection.</returns>
        Public Function getLevelCount() As Long
            Dim tempSign As List(Of CryptoSignatureInfo) = Me
            Dim deepLenght As Long = 0

            While tempSign.Count > 0
                tempSign = tempSign(0).counterSignatures
                deepLenght = deepLenght + 1
            End While

            Return deepLenght

        End Function

        ''' <summary>
        ''' This method retrurns the last collection level of crypto signature info.
        ''' </summary>
        ''' <returns>The last <see cref="CryptoSignatureInfoCollection"> CryptoSignatureInfoCollection </see> level</returns>
        ''' <remarks>This method searches the last level of <see cref="CryptoSignatureInfoCollection">CryptoSignatureInfoCollection</see></remarks>
        Public Function getLastSignaturesLevel() As CryptoSignatureInfoCollection
            Return Me.getLevel(Me.getLevelCount - 1)
        End Function


        ''' <summary>
        ''' This method returns the <see cref="CryptoSignatureInfo">CryptoSignatureInfo</see> according to signature Id.
        ''' </summary>
        ''' <param name="ID">The signature id.</param>
        ''' <param name="recursive">If True - Seraches the <see cref="CryptoSignatureInfo">CryptoSignatureInfo</see> in recurcive manner, 
        ''' Otherwise seraches the <see cref="CryptoSignatureInfo">CryptoSignatureInfo</see> using for loop.
        ''' Optional - default true.</param>
        ''' <returns>The <see cref="CryptoSignatureInfo">CryptoSignatureInfo</see> by signature Id</returns>
        ''' <remarks>This method searches the <see cref="CryptoSignatureInfo">CryptoSignatureInfo</see> by the signature Id. </remarks>
        Public Function getSignatureInfoByID(ByVal ID As String, Optional ByVal recursive As Boolean = True) As CryptoSignatureInfo
            Return _getSignatureInfoByID(ID, recursive, Me)
        End Function

   
        ''' <summary>
        ''' This method returns signature by <see cref="Certificate">Certificate</see> Name. 
        ''' </summary>
        ''' <param name="CN">The sign certificate name</param>
        ''' <param name="recursive">If True - Seraches the <see cref="CryptoSignatureInfo">CryptoSignatureInfo</see> in recurcive manner, 
        ''' Otherwise seraches the <see cref="CryptoSignatureInfo">CryptoSignatureInfo</see> using for loop.
        ''' Optional - default true.</param>
        ''' <returns>The <see cref="CryptoSignatureInfo">signature info</see></returns>
        ''' <remarks>This method searches the <see cref="CryptoSignatureInfo">CryptoSignatureInfo</see> by <see cref="Certificate">Certificate</see> Name.</remarks>
        Public Function getSignatureInfoByCN(ByVal CN As String, Optional ByVal recursive As Boolean = True) As CryptoSignatureInfo
            Return _getSignatureInfoByCN(CN, recursive, Me)
        End Function


        ''' <summary>
        ''' This method returns the signature by <see cref="Certificate">Certificate</see> details.
        ''' </summary>
        ''' <param name="cert">The serached <see cref="Certificate">Certificate</see>.</param>
        ''' <param name="recursive">If True - Seraches the <see cref="CryptoSignatureInfo">CryptoSignatureInfo</see> in recurcive manner, 
        ''' Otherwise seraches the <see cref="CryptoSignatureInfo">CryptoSignatureInfo</see> using for loop.
        ''' Optional - default true.</param>
        ''' <returns>The <see cref="CryptoSignatureInfo">signature info</see> </returns>
        ''' <remarks>This method searches the <see cref="CryptoSignatureInfo">CryptoSignatureInfo</see> by <see cref="Certificate">Certificate</see> details.</remarks>
        Public Function getSignatureInfoByCertificate(ByVal cert As X509Certificate2, Optional ByVal recursive As Boolean = True) As CryptoSignatureInfo
            Return _getSignatureInfoByCertificate(cert, recursive, Me)
        End Function


        ''' <summary>
        ''' This method checks siganture collection valididaty.
        ''' The signature can be one of the following:<br />
        ''' <list type="number">
        ''' <item>Valid - if all the checks are valid.</item>
        ''' <item> Unvalid - if one of the checks is unvalid.</item>
        ''' <item> Unchecked - if one of the checks is unchecked.</item>
        ''' </list>
        ''' <seealso cref="SignaturesStateType">SignaturesStateType</seealso>
        ''' </summary>
        ''' <returns><seealso cref="SignaturesStateType">SignaturesStateType</seealso> state of the signatures in the collection</returns>
        Public Function getGlobalSignatureState() As SignaturesStateType
            GetRecursiveSignaturesStates(Me)
            If SignatureStateArr.Contains(SignaturesStateType.UnValid) Then
                Return SignaturesStateType.UnValid
            ElseIf SignatureStateArr.Contains(SignaturesStateType.Unchecked) Then
                Return SignaturesStateType.Unchecked
            ElseIf SignatureStateArr.Contains(SignaturesStateType.Unknow) Then
                Return SignaturesStateType.Unknow
            Else
                Return SignaturesStateType.Valid
            End If

        End Function

        Public Function getGlobalTimeStampState() As SignaturesStateType
            GetRecursiveTimestampStates(Me)
            If TimeStampStateArr.Contains(SignaturesStateType.UnValid) Then
                Return SignaturesStateType.UnValid
            ElseIf TimeStampStateArr.Contains(SignaturesStateType.Unchecked) Then
                Return SignaturesStateType.Unchecked
            Else
                Return SignaturesStateType.Valid
            End If

        End Function
#End Region

#Region "Private methodes"

        'get the last signatures level for simple sign model
        'the parralle sign is only on the last level
        'NOT IN USE
        Private Function _getLastSignaturesLevelSimple(ByVal cryptoSign As CryptoSignatureInfoCollection) As CryptoSignatureInfoCollection

            Dim result As New CryptoSignatureInfoCollection

            If cryptoSign.Count > 0 Then
                If cryptoSign(0).counterSignatures.Count = 0 Then
                    For Each sign As CryptoSignatureInfo In cryptoSign
                        result.Add(sign)
                    Next
                Else
                    result = _getLastSignaturesLevelSimple(cryptoSign(0).counterSignatures)
                End If
            End If

            Return result

        End Function

        'get the last signatures level for complex sign model
        'the parralle sign can be on each level
        'NOT IN USE
        Private Sub _getLastSignaturesLevelComplex(ByVal cryptoSign As List(Of CryptoSignatureInfo), ByRef result As List(Of CryptoSignatureInfo), ByVal ids As ArrayList)

            For Each sign As CryptoSignatureInfo In cryptoSign
                If sign.counterSignatures.Count = 0 Then
                    If Not ids.Contains(sign.id) Then
                        result.Add(sign)
                        ids.Add(sign.id)
                    End If

                Else
                    _getLastSignaturesLevelComplex(sign.counterSignatures, result, ids)
                End If
            Next

        End Sub

        'get signature by ID
        Private Function _getSignatureInfoByID(ByVal ID As String, ByVal recursive As Boolean, ByVal cryptoSign As CryptoSignatureInfoCollection) As CryptoSignatureInfo

            If cryptoSign.Count > 0 Then
                For Each sign As CryptoSignatureInfo In cryptoSign
                    If sign.id = ID Then
                        Return sign
                    End If
                Next
                If recursive Then Return _getSignatureInfoByID(ID, recursive, cryptoSign(0).counterSignatures)

            Else
                Return Nothing
            End If
            Return Nothing
        End Function

        'get signature by Certificate Name (CN) 
        Private Function _getSignatureInfoByCN(ByVal CN As String, ByVal recursive As Boolean, ByVal cryptoSign As CryptoSignatureInfoCollection) As CryptoSignatureInfo

            If cryptoSign.Count > 0 Then
                For Each sign As CryptoSignatureInfo In cryptoSign
                    If Certificate.getSignCertificateName(sign.certificate) = CN Then
                        Return sign
                    End If
                Next
                If recursive Then Return _getSignatureInfoByCN(CN, recursive, cryptoSign(0).counterSignatures)

            Else
                Return Nothing
            End If
            Return Nothing
        End Function

        'get signature by Certificate
        Private Function _getSignatureInfoByCertificate(ByVal cert As X509Certificate2, ByVal recursive As Boolean, ByVal cryptoSign As CryptoSignatureInfoCollection) As CryptoSignatureInfo

            If cryptoSign.Count > 0 Then
                For Each sign As CryptoSignatureInfo In cryptoSign
                    If sign.certificate.Equals(cert) Then
                        Return sign
                    End If
                Next
                If recursive Then Return _getSignatureInfoByCertificate(cert, recursive, cryptoSign(0).counterSignatures)

            Else
                Return Nothing
            End If
            Return Nothing
        End Function


        ''' <summary>
        ''' This method checks siganture collection valididaty.
        ''' The signature can be one of the following:<br />
        ''' <list type="number">
        ''' <item>Valid - if all the checks are valid.</item>
        ''' <item> Unvalid - if one of the checks is unvalid.</item>
        ''' <item> Unchecked - if one of the checks is unchecked.</item>
        ''' </list>
        ''' <seealso cref="SignaturesStateType">SignaturesStateType</seealso>
        ''' </summary>
        ''' <remarks>This siganture check is done to indicate to the user the state
        ''' of all signatures on specific file</remarks>
        Private Sub GetRecursiveSignaturesStates(ByVal signatures As CryptoSignatureInfoCollection)
            For Each signature As CryptoSignatureInfo In signatures
                If Not signature Is Nothing Then
                    If signature.EndSignatureState = EndSignatureStateType.SignatureUnvalid Or _
                           signature.CRLstate = CRLSignatureStateType.Revoked Or _
                           signature.ChainSignatureState = ChainSignatureStateType.Unvalid Then 'Or _
                        'signature.TimeStausStatus = TimeStausStatus_Enum.Rejection Then 'unvalid
                        SignatureStateArr.Add(SignaturesStateType.UnValid)
                    ElseIf signature.EndSignatureState = EndSignatureStateType.CertificateExpired Or _
                        signature.CRLstate = CRLSignatureStateType.Unknown Then
                        SignatureStateArr.Add(SignaturesStateType.Unknow)
                    ElseIf signature.EndSignatureState = EndSignatureStateType.Unchecked Or _
                       signature.CRLstate = CRLSignatureStateType.Unchecked Or _
                       signature.ChainSignatureState = ChainSignatureStateType.Unchecked Then 'Or _
                        'signature.TimeStausStatus = TimeStausStatus_Enum.Unchecked Then 'unchecked
                        SignatureStateArr.Add(SignaturesStateType.Unchecked)
                        GetRecursiveSignaturesStates(signature.counterSignatures)
                    Else 'valid
                        SignatureStateArr.Add(SignaturesStateType.Valid)
                        GetRecursiveSignaturesStates(signature.counterSignatures)
                    End If
                End If
            Next
        End Sub
        Private Sub GetRecursiveTimestampStates(ByVal signatures As CryptoSignatureInfoCollection)
            For Each signature As CryptoSignatureInfo In signatures
                If Not signature Is Nothing Then
                    If signature.TimeStampState Is Nothing Then
                        TimeStampStateArr.Add(SignaturesStateType.Unchecked)
                        GetRecursiveSignaturesStates(signature.counterSignatures)
                    ElseIf signature.TimeStampState.ResponseStatus = TimeStamp.TimeStampResponseStatus.Rejection Or _
                        signature.TimeStampState.ResponseStatus = TimeStamp.TimeStampResponseStatus.GrantedwithMods Or _
                        signature.TimeStampState.ResponseStatus = TimeStamp.TimeStampResponseStatus.RevocationNotification Or _
                           signature.TimeStampState.ResponseStatus = TimeStamp.TimeStampResponseStatus.RevocationWarning Or _
                           signature.TimeStampState.ResponseStatus = TimeStamp.TimeStampResponseStatus.Waiting Or _
                           signature.TimeStampState.CertificateState = EndSignatureStateType.SignatureUnvalid Or _
                           signature.TimeStampState.CertificateState = EndSignatureStateType.CertificateExpired Or _
                           signature.TimeStampState.CRLState = CRLSignatureStateType.Revoked Or _
                           signature.TimeStampState.ChainState = ChainSignatureStateType.Unvalid Then
                        'signature.TimeStausStatus = TimeStausStatus_Enum.Rejection Then 'unvalid
                        TimeStampStateArr.Add(SignaturesStateType.UnValid)
                    ElseIf signature.TimeStampState.CRLState = CRLSignatureStateType.Unknown Then
                        TimeStampStateArr.Add(SignaturesStateType.Unknow)
                    ElseIf signature.TimeStampState.ResponseStatus = TimeStamp.TimeStampResponseStatus.Unchecked Or _
                       signature.TimeStampState.CRLState = CRLSignatureStateType.Unchecked Or _
                       signature.TimeStampState.ChainState = ChainSignatureStateType.Unchecked Or _
                        signature.TimeStampState.CertificateState = EndSignatureStateType.Unchecked Then  'Or _
                        'signature.TimeStausStatus = TimeStausStatus_Enum.Unchecked Then 'unchecked
                        TimeStampStateArr.Add(SignaturesStateType.Unchecked)
                        GetRecursiveSignaturesStates(signature.counterSignatures)
                    Else 'valid
                        TimeStampStateArr.Add(SignaturesStateType.Valid)
                        GetRecursiveSignaturesStates(signature.counterSignatures)
                    End If
                End If
            Next
        End Sub
#End Region

    End Class
End Namespace