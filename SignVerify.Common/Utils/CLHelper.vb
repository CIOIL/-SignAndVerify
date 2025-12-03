Imports System
Imports System.IO



Namespace SignVerify.Common.Utils


    Public Module CLHelper

        Public Function GetParam(ByVal Args() As String, ByVal param As String) As String
            For i As Integer = 1 To Args.Length - 1
                If Args(i).StartsWith("-" + param) Then
                    If Args.Length >= i + 1 Then
                        i += 1
                        Return Args(i)
                    Else
                        Return String.Empty

                    End If
                End If
            Next
            Return String.Empty
        End Function

        Public Function IsFolder(path As String) As Boolean
            Dim uri__1 As Uri = Nothing
            Dim success As Boolean = Uri.TryCreate(path, UriKind.RelativeOrAbsolute, uri__1)
            If success Then
                If Not uri__1.IsAbsoluteUri Then
                    path = System.IO.Path.GetFullPath(path)
                    Uri.TryCreate(path, UriKind.RelativeOrAbsolute, uri__1)
                End If
            End If
            If uri__1.IsFile AndAlso (System.IO.File.Exists(path) OrElse System.IO.Directory.Exists(path)) Then
                If System.IO.File.GetAttributes(path).ToString().Contains(System.IO.FileAttributes.Directory.ToString()) Then
                    Return True
                Else
                    Return False
                End If
            End If
            Return False
        End Function

        Public Function IsUrl(path As String) As Boolean
            Dim uri__1 As Uri = Nothing
            Dim success As Boolean = Uri.TryCreate(path, UriKind.RelativeOrAbsolute, uri__1)
            If success Then
                If Not uri__1.IsAbsoluteUri Then
                    path = System.IO.Path.GetFullPath(path)
                    Uri.TryCreate(path, UriKind.RelativeOrAbsolute, uri__1)
                End If
            End If
            If uri__1.IsFile Then
                Return False
            Else
                Return True
            End If
            Return False
        End Function

        Public Function DownloadFile(Uri As String) As Byte()
            Dim bytes As Byte() = New Byte(-1) {}
            Dim webClient As New Net.WebClient()
            Try
                bytes = webClient.DownloadData(Uri)
            Catch ex As Net.WebException
                If ex.Status = Net.WebExceptionStatus.ProtocolError Then
                    webClient.UseDefaultCredentials = True
                    bytes = webClient.DownloadData(Uri)
                Else
                    Throw ex
                End If
            End Try
            Return bytes
        End Function


        Public Function UploadFile(filepath As String, content As Byte()) As String
            Dim request As Net.HttpWebRequest = DirectCast(Net.WebRequest.Create(filepath), Net.HttpWebRequest)
            request.Method = "POST"
            request.ContentLength = content.Length
            Dim requestStream As Stream = request.GetRequestStream()
            requestStream.Write(content, 0, content.Length)
            requestStream.Close()
            Dim response As Net.HttpWebResponse
            Try
                response = DirectCast(request.GetResponse(), Net.HttpWebResponse)
            Catch ex As Net.WebException
                If ex.Status = Net.WebExceptionStatus.ProtocolError Then
                    Dim requestCred As Net.HttpWebRequest = DirectCast(Net.WebRequest.Create(filepath), Net.HttpWebRequest)
                    requestCred.Method = "POST"
                    requestCred.ContentLength = content.Length
                    requestCred.UseDefaultCredentials = True
                    Dim requestStreamCred As Stream = requestCred.GetRequestStream()
                    requestStreamCred.Write(content, 0, content.Length)
                    requestStreamCred.Close()
                    response = DirectCast(request.GetResponse(), Net.HttpWebResponse)
                Else
                    Throw ex
                End If
            End Try
            If response.StatusCode = Net.HttpStatusCode.OK Then
                Dim objStreamReader As New StreamReader(response.GetResponseStream(), System.Text.Encoding.UTF8)
                Return objStreamReader.ReadToEnd()
            Else
                Throw New Exception(String.Format("Status {1} on sending signed file to destination {0}.", filepath, response.StatusDescription))
            End If

        End Function

        Public Function GetFileNameByUrl(file As String) As String
            Dim rgPattern = "[\\\/:\*\?""'<>|]"
            Dim objRegEx As New System.Text.RegularExpressions.Regex(rgPattern)
            Return objRegEx.Replace(file, "") + ".signed"
        End Function

        Function GetCosignType(Ags As String()) As CoSignType
            For i As Integer = 1 To Ags.Length - 1
                If Ags(i).StartsWith("-o") Then
                    Return CoSignType.OverSignature
                End If
            Next
            Return CoSignType.Parallel
        End Function

        Function IsQuietMoade(Ags As String()) As Boolean
            For i As Integer = 1 To Ags.Length - 1
                If Ags(i).Equals("-q") Then
                    Return True
                End If
            Next
            Return False
        End Function
        

    End Module

End Namespace
