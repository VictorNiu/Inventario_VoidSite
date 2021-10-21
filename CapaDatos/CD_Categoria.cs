using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Categoria
    {
        private CD_Conexion conexion = new CD_Conexion();
        SqlCommand comando = new SqlCommand();

        public DataTable MostrarCategoriaSP()
        {
            SqlDataReader leer;
            DataTable tabla = new DataTable();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarCategoria";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            leer.Close();
            conexion.CerrarConexion();
            return tabla;
        }

        public void InsertarCategoria(string nombre, int id_variante)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarCategoria";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nom_categoria", nombre);
            comando.Parameters.AddWithValue("@id_variante", id_variante);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void EditarCategoria(string nombre, int id_variante, int id_categoria)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EditarCategoria";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nom_categoria", nombre);
            comando.Parameters.AddWithValue("@id_variante", id_variante);
            comando.Parameters.AddWithValue("@id_categoria", id_categoria);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }


        public void EliminarCategoria(int id_categoria)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarCategoria";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id_categoria", id_categoria);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public DataTable MostrarVarianteSP()
        {
            SqlDataReader leer;
            DataTable tabla = new DataTable();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarVariantes";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            leer.Close();
            conexion.CerrarConexion();
            return tabla;
        }

        public void InsertarVariante(string nombre)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarVariantes";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre_variante", nombre);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void EditarVariante(string nombre, int id_variante)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EditarVariantes";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre_variante", nombre);
            comando.Parameters.AddWithValue("@id_variante", id_variante);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void EliminarVariante(int id_variante)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarVariantes";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id_variante", id_variante);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public DataTable MostrarValorVarianteSP()
        {
            SqlDataReader leer;
            DataTable tabla = new DataTable();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarValorVariante";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            leer.Close();
            conexion.CerrarConexion();
            return tabla;
        }

        public DataTable ListarValoresVariantes(int id_variante)
        {
            DataTable tabla = new DataTable();
            SqlCommand comando = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ListarValoresVariantes";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("id_variante", id_variante);
            da.Fill(tabla);
            conexion.CerrarConexion();
            return tabla;
        }

        public void InsertarValorVariante(int id_variante, string valor)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarValorVariante";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id_variante", id_variante);
            comando.Parameters.AddWithValue("@valor", valor);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void EditarValorVariante(int id_variante, string valor, int id_valor_variante)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EditarValorVariante";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id_variante", id_variante);
            comando.Parameters.AddWithValue("@valor", valor);
            comando.Parameters.AddWithValue("@id_valor_variante", id_valor_variante);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void EliminarValorVariante(int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarValorVariante";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id_valor_variante", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }
    }
}
