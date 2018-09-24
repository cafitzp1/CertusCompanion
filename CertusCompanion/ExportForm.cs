using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CertusCompanion
{
    public delegate void ExportEventHandler(object sender, Export filter);

    public partial class ExportForm : Form
    {
        #region ExportForm Data
        public bool DocumentWorkflowItemIDCheckChoice { get; set; }
        public bool CertificateIDCheckChoice { get; set; }
        public int CertificateComboBoxSelectedIndex { get; set; }
        public bool CompanyNameCheckChoice { get; set; }
        public int CompanyComboBoxSelectedIndex { get; set; }
        public bool ActiveCheckChoice { get; set; }
        public bool CompliantCheckChoice { get; set; }
        public bool IssueDateCheckChoice { get; set; }
        public int CertificateDateComboBoxSelectedIndex { get; set; }
        public bool WorkflowAnalystCheckChoice { get; set; }
        public int WorkflowAnalystComboBoxSelectedIndex { get; set; }
        public bool ComplianceAnalystCheckChoice { get; set; }
        public int ComplianceAnalystComboBoxSelectedIndex { get; set; }
        public bool EmailDateCheckChoice { get; set; }
        public bool EmailFromAddressCheckChoice { get; set; }
        public bool SubjectLineCheckChoice { get; set; }
        public bool StatusCheckChoice { get; set; }
        public bool CertusFileIDCheckChoice { get; set; }
        public bool FileNameCheckChoice { get; set; }
        public bool FileURLCheckChoice { get; set; }
        public bool FileSizeCheckChoice { get; set; }
        public bool FileMIMECheckChoice { get; set; }
        public bool AssignedToCheckChoice { get; set; }
        public int AssignedToComboBoxSelectedIndex { get; set; }
        public bool DisplayColorCheckChoice { get; set; }
        public bool ItemsAttachedCheckChoice { get; set; }
        public bool NoteCheckChoice { get; set; }
        public int PresetsComboBoxSelectedIndex { get; set; }
        public Export CurrentExport { get; set; }
        public List<WorkflowItem> ItemListToExport { get; set; }
        #endregion

        //
        // constructor for a new export
        public ExportForm(List<WorkflowItem> itemListToExport)
        {
            InitializeComponent();
            this.ItemListToExport = itemListToExport;

            this.presetsComboBox.SelectedIndex = 0;
        }
        //
        // constructor for a prepopulated export (not currently in use)
        public ExportForm(List<WorkflowItem> itemListToExport, Export export)
        {
            InitializeComponent();
            this.ItemListToExport = itemListToExport;
            this.CurrentExport = export;

            this.presetsComboBox.SelectedIndex = 0;
        }
        private void ExportForm_Load(object sender, EventArgs e)
        {
            exportBtn.Focus();
        }

        //
        // form functionality
        private void exportBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // save form changes
                this.Save();

                // create export
                this.GenerateExport();

                // output to CSV
                this.WriteCSV();

                // notify on items view
                (Application.OpenForms["ItemsView"] as ItemsView).SetStatusLabelAndTimer("Export to CSV successful. The file has been placed on your desktop.");

                // close
                this.Close();
                this.DialogResult = DialogResult.OK;
            }
            catch
            {
                statusLbl.Visible = true;
                statusLbl.Text = "Could not process the request";
                System.Media.SystemSounds.Hand.Play();
            }
        }
        private void clearBtn_Click(object sender, EventArgs e)
        {
            // clear data
            //this.documentWorkflowItemIDCheckBox.Checked = false;
            this.certificateIDCheckBox.Checked = false;
            this.companyNameCheckBox.Checked = false;
            this.activeCheckBox.Checked = false;
            this.compliantCheckBox.Checked = false;
            this.certificateDateCheckBox.Checked = false;
            this.workflowAnalystCheckBox.Checked = false;
            this.complianceAnalystCheckBox.Checked = false;
            this.emailDateCheckBox.Checked = false;
            this.emailFromCheckBox.Checked = false;
            this.subjectLineCheckBox.Checked = false;
            this.statusCheckBox.Checked = false;
            this.certusFileIDCheckBox.Checked = false;
            this.fileNameCheckBox.Checked = false;
            this.fileURLCheckBox.Checked = false;
            this.fileMIMECheckBox.Checked = false;
            this.fileSizeCheckBox.Checked = false;
            this.assignedToCheckBox.Checked = false;
            this.assignedToComboBox.SelectedIndex = 0;
            this.displayColorCheckBox.Checked = false;
            this.itemsAttachedCheckBox.Checked = false;
            this.noteCheckBox.Checked = false;
            this.presetsComboBox.SelectedIndex = -1;
        }
        private void presetsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if((string)presetsComboBox.SelectedItem == "Default")
            {
                this.documentWorkflowItemIDCheckBox.Checked = true;
                this.certificateIDCheckBox.Checked = true;
                this.companyNameCheckBox.Checked = true;
                this.activeCheckBox.Checked = true;
                this.compliantCheckBox.Checked = true;
                this.certificateDateCheckBox.Checked = true;
                this.workflowAnalystCheckBox.Checked = true;
                this.complianceAnalystCheckBox.Checked = true;
                this.emailDateCheckBox.Checked = true;
                this.emailFromCheckBox.Checked = true;
                this.subjectLineCheckBox.Checked = true;
                this.statusCheckBox.Checked = true;
                this.certusFileIDCheckBox.Checked = true;
                this.fileNameCheckBox.Checked = true;
                this.fileURLCheckBox.Checked = true;
                this.fileMIMECheckBox.Checked = true;
                this.fileSizeCheckBox.Checked = true;
                this.assignedToCheckBox.Checked = false;
                this.assignedToComboBox.SelectedIndex = 0;
                this.displayColorCheckBox.Checked = false;
                this.itemsAttachedCheckBox.Checked = false;
                this.noteCheckBox.Checked = false;
            }
            else if ((string)presetsComboBox.SelectedItem == "Item IDs Only")
            {
                this.documentWorkflowItemIDCheckBox.Checked = true;
                this.certificateIDCheckBox.Checked = false;
                this.companyNameCheckBox.Checked = false;
                this.activeCheckBox.Checked = false;
                this.compliantCheckBox.Checked = false;
                this.certificateDateCheckBox.Checked = false;
                this.workflowAnalystCheckBox.Checked = false;
                this.complianceAnalystCheckBox.Checked = false;
                this.emailDateCheckBox.Checked = false;
                this.emailFromCheckBox.Checked = false;
                this.subjectLineCheckBox.Checked = false;
                this.statusCheckBox.Checked = false;
                this.certusFileIDCheckBox.Checked = false;
                this.fileNameCheckBox.Checked = false;
                this.fileURLCheckBox.Checked = false;
                this.fileMIMECheckBox.Checked = false;
                this.fileSizeCheckBox.Checked = false;
                this.assignedToCheckBox.Checked = false;
                this.assignedToComboBox.SelectedIndex = 0;
                this.displayColorCheckBox.Checked = false;
                this.itemsAttachedCheckBox.Checked = false;
                this.noteCheckBox.Checked = false;
            }
            else if ((string)presetsComboBox.SelectedItem == "Item Assignment")
            {
                this.documentWorkflowItemIDCheckBox.Checked = true;
                this.certificateIDCheckBox.Checked = false;
                this.companyNameCheckBox.Checked = false;
                this.activeCheckBox.Checked = false;
                this.compliantCheckBox.Checked = false;
                this.certificateDateCheckBox.Checked = false;
                this.workflowAnalystCheckBox.Checked = false;
                this.complianceAnalystCheckBox.Checked = false;
                this.emailDateCheckBox.Checked = false;
                this.emailFromCheckBox.Checked = false;
                this.subjectLineCheckBox.Checked = false;
                this.statusCheckBox.Checked = false;
                this.certusFileIDCheckBox.Checked = false;
                this.fileNameCheckBox.Checked = false;
                this.fileURLCheckBox.Checked = false;
                this.fileMIMECheckBox.Checked = false;
                this.fileSizeCheckBox.Checked = false;
                this.assignedToCheckBox.Checked = true;
                this.assignedToComboBox.SelectedIndex = 1;
                this.displayColorCheckBox.Checked = false;
                this.itemsAttachedCheckBox.Checked = false;
                this.noteCheckBox.Checked = false;
            }
        }
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            //CloseForm();
            this.Close();
        }
        //
        // for generating the export
        private void GenerateExport()
        {
            CurrentExport = new Export();
            CurrentExport.SaveExport
                (
                    this.DocumentWorkflowItemIDCheckChoice,
                    this.CertificateIDCheckChoice,
                    this.CompanyNameCheckChoice,
                    this.ActiveCheckChoice,
                    this.CompliantCheckChoice,
                    this.IssueDateCheckChoice,
                    this.WorkflowAnalystCheckChoice,
                    this.ComplianceAnalystCheckChoice,
                    this.EmailDateCheckChoice,
                    this.EmailFromAddressCheckChoice,
                    this.SubjectLineCheckChoice,
                    this.StatusCheckChoice,
                    this.CertusFileIDCheckChoice,
                    this.FileNameCheckChoice,
                    this.FileURLCheckChoice,
                    this.FileSizeCheckChoice,
                    this.FileMIMECheckChoice,
                    this.AssignedToCheckChoice,
                    this.AssignedToComboBoxSelectedIndex,
                    this.DisplayColorCheckChoice,
                    this.ItemsAttachedCheckChoice,
                    this.NoteCheckChoice,
                    this.PresetsComboBoxSelectedIndex
                );
        }
        private void WriteCSV()
        {
            //string directory = Server.MapPath("~/DesktopModules/SMSFunction/SMSText");
            //string filename = String.Format("{0:yyyy-MM-dd}__{1}.txt", DateTime.Now, name);
            //string path = Path.Combine(directory, filename);

            string fileName = $"Workflow Item Export - {DateTime.Now.ToFileTime()}.csv";
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), fileName);

            // generate header line
            string headerLine = GenerateHeaderLine();

            using (StreamWriter sw = new StreamWriter(path))
            {
                // write header
                sw.WriteLine(headerLine);

                // write lines
                foreach (WorkflowItem wi in ItemListToExport)
                {
                    // generate values
                    List<string> values = GenerateValues(wi);

                    //for (int i = 0; i < values.Length; i++)
                    for (int i = 0; i < values.Count; i++)
                    {
                        if (values[i] != null && values[i].Contains(",") == true)
                        {
                            values[i] = values[i].Insert(0, "\"");
                            values[i] = values[i].Insert(values[i].Length, "\"");
                        }
                    }

                    string line = String.Join(",", values);

                    sw.WriteLine(line);
                }

                sw.Flush();
            }
        }
        private string GenerateHeaderLine()
        {
            string s = "";
            List<string> headers = new List<string>();

            if (this.DocumentWorkflowItemIDCheckChoice) headers.Add(this.documentWorkflowItemIDCheckBox.Tag as string);
            if (this.CertificateIDCheckChoice) headers.Add(this.certificateIDCheckBox.Tag as string);
            if (this.CompanyNameCheckChoice) headers.Add(this.companyNameCheckBox.Tag as string);
            if (this.ActiveCheckChoice) headers.Add(this.activeCheckBox.Tag as string);
            if (this.CompliantCheckChoice) headers.Add(this.compliantCheckBox.Tag as string);
            if (this.IssueDateCheckChoice) headers.Add(this.certificateDateCheckBox.Tag as string);
            if (this.WorkflowAnalystCheckChoice) headers.Add(this.workflowAnalystCheckBox.Tag as string);
            if (this.ComplianceAnalystCheckChoice) headers.Add(this.complianceAnalystCheckBox.Tag as string);
            if (this.EmailDateCheckChoice) headers.Add(this.emailDateCheckBox.Tag as string);
            if (this.EmailFromAddressCheckChoice) headers.Add(this.emailFromCheckBox.Tag as string);
            if (this.SubjectLineCheckChoice) headers.Add(this.subjectLineCheckBox.Tag as string);
            if (this.StatusCheckChoice) headers.Add(this.statusCheckBox.Tag as string);
            if (this.CertusFileIDCheckChoice) headers.Add(this.certusFileIDCheckBox.Tag as string);
            if (this.FileNameCheckChoice) headers.Add(this.fileNameCheckBox.Tag as string);
            if (this.FileURLCheckChoice) headers.Add(this.fileURLCheckBox.Tag as string);
            if (this.FileSizeCheckChoice) headers.Add(this.fileSizeCheckBox.Tag as string);
            if (this.FileMIMECheckChoice) headers.Add(this.fileMIMECheckBox.Tag as string);
            if (this.AssignedToCheckChoice)
            {
                if (this.AssignedToComboBoxSelectedIndex == 0) headers.Add(this.assignedToCheckBox.Tag as string);
                else if (this.AssignedToComboBoxSelectedIndex == 1) headers.Add(this.assignedToCheckBox.Tag as string);
            }
            if (this.DisplayColorCheckChoice) headers.Add(this.displayColorCheckBox.Tag as string);
            if (this.ItemsAttachedCheckChoice) headers.Add(this.itemsAttachedCheckBox.Tag as string);
            if (this.NoteCheckChoice) headers.Add(this.noteCheckBox.Tag as string);

            s = String.Join(",", headers);

            return s;
        }
        private List<string> GenerateValues(WorkflowItem wi)
        {
            List<string> ls = new List<string>();

            if (this.DocumentWorkflowItemIDCheckChoice) ls.Add(wi.DocumentWorkflowItemID);
            if (this.CertificateIDCheckChoice) if (wi.CertificateName != null) ls.Add(wi.CertificateName);
                else ls.Add("");
            if (this.CompanyNameCheckChoice) if (wi.VendorName != null) ls.Add(wi.VendorName);
                else ls.Add("");
            if (this.ActiveCheckChoice) if (wi.Active != null) ls.Add(wi.Active.ToString());
                else ls.Add("");
            if (this.CompliantCheckChoice) if (wi.Compliant != null) ls.Add(wi.Compliant.ToString());
                else ls.Add("");
            if (this.IssueDateCheckChoice) if (wi.IssueDate != null) ls.Add(wi.IssueDate.Value.ToString());
                else ls.Add("");
            if (this.WorkflowAnalystCheckChoice) if (wi.WorkflowAnalyst != null) ls.Add(wi.WorkflowAnalyst);
                else ls.Add("");
            if (this.ComplianceAnalystCheckChoice) if (wi.CompanyAnalyst != null) ls.Add(wi.CompanyAnalyst);
                else ls.Add("");
            if (this.EmailDateCheckChoice) if (wi.EmailDate != null) ls.Add(wi.EmailDate.Value.ToString());
                else ls.Add("");
            if (this.EmailFromAddressCheckChoice) if (wi.EmailFromAddress != null) ls.Add(wi.EmailFromAddress);
                else ls.Add("");
            if (this.SubjectLineCheckChoice) if (wi.SubjectLine != null) ls.Add(wi.SubjectLine);
                else ls.Add("");
            if (this.StatusCheckChoice) if (wi.Status != null) ls.Add(wi.Status);
                else ls.Add("");
            if (this.CertusFileIDCheckChoice) if (wi.CertusFileID != null) ls.Add(wi.CertusFileID);
                else ls.Add("");
            if (this.FileNameCheckChoice) if (wi.FileName != null) ls.Add(wi.FileName);
                else ls.Add("");
            if (this.FileURLCheckChoice) if (wi.FileURL != null) ls.Add(wi.FileURL);
                else ls.Add("");
            if (this.FileSizeCheckChoice) if (wi.FileSize != null) ls.Add(wi.FileSize);
                else ls.Add("");
            if (this.FileMIMECheckChoice) if (wi.FileMIME != null) ls.Add(wi.FileMIME);
                else ls.Add("");
            if (this.AssignedToCheckChoice)
            {
                if (this.AssignedToComboBoxSelectedIndex == 0) if (wi.AssignedToName != null) ls.Add(wi.AssignedToName);
                    else ls.Add("");
                else if (this.AssignedToComboBoxSelectedIndex == 1) if (wi.AssignedToID != null) ls.Add(wi.AssignedToID);
                    else ls.Add("");
            }
            if (this.DisplayColorCheckChoice) if (wi.DisplayColor != null) ls.Add(wi.DisplayColor);
                else ls.Add("");
            if (this.ItemsAttachedCheckChoice) if (wi.ItemsAttached != null) ls.Add(wi.ItemsAttached.Count.ToString());
                else ls.Add("");
            if (this.NoteCheckChoice) if (wi.Note != null) ls.Add(wi.Note);
                else ls.Add("");

            return ls;
        }
        //
        // for if export options are to be populated before opening the 
        // form (like for the filter form)
        private void Save()
        {
            this.DocumentWorkflowItemIDCheckChoice = documentWorkflowItemIDCheckBox.Checked;
            this.CertificateIDCheckChoice = certificateIDCheckBox.Checked;
            this.CompanyNameCheckChoice = companyNameCheckBox.Checked;
            this.ActiveCheckChoice = activeCheckBox.Checked;
            this.CompliantCheckChoice = compliantCheckBox.Checked;
            this.IssueDateCheckChoice = certificateDateCheckBox.Checked;
            this.WorkflowAnalystCheckChoice = workflowAnalystCheckBox.Checked;
            this.ComplianceAnalystCheckChoice = complianceAnalystCheckBox.Checked;
            this.EmailDateCheckChoice = emailDateCheckBox.Checked;
            this.EmailFromAddressCheckChoice = emailFromCheckBox.Checked;
            this.SubjectLineCheckChoice = subjectLineCheckBox.Checked;
            this.StatusCheckChoice = statusCheckBox.Checked;
            this.CertusFileIDCheckChoice = certusFileIDCheckBox.Checked;
            this.FileNameCheckChoice = fileNameCheckBox.Checked;
            this.FileURLCheckChoice = fileURLCheckBox.Checked;
            this.FileSizeCheckChoice = fileSizeCheckBox.Checked;
            this.FileMIMECheckChoice = fileMIMECheckBox.Checked;
            this.AssignedToCheckChoice = assignedToCheckBox.Checked;
            this.AssignedToComboBoxSelectedIndex = assignedToComboBox.SelectedIndex;
            this.DisplayColorCheckChoice = displayColorCheckBox.Checked;
            this.ItemsAttachedCheckChoice = itemsAttachedCheckBox.Checked;
            this.NoteCheckChoice = noteCheckBox.Checked;
            this.PresetsComboBoxSelectedIndex = presetsComboBox.SelectedIndex;
        }
        public void Populate()
        {
            this.documentWorkflowItemIDCheckBox.Checked = CurrentExport.DocumentWorkflowItemIDCheckChoice;
            this.certificateIDCheckBox.Checked = CurrentExport.CertificateIDCheckChoice;
            this.companyNameCheckBox.Checked = CurrentExport.CompanyNameCheckChoice;
            this.activeCheckBox.Checked = CurrentExport.ActiveCheckChoice;
            this.compliantCheckBox.Checked = CurrentExport.CompliantCheckChoice;
            this.certificateDateCheckBox.Checked = CurrentExport.CertificateDateCheckChoice;
            this.workflowAnalystCheckBox.Checked = CurrentExport.WorkflowAnalystCheckChoice;
            this.complianceAnalystCheckBox.Checked = CurrentExport.ComplianceAnalystCheckChoice;
            this.emailDateCheckBox.Checked = CurrentExport.EmailDateCheckChoice;
            this.emailFromCheckBox.Checked = CurrentExport.EmailFromAddressCheckChoice;
            this.subjectLineCheckBox.Checked = CurrentExport.SubjectLineCheckChoice;
            this.statusCheckBox.Checked = CurrentExport.StatusCheckChoice;
            this.certusFileIDCheckBox.Checked = CurrentExport.CertusFileIDCheckChoice;
            this.fileNameCheckBox.Checked = CurrentExport.FileNameCheckChoice;
            this.fileURLCheckBox.Checked = CurrentExport.FileURLCheckChoice;
            this.fileSizeCheckBox.Checked = CurrentExport.FileSizeCheckChoice;
            this.fileMIMECheckBox.Checked = CurrentExport.FileMIMECheckChoice;
            this.assignedToCheckBox.Checked = CurrentExport.AssignedToCheckChoice;
            this.assignedToComboBox.SelectedIndex = CurrentExport.AssignedToComboBoxSelectedIndex;
            this.displayColorCheckBox.Checked = CurrentExport.DisplayColorCheckChoice;
            this.itemsAttachedCheckBox.Checked = CurrentExport.ItemsAttachedCheckChoice;
            this.noteCheckBox.Checked = CurrentExport.NoteCheckChoice;
            this.presetsComboBox.SelectedIndex = CurrentExport.PresetsComboBoxSelectedIndex;
        }

        //
        // form accessibility
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

        //
        // form behavior
        private void optionBtn_Enter(object sender, EventArgs e)
        {
            (sender as Button).FlatAppearance.BorderColor = Color.FromKnownColor(KnownColor.Highlight);
        }
        private void optionBtn_Leave(object sender, EventArgs e)
        {
            (sender as Button).FlatAppearance.BorderColor = Color.FromKnownColor(KnownColor.WindowFrame);
        }
    }
}
