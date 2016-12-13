using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Biblioteka;

namespace SistemskeOperacije.RacunSO
{
    public class PronadjiRacune:OpstaSO
    {
        public override object Izvrsi(Biblioteka.OpstiDomenskiObjekat odo)
        {
            Racun ra= odo as Racun;
            List<Racun> listaRacunaZaDatum = new List<Racun>();
            List<Racun> listaRacuna = Sesija.Broker.dajSesiju().dajSve(odo).OfType<Racun>().ToList<Racun>();
            foreach (Racun r in listaRacuna)
            {
                if (r.Datum.ToShortDateString() == ra.Datum.ToShortDateString())
                {
                    StavkaRacuna s = new StavkaRacuna();
                    s.RacunID = r.RacunID;
                    List<StavkaRacuna> listaStavki = Sesija.Broker.dajSesiju().dajSveZaUslovVise(s).OfType<StavkaRacuna>().ToList<StavkaRacuna>();
                    foreach (StavkaRacuna sr in listaStavki)
                    {
                        sr.Knjiga = Sesija.Broker.dajSesiju().dajZaUslovJedan(sr.Knjiga) as Knjiga;
                        r.ListaStavki.Add(sr);
                    }

                    r.Radnik = Sesija.Broker.dajSesiju().dajZaUslovJedan(r.Radnik) as Radnik;
                    listaRacunaZaDatum.Add(r);
                }
            }

            return listaRacunaZaDatum;
        }
    }
}
