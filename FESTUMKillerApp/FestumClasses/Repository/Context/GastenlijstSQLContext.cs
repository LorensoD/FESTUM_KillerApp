using FestumClasses.Objects;
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
    class GastenlijstSQLContext: Database, IGastenlijstContext
    {
        private SqlConnection conn = getConnection();

        public List<User> getAllGasten(int feestId)
        {
            List<int> UserIds = new List<int>();
            List<User> Users = new List<User>();

            string getGastenId = @"SELECT UserId FROM Gastenlijst WHERE FeestId = @id";
            string getUsers = @"SELECT UserId, Gebruikersnaam FROM [User] WHERE UserId = @id";

            SqlCommand GetGastenId = new SqlCommand(getGastenId, conn);
            GetGastenId.Parameters.AddWithValue("id", feestId);

            using (SqlDataReader reader = GetGastenId.ExecuteReader())
            {
                while (reader.Read())
                {
                    UserIds.Add((int)reader["UserId"]);
                }
            }

            foreach(int id in UserIds)
            {
                SqlCommand GetUsers = new SqlCommand(getUsers, conn);
                GetUsers.Parameters.AddWithValue("id", id);

                using (SqlDataReader reader = GetUsers.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Users.Add(new User((int)reader["UserId"], (string)reader["Gebruikersnaam"]));
                    }
                    return Users;
                }
            }

           
        }


        public object getValue(int id)
        {
            throw new NotImplementedException();
        }

        public void saveValue(int userId, int feestId)
        {
            string InsertQuery = @"INSERT INTO Gastenlijst (FeestId, UserId) VALUES (@feestId, @userId)";
            using (SqlCommand cmd = new SqlCommand(InsertQuery, conn))
            {
                cmd.Parameters.AddWithValue("feestId", feestId);
                cmd.Parameters.AddWithValue("userId", userId);
                cmd.ExecuteNonQuery();
            }
        }

        public void deleteValue(int userId, int feestId)
        {
            string DeleteQuery = @"DELETE FROM [Gastenlijst] WHERE UserId = @id AND FeestId = @fid";
            using (SqlCommand cmd = new SqlCommand(DeleteQuery, conn))
            {
                cmd.Parameters.AddWithValue("id", userId);
                cmd.Parameters.AddWithValue("fid", feestId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
