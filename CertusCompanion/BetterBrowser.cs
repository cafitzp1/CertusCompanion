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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CertusCompanion
{
    public partial class BetterBrowser : Form
    {
        // --- BROWSER STARTUP --- //
        #region Browser Startup

        #region Data Instantiation

        ChromiumWebBrowser chrome;
        List<WorkflowItem> itemList1;
        List<WorkflowItem> itemList2;
        List<WorkflowItem> itemList3;

        Dictionary<string, string> itemIDsAndAssignmentIDsDict;
        Dictionary<string, string> currentDict;
        List<Dictionary<string, string>> subItemIDsAndAssignmentIDsDictList;

        string currentUserIDToAssign;
        string currentStatusIDToAssign;
        string url;
        string userName;
        string passWord;
        string logMessage;
        string consoleMessage;
        string consoleInstruction;
        string outputMessage;
        string messageTag;
        string trackTag;
        string script;
        const string IDHARDCODED = "2"; // change ID here if necessary (1-ER, 2-DA, 3-CA, 4-C, 5-T)

        int widthWhenPanelVisible;
        int itemsChecked;
        int itemsToAssign;
        int dictCount;
        int allAssignedItems;
        int counter4;
        int counter5;

        bool waitingForConsoleMessage;
        bool consoleInstructionReceived;
        bool continueProcess;
        bool userComplete;
        bool processComplete;
        bool abortProcess;
        bool panelVisible;
        bool waitingForConsoleInstruction;

        #endregion

        public BetterBrowser()
        {
            InitializeComponent();
        }

        public BetterBrowser(List<WorkflowItem> itemList1)
        {
            InitializeComponent();

            this.itemList1 = itemList1;
        }

        public BetterBrowser(List<WorkflowItem> itemList1, List<WorkflowItem> itemList2)
        {
            InitializeComponent();

            this.itemList1 = itemList1;
            this.itemList2 = itemList2;
        }

        public BetterBrowser(List<WorkflowItem> itemList1, List<WorkflowItem> itemList2, List<WorkflowItem> itemList3)
        {
            InitializeComponent();

            this.itemList1 = itemList1;
            this.itemList2 = itemList2;
            this.itemList3 = itemList3;
        }

        private void BetterBrowser_Load(object sender, EventArgs e)
        {
            CefSettings settings = new CefSettings();

            Cef.Initialize(settings);

            url = "https://www.bcscertus.com/sign-in.aspx?returnURL=%2fworkflow.aspx%3fc%3d36";
            chrome = new ChromiumWebBrowser(url);
            this.browserPanel.Controls.Add(chrome);
            chrome.Dock = DockStyle.Fill;
            panelVisible = false;
            widthWhenPanelVisible = this.ClientSize.Width - 200;

            // register events
            navigationComboBox.KeyDown += navigationComboBox_KeyDown;
            chrome.AddressChanged += Chrome_AddressChanged;
            chrome.StatusMessage += Chrome_StatusMessage;
            chrome.ConsoleMessage += Chrome_ConsoleMessage;
            chrome.LoadingStateChanged += Chrome_LoadingStateChanged;
            chrome.FrameLoadEnd += Chrome_FrameLoadEnd;
        }

        #endregion Browser Startup

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
                                allAssignedItems += itemsChecked;
                                counter4 += itemsChecked;
                            }
                            catch (Exception) { itemsChecked = -1; }
                        }
                    }
                    break;
            }
        }

        private void Chrome_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            //if (!e.IsLoading)
            //{
            //    waitingForPageToLoad = false;
            //}
        }

        private void Chrome_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            //if (e.Frame.IsMain)
            //{
            //    waitingForPageToLoad = false;
            //}
        }

        #endregion Event Handlers

        // --- METHODS --- //
        #region Methods

        private void ClearConsoleInstruction()
        {
            consoleInstructionReceived = false;
            consoleInstruction = String.Empty;
            outputMessage = String.Empty;
            consoleMessage = String.Empty;
            messageTag = String.Empty;
            //itemsChecked = 0;
        }

        private void WaitForConsoleInstruction()
        {
            bool abort = false;
            bool kill = false;
            int attempts = 0;
            int messages = 0;

            while (!consoleInstructionReceived && !abort && !kill) // this is set to true when console instruction message is received
            {
                if(distributeItemsBackgroundWorker.CancellationPending)
                {
                    kill = true;
                    continue;
                }

                ++attempts;
                if (attempts % 100 == 0) //10 seconds worth of attempts
                {
                    ++messages;
                    if (messages > 5) abort = true;
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

        #region Distribute Items Process

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

        private void DistributeProcessController(int i)
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

            //try
            //{
                #region Initiate Item Distribution
                this.Invoke(new Action(() => { LogEvent("Initiating Item Distribution process...\r\n",1); this.Refresh(); }));

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
                    this.Invoke(new Action(() => { LogEvent("--Process Failed--\r\n",1); this.Refresh(); }));
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
                    this.Invoke(new Action(() => { LogEvent("--Process Failed--\r\n",1); this.Refresh(); }));
                    MessageBox.Show("There was an error processing the request. Could not set items and assigned IDs lists.");
                    return;
                }
                #endregion

                foreach (var dict in subItemIDsAndAssignmentIDsDictList)
                {
                    #region Log Assignment Information
                    currentDict = dict;
                    currentUserIDToAssign = dict.Values.FirstOrDefault();
                    currentStatusIDToAssign = IDHARDCODED;
                    itemsToAssign = dict.Count;
                    ++dictCount;
                    counter4 = 0;

                    this.Invoke(new Action(() => { LogEvent($"User {currentUserIDToAssign} ({dictCount}/{subItemIDsAndAssignmentIDsDictList.Count}) | Item(s) assigned: {allAssignedItems}/{itemList1.Count}\r\n{itemsToAssign} items(s) to assign statusID: {currentStatusIDToAssign}\r\n"); this.Refresh(); }));
                    #endregion

                    DistributeProcessController(1);
                }

                #region Conclude Item Distribution

                this.Invoke(new Action(() => { LogEvent($"Item Distribution Complete\r\n\r\n{allAssignedItems}/{itemIDsAndAssignmentIDsDict.Count} items assigned to {subItemIDsAndAssignmentIDsDictList.Count} user(s)",1); this.Refresh(); }));

                #endregion
            //}
            //catch (Exception e)
            //{
            //    this.Invoke(new Action(() => { LogEvent("--Process Failed--\r\n",1); this.Refresh(); }));

            //    MessageBox.Show(e.Message, "Error");
            //}
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

                    DistributeProcessController(2);
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
                        "function transferarray() { " +
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
                        "myData = transferarray(); ";
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

                    DistributeProcessController(3);
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
                    //"document.getElementById('ctl00_cphPopups_m_WorkflowBulkSaveBTN').click(); " +
                    "document.getElementById('ctl00_cphPopups_m_WorkflowBulkCancelBTN').click(); " + // cancel button (for debugging)

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

                    DistributeProcessController(4);
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

                    DistributeProcessController(2);
                }
                else if (consoleInstruction == "complete")
                {
                    this.Invoke(new Action(() => { LogEvent("No more pages"); this.Refresh(); }));
                    this.Invoke(new Action(() => { LogEvent($"--User {currentUserIDToAssign} assignment complete--\r\n{counter4}/{currentDict.Count} assigned as statusID: {currentStatusIDToAssign}\r\n"); this.Refresh(); }));
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

        #endregion Distribute Items Process

        private void LogEvent(string message, int newLines = 0)
        {
            for (int i = 0; i < newLines; i++)
            {
                outputTbx.Text += "\r\n";
            }

            outputTbx.Text += "> " + message + "\r\n";

            if(outputTbx.Text.Length > 0) outputTbx.SelectionStart = outputTbx.Text.Length - 1;

            outputTbx.ScrollToCaret();
        }

        #endregion Methods

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

        private void button0_Click(object sender, EventArgs e)
        {
            chrome.Load(url);
        }

        private void SetCredentials()
        {
            userName = "cfitzpatrick@bcsops.com";
            passWord = "Monday1!";
        }

        private void button1_Click(object sender, EventArgs e) // sign in 
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

        private void button2_Click(object sender, EventArgs e) // action 1
        {
            // test

            chrome.EvaluateScriptAsync("alert('Why hello there. This is a test');");
            LogEvent("Hello. This is also a test");
            LogEvent("More tests... 1", 1);
            LogEvent("More tests... 2", 2);
            LogEvent("More tests... 3", 3);
        }

        private void button3_Click(object sender, EventArgs e) // action 2
        {
            //DistributeItems();

            try
            {
                if (!distributeItemsBackgroundWorker.IsBusy) distributeItemsBackgroundWorker.RunWorkerAsync();
                else
                {
                    DialogResult dr = MessageBox.Show("The process is already running. Cancel?", "Warning", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes) distributeItemsBackgroundWorker.CancelAsync();
                }
            }
            catch (ThreadStartException tSE) { MessageBox.Show(tSE.Message);  }
            catch (ThreadAbortException tAE) { MessageBox.Show(tAE.Message); }
            catch (Exception e1) { MessageBox.Show("Something went wrong"); }
        }

        private void button4_Click(object sender, EventArgs e) // action 3
        {
            DialogResult dr = MessageBox.Show("The process is currently running. Cancel?", "Warning", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes) distributeItemsBackgroundWorker.CancelAsync();
        }

        private void button5_Click(object sender, EventArgs e) // action 4
        {

        }

        private void button6_Click(object sender, EventArgs e) // action 5
        {

        }

        private void showPanelBtn_Click(object sender, EventArgs e)
        {
            // entering full view
            if (!panelVisible)
            {
                panelVisible = true;

                // change appearance of button 
                showPanelBtn.BackColor = Color.FromName("Highlight");

                //this.browserPanelContainer.Width = widthWhenPanelVisible;
                splitContainer1.Panel2Collapsed = false;
            }
            else
            {
                panelVisible = false;

                // change appearance of button 
                showPanelBtn.BackColor = Color.FromArgb(20, 20, 20);

                //this.browserPanelContainer.Width = this.ClientSize.Width;
                splitContainer1.Panel2Collapsed = true;
            }
        }

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

        private void BetterBrowser_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }

        #endregion Other
    }
}
