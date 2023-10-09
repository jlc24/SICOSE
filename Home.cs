using SICOSE.Controles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SICOSE
{
    public partial class Home : Form
    {
        private ConfigControl configControl;
        private Usuario usuario;
        public Home(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;

            lblUsuario.Text = usuario.Nombre + " " + usuario.Apellido;

            if (usuario.Tipo == "1")
            {
                lblTipo.Text = "Administrador";
            }

            lblCorreo.Text = usuario.Correo;
            lblID.Text = usuario.ID;
            lblArea.Text = usuario.Area;
            lblRol.Text = usuario.Rol;

            //LoadConfigControl();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            gpBoxPeatones.Visible = true;
            btnPeatones.Enabled = false;
        }

        private void btnPCancelar_Click(object sender, EventArgs e)
        {
            gpBoxPeatones.Visible = false;
            btnPeatones.Enabled = true;
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            LoadConfigControl();
        }

        private void LoadConfigControl()
        {
            configControl = new ConfigControl();
            configControl.parentForm = this;
            configControl.Dock = DockStyle.Fill;
            pnlDetalle.Controls.Add(configControl);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            try
            {
                if (configControl != null)
                {
                    if (configControl.cmbldx.Items.Count > 0)
                    {
                        configControl.OnDisconnect();
                    }
                }
            }
            catch { }

            var inicioForm = new Inicio();
            inicioForm.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                if (configControl != null)
                {
                    if (configControl.cmbldx.Items.Count > 0)
                    {
                        configControl.OnDisconnect();
                    }
                }
            }
            catch { }

            this.Hide();

        }
    }
}
