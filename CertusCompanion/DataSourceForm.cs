using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CertusCompanion
{
    public partial class DataSourceForm : Form
    {
        // --- FORM DATA --- //
        #region DataSourceForm Data
        private List<DataSource> dataSources;
        private DataSource selectedDataSource;
        private DataSource selectedDataSourceCopy;
        private int searchIndex;
        private string previousSearch;
        private string searchVal;
        private bool sortNumerically;
        private bool sortAlphabetically;
        private bool showItems;
        private SolidBrush spaceDarkBrush;
        List<string> itemsSortedAlphabetically;
        #endregion

        // --- STARTUP --- //
        #region Startup
        public DataSourceForm()
        {
            InitializeComponent();

            // read from .txt and generate lists here
            // ...
        }
        public DataSourceForm(List<DataSource> dataSourceList)
        {
            InitializeComponent();

            // instantiate
            dataSources = dataSourceList;
            spaceDarkBrush = new SolidBrush(ThemeColors.SpaceDark);

            // set up listview
            selectedDataSourceCopy = dataSources[0];
            itemsListView.VirtualListSize = 1;
            itemsListView.RetrieveVirtualItem += itemsListView_RetrieveVirtualItem;
            itemsListView.SearchForVirtualItem += ItemsListView_SearchForVirtualItem;
            DataSourceForm_Resize(this, null);
        }
        private void DataSources_Load(object sender, EventArgs e)
        {
            // tbxCmbx / tbxBtns need to be covered. fix size to a non-moving tbx
            typeTbx.Width = nameTbx.Width+1;
            bindedTbx.Width = nameTbx.Width+1;
            sortNumericallyBtn.PerformClick();

            PopulateData(dataSources);
            this.Focus();
        }
        private void PopulateData(List<DataSource> dataSourcesToPopulate)
        {
            sourcesLbx.DataSource = dataSourcesToPopulate;
        }
        private void PopulateItemsPanel()
        {
            selectedDataSource = (sourcesLbx.SelectedItem as DataSource);
            selectedDataSourceCopy = new DataSource(selectedDataSource.Name,selectedDataSource.Type,null,selectedDataSource.Binded);
            selectedDataSourceCopy.DateCreated = selectedDataSource.DateCreated;
            selectedDataSourceCopy.LastUpdated = selectedDataSource.LastUpdated;
            selectedDataSourceCopy.Items = new List<object>();
            selectedDataSourceCopy.Items.AddRange(selectedDataSource.Items);

            nameTbx.Text = selectedDataSourceCopy.Name;
            typeTbx.Text = selectedDataSourceCopy.Type;
            bindedTbx.Text = selectedDataSourceCopy.Binded.ToString();
            if (selectedDataSourceCopy.LastUpdated.HasValue) lastUpdatedTbx.Text = selectedDataSourceCopy.LastUpdated.Value.ToShortDateString();
            else lastUpdatedTbx.Text = String.Empty;
            itemsTbx.Text = selectedDataSourceCopy.Items.Count.ToString();

            itemsListView.VirtualListSize = selectedDataSourceCopy.Items.Count;
            DataSourceForm_Resize(this, null);
        }
        private void itemsListView_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            ListViewItem lvi = new ListViewItem();

            if (selectedDataSourceCopy == null || selectedDataSourceCopy.Items.Count < itemsListView.VirtualListSize) lvi.Text = "";
            else lvi.Text = selectedDataSourceCopy.Items[e.ItemIndex].ToString();

            e.Item = lvi; 		
        }
        private void ItemsListView_SearchForVirtualItem(object sender, SearchForVirtualItemEventArgs e)
        {
            int index = 0;
            if (sortAlphabetically)
            {
                List<object> items = new List<object>();
                items.AddRange(itemsSortedAlphabetically);
                index = FindMyStringInList(items, searchVal, searchIndex);
            }
            else index = FindMyStringInList((sourcesLbx.SelectedItem as DataSource).Items, searchVal, searchIndex);

            // find the item if index >= 0
            if (index >= 0)
            {
                e.Index = index;
            }
            else
            {
                if (searchIndex > 0)
                {
                    e.Index = searchIndex - 1;
                    MessageBox.Show("Reached the starting point of the seach.");
                    searchIndex = 0;
                    searchTbx.Focus();
                    return;
                }
                System.Media.SystemSounds.Hand.Play();
                MessageBox.Show("No items were found for that search", "Warning");
            }
                        
        }
        private void LoadSampleData()
        {
            dataSources = new List<DataSource>();

            for (int i = 0; i < 15; i++)
            {
                DataSource ds = new DataSource($"Data Source {i + 1}");
                ds.Type = "Sample Type";
                ds.LastUpdated = DateTime.Now;
                ds.Binded = true;

                List<object> sampleItems = new List<object>();

                for (int j = 0; j < 30; j++)
                {
                    object sampleItem = $"Sample, Item<{i}{j}0>";

                    sampleItems.Add(sampleItem);

                    if (j < 5) sampleItems.Add($"less than 5");
                    else if (j < 10) sampleItems.Add($"now less than 10");
                }

                ds.Items = sampleItems;

                dataSources.Add(ds);
            }

            PopulateData(dataSources);
        }
        #endregion Startup

        // --- FORM CONTROLS --- //
        #region Form Controls
        private void itemsMoreBtn_Click(object sender, EventArgs e)
        {
            if (!showItems)
            {
                showItems = true;
                itemsListView.Visible = true;
            }
            else
            {
                showItems = false;
                itemsListView.Visible = false;
            }
        }
        private void addSourceBtn_Click(object sender, EventArgs e)
        {

        }
        private void removeSourceBtn_Click(object sender, EventArgs e)
        {

        }
        private void sortNumericallyBtn_Click(object sender, EventArgs e)
        {
            if (sortAlphabetically)
            {
                sortAlphabetically = false;
                sortAlphabeticallyBtn.BackColor = Color.FromArgb(20, 20, 20);
            }

            sortNumerically = true;
            sortNumericallyBtn.BackColor = Color.FromName("Highlight");

            // show original items
            if ((sourcesLbx.SelectedItem as DataSource) == null || (sourcesLbx.SelectedItem as DataSource).Items == null ||
                (sourcesLbx.SelectedItem as DataSource).Items.Count == 0) return;

            selectedDataSourceCopy.Items.Clear();
            selectedDataSourceCopy.Items.AddRange(selectedDataSource.Items);
            itemsListView.Refresh();
        }
        private void sortAlphabeticallyBtn_Click(object sender, EventArgs e)
        {
            if (sortNumerically)
            {
                sortNumerically = false;
                sortNumericallyBtn.BackColor = Color.FromArgb(20, 20, 20);
            }

            sortAlphabetically = true;
            sortAlphabeticallyBtn.BackColor = Color.FromName("Highlight");

            try
            {
                itemsSortedAlphabetically = new List<string>();

                // query for a list of strings
                var query = from i in selectedDataSourceCopy.Items
                            select i.ToString();

                foreach (string item in query)
                {
                    itemsSortedAlphabetically.Add(item);
                }

                itemsSortedAlphabetically.Sort();
                selectedDataSourceCopy.Items.Clear();
                selectedDataSourceCopy.Items.AddRange(itemsSortedAlphabetically);
            }
            catch (InvalidOperationException m)
            {
                sortAlphabetically = false;
                sortAlphabeticallyBtn.BackColor = Color.FromArgb(20, 20, 20);
                MessageBox.Show("Could not sort. Reason: " + m.Message, "Error");
            }

            itemsListView.Refresh();
        }
        private void importDSBtn_Click(object sender, EventArgs e)
        {
            // this feature will not work as intended because embedded files cannot be edited during runtime. will have to think
            // of something else in the future.
        }
        private void ImportNewDS()
        {
            //openFileDialog1.FileName = "";
            //openFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            //openFileDialog1.FilterIndex = 1;

            //DialogResult dialogResult = openFileDialog1.ShowDialog();

            //if (dialogResult == DialogResult.OK)
            //{
            //    string fileName = openFileDialog1.FileName;
            //    string newContents;

            //    // save contents
            //    using (StreamReader sr = new StreamReader(fileName))
            //    {
            //        newContents = sr.ReadToEnd();
            //    }

            //    // write new contents to existing datasource file
            //    using (Stream strm = Assembly.GetExecutingAssembly().GetManifestResourceStream("CertusCompanion.Resources.DataSources.txt"))
            //    {
            //        using (StreamWriter sw = new StreamWriter(strm.)
            //        {
            //            sw.
            //        }
            //    }
            //}
        }
        private void importFromCSVBtn_Click(object sender, EventArgs e)
        {

        }
        private void importFromDBBtn_Click(object sender, EventArgs e)
        {

        }
        private void saveBtn_Click(object sender, EventArgs e)
        {

        }
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
        private void tbxCmbxComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (Control c in (sender as ComboBox).Parent.Controls)
                {
                    if (c is TextBox) (c as TextBox).Text = (sender as ComboBox).SelectedItem.ToString();
                }
            }
            catch (Exception) { }

            //typeTbx.Text = typeComboBox.SelectedItem.ToString();
        }
        private void tbxCmbxTextBox_Enter(object sender, EventArgs e)
        {
            (sender as TextBox).Width = nameTbx.Width - 18;

            //typeTbx.Width = nameTbx.Width-18;
        }
        private void tbxCmbxTextBox_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Control c in (sender as TextBox).Parent.Controls)
                {
                    if (c is ComboBox) (c as ComboBox).Focus();
                }
            }
            catch (Exception) { }

            //typeComboBox.Focus();
        }
        private void tbxCmbxComboBox_Leave(object sender, EventArgs e)
        {
            try
            {
                foreach (Control c in (sender as ComboBox).Parent.Controls)
                {
                    if (c is TextBox) (c as TextBox).Width = nameTbx.Width;
                }
            }
            catch (Exception) { }

            //typeTbx.Width = nameTbx.Width;
        }
        private void tbxBtnTextBox_Enter(object sender, EventArgs e)
        {
            (sender as TextBox).Width = nameTbx.Width - 18;
        }
        private void tbxBtnTextBox_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Control c in (sender as TextBox).Parent.Controls)
                {
                    if (c is Button)
                    {
                        (c as Button).Focus();
                    }
                }
            }
            catch (Exception) { }

            //typeComboBox.Focus();
        }
        private void tbxBtnButton_Leave(object sender, EventArgs e)
        {
            try
            {
                foreach (Control c in (sender as Button).Parent.Controls)
                {
                    if (c is TextBox) (c as TextBox).Width = nameTbx.Width;
                }
            }
            catch (Exception) { }

            //typeTbx.Width = nameTbx.Width;
        }
        #endregion Form Controls

        // --- SEARCH FUNCTIONALITY --- //
        #region Search Functionality
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
        }
        private void searchTbx_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) e.IsInputKey = true;
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
                //return if no items
                if ((sourcesLbx.SelectedItem as DataSource) == null || (sourcesLbx.SelectedItem as DataSource).Items == null || 
                    (sourcesLbx.SelectedItem as DataSource).Items.Count==0)
                {
                    System.Media.SystemSounds.Hand.Play();
                    return;
                }

                searchVal = searchTbx.Text;
                searchTbx.SelectAll();

                try
                {
                    if (searchVal != String.Empty)
                    {
                        var item = itemsListView.FindItemWithText(searchVal);
                        if (item != null)
                        {
                            itemsListView.FocusedItem = item;
                            item.Selected = true;
                            item.EnsureVisible();
                        }
                    }
                }
                catch (Exception)
                {
                    System.Media.SystemSounds.Hand.Play();
                    MessageBox.Show($"An unkown error occured while searching");
                    e.Handled = true;
                    e.SuppressKeyPress = true;
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
        private int FindMyStringInList(List<object> items, string searchString, int startIndex)
        {
            for (int i = startIndex; i < items.Count; ++i)
            {
                string s = items[i].ToString().ToLower();
                if (s.Contains(searchString.ToLower()))
                {
                    searchIndex = i + 1;
                    return i;
                }
            }
            return -1;
        }
        #endregion

        // --- OTHER --- //
        #region Other
        private void sourcesLbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                UseWaitCursor = true;
                PopulateItemsPanel();

                // this will restart the search box
                searchIndex = 0;

                // copied item list gets reset anyway so set the sort button back to default
                if (sortAlphabetically)
                {
                    sortAlphabetically = false;
                    sortAlphabeticallyBtn.BackColor = Color.FromArgb(20, 20, 20);
                }

                sortNumerically = true;
                sortNumericallyBtn.BackColor = Color.FromName("Highlight");
            }
            catch (Exception)
            {
                System.Media.SystemSounds.Hand.Play();
                MessageBox.Show("Something went wrong while selecting the datasource", "Error");
            }

            UseWaitCursor = false;
        }
        private void CloseForm()
        {
            try
            {
                foreach (Form frm in Application.OpenForms)
                {
                    if (frm.Name == "Transparent Form")
                    {
                        Application.OpenForms["Transparent Form"].Close();
                        return;
                    }
                }
                this.Close();
            }
            catch (Exception) { }
        }
        private void DataSourceForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F)
            {
                searchTbx.Focus();
                searchTbx.SelectAll();
            }
        }
        private void DataSourceForm_Resize(object sender, EventArgs e)
        {
            try
            {
                // column reisze
                columnHeader1.Width = itemsListView.ClientSize.Width;
            }
            catch (Exception)
            {

            }
        }
        private void itemsListView_VisibleChanged(object sender, EventArgs e)
        {
            DataSourceForm_Resize(this, null);
        }
        #endregion Other
    }
}
