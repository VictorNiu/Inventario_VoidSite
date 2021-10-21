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
    public partial class FormUsuarios : Form
    {
        CN_Usuarios objetoCN = new CN_Usuarios();
        private bool Editar = false;
        private string idUsuario = null;
        private string tipo_usuario = null;
        public FormUsuarios()
        {
            InitializeComponent();
        }

        private void FormUsuarios_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized; 
            MostrarUsuarios();
        }

        private void MostrarUsuarios()
        {
            CN_Usuarios objeto = new CN_Usuarios();
            dataGridView1.DataSource = objeto.MostrarUsuarios();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Editar == false)
            {
                try
                {
                    objetoCN.InsertarUsuario(txtUsuario.Text, txtNombre.Text, txtNoEmp.Text, tipoUsuario(), txtContra.Text);
                    MessageBox.Show("Usuario agregado correctamente.");
                    MostrarUsuarios();
                    limpiarForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al guardar los datos :c \n" + ex);
                }
            }
            if (Editar == true)
            {
                try
                {
                    objetoCN.EditarUsuario(txtUsuario.Text, txtNombre.Text, txtNoEmp.Text, tipoUsuario(), txtContra.Text, idUsuario);
                    MessageBox.Show("Datos de usuario actualizados correctamente.");
                    MostrarUsuarios();
                    Editar = false;
                    limpiarForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al editar los datos :c \n" + ex);
                }
            }
        }

        private String tipoUsuario()
        {   
            if (rbtnAdmin.Checked)
            {
                tipo_usuario = "admin";
            }
            if (rbtnEmpleado.Checked)
            {
                tipo_usuario = "emp";
            }
            return tipo_usuario;
        }

        private void limpiarForm()
        {
            txtUsuario.Clear();
            txtNombre.Clear();
            txtNoEmp.Clear();
            rbtnAdmin.Checked = false;
            rbtnEmpleado.Checked = false;
            txtContra.Clear();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                Editar = true;
                idUsuario = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
                txtUsuario.Text = dataGridView1.CurrentRow.Cells["Usuario"].Value.ToString();
                txtNombre.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                txtNoEmp.Text = dataGridView1.CurrentRow.Cells["No. de empleado"].Value.ToString();
                tipo_usuario = dataGridView1.CurrentRow.Cells["Tipo de usuario"].Value.ToString();
                check_rad();
                txtContra.Text = Login.acceso;
            }
            else
                MessageBox.Show("Selecciona la fila a editar.");
        }

        private void check_rad()
        {
            if (tipo_usuario == "admin")
            {
                rbtnAdmin.Checked = true;
            }
            if (tipo_usuario == "emp")
            {
                rbtnEmpleado.Checked = true;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Editar = false;
            limpiarForm();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
