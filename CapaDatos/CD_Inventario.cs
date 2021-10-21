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

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable Mostrar()
        {
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
            SqlDataAdapter da = new SqlDataAdapter(comando);
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ListarVariantes";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("id_articulo", id_articulo);
            da.Fill(tabla);
            conexion.CerrarConexion();
            return tabla;
        }

        public void Insertar(int id_articulo, int id_valor, int cantidad)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarInventario";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id_articulo", id_articulo);
            comando.Parameters.AddWithValue("@id_valor_variante", id_valor);
            comando.Parameters.AddWithValue("@cantidad", cantidad);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void Editar(int id_articulo, int id_valor, int cantidad, int id_inventario)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EditarInventario";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id_articulo", id_articulo);
            comando.Parameters.AddWithValue("@id_valor_variante", id_valor);
            comando.Parameters.AddWithValue("@cantidad", cantidad);
            comando.Parameters.AddWithValue("@id_inventario", id_inventario);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void Eliminar(int id_inventario)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarInventario";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id_inventario", id_inventario);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }
    }
}
