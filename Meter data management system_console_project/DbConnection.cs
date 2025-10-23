using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meter_data_management_system
{
    public static class DBConnection
    {
        // Server name
        private static string DataSource = @"LAPTOP-DANMUS7P\SQLEXPRESS";

        // Database name
        private static string Database = "MDMS";

        // Connection string
        private static string ConnectionString =
            @"Data Source=" + DataSource + ";Initial Catalog=" + Database + ";Trusted_Connection=True;";

        // ✅ Method to get a SqlConnection object
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}

