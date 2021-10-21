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
    public class CN_Historial
    {
        private CD_Historial objetoCD = new CD_Historial();

        public DataTable MostrarHistorial()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }

        public void RegistrarMovimiento(int id_operacion, int id_usuario, DateTime fecha, int id_inventario, int modificacion)
        {
            objetoCD.Registrar(id_operacion, id_usuario, fecha, id_inventario, modificacion);
        }
    }
}
