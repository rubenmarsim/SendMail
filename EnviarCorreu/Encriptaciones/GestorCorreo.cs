using System;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;

namespace Encriptaciones
{
    /// <summary>
    /// Clase para la gestio de correos, envia correos, encripta y desencripta XMLs
    /// </summary>
    public class GestorCorreo
    {
        #region Variables Globales
        RijndaelManaged key = null;
        const string _Path = @"recursos\archivos\";
        const string _Filename = "Users.xml";
        bool _bEncrypt = true;
        bool _bDecrypt = true;
        #endregion

        #region Propiedades
        private string _Asunto;
        /// <summary>
        /// Asunto del correo
        /// </summary>
        public string Asunto
        {
            get { return _Asunto; }
            set { _Asunto = value; }
        }

        private string _Contenido;
        /// <summary>
        /// Contenido del correo
        /// </summary>
        public string Contenido
        {
            get { return _Contenido; }
            set { _Contenido = value; }
        }

        private string _Destinatario;
        /// <summary>
        /// Destinatario del correo
        /// </summary>
        public string Destinatario
        {
            get { return _Destinatario; }
            set { _Destinatario = value; }
        }

        private string _Enviador;
        /// <summary>
        /// Correo de la persona que va a enviar el correo
        /// </summary>
        public string Enviador
        {
            get { return _Enviador; }
            set { _Enviador = value; }
        }

        private string _Contraseña;
        /// <summary>
        /// Contraseña de la persona que va a enviar el correo
        /// </summary>
        public string Contraseña
        {
            get { return _Contraseña; }
            set { _Contraseña = value; }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public GestorCorreo()
        {

        }
        #endregion

        #region Methods
        /// <summary>
        /// Envia un correo
        /// </summary>
        /// <param name="Subject">Asunto del correo</param>
        /// <param name="Body">Contenido del correo</param>
        /// <param name="To">Destinatario del correo</param>
        public void EnviarMail(string Subject, string Body, string To)
        {
            try
            {
                GetCredencials();

                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Host = "smtp.gmail.com";
                client.Credentials = new System.Net.NetworkCredential(Enviador, Contraseña);

                MailMessage mail = new MailMessage(Enviador, To, Subject, Body);
                mail.BodyEncoding = UTF8Encoding.UTF8;
                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                client.Send(mail);
            }
            catch (SmtpException)
            {
                MessageBox.Show("Credenciales incorrectas");
            }
        }

        /// <summary>
        /// Coje el correo y la contraseña de la persona que envia el correo
        /// </summary>
        public void GetCredencials()
        {
            try
            {
                key = new RijndaelManaged();
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.PreserveWhitespace = true;
                xmlDoc.Load(_Path + _Filename);

                DesencriptarXML(xmlDoc, key);
                xmlDoc.Save(_Path+"DecryptedDoc.xml");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                if(key != null)
                {
                    key.Clear();
                }
            }   
        }

        /// <summary>
        /// Desencripta un XML con clave simetrica
        /// </summary>
        /// <param name="Doc">Documento XML</param>
        /// <param name="Alg">Tipo de encriptacion</param>
        public void DesencriptarXML(XmlDocument Doc, SymmetricAlgorithm Alg)
        {
            // Check the arguments.  
            if (Doc == null)
                throw new ArgumentNullException("Doc");
            if (Alg == null)
                throw new ArgumentNullException("Alg");

            // Find the EncryptedData element in the XmlDocument.
            XmlElement encryptedElement = Doc.GetElementsByTagName("EncryptedData")[0] as XmlElement;

            // If the EncryptedData element was not found, throw an exception.
            if (encryptedElement == null)
            {
                throw new XmlException("The EncryptedData element was not found.");
            }


            // Create an EncryptedData object and populate it.
            EncryptedData edElement = new EncryptedData();
            edElement.LoadXml(encryptedElement);

            // Create a new EncryptedXml object.
            EncryptedXml exml = new EncryptedXml();


            // Decrypt the element using the symmetric key.
            byte[] rgbOutput = exml.DecryptData(edElement, Alg);

            // Replace the encryptedData element with the plaintext XML element.
            exml.ReplaceData(encryptedElement, rgbOutput);
        }

        /// <summary>
        /// Encripta un XML con clave simetrica
        /// </summary>
        /// <param name="Doc">Documento XML</param>
        /// <param name="ElementName">Nombre del elemento a encriptar</param>
        /// <param name="Key">Tipo de encriptacion</param>
        public void EncriptarXML(XmlDocument Doc,string ElementName, SymmetricAlgorithm Key)
        {
            // Check the arguments.  
            if (Doc == null)
                throw new ArgumentNullException("Doc");
            if (ElementName == null)
                throw new ArgumentNullException("ElementToEncrypt");
            if (Key == null)
                throw new ArgumentNullException("Alg");

            ////////////////////////////////////////////////
            // Find the specified element in the XmlDocument
            // object and create a new XmlElemnt object.
            ////////////////////////////////////////////////
            XmlElement elementToEncrypt = Doc.GetElementsByTagName(ElementName)[0] as XmlElement;
            // Throw an XmlException if the element was not found.
            if (elementToEncrypt == null)
            {
                throw new XmlException("The specified element was not found");

            }

            //////////////////////////////////////////////////
            // Create a new instance of the EncryptedXml class 
            // and use it to encrypt the XmlElement with the 
            // symmetric key.
            //////////////////////////////////////////////////

            EncryptedXml eXml = new EncryptedXml();

            byte[] encryptedElement = eXml.EncryptData(elementToEncrypt, Key, false);
            ////////////////////////////////////////////////
            // Construct an EncryptedData object and populate
            // it with the desired encryption information.
            ////////////////////////////////////////////////

            EncryptedData edElement = new EncryptedData();
            edElement.Type = EncryptedXml.XmlEncElementUrl;

            // Create an EncryptionMethod element so that the 
            // receiver knows which algorithm to use for decryption.
            // Determine what kind of algorithm is being used and
            // supply the appropriate URL to the EncryptionMethod element.

            string encryptionMethod = null;

            if (Key is TripleDES)
            {
                encryptionMethod = EncryptedXml.XmlEncTripleDESUrl;
            }
            else if (Key is DES)
            {
                encryptionMethod = EncryptedXml.XmlEncDESUrl;
            }
            if (Key is Rijndael)
            {
                switch (Key.KeySize)
                {
                    case 128:
                        encryptionMethod = EncryptedXml.XmlEncAES128Url;
                        break;
                    case 192:
                        encryptionMethod = EncryptedXml.XmlEncAES192Url;
                        break;
                    case 256:
                        encryptionMethod = EncryptedXml.XmlEncAES256Url;
                        break;
                }
            }
            else
            {
                // Throw an exception if the transform is not in the previous categories
                throw new CryptographicException("The specified algorithm is not supported for XML Encryption.");
            }

            edElement.EncryptionMethod = new EncryptionMethod(encryptionMethod);

            // Add the encrypted element data to the 
            // EncryptedData object.
            edElement.CipherData.CipherValue = encryptedElement;

            ////////////////////////////////////////////////////
            // Replace the element from the original XmlDocument
            // object with the EncryptedData element.
            ////////////////////////////////////////////////////
            EncryptedXml.ReplaceElement(elementToEncrypt, edElement, false);
        }

        /// <summary>
        /// Encripta un XML con clave asimetrica
        /// </summary>
        /// <param name="Doc">Documento XML</param>
        /// <param name="ElementToEncrypt">Nombre del elemento a encriptar</param>
        /// <param name="EncryptionElementID"></param>
        /// <param name="Alg">Tipo de encriptacion</param>
        /// <param name="KeyName"></param>
        public void EncriptarXML(XmlDocument Doc, string ElementToEncrypt, string EncryptionElementID, RSA Alg, string KeyName)
        {
            // Check the arguments.
            if (Doc == null)
                throw new ArgumentNullException("Doc");
            if (ElementToEncrypt == null)
                throw new ArgumentNullException("ElementToEncrypt");
            if (EncryptionElementID == null)
                throw new ArgumentNullException("EncryptionElementID");
            if (Alg == null)
                throw new ArgumentNullException("Alg");
            if (KeyName == null)
                throw new ArgumentNullException("KeyName");

            ////////////////////////////////////////////////
            // Find the specified element in the XmlDocument
            // object and create a new XmlElemnt object.
            ////////////////////////////////////////////////
            XmlElement elementToEncrypt = Doc.GetElementsByTagName(ElementToEncrypt)[0] as XmlElement;

            // Throw an XmlException if the element was not found.
            if (elementToEncrypt == null)
            {
                throw new XmlException("The specified element was not found");

            }
            RijndaelManaged sessionKey = null;

            try
            {
                //////////////////////////////////////////////////
                // Create a new instance of the EncryptedXml class
                // and use it to encrypt the XmlElement with the
                // a new random symmetric key.
                //////////////////////////////////////////////////

                // Create a 256 bit Rijndael key.
                sessionKey = new RijndaelManaged();
                sessionKey.KeySize = 256;

                EncryptedXml eXml = new EncryptedXml();

                byte[] encryptedElement = eXml.EncryptData(elementToEncrypt, sessionKey, false);
                ////////////////////////////////////////////////
                // Construct an EncryptedData object and populate
                // it with the desired encryption information.
                ////////////////////////////////////////////////

                EncryptedData edElement = new EncryptedData();
                edElement.Type = EncryptedXml.XmlEncElementUrl;
                edElement.Id = EncryptionElementID;
                // Create an EncryptionMethod element so that the
                // receiver knows which algorithm to use for decryption.

                edElement.EncryptionMethod = new EncryptionMethod(EncryptedXml.XmlEncAES256Url);
                // Encrypt the session key and add it to an EncryptedKey element.
                EncryptedKey ek = new EncryptedKey();

                byte[] encryptedKey = EncryptedXml.EncryptKey(sessionKey.Key, Alg, false);

                ek.CipherData = new CipherData(encryptedKey);

                ek.EncryptionMethod = new EncryptionMethod(EncryptedXml.XmlEncRSA15Url);

                // Create a new DataReference element
                // for the KeyInfo element.  This optional
                // element specifies which EncryptedData
                // uses this key.  An XML document can have
                // multiple EncryptedData elements that use
                // different keys.
                DataReference dRef = new DataReference();

                // Specify the EncryptedData URI.
                dRef.Uri = "#" + EncryptionElementID;

                // Add the DataReference to the EncryptedKey.
                ek.AddReference(dRef);
                // Add the encrypted key to the
                // EncryptedData object.

                edElement.KeyInfo.AddClause(new KeyInfoEncryptedKey(ek));
                // Set the KeyInfo element to specify the
                // name of the RSA key.


                // Create a new KeyInfoName element.
                KeyInfoName kin = new KeyInfoName();

                // Specify a name for the key.
                kin.Value = KeyName;

                // Add the KeyInfoName element to the
                // EncryptedKey object.
                ek.KeyInfo.AddClause(kin);
                // Add the encrypted element data to the
                // EncryptedData object.
                edElement.CipherData.CipherValue = encryptedElement;
                ////////////////////////////////////////////////////
                // Replace the element from the original XmlDocument
                // object with the EncryptedData element.
                ////////////////////////////////////////////////////
                EncryptedXml.ReplaceElement(elementToEncrypt, edElement, false);
            }
            catch (Exception e)
            {
                // re-throw the exception.
                throw e;
            }
            finally
            {
                if (sessionKey != null)
                {
                    sessionKey.Clear();
                }

            }
        }

        /// <summary>
        /// Desencripta un XML con clave asimetrica
        /// </summary>
        /// <param name="Doc">Documento XML</param>
        /// <param name="Alg">Tipo de encriptacion</param>
        /// <param name="KeyName">keyname</param>
        public void DesencriptarXML(XmlDocument Doc, RSA Alg, string KeyName)
        {
            // Check the arguments.  
            if (Doc == null)
                throw new ArgumentNullException("Doc");
            if (Alg == null)
                throw new ArgumentNullException("Alg");
            if (KeyName == null)
                throw new ArgumentNullException("KeyName");

            // Create a new EncryptedXml object.
            EncryptedXml exml = new EncryptedXml(Doc);

            // Add a key-name mapping.
            // This method can only decrypt documents
            // that present the specified key name.
            exml.AddKeyNameMapping(KeyName, Alg);

            // Decrypt the element.
            exml.DecryptDocument();
        }

        public void GestionDatos(bool IsAsimetric, bool bEncrypt, bool bDecrypt)
        {
            key = new RijndaelManaged();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.PreserveWhitespace = true;
            xmlDoc.Load(_Path + _Filename);

            // Create a new CspParameters object to specify
            // a key container.
            CspParameters cspParams = new CspParameters();
            cspParams.KeyContainerName = "XML_ENC_RSA_KEY";
            // Create a new RSA key and save it in the container.  This key will encrypt
            // a symmetric key, which will then be encryped in the XML document.
            RSACryptoServiceProvider rsaKey = new RSACryptoServiceProvider(cspParams);

            if (IsAsimetric)
            {
                try
                {
                    if (bEncrypt)
                    {
                        EncriptarXML(xmlDoc, "User", "", rsaKey, "rsaKey");
                        xmlDoc.Save(_Path + "AEncryptedDoc.xml");

                    }
                    if (bDecrypt)
                    {
                        xmlDoc.Load(_Path + "AEncryptedDoc.xml");
                        DesencriptarXML(xmlDoc, rsaKey, "rsaKey");
                        xmlDoc.Save(_Path + "ADecryptedDoc.xml");
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                finally
                {
                    // Clear the RSA key.
                    rsaKey.Clear();
                }
            }
            else
            {
                try
                {                    
                    if (bEncrypt)
                    {
                        EncriptarXML(xmlDoc, "User", key);
                        xmlDoc.Save(_Path + "SEncryptedDoc.xml");

                    }
                    if (bDecrypt)
                    {
                        xmlDoc.Load(_Path + "SEncryptedDoc.xml");
                        DesencriptarXML(xmlDoc, key);
                        xmlDoc.Save(_Path + "SDecryptedDoc.xml");
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                finally
                {
                    if (key != null)
                    {
                        key.Clear();
                    }
                }
            }            
        }
        #endregion
    }
}
