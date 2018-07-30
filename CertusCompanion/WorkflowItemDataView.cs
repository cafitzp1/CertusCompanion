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
    public delegate void WorkflowItemEventHandler(object sender, WorkflowItem wi);
    public delegate void CheckBoxEventHandler(object sender, bool isChecked, bool isIgnored, WorkflowItem wi);
    public delegate void CopyItemEventHandler(object sender, string itemId);

    public partial class WorkflowItemDataView : Form
    {
        NoteForm note;
        WorkflowItem currentWorkflowItem;
        List<WorkflowItem> uniqueItems;
        List<TextBox> tbxList;
        //bool isIgnored;
        
        public event WorkflowItemEventHandler NextBtnClicked;
        public event WorkflowItemEventHandler PrevBtnClicked;
        public event WorkflowItemEventHandler LastBtnClicked;
        //public event CheckBoxEventHandler DuplicateChBxCheckedChanged;
        public event CopyItemEventHandler CopyIdBtnClicked;

        public WorkflowItemDataView()
        {
            InitializeComponent();

            this.Text = "View Data Form";
            nextBtn.Enabled = false;
            prevBtn.Enabled = false;
            lastBtn.Enabled = false;
            //button101.ImageList = null;
            //button101.Enabled = false;
        }

        public WorkflowItemDataView(List<WorkflowItem> uniqueItems)
        {
            InitializeComponent();

            //this.uniqueItems = new List<WorkflowItem>();
            this.uniqueItems = uniqueItems;
        }

        private void WorkflowItemData_Load(object sender, EventArgs e)
        {
            ShiftControls();
        }

        private void ShiftControls()
        {
            tbxList = new List<TextBox>();

            int tabIndex = 0;

            // move controls in run time
            foreach (Panel panel in Controls.OfType<Panel>())
            {
                panel.Top += 1;
                panel.TabIndex = 15 - tabIndex;
                ++tabIndex;
                panel.TabStop = false;

                // manipulate controls within panels
                foreach (TextBox tbx in panel.Controls.OfType<TextBox>())
                {
                    tbx.Top += 1;
                    tbx.HideSelection = true;
                    (tbx).Left += 1;
                    tbxList.Add(tbx);
                    tbx.ReadOnly = true;
                }
                foreach (Button btn in panel.Controls.OfType<Button>())
                {
                    if (btn.Name.Count() < 9 || btn.Name.ToString() == "button101")
                    {
                        btn.Top -= 1;
                        if (btn.Name.Count() < 9)
                        {
                            btn.ImageList = imageList1;
                        }
                        btn.ImageIndex = 0;
                        btn.FlatAppearance.MouseOverBackColor = btn.BackColor;
                        btn.BackColorChanged += (s, e) => {
                            btn.FlatAppearance.MouseOverBackColor = btn.BackColor;
                        };
                    }
                    else
                    {
                        btn.Enabled = false;
                    }

                    btn.TabStop = false;
                }
            }
        }

        public void PopulateData(WorkflowItem wi)
        {
            currentWorkflowItem = wi;

            lastItemLbl.Text = String.Empty;
            documentWorkflowItemIdTbx.Text = wi.DocumentWorkflowItemID;
            contractIdTbx.Text = wi.ContractID;
            companyNameTbx.Text = wi.VendorName;
            activeTbx.Text = wi.Active.ToString();
            compliantTbx.Text = wi.Compliant.ToString();
            nextExpDateTbx.Text = wi.NextExpirationDate.ToString();
            workflowAnalystTbx.Text = wi.WorkflowAnalyst;
            companyAnalystTbx.Text = wi.CompanyAnalyst;
            emailDateTbx.Text = wi.EmailDate.ToString();
            emailFromTbx.Text = wi.EmailFromAddress;
            subjectTbx.Text = wi.SubjectLine;
            statusTbx.Text = wi.Status;
            certusFileIdTbx.Text = wi.CertusFileID;
            fileNameTbx.Text = wi.FileName;
            fileUrlTbx.Text = wi.FileURL;
        }

        public void PopulateData(WorkflowItem wi, string lastItem)
        {
            currentWorkflowItem = wi;

            lastItemLbl.Text = String.Empty;
            documentWorkflowItemIdTbx.Text = wi.DocumentWorkflowItemID;
            contractIdTbx.Text = wi.ContractID;
            companyNameTbx.Text = wi.VendorName;
            activeTbx.Text = wi.Active.ToString();
            compliantTbx.Text = wi.Compliant.ToString();
            nextExpDateTbx.Text = wi.NextExpirationDate.ToString();
            workflowAnalystTbx.Text = wi.WorkflowAnalyst;
            companyAnalystTbx.Text = wi.CompanyAnalyst;
            emailDateTbx.Text = wi.EmailDate.ToString();
            emailFromTbx.Text = wi.EmailFromAddress;
            subjectTbx.Text = wi.SubjectLine;
            statusTbx.Text = wi.Status;
            certusFileIdTbx.Text = wi.CertusFileID;
            fileNameTbx.Text = wi.FileName;
            fileUrlTbx.Text = wi.FileURL;

            lastItemLbl.Text = lastItem;
        }

        private void CheckCheckBox(CheckBox checkBox)
        {
            //this.isIgnored = true;

            bool containsItem = uniqueItems.Any(item => item.DocumentWorkflowItemID == currentWorkflowItem.DocumentWorkflowItemID);

            if (containsItem)
            {
                checkBox.Checked = false;
            }
            else
            {
                checkBox.Checked = true;
            }
            //this.isIgnored = false;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void openFileBtn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string targetURL = fileUrlTbx.Text;

            System.Diagnostics.Process.Start(targetURL);
            Cursor.Current = Cursors.Default;
        }

        private void highlightBtn_Click(object sender, EventArgs e)
        {
            if (sender != null)
            {
                string buttonNum;

                if (((Button)sender).Name.Length == 7)
                {
                    buttonNum = ((Button)sender).Name.Substring(6, 1);
                }
                else
                {
                    buttonNum = ((Button)sender).Name.Substring(6, 2);
                }

                tbxList[16- Convert.ToInt32(buttonNum) -1].Focus();
                tbxList[16- Convert.ToInt32(buttonNum) -1].SelectAll();
            }
        }

        private void copyIdBtn_Click(object sender, EventArgs e)
        {
            string itemId = documentWorkflowItemIdTbx.Text;

            if (CopyIdBtnClicked != null)
                CopyIdBtnClicked(this, itemId);
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            if (NextBtnClicked != null)
                NextBtnClicked(this, currentWorkflowItem);
        }

        private void prevBtn_Click(object sender, EventArgs e)
        {
            if (PrevBtnClicked != null)
                PrevBtnClicked(this, currentWorkflowItem);
        }

        //private void duplicateChBx_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (DuplicateChBxCheckedChanged != null)
        //        DuplicateChBxCheckedChanged(this, duplicateChBx.Checked, this.isIgnored, currentWorkflowItem);
        //}

        private void noteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // if there's currently a note, close it
                if ((Application.OpenForms[0] as MainForm).CheckIfFormIsOpened("Note"))
                {
                    note.Close();
                }

                // make a new note
                note = new NoteForm();
                note.Populate(currentWorkflowItem);
                note.ShowDialog(this);
            }
            catch (Exception)
            {
                // send a notification to the main form and set focus to it
                (Application.OpenForms[0] as MainForm).SetStatusLabelAndTimer("Something went wrong. Could not generate the note.");
                (Application.OpenForms[0] as MainForm).Focus();

                // make a ding
                System.Media.SystemSounds.Hand.Play();
            }
        }

        private void lastBtn_Click(object sender, EventArgs e)
        {
            if (LastBtnClicked != null)
                LastBtnClicked(this, currentWorkflowItem);
        }
    }
}
