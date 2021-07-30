using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Categoria
    {
        private CD_Categoria objetoCD = new CD_Categoria();

        public DataTable MostrarCategorias()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarCategoriaSP(); ;
            return tabla;
        }

        public DataTable MostrarVariantes()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarVarianteSP(); ; ;
            return tabla;
        }

        public DataTable MostrarValorVariante()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarValorVarianteSP(); ; ;
            return tabla;
        }
    }
}
