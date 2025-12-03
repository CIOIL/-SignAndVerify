// XadesSignedXml.cs
//
// XAdES Starter Kit for Microsoft .NET 3.5 (and above)
// 2010 Microsoft France
// Published under the CECILL-B Free Software license agreement.
// (http://www.cecill.info/licences/Licence_CeCILL-B_V1-en.txt)
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// WHETHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
// THE ENTIRE RISK OF USE OR RESULTS IN CONNECTION WITH THE USE OF THIS CODE 
// AND INFORMATION REMAINS WITH THE USER. 
//

using System;
using System.IO;
using System.Globalization;
using System.Xml;
using System.Xml.Schema;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Collections;

namespace SignVerify.Xades
{
	


	/// <summary>
	/// Facade class for the XAdES signature library.  The class inherits from
	/// the System.Security.Cryptography.Xml.SignedXml class and is backwards
	/// compatible with it, so this class can host xmldsig signatures and XAdES
	/// signatures.  The property SignatureStandard will indicate the type of the
	/// signature: XMLDSIG or XAdES.
	/// </summary>
    public class GovSignedXml : System.Security.Cryptography.Xml.SignedXml
    {
        private bool isXades = false;
        public bool IsXades { get { return isXades; } set { isXades = value; } }

        public XmlNode SignatureTimeStampNode 
        { get 
            {
                XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(this.GetXml().OwnerDocument.NameTable); //Create an XmlNamespaceManager to resolve namespace
                xmlNamespaceManager.AddNamespace("ds", SignedXml.XmlDsigNamespaceUrl);
                xmlNamespaceManager.AddNamespace("xsd", XadesSignedXml.XadesNamespaceUri);

                return this.GetXml().SelectSingleNode("ds:Object/xsd:QualifyingProperties/xsd:UnsignedProperties/xsd:UnsignedSignatureProperties/xsd:SignatureTimeStamp", xmlNamespaceManager);
            } 
        }

        public XadesObject XadesObject
        {
            get
            {
                XadesObject retVal = new XadesObject();

                retVal.LoadXml(this.GetXadesObjectElement(this.GetXml()), this.GetXml());

                return retVal;
            }
        }

        private static readonly string[] idAttrs = new string[]
        {
            "_id",
            "_Id",
            "_ID"
        };
        public new XmlElement GetXml()
        {
            XmlElement retVal;
            XmlNodeList xmlNodeList;
            XmlNamespaceManager xmlNamespaceManager;

            retVal = base.GetXml();
            if (this.signatureValueId != null && this.signatureValueId != "")
            { //Id on Signature value is needed for XAdES-T. We inject it here.
                xmlNamespaceManager = new XmlNamespaceManager(retVal.OwnerDocument.NameTable);
                xmlNamespaceManager.AddNamespace("ds", SignedXml.XmlDsigNamespaceUrl);
                xmlNodeList = retVal.SelectNodes("ds:SignatureValue", xmlNamespaceManager);
                if (xmlNodeList.Count > 0)
                {
                    ((XmlElement)xmlNodeList[0]).SetAttribute("Id", this.signatureValueId);
                }
            }
            return retVal;
        }
        public GovSignedXml(System.Xml.XmlDocument signatureElement)
            : base(signatureElement)
		{

		}
        public GovSignedXml(XmlElement signatureElement)
            : base(signatureElement)
		{

		}
        public string signatureValueId { get; set; }
        public override XmlElement GetIdElement(XmlDocument xmlDocument, string idValue)
        {
            XmlElement elem = base.GetIdElement(xmlDocument, idValue);

            if (elem == null)
            {
                XmlNode node1;
                foreach (DataObject data in base.Signature.ObjectList)
                {
                    foreach (XmlNode node in data.Data)
                    {
                        node1 = node.SelectSingleNode("//SignedProperties[@Id='" + idValue + "']");
                        if (node1 != null)
                        {
                            return (XmlElement)node1;
                        }
                    }
                }
            }

            return elem;
        }
        public new void LoadXml(System.Xml.XmlElement xmlElement)
        {

            this.signatureValueId = null;
            base.LoadXml(xmlElement);

            XmlNode idAttribute = xmlElement.Attributes.GetNamedItem("Id");
            if (idAttribute != null)
            {
                this.Signature.Id = idAttribute.Value;
            }


            XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(xmlElement.OwnerDocument.NameTable);
            xmlNamespaceManager.AddNamespace("ds", SignedXml.XmlDsigNamespaceUrl);

            XmlNodeList xmlNodeList = xmlElement.SelectNodes("ds:SignatureValue", xmlNamespaceManager);
            if (xmlNodeList.Count > 0)
            {
                if (((XmlElement)xmlNodeList[0]).HasAttribute("Id"))
                {
                    this.signatureValueId = ((XmlElement)xmlNodeList[0]).Attributes["Id"].Value;
                }
            }
            xmlNodeList = xmlElement.SelectNodes("ds:SignedInfo", xmlNamespaceManager);
            if (xmlNodeList.Count > 0)
            {
                if (((XmlElement)xmlNodeList[0]).HasAttribute("Id"))
                {
                    this.signedInfoIdBuffer = ((XmlElement)xmlNodeList[0]).Attributes["Id"].Value;
                }
                else
                {
                    this.signedInfoIdBuffer = null;
                }
            }
            
        }

        public bool XadesCheckSignature()
        {
            bool retVal;

            retVal = true;
            retVal &= this.CheckXmldsigSignature();
            retVal &= this.CheckSameCertificate();
            retVal &= this.CheckAllReferencesExistInAllDataObjectsTimeStamp();
            retVal &= this.CheckAllHashDataInfosInIndividualDataObjectsTimeStamp();
            retVal &= this.CheckIfClaimedRolesOrCertifiedRolesPresentInSignerRole();
            retVal &= this.CheckHashDataInfoOfSignatureTimeStampPointsToSignatureValue();
            retVal &= this.CheckQualifyingPropertiesTarget();
            retVal &= this.CheckQualifyingProperties();
            retVal &= this.CheckSigAndRefsTimeStampHashDataInfos();
            retVal &= this.CheckArchiveTimeStampHashDataInfos();
            retVal &= this.CheckXadesCIsXadesT();
            retVal &= this.CheckXadesXLIsXadesX();
            //retVal &= this.CheckCertificateValuesMatchCertificateRefs();
            retVal &= this.CheckRevocationValuesMatchRevocationRefs();

            return retVal;
        }
        private XmlElement GetXadesObjectElement(XmlElement signatureElement)
        {
            XmlElement retVal = null;

            XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(signatureElement.OwnerDocument.NameTable); //Create an XmlNamespaceManager to resolve namespace
            xmlNamespaceManager.AddNamespace("ds", SignedXml.XmlDsigNamespaceUrl);
            xmlNamespaceManager.AddNamespace("xsd", XadesSignedXml.XadesNamespaceUri);

            XmlNodeList xmlNodeList = signatureElement.SelectNodes("ds:Object/xsd:QualifyingProperties", xmlNamespaceManager);
            if (xmlNodeList.Count > 0)
            {
                retVal = (XmlElement)xmlNodeList.Item(0).ParentNode;
                this.IsXades = true;
            }
            else
            {
                retVal = null;
            }

            return retVal;
        }
        #region XadesCheckSignature routines
        /// <summary>
        /// Check the signature of the underlying XMLDSIG signature
        /// </summary>
        /// <returns>If the function returns true the check was OK</returns>
        public virtual bool CheckXmldsigSignature()
        {
            bool retVal = false;

            KeyInfo keyInfo = new KeyInfo();
            X509Certificate xmldsigCert = new X509Certificate(System.Text.Encoding.ASCII.GetBytes(this.KeyInfo.GetXml().InnerText));
            keyInfo.AddClause(new KeyInfoX509Data(xmldsigCert));
            this.KeyInfo = keyInfo;

            retVal = this.CheckSignature();
            if (retVal == false)
            {
                throw new CryptographicException("CheckXmldsigSignature() failed");
            }

            return retVal;
        }

       


        /// <summary>
        /// Check to see if first XMLDSIG certificate has same hashvalue as first XAdES SignatureCertificate
        /// </summary>
        /// <returns>If the function returns true the check was OK</returns>
        public virtual bool CheckSameCertificate()
        {
            bool retVal = false;

            //KeyInfoX509Data keyInfoX509Data = new KeyInfoX509Data();
            //keyInfoX509Data.LoadXml(this.KeyInfo.GetXml());
            //if (keyInfoX509Data.Certificates.Count <= 0)
            //{
            //    throw new CryptographicException("Certificate not found in XMLDSIG signature while doing CheckSameCertificate()");
            //}
            //string xmldsigCertHash = Convert.ToBase64String(((X509Certificate)keyInfoX509Data.Certificates[0]).GetCertHash());

            X509Certificate xmldsigCert = new X509Certificate(System.Text.Encoding.ASCII.GetBytes(this.KeyInfo.GetXml().InnerText));
            string xmldsigCertHash = Convert.ToBase64String(xmldsigCert.GetCertHash());

            CertCollection xadesSigningCertificateCollection = this.XadesObject.QualifyingProperties.SignedProperties.SignedSignatureProperties.SigningCertificate.CertCollection;
            if (xadesSigningCertificateCollection.Count <= 0)
            {
                throw new CryptographicException("Certificate not found in SigningCertificate element while doing CheckSameCertificate()");
            }
            string xadesCertHash = Convert.ToBase64String(((Cert)xadesSigningCertificateCollection[0]).CertDigest.DigestValue);

            if (String.Compare(xmldsigCertHash, xadesCertHash, true, CultureInfo.InvariantCulture) != 0)
            {
                throw new CryptographicException("Certificate in XMLDSIG signature doesn't match certificate in SigningCertificate element");
            }
            retVal = true;

            return retVal;
        }

        /// <summary>
        /// Check if there is a HashDataInfo for each reference if there is a AllDataObjectsTimeStamp
        /// </summary>
        /// <returns>If the function returns true the check was OK</returns>
        public virtual bool CheckAllReferencesExistInAllDataObjectsTimeStamp()
        {
            AllDataObjectsTimeStampCollection allDataObjectsTimeStampCollection;
            bool allHashDataInfosExist;
            TimeStamp timeStamp;
            int timeStampCounter;
            bool retVal;

            allHashDataInfosExist = true;
            retVal = false;
            allDataObjectsTimeStampCollection = this.XadesObject.QualifyingProperties.SignedProperties.SignedDataObjectProperties.AllDataObjectsTimeStampCollection;
            if (allDataObjectsTimeStampCollection.Count > 0)
            {
                for (timeStampCounter = 0; allHashDataInfosExist && (timeStampCounter < allDataObjectsTimeStampCollection.Count); timeStampCounter++)
                {
                    timeStamp = allDataObjectsTimeStampCollection[timeStampCounter];
                    allHashDataInfosExist &= this.CheckHashDataInfosForTimeStamp(timeStamp);
                }
                if (!allHashDataInfosExist)
                {
                    throw new CryptographicException("At least one HashDataInfo is missing in AllDataObjectsTimeStamp element");
                }
            }
            retVal = true;

            return retVal;
        }
        private bool CheckHashDataInfosForTimeStamp(TimeStamp timeStamp)
        {
            bool retVal = true;

            for (int referenceCounter = 0; retVal == true && (referenceCounter < this.SignedInfo.References.Count); referenceCounter++)
            {
                string referenceId = ((Reference)this.SignedInfo.References[referenceCounter]).Id;
                string referenceUri = ((Reference)this.SignedInfo.References[referenceCounter]).Uri;
                if (referenceUri != ("#" + this.XadesObject.QualifyingProperties.SignedProperties.Id))
                {
                    bool hashDataInfoFound = false;
                    for (int hashDataInfoCounter = 0; hashDataInfoFound == false && (hashDataInfoCounter < timeStamp.HashDataInfoCollection.Count); hashDataInfoCounter++)
                    {
                        HashDataInfo hashDataInfo = timeStamp.HashDataInfoCollection[hashDataInfoCounter];
                        hashDataInfoFound = (("#" + referenceId) == hashDataInfo.UriAttribute);
                    }
                    retVal = hashDataInfoFound;
                }
            }

            return retVal;
        }
        /// <summary>
        /// Check if the HashDataInfo of each IndividualDataObjectsTimeStamp points to existing Reference
        /// </summary>
        /// <returns>If the function returns true the check was OK</returns>
        public virtual bool CheckAllHashDataInfosInIndividualDataObjectsTimeStamp()
        {
            IndividualDataObjectsTimeStampCollection individualDataObjectsTimeStampCollection;
            bool hashDataInfoExists;
            TimeStamp timeStamp;
            int timeStampCounter;
            bool retVal;

            hashDataInfoExists = true;
            retVal = false;
            individualDataObjectsTimeStampCollection = this.XadesObject.QualifyingProperties.SignedProperties.SignedDataObjectProperties.IndividualDataObjectsTimeStampCollection;
            if (individualDataObjectsTimeStampCollection.Count > 0)
            {
                for (timeStampCounter = 0; hashDataInfoExists && (timeStampCounter < individualDataObjectsTimeStampCollection.Count); timeStampCounter++)
                {
                    timeStamp = individualDataObjectsTimeStampCollection[timeStampCounter];
                    hashDataInfoExists &= this.CheckHashDataInfosExist(timeStamp);
                }
                if (hashDataInfoExists == false)
                {
                    throw new CryptographicException("At least one HashDataInfo is pointing to non-existing reference in IndividualDataObjectsTimeStamp element");
                }
            }
            retVal = true;

            return retVal;
        }

        private bool CheckHashDataInfosExist(TimeStamp timeStamp)
        {
            bool retVal = true;

            for (int hashDataInfoCounter = 0; retVal == true && (hashDataInfoCounter < timeStamp.HashDataInfoCollection.Count); hashDataInfoCounter++)
            {
                HashDataInfo hashDataInfo = timeStamp.HashDataInfoCollection[hashDataInfoCounter];
                bool referenceFound = false;
                string referenceId;

                for (int referenceCounter = 0; referenceFound == false && (referenceCounter < this.SignedInfo.References.Count); referenceCounter++)
                {
                    referenceId = ((Reference)this.SignedInfo.References[referenceCounter]).Id;
                    if (("#" + referenceId) == hashDataInfo.UriAttribute)
                    {
                        referenceFound = true;
                    }
                }
                retVal = referenceFound;
            }

            return retVal;
        }

      
       
        /// <summary>
        /// Check if at least ClaimedRoles or CertifiedRoles present in SignerRole
        /// </summary>
        /// <returns>If the function returns true the check was OK</returns>
        public virtual bool CheckIfClaimedRolesOrCertifiedRolesPresentInSignerRole()
        {
            SignerRole signerRole;
            bool retVal;

            retVal = false;
            signerRole = this.XadesObject.QualifyingProperties.SignedProperties.SignedSignatureProperties.SignerRole;
            if (signerRole != null)
            {
                if (signerRole.CertifiedRoles != null)
                {
                    retVal = (signerRole.CertifiedRoles.CertifiedRoleCollection.Count > 0);
                }
                if (retVal == false)
                {
                    if (signerRole.ClaimedRoles != null)
                    {
                        retVal = (signerRole.ClaimedRoles.ClaimedRoleCollection.Count > 0);
                    }
                }
                if (retVal == false)
                {
                    throw new CryptographicException("SignerRole element must contain at least one CertifiedRole or ClaimedRole element");
                }
            }
            else
            {
                retVal = true;
            }

            return retVal;
        }

        /// <summary>
        /// Check if HashDataInfo of SignatureTimeStamp points to SignatureValue
        /// </summary>
        /// <returns>If the function returns true the check was OK</returns>
        public virtual bool CheckHashDataInfoOfSignatureTimeStampPointsToSignatureValue()
        {
            SignatureTimeStampCollection signatureTimeStampCollection;
            bool hashDataInfoPointsToSignatureValue;
            TimeStamp timeStamp;
            int timeStampCounter;
            bool retVal;

            hashDataInfoPointsToSignatureValue = true;
            retVal = false;
            signatureTimeStampCollection = this.XadesObject.QualifyingProperties.UnsignedProperties.UnsignedSignatureProperties.SignatureTimeStampCollection;
            if (signatureTimeStampCollection.Count > 0)
            {
                for (timeStampCounter = 0; hashDataInfoPointsToSignatureValue && (timeStampCounter < signatureTimeStampCollection.Count); timeStampCounter++)
                {
                    timeStamp = signatureTimeStampCollection[timeStampCounter];
                    hashDataInfoPointsToSignatureValue &= this.CheckHashDataInfoPointsToSignatureValue(timeStamp);
                }
                if (hashDataInfoPointsToSignatureValue == false)
                {
                    throw new CryptographicException("HashDataInfo of SignatureTimeStamp doesn't point to signature value element");
                }
            }
            retVal = true;

            return retVal;
        }
        private bool CheckHashDataInfoPointsToSignatureValue(TimeStamp timeStamp)
        {
            bool retVal = true;
            foreach (HashDataInfo hashDataInfo in timeStamp.HashDataInfoCollection)
            {
                retVal &= (hashDataInfo.UriAttribute == ("#" + this.signatureValueId));
            }

            return retVal;
        }
        /// <summary>
        /// Check if the QualifyingProperties Target attribute points to the signature element
        /// </summary>
        /// <returns>If the function returns true the check was OK</returns>
        public virtual bool CheckQualifyingPropertiesTarget()
        {
            string qualifyingPropertiesTarget;
            bool retVal;

            retVal = true;
            qualifyingPropertiesTarget = this.XadesObject.QualifyingProperties.Target;
            if (this.Signature.Id == null)
            {
                retVal = false;
            }
            else
            {
                if (qualifyingPropertiesTarget != ("#" + this.Signature.Id))
                {
                    retVal = false;
                }
            }
            if (retVal == false)
            {
                throw new CryptographicException("Qualifying properties target doesn't point to signature element or signature element doesn't have an Id");
            }

            return retVal;
        }

        /// <summary>
        /// Check that QualifyingProperties occur in one Object, check that there is only one QualifyingProperties and that signed properties occur in one QualifyingProperties element
        /// </summary>
        /// <returns>If the function returns true the check was OK</returns>
        public virtual bool CheckQualifyingProperties()
        {
            XmlElement signatureElement;
            XmlNamespaceManager xmlNamespaceManager;
            XmlNodeList xmlNodeList;

            signatureElement = this.GetXml();
            xmlNamespaceManager = new XmlNamespaceManager(signatureElement.OwnerDocument.NameTable);
            xmlNamespaceManager.AddNamespace("ds", SignedXml.XmlDsigNamespaceUrl);
            xmlNamespaceManager.AddNamespace("xsd", XadesSignedXml.XadesNamespaceUri);
            xmlNodeList = signatureElement.SelectNodes("ds:Object/xsd:QualifyingProperties", xmlNamespaceManager);
            if (xmlNodeList.Count > 1)
            {
                throw new CryptographicException("More than one Object contains a QualifyingProperties element");
            }

            return true;
        }

        /// <summary>
        /// Check if all required HashDataInfos are present on SigAndRefsTimeStamp
        /// </summary>
        /// <returns>If the function returns true the check was OK</returns>
        public virtual bool CheckSigAndRefsTimeStampHashDataInfos()
        {
            SignatureTimeStampCollection signatureTimeStampCollection;
            TimeStamp timeStamp;
            bool allRequiredhashDataInfosFound;
            bool retVal;

            retVal = true;
            signatureTimeStampCollection = this.XadesObject.QualifyingProperties.UnsignedProperties.UnsignedSignatureProperties.SigAndRefsTimeStampCollection;
            if (signatureTimeStampCollection.Count > 0)
            {
                allRequiredhashDataInfosFound = true;
                for (int timeStampCounter = 0; allRequiredhashDataInfosFound && (timeStampCounter < signatureTimeStampCollection.Count); timeStampCounter++)
                {
                    timeStamp = signatureTimeStampCollection[timeStampCounter];
                    allRequiredhashDataInfosFound &= this.CheckHashDataInfosOfSigAndRefsTimeStamp(timeStamp);
                }
                if (allRequiredhashDataInfosFound == false)
                {
                    throw new CryptographicException("At least one required HashDataInfo is missing in a SigAndRefsTimeStamp element");
                }
            }

            return retVal;
        }
        private bool CheckHashDataInfosOfSigAndRefsTimeStamp(TimeStamp timeStamp)
        {
            UnsignedSignatureProperties unsignedSignatureProperties;
            bool signatureValueHashDataInfoFound = false;
            bool allSignatureTimeStampHashDataInfosFound = false;
            bool completeCertificateRefsHashDataInfoFound = false;
            bool completeRevocationRefsHashDataInfoFound = false;

            ArrayList signatureTimeStampIds = new ArrayList();

            bool retVal = true;

            unsignedSignatureProperties = this.XadesObject.QualifyingProperties.UnsignedProperties.UnsignedSignatureProperties;

            foreach (TimeStamp signatureTimeStamp in unsignedSignatureProperties.SignatureTimeStampCollection)
            {
                signatureTimeStampIds.Add("#" + signatureTimeStamp.EncapsulatedTimeStamp.Id);
            }
            signatureTimeStampIds.Sort();
            foreach (HashDataInfo hashDataInfo in timeStamp.HashDataInfoCollection)
            {
                if (hashDataInfo.UriAttribute == "#" + this.signatureValueId)
                {
                    signatureValueHashDataInfoFound = true;
                }
                int signatureTimeStampIdIndex = signatureTimeStampIds.BinarySearch(hashDataInfo.UriAttribute);
                if (signatureTimeStampIdIndex >= 0)
                {
                    signatureTimeStampIds.RemoveAt(signatureTimeStampIdIndex);
                }
                if (hashDataInfo.UriAttribute == "#" + unsignedSignatureProperties.CompleteCertificateRefs.Id)
                {
                    completeCertificateRefsHashDataInfoFound = true;
                }
                if (hashDataInfo.UriAttribute == "#" + unsignedSignatureProperties.CompleteRevocationRefs.Id)
                {
                    completeRevocationRefsHashDataInfoFound = true;
                }
            }
            if (signatureTimeStampIds.Count == 0)
            {
                allSignatureTimeStampHashDataInfosFound = true;
            }
            retVal = signatureValueHashDataInfoFound && allSignatureTimeStampHashDataInfosFound && completeCertificateRefsHashDataInfoFound && completeRevocationRefsHashDataInfoFound;

            return retVal;
        }

       

        /// <summary>
        /// Check if all required HashDataInfos are present on ArchiveTimeStamp
        /// </summary>
        /// <returns>If the function returns true the check was OK</returns>
        public virtual bool CheckArchiveTimeStampHashDataInfos()
        {
            SignatureTimeStampCollection signatureTimeStampCollection;
            TimeStamp timeStamp;
            bool allRequiredhashDataInfosFound;
            bool retVal;

            retVal = true;
            signatureTimeStampCollection = this.XadesObject.QualifyingProperties.UnsignedProperties.UnsignedSignatureProperties.ArchiveTimeStampCollection;
            if (signatureTimeStampCollection.Count > 0)
            {
                allRequiredhashDataInfosFound = true;
                for (int timeStampCounter = 0; allRequiredhashDataInfosFound && (timeStampCounter < signatureTimeStampCollection.Count); timeStampCounter++)
                {
                    timeStamp = signatureTimeStampCollection[timeStampCounter];
                    allRequiredhashDataInfosFound &= this.CheckHashDataInfosOfArchiveTimeStamp(timeStamp);
                }
                if (allRequiredhashDataInfosFound == false)
                {
                    throw new CryptographicException("At least one required HashDataInfo is missing in a ArchiveTimeStamp element");
                }
            }

            return retVal;
        }
        private bool CheckHashDataInfosOfArchiveTimeStamp(TimeStamp timeStamp)
        {
            UnsignedSignatureProperties unsignedSignatureProperties;
            SignedProperties signedProperties;

            bool allReferenceHashDataInfosFound = false;
            bool signedInfoHashDataInfoFound = false;
            bool signedPropertiesHashDataInfoFound = false;
            bool signatureValueHashDataInfoFound = false;
            bool allSignatureTimeStampHashDataInfosFound = false;
            bool completeCertificateRefsHashDataInfoFound = false;
            bool completeRevocationRefsHashDataInfoFound = false;
            bool certificatesValuesHashDataInfoFound = false;
            bool revocationValuesHashDataInfoFound = false;
            bool allSigAndRefsTimeStampHashDataInfosFound = false;
            bool allRefsOnlyTimeStampHashDataInfosFound = false;
            bool allArchiveTimeStampHashDataInfosFound = false;
            bool allOlderArchiveTimeStampsFound = false;

            ArrayList referenceIds = new ArrayList();
            ArrayList signatureTimeStampIds = new ArrayList();
            ArrayList sigAndRefsTimeStampIds = new ArrayList();
            ArrayList refsOnlyTimeStampIds = new ArrayList();
            ArrayList archiveTimeStampIds = new ArrayList();

            bool retVal = true;

            unsignedSignatureProperties = this.XadesObject.QualifyingProperties.UnsignedProperties.UnsignedSignatureProperties;
            signedProperties = this.XadesObject.QualifyingProperties.SignedProperties;

            foreach (Reference reference in this.Signature.SignedInfo.References)
            {
                if (reference.Uri != "#" + signedProperties.Id)
                {
                    referenceIds.Add(reference.Uri);
                }
            }
            referenceIds.Sort();
            foreach (TimeStamp signatureTimeStamp in unsignedSignatureProperties.SignatureTimeStampCollection)
            {
                signatureTimeStampIds.Add("#" + signatureTimeStamp.EncapsulatedTimeStamp.Id);
            }
            signatureTimeStampIds.Sort();
            foreach (TimeStamp sigAndRefsTimeStamp in unsignedSignatureProperties.SigAndRefsTimeStampCollection)
            {
                sigAndRefsTimeStampIds.Add("#" + sigAndRefsTimeStamp.EncapsulatedTimeStamp.Id);
            }
            sigAndRefsTimeStampIds.Sort();
            foreach (TimeStamp refsOnlyTimeStamp in unsignedSignatureProperties.RefsOnlyTimeStampCollection)
            {
                refsOnlyTimeStampIds.Add("#" + refsOnlyTimeStamp.EncapsulatedTimeStamp.Id);
            }
            refsOnlyTimeStampIds.Sort();
            allOlderArchiveTimeStampsFound = false;
            for (int archiveTimeStampCounter = 0; !allOlderArchiveTimeStampsFound && (archiveTimeStampCounter < unsignedSignatureProperties.ArchiveTimeStampCollection.Count); archiveTimeStampCounter++)
            {
                TimeStamp archiveTimeStamp = unsignedSignatureProperties.ArchiveTimeStampCollection[archiveTimeStampCounter];
                if (archiveTimeStamp.EncapsulatedTimeStamp.Id == timeStamp.EncapsulatedTimeStamp.Id)
                {
                    allOlderArchiveTimeStampsFound = true;
                }
                else
                {
                    archiveTimeStampIds.Add("#" + archiveTimeStamp.EncapsulatedTimeStamp.Id);
                }
            }

            archiveTimeStampIds.Sort();
            foreach (HashDataInfo hashDataInfo in timeStamp.HashDataInfoCollection)
            {
                int index = referenceIds.BinarySearch(hashDataInfo.UriAttribute);
                if (index >= 0)
                {
                    referenceIds.RemoveAt(index);
                }
                if (hashDataInfo.UriAttribute == "#" + this.signedInfoIdBuffer)
                {
                    signedInfoHashDataInfoFound = true;
                }
                if (hashDataInfo.UriAttribute == "#" + signedProperties.Id)
                {
                    signedPropertiesHashDataInfoFound = true;
                }
                if (hashDataInfo.UriAttribute == "#" + this.signatureValueId)
                {
                    signatureValueHashDataInfoFound = true;
                }
                index = signatureTimeStampIds.BinarySearch(hashDataInfo.UriAttribute);
                if (index >= 0)
                {
                    signatureTimeStampIds.RemoveAt(index);
                }
                if (hashDataInfo.UriAttribute == "#" + unsignedSignatureProperties.CompleteCertificateRefs.Id)
                {
                    completeCertificateRefsHashDataInfoFound = true;
                }
                if (hashDataInfo.UriAttribute == "#" + unsignedSignatureProperties.CompleteRevocationRefs.Id)
                {
                    completeRevocationRefsHashDataInfoFound = true;
                }
                if (hashDataInfo.UriAttribute == "#" + unsignedSignatureProperties.CertificateValues.Id)
                {
                    certificatesValuesHashDataInfoFound = true;
                }
                if (hashDataInfo.UriAttribute == "#" + unsignedSignatureProperties.RevocationValues.Id)
                {
                    revocationValuesHashDataInfoFound = true;
                }
                index = sigAndRefsTimeStampIds.BinarySearch(hashDataInfo.UriAttribute);
                if (index >= 0)
                {
                    sigAndRefsTimeStampIds.RemoveAt(index);
                }
                index = refsOnlyTimeStampIds.BinarySearch(hashDataInfo.UriAttribute);
                if (index >= 0)
                {
                    refsOnlyTimeStampIds.RemoveAt(index);
                }
                index = archiveTimeStampIds.BinarySearch(hashDataInfo.UriAttribute);
                if (index >= 0)
                {
                    archiveTimeStampIds.RemoveAt(index);
                }
            }
            if (referenceIds.Count == 0)
            {
                allReferenceHashDataInfosFound = true;
            }
            if (signatureTimeStampIds.Count == 0)
            {
                allSignatureTimeStampHashDataInfosFound = true;
            }
            if (sigAndRefsTimeStampIds.Count == 0)
            {
                allSigAndRefsTimeStampHashDataInfosFound = true;
            }
            if (refsOnlyTimeStampIds.Count == 0)
            {
                allRefsOnlyTimeStampHashDataInfosFound = true;
            }
            if (archiveTimeStampIds.Count == 0)
            {
                allArchiveTimeStampHashDataInfosFound = true;
            }

            retVal = allReferenceHashDataInfosFound && signedInfoHashDataInfoFound && signedPropertiesHashDataInfoFound &&
                signatureValueHashDataInfoFound && allSignatureTimeStampHashDataInfosFound && completeCertificateRefsHashDataInfoFound &&
                completeRevocationRefsHashDataInfoFound && certificatesValuesHashDataInfoFound && revocationValuesHashDataInfoFound &&
                allSigAndRefsTimeStampHashDataInfosFound && allRefsOnlyTimeStampHashDataInfosFound && allArchiveTimeStampHashDataInfosFound;

            return retVal;
        }
        /// <summary>
        /// Check if a XAdES-C signature is also a XAdES-T signature
        /// </summary>
        /// <returns>If the function returns true the check was OK</returns>
        public virtual bool CheckXadesCIsXadesT()
        {
            UnsignedSignatureProperties unsignedSignatureProperties;
            bool retVal;

            retVal = true;
            unsignedSignatureProperties = this.XadesObject.QualifyingProperties.UnsignedProperties.UnsignedSignatureProperties;
            if (((unsignedSignatureProperties.CompleteCertificateRefs != null) && (unsignedSignatureProperties.CompleteCertificateRefs.HasChanged()))
                || ((unsignedSignatureProperties.CompleteCertificateRefs != null) && (unsignedSignatureProperties.CompleteCertificateRefs.HasChanged())))
            {
                if (unsignedSignatureProperties.SignatureTimeStampCollection.Count == 0)
                {
                    throw new CryptographicException("XAdES-C signature should also contain a SignatureTimeStamp element");
                }
            }

            return retVal;
        }

        /// <summary>
        /// Check if a XAdES-XL signature is also a XAdES-X signature
        /// </summary>
        /// <returns>If the function returns true the check was OK</returns>
        public virtual bool CheckXadesXLIsXadesX()
        {
            UnsignedSignatureProperties unsignedSignatureProperties;
            bool retVal;

            retVal = true;
            unsignedSignatureProperties = this.XadesObject.QualifyingProperties.UnsignedProperties.UnsignedSignatureProperties;
            if (((unsignedSignatureProperties.CertificateValues != null) && (unsignedSignatureProperties.CertificateValues.HasChanged()))
                || ((unsignedSignatureProperties.RevocationValues != null) && (unsignedSignatureProperties.RevocationValues.HasChanged())))
            {
                if ((unsignedSignatureProperties.SigAndRefsTimeStampCollection.Count == 0) && (unsignedSignatureProperties.RefsOnlyTimeStampCollection.Count == 0))
                {
                    throw new CryptographicException("XAdES-XL signature should also contain a XAdES-X element");
                }
            }

            return retVal;
        }

        /// <summary>
        /// Check if CertificateValues match CertificateRefs
        /// </summary>
        /// <returns>If the function returns true the check was OK</returns>
        public virtual bool CheckCertificateValuesMatchCertificateRefs()
        {
            SHA1Managed sha1Managed;
            UnsignedSignatureProperties unsignedSignatureProperties;
            ArrayList certDigests;
            byte[] certDigest;
            int index;
            bool retVal;

            //TODO: Similar test should be done for XML based (Other) certificates, but as the check needed is not known, there is no implementation
            retVal = true;
            unsignedSignatureProperties = this.XadesObject.QualifyingProperties.UnsignedProperties.UnsignedSignatureProperties;
            if ((unsignedSignatureProperties.CompleteCertificateRefs != null) && (unsignedSignatureProperties.CompleteCertificateRefs.CertRefs != null) &&
                (unsignedSignatureProperties.CertificateValues != null))
            {
                certDigests = new ArrayList();
                foreach (Cert cert in unsignedSignatureProperties.CompleteCertificateRefs.CertRefs.CertCollection)
                {
                    certDigests.Add(Convert.ToBase64String(cert.CertDigest.DigestValue));
                }
                certDigests.Sort();
                foreach (EncapsulatedX509Certificate encapsulatedX509Certificate in unsignedSignatureProperties.CertificateValues.EncapsulatedX509CertificateCollection)
                {
                    sha1Managed = new SHA1Managed();
                    certDigest = sha1Managed.ComputeHash(encapsulatedX509Certificate.PkiData);
                    index = certDigests.BinarySearch(Convert.ToBase64String(certDigest));
                    if (index >= 0)
                    {
                        certDigests.RemoveAt(index);
                    }
                }
                if (certDigests.Count != 0)
                {
                    throw new CryptographicException("Not all CertificateRefs correspond to CertificateValues");
                }
            }


            return retVal;
        }

        /// <summary>
        /// Check if RevocationValues match RevocationRefs
        /// </summary>
        /// <returns>If the function returns true the check was OK</returns>
        public virtual bool CheckRevocationValuesMatchRevocationRefs()
        {
            SHA1Managed sha1Managed;
            UnsignedSignatureProperties unsignedSignatureProperties;
            ArrayList crlDigests;
            byte[] crlDigest;
            int index;
            bool retVal;

            //TODO: Similar test should be done for XML based (Other) revocation information and OCSP responses, but to keep the library independent of these technologies, this test is left to appliactions using the library
            retVal = true;
            unsignedSignatureProperties = this.XadesObject.QualifyingProperties.UnsignedProperties.UnsignedSignatureProperties;
            if ((unsignedSignatureProperties.CompleteRevocationRefs != null) && (unsignedSignatureProperties.CompleteRevocationRefs.CRLRefs != null) &&
                (unsignedSignatureProperties.RevocationValues != null))
            {
                crlDigests = new ArrayList();
                foreach (CRLRef crlRef in unsignedSignatureProperties.CompleteRevocationRefs.CRLRefs.CRLRefCollection)
                {
                    crlDigests.Add(Convert.ToBase64String(crlRef.CertDigest.DigestValue));
                }
                crlDigests.Sort();
                foreach (CRLValue crlValue in unsignedSignatureProperties.RevocationValues.CRLValues.CRLValueCollection)
                {
                    sha1Managed = new SHA1Managed();
                    crlDigest = sha1Managed.ComputeHash(crlValue.PkiData);
                    index = crlDigests.BinarySearch(Convert.ToBase64String(crlDigest));
                    if (index >= 0)
                    {
                        crlDigests.RemoveAt(index);
                    }
                }
                if (crlDigests.Count != 0)
                {
                    throw new CryptographicException("Not all RevocationRefs correspond to RevocationValues");
                }
            }

            return retVal;
        }
        #endregion

        public string signedInfoIdBuffer { get; set; }
    }
}
