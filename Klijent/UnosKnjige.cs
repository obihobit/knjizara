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
    public partial class UnosKnjige : Form
    {
        KontrolerKorisnickogInterfejsa.KontrolerKI kki = new KontrolerKorisnickogInterfejsa.KontrolerKI();
        public UnosKnjige()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kki.KreirajKnjigu(txtID, cmbDobavljac, groupBox1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            kki.zapamtiKnjigu(txtAutor, txtCena, txtID, txtNaziv, txtOpis, txtKolicinaStanje, cmbDobavljac, groupBox1);
        }
    }
}
