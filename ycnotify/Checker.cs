using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace ycnotify
{
    class Checker
    {
        public static string htmlData;
        static Thread timerThread;
        // these will hold our scan last results so we can see what's new etc.
        public static List<string> lastLinkTitles;
        public static List<string> lastLinks;
        public static List<string> lastAges;
        // this will hold how new many items we have (max 30, lol, because YC shows 30 / page by default); 
        // I will not bother scanning second page, etc. first page will do
        public static int newItems;
        public static bool updateText;
        static bool firstTime;

        // these two are needed becuse updateText is static so not get/set is possible here :-/
        public void setUpdateText(bool val)
        {
            updateText = val;
        }

        public bool getUpdateText()
        {
            return updateText;
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            timerThread = new Thread(new ThreadStart(check));
            // delete previous contents
            //Program.mf.changeText("");  
            timerThread.Start();
        }

        public Checker()
        {
            lastLinkTitles = new List<string>();
            lastLinks = new List<string>();
            lastAges = new List<string>();
            // first time here so run the check then start the timer
            updateText = false;
            check();
            firstTime = false;
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimedEvent);
            timer.Interval = ycnotify.Properties.Settings.Default.interval;
            timer.Enabled = true;
        } 

        public void displayLastScan()
        {
            for (int i = 0; i < lastLinks.Count; i++)
            {
                // combine the 3 parts of information
                string item = "<a href='" + lastLinks.ElementAt(i) + "'>" + lastLinkTitles.ElementAt(i) + "</a> (" + lastAges.ElementAt(i) + ")</br>";
                htmlData += item;
            }
            Program.mf.changeText(htmlData);
        }

        public static void check()
        {
            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load("https://news.ycombinator.com/newest");

            HtmlNodeCollection athings = doc.DocumentNode.SelectNodes("//tr[@class='athing']");     // select table rows that belong to the 'athing' class

            List<string> linkTitles = new List<string>();
            List<string> links = new List<string>();
            List<string> ages = new List<string>();

            foreach (HtmlNode thing in athings)
            {
                // select only links with rel='nofollow' (those are links to items in the news list, others are functional links like comment, points etc)
                HtmlNodeCollection _links = thing.SelectNodes("//a[@rel='nofollow']");              
                foreach(HtmlNode _link in _links)
                {
                    // select only http/s urls not #urls
                    if (_link.Attributes["href"].Value.Contains("http"))                             
                    {
                        links.Add(_link.Attributes["href"].Value);
                    }
                }
                // select tds with the title class
                HtmlNodeCollection titles = thing.SelectNodes("//td[@class='title']");              
                foreach(HtmlNode title in titles)
                {
                    // only select titles, not numberings (also have 'title' class)
                    if (System.Text.RegularExpressions.Regex.IsMatch(title.InnerText, "\\A\\d{1,}(\\W)") == false)
                            linkTitles.Add(title.InnerText);
                }
                // select spans with the 'age' class
                HtmlNodeCollection _ages = thing.SelectNodes("//span[@class='age']//a");            
                foreach(HtmlNode age in _ages)
                {
                    ages.Add(age.InnerText);
                }
                break;
            }

            htmlData = "";

            for (int i = 0; i < links.Count; i++)
            {
                // combine the 3 parts of information
                string item = "<a href='" + links.ElementAt(i) + "'>" + linkTitles.ElementAt(i) + "</a> (" + ages.ElementAt(i) + ")</br>";
                htmlData += item;
            }

            // compute difference between last and current links list so we get how many are new
            newItems = 0;
            IEnumerable<string> difference = lastLinks.Except(links);
            foreach (string s in difference)
                newItems++;

            if(Program.ac != null && newItems > 0)
                    Program.ac.trayIcon.ShowBalloonTip(3000, "New links!", "There are " + newItems.ToString() + " new links!", ToolTipIcon.Info);
            if((updateText == true && newItems > 0) || firstTime == true)
                Program.mf.changeText(htmlData);

            // save those as 'last', because on the next check they will be deleted and replaced
            lastLinkTitles = new List<string>(linkTitles);
            lastLinks = new List<string>(links);
            lastAges = new List<string>(ages);

            web = null;
            doc = null;
            athings = null;
            
            // only update text if we want to, maybe the form is hidden?, also, check if it's the first time
            if ((updateText == true && newItems > 0) || firstTime == true)
                Program.mf.changeText(htmlData);
        }

    }
}
