﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemskeOperacije.DobavljacSO
{
    public class PronadjiDobavljaca:OpstaSO
    {
        public override object Izvrsi(Biblioteka.OpstiDomenskiObjekat odo)
        {
            return Sesija.Broker.dajSesiju().dajZaUslovVise(odo);
        }
    }
}
