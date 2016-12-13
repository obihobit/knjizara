using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Biblioteka;

namespace SistemskeOperacije.DobavljacSO
{
    public class KreirajNovogDobavljaca:OpstaSO
    {
        public override object Izvrsi(Biblioteka.OpstiDomenskiObjekat odo)
        {
            Dobavljac d = odo as Dobavljac;
            d.DobavljacID = Sesija.Broker.dajSesiju().dajSifru(d);
            return d;
        }
    }
}
