using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Biblioteka
{
    [Serializable]
    public class Knjiga:OpstiDomenskiObjekat
    {
        public override string ToString()
        {
            return naziv;
        }

        int knjigaID;
        [Browsable(false)]
        public int KnjigaID
        {
            get { return knjigaID; }
            set { knjigaID = value; }
        }
        string naziv;

        public string Naziv
        {
            get { return naziv; }
            set { naziv = value; }
        }
        double cena;

        public double Cena
        {
            get { return cena; }
            set { cena = value; }
        }
        string opis;

        public string Opis
        {
            get { return opis; }
            set { opis = value; }
        }
        string autor;
        [Browsable(false)]

        public string Autor
        {
            get { return autor; }
            set { autor = value; }
        }
        Dobavljac dobavljac;
        [DisplayName("Dobavljač")]
        public Dobavljac Dobavljac
        {
            get { return dobavljac; }
            set { dobavljac = value; }
        }

        public int kolicinaStanje;
        [DisplayName("Količina na stanju")]
        public int KolicinaStanje
        {
            get { return kolicinaStanje; }
            set { kolicinaStanje = value; }
        }

        [Browsable(false)]

        public string tabela
        {
            get { return "Knjiga"; }
        }
        [Browsable(false)]

        public string kljuc
        {
            get { return "KnjigaID"; }
        }
        [Browsable(false)]

        public string uslovJedan
        {
            get { return "KnjigaID="+knjigaID; }
        }
        [Browsable(false)]

        public string uslovVise
        {
            get { return "Autor='"+autor+"'"; }
        }
        [Browsable(false)]

        public string azuriranje
        {
            get { return "Cena="+cena+", Opis='"+opis+"', KolicinaStanje="+KolicinaStanje+""; }
        }
        [Browsable(false)]

        public string upisivanje
        {
            get { return "("+knjigaID+",'"+naziv+"',"+cena+",'"+opis+"','"+autor+"',"+dobavljac.DobavljacID+", "+kolicinaStanje+")"; }
        }



        public OpstiDomenskiObjekat napuni(System.Data.DataRow red)
        {
            Knjiga k = new Knjiga();
            k.knjigaID = Convert.ToInt32(red[0]);
            k.naziv = red[1].ToString();
            k.Cena = Convert.ToDouble(red[2]);
            k.opis = red[3].ToString();
            k.autor = red[4].ToString();
            k.dobavljac = new Dobavljac();
            k.dobavljac.DobavljacID = Convert.ToInt32(red[5]);
            k.kolicinaStanje = Convert.ToInt32(red[6]);
            return k;
        }
    }
}
