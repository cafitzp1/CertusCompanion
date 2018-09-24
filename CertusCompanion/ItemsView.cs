using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CertusCompanion
{
    //
    // delegate declaration
    public delegate void ItemsStatusChangedEventHandler(object sender, ItemsCompletedReport completedReport);
    public delegate void ItemsColorUpdatedEventHandler(object sender, List<WorkflowItem> itemList);
    public delegate void OpenCertificateInBrowserEventHandler(object sender, string[] certificateIds);
    public delegate void OpenCompanyInBrowserEventHandler(object sender, string[] companyIDs);

    public partial class ItemsView : Form
    {
        #region ItemsView Data
        public event ItemsStatusChangedEventHandler SaveItemsCompletedReportToFullForm;
        public event ItemsColorUpdatedEventHandler ChangeItemsColor;
        WorkflowManager altMain;
        ListViewColumnSorter lvwColumnSorter;
        List<WorkflowItem> workflowItems;
        List<string> excludedIDs;
        List<WorkflowItem> excludedWfItems;
        List<WorkflowItem> workflowItemsLoaded;
        List<string> idsAddedToLv;
        ItemsCompletedReport completedReport;
        string[] selectedCertificateIds;
        string[] selectedCompanyIds;
        int itemNum = 0;
        string searchVal;
        int searchIndex;
        private string previousSearch;
        bool showColors = false;
        private string formFormat;
        #endregion

        // ----- FORM STARTUP ----- //
        #region Form Startup
        public ItemsView()
        {
            InitializeComponent();

            FormLoad();
        }
        private void FormLoad()
        {
            // Create an instance of a ListView column sorter and assign it 
            // to the ListView control.
            lvwColumnSorter = new ListViewColumnSorter();
            this.itemsListView.ListViewItemSorter = lvwColumnSorter;

            // create instance of the main form
            altMain = new WorkflowManager();

            // set format to default
            this.formFormat = "default";

            // assign 1 slot for selected lists
            selectedCertificateIds = new string[1];
            selectedCompanyIds = new string[1];

            // resize
            //this.Size = new Size(1600, 900);
            itemsView_Resize(this, null);

            // code to appear in the center of the form
            int x = Application.OpenForms[0].Location.X + (Application.OpenForms[0].Bounds.Width / 2 - this.Width / 2);
            int y = Application.OpenForms[0].Location.Y + (Application.OpenForms[0].Bounds.Height / 2 - this.Height / 2);
            this.Location = new Point(x, y);

            // should focus the export btn
            exportBtn.Focus();
        }
        #endregion

        // ----- ITEM POPULATION ----- //
        #region Item Population
        public void PopulateItems(List<WorkflowItem> workflowItems, List<string> excludedIDs)
        {
            idsAddedToLv = new List<string>();
            excludedWfItems = new List<WorkflowItem>();
            workflowItemsLoaded = new List<WorkflowItem>();
            int itemsNotShowing = 0;

            // save lists to this instance
            this.workflowItems = workflowItems;
            this.excludedIDs = excludedIDs;

            // set excluded items as wf items or notify user they cannot be set
            try
            {
                excludedWfItems = GetItemsToDisplayFromIDs();
                workflowItemsLoaded = excludedWfItems;
            }
            catch (Exception)
            {
                MessageBox.Show("Could not load items. Ensure ID list is in the correct format");
            }

            // reset lv
            this.itemsListView.BeginUpdate();
            this.itemsListView.ListViewItemSorter = null;
            this.itemsListView.Items.Clear();

            // column headers
            this.viewColumnHeader1.Text = "";
            this.viewColumnHeader2.Text = "Item ID";
            this.viewColumnHeader3.Text = "Company Name";
            this.viewColumnHeader4.Text = "Sent Date";
            this.viewColumnHeader5.Text = "From Address";
            this.viewColumnHeader6.Text = "Subject";
            this.viewColumnHeader7.Text = "Status";

            SetInitialColumnHeaderSizes();

            // for each id in the list
            foreach (string excludedID in excludedIDs)
            {
                // if list does not already contain item
                if (!idsAddedToLv.Contains(excludedID))
                {
                    // if workflow items are available, show entire items in LV
                    if (workflowItems != null && workflowItems.Count > 0)
                    {
                        // if item is available
                        if (this.GetWorkflowItemByID(excludedID) != null)
                        {
                            // get the item from the id string
                            WorkflowItem wfItem = this.GetWorkflowItemByID(excludedID);

                            // make tmp lvItem
                            ListViewItem lvItem = new ListViewItem(itemNum.ToString());

                            // add to tmp lvItem
                            lvItem.SubItems.Add(wfItem.DocumentWorkflowItemID.ToString());
                            lvItem.SubItems.Add(wfItem.VendorName);
                            lvItem.SubItems.Add(wfItem.EmailDate.ToString());
                            lvItem.SubItems.Add(wfItem.EmailFromAddress);
                            lvItem.SubItems.Add(wfItem.SubjectLine);
                            lvItem.SubItems.Add(wfItem.Status);

                            // add lvItem to lv
                            itemsListView.Items.Add(lvItem);

                            // add string to added lv ids
                            idsAddedToLv.Add(excludedID);
                        }
                        else
                        {
                            ++itemsNotShowing;
                        }
                    }
                    // if workflow items aren't available, just show IDs instead
                    else
                    {
                        // make tmp lvItem
                        ListViewItem lvItem = new ListViewItem(itemNum.ToString());

                        // add ID to tmp lvItem
                        lvItem.SubItems.Add(excludedID);

                        // add lvItem to lv
                        itemsListView.Items.Add(lvItem);
                    }

                    altMain.CountListViewItems(itemsListView);
                    this.itemsListView.ListViewItemSorter = lvwColumnSorter;
                    this.itemsListView.EndUpdate();
                    CorrectColumnHeaderSize(viewColumnHeader6);
                }
            }

            // display items not showing count if > 0
            if (itemsNotShowing > 0)
            {
                if (itemsNotShowing == 1)
                {
                    SetStatusLabelAndTimer($"{itemsNotShowing} item on the file cannot displayed. Item ID doesn't correlate with any item in the current view.");
                }
                else
                {
                    SetStatusLabelAndTimer($"{itemsNotShowing} items on the file cannot displayed. Item ID's don't correlate with any items in the current view.");
                }
            }
        }
        public void PopulateItems(List<WorkflowItem> itemsToView)
        {
            this.workflowItemsLoaded = itemsToView;

            // reset lv
            this.itemsListView.BeginUpdate();
            this.itemsListView.ListViewItemSorter = null;
            this.itemsListView.Items.Clear();

            // column headers
            this.viewColumnHeader1.Text = "";
            this.viewColumnHeader2.Text = "Item ID";
            this.viewColumnHeader3.Text = "Company Name";
            this.viewColumnHeader4.Text = "Sent Date";
            this.viewColumnHeader5.Text = "From Address";
            this.viewColumnHeader6.Text = "Subject";
            this.viewColumnHeader7.Text = "Status";

            SetInitialColumnHeaderSizes();

            foreach (WorkflowItem wfItem in workflowItemsLoaded)
            {
                // make tmp lvItem
                ListViewItem lvItem = new ListViewItem(itemNum.ToString());

                // add to tmp lvItem
                // add to tmp lvItem
                lvItem.SubItems.Add(wfItem.DocumentWorkflowItemID.ToString());
                lvItem.SubItems.Add(wfItem.VendorName);
                lvItem.SubItems.Add(wfItem.EmailDate.ToString());
                lvItem.SubItems.Add(wfItem.EmailFromAddress);
                lvItem.SubItems.Add(wfItem.SubjectLine);
                lvItem.SubItems.Add(wfItem.Status);

                // add lvItem to lv
                itemsListView.Items.Add(lvItem);
            }

            this.altMain.CountListViewItems(itemsListView);
            this.itemsListView.ListViewItemSorter = lvwColumnSorter;
            this.itemsListView.EndUpdate();
            CorrectColumnHeaderSize(viewColumnHeader6);
        }
        public void PopulateCertificates(List<Certificate> certificatesToView)
        {
            // reset lv
            this.itemsListView.BeginUpdate();
            this.itemsListView.ListViewItemSorter = null;
            this.itemsListView.Items.Clear();

            itemNum = 0;

            foreach (Certificate cert in certificatesToView)
            {
                // make tmp lvItem
                ListViewItem lvItem = new ListViewItem(itemNum.ToString());

                // add to tmp lvItem
                lvItem.SubItems.Add(cert.CertificateName);
                lvItem.SubItems.Add(cert.IssueDate.ToString());
                lvItem.SubItems.Add(cert.CompanyName);
                lvItem.SubItems.Add(cert.CertificateActive.ToString());
                lvItem.SubItems.Add(cert.CertificateCompliant.ToString());
                lvItem.SubItems.Add(cert.Market);

                // add lvItem to lv
                itemsListView.Items.Add(lvItem);
            }

            this.altMain.CountListViewItems(itemsListView);
            this.itemsListView.ListViewItemSorter = lvwColumnSorter;
            this.itemsListView.EndUpdate();
            CorrectColumnHeaderSize(viewColumnHeader4);
        }
        public void PopulateCompanies(List<Company> companiesToView)
        {
            // reset lv
            this.itemsListView.BeginUpdate();
            this.itemsListView.ListViewItemSorter = null;
            this.itemsListView.Items.Clear();

            itemNum = 0;

            foreach (Company company in companiesToView)
            {
                // make tmp lvItem
                ListViewItem lvItem = new ListViewItem(itemNum.ToString());

                // add to tmp lvItem
                lvItem.SubItems.Add(company.BcsCompanyID);
                lvItem.SubItems.Add(company.CompanyName);
                lvItem.SubItems.Add(company.VendorID);
                lvItem.SubItems.Add(company.CompanyActive.ToString());
                lvItem.SubItems.Add(company.CompanyComplianceLevel);
                lvItem.SubItems.Add(string.Empty);

                // add lvItem to lv
                itemsListView.Items.Add(lvItem);
            }

            this.altMain.CountListViewItems(itemsListView);
            this.itemsListView.ListViewItemSorter = lvwColumnSorter;
            this.itemsListView.EndUpdate();
            CorrectColumnHeaderSize(viewColumnHeader3);
        }
        #endregion

        // ----- ITEMS VIEW APPEARANCE AND BEHAVIOR ----- //
        #region Items View Appearance and Behavior

        #region Items View Format
        private void SetInitialColumnHeaderSizes()
        {
            // size column headers according to header value width, except for header 1 which is the count

            this.viewColumnHeader1.Width-=75;

            this.viewColumnHeader2.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            this.viewColumnHeader3.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            this.viewColumnHeader4.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            this.viewColumnHeader5.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            this.viewColumnHeader6.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            //this.viewColumnHeader7.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);

            if(formFormat!="companies") this.viewColumnHeader7.Width=120;
            else this.viewColumnHeader7.Width = 0;

            this.viewColumnHeader2.Width += 30;
            this.viewColumnHeader3.Width += 30;
            this.viewColumnHeader4.Width += 30;
            this.viewColumnHeader5.Width += 30;
            this.viewColumnHeader6.Width += 30;
            this.viewColumnHeader7.Width += 30;
        }
        private void CorrectColumnHeaderSize(ColumnHeader headerToVary)
        {
            // column headerToVary will always fill to the end of the view
            int headerIndx = 7;

            try
            {
                int allOtherColumnsWidth = 0;
                int columnWidthToSet = itemsListView.Columns[headerIndx].Width;
                for (int i = 0; i < itemsListView.Columns.Count; i++)
                {
                    if (i != headerIndx)
                    {
                        allOtherColumnsWidth += itemsListView.Columns[i].Width;
                    }
                }

                if (itemsListView.ClientSize.Width > allOtherColumnsWidth)
                {
                    if (itemsListView.Columns[headerIndx].Width != (itemsListView.ClientSize.Width - allOtherColumnsWidth))
                        itemsListView.Columns[headerIndx].Width = (itemsListView.ClientSize.Width - allOtherColumnsWidth);
                }
            }
            catch (StackOverflowException)
            {
                SetStatusLabelAndTimer("Could not resize the columns");
            }
        }
        #endregion

        private void itemsListView_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            if (formFormat == "default" || formFormat == "excluded" || formFormat == "completed")
                CorrectColumnHeaderSize(viewColumnHeader5);
            else CorrectColumnHeaderSize(viewColumnHeader4);
        }
        private void itemsView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            Color background = Color.FromArgb(15,15,15);
            SolidBrush myBrush = new SolidBrush(background);

            using (var headerFont = new Font("Microsoft Sans Serif", 8))
            {
                string s = $"  {e.Header.Text}";

                e.Graphics.FillRectangle(myBrush, e.Bounds);
                e.Graphics.DrawString(s, headerFont,
                    Brushes.Gray, e.Bounds);
            }
        }
        private void itemsView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            string idBeingDrawn = e.Item.SubItems[1].Text;

            if (showColors)
            {
                WorkflowItem itemBeingDrawn = GetWorkflowItemFromCurrentViewByID(idBeingDrawn);
                ListViewItem lvItem = itemsListView.Items[e.ItemIndex] as ListViewItem;

                // draw respective color
                try
                {
                    e.Item.ForeColor = Color.FromName(itemBeingDrawn.DisplayColor);
                    e.Item.UseItemStyleForSubItems = true;
                    if (e.Item.Focused == true || e.Item.Checked == true)
                    {
                        e.Item.BackColor = Color.FromName("ActiveCaption");
                    }
                    else
                    {
                        e.Item.BackColor = Color.FromArgb(15,15,15);
                    }
                }
                catch (Exception)
                {
                    // just so the program doesn't crash if there's any issues drawing an item (when items get removed from the view)
                }

                // draw every other item default
                e.DrawDefault = true;
            }
            else
            {
                try
                {
                    e.Item.ForeColor = Color.FromName("ControlLight");
                    e.Item.UseItemStyleForSubItems = true;
                    if (e.Item.Focused == true || e.Item.Checked == true)
                    {
                        e.Item.BackColor = Color.FromName("ActiveCaption");
                    }
                    else
                    {
                        e.Item.BackColor = Color.FromArgb(15,15,15);
                    }
                }
                catch (Exception)
                {
                    // just so the program doesn't crash if there's any issues drawing an item (when items get removed from the view)
                }

                // draw every other item default
                e.DrawDefault = true;
            }
        }
        private void itemsView_Resize(object sender, EventArgs e)
        {
            if (formFormat == "default" || formFormat == "excluded" || formFormat == "completed")
                CorrectColumnHeaderSize(viewColumnHeader5);
            else CorrectColumnHeaderSize(viewColumnHeader4);
        }
        private void itemsListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.itemsListView.Sort();

            altMain.CountListViewItems(itemsListView);

            Cursor.Current = Cursors.Default;
        }
        private void itemsListView_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.F)
                {
                    searchTbx.Focus();
                }
            }
            catch
            {
                //SetStatusLabelAndTimer("There was an error with that key press");

                // just don't crash
            }
        }
        private void itemsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (formFormat == "certificates")
            {
                if (itemsListView.SelectedItems != null && itemsListView.SelectedItems.Count > 0)
                {
                    // add the certificate name for which ever selected item was selected first
                    selectedCertificateIds[0] = (itemsListView.SelectedItems[0].SubItems[1].Text);
                }
            }
            else if (formFormat == "companies")
            {
                if (itemsListView.SelectedItems != null && itemsListView.SelectedItems.Count > 0)
                {
                    // add the certificate name for which ever selected item was selected first
                    selectedCompanyIds[0] = (itemsListView.SelectedItems[0].SubItems[1].Text);
                }
            }
        }
        private void itemsListView_VisibleChanged(object sender, EventArgs e)
        {
            //if (this.itemsListView.Visible == true)
            //{
            //    this.itemsListView.ColumnWidthChanged += this.itemsListView_ColumnWidthChanged;
            //}
            //else this.itemsListView.ColumnWidthChanged -= this.itemsListView_ColumnWidthChanged;

            //if (formFormat == "default" || formFormat == "excluded" || formFormat == "completed")
            //{
            //    CorrectColumnHeaderSize(viewColumnHeader5);
            //}
            //else CorrectColumnHeaderSize(viewColumnHeader4);
        }
        private void optionBtn_Enter(object sender, EventArgs e)
        {
            (sender as Button).FlatAppearance.BorderColor = Color.FromKnownColor(KnownColor.Highlight);
        }
        private void optionBtn_Leave(object sender, EventArgs e)
        {
            (sender as Button).FlatAppearance.BorderColor = Color.FromKnownColor(KnownColor.WindowFrame);
        }
        #endregion

        // ----- PULL DATA ----- //
        #region Pull Data
        private List<WorkflowItem> GetItemsToDisplayFromIDs()
        {
            WorkflowItem wfItem;;

            // for each id in the list
            foreach (string excludedID in excludedIDs)
            {
                // trim spaces
                excludedID.TrimEnd(' ');

                // if item is found
                try
                {
                    // get the item from the id string
                    wfItem = this.GetWorkflowItemByID(excludedID);

                    // add if not null (want to display items now showing if null)
                    if (wfItem != null)
                    {
                        // if list does not already contain item
                        if (!excludedWfItems.Contains(wfItem))
                        {
                            excludedWfItems.Add(wfItem);
                        }
                    }
                    else
                    {
                        excludedWfItems.Add(wfItem);
                    }
                }
                catch
                {
                    
                }
                
            }

            return excludedWfItems;
        }
        private WorkflowItem GetWorkflowItemByID(string id)
        {
            WorkflowItem result;

            // query the list for id
            result = workflowItems.Find(o => o.DocumentWorkflowItemID == id);

            return result;
        }
        private List<WorkflowItem> GetWorkflowItemListFromIds(List<string> idsList)
        {
            List<WorkflowItem> resultsList = new List<WorkflowItem>();

            // query the list for id
            foreach (string id in idsList)
            {
                resultsList.Add(GetWorkflowItemByID(id));
            }

            return resultsList;
        } 
        private List<WorkflowItem> GetWorkflowItemsFromItemsView()
        {
            List<WorkflowItem> items = new List<WorkflowItem>();

            for (int i = 0; i < this.itemsListView.Items.Count; i++)
            {
                WorkflowItem item = new WorkflowItem();

                item = GetWorkflowItemByID(itemsListView.Items[i].SubItems[1].Text);

                items.Add(item);
            }

            return items;
        }
        private WorkflowItem GetWorkflowItemFromCurrentViewByID(string id)
        {
            // query the list for id
            WorkflowItem result = this.workflowItemsLoaded.Find(o => o.DocumentWorkflowItemID == id);

            return result;
        }
        #endregion

        // ----- SEARCH FUNCTIONALITY ----- //
        #region Search Functionality
        private string DetermineWhichListToSearch(ItemsView viewForm)
        {
            if (viewForm.workflowItemsLoaded != null && workflowItemsLoaded.Count > 0)
            {
                return "itemsToView";
            }
            else if (viewForm.excludedWfItems != null && excludedWfItems.Count > 0)
            {
                return "excludedWfItems";
            }
            else if (viewForm.excludedIDs != null && workflowItemsLoaded.Count > 0)
            {
                return "excludedIDs";
            }
            else
            {
                return "null";
            }
        }
        private void searchTbx_Enter(object sender, EventArgs e)
        {
            searchTbx_MouseHover(sender, e);
            searchTbx.MouseLeave -= searchTbx_MouseLeave;

            if (searchTbx.Text == "Search Items (Ctrl+F)") searchTbx.Text = String.Empty;
        }
        private void searchTbx_MouseMove(object sender, MouseEventArgs e)
        {
            searchTbx_MouseHover(sender, e);
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
                this.toolStripStatusLabel.Text = $"Find \"{searchTbx.Text}\"";
            }
            else
            {
                this.toolStripStatusLabel.Text = "Ready";
            }

        }
        private void searchTbx_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Shift && e.KeyCode == Keys.Space)
            {
                itemsListView.Focus();
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
                        index = FindMyStringInListView(itemsListView, searchVal, searchIndex);

                        // find the item if index >= 0
                        if (index >= 0)
                        {
                            SelectItemInListView(index);

                            // update status label
                            this.toolStripStatusLabel.Text = $"Find \"{searchTbx.Text}\"";

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
                            this.toolStripStatusLabel.Text = $"The following text was not found: {searchTbx.Text}";
                        }
                    }
                }
                catch (Exception)
                {
                    SetStatusLabelAndTimer($"An unkown error occured while searching");
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    System.Media.SystemSounds.Hand.Play();
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
        private int FindMyStringInListView(ListView listViewToSearch, string searchString, int startIndex)
        {
            // only regular case search for this view
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
            
            return -1;
        }
        private void FocusItemInListView(int index)
        {
            try
            {
                itemsListView.Items[index].Focused = true;
                itemsListView.EnsureVisible(index);
            }
            catch (Exception)
            {
                this.toolStripStatusLabel.Text="Could not get the item";
                System.Media.SystemSounds.Hand.Play();
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
        private int FindMyStringInList(List<string> excludedIDs, string searchString, int startIndex)
        {
            for (int i = startIndex; i < excludedIDs.Count; ++i)
            {
                string wiString = excludedIDs[i].ToString();
                if (wiString.Contains(searchString))
                {
                    searchIndex = i + 1;
                    return i;
                }
            }
            return -1;
        }
        private void SelectItemInListView(int index)
        {
            itemsListView.SelectedIndices.Clear();
            itemsListView.Items[index].Selected = true;
            itemsListView.Items[index].Focused = true;
            itemsListView.EnsureVisible(index);
        }
        #endregion

        // ----- ITEMS VIEW OPTIONS ----- //
        #region Items View Options
        private void viewColorsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (viewColorsCheckBox.Checked == true)
            {
                //changeColorCheckBox.Checked = false;
                showColors = true;
            }
            else
            {
                //changeColorCheckBox.Checked = true;
                showColors = false;
            }

            itemsListView.Refresh();
        }
        private void exportBtn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            
            ExportForm exportForm = new ExportForm(workflowItemsLoaded);
            exportForm.ShowDialog();

            Cursor.Current = Cursors.Default;
        }
        #endregion

        // ----- STATUS STRIP ----- //
        #region Status Strip
        public void SetStatusLabelAndTimer(string statusLblMessage)
        {
            toolStripStatusLabel.Text = statusLblMessage;
            timer.Enabled = true;
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            this.toolStripStatusLabel.Text = "Ready";
        }
        #endregion
    }
}
