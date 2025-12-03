using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Xml;
using System.Security.Cryptography.Xml;
using System.IO;
using System.Security.Cryptography;

namespace SignVerify.Xades
{
    public static class XadesHelper
    {
        public static bool AddTSNode(DataObject xadesDataObject, XmlNode unsignedNode)
        {
            XmlElement dataObjectXmlElement = null;
            System.Security.Cryptography.Xml.DataObject  newXadesDataObject;
            XmlNamespaceManager xmlNamespaceManager;
            XmlNodeList qualifyingPropertiesXmlNodeList;
            XmlNodeList unsignedPropertiesXmlNodeList;

            //xadesDataObject = this.GetXadesDataObject();
            if (xadesDataObject != null)
            {
                dataObjectXmlElement = xadesDataObject.GetXml();
                xmlNamespaceManager = new XmlNamespaceManager(dataObjectXmlElement.OwnerDocument.NameTable);
                xmlNamespaceManager.AddNamespace("xsd", XadesSignedXml.XadesNamespaceUri);
                qualifyingPropertiesXmlNodeList = dataObjectXmlElement.SelectNodes("xsd:QualifyingProperties", xmlNamespaceManager);
                unsignedPropertiesXmlNodeList = dataObjectXmlElement.SelectNodes("xsd:QualifyingProperties/xsd:UnsignedProperties", xmlNamespaceManager);
                if (unsignedPropertiesXmlNodeList.Count != 0)
                {
                    qualifyingPropertiesXmlNodeList[0].RemoveChild(unsignedPropertiesXmlNodeList[0]);
                }
                qualifyingPropertiesXmlNodeList[0].AppendChild(dataObjectXmlElement.OwnerDocument.ImportNode(unsignedNode, true));

                newXadesDataObject = new DataObject();
                newXadesDataObject.LoadXml(dataObjectXmlElement);
                xadesDataObject.Data = newXadesDataObject.Data;
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool AddUnsignedProperties(DataObject xadesDataObject,UnsignedProperties uProperties)
        {
            XmlElement dataObjectXmlElement = null;
            System.Security.Cryptography.Xml.DataObject  newXadesDataObject;
            XmlNamespaceManager xmlNamespaceManager;
            XmlNodeList qualifyingPropertiesXmlNodeList;
            XmlNodeList unsignedPropertiesXmlNodeList;

            //xadesDataObject = this.GetXadesDataObject();
            if (xadesDataObject != null)
            {
                dataObjectXmlElement = xadesDataObject.GetXml();
                xmlNamespaceManager = new XmlNamespaceManager(dataObjectXmlElement.OwnerDocument.NameTable);
                xmlNamespaceManager.AddNamespace("xsd", XadesSignedXml.XadesNamespaceUri);
                qualifyingPropertiesXmlNodeList = dataObjectXmlElement.SelectNodes("xsd:QualifyingProperties", xmlNamespaceManager);
                unsignedPropertiesXmlNodeList = dataObjectXmlElement.SelectNodes("xsd:QualifyingProperties/xsd:UnsignedProperties", xmlNamespaceManager);
                if (unsignedPropertiesXmlNodeList.Count != 0)
                {
                    qualifyingPropertiesXmlNodeList[0].RemoveChild(unsignedPropertiesXmlNodeList[0]);
                }
                qualifyingPropertiesXmlNodeList[0].AppendChild(dataObjectXmlElement.OwnerDocument.ImportNode(uProperties.GetXml(), true));

                newXadesDataObject = new DataObject();
                newXadesDataObject.LoadXml(dataObjectXmlElement);
                xadesDataObject.Data = newXadesDataObject.Data;
                return true;
            }
            else
            {
                throw new CryptographicException("XAdES object not found. Use AddXadesObject() before accessing UnsignedProperties.");
            }
        }

         public static byte[] ComputeHashValueOfElementList(XmlElement signatureXmlElement, ArrayList elementXpaths, ref ArrayList elementIdValues,out byte[] originalMessage)
		{
			XmlDocument xmlDocument;
			XmlNamespaceManager xmlNamespaceManager;
			XmlNodeList searchXmlNodeList;
			XmlElement composedXmlElement;
			XmlDsigC14NTransform xmlDsigC14NTransform;
            MemoryStream canonicalizedStream;
			SHA1 sha1Managed;
			byte[] retVal;

			xmlDocument = signatureXmlElement.OwnerDocument;
			composedXmlElement = xmlDocument.CreateElement("ComposedElement", SignedXml.XmlDsigNamespaceUrl);
             
			xmlNamespaceManager = new XmlNamespaceManager(xmlDocument.NameTable);
			xmlNamespaceManager.AddNamespace("ds", SignedXml.XmlDsigNamespaceUrl);
			xmlNamespaceManager.AddNamespace("xsd", XadesSignedXml.XadesNamespaceUri);
			foreach (string elementXpath in elementXpaths)
			{
				searchXmlNodeList = signatureXmlElement.SelectNodes(elementXpath, xmlNamespaceManager);
				if (searchXmlNodeList.Count == 0)
				{
					throw new CryptographicException("Element " + elementXpath + " not found while calculating hash");
				}
				foreach (XmlNode xmlNode in searchXmlNodeList)
				{
					if (((XmlElement)xmlNode).HasAttribute("Id"))
					{
						elementIdValues.Add(((XmlElement)xmlNode).Attributes["Id"].Value);
						composedXmlElement.AppendChild(xmlNode);
					}
					else
					{
						throw new CryptographicException("Id attribute missing on " + xmlNode.LocalName + " element");
					}
				}
			}
			xmlDsigC14NTransform = new XmlDsigC14NTransform(false);
			xmlDsigC14NTransform.LoadInput(composedXmlElement.ChildNodes);
            canonicalizedStream = (MemoryStream)xmlDsigC14NTransform.GetOutput(typeof(MemoryStream));
            originalMessage = canonicalizedStream.ToArray();
			sha1Managed = new SHA1Managed();
			retVal = sha1Managed.ComputeHash(canonicalizedStream);
			canonicalizedStream.Close();

			return retVal;
		} 
	}
    

   
}
