Imports System.Collections
Imports System
Imports ICSharpCode.SharpZipLib
Imports System.IO
Imports ICSharpCode.SharpZipLib.Zip
Imports ICSharpCode.SharpZipLib.Core
Imports System.Collections.Generic

Namespace SignVerify.Common.Utils
    Public Class ZipProvider
#Region "Events declarations"

        Public Delegate Sub FileZippedHandler(ByVal sender As Object, ByVal e As FileZippedEventArgs)
        Public Event FileZipped As FileZippedHandler

#End Region

#Region "Public methodes"

        Public Function extractFromPackage(signedObject As Byte()) As List(Of CryptoExtractedEntry)
            Dim retVal As New List(Of CryptoExtractedEntry)()
            Dim entry As CryptoExtractedEntry
            Dim ms As New MemoryStream(signedObject)
            Dim zipFile As New ZipFile(ms)
            For Each zipEntry As ZipEntry In zipFile
                Dim buffer As Byte() = New Byte(4095) {}
                Using streamWriter As New MemoryStream()
                    StreamUtils.Copy(zipFile.GetInputStream(zipEntry), streamWriter, buffer)
                    entry = New CryptoExtractedEntry(zipEntry.Name, streamWriter.ToArray())
                End Using
                retVal.Add(entry)
            Next
            Return retVal
        End Function

        Public Sub extractFiles(ByVal inputStream As MemoryStream, ByVal destination As String)
            Dim ZipInputStream As New ICSharpCode.SharpZipLib.Zip.ZipInputStream(inputStream)
            Dim zipEntry As ICSharpCode.SharpZipLib.Zip.ZipEntry = ZipInputStream.GetNextEntry()
            'Directory.CreateDirectory(destination)
            While zipEntry IsNot Nothing
                Dim buffer As Byte() = New Byte(4095) {}
                ' Dim data As Byte() = New Byte(Convert.ToInt32(ZipInputStream.Length)) {}
                'ZipInputStream.Read(data, 0, data.Length)
                'ZipInputStream.Write(bytes, DirectCast(zipEntry.Offset, Integer), DirectCast(zipEntry.Size, Integer))
                'File.WriteAllBytes(Path.Combine(destination, zipEntry.Name), data)
                Using streamWriter As FileStream = File.Create(Path.Combine(destination, zipEntry.Name))
                    StreamUtils.Copy(ZipInputStream, streamWriter, buffer)
                End Using
                zipEntry = ZipInputStream.GetNextEntry()
            End While
        End Sub

        Public Sub archivesFiles(ByVal outputStream As MemoryStream, ByVal filenames As ArrayList)
            Dim fileBytes As New ArrayList
            For Each elem As String In filenames
                fileBytes.Add(File.ReadAllBytes(elem))
            Next
            archivesFiles(outputStream, filenames, fileBytes)
        End Sub

        Public Sub archivesFiles(ByVal outputStream As MemoryStream, ByVal filenames As ArrayList, ByVal fileBytes As ArrayList)
            If fileBytes.Count <> filenames.Count Then
                Throw New ArgumentException("The filename arrays length different from filebytes array lenght.")
            End If

            Dim ZipOutputStream As New ICSharpCode.SharpZipLib.Zip.ZipOutputStream(outputStream)
            ZipOutputStream.SetLevel(3)
            For i As Integer = 0 To fileBytes.Count - 1
                Dim bytes As Byte() = CType(fileBytes(i), Byte())
                Dim zipEntry As New ICSharpCode.SharpZipLib.Zip.ZipEntry(Path.GetFileName(filenames(i).ToString))
                'zipEntry.Size = bytes.Length
                ZipOutputStream.PutNextEntry(zipEntry)
                ZipOutputStream.Write(bytes, 0, bytes.Length)

                RaiseEvent FileZipped(Me, New FileZippedEventArgs(filenames(i).ToString))

            Next


            If ZipOutputStream.Length > 0 Then
                'save the result file to the output memory stream
                ZipOutputStream.Finish()
            End If

        End Sub
#End Region



    End Class

    Public Class FileZippedEventArgs
        Inherits EventArgs

        Private _filepath As String
        Public Property Filepath() As String
            Get
                Return _filepath
            End Get
            Set(ByVal value As String)
                _filepath = value
            End Set
        End Property

        Public Sub New(ByVal filepath As String)
            Me.Filepath = filepath
        End Sub
    End Class
End Namespace