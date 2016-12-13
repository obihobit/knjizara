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
    public partial class Pregled_knjiga : Form
    {
        KontrolerKorisnickogInterfejsa.KontrolerKI kki = new KontrolerKorisnickogInterfejsa.KontrolerKI();
        public Pregled_knjiga()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kki.pronadjiKnjige(txtAutor, dataGridView1, groupBox1);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sistem je pronašao podatke o izabranoj knjizi");
            if (kki.prikaziDetaljeKnjiga(dataGridView1)) new DetaljiKnjige().ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            kki.obrisiKnjigu(dataGridView1);
            button1_Click(sender, e);
        }

        private void Pregled_knjiga_Load(object sender, EventArgs e)
        {

        }
    }
}
