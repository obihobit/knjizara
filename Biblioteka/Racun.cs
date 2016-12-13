using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Biblioteka
{
    [Serializable]
    public class Racun:OpstiDomenskiObjekat
    {


        int racunID;
        [DisplayName("RačunID")]
        public int RacunID
        {
            get { return racunID; }
            set { racunID = value; }
        }
        DateTime datum;

        public DateTime Datum
        {
            get { return datum; }
            set { datum = value; }
        }
        double ukIznos;
        [DisplayName("Ukupan iznos")]
        public double UkIznos
        {
            get { return ukIznos; }
            set { ukIznos = value; }
        }
        Radnik radnik;

        public Radnik Radnik
        {
            get { return radnik; }
            set { radnik = value; }
        }

        BindingList<StavkaRacuna> listaStavki;

        public BindingList<StavkaRacuna> ListaStavki
        {
            get { return listaStavki; }
            set { listaStavki = value; }
        }

        public Racun()
        {
            listaStavki = new BindingList<StavkaRacuna>();
        }

        [Browsable(false)]
        public string tabela
        {
            get { return "Racun"; }
        }

        [Browsable(false)]
        public string kljuc
        {
            get { return "RacunID"; }
        }

        [Browsable(false)]
        public string uslovJedan
        {
            get { return "RacunID="+racunID; }
        }

        [Browsable(false)]
        public string uslovVise
        {
            get { return "Datum='"+datum+"'"; }
        }

        [Browsable(false)]
        public string azuriranje
        {
            get { return "Datum='"+datum.ToShortDateString()+"', UkupanIznos="+ukIznos+""; }
        }

        [Browsable(false)]
        public string upisivanje
        {
            get { return "("+racunID+",'"+datum.ToShortDateString()+"',"+ukIznos+","+radnik.RadnikID+")"; }
        }

        public OpstiDomenskiObjekat napuni(System.Data.DataRow red)
        {
            Racun r = new Racun();
            r.RacunID = Convert.ToInt32(red[0]);
            r.Datum = Convert.ToDateTime(red[1]);
            r.UkIznos = Convert.ToDouble(red[2]);
            r.Radnik = new Radnik();
            r.Radnik.RadnikID = Convert.ToInt32(red[3]);
            return r;
        }
    }
}
