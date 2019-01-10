using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnviarCorreu
{
    public partial class EnviarCorreo : Form
    {
        #region Variables Globales
        string _Enviador = string.Empty;
        string _Receptor = string.Empty;
        string _Asunto = string.Empty;
        string _Contenido = string.Empty;
        string _Password = string.Empty;
        #endregion
        public EnviarCorreo()
        {
            InitializeComponent();
        }

        private void EnviarCorreo_Load(object sender, EventArgs e)
        {
            _Enviador = txtBoxDe.Text;
            _Receptor = txtBoxPara.Text;
            _Asunto = txtBoxAsunto.Text;
            _Contenido = txtBoxContenido.Text;            
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            _Password = txtBoxPassword.Text;

            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "smtp.gmail.com";
            client.Credentials = new System.Net.NetworkCredential(_Enviador, _Password);

            MailMessage mail = new MailMessage(_Enviador, _Receptor, _Asunto, _Contenido);
            mail.BodyEncoding = UTF8Encoding.UTF8;
            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            client.Send(mail);
        }
    }
}
