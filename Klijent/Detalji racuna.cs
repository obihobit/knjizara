using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Klijent
{
    public partial class Detalji_racuna : Form
    {
        KontrolerKorisnickogInterfejsa.KontrolerKI kki = new KontrolerKorisnickogInterfejsa.KontrolerKI();
        public Detalji_racuna()
        {
            InitializeComponent();
        }

        private void Detalji_racuna_Load(object sender, EventArgs e)
        {
            kki.popuniPoljaRacuna(dtpDatum, lblRadnik, cmbKnjige, dataGridView1, txtUkIznos);
        }

        private void Dodaj_Click(object sender, EventArgs e)
        {
            kki.dodajStavku(cmbKnjige, txtKolicina, txtUkIznos);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kki.obrisiStavku(dataGridView1, txtUkIznos);
        }

        private void button2_Click(object sender, EventArgs e)
        {
           if( kki.izmeniRacun(dtpDatum)) this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           if( kki.obrisiRacun()) this.Close();
        }
    }
}
