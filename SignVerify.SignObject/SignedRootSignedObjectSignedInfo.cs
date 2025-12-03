
namespace GovIL.SignAndVerifySDK.SignObject
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.gov.il/xmldigsig/v_1_0_0")]
    public class SignedRootSignedObjectSignedInfo
    {

        /// <remarks/>
        private SignedRootSignedObjectSignedInfoData dataField;

        private SignedRootSignedObjectSignedInfoOptionalDataParams optionalDataParamsField;

        private string idField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Data")]
        public SignedRootSignedObjectSignedInfoData   Data
        {
            get
            {
                return this.dataField;
            }
            set
            {
                this.dataField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("OptionalDataParams")]
        public SignedRootSignedObjectSignedInfoOptionalDataParams OptionalDataParams
        {
            get
            {
                return this.optionalDataParamsField;
            }
            set
            {
                this.optionalDataParamsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

    }
}