
using System;
using System.Runtime.Serialization;
namespace GovIL.SignAndVerifySDK.SignObject
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.gov.il/xmldigsig/v_1_0_0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.gov.il/xmldigsig/v_1_0_0", IsNullable = false, ElementName = "SignedRoot")]

     
        public class SignedRoot
        // make sure TDataObject is a class with default constractor
    {
        private SignedRootSigningAppInfo signingAppInfoField;

        private SignedRootSignedObject signedObjectField;

        private Signature signatureField;

        private string versionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SigningAppInfo")]
        public SignedRootSigningAppInfo SigningAppInfo
        {
            get
            {
                return this.signingAppInfoField;
            }
            set
            {
                this.signingAppInfoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SignedObject")]
        public SignedRootSignedObject SignedObject
        {
            get
            {
                return this.signedObjectField;
            }
            set
            {
                this.signedObjectField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public Signature Signature
        {
            get
            {
                return this.signatureField;
            }
            set
            {
                this.signatureField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }

      public  static Type[] GetKnownTypes()
        {
            return new Type[] { typeof(SignedRoot) };
        }
    }

}