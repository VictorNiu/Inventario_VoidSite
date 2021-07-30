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
    public partial class FormHistorial : Form
    {
        CN_Articulo objetoCN = new CN_Articulo();
        public FormHistorial()
        {
            InitializeComponent();
        }

        private void FormHistorial_Load(object sender, EventArgs e)
        {
            MostrarHistorial();
        }

        private void MostrarHistorial()
        {
            CN_Historial objetoCN = new CN_Historial();
            dataGridView1.DataSource = objetoCN.MostrarHistorial();
        }
    }
}
