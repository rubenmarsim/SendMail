using System;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace Encriptaciones
{
    /// <summary>
    /// Clase para la gestio de correos, envia correos, encripta y desencripta XMLs
    /// </summary>
    public class GestorCorreo
    {
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
            if (Enviador.Equals(string.Empty) || Contraseña.Equals(string.Empty))
            {
                DesencriptarXML();
            }
        }

        /// <summary>
        /// Desencripta un XML
        /// </summary>
        public void DesencriptarXML()
        {

        }
        #endregion
    }
}
