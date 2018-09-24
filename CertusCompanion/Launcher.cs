using System;
using System.Threading;
using System.Windows.Forms;

namespace CertusCompanion
{
    public partial class Launcher : Form
    {
        public int Distance { get; set; }
        public bool Increment { get; set; }
        public string StatusMessage {get;set;}
        public bool HideStatus { get; set; }

        //
        // delegates
        private delegate void CloseDelegate();
        private delegate void ReportDelegate();
        private delegate void MoveDelegate();
        private static Launcher launcher;

        //
        // constructor
        public Launcher()
        {
            InitializeComponent();
            this.loadForegroundPanel.Width = 0;
            this.statusLbl.Visible = false;
        }

        //
        // methods
        public static void ShowLauncher()
        {
            if (launcher != null) return;
            Thread thread = new Thread(new ThreadStart(Launcher.ShowForm));
            thread.IsBackground = true;
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
        private static void ShowForm()
        {
            launcher = new Launcher();
            Application.Run(launcher);
        }
        public static void CloseForm()
        {
            launcher.Invoke(new CloseDelegate(Launcher.CloseFormInternal));
        }
        private static void CloseFormInternal()
        {
            launcher.Close();
            launcher = null;
        }
        public static void ReportStatus(string message, bool hide = false)
        {
            launcher.StatusMessage = message;
            launcher.HideStatus = hide;
            launcher.Invoke(new ReportDelegate(ReportStatusInternal));
        }
        private static void ReportStatusInternal()
        {
            if (launcher.HideStatus) launcher.statusLbl.Visible = false;
            else
            {
                launcher.statusLbl.Visible = true;
                launcher.statusLbl.Text = launcher.StatusMessage;
            }
        }
        public static void MoveBar(int distance, bool increment = true)
        {
            launcher.Distance = distance;
            launcher.Increment = increment;
            launcher.Invoke(new MoveDelegate(MoveBarInternal));
        }
        private static void MoveBarInternal()
        {
            double percentage = (double)launcher.Distance * .01;

            if (launcher.Increment) // move incremenetally
            {
                launcher.loadForegroundPanel.Width += Convert.ToInt32(launcher.loadBackgroundPanel.Width*percentage);
            }
            else // replace and use new distance
            {
                launcher.loadForegroundPanel.Width = Convert.ToInt32(launcher.loadBackgroundPanel.Width * percentage);
            }
        }
    }
}
