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
    public class CN_Login
    {
        private CD_Login objetoCD = new CD_Login();

        public DataTable CN_UsuarioLogin(string usuario, string acceso)
        {
            return objetoCD.UsuarioLogin(usuario, acceso);
        }
    }
}
