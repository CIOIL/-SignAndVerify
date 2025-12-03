Imports System.Xml
Imports System.IO
Namespace SignVerify.Common.Utils
    Public Module XmlHelper
        Public Function LoadXmlFromFile(filePath As String) As XmlDocument
            Dim reader As XmlTextReader = New XmlTextReader(New StreamReader(filePath))
            Return LoadXmlFromReader(reader)
        End Function

        Public Function LoadXmlFromString(xmlString As String) As XmlDocument
            Dim reader As XmlTextReader = New XmlTextReader(New StringReader(xmlString))
            Return LoadXmlFromReader(reader)
        End Function

        Public Function LoadXmlFromBytes(xmlBytes As Byte()) As XmlDocument
            Dim reader As XmlTextReader = New XmlTextReader(New MemoryStream(xmlBytes))
            Return LoadXmlFromReader(reader)
        End Function

        Public Function LoadXmlFromReader(reader As XmlTextReader) As XmlDocument
            reader.ProhibitDtd = True
            Dim document As XmlDocument = New XmlDocument()
            document.PreserveWhitespace = True
            document.Load(reader)
            Return document
        End Function

    End Module
End Namespace
