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
    public class CN_Inventario
    {
        private CD_Inventario objetoCD = new CD_Inventario();

        public DataTable MostrarInventario()
        {
            CD_Inventario objetoCD = new CD_Inventario();
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }

        public DataTable ListarVariantes(int id_articulo)
        {
            CD_Inventario objeto = new CD_Inventario();
            DataTable tabla = new DataTable();
            tabla = objeto.ListarVariantes(Convert.ToInt32(id_articulo));
            return tabla;
        }
    }
}
