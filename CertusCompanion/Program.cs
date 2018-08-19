#define DEBUG
#undef DEBUG

using System;
using System.Threading;
using System.Windows.Forms;

namespace CertusCompanion
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        //
// for using the launch form
        #if !DEBUG
        [STAThread]
        static void Main(string[] args)
        {
            Launcher.ShowLauncher();

            // delay startup to show the launch form
            Thread.Sleep(1000);
            Launcher.ReportStatus("Initializing application settings...");
            Thread.Sleep(1000);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            WorkflowManager workflowManager = new WorkflowManager();

            // delay startup to show the launch form
            Launcher.ReportStatus("Launching...");
            Thread.Sleep(1000);

            Launcher.CloseForm();
            Application.Run(workflowManager);
        }

        //
// for starting without the launcher
        #else
                [STAThread]
                static void Main(string[] args)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new WorkflowManager());
                }
        #endif

        //
// for keeping the app alive when terminating the main form
        /* 
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var main = new Launcher();
            main.FormClosed += new FormClosedEventHandler(FormClosed);
            main.Show();
            Application.Run();
        }

        static void FormClosed(object sendert, FormClosedEventArgs e)
        {
            ((Form)sendert).FormClosed -= FormClosed;
            if (Application.OpenForms.Count == 0) Application.ExitThread();
            else Application.OpenForms[0].FormClosed += FormClosed;
        }
        */
    }
}
