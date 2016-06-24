﻿using System;
using System.Collections.Generic;
using System.IO;
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
            new XmLer().Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Main().Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new ParserV3().Show();
            Hide();
        }

        private void seffTrayIco_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }
    }
}