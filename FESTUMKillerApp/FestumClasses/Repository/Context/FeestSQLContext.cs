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
    class FeestSQLContext: Database, IMainContext 
    {
        private SqlConnection conn = getConnection();

        public List<object> getAllValues()
        {
            List<Feest> feesten = new List<Feest>();

            string getFeest = @"SELECT FeestId, Naam, Locatie, Beschrijving, Plaatje, AanvangTijd, Datum, OrganisatorId FROM [Feest]";
            SqlCommand GetFeest = new SqlCommand(getFeest, conn);

            using (SqlDataReader reader = GetFeest.ExecuteReader())
            {
                while (reader.Read())
                {
                    feesten.Add(new Feest((int)reader["FeestId"], (string)reader["Naam"], (string)reader["Locatie"], (string)reader["Beschrijving"], (int)reader["OrganisatorId"], (byte[])reader["Plaatje"], (DateTime)((DateTime)reader["Datum"] + (TimeSpan)reader["AanvangTijd"])));
                }
            }
            return feesten.Cast<object>().ToList();
        }


        public object getValue(int id)
        {
            List<int> gasten = new List<int>();

            string getFeest = @"SELECT FeestId, Naam, Locatie, Beschrijving, Plaatje, AanvangTijd, Datum, OrganisatorId FROM [Feest] WHERE FeestId = @id";
            string getGuests = @"SELECT UserId FROM Gastenlijst WHERE FeestId = @id";

            SqlCommand GetFeest = new SqlCommand(getFeest, conn);
            GetFeest.Parameters.AddWithValue("id", id);

            SqlCommand GetGuests = new SqlCommand(getGuests, conn);
            GetGuests.Parameters.AddWithValue("id", id);

            using (SqlDataReader reader = GetGuests.ExecuteReader())
            {
                if (reader.Read())
                {
                    gasten.Add((int)reader["UserId"]);
                }
            }

            using (SqlDataReader reader = GetFeest.ExecuteReader())
            {
                if (reader.Read())
                {
                    Feest fissa = new Feest((int)reader["FeestId"], (string)reader["Naam"], (string)reader["Locatie"], (string)reader["Beschrijving"], (int)reader["OrganisatorId"], gasten, (DateTime)((DateTime)reader["Datum"] + (TimeSpan)reader["AanvangTijd"]));
                    return fissa;
                }
            }
            return null;
        }

        public void saveValue(object value)
        {
            Feest obj = (Feest)value;

            string InsertQuery = @"INSERT INTO Feest (Naam, Locatie, Beschrijving, Plaatje, AanvangTijd, Datum, OrganisatorId) VALUES (@naam, @locatie, @beschrijving, @plaatje, @aanvangTijd, @datum, @organisator)";
            using (SqlCommand cmd = new SqlCommand(InsertQuery, conn))
            {
                cmd.Parameters.AddWithValue("naam", (string)obj.Naam);
                cmd.Parameters.AddWithValue("locatie", (string)obj.Locatie);
                cmd.Parameters.AddWithValue("beschrijving", (string)obj.Beschrijving);
                cmd.Parameters.AddWithValue("plaatje", (byte[])obj.Plaatje);
                cmd.Parameters.AddWithValue("aanvangTijd", obj.DatumTijdFeest.TimeOfDay);
                cmd.Parameters.AddWithValue("datum", obj.DatumTijdFeest.Date);
                cmd.Parameters.AddWithValue("organisator", (int)obj.HostFeest);
                cmd.ExecuteNonQuery();
            }
        }

        public void deleteValue(object value)
        {
            string DeleteQuery = @"DELETE FROM [Feest] WHERE FeestId = @id";
            using (SqlCommand cmd = new SqlCommand(DeleteQuery, conn))
            {
                cmd.Parameters.AddWithValue("id", ((Feest)value).FeestID);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
