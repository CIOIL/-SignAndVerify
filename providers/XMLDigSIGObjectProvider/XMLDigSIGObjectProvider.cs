using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using System.Xml;
using GovIL.SignAndVerifySDK.Providers;
using System.Security.Cryptography.X509Certificates;
using SignVerify.Common;
using GovIL.SignAndVerifySDK.SignObject;
using SignVerify.Providers.XmlDigSig;

namespace GovIL.SignAndVerifySDK.Providers
{
    public class XMLDigSIGObjectProviderClass
    {
        public SignedRoot Sign(object BOobj, SignVerify.Common.SignParameters signingParameters)
        {
            var stream = new MemoryStream();
        

            XmlDocument doc = new XmlDocument();
            // serialize object to byte array
            var ser = new XmlSerializer(BOobj.GetType());

            using (stream = new MemoryStream())
            {
                XmlWriterSettings settings = new XmlWriterSettings()
                {
                    Encoding = Encoding.UTF8,
                     OmitXmlDeclaration=true
                    //NamespaceHandling = NamespaceHandling.OmitDuplicates
                };
                using (XmlWriter writer = XmlWriter.Create(stream, settings))
                {
                    ser.Serialize(writer, BOobj);
                }
                stream.Seek(0, SeekOrigin.Begin);



                doc.Load(stream);

            }

            doc.ChildNodes[1].Attributes.RemoveAt(0);
            doc.ChildNodes[1].Attributes.RemoveAt(0);
            stream = new MemoryStream();
            doc.Save(stream);
            var data = new byte[stream.Length];
            stream.Seek(0, SeekOrigin.Begin);
            stream.Read(data, 0, data.Length);
            var cryptoProvider = new XmlDigSig();
            //X509Certificate2 cert = SignVerify.Common.Certificate.GetSignCertificate(true, false);
            //var signature = new CryptoSignatureInfo(cert);

       //     signingParameters.signatureInfo.fileName= typeof(BOType).Name;

            ////Set the parameters for verifying the signature
            //var signParams = new SignParameters(signature);

            // invoke sign 
            CryptoSignedObject<byte[]> cryptoSignedObject = cryptoProvider.Sign(data, signingParameters);

            // desterilize
            stream = new MemoryStream();
            stream.Write(cryptoSignedObject.ContentInfo.signedContent, 0, cryptoSignedObject.ContentInfo.signedContent.Length);

            String ss = System.Text.Encoding.UTF8.GetString(cryptoSignedObject.ContentInfo.signedContent);//SignedRootOfDataObj

        
             SignedRoot result;
           
              XmlSerializer ser4 = new XmlSerializer(typeof(SignedRoot));
             using (TextReader tr = new StringReader(ss))
             {
                 result = (SignedRoot)ser4.Deserialize(tr);
             }
             result.SignedObject.SignedInfo.Data.DataObj = BOobj;
    
             return result;
        }

        public SignVerify.Common.CryptoSignedObject<byte[]> Verify(SignedRoot sigend, SignVerify.Common.VerifyParameters verifyParametersInfo)
        {

            // serialize object to byte array
            XmlSerializerNamespaces myNamespaces = new XmlSerializerNamespaces();

            myNamespaces.Add("xa", "http://uri.etsi.org/01903/v1.3.2#");
            myNamespaces.Add("ds", "http://www.w3.org/2000/09/xmldsig#");
            myNamespaces.Add("gov.il", "http://www.gov.il/xmldigsig/v_1_0_0");
            var att = new XmlRootAttribute { Namespace = "http://www.gov.il/xmldigsig/v_1_0_0", };
            var types = new Type[1];
            types[0] = sigend.SignedObject.SignedInfo.Data.DataObj.GetType();
            var ser = new XmlSerializer(typeof(SignedRoot), new XmlAttributeOverrides(), types, att, null);
            
            using (MemoryStream stream = new MemoryStream())
            {
                XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
                xmlWriterSettings.Encoding = new UTF8Encoding(false);

                using (XmlWriter writer = XmlWriter.Create(stream, xmlWriterSettings))
                {
                    ser.Serialize(writer, sigend,myNamespaces );
                }

                stream.Seek(0, SeekOrigin.Begin);


                XmlDigSig CryptoProvider = new XmlDigSig();

                //VerifyParameters VerifyParams = new VerifyParameters();
                //VerifyParams.CheckTrustChain = true;
                byte[] data = new byte[stream.Length];
                stream.Read(data, 0, (int)data.Length);
                string tempString = System.Text.Encoding.UTF8.GetString(data);
                string className = sigend.SignedObject.SignedInfo.Data.DataObj.GetType().Name;// tempString.Substring(tempString.IndexOf("<gov.il:FileName>") + 17, tempString.IndexOf("</gov.il:FileName>") - tempString.IndexOf("<gov.il:FileName>") - 17);
                tempString = Regex.Replace(tempString, "<(/?)DataObj.*?>", @"<$1" + className + ">");
                data = System.Text.Encoding.UTF8.GetBytes(tempString);
                SignVerify.Common.CryptoSignedObject<byte[]> data_res = CryptoProvider.VerifySignature(data, verifyParametersInfo);
                return data_res;
            }
        }
    }
}

