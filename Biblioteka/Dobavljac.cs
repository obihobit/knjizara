using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biblioteka
{
    [Serializable]
    public class Dobavljac:OpstiDomenskiObjekat
    {

        public override string ToString()
        {
            return naziv;
        }

        int dobavljacID;

        public int DobavljacID
        {
            get { return dobavljacID; }
            set { dobavljacID = value; }
        }
        string naziv;

        public string Naziv
        {
            get { return naziv; }
            set { naziv = value; }
        }
        string pib;

        public string Pib
        {
            get { return pib; }
            set { pib = value; }
        }


        public string tabela
        {
            get { return "Dobavljac"; }
        }

        public string kljuc
        {
            get { return "DobavljacID"; }
        }

        public string uslovJedan
        {
            get { return "DobavljacID="+dobavljacID; }
        }

        public string uslovVise
        {
            get { return "Pib='"+pib+"'"; }
        }

        public string azuriranje
        {
            get { return "Pib='"+pib+"', Naziv='"+naziv+"'"; }
        }

        public string upisivanje
        {
            get { return "("+dobavljacID+",'"+naziv+"','"+pib+"')"; }
        }

        public OpstiDomenskiObjekat napuni(System.Data.DataRow red)
        {
            Dobavljac d = new Dobavljac();
            d.DobavljacID = Convert.ToInt32(red[0]);
            d.naziv = red[1].ToString();
            d.pib = red[2].ToString();

            return d;
        }
    }
}
