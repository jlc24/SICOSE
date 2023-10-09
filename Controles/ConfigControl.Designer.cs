namespace SICOSE.Controles
{
    partial class ConfigControl
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
            groupBox1 = new GroupBox();
            btnDesconectarLector = new Button();
            btnConectarLector = new Button();
            label1 = new Label();
            cmbldx = new ComboBox();
            picFPImg = new PictureBox();
            lblDeviceStatus = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picFPImg).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnDesconectarLector);
            groupBox1.Controls.Add(btnConectarLector);
            groupBox1.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(25, 15);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(221, 164);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Conexion";
            // 
            // btnDesconectarLector
            // 
            btnDesconectarLector.BackColor = Color.FromArgb(230, 112, 134);
            btnDesconectarLector.Cursor = Cursors.Hand;
            btnDesconectarLector.Enabled = false;
            btnDesconectarLector.FlatStyle = FlatStyle.Flat;
            btnDesconectarLector.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnDesconectarLector.ForeColor = Color.White;
            btnDesconectarLector.Location = new Point(25, 95);
            btnDesconectarLector.Name = "btnDesconectarLector";
            btnDesconectarLector.Size = new Size(178, 54);
            btnDesconectarLector.TabIndex = 11;
            btnDesconectarLector.Text = "Desconectar";
            btnDesconectarLector.UseVisualStyleBackColor = false;
            btnDesconectarLector.Click += btnDesconectarLector_Click;
            // 
            // btnConectarLector
            // 
            btnConectarLector.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnConectarLector.Location = new Point(25, 34);
            btnConectarLector.Name = "btnConectarLector";
            btnConectarLector.Size = new Size(178, 54);
            btnConectarLector.TabIndex = 10;
            btnConectarLector.Text = "Conectar";
            btnConectarLector.UseVisualStyleBackColor = true;
            btnConectarLector.Click += btnConectarLector_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(375, 49);
            label1.Name = "label1";
            label1.Size = new Size(205, 19);
            label1.TabIndex = 1;
            label1.Text = "Dispositivos Disponibles:";
            // 
            // cmbldx
            // 
            cmbldx.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cmbldx.FormattingEnabled = true;
            cmbldx.Location = new Point(709, 49);
            cmbldx.Name = "cmbldx";
            cmbldx.Size = new Size(54, 26);
            cmbldx.TabIndex = 2;
            cmbldx.SelectedIndexChanged += cmbldx_SelectedIndexChanged;
            // 
            // picFPImg
            // 
            picFPImg.BorderStyle = BorderStyle.FixedSingle;
            picFPImg.Location = new Point(269, 135);
            picFPImg.Name = "picFPImg";
            picFPImg.Size = new Size(300, 375);
            picFPImg.TabIndex = 3;
            picFPImg.TabStop = false;
            // 
            // lblDeviceStatus
            // 
            lblDeviceStatus.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblDeviceStatus.ForeColor = Color.FromArgb(105, 204, 240);
            lblDeviceStatus.Location = new Point(605, 187);
            lblDeviceStatus.Name = "lblDeviceStatus";
            lblDeviceStatus.Size = new Size(351, 110);
            lblDeviceStatus.TabIndex = 4;
            lblDeviceStatus.Text = "Desconectado";
            // 
            // ConfigControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblDeviceStatus);
            Controls.Add(picFPImg);
            Controls.Add(cmbldx);
            Controls.Add(label1);
            Controls.Add(groupBox1);
            Name = "ConfigControl";
            Size = new Size(998, 605);
            Load += ConfigControl_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picFPImg).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnDesconectarLector;
        private Button btnConectarLector;
        private Label label1;
        private PictureBox picFPImg;
        private Label lblDeviceStatus;
        public ComboBox cmbldx;
    }
}
