using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Historial
    {
        private CD_Conexion conexion = new CD_Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable Mostrar()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarMovimientos";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            leer.Close();
            conexion.CerrarConexion();
            return tabla;
        }

        public DataTable Operaciones()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarOperacion";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            leer.Close();
            conexion.CerrarConexion();
            return tabla;
        }
        
        public void Registrar(int id_operacion, int id_usuario, DateTime fecha, int id_inventario, int modificacion)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "RegistrarMovimiento";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id_operacion", id_operacion);
            comando.Parameters.AddWithValue("@id_usuario", id_usuario);
            comando.Parameters.AddWithValue("@fecha", fecha);
            comando.Parameters.AddWithValue("@id_inventario", id_inventario);
            comando.Parameters.AddWithValue("@modificacion", modificacion);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }
    }
}
