namespace GovIL.SignAndVerifySDK.SignObject
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.gov.il/xmldigsig/v_1_0_0")]
    public class SignedRootSignedObject
        // make sure TDataObject is a class with default constractor
    {

       private SignedRootSignedObjectSignedInfo signedInfoField;
    
    private string mimeTypeField;
    
    private string idField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("SignedInfo")]
    public SignedRootSignedObjectSignedInfo SignedInfo {
        get {
            return this.signedInfoField;
        }
        set {
            this.signedInfoField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string MimeType {
        get {
            return this.mimeTypeField;
        }
        set {
            this.mimeTypeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Id {
        get {
            return this.idField;
        }
        set {
            this.idField = value;
        }
    }
}

}
