using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class MainForm : Form
    {
        public static DateTime time;
        FormInventario inventario_form = new FormInventario();
        FormHistorial historial_form = new FormHistorial();
        FormArticulo articulo_form = new FormArticulo();
        FormCategorias categoria_form = new FormCategorias();
        FormUsuarios usuarios_form = new FormUsuarios();
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            statUsuario.Text = Login.nom_usuario;
            sysTimer.Start();
            if (Login.tipo_usuario == "emp")
            {
                menuItemUsuarios.Enabled = false;
            }
        }

        private void menuItemInventario_Click(object sender, EventArgs e)
        {
            inventario_form.MdiParent = this;
            hideForms();
            inventario_form.Show();
            inventario_form.ListarArticulo();
        }

        private void sysTimer_Tick(object sender, EventArgs e)
        {
            statTiempo.Text = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss");
            time = DateTime.Now;
        }

        private void menuItemArticulos_Click(object sender, EventArgs e)
        {
            articulo_form.MdiParent = this;
            hideForms();
            articulo_form.Show();
            articulo_form.ListarCategorias();
        }

        private void hideForms()
        {
            inventario_form.Hide();
            historial_form.Hide();
            articulo_form.Hide();
            categoria_form.Hide();
            usuarios_form.Hide();
        }

        private void menuItemHistorial_Click(object sender, EventArgs e)
        {
            historial_form.MdiParent = this;
            hideForms();
            historial_form.Show();
            historial_form.MostrarHistorial();
        }

        private void menuItemCategorias_Click(object sender, EventArgs e)
        {
            categoria_form.MdiParent = this;
            hideForms();
            categoria_form.Show();
        }

        private void menuItemUsuarios_Click(object sender, EventArgs e)
        {
            usuarios_form.MdiParent = this;
            hideForms();
            usuarios_form.Show();
        }
    }
}
