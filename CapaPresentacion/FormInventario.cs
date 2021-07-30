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
        public FormInventario()
        {
            InitializeComponent();
            cmbVariante.Enabled = false;
        }

        private void FormInventario_Load(object sender, EventArgs e)
        {
            MostrarInventario();
            ListarArticulo();
        }

        private void MostrarInventario()
        {
            CN_Inventario objetoCN = new CN_Inventario();
            dataGridView1.DataSource = objetoCN.MostrarInventario();
        }
        private void ListarArticulo()
        {
            CN_Articulo objCN = new CN_Articulo();
            cmbArticulo.DataSource = objCN.MostrarArticulos();
            cmbArticulo.DisplayMember = "Artículo";
            cmbArticulo.ValueMember = "ID";

        }

        private void cmbArticulo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbArticulo_SelectionChangeCommitted(object sender, EventArgs e)
        {
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
    }
}
