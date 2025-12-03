Imports LipingShare.LCLib.Asn1Processor
Imports System
Imports System.IO
Imports System.Net

Namespace SignVerify.Common.TimeStamp
    Public Class TimeStampRequest

        Public Data() As Byte
        Public Nonce As Guid

        ''' <summary>
        ''' This method creates the request to the TSA server with the original hashed message.
        ''' </summary>
        ''' <param name="OriginalHashMessage">the original message (hashed) as byte array</param>
        ''' the response when no local clock is available. </param> 
        Public Sub New(ByVal OriginalHashMessage() As Byte)
            Me.New(OriginalHashMessage, Guid.NewGuid())
        End Sub

        ''' <summary>
        ''' This method creates the request to the TSA server with the original hashed message.
        ''' </summary>
        ''' <param name="OriginalHashMessage">the original message (hashed) as byte array</param>
        ''' <param name="Nonce"> The nonce, if included, allows the client to verify the timeliness of
        ''' the response when no local clock is available. </param> 
        Public Sub New(ByVal OriginalHashMessage() As Byte, ByVal Nonce As Guid)

            'The root asn node which contains the request
            Dim oTspRequest As Asn1Node = Utils.GetSequenceNode()

            'The version field 
            Dim oVersion As Asn1Node = Utils.GetVersionNode()

            'The messageImprint field 
            Dim oMessageImprint As Asn1Node = Utils.GetMessageImprintNode(OriginalHashMessage)

            'The nonce node
            Dim oNonce As Asn1Node = Utils.GetNonceNode(Nonce)

            'If the certReq field 
            Dim reqCert As Asn1Node = Utils.GetCertificateRequiredNode()

            'build the ASN1 tree in the correct order
            oTspRequest.AddChild(oVersion)
            oTspRequest.AddChild(oMessageImprint)
            oTspRequest.AddChild(oNonce)
            oTspRequest.AddChild(reqCert)

            Me.Data = Utils.GetBytes(oTspRequest)
            Me.Nonce = Nonce
        End Sub

        ''' <summary>
        ''' This method sends the request to the TSA server.
        '''    As the first message of this mechanism, the requesting entity
        ''' requests a time-stamp token by sending a request (which is or
        ''' includes a TimeStampReq, as defined below) to the Time Stamping
        ''' Authority.  As the second message, the Time Stamping Authority
        ''' responds by sending a response (which is or includes a TimeStampResp,
        ''' as defined below) to the requesting entity.
        ''' </summary>
        ''' <param name="Url">The time stamp authority URL</param>
        ''' <returns>Response as byte array.</returns>
        Public Function Send(ByVal Url As String) As Byte()

            'get the data to send
            'create the webRequest

            Try
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls

                Dim oMyReq As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create(Url)
                oMyReq.Method = "POST"
                oMyReq.ContentType = "application/timestamp-request"
                'oMyReq.SendChunked = True
                'oMyReq.TransferEncoding = "binary/octet-stream"
                oMyReq.ContentLength = Data.Length

                oMyReq.GetRequestStream.Write(Data, 0, Data.Length)

                'get the response
                Dim myRes As System.Net.WebResponse = oMyReq.GetResponse()


                Dim length As Integer = CType(myRes.ContentLength, Integer)
                Dim readed As Integer = 0
                Dim buffer(length - 1) As Byte

                While readed < length
                    readed += myRes.GetResponseStream().Read(buffer, readed, length - readed)
                End While

                myRes.Close()

                '  IO.File.WriteAllBytes("C:\test.dat", buffer)

                Return buffer
            Catch ex As Exception
                Return Nothing
            End Try
        End Function


        Public Function GetResponse(ByVal Url As String) As TimeStampResponse
            Return New TimeStampResponse(Send(Url))
        End Function
    End Class
End Namespace