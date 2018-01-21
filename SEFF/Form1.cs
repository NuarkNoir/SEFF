using System;
using System.IO;
using System.Windows.Forms;
using NuarkNETOD;
using Newtonsoft.Json;

namespace SEFF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getr();
        }

        void getr()
        {
            var number = int.Parse(tB.Text);
            for (var i = number; i < 100; i++)
            {
                var htmlDoc = NuarkNeToD.GetResponse(@"http://dev.nuarknoir.h1n.ru/api/?ID=" + i);
                var f = JsonConvert.DeserializeObject<Fanfic>(htmlDoc);
                if (f.HSC == "OK") listBox1.Items.Add(f.TITLE);
            }
        }
    }
}
