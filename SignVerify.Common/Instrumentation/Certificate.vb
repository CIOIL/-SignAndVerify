Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Security.Cryptography.X509Certificates
Imports System.Runtime.InteropServices
Imports System.Threading

Namespace SignVerify.Common
    ''' <summary>
    ''' Certificates enable users to provide enhanced security in communications by <br />
    ''' providing a common credential to verify identity.
    ''' This certificate is signed with a private key that uniquely and positively <br />
    ''' identifies the holder of the certificate.
    ''' </summary>
    ''' 

    Public Class Certificate

#Region "Constructor"

        ''' <summary>
        ''' Initializes a new instance of the Certificate class.
        ''' </summary>
        Private Sub New()

        End Sub

#End Region

#Region "Get certificate methodes"


        ''' <summary>
        ''' This method returns the defined collection that stores X509Certificate objects 
        ''' according to certificate store name.
        ''' </summary>
        ''' <param name="certificateStoreName">The certificate store name.</param>
        '''<param name="ShowOnlyNonRepudiation">True - displays only non repudiation certificates</param>
        ''' <returns>The defined collection that stores X509Certificate objects</returns>
        Public Shared Function GetSignCertificateCollection(ByVal certificateStoreName As StoreName, ByVal ShowOnlyNonRepudiation As Boolean) As X509Certificate2Collection
            Dim store As X509Store = New X509Store(certificateStoreName, StoreLocation.CurrentUser)

            store.Open(System.Security.Cryptography.X509Certificates.OpenFlags.OpenExistingOnly)
            Dim result As New X509Certificate2Collection
            For Each cert As X509Certificate2 In store.Certificates
                If cert.HasPrivateKey Then result.Add(cert)
            Next

            If Not result Is Nothing AndAlso result.Count > 0 AndAlso ShowOnlyNonRepudiation Then
                result = FilterCertificateByNonRepudiation(result)
            End If

            Return result
        End Function

        ''' <summary>
        ''' This method returns the defined collection that stores X509Certificate objects 
        ''' </summary>
        '''<param name="ShowOnlyNonRepudiation">True - displays only non repudiation certificates</param>
        ''' <returns>The defined collection that stores X509Certificate objects</returns>
        Public Shared Function GetSignCertificateCollection(ByVal ShowOnlyNonRepudiation As Boolean) As X509Certificate2Collection
            Return GetSignCertificateCollection(StoreName.My, ShowOnlyNonRepudiation)
        End Function


        ''' <summary>
        ''' This method returns the defined certificate according to certificate store name.
        ''' </summary>
        ''' <param name="showUserInterface">True - Displays a dialog box for selecting a certificate from a certificate collection, false otherwise.</param>
        ''' <param name="ShowOnlyNonRepudiation">True - displays only non repudiation certificates</param>
        ''' <param name="certificateStoreName">The name of the principal to which the certificate was issued</param>
        ''' <returns><see cref="System.Security.Cryptography.X509Certificates.X509Certificate2">X509Certificate2</see> </returns>
        Public Shared Function GetSignCertificate(ByVal showUserInterface As Boolean, ByVal ShowOnlyNonRepudiation As Boolean, ByVal certificateStoreName As StoreName) As X509Certificate2
            Dim coll As X509Certificate2Collection = GetSignCertificateCollection(certificateStoreName, ShowOnlyNonRepudiation)
            Dim result As X509Certificate2Collection
            If coll.Count > 1 AndAlso showUserInterface Then

                result = X509Certificate2UI.SelectFromCollection(coll, "Select certificate for signing", "Available certificates", X509SelectionFlag.SingleSelection)

                If result.Count = 0 Then Return Nothing
                Return result(0)
            ElseIf (coll.Count > 1 AndAlso (Not showUserInterface)) OrElse coll.Count = 1 Then
                Return coll(0)
            End If
            Return Nothing
        End Function

        Public Shared Function GetSignCertificateBySerialNumber(ByVal SerialNumber As String, ByVal ShowOnlyNonRepudiation As Boolean) As X509Certificate2
            Dim coll As X509Certificate2Collection = GetSignCertificateCollection(StoreName.My, ShowOnlyNonRepudiation)
            Dim result As X509Certificate2Collection = coll.Find(X509FindType.FindBySerialNumber, SerialNumber, False)
            If result.Count >= 1 Then
                Return result(0)
            End If
            Return Nothing
        End Function

        ''' <summary>
        ''' This method shows the card details
        ''' </summary>
        Public Shared Function GetMySignCertificateDetails(ByVal ShowOnlyNonRepudiation As Boolean) As Boolean
            Dim Certificate As X509Certificate2 = GetCerteficateInReader()

            If Not Certificate Is Nothing Then
                X509Certificate2UI.DisplayCertificate(GetSignCertificate(False, ShowOnlyNonRepudiation, StoreName.My))
                Return True
            Else
                Return False
            End If
        End Function

        ''' <summary>
        ''' display certeficate details.
        ''' </summary>
        ''' <param name="p_oCert">The certeficate object.</param>
        Public Shared Function DisplayCertificate(ByVal p_oCert As X509Certificate2) As Boolean
            If Not p_oCert Is Nothing Then
                X509Certificate2UI.DisplayCertificate(p_oCert)
                Return True
            Else
                Return False
            End If
        End Function


        ''' <summary>
        ''' This method shows the selected certeficate
        ''' </summary>
        Public Shared Function showSelectedCertificate(ByVal SerialNumber As String) As Boolean
            Dim oCert As X509Certificate2 = GetSignCertificateBySerialNumber(SerialNumber, False)
            If Not oCert Is Nothing Then
                X509Certificate2UI.DisplayCertificate(oCert)
                Return True
            Else
                Return False
            End If
        End Function
        ''' <summary>
        ''' This method returns the sign certificate which stored for personal certificates.
        ''' </summary>
        ''' <param name="showUserInterface">True - Displays a dialog box for selecting a certificate from a certificate collection, false otherwise.</param>
        ''' <returns><see cref="System.Security.Cryptography.X509Certificates.X509Certificate2">X509Certificate2</see> </returns>
        Public Shared Function GetSignCertificate(ByVal showUserInterface As Boolean, ByVal ShowOnlyNonRepudiation As Boolean) As X509Certificate2
            Return GetSignCertificate(showUserInterface, ShowOnlyNonRepudiation, StoreName.My)
        End Function
        ''' <summary>
        ''' This method returns the sign certificate according to the certificate name 
        ''' (name of the principal to which the certificate was issued) and the <see cref=" System.Security.Cryptography.X509Certificates.StoreName">StoreName</see> type.
        ''' </summary>
        ''' <param name="CertificatName">name of the principal to which the certificate was issued.</param>
        ''' <param name="certificateStoreName">Specifies the name of the certificate store to open.<seealso cref=" System.Security.Cryptography.X509Certificates.StoreName"/></param>
        ''' <param name="ShowOnlyNonRepudiation">True - Displays a dialog box for selecting a certificate from a certificate collection, false otherwise.</param>
        ''' <returns><see cref="System.Security.Cryptography.X509Certificates.X509Certificate2">X509Certificate2</see></returns>
        Public Shared Function getSignCertificateByName(ByVal CertificatName As String, ByVal certificateStoreName As StoreName, ByVal ShowOnlyNonRepudiation As Boolean) As X509Certificate2
            Dim coll As X509Certificate2Collection = GetSignCertificateCollection(certificateStoreName, ShowOnlyNonRepudiation)
            For Each cert As X509Certificate2 In coll
                If getSignCertificateName(cert) = CertificatName Then
                    Return cert
                End If
            Next cert
            Return Nothing
        End Function

        ''' <summary>
        ''' This method returns the sign certificate according to the certificate name 
        ''' (name of the principal to which the certificate was issued).
        '''  And the <see cref=" System.Security.Cryptography.X509Certificates.StoreName">StoreName</see> Me - which indicate certificate store for personal certificates.
        ''' </summary>
        ''' <param name="ShowOnlyNonRepudiation">True - Displays a dialog box for selecting a certificate from a certificate collection, false otherwise.</param>
        ''' <param name="CertificatName">name of the principal to which the certificate was issued.</param>
        ''' <returns><see cref="System.Security.Cryptography.X509Certificates.X509Certificate2">X509Certificate2</see></returns>
        Public Shared Function getSignCertificateByName(ByVal CertificatName As String, ByVal ShowOnlyNonRepudiation As Boolean) As X509Certificate2
            Return getSignCertificateByName(CertificatName, StoreName.My, ShowOnlyNonRepudiation)
        End Function

        ''' <summary>
        ''' This method returns the subject distinguished name from the certificate. 
        ''' if the certeficate is nothing return Empty String.
        ''' </summary>
        ''' <param name="certificate"><see cref="System.Security.Cryptography.X509Certificates.X509Certificate2">X509Certificate2</see> data.</param>
        ''' <returns>The distinguished name from the certificate.</returns>
        Public Shared Function getSignCertificateName(ByVal certificate As X509Certificate2) As String
            If certificate Is Nothing Then Return ""
            For Each obj As String In certificate.Subject.Split(",")
                If obj.Trim.StartsWith("CN") Then
                    Return obj.Split("=")(1)
                End If
            Next
            Return ""
        End Function

        ''' <summary>
        ''' This method returns the name of the certificate authority that issued the certificate. 
        ''' if the certeficate is nothing returns Empty String.
        ''' </summary>
        ''' <param name="certificate"><see cref="System.Security.Cryptography.X509Certificates.X509Certificate2">X509Certificate2</see> data.</param>
        ''' <returns>The name of the certificate authority that issued the certificate.</returns>
        Public Shared Function getIssuerName(ByVal certificate As X509Certificate2) As String
            If certificate Is Nothing Then Return ""
            For Each obj As String In certificate.Issuer.Split(",")
                If obj.Trim.StartsWith("CN") Then
                    Return obj.Split("=")(1)
                End If
            Next
            Return ""
        End Function
        ''' <summary>
        ''' This method returns the certeficate in the reader.
        ''' </summary>
        ''' <param name="showSelectCertificateDialog">True - Displays a dialog box for selecting a certificate from a certificate collection, False - The first certificate in the store is returned.</param>
        ''' <returns>The certeficate in the reader, if more then 1 reader is connected then nothing is returned.</returns>
        Public Shared Function GetCerteficateInReader(ByVal showSelectCertificateDialog As Boolean) As X509Certificate2
            Dim asReaders As List(Of String) = CardServices.ListReaders()
            If asReaders Is Nothing Then
                Logger.Instance.Warn("No reader is connected.")
                Return Nothing
            End If
            Dim iCountCards As Integer = 0
            Dim sReaderConnected As String = String.Empty
            Logger.Instance.Warn("Number of readers:" & asReaders.Count)

            For Each sReaderName As String In asReaders
                Logger.Instance.Warn("Reader Name:" & sReaderName)
                If CardServices.isCardInReader(sReaderName) Then
                    Logger.Instance.Warn("Card in Reader Name:" & sReaderName)
                    iCountCards += 1
                    sReaderConnected = sReaderName
                End If
            Next

            If iCountCards <> 1 Then
                Logger.Instance.Warn("More then 1 card is in  reader.")
                Return Nothing
            End If
            If Not CardServices.isCardInReader(sReaderConnected) Then
                Logger.Instance.Warn("No card in reader.")
                Return Nothing
            End If
            Dim oCertificate As X509Certificate2 = GetSignCertificate(showSelectCertificateDialog, False, StoreName.My)
            Return oCertificate
        End Function

        Public Shared Event Card_In()
        Public Shared Event Card_Out()

        Private Shared Sub ThreadTask()
            Dim rnd As New Random()
            Dim prevCert As X509Certificate2 = GetCerteficateInReader(False)
            Do
                Dim oCert As X509Certificate2 = GetCerteficateInReader(False)
                If Not Object.Equals(prevCert, oCert) Then
                    If oCert Is Nothing Then
                        RaiseEvent Card_Out()
                    Else
                        RaiseEvent Card_In()
                    End If
                    trd.Abort()
                End If
                Thread.Sleep(100)
            Loop
        End Sub

        Private Shared trd As System.Threading.Thread
        ''' <summary>
        ''' This method raises events of inserting and removing card from the reader.
        ''' The names of reised events: Card_In and Card_Out.
        ''' 
        ''' </summary>
        ''' <example> Code example in C# how to handle these events:  
        ''' <code> 
        ''' // In initialaze method:
        ''' Certificate.Card_In += new Certificate.Card_InEventHandler(Certificate_Card_In);
        ''' Certificate.Card_Out += new Certificate.Card_OutEventHandler(Certificate_Card_Out);
        ''' Certificate.ListenToCardInReader();
        ''' 
        ''' // Implementation of funcions that declared as handlers of events        
        ''' void Certificate_Card_Out()
        ''' {
        '''     this.SetText("Card out");
        ''' }
        ''' 
        ''' void Certificate_Card_In()
        ''' {
        '''     this.SetText("Card insert");
        ''' }
        ''' 
        ''' delegate void SetTextCallback(string text);
        ''' public void SetText(string text)
        ''' {
        '''     if (this.lblCardStatus.InvokeRequired)
        '''     {
        '''         SetTextCallback d = new SetTextCallback(SetText);
        '''         this.Invoke(d, new object[] { text });
        '''     }
        '''     else
        '''     {
        '''         this.lblCardStatus.Text = text;
        '''     }
        ''' }
        ''' </code> 
        ''' </example> 

        Public Shared Sub ListenToCardInReader()
            If trd Is Nothing OrElse Not trd.IsAlive Then
                trd = New Thread(AddressOf ThreadTask)
                trd.IsBackground = True
                trd.Start()
            End If
        End Sub

        ''' <summary>
        ''' This method returns the certeficate in the reader.
        ''' </summary>
        ''' <returns>The certeficate in the reader, if more then 1 reader is connected then nothing is returned.</returns>
        Public Shared Function GetCerteficateInReader() As X509Certificate2
            Dim asReaders As List(Of String) = CardServices.ListReaders()
            If asReaders Is Nothing Then
                Logger.Instance.Warn("No reader is connected.")
                Return Nothing
            End If
            Dim iCountCards As Integer = 0
            Dim sReaderConnected As String = String.Empty
            Logger.Instance.Warn("Number of readers:" & asReaders.Count)

            For Each sReaderName As String In asReaders
                Logger.Instance.Warn("Reader Name:" & sReaderName)
                If CardServices.isCardInReader(sReaderName) Then
                    Logger.Instance.Warn("Card in Reader Name:" & sReaderName)
                    iCountCards += 1
                    sReaderConnected = sReaderName
                End If
            Next

            If iCountCards <> 1 Then
                Logger.Instance.Warn("More then 1 card is in  reader.")
                Return Nothing
            End If
            If Not CardServices.isCardInReader(sReaderConnected) Then
                Logger.Instance.Warn("No card in reader.")
                Return Nothing
            End If
            Dim oCertificate As X509Certificate2 = GetSignCertificate(True, False, StoreName.My)
            Return oCertificate
        End Function

#Region "Private"

        ''' <summary>
        ''' This method filter by out the  repudiation certificate and leave the 
        '''  non repudiation certificates.
        ''' </summary>
        ''' <param name="CertificateCollection">The orignal user certificate collection.</param>
        ''' <returns>The filter certificate collection</returns>
        Private Shared Function FilterCertificateByNonRepudiation(ByVal CertificateCollection As X509Certificate2Collection) As X509Certificate2Collection
            Return CertificateCollection.Find(X509FindType.FindByKeyUsage, X509KeyUsageFlags.NonRepudiation, True)
        End Function

        ''' <summary>
        ''' This method filter by specific CA the user certificates
        ''' </summary>
        ''' <param name="CertificateCollection">The certificate collection to check</param>
        ''' <returns>The certificate collection after filtering CA.</returns>
        Private Function FilterCertificateByCA(ByVal CertificateCollection As X509Certificate2Collection) As X509Certificate2Collection

            Dim X509Certificate2CollectionClearByCA As New X509Certificate2Collection()
            Dim asCANames As List(Of String) = GetCACertificateName()

            For Each cert As X509Certificate2 In CertificateCollection
                If asCANames.Contains(getIssuerName(cert)) Then
                    X509Certificate2CollectionClearByCA.Add(cert)
                End If
            Next cert
            Return X509Certificate2CollectionClearByCA
        End Function

        ''' <summary>
        ''' This method loads all CA certificates.
        ''' </summary>
        ''' <returns>The issuer names in string array</returns>
        Private Function GetCACertificateName() As List(Of String)
            Dim store As X509Store = New X509Store(StoreName.CertificateAuthority, StoreLocation.CurrentUser)

            store.Open(System.Security.Cryptography.X509Certificates.OpenFlags.OpenExistingOnly)
            Dim asCANames As New List(Of String)
            For Each cert As X509Certificate2 In store.Certificates
                If Not asCANames.Contains(cert.Issuer) Then
                    asCANames.Add(cert.Issuer)
                End If
            Next
            Return asCANames
        End Function
#End Region

#End Region

#Region "Verify certificate methodes"

        ''' <summary>
        ''' This method returns the status of a end certificate state according to the
        ''' certificate data.
        ''' </summary>
        ''' <param name="certificate"><see cref="System.Security.Cryptography.X509Certificates.X509Certificate2">X509Certificate2</see> data.</param>
        ''' <returns><see cref="EndSignatureStateType">End signature state type</see> which defines the end certificate state.</returns>
        Public Shared Function getEndCertificateState(ByVal certificate As X509Certificate2) As EndSignatureStateType

            'set default options ( not check CRL )
            Dim ch As New X509Chain()
            ch.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck
            ch.ChainPolicy.VerificationFlags = X509VerificationFlags.NoFlag
            ch.ChainPolicy.VerificationFlags = X509VerificationFlags.AllowUnknownCertificateAuthority

            'build chain
            ch.Build(certificate)

            'get the chain status and return it if it's an error 
            For Each ele As X509ChainStatus In ch.ChainStatus
                Select Case ele.Status
                    Case X509ChainStatusFlags.NoError
                        Return EndSignatureStateType.Valid

                    Case X509ChainStatusFlags.NotSignatureValid
                        Return EndSignatureStateType.SignatureUnvalid

                    Case X509ChainStatusFlags.NotTimeValid
                        Return EndSignatureStateType.CertificateExpired

                    Case X509ChainStatusFlags.UntrustedRoot
                        Return EndSignatureStateType.Valid

                    Case X509ChainStatusFlags.PartialChain
                        Return EndSignatureStateType.Valid
                End Select

            Next

            'return the valid state
            Return EndSignatureStateType.Valid

        End Function

        ''' <summary>
        ''' This method returns the validity (status) of the certificate chain according to the
        ''' certificate data.<br />
        ''' Unvalid chain can occur due to invalid  an untrusted root certificate or
        ''' due to fact that the chain could not be built up to the root certificate,
        ''' Otherwise the cerificate chain is valid.
        ''' <seealso cref=" System.Security.Cryptography.X509Certificates.X509ChainStatusFlags"/>
        ''' </summary>
        ''' <param name="certificate"><see cref="System.Security.Cryptography.X509Certificates.X509Certificate2">X509Certificate2</see> data.</param>
        ''' <returns><see cref="ChainSignatureStateType">chain signature state type</see>.</returns>
        Public Shared Function getCertificateChainState(ByVal certificate As X509Certificate2) As ChainSignatureStateType

            'set default options ( not check CRL )
            Dim ch As New X509Chain()
            ch.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck
            ch.ChainPolicy.VerificationFlags = X509VerificationFlags.NoFlag


            'build chain
            ch.Build(certificate)

            'get the chain status and return it if it's an error 
            For Each ele As X509ChainStatus In ch.ChainStatus
                Select Case ele.Status
                    Case X509ChainStatusFlags.NoError
                        Return ChainSignatureStateType.Valid

                    Case X509ChainStatusFlags.UntrustedRoot
                        Return ChainSignatureStateType.Unvalid

                    Case X509ChainStatusFlags.PartialChain
                        Return ChainSignatureStateType.Unvalid


                End Select

            Next

            'return the valid state
            Return ChainSignatureStateType.Valid

        End Function

        'verify the CRL state
        ''' <summary>
        ''' This method returns the validity of the certificate CRL state according to the
        ''' certificate data and verify parameters<br />
        ''' Revoked - can occur due to a revoked certificate (if CheckTrustChain is selected all the cahin is checked)<br />
        ''' Unknown - can occur due to fact that the revocation can no be determined (if CheckTrustChain is selected all the cahin is checked)<br />
        ''' Otherwise the cerificate CRL is valid.<br />
        ''' <seealso cref=" System.Security.Cryptography.X509Certificates.X509RevocationMode"/>
        ''' <seealso cref=" System.Security.Cryptography.X509Certificates.X509ChainStatusFlags"/>
        ''' </summary>
        ''' <param name="certificate"><see cref="System.Security.Cryptography.X509Certificates.X509Certificate2">X509Certificate2</see> data.</param>
        ''' <param name="verifyParameters"><see cref="VerifyParameters">Verify Parameters</see></param>
        ''' <returns><see cref="CRLSignatureStateType">CRL signature state type</see>.</returns>
        Public Shared Function getCertificateCRLState(ByVal certificate As X509Certificate2, ByVal verifyParameters As VerifyParameters) As CRLSignatureStateType

            'if we don't want to check CRL return UNCHECKED state
            If Not verifyParameters.checkCRL Then
                Return CRLSignatureStateType.Unchecked
            End If

            'set the Revocation mode to ONLINE
            Dim ch As New X509Chain()
            ch.ChainPolicy.RevocationMode = X509RevocationMode.Online
            If Not verifyParameters.CheckTrustChain Then
                ch.ChainPolicy.RevocationFlag = X509RevocationFlag.EndCertificateOnly
            Else
                ch.ChainPolicy.RevocationFlag = X509RevocationFlag.ExcludeRoot
            End If
            ch.ChainPolicy.UrlRetrievalTimeout = TimeSpan.FromSeconds(5)

            'build the chain
            ch.Build(certificate)

            'get the chain status and return it if it's an error 
            For Each ele As X509ChainStatus In ch.ChainStatus
                If ele.Status = X509ChainStatusFlags.NoError Then
                    Return CRLSignatureStateType.Valid
                ElseIf ele.Status = X509ChainStatusFlags.RevocationStatusUnknown Then
                    Return CRLSignatureStateType.Unknown
                ElseIf ele.Status = X509ChainStatusFlags.Revoked Then
                    Return CRLSignatureStateType.Revoked
                End If
            Next

            'return the valid state
            Return CRLSignatureStateType.Valid
        End Function

        Public Shared Function getCertificateCRLState(ByVal certificate As X509Certificate2) As CRLSignatureStateType
            Dim params As New VerifyParameters
            params.checkCRL = True
            Return getCertificateCRLState(certificate, params)
        End Function

#End Region

    End Class

End Namespace
