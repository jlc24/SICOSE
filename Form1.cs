using Newtonsoft.Json;
using SICOSE.Controles;
using System.ComponentModel;
using System.Windows.Forms;

namespace SICOSE
{
    public partial class Inicio : Form
    {
        private readonly string ip = "http://sicose_puntocom.test/";

        public Inicio()
        {
            InitializeComponent();
        }

        private async void btnIniciarSesion_ClickAsync(object sender, EventArgs e)
        {
            string usuario = txtUser.Text;
            string password = txtPassword.Text;
            if (usuario == "")
            {
                MessageBox.Show("Ingreser Usuario", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (password == "")
            {
                MessageBox.Show("Ingreser Contraseña", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                await IniciarSesionasync(usuario, password);
            }

        }

        public async Task IniciarSesionasync(string usuario, string password)
        {
            string url = $"{ip}/desktop/iniciar_sesion.php?user={usuario}&password={password}";

            using (HttpClient httpclient = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await httpclient.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        dynamic resultado = JsonConvert.DeserializeObject(json);

                        string message = resultado.message;

                        if (message == "ingreso correctamente")
                        {
                            txtUser.Text = "";
                            txtPassword.Text = "";
                            MessageBox.Show(message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            Usuario user = new Usuario
                            {
                                ID = resultado.id,
                                Nombre = resultado.nombre,
                                Apellido = resultado.apellido,
                                Correo = resultado.correo,
                                Tipo = resultado.tipo,
                                Area = resultado.area,
                                Rol = resultado.rol,
                            };

                            this.Hide();

                            Home home = new Home(user);
                            home.ShowDialog();
                        }
                        else
                        {
                            txtUser.Text = "";
                            txtPassword.Text = "";
                            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtUser.Focus();
                        }
                    }
                    else
                    {
                        txtUser.Text = "";
                        txtPassword.Text = "";
                        MessageBox.Show("Error en la solicitud: " + response.StatusCode.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtUser.Focus();
                    }
                }
                catch (Exception ex)
                {
                    txtUser.Text = "";
                    txtPassword.Text = "";
                    MessageBox.Show("Error en la solicitud: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            Application.Exit();

        }

        private async void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                string usuario = txtUser.Text;
                string password = txtPassword.Text;
                if (usuario == "")
                {
                    MessageBox.Show("Ingreser Usuario", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtUser.Text = "";
                    txtUser.Focus();
                }
                else if (password == "")
                {
                    MessageBox.Show("Ingreser Contraseña", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPassword.Text = "";
                    txtPassword.Focus();
                }
                else
                {
                    await IniciarSesionasync(usuario, password);
                }
            }
        }

        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Cancelar el caracter no válido
            }
        }
    }
}