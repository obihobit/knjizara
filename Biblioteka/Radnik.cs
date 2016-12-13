using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biblioteka
{
    [Serializable]
    public class Radnik:OpstiDomenskiObjekat
    {

        public override string ToString()
        {
            return ime;
        }

        int radnikID;

        public int RadnikID
        {
            get { return radnikID; }
            set { radnikID = value; }
        }
        string korisnickoIme;

        public string KorisnickoIme
        {
            get { return korisnickoIme; }
            set { korisnickoIme = value; }
        }
        string korisnickaSifra;

        public string KorisnickaSifra
        {
            get { return korisnickaSifra; }
            set { korisnickaSifra = value; }
        }
        string ime;

        public string Ime
        {
            get { return ime; }
            set { ime = value; }
        }
        string jmbg;

        public string Jmbg
        {
            get { return jmbg; }
            set { jmbg = value; }
        }

        public string tabela
        {
            get { return "Radnik"; }
        }

        public string kljuc
        {
            get { return "RadnikID"; }
        }

        public string uslovJedan
        {
            get { return "RadnikID="+radnikID; }
        }

        public string uslovVise
        {
            get { return "KorisnickoIme='"+korisnickoIme+"' and KorisnickaSifra='"+korisnickaSifra+"'"; }
        }

        public string azuriranje
        {
            get { return null; }
        }

        public string upisivanje
        {
            get { return null; }
        }

        public OpstiDomenskiObjekat napuni(System.Data.DataRow red)
        {
            Radnik r = new Radnik();
            r.radnikID = Convert.ToInt32(red[0]);
            r.korisnickoIme = red[1].ToString();
            r.KorisnickaSifra = red[2].ToString();
            r.Ime= red[3].ToString();
            r.Jmbg = red[4].ToString();

            return r;
        }
    }
}
