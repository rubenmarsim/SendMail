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
        /// <summary>
        /// Contructor por defecto
        /// </summary>
        public EnviarCorreo()
        {
            InitializeComponent();
        }

        #region Eventos
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            EnviarMail();
        }

        private void txtBoxPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EnviarMail();
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// 
        /// </summary>
        public void EnviarMail()
        {
            try
            {
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Host = "smtp.gmail.com";
                client.Credentials = new System.Net.NetworkCredential(txtBoxDe.Text, txtBoxPassword.Text);

                MailMessage mail = new MailMessage(txtBoxDe.Text, txtBoxPara.Text, txtBoxAsunto.Text, txtBoxContenido.Text);
                mail.BodyEncoding = UTF8Encoding.UTF8;
                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                client.Send(mail);
            }
            catch (SmtpException)
            {
                MessageBox.Show("Credenciales incorrectas");
            }            
        }
        #endregion

    }
}
