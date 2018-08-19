using System.Threading;
using System.Windows.Forms;

namespace CertusCompanion
{
    public partial class Launcher : Form
    {
        //
        // delegates
        private delegate void CloseDelegate();
        private static Launcher launcher;

        //
        // constructor
        public Launcher()
        {
            InitializeComponent();
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
    }
}
