Imports System.Xml

Namespace SignVerify.Profils
    Public Class XmlProfil
        Inherits Profil
#Region "Public methodes"


        'load profil from xml file
        Public Sub Load(ByVal filename As String)
            Try
                Dim xmlDoc As New XmlDocument
                xmlDoc.Load(filename)
                FriendlyName = getAttributeValue(xmlDoc, "FriendlyName", "value")
                ProviderName = getAttributeValue(xmlDoc, "ProviderName", "value")
                TimeStampURL = getAttributeValue(xmlDoc, "TimeStampURL", "value")
                Boolean.TryParse(getAttributeValue(xmlDoc, "ShowOnlyNonRepudiation", "value"), ShowOnlyNonRepudiation)
                SignAlgorithm = getAttributeValue(xmlDoc, "SignAlgorithm", "value")
                Boolean.TryParse(getAttributeValue(xmlDoc, "CheckTimeStamp", "value"), CheckTimeStamp)
                Boolean.TryParse(getAttributeValue(xmlDoc, "CheckCertificationPath", "value"), CheckCertificationPath)
                Boolean.TryParse(getAttributeValue(xmlDoc, "CheckCRL", "value"), CheckCRL)
                Boolean.TryParse(getAttributeValue(xmlDoc, "DisplayTimeStamp", "value"), DisplayTimeStamp)

                If hasNode(xmlDoc, "SavingType") Then
                    SavingType = [Enum].Parse(GetType(SavingTypes), getAttributeValue(xmlDoc, "SavingType", "value"), True)
                Else
                    SavingType = Nothing
                End If
                If ProviderName = "PDF crypto provider." Then
                    PdfParameters = New PdfParams
                    PdfParameters.Contact = getAttributeValue(xmlDoc, "PDFContact", "value")
                    PdfParameters.Text = getAttributeValue(xmlDoc, "PDFText", "value")
                    Boolean.TryParse(getAttributeValue(xmlDoc, "PDFIsVisible", "value"), PdfParameters.IsVisible)
                    PdfParameters.ImagePath = getAttributeValue(xmlDoc, "PDFImagePath", "value")
                    PdfParameters.Location = getAttributeValue(xmlDoc, "PDFLocation", "value")

                    PdfParameters.Reason = getAttributeValue(xmlDoc, "PDFReason", "value")
                    Boolean.TryParse(getAttributeValue(xmlDoc, "PDFUseDefaultImage", "value"), PdfParameters.UseDefaultImage)
                    Boolean.TryParse(getAttributeValue(xmlDoc, "PDFShowImage", "value"), PdfParameters.ShowImage)
                    Boolean.TryParse(getAttributeValue(xmlDoc, "PDFShowName", "value"), PdfParameters.ShowName)
                    If hasNode(xmlDoc, "PDFPosition") Then
                        PdfParameters.Position = [Enum].Parse(GetType(PositionTypes), getAttributeValue(xmlDoc, "PDFPosition", "value"), True)
                    Else
                        PdfParameters.Position = Nothing
                    End If
                End If
            Catch ex As Exception

            End Try

        End Sub


        'save profil to xml file
        Public Sub Save(ByVal filename As String)
            Dim xmlDoc As New XmlDocument
            Dim node As XmlNode
            Dim attValue As XmlAttribute

            'root 
            node = xmlDoc.CreateElement("root")
            xmlDoc.AppendChild(node)

            'FriendlyName
            node = xmlDoc.CreateElement("FriendlyName")
            attValue = xmlDoc.CreateAttribute("value")
            attValue.Value = FriendlyName
            node.Attributes.Append(attValue)
            xmlDoc.DocumentElement.AppendChild(node)

         
            'ProviderName
            node = xmlDoc.CreateElement("ProviderName")
            attValue = xmlDoc.CreateAttribute("value")
            attValue.Value = ProviderName
            node.Attributes.Append(attValue)
            xmlDoc.DocumentElement.AppendChild(node)

            'TimeStampURL
            node = xmlDoc.CreateElement("TimeStampURL")
            attValue = xmlDoc.CreateAttribute("value")
            attValue.Value = ProviderName
            node.Attributes.Append(attValue)
            xmlDoc.DocumentElement.AppendChild(node)

            'ShowOnlyNonRepudiation
            node = xmlDoc.CreateElement("ShowOnlyNonRepudiation")
            attValue = xmlDoc.CreateAttribute("value")
            attValue.Value = ShowOnlyNonRepudiation
            node.Attributes.Append(attValue)
            xmlDoc.DocumentElement.AppendChild(node)

            'SignAlgorithm
            node = xmlDoc.CreateElement("SignAlgorithm")
            attValue = xmlDoc.CreateAttribute("value")
            attValue.Value = SignAlgorithm
            node.Attributes.Append(attValue)
            xmlDoc.DocumentElement.AppendChild(node)

            'CheckTimeStamp
            node = xmlDoc.CreateElement("CheckTimeStamp")
            attValue = xmlDoc.CreateAttribute("value")
            attValue.Value = CheckTimeStamp
            node.Attributes.Append(attValue)
            xmlDoc.DocumentElement.AppendChild(node)

            'CheckCertificationPath
            node = xmlDoc.CreateElement("CheckCertificationPath")
            attValue = xmlDoc.CreateAttribute("value")
            attValue.Value = CheckCertificationPath
            node.Attributes.Append(attValue)
            xmlDoc.DocumentElement.AppendChild(node)

            'CheckCRL
            node = xmlDoc.CreateElement("CheckCRL")
            attValue = xmlDoc.CreateAttribute("value")
            attValue.Value = CheckCRL
            node.Attributes.Append(attValue)
            xmlDoc.DocumentElement.AppendChild(node)

            'DisplayTimeStamp
            node = xmlDoc.CreateElement("DisplayTimeStamp")
            attValue = xmlDoc.CreateAttribute("value")
            attValue.Value = DisplayTimeStamp
            node.Attributes.Append(attValue)
            xmlDoc.DocumentElement.AppendChild(node)



            If ProviderName = "PDF crypto provider." And PdfParameters IsNot Nothing Then

                'PDFIsVisible
                node = xmlDoc.CreateElement("PDFIsVisible")
                attValue = xmlDoc.CreateAttribute("value")
                attValue.Value = PdfParameters.IsVisible
                node.Attributes.Append(attValue)
                xmlDoc.DocumentElement.AppendChild(node)

                'PDFFieldName
                node = xmlDoc.CreateElement("PDFText")
                attValue = xmlDoc.CreateAttribute("value")
                attValue.Value = PdfParameters.Text
                node.Attributes.Append(attValue)
                xmlDoc.DocumentElement.AppendChild(node)

                'PDFContact
                node = xmlDoc.CreateElement("PDFContact")
                attValue = xmlDoc.CreateAttribute("value")
                attValue.Value = PdfParameters.Contact
                node.Attributes.Append(attValue)
                xmlDoc.DocumentElement.AppendChild(node)

                'PDFImagePath
                node = xmlDoc.CreateElement("PDFImagePath")
                attValue = xmlDoc.CreateAttribute("value")
                attValue.Value = PdfParameters.ImagePath
                node.Attributes.Append(attValue)
                xmlDoc.DocumentElement.AppendChild(node)

                'PDFLocation
                node = xmlDoc.CreateElement("PDFLocation")
                attValue = xmlDoc.CreateAttribute("value")
                attValue.Value = PdfParameters.Location
                node.Attributes.Append(attValue)
                xmlDoc.DocumentElement.AppendChild(node)

                'PDFPosition
                node = xmlDoc.CreateElement("PDFPosition")
                attValue = xmlDoc.CreateAttribute("value")
                attValue.Value = PdfParameters.Position
                node.Attributes.Append(attValue)
                xmlDoc.DocumentElement.AppendChild(node)

                'PDFReason
                node = xmlDoc.CreateElement("PDFReason")
                attValue = xmlDoc.CreateAttribute("value")
                attValue.Value = PdfParameters.Reason
                node.Attributes.Append(attValue)
                xmlDoc.DocumentElement.AppendChild(node)

                'PDFUseDefaultImage
                node = xmlDoc.CreateElement("PDFUseDefaultImage")
                attValue = xmlDoc.CreateAttribute("value")
                attValue.Value = PdfParameters.UseDefaultImage
                node.Attributes.Append(attValue)
                xmlDoc.DocumentElement.AppendChild(node)

                'PDFShowImage
                node = xmlDoc.CreateElement("PDFShowImage")
                attValue = xmlDoc.CreateAttribute("value")
                attValue.Value = PdfParameters.ShowImage
                node.Attributes.Append(attValue)
                xmlDoc.DocumentElement.AppendChild(node)
                'PDFShowImage
                node = xmlDoc.CreateElement("PDFShowName")
                attValue = xmlDoc.CreateAttribute("value")
                attValue.Value = PdfParameters.ShowName
                node.Attributes.Append(attValue)
                xmlDoc.DocumentElement.AppendChild(node)
            End If


            'save profil
            xmlDoc.Save(filename)

        End Sub

#End Region

#Region "Private methodes"

        'get attribute value
        Private Function getAttributeValue(ByVal xmldoc As XmlDocument, ByVal nodeName As String, ByVal attributeName As String) As String
            Try
                Dim node As XmlNode = xmldoc.DocumentElement.SelectSingleNode("//" & nodeName)
                If Not node Is Nothing AndAlso Not node.Attributes(attributeName) Is Nothing Then Return node.Attributes(attributeName).Value
                Return ""
            Catch ex As Exception
                Return ""
            End Try
        End Function

        'get attribute value
        Private Function hasNode(ByVal xmldoc As XmlDocument, ByVal nodeName As String) As Boolean

            Dim node As XmlNode = xmldoc.DocumentElement.SelectSingleNode("//" & nodeName)
            Return Not node Is Nothing

        End Function

#End Region
    End Class
End Namespace
