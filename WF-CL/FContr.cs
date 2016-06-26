using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_CL
{
    public partial class FContr: UserControl
    {
        public string HtmlLink;
        public string Fb2Link;
        public string Identificator;
        public string CountWords;
        public string CountReads;
        public string AGRate;
        public string FName;

        WebClient wc = new WebClient();

        public FContr()
        {
            InitializeComponent();
        }

        private void htmldownload_Click(object sender, EventArgs e)
        {
            string toDownload = "[" + AGRate + "]" + FName + "[HTML].zip";
            wc.DownloadFileAsync(new Uri(HtmlLink), toDownload);
        }

        private void fb2download_Click(object sender, EventArgs e)
        {
            string toDownload = "[" + AGRate + "]" + FName + "[FB2].zip";
            wc.DownloadFileAsync(new Uri(Fb2Link), toDownload);
        }

        private void FContr_Load(object sender, EventArgs e)
        {
            FID.Text = Identificator;
            title.Text = FName;
            words.Text = CountWords;
            reads.Text = CountReads;
            rate.Text = AGRate;
        }
    }
}
