using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using Biblioteka;
using Sesija;
using System.Threading;

using SistemskeOperacije.LoginSO;
using SistemskeOperacije.DobavljacSO;
using SistemskeOperacije.KnjigaSO;
using SistemskeOperacije.RacunSO;


namespace Server
{
    public class Obrada
    {
        BinaryFormatter formater;
        NetworkStream tok;

        public Obrada(NetworkStream tok)
        {
            this.tok = tok;
            formater = new BinaryFormatter();

            ThreadStart ts = obradiKlijenta;
            Thread nit = new Thread(ts);
            nit.Start();
        }

        public void obradiKlijenta() 
        {
            int operacija = 0;
            while (operacija != (int)Operacije.Kraj) 
            {
                TransferKlasa transfer = formater.Deserialize(tok) as TransferKlasa;
                switch (transfer.Operacija)
                {
                    case Operacije.Login:
                        Login l = new Login();
                        transfer.Rezultat = l.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                        formater.Serialize(tok, transfer);
                        break;

                    case Operacije.KreirajDobavljaca:
                        KreirajNovogDobavljaca knd = new KreirajNovogDobavljaca();
                        transfer.Rezultat = knd.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                        formater.Serialize(tok, transfer);
                        break;

                    case Operacije.SacuvajDobavljaca:
                        ZapamtiDobavljaca zd = new ZapamtiDobavljaca();
                        transfer.Rezultat = zd.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                        formater.Serialize(tok, transfer);
                        break;

                    case Operacije.PronadjiDobavljaca:
                        PronadjiDobavljaca pd = new PronadjiDobavljaca();
                        transfer.Rezultat = pd.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                        formater.Serialize(tok, transfer);
                        break;

                    case Operacije.IzmeniDobavljaca:
                        IzmeniDobavljaca id = new IzmeniDobavljaca();
                        transfer.Rezultat = id.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                        formater.Serialize(tok, transfer);
                        break;

                    case Operacije.VratiSveDobavljace:
                        VratiSveDobavljace vsd = new VratiSveDobavljace();
                        transfer.Rezultat = vsd.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                        formater.Serialize(tok, transfer);
                        break;

                    case Operacije.KreirajKnjigu:
                        KreirajNovuKnjigu knk = new KreirajNovuKnjigu();
                        transfer.Rezultat = knk.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                        formater.Serialize(tok, transfer);
                        break;

                    case Operacije.PronadjiKnjige:
                        PronadjiKnjige pk = new PronadjiKnjige();
                        transfer.Rezultat = pk.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                        formater.Serialize(tok, transfer);
                        break;

                    case Operacije.ZapamtiKnjigu:
                        ZapamtiKnjigu zk = new ZapamtiKnjigu();
                        transfer.Rezultat = zk.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                        formater.Serialize(tok, transfer);
                        break;


                    case Operacije.ObrisiKnjigu:
                        ObrisiKnjigu ok = new ObrisiKnjigu();
                        transfer.Rezultat = ok.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                        formater.Serialize(tok, transfer);
                        break;

                    case Operacije.KreirajRacun:
                        KreirajNoviRacun knr = new KreirajNoviRacun();
                        transfer.Rezultat = knr.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                        formater.Serialize(tok, transfer);
                        break;

                    case Operacije.SacuvajRacun:
                        SacuvajRacun sr = new SacuvajRacun();
                        transfer.Rezultat = sr.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                        formater.Serialize(tok, transfer);
                        break;

                    case Operacije.IzmeniRacun:
                        IzmeniRacun ir = new IzmeniRacun();
                        transfer.Rezultat = ir.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                        formater.Serialize(tok, transfer);
                        break;

                    case Operacije.StornirajRacun:
                        StornirajRacun str = new StornirajRacun();
                        transfer.Rezultat = str.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                        formater.Serialize(tok, transfer);
                        break;

                    case Operacije.PronadjiRacune:
                        PronadjiRacune pr = new PronadjiRacune();
                        transfer.Rezultat = pr.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                        formater.Serialize(tok, transfer);
                        break;

                    case Operacije.VratiSveKnjige:
                        VratiSveKnjige vsk = new VratiSveKnjige();
                        transfer.Rezultat = vsk.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                        formater.Serialize(tok, transfer);
                        break;

                    case Operacije.PronadjiSveKnjige:
                        PrikaziSveKnjige psk = new PrikaziSveKnjige();
                        transfer.Rezultat = psk.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                        formater.Serialize(tok, transfer);
                        break;

                    case Operacije.IzmeniKnjigu:
                        IzmeniKnjigu ik = new IzmeniKnjigu();
                        transfer.Rezultat = ik.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                        formater.Serialize(tok, transfer);
                        break;

                    case Operacije.Kraj: operacija = 1;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
