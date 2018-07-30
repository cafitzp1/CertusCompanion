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
    public delegate void ExportEventHandler(object sender, Export filter);

    public partial class ExportForm : Form
    {
        //public event ExportEventHandler SaveExport;

        #region form data
        bool documentWorkflowItemIDCheckChoice;
        bool contractCheckChoice;
        int contractComboBoxSelectedIndex;
        bool companyCheckChoice;
        int companyComboBoxSelectedIndex;
        bool activeCheckChoice;
        bool compliantCheckChoice;
        bool certificateDateCheckChoice;
        int certificateDateComboBoxSelectedIndex;
        bool workflowAnalystCheckChoice;
        int workflowAnalystComboBoxSelectedIndex;
        bool complianceAnalystCheckChoice;
        int complianceAnalystComboBoxSelectedIndex;
        bool emailDateCheckChoice;
        bool emailFromAddressCheckChoice;
        bool subjectLineCheckChoice;
        bool statusCheckChoice;
        bool certusFileIDCheckChoice;
        bool fileNameCheckChoice;
        bool fileURLCheckChoice;
        bool fileSizeCheckChoice;
        bool fileMIMECheckChoice;
        bool assignedToCheckChoice;
        int assignedToComboBoxSelectedIndex;
        bool displayColorCheckChoice;
        bool itemsAttachedCheckChoice;
        bool noteCheckChoice;
        int presetsComboBoxSelectedIndex;
        Export currentExport;
        List<WorkflowItem> itemListToExport;

        public bool DocumentWorkflowItemIDCheckChoice { get => documentWorkflowItemIDCheckChoice; set => documentWorkflowItemIDCheckChoice = value; }
        public bool ContractIDCheckChoice { get => contractCheckChoice; set => contractCheckChoice = value; }
        public int ContractComboBoxSelectedIndex { get => contractComboBoxSelectedIndex; set => contractComboBoxSelectedIndex = value; }
        public bool CompanyNameCheckChoice { get => companyCheckChoice; set => companyCheckChoice = value; }
        public int CompanyComboBoxSelectedIndex { get => companyComboBoxSelectedIndex; set => companyComboBoxSelectedIndex = value; }
        public bool ActiveCheckChoice { get => activeCheckChoice; set => activeCheckChoice = value; }
        public bool CompliantCheckChoice { get => compliantCheckChoice; set => compliantCheckChoice = value; }
        public bool IssueDateCheckChoice { get => certificateDateCheckChoice; set => certificateDateCheckChoice = value; }
        public int CertificateDateComboBoxSelectedIndex { get => certificateDateComboBoxSelectedIndex; set => certificateDateComboBoxSelectedIndex = value; }
        public bool WorkflowAnalystCheckChoice { get => workflowAnalystCheckChoice; set => workflowAnalystCheckChoice = value; }
        public int WorkflowAnalystComboBoxSelectedIndex { get => workflowAnalystComboBoxSelectedIndex; set => workflowAnalystComboBoxSelectedIndex = value; }
        public bool ComplianceAnalystCheckChoice { get => complianceAnalystCheckChoice; set => complianceAnalystCheckChoice = value; }
        public int ComplianceAnalystComboBoxSelectedIndex { get => complianceAnalystComboBoxSelectedIndex; set => complianceAnalystComboBoxSelectedIndex = value; }
        public bool EmailDateCheckChoice { get => emailDateCheckChoice; set => emailDateCheckChoice = value; }
        public bool EmailFromAddressCheckChoice { get => emailFromAddressCheckChoice; set => emailFromAddressCheckChoice = value; }
        public bool SubjectLineCheckChoice { get => subjectLineCheckChoice; set => subjectLineCheckChoice = value; }
        public bool StatusCheckChoice { get => statusCheckChoice; set => statusCheckChoice = value; }
        public bool CertusFileIDCheckChoice { get => certusFileIDCheckChoice; set => certusFileIDCheckChoice = value; }
        public bool FileNameCheckChoice { get => fileNameCheckChoice; set => fileNameCheckChoice = value; }
        public bool FileURLCheckChoice { get => fileURLCheckChoice; set => fileURLCheckChoice = value; }
        public bool FileSizeCheckChoice { get => fileSizeCheckChoice; set => fileSizeCheckChoice = value; }
        public bool FileMIMECheckChoice { get => fileMIMECheckChoice; set => fileMIMECheckChoice = value; }
        public bool AssignedToCheckChoice { get => assignedToCheckChoice; set => assignedToCheckChoice = value; }
        public int AssignedToComboBoxSelectedIndex { get => assignedToComboBoxSelectedIndex; set => assignedToComboBoxSelectedIndex = value; }
        public bool DisplayColorCheckChoice { get => displayColorCheckChoice; set => displayColorCheckChoice = value; }
        public bool ItemsAttachedCheckChoice { get => itemsAttachedCheckChoice; set => itemsAttachedCheckChoice = value; }
        public bool NoteCheckChoice { get => noteCheckChoice; set => noteCheckChoice = value; }
        public int PresetsComboBoxSelectedIndex { get => presetsComboBoxSelectedIndex; set => presetsComboBoxSelectedIndex = value; }
        public Export CurrentExport { get => currentExport; set => currentExport = value; }
        public List<WorkflowItem> ItemListToExport { get => itemListToExport; set => itemListToExport = value; }
        #endregion

        public ExportForm(List<WorkflowItem> itemListToExport)
        {
            InitializeComponent();
            this.ItemListToExport = itemListToExport;

            this.presetsComboBox.SelectedIndex = 0;
        }

        public ExportForm(List<WorkflowItem> itemListToExport, Export export)
        {
            InitializeComponent();
            this.ItemListToExport = itemListToExport;
            this.CurrentExport = export;

            this.presetsComboBox.SelectedIndex = 0;
        }

        public void Populate()
        {
            this.documentWorkflowItemIDCheckBox.Checked = CurrentExport.DocumentWorkflowItemIDCheckChoice;
            this.contractIDCheckBox.Checked = CurrentExport.ContractIDCheckChoice;
            this.companyNameCheckBox.Checked= CurrentExport.CompanyNameCheckChoice;
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
            this.assignedToCheckBox.Checked= CurrentExport.AssignedToCheckChoice;
            this.assignedToComboBox.SelectedIndex = CurrentExport.AssignedToComboBoxSelectedIndex;
            this.displayColorCheckBox.Checked = CurrentExport.DisplayColorCheckChoice;
            this.itemsAttachedCheckBox.Checked = CurrentExport.ItemsAttachedCheckChoice;
            this.noteCheckBox.Checked = CurrentExport.NoteCheckChoice;
            this.presetsComboBox.SelectedIndex = CurrentExport.PresetsComboBoxSelectedIndex;
        }

        private void Save()
        {
            this.DocumentWorkflowItemIDCheckChoice = documentWorkflowItemIDCheckBox.Checked;
            this.ContractIDCheckChoice = contractIDCheckBox.Checked;
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

        private void GenerateExport()
        {
            currentExport = new Export();
            currentExport.SaveExport
                (
                    this.DocumentWorkflowItemIDCheckChoice,
                    this.ContractIDCheckChoice,
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
            //string path = $@"\Downloads\{fileName}";
            string path = fileName;

            // generate header line
            string headerLine = GenerateHeaderLine();

            using (StreamWriter sw = new StreamWriter(path))
            {
                // write header
                sw.WriteLine(headerLine);

                // write lines
                foreach (WorkflowItem wi in itemListToExport)
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
            if (this.ContractIDCheckChoice) headers.Add(this.contractIDCheckBox.Tag as string);
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
            if (this.ContractIDCheckChoice) ls.Add(wi.ContractID);
            if (this.CompanyNameCheckChoice) ls.Add(wi.VendorName);
            if (this.ActiveCheckChoice) ls.Add(wi.Active.ToString());
            if (this.CompliantCheckChoice) ls.Add(wi.Compliant.ToString());
            if (this.IssueDateCheckChoice) ls.Add(wi.IssueDate.Value.ToShortDateString());
            if (this.WorkflowAnalystCheckChoice) ls.Add(wi.WorkflowAnalyst);
            if (this.ComplianceAnalystCheckChoice) ls.Add(wi.CompanyAnalyst);
            if (this.EmailDateCheckChoice) ls.Add(wi.EmailDate.Value.ToShortDateString());
            if (this.EmailFromAddressCheckChoice) ls.Add(wi.EmailFromAddress);
            if (this.SubjectLineCheckChoice) ls.Add(wi.SubjectLine);
            if (this.StatusCheckChoice) ls.Add(wi.Status);
            if (this.CertusFileIDCheckChoice) ls.Add(wi.CertusFileID);
            if (this.FileNameCheckChoice) ls.Add(wi.FileName);
            if (this.FileURLCheckChoice) ls.Add(wi.FileURL);
            if (this.FileSizeCheckChoice) ls.Add(wi.FileSize);
            if (this.FileMIMECheckChoice) ls.Add(wi.FileMIME);
            if (this.AssignedToCheckChoice)
            {
                if (this.AssignedToComboBoxSelectedIndex == 0) ls.Add(wi.AssignedToName);
                else if (this.AssignedToComboBoxSelectedIndex == 1) ls.Add(wi.AssignedToID);
            }
            if (this.DisplayColorCheckChoice) ls.Add(wi.DisplayColor);
            if (this.ItemsAttachedCheckChoice) ls.Add(wi.ItemsAttached.Count.ToString());
            if (this.NoteCheckChoice) ls.Add(wi.Note);

            return ls;
        }

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
                (Application.OpenForms["Items View"] as ItemsView).SetStatusLabelAndTimer("Export to CSV successful");

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
            this.contractIDCheckBox.Checked = false;
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
                this.contractIDCheckBox.Checked = true;
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
                this.contractIDCheckBox.Checked = false;
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
                this.contractIDCheckBox.Checked = false;
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
    }
}
