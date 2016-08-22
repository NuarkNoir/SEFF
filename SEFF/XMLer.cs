using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using NuarkNETOD;
using SEFF.Properties;

namespace SEFF
{
    public partial class XmLer : Form
    {
        private string _downloadBlock, _downloadFbtwo, _downloadHtml, _htmlDoc, _rate, _reads, _title, _words;
        private bool _forf = true;
        private int _maxFanf = 5;

        private int _number = 1;
        private readonly string _pathToXml = "fanfDB.xml";

        public XmLer()
        {
            InitializeComponent();
            if (File.Exists(_pathToXml))
            {
                button2.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var i = int.Parse(textBox1.Text);
            _maxFanf = i;
            progressBar1.Maximum = _maxFanf;
            progressBar1.Value = 0;

            try
            {
                if (!File.Exists(_pathToXml))
                {
                    var textWritter = new XmlTextWriter(_pathToXml, Encoding.UTF8);
                    textWritter.WriteStartDocument();
                    textWritter.WriteStartElement("head");
                    textWritter.WriteEndElement();
                    textWritter.Close();
                }
                while (_number <= _maxFanf)
                {
                    _htmlDoc = NuarkNeToD.GetResponse(@"https://stories.everypony.ru/story/" + _number);

                    if (_forf == false)
                    {
                        var document = new XmlDocument();

                        _title = Regex.Match(_htmlDoc, @"<title>(.*?)</title>").ToString();
                        _title =
                            Regex.Match(_title, @"[^(<title>)]([\[\]A-Za-zА-Яа-я\.: —]?[^( & )]){1,100}[^(</title>)]")
                                .ToString();
                        _rate =
                            Regex.Match(_htmlDoc,
                                @"(Рейтинг — <a href=""/search/rating/)(1|2|3|4)(/"">)(G|PG-13|R|NC-18)").ToString();
                        _rate = Regex.Match(_rate, @"(G|PG-13|R|NC-18)").ToString();
                        _words =
                            Regex.Match(_htmlDoc, @"([0-9]* (слов|слово|слова), [0-9]* (просмотра|просмотров))")
                                .ToString();
                        _words = Regex.Match(_words, @"([0-9]* (слов|слово|слова))").ToString();
                        _words = Regex.Match(_words, @"[0-9]*\d").ToString();
                        _reads =
                            Regex.Match(_htmlDoc, @"([0-9]* (слов|слово|слова), [0-9]* (просмотра|просмотров))")
                                .ToString();
                        _reads = Regex.Match(_reads, @"([0-9]* (просмотра|просмотров))").ToString();
                        _reads = Regex.Match(_reads, @"[0-9]*\d").ToString();
                        _downloadBlock =
                            Regex.Match(_htmlDoc, @"((<span class=""chapter-controls"">)(.*?)(<\/span>))").ToString();
                        _downloadHtml =
                            Regex.Match(_downloadBlock,
                                @"((<a title=""Скачать в HTML"" href="")(.*?)("" class=""get html"">))").ToString();
                        _downloadHtml =
                            Regex.Match(_downloadHtml, @"(((\/story\/([0-9]+?)\/download\/(.*?).html.zip)))").ToString();
                        _downloadFbtwo =
                            Regex.Match(_downloadBlock,
                                @"((<a title=""Скачать в FB2"" href="")(.*?)("" class=""get fb2"">))").ToString();
                        _downloadFbtwo =
                            Regex.Match(_downloadFbtwo, @"((\/story\/([0-9]+?)\/download\/(.*?).fb2.zip))").ToString();

                        if (_forf == false) _downloadFbtwo = "http://stories.everypony.ru" + _downloadFbtwo;

                        document.Load(_pathToXml);
                        XmlNode element = document.CreateElement("Fanfic");
                        document.DocumentElement?.AppendChild(element);
                        var id = document.CreateAttribute("id");
                        id.Value = _number.ToString();
                        var forbidden = document.CreateAttribute("Forbidden");
                        forbidden.Value = _forf.ToString();
                        element.Attributes?.Append(forbidden);

                        XmlNode subElement1 = document.CreateElement("Tittle");
                        subElement1.InnerText = _title;
                        element.AppendChild(subElement1);

                        XmlNode subElement2 = document.CreateElement("Rating");
                        subElement2.InnerText = _rate;
                        element.AppendChild(subElement2);

                        XmlNode subElement3 = document.CreateElement("Words");
                        subElement3.InnerText = _words;
                        element.AppendChild(subElement3);

                        XmlNode subElement4 = document.CreateElement("Readings");
                        subElement4.InnerText = _reads;
                        element.AppendChild(subElement4);

                        XmlNode subElement5 = document.CreateElement("DownloadHTML");
                        subElement5.InnerText = _downloadHtml;
                        element.AppendChild(subElement5);

                        XmlNode subElement6 = document.CreateElement("DownloadFB2");
                        subElement6.InnerText = _downloadFbtwo;
                        element.AppendChild(subElement6);

                        if (_forf) element.RemoveAll();

                        document.Save(_pathToXml);
                    }
                    progressBar1.Value = _number;
                    _number = _number + 1;
                }

                if (_number > _maxFanf) MessageBox.Show(Resources.WorkDone, Resources.Work);

                _number = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (File.Exists(_pathToXml))
            {
                button2.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            File.Delete(_pathToXml);
            if (File.Exists(_pathToXml))
            {
                button2.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
            }
        }

        private void XmLer_FormClosed(object sender, FormClosedEventArgs e)
        {
            new Chooser().Show();
            Hide();
        }
    }
}