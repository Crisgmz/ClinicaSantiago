using ClinicaSantiago.Modal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaSantiago.Comunes
{
    public static class MetodosComunes
    {
        public static void ResetGlobal()
        {
            Global.InfoUsuario = new Modal.InfoUsuario();
        }
        public static SqlConnection OpenConnectionString(SqlConnection sqlCon)
        {
            if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            sqlCon.Open();
            return sqlCon;
        }
        public static void GetInfoUsuario(DataTable dt)
        {
            Global.InfoUsuario = (from rw in dt.AsEnumerable()
                                  select new InfoUsuario()
                               {
                                   IDUsuario = Convert.ToInt32(rw["IDUsuario"]),
                                   NombreUsuario = Convert.ToString(rw["NombreUsuario"]),
                                   Contrasena = Convert.ToString(rw["Contrasena"]),
                                   TipoUsuario = Convert.ToInt32(rw["TipoUsuario"]),
                                   IDDoctor = Convert.ToInt32(rw["IDDoctor"])
                                  }).ToList().FirstOrDefault();
        }
    }

}
