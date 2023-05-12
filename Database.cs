using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSCS
{
    public static class DatabaseConnection
    {
        static MySqlConnection connection = null;
        public static MySqlConnection getDBConnection()
        {
            if (connection == null)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MySQL"].ConnectionString;
                connection = new MySqlConnection(connectionString);
            }
            return connection;
        }
    }
}
