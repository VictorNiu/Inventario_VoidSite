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
    public partial class FormInventario : Form
    {
        private string idInventario = null;
        private bool Editar = false;
        public FormInventario()
        {
            InitializeComponent();
            cmbVariante.Enabled = false;
        }

        private void FormInventario_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            MostrarInventario();
            LimpiarForm();
        }

        private void MostrarInventario()
        {
            CN_Inventario objetoCN = new CN_Inventario();
            dataGridView1.DataSource = objetoCN.MostrarInventario();
        }
        public void ListarArticulo()
        {
            CN_Articulo objCN = new CN_Articulo();
            cmbArticulo.DataSource = objCN.MostrarArticulos();
            cmbArticulo.DisplayMember = "Artículo";
            cmbArticulo.ValueMember = "ID";

        }

        private void RegistrarMovimientos(int id_operacion, string id_inventario_str, string cantidad_str)
        {
            int id_inventario = Convert.ToInt32(id_inventario_str);
            int cantidad = Convert.ToInt32(cantidad_str);
            CN_Historial obj = new CN_Historial();
            if (cantidad > 0)
                id_operacion = 3;
            if (cantidad < 0)
                id_operacion = 4;
            obj.RegistrarMovimiento(id_operacion, Convert.ToInt32(Login.id_usuario), MainForm.time, id_inventario, cantidad);
        }

        private void cmbArticulo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbArticulo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cmbVariante.Update();
            if (cmbArticulo.SelectedValue.ToString() != null)
            {
                int id_articulo = int.Parse(cmbArticulo.SelectedValue.ToString());
                CN_Inventario objeto = new CN_Inventario();
                cmbVariante.DisplayMember = "Variante";
                cmbVariante.ValueMember = "ID";
                cmbVariante.DataSource = objeto.ListarVariantes(id_articulo);
                cmbVariante.Enabled = true;
            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Editar == false)
            {
                try
                {
                    CN_Inventario objetoCN = new CN_Inventario();
                    int id_art = int.Parse(cmbArticulo.SelectedValue.ToString());
                    int id_var = int.Parse(cmbVariante.SelectedValue.ToString());
                    objetoCN.InsertarInventario(id_art, id_var, txtCantidad.Text);
                    MessageBox.Show("Registro ingresado.");
                    MostrarInventario();
                    LimpiarForm();
                    txtCantidad.Text = idInventario;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al insertar :c \n" + ex);
                }
            }
            if (Editar == true)
            {
                try
                {
                    CN_Inventario objetoCN = new CN_Inventario();
                    objetoCN.EditarInventario(cmbArticulo.SelectedValue, cmbVariante.SelectedValue, txtCantidad.Text, idInventario);
                    RegistrarMovimientos(5, idInventario, txtCantidad.Text);
                    MessageBox.Show("El registro de inventario se actualizó correctamente.");
                    MostrarInventario();
                    Editar = false;
                    LimpiarForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al editar los datos :c \n" + ex);
                }
            }
        }

        public void LimpiarForm()
        {
            cmbArticulo.SelectedIndex = -1;
            cmbVariante.SelectedIndex = -1;
            txtCantidad.Clear();
            ListarArticulo();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Editar = true;
                idInventario = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
                cmbArticulo.Text = dataGridView1.CurrentRow.Cells["Artículo"].Value.ToString();
                cmbVariante.Text = dataGridView1.CurrentRow.Cells["Variante"].Value.ToString();
                txtCantidad.Text = dataGridView1.CurrentRow.Cells["Cantidad"].Value.ToString();
                cmbVariante.Enabled = true;
            }
            else
                MessageBox.Show("Selecciona la fila a editar.");
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Editar = false;
            LimpiarForm();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    CN_Inventario obj = new CN_Inventario();
                    idInventario = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
                    obj.EliminarInventario(idInventario);
                    RegistrarMovimientos(2, idInventario, "0");
                    MessageBox.Show("Registro eliminado.");
                    MostrarInventario();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo eliminar el registro x.x" + ex);
                }
            }
            else
                MessageBox.Show("Selecciona una fila para eliminar el registro.");
            
        }

        private void cmbVariante_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
