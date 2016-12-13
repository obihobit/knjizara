using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Biblioteka;

namespace SistemskeOperacije.KnjigaSO
{
    public class PrikaziSveKnjige : OpstaSO
    {
        public override object Izvrsi(Biblioteka.OpstiDomenskiObjekat odo)
        {
            List<Knjiga> listaKnjigaSve = Sesija.Broker.dajSesiju().dajSve(odo).OfType<Knjiga>().ToList<Knjiga>();
            foreach (Knjiga k in listaKnjigaSve)
            {
                k.Dobavljac = Sesija.Broker.dajSesiju().dajZaUslovJedan(k.Dobavljac) as Dobavljac;
            }

            return listaKnjigaSve;
        }
    }
}