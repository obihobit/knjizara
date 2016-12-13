using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Biblioteka;

namespace SistemskeOperacije.RacunSO
{
    public class KreirajNoviRacun:OpstaSO
    {
        public override object Izvrsi(Biblioteka.OpstiDomenskiObjekat odo)
        {
            Racun r=new Racun();
            r.RacunID = Sesija.Broker.dajSesiju().dajSifru(odo);
            return r;
        }
    }
}
