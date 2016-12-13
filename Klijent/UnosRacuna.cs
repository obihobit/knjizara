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
    public partial class UnosRacuna : Form
    {
        KontrolerKorisnickogInterfejsa.KontrolerKI kki = new KontrolerKorisnickogInterfejsa.KontrolerKI();
        public UnosRacuna()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kki.obrisiStavku(dataGridView1, txtUkIznos);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            kki.kreirajRacun(txtID, cmbKnjige, groupBox2,lblRadnik,dataGridView1);
        }

        private void Dodaj_Click(object sender, EventArgs e)
        {
            kki.dodajStavku(cmbKnjige, txtKolicina, txtUkIznos);
            dataGridView1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            kki.sacuvajRacun(dtpDatum, groupBox2,cmbKnjige,txtUkIznos,txtID);
        }

        private void UnosRacuna_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
