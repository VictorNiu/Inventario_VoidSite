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

        public void InsertarInventario(int id_articulo, int valor, string cantidad)
        {
            objetoCD.Insertar(id_articulo, valor, Convert.ToInt32(cantidad));
        }

        public void EditarInventario(object id_articulo, object valor, string cantidad, string id_inventario)
        {
            objetoCD.Editar(Convert.ToInt32(id_articulo), Convert.ToInt32(valor), Convert.ToInt32(cantidad), Convert.ToInt32(id_inventario));
        }

        public void EliminarInventario(string id_inventario)
        {
            objetoCD.Eliminar(Convert.ToInt32(id_inventario));
        }
    }
}
