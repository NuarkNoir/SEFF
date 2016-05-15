using System;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Chooser : Form
    {
        public Chooser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XMLer newMDIChild = new XMLer();
            newMDIChild.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Main newMDIChild = new Main();
            newMDIChild.Show();
            Hide();
        }
    }
}