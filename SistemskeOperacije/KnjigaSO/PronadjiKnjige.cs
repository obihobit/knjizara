﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Biblioteka;

namespace SistemskeOperacije.KnjigaSO
{
    public class PronadjiKnjige:OpstaSO
    {
        public override object Izvrsi(Biblioteka.OpstiDomenskiObjekat odo)
        {
            List<Knjiga> listaKnjiga = Sesija.Broker.dajSesiju().dajSveZaUslovVise(odo).OfType<Knjiga>().ToList<Knjiga>() ;
            foreach (Knjiga k in listaKnjiga) 
            {
                k.Dobavljac = Sesija.Broker.dajSesiju().dajZaUslovJedan(k.Dobavljac) as Dobavljac;
            }

            return listaKnjiga;

        }
    }
}
