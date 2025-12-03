Imports Microsoft.VisualBasic
Imports System.Security.Cryptography.X509Certificates
Imports System.Security.Cryptography.Pkcs
Imports System.Security.Cryptography
Imports System

Public Class sample
    Public Function Sign(ByVal objectToSign As Byte(), ByVal certificate As X509Certificate2) As Byte()

        If (Not certificate.HasPrivateKey) Then
            Throw New ApplicationException("Certificate does not contain private key and can not be used for signing")
        End If

        'create new cmsSigner with the given certificate
        Dim signer As CmsSigner = New CmsSigner(certificate)

        'choose the certificates to add into signatures( intermediate, ca..)
        signer.IncludeOption = X509IncludeOption.EndCertOnly

        'Create ContentInfo object and put the data to sign into it
        Dim info As ContentInfo = New ContentInfo(objectToSign)

        'fill the SignedCms with the ContentInfo
        Dim cms As SignedCms = New SignedCms(info)

        'sign the file 
        cms.ComputeSignature(signer, False)

        'verify the signed content
        cms.CheckSignature(True)

        'create the CryptoSignedObject
        Return cms.ContentInfo.Content

    End Function

    Public Shared Function GetSignCertificate() As X509Certificate2

        'Set the store we want to use ( My , current user)
        Dim store As X509Store = New X509Store("My", StoreLocation.CurrentUser)
        store.Open(System.Security.Cryptography.X509Certificates.OpenFlags.OpenExistingOnly)

        'get form the selected store all certificates with private key
        Dim coll As New X509Certificate2Collection
        For Each cert As X509Certificate2 In store.Certificates
            If cert.HasPrivateKey Then coll.Add(cert)
        Next

        'if the certificate collection contains more than one certificate , display the "choose cert diag", else return the certificate
        If coll.Count > 1 Then

            Return X509Certificate2UI.SelectFromCollection(coll, "Select certificate for signing", "Available certificates", X509SelectionFlag.SingleSelection)(0)

        ElseIf coll.Count = 1 Then
            Return coll(0)

        ElseIf coll.Count = 0 Then
            Return Nothing
        End If

        Return Nothing
    End Function

End Class
