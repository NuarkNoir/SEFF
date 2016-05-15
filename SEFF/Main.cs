using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private int number = 1;
        private int maxFanf = 5;
        private int n;
        private string title;
        private string htmlDoc;
        private string words;
        private string reads;
        private string rate;
        public bool forf;

        private string getResponse(string uri)
        {
            forf = false;
            try
            {
                StringBuilder sb = new StringBuilder();
                byte[] buf = new byte[8192];
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream resStream = response.GetResponseStream();
                int count = 0;
                do
                {
                    count = resStream.Read(buf, 0, buf.Length);
                    if (count != 0)
                    {
                        sb.Append(Encoding.UTF8.GetString(buf, 0, count));
                    }
                }
                while (count > 0);
                return sb.ToString();
            }
            catch (WebException ex)
            {
                forf = true;
                HttpWebResponse webResponse = (HttpWebResponse)ex.Response;
                if (webResponse.StatusCode == HttpStatusCode.NotFound)
                {
                    return "404";
                }
                else
                {
                    if (webResponse.StatusCode == HttpStatusCode.Forbidden)
                    {
                        return "403";
                    }
                    else
                    {
                        if (webResponse.StatusCode == HttpStatusCode.BadGateway)
                        {
                            return "502";
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = int.Parse(textBox1.Text);
            maxFanf = i;
            progressBar1.Maximum = maxFanf;
            progressBar1.Value = 0;
            while (number <= maxFanf)
            {
                htmlDoc = getResponse(@"https://stories.everypony.ru/story/" + number);

                if (forf == false)
                {
                    n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = number;

                    title = Regex.Match(htmlDoc, @"<title>(.*?)</title>").ToString();
                    title = Regex.Match(title, @"[^(<title>)]([\[\]A-Za-zА-Яа-я\.: —]?[^( & )]){1,100}[^(</title>)]").ToString();
                    dataGridView1.Rows[n].Cells[1].Value = title;

                    rate = Regex.Match(htmlDoc, @"(Рейтинг — <a href=""/search/rating/)(1|2|3|4)(/"">)(G|PG-13|R|NC-18)").ToString();
                    rate = Regex.Match(rate, @"(G|PG-13|R|NC-18)").ToString();
                    dataGridView1.Rows[n].Cells[2].Value = rate;

                    words = Regex.Match(htmlDoc, @"([0-9]* (слов|слово|слова), [0-9]* (просмотра|просмотров))").ToString();
                    words = Regex.Match(words, @"([0-9]* (слов|слово|слова))").ToString();
                    words = Regex.Match(words, @"[0-9]*\d").ToString();
                    dataGridView1.Rows[n].Cells[3].Value = words;

                    reads = Regex.Match(htmlDoc, @"([0-9]* (слов|слово|слова), [0-9]* (просмотра|просмотров))").ToString();
                    reads = Regex.Match(reads, @"([0-9]* (просмотра|просмотров))").ToString();
                    reads = Regex.Match(reads, @"[0-9]*\d").ToString();
                    dataGridView1.Rows[n].Cells[4].Value = reads;

                    if (title == "") dataGridView1.Rows[n].Visible = false;
                }
                progressBar1.Value = number;
                number = number + 1;
            }

            button2.Enabled = true;
            button1.Enabled = false;

            number = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.SelectAll();
            dataGridView1.Rows.Clear();
            button2.Enabled = false;
            button1.Enabled = true;
        }

        private void chooserCaller_Click(object sender, EventArgs e)
        {
            Chooser newMDIChild = new Chooser();
            newMDIChild.Show();
            Hide();
        }
    }
}