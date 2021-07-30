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
    public class CN_Articulo
    {
        private CD_Articulo objetoCD = new CD_Articulo();

        public DataTable MostrarArticulos()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }

        public void InsertarArticulo(string nombre_articulo, string precio_articulo, object id_categoria)
        {
            objetoCD.Insertar(nombre_articulo, Convert.ToDouble(precio_articulo), Convert.ToInt32(id_categoria));
        }

        public void EditarArticulo(string id_articulo, string nombre_articulo, string precio_articulo, object id_categoria)
        {
            objetoCD.Editar(Convert.ToInt32(id_articulo), nombre_articulo, Convert.ToDouble(precio_articulo), Convert.ToInt32(id_categoria));
        }

        public void EliminarArticulo(string id_articulo)
        {
            objetoCD.Eliminar(Convert.ToInt32(id_articulo));
        }
    }
}
