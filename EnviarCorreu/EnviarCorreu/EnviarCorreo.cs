using Encriptaciones;
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
    /// <summary>
    /// Formulario para enviar correos
    /// </summary>
    public partial class EnviarCorreo : Form
    {
        #region Variables Globales
        GestorCorreo CGestorCorreo;
        #endregion

        /// <summary>
        /// Contructor por defecto
        /// </summary>
        public EnviarCorreo()
        {
            InitializeComponent();
        }

        #region Eventos
        private void EnviarCorreo_Load(object sender, EventArgs e)
        {
            CGestorCorreo = new GestorCorreo();
        }
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            CGestorCorreo.EnviarMail(txtBoxAsunto.Text, txtBoxContenido.Text, txtBoxPara.Text);
        }
        #endregion

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            CGestorCorreo.GestionDatos(true, true, false);
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            CGestorCorreo.GestionDatos(true, false, true);
        }
    }
}
