using FestumClasses.Objects;
using FestumClasses.Objects.Data;
using FestumClasses.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestumClasses.Repository.Context
{
    class UserSQLContext : Database, IUserContext
    {
        private SqlConnection conn = getConnection();

        public List<object> getAllValues()
        {
            throw new NotImplementedException();
        }


        public object getValue(int id)
        {
            List<int> vrienden = new List<int>();

            string Getuser = @"SELECT UserId, Gebruikersnaam, Status, [E-mail], Profielfoto FROM [User] WHERE UserId = @id";
            string Getfriends = @"SELECT UserIdVriend FROM Vriendenlijst WHERE UserId = @id";

            SqlCommand GetUser = new SqlCommand(Getuser, conn);
            GetUser.Parameters.AddWithValue("id", id);

            SqlCommand GetFriends = new SqlCommand(Getfriends, conn);
            GetFriends.Parameters.AddWithValue("id", id);

            using (SqlDataReader reader = GetFriends.ExecuteReader())
            {
                if (reader.Read())
                {
                    vrienden.Add((int)reader["UserIdVriend"]);
                }
            }

            using (SqlDataReader reader = GetUser.ExecuteReader())
            {
                if (reader.Read())
                {
                    User gebruiker = new User((int)reader["UserId"], (string)reader["Gebruikersnaam"], vrienden, (string)reader["Status"], (string)reader["E-mail"], (byte[])reader["Profielfoto"]);
                    return gebruiker;
                }
            }
            return null;
        }

        public void saveValue(object value)
        {
            User obj = (User)value;

            string InsertQuery = @"INSERT INTO [User] (Gebruikersnaam, Wachtwoord, Status, [E-mail], Profielfoto) VALUES (@gebruikersnaam, @wachtwoord, @status, @e-mail, @profielfoto)";
            using (SqlCommand cmd = new SqlCommand(InsertQuery, conn))
            {
                cmd.Parameters.AddWithValue("gebruikersnaam", (string)obj.Gebruikersnaam);
                cmd.Parameters.AddWithValue("wachtwoord", (string)obj.Wachtwoord);
                cmd.Parameters.AddWithValue("status", (string)obj.Status);
                cmd.Parameters.AddWithValue("e-mail", (string)obj.EMail);
                cmd.Parameters.AddWithValue("profielfoto", obj.Profielfoto);
                obj.Wachtwoord = "";
                cmd.ExecuteNonQuery();
            }
        }

        public int tryLogin(string username, string password)
        {
            string loginValidQuery = "SELECT UserId, Wachtwoord FROM [User] WHERE Gebruikersnaam = @username";
            SqlCommand getLogin = new SqlCommand(loginValidQuery, conn);
            getLogin.Parameters.AddWithValue("username", username);

            using (SqlDataReader reader = getLogin.ExecuteReader())
            {
                if (reader.Read())
                {
                    if (reader["Wachtwoord"].ToString().Equals(password))
                    {
                        return (int)reader["UserId"];
                    }
                }
            }

            return -1;
        }

        public void deleteValue(object value)
        {
            string DeleteQuery = @"DELETE FROM [User] WHERE UserId = @id";
            using (SqlCommand cmd = new SqlCommand(DeleteQuery, conn))
            {
                cmd.Parameters.AddWithValue("id", ((User)value).UserID);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
