using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using NuarkNETOD;

namespace SEFF
{
    public partial class Main : Form
    {
        private string _htmlDoc;
        private int _maxFanf = 5;
        private int _n;

        private int _number = 1;
        private string _rate;
        private string _reads;
        private string _title;
        private string _words;
        public bool Forf;

        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var fics = new TreeNode("Фанфики");

            var i = int.Parse(textBox1.Text);
            _maxFanf = i;
            progressBar1.Maximum = _maxFanf;
            progressBar1.Value = 0;
            while (_number <= _maxFanf)
            {
                _htmlDoc = NuarkNeToD.GetResponse(@"https://stories.everypony.ru/story/" + _number);

                if (Forf == false)
                {
                    _n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[_n].Cells[0].Value = _number;

                    _title = Regex.Match(_htmlDoc, @"<title>(.*?)</title>").ToString();
                    _title =
                        Regex.Match(_title, @"[^(<title>)]([\[\]A-Za-zА-Яа-я\.: —]?[^( & )]){1,100}[^(</title>)]")
                            .ToString();
                    dataGridView1.Rows[_n].Cells[1].Value = _title;

                    _rate =
                        Regex.Match(_htmlDoc, @"(Рейтинг — <a href=""/search/rating/)(1|2|3|4)(/"">)(G|PG-13|R|NC-18)")
                            .ToString();
                    _rate = Regex.Match(_rate, @"(G|PG-13|R|NC-18)").ToString();
                    dataGridView1.Rows[_n].Cells[2].Value = _rate;

                    _words =
                        Regex.Match(_htmlDoc, @"([0-9]* (слов|слово|слова), [0-9]* (просмотра|просмотров))").ToString();
                    _words = Regex.Match(_words, @"([0-9]* (слов|слово|слова))").ToString();
                    _words = Regex.Match(_words, @"[0-9]*\d").ToString();
                    dataGridView1.Rows[_n].Cells[3].Value = _words;

                    _reads =
                        Regex.Match(_htmlDoc, @"([0-9]* (слов|слово|слова), [0-9]* (просмотра|просмотров))").ToString();
                    _reads = Regex.Match(_reads, @"([0-9]* (просмотра|просмотров))").ToString();
                    _reads = Regex.Match(_reads, @"[0-9]*\d").ToString();
                    dataGridView1.Rows[_n].Cells[4].Value = _reads;

                    if (_title == "") dataGridView1.Rows[_n].Visible = false;
                }
                progressBar1.Value = _number;
                _number = _number + 1;
            }

            button2.Enabled = true;
            button1.Enabled = false;

            _number = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.SelectAll();
            dataGridView1.Rows.Clear();
            button2.Enabled = false;
            button1.Enabled = true;
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            var newMdiChild = new Chooser();
            newMdiChild.Show();
            Hide();
        }
    }
}