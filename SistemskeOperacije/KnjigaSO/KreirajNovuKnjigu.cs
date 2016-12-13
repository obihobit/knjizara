using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Biblioteka;

namespace SistemskeOperacije.KnjigaSO
{
    public class KreirajNovuKnjigu:OpstaSO
    {
        public override object Izvrsi(Biblioteka.OpstiDomenskiObjekat odo)
        {
            Knjiga k = new Knjiga();
            k.KnjigaID = Sesija.Broker.dajSesiju().dajSifru(odo);
            return k;
        }
    }
}
