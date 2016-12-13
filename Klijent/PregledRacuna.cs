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
    public partial class PregledRacuna : Form
    {
        KontrolerKorisnickogInterfejsa.KontrolerKI kki = new KontrolerKorisnickogInterfejsa.KontrolerKI();
        public PregledRacuna()
        {
            InitializeComponent();
        }

        private void dtpDatum_ValueChanged(object sender, EventArgs e)
        {
            kki.pronadjiRacune(dtpDatum, dataGridView1);
        }

        private void Prikazi_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sistem je pronašao podatke o izabranom računu");
            if (kki.prikaziDetalje(dataGridView1)) new Detalji_racuna().ShowDialog();
            dtpDatum_ValueChanged(sender, e);

            
        }
    }
}
