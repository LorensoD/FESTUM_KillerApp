using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestumClasses.Objects
{
    public class User
    {
        private int userID;
        private string gebruikersnaam;
        private List<int> vrienden = new List<int>();
        private string status;
        private string eMail;
        private byte[] profielfoto;
        private string wachtwoord;

        //Het ID van de User in de database
        public int UserID
        {
            get
            {
                return userID;
            }

            set
            {
                userID = value;
            }
        }

        //De gebruikersnaam van de User
        public string Gebruikersnaam
        {
            get
            {
                return gebruikersnaam;
            }

            set
            {
                gebruikersnaam = value;
            }
        }

        //Een lijst met integers waarin de ID's van de vrienden van de huidige User staan
        public List<int> Vrienden
        {
            get
            {
                return vrienden;
            }

            set
            {
                vrienden = value;
            }
        }

        //De status van de User
        public string Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        //De e-mail van de User
        public string EMail
        {
            get
            {
                return eMail;
            }

            set
            {
                eMail = value;
            }
        }

        //De profielfoto van de User opgeslagen als byte array
        public byte[] Profielfoto
        {
            get
            {
                return profielfoto;
            }

            set
            {
                profielfoto = value;
            }
        }

        //Het wachtwoord van de gebruiker
        public string Wachtwoord
        {
            get
            {
                return wachtwoord;
            }

            set
            {
                wachtwoord = value;
            }
        }

        public User(int userID, string gebruikersnaam, List<int> vrienden, string status, string eMail, byte[] profielfoto)
        {
            this.UserID = userID;
            this.Gebruikersnaam = gebruikersnaam;
            this.Vrienden = vrienden;
            this.Status = status;
            this.EMail = eMail;
            this.Profielfoto = profielfoto;
        }
    }
}
