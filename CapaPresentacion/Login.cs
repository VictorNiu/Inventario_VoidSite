using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class Login : Form
    {
        public static string nom_usuario;
        public static string tipo_usuario;
        public static string acceso;

        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text != "")
            {
                if (txtAcceso.Text != "")
                {
                    CN_Login sesion_usuario = new CN_Login();
                    var usuario_valido = sesion_usuario.CN_UsuarioLogin(txtUsuario.Text, txtAcceso.Text);
                    if (usuario_valido.Rows.Count > 0)
                    {
                        MainForm mainForm = new MainForm();
                        nom_usuario = usuario_valido.Rows[0][3].ToString();
                        tipo_usuario = usuario_valido.Rows[0][2].ToString();
                        acceso = usuario_valido.Rows[0][1].ToString();
                        MessageBox.Show("Bienvenido " + nom_usuario);
                        this.Hide();
                        mainForm.ShowDialog();
                        limpiarForm();
                        this.Show();
                        txtUsuario.Focus();
                    }
                    else
                    {
                        mensajeError("Credenciales incorrectas.");
                        txtUsuario.Focus();
                    }
                }
                else
                {
                    mensajeError("Ingresa una contraseña.");
                    txtAcceso.Focus();
                }
            }
            else
            {
                mensajeError("Ingresa un usuario.");
                txtUsuario.Focus();
            }
        }

        private void mensajeError(string mensaje)
        {
            lblError.Text = mensaje;
            lblError.Visible = true;
        }

        private void limpiarForm()
        {
            txtUsuario.Clear();
            txtAcceso.Clear();
        }
        private void Login_Load(object sender, EventArgs e)
        {
            
        }
    }
}
