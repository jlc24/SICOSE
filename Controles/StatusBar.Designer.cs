namespace SICOSE.Controles
{
    partial class StatusBar
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            lblMessage = new Label();
            SuspendLayout();
            // 
            // lblMessage
            // 
            lblMessage.Dock = DockStyle.Fill;
            lblMessage.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblMessage.Location = new Point(0, 0);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(1185, 35);
            lblMessage.TabIndex = 0;
            lblMessage.Text = "label1";
            lblMessage.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // StatusBar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblMessage);
            Name = "StatusBar";
            Size = new Size(1185, 35);
            ResumeLayout(false);
        }

        #endregion

        public Label lblMessage;
    }
}
