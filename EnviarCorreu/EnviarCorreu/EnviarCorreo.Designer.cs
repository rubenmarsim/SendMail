namespace EnviarCorreu
{
    partial class EnviarCorreo
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpBoxEnviarCorreu = new System.Windows.Forms.GroupBox();
            this.txtBoxPara = new System.Windows.Forms.TextBox();
            this.txtBoxContenido = new System.Windows.Forms.TextBox();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.lblPara = new System.Windows.Forms.Label();
            this.lblContenido = new System.Windows.Forms.Label();
            this.lblDe = new System.Windows.Forms.Label();
            this.txtBoxDe = new System.Windows.Forms.TextBox();
            this.lblAsunto = new System.Windows.Forms.Label();
            this.txtBoxAsunto = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtBoxPassword = new System.Windows.Forms.TextBox();
            this.grpBoxEnviarCorreu.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBoxEnviarCorreu
            // 
            this.grpBoxEnviarCorreu.Controls.Add(this.txtBoxPassword);
            this.grpBoxEnviarCorreu.Controls.Add(this.lblPassword);
            this.grpBoxEnviarCorreu.Controls.Add(this.lblAsunto);
            this.grpBoxEnviarCorreu.Controls.Add(this.txtBoxAsunto);
            this.grpBoxEnviarCorreu.Controls.Add(this.lblDe);
            this.grpBoxEnviarCorreu.Controls.Add(this.txtBoxDe);
            this.grpBoxEnviarCorreu.Controls.Add(this.lblContenido);
            this.grpBoxEnviarCorreu.Controls.Add(this.lblPara);
            this.grpBoxEnviarCorreu.Controls.Add(this.btnEnviar);
            this.grpBoxEnviarCorreu.Controls.Add(this.txtBoxContenido);
            this.grpBoxEnviarCorreu.Controls.Add(this.txtBoxPara);
            this.grpBoxEnviarCorreu.Location = new System.Drawing.Point(30, 12);
            this.grpBoxEnviarCorreu.Name = "grpBoxEnviarCorreu";
            this.grpBoxEnviarCorreu.Size = new System.Drawing.Size(742, 426);
            this.grpBoxEnviarCorreu.TabIndex = 0;
            this.grpBoxEnviarCorreu.TabStop = false;
            this.grpBoxEnviarCorreu.Text = "Enviar Correu";
            // 
            // txtBoxPara
            // 
            this.txtBoxPara.Location = new System.Drawing.Point(100, 69);
            this.txtBoxPara.Name = "txtBoxPara";
            this.txtBoxPara.Size = new System.Drawing.Size(354, 20);
            this.txtBoxPara.TabIndex = 1;
            this.txtBoxPara.Text = "ruben.martinez.simon@sarria.salesians.cat";
            // 
            // txtBoxContenido
            // 
            this.txtBoxContenido.Location = new System.Drawing.Point(100, 146);
            this.txtBoxContenido.Multiline = true;
            this.txtBoxContenido.Name = "txtBoxContenido";
            this.txtBoxContenido.Size = new System.Drawing.Size(354, 140);
            this.txtBoxContenido.TabIndex = 3;
            this.txtBoxContenido.Text = "Buenos Dias";
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(379, 324);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(75, 23);
            this.btnEnviar.TabIndex = 5;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // lblPara
            // 
            this.lblPara.AutoSize = true;
            this.lblPara.Location = new System.Drawing.Point(23, 72);
            this.lblPara.Name = "lblPara";
            this.lblPara.Size = new System.Drawing.Size(32, 13);
            this.lblPara.TabIndex = 7;
            this.lblPara.Text = "Para:";
            // 
            // lblContenido
            // 
            this.lblContenido.AutoSize = true;
            this.lblContenido.Location = new System.Drawing.Point(23, 146);
            this.lblContenido.Name = "lblContenido";
            this.lblContenido.Size = new System.Drawing.Size(58, 13);
            this.lblContenido.TabIndex = 9;
            this.lblContenido.Text = "Contenido:";
            // 
            // lblDe
            // 
            this.lblDe.AutoSize = true;
            this.lblDe.Location = new System.Drawing.Point(23, 34);
            this.lblDe.Name = "lblDe";
            this.lblDe.Size = new System.Drawing.Size(24, 13);
            this.lblDe.TabIndex = 6;
            this.lblDe.Text = "De:";
            // 
            // txtBoxDe
            // 
            this.txtBoxDe.Location = new System.Drawing.Point(100, 31);
            this.txtBoxDe.Name = "txtBoxDe";
            this.txtBoxDe.ReadOnly = true;
            this.txtBoxDe.Size = new System.Drawing.Size(354, 20);
            this.txtBoxDe.TabIndex = 0;
            this.txtBoxDe.Text = "insigns2am@gmail.com";
            // 
            // lblAsunto
            // 
            this.lblAsunto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblAsunto.AutoSize = true;
            this.lblAsunto.Location = new System.Drawing.Point(23, 110);
            this.lblAsunto.Name = "lblAsunto";
            this.lblAsunto.Size = new System.Drawing.Size(43, 13);
            this.lblAsunto.TabIndex = 8;
            this.lblAsunto.Text = "Asunto:";
            // 
            // txtBoxAsunto
            // 
            this.txtBoxAsunto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBoxAsunto.Location = new System.Drawing.Point(100, 107);
            this.txtBoxAsunto.Name = "txtBoxAsunto";
            this.txtBoxAsunto.Size = new System.Drawing.Size(354, 20);
            this.txtBoxAsunto.TabIndex = 2;
            this.txtBoxAsunto.Text = "Hula";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(29, 309);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(64, 13);
            this.lblPassword.TabIndex = 10;
            this.lblPassword.Text = "Contraseña:";
            // 
            // txtBoxPassword
            // 
            this.txtBoxPassword.Location = new System.Drawing.Point(100, 304);
            this.txtBoxPassword.Name = "txtBoxPassword";
            this.txtBoxPassword.PasswordChar = '*';
            this.txtBoxPassword.Size = new System.Drawing.Size(209, 20);
            this.txtBoxPassword.TabIndex = 4;
            this.txtBoxPassword.Text = "12345_aA";
            this.txtBoxPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBoxPassword_KeyUp);
            // 
            // EnviarCorreo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grpBoxEnviarCorreu);
            this.Name = "EnviarCorreo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enviar Correo";
            this.grpBoxEnviarCorreu.ResumeLayout(false);
            this.grpBoxEnviarCorreu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxEnviarCorreu;
        private System.Windows.Forms.Label lblContenido;
        private System.Windows.Forms.Label lblPara;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.TextBox txtBoxContenido;
        private System.Windows.Forms.TextBox txtBoxPara;
        private System.Windows.Forms.Label lblDe;
        private System.Windows.Forms.TextBox txtBoxDe;
        private System.Windows.Forms.Label lblAsunto;
        private System.Windows.Forms.TextBox txtBoxAsunto;
        private System.Windows.Forms.TextBox txtBoxPassword;
        private System.Windows.Forms.Label lblPassword;
    }
}

