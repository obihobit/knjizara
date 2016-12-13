using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Komunikacija;
using Biblioteka;
using System.Windows.Forms;

namespace KontrolerKorisnickogInterfejsa
{
    public class KontrolerKI
    {
        public static Komunikacija.Komunikacija kom;
        public static Radnik radnik;
        public static Dobavljac dobavljac;
        public static Knjiga knjiga;
        public static Racun racun;


        public static bool poveziSeNaServer()
        {
            kom = new Komunikacija.Komunikacija();
            return kom.poveziSeNaServer();
        }

        public bool login(TextBox txtUser, TextBox txtPAss)
        {
            radnik = new Radnik();
            radnik.KorisnickoIme = txtUser.Text;
            radnik.KorisnickaSifra = txtPAss.Text;

            radnik = kom.login(radnik);

            if (radnik == null)
            {
                MessageBox.Show("Pogrešno uneto korisničko ime / lozinka");
                txtPAss.Clear();
                txtUser.Clear();
                txtUser.Focus();
                return false;
            }
            else 
            {
                MessageBox.Show("Uspešno ste se prijavili, "+radnik.Ime+"e");
                return true;
            }
        }

        public void kreirajDobavljaca(TextBox txtID, GroupBox groupBox)
        {
            txtID.Clear();
            groupBox.Visible = false;
            dobavljac = kom.kreirajNovogDobavljaca();
            if (dobavljac == null)
            {
                MessageBox.Show("Sistem ne može da kreira novog dobavljača");
            }
            else 
            {

                MessageBox.Show("Dobavljač je kreiran");
                txtID.Text = dobavljac.DobavljacID.ToString();
                groupBox.Visible = true;
            }
        }

        public bool zapamtiDobavljaca(TextBox txtNaziv, TextBox txtPIB)
        {
            dobavljac.Naziv = txtNaziv.Text;
            try
            {
                
                long a = Convert.ToInt64(txtPIB.Text);

                if (txtPIB.Text.Length != 10) 
                {
                    MessageBox.Show("Niste ispravno uneli PIB");
                    txtPIB.Focus();
                    return false;
                }
                dobavljac.Pib = txtPIB.Text;
            }
            catch (Exception)
            {

                MessageBox.Show("Sistem ne može da upiše podatke");
                txtPIB.Focus();
                return false;
            }

            Object o = kom.ZapamtiDobavljaca(dobavljac);
            if (o == null)
            {
                MessageBox.Show("Sistem ne može da upiše podatke");
                return false;
            }
            else 
            {
                MessageBox.Show("Dobavljač je uspešno unet");
                return true;
            }
        }

        public void pronadjiDobavljaca(TextBox txtNaziv, TextBox txtPIB, TextBox txtPIbUnos, GroupBox groupBox1)
        {
            groupBox1.Visible = false;
            dobavljac = new Dobavljac();
            dobavljac.Pib = txtPIbUnos.Text;

            dobavljac = kom.PronadjiDobavljaca(dobavljac);

            if (dobavljac == null)
            {
                MessageBox.Show("Sistem ne može da nađe dobavljača po zadatoj vrednosti");
            }
            else 
            {
                MessageBox.Show("Sistem je našao dobavljača po zadatoj vrednosti");
                groupBox1.Visible = true;
                txtPIB.Text = dobavljac.Pib;
                txtNaziv.Text = dobavljac.Naziv;
            }
        }

        public void izmeniDobavljaca(TextBox txtPIB, TextBox txtNaziv, GroupBox groupBox1, TextBox txtPIbUnos)
        {
            dobavljac.Naziv = txtNaziv.Text;
            dobavljac.Pib = txtPIB.Text;

            Object o = kom.IzmeniDobavljaca(dobavljac);
            if (o == null || txtNaziv.Text == "" || txtPIB.Text == "")
            {
                MessageBox.Show("Sistem ne 	može da zapamti dobavljača");
            }
            else 
            {
                MessageBox.Show("Sistem je zapamtio dobavljača");
                groupBox1.Visible = false;
                txtPIbUnos.Clear();
                txtPIbUnos.Focus();
            }
        }

        public void KreirajKnjigu(TextBox txtID, ComboBox cmbDobavljac, GroupBox groupBox1)
        {
            groupBox1.Visible = false;
            knjiga = kom.kreirajNovuKnjigu();
            if (knjiga == null)
            {
                MessageBox.Show("Sistem ne 	može da kreira novu knjigu");
            }
            else 
            {
                //MessageBox.Show("Sistem je zapamtio knjigu");
                txtID.Text = knjiga.KnjigaID.ToString();
                cmbDobavljac.DataSource = kom.vratiSveDobavljace();
                groupBox1.Visible = true;
                
            }
            
        }

        public void zapamtiKnjigu(TextBox txtAutor, TextBox txtCena, TextBox txtID, TextBox txtNaziv, TextBox txtOpis, TextBox txtKolicinaStanje, ComboBox cmbDobavljac, GroupBox groupBox1)
        {
            knjiga.Naziv = txtNaziv.Text;
            knjiga.Opis = txtOpis.Text;
            knjiga.Autor = txtAutor.Text;
            knjiga.KolicinaStanje = Convert.ToInt32(txtKolicinaStanje.Text);
            knjiga.Dobavljac = cmbDobavljac.SelectedItem as Dobavljac;
            try
            {
                knjiga.Cena = Convert.ToDouble(txtCena.Text);
            }
            catch (Exception)
            {

                MessageBox.Show("Niste ispravno uneli cenu");
                txtCena.Clear();
                txtCena.Focus();
                return;
            }

            Object o = kom.zapamtiKnjigu(knjiga);

            if (o == null || txtNaziv.Text == "" || txtOpis.Text == "" || txtAutor.Text == "")
            {
                MessageBox.Show("Sistem	ne može da zapamti knjigu");
            }
            else 
            {
                MessageBox.Show("Sistem je uspešno zapamtio knjigu");
                txtID.Clear();
                groupBox1.Visible = false;
                txtAutor.Clear();
                txtCena.Clear();
                txtNaziv.Clear();
                txtOpis.Clear();
                cmbDobavljac.Text = "";
            }


        }

        public void pronadjiKnjige(TextBox txtAutor, DataGridView dataGridView1, GroupBox groupBox1)
        {
            groupBox1.Visible = false;
            Knjiga k = new Knjiga();
            k.Autor = txtAutor.Text;

            List<Knjiga> listaKnjiga = kom.pronadjiKnjige(k);
            List<Knjiga> listaKnjigaSve = kom.pronadjiSveKnjige(k);

            if (txtAutor.Text == "")
            {
                MessageBox.Show("Sistem je našao knjige po zadatoj vrednosti");
                dataGridView1.DataSource = listaKnjigaSve;
                groupBox1.Visible = true;
                groupBox1.Text = "Sve knjige";
            }
            else
            {
                if (listaKnjiga == null || listaKnjiga.Count == 0)
                {
                    MessageBox.Show("Sistem ne može da pronađe knjige po zadatoj vrednosti");
                    txtAutor.Focus();
                }
                else
                {
                    MessageBox.Show("Sistem je našao knjige po zadatoj vrednosti");
                    dataGridView1.DataSource = listaKnjiga;
                    groupBox1.Visible = true;
                    groupBox1.Text = "Knjige autora " + k.Autor;
                }
            }
        }

        public void obrisiKnjigu(DataGridView dataGridView1)
        {
            try
            {
                knjiga = dataGridView1.SelectedRows[0].DataBoundItem as Knjiga;
                Object o = kom.obrisiKnjigu(knjiga);
                if (o == null)
                {
                    MessageBox.Show("Sistem ne 	može da obriše knjigu");
                }
                else 
                {
                    MessageBox.Show("Sistem je uspešno obrisao knjigu");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Niste odabrali knjigu za brisanje");
            }
        }

        public void kreirajRacun(TextBox txtID, ComboBox cmbKnjige, GroupBox groupBox2, Label lblRadnik,DataGridView dgv)
        {
            racun = kom.kreirajNoviRacun();
            if (racun == null)
            {
                groupBox2.Visible = false;
                MessageBox.Show("Sistem ne može da kreira novi račun");
            }
            else 
            {
                MessageBox.Show("Račun je kreiran");
                groupBox2.Visible = true;
                racun.Radnik = radnik;
                lblRadnik.Text = radnik.ToString();
                txtID.Text = racun.RacunID.ToString();
                cmbKnjige.DataSource = kom.vratiSveKnjige();
                dgv.DataSource = racun.ListaStavki;


            }
        }

        public void dodajStavku(ComboBox cmbKnjige, TextBox txtKolicina, TextBox txtUkIznos)
        {
            Knjiga k = cmbKnjige.SelectedItem as Knjiga;
            int kolicina;
            int kolicinaStanje = k.KolicinaStanje;


            
            try
            {
                kolicina = Convert.ToInt32(txtKolicina.Text);
            }
            catch (Exception)
            {

                MessageBox.Show("Niste ispravno uneli količinu");
                txtKolicina.Focus();
                return;
            }

            if (kolicina == 0)
            {
                MessageBox.Show("Količina mora biti veća od 0");
                return;

            }

            if (kolicina > kolicinaStanje)
            {
                MessageBox.Show("Ne postoji tolika količina artikla na stanju");
                return;
            }

            foreach (StavkaRacuna str in racun.ListaStavki)
            {
                if (str.Knjiga.KnjigaID == k.KnjigaID)
                {
                    str.Kolicina += kolicina;
                    return;
                }
            }

            StavkaRacuna sr = new StavkaRacuna();
            sr.RacunID = racun.RacunID;
            sr.Rb = racun.ListaStavki.Count + 1;
            sr.Knjiga = k;
            sr.Kolicina = kolicina;

         

            sr.Vrednost = sr.Kolicina * sr.Knjiga.Cena;
            racun.UkIznos += sr.Vrednost;
            txtUkIznos.Text = racun.UkIznos.ToString();
            racun.ListaStavki.Add(sr);
            txtKolicina.Clear();
            cmbKnjige.Text = "";
        }

        public void obrisiStavku(DataGridView dataGridView1, TextBox txtUkIznos)
        {
            try
            {
                StavkaRacuna sr = dataGridView1.SelectedRows[0].DataBoundItem as StavkaRacuna;
                racun.ListaStavki.Remove(sr);
                racun.UkIznos -= sr.Vrednost;
                txtUkIznos.Text = racun.UkIznos.ToString();

                int i = 1;
                foreach (StavkaRacuna s in racun.ListaStavki) 
                {
                    s.Rb = i;
                    i++;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Niste odabrali stavku za brisanje");
            }
        }
        private void smanjiKnjige(Knjiga knjiga, int brojKnjiga)
        {
               
        }

        public void sacuvajRacun(DateTimePicker dtpDatum, GroupBox groupBox2, ComboBox cmbKnjige, TextBox txtUkIznos, TextBox txtID)
        {
            racun.Datum = dtpDatum.Value;

            Object o = kom.sacuvajRacun(racun);

            if (o == null)
            {
                MessageBox.Show("Sistem ne može da zapamti račun");
            }
            else 
            {
                MessageBox.Show("Sistem je zapamtio račun");
                txtID.Clear();
                txtUkIznos.Clear();
                cmbKnjige.Text = "";
                groupBox2.Visible = false;
            }
        }

        public void pronadjiRacune(DateTimePicker dtpDatum, DataGridView dataGridView1)
        {
            Racun r = new Racun();
            r.Datum = dtpDatum.Value;
            List<Racun> listaRacuna = kom.pronadjiRacune(r);
            if (listaRacuna == null || listaRacuna.Count == 0)
            {
                MessageBox.Show("Sistem ne može da nađe račun po zadatoj vrednosti");
                dataGridView1.DataSource = null;
            }
            else 
            {
                MessageBox.Show("Sistem je našao račun po zadatoj vrednosti");
                dataGridView1.DataSource = listaRacuna;
            }

        }

        public bool prikaziDetalje(DataGridView dataGridView1)
        {
            try
            {
                racun = dataGridView1.SelectedRows[0].DataBoundItem as Racun;
                return true;
            }
            catch (Exception)
            {

                MessageBox.Show("Niste izabrali račun za prikaz");
                return false;
            }
        }

        public bool prikaziDetaljeKnjiga(DataGridView dataGridView1)
        {
            try
            {
                knjiga = dataGridView1.SelectedRows[0].DataBoundItem as Knjiga;
                return true;
            }
            catch (Exception)
            {

                MessageBox.Show("Niste izabrali knjigu za prikaz");
                return false;
            }
        }

        public void popuniPoljaRacuna(DateTimePicker dtpDatum, Label lblRadnik, ComboBox cmbKnjige, DataGridView dataGridView1, TextBox txtUkIznos)
        {
            dtpDatum.Value = racun.Datum;
            lblRadnik.Text = racun.Radnik.ToString();
            txtUkIznos.Text = racun.UkIznos.ToString();
            dataGridView1.DataSource = racun.ListaStavki;
            cmbKnjige.DataSource = kom.vratiSveKnjige();
        }

        public void popuniPoljaKnjige(TextBox txtNaziv, TextBox txtOpis, TextBox txtAutor, TextBox txtCena, TextBox txtKolicinaStanje, ComboBox cmbDobavljac)
        {
            txtNaziv.Text = knjiga.Naziv;
            txtOpis.Text = knjiga.Opis;
            txtAutor.Text = knjiga.Autor;
            txtCena.Text = knjiga.Cena.ToString();
            txtKolicinaStanje.Text = knjiga.KolicinaStanje.ToString();
            cmbDobavljac.DataSource = kom.vratiSveDobavljace();
        }

        public bool izmeniRacun(DateTimePicker dtpDatum)
        {
            racun.Radnik = radnik;
            racun.Datum = dtpDatum.Value;

            Object o = kom.izmeniRacun(racun);
            if (o == null)
            {
                MessageBox.Show("Sistem nije uspeo da zapamti račun");
                return false;
            }
            else 
            {
                MessageBox.Show("Sistem je zapamtio račun");
                return true;
                
            }
        }

        public bool izmeniKnjigu(TextBox tnaziv, TextBox topis,TextBox tautor, TextBox tcena, TextBox tkolicina, ComboBox cdobavljac)
        {
            knjiga.Naziv = tnaziv.Text;
            knjiga.Opis = topis.Text;
            knjiga.KolicinaStanje = Convert.ToInt32(tkolicina.Text);
            knjiga.Cena = Convert.ToInt32(tcena.Text);
            knjiga.Autor = tautor.Text;
            knjiga.Dobavljac = cdobavljac.DataSource as Dobavljac;
            Object o = kom.izmeniKnjigu(knjiga);
            if (o == null)
            {
                MessageBox.Show("Sistem nije uspeo da zapamti knjigu");
                return false;
            }
            else
            {
                MessageBox.Show("Sistem je zapamtio knjigu");
                return true;

            }
        }

        public bool obrisiRacun()
        {
            Object o = kom.stornirajRacun(racun);
            if (o == null)
            {
                MessageBox.Show("Sistem ne može dа stornirа rаčun");
                return false;
            }
            else
            {
                MessageBox.Show("Sistem je stornirao račun");
                return true;

            }
        }
    }
}
