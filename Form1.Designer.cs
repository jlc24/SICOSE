namespace SICOSE
{
    partial class Inicio
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel2 = new Panel();
            label3 = new Label();
            label2 = new Label();
            btnIniciarSesion = new Button();
            txtPassword = new TextBox();
            txtUser = new TextBox();
            panel1 = new Panel();
            label1 = new Label();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Control;
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(btnIniciarSesion);
            panel2.Controls.Add(txtPassword);
            panel2.Controls.Add(txtUser);
            panel2.Location = new Point(448, 252);
            panel2.Name = "panel2";
            panel2.Size = new Size(312, 247);
            panel2.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Lucida Console", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(3, 109);
            label3.Name = "label3";
            label3.Size = new Size(127, 21);
            label3.TabIndex = 4;
            label3.Text = "Password:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Lucida Console", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(16, 42);
            label2.Name = "label2";
            label2.Size = new Size(114, 21);
            label2.TabIndex = 3;
            label2.Text = "Usuario:";
            // 
            // btnIniciarSesion
            // 
            btnIniciarSesion.BackColor = Color.FromArgb(61, 153, 112);
            btnIniciarSesion.Font = new Font("Lucida Console", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnIniciarSesion.ForeColor = Color.White;
            btnIniciarSesion.Location = new Point(34, 180);
            btnIniciarSesion.Name = "btnIniciarSesion";
            btnIniciarSesion.Size = new Size(246, 45);
            btnIniciarSesion.TabIndex = 2;
            btnIniciarSesion.Text = "ENTRAR";
            btnIniciarSesion.UseVisualStyleBackColor = false;
            btnIniciarSesion.Click += btnIniciarSesion_ClickAsync;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Lucida Console", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txtPassword.Location = new Point(128, 104);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(170, 31);
            txtPassword.TabIndex = 1;
            txtPassword.KeyPress += txtPassword_KeyPress;
            // 
            // txtUser
            // 
            txtUser.Font = new Font("Lucida Console", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txtUser.Location = new Point(128, 37);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(170, 31);
            txtUser.TabIndex = 0;
            txtUser.KeyPress += txtUser_KeyPress;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(61, 153, 112);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(448, 192);
            panel1.Name = "panel1";
            panel1.Size = new Size(312, 60);
            panel1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Lucida Console", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(52, 18);
            label1.Name = "label1";
            label1.Size = new Size(206, 24);
            label1.TabIndex = 0;
            label1.Text = "Iniciar Sesion";
            // 
            // Inicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fondo_SICOSE;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1184, 761);
            Controls.Add(panel2);
            Controls.Add(panel1);
            MaximizeBox = false;
            Name = "Inicio";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SICOSE";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private Label label3;
        private Label label2;
        private Button btnIniciarSesion;
        private TextBox txtPassword;
        private TextBox txtUser;
        private Panel panel1;
        private Label label1;
    }
}