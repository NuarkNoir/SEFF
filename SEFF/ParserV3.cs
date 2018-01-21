using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using NuarkNETOD;

namespace SEFF
{
    public partial class ParserV3 : Form
    {
        public ParserV3()
        {
            InitializeComponent();
        }

        private string _htmlDoc;
        private int _maxFanf = 5;
        private int _n;

        private int _number = 1;
        private string _rate;
        private string _reads;
        private string _title;
        private string _words;
        private string _downloadBlock, _downloadHtml, _downloadFbtwo;
        public bool Forf;

        const int Px = 10;
        public int Py = 40;

        private void button1_Click(object sender, EventArgs e)
        {
            var i = int.Parse(textBox1.Text);
            _maxFanf = i;
            progressBar1.Maximum = _maxFanf;
            progressBar1.Value = 0;
            while (_number <= _maxFanf)
            {
                _htmlDoc = NuarkNeToD.GetResponse(@"https://stories.everypony.ru/story/" + _number);

                if (Forf == false)
                {
                    _title = Regex.Match(_htmlDoc, @"<title>(.*?)</title>").ToString();
                    _title = Regex.Match(_title, @"[^(<title>)]([\[\]A-Za-zА-Яа-я\.: —]?[^( & )]){1,100}[^(</title>)]").ToString();

                    _rate = Regex.Match(_htmlDoc, @"(Рейтинг — <a href=""/search/rating/)(1|2|3|4)(/"">)(G|PG-13|R|NC-18)").ToString();
                    _rate = Regex.Match(_rate, @"(G|PG-13|R|NC-18)").ToString();

                    _words = Regex.Match(_htmlDoc, @"([0-9]* (слов|слово|слова), [0-9]* (просмотра|просмотров))").ToString();
                    _words = Regex.Match(_words, @"([0-9]* (слов|слово|слова))").ToString();
                    _words = Regex.Match(_words, @"[0-9]*\d").ToString();

                    _reads = Regex.Match(_htmlDoc, @"([0-9]* (слов|слово|слова), [0-9]* (просмотра|просмотров))").ToString();
                    _reads = Regex.Match(_reads, @"([0-9]* (просмотра|просмотров))").ToString();
                    _reads = Regex.Match(_reads, @"[0-9]*\d").ToString();

                    _downloadBlock =Regex.Match(_htmlDoc, @"((<span class=""chapter-controls"">)(.*?)(<\/span>))").ToString();
                    _downloadHtml = Regex.Match(_downloadBlock, @"((<a title=""Скачать в HTML"" href="")(.*?)("" class=""get html"">))").ToString();
                    _downloadHtml = Regex.Match(_downloadHtml, @"(((\/story\/([0-9]+?)\/download\/(.*?).html.zip)))").ToString();
                    _downloadFbtwo = Regex.Match(_downloadBlock, @"((<a title=""Скачать в FB2"" href="")(.*?)("" class=""get fb2"">))").ToString();
                    _downloadFbtwo = Regex.Match(_downloadFbtwo, @"((\/story\/([0-9]+?)\/download\/(.*?).fb2.zip))").ToString();

                    _downloadHtml = "http://stories.everypony.ru" + _downloadHtml;
                    _downloadFbtwo = "http://stories.everypony.ru" + _downloadFbtwo;

                    if (_title != "") ControlAdd(_title, _rate, _reads, _words, _number, _downloadHtml, _downloadFbtwo);
                }
                progressBar1.Value = _number;
                _number = _number + 1;
            }

            _number = 1;
        }

        public void ControlAdd(string t, string ra, string re, string wo, int num, string htl, string fbl)
        {
            var fc = new FanficItemInterface
            {
                Name = "Fcontr" + _number.ToString(),
                FName = _title,
                AGRate = _rate,
                CountReads = _reads,
                CountWords = _words,
                Identificator = _number.ToString(),
                HtmlLink = htl,
                Fb2Link = fbl,
                Location = new Point(Px, Py)
            };

            Controls.Add(fc);

            Py += 50;
        }

        private void ParserV3_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
