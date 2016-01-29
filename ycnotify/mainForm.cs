using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ycnotify
{
    public partial class mainForm : Form
    {

        public mainForm()
        {
            InitializeComponent();
        }

        // we need this to make the webbrowser control open the default browser instead of navigating
        private void content_DocumentCompleted(object sender,
                                 WebBrowserDocumentCompletedEventArgs e)
        {
            int i;
            for (i = 0; i < content.Document.Links.Count; i++)
            {
                string link = content.Document.Links[i].GetAttribute("href");
                content.Document.Links[i].Click += new HtmlElementEventHandler((_sender, _e) => linkClicked(_sender, _e, link));
            }
        }

        private void linkClicked(object sender, System.EventArgs e, string link)
        {
            Process.Start(link);
        }

        public void changeText(string text)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(changeText), new object[] { text });
                return;
            }
            content.AllowNavigation = true;
            content.DocumentText = text;
            
        }

        private void content_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            // this is so that when we click a link it only loads in the default browser and not in the WebBrowser control
            content.AllowNavigation = false;
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.UserClosing) return;
            e.Cancel = true;
            Hide();
            Program.checker.setUpdateText(false);
        }

        private void mainForm_Shown(object sender, EventArgs e)
        {
            Program.checker.setUpdateText(true);
            Program.checker.displayLastScan();
        }

        private void hideButton_Click(object sender, EventArgs e)
        {
            Hide();
            Program.checker.setUpdateText(false);
        }

        private void minutesCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(minutesCombobox.SelectedIndex)
            {
                case 0: // 1 min
                    ycnotify.Properties.Settings.Default.interval = 1000 * 60;
                    break;
                case 1: // 5 min
                    ycnotify.Properties.Settings.Default.interval = 1000 * 60 * 5;
                    break;
                case 2: // 10 min
                    ycnotify.Properties.Settings.Default.interval = 1000 * 60 * 10;
                    break;
                case 3: // 30 min
                    ycnotify.Properties.Settings.Default.interval = 1000 * 60 * 30;
                    break;
                case 4: // 1 hour
                    ycnotify.Properties.Settings.Default.interval = 1000 * 60 * 60;
                    break;
                default:
                    break;
            }
        }
    }
}
