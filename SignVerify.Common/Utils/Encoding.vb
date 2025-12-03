Imports System.Text
Imports System
Imports System.Collections.Generic

Namespace SignVerify.Common.Utils

    Public Class EncodingHelper

        'get default encoding if no one was specified (by bom value)
        Public Shared defaultEncoding As Encoding = Encoding.ASCII

        'get the encoding according to his bom (byte order marker) 
        Public Shared Function getEncoding(ByVal data As Byte()) As Encoding
            For Each encodingInfo As EncodingInfo In encoding.GetEncodings()
                Dim encoding As Encoding = encodingInfo.GetEncoding()
                Dim bom As Byte() = encoding.GetPreamble()
                If DataStartsWithBom(data, bom) Then
                    Return encoding
                End If
            Next encodingInfo
            Return Nothing
        End Function

        'remove the Bom bytes
        Public Shared Function removeBom(ByVal data As Byte()) As Byte()
            Dim enc As Encoding = getEncoding(data)
            Return removeBom(data, enc)
        End Function

        'remove the Bom bytes
        Public Shared Function removeBom(ByVal data As Byte(), ByVal enc As Encoding) As Byte()
            If Not enc Is Nothing AndAlso data.Length > enc.GetPreamble.Length Then
                Dim preambleLength As Integer = enc.GetPreamble.Length
                Dim result As New List(Of Byte)(data)
                result.RemoveRange(0, preambleLength)
                Return result.ToArray
            End If
            Return data
        End Function

        'this method convert the bytes array to base64 (for older version signed with capicom)
        Public Shared Function ConvertFromBase64(ByVal data() As Byte, Optional ByVal removeInvalidCharacters As Boolean = True) As Byte()


            'get the data encoding
            Dim enc As Encoding = getEncoding(data)
            If enc Is Nothing Then enc = defaultEncoding

            Dim result As New StringBuilder
            Dim dataAsChars() As Char = enc.GetChars(removeBom(data, enc))

            'remove the invalid characters
            If removeInvalidCharacters Then
                For Each elem As Char In dataAsChars
                    If Char.IsLetterOrDigit(elem) OrElse elem = "=" OrElse elem = "+" OrElse elem = "/" Then
                        result.Append(elem)
                    End If
                Next
            Else

                result.Append(dataAsChars)
            End If

            'fixe the string length
            While Not result.Length Mod 4 = 0
                result.Append("=")
            End While

            Return Convert.FromBase64String(result.ToString)

        End Function



        Private Shared Function DataStartsWithBom(ByVal data As Byte(), ByVal bom As Byte()) As Boolean
            Dim success As Boolean = data.Length >= bom.Length AndAlso bom.Length > 0
            Dim j As Integer = 0
            Do While success AndAlso j < bom.Length
                If data(j) = bom(j) Then success = True Else success = False
                j += 1
            Loop
            Return success
        End Function



    End Class

End Namespace