using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Inventario
    {
        private CD_Conexion conexion = new CD_Conexion();

        public DataTable Mostrar()
        {
            SqlDataReader leer;
            DataTable tabla = new DataTable();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarInventario";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            leer.Close();
            conexion.CerrarConexion();
            return tabla;
        }

        public DataTable ListarVariantes(int id_articulo)
        {
            DataTable tabla = new DataTable();
            SqlCommand comando = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ListarVariantes";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("id_articulo", id_articulo);
            da.Fill(tabla);
            conexion.CerrarConexion();
            return tabla;
        }
    }
}
