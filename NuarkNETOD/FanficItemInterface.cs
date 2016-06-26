using System;
using System.Net;
using System.Windows.Forms;

namespace NuarkNETOD
{
    public partial class FanficItemInterface : UserControl
    {
        public string AGRate;
        public string CountReads;
        public string CountWords;
        public string Fb2Link;
        public string FName;
        public string HtmlLink;
        public string Identificator;

        private readonly WebClient wc = new WebClient();

        public FanficItemInterface()
        {
            InitializeComponent();
        }

        private void htmldownload_Click(object sender, EventArgs e)
        {
            var toDownload = "[" + AGRate + "]" + FName + "[HTML].zip";
            wc.DownloadFileAsync(new Uri(HtmlLink), toDownload);
        }

        private void fb2download_Click(object sender, EventArgs e)
        {
            var toDownload = "[" + AGRate + "]" + FName + "[FB2].zip";
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