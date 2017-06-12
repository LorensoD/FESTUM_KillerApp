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
        private const string connectionString = @"Data Source=192.168.19.100;Initial Catalog=Fissa database;Integrated Security=False;User ID=admin;Password=admin;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //@"Data Source=LORENSO-LAPPIE;Initial Catalog=Fissa database;Integrated Security=True"
        protected static SqlConnection getConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}
