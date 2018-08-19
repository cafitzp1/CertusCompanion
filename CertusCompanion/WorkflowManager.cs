//WorkflowManager v4.3

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Reflection;
using System.Diagnostics;
using System.Configuration;

namespace CertusCompanion
{
    public partial class WorkflowManager : Form
    {
        // ----- WORKFLOW MANAGER DATA ----- //
        #region WorkflowManager Data
        //
        // Instances
        internal WorkflowItemDatabase WorkflowItemDatabase { get; set; }
        internal AppSave AppSave { get; set; }
        internal AppData AppData { get; set; }
        internal ItemImports ItemImportsList { get; set; }
        internal ItemsCompletedReports ItemsCompletedReportsList { get; set; }
        internal List<Import> AllItemImportsLoaded { get; set; }
        internal List<ItemsCompletedReport> AllItemsCompletedReportsLoaded { get; set; }
        internal CSVImport CurrentImport { get; set; }
        internal Filter CurrentFilter { get; set; }
        internal Import SelectedImport { get; set; }
        internal ItemsCompletedReport SelectedReport { get; set; }
        internal NoteForm NoteIns { get; set; }
        internal Form TransparentForm { get; set; }
        internal ItemsView ItemViewIns { get; set; }
        internal FiltersForm FiltersFormIns { get; set; }
        internal WorkflowItem SelectedWorkflowItem { get; set; }
        internal ListViewItem PreviousItem { get; set; }
        internal CertusBrowser CertusBrowser { get; set; }
        internal ThemeColors ThemeColors { get; set; }
        internal MyRenderer CustomRenderer { get; set; }
        internal LoadingForm LoadingForm { get; set; }
        internal ModifyForm ModifyForm { get; set; }
        internal ImportFromDatabaseForm ImportFromDBForm { get; set; }
        internal CSVImport CurrentWorkflowItemCSVImport { get; set; }
        internal ItemsCompletedReport CurrentCompletedReport { get; set; }
        internal DataSourceForm DataSourceFormIns { get; set; }
        //
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
        private List<DataSource> DataSources { get; set; }
        private List<string> ColorsDataSource { get; set; }
        private List<string> StatusesDataSource { get; set; }
        private List<Client> ClientsDataSource { get; set; }
        private List<Company> CompaniesSubSource { get; set; }
        private List<Certificate> CertificatesSubSource { get; set; }
        private List<Analyst> AnalystsSubSource { get; set; }
        private List<Contact> ContactsSubSource { get; set; }
        private List<CertificateLocation> CertificateLocationsSubSource { get; set; }
        private List<Location> LocationsSubSource { get; set; }
        private HashSet<string> SenderEmailsSubSource { get; set; }
        private List<string> excludedItems;
        private List<string> companiesWhichHadDifferentAnalysts;
        private List<string> CompanyNamesSubSource { get; set; }
        private List<string> CertificateNamesSubSource { get; set; }
        private List<string> AnalystNamesSubSource { get; set; }
        List<string> CurrentDetailTbxVals { get; set; }
        //
        // Dictionaries
        private Dictionary<string, Company> CompanyDictionary { get; set; }
        private Dictionary<string, string> CompanyNameDictionary { get; set; }
        private Dictionary<string, List<Contact>> CompanyContactDictionary { get; set; }
        private Dictionary<string, Color> ItemGroupsSortedColors { get; set; }
        private Dictionary<string, string> MarketAssignments { get; set; }
        private Dictionary<string, WorkflowItem> WorkflowItemDictionary { get; set; }
        private Dictionary<string, string> SystemUserIDsDictionary { get; set; }
        private Dictionary<string, Certificate> CertificateDictionary { get; set; }
        //
        // Objects
        private Color currentColor;
        private SolidBrush spaceDarkBrush;
        private SolidBrush spaceLightBrush;
        private SolidBrush spaceLightOffBrush;
        private SolidBrush highlightBrush;
        private Pen highlightPen;
        private Pen mainThemePen;
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
        private Image img = CertusCompanion.Properties.Resources.icons8_sort_down_24__8_;
        private Image img2 = CertusCompanion.Properties.Resources.icons8_sort_down_24__10_;
        private Image imgToUse;
        private AutoCompleteStringCollection searchTbxACS;
        //
        // Variables
        private string defaultClient;
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
        private string loadedWorkspacePath;
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
        private int connectionBtnStatus;
        private bool tabWasPressed;
        private bool checkedItemsAreFocused;
        private bool itemsCouldNotBeAppended;
        private bool contrastItemGroups = false;
        private bool showItemsMonotone = false;
        private bool itemDetailsChanged = false;
        private bool tabWasPressedOnSaveBtn;
        private bool enterWasPressedOnSaveBtn;
        private bool contextMenuOpened;
        private string loadedWorkspaceFileName;
        private string workspacePathToLoad;
        private string workspacePathToSave;
        private bool ignoreThisTextChange;

        public string SelectedClientID { get; set; }
        #endregion

        // ----- APPLICATION STARTUP ----- //
        #region Application Startup
        internal WorkflowManager()
        {
            InitializeComponent();

            InstantiateWorkflowManagerData();
            LoadForm();
            InstantiateDataSources();
            PopulateMainFormStatic();

            #if !DEBUG
                //TestDBConnection();
            #endif
        }
        private void InstantiateWorkflowManagerData()
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
            SenderEmailsSubSource = new HashSet<string>();
            AllItemImportsLoaded = new List<Import>();
            AllItemsCompletedReportsLoaded = new List<ItemsCompletedReport>();
            CurrentWorkflowItems = new List<WorkflowItem>();
            TemporaryExportList = new List<WorkflowItem>();
            SearchResultsList = new List<WorkflowItem>();
            WorkflowItemDictionary = new Dictionary<string, WorkflowItem>();
            ThemeColors = new ThemeColors();
            spaceDarkBrush = new SolidBrush(ThemeColors.SpaceDark);
            spaceLightBrush = new SolidBrush(ThemeColors.SpaceLight);
            spaceLightOffBrush = new SolidBrush(ThemeColors.SpaceLightOff);
            highlightBrush = new SolidBrush(Color.FromKnownColor(KnownColor.Highlight));
            highlightPen = new Pen(Color.FromKnownColor(KnownColor.Highlight));
            mainThemePen = new Pen(ThemeColors.MainTheme);
            imgToUse = img;
            connectionBtnStatus = 1;

            workflowItemsListView.ForeColor = ThemeColors.ItemDefault;
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
        }
        private void LoadForm()
        {
            // enable controls
            fullViewBtn.Enabled = true;
            enlargeBtn.Enabled = true;

            // move/resize
            detailNotificationPanelTop = detailNotificationsPanel.Top;
            detailNotificationPanelLeft = detailNotificationsPanel.Left;

            // invoke a resize for the column header alignment
            this.WorkflowManager_Resize(this, null);

            // set starting color for paint button texts / tool tips
            buttonDescToolTip.SetToolTip(paintBtn, $"Paint ({paintColorDialog.Color.Name})");
            buttonDescToolTip.SetToolTip(paintFromQueryBtn, $"Paint ({paintColorDialog.Color.Name})");
            paintContextMenuItem.Text = $"Paint ({paintColorDialog.Color.Name})";

            // change context menu renderers
            CustomRenderer = new MyRenderer();
            this.listViewContextMenuStrip.Renderer = CustomRenderer;
            this.formMenuStrip.Renderer = CustomRenderer;
            this.qfndCustomDDLMenuStrip.Renderer = CustomRenderer;
            this.vcCustomDDLMenuStrip.Renderer = CustomRenderer;
            this.clCustomDDLMenuStrip.Renderer = CustomRenderer;

            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            this.Text = "Workflow Manager v" + fvi.FileVersion;
        }
        private void LoadMarketAssignments()
        {
            MarketAssignments = new Dictionary<string, string>();
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
                        MarketAssignments.Add(market, name);
                        continue;
                    }
                }
            }
            catch (Exception)
            {
                SetStatusLabelAndTimer("Error loading Market Assignments");
            }
        }
        private void InstantiateDataSources()
        {
            DataSources = new List<DataSource>();
            ColorsDataSource = new List<string>();
            StatusesDataSource = new List<string>();
            ClientsDataSource = new List<Client>();
            CompaniesSubSource = new List<Company>();
            CertificatesSubSource = new List<Certificate>();
            AnalystsSubSource = new List<Analyst>();
            ContactsSubSource = new List<Contact>();
            CertificateLocationsSubSource = new List<CertificateLocation>();
            LocationsSubSource = new List<Location>();
            MarketAssignments = new Dictionary<string, string>();
            DataSource ds = new DataSource();

            // hardcode
            #region HardCode DataSources
            // --- COLORS --- //
            ds = new DataSource("ALL", "Colors", true);
            ds.Items.Add("Default");
            ds.Items.Add("Teal");
            ds.Items.Add("Blue");
            ds.Items.Add("Navy");
            ds.Items.Add("Aqua");
            ds.Items.Add("Green");
            ds.Items.Add("Lime");
            ds.Items.Add("Yellow");
            ds.Items.Add("Purple");
            ds.Items.Add("Red");
            ds.Items.Add("Gray");
            ds.Items.Add("Silver");
            ds.Items.Add("SpringGreen");
            ds.Items.Add("Black");
            DataSources.Add(ds);

            ColorsDataSource.Add("Default");
            ColorsDataSource.Add("Teal");
            ColorsDataSource.Add("Blue");
            ColorsDataSource.Add("Navy");
            ColorsDataSource.Add("Aqua");
            ColorsDataSource.Add("Green");
            ColorsDataSource.Add("Lime");
            ColorsDataSource.Add("Yellow");
            ColorsDataSource.Add("Purple");
            ColorsDataSource.Add("Red");
            ColorsDataSource.Add("Gray");
            ColorsDataSource.Add("Silver");
            ColorsDataSource.Add("SpringGreen");
            ColorsDataSource.Add("Black");

            // --- STATUSES --- //
            ds = new DataSource("ALL", "Statuses", true);
            ds.Items.Add("Email Received");
            ds.Items.Add("Documentation Analyst");
            ds.Items.Add("Compliance Analyst");
            ds.Items.Add("Completed");
            ds.Items.Add("Trash");
            DataSources.Add(ds);

            StatusesDataSource.Add("Email Received");
            StatusesDataSource.Add("Documentation Analyst");
            StatusesDataSource.Add("Compliance Analyst");
            StatusesDataSource.Add("Completed");
            StatusesDataSource.Add("Trash");
            #endregion

            #region Old code (reading datasources from .txt - now generated fron DB conn)
            /*
            // get datasources from txt
            #region Pull DataSources
            string itemType = "";
            List<object> itemsToAdd = new List<object>();
            Client cl = new Client();
            Company co = new Company();
            Certificate ct = new Certificate();
            Analyst anl = new Analyst();

            using (Stream strm = Assembly.GetExecutingAssembly().GetManifestResourceStream("CertusCompanion.Configuration.StaticDataSources.txt"))
            {
                using (StreamReader sr = new StreamReader(strm))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        // if line is blank continue
                        if (line == String.Empty) continue;

                        // if line is # file is done
                        if (line.StartsWith("#"))
                        {
                            if (itemsToAdd != null && itemsToAdd.Count != 0)
                            {
                                ds.Items = itemsToAdd;
                                DataSources.Add(ds);
                                return;
                            }
                        }

                        // if line starts with '<<' it is not an item
                        if (line.StartsWith("<<"))
                        {
                            // save list to DS (will skip the first time)
                            if (itemsToAdd != null && itemsToAdd.Count != 0)
                            {
                                ds.Items = itemsToAdd;
                                DataSources.Add(ds);
                            }

                            itemsToAdd = new List<object>();

                            switch (line.Substring(2, line.IndexOf('>') - 2))
                            {
                                case "CLIENTS":
                                    {
                                        ds = new DataSource("ALL", "Clients", true);
                                        itemType = "client";
                                    }
                                    break;
                                case "COMPANIES":
                                    {
                                        ds = new DataSource("ALL", "Companies");
                                        itemType = "company";
                                    }
                                    break;
                                case "CERTIFICATES":
                                    {
                                        ds = new DataSource("ALL", "Certificates");
                                        itemType = "certificate";
                                    }
                                    break;
                                case "ANALYSTS":
                                    {
                                        ds = new DataSource("ALL", "Analysts");
                                        itemType = "analyst";
                                    }
                                    break;
                                case "MARKET ASSIGNMENTS":
                                    {
                                        ds = new DataSource("", "Market Assignments", true); // needs to be changed
                                        itemType = "market assignment";
                                    }
                                    break;
                            }

                            continue;
                        }

                        // return fields in a string array split by commas (not including those which are within quotations)
                        string[] result = Regex.Split(line, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");

                        // remove paranthesis if comma is in value
                        for (int i = 0; i < result.Length; i++)
                        {
                            if (result[i].Contains(',') == true)
                            {
                                result[i] = result[i].Remove(0, 1);
                                result[i] = result[i].Remove(result[i].Length - 1, 1);
                            }
                        }

                        // save items
                        switch (itemType)
                        {
                            case "client":
                                {
                                    // add to DS list
                                    cl = new Client(result[0], result[1]);
                                    ClientsDataSource.Add(cl);
                                    itemsToAdd.Add(cl);
                                }
                                break;
                            case "company":
                                {
                                    co = new Company(result[2], result[0], result[1]);
                                    CompaniesDataSource.Add(co);
                                    itemsToAdd.Add(co);
                                }
                                break;
                            case "certificate":
                                {
                                    ct = new Certificate(result[0], result[3], result[2], result[1]);
                                    CertificatesDataSource.Add(ct);
                                    itemsToAdd.Add(ct);
                                }
                                break;
                            case "analyst":
                                {
                                    anl = new Analyst(result[0], result[1], result[2]);
                                    AnalystsDataSource.Add(anl);
                                    itemsToAdd.Add(anl);
                                }
                                break;
                            case "market assignment":
                                {
                                    MarketAssignments.Add(result[0], result[1]);
                                    itemsToAdd.Add($"{result[1]} <{result[0]}>");
                                }
                                break;
                        }
                    }
                }
            }
            */
            #endregion
        }
        private void PopulateMainFormStatic()
        {
            DataSource ds = new DataSource();

            // --- CLIENT COMBOBOX --- //
            clCustomDDLMenuStrip.Items.Clear();

            if (DataSources == null || DataSources.Count <= 2) return;
            ds = DataSources.Where(d => d.Name == "ALL" && d.Type == "Clients").FirstOrDefault() as DataSource;

            if (this.InvokeRequired) this.Invoke(new Action(() =>
            {
                foreach (var item in ds.Items)
                {
                    clCustomDDLMenuStrip.Items.Add(item.ToString());
                    clCustomDDLMenuStrip.Items[clCustomDDLMenuStrip.Items.Count - 1].ForeColor = Color.FromKnownColor(KnownColor.Control);
                }

                clCustomDDLMenuStrip.AutoSize = false;
                clCustomDDLMenuStrip.Size = new Size(330, 330);
                if (this.InvokeRequired) this.Invoke(new Action(() => { clSelectionBtn.Text = "Select one..."; }));
                else clSelectionBtn.Text = "Select one...";
            }));
            else
            {
                foreach (var item in ds.Items)
                {
                    clCustomDDLMenuStrip.Items.Add(item.ToString());
                    clCustomDDLMenuStrip.Items[clCustomDDLMenuStrip.Items.Count - 1].ForeColor = Color.FromKnownColor(KnownColor.Control);
                }

                clCustomDDLMenuStrip.AutoSize = false;
                clCustomDDLMenuStrip.Size = new Size(330, 330);
                if (this.InvokeRequired) this.Invoke(new Action(() => { clSelectionBtn.Text = "Select one..."; }));
                else clSelectionBtn.Text = "Select one...";
            }
        }
        private void PopulateMainFormDynamic()
        {
            // --- COMPANIES TBX --- //
            AutoCompleteStringCollection companiesACS = new AutoCompleteStringCollection();

            foreach (Company o in CompaniesSubSource)
            {
                companiesACS.Add(o.CompanyName);
            }

            companyNameTbx.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            companyNameTbx.AutoCompleteCustomSource = companiesACS;
            companyNameTbx.AutoCompleteSource = AutoCompleteSource.CustomSource;

            // --- CERTIFICATES TBX --- //
            AutoCompleteStringCollection certificatesACS = new AutoCompleteStringCollection();

            foreach (Certificate o in CertificatesSubSource)
            {
                certificatesACS.Add(o.CertificateName);
            }

            contractIdTbx.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            contractIdTbx.AutoCompleteCustomSource = certificatesACS;
            contractIdTbx.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
        public void EnableOptionsPanels()
        {
            listViewOptionsPanel.Enabled = true;
            detailsOptionsPanel.Enabled = true;
        }
        private void TestDBConnection()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["CertusDB"].ToString();
                string query;

                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand command = conn.CreateCommand();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    
                }
            }
            catch (Exception)
            {
                MessageBox.Show("You currently have no database connection. You will not be able to perform any database imports without a connection.", "Warning");
            }
        }
        #endregion

        // ----- TOOL STRIP MENU ----- //
        #region Tool Strip Menu 
        //
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
                    loadBackgroundWorker.RunWorkerAsync(openFileDialog.FileName);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Could not process the request", "Error");
                return;
            }
        }
        private void clearWorkspaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LoadForm();
        }
        private void saveWorkspaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loadedWorkspacePath != null && loadedWorkspacePath != String.Empty)
            {
                try
                {
                    UseWaitCursor = true;
                    saveBackgroundWorker.RunWorkerAsync(loadedWorkspacePath);
                }
                catch (Exception)
                {
                    SetStatusLabelAndTimer("Could not process that request");
                    MakeErrorSound();
                    return;
                }
            }
            else saveAsToolStripMenuItem_Click(sender, e);
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
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //
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
        //
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

            ItemViewIns = new ItemsView();

            // change for excluded items
            ItemViewIns.FormatForExcludedItemsView();

            // register event
            ItemViewIns.ChangeItemsColor += new ItemsColorUpdatedEventHandler(ItemsViewForm_SaveItemsColor);

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
            ItemViewIns.PopulateItems(workflowItemListPopulated, excludedItems);

            ShowAndFocusForm(ItemViewIns);

            Cursor.Current = Cursors.Default;
        }
        private void itemsViewBtn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                ItemViewIns = new ItemsView();

                // register event
                ItemViewIns.SaveItemsCompletedReportToFullForm += new ItemsStatusChangedEventHandler(ItemsViewForm_SaveCompletedReport);

                // pass items viewing
                ItemViewIns.PopulateItems(workflowItemListPopulated);

                ShowAndFocusForm(ItemViewIns);
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

            ItemViewIns = new ItemsView();

            ItemViewIns.FormatForCertificatesView();

            // pass items to view
            ItemViewIns.PopulateCertificates(AllCertificatesLoaded);

            ShowAndFocusForm(ItemViewIns);

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

            ItemViewIns = new ItemsView();

            ItemViewIns.FormatForCompaniesView();

            // pass items to view
            ItemViewIns.PopulateCompanies(AllCompaniesLoaded);


            ShowAndFocusForm(ItemViewIns);

            Cursor.Current = Cursors.Default;
        }
        //
        // Tools
        private void certusBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (workflowItemsListView.CheckedItems == null || workflowItemsListView.CheckedItems.Count == 0) this.CertusBrowser = new CertusBrowser(SelectedClientID, CompaniesSubSource, CertificatesSubSource);
            else
            {
                this.Invoke(new Action(() => { SetStatusLabelAndTimer($"Opening certus browser with {workflowItemsListView.CheckedItems.Count} items..."); }));
                Application.UseWaitCursor = true;
                Application.DoEvents();

                // get checked items and see if they all have IDs or not
                bool itemsMissingID = false;
                List<WorkflowItem> checkedItems = GetWorkflowItemsFromChecked(workflowItemsListView);
                foreach (WorkflowItem item in checkedItems)
                {
                    if (item.AssignedToID == null || item.AssignedToID == "0" || !Char.IsDigit(item.AssignedToID[0]))
                    {
                        itemsMissingID = true;
                    }
                }
                if (itemsMissingID)
                {
                    DialogResult dr = MessageBox.Show
                    (
                        "One or more items selected do not have assigned IDs. IDs will be missing if there is no analyst assigned or if " +
                        "analyst information was manually modified and there was no successful DB connection while doing so. " +
                        "You will not be able to distribute items without assigned IDs for each item. Continue anyway? ",
                        "Warning", MessageBoxButtons.YesNo
                    );
                    if (dr == DialogResult.No)
                    {
                        MessageBox.Show
                        (
                            "IDs can be tied to the items a few different ways. You can connect to the DB then go to Data > Tie User IDs " +
                            "and all items which have valid analyst names will receive their corresponding IDs. You can also fill in the " +
                            "assigned ID manually for each item by switching the 'Assigned To' data view label to 'Assigned ID', entering " +
                            "the ID in textbox, and then pressing save. "
                        );
                        Application.UseWaitCursor = false;
                        Application.DoEvents();
                        ResetStatusStrip();
                        return;
                    }
                }

                this.CertusBrowser = new CertusBrowser(SelectedClientID, checkedItems, CompaniesSubSource, CertificatesSubSource);
                this.certusBrowserToolStripMenuItem.Enabled = false;
            }
            this.CertusBrowser.Show();
            Application.UseWaitCursor = false;
            Application.DoEvents();
        }
        private void certusConnectionBtn_Click(object sender, EventArgs e)
        {
            Application.UseWaitCursor = true;
            Application.DoEvents();

            switch (connectionBtnStatus)
            {
                case 1:
                    if (connectToDBBackgroundWorker.IsBusy)
                    {
                        MessageBox.Show("Process is still running. Wait a few moments before trying again.");
                        break;
                    }
                    else connectToDBBackgroundWorker.RunWorkerAsync();
                    break;
                case 2:
                    MessageBox.Show("Select a client from the client drop down list");
                    break;
                case 3:
                    DialogResult dr = MessageBox.Show("Reset datasources?", "", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        // remove sources
                        while (DataSources.Count > 2)
                        {
                            DataSources.RemoveAt(2);
                        }

                        // reset client ddl items
                        clCustomDDLMenuStrip.Items.Clear();
                        clSelectionBtn.Text = String.Empty;

                        ConnectionBtnNoConnection();
                    }
                    break;
                case 4:
                    MessageBox.Show("Select/reselect a client from the drop down list to update client data");
                    break;
            }

            Application.UseWaitCursor = false;
            Application.DoEvents();
        }
        public void ConnectionBtnIncomplete()
        {
            certusConnectionBtn.BackgroundImage = CertusCompanion.Properties.Resources.icons8_connection_status_on_48_2;
            buttonDescToolTip.SetToolTip(certusConnectionBtn, $"Clients have been successfully imported. Select a client to complete the import process.");
            connectionBtnStatus = 2;
        }
        public void ConnectionBtnGood()
        {
            certusConnectionBtn.BackgroundImage = CertusCompanion.Properties.Resources.icons8_connection_status_on_48;
            buttonDescToolTip.SetToolTip(certusConnectionBtn,
                $"Data successfully imported from CertusDB. Clients imported: {DataSources[2].DateCreated.ToShortDateString()}. Client information imported: {DataSources[3].DateCreated.ToShortDateString()}");
            connectionBtnStatus = 3;
        }
        public void ConnectionBtnOutdated()
        {
            certusConnectionBtn.BackgroundImage = CertusCompanion.Properties.Resources.icons8_connection_status_on_48_3;
            buttonDescToolTip.SetToolTip(certusConnectionBtn,
                $"Client information last updated over a week ago");
            connectionBtnStatus = 4;
        }
        public void ConnectionBtnNoConnection()
        {
            certusConnectionBtn.BackgroundImage = CertusCompanion.Properties.Resources.icons8_connection_status_on_48__1_;
            buttonDescToolTip.SetToolTip(certusConnectionBtn, "Import Data Sources from CertusDB");
            connectionBtnStatus = 1;
        }
        //
        // Data
        private void dataSourcesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // generate form
            #region Generate Form
            DimForm();

            if (DataSources != null && DataSources.Count != 0) DataSourceFormIns = new DataSourceForm(DataSources);
            else DataSourceFormIns = new DataSourceForm();

            DialogResult result = DataSourceFormIns.ShowDialog();

            // return form appearance to normal
            if (CheckIfFormIsOpened("Transparent Form")) TransparentForm.Close();
            this.Focus();

            #endregion
        }
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
        private void updatRelatedFilesDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.AllWorkflowItemsLoaded == null || this.AllWorkflowItemsLoaded.Count == 0)
                return;

            updateRelatedFilesDataBackgroundWorker.RunWorkerAsync();
        }
        private void updateContractDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CertificateDictionary == null || CertificateDictionary.Count == 0)
            {
                SetStatusLabelAndTimer("Certificates need to be imported for this function");
                MakeErrorSound();
                return;
            }

            UseWaitCursor = true;

            updateContractInformationBackgroundWorker.RunWorkerAsync(AllWorkflowItemsLoaded);
        }
        private void tieUserIDsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.AllWorkflowItemsLoaded == null || this.AllWorkflowItemsLoaded.Count == 0)
                return;

            Application.UseWaitCursor = true;
            Application.DoEvents();

            int idsAssigned = 0;
            int usersToAssignTo = 0;
            string assignee = String.Empty;

            try
            {
                if (AnalystsSubSource == null || AnalystsSubSource.Count == 0)
                {
                    throw new Exception("No analyst datasource is available");
                }
                foreach (WorkflowItem item in AllWorkflowItemsLoaded)
                {
                    // if there is a name in the assigned to field
                    if (item.AssignedToName != String.Empty && item.AssignedToName != null)
                    {
                        assignee = item.AssignedToName;

                        if (item.AssignedToName == "(Unassigned)" || item.AssignedToName == "Richard Ellis") continue;

                        ++usersToAssignTo;

                        // if the user isn't in the datasource then their name must be spelled differently
                        if (!AnalystsSubSource.Any(i => i.Name == item.AssignedToName)) continue;

                        string idToAssign = (AnalystsSubSource.Where(i => i.Name == item.AssignedToName).FirstOrDefault() as Analyst).SystemUserID;

                        // if the user id isn't there
                        if (item.AssignedToID == String.Empty || item.AssignedToID == null)
                        {
                            // assign
                            item.AssignedToID = idToAssign;
                            ++idsAssigned;
                        }
                        else // id is there
                        {
                            // if idToAssign is not the id already there
                            if (item.AssignedToID != idToAssign)
                            {
                                // assign
                                item.AssignedToID = idToAssign;
                                ++idsAssigned;
                            }
                            else continue;
                        }
                    }
                }
            }
            catch (Exception m)
            {
                MessageBox.Show("Could not process the request. \n\nReason: " + m.Message, "Error");
                ResetStatusStrip();
            }

            if (idsAssigned == 0) SetStatusLabelAndTimer($"IDs tied for 0 items", true);
            else SetStatusLabelAndTimer($"{idsAssigned} id(s) successfully assigned for {usersToAssignTo} user(s)", true);
            Application.UseWaitCursor = false;
            Application.DoEvents();
        }
        //
        // Window
        private void minimizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void maximizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
        #endregion

        // ----- SEARCH FUNCTIONALITY ----- //
        #region Search Functionality
        private void searchTbx_Enter(object sender, EventArgs e)
        {
            searchTbx_MouseHover(sender, e);
            searchTbx.MouseLeave -= searchTbx_MouseLeave;

            if (searchTbx.Text == "Search Items (Ctrl+F)") searchTbx.Text = String.Empty;
        }
        private void searchTbx_MouseHover(object sender, EventArgs e)
        {
            searchTbxActiveBorder.BackColor = Color.FromKnownColor(KnownColor.Highlight);
            searchTbxInactiveBorder.BackColor = Color.FromArgb(40, 40, 40);
            searchTbx.BackColor = Color.FromArgb(40, 40, 40);
            searchTbx.ForeColor = Color.FromKnownColor(KnownColor.ButtonHighlight);
        }
        private void searchTbx_MouseLeave(object sender, EventArgs e)
        {
            searchTbxActiveBorder.BackColor = Color.FromKnownColor(KnownColor.WindowFrame);
            searchTbx.ForeColor = Color.FromKnownColor(KnownColor.Gray);
            searchTbxInactiveBorder.BackColor = Color.FromArgb(27, 27, 27);
            searchTbx.BackColor = Color.FromArgb(27, 27, 27);
            searchTbxActiveBorder.Refresh();
        }
        private void searchTbx_MouseMove(object sender, MouseEventArgs e)
        {
            searchTbx_MouseHover(sender, e);
        }
        private void searchTbx_TextChanged(object sender, EventArgs e)
        {
            // reset starting index for the search function
            searchIndex = 0;

            // set the tbx to the search value and save prev search
            previousSearch = searchVal;
            searchVal = searchTbx.Text;

            if (searchVal != String.Empty && searchVal != "Search Items (Ctrl+F)")
            {
                // update status label
                this.SetStatusLabelAndTimer($"Find \"{searchTbx.Text}\"", true, true);
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
                            this.SetStatusLabelAndTimer($"Find \"{searchTbx.Text}\"", true, true);

                            e.Handled = true;
                            e.SuppressKeyPress = true;
                        }
                        else
                        {
                            if (searchIndex > 0)
                            {
                                FocusItemInListView(searchIndex - 1);
                                SetStatusLabelAndTimer("Reached the starting point of the seach.");
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
        private void searchTbx_Leave(object sender, EventArgs e)
        {
            searchTbx.MouseLeave += searchTbx_MouseLeave;
            searchTbx_MouseLeave(sender, e);

            if (searchTbx.Text == String.Empty) searchTbx.Text = "Search Items (Ctrl+F)";
        }
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
        #endregion

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
        #endregion

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
        private void addReferenceBtn_Click(object sender, EventArgs e)
        {
            // return if no checked items
            if (workflowItemsListView.CheckedItems == null || workflowItemsListView.CheckedItems.Count == 0)
            {
                SetStatusLabelAndTimer("Items need to be checked for that", 5000);
                MakeErrorSound();
                return;
            }

            Cursor.Current = Cursors.WaitCursor;

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

            if (wi.DisplayColor == "Default") itemButtons[nextAvailableButton].ForeColor = ThemeColors.ItemDefault;
            else itemButtons[nextAvailableButton].ForeColor = Color.FromName(wi.DisplayColor);

            // count index up until it hits the max
            if (nextAvailableButton < 10)
            {
                ++nextAvailableButton;
            }
        }
        private void removePaintBtn_Click(object sender, EventArgs e)
        {
            // return if no checked items
            if (workflowItemsListView.CheckedItems == null || workflowItemsListView.CheckedItems.Count == 0)
            {
                SetStatusLabelAndTimer("Items need to be checked for that", 5000);
                MakeErrorSound();
                return;
            }

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
            // return if no checked items
            if (workflowItemsListView.CheckedItems == null || workflowItemsListView.CheckedItems.Count == 0)
            {
                SetStatusLabelAndTimer("Items need to be checked for that", 5000);
                MakeErrorSound();
                return;
            }

            Cursor.Current = Cursors.WaitCursor;

            int itemsPainted = 0;
            List<WorkflowItem> itemsToPaint = new List<WorkflowItem>();

            this.workflowItemsListView.BeginUpdate();

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
                MessageBox.Show("Item(s) could not be upddated.");
                MakeErrorSound();
            }

            this.workflowItemsListView.EndUpdate();

            SetStatusLabelAndTimer($"{itemsPainted} item(s) painted");

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
                paintBtn.ForeColor = colorDialogSelection;
                paintFromQueryBtn.ForeColor = colorDialogSelection;
            }

            // now change the tooltips and texts to the new color selected
            buttonDescToolTip.SetToolTip(paintBtn, $"Paint ({paintColorDialog.Color.Name})");
            buttonDescToolTip.SetToolTip(paintFromQueryBtn, $"Paint ({paintColorDialog.Color.Name})");
            paintContextMenuItem.Text = $"Paint ({paintColorDialog.Color.Name})";

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
        private void AddItemsToAllWorkflowItemsLoaded(string fileName, List<WorkflowItem> currentImportItems, int valueToIncrementByIfLoading = 1)
        {
            // for reporting loading progress
            int valueToIncrement = 0;
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
            HashSet<string> existingIDs = new HashSet<string>();
            var workflowItemQuery = AllWorkflowItemsLoaded.Select(i => i.DocumentWorkflowItemID).Distinct().ToList();
            foreach (string id in workflowItemQuery)
            {
                existingIDs.Add(id);
            }

            // check before adding
            if (AllWorkflowItemsLoaded != null && AllWorkflowItemsLoaded.Count > 0)
            {
                foreach (WorkflowItem importItem in currentImportItems)
                {
                    // if the id doesn't exist in the db items
                    if (!existingIDs.Contains(importItem.DocumentWorkflowItemID))
                    {
                        AllWorkflowItemsLoaded.Add(importItem);
                        existingIDs.Add(importItem.DocumentWorkflowItemID);
                        if (AllItemImportsLoaded != null && AllItemImportsLoaded.Count != 0) AllItemImportsLoaded[AllItemImportsLoaded.Count - 1].ItemsAdded.Add(importItem.DocumentWorkflowItemID);
                    }
                    else
                    {
                        WorkflowItem existingItem = (AllWorkflowItemsLoaded.First(i => i.DocumentWorkflowItemID == importItem.DocumentWorkflowItemID)) as WorkflowItem;
                        int indx = AllWorkflowItemsLoaded.IndexOf(existingItem);

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
                        else // add as normal (still update critical information)
                        {
                            string newStatus = importItem.Status;
                            string newAssignment = importItem.AssignedToName;
                            WorkflowItem wi = new WorkflowItem();
                            string oldStatus = existingItem.Status;
                            string oldAssignment = existingItem.AssignedToName;

                            // if status or assignment changed
                            if (!CheckIfItemStatusOrAssignedChanged(existingItem, importItem))
                            {
                                wi = existingItem;
                                wi.WorkflowAnalyst = importItem.WorkflowAnalyst;
                                wi.CompanyAnalyst = importItem.CompanyAnalyst;
                                wi.Status = importItem.Status;
                                wi.AssignedToName = importItem.AssignedToName;
                                wi.WorkflowItemInformationDifferentThanCertus = false;

                                // if an item is yellow after the import, it means the item was never changed on certus even though it was colored as changed and should have been
                                // the item wf information is now back to reflecting certus
                                wi.DisplayColor = "Yellow";

                                wi.Note += $"<{oldStatus} : {oldAssignment}" +
                                    $" -> {newStatus} : {newAssignment} via '{fileName}'> ";

                                AllWorkflowItemsLoaded[indx] = wi;
                                if (AllItemImportsLoaded != null && AllItemImportsLoaded.Count != 0) AllItemImportsLoaded[AllItemImportsLoaded.Count - 1].ItemsUpdated.Add(importItem.DocumentWorkflowItemID);
                            }
                            else // item status/assignment did not change
                            {
                                wi = existingItem;
                                wi.WorkflowItemInformationDifferentThanCertus = false;

                                AllWorkflowItemsLoaded[indx] = wi;
                            }
                        }
                    }
                }

                // complete and paint items gray if they're not on the current import
                foreach (WorkflowItem item in currentImportItems)
                {
                    // if the item isn't on the import list, that means it was completed or trashed. importItems only included non-completed or trashed items
                    if (!currentImportItems.Exists(i => i.DocumentWorkflowItemID == item.DocumentWorkflowItemID))
                    {
                        if (item.Status != "Completed/Trash" && item.Status != "Completed" && item.Status != "Trash")
                        {
                            item.Status = "Completed/Trash";
                            item.Note += $"<completed via clean-up from '{fileName}'> ";
                        }

                        // by default, these items should show the completed color which is gray. don't remove black
                        if (item.DisplayColor != "Black" && item.DisplayColor != "Gray")
                            item.DisplayColor = "Gray";
                    }
                }
            }
            else // this is the first import
            {
                AllWorkflowItemsLoaded = currentImportItems;
                if (AllItemImportsLoaded != null && AllItemImportsLoaded.Count != 0) AllItemImportsLoaded[AllItemImportsLoaded.Count - 1].ItemsAdded.AddRange(currentImportItems.Select(i => i.DocumentWorkflowItemID).ToList());
            }


            // sort list by ID (case if older items get added after newer items)
            AllWorkflowItemsLoaded = AllWorkflowItemsLoaded.OrderBy(i => i.DocumentWorkflowItemID).ToList();

            // add emails to hashset
            var query = AllWorkflowItemsLoaded.Select(i => i.EmailFromAddress).Distinct().ToList();

            foreach (var item in query)
            {
                SenderEmailsSubSource.Add(item.ToString());
            }
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
        private bool CheckIfItemStatusOrAssignedChanged(WorkflowItem currentItemInDB, WorkflowItem importItem)
        {
            // if this data is different, return false
            if (currentItemInDB.AssignedToName != importItem.AssignedToName || currentItemInDB.Status != importItem.Status)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void importFromDatabaseBtn_Click(object sender, EventArgs e)
        {
            #region Generate Form

            if(importFromDBBackGroundWorker.IsBusy)
            {
                MessageBox.Show("Process is still running. Wait a few moments before trying again.");
                return;
            }

            UseWaitCursor = true;

            // construct forms
            DimForm();
            string client = clSelectionBtn.Text;
            if( client!=null && client != String.Empty && client != "Select one...") ImportFromDBForm = new ImportFromDatabaseForm(ClientsDataSource, client);
            else ImportFromDBForm = new ImportFromDatabaseForm(ClientsDataSource);

            UseWaitCursor = false;

            // show as dialog
            DialogResult result = ImportFromDBForm.ShowDialog();

            // return form appearance to normal
            if (CheckIfFormIsOpened("Transparent Form")) TransparentForm.Close();
            this.Focus();

            #endregion

            if (result == DialogResult.OK)
            {
                DisableWFDataOptions();
                importFromDatabaseBtn.Enabled = true;

                importFromDBBackGroundWorker.RunWorkerAsync(result);
            }
            else if (result == DialogResult.Abort)
            {
                MessageBox.Show("Something went wrong while setting up the import", "Error");
            }
        }
        private void vcCustomDDLSelectionBtn_TextChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            switch (vcSelectionBtn.Text)
            {
                case "All Workflow":
                    //if (workflowItemListPopulated == null || workflowItemListPopulated != this.AllWorkflowItemsLoaded)
                    {
                        if (this.AllWorkflowItemsLoaded == null || this.AllWorkflowItemsLoaded.Count == 0)
                        {
                            SetStatusLabelAndTimer("No items in that list", 5000);
                            MakeErrorSound();
                            vcSelectionBtn.Text = String.Empty;
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
                            vcSelectionBtn.Text = String.Empty;
                        }
                    }
                    break;
                case "Non-completed":
                    {
                        if (this.CurrentWorkflowItems == null || this.CurrentWorkflowItems.Count == 0)
                        {
                            SetStatusLabelAndTimer("No items in that list", 5000);
                            MakeErrorSound();
                            vcSelectionBtn.Text = String.Empty;
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
                            vcSelectionBtn.Text = String.Empty;
                        }
                    }
                    break;
                case "Export":
                    {
                        if (TemporaryExportList == null || TemporaryExportList.Count == 0)
                        {
                            SetStatusLabelAndTimer("No items in that list", 5000);
                            MakeErrorSound();
                            vcSelectionBtn.Text = String.Empty;
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
                            vcSelectionBtn.Text = String.Empty;
                        }
                    }
                    break;
                case "Search Results":
                    {

                        // add items to a results list
                        SearchResultsList.Clear();

                        if (searchTbx.Text == String.Empty)
                        {
                            SetStatusLabelAndTimer("You need something to search first");
                            MakeErrorSound();
                            vcSelectionBtn.Text = String.Empty;
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
                                if (searchVal == null || searchVal == String.Empty)
                                {
                                    SetStatusLabelAndTimer("You must search for something first");
                                    MakeErrorSound();
                                    return;
                                }

                                foreach (ListViewItem.ListViewSubItem subItem in workflowItemsListView.Items[i].SubItems)
                                {
                                    if (subItem != null && subItem.Text != String.Empty && subItem.Text.ToLower().Contains(searchVal.ToLower()))
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
                            vcSelectionBtn.Text = String.Empty;
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
                            vcSelectionBtn.Text = String.Empty;
                        }
                    }

                    break;
                case "Queried":
                    {
                        if (queriedItemList == null || queriedItemList.Count == 0)
                        {
                            SetStatusLabelAndTimer("No items in that list", 5000);
                            MakeErrorSound();
                            vcSelectionBtn.Text = String.Empty;
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
                            vcSelectionBtn.Text = String.Empty;
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

            switch (vcSelectionBtn.Text)
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
                switch (vcSelectionBtn.Text)
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

            // if there's currently a Filter Options, close it
            if (CheckIfFormIsOpened("Filter Options"))
            {
                FiltersFormIns.Close();
            }

            // if currently there is a filter
            if (CurrentFilter != null)
            {
                FiltersFormIns = new FiltersForm(CurrentFilter, ColorsDataSource, AnalystsSubSource, StatusesDataSource, CompaniesSubSource, ContactsSubSource);
                FiltersFormIns.PopulateCurrentFilter();
            }
            else
            {
                FiltersFormIns = new FiltersForm(ColorsDataSource, AnalystsSubSource, StatusesDataSource, CompaniesSubSource, ContactsSubSource);
            }

            // register events
            FiltersFormIns.SaveFilter += new FilterEventHandler(FiltersForm_SaveFilter);

            DimForm();

            // show form
            FiltersFormIns.ShowDialog();

            // return form appearance to normal
            if (CheckIfFormIsOpened("Transparent Form")) TransparentForm.Close();
            this.Focus();

            if (FiltersFormIns.DialogResult == DialogResult.Cancel) return;

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
        private void fullViewBtn_Click(object sender, EventArgs e)
        {
            // entering full view
            if (fullView == false)
            {
                fullView = true;
                fullViewBtn.BackColor = Color.FromName("Highlight");

                // save current splitter distance
                currentSplitter1Distance = splitContainerChild1.SplitterDistance;

                // set min panel size
                splitContainerChild1.Panel2MinSize = 37;

                // move splitter distance to as far as it'll go
                splitContainerChild1.SplitterDistance = 5000;

                // show controls
                detailsOptionsPanel2.Visible = true;

                // lock 
                splitContainerChild1.IsSplitterFixed = true;
                enlargeBtn.Enabled = false;

                // hide panels
                itemDetailsPanel.Visible = false;
                queryPanel.Visible = false;
                importPanel.Visible = false;
                detailsOptionsPanel.Visible = false;

                // move notifications panel
                detailNotificationsPanel.Top = detailsOptionsPanel2.Top + 1;
                detailNotificationsPanel.Left = detailsOptionsPanel2.Left - 250;

                workflowItemsListView.Focus();
            }
            else
            {
                // exiting full view
                fullView = false;
                fullViewBtn.BackColor = Color.FromArgb(20, 20, 20);
                splitContainerChild1.SplitterDistance = currentSplitter1Distance;
                splitContainerChild1.Panel2MinSize = 408;
                detailsOptionsPanel2.Visible = false;
                splitContainerChild1.IsSplitterFixed = false;
                enlargeBtn.Enabled = true;
                itemDetailsPanel.Visible = true;
                queryPanel.Visible = true;
                importPanel.Visible = true;
                detailsOptionsPanel.Visible = true;
                enlargeBtn.Enabled = true;
                detailNotificationsPanel.Top = detailNotificationPanelTop;
                detailNotificationsPanel.Left = detailNotificationPanelLeft;
            }
        }
        private void enlargeBtn_Click(object sender, EventArgs e)
        {
            this.splitContainerChild1.SplitterDistance = splitContainerChild1.Bottom - 412;
            this.splitContainerChild2.SplitterDistance = 5000;
            workflowItemsListView.Focus();
        }
        private void refreshListViewBtn_Click(object sender, EventArgs e)
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
            this.Refresh();
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
                    Color altBackColor = Color.FromArgb(15, 23, 23);
                    previousEmailDate = "";
                    previousSender = "";
                    string id = "";
                    ItemGroupsSortedColors = new Dictionary<string, Color>();

                    foreach (ListViewItem item in workflowItemsListView.Items)
                    {
                        if (previousEmailDate == String.Empty)
                        {
                            id = item.SubItems[1].Text;
                            ItemGroupsSortedColors.Add(id, defaultBackColor);
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
                        ItemGroupsSortedColors.Add(id, currentColor);
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
            if (!showItemsMonotone)
            {
                showItemsMonotone = true;
                showItemsMonotoneBtn.BackColor = Color.FromName("Highlight");
            }
            else
            {
                showItemsMonotone = false;
                showItemsMonotoneBtn.BackColor = ThemeColors.Space;
            }
        }
        private void fixListViewColumnSizingBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < workflowItemsListView.Columns.Count - 1; i++)
            {
                workflowItemsListView.Columns[i].Width = 70;
            }
        }
        private void clCustomDDLSelectionBtn_TextChanged(object sender, EventArgs e)
        {
            string client = clSelectionBtn.Text;
            if (client == "Select one..." || client == String.Empty) return;
            int delim = client.IndexOf('<');
            SelectedClientID = client.Substring(delim + 1, client.Length - 1 - delim - 1);

            // return if loading client selection as opposed to generating info from client selection
            if (ignoreThisTextChange)
            {
                ignoreThisTextChange = false;
                return;
            }

            if (changeClientBackgroundWorker.IsBusy)
            {
                MessageBox.Show("Process is still running. Wait a few moments before trying again.");
                return;
            }
            else changeClientBackgroundWorker.RunWorkerAsync(SelectedClientID);
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
        private void DisableWFDataOptions()
        {
            this.loadWorkspaceToolStripMenuItem.Enabled = false;
            this.dataToolStripMenuItem.Enabled = false;
            this.importBtn.Enabled = false;
            this.importFromDatabaseBtn.Enabled = false;
        }
        private void EnableWFDataOptions()
        {
            this.loadWorkspaceToolStripMenuItem.Enabled = true;
            this.dataToolStripMenuItem.Enabled = true;
            this.importBtn.Enabled = true;
            this.importFromDatabaseBtn.Enabled = true;
        }
        //
        // ContextMenu
        //
        //
        // Copy and Selection
        private void copyContextMenuItem_Click(object sender, EventArgs e)
        {
            string s = "";
            string ss = "";

            try
            {
                // get checked and selected together
                List<ListViewItem> items = new List<ListViewItem>();

                if (workflowItemsListView.SelectedItems != null && workflowItemsListView.SelectedItems.Count > 0 && workflowItemsListView.SelectedItems[0].Checked == false)
                {
                    foreach (ListViewItem selectedItem in workflowItemsListView.SelectedItems)
                    {
                        items.Add(selectedItem);
                    }
                }

                if (workflowItemsListView.CheckedItems != null && workflowItemsListView.CheckedItems.Count > 0)
                {
                    foreach (ListViewItem checkedItem in workflowItemsListView.CheckedItems)
                    {
                        items.Add(checkedItem);
                    }
                }

                items.OrderBy(i => i.SubItems[1]);

                // copy items
                if (items != null && items.Count > 0)
                {
                    foreach (ListViewItem item in items)
                    {
                        ss = "";

                        // first 6 subitems after 0... change here if necessary (currently stops at subject)
                        for (int i = 1; i < 7; i++)
                        {
                            ss += $"{item.SubItems[i].Text}\t";
                        }

                        s += $"{ss}{Environment.NewLine}";
                    }
                }

                if (s != String.Empty) Clipboard.SetText(s);

                SetStatusLabelAndTimer($"{items.Count} item(s) copied to clipboard");
            }
            catch (Exception)
            {
                SetStatusLabelAndTimer("Unable to copy item(s)");
            }
        }
        private void copyWithHeadersContextMenuItem_Click(object sender, EventArgs e)
        {
            string s = "";
            string ss = "";

            try
            {
                // get checked and selected together
                List<ListViewItem> items = new List<ListViewItem>();

                if (workflowItemsListView.SelectedItems != null && workflowItemsListView.SelectedItems.Count > 0 && workflowItemsListView.SelectedItems[0].Checked == false)
                {
                    foreach (ListViewItem selectedItem in workflowItemsListView.SelectedItems)
                    {
                        items.Add(selectedItem);
                    }
                }

                if (workflowItemsListView.CheckedItems != null && workflowItemsListView.CheckedItems.Count > 0)
                {
                    foreach (ListViewItem checkedItem in workflowItemsListView.CheckedItems)
                    {
                        items.Add(checkedItem);
                    }
                }

                items.OrderBy(i => i.SubItems[1]);

                // copy items
                if (items != null && items.Count > 0)
                {
                    // copy headers
                    ss = "";

                    // first 6 subitems after 0... change here if necessary (currently stops at subject)
                    for (int i = 1; i < 7; i++)
                    {
                        ss += $"{workflowItemsListView.Columns[i].Text}\t";
                    }

                    s += $"{ss}{Environment.NewLine}";

                    // copy contents
                    foreach (ListViewItem item in items)
                    {
                        ss = "";

                        // first 6 subitems after 0... change here if necessary (currently stops at subject)
                        for (int i = 1; i < 7; i++)
                        {
                            ss += $"{item.SubItems[i].Text}\t";
                        }

                        s += $"{ss}{Environment.NewLine}";
                    }
                }

                if (s != String.Empty) Clipboard.SetText(s);

                SetStatusLabelAndTimer($"{items.Count} item(s) copied to clipboard with headers");
            }
            catch (Exception)
            {
                SetStatusLabelAndTimer("Unable to copy item(s)");
            }
        }
        private void copyIdsContextMenuItem_Click(object sender, EventArgs e)
        {
            string s = "";
            string ss = "";

            try
            {
                // get checked and selected together
                List<ListViewItem> items = new List<ListViewItem>();

                if (workflowItemsListView.SelectedItems != null && workflowItemsListView.SelectedItems.Count > 0 && workflowItemsListView.SelectedItems[0].Checked == false)
                {
                    foreach (ListViewItem selectedItem in workflowItemsListView.SelectedItems)
                    {
                        items.Add(selectedItem);
                    }
                }

                if (workflowItemsListView.CheckedItems != null && workflowItemsListView.CheckedItems.Count > 0)
                {
                    foreach (ListViewItem checkedItem in workflowItemsListView.CheckedItems)
                    {
                        items.Add(checkedItem);
                    }
                }

                items.OrderBy(i => i.SubItems[1]);

                // copy items
                if (items != null && items.Count > 0)
                {
                    foreach (ListViewItem item in items)
                    {
                        ss = "";

                        // only ids
                        ss += $"{item.SubItems[1].Text}";

                        s += $"{ss}{Environment.NewLine}";
                    }
                }

                if (s != String.Empty) Clipboard.SetText(s);

                SetStatusLabelAndTimer($"{items.Count} id(s) copied to clipboard");
            }
            catch (Exception)
            {
                SetStatusLabelAndTimer("Unable to copy item(s)");
            }
        }
        private void selectAllContextMenuItem_Click(object sender, EventArgs e)
        {
            CheckAllListViewItems();
            if (workflowItemsListView.SelectedItems != null && workflowItemsListView.SelectedItems.Count > 0) workflowItemsListView.SelectedItems[0].Selected = false;
            workflowItemsListView.Focus();
            workflowItemsListView.Refresh();
        }
        //
        // Item Action
        private void openLinkContextMenuItem_Click(object sender, EventArgs e)
        {
            // return if no checked items
            if (workflowItemsListView.CheckedItems == null || workflowItemsListView.CheckedItems.Count == 0)
            {
                SetStatusLabelAndTimer("Items need to be checked for that", 5000);
                MakeErrorSound();
                return;
            }

            List<string> idsInList = new List<string>();
            int urlsNotOpened = 0;

            // foreach id checked
            if (workflowItemsListView.CheckedItems.Count > 25)
            {
                SetStatusLabelAndTimer("Cannot open links for more than 25 items at a time");
                MakeErrorSound();
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            foreach (ListViewItem checkedItem in workflowItemsListView.CheckedItems)
            {
                idsInList.Add(checkedItem.SubItems[1].Text);
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
            // return if no checked items
            if (workflowItemsListView.CheckedItems == null || workflowItemsListView.CheckedItems.Count == 0)
            {
                SetStatusLabelAndTimer("Items need to be checked for that", 5000);
                MakeErrorSound();
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            List<WorkflowItem> tmpList = new List<WorkflowItem>();
            tmpList = GetWorkflowItemsFromChecked(workflowItemsListView);
            int addedCount = 0;

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

            workflowItemsListView.EndUpdate();
            Cursor.Current = Cursors.Default;
        }
        private void removeFromExportViewContextMenuItem_Click(object sender, EventArgs e)
        {
            // return if no checked items
            if (workflowItemsListView.CheckedItems == null || workflowItemsListView.CheckedItems.Count == 0)
            {
                SetStatusLabelAndTimer("Items need to be checked for that", 5000);
                MakeErrorSound();
                return;
            }

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

            Cursor.Current = Cursors.Default;
        }
        //
        // Item Edit (app info)
        private void paintContextMenuItem_Click(object sender, EventArgs e)
        {
            paintBtn.PerformClick();
        }
        private void removePaintContextMenuItem_Click(object sender, EventArgs e)
        {
            removePaintBtn.PerformClick();
        }
        private void markPriorityContextMenuItem_Click(object sender, EventArgs e)
        {
            // return if no checked items
            if (workflowItemsListView.CheckedItems == null || workflowItemsListView.CheckedItems.Count == 0)
            {
                SetStatusLabelAndTimer("Items need to be checked for that", 5000);
                MakeErrorSound();
                return;
            }

            UseWaitCursor = true;

            try
            {
                itemsUpdated = 0;

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
            // return if no checked items
            if (workflowItemsListView.CheckedItems == null || workflowItemsListView.CheckedItems.Count == 0)
            {
                SetStatusLabelAndTimer("Items need to be checked for that", 5000);
                MakeErrorSound();
                return;
            }
            // return if more than 50 items
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
            // return if no checked items
            if (workflowItemsListView.CheckedItems == null || workflowItemsListView.CheckedItems.Count == 0)
            {
                SetStatusLabelAndTimer("Items need to be checked for that", 5000);
                MakeErrorSound();
                return;
            }

            UseWaitCursor = true;

            try
            {
                itemsUpdated = 0;

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
            // return if no checked items
            if (workflowItemsListView.CheckedItems == null || workflowItemsListView.CheckedItems.Count == 0)
            {
                SetStatusLabelAndTimer("Items need to be checked for that", 5000);
                MakeErrorSound();
                return;
            }

            UseWaitCursor = true;

            try
            {
                itemsUpdated = 0;

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
            // return if no checked items
            if (workflowItemsListView.CheckedItems == null || workflowItemsListView.CheckedItems.Count == 0)
            {
                SetStatusLabelAndTimer("Items need to be checked for that", 5000);
                MakeErrorSound();
                return;
            }

            UseWaitCursor = true;

            try
            {
                itemsUpdated = 0;

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
        //
        // Item Edit (workflow info)
        private void modifyContextMenuItem_Click(object sender, EventArgs e)
        {
            // return if no checked items
            if (workflowItemsListView.CheckedItems == null || workflowItemsListView.CheckedItems.Count == 0)
            {
                SetStatusLabelAndTimer("Items need to be checked for that", 5000);
                MakeErrorSound();
                return;
            }

            #region Generate Form

            DimForm();
            ModifyForm = new ModifyForm(CompaniesSubSource, CertificatesSubSource, AnalystsSubSource, StatusesDataSource);
            List<string> options = new List<string>();

            DialogResult result = ModifyForm.ShowDialog();

            if (CheckIfFormIsOpened("Transparent Form")) TransparentForm.Close();
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
                string selectedAssignmentID = ModifyForm.SelectedAssignmentID;
                string selectedStatus = ModifyForm.SelectedStatus;
                string note = ModifyForm.Note;
                bool appendNote = ModifyForm.AppendNote;

                foreach (WorkflowItem wi in checkedItems)
                {
                    // item edit here
                    if (selectedCompany != null && selectedCompany != String.Empty)
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
                        //if (AnalystsSubSource.Any(i => i.Name == selectedAssignment))
                        //    wi.AssignedToID = (AnalystsSubSource.Where(i => i.Name == selectedAssignment).FirstOrDefault() as Analyst).SystemUserID;
                        wi.WorkflowItemInformationDifferentThanCertus = true;
                        wi.DisplayColor = "SpringGreen";
                        itemsToUpdate.Add(wi);
                    }
                    if (selectedAssignmentID != null && selectedAssignmentID != String.Empty)
                    {
                        wi.AssignedToID = selectedAssignmentID;
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
                        if (appendNote) wi.Note += $"{note} ";
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
            // return if no checked items
            if (workflowItemsListView.CheckedItems == null || workflowItemsListView.CheckedItems.Count == 0)
            {
                SetStatusLabelAndTimer("Items need to be checked for that", 5000);
                MakeErrorSound();
                return;
            }

            if (CompanyDictionary == null || CompanyDictionary.Count == 0)
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
                SetStatusLabelAndTimer("Getting the checked items together. This sometimes takes awhile...", true);
                this.Refresh();
                findAndFillCompanyBackgroundWorker.RunWorkerAsync("sender");
            }
            else if (LoadingForm.DialogResult == DialogResult.OK)
            {
                Application.UseWaitCursor = true;
                Application.DoEvents();
                SetStatusLabelAndTimer("Getting the checked items together. This sometimes takes awhile...", true);
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
            // return if no checked items
            if (workflowItemsListView.CheckedItems == null || workflowItemsListView.CheckedItems.Count == 0)
            {
                SetStatusLabelAndTimer("Items need to be checked for that", 5000);
                MakeErrorSound();
                return;
            }

            if (CertificateDictionary == null || CertificateDictionary.Count == 0)
            {
                SetStatusLabelAndTimer("Certificates need to be imported for that");
                MakeErrorSound();
                return;
            }

            Application.UseWaitCursor = true;
            Application.DoEvents();

            SetStatusLabelAndTimer("Getting the checked items together. This sometimes takes awhile...", true);
            this.Refresh();
            List<WorkflowItem> checkedItems = GetWorkflowItemsFromChecked(workflowItemsListView);
            findAndOverrideContractInformationBackgroundWorker.RunWorkerAsync(checkedItems);
        }
        private void appendCompaniesContextMenuItem_Click(object sender, EventArgs e)
        {
            // return if no checked items
            if (workflowItemsListView.CheckedItems == null || workflowItemsListView.CheckedItems.Count == 0)
            {
                SetStatusLabelAndTimer("Items need to be checked for that", 5000);
                MakeErrorSound();
                return;
            }

            Application.UseWaitCursor = true;
            Application.DoEvents();

            SetStatusLabelAndTimer("Getting items...", true);
            this.Refresh();
            fillCompanyBackgroundWorker.RunWorkerAsync();
        }
        private void appendContractContextMenuItem_Click(object sender, EventArgs e)
        {
            // return if no checked items
            if (workflowItemsListView.CheckedItems == null || workflowItemsListView.CheckedItems.Count == 0)
            {
                SetStatusLabelAndTimer("Items need to be checked for that", 5000);
                MakeErrorSound();
                return;
            }

            Application.UseWaitCursor = true;
            Application.DoEvents();

            SetStatusLabelAndTimer("Getting items...", true);
            this.Refresh();
            fillContractInformationBackgroundWorker.RunWorkerAsync();
        }
        private void appendAssignmentContextMenuItem_Click(object sender, EventArgs e)
        {
            // return if no checked items
            if (workflowItemsListView.CheckedItems == null || workflowItemsListView.CheckedItems.Count == 0)
            {
                SetStatusLabelAndTimer("Items need to be checked for that", 5000);
                MakeErrorSound();
                return;
            }

            Application.UseWaitCursor = true;
            Application.DoEvents();

            SetStatusLabelAndTimer("Getting items...", true);
            this.Refresh();
            fillAssignmentBackgroundWorker.RunWorkerAsync();
        }
        private void appendStatusAndAssignmentContextMenuItem_Click(object sender, EventArgs e)
        {
            // return if no checked items
            if (workflowItemsListView.CheckedItems == null || workflowItemsListView.CheckedItems.Count == 0)
            {
                SetStatusLabelAndTimer("Items need to be checked for that", 5000);
                MakeErrorSound();
                return;
            }

            Application.UseWaitCursor = true;
            Application.DoEvents();

            SetStatusLabelAndTimer("Getting items...", true);
            this.Refresh();
            fillAssignmentAndStatusBackgroundWorker.RunWorkerAsync();
        }
        private void setAssignmentFindContextMenuItem_Click(object sender, EventArgs e)
        {
            // return if no checked items
            if (workflowItemsListView.CheckedItems == null || workflowItemsListView.CheckedItems.Count == 0)
            {
                SetStatusLabelAndTimer("Items need to be checked for that", 5000);
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
                            if (CompanyDictionary == null || CompanyDictionary.Count == 0)
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
                            if (CompanyDictionary == null || CompanyDictionary.Count == 0)
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
                            if (CompanyDictionary == null || CompanyDictionary.Count == 0 || CertificateDictionary == null || CertificateDictionary.Count == 0)
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
            // return if no checked items
            if (workflowItemsListView.CheckedItems == null || workflowItemsListView.CheckedItems.Count == 0)
            {
                SetStatusLabelAndTimer("Items need to be checked for that", 5000);
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
            foreach (var keyValPair in SystemUserIDsDictionary)
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
            // return if no checked items
            if (workflowItemsListView.CheckedItems == null || workflowItemsListView.CheckedItems.Count == 0)
            {
                SetStatusLabelAndTimer("Items need to be checked for that", 5000);
                MakeErrorSound();
                return;
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
                        wi.AssignedToID = null;
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
        #endregion

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
                int columnToResize = sizeFixHeader.Index;

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
                if (workflowItemsListView.ClientSize.Width > allOtherColumnsWidth)
                {
                    if (workflowItemsListView.Columns[columnToResize].Width != (workflowItemsListView.ClientSize.Width - allOtherColumnsWidth))
                        workflowItemsListView.Columns[columnToResize].Width = (workflowItemsListView.ClientSize.Width - allOtherColumnsWidth);
                }
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

            //e.Graphics.DrawLine(SystemPens.ControlDark, e.Bounds.X, e.Bounds.Y, e.Bounds.Right, e.Bounds.Y);
            //e.Graphics.DrawLine(SystemPens.WindowFrame, e.Bounds.X, e.Bounds.Y+23, e.Bounds.Right, e.Bounds.Y+23);
            e.Graphics.DrawLine(SystemPens.WindowFrame, e.Bounds.X - 1, e.Bounds.Y, e.Bounds.X - 1, e.Bounds.Bottom / 5);
        }
        private void workflowItemsListView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            if (AllWorkflowItemsLoaded == null || AllWorkflowItemsLoaded.Count == 0) return;

            string idBeingDrawn = e.Item.SubItems[1].Text;
            WorkflowItem itemBeingDrawn = GetWorkflowItemFromCurrentViewByID(idBeingDrawn);
            ListViewItem lvItem = workflowItemsListView.Items[e.ItemIndex] as ListViewItem;
            Rectangle checkBoxRect = new Rectangle(e.Bounds.X + 2, e.Bounds.Y, e.Bounds.Height - 1, e.Bounds.Height - 1);
            //Rectangle checkBoxRect = new Rectangle(e.Bounds.X + 3, e.Bounds.Y + 1, e.Bounds.Height - 3, e.Bounds.Height - 3);
            Pen checkBoxRectHighlight = new Pen(Color.SpringGreen);

            try
            {
                switch (contrastItemGroups)
                {
                    case true:
                        {
                            if (e.Item.Checked || e.Item.Focused)
                            {
                                if (e.Item.Selected)
                                {
                                    e.Item.BackColor = ThemeColors.SpaceLightOff;
                                    e.DrawFocusRectangle();
                                }
                                else if (e.Item.Checked && checkedItemsAreFocused)
                                {
                                    e.Graphics.DrawRectangle(checkBoxRectHighlight, checkBoxRect);

                                    e.Item.BackColor = ThemeColors.SpaceLightOff;
                                    e.Item.ForeColor = ThemeColors.MainThemeLight;
                                    e.Item.UseItemStyleForSubItems = true;
                                    e.DrawDefault = true;
                                    return;
                                }
                                else if (e.Item.Checked && e.Item.Focused)
                                {
                                    e.Graphics.DrawRectangle(checkBoxRectHighlight, checkBoxRect);

                                    e.Item.BackColor = ThemeColors.SpaceLightOff;
                                    e.DrawFocusRectangle();
                                }
                                else if (e.Item.Focused)
                                {
                                    e.Graphics.DrawRectangle(checkBoxRectHighlight, checkBoxRect);
                                    e.Item.BackColor = ItemGroupsSortedColors[e.Item.SubItems[1].Text];
                                    e.DrawFocusRectangle();
                                }
                                else if (e.Item.Checked)
                                {
                                    e.Item.BackColor = ThemeColors.SpaceLightOff;
                                }
                            }
                            else
                            {
                                e.Item.BackColor = ItemGroupsSortedColors[e.Item.SubItems[1].Text];
                            }
                        }
                        break;
                    case false:
                        {
                            if (e.Item.Checked || e.Item.Focused)
                            {
                                if (e.Item.Selected)
                                {
                                    e.Item.BackColor = ThemeColors.SpaceLightOff;
                                    e.DrawFocusRectangle();
                                }
                                else if (e.Item.Checked && checkedItemsAreFocused)
                                {
                                    e.Graphics.DrawRectangle(checkBoxRectHighlight, checkBoxRect);

                                    e.Item.BackColor = ThemeColors.SpaceLightOff;
                                    e.Item.ForeColor = ThemeColors.MainThemeLight;
                                    e.Item.UseItemStyleForSubItems = true;
                                    e.DrawDefault = true;
                                    return;
                                }
                                else if (e.Item.Checked && e.Item.Focused)
                                {
                                    e.Graphics.DrawRectangle(checkBoxRectHighlight, checkBoxRect);

                                    e.Item.BackColor = ThemeColors.SpaceLightOff;
                                    e.DrawFocusRectangle();

                                }
                                else if (e.Item.Focused)
                                {
                                    e.Graphics.DrawRectangle(checkBoxRectHighlight, checkBoxRect);

                                    e.Item.BackColor = ThemeColors.SpaceDark;
                                    e.DrawFocusRectangle();
                                }
                                else if (e.Item.Checked)
                                {
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

            if (!showItemsMonotone)
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
            try
            {
                clickedItem = workflowItemsListView.HitTest(e.Location);

                // context menu launch
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
                        copyContextMenuItem_Click(this, null);
                    }
                    else if (e.Control && e.Shift && e.KeyCode == Keys.C)
                    {
                        copyWithHeadersContextMenuItem_Click(this, null);
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
        //
        // Item Buttons/Tabs
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
        // 
        // The normal viewable controls for the details view
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
            for (int i = 0; i < itemButtons.Length; i++)
            {
                if (itemButtons[i].Text != "Item" && itemButtons[i].Visible == true)
                    itemButtons[i].BackColor = Color.FromName("Highlight");
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
        private void clearItemDetailsBtn_Click(object sender, EventArgs e)
        {
            ClearItemDetails();
        }
        private void ClearItemDetails()
        {

            foreach (Panel panl in detailPanels)
            {
                foreach (Control cc in panl.Controls)
                {
                    if (cc is TextBox)
                    {
                        (cc as TextBox).Text = String.Empty;
                    }
                }
            }

            ResetStatusStrip();
        }
        private void openInCertusBtn_Click(object sender, EventArgs e)
        {
            /*
            //UseWaitCursor = true;
            // ...
            // turning on
            if (connectionBtnStatus && CheckIfFormIsOpened("BrowserForm"))
            {
                if (subjectTbx != null && subjectTbx.Text != String.Empty)
                {
                    //CertusBrowser.OpenItemInWorkflow(documentWorkflowItemIdTbx.Text, subjectTbx.Text);
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
            */
        }
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
        private void openNoteBtn_Click(object sender, EventArgs e)
        {
            if (documentWorkflowItemIdTbx.Text == String.Empty)
            {
                SetStatusLabelAndTimer("No item is in the details view");
                return;
            }

            string itemID = documentWorkflowItemIdTbx.Text;
            WorkflowItem wi;

            #region Generate Form
            DimForm();
            NoteIns = new NoteForm();

            try
            {
                wi = GetWorkflowItemFromAllByID(itemID);
                NoteIns.Populate(wi);
            }
            catch (Exception)
            {
                SetStatusLabelAndTimer("Could not process the request");
                if (CheckIfFormIsOpened("Transparent Form")) TransparentForm.Close();
                return;
            }

            DialogResult result = NoteIns.ShowDialog();

            if (CheckIfFormIsOpened("Transparent Form")) TransparentForm.Close();
            this.Focus();
            #endregion

            if (result == DialogResult.OK)
            {
                // new item
                WorkflowItem newItem = new WorkflowItem();
                newItem = wi;
                newItem.Note = NoteIns.Note;

                // replace
                UpdateAllLoadedWorkflowItems(newItem);

                SetStatusLabelAndTimer($"Item {itemID} note updated");
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
        //
        // Notifications
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

            if (assignedToDescLbl.Text == "> Assigned To:")
            {
                if (itemToSave.AssignedToName != assignedToTbx.Text)
                {
                    itemToSave.AssignedToName = assignedToTbx.Text;

                    if (itemToSave.Status == "Documentation Analyst") itemToSave.WorkflowAnalyst = itemToSave.AssignedToName;
                    else if (itemToSave.Status == "Compliance Analyst") itemToSave.CompanyAnalyst = itemToSave.AssignedToName;

                    itemToSave.DisplayColor = "SpringGreen";
                    itemToSave.WorkflowItemInformationDifferentThanCertus = true;
                }
            }
            else if (assignedToDescLbl.Text == ">> Assigned ID:")
            {
                if (itemToSave.AssignedToID != assignedToTbx.Text)
                {
                    itemToSave.AssignedToID = assignedToTbx.Text;

                    itemToSave.DisplayColor = "SpringGreen";
                    itemToSave.WorkflowItemInformationDifferentThanCertus = true;
                }
            }
            else if (assignedToDescLbl.Text == ">>> Workflow Analyst:")
            {
                if (itemToSave.WorkflowAnalyst != assignedToTbx.Text)
                {
                    itemToSave.WorkflowAnalyst = assignedToTbx.Text;

                    if (itemToSave.Status == "Documentation Analyst") itemToSave.AssignedToName = itemToSave.WorkflowAnalyst;

                    itemToSave.DisplayColor = "SpringGreen";
                    itemToSave.WorkflowItemInformationDifferentThanCertus = true;
                }
            }
            else if (assignedToDescLbl.Text == ">>>> Company Analyst:")
            {
                if (itemToSave.CompanyAnalyst != assignedToTbx.Text)
                {
                    itemToSave.CompanyAnalyst = assignedToTbx.Text;

                    if (itemToSave.Status == "Compliance Analyst") itemToSave.AssignedToName = itemToSave.CompanyAnalyst;

                    itemToSave.DisplayColor = "SpringGreen";
                    itemToSave.WorkflowItemInformationDifferentThanCertus = true;
                }
            }

            itemToSave.Note = detailNoteTbx.Text;

            AllWorkflowItemsLoaded[indexToSaveTo] = itemToSave;
        }
        #endregion

        // ----- ITEM DETAIL APPEARANCE AND BEHAVIOR ----- //
        #region Item Detail Appearance and Behavior
        //
        // Handler for the ID tbx which is the only one that gets a different TextChanged handler
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
                SetStatusLabelAndTimer($"Showing '{documentWorkflowItemIdTbx.Text}'", true, true);
            }
            else
            {
                ResetStatusStrip();
            }
        }
        //
        // Item button tab appearance (some function)
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
                if (wi.DisplayColor == "Default") itemButton0.ForeColor = ThemeColors.ItemDefault;
                else itemButton0.ForeColor = Color.FromName(wi.DisplayColor);
            }
            catch (Exception)
            {
                SetStatusLabelAndTimer("Couldn't get item color", 3000);
                MakeErrorSound();
            }
        }
        //
        // Clickable Detail Labels
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
            {
                this.contractIdDescLbl.Text = ">> Certus ID:";
                contractIdTbx.AutoCompleteMode = AutoCompleteMode.None;
            }
            else if (this.contractIdDescLbl.Text == ">> Certus ID:")
            { 
                this.contractIdDescLbl.Text = "> Contract ID:";
                contractIdTbx.AutoCompleteMode = AutoCompleteMode.Append;
            }

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
                this.assignedToTbx.ReadOnly = false;
            }
            else if (this.assignedToDescLbl.Text == ">> Assigned ID:")
            {
                this.assignedToDescLbl.Text = ">>> Workflow Analyst:";
                this.assignedToTbx.ReadOnly = true;
            }
            else if (this.assignedToDescLbl.Text == ">>> Workflow Analyst:")
            {
                this.assignedToDescLbl.Text = ">>>> Company Analyst:";
            }
            else if (this.assignedToDescLbl.Text == ">>>> Company Analyst:")
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
        #endregion

        // ----- QUERY PANEL ----- //
        #region Query Panel
        //
        // Query options/controls
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
        private void qfndCustomDDLSelectionBtn_TextChanged(object sender, EventArgs e)
        {
            switch (this.qfndSelectionBtn.Text)
            {
                case "Images":
                    this.querySelectComboBox.Text = "Items";
                    this.qsTbx.Text = "Items";
                    this.queryFromComboBox.Text = "Non-completed";
                    this.qfTbx.Text = "Non-completed";
                    this.queryWhereComboBox.Text = "Image attached & not alone";
                    this.qwTbx.Text = "Image attached & not alone";
                    break;
                case "Req Tmp":
                    this.querySelectComboBox.Text = "Items";
                    this.qsTbx.Text = "Items";
                    this.queryFromComboBox.Text = "Non-completed";
                    this.qfTbx.Text = "Non-completed";
                    this.queryWhereComboBox.Text = "Req Tmp attached & not alone";
                    this.qwTbx.Text = "Req Tmp attached & not alone";
                    break;
                case "Same COI":
                    this.querySelectComboBox.Text = "Items";
                    this.qsTbx.Text = "Items";
                    this.queryFromComboBox.Text = "Non-completed";
                    this.qfTbx.Text = "Non-completed";
                    this.queryWhereComboBox.Text = "COI attached & file name matches any in DB (all)";
                    this.qwTbx.Text = "COI attached & file name matches any in DB (all)";
                    break;
                case "Clutter":
                    this.querySelectComboBox.Text = "Item Groups";
                    this.qsTbx.Text = "Item Groups";
                    this.queryFromComboBox.Text = "Non-completed";
                    this.qfTbx.Text = "Non-completed";
                    this.queryWhereComboBox.Text = "Email date & file size match (all)";
                    this.qwTbx.Text = "Email date & file size match (all)";
                    break;
                case "No Attach":
                    this.querySelectComboBox.Text = "Items";
                    this.qsTbx.Text = "Items";
                    this.queryFromComboBox.Text = "Non-completed";
                    this.qfTbx.Text = "Non-completed";
                    this.queryWhereComboBox.Text = "No attachments";
                    this.qwTbx.Text = "No attachments";
                    break;
                case "Auto Reply":
                    this.SetStatusLabelAndTimer("That query has not been set up yet");
                    MakeErrorSound();
                    return;
                default:
                    break;
            }

            viewQueryBtn.Focus();
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
        //
        // LINQ Queries
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
        private dynamic QueryDuplicateCOIs(List<WorkflowItem> listToQuery)
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
                            where item.Active == true
                            select item;

            return results;
        }
        private dynamic QueryInactiveContracts(List<WorkflowItem> listToQuery)
        {
            var results = from item in listToQuery
                            where item.Active == false
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
        //
        // Query panel functionality
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
        //
        // Filter methods for finding COIs (not really all that accurate)
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
        #endregion

        // ----- IMPORTS PANEL ----- //
        #region Imports Panel
        private void itemImportsLbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.itemImportsLbx.SelectedItem != null)
            {
                SelectedImport = (Import)itemImportsLbx.SelectedItem;

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
        #endregion

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
        private void SetStatusLabelAndTimer(string statusLblMessage, bool timerIgnored, bool colorChangeIgnored)
        {
            statusLblTimer.Enabled = false;

            if (this.InvokeRequired) this.Invoke(new Action(() =>
            {
                toolStripStatusLabel.Text = statusLblMessage;
                this.toolStripStatusLabel.BackColor = Color.FromArgb(46, 204, 113);
            }));
            else
            {
                toolStripStatusLabel.Text = statusLblMessage;
                this.toolStripStatusLabel.BackColor = Color.FromArgb(46, 204, 113);
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
        #endregion

        // ----- FORM MANEUVERABILITY ----- //
        #region Form Maneuverability
        //
        // The methods/handlers within this region all focus on proper tab
        // usage throughout the main form. User should be able to tab from
        // the listview, to the last item opened (item with the '-' text in
        // front, to the save button, back to the listview. Arrow controls
        // should navigate through the items and enter key should bring focus
        // back to the item being viewed focus button, then to the save button
        private Button DetailPanelFocusBtn(Panel panel)
        {
            Button fBtn = new Button();

            foreach (Button btn in panel.Controls.OfType<Button>())
            {
                if (btn.Name.StartsWith("focus")) fBtn = btn;
                break;
            }

            return fBtn;
        }
        private TextBox DetailPanelTbx(Panel panel)
        {
            TextBox tbx = new TextBox();

            foreach (Control c in panel.Controls)
            {
                if (c is TextBox) tbx = c as TextBox;
                break;
            }

            return tbx;
        }
        private Button DetailPanelActiveBtn(Panel panel)
        {
            Button aBtn = new Button();

            foreach (Button btn in panel.Controls.OfType<Button>())
            {
                if (btn.Name.StartsWith("active")) aBtn = btn;
                break;
            }

            return aBtn;
        }
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
                        DetailPanelFocusBtn(detailPanels[detailPanels.Length - 1]).PerformClick();
                    }
                    else if (selectedPanelIndex == 12)
                    {
                        detailPanels[5].Focus();
                        DetailPanelFocusBtn(detailPanels[5]).PerformClick();
                    }
                    else
                    {
                        detailPanels[selectedPanelIndex - 1].Focus();
                        DetailPanelFocusBtn(detailPanels[selectedPanelIndex - 1]).PerformClick();
                    }
                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.Down)
                {
                    if (selectedPanelIndex == detailPanels.Length - 1)
                    {
                        detailPanels[0].Focus();
                        DetailPanelFocusBtn(detailPanels[0]).PerformClick();
                    }
                    else if (selectedPanelIndex == 5)
                    {
                        detailPanels[12].Focus();
                        DetailPanelFocusBtn(detailPanels[12]).PerformClick();
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
                        DetailPanelFocusBtn(detailPanels[selectedPanelIndex - 6]).PerformClick();
                    }
                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.Right)
                {
                    if (selectedPanelIndex == 0 || selectedPanelIndex == 1 || selectedPanelIndex == 2 ||
                        selectedPanelIndex == 3 || selectedPanelIndex == 4 || selectedPanelIndex == 5)
                    {
                        detailPanels[selectedPanelIndex + 6].Focus();
                        DetailPanelFocusBtn(detailPanels[selectedPanelIndex + 6]).PerformClick();
                    }
                    e.Handled = true;
                }
                else if (e.Control && e.KeyCode == Keys.V)
                {
                    foreach (Control c in ((sender as Button).Parent as Panel).Controls)
                    {
                        if (c is TextBox) // c is the tbx
                        {
                            (c as TextBox).Focus();
                            if ((c as TextBox).ReadOnly == false)
                            {
                                (c as TextBox).Text = String.Empty;
                                (c as TextBox).Text = Clipboard.GetText();
                                (c as TextBox).SelectionStart = (c as TextBox).TextLength;
                            }
                        }
                    }
                    return;
                }
                else if (e.KeyCode == Keys.Enter)
                {
                    detailsSaveBtn.Focus();
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
                DetailPanelFocusBtn((sender as TextBox).Parent as Panel).Focus();
            }
        }
        private void detailPanelTbx_KeyDown(object sender, KeyEventArgs e)
        {
            //
        }
        private void detailPanelTbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (sender is Button)
            {
                foreach (Control c in ((sender as Button).Parent as Panel).Controls)
                {
                    if (c is TextBox)
                    {
                        (c as TextBox).Focus();
                        if ((c as TextBox).ReadOnly == false)
                        {
                            (c as TextBox).Text = String.Empty;
                            (c as TextBox).Text += e.KeyChar.ToString();
                            (c as TextBox).SelectionStart = (c as TextBox).TextLength;
                        }
                        break;
                    }
                }
                return;
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
                DetailPanelFocusBtn(panel).TabStop = false;
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
            Button fBtn = DetailPanelFocusBtn(selectedPanel);

            // reset current tracked item by resetting all items
            foreach (Panel panel in detailPanels)
            {
                panel.TabStop = false;
                DetailPanelFocusBtn(panel).Text = String.Empty;
                DetailPanelTbx(panel).TabStop = false;
                DetailPanelFocusBtn(panel).TabStop = false;
            }

            fBtn.BackColor = Color.FromName("Highlight");
            fBtn.Text = "-";
            fBtn.TabStop = true;
            fBtn.Focus();
            fBtn.PerformClick();
        }
        private void detailPanel_Leave(object sender, EventArgs e)
        {
            Panel selectedPanel = sender as Panel;

            // leave
            DetailPanelFocusBtn(selectedPanel).BackColor = Color.FromArgb(20, 20, 20);
            DetailPanelTbx(selectedPanel).TabStop = false;
            DetailPanelTbx(selectedPanel).DeselectAll();
        }
        private List<string> ReturnDetailPanelValues()
        {
            List<string> vals = new List<string>();

            // add tbx text vals from each panel individually
            foreach (Panel p in splitterPanelSection1.Controls.OfType<Panel>())
            {
                if (p.Name.StartsWith("detailPanel"))
                {
                    foreach (Control c in p.Controls)
                    {
                        if (c is TextBox)
                        {
                            vals.Add((c as TextBox).Text);
                        }
                    }
                }
            }
            foreach (Panel p in splitterPanelSection2.Controls.OfType<Panel>())
            {
                if (p.Name.StartsWith("detailPanel"))
                {
                    foreach (Control c in p.Controls)
                    {
                        if (c is TextBox)
                        {
                            vals.Add((c as TextBox).Text);
                        }
                    }
                }
            }
            foreach (Panel p in itemDetailsPanel.Controls.OfType<Panel>())
            {
                if (p.Name.StartsWith("detailPanel"))
                {
                    foreach (Control c in p.Controls)
                    {
                        if (c is TextBox)
                        {
                            vals.Add((c as TextBox).Text);
                        }
                    }
                }
            }

            return vals;
        }
        private void itemDetailsPanel_Enter(object sender, EventArgs e)
        {
            CurrentDetailTbxVals = ReturnDetailPanelValues();
        }
        private void itemDetailsPanel_Leave(object sender, EventArgs e)
        {
            // find out if changes were made
            int indx = 0;
            List<string> vals = ReturnDetailPanelValues();
            foreach (string s in vals)
            {
                if(s != CurrentDetailTbxVals[indx])
                {
                    itemDetailsChanged = true;
                    break;
                }

                ++indx;
            }

            // prompt if changes made
            if (itemDetailsChanged)
            {
                if (!YesOrNoMsgBox("Leave without saving item changes?", "Warning"))
                {
                    selectedIndexChangedEventIgnored = true;
                    ignoreThisSaveBtnTabPress = true;
                    itemDetailsPanel.Focus();

                    foreach (Panel panel in detailPanels)
                    {
                        if (DetailPanelFocusBtn(panel).Text == "-")
                        {
                            tabWasPressed = true;
                            panel.Focus();
                            DetailPanelTbx(panel).Focus();
                            SelectItemInListView(documentWorkflowItemIdTbx.Text);
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

            //foreach (Panel panel in itemDetailsPanel.Controls.OfType<Panel>())
            //{
            //    if (panel.Name.StartsWith("detail"))
            //    {
            //        break;
            //        if (DetailPanelFocusBtn(panel).Text == "-")
            //        {
            //            panel.TabStop = true;
            //            DetailPanelFocusBtn(panel).TabStop = true;
            //        }
            //    }
            //}

            foreach (Panel panel in detailPanels)
            {
                if (DetailPanelFocusBtn(panel).Text == "-")
                {
                    panel.TabStop = true;
                    DetailPanelFocusBtn(panel).TabStop = true;
                }
            }
        }
        //
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
            if (e.Control && e.KeyCode == Keys.S)
            {
                saveWorkspaceToolStripMenuItem.PerformClick();
            }
            if (e.Control && e.KeyCode == Keys.F)
            {
                searchTbx.Focus();
                searchTbx.SelectAll();
            }
        }
        #endregion

        // ----- FORM APPEARANCE AND BEHAVIOR ----- //
        #region Form Appearance and Behavior
        private void WorkflowManager_Resize(object sender, EventArgs e)
        {
            try
            {
                // status strip
                this.toolStripStatusLabel.Width = this.ClientSize.Width - (displayingToolStripDropDownButton.Width +
                    displayingCountStatusLbl.Width + checkedToolStripDropDownButton.Width + checkedCountStatusLbl.Width +
                    queriedToolStripDropDownButton.Width + queriedCountStatusLbl.Width + filterStatusLbl.Width);

                // splitter distance
                if(!fullView) splitContainerChild1.SplitterDistance = (Convert.ToInt32(splitContainerChild1.Height * .43));
            }
            catch (Exception)
            {
                // dont crash while resizing the status strip or splitter distance
            }

            try
            {
                // column reisze
                int columnToResize = sizeFixHeader.Index;

                int allOtherColumnsWidth = 0;
                int columnWidthToSet = workflowItemsListView.Columns[columnToResize].Width;
                for (int i = 0; i < workflowItemsListView.Columns.Count; i++)
                {
                    if (i != columnToResize)
                    {
                        allOtherColumnsWidth += workflowItemsListView.Columns[i].Width;
                    }
                }

                if (workflowItemsListView.ClientSize.Width > allOtherColumnsWidth)
                {
                    if (workflowItemsListView.Columns[columnToResize].Width != (workflowItemsListView.ClientSize.Width - allOtherColumnsWidth))
                        workflowItemsListView.Columns[columnToResize].Width = (workflowItemsListView.ClientSize.Width - allOtherColumnsWidth);
                }
            }
            catch (Exception)
            {
                // dont crash while resizing the columns
            }
        }
        private void tbxComboBoxPair_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmbx = (sender as ComboBox);
            string s;

            if (cmbx.SelectedItem != null) s = cmbx.SelectedItem.ToString();
            else s = String.Empty;

            foreach (Control c in cmbx.Parent.Controls)
            {
                if (c is TextBox) (c as TextBox).Text = s;
                if (c is Panel)
                {
                    foreach (Control cc in c.Controls)
                    {
                        if (cc is TextBox) (cc as TextBox).Text = s;
                        if (cc is Panel)
                        {
                            foreach (Control ccc in cc.Controls)
                            {
                                if (ccc is TextBox) (ccc as TextBox).Text = s;
                            }
                        }
                    }
                }
            }
        }
        private void customDDLPanel_MouseLeave(object sender, EventArgs e)
        {

        }
        private void customDDLPanel_MouseHover(object sender, EventArgs e)
        {

        }
        private void customDDLPanel_MouseMove(object sender, MouseEventArgs e)
        {

        }
        private void testBtn_Click(object sender, EventArgs e)
        {

        }
        //
        // Custom DDLS
        //
        private void customDDLContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            contextMenuOpened = true;
        }
        private void customDDLPreventDropDownReopen_Tick(object sender, EventArgs e)
        {
            preventDropDownReopen.Enabled = false;
            contextMenuOpened = false;
        }
        //
        // quick find
        private void qfndCustomDDLBtns_MouseDown(object sender, MouseEventArgs e)
        {
            if (contextMenuOpened)
            {
                qfndCustomDDLPanel_Leave(sender, e);
                contextMenuOpened = false;
                return;
            }

            imgToUse = img2;
            qfndCustomDDLPanel_Enter(sender, e);

            // specific to each DDL
            qfndCustomDDLMenuStrip.Show(qfndOuterPanel, new Point(-1, qfndOuterPanel.Height - 2));
        }
        private void qfndCustomDDLPanel_Enter(object sender, EventArgs e)
        {
            qfndCustomDDLPanel_MouseHover(sender, e);

            qfndOuterPanel.MouseLeave -= qfndCustomDDLPanel_MouseLeave;
            qfndSelectionBtn.MouseLeave -= qfndCustomDDLPanel_MouseLeave;
            qfndDropBtn.MouseLeave -= qfndCustomDDLPanel_MouseLeave;

            // specific to each DDL
            qfndCustomDDLMenuStrip.MouseLeave -= qfndCustomDDLPanel_MouseLeave;
        }
        private void qfndCustomDDLPanel_MouseHover(object sender, EventArgs e)
        {
            // mouse over effect
            qfndSelectionBtn.BackColor = Color.FromArgb(40, 40, 40);
            qfndSplitPanel.Visible = true;
            qfndDropBtn.BackgroundImage = imgToUse;
        }
        private void qfndCustomDDLPanel_MouseLeave(object sender, EventArgs e)
        {
            // mouse off effect
            qfndSelectionBtn.BackColor = Color.FromArgb(27, 27, 27);
            qfndSplitPanel.Visible = false;
            qfndDropBtn.BackgroundImage = CertusCompanion.Properties.Resources.icons8_sort_down_24__7_;
            imgToUse = img;
        }
        private void qfndCustomDDLPanel_MouseMove(object sender, MouseEventArgs e)
        {
            qfndCustomDDLPanel_MouseHover(sender, e);
        }
        private void qfndCustomDDLPanel_Leave(object sender, EventArgs e)
        {
            qfndOuterPanel.MouseLeave += qfndCustomDDLPanel_MouseLeave;
            qfndDropBtn.MouseLeave += qfndCustomDDLPanel_MouseLeave;
            qfndSelectionBtn.MouseLeave += qfndCustomDDLPanel_MouseLeave;

            // specific to each DDL
            qfndCustomDDLMenuStrip.MouseLeave += qfndCustomDDLPanel_MouseLeave;

            qfndCustomDDLPanel_MouseLeave(sender, e);
        }
        private void qfndCustomDDLContextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            qfndSelectionBtn.Text = e.ClickedItem.Text;
            qfndCustomDDLPanel_MouseLeave(sender, e);
            contextMenuOpened = false;
        }
        private void qfndCustomDDLContextMenuStrip_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            qfndCustomDDLPanel_Leave(sender, e);
            preventDropDownReopen.Enabled = true;
        }
        //
        // view choice
        private void vcCustomDDLBtns_MouseDown(object sender, MouseEventArgs e)
        {
            if (contextMenuOpened)
            {
                vcCustomDDLPanel_Leave(sender, e);
                contextMenuOpened = false;
                return;
            }

            imgToUse = img2;
            vcCustomDDLPanel_Enter(sender, e);

            // specific to each DDL
            vcCustomDDLMenuStrip.Show(vcOuterPanel, new Point(-1, vcOuterPanel.Height - 2));
        }
        private void vcCustomDDLPanel_Enter(object sender, EventArgs e)
        {
            vcCustomDDLPanel_MouseHover(sender, e);

            vcOuterPanel.MouseLeave -= vcCustomDDLPanel_MouseLeave;
            vcSelectionBtn.MouseLeave -= vcCustomDDLPanel_MouseLeave;
            vcDropBtn.MouseLeave -= vcCustomDDLPanel_MouseLeave;

            // specific to each DDL
            vcCustomDDLMenuStrip.MouseLeave -= vcCustomDDLPanel_MouseLeave;
        }
        private void vcCustomDDLPanel_MouseHover(object sender, EventArgs e)
        {
            // mouse over effect
            vcSelectionBtn.BackColor = Color.FromArgb(40, 40, 40);
            vcSplitPanel.Visible = true;
            vcDropBtn.BackgroundImage = imgToUse;
        }
        private void vcCustomDDLPanel_MouseLeave(object sender, EventArgs e)
        {
            // mouse off effect
            vcSelectionBtn.BackColor = Color.FromArgb(27, 27, 27);
            vcSplitPanel.Visible = false;
            vcDropBtn.BackgroundImage = CertusCompanion.Properties.Resources.icons8_sort_down_24__7_;
            imgToUse = img;
        }
        private void vcCustomDDLPanel_MouseMove(object sender, MouseEventArgs e)
        {
            vcCustomDDLPanel_MouseHover(sender, e);
        }
        private void vcCustomDDLPanel_Leave(object sender, EventArgs e)
        {
            vcOuterPanel.MouseLeave += vcCustomDDLPanel_MouseLeave;
            vcDropBtn.MouseLeave += vcCustomDDLPanel_MouseLeave;
            vcSelectionBtn.MouseLeave += vcCustomDDLPanel_MouseLeave;

            // specific to each DDL
            vcCustomDDLMenuStrip.MouseLeave += vcCustomDDLPanel_MouseLeave;

            vcCustomDDLPanel_MouseLeave(sender, e);
        }
        private void vcCustomDDLContextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            vcSelectionBtn.Text = e.ClickedItem.Text;
            vcCustomDDLPanel_MouseLeave(sender, e);
            contextMenuOpened = false;
        }
        private void vcCustomDDLContextMenuStrip_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            vcCustomDDLPanel_Leave(sender, e);
            preventDropDownReopen.Enabled = true;
        }
        //
        // client
        private void clCustomDDLBtns_MouseDown(object sender, MouseEventArgs e)
        {
            if (contextMenuOpened)
            {
                clCustomDDLPanel_Leave(sender, e);
                contextMenuOpened = false;
                return;
            }

            imgToUse = img2;
            clCustomDDLPanel_Enter(sender, e);

            // specific to each DDL
            clCustomDDLMenuStrip.Show(clOuterPanel, new Point(-1, clOuterPanel.Height - 2));
        }
        private void clCustomDDLPanel_Enter(object sender, EventArgs e)
        {
            clCustomDDLPanel_MouseHover(sender, e);

            clOuterPanel.MouseLeave -= clCustomDDLPanel_MouseLeave;
            clSelectionBtn.MouseLeave -= clCustomDDLPanel_MouseLeave;
            clDropBtn.MouseLeave -= clCustomDDLPanel_MouseLeave;

            // specific to each DDL
            clCustomDDLMenuStrip.MouseLeave -= clCustomDDLPanel_MouseLeave;
        }
        private void clCustomDDLPanel_MouseHover(object sender, EventArgs e)
        {
            // mouse over effect
            clSelectionBtn.BackColor = Color.FromArgb(40, 40, 40);
            clSplitPanel.Visible = true;
            clDropBtn.BackgroundImage = imgToUse;
        }
        private void clCustomDDLPanel_MouseLeave(object sender, EventArgs e)
        {
            // mouse off effect
            clSelectionBtn.BackColor = Color.FromArgb(27, 27, 27);
            clSplitPanel.Visible = false;
            clDropBtn.BackgroundImage = CertusCompanion.Properties.Resources.icons8_sort_down_24__7_;
            imgToUse = img;
        }
        private void clCustomDDLPanel_MouseMove(object sender, MouseEventArgs e)
        {
            clCustomDDLPanel_MouseHover(sender, e);
        }
        private void clCustomDDLPanel_Leave(object sender, EventArgs e)
        {
            clOuterPanel.MouseLeave += clCustomDDLPanel_MouseLeave;
            clDropBtn.MouseLeave += clCustomDDLPanel_MouseLeave;
            clSelectionBtn.MouseLeave += clCustomDDLPanel_MouseLeave;

            // specific to each DDL
            clCustomDDLMenuStrip.MouseLeave += clCustomDDLPanel_MouseLeave;

            clCustomDDLPanel_MouseLeave(sender, e);
        }
        private void clCustomDDLContextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            clSelectionBtn.Text = String.Empty;
            clSelectionBtn.Text = e.ClickedItem.Text;
            clCustomDDLPanel_MouseLeave(sender, e);
            contextMenuOpened = false;
        }
        private void clCustomDDLContextMenuStrip_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            clCustomDDLPanel_Leave(sender, e);
            preventDropDownReopen.Enabled = true;
        }
        #endregion

        // ----- PULL/EDIT DATA ----- //
        #region Pull/Edit Data
        private ListViewItem GetListViewItemFromWorkFlowItem(WorkflowItem item)
        {
            WorkflowItem wfItem = item;
            ListViewItem lvItem = new ListViewItem();

            // ...

            return lvItem;
        }
        private void UpdateAllLoadedWorkflowItems(WorkflowItem itemToUpdate)
        {
            var tmpItem = AllWorkflowItemsLoaded.First(i => i.DocumentWorkflowItemID == itemToUpdate.DocumentWorkflowItemID);
            int index = AllWorkflowItemsLoaded.IndexOf(tmpItem as WorkflowItem);

            this.AllWorkflowItemsLoaded[index] = itemToUpdate;
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
            return GetWorkflowItemFromCurrentViewByID(item.SubItems[1].Text);
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
        #endregion

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
            else if (assignedToDescLbl.Text == ">>>> Company Analyst:")
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

            if (wi.Excluded == true) itemExcludedBtn.Visible = true;
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
        private void PopulateImportLbx(List<Import> imports)
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
        private void PopulateImportViewData(Import itemImport)
        {
            if (itemImport is CSVImport)
            {
                this.importDateTbx.Text = (itemImport as CSVImport).ImportDate.ToLongDateString();
                this.importFileNameTbx.Text = (itemImport as CSVImport).FileName;
                this.importTypeTbx.Text = (itemImport as CSVImport).ImportType;
                this.itemsOnImportTbx.Text = (itemImport as CSVImport).TotalItemsOnImport.Count.ToString();
                this.itemsAddedTbx.Text = (itemImport as CSVImport).ItemsAdded.Count.ToString();
                this.itemsUpdatedTbx.Text = (itemImport as CSVImport).ItemsUpdated.Count.ToString();
            }
            else if (itemImport is DBImport)
            {
                this.importDateTbx.Text = (itemImport as DBImport).ImportDate.ToLongDateString();
                this.importFileNameTbx.Text = (itemImport as DBImport).ImportName;
                this.importTypeTbx.Text = (itemImport as DBImport).ImportType;
                this.itemsOnImportTbx.Text = (itemImport as DBImport).TotalItemsOnImport.Count.ToString();
                this.itemsAddedTbx.Text = (itemImport as DBImport).ItemsAdded.Count.ToString();
                this.itemsUpdatedTbx.Text = (itemImport as DBImport).ItemsUpdated.Count.ToString();
            }
        }
        #endregion

        // ----- LONG PROCESS TASKS ----- //
        #region Long Process Tasks
        //
        // Load app data (Workspace)
        private void loadBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            workspacePathToLoad = e.Argument.ToString();

            // generate loading form
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

            this.AppSave.Load(fileName);
            this.loadBackgroundWorker.ReportProgress(10);

            try
            {
                this.AppData = AppSave.MostRecentSave;
                this.StoreAppDataToForm(AppData);
                this.loadBackgroundWorker.ReportProgress(10);
            }
            catch (Exception)
            {
                throw new AppDataLoadFailedException("Loading failed; could not load 'AppData'");
            }
            try
            {
                this.ItemImportsList = AppData.ItemImportsList;
                this.loadBackgroundWorker.ReportProgress(10);
            }
            catch (Exception)
            {
                throw new ItemImportsLoadFailedException("Loading failed; could not load 'ItemImports'");
            }
            try
            {
                this.ItemsCompletedReportsList = AppData.ItemsCompletedReportsList;
                this.loadBackgroundWorker.ReportProgress(10);
            }
            catch (Exception)
            {
                throw new ItemsCompletedReportsLoadFailedException("Loading failed; could not load 'ItemsCompletedReports'");
            }
            try
            {
                this.DataSources = AppData.DataSources;
                this.StoreDataSources();

                // ascertain connection btn status based on amount of sources
                if (DataSources.Count == 2) ConnectionBtnNoConnection();
                else if (DataSources.Count == 3) // count of 3 means there are clients
                {
                    PopulateMainFormStatic();
                    ConnectionBtnIncomplete();
                }
                else if (DataSources.Count > 3)
                { 
                    PopulateMainFormStatic();
                    PopulateMainFormDynamic();

                    // outdated if date is over a week ago
                    if (DataSources[3].LastUpdated.Value < DateTime.Now.AddDays(-7)) ConnectionBtnOutdated();
                    else ConnectionBtnGood();

                    // show client as DDL selection but don't generate any data
                    ignoreThisTextChange = true;
                    string clientName = DataSources[3].Name;
                    string clientID = (ClientsDataSource.Where(i => i.Name == clientName).FirstOrDefault() as Client).ClientID;
                    clSelectionBtn.Text = $"{clientName} <{clientID}>";
                }

                this.loadBackgroundWorker.ReportProgress(10);
            }
            catch (Exception)
            {
                throw new Exception("Loading failed; could not load 'DataSources'");
            }
            try
            {
                this.WorkflowItemDatabase = AppData.WorkflowItemDatabase;
                this.loadBackgroundWorker.ReportProgress(10);
            }
            catch (Exception)
            {
                throw new WorkflowItemDatabaseLoadFailedException("Loading failed; could not load 'WorkflowItemDatabase'");
            }
        }
        private void StoreDataSources()
        {
            // instantiate sources lists
            #region Instantiate
            ColorsDataSource = new List<string>();
            StatusesDataSource = new List<string>();
            ClientsDataSource = new List<Client>();
            CompaniesSubSource = new List<Company>();
            CertificatesSubSource = new List<Certificate>();
            AnalystsSubSource = new List<Analyst>();
            ContactsSubSource = new List<Contact>();
            CertificateLocationsSubSource = new List<CertificateLocation>();
            LocationsSubSource = new List<Location>();
            #endregion

            if (DataSources == null || DataSources.Count == 0) return;
            int indx = 0;

            // colors
            foreach (var item in DataSources[indx].Items)
            {
                this.ColorsDataSource.Add(item as string);
            }
            ++indx;

            // statuses
            if (DataSources.Count <= indx) return;
            foreach (var item in DataSources[indx].Items)
            {
                this.StatusesDataSource.Add(item as string);
            }
            ++indx;

            // clients
            if (DataSources.Count <= indx) return;
            foreach (var item in DataSources[indx].Items)
            {
                this.ClientsDataSource.Add(item as Client);
            }
            ++indx;

            // companies
            if (DataSources.Count <= indx) return;
            foreach (var item in DataSources[indx].Items)
            {
                this.CompaniesSubSource.Add(item as Company);
            }
            ++indx;

            // certificates
            if (DataSources.Count <= indx) return;
            foreach (var item in DataSources[indx].Items)
            {
                this.CertificatesSubSource.Add(item as Certificate);
            }
            ++indx;

            // analysts
            if (DataSources.Count <= indx) return;
            foreach (var item in DataSources[indx].Items)
            {
                this.AnalystsSubSource.Add(item as Analyst);
            }
            ++indx;

            // contacts
            if (DataSources.Count <= indx) return;
            foreach (var item in DataSources[indx].Items)
            {
                this.ContactsSubSource.Add(item as Contact);
            }
            ++indx;

            // certificateLocations
            if (DataSources.Count <= indx) return;
            foreach (var item in DataSources[indx].Items)
            {
                this.CertificateLocationsSubSource.Add(item as CertificateLocation);
            }
            ++indx;

            // locations
            if (DataSources.Count <= indx) return;
            foreach (var item in DataSources[indx].Items)
            {
                this.LocationsSubSource.Add(item as Location);
            }
            ++indx;
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
                MessageBox.Show($"{e.Error.Message}", "Error");
                if (CheckIfFormIsOpened("Transparent Form"))
                    this.Invoke(new Action(() => { TransparentForm.Close(); }));
            }
            else
            {
                #region Save Loaded Workspace Info

                // set filePath
                loadedWorkspacePath = workspacePathToLoad;

                //get fileName from path
                char[] charArray = loadedWorkspacePath.ToCharArray();
                Array.Reverse(charArray);
                string revFileName = new string(charArray);
                int indx = revFileName.IndexOf(@"\");
                loadedWorkspaceFileName = loadedWorkspacePath.Substring(loadedWorkspacePath.Length - indx);

                #endregion

                // change save btn texts
                if (this.InvokeRequired) this.Invoke(new Action(() =>
                {
                    saveWorkspaceToolStripMenuItem.Text = $"Save {loadedWorkspaceFileName}";
                    saveAsToolStripMenuItem.Text = $"Save {loadedWorkspaceFileName} As...                    ";
                }));
                else
                {
                    saveWorkspaceToolStripMenuItem.Text = $"Save {loadedWorkspaceFileName}";
                    saveAsToolStripMenuItem.Text = $"Save {loadedWorkspaceFileName} As...                    ";
                }

                if (this.InvokeRequired) this.Invoke(new Action(() => { LoadingForm.ChangeLabel("Populating views"); }));
                else LoadingForm.ChangeLabel("Populating views");

                this.LoadingForm.Refresh();

                // populate lv  
                this.vcSelectionBtn.Text = "Non-completed";

                // enable clear
                this.clearWorkspaceToolStripMenuItem.Enabled = true;

                PopulateImportLbx(this.AllItemImportsLoaded);

                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() => { this.LoadingForm.CompleteProgress(); }));
                    this.Invoke(new Action(() => { this.LoadingForm.ChangeLabel("Data loaded successfully"); }));
                    this.Invoke(new Action(() => { this.loadingFormTimer.Enabled = true; }));
                }
                else
                {
                    this.LoadingForm.CompleteProgress();
                    this.LoadingForm.ChangeLabel("Data loaded successfully");
                    this.loadingFormTimer.Enabled = true;
                }
            }
        }
        //
        // Save App Data
        private void saveBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            string saveFileName;

            if (e.Argument is SaveFileDialog)
            {
                saveFileDialog = e.Argument as SaveFileDialog;
                workspacePathToSave = saveFileDialog.FileName;

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
            else
            {
                saveFileName = e.Argument.ToString();
                workspacePathToSave = e.Argument.ToString();

                if (this.InvokeRequired)
                    this.Invoke(new Action(() =>
                    {
                        SetStatusLabelAndTimer("Saving database items", true);
                        SaveAllWorkflowItemsLoadedToDB();
                        SaveItemImportsToItemImportsList();
                        SaveItemsCompletedReportsToItemsCompletedReportsList();

                        SetStatusLabelAndTimer("Storing app data", true);
                        SaveAppData(saveFileName);
                    }));
                else
                {
                    SetStatusLabelAndTimer("Saving database items", true);
                    SaveAllWorkflowItemsLoadedToDB();
                    SaveItemImportsToItemImportsList();
                    SaveItemsCompletedReportsToItemsCompletedReportsList();

                    SetStatusLabelAndTimer("Storing app data", true);
                    SaveAppData(saveFileName);
                }
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
            ItemsCompletedReportsList = new ItemsCompletedReports(AllItemsCompletedReportsLoaded);
        }
        private void SaveDataSources()
        {
            ItemsCompletedReportsList = new ItemsCompletedReports(AllItemsCompletedReportsLoaded);
        }
        private void SaveAppData(string file)
        {
            string fileName = file;

            AppData = new AppData(WorkflowItemDatabase, ItemImportsList, ItemsCompletedReportsList, DataSources);

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
                #region Save Saved Workspace Info

                // set filePath
                loadedWorkspacePath = workspacePathToSave;

                //get fileName from path
                char[] charArray = loadedWorkspacePath.ToCharArray();
                Array.Reverse(charArray);
                string revFileName = new string(charArray);
                int indx = revFileName.IndexOf(@"\");
                loadedWorkspaceFileName = loadedWorkspacePath.Substring(loadedWorkspacePath.Length - indx);

                #endregion

                // change save btn texts
                if (this.InvokeRequired) this.Invoke(new Action(() =>
                {
                    saveWorkspaceToolStripMenuItem.Text = $"Save {loadedWorkspaceFileName}";
                    saveAsToolStripMenuItem.Text = $"Save {loadedWorkspaceFileName} As...                    ";
                }));
                else
                {
                    saveWorkspaceToolStripMenuItem.Text = $"Save {loadedWorkspaceFileName}";
                    saveAsToolStripMenuItem.Text = $"Save {loadedWorkspaceFileName} As...                    ";
                }

                if (this.InvokeRequired) this.Invoke(new Action(() => { LoadingForm.ChangeLabel("Populating views"); }));
                else LoadingForm.ChangeLabel("Populating views");

                SetStatusLabelAndTimer("Save successful");
            }

            AllWorkflowItemsLoaded = WorkflowItemDatabase.ReturnAllItemsFromDatabase();
            if (this.vcSelectionBtn.Text == "All Workflow")
            {
                this.vcSelectionBtn.Text = "";
                this.vcSelectionBtn.Text = "All Workflow";
            }
            UseWaitCursor = false;
            Cursor.Current = Cursors.Default;
        }
        //
        // CSV Import
        private void importWorkflowCSVBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                ImportWorkflowCSV(e.Argument as OpenFileDialog);
            }
            catch (Exception m)
            {
                MessageBox.Show("Something went wrong with the import.\n\nReason " + m.Message);
            }
        }
        private void ImportWorkflowCSV(OpenFileDialog ofd)
        {
            OpenFileDialog openFileDialog = ofd;
            importFilesSelected = openFileDialog.FileNames.Count();
            DimForm();
            LoadingForm = new LoadingForm();

            if (TransparentForm.InvokeRequired) TransparentForm.Invoke(new Action(() => { LoadingForm.Show(TransparentForm); }));
            else LoadingForm.Show(TransparentForm);

            for (int i = 0; i < importFilesSelected; i++)
            {
                importFileName = openFileDialog.FileNames[i];

                CSVImport import = new CSVImport();

                //SetStatusLabelAndTimer($"Importing file {importFileBeingWorkedOn} of {importFilesSelected}", true);
                if (this.InvokeRequired) this.Invoke(new Action(() => { LoadingForm.ChangeLabel($"Importing file {i + 1} of {importFilesSelected}"); LoadingForm.Refresh(); }));
                else
                {
                    LoadingForm.ChangeLabel($"Importing file {i + 1} of {importFilesSelected}");
                    LoadingForm.Refresh();
                }

                // import the file
                import.InitiateWorkflowImport(importFileName);

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

                // save this import
                AllItemImportsLoaded.Add(import.ReturnCSVImport());

                // add to AllWorkflowItemsLoaded - will report progress within the method
                AddItemsToAllWorkflowItemsLoaded(importFileName, import.ReturnWorkflowItems(), importFilesSelected * 2);

                // set non completed items list
                SetNonCompletedItemsList();
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
                this.vcSelectionBtn.Text = "Non-completed";

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
            string csvLine = "";
            Certificate certificateToImport;
            Boolean parsedBoolValue;
            DateTime parsedDateTimeValue;
            //int fileOn = 0;

#region Instantiate Acceptable Headers and Indexes List
            List<Tuple<int, string>> acceptableHeaderValuesAndTheirIndexes = new List<Tuple<int, string>>();

            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "BCS Certificate ID"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Certificate ID")); // same as above
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Certificate Name"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Certificate Identity Field"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Identity Field")); // same as above
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Contract ID")); // same as above
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Company Name"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "BCS Company ID"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Company ID")); // same as above
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Client ID"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Ins. Req. Category"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Issue Date"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Next Policy Expiration Date"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Certificate Active"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Certificate Compliant"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Back To Client Status"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Buildings"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Certificate Last Note Date"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Client"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Market"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Service Type"));
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
                this.Invoke(new Action(() => { LoadingForm.ChangeLabel("Importing certificates..."); }));
                this.Invoke(new Action(() => { LoadingForm.Refresh(); }));
            }
            else
            {
                LoadingForm.ChangeLabel("Importing certificates...");
                LoadingForm.Refresh();
            }
#endregion Set Up Loading Form

            // Opens the csv file for reading
            using (StreamReader sr = new StreamReader(importFileName))
            {
                // save file length data for reporting progress
                Stream baseStream = sr.BaseStream;
                long length = baseStream.Length;

#region Save Header
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
                    for (int j = 0; j < acceptableHeaderValuesAndTheirIndexes.Count; j++)
                    {
                        string csvHeaderValForComparison = new String(csvFileHeaderValues[i].Where(c => Char.IsLetter(c) || Char.IsNumber(c)).ToArray()).ToLower();
                        string accHeaderValForComparison = new String(acceptableHeaderValuesAndTheirIndexes[j].Item2.Where(c => Char.IsLetter(c) || Char.IsNumber(c)).ToArray()).ToLower();

                        if (csvHeaderValForComparison == (accHeaderValForComparison))
                        {
                            // save new tuple which contains the correct index location for the header 
                            Tuple<int, string> newTuple;
                            int index = acceptableHeaderValuesAndTheirIndexes.IndexOf(acceptableHeaderValuesAndTheirIndexes[j]);
                            string accHeader = acceptableHeaderValuesAndTheirIndexes[j].Item2;
                            newTuple = new Tuple<int, string>(i, accHeader);

                            // replace old tuple with the new one
                            acceptableHeaderValuesAndTheirIndexes[index] = newTuple;
                        }
                    }
                }

                // right now, return if BCS ID and Certificate Name are not in their correct places
                if (acceptableHeaderValuesAndTheirIndexes[0].Item1 != 0 && acceptableHeaderValuesAndTheirIndexes[1].Item1 != 1)
                {
                    throw new CertificateImportNotCorrectFormatException("CSV file is not recognized as an acceptable Certificate Export. BCS Certificate ID must be in the first column followed by the Certificate Name in the second column.");
                }
#endregion Save Header

                // instantiate data if CSV header is an acceptable format
                AllCertificatesLoaded = new List<Certificate>();
                CertificateDictionary = new Dictionary<string, Certificate>();

                // Read the rest of the csv line by line
                while ((csvLine = sr.ReadLine()) != null)
                {
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

#region Read And Store Data Per Line

                    // --- BCS Certificate ID --- //
                    int indx = 0;
                    string bcsCertificateID = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];

                    // --- Certificate ID --- // (same as above)
                    ++indx;
                    if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                        bcsCertificateID = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];

                    // --- Certificate Name --- //
                    ++indx;
                    string certificateName = "";
                    if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                        certificateName = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];

                    // --- Certificate Identity Field --- //
                    ++indx;
                    string certificateIdentityField = "";
                    if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                        certificateIdentityField = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];

                    // --- Identity Field --- // (same as above)
                    ++indx;
                    if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                        certificateIdentityField = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];

                    // --- Contract ID --- // (same as above)
                    ++indx;
                    if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                        certificateIdentityField = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];

                    // --- Company Name --- //
                    ++indx;
                    string companyName = "";
                    if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                        companyName = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];

                    // --- BCS Company ID --- //
                    ++indx;
                    string bcsCompanyID = "";
                    if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                        bcsCompanyID = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];

                    // --- Company ID --- // (same as above)
                    ++indx;
                    if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                        bcsCompanyID = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];

                    // --- Client ID --- //
                    ++indx;
                    string clientID = "";
                    if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                        clientID = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];

                    // --- Ins Req Category --- //
                    ++indx;
                    string insReqCategory = "";
                    if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                        insReqCategory = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];

                    // --- Issue Date --- //
                    ++indx;
                    DateTime? issueDate = null;
                    if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                    {
                        if (DateTime.TryParse(result[acceptableHeaderValuesAndTheirIndexes[indx].Item1], out parsedDateTimeValue)) issueDate = parsedDateTimeValue;
                        else issueDate = null;
                    }

                    // --- Next Policy Expiration --- //
                    ++indx;
                    DateTime? nextPolicyExpirationDate = null;
                    if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                    {
                        if (DateTime.TryParse(result[acceptableHeaderValuesAndTheirIndexes[indx].Item1], out parsedDateTimeValue)) nextPolicyExpirationDate = parsedDateTimeValue;
                        else nextPolicyExpirationDate = null;
                    }

                    // --- Certificate Active --- //
                    ++indx;
                    bool? certificateActive = null;
                    if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                    {
                        if (Boolean.TryParse(result[acceptableHeaderValuesAndTheirIndexes[indx].Item1], out parsedBoolValue))
                        {
                            if (parsedBoolValue) certificateActive = parsedBoolValue;
                            else certificateActive = parsedBoolValue;
                        }
                        else certificateActive = null;
                    }

                    // --- Certificate Compliant --- //
                    ++indx;
                    bool? certificateCompliant = null;
                    if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                    {
                        if (Boolean.TryParse(result[acceptableHeaderValuesAndTheirIndexes[indx].Item1], out parsedBoolValue))
                        {
                            if (parsedBoolValue) certificateCompliant = parsedBoolValue;
                            else certificateCompliant = parsedBoolValue;
                        }
                        else certificateCompliant = null;
                    }

                    // --- Back to Client Status --- //
                    ++indx;
                    string backToClientStatus = "";
                    if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                        backToClientStatus = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];

                    // --- Buildings --- //
                    ++indx;
                    string buildings = "";
                    if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                        buildings = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];

                    // --- Certificate Last Note Date --- //
                    ++indx;
                    DateTime? lastNoteDate = null;
                    if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                    {
                        if (DateTime.TryParse(result[acceptableHeaderValuesAndTheirIndexes[indx].Item1], out parsedDateTimeValue)) lastNoteDate = parsedDateTimeValue;
                        else issueDate = null;
                    }

                    // --- Source --- //
                    ++indx;
                    string source = "";
                    if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                        source = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];

                    // --- market --- //
                    ++indx;
                    string market = "";
                    if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                        market = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];

                    // --- Service Type --- //
                    ++indx;
                    string serviceType = "";
                    if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                        serviceType = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];

                    // construct the certificate from the line item and whatever was extracted
                    certificateToImport = new Certificate(bcsCertificateID, certificateName, certificateIdentityField, companyName, bcsCompanyID, clientID, insReqCategory, issueDate, nextPolicyExpirationDate, certificateActive, certificateCompliant, backToClientStatus, buildings, lastNoteDate, source, market, serviceType);

                    // add to certificates list IF NOT THERE
                    if (!this.CertificateDictionary.ContainsKey(certificateToImport.CertificateName))
                    {
                        this.AllCertificatesLoaded.Add(certificateToImport);
                        this.CertificateDictionary.Add(certificateToImport.CertificateName, certificateToImport);
                    }

#endregion Read And Store Data Per Line

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
                        if (CertificateDictionary.ContainsKey(wi.ContractID))
                        {
                            // get this contract
                            contract = CertificateDictionary[wi.ContractID];

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
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Company ID")); // same as above
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Company Name"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Client ID"));
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
                        string csvHeaderValForComparison = new String(csvFileHeaderValues[i].Where(c => Char.IsLetter(c) || Char.IsNumber(c)).ToArray()).ToLower();
                        string accHeaderValForComparison = new String(acceptableHeaderValuesAndTheirIndexes[j].Item2.Where(c => Char.IsLetter(c) || Char.IsNumber(c)).ToArray()).ToLower();

                        // has to be starts with otherwise contacts will not be picked up
                        if (csvHeaderValForComparison.StartsWith(accHeaderValForComparison))
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

                            break;
                        }
                    }
                }

                // right now, return if BCS id and Company Name are not in their correct places
                if (acceptableHeaderValuesAndTheirIndexes[0].Item1 != 0 && acceptableHeaderValuesAndTheirIndexes[1].Item1 != 1)
                {
                    throw new CompanyImportNotCorrectFormatException("CSV file is not recognized as an acceptable Company Export. BCS Company ID must be in the first column followed by the Company Name in the second column.");
                }
                #endregion Save Header

                // instantiate data if CSV header is an acceptable format
                AllCompaniesLoaded = new List<Company>();
                CompanyDictionary = new Dictionary<string, Company>();
                CompanyNameDictionary = new Dictionary<string, string>();
                CompanyContactDictionary = new Dictionary<string, List<Contact>>();

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

                    #region Read And Store Data Per Line

                    // BCS Company ID has to be there and has to be first***
                    int indx = 0;
                    string bcsCompanyID = "";
                    bcsCompanyID = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];
                    if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 >= 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                    {
                        bcsCompanyID = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];
                    }

                    // --- Company ID --- // (same as above)
                    ++indx;
                    if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 >= 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                    {
                        bcsCompanyID = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];
                    }

                    if (bcsCompanyID == null || bcsCompanyID == String.Empty) throw new Exception("BCS Company ID must be in the first column.");

                    // Company Name has to be second
                    indx++;
                    string companyName = "";
                    if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                    {
                        companyName = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];
                    }

                    if (companyName == null || companyName == String.Empty) throw new Exception("Company Name must be in the second column.");

                    indx++;
                    string clientID = "";
                    if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                    {
                        clientID = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];
                    }

                    // for the rest, let the default data populate if index wasn't found (-1), the result values aren't this long, or the result value is null
                    indx++;
                    string vendorID = "";
                    if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                    {
                        vendorID = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];
                    }

                    indx++;
                    string dba = "";
                    if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                    {
                        dba = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];
                    }

                    indx++;
                    string address1 = "";
                    if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                    {
                        address1 = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];
                    }

                    indx++;
                    string address2 = "";
                    if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                    {
                        address2 = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];
                    }

                    indx++;
                    string city = "";
                    if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                    {
                        city = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];
                    }

                    indx++;
                    string state = "";
                    if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                    {
                        state = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];
                    }

                    indx++;
                    string zip = "";
                    if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                    {
                        zip = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];
                    }

                    indx++;
                    string country = "";
                    if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                    {
                        country = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];
                    }

                    indx++;
                    string phone = "";
                    if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                    {
                        phone = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];
                    }

                    indx++;
                    string emailAddress = "";
                    if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                    {
                        emailAddress = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];
                    }

                    indx++;
                    bool? companyActive = null;
                    if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                    {
                        if (Boolean.TryParse(result[acceptableHeaderValuesAndTheirIndexes[indx].Item1], out parsedBoolValue))
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

                    indx++;
                    string companyComplianceLevel = "";
                    if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                    {
                        companyComplianceLevel = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];
                    }

                    indx++;
                    string analyst = "";
                    if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                    {
                        analyst = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];
                    }

                    indx++;
                    string companyLastNoteDate = "";
                    if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                    {
                        companyLastNoteDate = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];
                    }

                    // for each contact, instantiate contacts
                    List<Contact> contacts = new List<Contact>();

                    indx++;
                    Contact mainContact = new Contact();
                    if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                    {
                        mainContact.Name = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];
                        mainContact.Title = result[(acceptableHeaderValuesAndTheirIndexes[indx].Item1) + 1];
                        //mainContact.Phone = result[(acceptableHeaderValuesAndTheirIndexes[indx].Item1) + 2];
                        mainContact.Email = result[(acceptableHeaderValuesAndTheirIndexes[indx].Item1) + 3];

                        if (mainContact.Name != String.Empty) contacts.Add(mainContact);
                    }

                    indx++;
                    if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                    {
                        int index = acceptableHeaderValuesAndTheirIndexes[indx].Item1; // should be 17?

                        while (result[index] != null && result[index] != String.Empty)
                        {
                            Contact otherContact = new Contact();

                            otherContact.Name = result[index];
                            otherContact.Title = result[++index];
                            //otherContact.Phone = result[++index];
                            ++index;
                            otherContact.Email = result[++index];

                            ++index;

                            contacts.Add(otherContact);
                        }
                    }

                    // construct the company from the line item and whatever was extracted
                    companyToImport = new Company(companyName, bcsCompanyID, clientID, vendorID, dba, address1, address2, city, state,
                        zip, country, phone, emailAddress, companyActive, companyComplianceLevel, analyst, companyLastNoteDate,
                        contacts);

                    // add to lists
                    this.AllCompaniesLoaded.Add(companyToImport);
                    this.CompanyDictionary.Add(companyToImport.BcsCompanyID, companyToImport);
                    this.CompanyNameDictionary.Add(companyToImport.BcsCompanyID, companyToImport.CompanyName);
                    this.CompanyContactDictionary.Add(companyToImport.BcsCompanyID, companyToImport.Contacts);
                    //this.companyNameHashSet.Add(companyToImport.CompanyName);

                    #endregion Read And Store Data Per Line

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
        //
        // DB Import
        private void importFromDBBackGroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            ImportWorkflowItemsFromDB();
        }
        private void ImportWorkflowItemsFromDB()
        {
            DimForm();
            LoadingForm = new LoadingForm();

            if (TransparentForm.InvokeRequired) TransparentForm.Invoke(new Action(() => { LoadingForm.Show(TransparentForm); }));
            else LoadingForm.Show(TransparentForm);

            if (this.InvokeRequired) this.Invoke(new Action(() => 
            {
                LoadingForm.ChangeLabel($"Establishing DB Connection...");
                LoadingForm.ShowCloseBtn("Close");
                LoadingForm.Refresh();
            }));
            else
            {
                LoadingForm.ChangeLabel($"Establishing DB Connection...");
                LoadingForm.ShowCloseBtn("Close");
                LoadingForm.Refresh();
            }

            DBImport import = new DBImport();
            import.InitiateWorkflowImport(ImportFromDBForm.ClientIDSelection, ImportFromDBForm.WorkflowItemsSelection, ImportFromDBForm.WorkflowItemsAmount);

            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => 
                {
                    importWorkflowItemsBackgroundWorker.ReportProgress(50);
                    LoadingForm.ChangeLabel("Adding imported items to the current list"); 
                    LoadingForm.Refresh();
                }));
            }
            else
            {
                importWorkflowItemsBackgroundWorker.ReportProgress(50);
                LoadingForm.ChangeLabel("Adding imported items to the current list");
                LoadingForm.Refresh();
            }

            // save import
            AllItemImportsLoaded.Add(import.ReturnDBImport());

            // add to AllWorkflowItemsLoaded - will report progress within the method
            AddItemsToAllWorkflowItemsLoaded($"{import.ImportType} - {import.ImportDate}", import.ReturnWorkflowItems());

            // set non completed items list
            SetNonCompletedItemsList();
        }
        private void importFromDBBackGroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                SetStatusLabelAndTimer("Operation was canceled");
                MakeErrorSound();
            }
            else if (e.Error != null)
            {
                if (this.InvokeRequired) this.Invoke(new Action(() =>
                {
                    this.LoadingForm.ShowCloseBtn();
                    this.LoadingForm.HideBar();
                    this.LoadingForm.ChangeHeaderLabel("Import Unsuccessful");
                    this.LoadingForm.ChangeLabel($"{e.Error.Message}");
                    this.LoadingForm.Refresh();
                }));
                else
                {
                    this.LoadingForm.ShowCloseBtn();
                    this.LoadingForm.HideBar();
                    this.LoadingForm.ChangeHeaderLabel("Import Unsuccessful");
                    this.LoadingForm.ChangeLabel($"{e.Error.Message}");
                    this.LoadingForm.Refresh();
                }

                MessageBox.Show($"Data generation unsuccessful\n\n{e.Error.Message}", "Error");

                if (CheckIfFormIsOpened("Transparent Form")) this.TransparentForm.Close();
                ResetStatusStrip();
            }
            else
            {
                // populate lv
                this.vcSelectionBtn.Text = "Non-completed";

                // populate lbx
                PopulateImportLbx(this.AllItemImportsLoaded);

                //SetStatusLabelAndTimer("Import successful");
                if (this.InvokeRequired) this.Invoke(new Action(() =>
                {
                    this.LoadingForm.ShowCloseBtn();
                    this.LoadingForm.CompleteProgress();
                    this.LoadingForm.ChangeLabel("Items imported successfully");
                    this.LoadingForm.Refresh();
                }));
                else
                {
                    this.LoadingForm.ShowCloseBtn();
                    this.LoadingForm.CompleteProgress();
                    this.LoadingForm.ChangeLabel("Items imported successfully");
                    this.LoadingForm.Refresh();
                }
            }

            EnableWFDataOptions();
            UseWaitCursor = false;
        }
        //
        // LINQ Query
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
        //
        // Update workflow item data
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
                LoadingForm.ChangeLabel("Finishing putting the updated list of items together");
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
        //
        // Fill workflow item data 
        private void appendCompanyBackgroundWorker_DoWork(object sender, DoWorkEventArgs e) //*
        {
            try
            {
                this.Invoke(new Action(() =>
                {

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
        private void appendContractInformationBackgroundWorker_DoWork(object sender, DoWorkEventArgs e) //*
        {
            try
            {
                this.Invoke(new Action(() =>
                {

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
        private void appendAssignedAndStatusBackgroundWorker_DoWork(object sender, DoWorkEventArgs e) //*
        {
            try
            {
                this.Invoke(new Action(() =>
                {

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
                        if (status != String.Empty && assignedTo != String.Empty)
                        {
                            // change this item
                            if (wi.Status != status && wi.AssignedToName != assignedTo)
                            {
                                wi.Status = status;
                                wi.AssignedToName = assignedTo;
                                if(AnalystsSubSource.Any(i=>i.Name==assignedTo))
                                    wi.AssignedToID = (AnalystsSubSource.Where(i => i.Name == assignedTo).FirstOrDefault() as Analyst).SystemUserID;

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
                                if (AnalystsSubSource.Any(i => i.Name == assignedTo))
                                    wi.AssignedToID = (AnalystsSubSource.Where(i => i.Name == assignedTo).FirstOrDefault() as Analyst).SystemUserID;

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
        private void appendAssignedBackgroundWorker_DoWork(object sender, DoWorkEventArgs e) //*
        {
            try
            {
                this.Invoke(new Action(() =>
                {

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
                                if (AnalystsSubSource.Any(i => i.Name == assignedTo))
                                    wi.AssignedToID = (AnalystsSubSource.Where(i => i.Name == assignedTo).FirstOrDefault() as Analyst).SystemUserID;

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
        private void appendDataBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) //*
        {
            if (e.Cancelled == true)
            {
                SetStatusLabelAndTimer("Operation was canceled");
                MakeErrorSound();
            }
            else if (e.Error != null)
            {
                MessageBox.Show($"Data appending unsuccessful\n\n{e.Error.Message}", "Error");
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
        //
        // Find workflow item data
        private void setAnalystFromCompanyBackgroundWorker_DoWork(object sender, DoWorkEventArgs e) //*
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
                                else if (!CompanyNameDictionary.ContainsValue(wi.VendorName))
                        {
                            ++itemsWhereCompanyNotRecognized;
                            continue;
                        }
                                // company does exists, check further
                                else
                        {
                                    // if the company name is a value more than once in the dictionary
                                    if (CompanyNameDictionary.Count(i => i.Value == wi.VendorName) > 1)
                            {
                                List<string> companyIdsWhereValueIsSame = new List<string>();
                                List<Company> companiesToCheck = new List<Company>();
                                List<string> analystsToCheck = new List<string>();

                                        // get company ids where value occurs twice in compNameDic
                                        foreach (var keyValuePair in CompanyNameDictionary)
                                {
                                    if (keyValuePair.Value == wi.VendorName) companyIdsWhereValueIsSame.Add(keyValuePair.Key);
                                }

                                        // get companies from company ids out of the companyDic
                                        foreach (var companyId in companyIdsWhereValueIsSame)
                                {
                                    foreach (var keyValuePair in CompanyDictionary)
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
                                            if (wi.AssignedToName == analystsToCheck[0])
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

                                foreach (var keyValuePair in CompanyNameDictionary)
                                {
                                    if (keyValuePair.Value == wi.VendorName) companyId = keyValuePair.Key;
                                }

                                Company comp = CompanyDictionary[companyId];

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

                                            // attempting to set the ID as well
                                            if (AnalystsSubSource.Any(i => i.Name == wi.AssignedToName))
                                        wi.AssignedToID = (AnalystsSubSource.Where(i => i.Name == wi.AssignedToName).FirstOrDefault() as Analyst).SystemUserID;

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
        private void setAnalystFromCompanyBackgroundWork_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) //*
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
        private void setAnalystFromMarketBackgroundWorker_DoWork(object sender, DoWorkEventArgs e) //*
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
                        else if (!CompanyNameDictionary.ContainsValue(wi.VendorName))
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
                            foreach (var keyValuePair in CompanyNameDictionary)
                            {
                                if (keyValuePair.Value == wi.VendorName) companyIdsWhereValueIsSame.Add(keyValuePair.Key);
                            }

                            // get companies from company ids out of the companyDic
                            foreach (var companyId in companyIdsWhereValueIsSame)
                            {
                                foreach (var keyValuePair in CompanyDictionary)
                                {
                                    if (keyValuePair.Key == companyId) companiesToCheck.Add(keyValuePair.Value);
                                }
                            }

                            // determine if a market can be found
                            foreach (Company com in companiesToCheck)
                            {
                                if (MarketAssignments.ContainsKey(com.City))
                                {
                                    marketsToCheck.Add(com.City);
                                    continue;
                                }
                                else if (MarketAssignments.ContainsKey(com.State))
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

                            if (marketsToCheck == null || marketsToCheck.Count == 0)
                            {
                                ++itemsWhereMarketNotFound;
                                continue;
                            }
                            else // market is found
                            {
                                market = marketsToCheck[0];
                                string analyst = MarketAssignments[market];
                                if (wi.AssignedToName != analyst)
                                {
                                    wi.AssignedToName = analyst;
                                    if (AnalystsSubSource.Any(i => i.Name == analyst))
                                        wi.AssignedToID = (AnalystsSubSource.Where(i => i.Name == analyst).FirstOrDefault() as Analyst).SystemUserID;
                                }
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
        private void setAnalystFromMarketBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) //*
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
                else if (!CertificateDictionary.ContainsKey(wi.ContractID))
                {
                    ++itemsWhereContractUnrecognized;
                    continue;
                }
                // contract does exists, check further
                else
                {
                    Certificate cert = CertificateDictionary[wi.ContractID];
                    string companyID = cert.BcsCompanyID;

                    Company company = new Company();
                    if (CompanyDictionary.ContainsKey(companyID)) company = CompanyDictionary[companyID]; // not all companies were tied at this step...
                    else continue;

                    // analyst is not listed for the company
                    if (company.Analyst == null || company.Analyst == String.Empty || company.Analyst == "Richard Ellis")
                    {
                        ++itemsWhereCompanyHadNoAnalyst;
                        continue;
                    }
                    else
                    {
                        // analyst is already assigned
                        if (wi.AssignedToName == company.Analyst)
                        {
                            ++itemsAlreadyCorrectlyAssigned;
                            continue;
                        }
                        // item gets assigned successfully
                        else
                        {
                            wi.AssignedToName = company.Analyst;
                            if (AnalystsSubSource.Any(i => i.Name == company.Analyst))
                                wi.AssignedToID = (AnalystsSubSource.Where(i => i.Name == company.Analyst).FirstOrDefault() as Analyst).SystemUserID;
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

                foreach (string companyName in CompanyNameDictionary.Values)
                {
                    string companyWithOnlyLettersAndNumbers = new String(companyName.Where(c => Char.IsLetter(c) || Char.IsNumber(c)).ToArray());

                    if (subjectWithOnlyLettersAndNumbers.ToLower().Contains(companyWithOnlyLettersAndNumbers.ToLower())
                        //&& companyName.ToLower() != "" && companyName.ToLower() != "west" && companyName.ToLower() != "arc" && companyName.ToLower() != "dsi")
                        && companyName.Count() > 4)
                    {
                        if (wi.VendorName.ToLower() != companyName.ToLower())
                        {
                            companiesToSettleOn.Add(companyName);
                        }
                    }
                }

                if (companiesToSettleOn != null && companiesToSettleOn.Count > 0)
                {
                    companySettledOn = companiesToSettleOn.Aggregate("", (max, cur) => max.Length > cur.Length ? max : cur);
                }

                if (companySettledOn != null && companySettledOn != String.Empty)
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
                        //ResetStatusStrip();
                        LoadingForm.Show(TransparentForm);
                        LoadingForm.ChangeHeaderLabel("Loading");
                        LoadingForm.ChangeLabel("Processing the request...");
                        LoadingForm.Refresh();
                    }));
                }
                else
                {
                    //ResetStatusStrip();
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


                foreach (var keyValuePair in CompanyContactDictionary)
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
                    companiesToCheck.Add(CompanyDictionary[id]);
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
        private void extractCompanyBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Application.UseWaitCursor = false;
            Application.DoEvents();

            if (e.Cancelled == true)
            {
                SetStatusLabelAndTimer("Operation was canceled");
                MakeErrorSound();
            }
            else if (e.Error != null)
            {
                MessageBox.Show("Operation unsuccessful\n\ne.Error.Message", "Error");
                if (CheckIfFormIsOpened("Transparent Form")) this.TransparentForm.Close();
                ResetStatusStrip();
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
        private void extractContractBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
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

            DimForm();

            // show loading form if more than 50 items
            if (checkedWorkflowItems.Count > 50)
            {
                if (TransparentForm.InvokeRequired)
                {
                    TransparentForm.Invoke(new Action(() =>
                    {
                        ResetStatusStrip();
                        LoadingForm.Show(TransparentForm);
                        LoadingForm.ChangeHeaderLabel("Loading");
                        LoadingForm.ChangeLabel("Processing the request...");
                        LoadingForm.Refresh();
                    }));
                }
                else
                {
                    ResetStatusStrip();
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

                foreach (var keyValuePair in CertificateDictionary)
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
                            if (wi.ContractID != keyValuePair.Key)
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
            Application.UseWaitCursor = false;
            Application.DoEvents();

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
                    ResetStatusStrip();
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
                            if (itemsUpdated > 0) this.SetStatusLabelAndTimer($"Contract(s) pulled for {contractsPulled} item(s). Company data updated for {itemsUpdated} item(s)", true);
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
                    if (CertificateDictionary.ContainsKey(wi.ContractID))
                    {
                        // get this contract
                        contract = CertificateDictionary[wi.ContractID];

                        // if any contract related info is different (including the companyName)
                        if (wi.VendorName != contract.CompanyName || wi.Active != contract.CertificateActive || wi.Active != contract.CertificateCompliant)
                        {
                            // update company only if not the same to preserve the indicator accuracy
                            if (wi.VendorName != contract.CompanyName)
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
        //
        // DB connection
        private void connectToDBBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            #region Loading form settup
            DimForm();
            LoadingForm = new LoadingForm();
            LoadingForm.Owner = this.TransparentForm;

            if (this.InvokeRequired) this.Invoke(new Action(() =>
            {
                LoadingForm.Show(this.TransparentForm);
                LoadingForm.ChangeLabel("Establishing DB Connection...");
                LoadingForm.ShowCloseBtn();
                LoadingForm.Refresh();
            }));
            else
            {
                LoadingForm.Show(this.TransparentForm);
                LoadingForm.ChangeLabel("Establishing DB Connection...");
                LoadingForm.ShowCloseBtn();
                LoadingForm.Refresh();
            }

            //this.Invoke(new Action(() => 
            //{
            //    LoadingForm.ChangeLabel("Establishing DB Connection...");
            //    LoadingForm.Refresh();
            //}));
            #endregion

            // establish DB connection
            string connectionString = ConfigurationManager.ConnectionStrings["CertusDB"].ToString();
            string query;

            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand command = conn.CreateCommand();

            // test the connection
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
            }

            // get static data (Clients)
            #region Clients
            this.Invoke(new Action(() => 
            {
                LoadingForm.ChangeLabel("Populating Data...");
                LoadingForm.HideCloseBtn();
                LoadingForm.Refresh();
            }));
            using (Stream strm = Assembly.GetExecutingAssembly().GetManifestResourceStream("CertusCompanion.ImportQueries.ClientDS.sql"))
            {
                using (StreamReader sr = new StreamReader(strm))
                {
                    query = sr.ReadToEnd();
                }
            }

            command.CommandText = query;
            command.CommandType = CommandType.Text;
            command.CommandTimeout = 450;

            SqlDataAdapter clAdapter = new SqlDataAdapter(command);

            DataTable clTable = new DataTable();
            clAdapter.Fill(clTable);

            foreach (DataRow row in clTable.Rows)
            {
                Client cl = new Client(row["ClientID"].ToString(), row["Name"].ToString());

                ClientsDataSource.Add(cl);

                if (this.InvokeRequired) this.Invoke(new Action(() => { LoadingForm.MoveBar(33); }));
                else LoadingForm.MoveBar(1);
            }

            DataSource clDs = new DataSource("ALL", "Clients", true);
            clDs.Items.AddRange(ClientsDataSource);
            DataSources.Add(clDs);
            #endregion

            conn.Close();
            PopulateMainFormStatic();
        }
        private void connectToDBBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                SetStatusLabelAndTimer("Operation was canceled");
                MakeErrorSound();
            }
            else if (e.Error != null)
            {
                MessageBox.Show($"Connection unsuccessful\n\n{e.Error.Message}", "Error");

                if (CheckIfFormIsOpened("Transparent Form")) this.TransparentForm.Close();
                ConnectionBtnNoConnection();
                ResetStatusStrip();
            }
            else
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        this.LoadingForm.CompleteProgress();
                        this.LoadingForm.ChangeLabel("Connection Successful");
                        this.LoadingForm.Refresh();
                        this.loadingFormTimer.Enabled = true;
                        this.SetStatusLabelAndTimer($"Connection Successful", true);
                        ConnectionBtnIncomplete();
                    }));
                }
                else
                {
                    this.LoadingForm.CompleteProgress();
                    this.LoadingForm.ChangeLabel("Connection Successful");
                    this.LoadingForm.Refresh();
                    this.loadingFormTimer.Enabled = true;
                    this.SetStatusLabelAndTimer($"Connection Successful", true);
                    ConnectionBtnIncomplete();
                }
            }
        }
        private void changeClientBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // called on client DDL btn text changed...
            //
            // make sure clients are there first (should always be if this handler is executing... check anyway)
            #region Check for Clients
            string clientID = e.Argument as string;
            if (ClientsDataSource == null || ClientsDataSource.Count == 0)
            {
                throw new Exception("The clients data source was missing or empty");
            }
            string clientName = (ClientsDataSource.Where(i => i.ClientID == clientID).FirstOrDefault() as Client).Name;
            #endregion

            // instantiate subsource lists
            #region Instantiate
            CompaniesSubSource = new List<Company>();
            CertificatesSubSource = new List<Certificate>();
            AnalystsSubSource = new List<Analyst>();
            ContactsSubSource = new List<Contact>();
            CertificateLocationsSubSource = new List<CertificateLocation>();
            LocationsSubSource = new List<Location>();
            DataSource ds;
            #endregion

            // set up the loading form
            #region Loading form settup
            DimForm();
            LoadingForm = new LoadingForm();
            LoadingForm.Owner = this.TransparentForm;

            if (this.InvokeRequired) this.Invoke(new Action(() =>
            {
                LoadingForm.Show(this.TransparentForm);
            }));
            else
            {
                LoadingForm.Show(this.TransparentForm);
            }

            this.Invoke(new Action(() => { LoadingForm.ChangeLabel("Connecting..."); }));
            this.Invoke(new Action(() => { LoadingForm.Refresh(); }));
            #endregion

            // retest DB connection
            #region TestConn
            string connectionString = ConfigurationManager.ConnectionStrings["CertusDB"].ToString();
            string query;

            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand command = conn.CreateCommand();
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
            }
            #endregion

            // remove any existing datasources after 3 (dynamic). First 3 will be static--colors, statuses, clients (static)
            if (DataSources.Count > 3)
            {
                while (DataSources.Count > 3)
                {
                    DataSources.RemoveAt(3);
                }
            }
            
            // populate subsources (dynamic)...
            //
            // --- COMPANIES --- //
            #region Companies
            ds = new DataSource();
            ds.Name = clientName;
            ds.Type = "Companies";
            ds.Binded = true;

            this.Invoke(new Action(() => { LoadingForm.ChangeLabel("Generating companies..."); }));
            this.Invoke(new Action(() => { LoadingForm.Refresh(); }));

            // connect to db, grab items for client id, add to subsource items list
            using (Stream strm = Assembly.GetExecutingAssembly().GetManifestResourceStream("CertusCompanion.ImportQueries.CompanyDS.sql"))
            {
                using (StreamReader sr = new StreamReader(strm))
                {
                    query = sr.ReadToEnd();
                }
            }

            // specifiy the client
            query += $"\nWHERE\t\tCO.ClientID = {clientID};";
            command.CommandText = query;
            command.CommandType = CommandType.Text;
            command.CommandTimeout = 450;

            SqlDataAdapter coAdapter = new SqlDataAdapter(command);

            DataTable coTable = new DataTable();
            coAdapter.Fill(coTable);

            // add to subsource
            foreach (DataRow row in coTable.Rows)
            {
                Company co = new Company(row["CompanyName"].ToString(), row["CompanyID"].ToString(), row["ClientID"].ToString());

                CompaniesSubSource.Add(co);
            }

            // add subsource items to ds items
            ds.Items.AddRange(CompaniesSubSource);
            DataSources.Add(ds);

            if (this.InvokeRequired) this.Invoke(new Action(() => { LoadingForm.MoveBar(20); }));
            else LoadingForm.MoveBar(20);
            #endregion

            // --- CERTIFICATES --- //
            #region Certificates
            ds = new DataSource();
            ds.Name = clientName;
            ds.Type = "Certificates";
            ds.Binded = true;

            this.Invoke(new Action(() => { LoadingForm.ChangeLabel("Generating certificates..."); }));
            this.Invoke(new Action(() => { LoadingForm.Refresh(); }));

            // connect to db, grab items for client id, add to subsource items list
            using (Stream strm = Assembly.GetExecutingAssembly().GetManifestResourceStream("CertusCompanion.ImportQueries.CompanyCertificateDS.sql"))
            {
                using (StreamReader sr = new StreamReader(strm))
                {
                    query = sr.ReadToEnd();
                }
            }

            // specifiy the client
            query += $"\nWHERE\t\tCL.ClientID = {clientID};";
            command.CommandText = query;
            command.CommandType = CommandType.Text;
            command.CommandTimeout = 450;

            SqlDataAdapter ctAdapter = new SqlDataAdapter(command);

            DataTable ctTable = new DataTable();
            ctAdapter.Fill(ctTable);

            // add to subsource
            foreach (DataRow row in ctTable.Rows)
            {
                Certificate ct = new Certificate(row["CompanyCertificateID"].ToString(), row["Name"].ToString(), row["IdentityField"].ToString(), row["ClientID"].ToString());

                CertificatesSubSource.Add(ct);
            }

            // add subsource items to ds items
            ds.Items.AddRange(CertificatesSubSource);
            DataSources.Add(ds);

            if (this.InvokeRequired) this.Invoke(new Action(() => { LoadingForm.MoveBar(20); }));
            else LoadingForm.MoveBar(20);
            #endregion

            // --- ANALYSTS --- //
            #region Analysts
            ds = new DataSource();
            ds.Name = clientName;
            ds.Type = "Analysts";
            ds.Binded = true;

            this.Invoke(new Action(() => { LoadingForm.ChangeLabel("Generating analysts..."); }));
            this.Invoke(new Action(() => { LoadingForm.Refresh(); }));

            // connect to db, grab items for client id, add to subsource items list
            using (Stream strm = Assembly.GetExecutingAssembly().GetManifestResourceStream("CertusCompanion.ImportQueries.SystemUserDS.sql"))
            {
                using (StreamReader sr = new StreamReader(strm))
                {
                    query = sr.ReadToEnd();
                }
            }

            // specifiy the client
            query += $"\nWHERE\t\tSU.DefaultClientID = {clientID};";
            command.CommandText = query;
            command.CommandType = CommandType.Text;
            command.CommandTimeout = 450;

            SqlDataAdapter anAdapter = new SqlDataAdapter(command);

            DataTable anTable = new DataTable();
            anAdapter.Fill(anTable);

            foreach (DataRow row in anTable.Rows)
            {
                Analyst an = new Analyst(row["SystemUserID"].ToString(), row["ClientID"].ToString(), row["Name"].ToString());

                AnalystsSubSource.Add(an);
            }

            // add subsource items to ds items
            ds.Items.AddRange(AnalystsSubSource);
            DataSources.Add(ds);

            if (this.InvokeRequired) this.Invoke(new Action(() => { LoadingForm.MoveBar(20); }));
            else LoadingForm.MoveBar(20);
            #endregion

            // --- CONTACTS --- //
            #region Contacts
            ds = new DataSource();
            ds.Name = clientName;
            ds.Type = "Contacts";
            ds.Binded = true;

            this.Invoke(new Action(() => { LoadingForm.ChangeLabel("Generating contacts..."); }));
            this.Invoke(new Action(() => { LoadingForm.Refresh(); }));

            // connect to db, grab items for client id, add to subsource items list
            using (Stream strm = Assembly.GetExecutingAssembly().GetManifestResourceStream("CertusCompanion.ImportQueries.ContactDS.sql"))
            {
                using (StreamReader sr = new StreamReader(strm))
                {
                    query = sr.ReadToEnd();
                }
            }

            // specifiy the client
            query += $"\nWHERE\t\t\tCO.ClientID = {clientID};";
            command.CommandText = query;
            command.CommandType = CommandType.Text;
            command.CommandTimeout = 450;

            SqlDataAdapter conAdapter = new SqlDataAdapter(command);

            DataTable conTable = new DataTable();
            conAdapter.Fill(conTable);

            foreach (DataRow row in conTable.Rows)
            {
                Contact con = new Contact(row["ContactID"].ToString(), row["Name"].ToString(), row["Title"].ToString(), row["EmailAddress"].ToString(), row["CompanyID"].ToString());

                ContactsSubSource.Add(con);
            }

            // add subsource items to ds items
            ds.Items.AddRange(ContactsSubSource);
            DataSources.Add(ds);

            if (this.InvokeRequired) this.Invoke(new Action(() => { LoadingForm.MoveBar(20); }));
            else LoadingForm.MoveBar(20);
            #endregion

            // --- CERTIFICATELOCATIONS --- //
            #region CertificateLocations
            ds = new DataSource();
            ds.Name = clientName;
            ds.Type = "CertificateLocations";
            ds.Binded = null;

            this.Invoke(new Action(() => { LoadingForm.ChangeLabel("Generating locations..."); }));
            this.Invoke(new Action(() => { LoadingForm.Refresh(); }));

            // connect to db, grab items for client id, add to subsource items list
            using (Stream strm = Assembly.GetExecutingAssembly().GetManifestResourceStream("CertusCompanion.ImportQueries.CertificateLocationDS.sql"))
            {
                using (StreamReader sr = new StreamReader(strm))
                {
                    query = sr.ReadToEnd();
                }
            }

            // specifiy the client
            query += $"\nWHERE\t\t\tC.ClientID = {clientID};";
            command.CommandText = query;
            command.CommandType = CommandType.Text;
            command.CommandTimeout = 450;

            SqlDataAdapter ctlAdapter = new SqlDataAdapter(command);

            DataTable ctlTable = new DataTable();
            ctlAdapter.Fill(ctlTable);

            foreach (DataRow row in ctlTable.Rows)
            {
                CertificateLocation ctl = new CertificateLocation(row["CertificateLocationID"].ToString(), row["CompanyCertificateID"].ToString(), row["LocationID"].ToString(), Convert.ToDateTime(row["DateCreated"]));

                CertificateLocationsSubSource.Add(ctl);
            }

            // add subsource items to ds items
            ds.Items.AddRange(CertificateLocationsSubSource);
            DataSources.Add(ds);
            #endregion

            // --- LOCATIONS --- //
            #region Locations

            ds = new DataSource();
            ds.Name = clientName;
            ds.Type = "Locations";
            ds.Binded = true;

            using (Stream strm = Assembly.GetExecutingAssembly().GetManifestResourceStream("CertusCompanion.ImportQueries.LocationDS.sql"))
            {
                using (StreamReader sr = new StreamReader(strm))
                {
                    query = sr.ReadToEnd();
                }
            }

            // specifiy the client
            query += $"\nWHERE\t\t\tL.ClientID = {clientID};";
            command.CommandText = query;
            command.CommandType = CommandType.Text;
            command.CommandTimeout = 450;

            SqlDataAdapter loAdapter = new SqlDataAdapter(command);

            DataTable loTable = new DataTable();
            loAdapter.Fill(loTable);

            foreach (DataRow row in loTable.Rows)
            {
                Location lo = new Location(row["LocationID"].ToString(), row["Name"].ToString(), row["Address1"].ToString(), row["Address2"].ToString());

                LocationsSubSource.Add(lo);
            }

            // close connection
            conn.Close();

            // add subsource items to ds items
            ds.Items.AddRange(LocationsSubSource);
            DataSources.Add(ds);

            if (this.InvokeRequired) this.Invoke(new Action(() => { LoadingForm.MoveBar(20); }));
            else LoadingForm.MoveBar(20);
            #endregion

            if(this.InvokeRequired) this.Invoke(new Action(() => 
            {
                LoadingForm.ChangeLabel("Populating sources...");
                LoadingForm.Refresh();
                PopulateMainFormDynamic();
            }));
            else
            {
                LoadingForm.ChangeLabel("Populating sources...");
                LoadingForm.Refresh();
                PopulateMainFormDynamic();
            }
        }
        private void changeClientBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                SetStatusLabelAndTimer("Operation was canceled");
                MakeErrorSound();
            }
            else if (e.Error != null)
            {
                MessageBox.Show($"Data generation unsuccessful\n\n{e.Error.Message}", "Error");

                if (CheckIfFormIsOpened("Transparent Form")) this.TransparentForm.Close();
                clSelectionBtn.Text = "Select one...";
                ResetStatusStrip();
            }
            else
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        this.LoadingForm.CompleteProgress();
                        this.LoadingForm.ChangeLabel("Data generation successful");
                        this.LoadingForm.Refresh();
                        this.loadingFormTimer.Enabled = true;
                        this.SetStatusLabelAndTimer($"Data generation successful", true);
                        ConnectionBtnGood();
                    }));
                }
                else
                {
                    this.LoadingForm.CompleteProgress();
                    this.LoadingForm.ChangeLabel("Data generation successful");
                    this.LoadingForm.Refresh();
                    this.loadingFormTimer.Enabled = true;
                    this.SetStatusLabelAndTimer($"Data generation successful", true);
                    ConnectionBtnGood();
                }
            }
        }
        //
        // Loading Form Manipulation
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
        #endregion

        // ----- OTHER ----- //
        #region Other
        //
        // Mouse Hover
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
        //
        // Sub forms
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
            //TransparentForm.Size = this.ClientSize;
            TransparentForm.Size = this.Size;
            TransparentForm.StartPosition = FormStartPosition.Manual;
            TransparentForm.BackColor = Color.Black;
            TransparentForm.Opacity = 0.3f;
            TransparentForm.ShowInTaskbar = false;
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => { TransparentForm.Show(this); }));
                //this.Invoke(new Action(() => { TransparentForm.Location = new Point(this.Location.X + 10, this.Location.Y + 10); }));
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
        //
        // Quality of life methods
        static public bool CheckIfFormIsOpened(string name)
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
        public void MakeErrorSound()
        {
            System.Media.SystemSounds.Hand.Play();
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
        private void SetColorButtonsBackToDefault()
        {
            colorDialogBtn.Font = new Font("Microsoft Sans Serif", 6, FontStyle.Italic);
            colorDialogBtn.ForeColor = Color.FromName("Default");
            paintBtn.Font = new Font("Microsoft Sans Serif", 6, FontStyle.Italic);
            paintBtn.ForeColor = Color.FromName("Default");
            paintFromQueryBtn.Font = new Font("Microsoft Sans Serif", 6, FontStyle.Italic);
            paintFromQueryBtn.ForeColor = Color.FromName("Default");
        }
        private void SetDatabaseDetailsProperties()
        {
            displayingCountStatusLbl.Text = $"{workflowItemListPopulated.Count.ToString()}";
            checkedCountStatusLbl.Text = $"{workflowItemsListView.CheckedItems.Count.ToString()}";
            queriedCountStatusLbl.Text = $"{CountOfQueriedItems().ToString()}";
        }
        #endregion Other
    }
}
