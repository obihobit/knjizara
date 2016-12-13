using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Biblioteka;

namespace SistemskeOperacije.RacunSO
{
    public class IzmeniRacun:OpstaSO
    {
        public override object Izvrsi(Biblioteka.OpstiDomenskiObjekat odo)
        {
            Racun r = odo as Racun;
            Sesija.Broker.dajSesiju().izmeni(odo);
            StavkaRacuna s = new StavkaRacuna();
            s.RacunID = r.RacunID;
            Sesija.Broker.dajSesiju().obrisiZaUslovVise(s);
            foreach (StavkaRacuna sr in r.ListaStavki)
            {
                Sesija.Broker.dajSesiju().sacuvaj(sr);
            }

            return 1;

        }
    }
}
