using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using HtmlAgilityPack;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace SEFF
{
    public partial class ParserV3 : Form
    {
        public string[] titlesOfFanfics;

        public ParserV3()
        {
            InitializeComponent();
        }

        /*public void GetRequest()
        {
            var lastfanf = 10;
            try
            {
                for (var i = 1; i <= lastfanf; i++)
                {
                    string html = "http://stories.everypony.ru/";
                    HtmlDocument hd = new HtmlDocument();
                    var web = new HtmlWeb
                    {
                        AutoDetectEncoding = false,
                        OverrideEncoding = Encoding.UTF8,
                    };
                    hd = web.Load(html);
                    HtmlNodeCollection noAltElements = hd.DocumentNode.SelectNodes("//*[@id=\"story_title\"]");

                    // проверка на наличие найденных узлов
                    if (noAltElements == null) continue;
                    foreach (string outputText in noAltElements.Select(hn => hn.InnerText))
                    {
                        titlesOfFanfics[i] = outputText;
                    }
                }
            }
            catch (Exception e)
            {
                File.WriteAllText("log.txt", e.ToString());
            }
        }

        public void MakeList()
        {
            foreach (string element in titlesOfFanfics)
            {
                listBox1.Items.Add(element);
            }
        }*/

        private void button1_Click(object sender, EventArgs e)
        {
            /*GetRequest();
            MakeList();*/

            var lastfanf = 5;
            try
            {
                for (var i = 1; i <= lastfanf; i++)
                {
                    string html = "http://stories.everypony.ru/";
                    HtmlDocument hd = new HtmlDocument();
                    var web = new HtmlWeb
                    {
                        AutoDetectEncoding = false,
                        OverrideEncoding = Encoding.UTF8,
                    };
                    hd = web.Load(html);
                    HtmlNodeCollection noAltElements = hd.DocumentNode.SelectNodes("//*[@id=\"story_title\"]");

                    // проверка на наличие найденных узлов
                    if (noAltElements == null) continue;
                    foreach (string outputText in noAltElements.Select(hn => hn.InnerText))
                    {
                        titlesOfFanfics[i] = outputText;
                    }
                }
            }
            catch (Exception exc)
            {

            }

            foreach (string element in titlesOfFanfics)
            {
                listBox1.Items.Add(element);
            }
        }
    }
}