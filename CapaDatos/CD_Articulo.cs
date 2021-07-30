using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Articulo
    {
        private CD_Conexion conexion = new CD_Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable Mostrar()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarArticulos";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            leer.Close();
            conexion.CerrarConexion();
            return tabla;
        }

        public void Insertar(string nombre_articulo, double precio_articulo, int id_categoria)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarArticulo";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", nombre_articulo);
            comando.Parameters.AddWithValue("@precio", precio_articulo);
            comando.Parameters.AddWithValue("@id_categoria", id_categoria);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void Editar(int id_articulo, string nombre_articulo, double precio_articulo, int id_categoria)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EditarArticulo";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id_articulo", id_articulo);
            comando.Parameters.AddWithValue("@nom_articulo", nombre_articulo);
            comando.Parameters.AddWithValue("@precio", precio_articulo);
            comando.Parameters.AddWithValue("@id_categoria", id_categoria);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void Eliminar(int id_articulo)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarArticulo";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id_articulo", id_articulo);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }
    }
}
