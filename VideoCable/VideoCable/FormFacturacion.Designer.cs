namespace VideoCable
{
    partial class FormFacturacion
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
            this.prueba = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // prueba
            // 
            this.prueba.Location = new System.Drawing.Point(218, 236);
            this.prueba.Name = "prueba";
            this.prueba.Size = new System.Drawing.Size(75, 23);
            this.prueba.TabIndex = 0;
            this.prueba.Text = "Prueba";
            this.prueba.UseVisualStyleBackColor = true;
            this.prueba.Click += new System.EventHandler(this.prueba_Click);
            // 
            // FormFacturacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 485);
            this.Controls.Add(this.prueba);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FormFacturacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button prueba;
    }
}

