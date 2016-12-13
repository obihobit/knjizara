using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Biblioteka;
using Sesija;

namespace SistemskeOperacije.RacunSO
{
    public class SacuvajRacun:OpstaSO
    {
        public override object Izvrsi(Biblioteka.OpstiDomenskiObjekat odo)
        {
            Racun r = odo as Racun;
            Sesija.Broker.dajSesiju().sacuvaj(odo);
            foreach (StavkaRacuna sr in r.ListaStavki) 
            {
                Broker b = Sesija.Broker.dajSesiju();
                Knjiga knjiga = new Knjiga();
                knjiga.KnjigaID = sr.Knjiga.KnjigaID;
                OpstiDomenskiObjekat odo1 = b.dajZaUslovJedan((OpstiDomenskiObjekat)knjiga);
                Knjiga knjiga1 = (Knjiga) odo1;
                if (sr.Kolicina > knjiga1.KolicinaStanje)
                {
                    return 0;
                }

                else
                {
                    b.smanjiKolicinu(knjiga1, sr.Kolicina);
                }
         
                b.sacuvaj(sr);

            }

            return 1;
        }
    }
}
