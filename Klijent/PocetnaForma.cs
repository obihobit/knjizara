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
    public partial class PocetnaForma : Form
    {
        public PocetnaForma()
        {
            InitializeComponent();
        }

        private void unosDobavljacaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new UnosDobavljaca().ShowDialog();
        }

        private void pregledDobavljacaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new PregledDobavljaca().ShowDialog();
        }

        private void unosKnjigeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new UnosKnjige().ShowDialog();
        }

        private void pregledKnjigaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Pregled_knjiga().ShowDialog();
        }

        private void unosRacunaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new UnosRacuna().ShowDialog();
        }

        private void pregledRacunaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new PregledRacuna().ShowDialog();
        }

        private void krajRadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
