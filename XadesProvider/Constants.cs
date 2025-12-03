using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SignVerify.Providers.XadesProvider
{
    static class Constants
    {
        #region Version
        public const string AppVersion = "3.0.0";
        public const string SDKVersion = "1.0.0.0";
        #endregion

        #region Sha256Values
        public const string XmlDsigRSASHA256Url = @"http://www.w3.org/2001/04/xmldsig-more#rsa-sha256";
        public const string DigestMethodSha256 = @"http://www.w3.org/2001/04/xmlenc#sha256";
        public const string SHA256 = "SHA256";
        public const string XmlDsigRSASHA1Url = @"http://www.w3.org/2000/09/xmldsig#rsa-sha1";
        #endregion

        public const string providerFriendlyName="Xades crypto provider.";

        #region FileNames
        public const string EndFileName = "-Xades.xml";
        public const string DefaultFileName = "data.xml";
        #endregion

        #region XadesTags
        public const string SigntureTag = "ds:Signature";
        public const string ObjectTag = "ds:Object";
        public const string SignatureValueTag = "ds:SignatureValue";
        #endregion

        #region Xpath
        public const string DescriptionXpath = "ds:Signature/ds:Object/xsd:QualifyingProperties/xsd:SignedProperties/xsd:SignedDataObjectProperties/xsd:DataObjectFormat";
        public const string EncapsulatedXpath = "ds:Object/xsd:QualifyingProperties/xsd:UnsignedProperties/xsd:UnsignedSignatureProperties/xsd:SignatureTimeStamp/xsd:EncapsulatedTimeStamp";
        public const string CompleteCertificatesRefsXpath = "ds:Object/xsd:QualifyingProperties/xsd:UnsignedProperties/xsd:UnsignedSignatureProperties/xsd:CompleteCertificateRefs";
        public const string CompleteRevocationRefsXpath = "ds:Object/xsd:QualifyingProperties/xsd:UnsignedProperties/xsd:UnsignedSignatureProperties/xsd:CompleteRevocationRefs";
        #endregion

        #region Ansi
        public const string AnsiUniversalPrimitive = "//Universal_Constructed_Sequence/Universal_Constructed_Sequence/Universal_Constructed_Sequence/Universal_Constructed_Set/Universal_Constructed_Sequence/Universal_Primitive_PrintableString";
        public const string AnsiUtc = "//Universal_Constructed_Sequence/Universal_Constructed_Sequence/Universal_Primitive_UtcTime";
        #endregion

        #region IDs
        public const string XadesTimeStampID = "SigAndRefsTimeStamp";
        public const string SignatureTimeStampID = "SignatureTimeStamp";
        public const string SignatureObjectID="SignatureObject";
        public const string XadesObjectID = "xadesObject";
         #endregion

        #region MimeTypes
        public const string XmlMimeType = "text/xml";
        public const string Base64MimeType = "base64";
        
        #endregion

        #region Same
        public const string Signature = "Signature";
        public const string Object = "Object";
        public const string OriginalData = "OriginalData";
        #endregion


        public const string sha1RSA = "sha1RSA";

        
    }
}
