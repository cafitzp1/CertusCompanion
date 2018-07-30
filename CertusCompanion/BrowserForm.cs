using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CertusCompanion
{
    public partial class BrowserForm : Form
    { 
        string Url = string.Empty;
        private string userName;
        private string passWord;
        private bool connectedToCertus = false;
        private string browserState;
        private List<Tuple<string, string>> ctcoIdPairList;
        string ctUrl = "https://www.bcscertus.com/search/certificates.aspx?c=36";

        public BrowserForm()
        {
            InitializeComponent();
            Url = ctUrl;
            Browser();
        }

        private void BrowserForm_Load(object sender, EventArgs e)
        {
            previousBtn.Enabled = false;
            nextBtn.Enabled = false;
        }

        private void Browser()
        {
            if (navigationComboBox.Text != "")
                Url = navigationComboBox.Text;
            webBrowser.Navigate(Url);
            webBrowser.ProgressChanged +=
            new WebBrowserProgressChangedEventHandler(webpage_ProgressChanged);
            webBrowser.DocumentTitleChanged +=
            new EventHandler(webpage_DocumentTitleChanged);
            webBrowser.StatusTextChanged += new EventHandler(webpage_StatusTextChanged);
            webBrowser.Navigated += new WebBrowserNavigatedEventHandler(webpage_Navigated);
            webBrowser.DocumentCompleted +=
            new WebBrowserDocumentCompletedEventHandler(webpage_DocumentCompleted);
        }

        private void Browser(string url)
        {
            navigationComboBox.Text = url;
            Url = navigationComboBox.Text;
            webBrowser.Navigate(Url);
            webBrowser.ProgressChanged +=
            new WebBrowserProgressChangedEventHandler(webpage_ProgressChanged);
            webBrowser.DocumentTitleChanged +=
            new EventHandler(webpage_DocumentTitleChanged);
            webBrowser.StatusTextChanged += new EventHandler(webpage_StatusTextChanged);
            webBrowser.Navigated += new WebBrowserNavigatedEventHandler(webpage_Navigated);
            webBrowser.DocumentCompleted +=
            new WebBrowserDocumentCompletedEventHandler(webpage_DocumentCompleted);
        }

        public void NavigateToUrl(string url)
        {
            Browser(url);
        }

        private void SetCredentials()
        {
            userName = "cfitzpatrick@bcsops.com";
            passWord = "Monday1!";
        }

        public void LogIn()
        {
            if(webBrowser.Url==null||!webBrowser.Url.ToString().StartsWith("https://www.bcscertus.com/sign-in"))
            {
                statusLbl.Text = "You are not on the sign-in page";
                (Application.OpenForms[0] as CertusCompanion.WorkflowManager).TurnOffCertusConnectionBtn();
                return;
            }

            SetCredentials();

            webBrowser.Document.GetElementById("ctl00_cphMain_m_UsernameTB").InnerText = userName;
            webBrowser.Document.GetElementById("ctl00_cphMain_m_PasswordTB").InnerText = passWord;

            foreach (HtmlElement HtmlElement1 in webBrowser.Document.Body.All)
            {
                if (HtmlElement1.GetAttribute("value") == "Sign-In")
                {
                    HtmlElement1.InvokeMember("click");
                    break;
                }
            }

            browserState = "logging in";

            //webBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(logIn_DocumentCompleted);
        }

        public void OpenItemInWorkflow(string itemID, string itemSubject)
        { 
            // prevent user from continuing if requirements are not met
            if (webBrowser.Url == null || !navigationComboBox.Text.StartsWith("https://www.bcscertus.com/"))
            {
                statusLbl.Text = "You are not on certus";
                return;
            }
            else if (!connectedToCertus)
            {
                statusLbl.Text = "You must be logged in first";
                return;
            }

            // enter subject in tbx, drop down to workflow, click go
            SearchWorkflow(itemID, itemSubject);

            /*
            // navigate to workflow if not there
            if (!webBrowser.Url.ToString().StartsWith("https://www.bcscertus.com/workflow.aspx?c=36"))
            {
                Browser("https://www.bcscertus.com/workflow.aspx?c=36");
                webBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(navigatedToMainWorkflowPage_DocumentCompleted);
                return;
            }
            */
        }

        private void SearchWorkflow(string itemID, string itemSubject)
        {
            webBrowser.Document.GetElementById("ctl00$m_SearchTB").InnerText = itemSubject;
            webBrowser.Document.GetElementById("ctl00$m_SearchTypeDDL").Children[3].SetAttribute("selected","selected");
            webBrowser.Document.GetElementById("ctl00$m_SearchBTN").InvokeMember("click"); 

            browserState = "searching workflow";
        }

        private void searchWorkflow_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            // ...
        }

        private void executeProcess1Btn_Click(object sender, EventArgs e)
        {
            ctcoIdPairList = new List<Tuple<string, string>>();
            AddIdsToList();
            // WriteIdsToTxtFile();
        }

        private void AddIdsToList()
        {
            browserState = "pulling ids";
            string pageCap = webBrowser.Document.GetElementById("ctl00_cphMain_m_PageNumberUpper_m_TopTotalPagesLBL").InnerText;

            foreach (HtmlElement HtmlElement1 in webBrowser.Document.Body.All)
            {
                if (HtmlElement1.TagName=="A")
                {
                    if(HtmlElement1.OuterHtml.Contains("managecertificate.aspx?c=36&amp;co="))
                    {
                        int ctIndx = HtmlElement1.OuterHtml.IndexOf("</A>") - 6;
                        int coIndx = HtmlElement1.OuterHtml.IndexOf("co=") +3;

                        int ctIdLen = 0;
                        int coIdLen = 0;

                        //determine contract id length
                        for (int i = ctIndx; i < ctIndx+7; i++)
                        {
                            if (Char.IsNumber(HtmlElement1.OuterHtml[i])) ++ctIdLen;
                            else i = ctIndx + 7;
                        }

                        //determine company id length
                        for (int i = coIndx; i < coIndx+7; i++)
                        {
                            if (Char.IsNumber(HtmlElement1.OuterHtml[i])) ++coIdLen;
                            else i = coIndx + 7;
                        }

                        string ctId = HtmlElement1.OuterHtml.Substring(ctIndx, ctIdLen);
                        string coId = HtmlElement1.OuterHtml.Substring(coIndx, coIdLen);

                        Tuple<string, string> ctcoIdPair = new Tuple<string, string>(ctId, coId);
                        ctcoIdPairList.Add(ctcoIdPair);
                    }
                }
            }

            // get current page on
            string thisPageNum = "0";
            var element = webBrowser.Document.GetElementById("ctl00$cphMain$m_PageNumberUpper$CurrentPageDDL");
            dynamic dom = element.DomElement;
            int index = (int)dom.selectedIndex();
            if (index != -1)
            {
                thisPageNum = element.Children[index].InnerText;
            }

            if (thisPageNum == pageCap)
            {
                browserState = "default";
                WriteIdsToTxtFile();
            }
            //else webBrowser.Document.GetElementById("ctl00$cphMain$m_PageNumberUpper$CurrentPageDDL").Children[Convert.ToInt32(nextPage)].SetAttribute("selected", "selected");
            else webBrowser.Document.GetElementById("ctl00_cphMain_m_PageNumberUpper_m_TopGoToNextPageLB").InvokeMember("click");
        }

        private void WriteIdsToTxtFile()
        {
            string path = @"\\Mac\Home\Downloads\ctcoIdPairs.txt";
            using (var tw = new StreamWriter(path, true))
            {
                tw.WriteLine("Contracts - Companies");

                foreach (Tuple<string, string> ctcoIdPair in ctcoIdPairList)
                {
                    tw.WriteLine($"{ctcoIdPair.Item1} - {ctcoIdPair.Item2}");
                }

                tw.Close();
            }

            browserState = "default";
            MessageBox.Show("IDs saved successfuly");
        }

        private void browserLogIn()
        {
            if (webBrowser.Url.ToString().StartsWith("https://www.bcscertus.com/sign-in"))
            {
                // not logged in
                try
                {
                    if ((Application.OpenForms[0] as CertusCompanion.WorkflowManager).InvokeRequired)
                    {
                        // uncheck connection button
                        (Application.OpenForms[0] as CertusCompanion.WorkflowManager).Invoke(new Action(() =>
                        { (Application.OpenForms[0] as CertusCompanion.WorkflowManager).TurnOffCertusConnectionBtn(); }));

                        // notify on main form
                        (Application.OpenForms[0] as CertusCompanion.WorkflowManager).Invoke(new Action(() =>
                        { (Application.OpenForms[0] as CertusCompanion.WorkflowManager).NotificationBox("Certus authentication failed", "Warning"); }));

                    }
                    else
                    {
                        (Application.OpenForms[0] as CertusCompanion.WorkflowManager).TurnOffCertusConnectionBtn();
                        (Application.OpenForms[0] as CertusCompanion.WorkflowManager).NotificationBox("Certus authentication failed", "Warning");
                    }

                    this.statusLbl.Text = "Log in failed";
                    connectedToCertus = false;
                    browserState = "failed authentication";
                }
                catch (Exception)
                {
                    // dont crash
                }
            }
            else
            {
                // logged in
                try
                {
                    if ((Application.OpenForms[0] as CertusCompanion.WorkflowManager).InvokeRequired)
                    {
                        // check connection button
                        (Application.OpenForms[0] as CertusCompanion.WorkflowManager).Invoke(new Action(() =>
                        { (Application.OpenForms[0] as CertusCompanion.WorkflowManager).TurnOnCertusConnectionBtn(); }));

                        // notify on main form
                        (Application.OpenForms[0] as CertusCompanion.WorkflowManager).Invoke(new Action(() =>
                        { (Application.OpenForms[0] as CertusCompanion.WorkflowManager).SetStatusLabelAndTimer("Certus authentication successful"); }));

                    }
                    else
                    {
                        (Application.OpenForms[0] as CertusCompanion.WorkflowManager).TurnOnCertusConnectionBtn();
                        (Application.OpenForms[0] as CertusCompanion.WorkflowManager).SetStatusLabelAndTimer("Certus authentication successful");
                    }

                    this.certusConnectionTimer.Enabled = true;
                    this.statusLbl.Text = "Done";
                    connectedToCertus = true;
                    browserState = "logged in";
                }
                catch (Exception)
                {
                    // dont crash
                }
            }

            // stop loading cursor
            if ((Application.OpenForms[0] as CertusCompanion.WorkflowManager).InvokeRequired)
            {
                (Application.OpenForms[0] as CertusCompanion.WorkflowManager).Invoke(new Action(() =>
                { (Application.OpenForms[0] as CertusCompanion.WorkflowManager).UseWaitCursor = false; }));
            }
            else
            {
                (Application.OpenForms[0] as CertusCompanion.WorkflowManager).UseWaitCursor = false;
            }
        }

        private void webpage_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //browserState = "default";

            switch (browserState)
            {
                case "logging in":
                    {
                        browserLogIn();
                        break;
                    }
                case "searching workflow":
                    {
                        WebPageLoaded();
                        break;
                    }
                case "pulling ids":
                    {
                        AddIdsToList();
                        break;
                    }
                //case "pulling ids finished":
                //    {
                //        WriteIdsToTxtFile();
                //        break;
                //    }
                default:
                    {
                        WebPageLoaded();
                        break;
                    }
            }
        }

        private void WebPageLoaded()
        {
            if (webBrowser.CanGoBack) previousBtn.Enabled = true;
            else previousBtn.Enabled = false;

            if (webBrowser.CanGoForward) nextBtn.Enabled = true;
            else nextBtn.Enabled = false;
            statusLbl.Text = "Done";
        }

        private void webpage_DocumentTitleChanged(object sender, EventArgs e)
        {
            this.Text = webBrowser.DocumentTitle.ToString();
        }

        private void webpage_StatusTextChanged(object sender, EventArgs e)
        {
            statusLbl.Text = webBrowser.StatusText;
        }

        private void webpage_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            progressBar.Maximum = (int)e.MaximumProgress;
            progressBar.Value = ((int)e.CurrentProgress < 0 ||
            (int)e.MaximumProgress < (int)e.CurrentProgress) ?
            (int)e.MaximumProgress : (int)e.CurrentProgress;
        }

        private void webpage_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            navigationComboBox.Text = webBrowser.Url.ToString();

            // keep restarting connection timer as long as certus is being navigated
            if (navigationComboBox.Text.StartsWith("https://www.bcscertus.com/"))
            {
                certusConnectionTimer.Enabled = false;
                certusConnectionTimer.Enabled = true;

                // reset timer on the main form as well
                if ((Application.OpenForms[0] as CertusCompanion.WorkflowManager).InvokeRequired)
                {
                    (Application.OpenForms[0] as CertusCompanion.WorkflowManager).Invoke(new Action(() =>
                    { (Application.OpenForms[0] as CertusCompanion.WorkflowManager).ResetCertusConnectionTimer(); }));

                }
                else
                {
                    (Application.OpenForms[0] as CertusCompanion.WorkflowManager).ResetCertusConnectionTimer();
                }
            }
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            webBrowser.Refresh();
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            webBrowser.GoForward();
        }

        private void previousBtn_Click(object sender, EventArgs e)
        {
            webBrowser.GoBack();
        }

        private void navigationComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Browser();
            }
        }

        private void certusConnectionTimer_Tick(object sender, EventArgs e)
        {
            // logged out due to inactivity
            try
            {
                //if ((Application.OpenForms[0] as CertusCompanion.WorkflowManager).InvokeRequired)
                //{
                //    // uncheck connection button
                //    (Application.OpenForms[0] as CertusCompanion.WorkflowManager).Invoke(new Action(() =>
                //    { (Application.OpenForms[0] as CertusCompanion.WorkflowManager).TurnOffCertusConnectionBtn(); }));

                //    // notify on main form
                //    (Application.OpenForms[0] as CertusCompanion.WorkflowManager).Invoke(new Action(() =>
                //    { (Application.OpenForms[0] as CertusCompanion.WorkflowManager).NotificationBox("Logged out of certus due to inactivity","Warning"); }));

                //}
                //else
                //{
                //    (Application.OpenForms[0] as CertusCompanion.WorkflowManager).TurnOffCertusConnectionBtn();
                //    (Application.OpenForms[0] as CertusCompanion.WorkflowManager).NotificationBox("Logged out of certus due to inactivity", "Warning");
                //}

                Browser();
            }
            catch (Exception)
            {
                // dont crash
            }

            certusConnectionTimer.Enabled = false;
        }

        private void BrowserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // stop loading cursor
            if ((Application.OpenForms[0] as CertusCompanion.WorkflowManager).InvokeRequired)
            {
                (Application.OpenForms[0] as CertusCompanion.WorkflowManager).Invoke(new Action(() =>
                { (Application.OpenForms[0] as CertusCompanion.WorkflowManager).UseWaitCursor = false; }));
            }
            else
            {
                (Application.OpenForms[0] as CertusCompanion.WorkflowManager).UseWaitCursor = false;
            }
        }
    }
}