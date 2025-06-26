using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration; // Esta linha é crucial

namespace Litly._02.DAL
{
    internal class DbConnectionHelper
    {
        public static Microsoft.Data.SqlClient.SqlConnection GetConnection()
        {
            // Obtenha a connection string do App.config
            string connectionString = ConfigurationManager.ConnectionStrings["LitlyDB"].ConnectionString;
            return new Microsoft.Data.SqlClient.SqlConnection(connectionString);
        }
    }
}
