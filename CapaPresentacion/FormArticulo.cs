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
    public partial class FormArticulo : Form
    {
        CN_Articulo objetoCN = new CN_Articulo();
        private string idArticulo = null;
        private bool Editar = false;

        public FormArticulo()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarArticulos();
            ListarCategorias();
            cmbCategoria.SelectedIndex = -1;
        }

        private void ListarCategorias()
        {
            CN_Categoria objeto = new CN_Categoria();
            cmbCategoria.DataSource = objeto.MostrarCategorias();
            cmbCategoria.DisplayMember = "Categoría";
            cmbCategoria.ValueMember = "ID";
        }

        private void MostrarArticulos()
        {
            CN_Articulo objeto = new CN_Articulo();
            dataGridView1.DataSource = objeto.MostrarArticulos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Editar == false)
            {
                try
                {
                    objetoCN.InsertarArticulo(txtArticulo.Text, txtPrecio.Text, cmbCategoria.SelectedValue);
                    MessageBox.Show("El artículo se insertó correctamente.");
                    MostrarArticulos();
                    limpiarForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al insertar :c \n" + ex);
                }
            }
            if(Editar == true)
            {
                try
                {
                    objetoCN.EditarArticulo(idArticulo, txtArticulo.Text, txtPrecio.Text, cmbCategoria.SelectedValue);
                    MessageBox.Show("Los datos del artículo se modificaron correctamente.");
                    MostrarArticulos();
                    Editar = false;
                    limpiarForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al editar los datos :c \n" + ex);
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Editar = true;
                idArticulo = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
                txtArticulo.Text = dataGridView1.CurrentRow.Cells["Artículo"].Value.ToString();
                txtPrecio.Text = dataGridView1.CurrentRow.Cells["Precio"].Value.ToString();
                cmbCategoria.Text = dataGridView1.CurrentRow.Cells["Categoría"].Value.ToString();
            }
            else
                MessageBox.Show("Selecciona la fila a editar.");
        }

        private void limpiarForm()
        {
            txtArticulo.Clear();
            txtPrecio.Clear();
            cmbCategoria.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idArticulo = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
                objetoCN.EliminarArticulo(idArticulo);
                MessageBox.Show("Artículo eliminado.");
                MostrarArticulos();
            }
            else
                MessageBox.Show("Selecciona una fila para eliminar un artículo.");
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
