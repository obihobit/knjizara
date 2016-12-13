using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Biblioteka;

namespace SistemskeOperacije.KnjigaSO
{
    public class IzmeniKnjigu:OpstaSO
    {
        public override object Izvrsi(Biblioteka.OpstiDomenskiObjekat odo)
        {
            Knjiga k = odo as Knjiga;
            Sesija.Broker.dajSesiju().izmeni(odo);

            return 1;

        }
    }
}
