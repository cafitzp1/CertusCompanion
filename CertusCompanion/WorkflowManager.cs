//Certus Companion v3

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic.Devices;
using System.Net.Http.Headers;
using System.Data.SqlClient;

namespace CertusCompanion
{
    public partial class WorkflowManager : Form
    {
        // ----- DATA DECLARATIONS ----- //
        #region Data Declaration

        // Instances
        internal WorkflowItemDatabase WorkflowItemDatabase { get; set; }
        internal AppSave AppSave { get; set; }
        internal AppData AppData { get; set; }
        internal ItemImports ItemImportsList { get; set; }
        internal ItemsCompletedReports ItemsCompletedReportsList { get; set; }
        internal List<WorkflowItemCSVImport> AllItemImportsLoaded { get; set; }
        internal List<ItemsCompletedReport> AllItemsCompletedReportsLoaded { get; set; }
        internal WorkflowItemCSVImport CurrentImport { get; set; }
        internal Filter CurrentFilter { get; set; }
        internal WorkflowItemCSVImport SelectedImport { get; set; }
        internal ItemsCompletedReport SelectedReport { get; set; }
        internal NoteForm Note { get; set; }
        internal Form TransparentForm { get; set; }
        internal ItemsView ItemViewForm { get; set; }
        internal FiltersForm FilterForm { get; set; }
        internal WorkflowItem SelectedWorkflowItem { get; set; }
        internal ListViewItem PreviousItem { get; set; }
        internal BetterBrowser BetterBrowser { get; set; }
        internal ThemeColors ThemeColors { get; set; }
        internal MyRenderer CustomRenderer { get; set; }
        internal LoadingForm LoadingForm { get; set; }
        internal ModifyForm ModifyForm { get; set; }
        internal ImportFromDatabaseForm ImportFromDBForm { get; set; }
        internal BrowserForm CertusBrowser { get; set; }
        internal WorkflowItemCSVImport CurrentWorkflowItemCSVImport { get; set; }
        internal ItemsCompletedReport CurrentCompletedReport { get; set; }

        // Lists
        internal List<WorkflowItem> AllWorkflowItemsLoaded { get; set; }
        internal List<WorkflowItem> CurrentWorkflowItems { get; set; }
        internal List<WorkflowItem> SearchResultsList { get; set; }
        internal List<WorkflowItem> TemporaryExportList { get; set; }
        internal List<Certificate> AllCertificatesLoaded { get; set; }
        internal List<Company> AllCompaniesLoaded { get; set; }
        private List<WorkflowItem> uniqueWorkflowItems;
        private List<WorkflowItem> workflowItemListPopulated;
        private List<WorkflowItem> imageWorkflowItems;
        private List<WorkflowItem> requirementWorkflowItems;
        private List<WorkflowItem> dupsAndOriginals;
        private List<WorkflowItem> filteredWfItems;
        private List<WorkflowItem> originalItems;
        private List<WorkflowItem> dupItems;
        private List<WorkflowItem> queriedItemList;
        private List<ListViewItem> allLvWorkflowItems;
        private List<ListViewItem> filteredLvWorkflowItems;
        private List<ListViewItem> dupCertLvItems;
        private List<ListViewItem> dupCertOriginalLvItems;
        private List<ListViewItem> lvItemsShowing;
        private List<WorkflowItem> currentWorkflowItems;
        private List<WorkflowItem> temporaryExportList;
        private List<ItemsCompletedReport> allItemsCompletedReportsLoaded;
        private List<string> excludedItems;
        private List<string> companiesWhichHadDifferentAnalysts;
        
        // Dictionaries
        private Dictionary<string, Company> companyDictionary;
        private Dictionary<string, string> companyNameDictionary;
        private Dictionary<string, List<Contact>> companyContactDictionary;
        private Dictionary<string, Color> itemGroupsSortedColors;
        private Dictionary<string, string> marketAssignments;
        private Dictionary<string, WorkflowItem> workflowItemDictionary;
        private Dictionary<string, string> systemUserIDsDictionary;
        private Dictionary<string, Certificate> certificateDictionary;

        // Objects
        private Color currentColor;
        private SolidBrush spaceDarkBrush;
        private SolidBrush spaceLightBrush;
        private SolidBrush spaceLightOffBrush;
        private Panel selectedPanel;
        private ListViewItem listViewItemCheckedChanging;
        private ListViewHitTestInfo hoverItem;
        private ListViewHitTestInfo clickedItem;
        private Color colorDialogSelection;
        private Button[] itemButtons;
        private Panel[] detailPanels;
        private Button[] focusDetailPanelBtns;
        private ListViewItem lastCheckedItem;
        private ListViewItem shiftItemBeingChecked;
        private ListViewColumnSorter lvwColumnSorter;

        // Variables
        private string previousEmailDate;
        private string previousSender;
        private string searchVal;
        private string previousSearch;
        private string bindedColor1 = "Default";
        private string bindedColor2 = "Gray";
        private string bindedColor3 = "Teal";
        private string bindedColor4 = "Blue";
        private string bindedColor5 = "Black";
        private string excludedItemsFileName;
        private string importFileName = "";
        private string selectSelection = "";
        private string fromSelection = "";
        private string whereSelection = "";
        private const int tab_margin = 3;
        private int currentSplitter1Distance = 0;
        private int splitContainerChild1Panel2MinSize;
        private int itemsInfoAppended;
        private int nextAvailableButton = 1;
        private int itemsWithNoCompany;
        private int itemsWhereCompanyNotRecognized;
        private int itemsWhereCompanyHadDifferentAnalysts;
        private int itemsWhereCompanyHadNoAnalyst;
        private int itemsAlreadyCorrectlyAssigned;
        private int itemsWhereCompanyHadDifferentMarkets;
        private int itemsSuccessfullyAssigned;
        private int itemsWhereMarketNotFound;
        private int itemsWithNoCertificate;
        private int itemsWhereContractUnrecognized;
        private int searchIndex;
        private int itemsUpdated;
        private int itemsUpToDate;
        private int contractsPulled;
        private int detailNotificationPanelTop;
        private int detailNotificationPanelLeft;
        private int countOfListViewItems;
        private int importFilesSelected = 0;
        private int importFileBeingWorkedOn = 0;
        private bool fullView = false;
        private bool itemCheckedEventIgnored;
        private bool selectedIndexChangedEventIgnored;
        private bool ignoreThisSaveBtnTabPress;
        private bool ignoreThisSelectedIndexChanged = false;
        private bool showExcludedItems = false;
        private bool matchSearchResultsCase = false;
        private bool connectedToCertus = false;
        private bool tabWasPressed;
        private bool checkedItemsAreFocused;
        private bool itemsCouldNotBeAppended;
        private bool contrastItemGroups = false;
        private bool showItemsWithColor = false;
        private bool itemDetailsChanged = false;
        private bool tabWasPressedOnSaveBtn;
        private bool enterWasPressedOnSaveBtn;
        private bool lockListViewColumnSizing;

        #endregion Data Declaration

        // ----- APPLICATION STARTUP ----- //
        #region Application Startup

        internal WorkflowManager()
        {
            InitializeComponent();

            LoadForm();
            LoadSupplementalData();
        }

        internal WorkflowManager(AppData appData)
        {
            // if ever loading from a main screen use this constructor

            //InitializeComponent();

            //// save contents of appData for this form
            //StoreAppDataToForm(appData);

            //LoadForm();

            //ResizeControls();

            //// populate data
            //PopulateListViewData(AllWorkflowItemsLoaded);
        }

        public void ResizeControls()
        {
            // Form resize
            this.Size = new Size(1280, 720);

            // Panels resize
            this.splitContainerParent.Size = this.ClientSize;
            this.splitContainerParent.Height = this.Height - 60;
            this.splitContainerChild1.Panel1MinSize = 150;
            this.splitContainerChild1.Panel2MinSize = 440;
            this.splitContainerChild1Panel2MinSize = this.splitContainerChild1.Panel2MinSize;
            this.splitContainerChild1.Width = this.splitContainerParent.Width;
            this.splitContainerChild1.Height = this.splitContainerParent.Height;
            this.splitContainerChild2.Panel1MinSize = 650; //300
            this.splitContainerChild2.Panel2MinSize = 604;
            this.splitContainerChild2.Width = this.splitContainerChild1.Width;
            this.splitContainerChild2.Height = this.splitContainerChild1.Height - this.splitContainerChild1.Panel1.Height;
            this.splitContainerChild2.SplitterDistance = this.splitContainerChild1.Width - this.splitContainerChild1.Panel2MinSize;
            this.splitContainerChild3.Panel1MinSize = 300;
            this.splitContainerChild3.Panel2MinSize = 300;
            this.splitContainerChild3.Width = this.splitContainerChild1.Width - this.splitContainerChild2.Panel1.Width;
            this.splitContainerChild3.Height = this.splitContainerChild2.Height;
            this.queryPanel.Width = this.importPanel.Width;
            this.queryPanel.Height = this.importPanel.Height;
            this.splitContainerChild3.SplitterDistance = 300;

            // Controls resize - Control size/location followed by margin
            this.searchPanel.Left = this.splitContainerChild1.Width - 175;
            this.matchCaseBtn.Left = this.searchPanel.Left - 26;
            this.matchCaseBtn.Top = this.searchPanel.Top;
            this.matchCaseBtn.Height = this.searchPanel.Height;
            this.workflowItemsListView.Width = this.splitContainerChild1.Width - 18;
            this.workflowItemsListView.Height = this.splitContainerChild1.Panel1.Height - 35;
            this.copyIdsBtn.Left = this.splitContainerChild2.SplitterDistance - (18 + 13);
            this.detailsOptionsPanel2.Left = this.copyIdsBtn.Left - (this.detailsOptionsPanel2.Width + 8);
            this.itemDetailsPanel.Width = this.copyIdsBtn.Right;
            this.previewQueryComboBox.Left = this.splitContainerChild3.SplitterDistance - (70 + 28);
            this.previewQueryComboBox.Top -= 2;
            this.previewDescLbl.Left = this.previewQueryComboBox.Left - (this.previewDescLbl.Width + 3);
            this.importsDataViewBtn.Visible = true;
            this.importsDataViewBtn.Left = this.importPanel.Left + 7;
            this.queriedItemsListbox.Size = new Size(this.itemImportsLbx.Width, this.itemImportsLbx.Height);
            this.viewQueryBtn.Visible = true;
            this.viewQueryBtn.Left = this.queryPanel.Width - (50 + 8);
            this.viewQueryBtn.Top = this.queryPanel.Bottom - (18 + 34);
            this.clearQueryOptionsBtn.Left = this.viewQueryBtn.Left - (50 + 8);
            this.clearQueryOptionsBtn.Top = this.viewQueryBtn.Top;
            this.detailsSaveBtn.Top = this.viewQueryBtn.Top;
            this.toolStripStatusLabel.Width = this.Width - 755;

            // anchor subpanels
            this.itemDetailsPanel.Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom);
            this.queryPanel.Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom);
            this.importPanel.Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom);
        }

        public void LoadForm()
        {
            PreviousItem = new ListViewItem();
            lvwColumnSorter = new ListViewColumnSorter();
            filteredWfItems = new List<WorkflowItem>();
            allLvWorkflowItems = new List<ListViewItem>();
            filteredLvWorkflowItems = new List<ListViewItem>();
            dupItems = new List<WorkflowItem>();
            originalItems = new List<WorkflowItem>();
            dupsAndOriginals = new List<WorkflowItem>();
            dupCertLvItems = new List<ListViewItem>();
            dupCertOriginalLvItems = new List<ListViewItem>();
            lvItemsShowing = new List<ListViewItem>();
            AllWorkflowItemsLoaded = new List<WorkflowItem>();
            AllItemImportsLoaded = new List<WorkflowItemCSVImport>();
            AllItemsCompletedReportsLoaded = new List<ItemsCompletedReport>();
            CurrentWorkflowItems = new List<WorkflowItem>();
            TemporaryExportList = new List<WorkflowItem>();
            SearchResultsList = new List<WorkflowItem>();
            workflowItemDictionary = new Dictionary<string, WorkflowItem>();
            workflowItemsListView.ListViewItemSorter = lvwColumnSorter;

            itemButtons = new Button[]
            {
                itemButton0, itemButton1, itemButton2, itemButton3, itemButton4, itemButton5,
                itemButton6, itemButton7, itemButton8, itemButton9, itemButton10
            };

            detailPanels = new Panel[]
            {
                detailPanel1, detailPanel2, detailPanel3, detailPanel4, detailPanel5,
                detailPanel6, detailPanel7, detailPanel8, detailPanel9, detailPanel10,
                detailPanel11, detailPanel12, detailPanel13, detailPanel14, detailPanel15,
                detailPanel16, detailPanel17, detailPanel18
            };

            focusDetailPanelBtns = new Button[]
            {
                focusDetailPanelBtn1, focusDetailPanelBtn2, focusDetailPanelBtn3, focusDetailPanelBtn4,
                focusDetailPanelBtn5, focusDetailPanelBtn6, focusDetailPanelBtn7, focusDetailPanelBtn8,
                focusDetailPanelBtn9, focusDetailPanelBtn10, focusDetailPanelBtn11, focusDetailPanelBtn12,
                focusDetailPanelBtn13, focusDetailPanelBtn14, focusDetailPanelBtn15, focusDetailPanelBtn16,
                focusDetailPanelBtn17, focusDetailPanelBtn18
            };

            // enable controls
            viewChoiceComboBox.Enabled = true;
            fullViewBtn.Enabled = true;
            //enlargeBtn.Enabled = true;
            collapseToolPanelsBtn.Enabled = true;

            // move/resize
            detailNotificationPanelTop = detailNotificationsPanel.Top;
            detailNotificationPanelLeft = detailNotificationsPanel.Left;

            // invoke a resize for the column header alignment
            this.WorkflowManager_Resize(this, null);

            //instantiate graphics variables
            ThemeColors = new ThemeColors();
            spaceDarkBrush = new SolidBrush(ThemeColors.SpaceDark);
            spaceLightBrush = new SolidBrush(ThemeColors.SpaceLight);
            spaceLightOffBrush = new SolidBrush(ThemeColors.SpaceLightOff);
            workflowItemsListView.ForeColor = ThemeColors.ItemDefault;

            // change context menu renderer
            CustomRenderer = new MyRenderer();
            this.listViewContextMenuStrip.Renderer = CustomRenderer;
            this.formMenuStrip.Renderer = CustomRenderer;
        }

        private void LoadSupplementalData()
        {
            LoadMarketAssignments();
            LoadUserIDs();
            InstantiateSupplementalDataSources();
        }

        private void LoadMarketAssignments()
        {
            marketAssignments = new Dictionary<string, string>();
            string path = @"\\Mac\Home\Documents\Work\Companion Supplemental Data\MarketAssignments.txt";
            string name = "";
            string market = "";

            try
            {
                List<string> marketAssignmentTxtFile = File.ReadAllLines(path).ToList();

                foreach (string s in marketAssignmentTxtFile)
                {
                    if (s == null || s == String.Empty) continue;
                    char c = s[0];

                    //if(s[0]!='<' && s[0] != null && s[0] != '-')
                    if (Char.IsLetter(c))
                    {
                        name = s;
                        continue;
                    }
                    else if (c == '-')
                    {
                        market = s.Substring(2);
                        marketAssignments.Add(market, name);
                        continue;
                    }
                }
            }
            catch (Exception)
            {
                SetStatusLabelAndTimer("Error loading Market Assignments");
            }
        }

        private void LoadUserIDs()
        {
            systemUserIDsDictionary = new Dictionary<string, string>();
            string path = @"\\Mac\Home\Documents\Work\Companion Supplemental Data\UserIDs.txt";

            try
            {
                List<string> contractCompanyIdsTxtFile = File.ReadAllLines(path).ToList();
                string userID = "";
                string userName = "";

                foreach (string s in contractCompanyIdsTxtFile)
                {
                    if (s == null || s == String.Empty) continue;

                    int dividerIndex = s.IndexOf('-');

                    userID = s.Substring(0, dividerIndex);
                    userName = s.Substring(dividerIndex + 1, (s.Length - dividerIndex) - 1);

                    if (!systemUserIDsDictionary.ContainsKey(userID)) systemUserIDsDictionary.Add(userID, userName);
                }
            }
            catch (Exception)
            {
                SetStatusLabelAndTimer("Error loading System User IDs");
            }
        }

        private void InstantiateSupplementalDataSources()
        {
            return;

            foreach (var keyValuePair in systemUserIDsDictionary)
            {
                //setAssignmentManualToolStripComboBox.Items.Add(keyValuePair.Value);
            }
        }

        public void EnableOptionsPanels()
        {
            listViewOptionsPanel.Enabled = true;
            detailsOptionsPanel.Enabled = true;
        }

        #endregion Application Startup

        // ----- TOOL STRIP MENU ----- //
        #region Tool Strip Menu 

        //File
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog.FileName = "";
                openFileDialog.Filter = "App Data Files (*.dat)|*.dat|All Files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;

                DialogResult dialogResult = openFileDialog.ShowDialog();

                if (dialogResult == DialogResult.OK)
                {
                    //LoadAppData(openFileDialog.FileName); 
                    loadBackgroundWorker.RunWorkerAsync(openFileDialog.FileName);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Could not process the request", "Error");
                return;
            }

            //PopulateListViewData(this.AllWorkflowItemsLoaded);

            //PopulateImportLbx(this.AllItemImportsLoaded);

            //PopulateCompletedReportsLbx(this.AllItemsCompletedReportsLoaded);

            //SetStatusLabelAndTimer("Items loaded successfully");

            //Cursor.Current = Cursors.Default;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = $"Workflow Data - ({DateTime.Now.ToString("MM'-'dd'-'yyyy")})";
            saveFileDialog.Filter = "App Data Files (*.dat)|*.dat|All Files (*.*)|*.*";

            DialogResult dialogResult = saveFileDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                UseWaitCursor = true;
                saveBackgroundWorker.RunWorkerAsync(saveFileDialog);
            }
        }

        // Edit
        private void removeAllPaintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            // set colors back to how they started
            foreach (WorkflowItem dbItem in AllWorkflowItemsLoaded)
            {
                dbItem.DisplayColor = "Default";
            }

            SetColorButtonsBackToDefault();

            // filter option gets unselected
            filterBtn.BackColor = Color.FromArgb(20, 20, 20);
            //filterListView = false;

            // item button back to default
            itemButton0.ForeColor = Color.FromName("Default");

            // repopulate lv
            PopulateListViewData(DetermineWorkflowItemListToShowOnListView());

            Cursor.Current = Cursors.Default;

            // notify
            SetStatusLabelAndTimer("All paint removed");
        }

        private void markCompletedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            this.workflowItemsListView.BeginUpdate();

            int itemsMarked = 0;
            List<WorkflowItem> itemsToMark = new List<WorkflowItem>();

            if (workflowItemsListView.CheckedIndices == null || workflowItemsListView.CheckedIndices.Count == 0)
            {
                SetStatusLabelAndTimer("Select items to mark first", 3000);
                MakeErrorSound();
                return;
            }

            // for each item checked
            foreach (ListViewItem lvItem in workflowItemsListView.CheckedItems)
            {
                WorkflowItem item = new WorkflowItem();

                // get item from lvItem
                item = GetWorkflowItemFromLvItem(lvItem);

                // count only if not the color
                if (item.Status != "Completed")
                {
                    ++itemsMarked;
                }

                // change dbItem
                item.Status = "Completed";
                item.WorkflowItemInformationDifferentThanCertus = true;
                item.DisplayColor = "SpringGreen";

                // add item to list
                itemsToMark.Add(item);
            }

            try
            {
                UpdateAllLoadedWorkflowItems(itemsToMark);

                // set non completed items list
                SetNonCompletedItemsList();
            }
            catch (Exception)
            {
                SetStatusLabelAndTimer("Could not update the items' status");
                MakeErrorSound();
            }

            //this.UncheckAllListViewItems();

            this.workflowItemsListView.EndUpdate();

            // refresh views
            this.refreshBtn.PerformClick();

            SetStatusLabelAndTimer($"{itemsMarked} items marked 'Completed'");

            Cursor.Current = Cursors.Default;
        }

        private void markTrashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            this.workflowItemsListView.BeginUpdate();

            int itemsMarked = 0;
            List<WorkflowItem> itemsToMark = new List<WorkflowItem>();

            if (workflowItemsListView.CheckedIndices == null || workflowItemsListView.CheckedIndices.Count == 0)
            {
                SetStatusLabelAndTimer("Select items to mark first", 3000);
                MakeErrorSound();
                return;
            }

            // for each item checked
            foreach (ListViewItem lvItem in workflowItemsListView.CheckedItems)
            {
                WorkflowItem item = new WorkflowItem();

                // get item from lvItem
                item = GetWorkflowItemFromLvItem(lvItem);

                // count only if not the color
                if (item.Status != "Trash") //
                {
                    ++itemsMarked;
                }

                // change dbItem status
                item.Status = "Trash";
                item.WorkflowItemInformationDifferentThanCertus = true;
                item.DisplayColor = "SpringGreen";

                // add item to itemsToPaint
                itemsToMark.Add(item);
            }

            try
            {
                UpdateAllLoadedWorkflowItems(itemsToMark);

                // set non completed items list
                SetNonCompletedItemsList();
            }
            catch (Exception)
            {
                SetStatusLabelAndTimer("Could not update the items' status", 3000);
                MakeErrorSound();
            }

            //this.UncheckAllListViewItems();

            this.workflowItemsListView.EndUpdate();

            // refresh views
            this.refreshBtn.PerformClick();

            SetStatusLabelAndTimer($"{itemsMarked} items marked 'Trash'"); //

            Cursor.Current = Cursors.Default;
        }

        // View
        private void excludedItemsViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (excludedItems == null || excludedItems.Count == 0)
            {
                SetStatusLabelAndTimer("You must import excluded items first", 5000);
                MakeErrorSound();
                return;
            }

            ItemViewForm = new ItemsView();

            // change for excluded items
            ItemViewForm.FormatForExcludedItemsView();

            // register event
            ItemViewForm.ChangeItemsColor += new ItemsColorUpdatedEventHandler(ItemsViewForm_SaveItemsColor);

            // get current list
            try
            {
                excludedItems = File.ReadAllLines(excludedItemsFileName).ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("Data loading was unsuccessful", "Error");
            }

            // pass items to view
            ItemViewForm.PopulateItems(workflowItemListPopulated, excludedItems);

            ShowAndFocusForm(ItemViewForm);

            Cursor.Current = Cursors.Default;
        }

        private void currentListViewItemsViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //itemViewForm = new ItemsView();
            //itemViewForm.Show();

            try
            {
                ItemViewForm = new ItemsView();

                // register event
                ItemViewForm.SaveItemsCompletedReportToFullForm += new ItemsStatusChangedEventHandler(ItemsViewForm_SaveCompletedReport);

                // pass items viewing
                ItemViewForm.PopulateItems(workflowItemListPopulated);

                ShowAndFocusForm(ItemViewForm);
            }
            catch (Exception)
            {
                SetStatusLabelAndTimer("Could not open form", 5000);
                MakeErrorSound();
            }

            Cursor.Current = Cursors.Default;
        }

        private void certificatesViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (AllCertificatesLoaded == null || AllCertificatesLoaded.Count == 0)
            {
                SetStatusLabelAndTimer("You must import certificates first", 5000);
                MakeErrorSound();
                return;
            }

            ItemViewForm = new ItemsView();

            ItemViewForm.FormatForCertificatesView();

            // pass items to view
            ItemViewForm.PopulateCertificates(AllCertificatesLoaded);

            // register event
            //itemViewForm.OpenCertificate += new OpenCertificateInBrowserEventHandler(ItemsViewForm_OpenCertificate);

            ShowAndFocusForm(ItemViewForm);

            Cursor.Current = Cursors.Default;
        }

        private void companiesViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (AllCompaniesLoaded == null || AllCompaniesLoaded.Count == 0)
            {
                SetStatusLabelAndTimer("You must import companies first", 5000);
                MakeErrorSound();
                return;
            }

            ItemViewForm = new ItemsView();

            ItemViewForm.FormatForCompaniesView();

            // pass items to view
            ItemViewForm.PopulateCompanies(AllCompaniesLoaded);

            // register event
            //itemViewForm.OpenCompany += new OpenCompanyInBrowserEventHandler(ItemsViewForm_OpenCompany);

            ShowAndFocusForm(ItemViewForm);

            Cursor.Current = Cursors.Default;
        }

        // Tools
        #region Certus Browser

        private void certusBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (workflowItemsListView.CheckedItems == null || workflowItemsListView.CheckedItems.Count == 0) this.BetterBrowser = new BetterBrowser();
            else
            {
                Application.UseWaitCursor = true;
                Application.DoEvents();
                UseWaitCursor = true;
                this.BetterBrowser = new BetterBrowser(GetWorkflowItemsFromChecked(workflowItemsListView));
            }
            this.BetterBrowser.Show();
            UseWaitCursor = false;
            Application.UseWaitCursor = false;
        }

        private void certusConnectionBtn_Click(object sender, EventArgs e)
        {
            UseWaitCursor = true;

            // turning on
            if (CheckIfFormIsOpened("BrowserForm"))
            {
                CertusBrowser.LogIn();
                certusConnectionBtn.Enabled = false;
            }
            else
            {
                UseWaitCursor = false;
                SetStatusLabelAndTimer("This feature only works if you have the certus browser open (Tools > Certus Browser)");
                TurnOffCertusConnectionBtn();
                MakeErrorSound();
            }

            // turning off
            // ...(user should not be allowed to change the button once signed in)
        }

        public void TurnOnCertusConnectionBtn()
        {
            //certusConnectionRadioButton.Checked = true;
            //isCertusRadioButtonChecked = false;

            certusConnectionBtn.BackgroundImage = CertusCompanion.Properties.Resources.icons8_connection_status_on_48;
            certusConnectionBtn.Enabled = false;
            certusConnectionTimer.Enabled = true;
            connectedToCertus = true;
        }

        public void TurnOffCertusConnectionBtn()
        {
            //certusConnectionRadioButton.Checked = false;

            certusConnectionBtn.BackgroundImage = CertusCompanion.Properties.Resources.icons8_connection_status_on_48__1_;
            certusConnectionBtn.Enabled = true;
            connectedToCertus = false;
        }

        private void certusConnectionTimer_Tick(object sender, EventArgs e)
        {
            TurnOffCertusConnectionBtn();
        }

        public void ResetCertusConnectionTimer()
        {
            certusConnectionTimer.Enabled = false;
            certusConnectionTimer.Enabled = true;
        }

        #endregion Certus Browser

        // Data
        private void importExcludedItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                excludedItems = new List<string>();
                excludedItemsFileName = "";

                openFileDialog.FileName = "";
                openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;

                DialogResult dialogResult = openFileDialog.ShowDialog();

                if (dialogResult == DialogResult.OK)
                {
                    excludedItemsFileName = openFileDialog.FileName;

                    excludedItems = File.ReadAllLines(excludedItemsFileName).ToList();

                    SetDatabaseDetailsProperties();
                    SetStatusLabelAndTimer("Data loaded successfully");
                }
                else return;
            }
            catch (Exception m)
            {
                MessageBox.Show(m.Message, "Error");
            }
        }

        private void importCertificatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.FileName = "";
            openFileDialog.Filter = "CSV Files (*.csv)|*.csv";
            openFileDialog.FilterIndex = 1;

            DialogResult dialogResult = openFileDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                UseWaitCursor = true;
                importCertificatesBackgroundWorker.RunWorkerAsync(openFileDialog);
            }
        }

        private void importCompaniesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.FileName = "";
            openFileDialog.Filter = "CSV Files (*.csv)|*.csv";
            openFileDialog.FilterIndex = 1;

            DialogResult dialogResult = openFileDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                UseWaitCursor = true;
                importCompaniesBackgroundWorker.RunWorkerAsync(openFileDialog);
            }
        }

        private void updateContractDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (workflowItemsListView.CheckedItems == null || workflowItemsListView.CheckedItems.Count == 0)
            {
                SetStatusLabelAndTimer("There need to be checked items for this function");
                MakeErrorSound();
                return;
            }

            if (certificateDictionary == null || certificateDictionary.Count == 0)
            {
                SetStatusLabelAndTimer("Certificates need to be imported for this function");
                MakeErrorSound();
                return;
            }

            UseWaitCursor = true;

            List<WorkflowItem> checkedItems = GetWorkflowItemsFromChecked(workflowItemsListView);
            updateContractInformationBackgroundWorker.RunWorkerAsync(checkedItems);
        }

        // Window
        private void minimizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void maximizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        // Admin
        private string ExtractViewState(string s)
        {
            string viewStateNameDelimiter = "__VIEWSTATE";
            string valueDelimiter = "value=\"";

            int viewStateNamePosition = s.IndexOf(viewStateNameDelimiter);
            int viewStateValuePosition = s.IndexOf(
                  valueDelimiter, viewStateNamePosition
               );

            int viewStateStartPosition = viewStateValuePosition +
                                         valueDelimiter.Length;
            int viewStateEndPosition = s.IndexOf("\"", viewStateStartPosition);

            return HttpUtility.UrlEncode(s.Substring(
                        viewStateStartPosition,
                        viewStateEndPosition - viewStateStartPosition
                     )
                  );
        }

        private void performAction1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //return;

            #region Close Transparent Form
            try
            {
                this.TransparentForm.Close();
            }
            catch (Exception)
            {
                SetStatusLabelAndTimer("That didn't work...");
                MakeErrorSound();
            }
            #endregion

            return;

            #region Edit ListView Items
            Application.UseWaitCursor = true;
            Application.DoEvents();

            List<WorkflowItem> checkedItems = GetWorkflowItemsFromChecked(workflowItemsListView);
            List<WorkflowItem> itemsToUpdate = new List<WorkflowItem>();

            foreach (WorkflowItem wi in checkedItems)
            {
                // item edit here

                if (wi.DisplayColor != "SpringGreen")
                {
                    wi.DisplayColor = "SpringGreen";
                    itemsToUpdate.Add(wi);

                    // colors - SpringGreen, Aquamarine, Default
                }
            }

            UpdateAllLoadedWorkflowItems(itemsToUpdate);

            SetStatusLabelAndTimer($"{itemsToUpdate.Count} items updated", true);

            Application.UseWaitCursor = false;
            #endregion
        }

        private void performAction2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region Generate Form
            DimForm();
            LoadingForm = new LoadingForm();
            List<string> options = new List<string>();
            LoadingForm.ChangeHeaderLabel("Assign");
            LoadingForm.ChangeLabel("Assign to user: ");
            // generate options from system users
            foreach (var keyValPair in systemUserIDsDictionary)
            {
                string s = $"{keyValPair.Value} <{keyValPair.Key}>";
                options.Add(s);
            }
            LoadingForm.FormatForDialog(options);
            DialogResult result = LoadingForm.ShowDialog();
            this.Focus();
            #endregion

            if (result == DialogResult.OK)
            { 
                string selectedText = LoadingForm.SelectedComboBoxText;
                int idStartIndx = selectedText.IndexOf('<') + 1;
                int idEndIndx = selectedText.IndexOf('>') - 1;
                int idLen = idEndIndx - idStartIndx + 1;
                string idToAssign = selectedText.Substring(idStartIndx, idLen);
                string nameToAssign = selectedText.Substring(0, idStartIndx - 2);
            }
        }

        private void performAction3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region Get IDs for items from User 
            Application.UseWaitCursor = true;
            Application.DoEvents();

            List<WorkflowItem> checkedItems = GetWorkflowItemsFromChecked(workflowItemsListView);
            List<WorkflowItem> itemsToUpdate = new List<WorkflowItem>();

            int itemsUserIDNotAvailable = 0;
            itemsUpdated = 0;

            try
            {
                foreach (WorkflowItem wi in checkedItems)
                {
                    // item edit here

                    if (wi.AssignedToName != null && wi.AssignedToName != String.Empty)
                    {
                        //string name = wi.AssignedToName;

                        if (!systemUserIDsDictionary.ContainsValue(wi.AssignedToName))
                        {
                            ++itemsUserIDNotAvailable;
                            continue;
                        }

                        string id = systemUserIDsDictionary.FirstOrDefault(x => x.Value == wi.AssignedToName).Key;

                        if (wi.AssignedToID == null || wi.AssignedToID == String.Empty || wi.AssignedToID != id)
                        {
                            wi.AssignedToID = id;
                            itemsToUpdate.Add(wi);
                            ++itemsUpdated;
                        }
                    }
                }
            }
            catch (Exception)
            {
                SetStatusLabelAndTimer("There was an error processing the request", true);
                MakeErrorSound();
                return;
            }

            UpdateAllLoadedWorkflowItems(itemsToUpdate);

            if (itemsUserIDNotAvailable > 0) SetStatusLabelAndTimer($"{itemsToUpdate} item(s) updated, ID(s) unrecognized for {itemsUserIDNotAvailable}", true);
            else SetStatusLabelAndTimer($"{itemsToUpdate} item(s) updated", true);

            Application.UseWaitCursor = false;
            #endregion
        }

        private void updateDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.AllWorkflowItemsLoaded == null || this.AllWorkflowItemsLoaded.Count == 0)
                return;
            updateDataBackgroundWorker.RunWorkerAsync();
        }

        private void getIDsForAnalystsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region Get IDs for items from User 
            Application.UseWaitCursor = true;
            Application.DoEvents();

            List<WorkflowItem> checkedItems = GetWorkflowItemsFromChecked(workflowItemsListView);
            List<WorkflowItem> itemsToUpdate = new List<WorkflowItem>();

            int itemsUserIDNotAvailable = 0;
            itemsUpdated = 0;

            try
            {
                foreach (WorkflowItem wi in checkedItems)
                {
                    // item edit here

                    if (wi.AssignedToName != null && wi.AssignedToName != String.Empty)
                    {
                        //string name = wi.AssignedToName;

                        if (!systemUserIDsDictionary.ContainsValue(wi.AssignedToName))
                        {
                            ++itemsUserIDNotAvailable;
                            continue;
                        }

                        string id = systemUserIDsDictionary.FirstOrDefault(x => x.Value == wi.AssignedToName).Key;

                        if (wi.AssignedToID == null || wi.AssignedToID == String.Empty || wi.AssignedToID != id)
                        {
                            wi.AssignedToID = id;
                            itemsToUpdate.Add(wi);
                            ++itemsUpdated;
                        }
                    }
                }
            }
            catch (Exception)
            {
                SetStatusLabelAndTimer("There was an error processing the request", true);
                MakeErrorSound();
                return;
            }

            UpdateAllLoadedWorkflowItems(itemsToUpdate);

            if (itemsUserIDNotAvailable > 0) SetStatusLabelAndTimer($"{itemsUpdated} item(s) updated, ID(s) unrecognized for {itemsUserIDNotAvailable}", true);
            else SetStatusLabelAndTimer($"{itemsUpdated} item(s) updated", true);

            Application.UseWaitCursor = false;
            #endregion
        }

        private void clearCompItemsDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (this.AllItemImportsLoaded == null || this.AllItemImportsLoaded.Count == 0)
                return;

            foreach (WorkflowItemCSVImport import in this.AllItemImportsLoaded)
            {
                import.ClearDataNotToBeSaved();
            }

            refreshBtn.PerformClick();

            Cursor.Current = Cursors.Default;
        }

        #endregion Tool Strip Menu

        // ----- SEARCH FUNCTIONALITY ----- //
        #region Search Functionality

        private void matchCaseBtn_Click(object sender, EventArgs e)
        {
            if (!matchSearchResultsCase)
            {
                matchSearchResultsCase = true;
                matchCaseBtn.BackgroundImage = CertusCompanion.Properties.Resources.icons8_uppercase_48__3_;
            }
            else
            {
                matchSearchResultsCase = false;
                matchCaseBtn.BackgroundImage = CertusCompanion.Properties.Resources.icons8_lowercase_48__3_;
            }
        }

        private void searchHighlightBtn_Click(object sender, EventArgs e)
        {
            if (sender != null)
            {
                searchTbx.Focus();
                searchTbx.SelectAll();
            }
        }

        private void searchTbx_TextChanged(object sender, EventArgs e)
        {
            // reset starting index for the search function
            searchIndex = 0;

            // set the tbx to the search value and save prev search
            previousSearch = searchVal;
            searchVal = searchTbx.Text;

            // show/hide buttons
            clearBtn.Visible = false;

            //remove label telling the user to type whenever text is in the tbx
            if (searchVal != String.Empty)
            {
                clearBtn.Visible = true;
                // update status label
                this.SetStatusLabelAndTimer($"Find \"{searchTbx.Text}\"", true);
            }
            else
            {
                ResetStatusStrip();
            }

        }

        private void searchTbx_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Shift && e.KeyCode == Keys.Space)
            {
                workflowItemsListView.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
                return;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                int index = 0;
                searchVal = searchTbx.Text;
                searchTbx.SelectAll();

                try
                {
                    if (searchVal != String.Empty)
                    {
                        index = FindMyStringInListView(workflowItemsListView, searchVal, searchIndex);

                        // find the item if index >= 0
                        if (index >= 0)
                        {
                            FocusItemInListView(index);

                            // update status label
                            this.SetStatusLabelAndTimer($"Find \"{searchTbx.Text}\"", true);

                            e.Handled = true;
                            e.SuppressKeyPress = true;
                        }
                        else
                        {
                            if (searchIndex > 0)
                            {
                                FocusItemInListView(searchIndex - 1);
                                SetStatusLabelAndTimer("End of data.");
                                searchIndex = 0;
                                searchTbx.Focus();
                                return;
                            }
                            SetStatusLabelAndTimer($"The following text was not found: {searchTbx.Text}", true);
                        }
                    }
                }
                catch (Exception)
                {
                    SetStatusLabelAndTimer($"An unkown error occured while searching");
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    MakeErrorSound();
                }
            }

            searchTbx.Focus();
        }

        private int FindMyStringInList(List<WorkflowItem> wi, string searchString, int startIndex)
        {
            for (int i = startIndex; i < wi.Count; ++i)
            {
                string wiString = wi[i].ToString();
                if (wiString.Contains(searchString))
                {
                    searchIndex = i + 1;
                    return i;
                }
            }
            return -1;
        }

        private int FindMyStringInListView(ListView listViewToSearch, string searchString, int startIndex)
        {
            if (matchSearchResultsCase)
            {
                for (int i = startIndex; i < listViewToSearch.Items.Count; ++i)
                {
                    foreach (ListViewItem.ListViewSubItem subItem in listViewToSearch.Items[i].SubItems)
                    {
                        if (subItem.Text.Contains(searchString))
                        {
                            searchIndex = i + 1;
                            return i;
                        }
                    }
                }
            }
            else
            {
                for (int i = startIndex; i < listViewToSearch.Items.Count; ++i)
                {
                    foreach (ListViewItem.ListViewSubItem subItem in listViewToSearch.Items[i].SubItems)
                    {
                        if (subItem.Text.ToLower().Contains(searchString.ToLower()))
                        {
                            searchIndex = i + 1;
                            return i;
                        }
                    }
                }
            }
            return -1;
        }

        private void SelectItemInListView(string itemID)
        {
            if (workflowItemsListView.SelectedItems != null && workflowItemsListView.SelectedItems.Count > 0)
            {
                ignoreThisSelectedIndexChanged = true;
                workflowItemsListView.SelectedItems[0].Selected = false;
            }

            for (int i = 0; i < workflowItemsListView.Items.Count; i++)
            {
                if (workflowItemsListView.Items[i].SubItems[1].Text == itemID)
                {
                    workflowItemsListView.Items[i].Selected = true;
                    workflowItemsListView.EnsureVisible(i);
                }
            }
        }

        private void SelectItemInListView(int index)
        {
            try
            {
                workflowItemsListView.SelectedIndices.Clear();
                workflowItemsListView.Items[index].Selected = true;
                workflowItemsListView.Items[index].Focused = true;
                workflowItemsListView.EnsureVisible(index);
            }
            catch (Exception)
            {
                SetStatusLabelAndTimer("Could not get the item", 3000);
                MakeErrorSound();
            }
        }

        private void FocusItemInListView(int index)
        {
            try
            {
                workflowItemsListView.Items[index].Focused = true;
                workflowItemsListView.EnsureVisible(index);
            }
            catch (Exception)
            {
                SetStatusLabelAndTimer("Could not get the item", 3000);
                MakeErrorSound();
            }
        }

        #endregion Search Functionality

        // ----- START PROCESSES ----- //
        #region Start Processes

        private void ItemsViewForm_OpenCertificate(object sender, string[] certificatesIds)
        {
            throw new NotImplementedException();
        }

        private void ItemsViewForm_OpenCompany(object sender, string[] companyIds)
        {
            throw new NotImplementedException();
        }

        #endregion Start Processes

        // ----- LISTVIEW OPTIONS ----- //
        #region ListView Options

        private void checkInBulkBtn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            // no items/checked items - do nothing
            if (workflowItemsListView.Items == null || workflowItemsListView.Items.Count == 0 ||
                workflowItemsListView.CheckedItems == null)
            {
                return;
            }
            // 0 items checked - check all
            else if (workflowItemsListView.CheckedItems.Count == 0)
            {
                this.workflowItemsListView.BeginUpdate();
                CheckAllListViewItems();
                bulkCheckBtn.BackgroundImage = CertusCompanion.Properties.Resources.icons8_checked_checkbox_48__1_;
            }
            else
            {
                // 1 or more items - uncheck all 
                this.workflowItemsListView.BeginUpdate();
                UncheckAllListViewItems();
                bulkCheckBtn.BackgroundImage = CertusCompanion.Properties.Resources.icons8_unchecked_checkbox_48__1_;
            }

            this.workflowItemsListView.EndUpdate();
            this.SetDatabaseDetailsProperties();
            //this.workflowItemsListView.Focus();
            if (workflowItemsListView.FocusedItem != null) workflowItemsListView.FocusedItem.Focused = false;

            Cursor.Current = Cursors.Default;
        }

        private void singleCheckBtn_Click(object sender, EventArgs e)
        {
            if (workflowItemsListView.FocusedItem != null && workflowItemsListView.FocusedItem.Index > 0)
            {
                workflowItemsListView.FocusedItem.Checked = true;
            }

            workflowItemsListView.Focus();
        }

        private void deselectBtn_Click(object sender, EventArgs e)
        {
            if (workflowItemsListView.Items != null && workflowItemsListView.Items.Count > 0)
            {
                if (workflowItemsListView.SelectedItems != null && workflowItemsListView.SelectedItems.Count > 0)
                {
                    for (int i = 0; i < workflowItemsListView.SelectedItems.Count; i++)
                    {
                        workflowItemsListView.SelectedItems[i].Selected = false;
                    }
                }

                ClearItemDetails();

                if (workflowItemsListView.FocusedItem != null) workflowItemsListView.FocusedItem.Focused = false;
            }

            ResetStatusStrip();
        }

        private void addAsReferenceBtn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (workflowItemsListView.CheckedIndices == null || workflowItemsListView.CheckedIndices.Count == 0)
            {
                SetStatusLabelAndTimer("No item/items currently selected", 3000);
                MakeErrorSound();
                //workflowItemsListView_MouseDoubleClick(workflowItemsListView, null);
            }
            else
            {
                try
                {
                    for (int i = 0; i < workflowItemsListView.CheckedIndices.Count; i++)
                    {
                        string id = workflowItemsListView.CheckedItems[i].SubItems[1].Text;

                        AddReferenceButton(id);
                    }

                    UncheckAllListViewItems();
                    itemButtons[this.nextAvailableButton - 2].PerformClick();
                    itemButtons[this.nextAvailableButton - 1].PerformClick();
                }
                catch (Exception)
                {
                    SetStatusLabelAndTimer("Could not add references", 3000);
                    MakeErrorSound();
                }
            }

            workflowItemsListView.Focus();

            Cursor.Current = Cursors.Default;
        }

        private void AddReferenceButton(WorkflowItem wi)
        {
            // save reference to item in next available item button
            itemButtons[nextAvailableButton].Visible = true;
            itemButtons[nextAvailableButton].Text = wi.DocumentWorkflowItemID;
            //itemButtons[nextAvailableButton].BackColor = Color.FromName("Highlight");
            itemButtons[nextAvailableButton].ForeColor = Color.FromName(wi.DisplayColor);

            // count index up until it hits the max
            if (nextAvailableButton < 10)
            {
                ++nextAvailableButton;
            }
        }

        private void AddReferenceButton(string itemID)
        {
            WorkflowItem wi = GetWorkflowItemFromAllByID(itemID);

            // save reference to item in next available item button
            itemButtons[nextAvailableButton].Visible = true;
            itemButtons[nextAvailableButton].Text = wi.DocumentWorkflowItemID;
            //itemButtons[nextAvailableButton].BackColor = Color.FromName("Highlight");
            itemButtons[nextAvailableButton].ForeColor = Color.FromName(wi.DisplayColor);

            // count index up until it hits the max
            if (nextAvailableButton < 10)
            {
                ++nextAvailableButton;
            }
        }

        private void removeColorBtn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            List<WorkflowItem> itemsToPaint = new List<WorkflowItem>();
            int itemsPainted = 0;

            try
            {
                workflowItemsListView.BeginUpdate();

                // set colors back to how they started
                foreach (ListViewItem lvItem in workflowItemsListView.CheckedItems)
                {
                    WorkflowItem item = GetWorkflowItemFromLvItem(lvItem);

                    if (item.DisplayColor != "Default")
                    {
                        ++itemsPainted;
                    }

                    item.DisplayColor = "Default";
                    itemsToPaint.Add(item);
                }

                this.UpdateAllLoadedWorkflowItems(itemsToPaint);

                workflowItemsListView.EndUpdate();

                // notify
                SetStatusLabelAndTimer($"Paint removed from {itemsPainted} items");
            }
            catch (Exception)
            {
                workflowItemsListView.EndUpdate();
                SetStatusLabelAndTimer("Couldn't remove paint from the items", 5000);
                MakeErrorSound();
            }

            Cursor.Current = Cursors.Default;
            workflowItemsListView.Focus();
        }

        private void paintBtn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            this.workflowItemsListView.BeginUpdate();

            int itemsPainted = 0;
            List<WorkflowItem> itemsToPaint = new List<WorkflowItem>();

            if (workflowItemsListView.CheckedIndices == null || workflowItemsListView.CheckedIndices.Count == 0)
            {
                SetStatusLabelAndTimer("Select items to paint first", 5000);
                MakeErrorSound();
                return;
            }

            // for each item checked
            foreach (ListViewItem lvItem in workflowItemsListView.CheckedItems)
            {
                WorkflowItem item = new WorkflowItem();

                // get item from lvItem
                item = GetWorkflowItemFromLvItem(lvItem);

                // count only if not the color
                if (item.DisplayColor != colorDialogSelection.Name)
                {
                    ++itemsPainted;
                }

                // change dbItem color
                item.DisplayColor = colorDialogSelection.Name;

                // add item to itemsToPaint
                itemsToPaint.Add(item);
            }

            // update allLoadedItems
            try
            {
                UpdateAllLoadedWorkflowItems(itemsToPaint);
            }
            catch (Exception)
            {
                SetStatusLabelAndTimer("Item/Items could not be upddated.");
                MakeErrorSound();
            }

            this.workflowItemsListView.EndUpdate();

            SetStatusLabelAndTimer($"{itemsPainted} items painted");

            Cursor.Current = Cursors.Default;
            workflowItemsListView.Focus();
        }

        private void colorSelectionBtn_Click(object sender, EventArgs e)
        {
            if (paintColorDialog.ShowDialog() == DialogResult.OK)
            {
                // store selected color
                colorDialogSelection = paintColorDialog.Color;

                // change button appearances
                colorDialogBtn.ForeColor = colorDialogSelection;
                paintFromListViewBtn.ForeColor = colorDialogSelection;
                paintFromQueryBtn.ForeColor = colorDialogSelection;
            }

            workflowItemsListView.Focus();
        }

        private void importWorkflowItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            importFileBeingWorkedOn = 1;

            openFileDialog.Multiselect = true;

            try
            {
                openFileDialog.FileName = "";
                openFileDialog.Filter = "CSV Files (*.csv)|*.csv";
                openFileDialog.FilterIndex = 1;

                DialogResult dialogResult = openFileDialog.ShowDialog();

                if (dialogResult == DialogResult.OK)
                {
                    UseWaitCursor = true;
                    importWorkflowItemsBackgroundWorker.RunWorkerAsync(openFileDialog);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("The import was unsuccessful.", "Error");
                // should save back to old state (does not). same with any loading/saving if it catches an exception
            }

            workflowItemsListView.Focus();
        }

        private void AddItemsToAllWorkflowItemsLoaded(List<WorkflowItem> currentImportItems, int valueToIncrementByIfLoading = 1)
        {
            // for reporting loading progress
            int valueToIncrement = 0;
            int itemCount = 0;
            int valueToIncrementBy = valueToIncrementByIfLoading;
            bool loadingFormIsActive = (CheckIfFormIsOpened("LoadingForm"));

            // if there's a loading form
            if (loadingFormIsActive)
            {
                // set up data for reporting progress
                valueToIncrement = (int)(currentImportItems.Count * .01);
                valueToIncrement *= valueToIncrementBy;
                if (valueToIncrement <= 0) valueToIncrement = 1;
            }

            // to speed up checking ID's...
            List<string> existingIDs = new List<string>();
            existingIDs.AddRange(from item in AllWorkflowItemsLoaded
                                   select item.DocumentWorkflowItemID);

            foreach (WorkflowItem importItem in currentImportItems)
            {
                ++itemCount;

                // report progress if there's a loading form
                if (loadingFormIsActive)
                {
                    // report progress
                    if (itemCount % valueToIncrement == 0)
                    {
                        if (this.InvokeRequired)
                            this.Invoke(new Action(() => { LoadingForm.MoveBar(1); }));
                        else
                            LoadingForm.MoveBar(1);
                    }
                }

                // if the item exists in the current list
                //if (AllWorkflowItemsLoaded.Exists(i => i.DocumentWorkflowItemID == importItem.DocumentWorkflowItemID))
                if (existingIDs.Contains(importItem.DocumentWorkflowItemID))
                {
                    WorkflowItem existingItem = new WorkflowItem();
                    var item = (AllWorkflowItemsLoaded.First(i => i.DocumentWorkflowItemID == importItem.DocumentWorkflowItemID));
                    existingItem = item as WorkflowItem;

                    // if user wants to add and update (if check box is not checked, item will not be added if there is one existing with the same id)
                    if (addAndUpdateCheckBox.Checked == true)
                    {
                        // if the new item was updated
                        if (CheckIfItemWasUpdated(existingItem, importItem))
                        {
                            // replace new with old
                            AllWorkflowItemsLoaded[AllWorkflowItemsLoaded.IndexOf(existingItem)] = importItem;
                        }
                    }
                }
                else // item doesn't exist in the list
                {
                    AllWorkflowItemsLoaded.Add(importItem);
                    existingIDs.Add(importItem.DocumentWorkflowItemID);
                }
            }

            // sort list by ID (case if older items get added after newer items)
            AllWorkflowItemsLoaded = AllWorkflowItemsLoaded.OrderBy(i => i.DocumentWorkflowItemID).ToList();
        }

        private bool CheckIfItemWasUpdated(WorkflowItem currentItemInDB, WorkflowItem importItem)
        {
            // if any data is not the same, item was changed. return true for check if item was updated 
            if (currentItemInDB.ContractID != importItem.ContractID || currentItemInDB.Active != importItem.Active ||
                currentItemInDB.Compliant != importItem.Compliant || currentItemInDB.NextExpirationDate != importItem.NextExpirationDate ||
                currentItemInDB.WorkflowAnalyst != importItem.WorkflowAnalyst || currentItemInDB.CompanyAnalyst != importItem.CompanyAnalyst ||
                currentItemInDB.Status != importItem.Status || currentItemInDB.FileSize != importItem.FileSize ||
                currentItemInDB.FileMIME != importItem.FileMIME || currentItemInDB.AssignedToName != importItem.AssignedToName)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void importFromDatabaseBtn_Click(object sender, EventArgs e)
        {
            #region Generate Form

            // construct forms
            DimForm();
            ImportFromDBForm = new ImportFromDatabaseForm();

            // pass data sources
            // ...

            // show as dialog
            DialogResult result = ImportFromDBForm.ShowDialog();
            this.Focus();

            #endregion

            if (result == DialogResult.OK)
            {
                importFromDBBackGroundWorker.RunWorkerAsync();
            }
        }

        private void viewChoiceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            switch (viewChoiceComboBox.Text)
            {
                case "All Workflow":
                    if (workflowItemListPopulated != this.AllWorkflowItemsLoaded)
                    {
                        if (this.AllWorkflowItemsLoaded == null || this.AllWorkflowItemsLoaded.Count == 0)
                        {
                            SetStatusLabelAndTimer("No items in that list", 5000);
                            MakeErrorSound();
                            return;
                        }

                        this.removeFromExportViewToolStripMenuItem.Enabled = false;
                        this.removeFromExportContextMenuItem.Enabled = false;
                        if (this.queryFromComboBox.Items.Count == 2)
                            this.queryFromComboBox.Items.Add("Current View");

                        try
                        {
                            PopulateListViewData(AllWorkflowItemsLoaded);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Could not load the selected list.", "Error");
                        }
                    }
                    break;
                case "Non-completed":
                    if (workflowItemListPopulated != this.CurrentWorkflowItems)
                    {
                        if (this.CurrentWorkflowItems == null || this.CurrentWorkflowItems.Count == 0)
                        {
                            SetStatusLabelAndTimer("No items in that list", 5000);
                            MakeErrorSound();
                            return;
                        }

                        this.removeFromExportViewToolStripMenuItem.Enabled = false;
                        this.removeFromExportContextMenuItem.Enabled = false;
                        if (this.queryFromComboBox.Items.Count == 2)
                            this.queryFromComboBox.Items.Add("Current View");

                        try
                        {
                            PopulateListViewData(CurrentWorkflowItems);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Could not load the selected list.", "Error");
                        }
                    }
                    break;
                case "Export":
                    if (workflowItemListPopulated != this.TemporaryExportList)
                    {
                        if (TemporaryExportList == null || TemporaryExportList.Count == 0)
                        {
                            SetStatusLabelAndTimer("No items in that list", 5000);
                            MakeErrorSound();
                            return;
                        }

                        this.removeFromExportViewToolStripMenuItem.Enabled = true;
                        this.removeFromExportContextMenuItem.Enabled = true;
                        if (this.queryFromComboBox.Items.Count == 2)
                            this.queryFromComboBox.Items.Add("Current View");

                        try
                        {
                            PopulateListViewData(TemporaryExportList);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Could not load the selected list.", "Error");
                        }
                    }
                    break;
                case "Search Results":
                    {
                        if (workflowItemListPopulated != this.SearchResultsList)
                        {
                            // add items to a results list
                            SearchResultsList.Clear();

                            if (searchTbx.Text == String.Empty)
                            {
                                SetStatusLabelAndTimer("You need something to search first");
                                MakeErrorSound();
                                return;
                            }
                            for (int i = 0; i < workflowItemsListView.Items.Count; ++i)
                            {
                                if (matchSearchResultsCase)
                                {
                                    foreach (ListViewItem.ListViewSubItem subItem in workflowItemsListView.Items[i].SubItems)
                                    {
                                        WorkflowItem wi = new WorkflowItem();
                                        wi = GetWorkflowItemFromCurrentViewByID(workflowItemsListView.Items[i].SubItems[1].Text);

                                        if (subItem.Text.Contains(searchVal))
                                        {
                                            if (!SearchResultsList.Contains(wi))
                                                this.SearchResultsList.Add(wi);
                                        }
                                    }
                                }
                                else
                                {
                                    foreach (ListViewItem.ListViewSubItem subItem in workflowItemsListView.Items[i].SubItems)
                                    {
                                        if (subItem.Text.ToLower().Contains(searchVal.ToLower()))
                                        {
                                            WorkflowItem wi = new WorkflowItem();
                                            wi = GetWorkflowItemFromCurrentViewByID(workflowItemsListView.Items[i].SubItems[1].Text);

                                            this.SearchResultsList.Add(wi);
                                        }
                                    }
                                }
                            }

                            List<WorkflowItem> listToReplace = new List<WorkflowItem>();

                            foreach (WorkflowItem item in SearchResultsList)
                            {
                                if (!listToReplace.Contains(item))
                                    listToReplace.Add(item);
                            }

                            SearchResultsList = listToReplace;

                            if (SearchResultsList == null || SearchResultsList.Count == 0)
                            {
                                SetStatusLabelAndTimer("No items in that list", 5000);
                                MakeErrorSound();
                                return;
                            }

                            this.removeFromExportViewToolStripMenuItem.Enabled = true;
                            this.removeFromExportContextMenuItem.Enabled = true;
                            if (this.queryFromComboBox.Items.Count == 2)
                                this.queryFromComboBox.Items.Add("Current View");

                            try
                            {
                                PopulateListViewData(SearchResultsList);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Could not load the selected list.", "Error");
                            }
                        }
                    }
                    break;
                case "Queried":
                    if (workflowItemListPopulated != this.queriedItemList)
                    {
                        if (queriedItemList == null || queriedItemList.Count == 0)
                        {
                            SetStatusLabelAndTimer("No items in that list", 5000);
                            MakeErrorSound();
                            return;
                        }

                        this.removeFromExportViewToolStripMenuItem.Enabled = false;
                        this.removeFromExportContextMenuItem.Enabled = false;
                        if (this.queryFromComboBox.Items.Count == 2)
                            this.queryFromComboBox.Items.Add("Current View");

                        try
                        {
                            PopulateListViewData(queriedItemList);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Could not load the selected list.", "Error");
                        }
                    }
                    break;
                default:
                    break;
            }

            Cursor.Current = Cursors.Default;
            workflowItemsListView.Focus();
        }

        private List<WorkflowItem> ListViewComboBoxChoice()
        {
            List<WorkflowItem> list = new List<WorkflowItem>();

            switch (viewChoiceComboBox.Text)
            {
                case "All Workflow":
                    list = AllWorkflowItemsLoaded;
                    break;
                case "Non-completed":
                    list = this.CurrentWorkflowItems;
                    break;
                case "Export":
                    list = this.TemporaryExportList;
                    break;
                case "Search Results":
                    list = this.SearchResultsList;
                    break;
                case "Queried":
                    list = this.queriedItemList;
                    break;
                default:
                    break;
            }

            return list;
        }

        private List<WorkflowItem> DetermineWorkflowItemListToShowOnListView()
        {
            // default
            if (IsFilterActive())
            {
                return filteredWfItems;
            }
            else
            {
                // show items depending on current view according to combo box
                switch (viewChoiceComboBox.Text)
                {
                    case "All Workflow":
                        return AllWorkflowItemsLoaded;
                    case "Non-completed":
                        return CurrentWorkflowItems;
                    case "Export":
                        return TemporaryExportList;
                    case "Search Results":
                        return SearchResultsList;
                    case "Queried":
                        return queriedItemList;
                    default:
                        return AllWorkflowItemsLoaded;
                }
            }
        }

        private void lvFiltersBtn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            /* // filter botton toggle
             
            if (filterListView == true)
            {
                PopulateListViewData(ListViewComboBoxChoice());
                filterListView = false;
                filterLvBtn.BackColor = Color.FromArgb(20, 20, 20);
                filterStatusLbl.Text = "Filter: None";
                return;
            }

            */

            // if there's currently a Filter Options, close it
            if (CheckIfFormIsOpened("Filter Options"))
            {
                FilterForm.Close();
            }

            // if currently there is a filter
            if (CurrentFilter != null)
            {
                FilterForm = new FiltersForm(CurrentFilter);
                FilterForm.Populate();
            }
            else
            {
                FilterForm = new FiltersForm();
            }

            // register events
            FilterForm.SaveFilter += new FilterEventHandler(FiltersForm_SaveFilter);

            DimForm();

            // show form
            FilterForm.ShowDialog();

            // return form appearance to normal
            TransparentForm.Close();
            (Application.OpenForms[0] as WorkflowManager).Focus();

            if (FilterForm.DialogResult == DialogResult.Cancel) return;

            // determine whether to show filtered items and show button as selected
            if (IsFilterActive())
            {
                Cursor.Current = Cursors.WaitCursor;
                filterBtn.BackColor = Color.FromName("Highlight");

                // save list of filtered items
                SaveFilteredItemList();

                // populate the lv with the filtered items
                try
                {
                    PopulateListViewData(filteredWfItems);
                    //filterListView = true;
                    filterStatusLbl.Text = $"Filter: {CurrentFilter.ToString()}";
                }
                catch (Exception)
                {
                    SetStatusLabelAndTimer("Could not filter the list", 5000);
                    MakeErrorSound();

                    // unselect 
                    //filterListView = false;
                    filterBtn.BackColor = Color.FromArgb(20, 20, 20);
                    PopulateListViewData(ListViewComboBoxChoice());
                }
            }
            else
            {
                Cursor.Current = Cursors.WaitCursor;
                //filterListView = false;
                filterBtn.BackColor = Color.FromArgb(20, 20, 20);
                PopulateListViewData(ListViewComboBoxChoice());
            }

            Cursor.Current = Cursors.Default;
            workflowItemsListView.Focus();
        }

        private void FiltersForm_SaveFilter(object sender, Filter filter)
        {
            this.CurrentFilter = filter;
        }

        private void SaveFilteredItemList()
        {
            if (CurrentFilter == null)
            {
                return;
            }

            if (filteredLvWorkflowItems != null && filteredLvWorkflowItems.Count > 0)
            {
                filteredWfItems.Clear();
            }

            List<WorkflowItem> newList = new List<WorkflowItem>();
            List<WorkflowItem> lvList = this.ListViewComboBoxChoice();

            if (CurrentFilter.ColorCheckChoice == true)
            {
                if (CurrentFilter.ColorSelection == "All Colors")
                {
                    newList.AddRange(GetAllColoredWfItems());
                }
                if (CurrentFilter.ColorSelection == "Active Colors")
                {
                    newList.AddRange(GetActiveColoredWfItems());
                }
                if (CurrentFilter.ColorSelection == "Inactive Colors")
                {
                    newList.AddRange(GetInactiveColoredWfItems());
                }
                else
                {
                    foreach (WorkflowItem item in lvList)
                    {
                        if (item.DisplayColor == CurrentFilter.ColorSelection)
                        {
                            newList.Add(item);
                        }
                    }
                }
            }
            if (CurrentFilter.AnalystCheckChoice == true)
            {
                foreach (WorkflowItem item in lvList)
                {
                    if (item.AssignedToName == CurrentFilter.AnalystSelection)
                    {
                        newList.Add(item);
                    }
                }
            }
            if (CurrentFilter.StatusCheckChoice == true)
            {
                foreach (WorkflowItem item in lvList)
                {
                    if (item.Status == CurrentFilter.StatusSelection)
                    {
                        newList.Add(item);
                    }
                }
            }
            if (CurrentFilter.QueriedCheckChoice == true)
            {
                foreach (WorkflowItem item in queriedItemList)
                {
                    newList.Add(item);
                }
            }
            if (CurrentFilter.CompanyCheckChoice == true)
            {
                foreach (WorkflowItem item in lvList)
                {
                    if (item.VendorName.ToLower() == CurrentFilter.CompanySelection.ToLower())
                    {
                        newList.Add(item);
                    }
                }
            }
            if (CurrentFilter.SenderCheckChoice == true)
            {
                foreach (WorkflowItem item in lvList)
                {
                    if (item.EmailFromAddress.ToLower() == CurrentFilter.SenderSelection.ToLower())
                    {
                        newList.Add(item);
                    }
                }
            }
            if (CurrentFilter.SubjectCheckChoice == true)
            {
                foreach (WorkflowItem item in lvList)
                {
                    if (item.SubjectLine.ToLower() == CurrentFilter.SubjectSelection.ToLower())
                    {
                        newList.Add(item);
                    }
                }
            }
            if (CurrentFilter.DateCheckChoice == true)
            {
                foreach (WorkflowItem item in lvList)
                {
                    if (CurrentFilter.StartDate.Ticks < Convert.ToDateTime(item.EmailDate).Ticks &&
                        CurrentFilter.EndDate.Ticks > Convert.ToDateTime(item.EmailDate).Ticks)
                    {
                        newList.Add(item);
                    }
                }
            }

            filteredWfItems = newList;
        }

        private bool IsFilterActive()
        {
            if (CurrentFilter == null)
            {
                return false;
            }
            else if (CurrentFilter.ColorCheckChoice == false && CurrentFilter.AnalystCheckChoice == false &&
                CurrentFilter.StatusCheckChoice == false && CurrentFilter.QueriedCheckChoice == false &&
                CurrentFilter.CompanyCheckChoice == false && CurrentFilter.SenderCheckChoice == false &&
                CurrentFilter.SubjectCheckChoice == false && CurrentFilter.DateCheckChoice == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void fullScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // hide LV while the other controls have a chance to change 
            workflowItemsListView.Visible = false;

            // entering full view
            if (fullView == false)
            {
                fullView = true;

                // change appearance of button 
                fullViewBtn.BackColor = Color.FromName("Highlight");

                // save current splitter distance
                currentSplitter1Distance = splitContainerChild1.SplitterDistance;

                // move splitter distance to as far as it'll go
                splitContainerChild1.SplitterDistance = 5000;

                // show controls
                detailsOptionsPanel2.Visible = true;

                // lock controls
                //splitContainerChild2.IsSplitterFixed = true;
                splitContainerChild1.IsSplitterFixed = true;

                // hide panels
                itemDetailsPanel.Visible = false;
                queryPanel.Visible = false;
                importPanel.Visible = false;
                detailsOptionsPanel.Visible = false;

                // disable controls
                //this.enlargeBtn.Enabled = false;
                workflowItemsListView.Focus();

                detailNotificationsPanel.Top = detailsOptionsPanel2.Top+1;
                detailNotificationsPanel.Left = detailsOptionsPanel2.Left - 250;
            }
            else
            {
                // exiting full view

                fullView = false;

                fullViewBtn.BackColor = Color.FromArgb(20, 20, 20);

                splitContainerChild1.SplitterDistance = currentSplitter1Distance;


                detailsOptionsPanel2.Visible = false;

                //splitContainerChild2.IsSplitterFixed = false;
                splitContainerChild1.IsSplitterFixed = false;

                itemDetailsPanel.Visible = true;
                queryPanel.Visible = true;
                importPanel.Visible = true;
                detailsOptionsPanel.Visible = true;

                //enlargeBtn.Enabled = true;

                detailNotificationsPanel.Top = detailNotificationPanelTop;
                detailNotificationsPanel.Left = detailNotificationPanelLeft;
            }

            workflowItemsListView.Visible = true;
        }

        private void enlargeBtn_Click(object sender, EventArgs e)
        {
            this.splitContainerChild1.SplitterDistance = splitContainerChild1.Bottom - 837; //835 was the original here and 458 for split distance 1
            this.splitContainerChild2.SplitterDistance = 5000;
            workflowItemsListView.Focus();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                // update filtered items
                if (IsFilterActive())
                {
                    SaveFilteredItemList();
                }

                // populate views 
                this.RefreshListView();
                this.PopulateImportLbx(AllItemImportsLoaded);

                // refresh views
                //workflowItemsListView.Refresh();
                itemImportsLbx.Refresh();
            }
            catch (Exception)
            {
                SetStatusLabelAndTimer("Could not refresh", 3000);
                MakeErrorSound();
            }

            Cursor.Current = Cursors.Default;
            workflowItemsListView.Focus();
        }

        private void RefreshListView()
        {
            workflowItemsListView.OwnerDraw = false;
            workflowItemsListView.Visible = false;

            try
            {
                PopulateListViewData(workflowItemListPopulated);
            }
            catch (Exception)
            {
                SetStatusLabelAndTimer("There was a problem refreshing");
                MakeErrorSound();
            }

            workflowItemsListView.OwnerDraw = true;
            workflowItemsListView.Visible = true;
        }

        private void redrawItemsBtn_Click(object sender, EventArgs e)
        {
            UseWaitCursor = true;
            this.Refresh();

            try
            {
                workflowItemsListView.BeginUpdate();

                int checkedIndex = 0;

                foreach (ListViewItem checkedItem in workflowItemsListView.CheckedItems)
                {
                    int index = workflowItemsListView.Items.IndexOf(workflowItemsListView.CheckedItems[checkedIndex]);
                    WorkflowItem wi = GetWorkflowItemFromCurrentViewByID(checkedItem.SubItems[1].Text);

                    // repopulate item at the checked index
                    workflowItemsListView.Items[index].SubItems[1].Text = wi.DocumentWorkflowItemID;
                    workflowItemsListView.Items[index].SubItems[2].Text = wi.VendorName;
                    workflowItemsListView.Items[index].SubItems[3].Text = wi.ContractID;
                    workflowItemsListView.Items[index].SubItems[4].Text = wi.EmailDate.Value.ToString();
                    workflowItemsListView.Items[index].SubItems[5].Text = wi.EmailFromAddress;
                    workflowItemsListView.Items[index].SubItems[6].Text = wi.SubjectLine;
                    workflowItemsListView.Items[index].SubItems[7].Text = wi.FileName;
                    workflowItemsListView.Items[index].SubItems[8].Text = wi.FileSize;
                    workflowItemsListView.Items[index].SubItems[9].Text = wi.FileURL;
                    workflowItemsListView.Items[index].SubItems[10].Text = wi.AssignedToName;
                    workflowItemsListView.Items[index].SubItems[11].Text = wi.Status;

                    ++checkedIndex;
                }

                workflowItemsListView.EndUpdate();

                // force refresh
                workflowItemsListView.Refresh();
            }
            catch (Exception)
            {
                SetStatusLabelAndTimer("There was an error processing that request");
                workflowItemsListView.EndUpdate();
                MakeErrorSound();
            }

            UseWaitCursor = false;
            workflowItemsListView.Focus();
        }

        private void contrastItemGroupsBtn_Click(object sender, EventArgs e)
        {
            // toggle on
            if (!contrastItemGroups)
            {
                try
                {
                    contrastItemGroups = true;
                    contrastItemGroupsBtn.BackColor = Color.FromName("Highlight");
                    Color defaultBackColor = workflowItemsListView.BackColor;
                    Color altBackColor = Color.FromArgb(25, 25, 25);
                    previousEmailDate = "";
                    previousSender = "";
                    string id = "";
                    itemGroupsSortedColors = new Dictionary<string, Color>();

                    foreach (ListViewItem item in workflowItemsListView.Items)
                    {
                        if (previousEmailDate == String.Empty)
                        {
                            id = item.SubItems[1].Text;
                            itemGroupsSortedColors.Add(id, defaultBackColor);
                            currentColor = defaultBackColor;
                            previousEmailDate = item.SubItems[dateColumnHeader.Index].Text;
                            previousSender = item.SubItems[senderColumnHeader.Index].Text;
                            continue;
                        }

                        //alternate backcolors when different date and sender
                        if (item.SubItems[dateColumnHeader.Index].Text != previousEmailDate || item.SubItems[senderColumnHeader.Index].Text != previousSender)
                        {
                            if (currentColor == defaultBackColor) currentColor = altBackColor;
                            else currentColor = defaultBackColor;
                        }

                        id = item.SubItems[1].Text;
                        itemGroupsSortedColors.Add(id, currentColor);
                        previousEmailDate = item.SubItems[dateColumnHeader.Index].Text;
                        previousSender = item.SubItems[senderColumnHeader.Index].Text;
                    }
                }
                catch (Exception)
                {
                    SetStatusLabelAndTimer("Could not toggle item group contraster", true);
                    MakeErrorSound();

                    // toggle off
                    contrastItemGroups = false;
                    contrastItemGroupsBtn.BackColor = ThemeColors.Space;
                }
            }
            // toggle off
            else
            {
                contrastItemGroups = false;
                contrastItemGroupsBtn.BackColor = ThemeColors.Space;
            }
        }

        private void showItemsMonotoneBtn_Click(object sender, EventArgs e)
        {
            if (!showItemsWithColor)
            {
                showItemsWithColor = true;
                showItemColorsBtn.BackColor = Color.FromName("Highlight");
            }
            else
            {
                showItemsWithColor = false;
                showItemColorsBtn.BackColor = ThemeColors.Space;
            }
        }

        private void lockListViewColumnSizingBtn_Click(object sender, EventArgs e)
        {
            if (!lockListViewColumnSizing)
            {
                lockListViewColumnSizing = true;
                workflowItemsListView.ColumnWidthChanged -= workflowItemsListView_ColumnWidthChanged;
                this.Resize -= WorkflowManager_Resize;
                lockListViewColumnSizingBtn.BackColor = Color.FromName("Highlight");
            }
            else
            {
                lockListViewColumnSizing = false;
                workflowItemsListView.ColumnWidthChanged += workflowItemsListView_ColumnWidthChanged;
                this.Resize += WorkflowManager_Resize;
                lockListViewColumnSizingBtn.BackColor = ThemeColors.Space;
            }
        }

        private void optionButtons_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Left || e.KeyCode == Keys.Left || e.KeyCode == Keys.Left)
            {
                e.IsInputKey = true;
            }
        }

        private void optionButtons_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Left || e.KeyCode == Keys.Left || e.KeyCode == Keys.Left)
            {
                e.Handled = true;
            }
        }
        
        #region ListView Context Menu

        // Copy and Selection
        private void copyContextMenuItem_Click(object sender, EventArgs e)
        {
            string s = "";
            string ss = "";

            try
            {
                if (workflowItemsListView.SelectedItems != null && workflowItemsListView.SelectedItems.Count > 0 && workflowItemsListView.SelectedItems[0].Checked == false)
                {
                    foreach (ListViewItem selectedItem in workflowItemsListView.SelectedItems)
                    {
                        ss = "";

                        //s += $"{GetWorkflowItemFromLvItem(selectedItem).ToString()}{Environment.NewLine}";
                        //foreach (ListViewItem.ListViewSubItem si in selectedItem.SubItems)
                        //{
                        //    ss += $"{si}\t";
                        //}

                        for (int i = 1; i < 7; i++)
                        {
                            ss+=$"{selectedItem.SubItems[i].Text}\t";
                        }

                        s += $"{ss}{Environment.NewLine}";
                    }
                }

                if (workflowItemsListView.CheckedItems != null && workflowItemsListView.CheckedItems.Count > 0)
                {
                    foreach (ListViewItem checkedItem in workflowItemsListView.CheckedItems)
                    {
                        s += $"{GetWorkflowItemFromLvItem(checkedItem).ToString()}{Environment.NewLine}";
                    }
                }

                if (s != String.Empty) Clipboard.SetText(s);
            }
            catch(Exception)
            {
                SetStatusLabelAndTimer("Unable to copy item(s)");
            }
        }

        private void copyWithHeadersContextMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void copyIdsContextMenuItem_Click(object sender, EventArgs e)
        {
            string s = "";

            if (workflowItemsListView.SelectedItems != null && workflowItemsListView.SelectedItems.Count > 0 && workflowItemsListView.SelectedItems[0].Checked == false)
            {
                foreach (ListViewItem selectedItem in workflowItemsListView.SelectedItems)
                {
                    s += $"{(GetWorkflowItemFromLvItem(selectedItem).DocumentWorkflowItemID)}{Environment.NewLine}";
                }
            }

            if (workflowItemsListView.CheckedItems != null && workflowItemsListView.CheckedItems.Count > 0)
            {
                foreach (ListViewItem checkedItem in workflowItemsListView.CheckedItems)
                {
                    s += $"{(GetWorkflowItemFromLvItem(checkedItem).DocumentWorkflowItemID)}{Environment.NewLine}";
                }
            }

            if (s != String.Empty) Clipboard.SetText(s);
        }

        private void selectAllContextMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        // Item Action
        private void openLinkContextMenuItem_Click(object sender, EventArgs e)
        {
            List<string> idsInList = new List<string>();
            int urlsNotOpened = 0;

            // foreach id checked
            if (workflowItemsListView.CheckedItems != null && workflowItemsListView.CheckedItems.Count > 0)
            {
                if (workflowItemsListView.CheckedItems.Count > 25)
                {
                    SetStatusLabelAndTimer("Cannot open links for more than 20 items at a time");
                    MakeErrorSound();
                    return;
                }

                Cursor.Current = Cursors.WaitCursor;
                foreach (ListViewItem checkedItem in workflowItemsListView.CheckedItems)
                {
                    idsInList.Add(checkedItem.SubItems[1].Text);
                }
            }
            else
            {
                SetStatusLabelAndTimer("You have to check items first");
                MakeErrorSound();
                return;
            }

            // if there are ids available 
            if (idsInList != null && idsInList.Count > 0)
            {
                foreach (string id in idsInList)
                {
                    try
                    {
                        string targetURL = GetWorkflowItemFromAllByID(id).FileURL;

                        System.Diagnostics.Process.Start(targetURL);
                    }
                    catch (Exception)
                    {
                        ++urlsNotOpened;
                    }
                }
            }

            // if there were urls not opened
            if (urlsNotOpened != 0)
            {
                SetStatusLabelAndTimer($"Could not open URL/URLs for {urlsNotOpened} ID/IDs");
                MakeErrorSound();
            }

            Cursor.Current = Cursors.Default;
        }

        private void createReferencesContextMenuItem_Click(object sender, EventArgs e)
        {
            addReferenceBtn.PerformClick();
        }

        private void addToExportViewContextMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<WorkflowItem> tmpList = new List<WorkflowItem>();
            tmpList = GetWorkflowItemsFromChecked(workflowItemsListView);
            int addedCount = 0;

            if (workflowItemsListView.CheckedItems == null || workflowItemsListView.CheckedItems.Count == 0)
            {
                SetStatusLabelAndTimer("You must select items to add first", 3000);
                MakeErrorSound();
            }
            else
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    workflowItemsListView.BeginUpdate();

                    foreach (WorkflowItem item in tmpList)
                    {
                        // add only if not already on the list
                        if (!TemporaryExportList.Exists(i => i.DocumentWorkflowItemID == item.DocumentWorkflowItemID))
                        {
                            TemporaryExportList.Add(item);
                            ++addedCount;
                        }
                    }

                    SetStatusLabelAndTimer($"{addedCount} items added");
                }
                catch (Exception)
                {
                    SetStatusLabelAndTimer("Could not add items", 3000);
                    MakeErrorSound();
                }
            }

            workflowItemsListView.EndUpdate();
            Cursor.Current = Cursors.Default;
        }

        private void removeFromExportViewContextMenuItem_Click(object sender, EventArgs e)
        {
            if (workflowItemsListView.CheckedItems == null || workflowItemsListView.CheckedItems.Count == 0)
            {
                SetStatusLabelAndTimer("You must select items to remove first", 3000);
                MakeErrorSound();
            }
            else
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    int itemsRemoved = 0;

                    foreach (WorkflowItem item in GetWorkflowItemsFromChecked(workflowItemsListView))
                    {
                        TemporaryExportList.Remove(item);
                        ++itemsRemoved;
                    }

                    //UncheckAllListViewItems();

                    this.PopulateListViewData(TemporaryExportList);

                    SetStatusLabelAndTimer($"{itemsRemoved} items removed");
                }
                catch (Exception)
                {
                    SetStatusLabelAndTimer("Could not remove items", 3000);
                    MakeErrorSound();
                }
            }

            Cursor.Current = Cursors.Default;
        }

        // Item Edit (app info)
        private void paintContextMenuItem_Click(object sender, EventArgs e)
        {
            paintFromListViewBtn.PerformClick();
        }

        private void removePaintContextMenuItem_Click(object sender, EventArgs e)
        {
            removePaintBtn.PerformClick();
        }

        private void markPriorityContextMenuItem_Click(object sender, EventArgs e)
        {
            UseWaitCursor = true;

            try
            {
                itemsUpdated = 0;

                if (workflowItemsListView.SelectedItems != null && workflowItemsListView.SelectedItems.Count > 0 && workflowItemsListView.SelectedItems[0].Checked == false)
                {
                    foreach (ListViewItem selectedItem in workflowItemsListView.SelectedItems)
                    {
                        // get workflow item, change, replace
                        WorkflowItem wi = new WorkflowItem();
                        int index;
                        wi = GetWorkflowItemFromAllByID(selectedItem.SubItems[1].Text);
                        index = AllWorkflowItemsLoaded.IndexOf(wi);
                        if (!wi.ItemHasPriority)
                        {
                            wi.ItemHasPriority = true;
                            ++itemsUpdated;
                        }
                        AllWorkflowItemsLoaded[index] = wi;
                    }
                }

                if (workflowItemsListView.CheckedItems != null && workflowItemsListView.CheckedItems.Count > 0)
                {
                    foreach (ListViewItem checkedItem in workflowItemsListView.CheckedItems)
                    {
                        WorkflowItem wi = new WorkflowItem();
                        int index;
                        wi = GetWorkflowItemFromAllByID(checkedItem.SubItems[1].Text);
                        index = AllWorkflowItemsLoaded.IndexOf(wi);
                        if (!wi.ItemHasPriority)
                        {
                            wi.ItemHasPriority = true;
                            ++itemsUpdated;
                        }
                        AllWorkflowItemsLoaded[index] = wi;
                    }
                }

                SetStatusLabelAndTimer($"{itemsUpdated} items updated");
            }
            catch (NullReferenceException m)
            {
                SetStatusLabelAndTimer(m.Message);
            }
            catch (IndexOutOfRangeException m)
            {
                SetStatusLabelAndTimer(m.Message);
            }
            catch (Exception)
            {
                SetStatusLabelAndTimer("Could not process the request");
            }

            UseWaitCursor = false;
        }

        private void markExcludedContextMenuItem_Click(object sender, EventArgs e)
        {
            if (workflowItemsListView.CheckedItems == null || workflowItemsListView.CheckedItems.Count == 0)
            {
                SetStatusLabelAndTimer("You must select items first", 3000);
                MakeErrorSound();
            }
            else if (workflowItemsListView.CheckedItems.Count >= 50)
            {
                SetStatusLabelAndTimer("Cannot excluded more than 50 items at a time");
                MakeErrorSound();
            }
            else
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    workflowItemsListView.BeginUpdate();

                    //using (StreamWriter sw = File.AppendText(excludedItemsFileName))
                    //{
                    //    foreach (ListViewItem lvItem in workflowItemsListView.CheckedItems)
                    //    {
                    //        // change color
                    //        LvItemToWorkflowItem(lvItem).DisplayColor = "Black";

                    //        // append excluded items
                    //        sw.WriteLine(lvItem.SubItems[1].Text);
                    //    }
                    //}

                    List<WorkflowItem> itemsToUpdate = new List<WorkflowItem>();
                    int itemsExcluded = 0;

                    foreach (ListViewItem lvItem in workflowItemsListView.CheckedItems)
                    {
                        WorkflowItem wi = new WorkflowItem();
                        wi = LvItemToWorkflowItem(lvItem);

                        if (wi.Excluded != true)
                        {
                            wi.DisplayColor = "Black";
                            wi.Excluded = true;
                            ++itemsExcluded;
                        }
                    }

                    UpdateAllLoadedWorkflowItems(itemsToUpdate);

                    SetStatusLabelAndTimer($"{itemsExcluded} item(s) excluded");
                }
                catch (Exception)
                {
                    SetStatusLabelAndTimer("Could not process the request");
                    MakeErrorSound();
                }
            }

            workflowItemsListView.EndUpdate();
            Cursor.Current = Cursors.Default;
        }

        private void unmarkPriorityContextMenuItem_Click(object sender, EventArgs e)
        {
            UseWaitCursor = true;

            try
            {
                itemsUpdated = 0;

                if (workflowItemsListView.SelectedItems != null && workflowItemsListView.SelectedItems.Count > 0 && workflowItemsListView.SelectedItems[0].Checked == false)
                {
                    foreach (ListViewItem selectedItem in workflowItemsListView.SelectedItems)
                    {
                        // get workflow item, change, replace
                        WorkflowItem wi = new WorkflowItem();
                        int index;
                        wi = GetWorkflowItemFromAllByID(selectedItem.SubItems[1].Text);
                        index = AllWorkflowItemsLoaded.IndexOf(wi);
                        if (wi.ItemHasPriority)
                        {
                            wi.ItemHasPriority = false;
                            ++itemsUpdated;
                        }
                        AllWorkflowItemsLoaded[index] = wi;
                    }
                }

                if (workflowItemsListView.CheckedItems != null && workflowItemsListView.CheckedItems.Count > 0)
                {
                    foreach (ListViewItem checkedItem in workflowItemsListView.CheckedItems)
                    {
                        WorkflowItem wi = new WorkflowItem();
                        int index;
                        wi = GetWorkflowItemFromAllByID(checkedItem.SubItems[1].Text);
                        index = AllWorkflowItemsLoaded.IndexOf(wi);
                        if (wi.ItemHasPriority)
                        {
                            wi.ItemHasPriority = false;
                            ++itemsUpdated;
                        }
                        AllWorkflowItemsLoaded[index] = wi;
                    }
                }

                SetStatusLabelAndTimer($"{itemsUpdated} items updated");
            }
            catch (NullReferenceException m)
            {
                SetStatusLabelAndTimer(m.Message);
            }
            catch (IndexOutOfRangeException m)
            {
                SetStatusLabelAndTimer(m.Message);
            }
            catch (Exception)
            {
                SetStatusLabelAndTimer("Could not process the request");
            }

            UseWaitCursor = false;
        }

        private void unmarkExcludedContextMenuItem_Click(object sender, EventArgs e)
        {
            UseWaitCursor = true;

            try
            {
                itemsUpdated = 0;

                if (workflowItemsListView.SelectedItems != null && workflowItemsListView.SelectedItems.Count > 0 && workflowItemsListView.SelectedItems[0].Checked == false)
                {
                    foreach (ListViewItem selectedItem in workflowItemsListView.SelectedItems)
                    {
                        // get workflow item, change, replace
                        WorkflowItem wi = new WorkflowItem();
                        int index;
                        wi = GetWorkflowItemFromAllByID(selectedItem.SubItems[1].Text);
                        index = AllWorkflowItemsLoaded.IndexOf(wi);
                        if (wi.Excluded != false)
                        {
                            wi.Excluded = false;
                            ++itemsUpdated;
                        }
                        if (wi.DisplayColor == "Black") wi.DisplayColor = "Default";
                        AllWorkflowItemsLoaded[index] = wi;
                    }
                }

                if (workflowItemsListView.CheckedItems != null && workflowItemsListView.CheckedItems.Count > 0)
                {
                    foreach (ListViewItem checkedItem in workflowItemsListView.CheckedItems)
                    {
                        WorkflowItem wi = new WorkflowItem();
                        int index;
                        wi = GetWorkflowItemFromAllByID(checkedItem.SubItems[1].Text);
                        index = AllWorkflowItemsLoaded.IndexOf(wi);
                        if (wi.Excluded != false)
                        {
                            wi.Excluded = false;
                            ++itemsUpdated;
                        }
                        if (wi.DisplayColor == "Black") wi.DisplayColor = "Default";
                        AllWorkflowItemsLoaded[index] = wi;
                    }
                }

                SetStatusLabelAndTimer($"{itemsUpdated} items updated");
            }
            catch (NullReferenceException m)
            {
                SetStatusLabelAndTimer(m.Message);
            }
            catch (IndexOutOfRangeException m)
            {
                SetStatusLabelAndTimer(m.Message);
            }
            catch (Exception)
            {
                SetStatusLabelAndTimer("Could not process the request");
            }

            UseWaitCursor = false;
        }

        private void removeWarningContextMenuItem_Click(object sender, EventArgs e)
        {
            UseWaitCursor = true;

            try
            {
                itemsUpdated = 0;

                if (workflowItemsListView.SelectedItems != null && workflowItemsListView.SelectedItems.Count > 0 && workflowItemsListView.SelectedItems[0].Checked == false)
                {
                    foreach (ListViewItem selectedItem in workflowItemsListView.SelectedItems)
                    {
                        // get workflow item, change, replace
                        WorkflowItem wi = new WorkflowItem();
                        int index;
                        wi = GetWorkflowItemFromAllByID(selectedItem.SubItems[1].Text);
                        index = AllWorkflowItemsLoaded.IndexOf(wi);
                        if (wi.WorkflowItemInformationDifferentThanCertus != false)
                        {
                            wi.WorkflowItemInformationDifferentThanCertus = false;
                            ++itemsUpdated;
                        }
                        if (wi.DisplayColor == "White") wi.DisplayColor = "Default";
                        AllWorkflowItemsLoaded[index] = wi;
                    }
                }

                if (workflowItemsListView.CheckedItems != null && workflowItemsListView.CheckedItems.Count > 0)
                {
                    foreach (ListViewItem checkedItem in workflowItemsListView.CheckedItems)
                    {
                        WorkflowItem wi = new WorkflowItem();
                        int index;
                        wi = GetWorkflowItemFromAllByID(checkedItem.SubItems[1].Text);
                        index = AllWorkflowItemsLoaded.IndexOf(wi);
                        if (wi.WorkflowItemInformationDifferentThanCertus != false)
                        {
                            wi.WorkflowItemInformationDifferentThanCertus = false;
                            ++itemsUpdated;
                        }
                        if (wi.DisplayColor == "White") wi.DisplayColor = "Default";
                        AllWorkflowItemsLoaded[index] = wi;
                    }
                }

                SetStatusLabelAndTimer($"{itemsUpdated} items updated");
            }
            catch (NullReferenceException m)
            {
                SetStatusLabelAndTimer(m.Message);
            }
            catch (IndexOutOfRangeException m)
            {
                SetStatusLabelAndTimer(m.Message);
            }
            catch (Exception)
            {
                SetStatusLabelAndTimer("Could not process the request");
            }

            UseWaitCursor = false;
        }

        // Item Edit (workflow info)
        private void modifyContextMenuItem_Click(object sender, EventArgs e)
        {
            if (workflowItemsListView.CheckedItems == null || workflowItemsListView.CheckedItems.Count == 0)
            {
                SetStatusLabelAndTimer("You need checked items for that");
                MakeErrorSound();
                return;
            }

            #region Generate Form
            DimForm();
            ModifyForm = new ModifyForm();
            List<string> options = new List<string>();

            // generate options from system users
            foreach (var keyValPair in systemUserIDsDictionary)
            {
                string s = $"{keyValPair.Value} <{keyValPair.Key}>";
                options.Add(s);
            }

            DialogResult result = ModifyForm.ShowDialog();
            this.Focus();
            #endregion

            if (result == DialogResult.OK)
            {
                Application.UseWaitCursor = true;
                Application.DoEvents();

                List<WorkflowItem> itemsToUpdate = new List<WorkflowItem>();
                List<WorkflowItem> checkedItems = GetWorkflowItemsFromChecked(workflowItemsListView);

                string selectedCompany = ModifyForm.SelectedCompany;
                string selectedContract = ModifyForm.SelectedContract;
                string selectedAssignment = ModifyForm.SelectedAssignment;
                string selectedStatus = ModifyForm.SelectedStatus;
                string note = ModifyForm.Note;
                bool appendNote = ModifyForm.AppendNote;

                foreach (WorkflowItem wi in checkedItems)
                {
                    // item edit here
                    if (selectedCompany != null && selectedCompany!=String.Empty)
                    {
                        // add code for each to pull related data (ex: ids, contract info, etc...)
                        wi.VendorName = selectedCompany;
                        wi.CompanyUpdated = true;
                        itemsToUpdate.Add(wi);
                    }
                    if (selectedContract != null && selectedContract != String.Empty)
                    {
                        wi.ContractID = selectedContract;
                        wi.ContractIdOverridden = true;
                        itemsToUpdate.Add(wi);
                    }
                    if (selectedAssignment != null && selectedAssignment != String.Empty)
                    {
                        wi.AssignedToName = selectedAssignment;
                        wi.WorkflowItemInformationDifferentThanCertus = true;
                        wi.DisplayColor = "SpringGreen";
                        itemsToUpdate.Add(wi);
                    }
                    if (selectedStatus != null && selectedStatus != String.Empty)
                    {
                        wi.Status = selectedStatus;
                        wi.WorkflowItemInformationDifferentThanCertus = true;
                        wi.DisplayColor = "SpringGreen";
                        itemsToUpdate.Add(wi);
                    }
                    if (note != null && note != String.Empty)
                    {
                        if(appendNote) wi.Note += $"{note} ";
                        else wi.Note = $"{note} ";
                        itemsToUpdate.Add(wi);
                    }
                }

                UpdateAllLoadedWorkflowItems(itemsToUpdate);

                SetStatusLabelAndTimer($"Items modified");
                this.Refresh();

                Application.UseWaitCursor = false;
                Application.DoEvents();
            }
        }

        private void extractCompanyContextMenuItem_Click(object sender, EventArgs e)
        {
            if (workflowItemsListView.CheckedItems == null || workflowItemsListView.CheckedItems.Count == 0)
            {
                SetStatusLabelAndTimer("There need to be checked items for this function");
                MakeErrorSound();
                return;
            }

            if (companyDictionary == null || companyDictionary.Count == 0)
            {
                SetStatusLabelAndTimer("Companies need to be imported for this function");
                MakeErrorSound();
                return;
            }

            DimForm();
            LoadingForm = new LoadingForm();
            LoadingForm.ChangeHeaderLabel("Find Company");
            LoadingForm.ChangeLabel("Find company by");
            LoadingForm.FormatForDialog("Sender", "Subject");

            // show form
            LoadingForm.ShowDialog(TransparentForm);
            this.Focus();

            if (LoadingForm.DialogResult == DialogResult.None)
            {
                Application.UseWaitCursor = true;
                Application.DoEvents();
                SetStatusLabelAndTimer("Getting items...",true);
                this.Refresh();
                findAndFillCompanyBackgroundWorker.RunWorkerAsync("sender");
            }
            else if (LoadingForm.DialogResult == DialogResult.OK)
            {
                Application.UseWaitCursor = true;
                Application.DoEvents();
                SetStatusLabelAndTimer("Getting items...", true);
                this.Refresh();
                findAndFillCompanyBackgroundWorker.RunWorkerAsync("subject");
            }
            else if (LoadingForm.DialogResult == DialogResult.Cancel)
            {
                //UseWaitCursor = true;
                //findAndFillCompanyBackgroundWorker.RunWorkerAsync("all");
            }
        }

        private void extractContractContextMenuItem_Click(object sender, EventArgs e)
        {
            Application.UseWaitCursor = true;
            Application.DoEvents();

            if (workflowItemsListView.CheckedItems == null || workflowItemsListView.CheckedItems.Count == 0)
            {
                SetStatusLabelAndTimer("There need to be checked items for this function");
                MakeErrorSound();
                Application.UseWaitCursor = false;
                return;
            }

            if (certificateDictionary == null || certificateDictionary.Count == 0)
            {
                SetStatusLabelAndTimer("Certificates need to be imported for this function");
                MakeErrorSound();
                Application.UseWaitCursor = false;
                return;
            }

            List<WorkflowItem> checkedItems = GetWorkflowItemsFromChecked(workflowItemsListView);
            SetStatusLabelAndTimer("Getting items...", true);
            this.Refresh();
            findAndOverrideContractInformationBackgroundWorker.RunWorkerAsync(checkedItems);
        }

        private void appendCompaniesContextMenuItem_Click(object sender, EventArgs e)
        {
            Application.UseWaitCursor = true;
            Application.DoEvents();

            // if there are checked items
            if (workflowItemsListView.CheckedItems != null && workflowItemsListView.CheckedItems.Count > 0)
            {
                SetStatusLabelAndTimer("Getting items...", true);
                this.Refresh();
                fillCompanyBackgroundWorker.RunWorkerAsync();
            }
            else
            {
                SetStatusLabelAndTimer("You need to check items first");
                MakeErrorSound();
                Application.UseWaitCursor = false;
            }
        }

        private void appendContractContextMenuItem_Click(object sender, EventArgs e)
        {
            Application.UseWaitCursor = true;
            Application.DoEvents();

            // if there are checked items
            if (workflowItemsListView.CheckedItems != null && workflowItemsListView.CheckedItems.Count > 0)
            {
                SetStatusLabelAndTimer("Getting items...", true);
                this.Refresh();
                fillContractInformationBackgroundWorker.RunWorkerAsync();
            }
            else
            {
                SetStatusLabelAndTimer("You need to check items first");
                MakeErrorSound();
                Application.UseWaitCursor = false;
            }
        }

        private void appendAssignmentContextMenuItem_Click(object sender, EventArgs e)
        {
            //if (!YesOrNoMsgBox("Item changes will still need to be updated in Certus. Proceed?", "Warning")) return;

            Application.UseWaitCursor = true;
            Application.DoEvents();

            // if there are checked items
            if (workflowItemsListView.CheckedItems != null && workflowItemsListView.CheckedItems.Count > 0)
            {
                SetStatusLabelAndTimer("Getting items...", true);
                this.Refresh();
                fillAssignmentBackgroundWorker.RunWorkerAsync();
            }
            else
            {
                SetStatusLabelAndTimer("You need to check items first");
                MakeErrorSound();
                Application.UseWaitCursor = false;
            }
        }

        private void appendStatusAndAssignmentContextMenuItem_Click(object sender, EventArgs e)
        {
            if (!YesOrNoMsgBox("Item changes will still need to be updated in Certus. Proceed?", "Warning")) return;

            Application.UseWaitCursor = true;
            Application.DoEvents();

            // if there are checked items
            if (workflowItemsListView.CheckedItems != null && workflowItemsListView.CheckedItems.Count > 0)
            {
                SetStatusLabelAndTimer("Getting items...", true);
                this.Refresh();
                fillAssignmentAndStatusBackgroundWorker.RunWorkerAsync();
            }
            else
            {
                SetStatusLabelAndTimer("You need to check items first");
                MakeErrorSound();
                Application.UseWaitCursor = false;
            }
        }

        private void setAssignmentFindContextMenuItem_Click(object sender, EventArgs e)
        {
            if (workflowItemsListView.CheckedItems == null || workflowItemsListView.CheckedItems.Count == 0)
            {
                SetStatusLabelAndTimer("There need to be checked items for this function");
                MakeErrorSound();
                return;
            }

            #region Generate Form
            DimForm();
            LoadingForm = new LoadingForm();
            LoadingForm.ChangeHeaderLabel("Set Assignment");
            LoadingForm.ChangeLabel("Assign by (options sorted least to most accurate): ");
            LoadingForm.FormatForDialog("Market", "Company", "Certificate");
            LoadingForm.ShowDialog(TransparentForm);
            this.Focus();
            #endregion

            if (LoadingForm.DialogResult == DialogResult.OK)
            {
                switch (LoadingForm.SelectedRadioButton)
                {
                    case 1:
                        {
                            if (companyDictionary == null || companyDictionary.Count == 0)
                            {
                                SetStatusLabelAndTimer("Companies have not been imported");
                                MakeErrorSound();
                                return;
                            }

                            UseWaitCursor = true;
                            setAnalystFromMarketBackgroundWorker.RunWorkerAsync();
                        }
                        break;
                    case 2:
                        {
                            if (companyDictionary == null || companyDictionary.Count == 0)
                            {
                                SetStatusLabelAndTimer("Companies have not been imported");
                                MakeErrorSound();
                                return;
                            }

                            UseWaitCursor = true;
                            setAnalystFromCompanyBackgroundWorker.RunWorkerAsync();
                        }
                        break;
                    case 3:
                        {
                            if (companyDictionary == null || companyDictionary.Count == 0 || certificateDictionary == null || certificateDictionary.Count == 0)
                            {
                                SetStatusLabelAndTimer("Companies and Certificates both need to be imported for this function");
                                MakeErrorSound();
                                return;
                            }

                            UseWaitCursor = true;

                            List<WorkflowItem> checkedItems = GetWorkflowItemsFromChecked(workflowItemsListView);
                            setAnalystFromCertificateBackgroundWorker.RunWorkerAsync(checkedItems);
                        }
                        break;
                }
            }
        }

        private void setAssignmentManuallyContextMenuItem_Click(object sender, EventArgs e)
        {
            if (workflowItemsListView.CheckedItems == null || workflowItemsListView.CheckedItems.Count == 0)
            {
                SetStatusLabelAndTimer("You need checked items for that");
                MakeErrorSound();
                return;
            }

            #region Generate Form
            DimForm();
            LoadingForm = new LoadingForm();
            List<string> options = new List<string>();
            LoadingForm.ChangeHeaderLabel("Assign");
            LoadingForm.ChangeLabel("Assign to user: ");
            // generate options from system users
            foreach (var keyValPair in systemUserIDsDictionary)
            {
                string s = $"{keyValPair.Value} <{keyValPair.Key}>";
                options.Add(s);
            }
            LoadingForm.FormatForDialog(options);
            DialogResult result = LoadingForm.ShowDialog();
            this.Focus();
            #endregion

            if (result == DialogResult.OK)
            {
                Application.UseWaitCursor = true;
                Application.DoEvents();

                List<WorkflowItem> itemsToUpdate = new List<WorkflowItem>();
                List<WorkflowItem> checkedItems = GetWorkflowItemsFromChecked(workflowItemsListView);

                string selectedText = LoadingForm.SelectedComboBoxText;
                int idStartIndx = selectedText.IndexOf('<') + 1;
                int idEndIndx = selectedText.IndexOf('>') - 1;
                int idLen = idEndIndx - idStartIndx + 1;
                string idToAssign = selectedText.Substring(idStartIndx, idLen);
                string nameToAssign = selectedText.Substring(0, idStartIndx - 2);

                foreach (WorkflowItem wi in checkedItems)
                {
                    // item edit here
                    if (wi.AssignedToID == null || wi.AssignedToID != idToAssign)
                    {
                        wi.AssignedToID = idToAssign;
                        wi.AssignedToName = nameToAssign;
                        wi.WorkflowItemInformationDifferentThanCertus = true;
                        wi.DisplayColor = "SpringGreen";
                        itemsToUpdate.Add(wi);
                    }
                }

                UpdateAllLoadedWorkflowItems(itemsToUpdate);

                SetStatusLabelAndTimer($"{itemsToUpdate.Count} items assigned", true);
                this.Refresh();

                Application.UseWaitCursor = false;
                Application.DoEvents();
            }
        }

        private void unassignContextMenuItem_Click(object sender, EventArgs e)
        {
            if (workflowItemsListView.CheckedItems == null || workflowItemsListView.CheckedItems.Count == 0)
            {
                SetStatusLabelAndTimer("You must select items first");
                MakeErrorSound();
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                List<WorkflowItem> itemsToUpdate = new List<WorkflowItem>();
                int itemsUnassigned = 0;

                foreach (ListViewItem lvItem in workflowItemsListView.CheckedItems)
                {
                    WorkflowItem wi = new WorkflowItem();
                    wi = LvItemToWorkflowItem(lvItem);

                    if (wi.AssignedToName != "(Unassigned)")
                    {
                        wi.AssignedToName = "(Unassigned)";
                        wi.WorkflowItemInformationDifferentThanCertus = true;
                        wi.DisplayColor = "SpringGreen";
                        itemsToUpdate.Add(wi);
                        ++itemsUnassigned;
                    }
                }

                UpdateAllLoadedWorkflowItems(itemsToUpdate);

                SetStatusLabelAndTimer($"{itemsUnassigned} item(s) unassigned");
            }
            catch (Exception)
            {
                SetStatusLabelAndTimer("Could not process the request");
                MakeErrorSound();
            }

            Cursor.Current = Cursors.Default;
        }

        #endregion ListView Context Menu

        #endregion ListView Options

        // ----- LISTVIEW APPEARANCE AND BEHAVIOR ----- //
        #region ListView Appearance and Behavior

        private void workflowItemsListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == System.Windows.Forms.SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.workflowItemsListView.Sort();

            CountListViewItems(workflowItemsListView);

            Cursor.Current = Cursors.Default;
        }

        private void workflowItemsListView_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            try
            {
                // column reisze
                int columnToResize = emailSubjectColumnHeader.Index;

                int allOtherColumnsWidth = 0;
                int columnWidthToSet = workflowItemsListView.Columns[columnToResize].Width;
                for (int i = 0; i < workflowItemsListView.Columns.Count; i++)
                {
                    if (i != columnToResize)
                    {
                        allOtherColumnsWidth += workflowItemsListView.Columns[i].Width;
                    }
                }

                //ignoreThisResize = false;
                if (workflowItemsListView.Columns[columnToResize].Width != (workflowItemsListView.ClientSize.Width - allOtherColumnsWidth))
                    workflowItemsListView.Columns[columnToResize].Width = (workflowItemsListView.ClientSize.Width - allOtherColumnsWidth);
            }
            catch (StackOverflowException)
            {
                SetStatusLabelAndTimer("Could not resize the columns", 3000);
            }
        }

        private void workflowItemsListView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            using (var headerFont = new Font("Microsoft Sans Serif", 8))
            {
                string s = $"  {e.Header.Text}";

                e.Graphics.FillRectangle(spaceDarkBrush, workflowItemsListView.Bounds);
                e.Graphics.FillRectangle(spaceDarkBrush, e.Bounds);
                e.Graphics.DrawString(s, headerFont,
                    Brushes.Gray, e.Bounds);
            }
        }

        private void workflowItemsListView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            string idBeingDrawn = e.Item.SubItems[1].Text;
            WorkflowItem itemBeingDrawn = GetWorkflowItemFromCurrentViewByID(idBeingDrawn);
            ListViewItem lvItem = workflowItemsListView.Items[e.ItemIndex] as ListViewItem;

            try
            {
                switch (contrastItemGroups)
                {
                    case true:
                        {
                            if (e.Item.Checked || e.Item.Focused)
                            {
                                if (e.Item.Checked && checkedItemsAreFocused)
                                {
                                    //e.Graphics.FillRectangle(spaceLightOffBrush, e.Bounds);
                                    e.Item.BackColor = ThemeColors.SpaceLightOff;
                                    e.Item.ForeColor = ThemeColors.MainTheme;
                                    e.Item.UseItemStyleForSubItems = true;
                                    e.DrawDefault = true;
                                    return;
                                }
                                else if (e.Item.Checked && e.Item.Focused)
                                {
                                    //e.Graphics.FillRectangle(spaceLightOffBrush, e.Bounds);
                                    e.Item.BackColor = ThemeColors.SpaceLightOff;
                                    e.DrawFocusRectangle();
                                    //e.Graphics.FillRectangle(Brushes.LightGray, e.Bounds);
                                }
                                else if (e.Item.Focused)
                                {
                                    e.Item.BackColor = itemGroupsSortedColors[e.Item.SubItems[1].Text];
                                    e.DrawFocusRectangle();
                                    e.Graphics.FillRectangle(Brushes.LightGray, e.Bounds);
                                }
                                else if (e.Item.Checked)
                                {
                                    //e.Graphics.FillRectangle(spaceLightOffBrush, e.Bounds);
                                    e.Item.BackColor = ThemeColors.SpaceLightOff;
                                }
                            }
                            else
                            {
                                e.Item.BackColor = itemGroupsSortedColors[e.Item.SubItems[1].Text];
                            }
                        }
                        break;
                    case false:
                        {
                            if (e.Item.Checked || e.Item.Focused)
                            {
                                if (e.Item.Checked && checkedItemsAreFocused)
                                {
                                    //e.Graphics.FillRectangle(spaceLightOffBrush, e.Bounds);
                                    e.Item.BackColor = ThemeColors.SpaceLightOff;
                                    e.Item.ForeColor = ThemeColors.MainTheme;
                                    e.Item.UseItemStyleForSubItems = true;
                                    e.DrawDefault = true;
                                    return;
                                }
                                else if (e.Item.Checked && e.Item.Focused)
                                {
                                    //e.Graphics.FillRectangle(spaceLightOffBrush, e.Bounds);
                                    e.Item.BackColor = ThemeColors.SpaceLightOff;
                                    e.DrawFocusRectangle();
                                    //e.Graphics.FillRectangle(Brushes.LightGray, e.Bounds);
                                }
                                else if (e.Item.Focused)
                                {
                                    e.Item.BackColor = ThemeColors.SpaceDark;
                                    e.DrawFocusRectangle();
                                    e.Graphics.FillRectangle(Brushes.LightGray, e.Bounds);
                                }
                                else if (e.Item.Checked)
                                {
                                    //e.Graphics.FillRectangle(spaceLightOffBrush, e.Bounds);
                                    e.Item.BackColor = ThemeColors.SpaceLightOff;
                                }
                            }
                            else
                            {
                                e.Item.BackColor = ThemeColors.SpaceDark;
                            }
                        }
                        break;
                }
            }
            catch (Exception)
            {
                // just so the program doesn't crash if there's any issues drawing an item (when items get removed from the view)
            }

            if (showItemsWithColor)
            {
                if (itemBeingDrawn.DisplayColor == "Default") e.Item.ForeColor = ThemeColors.ItemDefault;
                else e.Item.ForeColor = Color.FromName(itemBeingDrawn.DisplayColor);
            }
            else e.Item.ForeColor = ThemeColors.ItemMonotone;

            // function needs these for every item to draw properly
            e.Item.UseItemStyleForSubItems = true;
            e.DrawDefault = true;
        }

        private void workflowItemsListView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (itemCheckedEventIgnored) return;

            checkedCountStatusLbl.Text = $"{workflowItemsListView.CheckedItems.Count.ToString()}";

            lastCheckedItem = e.Item;
        }

        private void workflowItemsListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                e.Item.Selected = false;
                e.Item.Focused = false;
            }
        }

        private void workflowItemsListView_MouseDown(object sender, MouseEventArgs e)
        {
            // should only be called when right clicking on checked items

            if (workflowItemsListView.Items == null || workflowItemsListView.Items.Count == 0) return;

            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    checkedItemsAreFocused = true;
                    workflowItemsListView.ItemSelectionChanged += workflowItemsListView_ItemSelectionChanged;
                }
                else
                {
                    checkedItemsAreFocused = false;
                    //workflowItemsListView.Refresh();
                    workflowItemsListView.ItemSelectionChanged -= workflowItemsListView_ItemSelectionChanged;
                }
            }
            catch (Exception)
            {
                SetStatusLabelAndTimer("Could not process the request");
            }
        }

        private void workflowItemsListView_MouseUp(object sender, MouseEventArgs e)
        {
            hoverItem = workflowItemsListView.HitTest(e.Location);

            if (workflowItemsListView.CheckedItems != null && workflowItemsListView.CheckedItems.Count > 0)
            {
                if (e.Button == MouseButtons.Left && Control.ModifierKeys == Keys.Shift)
                {
                    // focus item
                    hoverItem.Item.Focused = true;

                    string id = "";
                    shiftItemBeingChecked = new ListViewItem();

                    try
                    {
                        // get item being clicked
                        hoverItem = workflowItemsListView.HitTest(e.Location);
                        if (hoverItem.Item != null)
                        {
                            id = hoverItem.Item.SubItems[1].Text;
                        }
                        foreach (ListViewItem item in workflowItemsListView.Items)
                        {
                            if (id == item.SubItems[1].Text)
                            {
                                shiftItemBeingChecked = item;
                            }
                        }

                        int startIndex = workflowItemsListView.Items.IndexOf(lastCheckedItem);
                        int endIndex = workflowItemsListView.Items.IndexOf(shiftItemBeingChecked);

                        // check all items inbetween closest checked item and this
                        workflowItemsListView.BeginUpdate();
                        itemCheckedEventIgnored = true;

                        if (startIndex < endIndex)
                        {
                            // item is higher in list
                            for (int i = startIndex; i <= endIndex; i++)
                            {
                                workflowItemsListView.Items[i].Checked = true;
                                //workflowItemsListView.Items[endIndex].Focused = true;
                            }
                        }
                        else if (startIndex > endIndex)
                        {
                            // lower in list
                            for (int i = endIndex; i <= startIndex; i++)
                            {
                                workflowItemsListView.Items[i].Checked = true;
                                //workflowItemsListView.Items[endIndex].Focused = true;
                            }
                        }
                        else
                        {
                            // same item
                            shiftItemBeingChecked.Checked = true;
                            //workflowItemsListView.Items[endIndex].Focused = true;
                        }

                        listViewItemCheckedChanging = shiftItemBeingChecked;

                        // "select" checked items
                        // "select" items since item checked event is not being executed
                        foreach (ListViewItem item in workflowItemsListView.CheckedItems)
                        {
                            item.BackColor = Color.FromName("Highlight");
                        }

                        // invoke refresh to change current view
                        workflowItemsListView.Refresh();

                    }
                    catch (Exception)
                    {
                        SetStatusLabelAndTimer("Couldn't bulk check items", 5000);
                        MakeErrorSound();
                    }
                }

                workflowItemsListView.EndUpdate();

                // ignore last ItemChecked raise
                //isBulkCheck = true;
                itemCheckedEventIgnored = false;
                selectedIndexChangedEventIgnored = false;
            }
        }

        private void workflowItemsListView_MouseMove(object sender, MouseEventArgs e)
        {
            hoverItem = workflowItemsListView.HitTest(e.Location);
            if (hoverItem.SubItem != null && hoverItem.SubItem == hoverItem.Item.SubItems[fileUrlColumnHeader.Index])
            {
                workflowItemsListView.MouseDown += workflowItemsListView_MouseDown;
                workflowItemsListView.Cursor = Cursors.Hand;
            }
            else if (hoverItem.Item != null && hoverItem.Item.Checked == true)
            {
                workflowItemsListView.MouseDown += workflowItemsListView_MouseDown;
                workflowItemsListView.Cursor = Cursors.Default;
            }
            else if (hoverItem.Item != null && hoverItem.Item.Checked == false)
            {
                workflowItemsListView.MouseDown -= workflowItemsListView_MouseDown;
                workflowItemsListView.ItemSelectionChanged -= workflowItemsListView_ItemSelectionChanged;
                workflowItemsListView.Cursor = Cursors.Default;
            }
            else
            {
                workflowItemsListView.MouseDown -= workflowItemsListView_MouseDown;
                workflowItemsListView.ItemSelectionChanged -= workflowItemsListView_ItemSelectionChanged;
                workflowItemsListView.Cursor = Cursors.Default;
            }
        }

        private void workflowItemsListView_MouseClick(object sender, MouseEventArgs e)
        {
            //checkedItemsAreFocused = false;
            //workflowItemsListView.Refresh();

            try
            {
                clickedItem = workflowItemsListView.HitTest(e.Location);
                if (e.Button == MouseButtons.Right)
                {
                    workflowItemsListView.ItemSelectionChanged -= workflowItemsListView_ItemSelectionChanged;
                    workflowItemsListView.MouseDown -= workflowItemsListView_MouseDown;
                    clickedItem.Item.Focused = true;
                    clickedItem.Item.Selected = true;

                    listViewContextMenuStrip.Show(Cursor.Position);
                }
                if (clickedItem.SubItem != null && clickedItem.SubItem.Text != String.Empty && clickedItem.SubItem == clickedItem.Item.SubItems[fileUrlColumnHeader.Index])
                {
                    Cursor.Current = Cursors.WaitCursor;
                    string targetURL = clickedItem.Item.SubItems[fileUrlColumnHeader.Index].Text;

                    System.Diagnostics.Process.Start(targetURL);

                    //certusConnectionTimer.Enabled = false;
                    //certusConnectionRadioButton.Checked = true;
                    //certusConnectionTimer.Enabled = true;
                }

            }
            catch (Exception)
            {
                SetStatusLabelAndTimer("There was an error processing that request");
                MakeErrorSound();
            }

            Cursor.Current = Cursors.Default;
        }

        private void workflowItemsListView_KeyDown(object sender, KeyEventArgs e)
        {
            // listview key shortcuts

            try
            {
                int index = workflowItemsListView.FocusedItem.Index;

                if (workflowItemsListView.Focused == true || workflowItemsListView.FocusedItem != null)
                {
                    if (e.KeyCode == Keys.Up)
                    {
                        if (index != 0)
                        {
                            if (workflowItemsListView.Items[index].Selected == true)
                            {
                                workflowItemsListView.Items[index].Selected = false;
                                workflowItemsListView.Items[index - 1].Selected = true;
                            }

                            workflowItemsListView.FocusedItem = workflowItemsListView.Items[index - 1];
                            workflowItemsListView.FocusedItem.EnsureVisible();
                        }
                        e.Handled = true;
                    }
                    else if (e.KeyCode == Keys.Down)
                    {
                        if (index != workflowItemsListView.Items.Count - 1)
                        {
                            if (workflowItemsListView.Items[index].Selected == true)
                            {
                                workflowItemsListView.Items[index].Selected = false;
                                workflowItemsListView.Items[index + 1].Selected = true;
                            }

                            workflowItemsListView.FocusedItem = workflowItemsListView.Items[index + 1];
                            workflowItemsListView.FocusedItem.EnsureVisible();
                        }
                        e.Handled = true;
                    }
                    else if (e.KeyCode == Keys.Enter)
                    {
                        if (workflowItemsListView.SelectedItems != null && workflowItemsListView.SelectedItems.Count > 0 && index == workflowItemsListView.SelectedItems[0].Index)
                        {
                            workflowItemsListView.SelectedItems[0].Selected = false;
                        }
                        else
                        {
                            SelectItemInListView(index);
                        }
                        e.Handled = true;
                    }
                    else if (e.KeyCode == Keys.D1)
                    {
                        //if (workflowItemsListView.SelectedItems != null && workflowItemsListView.SelectedItems.Count > 0)
                        if (workflowItemsListView.FocusedItem != null)
                        {
                            WorkflowItem item = new WorkflowItem();

                            item = GetWorkflowItemFromAllByID(workflowItemsListView.FocusedItem.SubItems[1].Text);
                            item.DisplayColor = bindedColor1;
                            SetStatusLabelAndTimer($"Item '{item.DocumentWorkflowItemID}' painted {item.DisplayColor}");
                            UpdateItemButtonAppearance(item);
                            int indx = workflowItemsListView.Items.IndexOf(workflowItemsListView.FocusedItem);
                            workflowItemsListView.RedrawItems(index, index + 1, false);
                        }
                        else if (workflowItemsListView.CheckedItems != null && workflowItemsListView.CheckedItems.Count > 0)
                        {
                            List<WorkflowItem> checkedList = GetWorkflowItemsFromChecked(workflowItemsListView);

                            foreach (WorkflowItem checkedItem in checkedList)
                            {
                                checkedItem.DisplayColor = bindedColor1;
                            }

                            this.bulkCheckBtn.PerformClick();
                            SetStatusLabelAndTimer($"Items painted {bindedColor1}");
                        }
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                    }
                    else if (e.KeyCode == Keys.D2)
                    {
                        if (workflowItemsListView.FocusedItem != null)
                        {
                            WorkflowItem item = new WorkflowItem();

                            item = GetWorkflowItemFromAllByID(workflowItemsListView.FocusedItem.SubItems[1].Text);
                            item.DisplayColor = bindedColor2;
                            SetStatusLabelAndTimer($"Item '{item.DocumentWorkflowItemID}' painted Default");
                            UpdateItemButtonAppearance(item);
                            int indx = workflowItemsListView.Items.IndexOf(workflowItemsListView.FocusedItem);
                            workflowItemsListView.RedrawItems(index, index + 1, false);
                        }
                        else if (workflowItemsListView.CheckedItems != null && workflowItemsListView.CheckedItems.Count > 0)
                        {
                            List<WorkflowItem> checkedList = GetWorkflowItemsFromChecked(workflowItemsListView);

                            foreach (WorkflowItem checkedItem in checkedList)
                            {
                                checkedItem.DisplayColor = bindedColor2;
                            }

                            this.bulkCheckBtn.PerformClick();
                            SetStatusLabelAndTimer($"Items painted Default");
                        }
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                    }
                    else if (e.KeyCode == Keys.D3)
                    {
                        if (workflowItemsListView.FocusedItem != null)
                        {
                            WorkflowItem item = new WorkflowItem();

                            item = GetWorkflowItemFromAllByID(workflowItemsListView.FocusedItem.SubItems[1].Text);
                            item.DisplayColor = bindedColor3;
                            SetStatusLabelAndTimer($"Item '{item.DocumentWorkflowItemID}' painted {item.DisplayColor}");
                            UpdateItemButtonAppearance(item);
                            int indx = workflowItemsListView.Items.IndexOf(workflowItemsListView.FocusedItem);
                            workflowItemsListView.RedrawItems(index, index + 1, false);
                        }
                        else if (workflowItemsListView.CheckedItems != null && workflowItemsListView.CheckedItems.Count > 0)
                        {
                            List<WorkflowItem> checkedList = GetWorkflowItemsFromChecked(workflowItemsListView);

                            foreach (WorkflowItem checkedItem in checkedList)
                            {
                                checkedItem.DisplayColor = bindedColor3;
                            }

                            this.bulkCheckBtn.PerformClick();
                            SetStatusLabelAndTimer($"Items painted {bindedColor3}");
                        }
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                    }
                    else if (e.KeyCode == Keys.D4)
                    {
                        if (workflowItemsListView.FocusedItem != null)
                        {
                            WorkflowItem item = new WorkflowItem();

                            item = GetWorkflowItemFromAllByID(workflowItemsListView.FocusedItem.SubItems[1].Text);
                            item.DisplayColor = bindedColor4;
                            SetStatusLabelAndTimer($"Item '{item.DocumentWorkflowItemID}' painted {item.DisplayColor}");
                            UpdateItemButtonAppearance(item);
                            int indx = workflowItemsListView.Items.IndexOf(workflowItemsListView.FocusedItem);
                            workflowItemsListView.RedrawItems(index, index + 1, false);
                        }
                        else if (workflowItemsListView.CheckedItems != null && workflowItemsListView.CheckedItems.Count > 0)
                        {
                            List<WorkflowItem> checkedList = GetWorkflowItemsFromChecked(workflowItemsListView);

                            foreach (WorkflowItem checkedItem in checkedList)
                            {
                                checkedItem.DisplayColor = bindedColor4;
                            }

                            this.bulkCheckBtn.PerformClick();
                            SetStatusLabelAndTimer($"Items painted {bindedColor4}");
                        }
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                    }
                    else if (e.KeyCode == Keys.D5)
                    {
                        if (this.colorDialogSelection != null)
                        {
                            bindedColor5 = this.colorDialogSelection.Name;
                        }

                        if (workflowItemsListView.FocusedItem != null)
                        {
                            WorkflowItem item = new WorkflowItem();

                            item = GetWorkflowItemFromAllByID(workflowItemsListView.FocusedItem.SubItems[1].Text);
                            item.DisplayColor = bindedColor5;
                            SetStatusLabelAndTimer($"Item '{item.DocumentWorkflowItemID}' painted {item.DisplayColor}");
                            UpdateItemButtonAppearance(item);
                            int indx = workflowItemsListView.Items.IndexOf(workflowItemsListView.FocusedItem);
                            workflowItemsListView.RedrawItems(index, index + 1, false);
                        }
                        else if (workflowItemsListView.CheckedItems != null && workflowItemsListView.CheckedItems.Count > 0)
                        {
                            List<WorkflowItem> checkedList = GetWorkflowItemsFromChecked(workflowItemsListView);

                            foreach (WorkflowItem checkedItem in checkedList)
                            {
                                checkedItem.DisplayColor = bindedColor5;
                            }

                            this.bulkCheckBtn.PerformClick();
                            SetStatusLabelAndTimer($"Items painted {bindedColor5}");
                        }
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                    }
                    else if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
                    {
                        if (itemButtons.Any(b => b.BackColor.Name == "Highlight"))
                        {
                            (itemButtons.First(b => b.BackColor.Name == "Highlight") as Button).Focus();
                        }
                        else
                        {
                            itemButtons[1].Focus();
                        }
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                    }
                    else if (e.Control && !e.Shift && e.KeyCode == Keys.C)
                    {
                        //if (workflowItemsListView.SelectedItems != null && workflowItemsListView.SelectedItems.Count > 0)
                        //{
                        //    WorkflowItem item = new WorkflowItem();

                        //    item = GetWorkflowItemFromAllByID(workflowItemsListView.SelectedItems[0].SubItems[1].Text);
                        //    string clip = item.ToString();
                        //    Clipboard.SetText(clip);

                        //    SetStatusLabelAndTimer($"Item '{item.DocumentWorkflowItemID}' copied to clipboard");
                        //}

                        copyContextMenuItem_Click(this, null);
                    }
                    else if (e.Control && e.Shift && e.KeyCode == Keys.C)
                    {
                        copyIdsContextMenuItem_Click(this, null);
                    }
                    else if (e.Shift && e.KeyCode == Keys.Space)
                    {
                        // check all inbetween last checked and this

                        shiftItemBeingChecked = new ListViewItem();

                        try
                        {
                            // get item
                            shiftItemBeingChecked = workflowItemsListView.SelectedItems[0];

                            int startIndex = workflowItemsListView.Items.IndexOf(lastCheckedItem);
                            int endIndex = workflowItemsListView.Items.IndexOf(shiftItemBeingChecked);

                            // check all items inbetween closest checked item and this
                            workflowItemsListView.BeginUpdate();
                            itemCheckedEventIgnored = true;

                            if (startIndex < endIndex)
                            {
                                // item is higher in list
                                for (int i = startIndex; i <= endIndex; i++)
                                {
                                    workflowItemsListView.Items[i].Checked = true;
                                }
                            }
                            else if (startIndex > endIndex)
                            {
                                // lower in list
                                for (int i = endIndex; i <= startIndex; i++)
                                {
                                    workflowItemsListView.Items[i].Checked = true;
                                }
                            }
                            else
                            {
                                // same item
                                shiftItemBeingChecked.Checked = true;
                            }

                            listViewItemCheckedChanging = shiftItemBeingChecked;

                            // invoke refresh to change current view
                            workflowItemsListView.Refresh();
                        }
                        catch (Exception)
                        {
                            SetStatusLabelAndTimer("Couldn't bulk check items", 5000);
                            MakeErrorSound();
                        }

                        workflowItemsListView.EndUpdate();
                        itemCheckedEventIgnored = false;
                    }
                    else if (e.Control && !e.Shift && e.KeyCode == Keys.O)
                    {
                        openLinkContextMenuItem_Click(this, null);
                    }
                }
            }
            catch (Exception)
            {
                //SetStatusLabelAndTimer("There was an error with that keypress", 3000);
                //MakeErrorSound();

                // just don't crash
            }
        }

        private void workflowItemsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            // bypass if ignore
            if (selectedIndexChangedEventIgnored == true)
                return;

            // bypass if ignored just once
            if (ignoreThisSelectedIndexChanged == true)
            {
                ignoreThisSelectedIndexChanged = false;
                return;
            }

            try
            {
                if (workflowItemsListView.SelectedItems != null && workflowItemsListView.SelectedItems.Count > 0)
                {
                    // item should be selected
                    PopulateDetailsViewData(GetWorkflowItemFromCurrentViewByID(workflowItemsListView.SelectedItems[0].SubItems[1].Text));

                    // make main item button show the color of the selected item
                    UpdateItemButtonAppearance();

                    itemDetailsPanel.Refresh();
                }
            }
            catch (Exception)
            {
                SetStatusLabelAndTimer("Something went wrong with item selection", 3000);
                MakeErrorSound();
            }

            itemCheckedEventIgnored = false;
            //workflowItemsListView.EndUpdate();
        }

        private void workflowItemsListView_VisibleChanged(object sender, EventArgs e)
        {
            if (this.workflowItemsListView.Visible == true)
            {
                this.workflowItemsListView.ColumnWidthChanged += this.workflowItemsListView_ColumnWidthChanged;
            }
            else this.workflowItemsListView.ColumnWidthChanged -= this.workflowItemsListView_ColumnWidthChanged;
        }

        private void FocusItemInListView(string itemID)
        {
            for (int i = 0; i < workflowItemsListView.Items.Count; i++)
            {
                if (workflowItemsListView.Items[i].SubItems[1].Text == itemID)
                {
                    workflowItemsListView.Items[i].Focused = true;
                    workflowItemsListView.EnsureVisible(i);
                }
            }
        }

        private void CheckAllListViewItems()
        {
            // ignore events
            this.selectedIndexChangedEventIgnored = true;
            this.itemCheckedEventIgnored = true;

            try
            {
                foreach (ListViewItem listItem in workflowItemsListView.Items)
                {
                    listItem.Checked = true;
                }

                // invoke refresh to change current view
                workflowItemsListView.Refresh();
            }
            catch (Exception)
            {
                SetStatusLabelAndTimer("There was an issue checking the items", 3000);
                MakeErrorSound();
            }

            // unignore events
            this.selectedIndexChangedEventIgnored = false;
            this.itemCheckedEventIgnored = false;
        }

        private void UncheckAllListViewItems()
        {
            // ignore events
            this.selectedIndexChangedEventIgnored = true;
            this.itemCheckedEventIgnored = true;

            try
            {
                foreach (ListViewItem listItem in workflowItemsListView.Items)
                {
                    listItem.Checked = false;
                }

                if (workflowItemsListView.FocusedItem != null) workflowItemsListView.FocusedItem.Focused = false;

                // invoke refresh to change current view
                workflowItemsListView.Refresh();
            }
            catch (Exception)
            {
                SetStatusLabelAndTimer("There was an issue unchecking the items", 3000);
                MakeErrorSound();
            }

            // update records count
            this.SetDatabaseDetailsProperties();

            // unignore events
            this.selectedIndexChangedEventIgnored = false;
            this.itemCheckedEventIgnored = false;
        }

        public void CountListViewItems(ListView lv)
        {
            countOfListViewItems = 0;

            for (int i = 0; i < lv.Items.Count; i++)
            {
                ++countOfListViewItems;

                lv.Items[i].SubItems[0].Text = countOfListViewItems.ToString();
            }
        }

        #endregion ListView Appearance and Behavior

        // ----- ITEM DETAIL OPTIONS ----- //
        #region Item Detail Options

        #region Item Buttons/Tabs

        private void itemButton0_Click(object sender, EventArgs e)
        {
            try
            {
                if (workflowItemsListView.Focused == true || workflowItemsListView.FocusedItem != null)
                {
                    int index = workflowItemsListView.FocusedItem.Index;

                    if (workflowItemsListView.SelectedItems != null && workflowItemsListView.SelectedItems.Count > 0 && index == workflowItemsListView.SelectedItems[0].Index)
                    {
                        workflowItemsListView.SelectedItems[0].Selected = false;
                        workflowItemsListView.Focus();
                    }
                    else
                    {
                        SelectItemInListView(index);
                        workflowItemsListView.Focus();
                    }
                }
            }
            catch (Exception)
            {
                SetStatusLabelAndTimer("Could not process that request", 3000);
                MakeErrorSound();
            }
        }

        private void itemButton_Click(object sender, EventArgs e)
        {
            try
            {
                string id = ((Button)sender).Text;
                WorkflowItem item = GetWorkflowItemFromAllByID(id);
                if (workflowItemsListView.FocusedItem != null)
                    workflowItemsListView.FocusedItem.Focused = false;

                // remove all other colors and highlight this tab
                foreach (Button btn in itemButtons)
                {
                    btn.BackColor = Color.FromArgb(20, 20, 20);
                }

                ((Button)sender).BackColor = Color.FromName("Highlight");

                // populate details view if visible
                if (this.itemDetailsPanel.Visible == true)
                {
                    PopulateDetailsViewData(item);
                }

                // focus item if available
                FocusItemInListView(id);

                if (workflowItemsListView.FocusedItem == null || workflowItemsListView.FocusedItem.SubItems[1].Text != id)
                    SetStatusLabelAndTimer("Item not in current view", 2000);
                else
                    SetStatusLabelAndTimer($"Showing {id}", 5000);
            }
            catch (Exception)
            {
                SetStatusLabelAndTimer("Error with item selection");
                MakeErrorSound();
            }
        }

        private void itemButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (sender != null && ((sender as Button).Text != String.Empty || (sender as Button).Text.ToLower() != "item"))
            {
                if (e.KeyCode == Keys.Space)
                {
                    workflowItemsListView.Focus();
                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.D1)
                {
                    WorkflowItem item = new WorkflowItem();

                    item = GetWorkflowItemFromAllByID((sender as Button).Text);
                    item.DisplayColor = bindedColor1;
                    SetStatusLabelAndTimer($"Item {item.DocumentWorkflowItemID} painted {item.DisplayColor}");
                    (sender as Button).ForeColor = Color.FromName(bindedColor1);
                    //UpdateItemButtonAppearance(item);

                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
                else if (e.KeyCode == Keys.D2)
                {
                    WorkflowItem item = new WorkflowItem();

                    item = GetWorkflowItemFromAllByID((sender as Button).Text);
                    item.DisplayColor = bindedColor2;
                    SetStatusLabelAndTimer($"Item {item.DocumentWorkflowItemID} painted {item.DisplayColor}");
                    (sender as Button).ForeColor = Color.FromName(bindedColor2);
                    //UpdateItemButtonAppearance(item);

                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
                else if (e.KeyCode == Keys.D3)
                {
                    WorkflowItem item = new WorkflowItem();

                    item = GetWorkflowItemFromAllByID((sender as Button).Text);
                    item.DisplayColor = bindedColor3;
                    SetStatusLabelAndTimer($"Item {item.DocumentWorkflowItemID} painted {item.DisplayColor}");
                    (sender as Button).ForeColor = Color.FromName(bindedColor3);
                    //UpdateItemButtonAppearance(item);

                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
                else if (e.KeyCode == Keys.D4)
                {
                    WorkflowItem item = new WorkflowItem();

                    item = GetWorkflowItemFromAllByID((sender as Button).Text);
                    item.DisplayColor = bindedColor4;
                    SetStatusLabelAndTimer($"Item {item.DocumentWorkflowItemID} painted {item.DisplayColor}");
                    (sender as Button).ForeColor = Color.FromName(bindedColor4);
                    //UpdateItemButtonAppearance(item);

                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
                else if (e.KeyCode == Keys.D5)
                {
                    WorkflowItem item = new WorkflowItem();
                    if (this.colorDialogSelection != null)
                    {
                        bindedColor5 = this.colorDialogSelection.Name;
                    }

                    item = GetWorkflowItemFromAllByID((sender as Button).Text);
                    item.DisplayColor = bindedColor5;
                    SetStatusLabelAndTimer($"Item {item.DocumentWorkflowItemID} painted {item.DisplayColor}");
                    (sender as Button).ForeColor = Color.FromName(bindedColor5);
                    //UpdateItemButtonAppearance(item);

                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
        }

        private void itemButton_Enter(object sender, EventArgs e)
        {
            for (int i = 0; i < itemButtons.Length; i++)
            {
                itemButtons[i].BackColor = Color.FromArgb(20, 20, 20);
            }

            (sender as Button).PerformClick();
        }

        private void itemButton_Leave(object sender, EventArgs e)
        {
            //(sender as Button).BackColor = Color.FromArgb(20, 20, 20);
        }

        private void UnselectDataViewTabs()
        {
            // add/edit tabs here
            importsDataViewBtn.BackColor = Color.FromArgb(0, 20, 20, 20);
        }

        private void HideItemButton(int itemButton)
        {
            int visibleButtons = VisibleItemButtons();

            for (int i = itemButton; i < visibleButtons - 1; i++)
            {
                if (visibleButtons > 1)
                {
                    itemButtons[i].Text = itemButtons[i + 1].Text;
                }
            }

            itemButtons[visibleButtons - 1].Text = "item";
            itemButtons[visibleButtons - 1].Visible = false;
        }

        private int VisibleItemButtons()
        {
            int result = 0;

            for (int i = 0; i < itemButtons.Length; i++)
            {
                if (itemButtons[i].Visible == true)
                {
                    ++result;
                }
            }

            return result;
        }

        #endregion Item Buttons/Tabs

        private void closeItemButton_Click(object sender, EventArgs e)
        {
            int i = 0;
            int visibleButtons = VisibleItemButtons();

            for (i = 0; i < visibleButtons; i++)
            {
                if (itemButtons[i].Text != "Item" && itemButtons[i].BackColor == Color.FromName("Highlight"))
                {
                    // shift text of buttons to the left, make last button visible = false
                    HideItemButton(i);

                    // update next available button index but never change below 1
                    if (nextAvailableButton > 1)
                    {
                        --nextAvailableButton;
                    }
                }
            }

            visibleButtons = VisibleItemButtons();
            // move details onto next visible item
            if (visibleButtons > 1)
            {
                WorkflowItem wi;

                if (nextAvailableButton - 1 != visibleButtons)
                {
                    wi = GetWorkflowItemFromAllByID(itemButtons[nextAvailableButton - 1].Text);
                }
                else
                {
                    wi = GetWorkflowItemFromAllByID(itemButtons[nextAvailableButton - 2].Text);
                }

                // populate with said item
                PopulateDetailsViewData(wi);
            }
            else
            {
                ClearItemDetails();
            }
        }

        private void openAllLinks_Click(object sender, EventArgs e)
        {
            List<string> idsInList = new List<string>();
            int urlsNotOpened = 0;

            Cursor.Current = Cursors.WaitCursor;

            // foreach id showing HIGHLIGHTED
            foreach (Button btn in itemButtons)
            {
                if (btn.Text.ToLower() != "item" && btn.BackColor == Color.FromName("Highlight"))
                {
                    idsInList.Add(btn.Text);
                }
            }

            // if there are ids available 
            if (idsInList != null && idsInList.Count > 0)
            {
                foreach (string id in idsInList)
                {
                    try
                    {
                        string targetURL = GetWorkflowItemFromAllByID(id).FileURL;

                        System.Diagnostics.Process.Start(targetURL);

                        //certusConnectionTimer.Enabled = false;
                        //certusConnectionTimer.Enabled = true;
                    }
                    catch (Exception)
                    {
                        ++urlsNotOpened;
                    }
                }
            }

            // if there were urls not opened
            if (urlsNotOpened != 0)
            {
                SetStatusLabelAndTimer($"Could not open URL/URLs for {urlsNotOpened} ID/IDs");
                MakeErrorSound();
            }

            Cursor.Current = Cursors.Default;
        }

        private void selectAllItemsBtn_Click(object sender, EventArgs e)
        {
            //foreach (Button btn in itemButtons)
            //{
            //    if (btn.Text != "Item")
            //    {
            //        btn.Text = "item";
            //        btn.Visible = false;
            //        btn.BackColor = Color.FromArgb(20, 20, 20);
            //    }
            //}

            //nextAvailableButton = 1;

            for (int i = 0; i < itemButtons.Length; i++)
            {
                if (itemButtons[i].Text != "Item" && itemButtons[i].Visible == true)
                    itemButtons[i].BackColor = Color.FromName("Highlight");
            }
        }

        private void noteButton_Click(object sender, EventArgs e)
        {
            try
            {
                // if there's currently a note, close it
                if (CheckIfFormIsOpened("Note"))
                {
                    Note.Close();
                }

                // make a new note
                Note = new NoteForm();
                Note.Populate(GetWorkflowItemFromCurrentViewByID(documentWorkflowItemIdTbx.Text));

                DimForm();

                // show note
                Note.ShowDialog();

                // return form appearance to normal and focus the list view
                TransparentForm.Close();
                (Application.OpenForms[0] as WorkflowManager).Focus();
                (Application.OpenForms[0] as WorkflowManager).workflowItemsListView.Focus();

            }
            catch (Exception)
            {
                // close transparency form incase it opened
                if (CheckIfFormIsOpened("Transparent Form"))
                {
                    TransparentForm.Close();
                }

                // send a notification to the form and set focus to it
                (Application.OpenForms[0] as WorkflowManager).SetStatusLabelAndTimer("Could not generate the note", 5000);
                (Application.OpenForms[0] as WorkflowManager).Focus();

                // make a ding
                System.Media.SystemSounds.Hand.Play();
            }
        }

        private void copyIdsBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string copyString = "";

                foreach (Button btn in itemButtons)
                {
                    if (btn.Text.ToLower() != "item")
                    {
                        copyString += $"{btn.Text} ";
                    }
                }

                Clipboard.SetText(copyString);

                SetStatusLabelAndTimer($"'{copyString}' copied to clipboard");
            }
            catch
            {
                SetStatusLabelAndTimer("Could not copy items", 3000);
                MakeErrorSound();
            }
        }

        private void collapseToolPanelsBtn_Click(object sender, EventArgs e)
        {
            // collapsing
            if (splitContainerChild3.Visible == true)
            {
                //splitContainerChild2.Panel2Collapsed = true;
                splitContainerChild3.Visible = false;
                collapseToolPanelsBtn.BackgroundImage = CertusCompanion.Properties.Resources.icons8_open_pane_48;
            }

            // opening
            else
            {
                //splitContainerChild2.Panel2Collapsed = false;
                splitContainerChild3.Visible = true;
                collapseToolPanelsBtn.BackgroundImage = CertusCompanion.Properties.Resources.icons8_close_pane_48;
            }
        }

        private void clearItemDetailsBtn_Click(object sender, EventArgs e)
        {
            ClearItemDetails();
        }

        private void ClearItemDetails()
        {
            foreach (Control c in itemDetailsPanel.Controls)
            {
                if (c is Panel)
                {
                    foreach (Control cc in c.Controls)
                    {
                        if (cc is TextBox)
                            (cc as TextBox).Text = String.Empty;
                    }
                }
            }

            ResetStatusStrip();
        }

        private void openInCertusBtn_Click(object sender, EventArgs e)
        {
            //UseWaitCursor = true;
            // ...
            // turning on
            if (connectedToCertus && CheckIfFormIsOpened("BrowserForm"))
            {
                if (subjectTbx != null && subjectTbx.Text != String.Empty)
                {
                    CertusBrowser.OpenItemInWorkflow(documentWorkflowItemIdTbx.Text, subjectTbx.Text);
                    //openInCertusBtn.Enabled = false;
                }
                else
                {
                    UseWaitCursor = false;
                    SetStatusLabelAndTimer("You must have an item in the details view first. The item must also have a subject.");
                    MakeErrorSound();
                }
            }
            else
            {
                UseWaitCursor = false;
                SetStatusLabelAndTimer("This feature only works if you are connected with the certus browser and have it open (Tools > Certus Browser)");
                MakeErrorSound();
            }
        }

        private void detailsSaveBtn_Click(object sender, EventArgs e)
        {
            // add a field check sometime in the future
            // ...

            UseWaitCursor = true;

            try
            {
                // make sure there is an item in view
                if (documentWorkflowItemIdTbx != null && documentWorkflowItemIdTbx.Text != String.Empty)
                {
                    // save data to a new workflow item
                    SaveItemChanges(documentWorkflowItemIdTbx.Text);

                    itemDetailsChanged = false;
                    selectedIndexChangedEventIgnored = false;

                    // notify
                    SetStatusLabelAndTimer($"Changes to item '{documentWorkflowItemIdTbx.Text}' saved");
                }
                else
                {
                    SetStatusLabelAndTimer("No item is in the details view.");
                    MakeErrorSound();
                }
            }
            catch (Exception)
            {
                SetStatusLabelAndTimer("Item could not be saved. Be sure all changed fields are in the correct format");
            }

            UseWaitCursor = false;

            // that item now equals this item

            // this item's display color is now white
        }

        private void itemIsDifferentBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // get the old item position, change, replace
                WorkflowItem wi = new WorkflowItem();
                int index;
                wi = GetWorkflowItemFromAllByID(documentWorkflowItemIdTbx.Text);
                index = AllWorkflowItemsLoaded.IndexOf(wi);
                wi.WorkflowItemInformationDifferentThanCertus = false;
                AllWorkflowItemsLoaded[index] = wi;

                // hide btn
                itemIsDifferentBtn.Visible = false;
            }
            catch (NullReferenceException m)
            {
                SetStatusLabelAndTimer(m.Message);
                MakeErrorSound();
            }
            catch (IndexOutOfRangeException m)
            {
                SetStatusLabelAndTimer(m.Message);
                MakeErrorSound();
            }
            catch (Exception)
            {
                SetStatusLabelAndTimer("Could not process that request");
                MakeErrorSound();
            }
        }

        private void itemExcludedBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // get the old item position, change, replace
                WorkflowItem wi = new WorkflowItem();
                int index;
                wi = GetWorkflowItemFromAllByID(documentWorkflowItemIdTbx.Text);
                index = AllWorkflowItemsLoaded.IndexOf(wi);
                wi.Excluded = false;
                AllWorkflowItemsLoaded[index] = wi;

                // hide btn
                itemIsDifferentBtn.Visible = false;
            }
            catch (NullReferenceException m)
            {
                SetStatusLabelAndTimer(m.Message);
                MakeErrorSound();
            }
            catch (IndexOutOfRangeException m)
            {
                SetStatusLabelAndTimer(m.Message);
                MakeErrorSound();
            }
            catch (Exception)
            {
                SetStatusLabelAndTimer("Could not process that request");
                MakeErrorSound();
            }
        }

        private void contractIdOverridenBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // get the old item position, change, replace
                WorkflowItem wi = new WorkflowItem();
                int index;
                wi = GetWorkflowItemFromAllByID(documentWorkflowItemIdTbx.Text);
                index = AllWorkflowItemsLoaded.IndexOf(wi);
                wi.ContractIdOverridden = false;
                AllWorkflowItemsLoaded[index] = wi;

                // hide btn
                contractIdOverridenBtn.Visible = false;
            }
            catch (NullReferenceException m)
            {
                SetStatusLabelAndTimer(m.Message);
                MakeErrorSound();
            }
            catch (IndexOutOfRangeException m)
            {
                SetStatusLabelAndTimer(m.Message);
                MakeErrorSound();
            }
            catch (Exception)
            {
                SetStatusLabelAndTimer("Could not process that request");
                MakeErrorSound();
            }
        }

        private void contractInformationUpdatedBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // get the old item position, change, replace
                WorkflowItem wi = new WorkflowItem();
                int index;
                wi = GetWorkflowItemFromAllByID(documentWorkflowItemIdTbx.Text);
                index = AllWorkflowItemsLoaded.IndexOf(wi);
                wi.ContractInformationUpdated = false;
                AllWorkflowItemsLoaded[index] = wi;

                // hide btn
                contractInformationUpdatedBtn.Visible = false;
            }
            catch (NullReferenceException m)
            {
                SetStatusLabelAndTimer(m.Message);
                MakeErrorSound();
            }
            catch (IndexOutOfRangeException m)
            {
                SetStatusLabelAndTimer(m.Message);
                MakeErrorSound();
            }
            catch (Exception)
            {
                SetStatusLabelAndTimer("Could not process that request");
                MakeErrorSound();
            }
        }

        private void companyUpdatedBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // get the old item position, change, replace
                WorkflowItem wi = new WorkflowItem();
                int index;
                wi = GetWorkflowItemFromAllByID(documentWorkflowItemIdTbx.Text);
                index = AllWorkflowItemsLoaded.IndexOf(wi);
                wi.CompanyUpdated = false;
                AllWorkflowItemsLoaded[index] = wi;

                // hide btn
                companyUpdatedBtn.Visible = false;
            }
            catch (NullReferenceException m)
            {
                SetStatusLabelAndTimer(m.Message);
                MakeErrorSound();
            }
            catch (IndexOutOfRangeException m)
            {
                SetStatusLabelAndTimer(m.Message);
                MakeErrorSound();
            }
            catch (Exception)
            {
                SetStatusLabelAndTimer("Could not process that request");
                MakeErrorSound();
            }
        }

        private void priorityNotificationBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // get the old item position, change, replace
                WorkflowItem wi = new WorkflowItem();
                int index;
                wi = GetWorkflowItemFromAllByID(documentWorkflowItemIdTbx.Text);
                index = AllWorkflowItemsLoaded.IndexOf(wi);
                wi.ItemHasPriority = false;
                AllWorkflowItemsLoaded[index] = wi;

                // hide btn
                priorityNotificationBtn.Visible = false;
            }
            catch (NullReferenceException m)
            {
                SetStatusLabelAndTimer(m.Message);
                MakeErrorSound();
            }
            catch (IndexOutOfRangeException m)
            {
                SetStatusLabelAndTimer(m.Message);
                MakeErrorSound();
            }
            catch (Exception)
            {
                SetStatusLabelAndTimer("Could not process that request");
                MakeErrorSound();
            }
        }

        private void SaveItemChanges(string id)
        {
            WorkflowItem itemToSave = new WorkflowItem();
            itemToSave = GetWorkflowItemFromAllByID(id);
            int indexToSaveTo = AllWorkflowItemsLoaded.IndexOf(itemToSave);

            if (itemToSave.VendorName != companyNameTbx.Text && companyNameDescLbl.Text == "Company Name:")
            {
                itemToSave.VendorName = companyNameTbx.Text;
                itemToSave.CompanyUpdated = true;
            }

            if (itemToSave.ContractID != contractIdTbx.Text && contractIdDescLbl.Text == "> Contract ID:")
            {
                itemToSave.ContractID = contractIdTbx.Text;
                itemToSave.ContractInformationUpdated = true;
            }

            if (itemToSave.NextExpirationDate != null && itemToSave.NextExpirationDate.HasValue && itemToSave.NextExpirationDate.Value.ToShortDateString() != nextExpDateTbx.Text && nextExpDateDescLbl.Text == ">> Next Expiration Date:")
            {
                DateTime result;
                DateTime.TryParse(nextExpDateTbx.Text, out result);
                itemToSave.NextExpirationDate = result;
                itemToSave.ContractInformationUpdated = true;
            }

            // if there is a value in active tbx (has to be true or false or this will not go through)
            if (activeDescLbl.Text == "Active:")
            {
                if (activeTbx.Text != String.Empty)
                {
                    if (itemToSave.Active != Convert.ToBoolean(activeTbx.Text))
                    {
                        itemToSave.Active = Convert.ToBoolean(activeTbx.Text);
                        itemToSave.ContractInformationUpdated = true;
                    }
                }
                else // no value in tbx
                {
                    if (itemToSave.Active != null)
                    {
                        itemToSave.Active = null;
                        itemToSave.ContractInformationUpdated = true;
                    }
                }
            }

            // if there is a value in compliant tbx (has to be 0 or 1 or this will not go through)
            if (activeDescLbl.Text == "> Compliant:")
            {
                if (compliantTbx.Text != String.Empty)
                {
                    if (itemToSave.Compliant != Convert.ToBoolean(compliantTbx.Text))
                    {
                        itemToSave.Compliant = Convert.ToBoolean(compliantTbx.Text);
                        itemToSave.ContractInformationUpdated = true;
                    }
                }
                else // no value in tbx
                {
                    if (itemToSave.Compliant != null)
                    {
                        itemToSave.Compliant = null;
                        itemToSave.ContractInformationUpdated = true;
                    }
                }
            }

            if (itemToSave.Status != statusTbx.Text && statusDescLbl.Text == "> Status:")
            {
                itemToSave.Status = statusTbx.Text;
                itemToSave.DisplayColor = "SpringGreen";
                itemToSave.WorkflowItemInformationDifferentThanCertus = true;
            }

            if (assignedToTbx.Text == "> Assigned To:")
            {
                if (itemToSave.AssignedToName != assignedToTbx.Text)
                    itemToSave.AssignedToName = assignedToTbx.Text;

                if (itemToSave.Status == "Documentation Analyst") itemToSave.WorkflowAnalyst = itemToSave.AssignedToName;
                else if (itemToSave.Status == "Compliance Analyst") itemToSave.CompanyAnalyst = itemToSave.AssignedToName;

                itemToSave.DisplayColor = "SpringGreen";
                itemToSave.WorkflowItemInformationDifferentThanCertus = true;
            }
            else if (assignedToTbx.Text == ">> Workflow Analyst:")
            {
                if(itemToSave.WorkflowAnalyst != assignedToTbx.Text)
                itemToSave.WorkflowAnalyst = assignedToTbx.Text;

                if (itemToSave.Status == "Documentation Analyst") itemToSave.AssignedToName = itemToSave.WorkflowAnalyst;

                itemToSave.DisplayColor = "SpringGreen";
                itemToSave.WorkflowItemInformationDifferentThanCertus = true;
            }
            else if (assignedToTbx.Text == ">>> Compliance Analyst:")
            {
                if (itemToSave.CompanyAnalyst != assignedToTbx.Text)
                    itemToSave.CompanyAnalyst = assignedToTbx.Text;

                if (itemToSave.Status == "Compliance Analyst") itemToSave.AssignedToName = itemToSave.CompanyAnalyst;

                itemToSave.DisplayColor = "SpringGreen";
                itemToSave.WorkflowItemInformationDifferentThanCertus = true;
            }

            itemToSave.Note = detailNoteTbx.Text;

            AllWorkflowItemsLoaded[indexToSaveTo] = itemToSave;
        }

        //private void selectBtn_Click(object sender, EventArgs e)
        //{
        //    // not currently registered to any control
        //    try
        //    {
        //        SelectItemInListView(documentWorkflowItemIdTbx.Text);
        //    }
        //    catch (Exception)
        //    {
        //        SetStatusLabelAndTimer("Could not find item within current view", 3000);
        //        MakeErrorSound();
        //    }
        //}

        #endregion Item Detail Options

        // ----- ITEM DETAIL APPEARANCE AND BEHAVIOR ----- //
        #region Item Detail Appearance and Behavior

        private void UpdateItemButtonAppearance()
        {
            try
            {
                // make main item button show the color of the currently selected index in lv
                itemButton0.ForeColor = (workflowItemsListView.Items[workflowItemsListView.SelectedIndices[0]]).ForeColor;
            }
            catch (Exception)
            {
                SetStatusLabelAndTimer("Couldn't get item color", 3000);
                MakeErrorSound();
            }
        }

        private void UpdateItemButtonAppearance(WorkflowItem wi)
        {
            try
            {
                if(wi.DisplayColor=="Default") itemButton0.ForeColor = ThemeColors.ItemDefault;
                else itemButton0.ForeColor = Color.FromName(wi.DisplayColor);
            }
            catch (Exception)
            {
                SetStatusLabelAndTimer("Couldn't get item color", 3000);
                MakeErrorSound();
            }
        }

        private void documentWorkflowItemIdTbx_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < itemButtons.Length; i++)
            {
                itemButtons[i].BackColor = Color.FromArgb(20, 20, 20);

                if (itemButtons[i].Text == documentWorkflowItemIdTbx.Text)
                {
                    itemButtons[i].BackColor = Color.FromName("Highlight");
                }
            }

            if (documentWorkflowItemIdTbx.Text != String.Empty)
            {
                SetStatusLabelAndTimer($"Showing '{documentWorkflowItemIdTbx.Text}'", true);
            }
            else
            {
                ResetStatusStrip();
            }
        }

        #region Changing Detail Labels

        private void filesAttachedBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // return if items are > 10 or no files available
                if (Convert.ToInt32(filesAttachedTbx.Text) == 0 || filesAttachedTbx.Text == String.Empty)
                {
                    SetStatusLabelAndTimer("No items are available");
                    MakeErrorSound();
                    return;
                }
                else if (Convert.ToInt32(filesAttachedTbx.Text) > 10)
                {
                    SetStatusLabelAndTimer("Can't show more than 10 items at a time");
                    MakeErrorSound();
                    return;
                }

                string idShowing = this.documentWorkflowItemIdTbx.Text;
                WorkflowItem itemShowing = GetWorkflowItemFromAllByID(idShowing);

                if (this.filesAttachedDescLbl.Text == "> Files Attached:")
                {
                    foreach (string id in itemShowing.ItemsAttached)
                    {
                        AddReferenceButton(id);
                    }
                }
                else if (this.filesAttachedDescLbl.Text == ">> Files w/ this Size:")
                {
                    // find and store items with this file size
                    List<WorkflowItem> itemsFound = new List<WorkflowItem>();

                    WorkflowItem item = itemShowing;

                    var matchingFileSizeQuery = from i in this.AllWorkflowItemsLoaded
                                                where i.FileSize == item.FileSize
                                                select i;

                    foreach (var result in matchingFileSizeQuery)
                    {
                        itemsFound.Add(result as WorkflowItem);
                    }

                    // for each item found (will always be atleast 1) add ref button
                    foreach (WorkflowItem wi in itemsFound)
                    {
                        AddReferenceButton(wi);
                    }
                }
                else if (this.filesAttachedDescLbl.Text == ">>> Files w/ this Name:")
                {
                    List<WorkflowItem> itemsFound = new List<WorkflowItem>();

                    WorkflowItem item = itemShowing;

                    var matchingFileNameQuery = from i in this.AllWorkflowItemsLoaded
                                                where i.FileName == item.FileName
                                                select i;

                    foreach (var result in matchingFileNameQuery)
                    {
                        itemsFound.Add(result as WorkflowItem);
                    }

                    foreach (WorkflowItem wi in itemsFound)
                    {
                        AddReferenceButton(wi);
                    }
                }
            }
            catch (Exception)
            {
                SetStatusLabelAndTimer("Error processing that request");
            }
        }

        private void filesAttachedDescLbl_Click(object sender, EventArgs e)
        {
            if (this.filesAttachedDescLbl.Text == "> Files Attached:")
                this.filesAttachedDescLbl.Text = ">> Files w/ this Size:";
            else if (this.filesAttachedDescLbl.Text == ">> Files w/ this Size:")
                this.filesAttachedDescLbl.Text = ">>> Files w/ this Name:";
            else if (this.filesAttachedDescLbl.Text == ">>> Files w/ this Name:")
                this.filesAttachedDescLbl.Text = "> Files Attached:";

            if (this.documentWorkflowItemIdTbx.Text != String.Empty)
                PopulateDetailsViewData(GetWorkflowItemFromCurrentViewByID(this.documentWorkflowItemIdTbx.Text));
        }

        private void fileSizeDescLbl_Click(object sender, EventArgs e)
        {
            if (this.fileSizeDescLbl.Text == "> File Size:")
                this.fileSizeDescLbl.Text = ">> All Attachments Size:";
            else if (this.fileSizeDescLbl.Text == ">> All Attachments Size:")
                this.fileSizeDescLbl.Text = "> File Size:";

            if (this.documentWorkflowItemIdTbx.Text != String.Empty)
                PopulateDetailsViewData(GetWorkflowItemFromCurrentViewByID(this.documentWorkflowItemIdTbx.Text));
        }

        private void fileMimeDescLbl_Click(object sender, EventArgs e)
        {
            if (this.fileMimeDescLbl.Text == "> File MIME:")
                this.fileMimeDescLbl.Text = ">> File Type:";
            else if (this.fileMimeDescLbl.Text == ">> File Type:")
                this.fileMimeDescLbl.Text = "> File MIME:";

            if (this.documentWorkflowItemIdTbx.Text != String.Empty)
                PopulateDetailsViewData(GetWorkflowItemFromCurrentViewByID(this.documentWorkflowItemIdTbx.Text));
        }

        private void dateCompDescLbl_Click(object sender, EventArgs e)
        {
            if (this.dateCompDescLbl.Text == "> Date Completed:")
                this.dateCompDescLbl.Text = ">> Date Added:";
            else if (this.dateCompDescLbl.Text == ">> Date Added:")
                this.dateCompDescLbl.Text = "> Date Completed:";

            if (this.documentWorkflowItemIdTbx.Text != String.Empty)
                PopulateDetailsViewData(GetWorkflowItemFromCurrentViewByID(this.documentWorkflowItemIdTbx.Text));
        }

        private void compliantDescLbl_Click(object sender, EventArgs e)
        {
            if (this.compliantDescLbl.Text == "> Compliant:")
                this.compliantDescLbl.Text = ">> Was Compliant:";
            else if (this.compliantDescLbl.Text == ">> Was Compliant:")
                this.compliantDescLbl.Text = "> Compliant:";

            if (this.documentWorkflowItemIdTbx.Text != String.Empty)
                PopulateDetailsViewData(GetWorkflowItemFromCurrentViewByID(this.documentWorkflowItemIdTbx.Text));
        }

        private void contractIdDescLbl_Click(object sender, EventArgs e)
        {
            if (this.contractIdDescLbl.Text == "> Contract ID:")
                this.contractIdDescLbl.Text = ">> Certus ID:";
            else if (this.contractIdDescLbl.Text == ">> Certus ID:")
                this.contractIdDescLbl.Text = "> Contract ID:";

            if (this.documentWorkflowItemIdTbx.Text != String.Empty)
                PopulateDetailsViewData(GetWorkflowItemFromCurrentViewByID(this.documentWorkflowItemIdTbx.Text));
        }

        private void nextExpDateDescLbl_Click(object sender, EventArgs e)
        {
            if (this.nextExpDateDescLbl.Text == "> Issue Date:")
                this.nextExpDateDescLbl.Text = ">> Next Expiration Date:";
            else if (this.nextExpDateDescLbl.Text == ">> Next Expiration Date:")
                this.nextExpDateDescLbl.Text = "> Issue Date:";

            if (this.documentWorkflowItemIdTbx.Text != String.Empty)
                PopulateDetailsViewData(GetWorkflowItemFromCurrentViewByID(this.documentWorkflowItemIdTbx.Text));
        }

        private void assignedToDescLbl_Click(object sender, EventArgs e)
        {
            if (this.assignedToDescLbl.Text == "> Assigned To:")
            {
                this.assignedToDescLbl.Text = ">> Assigned ID:";
            }
            else if (this.assignedToDescLbl.Text == ">> Assigned ID:")
            {
                this.assignedToDescLbl.Text = ">>> Workflow Analyst:";
            }
            else if (this.assignedToDescLbl.Text == ">>> Workflow Analyst:")
            {
                this.assignedToDescLbl.Text = ">>>> Compliance Analyst:";
            }
            else if (this.assignedToDescLbl.Text == ">>>> Compliance Analyst:")
            {
                this.assignedToDescLbl.Text = "> Assigned To:";
            }

            if (this.documentWorkflowItemIdTbx.Text != String.Empty)
                PopulateDetailsViewData(GetWorkflowItemFromCurrentViewByID(this.documentWorkflowItemIdTbx.Text));
        }

        private void statusDescLbl_Click(object sender, EventArgs e)
        {
            if (this.statusDescLbl.Text == "> Status:")
                this.statusDescLbl.Text = ">> Display Color:";
            else if (this.statusDescLbl.Text == ">> Display Color:")
                this.statusDescLbl.Text = "> Status:";

            if (this.documentWorkflowItemIdTbx.Text != String.Empty)
                PopulateDetailsViewData(GetWorkflowItemFromCurrentViewByID(this.documentWorkflowItemIdTbx.Text));
        }

        private void changeableDescLbl_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }

        #endregion Changing Detail Labels

        #endregion Item Detail Appearance and Behavior

        // ----- QUERY PANEL ----- //
        #region Query Panel

        #region Query Options

        private void checkAllItemsInListBtn_Click(object sender, EventArgs e)
        {
            int itemsNotChecked = 0;

            Cursor.Current = Cursors.WaitCursor;

            this.workflowItemsListView.BeginUpdate();

            try
            {
                // check to make sure everything needed is there before proceeding
                if (queriedItemList == null || queriedItemList.Count == 0)
                {
                    SetStatusLabelAndTimer("You must query items first", 3000);
                    MakeErrorSound();
                    return;
                }

                foreach (WorkflowItem item in queriedItemList)
                {
                    try
                    {
                        workflowItemsListView.FindItemWithText(item.DocumentWorkflowItemID, true, 0, false).Checked = true;
                    }
                    catch (Exception)
                    {
                        ++itemsNotChecked;
                    }
                }

                if (itemsNotChecked == 0)
                {
                    SetStatusLabelAndTimer($"{workflowItemsListView.CheckedItems.Count} items checked", true);
                }
                else if (itemsNotChecked != 0 && workflowItemsListView.CheckedItems.Count != 0)
                {
                    SetStatusLabelAndTimer($"{workflowItemsListView.CheckedItems.Count} items checked, {itemsNotChecked} items could not be found", true);
                }
                else if (workflowItemsListView.CheckedItems.Count == 0)
                {
                    SetStatusLabelAndTimer($"None of the items could be found in the current view", true);
                }
            }
            catch (Exception)
            {
                SetStatusLabelAndTimer("Something went wrong with checking the items");
                MakeErrorSound();
            }

            this.workflowItemsListView.EndUpdate();

            Cursor.Current = Cursors.Default;
        }

        private void paintFromQueryBtn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            this.workflowItemsListView.BeginUpdate();

            int itemsPainted = 0;
            List<WorkflowItem> itemsToPaint = new List<WorkflowItem>();

            if (queriedItemList == null || queriedItemList.Count == 0)
            {
                SetStatusLabelAndTimer("You must query items first", 3000);
                MakeErrorSound();
                return;
            }

            // for each item in the query
            foreach (WorkflowItem wfItem in queriedItemList)
            {
                WorkflowItem item = wfItem;

                // count only if not the color
                if (item.DisplayColor != colorDialogSelection.Name)
                {
                    ++itemsPainted;
                }

                // change dbItem color
                item.DisplayColor = colorDialogSelection.Name;

                // add item to itemsToPaint
                itemsToPaint.Add(item);
            }

            // update allLoadedItems
            try
            {
                UpdateAllLoadedWorkflowItems(itemsToPaint);
            }
            catch (Exception)
            {
                SetStatusLabelAndTimer("Could not update the items' display color", 3000);
                MakeErrorSound();
            }

            this.workflowItemsListView.EndUpdate();

            SetStatusLabelAndTimer($"{itemsPainted} items painted");

            Cursor.Current = Cursors.Default;
        }

        private void quickFindQueryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.previewQueryComboBox.Text)
            {
                case "Images":
                    this.querySelectComboBox.Text = "Items";
                    this.queryFromComboBox.Text = "Non-completed";
                    this.queryWhereComboBox.Text = "Image attached & not alone";
                    break;
                case "Req Tmp":
                    this.querySelectComboBox.Text = "Items";
                    this.queryFromComboBox.Text = "Non-completed";
                    this.queryWhereComboBox.Text = "Req Tmp attached & not alone";
                    break;
                case "Same COI":
                    this.querySelectComboBox.Text = "Items";
                    this.queryFromComboBox.Text = "Non-completed";
                    this.queryWhereComboBox.Text = "COI attached & file name matches any in DB (all)";
                    break;
                case "Clutter":
                    this.querySelectComboBox.Text = "Item Groups";
                    this.queryFromComboBox.Text = "Non-completed";
                    this.queryWhereComboBox.Text = "Email date & file size match (all)";
                    break;
                case "No Attach":
                    this.querySelectComboBox.Text = "Items";
                    this.queryFromComboBox.Text = "Non-completed";
                    this.queryWhereComboBox.Text = "No attachments";
                    break;
                case "Auto Reply":
                    this.SetStatusLabelAndTimer("That query has not been set up yet");
                    MakeErrorSound();
                    return;
                default:
                    break;
            }

            viewQueryBtn.PerformClick();
        }

        private void clearQueryOptionsBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.querySelectComboBox.SelectedIndex = -1;
                this.queryFromComboBox.SelectedIndex = -1;
                this.queryWhereComboBox.SelectedIndex = -1;
                this.queryIncludeExcludedCheckBox.Checked = false;
                this.queriedItemList.Clear();
                this.queriedItemsListbox.DataSource = null;
                this.queriedItemsListbox.DataSource = queriedItemsListbox;
            }
            catch (Exception)
            {
                SetStatusLabelAndTimer("No queried items");
            }
        }

        #endregion Query Options

        #region Queries

        private void Query()
        {
            List<WorkflowItem> fromList = new List<WorkflowItem>();
            uniqueWorkflowItems = new List<WorkflowItem>();
            queriedItemList = new List<WorkflowItem>();
            IEnumerable<WorkflowItem> results = null;
            string queryListsToConstruct = "";

            // get correct fromList 
            if (fromSelection == "All Workflow")
                fromList = this.AllWorkflowItemsLoaded;
            else if (fromSelection == "Non-completed")
                fromList = this.CurrentWorkflowItems;
            else if (fromSelection == "Current View")
                fromList = this.workflowItemListPopulated;

            // notify status
            SetStatusLabelAndTimer("Running the query", true);

            // determine query to run 
            if (whereSelection.StartsWith("Email dates match "))
            {
                results = QueryMatchingEmailDates(fromList);
                queryListsToConstruct = "advanced - 1 condition";
            }
            else if (whereSelection.StartsWith("File sizes match "))
            {
                results = QueryMatchingFileSizes(fromList);
                queryListsToConstruct = "advanced - 1 condition";
            }
            else if (whereSelection.StartsWith("File names"))
            {
                results = QueryMatchingFileNames(fromList);
                queryListsToConstruct = "advanced - 1 condition";
            }
            else if (whereSelection.StartsWith("Email subjects match "))
            {
                results = QueryMatchingEmailSubjects(fromList);
                queryListsToConstruct = "advanced - 1 condition";
            }
            else if (whereSelection.StartsWith("Email date & file size match "))
            {
                results = QueryMatchingEmailDatesAndFileSizes(fromList);
                queryListsToConstruct = "advanced - 2 conditions (and)";
            }
            else if (whereSelection.StartsWith("COI attached &"))
            {
                results = QueryDuplicateCOIs(fromList);
                queryListsToConstruct = "advanced - coi";
            }
            else if (whereSelection.StartsWith("COI attached"))
            {
                results = QueryCOI(fromList);
                queryListsToConstruct = "normal";
            }
            else if (whereSelection == "ENDTs attached & auto")
            {
                results = QueryAutoEndts(fromList);
                queryListsToConstruct = "normal";
            }
            else if (whereSelection == "ENDTs attached")
            {
                results = QueryEndts(fromList);
                queryListsToConstruct = "normal";
            }
            else if (whereSelection == "Image attached & not alone")
            {
                results = QueryImagesNotAlone(fromList);
                queryListsToConstruct = "normal";
            }
            else if (whereSelection == "Image attached")
            {
                results = QueryImages(fromList);
                queryListsToConstruct = "normal";
            }
            else if (whereSelection == "Req Tmp attached & not alone")
            {
                results = QueryReqTemplatesNotAlone(fromList);
                queryListsToConstruct = "normal";
            }
            else if (whereSelection == "Req Tmp attached")
            {
                results = QueryReqTemplates(fromList);
                queryListsToConstruct = "normal";
            }
            else if (whereSelection == "Item contract active")
            {
                results = QueryActiveContracts(fromList);
                queryListsToConstruct = "normal";
            }
            else if (whereSelection == "Item contract inactive")
            {
                results = QueryInactiveContracts(fromList);
                queryListsToConstruct = "normal";
            }
            else if (whereSelection == "Item contract information updated")
            {
                results = QueryContractInformationUpdated(fromList);
                queryListsToConstruct = "normal";
            }
            else if (whereSelection == "Item contract information not updated")
            {
                results = QueryContractInformationNotUpdated(fromList);
                queryListsToConstruct = "normal";
            }
            else if (whereSelection == "Item contract overridden")
            {
                results = QueryContractOverridden(fromList);
                queryListsToConstruct = "normal";
            }
            else if (whereSelection == "Item contract not overridden")
            {
                results = QueryContractNotOverridden(fromList);
                queryListsToConstruct = "normal";
            }
            else if (whereSelection == "Item company exists")
            {
                results = QueryCompanyExists(fromList);
                queryListsToConstruct = "normal";
            }
            else if (whereSelection == "Item company missing")
            {
                results = QueryCompanyMissing(fromList);
                queryListsToConstruct = "normal";
            }
            else if (whereSelection == "Item company updated")
            {
                results = QueryCompanyUpdated(fromList);
                queryListsToConstruct = "normal";
            }
            else if (whereSelection == "Item company not updated")
            {
                results = QueryCompanyNotUpdated(fromList);
                queryListsToConstruct = "normal";
            }
            else if (whereSelection == "Item assigned")
            {
                results = QueryItemsAssigned(fromList);
                queryListsToConstruct = "normal";
            }
            else if (whereSelection == "Item unassigned")
            {
                results = QueryItemsUnassigned(fromList);
                queryListsToConstruct = "normal";
            }
            else if (whereSelection == "Item status completed")
            {
                results = QueryItemsStatusCompleted(fromList);
                queryListsToConstruct = "normal";
            }
            else if (whereSelection == "Item status not completed")
            {
                results = QueryItemsStatusNotCompleted(fromList);
                queryListsToConstruct = "normal";
            }
            else if (whereSelection == "Item status 'Email Received'")
            {
                results = QueryItemsStatusEmailReceived(fromList);
                queryListsToConstruct = "normal";
            }
            else if (whereSelection == "Item excluded")
            {
                results = QueryItemsExcluded(fromList);
                queryListsToConstruct = "normal";
            }
            else if (whereSelection == "Item information different from certus")
            {
                results = QueryItemsDifferentThanCertus(fromList);
                queryListsToConstruct = "normal";
            }
            else if (whereSelection == "Item assignment colors")
            {
                results = QueryItemsAssignmentColors(fromList);
                queryListsToConstruct = "normal";
            }
            else if (whereSelection == "Item colors not gray")
            {
                results = QueryItemsNotGray(fromList);
                queryListsToConstruct = "normal";
            }
            //else if (whereSelection == "Item colors not white")
            //{
            //    results = QueryItemsNotWhite(fromList);
            //    queryListsToConstruct = "normal";
            //}
            else if (whereSelection == "Item has priority")
            {
                results = QueryItemsPriority(fromList);
                queryListsToConstruct = "normal";
            }
            else if (whereSelection == "Item does not have priority")
            {
                results = QueryItemsNotPriority(fromList);
                queryListsToConstruct = "normal";
            }
            else if (whereSelection == "No attachments")
            {
                results = QueryItemsWithNoAttachments(fromList);
                queryListsToConstruct = "normal";
            }
            else if (whereSelection == "")
            {
                queriedItemList.AddRange(fromList);
            }

            // notify status
            SetStatusLabelAndTimer("Putting together the list of items", true);

            // construct queried items list
            if (queryListsToConstruct == "normal")
            {
                NormalQueriedItemsLists(results);
            }
            else if (queryListsToConstruct == "advanced - coi")
            {
                AdvancedQueriedItemsListsOneCondition(results, this.AllWorkflowItemsLoaded, whereSelection);
            }
            else if (queryListsToConstruct == "advanced - 1 condition")
            {
                AdvancedQueriedItemsListsOneCondition(results, fromList, whereSelection);
            }
            else if (queryListsToConstruct == "advanced - 2 conditions (and)")
            {
                AdvancedQueriedItemsListsTwoConditionsAnd(results, fromList, whereSelection);
            }

            // if checkbox is checked/unchecked, make a new list with/without those items and replace
            if (this.showExcludedItems == false)
            {
                List<WorkflowItem> itemsToReplace = new List<WorkflowItem>();

                // notify status
                SetStatusLabelAndTimer("Removing inactive items", true);

                // find the items to replace
                foreach (WorkflowItem item in queriedItemList)
                {
                    if (item.DisplayColor != "Gray" && item.DisplayColor != "Silver" && item.DisplayColor != "Black")
                    {
                        itemsToReplace.Add(item);
                    }
                }

                // replace list
                queriedItemList = itemsToReplace;
            }

            // if selecting items & connected, add all items with the same sender and email date for each
            if (this.selectSelection == "Item Groups")
            {
                List<WorkflowItem> itemsAndConnected = new List<WorkflowItem>();

                // notify status
                SetStatusLabelAndTimer("Adding each item's connected attachments", true);

                foreach (WorkflowItem item in queriedItemList)
                {
                    var connectedItemsQuery = from i in this.AllWorkflowItemsLoaded
                                              where i.EmailFromAddress == item.EmailFromAddress && i.EmailDate == item.EmailDate
                                              select i;

                    // for the workflow items querying from
                    foreach (WorkflowItem wi in connectedItemsQuery)
                    {
                        // if the workflow item isn't already on the list
                        if (!itemsAndConnected.Contains(wi))
                        {
                            // add to list
                            itemsAndConnected.Add(wi);
                        }
                    }
                }

                // replace list
                queriedItemList = itemsAndConnected;
            }

            // notify status
            SetStatusLabelAndTimer("Sorting the list", true);

            // sort the list (for now sort by ID as default, but consider adding options for this)
            queriedItemList = queriedItemList.OrderBy(i => i.DocumentWorkflowItemID).ToList();
        }

        private void NormalQueriedItemsLists(dynamic results)
        {
            foreach (var result in results)
            {
                if (!queriedItemList.Contains(result))
                {
                    queriedItemList.Add(result);
                }
            }
        }

        private void AdvancedQueriedItemsListsOneCondition(dynamic results, List<WorkflowItem> fromList, string whereSelection)
        {
            string property = "";

            // extract property being queried from the whereSelection
            if (whereSelection.StartsWith("Email dates"))
            {
                property = "EmailDate";
            }
            else if (whereSelection.StartsWith("File size"))
            {
                property = "FileSize";
            }
            else if (whereSelection.ToLower().Contains("file name"))
            {
                property = "FileName";
            }
            else if (whereSelection.StartsWith("Email Subject"))
            {
                property = "SubjectLine";
            }

            // results should be the duplicate items
            foreach (var result in results)
            {
                queriedItemList.Add(result);
            }

            if (whereSelection.EndsWith("(all)"))
            {
                queriedItemList = queriedItemList.OrderBy(i => i.DocumentWorkflowItemID).ToList();
                originalItems.Clear();

                foreach (WorkflowItem wi in fromList)
                {
                    // if the fileName exists on the queried items list
                    if (queriedItemList.Exists(i => i.GetType().GetProperty(property).GetValue(i, null).ToString() == wi.GetType().GetProperty(property).GetValue(wi, null).ToString()))
                    {
                        // if the item isn't on the queried item list
                        if (!queriedItemList.Contains(wi))
                        {
                            // if the fileName hasn't already been added to the originals and the fileName isn't for this item
                            if (!originalItems.Exists(i => i.GetType().GetProperty(property).GetValue(i, null).ToString() == wi.GetType().GetProperty(property).GetValue(wi, null).ToString()))
                            {
                                // add to list
                                originalItems.Add(wi);
                            }
                        }
                    }
                }

                // save dup and original items
                this.dupsAndOriginals.Clear();
                this.dupsAndOriginals.AddRange(originalItems);
                this.dupsAndOriginals.AddRange(queriedItemList);

                // save dup items (results from the original query)
                this.dupItems.Clear();
                this.dupItems = queriedItemList;

                // change list
                queriedItemList = dupsAndOriginals;
            }
            else if (whereSelection.EndsWith("(first)"))
            {
                // same code block as above, until 'save dup and...'
                queriedItemList = queriedItemList.OrderBy(i => i.DocumentWorkflowItemID).ToList();
                originalItems.Clear();

                foreach (WorkflowItem wi in fromList)
                {
                    // if the fileName exists on the queried items list
                    if (queriedItemList.Exists(i => i.GetType().GetProperty(property).GetValue(i, null).ToString() == wi.GetType().GetProperty(property).GetValue(wi, null).ToString()))
                    {
                        // if the item isn't on the queried item list
                        if (!queriedItemList.Contains(wi))
                        {
                            // if the fileName hasn't already been added to the originals and the fileName isn't for this item
                            if (!originalItems.Exists(i => i.GetType().GetProperty(property).GetValue(i, null).ToString() == wi.GetType().GetProperty(property).GetValue(wi, null).ToString()))
                            {
                                // add to list
                                originalItems.Add(wi);
                            }
                        }
                    }
                }

                queriedItemList = originalItems;
            }
            else if (whereSelection.EndsWith("(duplicate)"))
            {
                // list is already set to duplicate items
            }
        }

        private void AdvancedQueriedItemsListsTwoConditionsAnd(dynamic results, List<WorkflowItem> fromList, string whereSelection)
        {
            //string property1 = "";
            //string property2 = "";

            // extract property being queried from the whereSelection
            if (whereSelection.StartsWith("Email date & file size"))
            {
                //property1 = "EmailDate";
                //property2 = "FileSize";
            }

            // results should be the duplicate items
            foreach (var result in results)
            {
                queriedItemList.Add(result);
            }

            // ...

            //if (whereSelection.EndsWith("(all)"))
            //{
            queriedItemList = queriedItemList.OrderBy(i => i.DocumentWorkflowItemID).ToList();

            //originalItems.Clear();

            //foreach (WorkflowItem wi in fromList)
            //{
            //    // if the fileName exists on the queried items list
            //    if (queriedItemList.Exists(i => i.GetType().GetProperty(property1).GetValue(i, null).ToString() == wi.GetType().GetProperty(property1).GetValue(wi, null).ToString()))
            //    {
            //        // if the item isn't on the queried item list
            //        if (!queriedItemList.Contains(wi))
            //        {
            //            // if the fileName hasn't already been added to the originals and the fileName isn't for this item
            //            if (!originalItems.Exists(i => i.GetType().GetProperty(property1).GetValue(i, null).ToString() == wi.GetType().GetProperty(property1).GetValue(wi, null).ToString()))
            //            {
            //                // add to list
            //                originalItems.Add(wi);
            //            }
            //        }
            //    }
            //}

            //// save dup and original items
            //this.dupsAndOriginals.Clear();
            //this.dupsAndOriginals.AddRange(originalItems);
            //this.dupsAndOriginals.AddRange(queriedItemList);

            //// save dup items (results from the original query)
            //this.dupItems.Clear();
            //this.dupItems = queriedItemList;

            //// change list
            //queriedItemList = dupsAndOriginals;
            //}
            //else if (whereSelection.EndsWith("(first)"))
            //{
            //    Type type = GetType().GetProperty(property1).ReflectedType;
            //    Type type2 = GetType().GetProperty(property2).ReflectedType;

            //    // same block of code as above until 'save dup and...'
            //    originalItems.Clear();

            //    foreach (WorkflowItem result in results)
            //    {
            //        var resultsQuery = from i in fromList
            //                           where i.GetType().GetProperty(property1).ToString() == result.GetType().GetProperty(property1).ToString() &&
            //                                 i.GetType().GetProperty(property2).ToString() == result.GetType().GetProperty(property2).ToString()
            //                           group i by new { i.DocumentWorkflowItemID, type = i.GetType().GetProperty(property1).ToString(), type2 = i.GetType().GetProperty(property2).ToString() } into g
            //                           select g.ToList().First();

            //        foreach (WorkflowItem rslt in resultsQuery)
            //        {
            //            if (!originalItems.Contains(rslt))
            //            {
            //                originalItems.Add(rslt);
            //            }
            //        }
            //    }

            //    queriedItemList = originalItems;
            //}
            //else if (whereSelection.EndsWith("(duplicate)"))
            //{
            //    // list is already set to duplicate items
            //}
        }

        private dynamic QueryMatchingEmailDates(List<WorkflowItem> listToQuery)
        {
            // query the list
            var query = from i in listToQuery
                        group i by i.EmailDate into g
                        select g.ToList().First();

            // set or update the unique items list
            foreach (var item in query)
            {
                uniqueWorkflowItems.Add(item);
            }

            // save unique items' ids
            var uniqueIDs = new HashSet<string>(uniqueWorkflowItems.Select(o => o.DocumentWorkflowItemID));


            // query for the items which don't match these ids
            var results = from item in listToQuery
                          where !(uniqueIDs.Contains(item.DocumentWorkflowItemID))
                          select item;

            return results;
        }

        private dynamic QueryMatchingFileSizes(List<WorkflowItem> listToQuery)
        {
            // query the list
            var query = from i in listToQuery
                        group i by i.FileSize into g
                        select g.ToList().First();

            // set or update the unique items list
            foreach (var item in query)
            {
                uniqueWorkflowItems.Add(item);
            }

            // save unique items' ids
            var uniqueIDs = new HashSet<string>(uniqueWorkflowItems.Select(o => o.DocumentWorkflowItemID));


            // query for the items which don't match these ids
            var results = from item in listToQuery
                          where !(uniqueIDs.Contains(item.DocumentWorkflowItemID))
                          select item;

            return results;
        }

        private dynamic QueryMatchingFileNames(List<WorkflowItem> listToQuery)
        {
            // query the list
            var query = from i in listToQuery
                        group i by i.FileName into g
                        select g.ToList().First();

            // set or update the unique items list
            foreach (var item in query)
            {
                uniqueWorkflowItems.Add(item);
            }

            // save unique items' ids
            var uniqueIDs = new HashSet<string>(uniqueWorkflowItems.Select(o => o.DocumentWorkflowItemID));


            // query for the items which don't match these ids
            var results = from item in listToQuery
                          where !(uniqueIDs.Contains(item.DocumentWorkflowItemID))
                          select item;

            return results;
        }

        private dynamic QueryMatchingEmailSubjects(List<WorkflowItem> listToQuery)
        {
            // query the list
            var query = from i in listToQuery
                        group i by i.SubjectLine into g
                        select g.ToList().First();

            // set or update the unique items list
            foreach (var item in query)
            {
                uniqueWorkflowItems.Add(item);
            }

            // save unique items' ids
            var uniqueIDs = new HashSet<string>(uniqueWorkflowItems.Select(o => o.DocumentWorkflowItemID));


            // query for the items which don't match these ids
            var results = from item in listToQuery
                          where !(uniqueIDs.Contains(item.DocumentWorkflowItemID))
                          select item;

            return results;
        }

        private dynamic QueryMatchingEmailDatesAndFileSizes(List<WorkflowItem> listToQuery)
        {
            List<WorkflowItem> tmpList = new List<WorkflowItem>();

            // query the list
            var query = from i in listToQuery
                        where listToQuery.Exists(wi => wi.EmailDate == i.EmailDate && wi.FileSize == i.FileSize && wi != i)
                        select i;

            // translate new list of workflow items with only ids to full workflow items
            foreach (WorkflowItem wi in query)
            {
                if (!tmpList.Contains(wi))
                {
                    tmpList.Add(wi);
                }
            }

            // ...

            //// set or update the unique items list
            //foreach (var item in tmpList)
            //{
            //    uniqueWorkflowItems.Add(item);
            //}

            //// save unique items' ids
            //var uniqueIDs = new HashSet<string>(uniqueWorkflowItems.Select(o => o.DocumentWorkflowItemID));


            //// query for the items which don't match these ids
            //var results = from item in listToQuery
            //              where !(uniqueIDs.Contains(item.DocumentWorkflowItemID))
            //              select item;

            //return results;

            return tmpList;
        }

        private dynamic QueryCOI(List<WorkflowItem> listToQuery)
        {
            var results = from item in listToQuery
                          where FilterFileName(item.FileName) == false
                          select item;

            return results;
        }

        private dynamic QueryDuplicateCOIs(List<WorkflowItem> listToQuery) // ***need to change this to listToQuery
        {
            // query the list
            var queryAllItems = from o in listToQuery
                                group o by o.FileName into g
                                select g.ToList().First();

            // set or update the unique items list
            foreach (var item in queryAllItems)
            {
                WorkflowItem tmp = item;
                uniqueWorkflowItems.Add(tmp);
            }

            // if an item is listed in the unique items, run a query to set excluded IDs
            var excludedIDs = new HashSet<string>(uniqueWorkflowItems.Select(o => o.DocumentWorkflowItemID));

            // if the excluded items are available

            // query to remove items with excluded IDs, filtered filenames, filtered subjects, and loaded in excluded IDs (excludedItems)
            var results = from item in listToQuery
                          where !(excludedIDs.Contains(item.DocumentWorkflowItemID)) &&
                                FilterFileName(item.FileName) &&
                                FilterSubject(item.SubjectLine)
                          select item;

            return results;

        }

        private dynamic QueryEndts(List<WorkflowItem> listToQuery)
        {
            var results = from item in listToQuery
                          where !FilterFileName(item.FileName)
                          select item;

            return results;
        }

        private dynamic QueryAutoEndts(List<WorkflowItem> listToQuery)
        {
            var results = from item in listToQuery
                          where !FilterFileName(item.FileName) &&
                                item.FileName.ToLower().Contains("auto")
                          select item;

            return results;
        }

        private dynamic QueryImages(List<WorkflowItem> listToQuery)
        {
            var results = from item in listToQuery
                          where (item.FileName.ToLower().EndsWith(".png") ||
                                 item.FileName.ToLower().EndsWith(".jpeg") ||
                                 item.FileName.ToLower().EndsWith(".jfif") ||
                                 item.FileName.ToLower().EndsWith(".exif") ||
                                 item.FileName.ToLower().EndsWith(".tiff") ||
                                 item.FileName.ToLower().EndsWith(".gif") ||
                                 item.FileName.ToLower().EndsWith(".bmp") ||
                                 item.FileName.ToLower().EndsWith(".jpg"))
                          select item;

            return results;
        }

        private dynamic QueryImagesNotAlone(List<WorkflowItem> listToQuery)
        {
            var results = from item in listToQuery
                          where (item.FileName.ToLower().EndsWith(".png") ||
                                 item.FileName.ToLower().EndsWith(".jpeg") ||
                                 item.FileName.ToLower().EndsWith(".jfif") ||
                                 item.FileName.ToLower().EndsWith(".exif") ||
                                 item.FileName.ToLower().EndsWith(".tiff") ||
                                 item.FileName.ToLower().EndsWith(".gif") ||
                                 item.FileName.ToLower().EndsWith(".bmp") ||
                                 item.FileName.ToLower().EndsWith(".jpg")) &&
                                 ImageNotAlone(listToQuery, item)
                          select item;

            return results;
        }

        private bool ImageNotAlone(List<WorkflowItem> listToQuery, WorkflowItem imageWorkflowItem)
        {
            imageWorkflowItems = new List<WorkflowItem>();
            imageWorkflowItems.AddRange(listToQuery);
            imageWorkflowItems.Remove(imageWorkflowItem);

            bool val = imageWorkflowItems.Exists(x => x.EmailDate == imageWorkflowItem.EmailDate);
            return val;
        }

        private dynamic QueryReqTemplates(List<WorkflowItem> listToQuery)
        {
            var results = from item in listToQuery
                          where (item.FileName.ToLower().Contains("requirement") ||
                          item.FileName.ToLower().Contains("template"))
                          select item;

            return results;
        }

        private dynamic QueryReqTemplatesNotAlone(List<WorkflowItem> listToQuery)
        {
            var results = from item in listToQuery
                          where (item.FileName.ToLower().Contains("requirement") ||
                          item.FileName.ToLower().Contains("template")) &&
                            RequirementNotAlone(listToQuery, item)
                          select item;

            return results;
        }

        private bool RequirementNotAlone(List<WorkflowItem> listToQuery, WorkflowItem requirementWorkflowItem)
        {
            requirementWorkflowItems = new List<WorkflowItem>();
            requirementWorkflowItems.AddRange(listToQuery);
            requirementWorkflowItems.Remove(requirementWorkflowItem);

            bool val = requirementWorkflowItems.Exists(x => x.EmailDate == requirementWorkflowItem.EmailDate);
            return val;
        }

        private dynamic QueryActiveContracts(List<WorkflowItem> listToQuery)
        {
            var results = from item in listToQuery
                          where item.Active==true
                          select item;

            return results;
        }

        private dynamic QueryInactiveContracts(List<WorkflowItem> listToQuery)
        {
            var results = from item in listToQuery
                          where item.Active==false
                          select item;

            return results;
        }

        private dynamic QueryContractInformationUpdated(List<WorkflowItem> listToQuery)
        {
            var results = from item in listToQuery
                          where item.ContractInformationUpdated == true
                          select item;

            return results;
        }

        private dynamic QueryContractInformationNotUpdated(List<WorkflowItem> listToQuery)
        {
            var results = from item in listToQuery
                          where item.ContractInformationUpdated == false
                          select item;

            return results;
        }

        private dynamic QueryContractOverridden(List<WorkflowItem> listToQuery)
        {
            var results = from item in listToQuery
                          where item.ContractIdOverridden == true
                          select item;

            return results;
        }

        private dynamic QueryContractNotOverridden(List<WorkflowItem> listToQuery)
        {
            var results = from item in listToQuery
                          where item.ContractIdOverridden == false
                          select item;

            return results;
        }

        private dynamic QueryCompanyExists(List<WorkflowItem> listToQuery)
        {
            var results = from item in listToQuery
                          where item.VendorName != null && item.VendorName != String.Empty
                          select item;

            return results;
        }

        private dynamic QueryCompanyMissing(List<WorkflowItem> listToQuery)
        {
            var results = from item in listToQuery
                          where item.VendorName == null || item.VendorName == String.Empty
                          select item;

            return results;
        }

        private dynamic QueryCompanyUpdated(List<WorkflowItem> listToQuery)
        {
            var results = from item in listToQuery
                          where item.CompanyUpdated == true
                          select item;

            return results;
        }

        private dynamic QueryCompanyNotUpdated(List<WorkflowItem> listToQuery)
        {
            var results = from item in listToQuery
                          where item.CompanyUpdated == false
                          select item;

            return results;
        }

        private dynamic QueryItemsAssigned(List<WorkflowItem> listToQuery)
        {
            var results = from item in listToQuery
                          where item.AssignedToName != null && item.AssignedToName != String.Empty && item.AssignedToName != "(Unassigned)"
                          select item;

            return results;
        }

        private dynamic QueryItemsUnassigned(List<WorkflowItem> listToQuery)
        {
            var results = from item in listToQuery
                          where item.AssignedToName == null || item.AssignedToName == String.Empty || item.AssignedToName == "(Unassigned)"
                          select item;

            return results;
        }

        private dynamic QueryItemsStatusCompleted(List<WorkflowItem> listToQuery)
        {
            var results = from item in listToQuery
                          where item.Status == "Completed" || item.Status == "Trash" || item.Status == "Completed/Trash"
                          select item;

            return results;
        }

        private dynamic QueryItemsStatusNotCompleted(List<WorkflowItem> listToQuery)
        {
            var results = from item in listToQuery
                          where !(item.Status == "Completed" || item.Status == "Trash" || item.Status == "Completed/Trash")
                          select item;

            return results;
        }

        private dynamic QueryItemsStatusEmailReceived(List<WorkflowItem> listToQuery)
        {
            var results = from item in listToQuery
                          where item.Status == "Email Received"
                          select item;

            return results;
        }

        private dynamic QueryItemsExcluded(List<WorkflowItem> listToQuery)
        {
            var results = from item in listToQuery
                          where item.Excluded == true
                          select item;

            return results;
        }

        private dynamic QueryItemsDifferentThanCertus(List<WorkflowItem> listToQuery)
        {
            var results = from item in listToQuery
                          where item.WorkflowItemInformationDifferentThanCertus == true
                          select item;

            return results;
        }

        private dynamic QueryItemsAssignmentColors(List<WorkflowItem> listToQuery)
        {
            var results = from item in listToQuery
                          where (item.DisplayColor == "Silver" || item.DisplayColor == "Teal" || item.DisplayColor == "Gray" ||
                                item.DisplayColor == "Lime" || item.DisplayColor == "SpringGreen" || item.DisplayColor == "Navy" ||
                                item.DisplayColor == "Blue" || item.DisplayColor == "Black" || item.DisplayColor == "Yellow")
                          select item;

            return results;
        }

        private dynamic QueryItemsNotGray(List<WorkflowItem> listToQuery)
        {
            var results = from item in listToQuery
                          where (item.DisplayColor != "Gray")
                          select item;

            return results;
        }

        private dynamic QueryItemsNotWhite(List<WorkflowItem> listToQuery)
        {
            var results = from item in listToQuery
                          where (item.DisplayColor != "SpringGreen")
                          select item;

            return results;
        }

        private dynamic QueryItemsPriority(List<WorkflowItem> listToQuery)
        {
            var results = from item in listToQuery
                          where (item.ItemHasPriority)
                          select item;

            return results;
        }

        private dynamic QueryItemsNotPriority(List<WorkflowItem> listToQuery)
        {
            var results = from item in listToQuery
                          where (!item.ItemHasPriority)
                          select item;

            return results;
        }

        private dynamic QueryItemsWithNoAttachments(List<WorkflowItem> listToQuery)
        {
            var results = from item in listToQuery
                          where item.FileName == null ||
                            item.FileName == String.Empty
                          select item;

            return results;
        }

        private void viewQueryBtn_Click(object sender, EventArgs e)
        {
            if (workflowItemListPopulated == null || workflowItemListPopulated.Count == 0)
            {
                SetStatusLabelAndTimer("You need a list of items to query first");
                MakeErrorSound();
                return;
            }

            this.selectSelection = this.querySelectComboBox.Text;
            this.fromSelection = this.queryFromComboBox.Text;
            this.whereSelection = this.queryWhereComboBox.Text;
            this.showExcludedItems = this.queryIncludeExcludedCheckBox.Checked;

            // return if options have not been selected
            if (this.querySelectComboBox.SelectedIndex < 0 || this.queryFromComboBox.SelectedIndex < 0)
            {
                SetStatusLabelAndTimer("You need atleast \"Select\" and \"From\" selections");
                MakeErrorSound();
                return;
            }

            //// return if excluded items checkbox is checked and excluded items are not loaded
            //if (this.queryIncludeExcludedCheckBox.Checked == false)
            //{
            //    if (this.excludedItems == null || this.excludedItems.Count == 0)
            //    {
            //        SetStatusLabelAndTimer("Import excluded items before proceeding", 5000);
            //        MakeErrorSound();
            //        return;
            //    }
            //}

            // call background worker runasync
            UseWaitCursor = true;

            try
            {
                queryBackgroundWorker.RunWorkerAsync();
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong with the query.", "Error");
            }
        }

        private dynamic QuerySearchItems(List<WorkflowItem> allWorkflowItems)
        {
            // query the list of all (items to string) for search tbx criteria
            var results = from item in allWorkflowItems
                          where item.ToString().Contains(searchTbx.Text)
                          select item;

            return results;
        }

        #endregion Queries

        private void queriedItemsListbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.queriedItemsListbox.SelectedItem != null)
            {
                if (e.KeyCode == Keys.Space)
                {
                    workflowItemsListView.Focus();
                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.Enter)
                {
                    try
                    {
                        //SelectItemInListView((queriedItemsListbox.SelectedItem as WorkflowItem).DocumentWorkflowItemID);
                        workflowItemsListView.FocusedItem.Focused = false;
                        FocusItemInListView((queriedItemsListbox.SelectedItem as WorkflowItem).DocumentWorkflowItemID);

                        if (workflowItemsListView.FocusedItem == null)
                        {
                            SetStatusLabelAndTimer("Could not find the item within the current view");
                            MakeErrorSound();
                        }
                    }
                    catch (Exception)
                    {
                        SetStatusLabelAndTimer("Error processing that request");
                        MakeErrorSound();
                    }
                }
                else if (e.KeyCode == Keys.D1)
                {
                    WorkflowItem item = new WorkflowItem();

                    item = queriedItemsListbox.SelectedItem as WorkflowItem;
                    item.DisplayColor = bindedColor1;
                    SetStatusLabelAndTimer($"Item {item.DocumentWorkflowItemID} painted {item.DisplayColor}");
                    workflowItemsListView.Refresh();

                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
                else if (e.KeyCode == Keys.D2)
                {
                    WorkflowItem item = new WorkflowItem();

                    item = queriedItemsListbox.SelectedItem as WorkflowItem;
                    item.DisplayColor = bindedColor2;
                    SetStatusLabelAndTimer($"Item {item.DocumentWorkflowItemID} painted {item.DisplayColor}");
                    workflowItemsListView.Refresh();

                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
                else if (e.KeyCode == Keys.D3)
                {
                    WorkflowItem item = new WorkflowItem();

                    item = queriedItemsListbox.SelectedItem as WorkflowItem;
                    item.DisplayColor = bindedColor3;
                    SetStatusLabelAndTimer($"Item {item.DocumentWorkflowItemID} painted {item.DisplayColor}");
                    workflowItemsListView.Refresh();

                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
                else if (e.KeyCode == Keys.D4)
                {
                    WorkflowItem item = new WorkflowItem();

                    item = queriedItemsListbox.SelectedItem as WorkflowItem;
                    item.DisplayColor = bindedColor4;
                    SetStatusLabelAndTimer($"Item {item.DocumentWorkflowItemID} painted {item.DisplayColor}");
                    workflowItemsListView.Refresh();

                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
                else if (e.KeyCode == Keys.D5)
                {
                    WorkflowItem item = new WorkflowItem();
                    if (this.colorDialogSelection != null)
                    {
                        bindedColor5 = this.colorDialogSelection.Name;
                    }

                    item = queriedItemsListbox.SelectedItem as WorkflowItem;
                    item.DisplayColor = bindedColor5;
                    SetStatusLabelAndTimer($"Item {item.DocumentWorkflowItemID} painted {item.DisplayColor}");
                    workflowItemsListView.Refresh();

                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
        }

        private void queriedItemsListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (queriedItemsListbox.SelectedItem == null)
                return;

            // save reference to item in next available item button
            AddReferenceButton(SelectedWorkflowItem.DocumentWorkflowItemID);
        }

        private void queriedItemsListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (queriedItemsListbox.SelectedItem != null)
            {
                SelectedWorkflowItem = (WorkflowItem)queriedItemsListbox.SelectedItem;

                PopulateDetailsViewData(SelectedWorkflowItem);
            }
        }

        private bool FilterFileName(string fileName)
        {
            // returns false if fileName matches criteria 

            // immediately let fileName pass through if it has certain words, unless...
            if (
                (fileName.ToLower().Contains("coi") &&
                    // all these have to be added here and below in the else if
                    fileName != "CBRE COI.pdf" &&
                    fileName != "COI CBRE.pdf" &&
                    fileName != "COI & Forms.pdf" &&
                    fileName != "Revised COI.pdf" &&
                    fileName != "COI Auto 2018.pdf" &&
                    fileName.StartsWith("PRIDE ELECRIC COI ENDTS") != true &&
                    fileName.StartsWith("MCKINSTRY") != true &&
                    fileName.EndsWith("Inquiry.doc") != true &&
                    fileName.ToLower() != "coi.pdf" &&
                    fileName.ToLower() != "coi 2018.pdf") ||

                (fileName.ToLower().Contains("cert") &&
                    fileName != "certusfile.dat" &&
                    fileName != "certusfile.eml" &&
                    fileName != "Certificate of Insurance.pdf" &&
                    fileName != "Certificate of Liability Insurance.pdf" &&
                    fileName != "CertificateofLiabilityInsurance.pdf" &&
                    fileName != "Revised Certificate.pdf" &&
                    fileName != "certpros.pdf" &&
                    fileName != "PremCert.pdf" &&
                    fileName.StartsWith("Certificate of Insurance for") != true &&
                    fileName.StartsWith("Cert of Insurance for") != true &&
                    fileName.StartsWith("Renewal Certificates of Insurance for") != true &&
                    fileName.EndsWith("Inquiry.doc") != true &&
                    fileName.ToLower() != "certificate.pdf" &&
                    fileName.ToLower() != "certificate (1).pdf" &&
                    fileName.ToLower() != "cert_print.pdf" &&
                    fileName.ToLower() != "cert.pdf") &&
                    fileName.ToLower() != "cbre cert.pdf" &&
                    fileName.ToLower().StartsWith("certificate (.pdf") != true ||

                fileName.ToLower().Contains("acord") &&
                    fileName.ToLower().StartsWith("acord_25") != true
                )
            {
                return true;
            }
            // let fileName pass through if it doesn't match any of this
            else if (
                fileName != "" &&
                fileName != "certusfile.dat" &&
                fileName != "certusfile.eml" &&
                fileName != "CBRE COI.pdf" &&
                fileName != "COI CBRE.pdf" &&
                fileName != "Requirement Template.pdf" &&
                fileName != "RequirementTemplate.pdf" &&
                fileName != "Certificate (1).pdf" &&
                fileName != "RAW.pdf" &&
                fileName != "CBRE Global Investors, LLC.pdf" &&
                fileName != "Google LLC.pdf" &&
                fileName != "EQC Operating Trust.pdf" &&
                fileName != "Forms.pdf" &&
                fileName != "FFII TX Westway LP.pdf" &&
                fileName != "Certificate of Insurance.pdf" &&
                fileName != "Certificate of Liability Insurance.pdf" &&
                fileName != "CertificateofLiabilityInsurance.pdf" &&
                fileName != "PDF Creator.pdf" &&
                fileName != "1 Forms All 2018.pdf" &&
                fileName != "SelectiveElitePac_Ext 2016.pdf" &&
                fileName != "DOC013018.pdf" &&
                fileName != "Original Request.pdf" &&
                fileName != "a.pdf" &&
                fileName != "0.pdf" &&
                fileName != "Revised Certificate.pdf" &&
                fileName != "certpros.pdf" &&
                fileName != "CBRE add. insured end..pdf" &&
                fileName != "2404.pdf" &&
                fileName != "primary.pdf" &&
                fileName != "Revised COI.pdf" &&
                fileName != "COI Auto 2018.pdf" &&
                fileName != "PremCert.pdf" &&
                fileName != "Form.pdf" &&
                fileName != "Teachers Insurance and Annuity Association of America.pdf" &&
                fileName != "_tmp_ThunderheadDocument.pdf.pdf" &&
                fileName != "CBRE Global Investors.pdf" &&
                fileName != "17-18 Forms.pdf" &&
                fileName != "18-19 Forms.pdf" &&
                fileName != "CBRE, Inc.pdf" &&
                fileName.ToLower() != "certificate.pdf" &&
                fileName.ToLower() != "attachment.pdf" &&
                fileName.ToLower() != "attachment 1.pdf" &&
                fileName.ToLower() != "coi.pdf" &&
                fileName.ToLower() != "coi 2018.pdf" &&
                fileName.ToLower() != "cbre.pdf" &&
                fileName.ToLower() != "cert.pdf" &&
                fileName.ToLower() != "cbre cert.pdf" &&
                fileName.ToLower() != "cert_print.pdf" &&
                fileName.ToLower() != "scan.pdf" &&
                fileName.ToLower() != "document.pdf" &&
                fileName.ToLower() != "cbre inc.pdf" &&
                fileName.ToLower() != "coi 2018.pdf" &&
                fileName.ToLower() != "previewliabilityholder.aspx.pdf" &&
                fileName.StartsWith("ATT000") != true &&
                fileName.StartsWith("HEALT") != true &&
                fileName.StartsWith("CLEAN") != true &&
                fileName.StartsWith("PRIDE ELECRIC COI ENDTS") != true &&
                fileName.StartsWith("MCKINSTRY") != true &&
                fileName.StartsWith("Scanned from a Xerox") != true &&
                fileName.StartsWith("Certificate of Insurance for") != true &&
                fileName.StartsWith("Chantilly") != true &&
                fileName.StartsWith("K&I") != true &&
                fileName.StartsWith("BA9") != true &&
                fileName.StartsWith("Renewal Certificates of Insurance for") != true &&
                fileName.StartsWith("Cert of Insurance for") != true &&
                fileName.StartsWith("Culligan") != true &&
                fileName.StartsWith("A C ") != true &&
                fileName.StartsWith("CG") != true &&
                fileName.EndsWith(".png") != true &&
                fileName.EndsWith(".jpg") != true &&
                fileName.EndsWith(".vcf") != true &&
                fileName.EndsWith("Inquiry.doc") != true &&
                fileName.Contains("AI") != true &&
                fileName.Contains("GL") != true &&
                fileName.Contains("WC") != true &&
                fileName.Contains("CA") != true &&
                fileName.Contains("WOS") != true &&
                fileName.Contains("CSR24") != true &&
                fileName.Contains("PNC") != true &&
                fileName.Contains("PPA") != true &&
                fileName.Contains("AC") != true &&
                fileName.Contains("2037") != true &&
                fileName.Contains("2010") != true &&
                fileName.Contains("GA") != true &&
                fileName.Contains("Umbrella") != true &&
                fileName.Contains("CNA") != true &&
                fileName.Contains("UL") != true &&
                fileName.Contains("W9") != true &&
                fileName.Contains("SS 00") != true &&
                fileName.Contains("SS00") != true &&
                fileName.Contains("INSD") != true &&
                fileName.Contains("CLCG") != true &&
                fileName.Contains("ECG") != true &&
                fileName.Contains("ENV") != true &&
                fileName.Contains("ECP") != true &&
                fileName.ToLower().Contains("auto") != true &&
                fileName.ToLower().Contains("blanket") != true &&
                fileName.ToLower().Contains("loss payee") != true &&
                fileName.ToLower().Contains("primary ") != true &&
                fileName.ToLower().Contains("additional insured") != true &&
                fileName.ToLower().Contains("addl insd") != true &&
                fileName.ToLower().Contains("waiver") != true &&
                fileName.ToLower().Contains("waivor") != true &&
                fileName.ToLower().Contains("workers") != true &&
                fileName.ToLower().Contains("comp") != true &&
                fileName.ToLower().Contains("ongoing") != true &&
                fileName.ToLower().Contains("attachments") != true &&
                fileName.ToLower().Contains("umb") != true &&
                fileName.ToLower().Contains("underlying") != true &&
                fileName.ToLower().Contains("schedule") != true &&
                fileName.ToLower().Contains("endt") != true &&
                fileName.ToLower().Contains("endo") != true &&
                fileName.ToLower().Contains("cg ") != true &&
                fileName.ToLower().Contains("as required by written contract") != true &&
                fileName.ToLower().Contains("per project") != true &&
                fileName.ToLower().Contains("per proj") != true &&
                fileName.ToLower().Contains("policy forms") != true &&
                fileName.ToLower().StartsWith("acord_25") != true &&
                fileName.ToLower().StartsWith("contract_") != true &&
                fileName.ToLower().StartsWith("cg2") != true &&
                fileName.ToLower().StartsWith("cg7") != true &&
                fileName.ToLower().StartsWith("cgd") != true &&
                fileName.ToLower().StartsWith("certificate (.pdf") != true)
            {
                return true;
            }
            // fileName gets filtered. It doesn't pass through with accepted words and it gets knocked out by a filtered word.
            else
            {
                return false;
            }
        }

        private bool FilterSubject(string subject)
        {
            if (
                subject.Contains("These are for Alex")
                )
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private int CountOfQueriedItems()
        {
            if (queriedItemList != null && queriedItemList.Count > 0)
            {
                return queriedItemList.Count();
            }
            else
            {
                return 0;
            }
        }

        #endregion Query Panel

        // ----- IMPORTS PANEL ----- //
        #region Imports Panel

        private void itemImportsLbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.itemImportsLbx.SelectedItem != null)
            {
                SelectedImport = (WorkflowItemCSVImport)itemImportsLbx.SelectedItem;

                PopulateImportViewData(SelectedImport);
            }
        }

        private void ItemsViewForm_SaveCompletedReport(object sender, ItemsCompletedReport completedReport)
        {
            this.CurrentCompletedReport = new ItemsCompletedReport();
            this.CurrentCompletedReport.Date = completedReport.Date;
            this.CurrentCompletedReport.ItemListDetails = completedReport.ItemListDetails;
            this.CurrentCompletedReport.StatusChangedTo = completedReport.StatusChangedTo;
            this.CurrentCompletedReport.WorkflowItems.AddRange(completedReport.WorkflowItems);

            // save this report
            AllItemsCompletedReportsLoaded.Add(CurrentCompletedReport);

            // refresh views
            this.refreshBtn.PerformClick();

            UpdateAllLoadedWorkflowItems(CurrentCompletedReport.WorkflowItems);
        }

        private void RemoveCompletedReport(ItemsCompletedReport reportToRemove)
        {
            ItemsCompletedReport report = new ItemsCompletedReport();
            report = reportToRemove;

            AllItemsCompletedReportsLoaded.Remove(report);
        }

        #endregion Imports Panel

        // ----- STATUS STRIP ----- //
        #region Status Strip

        private void checkedToolStripDropDownButton_Click(object sender, EventArgs e)
        {
            if (workflowItemsListView.CheckedItems != null && workflowItemsListView.CheckedItems.Count > 0)
            {
                int index;

                try
                {
                    // unselect item if it's not checked and select first checked item
                    if (workflowItemsListView.SelectedItems.Count == 1 && workflowItemsListView.SelectedItems[0].Checked == false)
                    {
                        workflowItemsListView.SelectedItems[0].Selected = false;
                        workflowItemsListView.CheckedItems[0].Selected = true;
                        workflowItemsListView.CheckedItems[0].Focused = true;
                        workflowItemsListView.CheckedItems[0].EnsureVisible();
                    }
                    // determine index to check if any checked item is selected
                    else if (workflowItemsListView.SelectedItems.Count == 1 && workflowItemsListView.SelectedItems[0].Checked == true)
                    {
                        index = workflowItemsListView.CheckedItems.IndexOf(workflowItemsListView.SelectedItems[0]);
                        if (index == workflowItemsListView.CheckedItems.Count - 1)
                            index = -1;

                        ++index;

                        //select next checked item
                        workflowItemsListView.SelectedItems[0].Selected = false;
                        workflowItemsListView.CheckedItems[index].Selected = true;
                        workflowItemsListView.CheckedItems[index].Focused = true;
                        workflowItemsListView.CheckedItems[index].EnsureVisible();
                    }
                }
                catch (Exception)
                {
                    SetStatusLabelAndTimer("Could not select the item");
                    MakeErrorSound();
                }
            }
        }

        private void queriedToolStripDropDownButton_Click(object sender, EventArgs e)
        {
            if (this.queriedItemList != null && this.queriedItemList.Count > 0)
            {
                try
                {
                    workflowItemsListView.SelectedItems[0].Selected = false;
                    workflowItemsListView.FindItemWithText(this.queriedItemList[0].DocumentWorkflowItemID, true, 0, false).Selected = true;
                }
                catch (Exception)
                {
                    SetStatusLabelAndTimer("Could not select the item");
                    MakeErrorSound();
                }
            }
        }

        private void displayingToolStripDropDownButton_Click(object sender, EventArgs e)
        {
            if (this.workflowItemsListView.Items != null && this.workflowItemsListView.Items.Count > 0)
            {
                try
                {
                    workflowItemsListView.SelectedItems[0].Selected = false;
                    workflowItemsListView.Items[0].Selected = true;
                }
                catch (Exception)
                {
                    SetStatusLabelAndTimer("Could not select the item");
                    MakeErrorSound();
                }
            }
        }

        public void ResetStatusStrip()
        {
            if (this.InvokeRequired) this.Invoke(new Action(() =>
            {
                // same code as within the tick event
                toolStripStatusLabel.Text = "Ready";
                this.toolStripStatusLabel.BackColor = Color.FromArgb(46, 204, 113);
                this.displayingCountStatusLbl.Visible = true;
                this.checkedCountStatusLbl.Visible = true;
                this.queriedCountStatusLbl.Visible = true;
                this.filterStatusLbl.Visible = true;
                statusLblTimer.Enabled = false;
            }));
            else
            {
                toolStripStatusLabel.Text = "Ready";
                this.toolStripStatusLabel.BackColor = Color.FromArgb(46, 204, 113);
                this.displayingCountStatusLbl.Visible = true;
                this.checkedCountStatusLbl.Visible = true;
                this.queriedCountStatusLbl.Visible = true;
                this.filterStatusLbl.Visible = true;
                statusLblTimer.Enabled = false;
            }
        }

        public void SetStatusLabelAndTimer(string statusLblMessage)
        {
            if (this.InvokeRequired) this.Invoke(new Action(() =>
             {
                toolStripStatusLabel.Text = statusLblMessage;
                toolStripStatusLabel.BackColor = Color.FromArgb(39, 174, 96);
            }));
            else
            {
                toolStripStatusLabel.Text = statusLblMessage;
                toolStripStatusLabel.BackColor = Color.FromArgb(39, 174, 96);
            }
            statusLblTimer.Interval = 7000;
            statusLblTimer.Enabled = false;
            statusLblTimer.Enabled = true;
        }

        private void SetStatusLabelAndTimer(string statusLblMessage, bool timerIgnored)
        {
            statusLblTimer.Enabled = false;

            if (this.InvokeRequired) this.Invoke(new Action(() =>
            {
                toolStripStatusLabel.Text = statusLblMessage;
                toolStripStatusLabel.BackColor = Color.FromArgb(39, 174, 96);
            }));
            else
            {
                toolStripStatusLabel.Text = statusLblMessage;
                toolStripStatusLabel.BackColor = Color.FromArgb(39, 174, 96);
            }

            if (timerIgnored == false)
            {
                statusLblTimer.Enabled = true;
            }
        }

        private void SetStatusLabelAndTimer(string statusLblMessage, int timer)
        {
            if (this.InvokeRequired) this.Invoke(new Action(() =>
            {
                toolStripStatusLabel.Text = statusLblMessage;
                toolStripStatusLabel.BackColor = Color.FromArgb(39, 174, 96);
            }));
            else
            {
                toolStripStatusLabel.Text = statusLblMessage;
                toolStripStatusLabel.BackColor = Color.FromArgb(39, 174, 96);
            }

            statusLblTimer.Interval = timer;
            statusLblTimer.Enabled = false;
            statusLblTimer.Enabled = true;
        }

        private void statusLblTimer_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Ready";
            this.toolStripStatusLabel.BackColor = Color.FromArgb(46, 204, 113);
            this.displayingCountStatusLbl.Visible = true;
            this.checkedCountStatusLbl.Visible = true;
            this.queriedCountStatusLbl.Visible = true;
            this.filterStatusLbl.Visible = true;
            statusLblTimer.Enabled = false;
        }

        public void SetProgressTextFromOutsideMainForm(string text)
        {
            if (this.InvokeRequired)
            {
                Action<string> progressDelegate = this.SetProgressTextFromOutsideMainForm;
                progressDelegate.Invoke(text);
            }
            else
            {
                LoadingForm.ChangeLabel(text);
            }
        }

        #endregion Status Strip

        // ----- FORM MANEUVERABILITY ----- //
        #region Form Maneuverability

        private void focusDetailPanelBtn_Click(object sender, EventArgs e)
        {
            foreach (Control c in (sender as Button).Parent.Controls)
            {
                if (c is TextBox)
                {
                    (c as TextBox).TabStop = true;
                    (c as TextBox).TabIndex = 2;
                }
            }

            foreach (Control c in this.itemDetailsPanel.Controls)
            {
                if (c is Panel)
                {
                    if (c.Contains(sender as Button))
                    {
                        foreach (Control childC in c.Controls)
                        {
                            if (childC is TextBox)
                            {
                                return;
                            }
                        }
                    }
                }
            }
        }

        private void focusDetailPanelBtn_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode != Keys.Tab)
            {
                e.IsInputKey = true;
            }
            else if (e.KeyCode == Keys.Tab)
            {
                tabWasPressed = true;
            }
        }

        private void focusDetailPanelBtn_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                int selectedPanelNum = Convert.ToInt32(selectedPanel.Name.Substring(11));
                int selectedPanelIndex = selectedPanelNum - 1;

                if (e.KeyCode == Keys.Up)
                {
                    if (selectedPanelIndex == 0)
                    {
                        detailPanels[detailPanels.Length - 1].Focus();
                        (detailPanels[detailPanels.Length - 1].Controls[2] as Button).PerformClick();
                    }
                    else if (selectedPanelIndex == 12)
                    {
                        detailPanels[5].Focus();
                        (detailPanels[5].Controls[2] as Button).PerformClick();
                    }
                    else
                    {
                        detailPanels[selectedPanelIndex - 1].Focus();
                        (detailPanels[selectedPanelIndex - 1].Controls[2] as Button).PerformClick();
                    }
                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.Down)
                {
                    if (selectedPanelIndex == detailPanels.Length - 1)
                    {
                        detailPanels[0].Focus();
                        (detailPanels[0].Controls[2] as Button).PerformClick();
                    }
                    else if (selectedPanelIndex == 5)
                    {
                        detailPanels[12].Focus();
                        (detailPanels[12].Controls[2] as Button).PerformClick();
                    }
                    else
                    {
                        detailPanels[selectedPanelIndex + 1].Focus();
                    }
                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.Left)
                {
                    if (selectedPanelIndex == 6 || selectedPanelIndex == 7 || selectedPanelIndex == 8 ||
                        selectedPanelIndex == 9 || selectedPanelIndex == 10 || selectedPanelIndex == 11)
                    {
                        detailPanels[selectedPanelIndex - 6].Focus();
                        (detailPanels[selectedPanelIndex - 6].Controls[2] as Button).PerformClick();
                    }
                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.Right)
                {
                    if (selectedPanelIndex == 0 || selectedPanelIndex == 1 || selectedPanelIndex == 2 ||
                        selectedPanelIndex == 3 || selectedPanelIndex == 4 || selectedPanelIndex == 5)
                    {
                        detailPanels[selectedPanelIndex + 6].Focus();
                        (detailPanels[selectedPanelIndex + 6].Controls[2] as Button).PerformClick();
                    }
                    e.Handled = true;
                }
            }
            catch (Exception)
            {
                // just don't crash
            }
        }

        private void focusDetailPanelBtn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetterOrDigit(e.KeyChar))
            {
                detailPanelTbx_KeyPress(sender, e);
                e.Handled = true;
            }
        }

        private void detailPanelTbx__PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((sender as TextBox).Parent.Controls[2] as Button).Focus();
            }
        }

        private void detailPanelTbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (sender is Button)
            {
                ((sender as Button).Parent.Controls[1] as TextBox).Focus();
                if (((sender as Button).Parent.Controls[1] as TextBox).ReadOnly == false)
                {
                    ((sender as Button).Parent.Controls[1] as TextBox).Text = String.Empty;
                    ((sender as Button).Parent.Controls[1] as TextBox).Text += e.KeyChar.ToString();
                    ((sender as Button).Parent.Controls[1] as TextBox).SelectionStart = ((sender as Button).Parent.Controls[1] as TextBox).TextLength;
                }
                return;
            }

            if (sender is TextBox)
            {
                if ((sender as TextBox).ReadOnly == false && Char.IsLetterOrDigit(e.KeyChar)) itemDetailsChanged = true;
            }
        }

        private void detailTbx_TextChanged(object sender, EventArgs e)
        {
            try
            {
                (sender as TextBox).Tag = null;
            }
            catch (Exception)
            {

            }
        }

        private void detailPanelTbx_Enter(object sender, EventArgs e)
        {
            (sender as TextBox).TabStop = false;
            //(sender as TextBox).TabIndex = 0;

            if (tabWasPressed == true)
            {
                (sender as TextBox).SelectAll();
                tabWasPressed = false;
            }
        }

        private void detailPanelTbx_Leave(object sender, EventArgs e)
        {
            (sender as TextBox).DeselectAll();
        }

        private void detailsSaveBtn_Enter(object sender, EventArgs e)
        {
            (sender as Button).TabIndex = 0;

            foreach (Panel panel in detailPanels)
            {
                panel.TabStop = false;
                panel.Controls[2].TabStop = false;
            }
        }

        private void detailsSaveBtn_Leave(object sender, EventArgs e)
        {
            (sender as Button).TabIndex = 2;
        }

        private void detailsSaveBtn_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab && ignoreThisSaveBtnTabPress)
            {
                e.IsInputKey = true;
                tabWasPressedOnSaveBtn = true;
            }
            else if (e.KeyCode == Keys.Tab && !ignoreThisSaveBtnTabPress)
            {
                e.IsInputKey = true;
                workflowItemsListView.Focus();
                tabWasPressedOnSaveBtn = true;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                e.IsInputKey = true;
                enterWasPressedOnSaveBtn = true;
            }
        }

        private void detailsSaveBtn_KeyDown(object sender, KeyEventArgs e)
        {
            if (enterWasPressedOnSaveBtn)
            {
                detailsSaveBtn.PerformClick();
                workflowItemsListView.Focus();
                enterWasPressedOnSaveBtn = false;
                e.Handled = true;
            }
            else if (tabWasPressedOnSaveBtn && ignoreThisSaveBtnTabPress)
            {
                ignoreThisSaveBtnTabPress = false;
                e.Handled = true;
            }
            else if (tabWasPressedOnSaveBtn && !ignoreThisSaveBtnTabPress)
            {
                workflowItemsListView.Focus();
                tabWasPressedOnSaveBtn = false;
                e.Handled = true;
            }
        }

        private void detailPanel_Enter(object sender, EventArgs e)
        {
            selectedPanel = (sender as Panel);

            foreach (Panel panel in detailPanels)
            {
                panel.TabStop = false;
                panel.Controls[2].Text = String.Empty;
                panel.Controls[1].TabStop = false;
                panel.Controls[2].TabStop = false;
            }

            //((sender as Panel).Controls[1] as TextBox).PreviewKeyDown += new PreviewKeyDownEventHandler(detailPanelTbx_PreviewKeyDown);

            ((sender as Panel).Controls[2] as Button).BackColor = Color.FromName("Highlight");
            ((sender as Panel).Controls[2] as Button).Text = "-";
            ((sender as Panel).Controls[2] as Button).TabStop = true;
            ((sender as Panel).Controls[2] as Button).Focus();
            ((sender as Panel).Controls[2] as Button).PerformClick();
        }

        private void detailPanel_Leave(object sender, EventArgs e)
        {
            // leave
            (sender as Panel).Controls[2].BackColor = Color.FromArgb(20, 20, 20);
            (sender as Panel).Controls[1].TabStop = false;
            ((sender as Panel).Controls[1] as TextBox).DeselectAll();
        }

        private void itemDetailsPanel_Enter(object sender, EventArgs e)
        {
            foreach (Panel panel in itemDetailsPanel.Controls.OfType<Panel>())
            {
                if ((panel.Controls[2] as Button).Text == "-")
                {
                    (panel.Controls[2] as Button).PerformClick();
                }
            }
        }

        private void itemDetailsPanel_Leave(object sender, EventArgs e)
        {
            // prompt if changes made
            if (itemDetailsChanged)
            {
                if (!YesOrNoMsgBox("Leave without saving item changes?", "Warning"))
                {
                    selectedIndexChangedEventIgnored = true;
                    ignoreThisSaveBtnTabPress = true;
                    itemDetailsPanel.Focus();

                    foreach (Panel panel in itemDetailsPanel.Controls.OfType<Panel>())
                    {
                        if ((panel.Controls[2] as Button).Text == "-")
                        {
                            tabWasPressed = true;
                            panel.Focus();
                            (panel.Controls[1] as TextBox).Focus();
                        }
                    }

                    return;
                }
                else
                {
                    selectedIndexChangedEventIgnored = false;
                    itemDetailsChanged = false;
                }
            }

            foreach (Panel panel in itemDetailsPanel.Controls.OfType<Panel>())
            {
                if ((panel.Controls[2] as Button).Text == "-")
                {
                    panel.TabStop = true;
                    (panel.Controls[2] as Button).TabStop = true;
                }
            }
        }

        // form shortcuts
        private void WorkflowManager_KeyDown(object sender, KeyEventArgs e)
        {
            // listview options
            if (e.Alt && e.Shift && e.KeyCode == Keys.A)
            {
                bulkCheckBtn.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            if (e.Alt && e.KeyCode == Keys.X)
            {
                singleCheckBtn.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            if (e.Alt && e.KeyCode == Keys.D)
            {
                deselectBtn.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            if (e.Alt && e.Shift && e.KeyCode == Keys.Down)
            {
                addReferenceBtn.PerformClick();
            }
            if (e.Control && e.Shift && e.KeyCode == Keys.I)
            {
                importBtn.PerformClick();
            }
            if (e.Control && e.KeyCode == Keys.T)
            {
                filterBtn.PerformClick();
            }
            if (e.Control && e.Shift && e.KeyCode == Keys.V)
            {
                itemsViewBtn.PerformClick();
            }
            if (e.Control && e.KeyCode == Keys.Enter)
            {
                fullViewBtn.PerformClick();
            }
            if (e.Control && e.KeyCode == Keys.E)
            {
                enlargeBtn.PerformClick();
            }
            if (e.Control && e.KeyCode == Keys.R)
            {
                refreshBtn.PerformClick();
            }

            // ---------------
            if (e.Alt && e.Control && e.KeyCode == Keys.X)
            {
                // pause 
            }
            // ---------------

            // details options
            if (e.Control && e.Shift && e.KeyCode == Keys.X)
            {
                closeItemTabBtn.PerformClick();
            }
            if (e.Control && e.Shift && e.KeyCode == Keys.O)
            {
                openLinkBtn.PerformClick();
            }
            if (e.Control && e.Alt && e.KeyCode == Keys.A)
            {
                selectAllItemsBtn.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }

            // details tabs
            if (e.Control && e.KeyCode == Keys.D1)
            {
                itemButton1.Focus();
            }
            if (e.Control && e.KeyCode == Keys.D2)
            {
                itemButton2.Focus();
            }
            if (e.Control && e.KeyCode == Keys.D3)
            {
                itemButton3.Focus();
            }
            if (e.Control && e.KeyCode == Keys.D4)
            {
                itemButton4.Focus();
            }
            if (e.Control && e.KeyCode == Keys.D5)
            {
                itemButton5.Focus();
            }
            if (e.Control && e.KeyCode == Keys.D6)
            {
                itemButton6.Focus();
            }
            if (e.Control && e.KeyCode == Keys.D7)
            {
                itemButton7.Focus();
            }
            if (e.Control && e.KeyCode == Keys.D8)
            {
                itemButton8.Focus();
            }
            if (e.Control && e.KeyCode == Keys.D9)
            {
                itemButton9.Focus();
            }

            // window
            if (e.Shift && e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if (e.Control && e.KeyCode == Keys.F)
            {
                searchHighlightBtn.Focus();
                searchHighlightBtn.PerformClick();
            }
        }

        #endregion Form Maneuverability

        // ----- FORM APPEARANCE AND BEHAVIOR ----- //
        #region Form Appearance and Behavior

        private void WorkflowManager_Resize(object sender, EventArgs e)
        {
            try
            {
                this.toolStripStatusLabel.Width = this.ClientSize.Width - (displayingToolStripDropDownButton.Width +
                    displayingCountStatusLbl.Width + checkedToolStripDropDownButton.Width + checkedCountStatusLbl.Width +
                    queriedToolStripDropDownButton.Width + queriedCountStatusLbl.Width + filterStatusLbl.Width);
            }
            catch (Exception)
            {
                SetStatusLabelAndTimer("Could not resize the status bar", 3000);
            }

            try
            {
                // column reisze
                int columnToResize = emailSubjectColumnHeader.Index;

                int allOtherColumnsWidth = 0;
                int columnWidthToSet = workflowItemsListView.Columns[columnToResize].Width;
                for (int i = 0; i < workflowItemsListView.Columns.Count; i++)
                {
                    if (i != columnToResize)
                    {
                        allOtherColumnsWidth += workflowItemsListView.Columns[i].Width;
                    }
                }

                if (workflowItemsListView.Columns[columnToResize].Width != (workflowItemsListView.ClientSize.Width - allOtherColumnsWidth))
                    workflowItemsListView.Columns[columnToResize].Width = (workflowItemsListView.ClientSize.Width - allOtherColumnsWidth);
            }
            catch (Exception)
            {
                SetStatusLabelAndTimer("Could not resize the columns", 3000);
            }
        }

        #endregion Form Appearance and Behavior

        // ----- PULL/EDIT DATA ----- //
        #region Pull/Edit Data

        private ListViewItem GetListViewItemFromWorkFlowItem(WorkflowItem item)
        {
            WorkflowItem wfItem = item;
            ListViewItem lvItem = new ListViewItem();

            // ...

            return lvItem;
        }

        private void UpdateAllLoadedWorkflowItems(List<WorkflowItem> itemsToUpdate)
        {
            List<WorkflowItem> itemsToChange = itemsToUpdate;

            foreach (WorkflowItem item in itemsToChange)
            {
                var tmpItem = AllWorkflowItemsLoaded.First(i => i.DocumentWorkflowItemID == item.DocumentWorkflowItemID);
                int index = AllWorkflowItemsLoaded.IndexOf(tmpItem as WorkflowItem);

                this.AllWorkflowItemsLoaded[index] = item;
            }
        }

        public List<WorkflowItem> UpdateWorkflowItemsStatus(List<WorkflowItem> listToUpdate, List<WorkflowItem> itemsToUpdate)
        {
            List<WorkflowItem> itemListToUpdate = listToUpdate;
            List<WorkflowItem> itemsToChange = itemsToUpdate;

            foreach (WorkflowItem item in itemsToChange)
            {
                var tmpItem = itemListToUpdate.First(i => i.DocumentWorkflowItemID == item.DocumentWorkflowItemID);
                int index = itemListToUpdate.IndexOf(tmpItem as WorkflowItem);

                itemListToUpdate[index].Status = item.Status;
            }

            return itemListToUpdate;
        }

        public List<WorkflowItem> ChangeWorkflowItemsStatus(List<WorkflowItem> listToUpdate, string status)
        {
            List<WorkflowItem> itemListToUpdate = listToUpdate;
            string s = status;

            foreach (WorkflowItem item in itemListToUpdate)
            {
                item.Status = s;
            }

            return itemListToUpdate;
        }

        public List<WorkflowItem> UpdateWorkflowItemsColor(List<WorkflowItem> listToUpdate, List<WorkflowItem> itemsToUpdate)
        {
            List<WorkflowItem> itemListToUpdate = listToUpdate;
            List<WorkflowItem> itemsToChange = itemsToUpdate;

            foreach (WorkflowItem item in itemsToChange)
            {
                var tmpItem = itemListToUpdate.First(i => i.DocumentWorkflowItemID == item.DocumentWorkflowItemID);
                int index = itemListToUpdate.IndexOf(tmpItem as WorkflowItem);

                itemListToUpdate[index].DisplayColor = item.DisplayColor;
            }

            return itemListToUpdate;
        }

        public List<WorkflowItem> ChangeWorkflowItemsColor(List<WorkflowItem> listToUpdate, string color)
        {
            List<WorkflowItem> itemListToUpdate = listToUpdate;
            string colorChangingTo = color;

            foreach (WorkflowItem item in itemListToUpdate)
            {
                item.DisplayColor = colorChangingTo;
            }

            return itemListToUpdate;
        }

        public List<WorkflowItem> RemoveWorkflowItemsColor(List<WorkflowItem> listToUpdate)
        {
            List<WorkflowItem> itemListToUpdate = listToUpdate;

            foreach (WorkflowItem item in itemListToUpdate)
            {
                item.DisplayColor = "Gray";
            }

            return itemListToUpdate;
        }

        private void SetNonCompletedItemsList()
        {
            CurrentWorkflowItems.Clear();

            foreach (WorkflowItem item in AllWorkflowItemsLoaded)
            {
                if (item.Status != "Completed" && item.Status != "Trash" && item.Status != "Completed/Trash")
                {
                    CurrentWorkflowItems.Add(item);
                }
            }
        }

        private List<WorkflowItem> GetAllColoredWfItems()
        {
            List<WorkflowItem> tmpList = new List<WorkflowItem>();

            foreach (WorkflowItem item in workflowItemListPopulated)
            {
                if (item.DisplayColor != "Default")
                {
                    tmpList.Add(item);
                }
            }

            return tmpList;
        }

        private List<WorkflowItem> GetActiveColoredWfItems()
        {
            List<WorkflowItem> tmpList = new List<WorkflowItem>();

            foreach (WorkflowItem item in workflowItemListPopulated)
            {
                if (item.DisplayColor != "Default" && item.DisplayColor != "Gray" && item.DisplayColor != "Silver" && item.DisplayColor != "Black" && item.DisplayColor != "Teal")
                {
                    tmpList.Add(item);
                }
            }

            return tmpList;
        }

        private List<WorkflowItem> GetInactiveColoredWfItems()
        {
            List<WorkflowItem> tmpList = new List<WorkflowItem>();

            foreach (WorkflowItem item in workflowItemListPopulated)
            {
                if (item.DisplayColor == "Gray" || item.DisplayColor == "Silver" || item.DisplayColor == "Black")
                {
                    tmpList.Add(item);
                }
            }

            return tmpList;
        }

        public WorkflowItem GetWorkflowItemFromLvItem(ListViewItem lvItem)
        {
            WorkflowItem item = new WorkflowItem();

            item = GetWorkflowItemFromCurrentViewByID(lvItem.SubItems[1].Text);

            return item;
        }

        public List<WorkflowItem> GetWorkflowItemsFromLvItems(List<ListViewItem> lvItems)
        {
            List<WorkflowItem> items = new List<WorkflowItem>();

            foreach (ListViewItem lvItem in lvItems)
            {
                WorkflowItem item = new WorkflowItem();

                item = GetWorkflowItemFromCurrentViewByID(lvItem.SubItems[1].Text);

                items.Add(item);
            }

            return items;
        }

        private WorkflowItem LvItemToWorkflowItem(ListViewItem item)
        {
            return GetWorkflowItemFromAllByID(item.SubItems[1].Text);
        }

        public List<WorkflowItem> GetWorkflowItemsFromChecked(ListView listView)
        {
            List<WorkflowItem> tmpList = new List<WorkflowItem>();

            // for each checked item
            for (int i = 0; i < listView.CheckedItems.Count; i++)
            {
                // get item as wf item
                ListViewItem lvItem = listView.CheckedItems[i];
                WorkflowItem checkedItem = LvItemToWorkflowItem(lvItem);

                // add item to list
                tmpList.Add(checkedItem);
            }

            return tmpList;
        }

        private List<string> GetWorkflowIDsFromChecked(ListView listView)
        {
            List<string> tmpList = new List<string>();

            // for each checked item
            for (int i = 0; i < listView.CheckedItems.Count; i++)
            {
                // get item id
                string id = listView.CheckedItems[i].SubItems[1].Text;

                // add id to list
                tmpList.Add(id);
            }

            return tmpList;
        }

        private List<WorkflowItem> GetWorkflowItemsFromIDs(List<string> idList)
        {
            List<WorkflowItem> tmpList = new List<WorkflowItem>();

            // for each id
            foreach (string id in idList)
            {
                tmpList.Add(GetWorkflowItemFromAllByID(id));
            }

            return tmpList;
        }

        private List<string> GetIDsFromWorkflowItems(List<WorkflowItem> itemList)
        {
            List<string> tmpList = new List<string>();

            // for each item
            foreach (WorkflowItem item in itemList)
            {
                tmpList.Add(item.DocumentWorkflowItemID);
            }

            return tmpList;
        }

        private WorkflowItem GetWorkflowItemFromCurrentViewByID(string id)
        {
            // query the list for id
            WorkflowItem result = workflowItemListPopulated.Find(o => o.DocumentWorkflowItemID == id);

            return result;
        }

        private WorkflowItem GetWorkflowItemFromAllByID(string id)
        {
            // query the list for id
            WorkflowItem result = this.AllWorkflowItemsLoaded.Find(o => o.DocumentWorkflowItemID == id);

            return result;
        }

        #endregion Pull/Edit Data

        // ----- POPULATE DATA ----- //
        #region Populate Data

        public void PopulateListViewData(List<WorkflowItem> workflowItemListToPopulate)
        {
            // assign list
            this.workflowItemListPopulated = workflowItemListToPopulate;

            // drawing has to go back to normal whenever the lv is changed
            contrastItemGroups = false;
            contrastItemGroupsBtn.BackColor = Color.FromArgb(20, 20, 20);

            // Reset lv 
            workflowItemsListView.BeginUpdate();
            workflowItemsListView.ListViewItemSorter = null;
            workflowItemsListView.Items.Clear();

            // ignore itemChecked event
            itemCheckedEventIgnored = true;

            // save count for progress
            int lvItemCount = 0;

            foreach (WorkflowItem wfItem in this.workflowItemListPopulated)
            {
                ListViewItem lvItem = new ListViewItem();
                lvItem.SubItems.Add(wfItem.DocumentWorkflowItemID.ToString());
                lvItem.SubItems.Add(wfItem.VendorName);
                lvItem.SubItems.Add(wfItem.ContractID);
                lvItem.SubItems.Add(wfItem.EmailDate.ToString());
                lvItem.SubItems.Add(wfItem.EmailFromAddress);
                lvItem.SubItems.Add(wfItem.SubjectLine);
                lvItem.SubItems.Add(wfItem.FileName);
                lvItem.SubItems.Add(wfItem.FileSize);
                lvItem.SubItems.Add(wfItem.FileURL);
                lvItem.SubItems.Add(wfItem.AssignedToName);
                lvItem.SubItems.Add(wfItem.Status);

                workflowItemsListView.Items.Add(lvItem);
                ++lvItemCount;
            }

            // notify items were added
            SetStatusLabelAndTimer($"{lvItemCount} items added");

            // Set details count labels
            SetDatabaseDetailsProperties();

            // enable lvOption btns
            EnableOptionsPanels();

            // add item sorter back
            workflowItemsListView.ListViewItemSorter = lvwColumnSorter;

            workflowItemsListView.EndUpdate();

            // unignore the itemChecked event
            itemCheckedEventIgnored = false;

            //invoke form resize
            this.WorkflowManager_Resize(this, null);
        }

        private void PopulateDetailsViewData(WorkflowItem wi)
        {
            if (wi == null)
            {
                SetStatusLabelAndTimer("Null object reference");
                MakeErrorSound();
                return;
            }

            documentWorkflowItemIdTbx.Text = wi.DocumentWorkflowItemID;

            companyNameTbx.Text = wi.VendorName;

            if (contractIdDescLbl.Text == "> Contract ID:")
                contractIdTbx.Text = wi.ContractID;
            else contractIdTbx.Text = wi.CertusFileID;

            if (nextExpDateDescLbl.Text == "> Issue Date:")
            {
                if (wi.IssueDate.HasValue) nextExpDateTbx.Text = wi.IssueDate.Value.ToShortDateString();
                else nextExpDateTbx.Text = "";
            }
            else
            {
                if (wi.NextExpirationDate.HasValue) nextExpDateTbx.Text = wi.NextExpirationDate.Value.ToShortDateString();
                else nextExpDateTbx.Text = "";
            }

            activeTbx.Text = wi.Active.ToString();

            compliantTbx.Text = wi.Compliant.ToString();

            if (compliantDescLbl.Text == "> Compliant:")
                compliantTbx.Text = wi.Compliant.ToString();
            else if (compliantDescLbl.Text == ">> Was Compliant:")
                compliantTbx.Text = "n/a";

            if (filesAttachedDescLbl.Text == "> Files Attached:")
                if (wi.ItemsAttached != null && wi.ItemsAttached.Count > 0)
                    filesAttachedTbx.Text = wi.ItemsAttached.Count.ToString();
                else filesAttachedTbx.Text = String.Empty;
            else if (filesAttachedDescLbl.Text == ">> Files w/ this Size:")
                if (wi.ItemsWithThisFileSize != 0)
                    filesAttachedTbx.Text = wi.ItemsWithThisFileSize.ToString();
                else
                    filesAttachedTbx.Text = "n/a";
            else if (filesAttachedDescLbl.Text == ">>> Files w/ this Name:")
                if (wi.ItemsWithThisFileName != 0)
                    filesAttachedTbx.Text = wi.ItemsWithThisFileName.ToString();
                else
                    filesAttachedTbx.Text = "n/a";
            if (fileSizeDescLbl.Text == "> File Size:")
                fileSizeTbx.Text = wi.FileSize;
            else if (fileSizeDescLbl.Text == ">> All Attachments Size:")
                if (wi.AllAttachmentsSize != 0)
                    fileSizeTbx.Text = wi.AllAttachmentsSize.ToString();
                else
                    fileSizeTbx.Text = "n/a";

            if (fileMimeDescLbl.Text == "> File MIME:")
                fileMimeTbx.Text = wi.FileMIME;
            else if (fileMimeDescLbl.Text == ">> File Type:")
                fileMimeTbx.Text = "n/a";

            if (assignedToDescLbl.Text == "> Assigned To:")
                assignedToTbx.Text = wi.AssignedToName;
            else if (assignedToDescLbl.Text == ">> Assigned ID:")
                assignedToTbx.Text = wi.AssignedToID;
            else if (assignedToDescLbl.Text == ">>> Workflow Analyst:")
                assignedToTbx.Text = wi.WorkflowAnalyst;
            else if (assignedToDescLbl.Text == ">>>> Compliance Analyst:")
                assignedToTbx.Text = wi.CompanyAnalyst;

            if (statusDescLbl.Text == "> Status:")
                statusTbx.Text = wi.Status;
            else if (statusDescLbl.Text == ">> Display Color:")
                statusTbx.Text = wi.DisplayColor;

            dateCompTbx.Text = "n/a";
            if (dateCompDescLbl.Text == "> Date Completed:")
                dateCompTbx.Text = "n/a";
            else if (dateCompDescLbl.Text == ">> Date Added:")
                dateCompTbx.Text = wi.EmailDate.Value.ToShortDateString();

            emailDateTbx.Text = wi.EmailDate.ToString();

            emailFromTbx.Text = wi.EmailFromAddress;

            subjectTbx.Text = wi.SubjectLine;

            fileNameTbx.Text = wi.FileName;

            fileUrlTbx.Text = wi.FileURL;

            detailNoteTbx.Text = wi.Note;

            // notification symbols
            if (wi.WorkflowItemInformationDifferentThanCertus) itemIsDifferentBtn.Visible = true;
            else itemIsDifferentBtn.Visible = false;

            if (wi.Excluded==true) itemExcludedBtn.Visible = true;
            else itemExcludedBtn.Visible = false;

            if (wi.ContractIdOverridden) contractIdOverridenBtn.Visible = true;
            else contractIdOverridenBtn.Visible = false;

            if (wi.ContractInformationUpdated) contractInformationUpdatedBtn.Visible = true;
            else contractInformationUpdatedBtn.Visible = false;

            if (wi.CompanyUpdated) companyUpdatedBtn.Visible = true;
            else companyUpdatedBtn.Visible = false;

            if (wi.ItemHasPriority) priorityNotificationBtn.Visible = true;
            else priorityNotificationBtn.Visible = false;
        }

        private void PopulateImportLbx(List<WorkflowItemCSVImport> imports)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = imports;

            try
            {
                this.itemImportsLbx.DataSource = bs;
            }
            catch
            {

            }
        }

        private void PopulateImportViewData(WorkflowItemCSVImport itemImport)
        {
            this.importDateTbx.Text = itemImport.ImportDate.ToLongDateString();
            this.importFileNameTbx.Text = itemImport.FileName;
            this.importTypeTbx.Text = itemImport.ImportType;
            this.itemsOnImportTbx.Text = itemImport.TotalItemsOnImport.ToString();
            this.itemsAddedTbx.Text = itemImport.NewItemsAdded.Count.ToString();
            if (itemImport.CompletedSinceLastImport.Count == 1)
            {
                // this is most likely just the line which shows "n/a", so show 0
                this.itemsCompTbx.Text = "0";
            }
            else
            {
                this.itemsCompTbx.Text = itemImport.CompletedSinceLastImport.Count.ToString();
            }
        }

        #endregion Populate Data

        // ----- LONG PROCESS TASKS ----- //
        #region Long Process Tasks

        #region Load App Data

        private void loadBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            DimForm();
            LoadingForm = new LoadingForm();
            LoadingForm.Owner = this.TransparentForm;

            if (this.TransparentForm.InvokeRequired)
                this.TransparentForm.Invoke(new Action(() => { LoadingForm.Show(this.TransparentForm); }));
            else
                LoadingForm.Show(this.TransparentForm);

            if (this.InvokeRequired)
            {
                //this.Invoke(new Action(() => { ShowAndFocusForm(loadingForm); }));
                this.Invoke(new Action(() => { LoadingForm.ChangeLabel("Loading App Data"); }));
                this.Invoke(new Action(() => { LoadingForm.Refresh(); }));
                this.Invoke(new Action(() => { LoadAppData(e.Argument.ToString()); }));
            }
            else
            {
                //ShowAndFocusForm(loadingForm);
                LoadingForm.ChangeLabel("Loading App Data");
                LoadingForm.Refresh();
                LoadAppData(e.Argument.ToString());
            }
        }

        private void LoadAppData(string file)
        {
            this.AppSave = new AppSave();

            Cursor.Current = Cursors.WaitCursor;

            string fileName = file;

            //try
            //{
            //this.loadingForm.ChangeLabel("Loading app save");
            this.AppSave.Load(fileName);
            this.loadBackgroundWorker.ReportProgress(10);
            //this.loadingForm.Refresh();
            //}
            //catch (Exception)
            //{
            //    throw new AppSaveLoadFailedException("Loading failed; could not load 'AppSave'");
            //}

            try
            {
                //this.loadingForm.ChangeLabel("Loading app data");
                this.AppData = AppSave.MostRecentSave;
                this.StoreAppDataToForm(AppData);
                this.loadBackgroundWorker.ReportProgress(10);
                //this.loadingForm.Refresh();
            }
            catch (Exception)
            {
                throw new AppDataLoadFailedException("Loading failed; could not load 'AppData'");
            }
            try
            {
                //this.loadingForm.ChangeLabel("Loading imports list");
                this.ItemImportsList = AppData.ItemImportsList;
                this.loadBackgroundWorker.ReportProgress(10);
                //this.loadingForm.Refresh();
            }
            catch (Exception)
            {
                throw new ItemImportsLoadFailedException("Loading failed; could not load 'ItemImports'");
            }
            try
            {
                //this.loadingForm.ChangeLabel("Loading completed reports");
                this.ItemsCompletedReportsList = AppData.ItemsCompletedReportsList;
                this.loadBackgroundWorker.ReportProgress(10);
                //this.loadingForm.Refresh();
            }
            catch (Exception)
            {
                throw new ItemsCompletedReportsLoadFailedException("Loading failed; could not load 'ItemsCompletedReports'");
            }
            try
            {
                //this.loadingForm.ChangeLabel("Loading item list");
                this.WorkflowItemDatabase = AppData.WorkflowItemDatabase;
                this.loadBackgroundWorker.ReportProgress(10);
                //this.loadingForm.Refresh();
            }
            catch (Exception)
            {
                throw new WorkflowItemDatabaseLoadFailedException("Loading failed; could not load 'WorkflowItemDatabase'");
            }
        }

        internal void StoreAppDataToForm(AppData appData)
        {
            this.AppData = appData;

            // save database to list of workflow items
            this.AllWorkflowItemsLoaded = AppData.WorkflowItemDatabase.ReturnAllItemsFromDatabase();

            // set non completed items list
            SetNonCompletedItemsList();

            // save item imports
            this.AllItemImportsLoaded = AppData.ItemImportsList.ReturnAllImports();

            // save reports
            this.AllItemsCompletedReportsLoaded = AppData.ItemsCompletedReportsList.ReturnAllReports();
        }

        private void loadBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                SetStatusLabelAndTimer("Operation was canceled");
                MakeErrorSound();
            }
            else if (e.Error != null)
            {
                MessageBox.Show("Could not load data\n\ne.Error.Message", "Error");
                if (CheckIfFormIsOpened("Transparent Form"))
                    this.Invoke(new Action(() => { TransparentForm.Close(); }));
            }
            else
            {
                if (this.InvokeRequired)
                    this.Invoke(new Action(() => { LoadingForm.ChangeLabel("Populating views"); }));
                else
                    LoadingForm.ChangeLabel("Populating views");
                this.LoadingForm.Refresh();

                // populate lv  
                this.viewChoiceComboBox.SelectedIndex = 1;

                PopulateImportLbx(this.AllItemImportsLoaded);

                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() => { this.LoadingForm.CompleteProgress(); }));
                    this.Invoke(new Action(() => { this.LoadingForm.ChangeLabel("Items loaded successfully"); }));
                    this.Invoke(new Action(() => { this.loadingFormTimer.Enabled = true; }));
                }
                else
                {
                    this.LoadingForm.CompleteProgress();
                    this.LoadingForm.ChangeLabel("Items loaded successfully");
                    this.loadingFormTimer.Enabled = true;
                }
            }
        }

        #endregion Load App Data

        #region Save App Data

        private void saveBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            SaveFileDialog saveFileDialog = e.Argument as SaveFileDialog;

            if (this.InvokeRequired)
                this.Invoke(new Action(() =>
                {
                    SetStatusLabelAndTimer("Saving database items", true);
                    SaveAllWorkflowItemsLoadedToDB();
                    SaveItemImportsToItemImportsList();
                    SaveItemsCompletedReportsToItemsCompletedReportsList();

                    SetStatusLabelAndTimer("Storing app data", true);
                    SaveAppData(saveFileDialog.FileName);
                }));
            else
            {
                SetStatusLabelAndTimer("Saving database items", true);
                SaveAllWorkflowItemsLoadedToDB();
                SaveItemImportsToItemImportsList();
                SaveItemsCompletedReportsToItemsCompletedReportsList();

                SetStatusLabelAndTimer("Storing app data", true);
                SaveAppData(saveFileDialog.FileName);
            }
        }

        private void SaveAllWorkflowItemsLoadedToDB()
        {
            // if the database doesn't currently exist, we want to save the items currently loaded as the first of the DB items
            if (WorkflowItemDatabase == null || WorkflowItemDatabase.CountOfItemsInDB() == 0)
            {
                // passing list in constructor assign items to the list within the DB
                WorkflowItemDatabase = new WorkflowItemDatabase(AllWorkflowItemsLoaded);
            }
            // if there is a database and it has items
            else if (WorkflowItemDatabase != null && WorkflowItemDatabase.CountOfItemsInDB() > 0)
            {
                // save update selection option for determining what to do when when adding a duplicate item
                bool updateOlderItems = true;

                if (addAndUpdateCheckBox.Checked == false)
                {
                    updateOlderItems = false;
                }

                // add current loaded items to DB
                WorkflowItemDatabase.AddWorkflowItemList(AllWorkflowItemsLoaded, updateOlderItems);
            }
        }

        private void SaveItemImportsToItemImportsList()
        {
            // if the list doesn't currently exist, we want to assign the current list through the constructor 
            if (ItemImportsList == null || ItemImportsList.CountOfImportsInList() == 0)
            {
                // pass list in constructor to assign all current imports to the list within the DB
                ItemImportsList = new ItemImports(AllItemImportsLoaded);
            }
            // if there is a list and it has imports
            else if (ItemImportsList != null && ItemImportsList.CountOfImportsInList() > 0)
            {
                // add current loaded imports (class method will ignore duplicate imports
                ItemImportsList.AddImportList(AllItemImportsLoaded);
            }
        }

        private void SaveItemsCompletedReportsToItemsCompletedReportsList()
        {
            //// if the list doesn't currently exist, we want to assign the current list through the constructor 
            //if (ItemsCompletedReportsList == null || ItemsCompletedReportsList.CountOfReportsInList() == 0)
            //{
            // pass list in constructor to assign all current imports to the list within the DB
            ItemsCompletedReportsList = new ItemsCompletedReports(AllItemsCompletedReportsLoaded);
            //}
            //// if there is a list and it has reports
            //else if (ItemsCompletedReportsList != null && ItemsCompletedReportsList.CountOfReportsInList() > 0)
            //{
            //    // add current loaded reports (class method will ignore duplicate imports)
            //    ItemsCompletedReportsList.AddItemsCompletedReportList(AllItemsCompletedReportsLoaded);
            //}
        }

        private void SaveAppData(string file)
        {
            string fileName = file;

            //if (this.AppData == null)
            //{
            //    AppData = new AppData(WorkflowItemDatabase, ItemImportsList, ItemsCompletedReportsList);
            //}
            //else
            //{
            //    AppData = new AppData(workflowItemDatabase, AppData.WorkflowItemDatabase, ItemImportsList, ItemsCompletedReportsList);
            //}
            AppData = new AppData(WorkflowItemDatabase, ItemImportsList, ItemsCompletedReportsList);

            //if(AppSave==null||AppSave.SaveCount()==0)
            //if (AppSave == null)
            //{
            //    // add instance
            //    AppSave = new AppSave();
            //}
            //AppSave.AddSave(AppData);
            //AppSave.Save(fileName);

            AppSave = new AppSave();
            AppSave.AddSave(AppData);
            AppSave.Save(fileName);

            // ***database was still saved on this form even though this ran into a problem. this has to be taken into consideration if a save goes wrong in the future
            // database is no longer null and has items. may want to clear the instances if an exception is caught so that a new save will function as intended.
            // also may not want to do this because then properly loaded data will be lost. some sort of 'undo' method to remove these added items/imports/reports 
            // may be the solution.***
        }

        private void saveBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("Save unsuccessful\n\ne.Error.Message", "Error");
            }
            else
            {
                SetStatusLabelAndTimer("Save successful");
            }

            AllWorkflowItemsLoaded = WorkflowItemDatabase.ReturnAllItemsFromDatabase();
            if (this.viewChoiceComboBox.SelectedIndex == 0)
            {
                this.viewChoiceComboBox.SelectedIndex = -1;
                this.viewChoiceComboBox.SelectedIndex = 0;
            }
            UseWaitCursor = false;
            Cursor.Current = Cursors.Default;
        }

        #endregion Save App Data

        #region Import

        private void importWorkflowCSVBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            OpenFileDialog openFileDialog = e.Argument as OpenFileDialog;
            importFilesSelected = openFileDialog.FileNames.Count();
            DimForm();
            LoadingForm = new LoadingForm();

            if (TransparentForm.InvokeRequired)
            {
                TransparentForm.Invoke(new Action(() => { LoadingForm.Show(TransparentForm); }));
            }
            else
            {
                LoadingForm.Show(TransparentForm);
            }

            for (int i = 0; i < importFilesSelected; i++)
            {
                importFileName = openFileDialog.FileNames[i];

                if (AllWorkflowItemsLoaded != null && AllWorkflowItemsLoaded.Count > 0)
                {
                    CurrentImport = new WorkflowItemCSVImport(AllWorkflowItemsLoaded);
                }
                else
                {
                    CurrentImport = new WorkflowItemCSVImport();
                }

                //SetStatusLabelAndTimer($"Importing file {importFileBeingWorkedOn} of {importFilesSelected}", true);
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() => { LoadingForm.ChangeLabel($"Importing file {i + 1} of {importFilesSelected}"); }));
                    this.Invoke(new Action(() => { LoadingForm.Refresh(); }));
                }
                else
                {
                    LoadingForm.ChangeLabel($"Importing file {i + 1} of {importFilesSelected}");
                    LoadingForm.Refresh();
                }

                // import the file
                CurrentImport.Import(importFileName); // 1: 1,600ms; 2: 38,000ms, 3: 49,000ms

                //SetStatusLabelAndTimer("Adding imported items to the current list", true);
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() => { importWorkflowItemsBackgroundWorker.ReportProgress((int)(50 / importFilesSelected)); }));
                    this.Invoke(new Action(() => { LoadingForm.ChangeLabel("Adding imported items to the current list"); }));
                    this.Invoke(new Action(() => { LoadingForm.Refresh(); }));
                }
                else
                {
                    //importWorkflowItemsBackgroundWorker.ReportProgress((int)(50 / importFilesSelected));
                    LoadingForm.ChangeLabel("Adding imported items to the current list");
                    LoadingForm.Refresh();
                }
                importFileBeingWorkedOn++;

                // add to AllWorkflowItemsLoaded - will report progress within the method
                AddItemsToAllWorkflowItemsLoaded(CurrentImport.CurrentImportItems, importFilesSelected*2);

                // set non completed items list
                SetNonCompletedItemsList();

                // clear the current import items and current items in db from the current import
                CurrentImport.ClearDataNotToBeSaved();

                // save this import
                AllItemImportsLoaded.Add(CurrentImport);

                //if (this.InvokeRequired)
                //{
                //    this.Invoke(new Action(() => { importWorkflowItemsBackgroundWorker.ReportProgress((int)(50 / importFilesSelected)); }));
                //}
                //else
                //{
                //    importWorkflowItemsBackgroundWorker.ReportProgress((int)(50 / importFilesSelected));
                //}
            }

            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => { LoadingForm.ChangeLabel("Populating items"); }));
                this.Invoke(new Action(() => { LoadingForm.Refresh(); }));
            }
            else
            {
                LoadingForm.ChangeLabel("Populating items");
                LoadingForm.Refresh();
            }

            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => { LoadingForm.Refresh(); }));
            }
            else
            {
                LoadingForm.Refresh();
            }
        }

        private void importWorkflowCSVBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                SetStatusLabelAndTimer("Operation was canceled");
                MakeErrorSound();
            }
            else if (e.Error != null)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() => { this.LoadingForm.ShowCloseBtn(); }));
                    this.Invoke(new Action(() => { this.LoadingForm.HideBar(); }));
                    this.Invoke(new Action(() => { this.LoadingForm.ChangeHeaderLabel("Import Unsuccessful"); }));
                    this.Invoke(new Action(() => { this.LoadingForm.ChangeLabel($"{e.Error.Message}"); }));
                    this.Invoke(new Action(() => { LoadingForm.Refresh(); }));
                }
                else
                {
                    this.LoadingForm.ShowCloseBtn();
                    this.LoadingForm.HideBar();
                    this.LoadingForm.ChangeHeaderLabel("Import Unsuccessful");
                    this.LoadingForm.ChangeLabel($"{e.Error.Message}");
                    this.LoadingForm.Refresh();
                }
            }
            else
            {
                // populate lv
                this.viewChoiceComboBox.SelectedIndex = 1;

                // populate lbx
                PopulateImportLbx(this.AllItemImportsLoaded);

                //SetStatusLabelAndTimer("Import successful");
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() => { this.LoadingForm.ShowCloseBtn(); }));
                    this.Invoke(new Action(() => { this.LoadingForm.CompleteProgress(); }));
                    this.Invoke(new Action(() => { this.LoadingForm.ChangeLabel("Items imported successfully"); }));
                    this.Invoke(new Action(() => { LoadingForm.Refresh(); }));
                }
                else
                {
                    this.LoadingForm.ShowCloseBtn();
                    this.LoadingForm.CompleteProgress();
                    this.LoadingForm.ChangeLabel("Items imported successfully");
                    this.LoadingForm.Refresh();
                }
            }

            UseWaitCursor = false;
            Cursor.Current = Cursors.Default;
        }

        private void importCertificatesBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            OpenFileDialog openFileDialog = e.Argument as OpenFileDialog;
            importFileName = openFileDialog.FileName;
            DimForm();
            LoadingForm = new LoadingForm();
            string csvFileHeaderLine;
            string[] csvFileHeaderValues;
            string[] acceptableHeaderValues =
            {
                "BCS Certificate ID",
                "Certificate Name",
                "Company Name",
                "BCS Company ID",
                "Ins. Req. Category",
                "Issue Date",
                "Next Policy Expiration Date",
                "Certificate Active",
                "Certificate Compliant",
                "Back To Client Status",
                "Buildings",
                "Certificate Last Note Date",
                "Client",
                "Market",
                "Service Type"
            };
            int[] acceptableHeaderValueIndexes = { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
            string csvLine = "";
            Certificate certificateToImport;
            Boolean parsedBoolValue;
            DateTime parsedDateTimeValue;
            AllCertificatesLoaded = new List<Certificate>();
            certificateDictionary = new Dictionary<string, Certificate>();
            int fileOn = 0;

            if (TransparentForm.InvokeRequired)
            {
                TransparentForm.Invoke(new Action(() => { LoadingForm.Show(TransparentForm); }));
            }
            else
            {
                LoadingForm.Show(TransparentForm);
            }

            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => { LoadingForm.ChangeLabel("Importing certificates..."); }));
                this.Invoke(new Action(() => { LoadingForm.Refresh(); }));
            }
            else
            {
                LoadingForm.ChangeLabel("Importing certificates...");
                LoadingForm.Refresh();
            }

            // Opens the csv file for reading
            using (StreamReader sr = new StreamReader(importFileName))
            {
                // save file length data for reporting progress
                Stream baseStream = sr.BaseStream;
                long length = baseStream.Length;

                // Reads header first and stores it as array of strings
                csvFileHeaderLine = sr.ReadLine();

                csvFileHeaderValues = Regex.Split(csvFileHeaderLine, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");

                // remove paranthesis if comma is in value
                for (int i = 0; i < csvFileHeaderValues.Length; i++)
                {
                    if (csvFileHeaderValues[i].Contains(',') == true)
                    {
                        csvFileHeaderValues[i] = csvFileHeaderValues[i].Remove(0, 1);
                        csvFileHeaderValues[i] = csvFileHeaderValues[i].Remove(csvFileHeaderValues[i].Length - 1, 1);
                    }
                }

                // store header indexes if string values match any of the acceptable header values
                for (int i = 0; i < csvFileHeaderValues.Length; i++)
                {
                    for (int j = 0; j < acceptableHeaderValues.Length; j++)
                    {
                        if (csvFileHeaderValues[i] == acceptableHeaderValues[j])
                        {
                            acceptableHeaderValueIndexes[j] = i;
                        }
                    }
                }

                // right now, return if BCS id and Certificate number are not in their correct places
                if (acceptableHeaderValueIndexes[0] != 0 && acceptableHeaderValueIndexes[1] != 1)
                {
                    throw new CertificateImportNotCorrectFormatException("CSV file is not recognized as an acceptable Certificate Export. BCS Certificate ID must be in the first column followed by the Certificate Name in the second column.");
                }

                // Read the rest of the csv line by line
                while ((csvLine = sr.ReadLine()) != null)
                {
                    ++fileOn;

                    // return fields in a string array split by commas (not including those which are within quotations)
                    // CHANGE COMMA TO SEMICOLON HERE IF .SCSV
                    string[] result = Regex.Split(csvLine, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");

                    // remove paranthesis if comma is in value
                    for (int i = 0; i < result.Length; i++)
                    {
                        if (result[i].Contains(',') == true)
                        {
                            result[i] = result[i].Remove(0, 1);
                            result[i] = result[i].Remove(result[i].Length - 1, 1);
                        }
                    }

                    // BCS Certificate ID has to be there and has to be first***
                    string bcsCertificateID = result[acceptableHeaderValueIndexes[0]];

                    // Certificate Name has to be second
                    string certificateName = result[acceptableHeaderValueIndexes[1]];

                    // for the rest, let the default data populate if index wasn't found (-1), the result values aren't this long, or the result value is null
                    string companyName = "";
                    if (acceptableHeaderValueIndexes[2] > 0 && result.Length > 2 && result[acceptableHeaderValueIndexes[2]] != null)
                    {
                        companyName = result[acceptableHeaderValueIndexes[2]];
                    }

                    string bcsCompanyID = "";
                    if (acceptableHeaderValueIndexes[3] > 0 && result.Length > 3 && result[acceptableHeaderValueIndexes[3]] != null)
                    {
                        bcsCompanyID = result[acceptableHeaderValueIndexes[3]];
                    }

                    string insReqCategory = "";
                    if (acceptableHeaderValueIndexes[4] > 0 && result.Length > 4 && result[acceptableHeaderValueIndexes[4]] != null)
                    {
                        insReqCategory = result[acceptableHeaderValueIndexes[4]];
                    }

                    DateTime? issueDate = null;
                    if (acceptableHeaderValueIndexes[5] > 0 && result.Length > 5 && result[acceptableHeaderValueIndexes[5]] != null)
                    {
                        if (DateTime.TryParse(result[acceptableHeaderValueIndexes[5]], out parsedDateTimeValue))
                        {
                            issueDate = parsedDateTimeValue;
                        }
                        else
                        {
                            issueDate = null;
                        }
                    }

                    DateTime? nextPolicyExpirationDate = null;
                    if (acceptableHeaderValueIndexes[6] > 0 && result.Length > 6 && result[acceptableHeaderValueIndexes[6]] != null)
                    {
                        if (DateTime.TryParse(result[acceptableHeaderValueIndexes[6]], out parsedDateTimeValue))
                        {
                            nextPolicyExpirationDate = parsedDateTimeValue;
                        }
                        else
                        {
                            nextPolicyExpirationDate = null;
                        }
                    }

                    bool? certificateActive = null;
                    if (acceptableHeaderValueIndexes[7] > 0 && result.Length > 7 && result[acceptableHeaderValueIndexes[7]] != null)
                    {
                        if (Boolean.TryParse(result[acceptableHeaderValueIndexes[7]], out parsedBoolValue))
                        {
                            if (parsedBoolValue)
                            {
                                certificateActive = parsedBoolValue;
                            }
                            else
                            {
                                certificateActive = parsedBoolValue;
                            }
                        }
                        else
                        {
                            certificateActive = null;
                        }
                    }

                    bool? certificateCompliant = null;
                    if (acceptableHeaderValueIndexes[8] > 0 && result.Length > 8 && result[acceptableHeaderValueIndexes[8]] != null)
                    {
                        if (Boolean.TryParse(result[acceptableHeaderValueIndexes[8]], out parsedBoolValue))
                        {
                            if (parsedBoolValue)
                            {
                                certificateCompliant = parsedBoolValue;
                            }
                            else
                            {
                                certificateCompliant = parsedBoolValue;
                            }
                        }
                        else
                        {
                            certificateCompliant = null;
                        }
                    }

                    string backToClientStatus = "";
                    if (acceptableHeaderValueIndexes[9] > 0 && result.Length > 9 && result[acceptableHeaderValueIndexes[9]] != null)
                    {
                        backToClientStatus = result[acceptableHeaderValueIndexes[9]];
                    }

                    string buildings = "";
                    if (acceptableHeaderValueIndexes[10] > 0 && result.Length > 10 && result[acceptableHeaderValueIndexes[10]] != null)
                    {
                        buildings = result[acceptableHeaderValueIndexes[10]];
                    }

                    DateTime? lastNoteDate = null;
                    if (acceptableHeaderValueIndexes[11] > 0 && result.Length > 11 && result[acceptableHeaderValueIndexes[11]] != null)
                    {
                        if (DateTime.TryParse(result[acceptableHeaderValueIndexes[11]], out parsedDateTimeValue))
                        {
                            lastNoteDate = parsedDateTimeValue;
                        }
                        else
                        {
                            issueDate = null;
                        }
                    }

                    string client = "";
                    if (acceptableHeaderValueIndexes[12] > 0 && result.Length > 12 && result[acceptableHeaderValueIndexes[12]] != null)
                    {
                        client = result[acceptableHeaderValueIndexes[12]];
                    }

                    string market = "";
                    if (acceptableHeaderValueIndexes[13] > 0 && result.Length > 13 && result[acceptableHeaderValueIndexes[13]] != null)
                    {
                        market = result[acceptableHeaderValueIndexes[13]];
                    }

                    string serviceType = "";
                    if (acceptableHeaderValueIndexes[14] > 0 && result.Length > 14 && result[acceptableHeaderValueIndexes[14]] != null)
                    {
                        serviceType = result[acceptableHeaderValueIndexes[14]];
                    }

                    // construct the certificate from the line item and whatever was extracted
                    certificateToImport = new Certificate(bcsCertificateID, certificateName, companyName, bcsCompanyID, insReqCategory, issueDate, nextPolicyExpirationDate, certificateActive, certificateCompliant, backToClientStatus, buildings, lastNoteDate, client, market, serviceType);

                    // add to certificates list IF NOT THERE
                    if (!this.certificateDictionary.ContainsKey(certificateToImport.CertificateName))
                    {
                        this.AllCertificatesLoaded.Add(certificateToImport);
                        this.certificateDictionary.Add(certificateToImport.CertificateName, certificateToImport);
                    }

                    // report progress
                    if (this.InvokeRequired)
                    {
                        this.Invoke(new Action(() => { importCertificatesBackgroundWorker.ReportProgress(Convert.ToInt32((baseStream.Position / (double)length) * 100)); }));
                    }
                    else
                        importCertificatesBackgroundWorker.ReportProgress(Convert.ToInt32(baseStream.Position / length * 100));
                }

                // reset progress
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        LoadingForm.ResetBar();
                        LoadingForm.ChangeLabel("Adding certificate information to workflow items...");
                        LoadingForm.Refresh();
                    }));
                }
                else
                {
                    LoadingForm.ResetBar();
                    LoadingForm.ChangeLabel("Adding certificate information to workflow items...");
                    LoadingForm.Refresh();
                }

                // update items with certificate data
                #region Update WF Items
                List<WorkflowItem> itemsToUpdate = new List<WorkflowItem>();

                itemsUpdated = 0;
                itemsUpToDate = 0;
                itemsWhereContractUnrecognized = 0;
                itemsWithNoCertificate = 0;

                // for loading bar
                int valueToIncrement = AllWorkflowItemsLoaded.Count / 50;
                if (valueToIncrement <= 0) valueToIncrement = 1;
                int itemOn = 0;

                foreach (WorkflowItem wi in AllWorkflowItemsLoaded)
                {
                    List<string> companyIdsToCheck = new List<string>();
                    List<Company> companiesToCheck = new List<Company>();
                    Certificate contract = new Certificate();

                    // keep track of which item is being iterated for the loading bar
                    ++itemOn;

                    // update loading progress for increment value 
                    if (itemOn % valueToIncrement == 0)
                    {
                        if (this.InvokeRequired)
                        {
                            this.Invoke(new Action(() =>
                            {
                                LoadingForm.MoveBar(1);
                                //this.loadingForm.Refresh();
                            }));
                        }
                        else
                        {
                            LoadingForm.MoveBar(1);
                            //this.loadingForm.Refresh();
                        }
                    }

                    // if there's a contract id for the item
                    if (wi.ContractID != null && wi.ContractID != String.Empty)
                    {
                        // if the contract id is recognized
                        if (certificateDictionary.ContainsKey(wi.ContractID))
                        {
                            // get this contract
                            contract = certificateDictionary[wi.ContractID];

                            // if any contract related info is different
                            if (wi.Active != contract.CertificateActive || wi.Active != contract.CertificateCompliant)
                            { 
                                // update contract info
                                wi.Active = contract.CertificateActive;
                                wi.Compliant = contract.CertificateCompliant;
                                wi.NextExpirationDate = contract.NextPolicyExpirationDate;
                                wi.ContractInformationUpdated = true;

                                // an item will be marked as updated even if only the company needs changing... this is fine. companyName is now technically contract info
                                ++itemsUpdated;

                                itemsToUpdate.Add(wi);
                            }
                            else
                            {
                                ++itemsUpToDate;
                            }
                        }
                        else ++itemsWhereContractUnrecognized;
                    }
                    else ++itemsWithNoCertificate;
                }

                // update status
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        LoadingForm.ChangeLabel("Updating items...");
                        LoadingForm.Refresh();
                    }));
                }
                else
                {
                    LoadingForm.ChangeLabel("Updating items...");
                    LoadingForm.Refresh();
                }

                if (itemsToUpdate != null && itemsToUpdate.Count > 0) UpdateAllLoadedWorkflowItems(itemsToUpdate);
                #endregion Update WF Items
            }
        }

        private void importCertificatesBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                SetStatusLabelAndTimer("Operation was canceled");
                MakeErrorSound();
            }
            else if (e.Error != null)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() => { this.LoadingForm.ShowCloseBtn(); }));
                    this.Invoke(new Action(() => { this.LoadingForm.HideBar(); }));
                    this.Invoke(new Action(() => { this.LoadingForm.ChangeHeaderLabel("Import Unsuccessful"); }));
                    this.Invoke(new Action(() => { this.LoadingForm.ChangeLabel($"{e.Error.Message}"); }));
                    this.Invoke(new Action(() => { LoadingForm.Refresh(); }));
                }
                else
                {
                    this.LoadingForm.ShowCloseBtn();
                    this.LoadingForm.HideBar();
                    this.LoadingForm.ChangeHeaderLabel("Import Unsuccessful");
                    this.LoadingForm.ChangeLabel($"{e.Error.Message}");
                    this.LoadingForm.Refresh();
                }
            }
            else
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() => { this.LoadingForm.ShowCloseBtn(); }));
                    this.Invoke(new Action(() => { this.LoadingForm.CompleteProgress(); }));
                    this.Invoke(new Action(() => { this.LoadingForm.ChangeLabel("Certificates imported successfully"); }));
                    this.Invoke(new Action(() => { LoadingForm.Refresh(); }));
                }
                else
                {
                    this.LoadingForm.ShowCloseBtn();
                    this.LoadingForm.CompleteProgress();
                    this.LoadingForm.ChangeLabel("Certificates imported successfully");
                    this.LoadingForm.Refresh();
                }
            }

            UseWaitCursor = false;
        }

        private void importCompaniesBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            OpenFileDialog openFileDialog = e.Argument as OpenFileDialog;
            importFileName = openFileDialog.FileName;
            DimForm();
            LoadingForm = new LoadingForm();
            string csvFileHeaderLine;
            string[] csvFileHeaderValues;
            string csvLine = "";
            Company companyToImport;
            Boolean parsedBoolValue;
            int otherContactHeaders = 0;
            bool stopSettingIndex = false;

            #region Instantiate Acceptable Headers and Indexes List
            List<Tuple<int, string>> acceptableHeaderValuesAndTheirIndexes = new List<Tuple<int, string>>();

            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "BCS Company ID"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Company Name"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Vendor ID"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "DBA"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Address 1"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Address 2"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "City"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "State"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Zip"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Country"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Phone #"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Email Address"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Company Active"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Company Compliance Level"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Analyst"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Company Last Note Date"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Main Contact"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Other Contact"));
            #endregion Instantiate Acceptable Headers and Indexes List

            #region Set Up Loading Form
            if (TransparentForm.InvokeRequired)
            {
                TransparentForm.Invoke(new Action(() => { LoadingForm.Show(TransparentForm); }));
            }
            else
            {
                LoadingForm.Show(TransparentForm);
            }

            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => { LoadingForm.ChangeLabel("Importing companies"); }));
                this.Invoke(new Action(() => { LoadingForm.Refresh(); }));
            }
            else
            {
                LoadingForm.ChangeLabel("Importing companies");
                LoadingForm.Refresh();
            }
            #endregion Set Up Loading Form

            // Open csv file for reading
            using (StreamReader sr = new StreamReader(importFileName))
            {
                // save file length data for reporting progress
                Stream baseStream = sr.BaseStream;
                long length = baseStream.Length;

                #region Save Header
                // Read header first and store
                csvFileHeaderLine = sr.ReadLine();
                csvFileHeaderValues = Regex.Split(csvFileHeaderLine, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");

                // remove paranthesis if comma is in value
                for (int i = 0; i < csvFileHeaderValues.Length; i++)
                {
                    if (csvFileHeaderValues[i].Contains(',') == true)
                    {
                        csvFileHeaderValues[i] = csvFileHeaderValues[i].Remove(0, 1);
                        csvFileHeaderValues[i] = csvFileHeaderValues[i].Remove(csvFileHeaderValues[i].Length - 1, 1);
                    }
                }

                // store header indexes if string values match any of the acceptable header values
                for (int i = 0; i < csvFileHeaderValues.Length; i++)
                {
                    for (int j = 0; j < acceptableHeaderValuesAndTheirIndexes.Count; j++)
                    {
                        if (csvFileHeaderValues[i].Contains(acceptableHeaderValuesAndTheirIndexes[j].Item2))
                        {
                            // save new tuple which contains the correct index location for the header 
                            Tuple<int, string> newTuple;
                            int index = acceptableHeaderValuesAndTheirIndexes.IndexOf(acceptableHeaderValuesAndTheirIndexes[j]);
                            string accHeader = acceptableHeaderValuesAndTheirIndexes[j].Item2;
                            newTuple = new Tuple<int, string>(i, accHeader);

                            // this will only affect anything if there's ever header values listed after the other contacts
                            if (!stopSettingIndex)
                            {
                                // replace old tuple with the new one
                                acceptableHeaderValuesAndTheirIndexes[index] = newTuple;
                            }
                            stopSettingIndex = false;

                            // if this is the main contact header, we want to skip the next 3 indexes
                            if (accHeader == "Main Contact")
                            {
                                i += 3;
                            }

                            // if this is an other contact header, we want to skip 3 indexes (theres 4 indexes for each contact - 
                            // name, title, phone, and email) and save how many other contacts we find. We also want to ignore setting
                            // the index for the additional other contacts because this will be done through using the other countacts
                            // int value
                            if (accHeader == "Other Contact")
                            {
                                stopSettingIndex = true;
                                ++otherContactHeaders;
                                i += 3;
                            }
                        }
                    }
                }

                // right now, return if BCS id and Company Name are not in their correct places
                if (acceptableHeaderValuesAndTheirIndexes[0].Item1 != 0 && acceptableHeaderValuesAndTheirIndexes[1].Item1 != 1)
                {
                    throw new CompanyImportNotCorrectFormatException("CSV file is not recognized as an acceptable Company Export. BCS Company ID must be in the first column followed by the Company Name in the second column.");
                }
                #endregion Save Header

                // instantiate the list if CSV header is an acceptable format
                AllCompaniesLoaded = new List<Company>();
                companyDictionary = new Dictionary<string, Company>();
                companyNameDictionary = new Dictionary<string, string>();
                companyContactDictionary = new Dictionary<string, List<Contact>>();

                // Read the rest of the csv line by line
                while ((csvLine = sr.ReadLine()) != null)
                {
                    // return fields in a string array split by commas (not including those which are within quotations)
                    // CHANGE COMMA TO SEMICOLON HERE IF .SCSV
                    string[] result = Regex.Split(csvLine, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");

                    // remove paranthesis if comma is in value. also count other contacts
                    for (int i = 0; i < result.Length; i++)
                    {
                        if (result[i].Contains(',') == true)
                        {
                            result[i] = result[i].Remove(0, 1);
                            result[i] = result[i].Remove(result[i].Length - 1, 1);
                        }
                    }

                    #region Read And Store Company Data Per Line

                    // BCS Company ID has to be there and has to be first***
                    string bcsCompanyID = result[acceptableHeaderValuesAndTheirIndexes[0].Item1];

                    // Company Name has to be second
                    string companyName = result[acceptableHeaderValuesAndTheirIndexes[1].Item1];

                    // for the rest, let the default data populate if index wasn't found (-1), the result values aren't this long, or the result value is null
                    string vendorID = "";
                    if (acceptableHeaderValuesAndTheirIndexes[2].Item1 > 0 && result.Length > 2 && result[acceptableHeaderValuesAndTheirIndexes[2].Item1] != null)
                    {
                        vendorID = result[acceptableHeaderValuesAndTheirIndexes[2].Item1];
                    }

                    string dba = "";
                    if (acceptableHeaderValuesAndTheirIndexes[3].Item1 > 0 && result.Length > 3 && result[acceptableHeaderValuesAndTheirIndexes[3].Item1] != null)
                    {
                        dba = result[acceptableHeaderValuesAndTheirIndexes[3].Item1];
                    }

                    string address1 = "";
                    if (acceptableHeaderValuesAndTheirIndexes[4].Item1 > 0 && result.Length > 4 && result[acceptableHeaderValuesAndTheirIndexes[4].Item1] != null)
                    {
                        address1 = result[acceptableHeaderValuesAndTheirIndexes[4].Item1];
                    }

                    string address2 = "";
                    if (acceptableHeaderValuesAndTheirIndexes[5].Item1 > 0 && result.Length > 5 && result[acceptableHeaderValuesAndTheirIndexes[5].Item1] != null)
                    {
                        address2 = result[acceptableHeaderValuesAndTheirIndexes[5].Item1];
                    }

                    string city = "";
                    if (acceptableHeaderValuesAndTheirIndexes[6].Item1 > 0 && result.Length > 6 && result[acceptableHeaderValuesAndTheirIndexes[6].Item1] != null)
                    {
                        city = result[acceptableHeaderValuesAndTheirIndexes[6].Item1];
                    }

                    string state = "";
                    if (acceptableHeaderValuesAndTheirIndexes[7].Item1 > 0 && result.Length > 7 && result[acceptableHeaderValuesAndTheirIndexes[7].Item1] != null)
                    {
                        state = result[acceptableHeaderValuesAndTheirIndexes[7].Item1];
                    }

                    string zip = "";
                    if (acceptableHeaderValuesAndTheirIndexes[8].Item1 > 0 && result.Length > 8 && result[acceptableHeaderValuesAndTheirIndexes[8].Item1] != null)
                    {
                        zip = result[acceptableHeaderValuesAndTheirIndexes[8].Item1];
                    }

                    string country = "";
                    if (acceptableHeaderValuesAndTheirIndexes[9].Item1 > 0 && result.Length > 9 && result[acceptableHeaderValuesAndTheirIndexes[9].Item1] != null)
                    {
                        country = result[acceptableHeaderValuesAndTheirIndexes[9].Item1];
                    }

                    string phone = "";
                    if (acceptableHeaderValuesAndTheirIndexes[10].Item1 > 0 && result.Length > 10 && result[acceptableHeaderValuesAndTheirIndexes[10].Item1] != null)
                    {
                        phone = result[acceptableHeaderValuesAndTheirIndexes[10].Item1];
                    }

                    string emailAddress = "";
                    if (acceptableHeaderValuesAndTheirIndexes[11].Item1 > 0 && result.Length > 11 && result[acceptableHeaderValuesAndTheirIndexes[11].Item1] != null)
                    {
                        emailAddress = result[acceptableHeaderValuesAndTheirIndexes[11].Item1];
                    }

                    bool? companyActive = null;
                    if (acceptableHeaderValuesAndTheirIndexes[12].Item1 > 0 && result.Length > 12 && result[acceptableHeaderValuesAndTheirIndexes[12].Item1] != null)
                    {
                        if (Boolean.TryParse(result[acceptableHeaderValuesAndTheirIndexes[12].Item1], out parsedBoolValue))
                        {
                            if (parsedBoolValue)
                            {
                                companyActive = parsedBoolValue;
                            }
                            else
                            {
                                companyActive = parsedBoolValue;
                            }
                        }
                        else
                        {
                            companyActive = null;
                        }
                    }

                    string companyComplianceLevel = "";
                    if (acceptableHeaderValuesAndTheirIndexes[13].Item1 > 0 && result.Length > 13 && result[acceptableHeaderValuesAndTheirIndexes[13].Item1] != null)
                    {
                        companyComplianceLevel = result[acceptableHeaderValuesAndTheirIndexes[13].Item1];
                    }

                    string analyst = "";
                    if (acceptableHeaderValuesAndTheirIndexes[14].Item1 > 0 && result.Length > 14 && result[acceptableHeaderValuesAndTheirIndexes[14].Item1] != null)
                    {
                        analyst = result[acceptableHeaderValuesAndTheirIndexes[14].Item1];
                    }

                    string companyLastNoteDate = "";
                    if (acceptableHeaderValuesAndTheirIndexes[15].Item1 > 0 && result.Length > 15 && result[acceptableHeaderValuesAndTheirIndexes[15].Item1] != null)
                    {
                        companyLastNoteDate = result[acceptableHeaderValuesAndTheirIndexes[15].Item1];
                    }

                    // for each contact, instantiate contacts
                    List<Contact> contacts = new List<Contact>();

                    Contact mainContact = new Contact();
                    if (acceptableHeaderValuesAndTheirIndexes[16].Item1 > 0 && result.Length > 16 && result[acceptableHeaderValuesAndTheirIndexes[16].Item1] != null)
                    {
                        mainContact.Name = result[acceptableHeaderValuesAndTheirIndexes[16].Item1];
                        mainContact.Title = result[(acceptableHeaderValuesAndTheirIndexes[16].Item1) + 1];
                        mainContact.Phone = result[(acceptableHeaderValuesAndTheirIndexes[16].Item1) + 2];
                        mainContact.Email = result[(acceptableHeaderValuesAndTheirIndexes[16].Item1) + 3];

                        if(mainContact.Name!=String.Empty) contacts.Add(mainContact);
                    }

                    if (acceptableHeaderValuesAndTheirIndexes[17].Item1 > 0 && result.Length > 17 && result[acceptableHeaderValuesAndTheirIndexes[17].Item1] != null)
                    {
                        int index = acceptableHeaderValuesAndTheirIndexes[17].Item1;

                        while (result[index]!=null && result[index]!=String.Empty)
                        {
                            Contact otherContact = new Contact();

                            otherContact.Name = result[index];
                            otherContact.Title = result[++index];
                            otherContact.Phone = result[++index];
                            otherContact.Email = result[++index];

                            ++index;

                            contacts.Add(otherContact);
                        }
                    }

                    // construct the company from the line item and whatever was extracted
                    companyToImport = new Company(companyName, bcsCompanyID, vendorID,dba, address1,address2,city,state,
                        zip,country,phone,emailAddress,companyActive,companyComplianceLevel,analyst,companyLastNoteDate,
                        contacts);

                    // add to lists
                    this.AllCompaniesLoaded.Add(companyToImport);
                    this.companyDictionary.Add(companyToImport.BcsCompanyID, companyToImport);
                    this.companyNameDictionary.Add(companyToImport.BcsCompanyID, companyToImport.CompanyName);
                    this.companyContactDictionary.Add(companyToImport.BcsCompanyID, companyToImport.Contacts);
                    //this.companyNameHashSet.Add(companyToImport.CompanyName);

                    #endregion Read And Store Company Data Per Line

                    // report progress
                    if (this.InvokeRequired)
                    {
                        this.Invoke(new Action(() => { importCompaniesBackgroundWorker.ReportProgress(Convert.ToInt32((baseStream.Position / (double)length) * 100)); }));
                    }
                    else
                        importCompaniesBackgroundWorker.ReportProgress(Convert.ToInt32(baseStream.Position / length * 100));
                }
            }
        }

        private void importCompaniesBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                SetStatusLabelAndTimer("Operation was canceled");
                MakeErrorSound();
            }
            else if (e.Error != null)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() => { this.LoadingForm.ShowCloseBtn(); }));
                    this.Invoke(new Action(() => { this.LoadingForm.HideBar(); }));
                    this.Invoke(new Action(() => { this.LoadingForm.ChangeHeaderLabel("Import Unsuccessful"); }));
                    this.Invoke(new Action(() => { this.LoadingForm.ChangeLabel($"{e.Error.Message}"); }));
                    this.Invoke(new Action(() => { LoadingForm.Refresh(); }));
                }
                else
                {
                    this.LoadingForm.ShowCloseBtn();
                    this.LoadingForm.HideBar();
                    this.LoadingForm.ChangeHeaderLabel("Import Unsuccessful");
                    this.LoadingForm.ChangeLabel($"{e.Error.Message}");
                    this.LoadingForm.Refresh();
                }
            }
            else
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() => { this.LoadingForm.ShowCloseBtn(); }));
                    this.Invoke(new Action(() => { this.LoadingForm.CompleteProgress(); }));
                    this.Invoke(new Action(() => { this.LoadingForm.ChangeLabel("Companies imported successfully"); }));
                    this.Invoke(new Action(() => { LoadingForm.Refresh(); }));
                }
                else
                {
                    this.LoadingForm.ShowCloseBtn();
                    this.LoadingForm.CompleteProgress();
                    this.LoadingForm.ChangeLabel("Companies imported successfully");
                    this.LoadingForm.Refresh();
                }
            }

            UseWaitCursor = false;
        }

        // DB Import Process
        private void importFromDBBackGroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            ImportFromDB();
        }

        private void ImportFromDBDirector(int i)
        {
            switch (i)
            {
                case 1: ImportWorkflowItemsFromDB();
                    break;
                case 2: ImportCertificatesFromDB();
                    break;
                case 3: ImportCompaniesFromDB();
                    break;
                default:
                    break;
            }
        }

        private void ImportFromDB()
        {
            ImportFromDBDirector(1);
        }

        private void ImportWorkflowItemsFromDB()
        {
            // establish the connection
            SqlConnection conn = new SqlConnection("server=certus.cbzlvslfzbzc.us-east-1.rds.amazonaws.com;uid=cfitzpatrick;pwd=Monday1!;database=CertusDB;integrated security=false;");
            conn.Open();

            #region Write Command - ImportWorkflowItem
            string query =
            @"
                SELECT		DocumentWorkflowItem.DocumentWorkflowItemID,
			                ISNULL(CompanyCertificate.IdentityField, '') 
			                AS ContractID,
			                REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(LTRIM(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(ISNULL(Company.Name, ''), CHAR(13), ''), CHAR(10), ''), CHAR(9), ''), '=', ' ='), '""', ' ""')),' =', CHAR(9)), '=', '-'), CHAR(9), ' ='),' ""', CHAR(9)), '""', '-'), CHAR(9), ' 
                            AS Vendor,
                            DocumentWorkflowItem.CompanyID AS VendorID,
			                CASE
                                WHEN DocumentWorkflowItem.DocumentWorkflowStatusID = 2 AND DocumentationAnalyst.SystemUserID IS NOT NULL
                                    THEN DocumentationAnalyst.LastName + ', ' + DocumentationAnalyst.FirstName
                                WHEN DocumentWorkflowItem.DocumentWorkflowStatusID = 3 AND ComplianceAnalyst.SystemUserID IS NOT NULL
                                    THEN ComplianceAnalyst.LastName + ', ' + ComplianceAnalyst.FirstName
                                ELSE '(Unassigned)'
                                END AS WorkflowAnalyst,
			                CASE
                                WHEN DocumentWorkflowItem.DocumentWorkflowStatusID = 2 AND DocumentationAnalyst.SystemUserID IS NOT NULL
                                    THEN DocumentationAnalyst.SystemUserID
                                WHEN DocumentWorkflowItem.DocumentWorkflowStatusID = 3 AND ComplianceAnalyst.SystemUserID IS NOT NULL
                                    THEN ComplianceAnalyst.SystemUserID
                                END AS WorkflowAnalystID,
                            CASE
                                WHEN Company.AnalystID IS NULL
                                    THEN '(Unassigned)'
                                ELSE CompanyAnalyst.LastName + ', ' + CompanyAnalyst.FirstName
                                END AS CompanyAnalyst,
			                CASE
                                WHEN Company.AnalystID IS NOT NULL
                                    THEN CompanyAnalyst.SystemUserID
                                END AS CompanyAnalystID,
                            CAST(DocumentWorkflowItem.EmailDate AS datetime) AS EmailDate,
                            DocumentWorkflowItem.EmailFromAddress,
			                REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(LTRIM(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(DocumentWorkflowItem.EmailSubject, CHAR(13), ''), CHAR(10), ''), CHAR(9), ''), '=', ' ='), '""', ' ""')), ' =', CHAR(9)), '=', '-'), CHAR(9), ' ='), ' ""', CHAR(9)), '""', '-'), CHAR(9), ' 
                                AS SubjectLine,
                            DocumentWorkflowStatus.Description
                                AS Status,
			                DocumentWorkflowItem.CertusFileID,
			                ISNULL(CertusFile.FileName, '')
                                AS FileName,
                            CertusFile.FileSize,
			                ISNULL(CertusFile.FileMime, '')
                                AS FileMIME,
                            CASE
                                WHEN CertusFile.CertusFileID IS NULL
                                    THEN ''
                                ELSE 'https://www.bcscertus.com/handlers/viewfile.ashx?f=' + CAST(CertusFile.CertusFileID AS VARCHAR(MAX))
                                END AS FileURL
                FROM        DocumentWorkflowItem
                                LEFT JOIN CompanyCertificate ON DocumentWorkflowItem.CompanyCertificateID = CompanyCertificate.CompanyCertificateID
                                LEFT JOIN Company ON DocumentWorkflowItem.CompanyID = Company.CompanyID
                                LEFT JOIN SystemUser DocumentationAnalyst ON DocumentWorkflowItem.DocumentationAnalystID = DocumentationAnalyst.SystemUserID
                                LEFT JOIN SystemUser ComplianceAnalyst ON DocumentWorkflowItem.ComplianceAnalystID = ComplianceAnalyst.SystemUserID
                                LEFT JOIN SystemUser CompanyAnalyst ON Company.AnalystID = CompanyAnalyst.SystemUserID
                                JOIN DocumentWorkflowStatus ON DocumentWorkflowItem.DocumentWorkflowStatusID = DocumentWorkflowStatus.DocumentWorkflowStatusID
                                LEFT JOIN CertusFile ON DocumentWorkflowItem.CertusFileID = CertusFile.CertusFileID
                WHERE DocumentWorkflowItem.ClientID =
                            AND DocumentWorkflowStatus.DocumentWorkflowStatusID < 4
                ORDER BY    DocumentWorkflowItem.DocumentWorkflowItemID desc, DocumentWorkflowItem.EmailDate desc
            ";
            SqlCommand cmd = new SqlCommand(query);
            #endregion

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataTable table = new DataTable();
            adapter.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                string documentWorkflowItemID = row["DocumentWorkflowItemID"] as string;
                string contractID = row["ContractID"] as string;
                string vendorName = row["Vendor"] as string;
                string vendorID = row["VendorID"] as string;
                string workflowAnalyst =  row["WorkflowAnalyst"] as string;
                string workflowAnalystID =row["WorkflowAnalystID"] as string;
                string companyAnalyst = row["CompanyAnalyst"] as string;
                string companyAnalystID = row["CompanyAnalystID"] as string;
                DateTime parsedDateTimeValue;
                DateTime? emailDate = null;
                DateTime.TryParse(row["EmailDate"] as string, out parsedDateTimeValue);
                emailDate = parsedDateTimeValue;
                string emailFromAddress = row["EmailFromAddress"] as string;
                string subjectLine = row["SubjectLine"] as string;
                string status = row["Status"] as string;
                string certusFileID = row["CertusFileID"] as string;
                string fileName = row["FileName"] as string;
                string fileSize = row["FileSize"] as string;
                string fileMIME = row["FileMIME"] as string;
                string fileURL = row["FileURL"] as string;

                WorkflowItem wi = new WorkflowItem
                (
                    documentWorkflowItemID,
                    contractID,
                    vendorName,
                    vendorID,
                    null,
                    null,
                    null,
                    null,
                    workflowAnalyst,
                    workflowAnalystID,
                    companyAnalyst,
                    companyAnalystID,
                    emailDate,
                    emailFromAddress,
                    subjectLine,
                    null,
                    status,
                    certusFileID,
                    fileName,
                    fileURL,
                    fileSize,
                    fileMIME,
                    null
                );
            }
        }

        private void ImportCertificatesFromDB()
        {

        }

        private void ImportCompaniesFromDB()
        {

        }

        private void importFromDBBackGroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        #endregion Import

        #region Run Query

        private void queryBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Query();

            // notify status
            SetStatusLabelAndTimer("Populating items", true);
        }

        private void queryBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("Could not complete the query\n\ne.Error.Message", "Error");
            }
            else
            {
                // populate the list box with the queried items
                queriedItemsListbox.DataSource = queriedItemList;

                // show correct count of records
                SetDatabaseDetailsProperties();

                // notify user that the query was successful
                if (queriedItemList != null && queriedItemList.Count > 0)
                {
                    SetStatusLabelAndTimer($"Query successful, {queriedItemList.Count} items showing");
                }
                else
                {
                    SetStatusLabelAndTimer($"No items were found for that query");
                    MakeErrorSound();
                }
            }

            UseWaitCursor = false;
            Cursor.Current = Cursors.Default;
        }

        #endregion Run Query

        #region Update Data

        private void updateDataBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // data for reporting progress
            int valueToIncrement = (int)(this.AllWorkflowItemsLoaded.Count * .01);
            valueToIncrement *= 4;
            DimForm();
            LoadingForm = new LoadingForm();

            if (TransparentForm.InvokeRequired)
                TransparentForm.Invoke(new Action(() => { LoadingForm.Show(TransparentForm); }));
            else
                LoadingForm.Show(TransparentForm);

            // update for connected items - this can skip items because all attached items will never change
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => { LoadingForm.ChangeLabel("Finding each item's connected items"); }));
                this.Invoke(new Action(() => { LoadingForm.Refresh(); }));
            }
            else
            {
                LoadingForm.ChangeLabel("Finding each item's connected items");
                this.LoadingForm.Refresh();
            }

            for (int j = 0; j < this.AllWorkflowItemsLoaded.Count; j++)
            {
                if (AllWorkflowItemsLoaded[j].ItemsAttached == null || AllWorkflowItemsLoaded[j].ItemsAttached.Count == 0)
                {
                    List<string> itemsToAdd = new List<string>();

                    WorkflowItem item = this.AllWorkflowItemsLoaded[j];

                    var connectedItemsQuery = from i in this.AllWorkflowItemsLoaded
                                              where i.EmailFromAddress == item.EmailFromAddress && i.EmailDate == item.EmailDate
                                              select i;

                    foreach (var result in connectedItemsQuery)
                    {
                        itemsToAdd.Add(result.DocumentWorkflowItemID);
                    }

                    item.ItemsAttached = itemsToAdd;
                }

                // update loading progress for increment value 
                if (j % valueToIncrement == 0)
                {
                    if (this.InvokeRequired)
                        this.Invoke(new Action(() => { LoadingForm.MoveBar(1); }));
                    else
                        LoadingForm.MoveBar(1);
                }
            }

            // update for matching file sizes - needs to check every item every time
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => { LoadingForm.ChangeLabel("Finding items with the same file size"); }));
                this.Invoke(new Action(() => { LoadingForm.Refresh(); }));
            }
            else
            {
                LoadingForm.ChangeLabel("Finding items with the same file size");
                this.LoadingForm.Refresh();
            }

            for (int j = 0; j < this.AllWorkflowItemsLoaded.Count; j++)
            {
                int itemsToAdd = 0;

                WorkflowItem item = this.AllWorkflowItemsLoaded[j];

                var matchingFileSizeQuery = from i in this.AllWorkflowItemsLoaded
                                            where i.FileSize == item.FileSize
                                            select i;

                foreach (var result in matchingFileSizeQuery)
                {
                    ++itemsToAdd;
                }

                item.ItemsWithThisFileSize = itemsToAdd;

                // report progress
                if (j % valueToIncrement == 0)
                {
                    if (this.InvokeRequired)
                        this.Invoke(new Action(() => { LoadingForm.MoveBar(1); }));
                    else
                        LoadingForm.MoveBar(1);
                }
            }

            // update for matching file names - needs to check every item every time
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => { LoadingForm.ChangeLabel("Finding items with the same file name"); }));
                this.Invoke(new Action(() => { LoadingForm.Refresh(); }));
            }
            else
            {
                LoadingForm.ChangeLabel("Finding items with the same file name");
                this.LoadingForm.Refresh();
            }

            for (int j = 0; j < this.AllWorkflowItemsLoaded.Count; j++)
            {
                int itemsToAdd = 0;

                WorkflowItem item = this.AllWorkflowItemsLoaded[j];

                var matchingFileNameQuery = from i in this.AllWorkflowItemsLoaded
                                            where i.FileName == item.FileName
                                            select i;

                foreach (var result in matchingFileNameQuery)
                {
                    ++itemsToAdd;
                }

                item.ItemsWithThisFileName = itemsToAdd;

                if (j % valueToIncrement == 0)
                {
                    if (this.InvokeRequired)
                        this.Invoke(new Action(() => { LoadingForm.MoveBar(1); }));
                    else
                        LoadingForm.MoveBar(1);
                }
            }

            // each items' total attachments size - doesn't need every item to be checked, only those without sizes
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => { LoadingForm.ChangeLabel("Finding total size of attachments in each item"); }));
                this.Invoke(new Action(() => { LoadingForm.Refresh(); }));
            }
            else
            {
                LoadingForm.ChangeLabel("Finding total size of attachments in each item");
                this.LoadingForm.Refresh();
            }

            for (int j = 0; j < this.AllWorkflowItemsLoaded.Count; j++)
            {
                if (AllWorkflowItemsLoaded[j].AllAttachmentsSize == 0 && (AllWorkflowItemsLoaded[j].FileName != String.Empty || AllWorkflowItemsLoaded[j].FileName != null))
                {
                    //int attachmentsSize = 0;
                    //List<WorkflowItem> itemsInEmail = new List<WorkflowItem>();
                    //WorkflowItem item = this.AllWorkflowItemsLoaded[j];

                    //itemsInEmail = GetWorkflowItemsFromIDs(item.ItemsAttached);

                    //foreach (WorkflowItem wi in itemsInEmail)
                    //{
                    //    if (wi.FileSize != "n/a" && wi.FileSize != String.Empty && wi.FileSize != null)
                    //        attachmentsSize += Convert.ToInt32(wi.FileSize);
                    //}

                    //item.AllAttachmentsSize = attachmentsSize;
                }

                if (j % valueToIncrement == 0)
                {
                    if (this.InvokeRequired)
                        this.Invoke(new Action(() => { LoadingForm.MoveBar(1); }));
                    else
                        LoadingForm.MoveBar(1);
                }
            }

            // notify that update is being completed
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => { LoadingForm.ChangeLabel("Finishing putting the updated list of items together"); }));
                this.Invoke(new Action(() => { LoadingForm.Refresh(); }));
            }
            else
            {
                LoadingForm.ChangeLabel("FFinishing putting the updated list of items together");
                this.LoadingForm.Refresh();
            }
        }

        private void updateDataBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                SetStatusLabelAndTimer("Operation was canceled");
                MakeErrorSound();
            }
            else if (e.Error != null)
            {
                MessageBox.Show("Update unsuccessful\n\ne.Error.Message", "Error");
                if (CheckIfFormIsOpened("Transparent Form"))
                    this.Invoke(new Action(() => { TransparentForm.Close(); }));
            }
            else
            {
                // refresh
                this.refreshBtn.PerformClick();

                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() => { this.LoadingForm.ShowCloseBtn(); }));
                    this.Invoke(new Action(() => { this.LoadingForm.CompleteProgress(); }));
                    this.Invoke(new Action(() => { this.LoadingForm.ChangeLabel("Items updated successfully"); }));
                    this.Invoke(new Action(() => { LoadingForm.Refresh(); }));
                }
                else
                {
                    this.LoadingForm.ShowCloseBtn();
                    this.LoadingForm.CompleteProgress();
                    this.LoadingForm.ChangeLabel("Items updated successfully");
                    this.LoadingForm.Refresh();
                }
            }
        }

        #endregion Update Data

        #region Fill Data

        // needs reformatting
        private void appendCompanyBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                this.Invoke(new Action(() => {

                    int valueToIncrement = 0;

                    // only make the loading form if more than 100 items are being checked
                    if (this.workflowItemsListView.CheckedItems.Count > 100)
                    {
                        valueToIncrement = (int)(this.workflowItemsListView.CheckedItems.Count/75);
                        if (valueToIncrement <= 0) valueToIncrement = 1;
                        DimForm();
                        LoadingForm = new LoadingForm();
                        LoadingForm.Show(TransparentForm);
                    }

                    WorkflowItem wi = new WorkflowItem();
                    WorkflowItem previousItem = new WorkflowItem();
                    List<WorkflowItem> itemsToUpdate = new List<WorkflowItem>();
                    itemsInfoAppended = 0;
                    itemsCouldNotBeAppended = false;

                    // --- status update --- //
                    if (LoadingForm != null && LoadingForm.Visible)
                    {
                        LoadingForm.ChangeLabel("Finding items to append");
                        this.LoadingForm.Refresh();
                    }

                    foreach (ListViewItem checkedItem in workflowItemsListView.CheckedItems)
                    {
                        List<WorkflowItem> itemsInGroup;
                        string companyNameToFill;

                        // get the item, return if there's only 1 in the item group or if the previous item has the same time and sender
                        wi = GetWorkflowItemFromLvItem(checkedItem);

                        // update loading progress for increment value 
                        if (LoadingForm != null && LoadingForm.Visible)
                        {
                            if (workflowItemsListView.CheckedItems.IndexOf(checkedItem) % valueToIncrement == 0)
                            {
                                LoadingForm.MoveBar(1);
                            }
                        }

                        if (wi.ItemsAttached == null) // additional item info is required for this function
                        {
                            itemsCouldNotBeAppended = true;
                            continue;
                        }
                        if (wi.ItemsAttached.Count == 1) continue;
                        //if (previousItem != null && (wi.EmailDate == previousItem.EmailDate && wi.EmailFromAddress == previousItem.EmailFromAddress)) return;

                        // get all the items from the item group into a list
                        itemsInGroup = new List<WorkflowItem>();
                        companyNameToFill = "";

                        foreach (string id in wi.ItemsAttached)
                        {
                            itemsInGroup.Add(GetWorkflowItemFromAllByID(id));
                        }

                        // if any item in the group has a company name, end the loop and the name 
                        for (int i = 0; i < itemsInGroup.Count(); i++)
                        {
                            if (itemsInGroup[i].VendorName != String.Empty)
                            {
                                companyNameToFill = itemsInGroup[i].VendorName;
                                i = itemsInGroup.Count();
                            }
                        }

                        // if a name was saved
                        if (companyNameToFill != String.Empty)
                        {
                            // change this item

                            if (wi.VendorName != companyNameToFill)
                            {
                                wi.VendorName = companyNameToFill;
                                wi.CompanyUpdated = true;
                                ++itemsInfoAppended;

                                // add this item to list to update
                                itemsToUpdate.Add(wi);
                            }
                        }
                        previousItem = wi;
                    }

                    // --- status update --- //
                    if (LoadingForm != null && LoadingForm.Visible)
                    {
                        LoadingForm.ChangeLabel("Updating items");
                        this.LoadingForm.Refresh();
                    }

                    if (itemsToUpdate != null && itemsToUpdate.Count > 0)
                    {
                        valueToIncrement = (int)(25/itemsToUpdate.Count);
                        if (valueToIncrement <= 0) valueToIncrement = 1;

                        foreach (WorkflowItem item in itemsToUpdate)
                        { 
                            var tmpItem = AllWorkflowItemsLoaded.First(i => i.DocumentWorkflowItemID == item.DocumentWorkflowItemID);
                            int index = AllWorkflowItemsLoaded.IndexOf(tmpItem as WorkflowItem);

                            this.AllWorkflowItemsLoaded[index] = item;

                            // update loading progress for increment value 
                            if (LoadingForm != null && LoadingForm.Visible)
                            {
                                if (itemsToUpdate.IndexOf(item) % valueToIncrement == 0)
                                {
                                    LoadingForm.MoveBar(1);
                                }
                            }
                        }
                    }
                }));
            }
            catch (Exception)
            {
                this.Invoke(new Action(() =>
                {
                    SetStatusLabelAndTimer("Could not process the request");
                    MakeErrorSound();
                }));
            }

            Application.UseWaitCursor = false;
        }

        // needs reformatting
        private void appendContractInformationBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                this.Invoke(new Action(() => {

                    int valueToIncrement = 0;

                    // only make the loading form if more than 100 items are being checked
                    if (this.workflowItemsListView.CheckedItems.Count > 100)
                    {
                        valueToIncrement = (int)(this.workflowItemsListView.CheckedItems.Count / 75);
                        if (valueToIncrement <= 0) valueToIncrement = 1;
                        DimForm();
                        LoadingForm = new LoadingForm();
                        LoadingForm.Show(TransparentForm);
                    }

                    WorkflowItem wi = new WorkflowItem();
                    WorkflowItem previousItem = new WorkflowItem();
                    List<WorkflowItem> itemsToUpdate = new List<WorkflowItem>();
                    itemsInfoAppended = 0;
                    itemsCouldNotBeAppended = false;

                    // --- status update --- //
                    if (LoadingForm != null && LoadingForm.Visible)
                    {
                        LoadingForm.ChangeLabel("Finding items to append");
                        this.LoadingForm.Refresh();
                    }

                    foreach (ListViewItem checkedItem in workflowItemsListView.CheckedItems)
                    {
                        List<WorkflowItem> itemsInGroup;
                        string contractIdToFill;
                        bool? activeBoolToFill;
                        bool? compliantIntToFill;
                        DateTime? nextExpDateToFill;

                        // get the item, return if there's only 1 in the item group or if the previous item has the same time and sender
                        wi = GetWorkflowItemFromLvItem(checkedItem);

                        // update loading progress for increment value 
                        if (LoadingForm != null && LoadingForm.Visible)
                        {
                            if (workflowItemsListView.CheckedItems.IndexOf(checkedItem) % valueToIncrement == 0)
                            {
                                LoadingForm.MoveBar(1);
                            }
                        }

                        if (wi.ItemsAttached == null) // additional item info is required for this function
                        {
                            itemsCouldNotBeAppended = true;
                            continue;
                        }
                        if (wi.ItemsAttached.Count == 1) continue;

                        // get all the items from the item group into a list
                        itemsInGroup = new List<WorkflowItem>();
                        contractIdToFill = "";
                        activeBoolToFill = null;
                        compliantIntToFill = null;
                        nextExpDateToFill = null;

                        foreach (string id in wi.ItemsAttached)
                        {
                            itemsInGroup.Add(GetWorkflowItemFromAllByID(id));
                        }

                        // if any item in the group has a contract number, end the loop and save the data 
                        for (int i = 0; i < itemsInGroup.Count(); i++)
                        {
                            if (itemsInGroup[i].ContractID != String.Empty)
                            {
                                contractIdToFill = itemsInGroup[i].ContractID;
                                activeBoolToFill = itemsInGroup[i].Active;
                                compliantIntToFill = itemsInGroup[i].Compliant;
                                nextExpDateToFill = itemsInGroup[i].NextExpirationDate;

                                i = itemsInGroup.Count();
                            }
                        }

                        // if a contract id was saved
                        if (contractIdToFill != String.Empty)
                        {
                            // change this item

                            if (wi.ContractID != contractIdToFill)
                            {
                                wi.ContractID = contractIdToFill;
                                wi.Active = activeBoolToFill;
                                wi.Compliant = compliantIntToFill;
                                wi.NextExpirationDate = nextExpDateToFill;

                                wi.ContractInformationUpdated = true;
                                ++itemsInfoAppended;

                                // add this item to list to update
                                itemsToUpdate.Add(wi);
                            }
                        }

                        //previousItem = wi;
                    }

                    // --- status update --- //
                    if (LoadingForm != null && LoadingForm.Visible)
                    {
                        LoadingForm.ChangeLabel("Updating items");
                        this.LoadingForm.Refresh();
                    }

                    if (itemsToUpdate != null && itemsToUpdate.Count > 0)
                    {
                        valueToIncrement = (int)(25 / itemsToUpdate.Count);
                        if (valueToIncrement <= 0) valueToIncrement = 1;

                        foreach (WorkflowItem item in itemsToUpdate)
                        {
                            var tmpItem = AllWorkflowItemsLoaded.First(i => i.DocumentWorkflowItemID == item.DocumentWorkflowItemID);
                            int index = AllWorkflowItemsLoaded.IndexOf(tmpItem as WorkflowItem);

                            this.AllWorkflowItemsLoaded[index] = item;

                            // update loading progress for increment value 
                            if (LoadingForm != null && LoadingForm.Visible)
                            {
                                if (itemsToUpdate.IndexOf(item) % valueToIncrement == 0)
                                {
                                    LoadingForm.MoveBar(1);
                                }
                            }
                        }
                    }
                }));
            }
            catch (Exception)
            {
                this.Invoke(new Action(() =>
                {
                    SetStatusLabelAndTimer("Could not process the request");
                    MakeErrorSound();
                }));
            }

            Application.UseWaitCursor = false;
        }

        // needs reformatting
        private void appendAssignedAndStatusBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                this.Invoke(new Action(() => {

                    int valueToIncrement = 0;

                    // only make the loading form if more than 100 items are being checked
                    if (this.workflowItemsListView.CheckedItems.Count > 100)
                    {
                        valueToIncrement = (int)(this.workflowItemsListView.CheckedItems.Count / 75);
                        if (valueToIncrement <= 0) valueToIncrement = 1;
                        DimForm();
                        LoadingForm = new LoadingForm();
                        LoadingForm.Show(TransparentForm);
                    }

                    WorkflowItem wi = new WorkflowItem();
                    WorkflowItem previousItem = new WorkflowItem();
                    List<WorkflowItem> itemsToUpdate = new List<WorkflowItem>();
                    itemsInfoAppended = 0;
                    itemsCouldNotBeAppended = false;

                    // --- status update --- //
                    if (LoadingForm != null && LoadingForm.Visible)
                    {
                        LoadingForm.ChangeLabel("Finding items to append");
                        this.LoadingForm.Refresh();
                    }

                    foreach (ListViewItem checkedItem in workflowItemsListView.CheckedItems)
                    {
                        List<WorkflowItem> itemsInGroup;
                        string status;
                        string assignedTo;

                        // get the item, return if there's only 1 in the item group or if the previous item has the same time and sender
                        wi = GetWorkflowItemFromLvItem(checkedItem);

                        // update loading progress for increment value 
                        if (LoadingForm != null && LoadingForm.Visible)
                        {
                            if (workflowItemsListView.CheckedItems.IndexOf(checkedItem) % valueToIncrement == 0)
                            {
                                LoadingForm.MoveBar(1);
                            }
                        }

                        if (wi.ItemsAttached == null) // additional item info is required for this function
                        {
                            itemsCouldNotBeAppended = true;
                            continue;
                        }
                        if (wi.ItemsAttached.Count == 1) continue;

                        // get all the items from the item group into a list
                        itemsInGroup = new List<WorkflowItem>();
                        status = "";
                        assignedTo = "";
                        
                        foreach (string id in wi.ItemsAttached)
                        {
                            itemsInGroup.Add(GetWorkflowItemFromAllByID(id));
                        }

                        // take first assigned to val that's not unsg
                        for (int i = 0; i < itemsInGroup.Count(); i++)
                        {
                            if (itemsInGroup[i].AssignedToName != String.Empty && itemsInGroup[i].AssignedToName != "(Unassigned)")
                            {
                                assignedTo = itemsInGroup[i].AssignedToName;

                                i = itemsInGroup.Count();
                            }
                        }

                        // take first status val that isn't er, comp, trash, or comp/trash
                        for (int i = 0; i < itemsInGroup.Count(); i++)
                        {
                            if (itemsInGroup[i].Status != String.Empty && itemsInGroup[i].Status != "Email Received" &&
                            itemsInGroup[i].Status != "Completed" && itemsInGroup[i].Status != "Trash" &&
                            itemsInGroup[i].Status != "Completed/Trash")
                            {
                                status = itemsInGroup[i].Status;

                                i = itemsInGroup.Count();
                            }
                        }

                        // if a status and assigned to were saved
                        if (status!=String.Empty && assignedTo != String.Empty)
                        {
                            // change this item
                            if (wi.Status != status && wi.AssignedToName != assignedTo)
                            {
                                wi.Status = status;
                                wi.AssignedToName = assignedTo;

                                if(status=="Documentation Analyst")
                                {
                                    wi.WorkflowAnalyst = assignedTo;
                                }
                                else if (status == "Company Analyst")
                                {
                                    wi.CompanyAnalyst = assignedTo;
                                }

                                // changing this information is critical and therefore will change the item appearance
                                wi.WorkflowItemInformationDifferentThanCertus = true;
                                wi.DisplayColor = "SpringGreen";
                                ++itemsInfoAppended;

                                // add this item to list to update
                                itemsToUpdate.Add(wi);
                            }
                            else if (wi.Status != status)
                            {
                                wi.Status = status;

                                // changing this information is critical and therefore will change the item appearance
                                wi.WorkflowItemInformationDifferentThanCertus = true;
                                wi.DisplayColor = "SpringGreen";
                                ++itemsInfoAppended;

                                // add this item to list to update
                                itemsToUpdate.Add(wi);
                            }
                            else if (wi.AssignedToName != assignedTo)
                            {
                                wi.AssignedToName = assignedTo;

                                if (status == "Documentation Analyst")
                                {
                                    wi.WorkflowAnalyst = assignedTo;
                                }
                                else if (status == "Company Analyst")
                                {
                                    wi.CompanyAnalyst = assignedTo;
                                }

                                // changing this information is critical and therefore will change the item appearance
                                wi.WorkflowItemInformationDifferentThanCertus = true;
                                wi.DisplayColor = "SpringGreen";
                                ++itemsInfoAppended;

                                // add this item to list to update
                                itemsToUpdate.Add(wi);
                            }
                        }
                    }

                    // --- status update --- //
                    if (LoadingForm != null && LoadingForm.Visible)
                    {
                        LoadingForm.ChangeLabel("Updating items");
                        this.LoadingForm.Refresh();
                    }

                    if (itemsToUpdate != null && itemsToUpdate.Count > 0)
                    {
                        valueToIncrement = (int)(25 / itemsToUpdate.Count);
                        if (valueToIncrement <= 0) valueToIncrement = 1;

                        foreach (WorkflowItem item in itemsToUpdate)
                        {
                            var tmpItem = AllWorkflowItemsLoaded.First(i => i.DocumentWorkflowItemID == item.DocumentWorkflowItemID);
                            int index = AllWorkflowItemsLoaded.IndexOf(tmpItem as WorkflowItem);

                            this.AllWorkflowItemsLoaded[index] = item;

                            // update loading progress for increment value 
                            if (LoadingForm != null && LoadingForm.Visible)
                            {
                                if (itemsToUpdate.IndexOf(item) % valueToIncrement == 0)
                                {
                                    LoadingForm.MoveBar(1);
                                }
                            }
                        }
                    }
                }));
            }
            catch (Exception)
            {
                this.Invoke(new Action(() =>
                {
                    SetStatusLabelAndTimer("Could not process the request");
                    MakeErrorSound();
                }));
            }

            Application.UseWaitCursor = false;
        }

        // needs reformatting
        private void appendAssignedBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                this.Invoke(new Action(() => {

                    int valueToIncrement = 0;

                    // only make the loading form if more than 100 items are being checked
                    if (this.workflowItemsListView.CheckedItems.Count > 100)
                    {
                        valueToIncrement = (int)(this.workflowItemsListView.CheckedItems.Count / 75);
                        if (valueToIncrement <= 0) valueToIncrement = 1;
                        DimForm();
                        LoadingForm = new LoadingForm();
                        LoadingForm.Show(TransparentForm);
                    }

                    WorkflowItem wi = new WorkflowItem();
                    WorkflowItem previousItem = new WorkflowItem();
                    List<WorkflowItem> itemsToUpdate = new List<WorkflowItem>();
                    itemsInfoAppended = 0;
                    itemsCouldNotBeAppended = false;

                    // --- status update --- //
                    if (LoadingForm != null && LoadingForm.Visible)
                    {
                        LoadingForm.ChangeLabel("Finding items to append");
                        this.LoadingForm.Refresh();
                    }

                    foreach (ListViewItem checkedItem in workflowItemsListView.CheckedItems)
                    {
                        List<WorkflowItem> itemsInGroup;
                        //string status;
                        string assignedTo;

                        // get the item, return if there's only 1 in the item group
                        wi = GetWorkflowItemFromLvItem(checkedItem);

                        // update loading progress for increment value 
                        if (LoadingForm != null && LoadingForm.Visible)
                        {
                            if (workflowItemsListView.CheckedItems.IndexOf(checkedItem) % valueToIncrement == 0)
                            {
                                LoadingForm.MoveBar(1);
                            }
                        }

                        if (wi.ItemsAttached == null) // additional item info is required for this function
                        {
                            itemsCouldNotBeAppended = true;
                            continue;
                        }
                        if (wi.ItemsAttached.Count == 1) continue;

                        // get all the items from the item group into a list
                        itemsInGroup = new List<WorkflowItem>();
                        assignedTo = "";

                        foreach (string id in wi.ItemsAttached)
                        {
                            itemsInGroup.Add(GetWorkflowItemFromAllByID(id));
                        }

                        // take first assigned to val that's not unsg
                        for (int i = 0; i < itemsInGroup.Count(); i++)
                        {
                            if (itemsInGroup[i].AssignedToName != String.Empty && itemsInGroup[i].AssignedToName != "(Unassigned)")
                            {
                                assignedTo = itemsInGroup[i].AssignedToName;

                                i = itemsInGroup.Count();
                            }
                        }

                        // if assigned was saved
                        if (assignedTo != String.Empty)
                        {
                            // change this item
                            if (wi.AssignedToName != assignedTo)
                            {
                                wi.AssignedToName = assignedTo;

                                //if (status == "Documentation Analyst")
                                //{
                                //    wi.WorkflowAnalyst = assignedTo;
                                //}
                                //else if (status == "Company Analyst")
                                //{
                                //    wi.CompanyAnalyst = assignedTo;
                                //}

                                // changing this information is critical and therefore will change the item appearance
                                wi.WorkflowItemInformationDifferentThanCertus = true;
                                wi.DisplayColor = "SpringGreen";
                                ++itemsInfoAppended;

                                // add this item to list to update
                                itemsToUpdate.Add(wi);
                            }
                        }
                    }

                    // --- status update --- //
                    if (LoadingForm != null && LoadingForm.Visible)
                    {
                        LoadingForm.ChangeLabel("Updating items");
                        this.LoadingForm.Refresh();
                    }

                    if (itemsToUpdate != null && itemsToUpdate.Count > 0)
                    {
                        valueToIncrement = (int)(25 / itemsToUpdate.Count);
                        if (valueToIncrement <= 0) valueToIncrement = 1;

                        foreach (WorkflowItem item in itemsToUpdate)
                        {
                            var tmpItem = AllWorkflowItemsLoaded.First(i => i.DocumentWorkflowItemID == item.DocumentWorkflowItemID);
                            int index = AllWorkflowItemsLoaded.IndexOf(tmpItem as WorkflowItem);

                            this.AllWorkflowItemsLoaded[index] = item;

                            // update loading progress for increment value 
                            if (LoadingForm != null && LoadingForm.Visible)
                            {
                                if (itemsToUpdate.IndexOf(item) % valueToIncrement == 0)
                                {
                                    LoadingForm.MoveBar(1);
                                }
                            }
                        }
                    }
                }));
            }
            catch (Exception)
            {
                this.Invoke(new Action(() =>
                {
                    SetStatusLabelAndTimer("Could not process the request");
                    MakeErrorSound();
                }));
            }

            Application.UseWaitCursor = false;
        }

        // needs reformatting
        private void appendDataBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                SetStatusLabelAndTimer("Operation was canceled");
                MakeErrorSound();
            }
            else if (e.Error != null)
            {
                MessageBox.Show("Data appending unsuccessful\n\ne.Error.Message", "Error");
                if (CheckIfFormIsOpened("Transparent Form"))
                    this.Invoke(new Action(() => { TransparentForm.Close(); }));
            }
            else
            {
                // refresh
                //this.refreshBtn.PerformClick();

                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        Application.UseWaitCursor = false;

                        this.LoadingForm.CompleteProgress();
                        //this.loadingForm.ChangeLabel("Items appended successfully");
                        //this.loadingFormTimer.Enabled = true;
                        if (itemsCouldNotBeAppended)
                        {
                            this.LoadingForm.ChangeLabel($"1 or more items did not have information required for this function. {itemsInfoAppended} item(s) appended");
                            SetStatusLabelAndTimer($"1 or more items did not have information required for this function. {itemsInfoAppended} item(s) appended", true);
                        }
                        else
                        {
                            this.LoadingForm.ChangeLabel($"{itemsInfoAppended} item(s) appended");
                            SetStatusLabelAndTimer($"{itemsInfoAppended} item(s) appended", true);
                        }
                        this.LoadingForm.ShowCloseBtn();
                        this.LoadingForm.Refresh();
                    }));
                }
                else
                {
                    Application.UseWaitCursor = false;

                    this.LoadingForm.CompleteProgress();
                    //this.loadingForm.ChangeLabel("Items appended successfully");
                    //this.loadingFormTimer.Enabled = true;
                    if (itemsCouldNotBeAppended)
                    {
                        this.LoadingForm.ChangeLabel($"1 or more items did not have information required for this function. {itemsInfoAppended} item(s) appended");
                        SetStatusLabelAndTimer($"1 or more items did not have information required for this function. {itemsInfoAppended} item(s) appended", true);
                    }
                    else
                    {
                        this.LoadingForm.ChangeLabel($"{itemsInfoAppended} item(s) appended");
                        SetStatusLabelAndTimer($"{itemsInfoAppended} item(s) appended", true);
                    }
                    this.LoadingForm.ShowCloseBtn();
                    this.LoadingForm.Refresh();
                }
            }
        }

        #endregion Fill Data

        #region Find Data

        // needs reformatting
        private void setAnalystFromCompanyBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                if (CheckIfFormIsOpened("Transparent Form")) TransparentForm.Close();
                DimForm();
                LoadingForm = new LoadingForm();
                LoadingForm.Show(TransparentForm);
                LoadingForm.ChangeLabel("Attempting to assign analysts based on company data...");
                this.LoadingForm.Refresh();
            }));

            this.Invoke(new Action(() =>
            {
                try
                {
                    #region Data Declaration/Instantiation
                    itemsWithNoCompany = 0;
                    itemsWhereCompanyNotRecognized = 0;
                    itemsWhereCompanyHadDifferentAnalysts = 0;
                    itemsWhereCompanyHadNoAnalyst = 0;
                    companiesWhichHadDifferentAnalysts = new List<string>();
                    itemsAlreadyCorrectlyAssigned = 0;
                    itemsSuccessfullyAssigned = 0;

                    int valueToIncrement = (int)(this.workflowItemsListView.CheckedItems.Count / 100);
                    if (valueToIncrement <= 0) valueToIncrement = 1;
                    int itemOn = 0;

                    List<WorkflowItem> checkedWorkflowItems = GetWorkflowItemsFromChecked(workflowItemsListView);
                    List<WorkflowItem> workflowItemsUpdated = new List<WorkflowItem>();
                    #endregion Data Declaration/Instantiation

                    foreach (WorkflowItem wi in checkedWorkflowItems)
                    {
                        // keep track of which item is being iterated for the loading bar
                        ++itemOn;

                        // update loading progress for increment value 
                        if (itemOn % valueToIncrement == 0)
                        {
                            LoadingForm.MoveBar(1);
                            this.LoadingForm.Refresh();
                        }

                        // return if no company
                        if (wi.VendorName == null || wi.VendorName == String.Empty)
                        {
                            ++itemsWithNoCompany;
                            continue;
                        }
                        // return if company isn't in the dictionary
                        else if (!companyNameDictionary.ContainsValue(wi.VendorName))
                        {
                            ++itemsWhereCompanyNotRecognized;
                            continue;
                        }
                        // company does exists, check further
                        else
                        {
                            // if the company name is a value more than once in the dictionary
                            if (companyNameDictionary.Count(i => i.Value == wi.VendorName) > 1)
                            {
                                List<string> companyIdsWhereValueIsSame = new List<string>();
                                List<Company> companiesToCheck = new List<Company>();
                                List<string> analystsToCheck = new List<string>();

                                // get company ids where value occurs twice in compNameDic
                                foreach (var keyValuePair in companyNameDictionary)
                                {
                                    if (keyValuePair.Value == wi.VendorName) companyIdsWhereValueIsSame.Add(keyValuePair.Key);
                                }

                                // get companies from company ids out of the companyDic
                                foreach (var companyId in companyIdsWhereValueIsSame)
                                {
                                    foreach (var keyValuePair in companyDictionary)
                                    {
                                        if (keyValuePair.Key == companyId) companiesToCheck.Add(keyValuePair.Value);
                                    }
                                }

                                // get analysts from the companies. only add if analyst is there
                                foreach (Company comp in companiesToCheck)
                                {
                                    if (comp.Analyst != null && comp.Analyst != String.Empty && comp.Analyst != "Richard Ellis") analystsToCheck.Add(comp.Analyst);
                                }

                                // if analysts are not there, company doesn't have any analyst
                                if (analystsToCheck == null || analystsToCheck.Count == 0)
                                {
                                    ++itemsWhereCompanyHadNoAnalyst;
                                    continue;
                                }

                                // if analysts are different, save company name if it hasn't been saved already
                                if (analystsToCheck.Any(o => o != analystsToCheck[0]))
                                {
                                    ++itemsWhereCompanyHadDifferentAnalysts;
                                    if (!companiesWhichHadDifferentAnalysts.Contains(wi.VendorName)) companiesWhichHadDifferentAnalysts.Add(wi.VendorName);
                                }
                                else // analysts are not different
                                {
                                    // finally, check to make sure this analyst isn't already assigned
                                    if(wi.AssignedToName==analystsToCheck[0])
                                    {
                                        ++itemsAlreadyCorrectlyAssigned;
                                        continue;
                                    }

                                    ++itemsSuccessfullyAssigned;
                                    wi.AssignedToName = analystsToCheck[0];
                                    wi.WorkflowItemInformationDifferentThanCertus = true;
                                    wi.DisplayColor = "SpringGreen";
                                    workflowItemsUpdated.Add(wi);
                                }
                            }
                            // company only appears once in the dictionary
                            else
                            {
                                // get company
                                string companyId = null;

                                foreach (var keyValuePair in companyNameDictionary)
                                {
                                    if (keyValuePair.Value == wi.VendorName) companyId = keyValuePair.Key;
                                }

                                Company comp = companyDictionary[companyId];

                                // if company has no analyst (richard ellis is not an analyst)
                                if (comp.Analyst == null || comp.Analyst == String.Empty || comp.Analyst == "Richard Ellis")
                                {
                                    ++itemsWhereCompanyHadNoAnalyst;
                                    continue;
                                }
                                else // company has an analyst
                                {
                                    // finally, check to make sure this analyst isn't already assigned
                                    if (wi.AssignedToName == comp.Analyst)
                                    {
                                        ++itemsAlreadyCorrectlyAssigned;
                                        continue;
                                    }

                                    ++itemsSuccessfullyAssigned;
                                    wi.AssignedToName = comp.Analyst;
                                    wi.WorkflowItemInformationDifferentThanCertus = true;
                                    wi.DisplayColor = "SpringGreen";
                                    workflowItemsUpdated.Add(wi);
                                }
                            }
                        }
                    }

                    // Update loaded items if items were updated
                    if (workflowItemsUpdated != null && workflowItemsUpdated.Count > 0) UpdateAllLoadedWorkflowItems(workflowItemsUpdated);

                    return;
                }
                catch (NullReferenceException m)
                {
                    MessageBox.Show($"Encountered an error while processing the request.\n\nMessage: {m.Message}", "Error");
                    MakeErrorSound();
                }
                catch (IndexOutOfRangeException m)
                {
                    MessageBox.Show($"Encountered an error while processing the request.\n\nMessage: {m.Message}", "Error");
                    MakeErrorSound();
                }
                catch (Exception m)
                {
                    MessageBox.Show($"Encountered an error while processing the request.\n\nMessage: {m.Message}", "Error");
                    MakeErrorSound();
                }

            }));
        }

        // needs reformatting
        private void setAnalystFromCompanyBackgroundWork_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                Application.UseWaitCursor = false;

                if (e.Cancelled == true)
                {
                    SetStatusLabelAndTimer("Operation was canceled");
                    MakeErrorSound();
                }
                else if (e.Error != null)
                {
                    SetStatusLabelAndTimer("Operation unsuccessful");
                    MessageBox.Show("Operation unsuccessful\n\ne.Error.Message", "Error");
                    if (CheckIfFormIsOpened("Transparent Form")) this.TransparentForm.Close();
                }
                else
                {
                    this.LoadingForm.FormatForReport(140);
                    this.LoadingForm.ChangeHeaderLabel("Operation Complete");
                    this.LoadingForm.ChangeLabel($"Assignment Operation successful;\n\n" +
                        $"Items assigned: {itemsSuccessfullyAssigned}\n" +
                        $"Items not assigned: {itemsWithNoCompany + itemsWhereCompanyNotRecognized + itemsWhereCompanyHadNoAnalyst + itemsWhereCompanyHadDifferentAnalysts + itemsAlreadyCorrectlyAssigned}\n" +
                        $"---------------------------------------------------------------------------\n" +
                        $"    Items already correctly assigned: {itemsAlreadyCorrectlyAssigned}\n" +
                        $"    Items with no company: {itemsWithNoCompany}\n" +
                        $"    Items where the company was unrecognized: {itemsWhereCompanyNotRecognized}\n" +
                        $"    Items where the company had no analyst: {itemsWhereCompanyHadNoAnalyst}\n" +
                        $"    Items where the company had different analysts: {itemsWhereCompanyHadDifferentAnalysts}");
                    this.LoadingForm.ShowCloseBtn();
                    this.LoadingForm.Refresh();
                }

            }));
        }

        // needs reformatting
        private void setAnalystFromMarketBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                if (CheckIfFormIsOpened("Transparent Form")) TransparentForm.Close();
                DimForm();
                LoadingForm = new LoadingForm();
                LoadingForm.Show(TransparentForm);
                LoadingForm.ChangeLabel("Attempting to assign analysts based on company market data...");
                this.LoadingForm.Refresh();
            }));

            this.Invoke(new Action(() =>
            {
                try
                {
                    #region Data Declaration/Instantiation
                    itemsWithNoCompany = 0;
                    itemsWhereCompanyNotRecognized = 0;
                    itemsAlreadyCorrectlyAssigned = 0;
                    itemsWhereCompanyHadDifferentMarkets = 0;
                    itemsSuccessfullyAssigned = 0;
                    itemsWhereMarketNotFound = 0;
                    string market = "";

                    int valueToIncrement = (int)(this.workflowItemsListView.CheckedItems.Count / 100);
                    if (valueToIncrement <= 0) valueToIncrement = 1;
                    int itemOn = 0;

                    List<WorkflowItem> checkedWorkflowItems = GetWorkflowItemsFromChecked(workflowItemsListView);
                    List<WorkflowItem> workflowItemsUpdated = new List<WorkflowItem>();
                    #endregion Data Declaration/Instantiation

                    foreach (WorkflowItem wi in checkedWorkflowItems)
                    {
                        // keep track of which item is being iterated for the loading bar
                        ++itemOn;

                        // update loading progress for increment value 
                        if (itemOn % valueToIncrement == 0)
                        {
                            LoadingForm.MoveBar(1);
                            this.LoadingForm.Refresh();
                        }

                        // return if no company
                        if (wi.VendorName == null || wi.VendorName == String.Empty)
                        {
                            ++itemsWithNoCompany;
                            continue;
                        }
                        // return if company isn't in the dictionary
                        else if (!companyNameDictionary.ContainsValue(wi.VendorName))
                        {
                            ++itemsWhereCompanyNotRecognized;
                            continue;
                        }
                        // company does exists, check further
                        else
                        {
                            List<string> companyIdsWhereValueIsSame = new List<string>();
                            List<Company> companiesToCheck = new List<Company>();
                            List<string> marketsToCheck = new List<string>();

                            // get company ids where value occurs twice in compNameDic
                            foreach (var keyValuePair in companyNameDictionary)
                            {
                                if (keyValuePair.Value == wi.VendorName) companyIdsWhereValueIsSame.Add(keyValuePair.Key);
                            }

                            // get companies from company ids out of the companyDic
                            foreach (var companyId in companyIdsWhereValueIsSame)
                            {
                                foreach (var keyValuePair in companyDictionary)
                                {
                                    if (keyValuePair.Key == companyId) companiesToCheck.Add(keyValuePair.Value);
                                }
                            }

                            // determine if a market can be found
                            foreach (Company com in companiesToCheck)
                            {
                                if (marketAssignments.ContainsKey(com.City))
                                {
                                    marketsToCheck.Add(com.City);
                                    continue;
                                }
                                else if (marketAssignments.ContainsKey(com.State))
                                {
                                    marketsToCheck.Add(com.City);
                                    continue;
                                }
                                else // market is not found
                                {
                                    market = "";
                                }
                            }

                            // if markets are different, save and continue
                            if (marketsToCheck.Any(o => o != marketsToCheck[0]))
                            {
                                ++itemsWhereCompanyHadDifferentMarkets;
                                continue;
                            }

                            if (marketsToCheck == null|| marketsToCheck.Count==0)
                            {
                                ++itemsWhereMarketNotFound;
                                continue;
                            }
                            else // market is found
                            {
                                market = marketsToCheck[0];
                                string analyst = marketAssignments[market];
                                if(wi.AssignedToName != analyst) wi.AssignedToName = analyst;
                                else
                                {
                                    ++itemsAlreadyCorrectlyAssigned;
                                    continue;
                                }
                                wi.DisplayColor = "SpringGreen";
                                wi.WorkflowItemInformationDifferentThanCertus = true;
                                ++itemsSuccessfullyAssigned;
                                workflowItemsUpdated.Add(wi);
                            }
                        }
                    }

                    // Update loaded items if items were updated
                    if (workflowItemsUpdated != null && workflowItemsUpdated.Count > 0) UpdateAllLoadedWorkflowItems(workflowItemsUpdated);

                    return;
                }
                catch (NullReferenceException m)
                {
                    MessageBox.Show($"Encountered an error while processing the request.\n\nMessage: {m.Message}", "Error");
                    MakeErrorSound();
                }
                catch (IndexOutOfRangeException m)
                {
                    MessageBox.Show($"Encountered an error while processing the request.\n\nMessage: {m.Message}", "Error");
                    MakeErrorSound();
                }
                catch (Exception m)
                {
                    MessageBox.Show($"Encountered an error while processing the request.\n\nMessage: {m.Message}", "Error");
                    MakeErrorSound();
                }

            }));
        }
        
        // needs reformatting
        private void setAnalystFromMarketBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UseWaitCursor = false;

            if (e.Cancelled == true)
            {
                SetStatusLabelAndTimer("Operation was canceled");
                MakeErrorSound();
            }
            else if (e.Error != null)
            {
                SetStatusLabelAndTimer("Operation unsuccessful");
                MessageBox.Show("Operation unsuccessful\n\ne.Error.Message", "Error");
                if (CheckIfFormIsOpened("Transparent Form")) this.TransparentForm.Close();
            }
            else
            {
                if (this.InvokeRequired) this.Invoke(new Action(() =>
                    {
                        this.LoadingForm.FormatForReport(140);
                        this.LoadingForm.ChangeHeaderLabel("Operation Complete");
                        this.LoadingForm.ChangeLabel($"Assignment Operation successful;\n\n" +
                            $"Items assigned: {itemsSuccessfullyAssigned}\n" +
                            $"Items not assigned: {itemsWithNoCompany + itemsWhereCompanyNotRecognized + itemsAlreadyCorrectlyAssigned + itemsWhereCompanyHadDifferentMarkets + itemsWhereMarketNotFound}\n" +
                            $"---------------------------------------------------------------------------\n" +
                            $"    Items already correctly assigned: {itemsAlreadyCorrectlyAssigned}\n" +
                            $"    Items with no company: {itemsWithNoCompany}\n" +
                            $"    Items where the company was unrecognized: {itemsWhereCompanyNotRecognized}\n" +
                            $"    Items where the company had different markets: {itemsWhereCompanyHadDifferentMarkets}\n" +
                            $"    Items where the market was not found: {itemsWhereMarketNotFound}");
                        this.LoadingForm.ShowCloseBtn();
                        this.LoadingForm.Refresh();
                    }));
                else
                {
                    this.LoadingForm.FormatForReport(140);
                    this.LoadingForm.ChangeHeaderLabel("Operation Complete");
                    this.LoadingForm.ChangeLabel($"Assignment Operation successful;\n\n" +
                        $"Items assigned: {itemsSuccessfullyAssigned}\n" +
                        $"Items not assigned: {itemsWithNoCompany + itemsWhereCompanyNotRecognized + itemsAlreadyCorrectlyAssigned + itemsWhereCompanyHadDifferentMarkets + itemsWhereMarketNotFound}\n" +
                        $"---------------------------------------------------------------------------\n" +
                        $"    Items already correctly assigned: {itemsAlreadyCorrectlyAssigned}\n" +
                        $"    Items with no company: {itemsWithNoCompany}\n" +
                        $"    Items where the company was unrecognized: {itemsWhereCompanyNotRecognized}\n" +
                        $"    Items where the company had different markets: {itemsWhereCompanyHadDifferentMarkets}\n" +
                        $"    Items where the market was not found: {itemsWhereMarketNotFound}");
                    this.LoadingForm.ShowCloseBtn();
                    this.LoadingForm.Refresh();
                }
            }
        }

        private void setAnalystFromCertificateBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            UseWaitCursor = true;

            List<WorkflowItem> checkedWorkflowItems = e.Argument as List<WorkflowItem>;
            List<WorkflowItem> itemsToUpdate = new List<WorkflowItem>();

            // data to track
            itemsWithNoCertificate = 0;
            itemsWhereContractUnrecognized = 0;
            itemsWhereCompanyHadNoAnalyst = 0;
            itemsAlreadyCorrectlyAssigned = 0;
            itemsSuccessfullyAssigned = 0;

            // for loading bar
            LoadingForm = new LoadingForm();
            int valueToIncrement = (int)(checkedWorkflowItems.Count / 100);
            if (valueToIncrement <= 0) valueToIncrement = 1;
            int itemOn = 0;

            // show loading form regardless
            DimForm();
            if (TransparentForm.InvokeRequired)
            {
                TransparentForm.Invoke(new Action(() => { LoadingForm.Show(TransparentForm); }));
            }
            else
            {
                LoadingForm.Show(TransparentForm);
            }
            
            // start process
            foreach (WorkflowItem wi in checkedWorkflowItems)
            {
                List<string> companyIdsToCheck = new List<string>();
                List<Company> companiesToCheck = new List<Company>();
                Certificate contract = new Certificate();

                // keep track of which item is being iterated for the loading bar
                ++itemOn;

                // update loading progress for increment value 
                if (itemOn % valueToIncrement == 0)
                {
                    if (this.InvokeRequired)
                    {
                        this.Invoke(new Action(() =>
                        {
                            LoadingForm.MoveBar(1);
                            //this.loadingForm.Refresh();
                        }));
                    }
                    else
                    {
                        LoadingForm.MoveBar(1);
                        //this.loadingForm.Refresh();
                    }
                }

                // return if no certificate
                if (wi.ContractID == null || wi.ContractID == String.Empty)
                {
                    ++itemsWithNoCertificate;
                    continue;
                }
                // return if certificate isn't in the dictionary
                else if (!certificateDictionary.ContainsKey(wi.ContractID))
                {
                    ++itemsWhereContractUnrecognized;
                    continue;
                }
                // contract does exists, check further
                else
                {
                    Certificate cert = certificateDictionary[wi.ContractID];
                    string companyID = cert.BcsCompanyID;
                    
                    Company company = new Company();
                    if (companyDictionary.ContainsKey(companyID)) company = companyDictionary[companyID]; // not all companies were tied at this step...
                    else continue;

                    // analyst is not listed for the company
                    if (company.Analyst==null|| company.Analyst == String.Empty || company.Analyst == "Richard Ellis")
                    {
                        ++itemsWhereCompanyHadNoAnalyst;
                        continue;
                    }
                    else
                    {
                        // analyst is already assigned
                        if(wi.AssignedToName==company.Analyst)
                        {
                            ++itemsAlreadyCorrectlyAssigned;
                            continue;
                        }
                        // item gets assigned successfully
                        else
                        {
                            wi.AssignedToName = company.Analyst;
                            wi.WorkflowItemInformationDifferentThanCertus = true;
                            wi.DisplayColor = "SpringGreen";
                            ++itemsSuccessfullyAssigned;
                        }
                    }
                }
            }
        }

        private void setAnalystFromCertificateBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UseWaitCursor = false;

            if (e.Cancelled == true)
            {
                SetStatusLabelAndTimer("Operation was canceled");
                MakeErrorSound();
            }
            else if (e.Error != null)
            {
                SetStatusLabelAndTimer("Operation unsuccessful");
                MessageBox.Show("Operation unsuccessful\n\ne.Error.Message", "Error");
                if (CheckIfFormIsOpened("Transparent Form")) this.TransparentForm.Close();
            }
            else
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        this.LoadingForm.FormatForReport(140);
                        this.LoadingForm.ChangeHeaderLabel("Operation Complete");
                        this.LoadingForm.ChangeLabel($"Assignment Operation successful;\n\n" +
                            $"Items assigned: {itemsSuccessfullyAssigned}\n" +
                            $"Items not assigned: {itemsWithNoCertificate + itemsWhereContractUnrecognized + itemsWhereCompanyHadNoAnalyst + itemsAlreadyCorrectlyAssigned}\n" +
                            $"---------------------------------------------------------------------------\n" +
                            $"    Items already correctly assigned: {itemsAlreadyCorrectlyAssigned}\n" +
                            $"    Items where the company had no analyst: {itemsWhereCompanyHadNoAnalyst}\n" +
                            $"    Items where the certificate was unrecognized: {itemsWhereContractUnrecognized}\n" +
                            $"    Items with no certificate: {itemsWithNoCertificate}\n");
                        this.LoadingForm.ShowCloseBtn();
                        this.LoadingForm.Refresh();
                    }));
                }
                else
                {
                    this.LoadingForm.FormatForReport(140);
                    this.LoadingForm.ChangeHeaderLabel("Operation Complete");
                    this.LoadingForm.ChangeLabel($"Assignment Operation successful;\n\n" +
                        $"Items assigned: {itemsSuccessfullyAssigned}\n" +
                        $"Items not assigned: {itemsWithNoCertificate + itemsWhereContractUnrecognized + itemsWhereCompanyHadNoAnalyst + itemsAlreadyCorrectlyAssigned}\n" +
                        $"---------------------------------------------------------------------------\n" +
                        $"    Items already correctly assigned: {itemsAlreadyCorrectlyAssigned}\n" +
                        $"    Items where the company had no analyst: {itemsWhereCompanyHadNoAnalyst}\n" +
                        $"    Items where the certificate was unrecognized: {itemsWhereContractUnrecognized}\n" +
                        $"    Items with no certificate: {itemsWithNoCertificate}\n");
                    this.LoadingForm.ShowCloseBtn();
                    this.LoadingForm.Refresh();
                }
            }
        }

        //
        private void findAndFillCompanyBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //this.Invoke(new Action(() =>
            //{

            string selection = e.Argument as string;

            switch (selection)
            {
                case "sender":
                    {
                        CheckSenderForCompany();
                    }
                    break;
                case "subject":
                    {
                        CheckSubjectForCompany();
                    }
                    break;
                case "all":
                    break;
                default:
                    break;
            }

            //}));
        }

        //
        private void CheckSubjectForCompany()
        {
            List<WorkflowItem> checkedWorkflowItems = new List<WorkflowItem>();

            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    checkedWorkflowItems = GetWorkflowItemsFromChecked(workflowItemsListView);
                }));
            }
            else
            {
                checkedWorkflowItems = GetWorkflowItemsFromChecked(workflowItemsListView);
            }

            List<WorkflowItem> itemsToUpdate = new List<WorkflowItem>();
            itemsUpdated = 0;

            // for loading bar
            LoadingForm = new LoadingForm();
            int valueToIncrement = (int)(checkedWorkflowItems.Count / 100);
            if (valueToIncrement <= 0) valueToIncrement = 1;
            int itemOn = 0;

            // show loading form if more than 50 items
            if (checkedWorkflowItems.Count > 50)
            {
                DimForm();

                if (TransparentForm.InvokeRequired)
                {
                    TransparentForm.Invoke(new Action(() => 
                    {
                        LoadingForm.Show(TransparentForm);
                        LoadingForm.ChangeHeaderLabel("Loading");
                        LoadingForm.ChangeLabel("Processing the request...");
                        LoadingForm.Refresh();
                    }));
                }
                else
                {
                    LoadingForm.Show(TransparentForm);
                    LoadingForm.ChangeHeaderLabel("Loading");
                    LoadingForm.ChangeLabel("Processing the request...");
                    LoadingForm.Refresh();
                }
            }
            // use status label when less
            else
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() => { SetStatusLabelAndTimer("Processing the request...", true); ; }));
                }
                else
                {
                    SetStatusLabelAndTimer("Processing the request...", true);
                }
            }

            // process
            foreach (WorkflowItem wi in checkedWorkflowItems)
            {
                List<string> companiesToSettleOn = new List<string>();
                string companySettledOn = "";

                // keep track of which item is being iterated for the loading bar
                ++itemOn;

                // update loading progress for increment value 
                if (itemOn % valueToIncrement == 0)
                {
                    if (this.InvokeRequired)
                    {
                        this.Invoke(new Action(() =>
                        {
                            LoadingForm.MoveBar(1);
                        }));
                    }
                    else
                    {
                        LoadingForm.MoveBar(1);
                    }
                }

                // get subject line with only letters/numbers to match more company names
                string subject = wi.SubjectLine;
                string subjectWithOnlyLettersAndNumbers = new String(subject.Where(c => Char.IsLetter(c) || Char.IsNumber(c)).ToArray());

                foreach (string companyName in companyNameDictionary.Values)
                {
                    string companyWithOnlyLettersAndNumbers = new String(companyName.Where(c => Char.IsLetter(c) || Char.IsNumber(c)).ToArray());

                    if (subjectWithOnlyLettersAndNumbers.ToLower().Contains(companyWithOnlyLettersAndNumbers.ToLower())
                        //&& companyName.ToLower() != "cbre" && companyName.ToLower() != "west" && companyName.ToLower() != "arc" && companyName.ToLower() != "dsi")
                        && companyName.Count()>4)
                    {
                        if (wi.VendorName.ToLower() != companyName.ToLower())
                        {
                            companiesToSettleOn.Add(companyName);
                        }
                    }
                }

                if(companiesToSettleOn!=null&&companiesToSettleOn.Count>0)
                {
                    companySettledOn = companiesToSettleOn.Aggregate("", (max, cur) => max.Length > cur.Length ? max : cur);
                }

                if(companySettledOn!=null&&companySettledOn!=String.Empty)
                {
                    if (wi.VendorName.ToLower() != companySettledOn.ToLower())
                    {
                        wi.VendorName = companySettledOn;
                        wi.CompanyUpdated = true;
                        itemsToUpdate.Add(wi);
                        ++itemsUpdated;
                    }
                }
            }

            if (itemsToUpdate != null && itemsToUpdate.Count > 0) UpdateAllLoadedWorkflowItems(itemsToUpdate);
        }

        //
        private void CheckSenderForCompany()
        {
            List<WorkflowItem> checkedWorkflowItems = new List<WorkflowItem>();

            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    checkedWorkflowItems = GetWorkflowItemsFromChecked(workflowItemsListView);
                }));
            }
            else
            {
                checkedWorkflowItems = GetWorkflowItemsFromChecked(workflowItemsListView);
            }

            List<WorkflowItem> itemsToUpdate = new List<WorkflowItem>();
            itemsUpdated = 0;

            // for loading bar
            LoadingForm = new LoadingForm();
            int valueToIncrement = (int)(checkedWorkflowItems.Count / 100);
            if (valueToIncrement <= 0) valueToIncrement = 1;
            int itemOn = 0;

            // show loading form if more than 50 items
            if (checkedWorkflowItems.Count > 50)
            {
                DimForm();

                if (TransparentForm.InvokeRequired)
                {
                    TransparentForm.Invoke(new Action(() =>
                    {
                        LoadingForm.Show(TransparentForm);
                        LoadingForm.ChangeHeaderLabel("Loading");
                        LoadingForm.ChangeLabel("Processing the request...");
                        LoadingForm.Refresh();
                    }));
                }
                else
                {
                    LoadingForm.Show(TransparentForm);
                    LoadingForm.ChangeHeaderLabel("Loading");
                    LoadingForm.ChangeLabel("Processing the request...");
                    LoadingForm.Refresh();
                }
            }
            // use status label when less
            else
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() => { SetStatusLabelAndTimer("Processing the request...", true); ; }));
                }
                else
                {
                    SetStatusLabelAndTimer("Processing the request...", true);
                }
            }

            // process
            foreach (WorkflowItem wi in checkedWorkflowItems)
            {
                // keep track of which item is being iterated for the loading bar
                ++itemOn;

                // update loading progress for increment value 
                if (itemOn % valueToIncrement == 0)
                {
                    if (this.InvokeRequired)
                    {
                        this.Invoke(new Action(() =>
                        {
                            LoadingForm.MoveBar(1);
                        }));
                    }
                    else
                    {
                        LoadingForm.MoveBar(1);
                    }
                }

                bool emailWasFound = false;
                bool emailOccuredTwice = false;
                List<string> companyIdsToCheck = new List<string>();
                List<Company> companiesToCheck = new List<Company>();
                

                foreach (var keyValuePair in companyContactDictionary)
                {
                    if (keyValuePair.Value.Any(i => i.Email == wi.EmailFromAddress))
                    {
                        if (emailWasFound) emailOccuredTwice = true;
                        
                        emailWasFound = true;
                        companyIdsToCheck.Add(keyValuePair.Key);
                    }
                }

                foreach (string id in companyIdsToCheck)
                {
                    companiesToCheck.Add(companyDictionary[id]);
                }

                if (emailOccuredTwice)
                {
                    // check if the email was for different companies

                    if (companiesToCheck.Any(o => o.CompanyName != companiesToCheck[0].CompanyName))
                    {
                        // email was for different companies
                        continue;
                    }
                    else
                    {
                        // company is the same. contact can be tied
                        if (wi.VendorName != companiesToCheck[0].CompanyName)
                        {
                            wi.VendorName = companiesToCheck[0].CompanyName;
                            wi.CompanyUpdated = true;
                            itemsToUpdate.Add(wi);
                            ++itemsUpdated;
                        }
                    }
                }
                // contact is unique
                else if (emailWasFound)
                {
                    // contact can be tied
                    if (wi.VendorName != companiesToCheck[0].CompanyName)
                    {
                        wi.VendorName = companiesToCheck[0].CompanyName;
                        wi.CompanyUpdated = true;
                        itemsToUpdate.Add(wi);
                        ++itemsUpdated;
                    }
                }
            }

            if (itemsToUpdate != null && itemsToUpdate.Count > 0) UpdateAllLoadedWorkflowItems(itemsToUpdate);
        }

        //
        private void findAndFillCompanyBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UseWaitCursor = false;

            if (e.Cancelled == true)
            {
                SetStatusLabelAndTimer("Operation was canceled");
                MakeErrorSound();
            }
            else if (e.Error != null)
            {
                if (CheckIfFormIsOpened("Transparent Form")) this.TransparentForm.Close();
                SetStatusLabelAndTimer("Operation unsuccessful");
                MessageBox.Show("Operation unsuccessful\n\ne.Error.Message", "Error");
            }
            else
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        this.LoadingForm.CompleteProgress();
                        this.LoadingForm.ChangeLabel("Loading Complete");
                        this.LoadingForm.Refresh();
                        this.loadingFormTimer.Enabled = true;
                        this.SetStatusLabelAndTimer($"Company data updated for {itemsUpdated} item(s)", true);
                    }));
                }
                else
                {
                    this.LoadingForm.CompleteProgress();
                    this.LoadingForm.ChangeLabel("Loading Complete");
                    this.LoadingForm.Refresh();
                    this.loadingFormTimer.Enabled = true;
                    this.SetStatusLabelAndTimer($"Company data updated for {itemsUpdated} item(s)", true);
                }
            }
        }

        private void findAndOverrideContractInformationBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            UseWaitCursor = true;

            List<WorkflowItem> checkedWorkflowItems = e.Argument as List<WorkflowItem>;
            List<WorkflowItem> itemsToUpdate = new List<WorkflowItem>();
            itemsUpdated = 0;
            contractsPulled = 0;
            LoadingForm = new LoadingForm();

            // for loading bar
            int valueToIncrement = (int)(checkedWorkflowItems.Count / 100);
            if (valueToIncrement <= 0) valueToIncrement = 1;
            int itemOn = 0;

            // show loading form if more than 50 items
            if (checkedWorkflowItems.Count > 50)
            {
                DimForm();

                if (TransparentForm.InvokeRequired)
                {
                    TransparentForm.Invoke(new Action(() =>
                    {
                        LoadingForm.Show(TransparentForm);
                        LoadingForm.ChangeHeaderLabel("Loading");
                        LoadingForm.ChangeLabel("Processing the request...");
                        LoadingForm.Refresh();
                    }));
                }
                else
                {
                    LoadingForm.Show(TransparentForm);
                    LoadingForm.ChangeHeaderLabel("Loading");
                    LoadingForm.ChangeLabel("Processing the request...");
                    LoadingForm.Refresh();
                }
            }
            // use status label when less
            else
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() => { SetStatusLabelAndTimer("Processing the request...", true); ; }));
                }
                else
                {
                    SetStatusLabelAndTimer("Processing the request...", true);
                }
            }

            foreach (WorkflowItem wi in checkedWorkflowItems)
            {
                List<string> companyIdsToCheck = new List<string>();
                List<Company> companiesToCheck = new List<Company>();
                bool contractFound = false;

                // keep track of which item is being iterated for the loading bar
                ++itemOn;

                // update loading progress for increment value 
                if (itemOn % valueToIncrement == 0)
                {
                    if (this.InvokeRequired)
                    {
                        this.Invoke(new Action(() => 
                        {
                            LoadingForm.MoveBar(1);
                            //this.loadingForm.Refresh();
                        }));
                    }
                    else
                    {
                        LoadingForm.MoveBar(1);
                        //this.loadingForm.Refresh();
                    }
                }

                foreach (var keyValuePair in certificateDictionary)
                {
                    if (contractFound) continue;

                    if (wi.SubjectLine.Contains(keyValuePair.Key))
                    {
                        int index = wi.SubjectLine.IndexOf(keyValuePair.Key);
                        char charBefore = '<';
                        char charAfter = '>';

                        if (index != 0) charBefore = wi.SubjectLine[index - 1];
                        if (index + keyValuePair.Key.Length != wi.SubjectLine.Length) charAfter = wi.SubjectLine[index + keyValuePair.Key.Length];

                        if (!Char.IsNumber(charBefore) && !Char.IsNumber(charAfter))
                        {
                            // contract is there
                            contractFound = true;

                            // update all contract information associated with wf item
                            if(wi.ContractID!=keyValuePair.Key)
                            {
                                // company
                                if (wi.VendorName != keyValuePair.Value.CompanyName)
                                {
                                    wi.VendorName = keyValuePair.Value.CompanyName;
                                    wi.CompanyUpdated = true;
                                    ++itemsUpdated;
                                }

                                // contract
                                wi.ContractID = keyValuePair.Key;
                                wi.ContractIdOverridden = true;
                                ++contractsPulled;

                                // contract info
                                wi.Active = keyValuePair.Value.CertificateActive;
                                wi.Compliant = keyValuePair.Value.CertificateCompliant;
                                wi.NextExpirationDate = null; // next exp data is not included on cert imports (can change in future if necessary)
                                wi.ContractInformationUpdated = true;

                                itemsToUpdate.Add(wi);
                            }
                        }
                    }
                    else
                    {
                        // contract is not there
                        //wi.ContractID = String.Empty; // remove because current contract IDs cannot be trusted
                        //wi.ContractIdOverridden = true;
                    }
                }
            }

            if (itemsToUpdate != null && itemsToUpdate.Count > 0) UpdateAllLoadedWorkflowItems(itemsToUpdate);
        }

        private void findAndOverrideContractInformationBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Invoke(new Action(() =>
            {

            UseWaitCursor = false;

            if (e.Cancelled == true)
            {
                SetStatusLabelAndTimer("Operation was canceled");
                MakeErrorSound();
            }
            else if (e.Error != null)
            {
                MessageBox.Show("Operation unsuccessful\n\ne.Error.Message", "Error");
                if (CheckIfFormIsOpened("Transparent Form")) this.TransparentForm.Close();
            }
            else
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        this.LoadingForm.CompleteProgress();
                        this.LoadingForm.ChangeLabel("Loading Complete");
                        this.LoadingForm.Refresh();
                        this.loadingFormTimer.Enabled = true;
                        if(itemsUpdated>0) this.SetStatusLabelAndTimer($"Contract(s) pulled for {contractsPulled} item(s). Company data updated for {itemsUpdated} item(s)", true);
                        else this.SetStatusLabelAndTimer($"Contract(s) pulled for {contractsPulled} item(s)");
                    }));
                }
                else
                {
                    this.LoadingForm.CompleteProgress();
                    this.LoadingForm.ChangeLabel("Loading Complete");
                    this.LoadingForm.Refresh();
                    this.loadingFormTimer.Enabled = true;
                    if (itemsUpdated > 0) this.SetStatusLabelAndTimer($"Contract(s) pulled for {contractsPulled} item(s). Company data updated for {itemsUpdated} item(s)", true);
                    else this.SetStatusLabelAndTimer($"Contract(s) pulled for {contractsPulled} item(s)");
                }
            }

            }));
        }

        private void updateContractInformationBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            UseWaitCursor = true;

            List<WorkflowItem> checkedWorkflowItems = e.Argument as List<WorkflowItem>;
            List<WorkflowItem> itemsToUpdate = new List<WorkflowItem>();

            itemsUpdated = 0;
            itemsUpToDate = 0;
            itemsWhereContractUnrecognized = 0;
            itemsWithNoCertificate = 0;

            // for loading bar
            LoadingForm = new LoadingForm();
            int valueToIncrement = (int)(checkedWorkflowItems.Count / 100);
            if (valueToIncrement <= 0) valueToIncrement = 1;
            int itemOn = 0;

            // show loading form if more than 50 items
            if (checkedWorkflowItems.Count > 50)
            {
                DimForm();

                if (TransparentForm.InvokeRequired)
                {
                    TransparentForm.Invoke(new Action(() =>
                    {
                        LoadingForm.Show(TransparentForm);
                        LoadingForm.ChangeHeaderLabel("Loading");
                        LoadingForm.ChangeLabel("Processing the request...");
                        LoadingForm.Refresh();
                    }));
                }
                else
                {
                    LoadingForm.Show(TransparentForm);
                    LoadingForm.ChangeHeaderLabel("Loading");
                    LoadingForm.ChangeLabel("Processing the request...");
                    LoadingForm.Refresh();
                }
            }
            // use status label when less
            else
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() => { SetStatusLabelAndTimer("Processing the request...", true); ; }));
                }
                else
                {
                    SetStatusLabelAndTimer("Processing the request...", true);
                }
            }

            foreach (WorkflowItem wi in checkedWorkflowItems)
            {
                List<string> companyIdsToCheck = new List<string>();
                List<Company> companiesToCheck = new List<Company>();
                Certificate contract = new Certificate();

                // keep track of which item is being iterated for the loading bar
                ++itemOn;

                // update loading progress for increment value 
                if (itemOn % valueToIncrement == 0)
                {
                    if (this.InvokeRequired)
                    {
                        this.Invoke(new Action(() =>
                        {
                            LoadingForm.MoveBar(1);
                            //this.loadingForm.Refresh();
                        }));
                    }
                    else
                    {
                        LoadingForm.MoveBar(1);
                        //this.loadingForm.Refresh();
                    }
                }

                // if there's a contract id for the item
                if (wi.ContractID != null && wi.ContractID != String.Empty)
                {
                    // if the contract id is recognized
                    if (certificateDictionary.ContainsKey(wi.ContractID))
                    {
                        // get this contract
                        contract = certificateDictionary[wi.ContractID];

                        // if any contract related info is different (including the companyName)
                        if (wi.VendorName != contract.CompanyName || wi.Active != contract.CertificateActive || wi.Active != contract.CertificateCompliant)
                        {
                            // update company only if not the same to preserve the indicator accuracy
                            if(wi.VendorName!=contract.CompanyName)
                            {
                                wi.VendorName = contract.CompanyName;
                                wi.CompanyUpdated = true;
                            }

                            // update contract info
                            wi.Active = contract.CertificateActive;
                            wi.Compliant = contract.CertificateCompliant;
                            wi.NextExpirationDate = contract.NextPolicyExpirationDate;
                            wi.ContractInformationUpdated = true;

                            // an item will be marked as updated even if only the company needs changing... this is fine. companyName is now technically contract info
                            ++itemsUpdated;

                            itemsToUpdate.Add(wi);
                        }
                        else
                        {
                            ++itemsUpToDate;
                        }
                    }
                    else ++itemsWhereContractUnrecognized;
                }
                else ++itemsWithNoCertificate;
            }

            if (itemsToUpdate != null && itemsToUpdate.Count > 0) UpdateAllLoadedWorkflowItems(itemsToUpdate);
        }

        private void updateContractInformationBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UseWaitCursor = false;

            if (e.Cancelled == true)
            {
                SetStatusLabelAndTimer("Operation was canceled");
                MakeErrorSound();
            }
            else if (e.Error != null)
            {
                MessageBox.Show("Operation unsuccessful\n\ne.Error.Message", "Error");
                if (CheckIfFormIsOpened("Transparent Form")) this.TransparentForm.Close();
            }
            else
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        this.LoadingForm.CompleteProgress();
                        this.LoadingForm.ChangeLabel("Loading Complete");
                        this.LoadingForm.Refresh();
                        this.loadingFormTimer.Enabled = true;
                        this.SetStatusLabelAndTimer($"{itemsUpdated} contract(s) updated; {itemsUpToDate + itemsWhereContractUnrecognized + itemsWithNoCertificate} not updated - " +
                            $"{itemsUpToDate} already up to date, {itemsWhereContractUnrecognized} contract(s) unrecognized, {itemsWithNoCertificate} w/ no contract(s)", true);
                    }));
                }
                else
                {
                    this.LoadingForm.CompleteProgress();
                    this.LoadingForm.ChangeLabel("Loading Complete");
                    this.LoadingForm.Refresh();
                    this.loadingFormTimer.Enabled = true;
                    this.SetStatusLabelAndTimer($"{itemsUpdated} contract(s) updated; {itemsUpToDate + itemsWhereContractUnrecognized + itemsWithNoCertificate} not updated - " +
                        $"{itemsUpToDate} already up to date, {itemsWhereContractUnrecognized} contract(s) unrecognized - {itemsWithNoCertificate} w/ no contract(s)", true);
                }
            }
        }

        #endregion Find Data

        #region Loading Form Manipulation

        private void backgroundWorkerIncrementalProgress_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (LoadingForm != null)
            {
                LoadingForm.MoveBar(e.ProgressPercentage);
            }
        }

        private void backgroundWorkerAllProgress_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (LoadingForm != null)
            {
                LoadingForm.ReplaceBar(e.ProgressPercentage);
            }
        }

        private void loadingFormTimer_Tick(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
                this.Invoke(new Action(() => { this.TransparentForm.Close(); }));
            else
                this.TransparentForm.Close();

            loadingFormTimer.Enabled = false;
        }

        #endregion Loading Form Manipulation

        #endregion Long Process Tasks
        
        // ----- OTHER ----- //
        #region Other

        #region Mouse Hover Info

        private void detailTbx_MouseHover(object sender, EventArgs e)
        {
            try
            {
                if ((sender as TextBox).Tag != null) return;
                Size s = TextRenderer.MeasureText((sender as TextBox).Text, (sender as TextBox).Font);
                if (s.Width > (sender as TextBox).Width)
                {
                    tbxRemainsToolTip.SetToolTip((sender as TextBox), (sender as TextBox).Text);
                }
                else tbxRemainsToolTip.SetToolTip((sender as TextBox), string.Empty);
                (sender as TextBox).Tag = 0;
            }
            catch (Exception)
            {

            }
        }

        #endregion Mouse Hover Info

        #region SubForms

        public void NotificationBox(string content, string header)
        {
            // custom message box type notification
            // display a message on the main form with all other controls covered by a dim form
            DimForm();
            LoadingForm = new LoadingForm();

            LoadingForm.Owner = this.TransparentForm;
            if (this.TransparentForm.InvokeRequired)
            {
                this.TransparentForm.Invoke(new Action(() => { LoadingForm.Show(this.TransparentForm); }));
                this.TransparentForm.Invoke(new Action(() => { LoadingForm.Refresh(); }));
            }
            else
            {
                LoadingForm.Show(this.TransparentForm);
                LoadingForm.Refresh();
            }


            if (TransparentForm.InvokeRequired)
            {
                TransparentForm.Invoke(new Action(() => { LoadingForm.Show(TransparentForm); }));
            }
            else
            {
                LoadingForm.Show(TransparentForm);
            }

            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => { this.LoadingForm.ShowCloseBtn(); }));
                this.Invoke(new Action(() => { this.LoadingForm.HideBar(); }));
                this.Invoke(new Action(() => { this.LoadingForm.ChangeHeaderLabel(header); }));
                this.Invoke(new Action(() => { this.LoadingForm.ChangeLabel(content); }));
                this.Invoke(new Action(() => { LoadingForm.Refresh(); }));
            }
            else
            {
                this.LoadingForm.ShowCloseBtn();
                this.LoadingForm.HideBar();
                this.LoadingForm.ChangeHeaderLabel(header);
                this.LoadingForm.ChangeLabel(content);
                this.LoadingForm.Refresh();
            }
        }

        public void DialogBoxWithOptions(string content, string header, List<string> options)
        {
            //DimForm();
            //loadingForm = new LoadingForm();
            //loadingForm.Owner = this.transparentForm;
           
            //this.transparentForm.Invoke(new Action(() => 
            //{
            //    loadingForm.Show(this.transparentForm);
            //    loadingForm.Refresh();
            //}));

            //this.Invoke(new Action(() => 
            //{
            //    this.loadingForm.ShowCloseBtn();
            //    this.loadingForm.FormatForDialog()
            //    this.loadingForm.ChangeHeaderLabel(header);
            //    this.loadingForm.ChangeLabel(content);
            //    this.loadingForm.Refresh();
            //}));
        }

        private void DimForm()
        {
            TransparentForm = new Form();
            TransparentForm.ControlBox = false;
            TransparentForm.MinimizeBox = false;
            TransparentForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            TransparentForm.Text = "Transparent Form";
            TransparentForm.Name = "Transparent Form";
            TransparentForm.Size = this.Size;
            TransparentForm.BackColor = Color.Black;
            TransparentForm.Opacity = 0.3f;
            TransparentForm.ShowInTaskbar = false;
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => { TransparentForm.Show(this); }));
                this.Invoke(new Action(() => { TransparentForm.Location = this.Location; }));
            }
            else
            {
                TransparentForm.Show(this);
                TransparentForm.Location = this.Location;
            }
        }

        private void ShowAndFocusForm(Form form)
        {
            DimForm();

            // show form to be focused
            form.ShowDialog();

            // return form appearance to normal and focus the list view
            TransparentForm.Close();
            (Application.OpenForms[0] as WorkflowManager).Focus();
            (Application.OpenForms[0] as WorkflowManager).workflowItemsListView.Focus();

            if (Application.OpenForms["ItemsView"] != null)
            {
                Application.OpenForms["ItemsView"].Focus();
            }
        }

        private bool YesOrNoMsgBox(string message, string title)
        {
            DialogResult dialogResult = MessageBox.Show(message, title, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                return true;
            }
            else if (dialogResult == DialogResult.No)
            {
                return false;
            }
            else
            {
                return false;
            }
        }

        #endregion SubForms

        public bool CheckIfFormIsOpened(string name)
        {
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                if (frm.Name == name)
                {
                    return true;
                }
            }
            return false;
        }

        private void SetColorButtonsBackToDefault()
        {
            colorDialogBtn.Font = new Font("Microsoft Sans Serif", 6, FontStyle.Italic);
            colorDialogBtn.ForeColor = Color.FromName("Default");
            paintFromListViewBtn.Font = new Font("Microsoft Sans Serif", 6, FontStyle.Italic);
            paintFromListViewBtn.ForeColor = Color.FromName("Default");
            paintFromQueryBtn.Font = new Font("Microsoft Sans Serif", 6, FontStyle.Italic);
            paintFromQueryBtn.ForeColor = Color.FromName("Default");
        }

        public void MakeErrorSound()
        {
            System.Media.SystemSounds.Hand.Play();
        }

        private void SetDatabaseDetailsProperties()
        {
            displayingCountStatusLbl.Text = $"{workflowItemListPopulated.Count.ToString()}";
            checkedCountStatusLbl.Text = $"{workflowItemsListView.CheckedItems.Count.ToString()}";
            queriedCountStatusLbl.Text = $"{CountOfQueriedItems().ToString()}";
        }

        private void ItemsViewForm_SaveItemsColor(object sender, List<WorkflowItem> itemList)
        {
            List<WorkflowItem> updatedList = itemList;

            UpdateAllLoadedWorkflowItems(updatedList);
        }

        private void unignoreEvents_Tick(object sender, EventArgs e)
        {
            itemCheckedEventIgnored = false;
            selectedIndexChangedEventIgnored = false;

            unignoreEvents.Enabled = false;
        }

        #endregion Other
    }
}
