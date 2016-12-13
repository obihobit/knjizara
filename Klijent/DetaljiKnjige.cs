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
    public partial class DetaljiKnjige : Form
    {
        KontrolerKorisnickogInterfejsa.KontrolerKI kki = new KontrolerKorisnickogInterfejsa.KontrolerKI();
        public DetaljiKnjige()
        {
            InitializeComponent();
        }

        private void DetaljiKnjige_Load(object sender, EventArgs e)
        {
            kki.popuniPoljaKnjige(txtNaziv, txtOpis, txtAutor, txtCena, txtKolicinaStanje, cmbDobavljac);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            kki.izmeniKnjigu(txtNaziv, txtOpis, txtAutor ,txtCena, txtKolicinaStanje, cmbDobavljac);
            this.Close();
        }
    }
}
