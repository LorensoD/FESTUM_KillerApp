using FestumClasses.Objects.Data;
using FestumClasses.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestumClasses.Repository.Context
{
    class ChatSQLContext: Database, IMainContext
    {
        private SqlConnection conn = getConnection();

        public List<object> getAllValues()
        {
            throw new NotImplementedException();
        }


        public object getValue(int id)
        {
            throw new NotImplementedException();
        }

        public void saveValue(object bericht)
        {
            string InsertQuery = @"INSERT INTO Bericht (UserIdZender, ChatId, Tekst, Tijd, Datum, Melding) 
                                    VALUES (1, 1, @bericht, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, 0);";
            using (SqlCommand cmd = new SqlCommand(InsertQuery, conn))
            {
                cmd.Parameters.AddWithValue("bericht", (string)bericht);
                cmd.ExecuteNonQuery();
            }
        }

        public void deleteValue(object userId)
        {
            throw new NotImplementedException();
        }
    }
}
