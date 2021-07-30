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
    public class CN_Usuarios
    {
        private CD_Usuarios objetoCD = new CD_Usuarios();

        public DataTable MostrarUsuarios()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }

        public void InsertarUsuario(string usuario, string nombre, string num_emp, string tipo, string contra)
        {
            objetoCD.Insertar(usuario, nombre, Convert.ToInt32(num_emp), tipo, contra);
        }

        public void EditarUsuario(string usuario, string nombre, string num_emp, string tipo, string contra, string id)
        {
            objetoCD.Editar(usuario, nombre, Convert.ToInt32(num_emp), tipo, contra, Convert.ToInt32(id));
        }
    }
}
