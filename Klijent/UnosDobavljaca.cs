﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Klijent
{
    public partial class UnosDobavljaca : Form
    {
        KontrolerKorisnickogInterfejsa.KontrolerKI kki;
        public UnosDobavljaca()
        {
            InitializeComponent();
            kki = new KontrolerKorisnickogInterfejsa.KontrolerKI();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kki.kreirajDobavljaca(txtID,groupBox1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (kki.zapamtiDobavljaca(txtNaziv, txtPIB)) this.Close();
        }
    }
}
