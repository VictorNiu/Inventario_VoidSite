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
        public FormCategorias()
        {
            InitializeComponent();
        }

        private void FormCategorias_Load(object sender, EventArgs e)
        {
            MostrarTablas();
        }

        private void MostrarTablas()
        {
            CN_Categoria objetoCN = new CN_Categoria();
            dataGridView1.DataSource = objetoCN.MostrarCategorias();
            dataGridView2.DataSource = objetoCN.MostrarVariantes();
            dataGridView3.DataSource = objetoCN.MostrarValorVariante();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
