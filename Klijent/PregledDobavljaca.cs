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
    public partial class PregledDobavljaca : Form
    {
        KontrolerKorisnickogInterfejsa.KontrolerKI kki = new KontrolerKorisnickogInterfejsa.KontrolerKI();
        public PregledDobavljaca()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kki.pronadjiDobavljaca(txtNaziv, txtPIB, txtPIbUnos, groupBox1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            kki.izmeniDobavljaca(txtPIB, txtNaziv, groupBox1,txtPIbUnos);
        }
    }
}
