﻿using System;
using System.Windows.Forms;


namespace PDF_Splitter
{
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HandPDF hp = HandPDF();
            hp.SplitPDF();

        }

        private HandPDF HandPDF()
        {
            throw new NotImplementedException();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}