﻿using System;
using System.Windows.Forms;

namespace SEFF
{
    public partial class Chooser : Form
    {
        public Chooser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new XmLer().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Main().ShowDialog();
        }

        private void seffTrayIco_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private void Chooser_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new ParserV3().ShowDialog();
        }

        private void Chooser_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Form1().ShowDialog();
        }
    }
}