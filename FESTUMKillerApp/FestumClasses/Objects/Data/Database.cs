using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestumClasses.Objects.Data
{
    public abstract class Database
    {
        private const string connectionString = @"Data Source=LORENSO-LAPPIE;Initial Catalog=Fissa database;Integrated Security=True";

        protected static SqlConnection getConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}
