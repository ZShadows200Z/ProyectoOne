using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;//Agrega el Plugin: Microsoft.Data.SqlClient dentro de Packetes Nugget

namespace GestorEmpleado.DAL
{
    public class Connection
    {
        //Propiedades para realizar la conexión
        private readonly static string Server = "WINTERBOX400\\SQL2022";//Shadow, esto cambialo por tu Servidor SQL
        private readonly static string Database = "DB_GestorEmpleados";
        private readonly static string User = "sa";//Esto cambialo por el nombre de tu usuario en tu servidor SQL
        private readonly static string Password = "1234"; //Esto cambialo por tu contraseña de tu usuario SQL
        //private readonly static string Server = "localhost"; //Soy shadow para mi no es necesario cambiar Database y user
        //private readonly static string Password = "srshadows200";

        public static string ConextionString(bool SqlAuthentication = true)
        {
            SqlConnectionStringBuilder conn = new SqlConnectionStringBuilder();//Esto crea un constructor de conexion
            conn.ApplicationName = "MySystem";
            conn.IntegratedSecurity = !SqlAuthentication;
            conn.DataSource = Server;
            conn.InitialCatalog = Database;
            conn.TrustServerCertificate = true;

            if (SqlAuthentication)
            {
                conn.UserID = User;
                conn.Password = Password;
            }
            return conn.ConnectionString;
        }
    }
}
