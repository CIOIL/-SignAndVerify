Imports System.Collections.Generic
Imports System.Collections
Imports System
Imports Microsoft.VisualBasic
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography.X509Certificates
Imports System.Diagnostics
Imports System.IO

Namespace SignVerify.Common
    Public Class CardServices

        <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Auto)> _
        Friend Structure SCARD_READERSTATE
            <MarshalAs(UnmanagedType.LPTStr)> _
            Friend szReader As String
            Friend pvUserData As IntPtr
            Friend dwCurrentState As Integer
            Friend dwEventState As Integer
            Friend cbAtr As Integer
            <MarshalAs(UnmanagedType.ByValArray, SizeConst:=36)> _
            Friend rgbAtr As Byte()
        End Structure

        ''' <summary>
        ''' This method the SCardListReaders function provides the list of readers within a set of named
        '''  reader groups, eliminating duplicates.
        ''' The caller supplies a list of reader groups, and receives the list of readers 
        ''' within the named groups. Unrecognized group names are ignored
        ''' </summary>
        ''' <param name="hContext">Handle that identifies the resource manager context for the query. 
        ''' The resource manager context can be set by a previous call to SCardEstablishContext. 
        ''' This parameter cannot be NULL.</param>
        ''' <param name="mzGroup">Names of the reader groups defined to the system, as a multi-string. 
        ''' Use a NULL value to list all readers in the system (that is, the SCard$AllReaders group).</param>
        ''' <param name="ReaderList">Multi-string that lists the card readers within the supplied reader 
        ''' groups. If this value is NULL, SCardListReaders ignores the buffer length supplied in 
        ''' pcchReaders, writes the length of the buffer that would have been returned 
        ''' if this parameter had not been NULL to pcchReaders, and returns a success code.</param>
        ''' <param name="pcchReaders">Length of the mszReaders buffer in characters. 
        ''' This parameter receives the actual length of the multi-string structure, 
        ''' including all trailing null characters. If the buffer length is specified as SCARD_AUTOALLOCATE,
        '''  then mszReaders is converted to a pointer to a byte pointer, and receives
        '''  the address of a block of memory containing the multi-string structure. 
        ''' This block of memory must be deallocated with SCardFreeMemory.</param>
        ''' <returns>This function returns different values depending on whether it succeeds or fails.</returns>
        Private Declare Function SCardListReaders Lib "WinScard.dll" Alias "SCardListReadersA" ( _
                        ByVal hContext As IntPtr, _
                        ByVal mzGroup As String, _
                        ByVal ReaderList As String, _
                        ByRef pcchReaders As Integer _
    ) As Integer

        Private Declare Function SCardCancel Lib "WinScard.dll" Alias "SCardCancel" ( _
                        ByVal hContext As IntPtr) As Integer
        ''' <summary>
        ''' The SCardEstablishContext function establishes the resource manager context 
        ''' (the scope) within which database operations are performed.
        ''' </summary>
        ''' <param name="dwScope">Scope of the resource manager context</param>
        ''' <param name="pvReserved1">Reserved for future use and must be NULL. This parameter will allow a suitably privileged management application
        '''  to act on behalf of another user.</param>
        ''' <param name="pvReserved2">Reserved for future use and must be NULL.</param>
        ''' <param name="phContext">A handle to the established resource manager context. This handle can now be supplied to other 
        ''' functions attempting to do work within this context.</param>
        ''' <returns>If the function succeeds, the function returns SCARD_S_SUCCESS. 
        ''' If the function fails, it returns an error code. For more information, see Smart Card Return Values. </returns>
        Private Declare Ansi Function SCardEstablishContext Lib "WinScard.dll" ( _
                    ByVal dwScope As Integer, _
                    ByVal pvReserved1 As Integer, _
                    ByVal pvReserved2 As Integer, _
                    ByRef phContext As IntPtr _
    ) As Integer

        ''' <summary>
        ''' The SCardStatus function provides the current status of a smart card in a reader.
        '''  You can call it any time after a successful call to SCardConnect and before a successful call to SCardDisconnect. 
        ''' It does not affect the state of the reader or reader driver.
        ''' </summary>
        ''' <param name="hCard">Reference value returned from SCardConnect.</param>
        ''' <param name="szReaderName">List of display names (multiple string) by which the currently connected reader is known</param>
        ''' <param name="pcchReaderLen">On input, supplies the length of the szReaderName buffer. 
        ''' On output, receives the actual length (in characters) of the reader name list, 
        ''' including the trailing NULL character. If this buffer length is specified as SCARD_AUTOALLOCATE,
        '''  then szReaderName is converted to a pointer to a byte pointer, and it receives the 
        ''' address of a block of memory that contains the multiple-string structure.</param>
        ''' <param name="State">Current state of the smart card in the reader</param>
        ''' <param name="Protocol">Current protocol, if any. The returned value is meaningful only if the returned value of pdwState is SCARD_SPECIFICMODE.</param>
        ''' <param name="ATR">Pointer to a 32-byte buffer that receives the ATR string from the currently inserted card, if available.</param>
        ''' <param name="ATRLen">On input, supplies the length of the pbAtr buffer. 
        ''' On output, receives the number of bytes in the ATR string (32 bytes maximum). 
        ''' If this buffer length is specified as SCARD_AUTOALLOCATE, 
        ''' then pbAtr is converted to a pointer to a byte pointer, and it receives the address of a block of memory that contains the multiple-string structure.</param>
        ''' <returns>If the function successfully provides the current status of a smart card in a reader, the return value is SCARD_S_SUCCESS.
        ''' If the function fails, it returns an error code</returns>
        Private Declare Function SCardStatus Lib "WinScard.dll" Alias "SCardStatusA" ( _
                        ByVal hCard As IntPtr, _
                        ByVal szReaderName As String, _
                        ByRef pcchReaderLen As Integer, _
                        ByRef State As Integer, _
                        ByRef Protocol As Int32, _
                        ByVal ATR As Byte(), _
                        ByRef ATRLen As Integer _
    ) As IntPtr


        Private Declare Function SCardGetStatusChange Lib "WinScard.dll" Alias _
                           "SCardGetStatusChangeA" ( _
                        ByVal hContext As IntPtr, _
                        ByVal dwTimeOut As Integer, _
                        ByRef rgReaderStates As SCARD_READERSTATE, _
                        ByVal cReaders As Integer _
    ) As Integer

        ''' <summary>
        ''' The SCardReleaseContext function closes an established resource manager context, 
        ''' freeing any resources allocated under that context, including SCARDHANDLE objects 
        ''' and memory allocated using the SCARD_AUTOALLOCATE length designator.
        ''' </summary>
        ''' <param name="hContext">Handle that identifies the resource manager context. The resource manager context is set by a previous call to SCardEstablishContext.</param>
        ''' <returns>This function returns different values depending on whether it succeeds or fails.</returns>
        Private Declare Function SCardReleaseContext Lib "WinScard.dll" ( _
                            ByVal hContext As IntPtr _
    ) As Integer

        Private Declare Function SCardListCards Lib "WinScard.dll" Alias _
                           "SCardListCardsA" ( _
                    ByVal hContext As IntPtr, _
                    ByVal pbAtr As Byte(), _
                    ByVal rgguidInterfaces() As Integer, _
                    ByVal cguidInterfaceCount As Integer, _
                    ByRef mszCards As String, _
                    ByRef pcchCards As Integer _
            ) As Integer

        <DllImport("winscard.dll", CharSet:=CharSet.Auto)> _
        Private Shared Function SCardGetStatusChange(ByVal hContext As IntPtr, ByVal dwTimeout As Integer, <[In](), Out()> ByVal rgReaderStates As SCARD_READERSTATE(), ByVal cReaders As Integer) As Integer
        End Function



        ''' <summary>
        ''' The SCardConnect function establishes a connection (using a specific resource manager context)
        '''  between the calling application and a smart card contained by a specific reader. 
        ''' If no card exists in the specified reader, an error is returned.
        ''' </summary>
        ''' <param name="hContext">A handle that identifies the resource manager context. The resource manager context is set by a previous call to SCardEstablishContext.</param>
        ''' <param name="szReaderName">The name of the reader that contains the target card.</param>
        ''' <param name="dwShareMode">A flag that indicates whether other applications may form connections to the card</param>
        ''' <param name="dwPrefProtocol">A bitmask of acceptable protocols for the connection</param>
        ''' <param name="hCard">A handle that identifies the connection to the smart card in the designated reader.</param>
        ''' <param name="ActiveProtocol">A flag that indicates the established active protocol.</param>
        ''' <returns>This function returns different values depending on whether it succeeds or fails.</returns>
        Private Declare Function SCardConnect Lib "WinScard.dll" Alias "SCardConnectA" ( _
        ByVal hContext As IntPtr, _
        ByVal szReaderName As String, _
        ByVal dwShareMode As Integer, _
        ByVal dwPrefProtocol As Integer, _
        ByRef intptr As IntPtr, _
        ByRef ActiveProtocol As Integer _
    ) As Integer

        ' The context is a user context, and any database operations are performed
        ' within the domain of the user.
        Private Const SCARD_SCOPE_USER As Integer = 0

        ''' <summary>
        ''' SCARD_S_SUCCESS is returned if all went well.
        ''' </summary>
        Private Const SCARD_S_SUCCESS As Integer = 0

        ''' <summary>
        ''' This application will allow others to share the reader 
        ''' </summary>
        Private Const SCARD_SHARE_SHARED As Integer = 2

        ''' <summary>
        ''' card in the reader.  If this bit
        ''' is set, all the following bits
        ''' will be clear.
        ''' This implies that there is a card
        ''' </summary>
        ''' <remarks></remarks>
        Private Const SCARD_STATE_PRESENT As Integer = &H20 ' 

        Private Const SCARD_STATE_UNAWARE As Integer = 0

        ' T=0 is the active protocol.
        Private Const SCARD_PROTOCOL_T0 As Integer = &H1

        ' T=1 is the active protocol.
        Private Const SCARD_PROTOCOL_T1 As Integer = &H2

        ''' <summary>
        '''  This value implies the card has been
        ''' reset and specific communication
        ''' protocols have been established.
        ''' </summary>
        Private Const SCARD_SPECIFIC As Integer = 6

        Private Const SCARD_PROVIDER_CSP As Long = 2
        ''' <summary>
        ''' This method retrieves the connected reader list 
        ''' </summary>
        ''' <returns>The connected reader list </returns>
        Public Shared Function ListReaders() As List(Of String)
            'Dim m_nLastError As Integer
            Dim szListReaders As String
            Dim SmartcardContext As IntPtr
            szListReaders = "                                                                                                                                                                                                                                                                 "
            Dim Result As Integer            'result of smartcard functions
            Result = SCardEstablishContext(SCARD_SCOPE_USER, 0, 0, SmartcardContext)
            If Result <> SCARD_S_SUCCESS Then
                Logger.Instance.Error("Fail to load reader list, SCardEstablishContext failed")
                Return Nothing
            End If
            Result = SCardListReaders(SmartcardContext, Nothing, szListReaders, 255)

            If Result = SCARD_S_SUCCESS Then
                Dim asReaderList As New List(Of String)

                Dim asSep As New List(Of String)
                asSep.Add(vbNullChar)
                Dim asReaderListContainer() As String = szListReaders.Split(asSep.ToArray(), StringSplitOptions.None)

                For Each sReader As String In asReaderListContainer
                    If sReader.Trim().Length > 0 Then
                        asReaderList.Add(sReader)
                    End If
                Next
                ReleaseContext(SmartcardContext)
                Return asReaderList
            Else
                ReleaseContext(SmartcardContext)
                Logger.Instance.Error("Fail to load reader list, SCardTransmit failed")
                Return Nothing
            End If
        End Function

        Public Shared Function CheckIfOnlyCardInReader() As Boolean
            Dim asReaderList As List(Of String) = ListReaders()

            Dim asCardsInReader As New List(Of String)

            For Each sReaderName As String In asReaderList
                If isCardInReader(sReaderName) Then
                    asCardsInReader.Add(sReaderName)
                End If
            Next

            If asCardsInReader.Count <> 1 Then 'More then one card is in reader
                Return False
            End If

            Return True
        End Function
        ''' <summary>
        ''' This method checks if the card is connected to the smart card reader.
        ''' </summary>
        ''' <param name="p_sFriendlyName">The friendly name of the reader.</param>
        ''' <returns>True - if card is connected, false - otherwise.</returns>
        Public Shared Function isCardInReader(ByVal p_sFriendlyName As String) As Boolean
            Dim SmartcardContext As IntPtr
            Try
                Dim SmartcardHandle As IntPtr

                Dim SmartcardShareMode As Integer
                Dim SmartcardProtocol As Int32
                Dim SmartcardActiveProtocol As Integer
                Dim SmartcardStatus As Integer
                Dim result As Long
                Dim result1 As IntPtr

                result = SCardEstablishContext(SCARD_SCOPE_USER, 0, 0, SmartcardContext)
                If result <> SCARD_S_SUCCESS Then           'failed 
                    Logger.Instance.Error("Fail to check if card in reader, SCardEstablishContext failed")
                    Return False
                End If

                Dim AtrBuffer(32) As Byte 'New BytArray
                Dim AtrBufferLen As Integer
                Dim ReaderNameLen As Integer = 200
                result = 0                                  'init all values for SCARD functions
                AtrBufferLen = 32                         'length of buffer for receiving ATR
                SmartcardShareMode = SCARD_SHARE_SHARED     'card exclusivness mode
                SmartcardProtocol = SCARD_PROTOCOL_T0 Or SCARD_PROTOCOL_T1  'allow both T0 & T1

                'now try to connect to a card
                result = SCardConnect(SmartcardContext, p_sFriendlyName, SmartcardShareMode, SmartcardProtocol, _
                                       SmartcardHandle, SmartcardActiveProtocol)
                If result = SCARD_S_SUCCESS Then            'succeeded ---> get status
                    result1 = SCardStatus(SmartcardHandle, p_sFriendlyName, ReaderNameLen, SmartcardStatus, _
                                            SmartcardProtocol, AtrBuffer, AtrBufferLen)
                    If result = SCARD_S_SUCCESS Then        'succeeded ---> get card state
                        If SmartcardStatus = SCARD_SPECIFIC Then
                            ReleaseContext(SmartcardContext)
                            'card Status OK
                        Else
                            ReleaseContext(SmartcardContext)
                            Logger.Instance.Error("Fail to check if card in reader, SmartcardStatus failed")
                            Return False  'SmartcardStatus <> SCARD_SPECIFIC
                        End If

                    Else
                        ReleaseContext(SmartcardContext)
                        Logger.Instance.Error("Fail to check if card in reader, SCardStatus failed")
                        Return False  'SCardStatus failed
                    End If
                Else
                    ReleaseContext(SmartcardContext)
                    Logger.Instance.Error("Fail to check if card in reader, SCardConnect failed")
                    Return False 'SCardConnect failed
                    Exit Function
                End If
                ReleaseContext(SmartcardContext)
                Return True
            Catch
                ReleaseContext(SmartcardContext)
                Logger.Instance.Error("Fail to check if card in reader, SCardReleaseContext failed")
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method returns the card provider according to the readers name
        ''' </summary>
        ''' <returns>Dictinary containing the providers according to the reader name.</returns>
        Private Shared Function GetCardProviders() As Dictionary(Of String, List(Of String))
            Dim asProviderName As New Dictionary(Of String, List(Of String))

            For Each sReaderName As String In ListReaders()
                asProviderName.Add(sReaderName, New List(Of String))
            Next

            Dim asProvider As New List(Of String)
            For Each sReaderName As String In asProviderName.Keys
                If isCardInReader(sReaderName) Then

                    Dim sProvider As String = GetProviderNameByReader(sReaderName)
                    If sProvider.Length > 0 Then
                        asProvider.Add(sProvider)
                    End If
                End If
            Next
            Return asProviderName
        End Function

        Public Shared Sub Close()

            Dim SmartcardContext As Integer
            Dim Result As Integer            'result of smartcard functions

            Result = SCardEstablishContext(SCARD_SCOPE_USER, 0, 0, SmartcardContext)
            If Result <> SCARD_S_SUCCESS Then
                Logger.Instance.Error("Fail to load reader list, SCardEstablishContext failed")
                Return
            End If

            Result = SCardCancel(SmartcardContext)
            If Result <> SCARD_S_SUCCESS Then
                Logger.Instance.Error("Fail to load reader list, SCardCancel failed")
                Return
            End If

            If SmartcardContext <> Nothing Then
                SCardReleaseContext(SmartcardContext)
            End If
        End Sub
        Private Shared Function GetProviderNameByReader(ByVal p_sReaderName As String) As String
            Dim sProvider As String = String.Empty
            Dim SmartcardContext As Integer
            Dim Result As Integer            'result of smartcard functions
            Dim szListReaders As String = String.Empty

            Result = SCardEstablishContext(SCARD_SCOPE_USER, 0, 0, SmartcardContext)
            If Result <> SCARD_S_SUCCESS Then
                Logger.Instance.Error("Fail to load reader list, SCardEstablishContext failed")
                Return Nothing
            End If

            Dim oScardeadErstate As SCARD_READERSTATE = Nothing
            oScardeadErstate.szReader = p_sReaderName
            oScardeadErstate.dwCurrentState = SCARD_STATE_PRESENT
            Result = SCardGetStatusChange(SmartcardContext, 0, oScardeadErstate, 1)

            If Result <> SCARD_S_SUCCESS Then
                Logger.Instance.Error("Fail to GetProviderNameByReader, SCardGetStatusChange failed")
                Return Nothing
            End If
            Dim asList As New List(Of String)

            Dim SCARD_AUTOALLOCATE As Integer = -1

            'Result = SCardListCards(SmartcardContext, oScardeadErstate.rgbAtr, Nothing, Nothing, sProvider, SCARD_AUTOALLOCATE)
            Result = SCardListCards(Nothing, Nothing, Nothing, Nothing, sProvider, SCARD_AUTOALLOCATE)

            If Result <> SCARD_S_SUCCESS Then
                Logger.Instance.Error("Fail to GetProviderNameByReader, SCardGetStatusChange failed")
                Return Nothing
            End If


            If SmartcardContext <> Nothing Then
                SCardReleaseContext(SmartcardContext)
            End If

            Return sProvider
        End Function

#Region " Class ClearPinCode"
        Private Const CRYPT_VERIFYCONTEXT As Int32 = -268435456
        Private Const PP_KEYEXCHANGE_PIN As Int32 = 32
        Private Const PP_SIGNATURE_PIN As Int32 = 33

        Private Declare Function CryptAcquireCertificatePrivateKey Lib "Crypt32.dll" _
               (ByVal pCert As Integer, ByVal dwFlags As Integer, ByVal pReserved As Integer, ByRef hProv As Integer _
               , ByVal dwKeySpec As Integer, ByVal pfCallerFreeProv As Integer) As Integer

        ''' <summary>
        ''' The CryptAcquireContext function is used to acquire a handle to a particular key container within a particular cryptographic service provider (CSP). This returned handle is used in calls to CryptoAPI functions 
        ''' that use the selected CSP.
        ''' This function first attempts to find a CSP with the characteristics described in the dwProvType
        '''  and pszProvider parameters. If the CSP is found, the function attempts to find a key container within the 
        ''' CSP that matches the name specified by the pszContainer parameter. To acquire the context and the key container of
        '''  a private key associated with the public key of a certificate, use CryptAcquireCertificatePrivateKey.
        ''' With the appropriate setting of dwFlags, this function can also create and destroy key containers and can 
        ''' provide access to a CSP with a temporary key container if access to a private key is not required.
        ''' </summary>
        ''' <param name="phProv">A pointer to a handle of a CSP. When you have finished using the CSP, release the handle by calling the CryptReleaseContext function.</param>
        ''' <param name="szContainer">The key container name.</param>
        ''' <param name="szProvider">A null-terminated string that specifies the name of the CSP to be used. </param>
        ''' <param name="dwProvType">Specifies the type of provider to acquire. Defined provider types are discussed in Cryptographic Provider Types.</param>
        ''' <param name="dwFlags">Flag values.</param>
        ''' <returns>If the function succeeds, the function returns nonzero (TRUE).If the function fails, it returns zero (FALSE).</returns>
        <DllImport("Advapi32.dll", CharSet:=CharSet.Auto, SetLastError:=True)> _
        Private Shared Function CryptAcquireContext(ByRef phProv As IntPtr, <MarshalAs(UnmanagedType.LPTStr)> ByVal szContainer As String, <MarshalAs(UnmanagedType.LPTStr)> ByVal szProvider As String, ByVal dwProvType As UInteger, ByVal dwFlags As UInteger) As Boolean
        End Function

        ''' <summary>
        ''' The CryptSetProvParam function customizes the operations of a cryptographic service provider (CSP).
        '''  This function is commonly used to set a security descriptor
        '''  on the key container associated with a CSP to control access to the private keys in that key container.
        ''' </summary>
        ''' <param name="hProv">The handle of a CSP for which to set values. This handle must have already been created by using the CryptAcquireContext function.</param>
        ''' <param name="dwParam">Specifies the parameter to set</param>
        ''' <param name="pbData">A pointer to a data buffer that contains the value to be set as a provider parameter. The form of this data varies depending on the dwParam value. 
        ''' If dwParam contains PP_USE_HARDWARE_RNG, this parameter must be NULL.</param>
        ''' <param name="dwFlags">If dwParam contains PP_KEYSET_SEC_DESCR, dwFlags contains the SECURITY_INFORMATION applicable bit flags, as defined in the Platform SDK. 
        ''' Key-container security is handled by using SetFileSecurity and GetFileSecurity.
        ''' These bit flags can be combined by using a bitwise-OR operation. For more information, see CryptGetProvParam.
        ''' If dwParam is PP_USE_HARDWARE_RNG or PP_DELETEKEY, dwFlags must be set to zero.</param>
        ''' <returns>If the function succeeds, the return value is nonzero (TRUE).
        ''' If the function fails, the return value is zero (FALSE). </returns>
        <DllImport("advapi32.dll", SetLastError:=True)> _
        Private Shared Function CryptSetProvParam(ByVal hProv As IntPtr, ByVal dwParam As UInteger, ByVal pbData As Byte(), ByVal dwFlags As UInteger) As Boolean
        End Function

        ''' <summary>
        ''' The CryptReleaseContext function releases the handle of a cryptographic service provider (CSP) and a key container. 
        ''' At each call to this function, the reference count on the CSP is reduced by one.
        '''  When the reference count reaches zero, the context is fully released and it can no longer be used by any function in the application.
        ''' An application calls this function after finishing the use of the CSP. 
        ''' After this function is called, the released CSP handle is no longer valid. 
        ''' This function does not destroy key containers or key pairs.
        ''' </summary>
        ''' <param name="hProv">Handle of a cryptographic service provider (CSP) created by a call to CryptAcquireContext.</param>
        ''' <param name="dwFlags">Reserved for future use and must be zero. If dwFlags is not set to zero, this function returns FALSE but the CSP is released.</param>
        ''' <returns>If the function succeeds, the return value is nonzero (TRUE).
        ''' If the function fails, the return value is zero (FALSE). </returns>
        <DllImport("advapi32.dll")> _
        Private Shared Function CryptReleaseContext(ByVal hProv As IntPtr, ByVal dwFlags As UInteger) As Boolean
        End Function

        ''' <summary>
        ''' This method clears the pin code after each time user enters it.
        ''' </summary>
        ''' <param name="p_sContainer">The key container name.</param>
        ''' <param name="sProviderName">The handle of a CSP for which to set values. This handle must have already been created by using the CryptAcquireContext function.</param>
        ''' <returns>True - if the clear is successful, False - otherwise.</returns>
        Public Shared Function ClearPIN(ByVal p_sContainer As String, ByVal sProviderName As String) As Boolean
            Dim strProvider As String = sProviderName '"Apollo SCsquare CSP"
            Dim strContainer As String = "\\.\" + p_sContainer '"SCM Microsystems Inc. SCR33x USB Smart Card Reader 0"

            Dim h As IntPtr = IntPtr.Zero

            Try
                If (Not CryptAcquireContext(h, strContainer, strProvider, 1, &HF0000000L)) Then
                    Return False
                End If

                If (Not CryptSetProvParam(h, PP_KEYEXCHANGE_PIN, Nothing, 0)) Then
                    Return False
                End If
                Return True
            Catch ex As Exception
                Logger.Instance.Error(ex)
                Return False
            Finally
                CryptReleaseContext(h, 0)
            End Try
        End Function

        ''' <summary>
        ''' This method clears the pin code after each time user enters it.
        ''' </summary>
        ''' <returns>True - if the clear is successful, False - otherwise.</returns>
        Public Shared Function ClearPIN(ByVal cert As X509Certificate) As Boolean

            Dim h As IntPtr = IntPtr.Zero

            Try
                If CryptAcquireCertificatePrivateKey(cert.Handle, &H40, 0, h, 0, 0) Then
                    If (Not CryptSetProvParam(h, PP_KEYEXCHANGE_PIN, Nothing, 0)) Then
                        Return False
                    End If
                    Return True
                End If
                Return False
            Catch ex As Exception
                Logger.Instance.Error(ex)
                Return False
            Finally
                CryptReleaseContext(h, 0)
            End Try
        End Function


        ''' <summary>
        ''' This method clears all pin code from all the connected cards.
        ''' </summary>
        Public Shared Sub ClearAllCardsPinCode()
            Dim asReaders As List(Of String) = CardServices.ListReaders()
            For Each sReaderName As String In asReaders
                If CardServices.isCardInReader(sReaderName) Then
                    ClearPIN(sReaderName, GetProviderName())
                End If
            Next
        End Sub

#End Region

#Region "Reader services private methods"

        ''' <summary>
        ''' This method returns the card provider name from the connected card.
        ''' </summary>
        ''' <returns>If card is connected the provider name is returned, if more then one is connected empty strign is returned</returns>
        Private Shared Function GetProviderName() As String
            Dim sProviderNameas As String = String.Empty
            ' GetCardProviders()
            If File.Exists("C:\WINDOWS\system32\SC2CSP.dll") Then
                Dim oFileVersionInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo("C:\WINDOWS\system32\SC2CSP.dll")
                sProviderNameas = oFileVersionInfo.FileDescription
            Else
                sProviderNameas = "Apollo SCsquare CSP"
            End If
            Return sProviderNameas
        End Function
#End Region

        ''' <summary>
        ''' This method releases the SCard context
        ''' </summary>
        ''' <param name="SmartcardContext"></param>
        ''' <remarks></remarks>
        Private Shared Sub ReleaseContext(ByVal SmartcardContext As IntPtr)

            If SmartcardContext <> 0 Then
                SCardReleaseContext(SmartcardContext)
            End If

        End Sub

    End Class
End Namespace