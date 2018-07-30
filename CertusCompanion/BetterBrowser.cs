using CefSharp;
using CefSharp.WinForms;
using CefSharp.WinForms.Internals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CertusCompanion
{
    public partial class BetterBrowser : Form
    {
        // --- REGION BROWSER STARTUP --- //
        #region Browser Startup
        string Url = string.Empty;
        //private string userName;
        //private string passWord;
        //private bool connectedToCertus = false;
        //private string browserState;
        //private List<Tuple<string, string>> ctcoIdPairList;
        string ctUrl = "https://www.bcscertus.com/sign-in.aspx?";
        ChromiumWebBrowser chrome;
        string userName;
        string passWord;

        public BetterBrowser()
        {
            InitializeComponent();
        }

        private void BetterBrowser_Load(object sender, EventArgs e)
        {
            CefSettings settings = new CefSettings();

            Cef.Initialize(settings);

            chrome = new ChromiumWebBrowser(ctUrl);
            this.browserPanel.Controls.Add(chrome);
            chrome.Dock = DockStyle.Fill;
            chrome.AddressChanged += Chrome_AddressChanged;
            navigationComboBox.KeyDown += navigationComboBox_KeyDown;
            chrome.StatusMessage += Chrome_StatusMessage;
        }
        #endregion Browser Startup

        // --- REGION EVENT HANDLERS --- //
        #region Event Handlers
        private void Chrome_StatusMessage(object sender, StatusMessageEventArgs args)
        {
            this.InvokeOnUiThreadIfRequired(new Action(() =>
            {
                statusLbl.Text = args.Value;
            }));
        }

        private void Chrome_AddressChanged(object sender, AddressChangedEventArgs e)
        {
            this.Invoke(new MethodInvoker(() =>
            {
                this.navigationComboBox.Text = e.Address;
            }));
        }
        #endregion Event Handlers

        // --- REGION FORM CONTROLS --- //
        #region Form Controls
        private void refreshBtn_Click(object sender, EventArgs e)
        {
            chrome.Refresh();
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            if (chrome.CanGoForward) chrome.Forward();
        }

        private void previousBtn_Click(object sender, EventArgs e)
        {
            if (chrome.CanGoBack) chrome.Back();
        }


        private void button0_Click(object sender, EventArgs e)
        {
            chrome.Load(ctUrl);
        }

        private void SetCredentials()
        {
            userName = "cfitzpatrick@bcsops.com";
            passWord = "Monday1!";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetCredentials();

            string script = $"document.getElementById('ctl00_cphMain_m_UsernameTB').value='{userName}';\r\n" +
                            $"document.getElementById('ctl00_cphMain_m_PasswordTB').value = '{passWord}';";
            chrome.EvaluateScriptAsync(script).ContinueWith(x =>
            {
                var response = x.Result;

                if (response.Success && response.Result != null)
                {
                    chrome.EvaluateScriptAsync("document.getElementById('ctl00_cphMain_m_LoginBTN').click();");
                }
                else
                {
                    chrome.EvaluateScriptAsync("alert('Error')");
                }
            });

            //chrome.document.GetElementById("ctl00_cphMain_m_UsernameTB").InnerText = userName;
            //chrome.Document.GetElementById("ctl00_cphMain_m_PasswordTB").InnerText = passWord;

            //foreach (HtmlElement HtmlElement1 in webBrowser.Document.Body.All)
            //{
            //    if (HtmlElement1.GetAttribute("value") == "Sign-In")
            //    {
            //        HtmlElement1.InvokeMember("click");
            //        break;
            //    }
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void BetterBrowser_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }
        #endregion Form Controls

        // --- REGION OTHER --- //
        #region Other
        private void navigationComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                chrome.Load(navigationComboBox.Text);
            }
        }

        private void statusLbl_TextChanged(object sender, EventArgs e)
        {
            if (statusLbl.Text == null || statusLbl.Text == String.Empty) statusLbl.Visible = false;
            else statusLbl.Visible = true;
        }
        #endregion Other
    }
}
