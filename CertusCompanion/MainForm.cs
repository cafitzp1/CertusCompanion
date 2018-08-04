using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace CertusCompanion
{
    public partial class MainForm : Form
    {
        private WorkflowItemDatabase workflowItemDatabase;
        private AppSave appSave;
        private AppData appData;
        private ItemImports itemImportsList;
        private ItemsCompletedReports ItemsCompletedReportsList;
        private List<WorkflowItem> allWorkflowItemsLoaded;
        private List<WorkflowItemCSVImport> allItemImportsLoaded;
        private List<ItemsCompletedReport> allItemsCompletedReportsLoaded;

        /* review which of the following data is necessary
        WorkflowItem selectedWorkflowItem;
        WorkflowItemDataView workflowItemForm;
        QueriedItemsDataView queriedItemsForm;
        EventArgs e; 
        List<WorkflowItem> itemsToBeDeleted; 
        List<WorkflowItem> uniqueWorkflowItems; 
        List<WorkflowItem> allWorkflowItems; 
        List<WorkflowItem> queriedItems;
        List<WorkflowItem> itemsToBeDeletedFromQuery;
        List<WorkflowItem> itemsUnmarkedAsDuplicate;
        List<WorkflowItem> imageWorkflowItems;
        List<WorkflowItem> requirementWorkflowItems;

        string searchVal; 
        int searchIndex; 
        int selectedItemIndex; 
        int[] lastIndexes;
        */

        internal WorkflowItemDatabase WorkflowItemDatabase { get => workflowItemDatabase; set => workflowItemDatabase = value; }
        internal AppSave AppSave { get => appSave; set => appSave = value; }
        internal AppData AppData { get => appData; set => appData = value; }
        internal ItemImports ItemImportsList { get => itemImportsList; set => itemImportsList = value; }
        internal ItemsCompletedReports ItemsCompletedReportsList1 { get => ItemsCompletedReportsList; set => ItemsCompletedReportsList = value; }
        public List<WorkflowItem> AllWorkflowItemsLoaded { get => allWorkflowItemsLoaded; set => allWorkflowItemsLoaded = value; }
        internal List<WorkflowItemCSVImport> AllItemImportsLoaded { get => allItemImportsLoaded; set => allItemImportsLoaded = value; }
        internal List<ItemsCompletedReport> AllItemsCompletedReportsLoaded { get => allItemsCompletedReportsLoaded; set => allItemsCompletedReportsLoaded = value; }

        public MainForm()
        {
            InitializeComponent();

            //manually resize
            this.Size = new Size(1524/2, 825 / 2+17);
            this.MinimumSize = Size;

            //set inital details property labels
            recordsLbl.Text = workflowItemsLbx.Items.Count.ToString();
            queriedItemsLbl.Text = "0";

            // create an application folder in AppData
            string path = "";
            try
            {
                path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "UserDatabase");
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
            }
            catch
            {
                //MessageBox.Show("Unable to create folder " + path + ", check your user privileges.",
                //"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetStatusLabelAndTimer("Unable to create folder.");
            }

            // remove hover over color for search filter buttons
            highlightBtn.FlatAppearance.MouseOverBackColor = highlightBtn.BackColor;
            highlightBtn.BackColorChanged += (s, e) => {
                highlightBtn.FlatAppearance.MouseOverBackColor = highlightBtn.BackColor;
            };
            clearBtn.FlatAppearance.MouseOverBackColor = clearBtn.BackColor;
            clearBtn.BackColorChanged += (s, e) => {
                clearBtn.FlatAppearance.MouseOverBackColor = clearBtn.BackColor;
            };
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            //Cursor.Current = Cursors.WaitCursor;

            //try
            //{
            //    WorkflowItemDatabase.Save("workflowItems");
            //}
            //catch
            //{
            //    SetStatusLabelAndTimer("Unable to save items.");
            //}

            //Cursor.Current = Cursors.Default;
            //SetStatusLabelAndTimer("File saved successfully!");
        }

        private void loadBtn_Click(object sender, EventArgs e)
        {
            this.LoadAppData();
        }

        private void LoadAppData()
        {
            try
            {
                openFileDialog.FileName = "";
                openFileDialog.Filter = "App Data Files (*.dat)|*.dat|All Files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;

                DialogResult dialogResult = openFileDialog.ShowDialog();

                if (dialogResult == DialogResult.OK)
                {
                    string fileName = openFileDialog.FileName;

                    try
                    {
                        this.AppSave.Load(fileName);
                    }
                    catch (Exception)
                    {
                        throw new AppSaveLoadFailedException("Loading failed; could not load 'AppSave'");
                    }
                }

                try
                {
                    this.AppData = AppSave.MostRecentSave;
                    this.StoreAppDataToForm(AppData);
                }
                catch (Exception)
                {
                    throw new AppDataLoadFailedException("Loading failed; could not load 'AppData'");
                }
                try
                {
                    this.ItemImportsList = AppData.ItemImportsList;
                }
                catch (Exception)
                {
                    throw new ItemImportsLoadFailedException("Loading failed; could not load 'ItemImports'");
                }
                try
                {
                    this.ItemsCompletedReportsList = AppData.ItemsCompletedReportsList;
                }
                catch (Exception)
                {
                    throw new ItemsCompletedReportsLoadFailedException("Loading failed; could not load 'ItemsCompletedReports'");
                }
                try
                {
                    this.WorkflowItemDatabase = AppData.WorkflowItemDatabase;
                }
                catch (Exception)
                {
                    throw new WorkflowItemDatabaseLoadFailedException("Loading failed; could not load 'WorkflowItemDatabase'");
                }

            }
            catch (WorkflowItemDatabaseLoadFailedException)
            {

            }
            catch (ItemsCompletedReportsLoadFailedException)
            {

            }
            catch (ItemImportsLoadFailedException)
            {

            }
            catch (AppDataLoadFailedException)
            {

            }
            catch (AppSaveLoadFailedException)
            {

            }
            catch (Exception)
            {

            }
        }

        internal void StoreAppDataToForm(AppData appData)
        {
            this.AppData = appData;

            // save database to list of workflow items
            this.AllWorkflowItemsLoaded = AppData.WorkflowItemDatabase.ReturnAllItemsFromDatabase();

            // save item imports
            this.AllItemImportsLoaded = AppData.ItemImportsList.ReturnAllImports();

            // save reports
            this.AllItemsCompletedReportsLoaded = AppData.ItemsCompletedReportsList.ReturnAllReports();
        }

        //private void loadBtn_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        // have user select a file
        //        openFileDialog.FileName = "";
        //        openFileDialog.Filter = "Comma Separated Value Files (*.csv)|*.csv";
        //        openFileDialog.FilterIndex = 1;

        //        DialogResult dialogResult = openFileDialog.ShowDialog();

        //        // if file selection was ok
        //        if (dialogResult == DialogResult.OK)
        //        {
        //            Cursor.Current = Cursors.WaitCursor;

        //            string fileName = openFileDialog.FileName;

        //            // create database
        //            workflowItemDatabase = new Database("workflowItems", fileName);

        //            // close other forms when loading data 
        //            for (int i = 1; i < Application.OpenForms.Count; i++)
        //            {
        //                Application.OpenForms[i].Close();
        //            }

        //            // load workflow items database
        //            workflowItemDatabase.Load("workflowItems");
        //            workflowItemsLbx.Items.Clear();
        //            workflowItemsLbx.Items.AddRange(workflowItemDatabase.ReturnAllWorkflowItems());

        //            // make a list of all the workFlowItems
        //            allWorkflowItems = new List<WorkflowItem>();
        //            allWorkflowItems = workflowItemsLbx.Items.OfType<WorkflowItem>().ToList();
        //        }

        //        // if items were loaded into the program properly
        //        if (allWorkflowItems != null && allWorkflowItems.Count > 0)
        //        {
        //            SetStatusLabelAndTimer("Items loaded successfully!");

        //            // set inital details properties
        //            recordsLbl.Text = workflowItemsLbx.Items.Count.ToString();
        //            queriedItemsLbl.Text = "0";

        //            // enable buttons
        //            dataFormBtn.Enabled = true;
        //            queryBtn.Enabled = true;
        //            saveBtn.Enabled = true;
        //            removeBtn.Enabled = true;
        //            radioButton1.Enabled = true;
        //            radioButton2.Enabled = true;
        //            radioButton3.Enabled = true;
        //            radioButton4.Enabled = true;
        //        }
        //    }
        //    catch
        //    {
        //        SetStatusLabelAndTimer("Unable to load items.");
        //        System.Media.SystemSounds.Hand.Play();
        //    }

        //    Cursor.Current = Cursors.Default;
        //}

        private void workflowItemsLbx_SelectedIndexChanged(object sender, EventArgs e)
        {

            //    if (workflowItemsLbx.SelectedItem != null)
            //    {
            //        WorkflowItem i = (WorkflowItem)workflowItemsLbx.SelectedItem;
            //        fieldLbl1.Text = i.DocumentWorkflowItemID;
            //        fieldLbl2.Text = i.CompanyName;
            //        fieldLbl3.Text = i.EmailDate.ToString();
            //        fieldLbl4.Text = i.EmailFromAddress;
            //        fieldLbl5.Text = i.SubjectLine;
            //        fieldLbl6.Text = i.FileName;
            //    }
        }

        private void workflowItemsLbx_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //    if (workflowItemsLbx.SelectedItem == null)
            //        return;

            //    // get the question which is currently selected and position
            //    selectedWorkflowItem = (WorkflowItem)workflowItemsLbx.SelectedItem;
            //    selectedItemIndex = workflowItemsLbx.SelectedIndex;
            //    KeepTrackOfLastIndexes();


            //    if (CheckIfFormIsOpened("Item Data") == false)
            //    {
            //        // create the form 
            //        workflowItemForm = new WorkflowItemDataView(uniqueWorkflowItems);

            //        // register events
            //        workflowItemForm.NextBtnClicked += new WorkflowItemEventHandler(WorkflowItemsForm_NextBtnClicked);
            //        workflowItemForm.PrevBtnClicked += new WorkflowItemEventHandler(WorkflowItemsForm_PrevBtnClicked);
            //        //workflowItemForm.DuplicateChBxCheckedChanged += new CheckBoxEventHandler(WorkflowItemsForm_CheckBoxCheckedChanged);
            //        workflowItemForm.LastBtnClicked += new WorkflowItemEventHandler(WorkflowItemsForm_LastBtnClicked);
            //        workflowItemForm.CopyIdBtnClicked += new CopyItemEventHandler(WorkflowItemsForm_CopyIdBtnClicked);

            //        // show the form and set it to show details of the selected question
            //        workflowItemForm.Show();
            //    }
            //    workflowItemForm.PopulateData(selectedWorkflowItem);
            //    workflowItemForm.Focus();
            //    this.Focus();
        }

        public bool CheckIfFormIsOpened(string name)
        {
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                if (frm.Text == name)
                {
                    return true;
                }
            }
            return false;
        }

        //private void WorkflowItemsForm_NextBtnClicked(object sender, WorkflowItem wi)
        //{
        //    if (selectedItemIndex < workflowItemsLbx.Items.Count-1)
        //    {
        //        workflowItemsLbx.SetSelected(selectedItemIndex, false);
        //        ++selectedItemIndex;
        //        KeepTrackOfLastIndexes();
        //        workflowItemsLbx.SetSelected(selectedItemIndex, true);
        //        workflowItemForm.PopulateData((WorkflowItem)workflowItemsLbx.Items[selectedItemIndex]);
        //    }
        //    else
        //    {
        //        SetStatusLabelAndTimer("No more items!");
        //    }
        //}

        //private void WorkflowItemsForm_PrevBtnClicked(object sender, WorkflowItem wi)
        //{
        //    if (selectedItemIndex != 0)
        //    {
        //        workflowItemsLbx.SetSelected(selectedItemIndex, false);
        //        --selectedItemIndex;
        //        KeepTrackOfLastIndexes();
        //        workflowItemsLbx.SetSelected(selectedItemIndex, true);
        //        workflowItemForm.PopulateData((WorkflowItem)workflowItemsLbx.Items[selectedItemIndex]);
        //    }
        //    else
        //    {
        //        //MessageBox.Show("No previous items");
        //        SetStatusLabelAndTimer("No previous items!");
        //    }
        //}

        //private void WorkflowItemsForm_LastBtnClicked(object sender, WorkflowItem wi)
        //{
        //    string lastItem;
        //    try
        //    { 

        //        if (workflowItemsLbx.GetSelected(lastIndexes[1]))
        //        {
        //            workflowItemsLbx.SetSelected(selectedItemIndex, false);
        //            workflowItemsLbx.SetSelected(lastIndexes[0], true);
        //            lastItem = workflowItemsLbx.Items[lastIndexes[1]].ToString().Substring(0,7);
        //        }
        //        else if (workflowItemsLbx.GetSelected(lastIndexes[0]))
        //        {
        //            workflowItemsLbx.SetSelected(selectedItemIndex, false);
        //            workflowItemsLbx.SetSelected(lastIndexes[1], true);
        //            lastItem = workflowItemsLbx.Items[lastIndexes[0]].ToString().Substring(0, 7);
        //        }
        //        else
        //        {
        //            workflowItemsLbx.SetSelected(selectedItemIndex, false);
        //            workflowItemsLbx.SetSelected(lastIndexes[0], true);
        //            lastItem = "";
        //        }

        //        selectedItemIndex = workflowItemsLbx.SelectedIndex;
        //        workflowItemForm.PopulateData(workflowItemsLbx.SelectedItem as WorkflowItem, lastItem);
        //    }
        //    catch (Exception)
        //    {
        //        //MessageBox.Show("No previous items");
        //        SetStatusLabelAndTimer("Could not go to last item!");
        //    }
        //}

        //private void KeepTrackOfLastIndexes()
        //{
        //    if (workflowItemForm == null)
        //    {
        //        lastIndexes = new int[2];
        //        lastIndexes[1] = selectedItemIndex;
        //        lastIndexes[0] = selectedItemIndex;
        //    }
        //    else
        //    {
        //        lastIndexes[1] = lastIndexes[0];
        //        lastIndexes[0] = selectedItemIndex;
        //    }
        //}

        //private void WorkflowItemsForm_CopyIdBtnClicked(object sender, string item)
        //{
        //    searchTbx.Text = item;
        //    this.Focus();

        //    // do a quick version of what the search button does
        //    searchVal = searchTbx.Text;
        //    searchTbx.SelectAll();

        //    try
        //    {
        //        workflowItemsLbx.ClearSelected();
        //        workflowItemsLbx.SetSelected(FindMyStringInList(workflowItemsLbx, searchVal, searchIndex), true);
        //    }
        //    catch (Exception)
        //    {
        //        SetStatusLabelAndTimer("Cannot find data.");
        //    }
        //}

        ////private void WorkflowItemsForm_CheckBoxCheckedChanged(object sender, bool isChecked, bool isIgnored, WorkflowItem wi)
        ////{
        ////    // if this event is not ignored (ignored when setting checks in code) and there is one item selected
        ////    if (!isIgnored && workflowItemsLbx.SelectedItem != null && workflowItemsLbx.SelectedIndices.Count == 1)
        ////    {
        ////        // if we are unchecking the item, we want to make a list of the items unmarked if it isn't already made
        ////        if (isChecked == false)
        ////        {
        ////            if (itemsUnmarkedAsDuplicate == null)
        ////            {
        ////                itemsUnmarkedAsDuplicate = new List<WorkflowItem>();
        ////            }

        ////            (workflowItemsLbx.SelectedItem as WorkflowItem).IsDuplicate = false;

        ////            // then, we want to update our unique and queried item lists, and also add this item to the items unmarked list. 
        ////            // REPLACE THIS with update unique items method because it will have to be done when the list changes are loaded in, which should be the items unmarked
        ////            uniqueWorkflowItems.Add((WorkflowItem)workflowItemsLbx.SelectedItem); // THIS ITEM may not always be what is selected in the lbx***

        ////            // REPLACE THIS with update queried items method
        ////            queriedItems.Remove((WorkflowItem)workflowItemsLbx.SelectedItem);
        ////            itemsUnmarkedAsDuplicate.Add((WorkflowItem)workflowItemsLbx.SelectedItem);

        ////            // notify user that the item has been unmarked
        ////            SetStatusLabelAndTimer("Item is no longer marked as duplicate and will not show up in the query. Remember to save changes before exiting.");
        ////        }
        ////        // if we are checking the item, we want to make sure the item isn't on the unique items list.
        ////        else
        ////        {
        ////            (workflowItemsLbx.SelectedItem as WorkflowItem).IsDuplicate = true;

        ////            // REPLACE THIS " "
        ////            uniqueWorkflowItems.Remove((WorkflowItem)workflowItemsLbx.SelectedItem);
        ////            // REPLACE THIS " "
        ////            queriedItems.Add((WorkflowItem)workflowItemsLbx.SelectedItem);
        ////            // if this item was previously unmarked, it was added to the unmarked list and must be removed
        ////            if (itemsUnmarkedAsDuplicate != null && itemsUnmarkedAsDuplicate.Contains(workflowItemsLbx.SelectedItem) == true)
        ////            {
        ////                itemsUnmarkedAsDuplicate.Remove((WorkflowItem)workflowItemsLbx.SelectedItem); // AGAIN, THIS ITEM may not always be what is selected in the lbx***
        ////            }
        ////            // notify user item is now a duplicate
        ////            SetStatusLabelAndTimer("Item is now marked as duplicate and will show up in the query.");
        ////        }
        ////    }
        ////    // do nothing is the event is do be ignored

        ////    SetDatabaseDetailsProperties();
        ////}

        private void removeBtn_Click(object sender, EventArgs e)
        {
            //    if (workflowItemsLbx.SelectedItem != null && workflowItemsLbx.Items.Count > 0)
            //    {
            //        itemsToBeDeleted = new List<WorkflowItem>();
            //        int indicesCount = workflowItemsLbx.SelectedIndices.Count;
            //        int selectedRemoveIndex = workflowItemsLbx.SelectedIndex;

            //        // create a temporary list of the selected items to delete
            //        itemsToBeDeleted = workflowItemsLbx.SelectedItems.OfType<WorkflowItem>().ToList();

            //        // delete from database and Lbx. Also delete from workflowItems and unique items if not null
            //        for (int i = 0; i < indicesCount; i++)
            //        {
            //            workflowItemsDatabase.RemoveWorkflowItem(itemsToBeDeleted[i]);
            //            workflowItemsLbx.Items.Remove(itemsToBeDeleted[i]);
            //            if(allWorkflowItems != null && allWorkflowItems.Count>0)
            //            {
            //                allWorkflowItems.Remove(itemsToBeDeleted[i]);
            //            }
            //            if (uniqueWorkflowItems != null && uniqueWorkflowItems.Count > 0)
            //            {
            //                uniqueWorkflowItems.Remove(itemsToBeDeleted[i]);
            //            }
            //        }

            //        // have an item always be selected if removing one item
            //        KeepAnItemSelected(selectedRemoveIndex,indicesCount);
            //    }

            //    // reset temporary list of items to be deleted and update labels
            //    itemsToBeDeleted.Clear();
            //    SetDatabaseDetailsProperties();
        }

        //private void KeepAnItemSelected(int selectedRemoveIndex, int indicesCount)
        //{
        //    if (indicesCount > 1)
        //    {
        //        return;
        //    }
        //    else if (selectedRemoveIndex != workflowItemsLbx.Items.Count)
        //    {
        //        workflowItemsLbx.SelectedIndex = selectedRemoveIndex;
        //    }
        //    else if (selectedRemoveIndex == workflowItemsLbx.Items.Count && selectedRemoveIndex != 0)
        //    {
        //        workflowItemsLbx.SelectedIndex = selectedRemoveIndex - 1;
        //    }
        //}

        private void workflowItemsLbx_KeyDown(object sender, KeyEventArgs e)
        {
            //    if (sender != workflowItemsLbx) return;

            //    if (e.Control && e.KeyCode == Keys.C)
            //    {
            //        copyToolStripMenuItem_Click(this,null);
            //    }

            //    if (e.KeyCode == Keys.Enter)
            //    {
            //        workflowItemsLbx_MouseDoubleClick(workflowItemsLbx, null);
            //    }
            //    if (e.KeyData == Keys.Delete)
            //    {
            //        removeBtn_Click(this, e);
            //    }
        }

        private void removeBtn_KeyDown(object sender, KeyEventArgs e)
        {
            //    workflowItemsLbx_KeyDown(workflowItemsLbx, e);
        }

        //private int CountOfDuplicates() 
        //{
        //    if (queriedItems != null && queriedItems.Count > 0)
        //    {
        //        return queriedItems.Count();
        //    }
        //    else
        //    {
        //        return 0;
        //    }
        //}

        private void queryBtn_Click(object sender, EventArgs e)
        {
            //    Cursor.Current = Cursors.WaitCursor;

            //    try
            //    {
            //        // make the lists
            //        uniqueWorkflowItems = new List<WorkflowItem>();
            //        //allWorkflowItems = new List<WorkflowItem>();
            //        queriedItems = new List<WorkflowItem>();
            //        IEnumerable<WorkflowItem> results = null;

            //        //// make a list of workFlowItems
            //        //allWorkflowItems = workflowItemsLbx.Items.OfType<WorkflowItem>().ToList();

            //        // query the list
            //        if(radioButton1.Checked==true)
            //        {
            //            results = QueryImages(allWorkflowItems);
            //        }
            //        else if(radioButton2.Checked==true)
            //        {
            //            results = QueryClutter(allWorkflowItems);
            //        }
            //        else if (radioButton4.Checked == true)
            //        {
            //            results = QueryReqTemplates(allWorkflowItems);
            //        }
            //        else 
            //        {
            //            results = QueryDuplicateCOIs(allWorkflowItems);
            //        }

            //        // populate queried items with the remaining items as long as they are still marked true (will only be false if user unmarks them manually)
            //        foreach (var item in results)
            //        {
            //            // add according to list of filter items
            //            queriedItems.Add(item);   
            //        }

            //        // if a form is open, don't open a new one
            //        if (CheckIfFormIsOpened("Queried Items Data") == false)
            //        {
            //            queriedItemsForm = new QueriedItemsDataView();
            //            queriedItemsForm.Show();
            //        }

            //        // populate the listView with the queried items
            //        queriedItemsForm.PopulateData(queriedItems);
            //        this.Focus();

            //        // register event handler
            //        queriedItemsForm.ListViewDoubleClicked += new QueriedItemEventHandler(SelectListBoxItem);

            //        // show correct count of records
            //        SetDatabaseDetailsProperties();

            //        // notify user that the query was successful
            //        SetStatusLabelAndTimer("Query was successful!");
            //    }
            //    catch (Exception )
            //    {

            //        SetStatusLabelAndTimer("Query unsuccessful.");
            //    }

            //    Cursor.Current = Cursors.Default;
        }

        //private dynamic QueryImages(List<WorkflowItem> allWorkflowItems)
        //{
        //    // query the list of all items for images
        //    var results = from item in allWorkflowItems
        //                  where item.FileName.ToLower().EndsWith(".png") &&
        //                    ImageNotAlone(allWorkflowItems, item)
        //                  select item;

        //    return results;
        //}

        //private bool ImageNotAlone(List<WorkflowItem> allWorkflowItems, WorkflowItem imageWorkflowItem)
        //{
        //    // search a temporary list
        //    imageWorkflowItems = new List<WorkflowItem>();
        //    imageWorkflowItems.AddRange(allWorkflowItems);
        //    imageWorkflowItems.Remove(imageWorkflowItem);

        //    bool val = imageWorkflowItems.Exists(x => x.EmailDate == imageWorkflowItem.EmailDate);
        //    return val;
        //}

        //private dynamic QueryClutter(List<WorkflowItem> allWorkflowItems)
        //{
        //    // query the list to get all the first occurences of the specified items
        //    var queryAllItems = from o in allWorkflowItems
        //                        group o by new
        //                        {
        //                            o.EmailDate,
        //                            o.EmailFromAddress,
        //                            o.SubjectLine,
        //                            o.FileName
        //                        } into g
        //                        select g.ToList().First();

        //    // add the items to the unique items list. this will clear items if they are alone, and if not then it will only clear the first occurence, leaving the duplicates
        //    foreach (var item in queryAllItems)
        //    {
        //        WorkflowItem tmp = item;
        //        uniqueWorkflowItems.Add(tmp);
        //    }

        //    // if an item is listed in the unique items, run a query to set excluded IDs
        //    var excludedIDs = new HashSet<string>(uniqueWorkflowItems.Select(o => o.DocumentWorkflowItemID));

        //    // query to remove items with excluded IDs
        //    var results = from item in allWorkflowItems
        //                  where !(excludedIDs.Contains(item.DocumentWorkflowItemID))
        //                  select item;

        //    return results;
        //}

        //private dynamic QueryDuplicateCOIs(List<WorkflowItem> allWorkflowItems)
        //{
        //    // query the list
        //    var queryAllItems = from o in allWorkflowItems
        //                        group o by o.FileName into g
        //                        select g.ToList().First();

        //    // set or update the unique items list
        //    foreach (var item in queryAllItems)
        //    {
        //        // the items left are unique so bool data must be changed. add these items to our unique items list
        //        WorkflowItem tmp = item;
        //        //tmp.IsDuplicate = false;
        //        uniqueWorkflowItems.Add(tmp);
        //    }

        //    // if an item is listed in the unique items, run a query to set excluded IDs
        //    var excludedIDs = new HashSet<string>(uniqueWorkflowItems.Select(o => o.DocumentWorkflowItemID));

        //    // query to remove items with excluded IDs, common filenames, and unmarked duplicate values
        //    var results = from item in allWorkflowItems
        //                  where !(excludedIDs.Contains(item.DocumentWorkflowItemID)) &&
        //                     FilterFileName(item.FileName) 
        //                     //&&
        //                     //item.IsDuplicate
        //                  select item;

        //    return results;
        //}

        //private bool FilterFileName(string fileName)
        //{
        //    // immediately let fileName pass through if it has certain words, unless...
        //    if(
        //        (fileName.ToLower().Contains("coi") &&
        //            fileName != "CBRE COI.pdf" &&
        //            fileName != "COI CBRE.pdf" &&
        //            fileName != "COI & Forms.pdf" &&
        //            fileName.StartsWith("PRIDE ELECRIC COI ENDTS") != true &&
        //            fileName.StartsWith("MCKINSTRY") != true &&
        //            fileName.ToLower() != "coi.pdf" &&
        //            fileName.ToLower() != "coi 2018.pdf") ||

        //        (fileName.ToLower().Contains("cert") &&
        //            fileName != "certusfile.dat" &&
        //            fileName != "certusfile.eml" &&
        //            fileName != "Certificate of Insurance.pdf" &&
        //            fileName != "Certificate of Liability Insurance.pdf" &&
        //            fileName != "Certificate of Insurance for Garratt Callahan Company.pdf" &&
        //            fileName != "Revised Certificate.pdf" &&
        //            fileName != "certpros.pdf" &&
        //            fileName.ToLower() != "certificate.pdf" &&
        //            fileName.ToLower() != "certificate (1).pdf" &&
        //            fileName.ToLower() != "cert_print.pdf" &&
        //            fileName.ToLower() != "cert.pdf") ||

        //        fileName.ToLower().Contains("acord") &&
        //            fileName.ToLower().StartsWith("acord_25") != true
        //        )
        //    {
        //        return true;
        //    }
        //    // let fileName pass through if it doesn't have these words
        //    else if (
        //        fileName != "" &&
        //        fileName != "certusfile.dat" &&
        //        fileName != "certusfile.eml" &&
        //        fileName != "CBRE COI.pdf" &&
        //        fileName != "COI CBRE.pdf" &&
        //        fileName != "Requirement Template.pdf" &&
        //        fileName != "RequirementTemplate.pdf" &&
        //        fileName != "Certificate (1).pdf" &&
        //        fileName != "RAW.pdf" &&
        //        fileName != "CBRE Global Investors, LLC.pdf" &&
        //        fileName != "Google LLC.pdf" &&
        //        fileName != "EQC Operating Trust.pdf" &&
        //        fileName != "Forms.pdf" &&
        //        fileName != "FFII TX Westway LP.pdf" &&
        //        fileName != "Certificate of Insurance.pdf" &&
        //        fileName != "Certificate of Liability Insurance.pdf" &&
        //        fileName != "PDF Creator.pdf" &&
        //        fileName != "1 Forms All 2018.pdf" &&
        //        fileName != "SelectiveElitePac_Ext 2016.pdf" &&
        //        fileName != "DOC013018.pdf" &&
        //        fileName != "Original Request.pdf" &&
        //        fileName != "a.pdf" &&
        //        fileName != "0.pdf" &&
        //        fileName != "Certificate of Insurance for Garratt Callahan Company.pdf" &&
        //        fileName != "Revised Certificate.pdf" &&
        //        fileName != "certpros.pdf" &&
        //        fileName.ToLower() != "certificate.pdf" &&
        //        fileName.ToLower() != "certificate (1).pdf" &&
        //        fileName.ToLower() != "attachment.pdf" &&
        //        fileName.ToLower() != "attachment 1.pdf" &&
        //        fileName.ToLower() != "coi.pdf" &&
        //        fileName.ToLower() != "coi 2018.pdf" &&
        //        fileName.ToLower() != "cbre.pdf" &&
        //        fileName.ToLower() != "cert.pdf" &&
        //        fileName.ToLower() != "cert_print.pdf" &&
        //        fileName.ToLower() != "scan.pdf" &&
        //        fileName.ToLower() != "document.pdf" &&
        //        fileName.ToLower() != "cbre inc.pdf" &&
        //        fileName.ToLower() != "coi 2018.pdf" &&
        //        fileName.ToLower() != "previewliabilityholder.aspx.pdf" &&
        //        fileName.StartsWith("ATT000") != true &&
        //        fileName.StartsWith("HEALT") != true &&
        //        fileName.StartsWith("CLEAN") != true &&
        //        fileName.StartsWith("PRIDE ELECRIC COI ENDTS") != true &&
        //        fileName.StartsWith("MCKINSTRY") != true &&
        //        fileName.EndsWith(".png") != true &&
        //        fileName.EndsWith(".jpg") != true &&
        //        fileName.Contains("AI") != true &&
        //        fileName.Contains("GL") != true &&
        //        fileName.Contains("WC") != true &&
        //        fileName.Contains("CA") != true &&
        //        fileName.Contains("WOS") != true &&
        //        fileName.Contains("CSR24") != true &&
        //        fileName.Contains("PNC") != true &&
        //        fileName.Contains("PPA") != true &&
        //        fileName.Contains("AC") != true &&
        //        fileName.Contains("2037") != true &&
        //        fileName.Contains("2010") != true &&
        //        fileName.Contains("GA") != true &&
        //        fileName.Contains("Umbrella") != true &&
        //        fileName.Contains("CNA") != true &&
        //        fileName.Contains("UL") != true &&
        //        fileName.Contains("W9") != true &&
        //        fileName.ToLower().Contains("auto") != true &&
        //        fileName.ToLower().Contains("loss payee") != true &&
        //        fileName.ToLower().Contains("primary ") != true &&
        //        fileName.ToLower().Contains("additional insured") != true &&
        //        fileName.ToLower().Contains("waiver") != true &&
        //        fileName.ToLower().Contains("workers") != true &&
        //        fileName.ToLower().Contains("comp") != true &&
        //        fileName.ToLower().Contains("ongoing") != true &&
        //        fileName.ToLower().Contains("attachments") != true &&
        //        fileName.ToLower().Contains("umb") != true &&
        //        fileName.ToLower().Contains("underlying") != true &&
        //        fileName.ToLower().Contains("schedule") != true &&
        //        fileName.ToLower().Contains("endt") != true &&
        //        fileName.ToLower().Contains("endo") != true &&
        //        fileName.ToLower().Contains("cg") != true &&
        //        fileName.ToLower().StartsWith("acord_25") != true)

        //        //// filter if endt is not in a file name with coi or cert
        //        //(fileName.ToLower().Contains("endts") && !(fileName.ToLower().Contains("coi"))) != true &&
        //        //(fileName.ToLower().Contains("endo") && !(fileName.ToLower().Contains("coi"))) != true &&
        //        //(fileName.ToLower().Contains("endts") && !(fileName.ToLower().Contains("cert"))) != true &&
        //        //(fileName.ToLower().Contains("endo") && !(fileName.ToLower().Contains("cert"))) != true 
        //        //)
        //    {
        //        return true;
        //    }
        //    // fileName gets filtered. It doesn't pass through with accepted words and it gets knocked out by a filtered word.
        //    else
        //    {
        //        return false;
        //    }
        //}

        //private dynamic QueryReqTemplates(List<WorkflowItem> allWorkflowItems)
        //{
        //    // query the list of all items for req's
        //    var results = from item in allWorkflowItems
        //                  where item.FileName.ToLower().Contains("requirement") &&
        //                    RequirementNotAlone(allWorkflowItems, item)
        //                  select item;

        //    return results;
        //}

        //private bool RequirementNotAlone(List<WorkflowItem> allWorkflowItems, WorkflowItem requirementWorkflowItem)
        //{
        //    // search a temporary list
        //    requirementWorkflowItems = new List<WorkflowItem>();
        //    requirementWorkflowItems.AddRange(allWorkflowItems);
        //    requirementWorkflowItems.Remove(requirementWorkflowItem);

        //    bool val = requirementWorkflowItems.Exists(x => x.EmailDate == requirementWorkflowItem.EmailDate);
        //    return val;
        //}

        //// currently has no function
        private void removeDupsBtn_Click(object sender, EventArgs e)
        {
            //    Cursor.Current = Cursors.WaitCursor;
            //    List<WorkflowItem> uniqueWorkflowItems = new List<WorkflowItem>();
            //    allWorkflowItems = new List<WorkflowItem>();
            //    int duplicates = CountOfDuplicates();
            //    int totalObjects = workflowItemsLbx.Items.Count;
            //    int uniqueObjects = totalObjects - duplicates;
            //    int uniqueObjectBackUpNumber = uniqueObjects;

            //    // make a list of the objects from the Lbx
            //    for (int i = 0; i < totalObjects; i++)
            //    {
            //        allWorkflowItems.Add((WorkflowItem)workflowItemsLbx.Items[i]);
            //    }

            //    // make a new list of only unique objects 
            //    var query = allWorkflowItems
            //            .GroupBy(o => o.FileName)
            //            .Select(o => o.First())
            //            .ToList();

            //    foreach (var result in query) //needs to be changed for all DBs
            //    {
            //        WorkflowItem tmpWorkflowItem = new WorkflowItem();

            //        tmpWorkflowItem.DocumentWorkflowItemID = null; //need to add original back
            //        tmpWorkflowItem.ContractID = result.ContractID;
            //        tmpWorkflowItem.CompanyName = result.CompanyName;
            //        tmpWorkflowItem.Active = result.Active;
            //        tmpWorkflowItem.Compliant = result.Compliant;
            //        tmpWorkflowItem.NextExpirationDate = result.NextExpirationDate;
            //        tmpWorkflowItem.WorkflowAnalyst = result.WorkflowAnalyst;
            //        tmpWorkflowItem.CompanyAnalyst = result.CompanyAnalyst;
            //        tmpWorkflowItem.EmailDate = result.EmailDate;
            //        tmpWorkflowItem.EmailFromAddress = result.EmailFromAddress;
            //        tmpWorkflowItem.SubjectLine = result.SubjectLine;
            //        tmpWorkflowItem.Status = result.Status;
            //        tmpWorkflowItem.CertusFileID = result.CertusFileID;
            //        tmpWorkflowItem.FileName = result.FileName;
            //        tmpWorkflowItem.FileURL = null; //need to add original back

            //        uniqueWorkflowItems.Add(tmpWorkflowItem);
            //    }
            //    // Clear the listbox and database
            //    workflowItemsLbx.Items.Clear();
            //    workflowItemsDatabase.RemoveObjectsFromDB("workflow items");

            //    // populate database and list box with new items
            //    for (int i = 0; i < uniqueObjectBackUpNumber; i++)
            //    {
            //        workflowItemsDatabase.AddWorkflowItem(uniqueWorkflowItems[i].DocumentWorkflowItemID, uniqueWorkflowItems[i].ContractID, uniqueWorkflowItems[i].CompanyName, uniqueWorkflowItems[i].Active, uniqueWorkflowItems[i].Compliant, uniqueWorkflowItems[i].NextExpirationDate, uniqueWorkflowItems[i].WorkflowAnalyst, uniqueWorkflowItems[i].CompanyAnalyst, uniqueWorkflowItems[i].EmailDate, uniqueWorkflowItems[i].EmailFromAddress, uniqueWorkflowItems[i].SubjectLine, uniqueWorkflowItems[i].Status, uniqueWorkflowItems[i].CertusFileID, uniqueWorkflowItems[i].FileName, uniqueWorkflowItems[i].FileURL);
            //    }
            //    workflowItemsLbx.Items.AddRange(workflowItemsDatabase.ReturnAllWorkflowItems());

            //    SetDatabaseDetailsProperties();
            //    //queriedItemsForm.PopulateData(queriedItems);
            //    Cursor.Current = Cursors.Default;
        }

        private void formTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            //    if (formTabControl.SelectedTab == formTabControl.TabPages["workflowItemsTabPage"])
            //    {
            //        //change field label names
            //        fieldDescLbl1.Text = "Workflow Item ID:";
            //        fieldDescLbl2.Text = "Company Name:";
            //        fieldDescLbl3.Text = "Email Date:";
            //        fieldDescLbl4.Text = "Email From Address:";
            //        fieldDescLbl5.Text = "Subject Line:";
            //        fieldDescLbl6.Text = "File Name:";

            //        ClearFields();
            //        // repopulate fields with the selected index item
            //        workflowItemsLbx_SelectedIndexChanged(this, e);
            //    }
        }

        //private void ClearFields()
        //{
        //    fieldLbl1.Text = String.Empty;
        //    fieldLbl2.Text = String.Empty;
        //    fieldLbl3.Text = String.Empty;
        //    fieldLbl4.Text = String.Empty;
        //    fieldLbl5.Text = String.Empty;
        //    fieldLbl6.Text = String.Empty;
        //}

        //private void SetDatabaseDetailsProperties() 
        //{
        //    recordsLbl.Text = workflowItemsLbx.Items.Count.ToString();
        //    queriedItemsLbl.Text = CountOfDuplicates().ToString();
        //}


        private void searchTbx_TextChanged(object sender, EventArgs e)
        {
            //    // reset starting index for the search function
            //    searchIndex = 0;

            //    // set the tbx to the search value
            //    searchVal = searchTbx.Text;

            //    // show/hide buttons
            //    searchLbl.Visible = true;
            //    clearBtn.Visible = false;

            //    //remove label telling the user to type whenever text is in the tbx
            //    if (searchVal != String.Empty)
            //    {
            //        searchLbl.Visible = false;
            //        clearBtn.Visible = true;
            //    }

        }

        private void searchTbx_KeyDown(object sender, KeyEventArgs e)
        {
            //    // status strip shouldn't confuse the user once they begin typing, so reset
            //    toolStripStatusLabel.Text = "Ready";
            //    timer.Enabled = false;

            //    if (e.KeyCode == Keys.Enter)
            //    {
            //        searchVal = searchTbx.Text;
            //        searchTbx.SelectAll();

            //        try
            //        {
            //            if (searchVal != String.Empty)
            //            {
            //                workflowItemsLbx.ClearSelected();
            //                workflowItemsLbx.SetSelected(FindMyStringInList(workflowItemsLbx, searchVal, searchIndex), true);
            //                e.Handled = true;
            //                e.SuppressKeyPress = true;
            //            }
            //            else
            //            {
            //                SetStatusLabelAndTimer("Cannot find data.");
            //            }
            //        }
            //        catch (Exception)
            //        {
            //            if(searchIndex>0)
            //            {
            //                workflowItemsLbx.SelectedIndex = searchIndex-1;
            //                SetStatusLabelAndTimer("End of data.");
            //                searchIndex = 0;
            //                return;
            //            }
            //            SetStatusLabelAndTimer("Cannot find data.");
            //        }
            //    }
        }

        //private int FindMyStringInList(ListBox lb, string searchString, int startIndex)
        //{
        //    for (int i = startIndex; i < lb.Items.Count; ++i)
        //    {
        //        string lbString = lb.Items[i].ToString();
        //        if (lbString.Contains(searchString))
        //        {
        //            searchIndex = i+1;
        //            return i;
        //        }
        //    }
        //    return -1;
        //}

        //private void SelectListBoxItem(object sender, string docID)
        //{
        //    try
        //    {
        //        workflowItemsLbx.ClearSelected();
        //        workflowItemsLbx.SetSelected(FindMyStringInList(workflowItemsLbx, docID, 0), true);
        //        openDataInNewWindowToolStripMenuItem_Click(workflowItemsLbx, null);
        //        //queriedItemsForm.Focus();
        //    }
        //    catch (Exception)
        //    {
        //        SetStatusLabelAndTimer("Woops, something went wrong...");
        //    }
        //}

        private void highlightBtn_Click(object sender, EventArgs e)
        {
            //    if (sender != null)
            //    {
            //        searchTbx.Focus();
            //        searchTbx.SelectAll();
            //    }
    }

    private void workflowItemsLbx_MouseDown(object sender, MouseEventArgs e)
        {
            //    switch (e.Button)
            //    {
            //        case MouseButtons.Right:
            //            {
            //                workflowItemsLbx.ClearSelected();
            //                workflowItemsLbx.SelectedIndex = workflowItemsLbx.IndexFromPoint(e.X, e.Y);
            //                //place menu at the pointer position
            //                listboxContextMenuStrip.Show(this, new Point(e.X + 38, e.Y + 83));
            //            }
            //            break;
            //    }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //    removeBtn_Click(this, e);
        }

        private void unmarkAsDuplicateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //    if (workflowItemsLbx.SelectedItem != null && workflowItemsLbx.Items.Count > 0)
            //    {
            //        itemsToBeDeletedFromQuery = new List<WorkflowItem>();
            //        if (itemsUnmarkedAsDuplicate == null)
            //        {
            //            itemsUnmarkedAsDuplicate = new List<WorkflowItem>();
            //        }
            //        int indicesBackUpCount;
            //        int selectedUnmarkIndex;
            //        if (workflowItemsLbx.SelectedItem != null && workflowItemsLbx.Items.Count > 0)
            //        {
            //            indicesBackUpCount = workflowItemsLbx.SelectedIndices.Count;
            //            selectedUnmarkIndex = workflowItemsLbx.SelectedIndex;
            //            // make a list of the selected items
            //            for (int i = 0; i < indicesBackUpCount; i++)
            //            {
            //                itemsToBeDeletedFromQuery.Add((WorkflowItem)workflowItemsLbx.SelectedItems[i]);
            //                uniqueWorkflowItems.Add((WorkflowItem)workflowItemsLbx.SelectedItems[i]);
            //            }
            //            // make not show up on query list and remove from query list
            //            for (int i = 0; i < indicesBackUpCount; i++)
            //            {
            //                queriedItems.Remove(itemsToBeDeletedFromQuery[i]);
            //                itemsUnmarkedAsDuplicate.Add(itemsToBeDeletedFromQuery[i]);
            //            }
            //        }

            //        itemsToBeDeletedFromQuery.Clear();
            //        SetDatabaseDetailsProperties();
            //    }
        }

        //private void saveListChangesToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    saveFileDialog.FileName = "";
        //    saveFileDialog.Filter = "App Data Files (*.dat)|*.dat|All Files (*.*)|*.*";

        //    DialogResult dialogResult = saveFileDialog.ShowDialog();

        //    if (dialogResult == DialogResult.OK)
        //    {
        //        string fileName = saveFileDialog.FileName;
        //        try
        //        {
        //            FileStream file = new FileStream(fileName, FileMode.Create, FileAccess.Write);
        //            BinaryFormatter bf = new BinaryFormatter();
        //            bf.Serialize(file, itemsUnmarkedAsDuplicate);
        //            file.Close();
        //        }
        //        catch (Exception)
        //        {
        //            SetStatusLabelAndTimer("Save unsuccessful.");
        //        }
        //        SetStatusLabelAndTimer("Changes saved successfully!");
        //    }
        //}


        ////private void loadListChangesToolStripMenuItem_Click(object sender, EventArgs e)
        ////{
        ////    try
        ////    {
        ////        openFileDialog.FileName = "";
        ////        openFileDialog.Filter = "App Data Files (*.dat)|*.dat|All Files (*.*)|*.*";
        ////        openFileDialog.FilterIndex = 1;

        ////        DialogResult dialogResult = openFileDialog.ShowDialog();

        ////        if (dialogResult == DialogResult.OK)
        ////        {
        ////            string fileName = openFileDialog.FileName;

        ////            FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
        ////            BinaryFormatter bf = new BinaryFormatter();
        ////            itemsUnmarkedAsDuplicate = (List<WorkflowItem>)bf.Deserialize(file);
        ////        }

        ////        var excludedItems = new HashSet<bool>(itemsUnmarkedAsDuplicate.Select(o => o.IsDuplicate));

        ////        foreach (WorkflowItem item in workflowItemsLbx.Items)
        ////        {
        ////            if (excludedItems.Contains(item.IsDuplicate))
        ////            {
        ////                item.IsDuplicate = false;
        ////            }
        ////        }

        ////        SetDatabaseDetailsProperties();
        ////    }
        ////    catch (Exception)
        ////    {
        ////        SetStatusLabelAndTimer("Data loading unsuccessful");
        ////    }
        ////    SetStatusLabelAndTimer("Changes loaded successfully!");
        ////}

        private void dataFormBtn_Click(object sender, EventArgs e)
        {
            //    workflowItemsLbx_MouseDoubleClick(workflowItemsLbx, null);
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            //    searchTbx.Focus();
            //    searchTbx.Text = String.Empty;
        }

        private void fullScrnBtn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            WorkflowManager form;

            if (this.AppData != null)
            {
                form = new WorkflowManager(this.AppData);
            }
            else
            {
                form = new WorkflowManager();
            }

            //try
            //{
            //    form.PopulateListViewData();
            //}
            //catch (Exception)
            //{
            //    SetStatusLabelAndTimer("Data could not be added to the form.");
            //    System.Media.SystemSounds.Hand.Play();
            //}

            form.Show();
            Cursor.Current = Cursors.Default;
        }

        private void openDataInNewWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //    if (workflowItemsLbx.SelectedItem == null)
            //        return;

            //    // get the question which is currently selected
            //    selectedWorkflowItem = (WorkflowItem)workflowItemsLbx.SelectedItem;

            //    // create copy of the form 
            //    WorkflowItemDataView workflowItemFormView = new WorkflowItemDataView();

            //    // register the event handler 
            //    workflowItemFormView.CopyIdBtnClicked += new CopyItemEventHandler(WorkflowItemsForm_CopyIdBtnClicked);

            //    // show the form and set it to show details of the selected question
            //    workflowItemFormView.Show();
            //    workflowItemFormView.PopulateData(selectedWorkflowItem);
            //    workflowItemFormView.Focus();
            //this.Focus();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //    if ((workflowItemsLbx.SelectedItem as WorkflowItem).FileName == "")
            //    {
            //        Clipboard.Clear();
            //    }
            //    else
            //    {
            //        Clipboard.SetText((workflowItemsLbx.SelectedItem as WorkflowItem).FileName.ToString());
            //    }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Ready";
        }

        public void SetStatusLabelAndTimer(string statusLblMessage)
        {
            toolStripStatusLabel.Text = statusLblMessage;
            timer.Enabled = true;
        }

        private void openLinkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //    Cursor.Current = Cursors.WaitCursor;
            //    string targetURL = (workflowItemsLbx.SelectedItem as WorkflowItem).FileURL.ToString();

            //    System.Diagnostics.Process.Start(targetURL);
            //    Cursor.Current = Cursors.Default;
            //}

            //private void connectBtn_Click(object sender, EventArgs e)
            //{
            //    //WebClient client = new WebClient();
            //    //client.BaseAddress = "https://www.bcscertus.com/workflow.aspx?c=36";
        }
    }
}
