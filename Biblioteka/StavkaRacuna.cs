using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Biblioteka
{
    [Serializable]
    public class StavkaRacuna:OpstiDomenskiObjekat
    {

        int racunID;
        [DisplayName("RačunID")]
        public int RacunID
        {
            get { return racunID; }
            set { racunID = value; }
        }
        int rb;
        [DisplayName("Redni broj")]
        public int Rb
        {
            get { return rb; }
            set { rb = value; }
        }
        int kolicina;
        [DisplayName("Količina")]
        public int Kolicina
        {
            get { return kolicina; }
            set { kolicina = value; }
        }
        double vrednost;

        public double Vrednost
        {
            get { return vrednost; }
            set { vrednost = value; }
        }
        Knjiga knjiga;

        public Knjiga Knjiga
        {
            get { return knjiga; }
            set { knjiga = value; }
        }

        [Browsable(false)]
        public string tabela
        {
            get { return "StavkaRacuna"; }
        }

        [Browsable(false)]
        public string kljuc
        {
            get { return null; }
        }

        [Browsable(false)]
        public string uslovJedan
        {
            get { return "RacunID="+racunID+" and RbStavke="+rb; }
        }

        [Browsable(false)]
        public string uslovVise
        {
            get { return "RacunID=" + racunID; }
        }

        [Browsable(false)]
        public string azuriranje
        {
            get { return null; }
        }
        [Browsable(false)]
        public string upisivanje
        {
            get { return "("+racunID+","+rb+","+kolicina+","+vrednost+","+knjiga.KnjigaID+")"; }
        }

        public OpstiDomenskiObjekat napuni(System.Data.DataRow red)
        {
            StavkaRacuna sr = new StavkaRacuna();
            sr.RacunID = Convert.ToInt32(red[0]);
            sr.Rb = Convert.ToInt32(red[1]);
            sr.Kolicina = Convert.ToInt32(red[2]);
            sr.Vrednost = Convert.ToDouble(red[3]);
            sr.Knjiga = new Biblioteka.Knjiga();
            sr.Knjiga.KnjigaID = Convert.ToInt32(red[4]);

            return sr;
        }
    }
}
