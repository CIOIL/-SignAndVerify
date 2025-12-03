namespace GovIL.SignAndVerifySDK.SignObject
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "")]
    public class SignedRootSignedObjectSignedInfoData
    {



        private object dataObjField;

        private string dataEncodingTypeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0 )]



        public object DataObj
        {
            get
            {
                return this.dataObjField;
            }
            set
            {
                this.dataObjField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute("MimeType")]
        public string MimeType { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string DataEncodingType
        {
            get
            {
                return this.dataEncodingTypeField;
            }
            set
            {
                this.dataEncodingTypeField = value;
            }
        }

      


     

      

    }

}
