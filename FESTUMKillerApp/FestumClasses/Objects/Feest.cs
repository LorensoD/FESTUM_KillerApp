using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestumClasses.Objects
{
    public class Feest
    {
        private int feestID;
        private string naam;
        private string locatie;
        private string beschrijving;
        private byte[] plaatje;
        private int hostFeest;
        private List<int> gasten = new List<int>();
        private DateTime datumTijdFeest;
        private List<FotoVerhaal> fotoVerhaal = new List<FotoVerhaal>();

        //Het ID van het Feest in de database
        public int FeestID
        {
            get
            {
                return feestID;
            }

            set
            {
                feestID = value;
            }
        }

        //De naam van het feest
        public string Naam
        {
            get
            {
                return naam;
            }

            set
            {
                naam = value;
            }
        }

        //De locatie van het feest
        public string Locatie
        {
            get
            {
                return locatie;
            }

            set
            {
                locatie = value;
            }
        }

        //De beschrijving van het feest
        public string Beschrijving
        {
            get
            {
                return beschrijving;
            }

            set
            {
                beschrijving = value;
            }
        }

        //De host van het feest opgeslagen als de UserId van de host
        public int HostFeest
        {
            get
            {
                return hostFeest;
            }

            set
            {
                hostFeest = value;
            }
        }

        //Een lijst met UserId's van alle gasten van het feest
        public List<int> Gasten
        {
            get
            {
                return gasten;
            }

            set
            {
                gasten = value;
            }
        }

        //De Datum en Tijd waarop het feest zal plaatsvinden
        public DateTime DatumTijdFeest
        {
            get
            {
                return datumTijdFeest;
            }

            set
            {
                datumTijdFeest = value;
            }
        }

        //Het foto verhaal van het feest, opgeslagen als een list van FotoVerhaal instanties
        internal List<FotoVerhaal> FotoVerhaal
        {
            get
            {
                return fotoVerhaal;
            }

            set
            {
                fotoVerhaal = value;
            }
        }

        //Het plaatje van het feest
        public byte[] Plaatje
        {
            get
            {
                return plaatje;
            }

            set
            {
                plaatje = value;
            }
        }

        public Feest(int feestID, string naam, string locatie, string beschrijving, int hostFeest, List<int> gasten, DateTime datumTijdFeest, List<FotoVerhaal> fotoVerhaal)
        {
            this.FeestID = feestID;
            this.Naam = naam;
            this.Locatie = locatie;
            this.Beschrijving = beschrijving;
            this.HostFeest = hostFeest;
            this.Gasten = gasten;
            this.DatumTijdFeest = datumTijdFeest;
            this.FotoVerhaal = fotoVerhaal;
        }

        public Feest(string naam, string locatie, string beschrijving, int hostFeest, List<int> gasten, DateTime datumTijdFeest)
        {
            this.Naam = naam;
            this.Locatie = locatie;
            this.Beschrijving = beschrijving;
            this.HostFeest = hostFeest;
            this.Gasten = gasten;
            this.DatumTijdFeest = datumTijdFeest;
        }
    }
}
