using System;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
//using System.Security.Cryptography.Xml;

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
            catch (ArgumentNullException)
            {
                MessageBox.Show("Error al coger las credenciales");
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
        /// Desencripta un XML
        /// </summary>
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
        /// Encriptar un XML
        /// </summary>
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

        public void GestionDatos(bool bEncrypt, bool bDecrypt)
        {
            try
            {
                key = new RijndaelManaged();
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.PreserveWhitespace = true;
                xmlDoc.Load(_Path + _Filename);
                if (bEncrypt)
                {
                    EncriptarXML(xmlDoc, "User", key);
                    xmlDoc.Save(_Path+"EncryptedDoc.xml");

                }
                if (bDecrypt)
                {
                    xmlDoc.Load(_Path + "EncryptedDoc.xml");
                    DesencriptarXML(xmlDoc, key);
                    xmlDoc.Save(_Path+"DecryptedDoc.xml");
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
        #endregion
    }
}
