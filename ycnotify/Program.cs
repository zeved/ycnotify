using System;
using System.Windows.Forms;

namespace ycnotify
{
    static class Program
    {
        
        public static mainForm mf;
        public static Checker checker;
        public static AppContext ac;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);    
            mf = new mainForm();
            checker = new Checker();
            ac = new AppContext();
            Application.Run(ac);
        }
    }

    public class AppContext : ApplicationContext
    {
        public NotifyIcon trayIcon;

        public AppContext()
        {
            trayIcon = new NotifyIcon()
            {
                Icon = Properties.Resources.ycicon, ContextMenu = new ContextMenu(new MenuItem[] 
                    {
                        new MenuItem("Show", Show),
                        new MenuItem("Exit", Exit)
                    }), Visible = true
            };
            trayIcon.ShowBalloonTip(2000, "YCNotify", "YCNotify is running in your system tray", ToolTipIcon.Info);
        }

        private void Show(object sender, EventArgs e)
        {
            Program.mf.Show();
            Program.checker.displayLastScan();
        }

        private void Exit(object sender, EventArgs e)
        {
            trayIcon.Visible = false;
            Application.Exit();
        }
    }
}
