using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KontrolerKorisnickogInterfejsa;

namespace Klijent
{
    public partial class Form1 : Form
    {
        KontrolerKI kki;
        public Form1()
        {
            
            InitializeComponent();
            if(KontrolerKI.poveziSeNaServer()) this.Text="Uspesno povezan!";
            kki = new KontrolerKI();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (kki.login(txtUser, txtPAss)) new PocetnaForma().ShowDialog();
        }
    }
}
