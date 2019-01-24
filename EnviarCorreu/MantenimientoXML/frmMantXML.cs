using Encriptaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MantenimientoXML
{
    public partial class frmMantXML : Form
    {
        #region Variables Globales
        GestorCorreo CGestorCorreo;
        #endregion
        #region Constructores
        public frmMantXML()
        {
            InitializeComponent();
        }
        #endregion
        /// <summary>
        /// Desencripta el XML y coge las credenciales, que en este caso 
        /// son el user y el password
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMantXML_Load(object sender, EventArgs e)
        {
            CGestorCorreo = new GestorCorreo();
            CGestorCorreo.GetCredencials();
            txtBoxUser.Text = CGestorCorreo.Enviador;
            txtBoxPassword.Text = CGestorCorreo.Contraseña;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }
    }
}
