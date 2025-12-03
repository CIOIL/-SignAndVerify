using System;
using System.Collections.Generic;
using System.Text;
using SignVerify.Common;
using SignVerify.Xades;
using System.Xml;
using System.Security.Cryptography.Xml;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.Collections;
using SignVerify.Common.TimeStamp;
using System.Reflection;
using Security.Cryptography;


namespace SignVerify.Providers.XadesProvider
{


    public class Xades : ICryptoProviderBinary
    {

        #region Variables
        //private XmlDocument envelopedSignatureXmlDocument;
        private XadesSignedXml xadesSignedXml;
        private SignParameters m_SignParameters;
        private int documentDataObjectCounter;
        private X509Chain Chain;
        #endregion



        #region ExternalSignature
        /// <summary>
        /// Create and calculate the hash of the final signed xml document
        /// 
        /// </summary>
        /// <param name="objectToSign">bytes of the hash that need to be signed</param>
        /// <param name="signingParameters">parameters like public key</param>
        /// <returns>the hash that need to be signed</returns>
        public CryptoSignedObject<byte[]> CalculateHash(byte[] objectToSign, SignParameters signingParameters)
        {
            CheckIfParametersMissing(objectToSign, signingParameters);
            m_SignParameters = signingParameters;
            DataObjectFormat newDataObjectFormat = CreateReferenceToObject(true, objectToSign, signingParameters.signatureInfo.fileName, signingParameters.appName);
            AddCertificate(signingParameters.signatureInfo.certificate);
            CreateXadesObject(newDataObjectFormat);
            this.xadesSignedXml.SignedInfo.SignatureMethod = Constants.XmlDsigRSASHA256Url;
            byte[] hash = xadesSignedXml.ComputeHash(objectToSign, signingParameters.signatureInfo.fileName);
            CryptoHashInfo<byte[]> hashContent;
            if (m_SignParameters.detached)
                hashContent = new CryptoHashInfo<byte[]>(GetAsPackage(System.Text.Encoding.UTF8.GetBytes(xadesSignedXml.GetXml().OuterXml), objectToSign, signingParameters.signatureInfo.fileName), signingParameters.signatureInfo, hash);
            else
                hashContent = new CryptoHashInfo<byte[]>(System.Text.Encoding.UTF8.GetBytes(xadesSignedXml.GetXml().OuterXml), signingParameters.signatureInfo, hash);
            CryptoSignedObject<byte[]> retVal = new CryptoSignedObject<byte[]>(hashContent, ProviderFriendlyName);
            retVal.SdkVersion = Constants.SDKVersion;
            retVal.AppVersion = Constants.AppVersion;
            return retVal;
        }

        /// <summary>
        /// Sign the hash with the private key of the certificate
        /// </summary>
        /// <param name="hash">hash to be signed</param>
        /// <param name="certificate">certificate with private key</param>
        /// <returns>signature</returns>
        public byte[] SignHash(byte[] hash, X509Certificate2 certificate)
        {
            if (!certificate.HasPrivateKey)
            {
                Logger.Instance().Info("The certificate don't contains private key to sign with");
                throw new ApplicationException(XadesProvider.Lang.ErrorMessages.NotContainingPrivateKey);
            }
            if (hash == null)
            {
                Logger.Instance().Info("The hash value is empty.");
                throw new ApplicationException(XadesProvider.Lang.ErrorMessages.ParametersMissing);
            }
            try
            {
                byte[] sign;
                RSACryptoServiceProvider rsa = certificate.PrivateKey as RSACryptoServiceProvider;
                sign = rsa.SignHash(hash, Constants.SHA256);
                return sign;
            }
            catch (Exception ex)
            {
                Logger.Instance().Error("createSignature. Exception ComputeSignature.", ex);
                if (ex.Message.ToLower().Contains("wrong pin"))
                    throw new Exception(XadesProvider.Lang.ErrorMessages.WrongPinCode);
                else if (ex.Message.ToLower().Contains("the action was cancelled by the user."))
                    throw new Exception(XadesProvider.Lang.ErrorMessages.SignCanceled);
                else
                    throw new Exception("Failed ComputeSignature", ex);

            }
        }

        public CryptoSignedObject<byte[]> InsertSignatureValue(CryptoSignedObject<byte[]> cryptoObject, byte[] signatureValue)
        {
            return InsertSignatureValue(cryptoObject, signatureValue, new VerifyParameters());
        }

        /// <summary>
        /// Re-create the signed xml document with the same parameters 
        /// of the create hash function and insert the signature value
        /// The SigningTime must be the same of the CalculateHash function
        /// </summary>
        /// <param name="signatureValue">the signature value</param>
        /// <param name="objectToSign">the original content to sign</param>
        /// <param name="signingParameters">signing parameters</param>
        /// <param name="ComputeHashTime">the time of the hash calculation</param>
        /// <returns></returns>
        public CryptoSignedObject<byte[]> InsertSignatureValue(CryptoSignedObject<byte[]> cryptoObject, byte[] signatureValue, VerifyParameters verifyParametersInfo)
        {
            XmlDocument xmlDoc = IsXml(cryptoObject.HashInfo.ModifiedContent);
            //enveloping
            if (xmlDoc != null)
            {
                if (!IsSignatureXml(xmlDoc))
                    throw new ApplicationException(XadesProvider.Lang.ErrorMessages.WrongFile);
                byte[] signedBytes = CreateSignedFile(xmlDoc, signatureValue);
                return VerifySignature(signedBytes, null);
            }
            else
            {
                List<CryptoExtractedEntry> extractedFiles = ExtractPackage(cryptoObject.HashInfo.ModifiedContent);
                CryptoExtractedEntry signedObject = extractedFiles.Find(e => e.ParentFile != null);
                if (signedObject == null)
                    throw new ApplicationException(XadesProvider.Lang.ErrorMessages.WrongFile);
                xmlDoc = IsXml(signedObject.DataBytes);
                if (xmlDoc == null)
                    throw new ApplicationException(XadesProvider.Lang.ErrorMessages.WrongFile);
                if (!IsSignatureXml(xmlDoc))
                    throw new ApplicationException(XadesProvider.Lang.ErrorMessages.WrongFile);

                byte[] signedlBytes = CreateSignedFile(xmlDoc, signatureValue);

                CryptoExtractedEntry original = extractedFiles.Find(e => e.ParentFile == null && e.ChildFile != null);
                return VerifySignature(GetAsPackage(signedlBytes, original.DataBytes, original.FileName), verifyParametersInfo);
            }


        }

        private byte[] CreateSignedFile(XmlDocument xmlDoc, byte[] signatureValue)
        {
             XmlNodeList signatureNodeList = xmlDoc.GetElementsByTagName(Constants.Signature,SignedXml.XmlDsigNamespaceUrl);
            if (signatureNodeList.Count == 0)
            {
                signatureNodeList = xmlDoc.GetElementsByTagName(Constants.Signature);
            }
            if (signatureNodeList.Count == 0)
            {
                return null;
            }
            else
            {
                string dataID = string.Empty;



                this.xadesSignedXml = new XadesSignedXml(xmlDoc.DocumentElement);
                this.xadesSignedXml.LoadXml((XmlElement)signatureNodeList[0]);
                xadesSignedXml.InsertSignatureValue(signatureValue);
                this.xadesSignedXml.SignatureValueId = GetNewID();
                Logger.Instance().Info("Before adding xades.");
                //Xades 

                Logger.Instance().Info("Before xades T.");
                //Xades T
                if (m_SignParameters != null && m_SignParameters.timeStamped && !string.IsNullOrEmpty(m_SignParameters.signatureInfo.TimeStampURL))
                    AddTimeStampToSignature(m_SignParameters.signatureInfo.TimeStampURL);
                return System.Text.Encoding.UTF8.GetBytes(xadesSignedXml.GetXml().OuterXml);
            }
        }

        private bool IsSignatureXml(XmlDocument xmlDoc)
        {
            return xmlDoc.DocumentElement.Name.Equals(Constants.SigntureTag);
               
        }

        #endregion


        #region ICryptoProvider<byte[]> Members


        public CryptoSignedObject<byte[]> CoSign(byte[] objectToSign, CoSignParameters signingParameters)
        {
            throw new ApplicationException(XadesProvider.Lang.ErrorMessages.CosignNotSupported);
        }

        /// <summary>
        /// Sign the content in detached mode
        /// zip the signature with the content with .signed extension
        /// </summary>
        /// <param name="objectToSign">bytes to sign</param>
        /// <param name="signingParameters"></param>
        /// <returns></returns>
        public CryptoSignedObject<byte[]> Sign(byte[] objectToSign, SignParameters signingParameters)
        {
            CheckIfParametersMissing(objectToSign, signingParameters);
            if (!signingParameters.signatureInfo.certificate.HasPrivateKey)
            {
                Logger.Instance().Info("The certificate don't contains private key to sign with");
                throw new ApplicationException(XadesProvider.Lang.ErrorMessages.NotContainingPrivateKey);
            }

            Logger.Instance().Info(string.Format("Sign started.Parameters: File name:{0}, Certificate:{1}, ALGO:{2}, TS:{3}", signingParameters.signatureInfo.fileName, signingParameters.signatureInfo.certificate.FriendlyName, signingParameters.signatureInfo.signatureAlgorithm, signingParameters.timeStamped));
            // string dataID = GetNewID();

            m_SignParameters = signingParameters;
            DataObjectFormat newDataObjectFormat = CreateReferenceToObject(true, objectToSign, m_SignParameters.signatureInfo.fileName, m_SignParameters.appName);
            AddCertificate(m_SignParameters.signatureInfo.certificate);
            CreateXadesObject(newDataObjectFormat);

            this.xadesSignedXml.SigningKey = signingParameters.signatureInfo.certificate.PrivateKey;
            this.xadesSignedXml.SignedInfo.CanonicalizationMethod = SignedXml.XmlDsigExcC14NTransformUrl;
          
            //if (signingParameters.signatureInfo.certificate.SignatureAlgorithm.FriendlyName.Equals(Constants.sha1RSA))
            //{
            //    this.xadesSignedXml.SignedInfo.SignatureMethod = Constants.XmlDsigRSASHA1Url;
            //    signingParameters.signatureInfo.signatureAlgorithm = 1;
            //}
            //else
            //{
            //    this.xadesSignedXml.SignedInfo.SignatureMethod = Constants.XmlDsigRSASHA256Url;
            //    signingParameters.signatureInfo.signatureAlgorithm = 256;
            //}
            this.xadesSignedXml.SignedInfo.SignatureMethod = Constants.XmlDsigRSASHA256Url;
            Logger.Instance().Info("Before compute signature.");
            try
            {
                this.xadesSignedXml.ComputeSignature(objectToSign, m_SignParameters.signatureInfo.fileName);
            }
            catch (CryptographicException ex)
            {
                if (ex.Message.StartsWith("Invalid algorithm specified."))
                {
                    try
                    {
                        this.xadesSignedXml.SignedInfo.SignatureMethod = Constants.XmlDsigRSASHA1Url;
                        signingParameters.signatureInfo.signatureAlgorithm = 1;
                        this.xadesSignedXml.ComputeSignature(objectToSign, m_SignParameters.signatureInfo.fileName);
                    }
                    catch (Exception ex2)
                    {
                        throw new Exception("Failed ComputeSignature", ex2);
                    }
                }
                else
                {
                    throw new Exception("Failed ComputeSignature", ex);
                }
            }
            catch (Exception ex)
            {
                Logger.Instance().Error("createSignature. Exception ComputeSignature.", ex);
                if (ex.Message.ToLower().Contains("wrong pin"))
                    throw new Exception(XadesProvider.Lang.ErrorMessages.WrongPinCode);
                else if (ex.Message.ToLower().Contains("the action was cancelled by the user."))
                    throw new Exception(XadesProvider.Lang.ErrorMessages.SignCanceled);
                else
                    throw new Exception("Failed ComputeSignature", ex);

            }

            Logger.Instance().Info("After compute signature.");
            this.xadesSignedXml.SignatureValueId = GetNewID();

            Logger.Instance().Info("Before xades T.");
            //Xades T
            if (m_SignParameters.timeStamped && !string.IsNullOrEmpty(m_SignParameters.signatureInfo.TimeStampURL))
                AddTimeStampToSignature(m_SignParameters.signatureInfo.TimeStampURL);
            //Logger.Instance().Info("Before xades C.");
            //////Xades C
            //AddCompleteCertificateReferences(this.Chain, m_SignParameters.signatureInfo.certificate);
            //string crlUrl = GetCrlUrlFromCertificate(m_SignParameters.signatureInfo.certificate);
            //byte[] crlData = GetFileBytes(crlUrl);
            //AddCompleteRevocationReference(crlData,crlUrl);
            //Logger.Instance().Info("Before xades X.");
            ////Xades X
            //if (m_SignParameters.timeStamped && !string.IsNullOrEmpty(m_SignParameters.signatureInfo.TimeStampURL))
            //    AddSignAndRefsTimestamp(m_SignParameters.signatureInfo.TimeStampURL);
            //Logger.Instance().Info("Before xades XL.");
            ////Xades XL
            //AddCertificateValues();
            //if(crlData!=null)
            //    AddRevocationValues(crlData);

            //Logger.Instance().Info("After adding xades.");
            CryptoContentInfo<byte[]> content;
            //if (this.envelopedSignatureXmlDocument != null)
            //{
            //    this.envelopedSignatureXmlDocument.DocumentElement.AppendChild(this.envelopedSignatureXmlDocument.ImportNode(this.xadesSignedXml.GetXml(), true));
            //    content = new CryptoContentInfo<byte[]>(System.Text.Encoding.UTF8.GetBytes(this.envelopedSignatureXmlDocument.OuterXml));
            //}
            //else
            if(m_SignParameters.detached)
                content = new CryptoContentInfo<byte[]>(GetAsPackage(System.Text.Encoding.UTF8.GetBytes(xadesSignedXml.GetXml().OuterXml), objectToSign, signingParameters.signatureInfo.fileName));
            else
                content = new CryptoContentInfo<byte[]>(System.Text.Encoding.UTF8.GetBytes(xadesSignedXml.GetXml().OuterXml));
            content.originalContent = objectToSign;
            content.originalFileName = signingParameters.signatureInfo.fileName;
            CryptoSignedObject<byte[]> retVal = new CryptoSignedObject<byte[]>(content, ProviderFriendlyName);
            retVal.SdkVersion = Constants.SDKVersion;
            retVal.AppVersion = Constants.AppVersion;
            retVal.signatureInfos.Add(signingParameters.signatureInfo);
            return retVal;
        }


        /// <summary>
        /// Verify the signature depending on the paramaters
        /// </summary>
        /// <param name="signedObject">the signed content</param>
        /// <param name="verifyParametersInfo">verify params</param>
        /// <returns>all the data about the signature and the original file</returns>
        public CryptoSignedObject<byte[]> VerifySignature(byte[] signedObject, VerifyParameters verifyParametersInfo)
        {
            //Initialize the object to return
            CryptoContentInfo<byte[]> content = new CryptoContentInfo<byte[]>(signedObject);
            CryptoSignedObject<byte[]> retVal = new CryptoSignedObject<byte[]>(content, ProviderFriendlyName);

            //check if its an enveloping signature
            XmlDocument xmlDoc = IsXml(signedObject);
            //enveloping
            if (xmlDoc != null)
            {
                if (!IsSignatureXml(xmlDoc))
                    throw new ApplicationException(XadesProvider.Lang.ErrorMessages.WrongFile);
                else
                {
                    retVal.detached = false;
                    CryptoSignatureInfo info = GetCryptoSignatureInfo(xmlDoc, verifyParametersInfo, null);
                    if (info != null)
                    {
                        retVal.signatureInfos.Add(info);
                        if (this.xadesSignedXml.OriginalData != null)
                        {
                            XmlNodeList xmlOrginialData = this.xadesSignedXml.OriginalData.Data;
                            StringBuilder xmlString = new StringBuilder(xmlOrginialData.Count);
                            foreach (XmlNode originalNode in xmlOrginialData)
                                xmlString.Append(originalNode.OuterXml);
                            retVal.ContentInfo.originalContent = UTF8Encoding.UTF8.GetBytes(xmlString.ToString());
                        }

                    }
                }
            }
            //detached
            else
            {
                retVal.detached = true;
                //Extract files and create hierarchy
                List<CryptoExtractedEntry> extractedFiles = ExtractPackage(signedObject);

                //check signature for each signature file
                foreach (CryptoExtractedEntry current in extractedFiles.FindAll(e => e.ParentFile != null))
                {
                    xmlDoc = IsXml(current.DataBytes);

                    CryptoExtractedEntry original = original = extractedFiles.Find(e => e.FileName.Equals(current.ParentFile));

                    CryptoSignatureInfo info = GetCryptoSignatureInfo(xmlDoc, verifyParametersInfo, original);
                    if (info != null)
                    {
                        retVal.signatureInfos.Add(info);

                        if (current.ChildFile == null)
                        {
                            retVal.ContentInfo.originalContent = original.DataBytes;
                            string[] description = GetDescriptionData(xmlDoc);
                            if (description != null && description.Length > 2)
                            {
                                retVal.ContentInfo.originalFileName = description[0];
                                retVal.SdkVersion = description[1];
                                retVal.AppVersion = description[2];
                            }

                        }

                    }
                }
            }
            if(retVal.signatureInfos.Count==0)
                throw new ApplicationException(XadesProvider.Lang.ErrorMessages.WrongFile);
            return retVal;

        }

       
        private void SetChilds(List<CryptoExtractedEntry> extractedFiles)
        {
            foreach (CryptoExtractedEntry currentFile in extractedFiles.FindAll(e=>e.ParentFile!=null))
            {
                foreach(CryptoExtractedEntry parent in extractedFiles.FindAll(e=>e.FileName.Equals(currentFile.ParentFile)))
                    parent.ChildFile=currentFile.FileName;
            }
        }

        private  List<CryptoExtractedEntry> ExtractPackage(byte[] signedObject)
        {
            XmlDocument tempDoc;
            List<CryptoExtractedEntry> extractedFiles;
            //if its a zip file
            try
            {
                SignVerify.Common.Utils.ZipProvider zipper = new SignVerify.Common.Utils.ZipProvider();
                extractedFiles = zipper.extractFromPackage(signedObject);
            }
            catch
            {
                throw new ApplicationException(XadesProvider.Lang.ErrorMessages.WrongFile);
            }
            foreach (CryptoExtractedEntry file in extractedFiles)
            {
                try
                {
                    tempDoc = Common.Utils.XmlHelper.LoadXmlFromBytes(file.DataBytes);
                    if (IsSignatureXml(tempDoc))
                        file.ParentFile = GetParentFileName(tempDoc);
                    else
                        file.ParentFile = null;
                }
                catch
                {
                    file.ParentFile = null;
                    continue;
                }

            }

            SetChilds(extractedFiles);
            return extractedFiles;
        }

        private string GetParentFileName(XmlDocument tempDoc)
        {
            
            foreach (XmlElement element in tempDoc.GetElementsByTagName("ds:Reference"))
            {
                if(element.Attributes["URI"]!=null && !element.Attributes["URI"].Value.StartsWith("#"))
                    return element.Attributes["URI"].Value;
                       
            }
            return "";
              
        }

        private string[] GetDescriptionData(XmlDocument xmlDoc)
        {
            XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(xmlDoc.NameTable);
            xmlNamespaceManager.AddNamespace("ds", SignedXml.XmlDsigNamespaceUrl);
            xmlNamespaceManager.AddNamespace("xsd", XadesSignedXml.XadesNamespaceUri);
            XmlNode descriptionNode = xmlDoc.SelectSingleNode(Constants.DescriptionXpath, xmlNamespaceManager);
            if (descriptionNode != null)
                return descriptionNode.InnerText.Split(';');
            return null;
        }
       
        //private string ExtractFromPackage(byte[] signedObject)
        //{
        //    string destination = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        //    Directory.CreateDirectory(destination);
        //    SignVerify.Common.Utils.ZipProvider zipper = new SignVerify.Common.Utils.ZipProvider();
        //    MemoryStream ms=new MemoryStream(signedObject);
        //    zipper.extractFiles(ms, destination);
        //    return destination;            
        //}


        public string ProviderFriendlyName
        {
            get { return Constants.providerFriendlyName; }
        }

        #endregion

        #region Archive

        //private CryptoSignedObject<byte[]> Archive(CryptoSignedObject<byte[]> signedObject)
        //{
        //    X509Certificate2 certificate = signedObject.signatureInfos[0].certificate;
        //    ////Xades C
        //    if (this.Chain == null)
        //        CreateChain(certificate);
        //    AddCompleteCertificateReferences(this.Chain, certificate);
        //    string crlUrl = GetCrlUrlFromCertificate(certificate);
        //    byte[] crlData = GetFileBytes(crlUrl);
        //    AddCompleteRevocationReference(crlData, crlUrl);
        //    Logger.Instance().Info("Before xades X.");
        //    ////Xades X
        //    if (signedObject.timeStamped && !string.IsNullOrEmpty(signedObject.signatureInfos[0].TimeStampURL))
        //        AddSignAndRefsTimestamp(signedObject.signatureInfos[0].TimeStampURL);
        //    Logger.Instance().Info("Before xades XL.");
        //    ////Xades XL
        //    AddCertificateValues();
        //    if (crlData != null)
        //        AddRevocationValues(crlData);

        //    Logger.Instance().Info("After adding xades.");
        //    CryptoContentInfo<byte[]> content = new CryptoContentInfo<byte[]>(GetAsPackage(System.Text.Encoding.UTF8.GetBytes(xadesSignedXml.GetXml().OuterXml), signedObject.ContentInfo.originalContent, signedObject.ContentInfo.originalFileName));
        //    content.originalContent = signedObject.ContentInfo.originalContent;
        //    content.originalFileName = signedObject.ContentInfo.originalFileName;
        //    CryptoSignedObject<byte[]> retVal = new CryptoSignedObject<byte[]>(content, ProviderFriendlyName);
        //    retVal.SdkVersion = "";
        //    retVal.AppVersion = "";
        //    retVal.signatureInfos.AddRange(signedObject.signatureInfos);
        //    return retVal;
        //}

        //private static void ReadyToArchive(VerifyParameters verifyParametersInfo, CryptoSignedObject<byte[]> signedObject)
        //{
        //    if (signedObject.signatureInfos.Count == 0)
        //    {
        //        Logger.Instance().Info("The file don't contains signature info to archive with");
        //        throw new ApplicationException(XadesProvider.Lang.ErrorMessages.NotContainingSignatureInfo);
        //    }
        //    else
        //    {
        //        foreach (var signature in signedObject.signatureInfos)
        //        {
        //            if (signature.EndSignatureState != EndSignatureStateType.Valid)
        //            {
        //                Logger.Instance().Info("The file contains a " + signature.EndSignatureState + " signature we can't archive it");
        //                throw new ApplicationException(XadesProvider.Lang.ErrorMessages.VerifyFailed);
        //            }
        //            if (verifyParametersInfo.CheckTrustChain && signature.ChainSignatureState != ChainSignatureStateType.Valid)
        //            {
        //                Logger.Instance().Info("The file contains a  " + signature.ChainSignatureState + " ChainSignatureState we can't archive it");
        //                throw new ApplicationException(XadesProvider.Lang.ErrorMessages.VerifyFailed);
        //            }
        //            if (verifyParametersInfo.checkCRL && signature.CRLstate != CRLSignatureStateType.Valid)
        //            {
        //                Logger.Instance().Info("The file contains a  " + signature.ChainSignatureState + " CRLSignatureStateType we can't archive it");
        //                throw new ApplicationException(XadesProvider.Lang.ErrorMessages.VerifyFailed);
        //            }
        //            //if(signature.TimeStampState
        //        }
        //    }
        //}


        //public CryptoSignedObject<byte[]> VerifyAndArchive(byte[] signedData, VerifyParameters verifyParametersInfo)
        //{
        //    CryptoSignedObject<byte[]> signedObject = VerifySignature(signedData, verifyParametersInfo);

        //    ReadyToArchive(verifyParametersInfo, signedObject);

        //    return Archive(signedObject);

        //}

        #endregion

        #region Helper functions

        private XmlDocument IsXml(byte[] objectToSign)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                //XML encoding 
                using (MemoryStream ms = new MemoryStream(objectToSign))
                {
                    ms.Position = 0;
                    StreamReader reader = new StreamReader(ms);
                    doc.LoadXml(reader.ReadToEnd());
                    if (doc.FirstChild.NodeType == XmlNodeType.XmlDeclaration)
                    {
                        doc.RemoveChild(doc.FirstChild);
                    }
                }
                return doc;
            }
            catch
            { return null; }
        }
        private byte[] GetAsPackage(byte[] signatureBytes, byte[] objectToSign, string filePath)
        {

            ArrayList fileNames = new ArrayList();

            string fileName = Path.GetFileName(filePath);
            fileNames.Add(fileName);
            if (!fileName.EndsWith(".xml"))
                fileNames.Add(Path.ChangeExtension(fileName, ".xml"));
            else
                fileNames.Add(Path.GetFileNameWithoutExtension(fileName) + Constants.EndFileName);

            ArrayList fileBytes = new ArrayList();
            fileBytes.Add(objectToSign);
            fileBytes.Add(signatureBytes);
            SignVerify.Common.Utils.ZipProvider Zipper = new SignVerify.Common.Utils.ZipProvider();
            MemoryStream ms = new MemoryStream();
            Zipper.archivesFiles(ms, fileNames, fileBytes);
            return ms.ToArray();
        }

        private void CheckIfParametersMissing(byte[] objectToSign, SignParameters signingParameters)
        {
            if (objectToSign == null || signingParameters == null
                || signingParameters.signatureInfo == null || signingParameters.signatureInfo.certificate == null)
                throw new ApplicationException(XadesProvider.Lang.ErrorMessages.ParametersMissing);
        }

        private string GetNewID()
        {
            return "il-" + Guid.NewGuid().ToString();
        }

        private XmlNamespaceManager GetNamespaceManager(XmlDocument doc)
        {
            XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(doc.NameTable);
            xmlNamespaceManager.AddNamespace("xsd", XadesSignedXml.XadesNamespaceUri);
            xmlNamespaceManager.AddNamespace("ds", SignedXml.XmlDsigNamespaceUrl);
            return xmlNamespaceManager;
        }
        #endregion

        #region CRL Helper
        private string GetCrlUrlFromCertificate(X509Certificate2 x509Certificate2)
        {
            byte[] extension_bytes = x509Certificate2.RawData;
            System.Security.Cryptography.AsnEncodedData asndata = new System.Security.Cryptography.AsnEncodedData(extension_bytes);
            //X509ExtensionCollection extcollec = x509Certificate2.Extensions;
            string crl_point = Encoding.UTF8.GetString(extension_bytes);
            int index1 = crl_point.IndexOf("http");
            int index2 = crl_point.IndexOf(".crl") + 4;
            char[] url_a = new char[index2 - index1];
            crl_point.CopyTo(index1, url_a, 0, index2 - index1);
            return new string(url_a);
        }

        private byte[] GetFileBytes(string crlUrl)
        {
            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                byte[] crlBytes = client.DownloadData(crlUrl);
                return crlBytes;
            }
        }

        //private byte[] GetFileBytes(Stream stream)
        //{
        //    long originalPosition = 0;

        //    if (stream.CanSeek)
        //    {
        //        originalPosition = stream.Position;
        //        stream.Position = 0;
        //    }

        //    try
        //    {
        //        byte[] readBuffer = new byte[4096];

        //        int totalBytesRead = 0;
        //        int bytesRead;

        //        while ((bytesRead = stream.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0)
        //        {
        //            totalBytesRead += bytesRead;

        //            if (totalBytesRead == readBuffer.Length)
        //            {
        //                int nextByte = stream.ReadByte();
        //                if (nextByte != -1)
        //                {
        //                    byte[] temp = new byte[readBuffer.Length * 2];
        //                    Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
        //                    Buffer.SetByte(temp, totalBytesRead, (byte)nextByte);
        //                    readBuffer = temp;
        //                    totalBytesRead++;
        //                }
        //            }
        //        }

        //        byte[] buffer = readBuffer;
        //        if (readBuffer.Length != totalBytesRead)
        //        {
        //            buffer = new byte[totalBytesRead];
        //            Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytesRead);
        //        }
        //        return buffer;
        //    }
        //    finally
        //    {
        //        if (stream.CanSeek)
        //        {
        //            stream.Position = originalPosition;
        //        }
        //    }
        //}

        //private Stream GetCrlStream(string crlUrl)
        //{
        //    using (System.Net.WebClient client = new System.Net.WebClient())
        //    {
        //        Stream myStream = client.OpenRead(crlUrl);
        //        return myStream;
        //    }
        //}
        #endregion


        #region Xades Element functions

        #region Xades-XL
        private void AddRevocationValues(byte[] crlData)
        {
            UnsignedProperties unsignedProperties = this.xadesSignedXml.UnsignedProperties;
            unsignedProperties.UnsignedSignatureProperties.RevocationValues = new RevocationValues();
            RevocationValues revocationValues = unsignedProperties.UnsignedSignatureProperties.RevocationValues;
            revocationValues.Id = GetNewID();
            CRLValue newCRLValue = new CRLValue();
            newCRLValue.PkiData = crlData;
            revocationValues.CRLValues.CRLValueCollection.Add(newCRLValue);
            this.xadesSignedXml.UnsignedProperties = unsignedProperties;
        }

        private void AddCertificateValues()
        {
            if (this.Chain != null)
            {
                UnsignedProperties unsignedProperties = this.xadesSignedXml.UnsignedProperties;
                unsignedProperties.UnsignedSignatureProperties.CertificateValues = new CertificateValues();
                CertificateValues certificateValues = unsignedProperties.UnsignedSignatureProperties.CertificateValues;
                certificateValues.Id = GetNewID();

                EncapsulatedX509Certificate encapsulatedX509Certificate;
                foreach (X509ChainElement element in this.Chain.ChainElements)
                {
                    encapsulatedX509Certificate = new EncapsulatedX509Certificate();
                    encapsulatedX509Certificate.Id = GetNewID();
                    encapsulatedX509Certificate.PkiData = element.Certificate.GetRawCertData();
                    certificateValues.EncapsulatedX509CertificateCollection.Add(encapsulatedX509Certificate);
                }

                this.xadesSignedXml.UnsignedProperties = unsignedProperties;
            }
            else
            {
                throw new Exception(XadesProvider.Lang.ErrorMessages.CertificateChainError);
            }
        }
        #endregion


        #region Xades-X

        private void AddSignAndRefsTimestamp(string timeStampUrl)
        {
            ArrayList signatureValueElementXpaths = new ArrayList();
            signatureValueElementXpaths.Add(Constants.SignatureValueTag);
            signatureValueElementXpaths.Add(Constants.EncapsulatedXpath);
            signatureValueElementXpaths.Add(Constants.CompleteCertificatesRefsXpath);
            signatureValueElementXpaths.Add(Constants.CompleteRevocationRefsXpath);
            ArrayList elementIdValues = new ArrayList();
            byte[] originalData;
            byte[] signatureValueHash = SignVerify.Xades.XadesHelper.ComputeHashValueOfElementList(this.xadesSignedXml.GetXml(), signatureValueElementXpaths, ref elementIdValues, out originalData);
            TimeStampResponse timestampResponse = GetTimeStampResponse(originalData, signatureValueHash, timeStampUrl);
            if (timestampResponse.ValidationResult.ResponseStatus == TimeStampResponseStatus.Granted && timestampResponse.ValidationResult.ValidationErrors.Count == 0)
            {
                TimeStamp xadesXTimeStamp = new TimeStamp(Constants.XadesTimeStampID);
                xadesXTimeStamp.EncapsulatedTimeStamp.PkiData = timestampResponse.Data.DataBytes;
                xadesXTimeStamp.EncapsulatedTimeStamp.Id = GetNewID();

                HashDataInfo hashDataInfo;
                foreach (string elementIdValue in elementIdValues)
                {
                    hashDataInfo = new HashDataInfo();
                    hashDataInfo.UriAttribute = "#" + elementIdValue;
                    xadesXTimeStamp.HashDataInfoCollection.Add(hashDataInfo);
                }
                UnsignedProperties unsignedProperties = this.xadesSignedXml.UnsignedProperties;
                unsignedProperties.UnsignedSignatureProperties.RefsOnlyTimeStampFlag = false;
                unsignedProperties.UnsignedSignatureProperties.SigAndRefsTimeStampCollection.Add(xadesXTimeStamp);

                this.xadesSignedXml.UnsignedProperties = unsignedProperties;
            }

        }

        #endregion
        #region Xades-C
        private void AddCompleteCertificateReferences(X509Chain m_Chain, X509Certificate2 certificate)
        {
            if (m_Chain != null)
            {
                UnsignedProperties unsignedProperties = this.xadesSignedXml.UnsignedProperties;
                unsignedProperties.UnsignedSignatureProperties.CompleteCertificateRefs = new CompleteCertificateRefs();
                Cert chainCert;
                foreach (X509ChainElement element in m_Chain.ChainElements)
                {
                    chainCert = new Cert();
                    chainCert.IssuerSerial.X509IssuerName = element.Certificate.IssuerName.Name;
                    chainCert.IssuerSerial.X509SerialNumber = element.Certificate.SerialNumber;
                    chainCert.CertDigest.DigestMethod.Algorithm = SignedXml.XmlDsigSHA1Url;
                    chainCert.CertDigest.DigestValue = certificate.GetCertHash();
                    unsignedProperties.UnsignedSignatureProperties.CompleteCertificateRefs.Id = GetNewID();
                    unsignedProperties.UnsignedSignatureProperties.CompleteCertificateRefs.CertRefs.CertCollection.Add(chainCert);
                }

                this.xadesSignedXml.UnsignedProperties = unsignedProperties;
            }
        }

        private void AddCompleteRevocationReference(byte[] crlBytes, string crlUrl)
        {

            SHA1Managed sha1Managed = new SHA1Managed();
            byte[] crlDigest = sha1Managed.ComputeHash(crlBytes);

            CRLRef incCRLRef = new CRLRef();
            incCRLRef.CertDigest.DigestMethod.Algorithm = SignedXml.XmlDsigSHA1Url;
            incCRLRef.CertDigest.DigestValue = crlDigest;
            incCRLRef.CRLIdentifier.UriAttribute = crlUrl;

            Asn1Parser asn1Parser;
            asn1Parser = new Asn1Parser();
            asn1Parser.ParseAsn1(crlBytes);
            XmlNode searchXmlNode;
            searchXmlNode = asn1Parser.ParseTree.SelectSingleNode(Constants.AnsiUniversalPrimitive);
            if (searchXmlNode != null)
            {
                incCRLRef.CRLIdentifier.Issuer = searchXmlNode.Attributes["Value"].Value;
            }
            else
            {
                throw new Exception("Parse error TSA response: can't find Issuer in CRL");
            }
            searchXmlNode = asn1Parser.ParseTree.SelectSingleNode(Constants.AnsiUtc);
            if (searchXmlNode != null)
            {
                incCRLRef.CRLIdentifier.IssueTime = DateTime.Parse(searchXmlNode.Attributes["Value"].Value);
            }
            else
            {
                throw new Exception("Parse error TSA response: can't find IssueTime in CRL");
            }

            UnsignedProperties unsignedProperties = this.xadesSignedXml.UnsignedProperties;
            unsignedProperties.UnsignedSignatureProperties.CompleteRevocationRefs = new CompleteRevocationRefs();
            unsignedProperties.UnsignedSignatureProperties.CompleteRevocationRefs.Id = GetNewID();
            unsignedProperties.UnsignedSignatureProperties.CompleteRevocationRefs.CRLRefs.CRLRefCollection.Add(incCRLRef);
            this.xadesSignedXml.UnsignedProperties = unsignedProperties;
        }
        #endregion

        #region Xades-T
        private void AddTimeStampToSignature(string timeStampUrl)
        {
            ArrayList signatureValueElementXpaths = new ArrayList();
            signatureValueElementXpaths.Add(".");
            ArrayList elementIdValues = new ArrayList();
            XmlElement element = xadesSignedXml.GetXml();
            byte[] originalMessage;
            byte[] signatureValueHash = SignVerify.Xades.XadesHelper.ComputeHashValueOfElementList(element, signatureValueElementXpaths, ref elementIdValues, out originalMessage);
            TimeStampResponse timestampResponse = GetTimeStampResponse(originalMessage, signatureValueHash, timeStampUrl);
            if (timestampResponse.ValidationResult.ResponseStatus == TimeStampResponseStatus.Granted && timestampResponse.ValidationResult.ValidationErrors.Count == 0)
            {
                TimeStamp signatureTimeStamp = new TimeStamp(Constants.SignatureTimeStampID);
                signatureTimeStamp.EncapsulatedTimeStamp.Id = GetNewID();
                signatureTimeStamp.EncapsulatedTimeStamp.PkiData = timestampResponse.Data.DataBytes;
                HashDataInfo hashDataInfo = new HashDataInfo();
                hashDataInfo.UriAttribute = "#" + xadesSignedXml.SignatureValueId;
                signatureTimeStamp.HashDataInfoCollection.Add(hashDataInfo);
                UnsignedProperties unsignedProperties = this.xadesSignedXml.UnsignedProperties;
                unsignedProperties.UnsignedSignatureProperties.SignatureTimeStampCollection.Add(signatureTimeStamp);
                this.xadesSignedXml.UnsignedProperties = unsignedProperties;
            }

        }
        private TimeStampResponse GetTimeStampResponse(byte[] OriginalMessage, byte[] signatureValueHash, string tsUrl)
        {
            TimeStampRequest req = new TimeStampRequest(signatureValueHash);
            TimeStampResponse resp = req.GetResponse(tsUrl);
            resp.Validate(OriginalMessage, req.Nonce);
            return resp;
        }

        private void SetTimeStampState(CryptoSignatureInfo item)
        {
            if (this.xadesSignedXml.UnsignedProperties.UnsignedSignatureProperties.SignatureTimeStampCollection.Count > 0)
            {
                TimeStampResponseData response = new TimeStampResponseData(this.xadesSignedXml.UnsignedProperties.UnsignedSignatureProperties.SignatureTimeStampCollection[0].EncapsulatedTimeStamp.PkiData);

                byte[] originalMessage = GetSignature();
                item.TimeStampState = response.Validate(originalMessage, Guid.Empty);
                item.TimeStamp = response.TimeStamp;
                item.TimeStampCertificate = response.Certificate;
            }
        }
        private byte[] GetSignature()
        {
            ArrayList signatureValueElementXpaths = new ArrayList();
            signatureValueElementXpaths.Add(".");
            ArrayList elementIdValues = new ArrayList();
            XmlElement element = xadesSignedXml.GetXml();
            byte[] originalMessage;
            byte[] signatureValueHash = SignVerify.Xades.XadesHelper.ComputeHashValueOfElementList(element, signatureValueElementXpaths, ref elementIdValues, out originalMessage);
            return originalMessage;
        }
        #endregion

        #region XADES EPES

        private void CreateXadesObject(DataObjectFormat newDataObjectFormat)
        {
            this.xadesSignedXml.Signature.Id = Constants.SignatureObjectID; //GetNewID();
            XadesObject xadesObject = new XadesObject();
            xadesObject.Id = Constants.XadesObjectID;// GetNewID();
            xadesObject.QualifyingProperties.Target = "#" + this.xadesSignedXml.Signature.Id;
            this.AddSignedSignatureProperties(
                xadesObject.QualifyingProperties.SignedProperties.SignedSignatureProperties,
                xadesObject.QualifyingProperties.SignedProperties.SignedDataObjectProperties,
                newDataObjectFormat);
            this.xadesSignedXml.AddXadesObject(xadesObject);
        }

        private void AddSignedSignatureProperties(SignedSignatureProperties signedSignatureProperties, SignedDataObjectProperties signedDataObjectProperties, DataObjectFormat newDataObjectFormat)
        {

            Cert cert;

            cert = new Cert();
            cert.IssuerSerial.X509IssuerName = this.m_SignParameters.signatureInfo.certificate.IssuerName.Name;
            cert.IssuerSerial.X509SerialNumber = this.m_SignParameters.signatureInfo.certificate.SerialNumber;
            cert.CertDigest.DigestMethod.Algorithm = SignedXml.XmlDsigSHA1Url;
            cert.CertDigest.DigestValue = this.m_SignParameters.signatureInfo.certificate.GetCertHash();

            signedSignatureProperties.SigningCertificate.CertCollection.Add(cert);
            signedSignatureProperties.SigningTime = DateTime.Now;
            signedSignatureProperties.SignaturePolicyIdentifier.SignaturePolicyImplied = true;
            signedDataObjectProperties.DataObjectFormatCollection.Add(newDataObjectFormat);


        }

        private void AddCertificate(X509Certificate2 certificate)
        {
            CreateChain(certificate);
            this.AddCertificateInfoToSignature();
            //else
            //{
            //    Logger.Instance().Info("Enable to create the chain of the certificate.");
            //    throw new ApplicationException(XadesProvider.Lang.ErrorMessages.CertificateChainError);
            //}
        }

        private bool CreateChain(X509Certificate2 certificate)
        {
            this.Chain = new X509Chain();

            this.Chain.ChainPolicy.RevocationFlag = X509RevocationFlag.EntireChain;
            this.Chain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
            this.Chain.ChainPolicy.UrlRetrievalTimeout = new TimeSpan(0, 0, 30);
            this.Chain.ChainPolicy.VerificationFlags = X509VerificationFlags.NoFlag;

            if (this.Chain.Build(certificate) != true)
            {
                this.Chain = null;
                return false;
            }
            return true;
        }

        private void AddCertificateInfoToSignature()
        {
            KeyInfo keyInfo = new KeyInfo();
            keyInfo.AddClause(new KeyInfoX509Data((X509Certificate)this.m_SignParameters.signatureInfo.certificate));

            //if (this.m_SignParameters.signatureInfo.certificate.HasPrivateKey)
            //{
            //    RSACryptoServiceProvider rsaKey = (RSACryptoServiceProvider)this.m_SignParameters.signatureInfo.certificate.PrivateKey;
            //    keyInfo.AddClause(new RSAKeyValue(rsaKey));
            //    this.xadesSignedXml.SigningKey = rsaKey;
            //}
            //else
            //{
            //    RSACryptoServiceProvider rsaEncryptDecrypt = new RSACryptoServiceProvider();

            //    RSAParameters RSAKeyInfo = rsaEncryptDecrypt.ExportParameters(false);
            //    RSAKeyInfo.Modulus = this.m_SignParameters.signatureInfo.certificate.GetPublicKey();
                
                
            //}
            this.xadesSignedXml.KeyInfo = keyInfo;
        }

        private DataObjectFormat CreateReferenceToObject(bool newDocument, byte[] objectToSign, string fileName, string appName)
        {

            Reference reference = new Reference();
            reference.DigestMethod = Constants.DigestMethodSha256;

            DataObjectFormat newDataObjectFormat = new DataObjectFormat();
            newDataObjectFormat.Description = GetDescription(Path.GetFileName(fileName), appName);


            // if (m_SignParameters.detached)
            //{
            XmlDocument doc = IsXml(objectToSign);
            if (newDocument)
            {
                this.xadesSignedXml = new XadesSignedXml();

                this.documentDataObjectCounter = 1;
            }
            if (doc!=null)
            {
                DataObject dataObject = new DataObject();
                
                //XmlDocument doc = GetXmlDoc(objectToSign, newDataObjectFormat);
                //dataObject.MimeType = "text/xml";
                dataObject.Data = doc.ChildNodes;
                dataObject.Id = Constants.OriginalData;
                this.xadesSignedXml.OriginalData = dataObject;

                newDataObjectFormat.ObjectReferenceAttribute = "#" + dataObject.Id;

                reference.Uri = "#" + dataObject.Id;
                reference.Type = SignedXml.XmlDsigNamespaceUrl + "Object";

                m_SignParameters.detached = false;
            }
            else
            {
                if (string.IsNullOrEmpty(fileName))
                {
                    throw new ApplicationException(XadesProvider.Lang.ErrorMessages.FileNameMissing);
                }
                // reference.Uri = m_SignParameters.signatureInfo.fileName;
                reference.Uri = Path.GetFileName(fileName);
                //if (reference.Uri.EndsWith(".xml") || reference.Uri.EndsWith(".XML"))
                //{
                //    reference.AddTransform(new XmlDsigC14NTransform());
                //}

                newDataObjectFormat.ObjectReferenceAttribute = fileName;
                m_SignParameters.detached = true;
            }

            //  else
            //{

            //    DataObject dataObject = new DataObject();
            //    if (m_SignParameters.enveloping)
            //    {
            //        if (newDocument)
            //        {
            //            this.xadesSignedXml = new XadesSignedXml();
            //            this.documentDataObjectCounter = 1;
            //        }

            //        XmlDocument doc = GetXmlDoc(objectToSign, newDataObjectFormat);
            //        //dataObject.MimeType = "text/xml";
            //        dataObject.Data = doc.ChildNodes;
            //        dataObject.Id = GetNewID();
            //        newDataObjectFormat.ObjectReferenceAttribute = "#" + dataObject.Id;
            //        reference.Uri = "#" + dataObject.Id;
            //        reference.Type = SignedXml.XmlDsigNamespaceUrl + "Object";
            //        this.xadesSignedXml.AddObject(dataObject);

            //    }
            //    else
            //    {
            //        this.envelopedSignatureXmlDocument = GetXmlDoc(objectToSign, newDataObjectFormat);
            //        this.xadesSignedXml = new XadesSignedXml(this.envelopedSignatureXmlDocument);
            //        reference.Uri = "";
            //        XmlDsigC14NTransform xmlDsigC14NTransform = new XmlDsigC14NTransform();
            //        reference.AddTransform(xmlDsigC14NTransform);
            //        XmlDsigEnvelopedSignatureTransform xmlDsigEnvelopedSignatureTransform = new XmlDsigEnvelopedSignatureTransform();
            //        reference.AddTransform(xmlDsigEnvelopedSignatureTransform);
            //    }
            //}
            this.xadesSignedXml.AddReference(reference);
            this.documentDataObjectCounter++;
            return newDataObjectFormat;
        }

        private string GetDescription(string fileName, string appName)
        {
            return string.Format("{0};{1};{2};{3}", fileName, Constants.SDKVersion, Constants.AppVersion, appName.Replace(";", ""));
        }
        private Dictionary<string, string> GetDescriptionData(string description)
        {
            string[] data = description.Split(';');
            Dictionary<string, string> retVal = new Dictionary<string, string>();
            if (data.Length == 4)
            {
                retVal.Add("FileName", data[0]);
                retVal.Add("Version", data[1]);
                retVal.Add("AppVersion", data[2]);
                retVal.Add("AppName", data[3]);
            }
            return retVal;
        }
        #endregion

        //private XmlDocument GetXmlDoc(byte[] objectToSign, DataObjectFormat p_newDataObjectFormat)
        //{
        //    XmlDocument doc = new XmlDocument();
        //    doc.PreserveWhitespace = true;

        //    try
        //    {
        //        //XML encoding 
        //        using (MemoryStream ms = new MemoryStream(objectToSign))
        //        {
        //            ms.Position = 0;
        //            StreamReader reader = new StreamReader(ms);
        //            doc.LoadXml(reader.ReadToEnd());
        //            if (doc.FirstChild.NodeType == XmlNodeType.XmlDeclaration)
        //            {
        //                doc.RemoveChild(doc.FirstChild);
        //            }
        //            p_newDataObjectFormat.MimeType = Constants.XmlMimeType;

        //        }

        //    }
        //    catch
        //    {
        //        //BASE64 encoding
        //        p_newDataObjectFormat.MimeType = Constants.Base64MimeType ;
        //        doc.LoadXml(string.Format("<Data>{0}</Data>", Convert.ToBase64String(objectToSign)));
        //    }
        //    return doc;
        //}

        #endregion




        #region Verify functions

        private CryptoSignatureInfo GetCryptoSignatureInfo(XmlDocument xmlDocument, VerifyParameters verifyParametersInfo, CryptoExtractedEntry signedEntry)
        {
            XmlNodeList signatureNodeList = xmlDocument.GetElementsByTagName(Constants.Signature,SignedXml.XmlDsigNamespaceUrl);
            if (signatureNodeList.Count == 0)
            {
                signatureNodeList = xmlDocument.GetElementsByTagName(Constants.Signature);
            }
            if (signatureNodeList.Count == 0)
            {
                return null;
            }
            else
            {
                string dataID = string.Empty;

                if (verifyParametersInfo == null)
                {
                    verifyParametersInfo = new VerifyParameters();
                }
                Logger.Instance().Info("Start getCryptoSignedObject");

                this.xadesSignedXml = new XadesSignedXml(xmlDocument.DocumentElement);
                this.xadesSignedXml.LoadXml((XmlElement)signatureNodeList[0]);
                if (signatureNodeList.Count == 1)
                    return GetSignatureInfoFromSigner(verifyParametersInfo, signedEntry);
                else
                    return null;

            }

        }

        private CryptoSignatureInfo GetSignatureInfoFromSigner(VerifyParameters verifyParametersInfo, CryptoExtractedEntry signedEntry)
        {
            X509Certificate2 certificate = new X509Certificate2(System.Text.Encoding.ASCII.GetBytes(this.xadesSignedXml.KeyInfo.GetXml().InnerText));
            CryptoSignatureInfo retVal = new CryptoSignatureInfo(certificate);
            retVal.SignatureStandard = SignatureStandard.xades;
            retVal.id = this.xadesSignedXml.Signature.Id;
            //verify that there is no changes and that the signature is from the key info
            if (!this.xadesSignedXml.CheckSignature(signedEntry))//checkXmlDsigsignature failed !
                retVal.EndSignatureState = EndSignatureStateType.SignatureUnvalid;
            else
            {
                //verify that the certificate is valid
                retVal.EndSignatureState = SignVerify.Common.Certificate.getEndCertificateState(certificate);
                if (retVal.EndSignatureState != EndSignatureStateType.SignatureUnvalid)
                {
                    //verify that the certificate is trusted
                    if (verifyParametersInfo.CheckTrustChain)
                        retVal.ChainSignatureState = SignVerify.Common.Certificate.getCertificateChainState(certificate);
                    //verify that the certificate is not stollen    
                    retVal.CRLstate = SignVerify.Common.Certificate.getCertificateCRLState(certificate, verifyParametersInfo);
                }
                try
                {
                    //verify that the qualifiying properties exist correpond to the signature and point to it
                    if (this.xadesSignedXml.CheckSameCertificate() && this.xadesSignedXml.CheckQualifyingPropertiesTarget() && this.xadesSignedXml.CheckQualifyingProperties())
                        retVal.XadesSignatureState = EndSignatureStateType.Valid;
                    else
                        retVal.XadesSignatureState = EndSignatureStateType.SignatureUnvalid;
                }
                catch (Exception)
                {
                    retVal.XadesSignatureState = EndSignatureStateType.SignatureUnvalid;
                }
                //verify that the timestamp is valid and there is no changes in the signature
                if (this.xadesSignedXml.CheckHashDataInfoOfSignatureTimeStampPointsToSignatureValue())
                    SetTimeStampState(retVal);

            }
            return retVal;
        }





        //private byte[] GetOriginalContent(string mimeType, XmlDocument xmlDocument)
        //{
        //    if (xmlDocument.DocumentElement.Name.Equals(Constants.SigntureTag))
        //    {

        //        foreach (Reference currentReference in this.xadesSignedXml.SignedInfo.References)
        //        {
        //            //Enveloping (the signed file is within the signature)
        //            if (currentReference.Type != null && currentReference.Type.Equals(SignedXml.XmlDsigNamespaceUrl + Constants.Object))
        //            {
        //                foreach (XmlElement element in xmlDocument.GetElementsByTagName(Constants.ObjectTag))
        //                {
        //                    if (element.Attributes["Id"].InnerText.Equals(currentReference.Uri.Substring(1)))
        //                    {
        //                        if (mimeType.Equals(Constants.Base64MimeType))
        //                        {
        //                            return Convert.FromBase64String(element.FirstChild.InnerText);
        //                        }
        //                        else
        //                            return UTF8Encoding.UTF8.GetBytes(element.InnerXml);
        //                    }
        //                }
        //            }
        //            //detached (the signed file is external)
        //            else if (!string.IsNullOrEmpty(currentReference.Uri) && !currentReference.Uri.StartsWith("#"))
        //                return File.ReadAllBytes(currentReference.Uri);
        //        }
        //    }
        //    //enveloped (the signature is within the signed file)
        //    else
        //    {
        //        XmlDocument doc = new XmlDocument(xmlDocument.NameTable);
        //        doc.LoadXml(xmlDocument.OuterXml);
        //        XmlNamespaceManager ns = GetNamespaceManager(doc);
        //        XmlNodeList signatureNodeList = xmlDocument.GetElementsByTagName(Constants.Signature);
        //        if (signatureNodeList.Count == 0)
        //        {
        //            signatureNodeList = xmlDocument.GetElementsByTagName(Constants.Signature, SignedXml.XmlDsigNamespaceUrl);
        //        }
        //        for(int i=signatureNodeList.Count-1;i>=0;i--)
        //            signatureNodeList[i].ParentNode.RemoveChild(signatureNodeList[i]);
        //        if (mimeType.Equals(Constants.Base64MimeType))
        //        {
        //            return Convert.FromBase64String(doc.FirstChild.InnerText);
        //        }
        //        else
        //            return UTF8Encoding.UTF8.GetBytes(doc.OuterXml);
        //    }
        //    return null;
        //}  

        //private XadesCheckSignatureMasks ComposedMask
        //{
        //    get
        //    {
        //        XadesCheckSignatureMasks retVal;

        //        retVal = 0;

        //        //retVal |= XadesCheckSignatureMasks.CheckXmldsigSignature;

        //        //retVal |= XadesCheckSignatureMasks.ValidateAgainstSchema;

        //       // retVal |= XadesCheckSignatureMasks.CheckSameCertificate;

        //        retVal |= XadesCheckSignatureMasks.CheckAllReferencesExistInAllDataObjectsTimeStamp;

        //        retVal |= XadesCheckSignatureMasks.CheckAllHashDataInfosInIndividualDataObjectsTimeStamp;

        //        //retVal |= XadesCheckSignatureMasks.CheckCounterSignatures;

        //        //retVal |= XadesCheckSignatureMasks.CheckCounterSignaturesReference;

        //       // retVal |= XadesCheckSignatureMasks.CheckObjectReferencesInCommitmentTypeIndication;

        //       // retVal |= XadesCheckSignatureMasks.CheckIfClaimedRolesOrCertifiedRolesPresentInSignerRole;

        //        retVal |= XadesCheckSignatureMasks.CheckHashDataInfoOfSignatureTimeStampPointsToSignatureValue;

        //       // retVal |= XadesCheckSignatureMasks.CheckQualifyingPropertiesTarget;

        //       // retVal |= XadesCheckSignatureMasks.CheckQualifyingProperties;

        //      //  retVal |= XadesCheckSignatureMasks.CheckSigAndRefsTimeStampHashDataInfos;

        //       // retVal |= XadesCheckSignatureMasks.CheckRefsOnlyTimeStampHashDataInfos;

        //      //  retVal |= XadesCheckSignatureMasks.CheckArchiveTimeStampHashDataInfos;

        //      //  retVal |= XadesCheckSignatureMasks.CheckXadesCIsXadesT;

        //      //  retVal |= XadesCheckSignatureMasks.CheckXadesXLIsXadesX;

        //     //   retVal |= XadesCheckSignatureMasks.CheckCertificateValuesMatchCertificateRefs;

        //     //   retVal |= XadesCheckSignatureMasks.CheckRevocationValuesMatchRevocationRefs;

        //        return retVal;
        //    }

        //}

        #endregion


    }
}
