using Newtonsoft.Json;
using NuarkNETOD;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace pwxp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("Newtonsoft.Json.dll")) return;
            byte[] resf;
            resf = Properties.Resources.Newtonsoft_Json;
            File.WriteAllBytes("Newtonsoft.Json.dll", resf);
        }

        private void spth()
        {
            List<String> fic = new List<string>();
            for (int num = 1; num < 10; num++)
            {
                string uri =
                "https://query.yahooapis.com/v1/public/yql?q=select * from html where url='https://stories.everypony.ru/story/" + num + "/' and xpath='.//*[@id=\"story_title\"]'&format=json&env=store://datatables.org/alltableswithkeys&callback=";
                string request = NuarkNeToD.GetResponse(uri);
                dynamic titla = JsonConvert.DeserializeObject(request);
                if (titla.query.count != 0)
                {
                    string toAdd = titla.query.results.h1.content;
                    fic.Add(toAdd.Trim());
                }
            }
            foreach (var name in fic)
                lBo.Items.Add(name);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            spth();
        }
    }
}
