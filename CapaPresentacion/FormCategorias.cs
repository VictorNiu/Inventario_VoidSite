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
    public partial class FormCategorias : Form
    {
        CN_Categoria objetoCN = new CN_Categoria();
        private bool Editar = false;
        private string idCategoria = null;
        private string idVariante = null;
        private string idValorVariante = null;
        public FormCategorias()
        {
            InitializeComponent();
        }

        private void FormCategorias_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized; 
            MostrarTablas();
            ListarVariantes();
            ListarValorVariante();
            cmbVariante_Valor.SelectedIndex = -1;
            cmbVariante_Categoria.SelectedIndex = -1;
        }

        private void MostrarTablas()
        {
            CN_Categoria objetoCN = new CN_Categoria();
            dataGridView1.DataSource = objetoCN.MostrarCategorias();
            dataGridView2.DataSource = objetoCN.MostrarVariantes();
            dataGridView3.DataSource = objetoCN.MostrarValorVariante();
        }

        private void ListarVariantes()
        {
            CN_Categoria objeto = new CN_Categoria();
            cmbVariante_Categoria.DataSource = objeto.MostrarVariantes();
            cmbVariante_Categoria.DisplayMember = "Variante";
            cmbVariante_Categoria.ValueMember = "ID";
        }

        private void ListarValorVariante()
        {
            CN_Categoria objetoCN = new CN_Categoria();
            cmbVariante_Valor.DataSource = objetoCN.MostrarVariantes();
            cmbVariante_Valor.DisplayMember = "Variante";
            cmbVariante_Valor.ValueMember = "ID";
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(Editar == false)
            {
                try
                {
                    CN_Categoria objetoCN = new CN_Categoria();
                    objetoCN.InsertarCategoria(txtCategoria.Text, cmbVariante_Categoria.SelectedValue);
                    MessageBox.Show("La categoría se insertó correctamente.");
                    MostrarTablas();
                    limpiarForm();
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
                    CN_Categoria objetoCN = new CN_Categoria();
                    objetoCN.EditarCategoria(txtCategoria.Text, cmbVariante_Categoria.SelectedValue, idCategoria);
                    MessageBox.Show("Los datos se modificaron correctamente.");
                    MostrarTablas();
                    ListarVariantes();
                    ListarValorVariante();
                    Editar = false;
                    idCategoria = null;
                    limpiarForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al editar los datos :c \n" + ex);
                }
            }
        }

        private void limpiarForm()
        {
            Editar = false;
            txtCategoria.Clear();
            txtValorVariante.Clear();
            txtVariante.Clear();
            cmbVariante_Categoria.SelectedIndex = -1;
            cmbVariante_Valor.SelectedIndex = -1;
            ListarVariantes();
            ListarValorVariante();
        }

        private void btnEditarCategoria_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                Editar = true;
                idCategoria = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
                txtCategoria.Text = dataGridView1.CurrentRow.Cells["Categoría"].Value.ToString();
                cmbVariante_Categoria.Text = dataGridView1.CurrentRow.Cells["Tipo de variante"].Value.ToString();
            }
            else
                MessageBox.Show("Selecciona la fila a editar.");
        }

        private void btnEliminarCategoria_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    idCategoria = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
                    objetoCN.EliminarCategoria(idCategoria);
                    MessageBox.Show("Categoría eliminada.");
                    MostrarTablas();
                    ListarVariantes();
                    ListarValorVariante();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo eliminar la categoría.\n" + ex);
                }
            }
            else
                MessageBox.Show("Selecciona una fila para eliminar una categoría.");
        }

        private void btnEditarVariante_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                try
                {
                    Editar = true;
                    idVariante = dataGridView2.CurrentRow.Cells["ID"].Value.ToString();
                    txtVariante.Text = dataGridView2.CurrentRow.Cells["Variante"].Value.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo editar el registro.\n" + ex);
                }
            }
            else
                MessageBox.Show("Selecciona una fila a editar.");
        }

        private void btnGuardarVariante_Click(object sender, EventArgs e)
        {
            if(Editar == false)
            {
                try
                {
                    CN_Categoria objetoCN = new CN_Categoria();
                    objetoCN.InsertarVariante(txtVariante.Text);
                    MessageBox.Show("Variante agregada.");
                    MostrarTablas();
                    limpiarForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo agregar la variante :c\n" + ex);
                }
            }
            if(Editar == true)
            {
                try
                {
                    CN_Categoria objetoCN = new CN_Categoria();
                    objetoCN.EditarVariante(txtVariante.Text, idVariante);
                    MessageBox.Show("Variante actualizada.");
                    MostrarTablas();
                    limpiarForm();
                    Editar = false;
                    idVariante = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar variante." + ex);
                }
            }
        }

        private void btnEliminarVariante_Click(object sender, EventArgs e)
        {
            if(dataGridView2.SelectedRows.Count > 0)
            {
                try
                {
                    idVariante = dataGridView2.CurrentRow.Cells["ID"].Value.ToString();
                    CN_Categoria objetoCN = new CN_Categoria();
                    objetoCN.EliminarVariante(idVariante);
                    MessageBox.Show("Variante eliminada.");
                    MostrarTablas();
                    limpiarForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo eliminar la variante :/\n" + ex);
                }
            }
            else
                MessageBox.Show("Selecciona una fila para eliminar una variante.");
        }

        private void cmbVariante_Valor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbVariante_Valor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CN_Categoria objetoCN = new CN_Categoria();
            dataGridView3.DataSource = objetoCN.ListarValorVariante(cmbVariante_Valor.SelectedValue);
            cmbVariante_Valor.DisplayMember = "Variante";
            cmbVariante_Valor.ValueMember = "ID";
        }

        private void btnEditarValorV_Click(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count > 0)
            {
                Editar = true;
                idValorVariante = dataGridView3.CurrentRow.Cells["ID"].Value.ToString();
                cmbVariante_Valor.Text = dataGridView3.CurrentRow.Cells["Variante"].Value.ToString();
                txtValorVariante.Text = dataGridView3.CurrentRow.Cells["Valor"].Value.ToString();
            }
            else
                MessageBox.Show("Selecciona una fila para editar.");
        }

        private void btnGuardarValorV_Click(object sender, EventArgs e)
        {
            if(Editar == false)
            {
                try
                {
                    CN_Categoria objeto = new CN_Categoria();
                    objeto.InsertarValorVariante(cmbVariante_Valor.SelectedValue, txtValorVariante.Text);
                    MessageBox.Show("Se ingresó el valor.");
                    MostrarTablas();
                    limpiarForm();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("No se pudo ingresar el vaor :c\n" + ex);
                }
            }
            if(Editar == true)
            {
                try
                {
                    CN_Categoria objeto = new CN_Categoria();
                    objeto.EditarValorVariante(cmbVariante_Valor.SelectedValue, txtValorVariante.Text, idValorVariante);
                    MessageBox.Show("Se ingresó el valor.");
                    MostrarTablas();
                    limpiarForm();
                    Editar = false;
                    idValorVariante = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al editar el valor :s\n" + ex);
                }
            }
        }

        private void btnEliminarValorV_Click(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count > 0)
            {
                try
                {
                    idValorVariante = dataGridView3.CurrentRow.Cells["ID"].Value.ToString();
                    CN_Categoria obj = new CN_Categoria();
                    obj.EliminarValorVariante(idValorVariante);
                    MostrarTablas();
                    limpiarForm();
                    idValorVariante = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el valor :S\n" + ex);
                }
            }
            else
                MessageBox.Show("Selecciona una fila para eliminar un valor.");
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarForm();
            Editar = false;
        }

        private void btnLimpiar2_Click(object sender, EventArgs e)
        {
            limpiarForm();
            Editar = false;
        }

        private void btnLimpiar3_Click(object sender, EventArgs e)
        {
            limpiarForm();
            Editar = false;
        }
    }
}
