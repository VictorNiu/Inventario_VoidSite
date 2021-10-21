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

        public void InsertarCategoria(string nombre, object id_variante)
        {
            objetoCD.InsertarCategoria(nombre, Convert.ToInt32(id_variante));
        }

        public void EditarCategoria(string nombre, object id_variante, string id_categoria)
        {
            objetoCD.EditarCategoria(nombre, Convert.ToInt32(id_variante), Convert.ToInt32(id_categoria));
        }

        public void EliminarCategoria(string id_categoria)
        {
            objetoCD.EliminarCategoria(Convert.ToInt32(id_categoria));
        }

        public DataTable MostrarVariantes()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarVarianteSP();
            return tabla;
        }

        public void InsertarVariante(string nombre)
        {
            objetoCD.InsertarVariante(nombre);
        }

        public void EditarVariante(string nombre, string id_variante)
        {
            objetoCD.EditarVariante(nombre, Convert.ToInt32(id_variante));
        }

        public void EliminarVariante(string id_variante)
        {
            objetoCD.EliminarVariante(Convert.ToInt32(id_variante));
        }

        public DataTable MostrarValorVariante()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarValorVarianteSP(); 
            return tabla;
        }
        public void InsertarValorVariante(object id_variante, string valor)
        {
            objetoCD.InsertarValorVariante(Convert.ToInt32(id_variante), valor);
        }

        public DataTable ListarValorVariante(object id_valor_variante)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.ListarValoresVariantes(Convert.ToInt32(id_valor_variante));
            return tabla;
        }
        public void EditarValorVariante(object id_variante, string valor, string id_valor_variante)
        {
            objetoCD.EditarValorVariante(Convert.ToInt32(id_variante), valor, Convert.ToInt32(id_valor_variante));
        }

        public void EliminarValorVariante(string id_valor_variante)
        {
            objetoCD.EliminarValorVariante(Convert.ToInt32(id_valor_variante));
        }
    }
}
