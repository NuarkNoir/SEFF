﻿using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using NuarkNETOD;

namespace SEFF
{
    public partial class XmLer : Form
    {
        private string downloadBLOCK;
        private string downloadFBTWO;
        private string downloadHTML;
        public bool Forf;
        private string htmlDoc;
        private int maxFanf = 5;

        private int number = 1;
        private readonly string pathToXml = @"fanfDB.xml";
        private string rate;
        private string reads;
        private string title;
        private string words;

        public XmLer()
        {
            InitializeComponent();
            if (File.Exists(pathToXml))
            {
                button2.Enabled = true;
                button3.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
                button3.Enabled = false;
            }
            ;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var i = int.Parse(textBox1.Text);
            maxFanf = i;
            progressBar1.Maximum = maxFanf;
            progressBar1.Value = 0;

            try
            {
                if (!File.Exists(pathToXml))
                {
                    var textWritter = new XmlTextWriter(pathToXml, Encoding.UTF8);

                    textWritter.WriteStartDocument();

                    textWritter.WriteStartElement("head");

                    textWritter.WriteEndElement();

                    textWritter.Close();
                }
                while (number <= maxFanf)
                {
                    htmlDoc = NuarkNeToD.GetResponse(@"https://stories.everypony.ru/story/" + number);

                    if (Forf == false)
                    {
                        var document = new XmlDocument();

                        title = Regex.Match(htmlDoc, @"<title>(.*?)</title>").ToString();
                        title =
                            Regex.Match(title, @"[^(<title>)]([\[\]A-Za-zА-Яа-я\.: —]?[^( & )]){1,100}[^(</title>)]")
                                .ToString();
                        rate =
                            Regex.Match(htmlDoc,
                                @"(Рейтинг — <a href=""/search/rating/)(1|2|3|4)(/"">)(G|PG-13|R|NC-18)").ToString();
                        rate = Regex.Match(rate, @"(G|PG-13|R|NC-18)").ToString();
                        words =
                            Regex.Match(htmlDoc, @"([0-9]* (слов|слово|слова), [0-9]* (просмотра|просмотров))")
                                .ToString();
                        words = Regex.Match(words, @"([0-9]* (слов|слово|слова))").ToString();
                        words = Regex.Match(words, @"[0-9]*\d").ToString();
                        reads =
                            Regex.Match(htmlDoc, @"([0-9]* (слов|слово|слова), [0-9]* (просмотра|просмотров))")
                                .ToString();
                        reads = Regex.Match(reads, @"([0-9]* (просмотра|просмотров))").ToString();
                        reads = Regex.Match(reads, @"[0-9]*\d").ToString();
                        downloadBLOCK =
                            Regex.Match(htmlDoc, @"((<span class=""chapter-controls"">)(.*?)(<\/span>))").ToString();
                        downloadHTML =
                            Regex.Match(downloadBLOCK,
                                @"((<a title=""Скачать в HTML"" href="")(.*?)("" class=""get html"">))").ToString();
                        downloadHTML =
                            Regex.Match(downloadHTML, @"(((\/story\/([0-9]+?)\/download\/(.*?).html.zip)))").ToString();
                        downloadFBTWO =
                            Regex.Match(downloadBLOCK,
                                @"((<a title=""Скачать в FB2"" href="")(.*?)("" class=""get fb2"">))").ToString();
                        downloadFBTWO =
                            Regex.Match(downloadFBTWO, @"((\/story\/([0-9]+?)\/download\/(.*?).fb2.zip))").ToString();

                        if (Forf == false)
                        {
                            downloadHTML = "http://stories.everypony.ru" + downloadHTML;
                            downloadFBTWO = "http://stories.everypony.ru" + downloadFBTWO;
                        }

                        document.Load(pathToXml);
                        XmlNode element = document.CreateElement("Fanfic");
                        document.DocumentElement.AppendChild(element);
                        var id = document.CreateAttribute("id");
                        id.Value = number.ToString();
                        var forbidden = document.CreateAttribute("Forbidden");
                        forbidden.Value = Forf.ToString();
                        element.Attributes.Append(forbidden);

                        XmlNode subElement1 = document.CreateElement("Tittle");
                        subElement1.InnerText = title;
                        element.AppendChild(subElement1);

                        XmlNode subElement2 = document.CreateElement("Rating");
                        subElement2.InnerText = rate;
                        element.AppendChild(subElement2);

                        XmlNode subElement3 = document.CreateElement("Words");
                        subElement3.InnerText = words;
                        element.AppendChild(subElement3);

                        XmlNode subElement4 = document.CreateElement("Readings");
                        subElement4.InnerText = reads;
                        element.AppendChild(subElement4);

                        XmlNode subElement5 = document.CreateElement("DownloadHTML");
                        subElement5.InnerText = downloadHTML;
                        element.AppendChild(subElement5);

                        XmlNode subElement6 = document.CreateElement("DownloadFB2");
                        subElement6.InnerText = downloadFBTWO;
                        element.AppendChild(subElement6);

                        if (Forf) element.RemoveAll();

                        document.Save(pathToXml);
                    }
                    progressBar1.Value = number;
                    number = number + 1;
                }

                if (number > maxFanf) MessageBox.Show("Всё сделано", "Обработка");

                number = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (File.Exists(pathToXml))
            {
                button2.Enabled = true;
                button3.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
                button3.Enabled = false;
            }
            ;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            File.Delete(pathToXml);
            if (File.Exists(pathToXml))
            {
                button2.Enabled = true;
                button3.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
                button3.Enabled = false;
            }
            ;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start("notepad.exe", pathToXml);
        }

        private void XmLer_FormClosed(object sender, FormClosedEventArgs e)
        {
            var newMDIChild = new Chooser();
            newMDIChild.Show();
            Hide();
        }
    }
}