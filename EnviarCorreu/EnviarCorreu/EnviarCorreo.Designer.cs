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
            this.grpBoxEnviarCorreu.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBoxEnviarCorreu
            // 
            this.grpBoxEnviarCorreu.Controls.Add(this.lblDe);
            this.grpBoxEnviarCorreu.Controls.Add(this.txtBoxDe);
            this.grpBoxEnviarCorreu.Controls.Add(this.lblContenido);
            this.grpBoxEnviarCorreu.Controls.Add(this.lblPara);
            this.grpBoxEnviarCorreu.Controls.Add(this.btnEnviar);
            this.grpBoxEnviarCorreu.Controls.Add(this.txtBoxContenido);
            this.grpBoxEnviarCorreu.Controls.Add(this.txtBoxPara);
            this.grpBoxEnviarCorreu.Location = new System.Drawing.Point(192, 36);
            this.grpBoxEnviarCorreu.Name = "grpBoxEnviarCorreu";
            this.grpBoxEnviarCorreu.Size = new System.Drawing.Size(473, 321);
            this.grpBoxEnviarCorreu.TabIndex = 0;
            this.grpBoxEnviarCorreu.TabStop = false;
            this.grpBoxEnviarCorreu.Text = "Enviar Correu";
            // 
            // txtBoxPara
            // 
            this.txtBoxPara.Location = new System.Drawing.Point(100, 80);
            this.txtBoxPara.Name = "txtBoxPara";
            this.txtBoxPara.ReadOnly = true;
            this.txtBoxPara.Size = new System.Drawing.Size(354, 20);
            this.txtBoxPara.TabIndex = 0;
            this.txtBoxPara.Text = "marc.morata@sarria.salesians.cat";
            // 
            // txtBoxContenido
            // 
            this.txtBoxContenido.Location = new System.Drawing.Point(100, 119);
            this.txtBoxContenido.Multiline = true;
            this.txtBoxContenido.Name = "txtBoxContenido";
            this.txtBoxContenido.ReadOnly = true;
            this.txtBoxContenido.Size = new System.Drawing.Size(354, 140);
            this.txtBoxContenido.TabIndex = 1;
            this.txtBoxContenido.Text = "Hula";
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(392, 292);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(75, 23);
            this.btnEnviar.TabIndex = 2;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // lblPara
            // 
            this.lblPara.AutoSize = true;
            this.lblPara.Location = new System.Drawing.Point(23, 83);
            this.lblPara.Name = "lblPara";
            this.lblPara.Size = new System.Drawing.Size(32, 13);
            this.lblPara.TabIndex = 3;
            this.lblPara.Text = "Para:";
            // 
            // lblContenido
            // 
            this.lblContenido.AutoSize = true;
            this.lblContenido.Location = new System.Drawing.Point(23, 119);
            this.lblContenido.Name = "lblContenido";
            this.lblContenido.Size = new System.Drawing.Size(58, 13);
            this.lblContenido.TabIndex = 4;
            this.lblContenido.Text = "Contenido:";
            // 
            // lblDe
            // 
            this.lblDe.AutoSize = true;
            this.lblDe.Location = new System.Drawing.Point(23, 47);
            this.lblDe.Name = "lblDe";
            this.lblDe.Size = new System.Drawing.Size(24, 13);
            this.lblDe.TabIndex = 6;
            this.lblDe.Text = "De:";
            // 
            // txtBoxDe
            // 
            this.txtBoxDe.Location = new System.Drawing.Point(100, 44);
            this.txtBoxDe.Name = "txtBoxDe";
            this.txtBoxDe.ReadOnly = true;
            this.txtBoxDe.Size = new System.Drawing.Size(354, 20);
            this.txtBoxDe.TabIndex = 5;
            this.txtBoxDe.Text = "ruben.martinez.simon@sarria.salesians.cat";
            // 
            // EnviarCorreo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grpBoxEnviarCorreu);
            this.Name = "EnviarCorreo";
            this.Text = "Enviar Correo";
            this.Load += new System.EventHandler(this.EnviarCorreo_Load);
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
    }
}

