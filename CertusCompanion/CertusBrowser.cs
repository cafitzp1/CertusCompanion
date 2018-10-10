using CefSharp;
using CefSharp.WinForms;
using CefSharp.WinForms.Internals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace CertusCompanion
{
    public partial class CertusBrowser : Form
    {
        // --- BROWSER STARTUP --- //
        #region Browser Startup

        #region Certus Browser Data
        ChromiumWebBrowser chrome;
        BrowserConfigForm configForm;
        List<WorkflowItem> itemList1;
        MyRenderer myRenderer;
        Dictionary<string, string> itemIDsAndAssignmentIDsDict;
        Dictionary<string, string> currentDict;
        List<Dictionary<string, string>> subItemIDsAndAssignmentIDsDictList;
        List<string> itemIDs;
        List<Company> companiesDataSource;
        List<Certificate> certificatesDataSource;
        string clientID;
        string currentUserIDToAssign;
        string currentStatusIDToAssign;
        string logMessage;
        string consoleMessage;
        string consoleInstruction;
        string outputMessage;
        string messageTag;
        string trackTag;
        string script;
        int widthWhenPanelVisible;
        int itemsChecked;
        int itemsToAssign;
        int itemsToChangeStatus;
        int dictCount;
        int perUserAssignedItems;
        int allAssignedItems;
        int allCompletedItems;
        bool consoleInstructionReceived;
        bool panelVisible;
        //
        // instantiated through config file
        string homeURI; //https://www.bcscertus.com/sign-in.aspx?returnURL=%2fworkflow.aspx%3fc%3d36
        string userName; //username
        string passWord; //password
        string completeStatusID; //4
        string assignStatusID; //2
        string customScript1; //...
        string customScript2; //...
        string customScript3; //...
        private bool contextMenuOpen;
        #endregion

        // 
        // Blank constructor for no datasource or items imported
        public CertusBrowser()
        {
            InitializeComponent();

            // no items. disable preset scripts
            completeItemsScriptBtn.Enabled = false;
            distributeItemsScriptBtn.Enabled = false;
        }
        //
        // Constructor for datasources but no items list
        public CertusBrowser(string clientID, List<Company> companiesList, List<Certificate> certificatesList)
        {
            InitializeComponent();

            this.clientID = clientID;
            this.companiesDataSource = companiesList;
            this.certificatesDataSource = certificatesList;

            // no items. disable preset scripts
            completeItemsScriptBtn.Enabled = false;
            distributeItemsScriptBtn.Enabled = false;
        }
        // 
        // Constructor for all current browser features
        public CertusBrowser(string clientID, List<WorkflowItem> transferredWorkflowItems, List<Company> companiesList, List<Certificate> certificatesList)
        {
            InitializeComponent();

            this.itemList1 = transferredWorkflowItems;

            this.clientID = clientID;
            this.companiesDataSource = companiesList;
            this.certificatesDataSource = certificatesList;

            // disable preset scripts if no items / missing id / etc
            if (transferredWorkflowItems==null || transferredWorkflowItems.Count==0 || transferredWorkflowItems[0].DocumentWorkflowItemID==string.Empty || transferredWorkflowItems[0].DocumentWorkflowItemID==null)
            {
                completeItemsScriptBtn.Enabled = false;
                distributeItemsScriptBtn.Enabled = false;
                return;
            }

            // disable distribute script if...
            foreach (WorkflowItem item in transferredWorkflowItems)
            {
                // ... any missing analyst id
                if (item.AssignedToID==null || item.AssignedToID==String.Empty)
                {
                    distributeItemsScriptBtn.Enabled = false;
                    MessageBox.Show("One or more items were missing Assigned IDs. Distribute items feature has been disabled.");
                    return;
                }
                // ... any id not all numbers
                foreach (char c in item.AssignedToID)
                {
                    if (!Char.IsDigit(c))
                    {
                        distributeItemsScriptBtn.Enabled = false;
                        MessageBox.Show("One or more items had invalid Assigned IDs. Distribute items feature has been disabled.");
                        return;
                    }
                }
            }
        }
        
        private void BetterBrowser_Load(object sender, EventArgs e)
        {
            CefSettings settings = new CefSettings();
            myRenderer = new MyRenderer();

            Cef.Initialize(settings);

            homeURI = "https://www.bcscertus.com/sign-in.aspx?returnURL=%2fworkflow.aspx%3fc%3d36";
            chrome = new ChromiumWebBrowser(homeURI);
            this.browserPanel.Controls.Add(chrome);
            chrome.Dock = DockStyle.Fill;
            panelVisible = false;
            widthWhenPanelVisible = this.ClientSize.Width - 200;

            // change context renderers
            certInputContextMenuStrip.Renderer = myRenderer;
            companyInputContextMenuStrip.Renderer = myRenderer;
            browserSettingsContextMenuStrip.Renderer = myRenderer;

            // register events
            navigationComboBox.KeyDown += navigationComboBox_KeyDown;
            chrome.AddressChanged += Chrome_AddressChanged;
            chrome.StatusMessage += Chrome_StatusMessage;
            chrome.ConsoleMessage += Chrome_ConsoleMessage;
            menuBtn.FlatAppearance.MouseOverBackColor = menuBtn.FlatAppearance.MouseDownBackColor;

            // this is the only way I can get the panel to close properly on form load...
            this.showConsoleToolStripMenuItem_Click(sender, e);
            this.showConsoleToolStripMenuItem_Click(sender, e);
            
            // store options
            try
            {
                homeURI = Properties.Settings.Default.HomePage;
                userName = Properties.Settings.Default.Username;
                passWord = Properties.Settings.Default.Password;
                completeStatusID = Properties.Settings.Default.CompleteID.ToString();
                assignStatusID = Properties.Settings.Default.DistributeID.ToString();
                customScript1 = Properties.Settings.Default.CustomScript1;
                customScript2 = Properties.Settings.Default.CustomScript2;
                customScript3 = Properties.Settings.Default.CustomScript3;
            }
            catch (Exception m)
            {
                MessageBox.Show("There was a problem extracting data from the browser configuration file. Ensure data is entered correctly and instructions " +
                    "are followed as specified in the document. It is crucial that the header tags are not edited and that the correct content goes in each field " +
                    "beneath its corresponding tag. If you do not wish to enter content, leave the area blank or put '...' in the line directly beneath the tag.\n\n" +
                    $"Error message: {m.Message}", "Error");
            }

            // set buttons
            SetCustomScriptButtons();
        }
        private string ReadConfig()//-
        {
            // no longer being used -- configuration file functionality replaced with application Properties.Settings

            string s=String.Empty;

            using (Stream strm = Assembly.GetExecutingAssembly().GetManifestResourceStream("CertusCompanion.BrowserConfiguration.txt"))
            {
                using (StreamReader sr = new StreamReader(strm))
                {
                    s = sr.ReadToEnd();
                }
            }

            return s;
        }
        private string ExtractConfig(string fileContents, string tag)//-
        {
            // see ReadConfig()

            string s = String.Empty;

            // get lines beneath tag up to either '#' or '<' symbol IF line is not blank or '...'
            //
            
            // get start of tag and from it the start of input
            int tagStart = fileContents.IndexOf(tag);
            int inputStart = tagStart + tag.Length + 2;
            int inputEnd = 0;

            // search each char after input begin looking for '/'
            int searchIndx = inputStart;
            bool endFound = false;
            int loopCount = 0;
            while (!endFound)
            {
                ++loopCount;

                if (fileContents[searchIndx] == '/')
                {
                    ++searchIndx;
                    if (fileContents[searchIndx] == '/')
                    {
                        ++searchIndx;
                        if (fileContents[searchIndx] == '/')
                        {
                            endFound = true;
                            inputEnd = searchIndx;
                        }
                    }
                }

                ++searchIndx;

                if (loopCount >= 50000)
                    throw new Exception("End tag ('///') was not found");
            }

            // get string between start and end
            s = fileContents.Substring(inputStart, inputEnd - inputStart - 2);

            // trim
            s.TrimStart(' ');
            s.TrimEnd(' ');
            if (s.EndsWith("\r\n")) s = s.Remove(s.Length - 2, 2);

            return s;
        }
        private void SetCustomScriptButtons()
        {
            try
            {
                if(itemList1!=null && itemList1.Count>0) InitializeItemIDs();

                if (customScript1 != null && customScript1 != String.Empty && customScript1 != "...")
                {
                    #if DEBUG
                    /* // snippet is for testing when running only the browser and not WorkflowManager first
                    itemIDs = new List<string>();
                    itemIDs.Add("123");
                    itemIDs.Add("234");
                    itemIDs.Add("345");
                    */
                    #endif

                    if (itemIDs != null && itemIDs.Count > 0)
                    {
                        customScript1 = AddTransferArrayFunctionToScript(customScript1);
                    }

                    customScript1Btn.Enabled = true;
                }
                if (customScript2 != null && customScript2 != String.Empty && customScript2 != "...")
                {
                    customScript2Btn.Enabled = true;
                }
                if (customScript3 != null && customScript3 != String.Empty && customScript3 != "...")
                {
                    customScript3Btn.Enabled = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("There was an error setting the custom scripts. Make sure the script was entered correctly " +
                    "in the browser configuration file");

                customScript1Btn.Enabled = false;
                customScript2Btn.Enabled = false;
                customScript3Btn.Enabled = false;
            }
        }
        private string AddTransferArrayFunctionToScript(string script)
        {
            // method will insert the javascript code needed for declaring and instantiating an array of items (checked items brought over from WorkflowManager.cs)
            // prior to the custom script's beginning (array instantiated in javascript within the scope of the user entered script). If user decides to use the data,
            // user only has to call the function and save it to their own variable prior to the execution of their script. ex: var myData = transferArray();
            // Funciton returns the array (this array is only a IDs <string> at the moment). If user decides not to use the array, the code is still there but user
            // does not have to call the function.

            string s = script;

            string fScript =
                            "function transferArray() { " +
                            "\r\tvar i, array; " +
                            "\r\tarray = []; \r\n";

            foreach (var itemID in itemIDs)
            {
                fScript +=
                        $"\r\tarray.push({itemID}); ";
            }

            fScript +=
                        "\r\n\r\treturn array; " +
                        "\n} ";

            s = s.Insert(0, $"{fScript}\r\n\r\n");

            return s;
        }
        #endregion

        // --- EVENT HANDLERS --- //
        #region Event Handlers
        private void Chrome_AddressChanged(object sender, AddressChangedEventArgs e)
        {
            this.Invoke(new MethodInvoker(() =>
            {
                this.navigationComboBox.Text = e.Address;
            }));
        }
        private void Chrome_StatusMessage(object sender, StatusMessageEventArgs args)
        {
            this.InvokeOnUiThreadIfRequired(new Action(() =>
            {
                statusLbl.Text = args.Value;
            }));
        }
        private void Chrome_ConsoleMessage(object sender, ConsoleMessageEventArgs e)
        {
            consoleMessage = e.Message;
            messageTag = "system generated";
            consoleInstruction = "";
            outputMessage = "";

            if (consoleMessage.StartsWith(":"))
            {
                int indx = consoleMessage.IndexOf(':', 1);
                messageTag = consoleMessage.Substring(1,indx-1);
            }

            switch(messageTag)
            {
                case "ready":
                    {
                        consoleInstruction = messageTag;
                        outputMessage = consoleMessage.Substring(messageTag.Length+2);
                        consoleInstructionReceived = true;
                    }
                    break;
                case "stop":
                    {
                        consoleInstruction = messageTag;
                        outputMessage = consoleMessage.Substring(messageTag.Length + 2);
                        consoleInstructionReceived = true;
                    }
                    break;
                case "continue":
                    {
                        consoleInstruction = messageTag;
                        outputMessage = consoleMessage.Substring(messageTag.Length + 2);
                        consoleInstructionReceived = true;
                    }
                    break;
                case "complete":
                    {
                        consoleInstruction = messageTag;
                        outputMessage = consoleMessage.Substring(messageTag.Length + 2);
                        consoleInstructionReceived = true;
                    }
                    break;
                case "abort":
                    {
                        consoleInstruction = messageTag;
                        outputMessage = consoleMessage.Substring(messageTag.Length + 2);
                        consoleInstructionReceived = true;
                    }
                    break;
                case "kill":
                    {
                        consoleInstruction = messageTag;
                        outputMessage = consoleMessage.Substring(messageTag.Length + 2);
                        consoleInstructionReceived = true;
                    }
                    break;
                case "track":
                    {
                        int indx2 = consoleMessage.IndexOf(':', 7);
                        trackTag = consoleMessage.Substring(7, indx2-7);

                        if(trackTag == "checked")
                        {
                            try
                            {
                                itemsChecked = Convert.ToInt32(consoleMessage.Substring(15));
                                if (distributeItemsBackgroundWorker.IsBusy)
                                {
                                    allAssignedItems += itemsChecked;
                                    perUserAssignedItems += itemsChecked;
                                }
                                else if (completeItemsBackgroundWorker.IsBusy) allCompletedItems += itemsChecked;
                            }
                            catch (Exception) { itemsChecked = -1; }
                        }
                    }
                    break;
            }
        }
        #endregion

        // --- PROCESSES --- //
        #region Processes
        //
        // Methods essential for the functionaility of the 
        // complete and distribute processes
        private void ClearConsoleInstruction()
        {
            consoleInstructionReceived = false;
            consoleInstruction = String.Empty;
            outputMessage = String.Empty;
            consoleMessage = String.Empty;
            messageTag = String.Empty;
        }
        private void WaitForConsoleInstruction()
        {
            bool abort = false;
            bool kill = false;
            int attempts = 0;
            int messages = 0;

            while (!consoleInstructionReceived && !abort && !kill) // this is set to true when console instruction message is received
            {
                // cancel processes if pending
                if(distributeItemsBackgroundWorker.CancellationPending || completeItemsBackgroundWorker.CancellationPending)
                {
                    kill = true;
                    continue;
                }

                ++attempts;
                if (attempts % 100 == 0) //10 seconds worth of attempts
                {
                    ++messages;
                    if (messages > 20) abort = true;
                    else
                    {
                        logMessage = $"Awaiting console instruction (attempt: {messages})...";
                        this.Invoke(new Action(() => { LogEvent(logMessage); this.Refresh(); }));
                    }
                }
                Thread.Sleep(100);
            }
            if (kill && !consoleInstructionReceived) consoleInstruction = "kill";
            else if (abort && !consoleInstructionReceived) consoleInstruction = "abort";
        }
        private void LogEvent(string message, int newLines = 0)
        {
            for (int i = 0; i < newLines; i++)
            {
                outputTbx.Text += "\r\n";
            }

            outputTbx.Text += "> " + message + "\r\n";

            if (outputTbx.Text.Length > 0) outputTbx.SelectionStart = outputTbx.Text.Length - 1;

            outputTbx.ScrollToCaret();
        }
        //
        // Full complete items process
        //
        private void completeItemsBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            CompleteItems();
        }
        private void completeItemsBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                if (this.InvokeRequired) this.Invoke(new Action(() => { LogEvent("--Process Cancelled\r\n--", 1); this.Refresh(); }));
                else { LogEvent("--Process Cancelled--\r\n", 1); this.Refresh(); }

                MessageBox.Show("Process cancelled");
            }
            else if (e.Error != null)
            {
                if (this.InvokeRequired) this.Invoke(new Action(() => { LogEvent("--Process failed--\r\n", 1); this.Refresh(); }));
                else { LogEvent("--Process Failed--\r\n", 1); this.Refresh(); }

                MessageBox.Show(e.Error.Message);
            }
        }
        private void CompleteProcessRouter(int i)
        {
            ClearConsoleInstruction();
            switch (i)
            {
                case 1:
                    CompleteStep1();
                    break;
                case 2:
                    CompleteStep2();
                    break;
                case 3:
                    CompleteStep3();
                    break;
                case 4:
                    CompleteStep4();
                    break;
                default:
                    break;
            }
        }
        private void CompleteItems()
        {
            this.Invoke(new Action(() => { outputTbx.Focus(); }));

            #region Initiate Item Completion
            this.Invoke(new Action(() => { LogEvent("Initiating Item Completion process...\r\n", 1); this.Refresh(); }));

            // make a List of ids
            itemIDs = new List<string>();
            allCompletedItems = 0;

            // generate item list
            try
            {
                this.Invoke(new Action(() => { LogEvent("Generating list...\r\n"); this.Refresh(); }));

                foreach (WorkflowItem item in itemList1)
                {
                    string docID = item.DocumentWorkflowItemID;

                    itemIDs.Add(docID);
                }
            }
            catch (Exception)
            {
                this.Invoke(new Action(() => { LogEvent("--Process Failed--\r\n", 1); this.Refresh(); }));
                MessageBox.Show("There was an error processing the request. Items have most likely not been imported.");
                return;
            }
            #endregion

            // complete items
            #region Log Status Information
            itemsToChangeStatus = itemIDs.Count;

            this.Invoke(new Action(() => { LogEvent($"Items to complete: {itemIDs.Count}\r\n"); this.Refresh(); }));
            #endregion

            CompleteProcessRouter(1);

            #region Conclude Item Completion

            this.Invoke(new Action(() => { LogEvent($"Item Completion Process Finished\r\n\r\n{allCompletedItems}/{itemIDs.Count} items completed", 1); this.Refresh(); }));

            #endregion
        }
        private void CompleteStep1()
        {
            this.Invoke(new Action(() => { LogEvent("Cycling pages..."); this.Refresh(); }));

            // Write script - Cycle pages
            #region scriptW
            script = "Cycle pages";

            // definition for method to loop while document is loading
            string scriptW =
                "function g() { " +
                    "setTimeout(function() {" +
                        "if (document.getElementById('loadingOverlay') || document.readyState != 'complete') {" +
                            "g(); " +
                            "return; " +
                        "} " +
                        "endPageAndMaxItems(); " +
                    "}, 100); " +
                "} ";

            // method to change items to 1000, call the loading/looping method, and then change to the last page
            scriptW +=
                "function endPageAndMaxItems() { " +
                    "var totalPages; " +
                    "if (document.URL.indexOf('.bcscertus.com/workflow.aspx?') == -1) { " +
                        "alert('This only works in workflow!'); " +
                        //"console.log(':kill:'); " +
                        "return; " +
                    "} " +
                    "totalPages = document.getElementById('ctl00_cphMain_m_PageNumberUpper_m_TopTotalPagesLBL').textContent.trim() * 1; " +
                    "if (totalPages != 1) { " +
                        "if (document.getElementById('ctl00_cphMain_m_RecPerPageHF').value * 1 < 1000) { " +
                            "document.getElementById('ctl00_cphMain_m_RecPerPageTB').value = 1000; " +
                            "__doPostBack('ctl00$cphMain$m_RecPerPageLB', ''); " +
                            "g(); " +
                            "return; " +
                        "} " +
                        "if (document.getElementById('ctl00_cphMain_m_PageNumberUpper_CurrentPageDDL').value * 1 != totalPages) { " +
                            "__doPostBack('ctl00$cphMain$m_PageNumberUpper$m_TopGoToLastPageLB', ''); " +
                            "g(); " +
                            "return; " +
                        "} " +
                    "} " +
                    "console.log(':continue:'); " +
                "} ";

            // call method
            scriptW +=
                "endPageAndMaxItems(); ";
            #endregion

            // Execute as task
            var taskW = chrome.EvaluateScriptAsync(scriptW, 350000);

            // Wait for task to complete
            taskW.Wait();

            // Evaluate
            #region Evaluate
            var responseW = taskW.Result;

            if (responseW.Success)
            {
                this.Invoke(new Action(() => { LogEvent($"'{script}' script executed successfully"); this.Refresh(); }));

                WaitForConsoleInstruction();

                if (consoleInstruction == "continue")
                {
                    this.Invoke(new Action(() => { LogEvent("Pages cycled successfully"); this.Refresh(); }));

                    CompleteProcessRouter(2);
                }
                else if (consoleInstruction == "abort")
                {
                    this.Invoke(new Action(() => { LogEvent("--Step aborted"); this.Refresh(); }));

                    throw new Exception($"Process aborted while attempting to cycle pages");
                }
                else if (consoleInstruction == "kill")
                {
                    this.Invoke(new Action(() => { LogEvent("--Step cancelled"); this.Refresh(); }));
                }
                else
                {
                    this.Invoke(new Action(() => { LogEvent("--Console instruction failed"); this.Refresh(); }));
                    this.Invoke(new Action(() => { LogEvent("--Step failed"); this.Refresh(); }));

                    throw new Exception($"Process failed while attempting to cycle pages");
                }
            }
            else
            {
                this.Invoke(new Action(() => { LogEvent("--Script execution failed"); this.Refresh(); }));
                this.Invoke(new Action(() => { LogEvent("--Step failed"); this.Refresh(); }));

                throw new Exception($"Process failed while executing '{script}' script");
            }
            #endregion
        }
        private void CompleteStep2()
        {
            this.Invoke(new Action(() => { LogEvent("Checking items(s)..."); this.Refresh(); }));

            // Write script - Check items
            #region scriptX
            script = "Check items";

            // transferArray function definition
            #region region
            string scriptX =
                        "function transferArray() { " +
                        "var i, array; " +
                        "array = []; ";

            foreach (var itemID in itemIDs)
            {
                scriptX +=
                        $"array.push({itemID}); ";
            }

            scriptX +=
                        "return array; " +
                        "} ";
            #endregion

            // getZero function definition
            #region region
            scriptX +=
                        "function getZero(x) { " +
                            "if (x < 10) { " +
                                "return \"0\" + x; " +
                            "} " +
                            "return x; " +
                        "} ";
            #endregion

            // check items function definition
            #region region
            scriptX +=
                        "function checkItems() { " +
                        "var i, j, hf, left, type, count, menubar; " +
                        "left = \"ctl00_cphMain_m_WorkflowGV_ctl\"; " +
                        "type = document.getElementById(\"ctl00_cphPopups_m_FilterItemTypeDDL\").value; " +
                        "count = 0; " +
                        "if (type.length < 1) { " +
                            "type = 2; " +
                        "} " +
                        "type *= 1; " +
                        "for (i = 2; (hf = document.getElementById(left + getZero(i) + \"_m_WorkflowItemID\")); i++) { " +
                            "if (document.getElementById(left + getZero(i) + \"_m_WorkflowItemType\").value * 1 == type) { " +
                                "for (j = 0; j < myData.length; j++) { " +
                                    "if (myData[j] * 1 == hf.value * 1) { " +
                                        "document.getElementById(left + getZero(i) + \"_m_WorkflowRowCB\").checked = true; " +
                                        "count++; " +
                                        "j = myData.length; " +
                                        "} " +
                                    "} " +
                                "} " +
                            "} " +
                            "document.getElementById(\"ctl00_cphMain_m_BulkActionTopBTN\").disabled = false; " +
                            "document.getElementById('ctl00_m_UserNameLBL').innerText = '<< ITEMS CHECKED: ' + count + ' >> '; " +
                            "console.log(':track:checked:' + count); " +
                            "console.log(':continue:'); " +
                        "} ";
            #endregion

            // call transferArray
            #region region
            scriptX +=
                        "myData = transferArray(); ";
            #endregion

            // call
            #region region
            scriptX +=
                        "checkItems(); ";
            #endregion
            #endregion

            // Execute as task
            var taskX = chrome.EvaluateScriptAsync(scriptX, 300001);

            // Wait for task to complete
            taskX.Wait();

            // Evaluate
            #region Evaluate
            var responseX = taskX.Result;

            if (responseX.Success)
            {
                this.Invoke(new Action(() => { LogEvent($"'{script}' script executed successfully"); this.Refresh(); }));

                WaitForConsoleInstruction();

                if (consoleInstruction == "continue")
                {
                    this.Invoke(new Action(() => { LogEvent($"{itemsChecked} item(s) checked successfully"); this.Refresh(); }));

                    CompleteProcessRouter(3);
                }
                else if (consoleInstruction == "abort")
                {
                    this.Invoke(new Action(() => { LogEvent("--Step aborted"); this.Refresh(); }));

                    throw new Exception($"Process aborted while attempting to check items");
                }
                else if (consoleInstruction == "kill")
                {
                    this.Invoke(new Action(() => { LogEvent("--Step cancelled"); this.Refresh(); }));
                }
                else
                {
                    this.Invoke(new Action(() => { LogEvent("--Console instruction failed"); this.Refresh(); }));
                    this.Invoke(new Action(() => { LogEvent("--Step failed"); this.Refresh(); }));

                    throw new Exception($"Process failed while attempting to check items");
                }
            }
            else
            {
                this.Invoke(new Action(() => { LogEvent("--Script execution failed"); this.Refresh(); }));
                this.Invoke(new Action(() => { LogEvent("--Step failed"); this.Refresh(); }));

                throw new Exception($"Process failed while executing '{script}' script");
            }
            #endregion
        }
        private void CompleteStep3()
        {
            this.Invoke(new Action(() => { LogEvent("Completing items(s)..."); this.Refresh(); }));

            // Write script - Bulk action
            #region scriptY
            script = "Bulk action";

            string scriptY =

                // definition for method to loop while document is loading
                "function g() { " +
                    "setTimeout(function() { " +
                        "if (document.getElementById('loadingOverlay') || document.readyState != 'complete') { " +
                            "g(); " +
                            "return; " +
                        "} " +
                        "else if ($(document.getElementById('ctl00_cphPopups_m_EditWorkflowBulkPNL')).is (':hidden')) { " +
                            "console.log(':continue:'); " +
                            "return; " +
                        "} " +
                        "else { " +
                            "console.log(':stop:'); " +
                            "return; " +
                        "} " +
                    "}, 100); " +
                "} " +

                // method to bulk action
                "function bulkAction() {" +

                    // click bulk action btn
                    "document.getElementById('ctl00_cphMain_m_BulkActionTopBTN').click(); " +

                    // select element definition
                    "function SelectElement(id, valueToSelect) { " +
                        "var element = document.getElementById(id); " +
                        "element.value = valueToSelect; " +
                    "} " +

                    // set ddl's
                    $"SelectElement('ctl00_cphPopups_m_BulkDocumentWorkflowStatusDDL', '{completeStatusID}'); " +

                    // click save button
                    #if !DEBUG
                    "document.getElementById('ctl00_cphPopups_m_WorkflowBulkSaveBTN').click(); " +
                    #elif DEBUG
                    "document.getElementById('ctl00_cphPopups_m_WorkflowBulkCancelBTN').click(); " + // cancel button (for debugging)
                    #endif

                    // wait for response
                    "g(); " +
                    "return; " +
                "} " +

                // call
                "bulkAction(); ";

            #endregion

            // Execute as task
            var taskY = chrome.EvaluateScriptAsync(scriptY, 300001);

            // Wait for task to complete
            taskY.Wait();

            // Evaluate
            #region Evaluate
            var responseY = taskY.Result;

            if (responseY.Success)
            {
                this.Invoke(new Action(() => { LogEvent($"'{script}' script executed successfully"); this.Refresh(); }));

                WaitForConsoleInstruction();

                if (consoleInstruction == "continue")
                {
                    this.Invoke(new Action(() => { LogEvent($"{itemsChecked} item(s) completed successfully"); this.Refresh(); }));

                    CompleteProcessRouter(4);
                }
                else if (consoleInstruction == "stop")
                {
                    this.Invoke(new Action(() => { LogEvent("--Bulk Action Failed"); this.Refresh(); }));

                    throw new Exception($"Process failed while attempting to complete items");
                }
                else if (consoleInstruction == "abort")
                {
                    this.Invoke(new Action(() => { LogEvent("--Step aborted"); this.Refresh(); }));

                    throw new Exception($"Process aborted while attempting to complete items");
                }
                else if (consoleInstruction == "kill")
                {
                    this.Invoke(new Action(() => { LogEvent("--Step cancelled"); this.Refresh(); }));
                }
                else
                {
                    this.Invoke(new Action(() => { LogEvent("--Console instruction failed"); this.Refresh(); }));
                    this.Invoke(new Action(() => { LogEvent("--Step failed"); this.Refresh(); }));

                    throw new Exception($"Process failed while attempting to complete items");
                }
            }
            else
            {
                this.Invoke(new Action(() => { LogEvent("--Script execution failed"); this.Refresh(); }));
                this.Invoke(new Action(() => { LogEvent("--Step failed"); this.Refresh(); }));

                throw new Exception($"Process failed while executing '{script}' script");
            }
            #endregion
        }
        private void CompleteStep4()
        {
            this.Invoke(new Action(() => { LogEvent("Navigating to previous page..."); this.Refresh(); }));

            // write script - Prev page
            #region scriptZ
            script = "Navigate to prev page";

            string scriptZ =

                // definition for method to loop while document is loading
                "function g() { " +
                    "setTimeout(function() { " +
                        "if (document.getElementById('loadingOverlay') || document.readyState != 'complete') { " +
                            "g(); " +
                            "return; " +
                        "} " +
                        "else { " +
                            "console.log(':continue:'); " +
                            "return; " +
                        "} " +
                    "}, 100); " +
                "} " +

                // move to previous page
                "function prevPage() { " +
                    "if (document.getElementById('ctl00_cphMain_m_PageNumberUpper_CurrentPageDDL').value == 1) " +
                    "{ " +
                        "console.log(':complete:') " +
                    "} " +
                    "else {" +
                        "__doPostBack('ctl00$cphMain$m_PageNumberUpper$m_TopGoToPreviousPageLB', ''); " +
                        "if (document.getElementById('loadingOverlay') || document.readyState != 'complete') { " +
                            "g(); " +
                        "} " +
                    "} " +
                "} " +

                // call
                "prevPage(); ";

            #endregion

            // Execute as task
            var taskZ = chrome.EvaluateScriptAsync(scriptZ, 300001);

            // Wait for task to complete
            taskZ.Wait();

            // Evaluate
            #region Evaluate
            var responseZ = taskZ.Result;

            if (responseZ.Success)
            {
                this.Invoke(new Action(() => { LogEvent($"'{script}' script executed successfully"); this.Refresh(); }));

                WaitForConsoleInstruction();

                if (consoleInstruction == "continue")
                {
                    this.Invoke(new Action(() => { LogEvent("Navigated to previous page"); this.Refresh(); }));

                    CompleteProcessRouter(2);
                }
                else if (consoleInstruction == "complete")
                {
                    this.Invoke(new Action(() => { LogEvent("No more pages"); this.Refresh(); }));
                }
                else if (consoleInstruction == "abort")
                {
                    this.Invoke(new Action(() => { LogEvent("--Step aborted"); this.Refresh(); }));

                    throw new Exception($"Process aborted while attempting to navigate pages");
                }
                else if (consoleInstruction == "kill")
                {
                    this.Invoke(new Action(() => { LogEvent("--Step cancelled"); this.Refresh(); }));
                }
                else
                {
                    this.Invoke(new Action(() => { LogEvent("--Console instruction failed"); this.Refresh(); }));
                    this.Invoke(new Action(() => { LogEvent("--Step failed"); this.Refresh(); }));

                    throw new Exception($"Process failed while attempting to navigate pages");
                }
            }
            else
            {
                this.Invoke(new Action(() => { LogEvent("--Script execution failed"); this.Refresh(); }));
                this.Invoke(new Action(() => { LogEvent("--Step failed"); this.Refresh(); }));

                throw new Exception($"Process failed while executing '{script}' script");
            }
            #endregion
        }
        //
        // Full distribute items process
        //
        private void distributeItemsBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            DistributeItems();
        }
        private void distributeItemsBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                if (this.InvokeRequired) this.Invoke(new Action(() => { LogEvent("--Process Cancelled\r\n--", 1); this.Refresh(); }));
                else { LogEvent("--Process Cancelled--\r\n", 1); this.Refresh(); }

                MessageBox.Show("Process cancelled");
            }
            else if (e.Error != null)
            {
                if (this.InvokeRequired) this.Invoke(new Action(() => { LogEvent("--Process failed--\r\n", 1); this.Refresh(); }));
                else { LogEvent("--Process Failed--\r\n", 1); this.Refresh(); }

                MessageBox.Show(e.Error.Message);
            }
        }
        private void DistributeProcessRouter(int i)
        {
            ClearConsoleInstruction();
            switch (i)
            {
                case 1:
                    DistributeStep1();
                    break;
                case 2:
                    DistributeStep2();
                    break;
                case 3:
                    DistributeStep3();
                    break;
                case 4:
                    DistributeStep4();
                    break;
                default:
                    break;
            }
        }
        private void DistributeItems()
        {
            this.Invoke(new Action(() => { outputTbx.Focus(); }));

            #region Initiate Item Distribution
            this.Invoke(new Action(() => { LogEvent("Initiating Item Distribution process...\r\n", 1); this.Refresh(); }));

            // make a Dictionary and a list of sub-Dictionaries
            #region Data Instantiation

            itemIDsAndAssignmentIDsDict = new Dictionary<string, string>();
            subItemIDsAndAssignmentIDsDictList = new List<Dictionary<string, string>>();
            dictCount = 0;
            allAssignedItems = 0;

            #endregion

            // generate all items and assigned ids dictionary
            try
            {
                this.Invoke(new Action(() => { LogEvent("Generating lists...\r\n"); this.Refresh(); }));

                foreach (WorkflowItem item in itemList1)
                {
                    string docID = item.DocumentWorkflowItemID;
                    string assignID = item.AssignedToID;

                    itemIDsAndAssignmentIDsDict.Add(docID, assignID);
                }
            }
            catch (Exception)
            {
                this.Invoke(new Action(() => { LogEvent("--Process Failed--\r\n", 1); this.Refresh(); }));
                MessageBox.Show("There was an error processing the request. Items have most likely not been imported.");
                return;
            }

            // get unique ids from dictionary
            try
            {
                var distinctAssignIDs = itemIDsAndAssignmentIDsDict.Values.Distinct().ToList();

                foreach (var id in distinctAssignIDs)
                {
                    // make a sub-Dictionary
                    Dictionary<string, string> subItemIDsAndAssignmentIDsDict = new Dictionary<string, string>();

                    // generate items and their assigned id dictionaries, save into a list
                    foreach (WorkflowItem item in itemList1)
                    {
                        if (item.AssignedToID == id)
                        {
                            string docID = item.DocumentWorkflowItemID;
                            string assignID = item.AssignedToID;

                            subItemIDsAndAssignmentIDsDict.Add(docID, assignID);
                        }
                    }

                    subItemIDsAndAssignmentIDsDictList.Add(subItemIDsAndAssignmentIDsDict);
                }
            }
            catch (Exception)
            {
                this.Invoke(new Action(() => { LogEvent("--Process Failed--\r\n", 1); this.Refresh(); }));
                MessageBox.Show("There was an error processing the request. Could not set items and assigned IDs lists.");
                return;
            }
            #endregion

            foreach (var dict in subItemIDsAndAssignmentIDsDictList)
            {
                #region Log Assignment Information
                currentDict = dict;
                currentUserIDToAssign = dict.Values.FirstOrDefault();
                currentStatusIDToAssign = assignStatusID;
                itemsToAssign = dict.Count;
                ++dictCount;
                perUserAssignedItems = 0;

                this.Invoke(new Action(() => { LogEvent($"User {currentUserIDToAssign} ({dictCount}/{subItemIDsAndAssignmentIDsDictList.Count}) | Item(s) assigned: {allAssignedItems}/{itemList1.Count}\r\n{itemsToAssign} items(s) to assign statusID: {currentStatusIDToAssign}\r\n"); this.Refresh(); }));
                #endregion

                DistributeProcessRouter(1);
            }

            #region Conclude Item Distribution

            this.Invoke(new Action(() => { LogEvent($"Item Distribution Complete\r\n\r\n{allAssignedItems}/{itemIDsAndAssignmentIDsDict.Count} items assigned to {subItemIDsAndAssignmentIDsDictList.Count} user(s)", 1); this.Refresh(); }));

            #endregion
        }
        private void DistributeStep1()
        {
            this.Invoke(new Action(() => { LogEvent("Cycling pages..."); this.Refresh(); }));

            // Write script - Cycle pages
            #region scriptW
            script = "Cycle pages";

            // definition for method to loop while document is loading
            string scriptW =
                "function g() { " +
                    "setTimeout(function() {" +
                        "if (document.getElementById('loadingOverlay') || document.readyState != 'complete') {" +
                            "g(); " +
                            "return; " +
                        "} " +
                        "endPageAndMaxItems(); " +
                    "}, 100); " +
                "} ";

            // method to change items to 1000, call the loading/looping method, and then change to the last page
            scriptW +=
                "function endPageAndMaxItems() { " +
                    "var totalPages; " +
                    "if (document.URL.indexOf('.bcscertus.com/workflow.aspx?') == -1) { " +
                        "alert('This only works in workflow!'); " +
                        //"console.log(':kill:'); " +
                        "return; " +
                    "} " +
                    "totalPages = document.getElementById('ctl00_cphMain_m_PageNumberUpper_m_TopTotalPagesLBL').textContent.trim() * 1; " +
                    "if (totalPages != 1) { " +
                        "if (document.getElementById('ctl00_cphMain_m_RecPerPageHF').value * 1 < 1000) { " +
                            "document.getElementById('ctl00_cphMain_m_RecPerPageTB').value = 1000; " +
                            "__doPostBack('ctl00$cphMain$m_RecPerPageLB', ''); " +
                            "g(); " +
                            "return; " +
                        "} " +
                        "if (document.getElementById('ctl00_cphMain_m_PageNumberUpper_CurrentPageDDL').value * 1 != totalPages) { " +
                            "__doPostBack('ctl00$cphMain$m_PageNumberUpper$m_TopGoToLastPageLB', ''); " +
                            "g(); " +
                            "return; " +
                        "} " +
                    "} " +
                    "console.log(':continue:'); " +
                "} ";

            // call method
            scriptW +=
                "endPageAndMaxItems(); ";
            #endregion

            // Execute as task
            var taskW = chrome.EvaluateScriptAsync(scriptW,350000);

            // Wait for task to complete
            taskW.Wait();

            // Evaluate
            #region Evaluate
            var responseW = taskW.Result;

            if (responseW.Success)
            {
                this.Invoke(new Action(() => { LogEvent($"'{script}' script executed successfully"); this.Refresh(); }));

                WaitForConsoleInstruction();

                if (consoleInstruction == "continue")
                {
                    this.Invoke(new Action(() => { LogEvent("Pages cycled successfully"); this.Refresh(); }));

                    DistributeProcessRouter(2);
                }
                else if (consoleInstruction == "abort")
                {
                    this.Invoke(new Action(() => { LogEvent("--Step aborted"); this.Refresh(); }));

                    throw new Exception($"Process aborted while attempting to cycle pages for userID: {currentUserIDToAssign} ({dictCount}/{subItemIDsAndAssignmentIDsDictList.Count})");
                }
                else if (consoleInstruction == "kill")
                {
                    this.Invoke(new Action(() => { LogEvent("--Step cancelled"); this.Refresh(); }));
                }
                else
                {
                    this.Invoke(new Action(() => { LogEvent("--Console instruction failed"); this.Refresh(); }));
                    this.Invoke(new Action(() => { LogEvent("--Step failed"); this.Refresh(); }));

                    throw new Exception($"Process failed while attempting to cycle pages for userID: {currentUserIDToAssign} ({dictCount}/{subItemIDsAndAssignmentIDsDictList.Count})");
                }
            }
            else
            {
                this.Invoke(new Action(() => { LogEvent("--Script execution failed"); this.Refresh(); }));
                this.Invoke(new Action(() => { LogEvent("--Step failed"); this.Refresh(); }));

                throw new Exception($"Process failed while executing '{script}' script for userID: {currentUserIDToAssign} ({dictCount}/{subItemIDsAndAssignmentIDsDictList.Count})");
            }
            #endregion
        }
        private void DistributeStep2()
        {
            this.Invoke(new Action(() => { LogEvent("Checking items(s)..."); this.Refresh(); }));

            // Write script - Check items
            #region scriptX
            script = "Check items";

            // transferArray function definition
            #region region
            string scriptX =
                        "function transferArray() { " +
                        "var i, array; " +
                        "array = []; ";

            foreach (var keyValuePair in currentDict)
            {
                scriptX +=
                        $"array.push({keyValuePair.Key}); ";
            }

            scriptX +=
                        "return array; " +
                        "} ";
            #endregion

            // getZero function definition
            #region region
            scriptX +=
                        "function getZero(x) { " +
                            "if (x < 10) { " +
                                "return \"0\" + x; " +
                            "} " +
                            "return x; " +
                        "} ";
            #endregion

            // check items function definition
            #region region
            scriptX +=
                        "function checkItems() { " +
                        "var i, j, hf, left, type, count, menubar; " +
                        "left = \"ctl00_cphMain_m_WorkflowGV_ctl\"; " +
                        "type = document.getElementById(\"ctl00_cphPopups_m_FilterItemTypeDDL\").value; " +
                        "count = 0; " +
                        "if (type.length < 1) { " +
                            "type = 2; " +
                        "} " +
                        "type *= 1; " +
                        "for (i = 2; (hf = document.getElementById(left + getZero(i) + \"_m_WorkflowItemID\")); i++) { " +
                            "if (document.getElementById(left + getZero(i) + \"_m_WorkflowItemType\").value * 1 == type) { " +
                                "for (j = 0; j < myData.length; j++) { " +
                                    "if (myData[j] * 1 == hf.value * 1) { " +
                                        "document.getElementById(left + getZero(i) + \"_m_WorkflowRowCB\").checked = true; " +
                                        "count++; " +
                                        "j = myData.length; " +
                                        "} " +
                                    "} " +
                                "} " +
                            "} " +
                            "document.getElementById(\"ctl00_cphMain_m_BulkActionTopBTN\").disabled = false; " +
                            "document.getElementById('ctl00_m_UserNameLBL').innerText = '<< ITEMS CHECKED: ' + count + ' >> '; " +
                            "console.log(':track:checked:' + count); " +
                            "console.log(':continue:'); " +
                        "} ";
            #endregion

            // call transferArray
            #region region
            scriptX +=
                        "myData = transferArray(); ";
            #endregion

            // call
            #region region
            scriptX +=
                        "checkItems(); ";
            #endregion
            #endregion

            // Execute as task
            var taskX = chrome.EvaluateScriptAsync(scriptX, 300001);

            // Wait for task to complete
            taskX.Wait();

            // Evaluate
            #region Evaluate
            var responseX = taskX.Result;

            if (responseX.Success)
            {
                this.Invoke(new Action(() => { LogEvent($"'{script}' script executed successfully"); this.Refresh(); }));

                WaitForConsoleInstruction();

                if (consoleInstruction == "continue")
                {
                    this.Invoke(new Action(() => { LogEvent($"{itemsChecked} item(s) checked successfully"); this.Refresh(); }));

                    DistributeProcessRouter(3);
                }
                else if (consoleInstruction == "abort")
                {
                    this.Invoke(new Action(() => { LogEvent("--Step aborted"); this.Refresh(); }));

                    throw new Exception($"Process aborted while attempting to check items for userID: {currentUserIDToAssign} ({dictCount}/{subItemIDsAndAssignmentIDsDictList.Count})");
                }
                else if (consoleInstruction == "kill")
                {
                    this.Invoke(new Action(() => { LogEvent("--Step cancelled"); this.Refresh(); }));
                }
                else
                {
                    this.Invoke(new Action(() => { LogEvent("--Console instruction failed"); this.Refresh(); }));
                    this.Invoke(new Action(() => { LogEvent("--Step failed"); this.Refresh(); }));

                    throw new Exception($"Process failed while attempting to check items for userID: {currentUserIDToAssign} ({dictCount}/{subItemIDsAndAssignmentIDsDictList.Count})");
                }
            }
            else
            {
                this.Invoke(new Action(() => { LogEvent("--Script execution failed"); this.Refresh(); }));
                this.Invoke(new Action(() => { LogEvent("--Step failed"); this.Refresh(); }));

                throw new Exception($"Process failed while executing '{script}' script for userID: {currentUserIDToAssign} ({dictCount}/{subItemIDsAndAssignmentIDsDictList.Count})");
            }
            #endregion
        }
        private void DistributeStep3()
        {
            this.Invoke(new Action(() => { LogEvent("Assigning items(s)..."); this.Refresh(); }));

            // Write script - Bulk action
            #region scriptY
            script = "Bulk action";

            string scriptY =

                // definition for method to loop while document is loading
                "function g() { " +
                    "setTimeout(function() { " +
                        "if (document.getElementById('loadingOverlay') || document.readyState != 'complete') { " +
                            "g(); " +
                            "return; " +
                        "} " +
                        "else if ($(document.getElementById('ctl00_cphPopups_m_EditWorkflowBulkPNL')).is (':hidden')) { " +
                            "console.log(':continue:'); " +
                            "return; " +
                        "} " +
		                "else { " +
                            "console.log(':stop:'); " +
                            "return; " +
                        "} " +
                    "}, 100); " +
                "} " +

                // method to bulk action
                "function bulkAction() {" +

                    // click bulk action btn
                    "document.getElementById('ctl00_cphMain_m_BulkActionTopBTN').click(); " +

                    // select element definition
                    "function SelectElement(id, valueToSelect) { " +
                        "var element = document.getElementById(id); " +
                        "element.value = valueToSelect; " +
                    "} " +

                    // set ddl's
                    $"SelectElement('ctl00_cphPopups_m_BulkAnalystsDDL', '{currentUserIDToAssign}'); " +
                    $"SelectElement('ctl00_cphPopups_m_BulkDocumentWorkflowStatusDDL', '{currentStatusIDToAssign}'); " +

                    // click save button
                    #if !DEBUG
                    "document.getElementById('ctl00_cphPopups_m_WorkflowBulkSaveBTN').click(); " +
                    #elif DEBUG
                    "document.getElementById('ctl00_cphPopups_m_WorkflowBulkCancelBTN').click(); " + // cancel button (for debugging)
                    #endif

                    // wait for response
                    "g(); " +
                    "return; " +
                "} " +

                // call
                "bulkAction(); ";
                #endregion

            // Execute as task
            var taskY = chrome.EvaluateScriptAsync(scriptY, 300001);

            // Wait for task to complete
            taskY.Wait();

            // Evaluate
            #region Evaluate
            var responseY = taskY.Result;

            if (responseY.Success)
            {
                this.Invoke(new Action(() => { LogEvent($"'{script}' script executed successfully"); this.Refresh(); }));

                WaitForConsoleInstruction();

                if (consoleInstruction == "continue")
                {
                    this.Invoke(new Action(() => { LogEvent($"{itemsChecked} item(s) assigned successfully"); this.Refresh(); }));

                    DistributeProcessRouter(4);
                }
                else if (consoleInstruction == "stop") // first test debug SHOULD come to here
                {
                    this.Invoke(new Action(() => { LogEvent("--Bulk Action Failed"); this.Refresh(); }));

                    throw new Exception($"Process failed while attempting to assign items for userID: {currentUserIDToAssign} ({dictCount}/{subItemIDsAndAssignmentIDsDictList.Count})");
                }
                else if (consoleInstruction == "abort")
                {
                    this.Invoke(new Action(() => { LogEvent("--Step aborted"); this.Refresh(); }));

                    throw new Exception($"Process aborted while attempting to assign items for userID: {currentUserIDToAssign} ({dictCount}/{subItemIDsAndAssignmentIDsDictList.Count})");
                }
                else if (consoleInstruction == "kill")
                {
                    this.Invoke(new Action(() => { LogEvent("--Step cancelled"); this.Refresh(); }));
                }
                else
                {
                    this.Invoke(new Action(() => { LogEvent("--Console instruction failed"); this.Refresh(); }));
                    this.Invoke(new Action(() => { LogEvent("--Step failed"); this.Refresh(); }));

                    throw new Exception($"Process failed while attempting to assign items for userID: {currentUserIDToAssign} ({dictCount}/{subItemIDsAndAssignmentIDsDictList.Count})");
                }
            }
            else
            {
                this.Invoke(new Action(() => { LogEvent("--Script execution failed"); this.Refresh(); }));
                this.Invoke(new Action(() => { LogEvent("--Step failed"); this.Refresh(); }));

                throw new Exception($"Process failed while executing '{script}' script for userID: {currentUserIDToAssign} ({dictCount}/{subItemIDsAndAssignmentIDsDictList.Count})");
            }
            #endregion
        }
        private void DistributeStep4()
        {
            this.Invoke(new Action(() => { LogEvent("Navigating to previous page..."); this.Refresh(); }));

            // write script - Prev page
            #region scriptZ
            script = "Navigate to prev page";

            string scriptZ =

                // definition for method to loop while document is loading
                "function g() { " +
                    "setTimeout(function() { " +
                        "if (document.getElementById('loadingOverlay') || document.readyState != 'complete') { " +
                            "g(); " +
                            "return; " +
                        "} " +
                        "else { " +
                            "console.log(':continue:'); " +
                            "return; " +
                        "} " +
                    "}, 100); " +
                "} " +

                // move to previous page
                "function prevPage() { " +
                    "if (document.getElementById('ctl00_cphMain_m_PageNumberUpper_CurrentPageDDL').value == 1) " +
                    "{ " +
                        "console.log(':complete:') " +
                    "} " +
                    "else {" +
                        "__doPostBack('ctl00$cphMain$m_PageNumberUpper$m_TopGoToPreviousPageLB', ''); " +
                        "if (document.getElementById('loadingOverlay') || document.readyState != 'complete') { " +
                            "g(); " +
                        "} " +
                    "} " +
                "} " +

                // call
                "prevPage(); ";
                #endregion

            // Execute as task
            var taskZ = chrome.EvaluateScriptAsync(scriptZ, 300001);

            // Wait for task to complete
            taskZ.Wait();

            // Evaluate
            #region Evaluate
            var responseZ = taskZ.Result;

            if (responseZ.Success)
            {
                this.Invoke(new Action(() => { LogEvent($"'{script}' script executed successfully"); this.Refresh(); }));

                WaitForConsoleInstruction();

                if (consoleInstruction == "continue")
                {
                    this.Invoke(new Action(() => { LogEvent("Navigated to previous page"); this.Refresh(); }));

                    DistributeProcessRouter(2);
                }
                else if (consoleInstruction == "complete")
                {
                    this.Invoke(new Action(() => { LogEvent("No more pages"); this.Refresh(); }));
                    this.Invoke(new Action(() => { LogEvent($"--User {currentUserIDToAssign} assignment complete--\r\n{perUserAssignedItems}/{currentDict.Count} assigned as statusID: {currentStatusIDToAssign}\r\n"); this.Refresh(); }));
                }
                else if (consoleInstruction == "abort")
                {
                    this.Invoke(new Action(() => { LogEvent("--Step aborted"); this.Refresh(); }));

                    throw new Exception($"Process aborted while attempting to navigate pages for userID: {currentUserIDToAssign} ({dictCount}/{subItemIDsAndAssignmentIDsDictList.Count})");
                }
                else if (consoleInstruction == "kill")
                {
                    this.Invoke(new Action(() => { LogEvent("--Step cancelled"); this.Refresh(); }));
                }
                else
                {
                    this.Invoke(new Action(() => { LogEvent("--Console instruction failed"); this.Refresh(); }));
                    this.Invoke(new Action(() => { LogEvent("--Step failed"); this.Refresh(); }));

                    throw new Exception($"Process failed while attempting to navigate pages for userID: {currentUserIDToAssign} ({dictCount}/{subItemIDsAndAssignmentIDsDictList.Count})");
                }
            }
            else
            {
                this.Invoke(new Action(() => { LogEvent("--Script execution failed"); this.Refresh(); }));
                this.Invoke(new Action(() => { LogEvent("--Step failed"); this.Refresh(); }));

                throw new Exception($"Process failed while executing '{script}' script for userID: {currentUserIDToAssign} ({dictCount}/{subItemIDsAndAssignmentIDsDictList.Count})");
            }
        #endregion
        }
        //
        // custom scripts
        private void InitializeItemIDs()
        {
            // make a List of ids
            itemIDs = new List<string>();
            allCompletedItems = 0;

            // generate item list if list available
            if (itemList1 != null && itemList1.Count > 0)
            {
                foreach (WorkflowItem item in itemList1)
                {
                    string docID = item.DocumentWorkflowItemID;

                    itemIDs.Add(docID);
                }
            }
        }
        private void customScript1BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            InitializeItemIDs();
            ExecuteCustomScript1();
        }
        private void ExecuteCustomScript1()
        {
            try
            {
                this.Invoke(new Action(() => { LogEvent($"Executing custom script 1"); this.Refresh(); }));

                // Execute as task
                var task = chrome.EvaluateScriptAsync(customScript1);

                // Wait for task to complete
                task.Wait();

                // Evaluate
                var response = task.Result;

                if (response.Success)
                {
                    this.Invoke(new Action(() => { LogEvent($"Script executed successfully\r\n\r\n", 1); this.Refresh(); }));
                }
                else
                {
                    this.Invoke(new Action(() => { LogEvent($"Script failed\r\n\r\n", 1); this.Refresh(); }));
                }
            }

            catch (Exception m)
            {
                this.Invoke(new Action(() => { LogEvent("--Process Failed--\r\n", 1); this.Refresh(); }));
                MessageBox.Show($"There was an error processing the request.\n\nReason: {m.Message}");
                return;
            }
        }
        private void customScript2BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            InitializeItemIDs();
            ExecuteCustomScript2();
        }
        private void ExecuteCustomScript2()
        {

        }
        private void customScript3BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            InitializeItemIDs();
            ExecuteCustomScript3();
        }
        private void ExecuteCustomScript3()
        {

        }
        private void customScriptBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                if (this.InvokeRequired) this.Invoke(new Action(() => { LogEvent("--Process failed--\r\n", 1); this.Refresh(); }));
                else { LogEvent("--Process Failed--\r\n", 1); this.Refresh(); }

                MessageBox.Show($"There was a problem executing the script.\n\nError message: {e.Error.Message}");
            }
        }
        #endregion

        // --- FORM CONTROLS --- //
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
        private void homePageBtn_Click(object sender, EventArgs e)
        {
            navigationComboBox.Text = homeURI;
            chrome.Load(homeURI);
        }
        //
        // Will not work unless user has configured their credentials
        private void authenticateBtn_Click(object sender, EventArgs e)
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
        }
        private void openCertificate_Click(object sender, EventArgs e)
        {
            if(certificatesDataSource==null||certificatesDataSource.Count==0)
            {
                SetStatusLbl("Certificates cannot be searched because the certificate datasource is unavailable");
                System.Media.SystemSounds.Hand.Play();
                return;
            }

            //certInputContextMenuTbx.Clear();
            certInputContextMenuStrip.Show(openCertificateBtn, new Point(-1, openCertificateBtn.Height));
            certInputContextMenuTbx.Focus();
            certInputContextMenuTbx.SelectAll();
        }
        private void inputContextMenuTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    certInputContextMenuTbx.SelectAll();
                    string certNameToSearch = this.certInputContextMenuTbx.Text;

                    // generate uri
                    Certificate cert = certificatesDataSource.Where(i => i.CertificateName.EndsWith(certNameToSearch) || certNameToSearch.EndsWith(i.CertificateName)).FirstOrDefault() as Certificate;
                    string certBCSID = cert.BcsCertificateID;
                    string companyBCSID = cert.BcsCompanyID;
                    string certURI = $"https://www.bcscertus.com/managecertificate.aspx?c={clientID}&co={companyBCSID}&ct={certBCSID}";

                    UseWaitCursor = true;

                    // launch
                    navigationComboBox.Text = certURI;
                    chrome.Load(certURI);
                    certInputContextMenuStrip.Close();
                }
                catch (Exception)
                {
                    statusLbl.Text = "Could not navigate to the certificate";
                }

                UseWaitCursor = false;
            }
        }
        private void openCompanyBtn_Click(object sender, EventArgs e)
        {
            if (companiesDataSource == null || companiesDataSource.Count == 0)
            {
                SetStatusLbl("Companies cannot be searched because the company datasource is unavailable");
                System.Media.SystemSounds.Hand.Play();
                return;
            }

            //companyInputContextMenuStripTbx.Clear();
            companyInputContextMenuStrip.Show(openCompanyBtn, new Point(-1, openCertificateBtn.Height));
            companyInputContextMenuStripTbx.Focus();
            companyInputContextMenuStripTbx.SelectAll();
        }
        private void companyInputContextMenuTbx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    companyInputContextMenuStripTbx.SelectAll();
                    string companyNameToSearch = companyInputContextMenuStripTbx.Text;

                    // generate uri
                    Company co = companiesDataSource.Where(i => i.CompanyName.ToLower() == companyNameToSearch.ToLower()).FirstOrDefault() as Company;
                    string coBCSID = co.BcsCompanyID;
                    string coURI = $"https://www.bcscertus.com/managecompanydetail.aspx?c={clientID}&co={coBCSID}";

                    UseWaitCursor = true;

                    // launch
                    navigationComboBox.Text = coURI;
                    chrome.Load(coURI);
                    companyInputContextMenuStrip.Close();
                }
                catch (Exception)
                {
                    statusLbl.Text = "Could not navigate to the company";
                }

                UseWaitCursor = false;
            }
        }
        //
        // Used for testing a particular feature on the form
        private void testBtn_Click(object sender, EventArgs e)
        {
            // test

            chrome.EvaluateScriptAsync("alert('Why hello there. This is a test');");
            LogEvent("Hello. This is also a test");
            LogEvent("More tests... 1", 1);
            LogEvent("More tests... 2", 2);
            LogEvent("More tests... 3", 3);
        }
        //
        // Scripting options
        //
        private void viewItemsBtn_Click(object sender, EventArgs e)
        {
            //
        }
        private void completeItemsScriptBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!completeItemsBackgroundWorker.IsBusy && !distributeItemsBackgroundWorker.IsBusy) completeItemsBackgroundWorker.RunWorkerAsync();
                else if (completeItemsBackgroundWorker.IsBusy)
                {
                    DialogResult dr = MessageBox.Show("The process is currently running. Cancel?", "Warning", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes) completeItemsBackgroundWorker.CancelAsync();
                }
                else if (distributeItemsBackgroundWorker.IsBusy)
                {
                    DialogResult dr = MessageBox.Show("Item Distribution process is currently running. Do you want to cancel that process?", "Warning", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes) completeItemsBackgroundWorker.CancelAsync();
                }
            }
            catch (ThreadStartException tSE) { MessageBox.Show(tSE.Message); }
            catch (ThreadAbortException tAE) { MessageBox.Show(tAE.Message); }
            catch (Exception e1) { MessageBox.Show("Something went wrong"); }
        }
        private void distributeItemsScriptBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!completeItemsBackgroundWorker.IsBusy && !distributeItemsBackgroundWorker.IsBusy) distributeItemsBackgroundWorker.RunWorkerAsync();
                else if (distributeItemsBackgroundWorker.IsBusy)
                {
                    DialogResult dr = MessageBox.Show("The process is currently running. Cancel?", "Warning", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes) distributeItemsBackgroundWorker.CancelAsync();
                }
                else if (completeItemsBackgroundWorker.IsBusy)
                {
                    DialogResult dr = MessageBox.Show("Item Completion process is currently running. Do you want to cancel that process??", "Warning", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes) completeItemsBackgroundWorker.CancelAsync();
                }
            }
            catch (ThreadStartException tSE) { MessageBox.Show(tSE.Message); }
            catch (ThreadAbortException tAE) { MessageBox.Show(tAE.Message); }
            catch (Exception e1) { MessageBox.Show("Something went wrong"); }
        }
        private void customScript1Btn_Click(object sender, EventArgs e) //*
        {
            customScript1BackgroundWorker.RunWorkerAsync();
        }
        private void customScript2Btn_Click(object sender, EventArgs e) //*
        {
            customScript2BackgroundWorker.RunWorkerAsync();
        }
        private void customScript3Btn_Click(object sender, EventArgs e) //*
        {
            customScript3BackgroundWorker.RunWorkerAsync();
        }
        //
        // Used to cancel the preconfigured running scripts (comp & dist)
        private void cancelProcessBtn_Click(object sender, EventArgs e) //-
        {
            if (distributeItemsBackgroundWorker.IsBusy)
            {
                DialogResult dr = MessageBox.Show("Cancel distributing items?", "Warning", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes) distributeItemsBackgroundWorker.CancelAsync();
            }
            else if (completeItemsBackgroundWorker.IsBusy)
            {
                DialogResult dr = MessageBox.Show("Cancel completing items?", "Warning", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes) completeItemsBackgroundWorker.CancelAsync();
            }
            else MessageBox.Show("No process is currently running.");
        }
        //
        // Browser menu options
        private void menuBtn_MouseDown(object sender, MouseEventArgs e)
        {
            browserSettingsContextMenuStrip.Show(menuBtn, new Point(-145, menuBtn.Height + 6));
        }
        private void browserSettingsContextMenuStrip_Opened(object sender, EventArgs e)
        {
            menuBtn.BackColor = Color.FromArgb(64, 64, 64);
            //menuBtn.FlatAppearance.MouseDownBackColor = Color.FromArgb(27, 27, 27);
        }
        private void browserSettingsContextMenuStrip_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            menuBtn.BackColor = Color.FromArgb(27, 27, 27);
            //menuBtn.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 64, 64);
        }
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            configForm = new BrowserConfigForm();
            DialogResult dr = configForm.ShowDialog();
        }
        private void showConsoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // entering full view
            if (!panelVisible)
            {
                panelVisible = true;

                splitContainer1.Panel2Collapsed = false;
                splitContainer1.SplitterDistance = this.ClientSize.Width - 225;
            }
            else
            {
                panelVisible = false;

                splitContainer1.Panel2Collapsed = true;
            }
        }
        //
        // Console options
        private void clearLogBtn_Click(object sender, EventArgs e)
        {
            outputTbx.Clear();
        }
        private void copyLogBtn_Click(object sender, EventArgs e)
        {
            string s = "";

            s = outputTbx.Text;

            if (s != String.Empty) Clipboard.SetText(s);
        }
        #endregion Form Controls

        // --- OTHER --- //
        #region Other
        private void SetCredentials()
        {
            //userName = "cfitzpatrick@bcsops.com";
            //passWord = "Monday1!";
        }
        private void navigationComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                chrome.Load(navigationComboBox.Text);
            }
        }
        //
        // Handler to keep the status lbl hidden when there is no
        // text
        private void statusLbl_TextChanged(object sender, EventArgs e)
        {
            if (statusLbl.Text == null || statusLbl.Text == String.Empty) statusLbl.Visible = false;
            else statusLbl.Visible = true;
        }
        //
        // Method to manually set the status label of the browser
        // (same label used to show DOM status changes so beware
        // when moving the mouse and a label change occurs
        private void SetStatusLbl(string message)
        {
            this.statusLbl.Text = message;
            this.statusLblTimer.Enabled = true;
        }
        private void statusLblTimer_Tick(object sender, EventArgs e)
        {
            this.statusLbl.Text = String.Empty;
            this.statusLblTimer.Enabled = false;
        }
        //
        // This handler is required otherwise the browser will not
        // shutdown properly
        private void BetterBrowser_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }
        #endregion Other
    }
}
