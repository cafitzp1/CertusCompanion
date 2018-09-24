using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertusCompanion
{
    public class Export
    {
        //
        // export data
        public bool DocumentWorkflowItemIDCheckChoice { get; set; }
        public bool CertificateIDCheckChoice { get; set; }
        public bool CompanyNameCheckChoice { get; set; }
        public bool ActiveCheckChoice { get; set; }
        public bool CompliantCheckChoice { get; set; }
        public bool CertificateDateCheckChoice { get; set; }
        public bool WorkflowAnalystCheckChoice { get; set; }
        public bool ComplianceAnalystCheckChoice { get; set; }
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

        //
        // blank constructor
        public Export()
        {

        }

        //
        // methods
        public void ResetExport()
        {
            this.CurrentExport = new Export();
        }
        public void SaveExport(bool documentWorkflowItemIDCheckChoice, bool CertificateIDCheckChoice, bool companyNameCheckChoice, bool activeCheckChoice, bool compliantCheckChoice, bool certificateDateCheckChoice, bool workflowAnalystCheckChoice, bool complianceAnalystCheckChoice, bool emailDateCheckChoice, bool emailFromAddressCheckChoice, bool subjectLineCheckChoice, bool statusCheckChoice, bool certusFileIDCheckChoice, bool fileNameCheckChoice, bool fileURLCheckChoice, bool fileSizeCheckChoice, bool fileMIMECheckChoice, bool assignedToCheckChoice, int assignedToComboBoxSelectedIndex, bool displayColorCheckChoice, bool itemsAttachedCheckChoice, bool noteCheckChoice, int presetsComboBoxSelectedIndex)
        {
            this.CurrentExport = new Export();

            this.DocumentWorkflowItemIDCheckChoice = documentWorkflowItemIDCheckChoice;
            this.CertificateIDCheckChoice = CertificateIDCheckChoice;
            this.CompanyNameCheckChoice = companyNameCheckChoice;
            this.ActiveCheckChoice = activeCheckChoice;
            this.CompliantCheckChoice = compliantCheckChoice;
            this.CertificateDateCheckChoice = certificateDateCheckChoice;
            this.WorkflowAnalystCheckChoice = workflowAnalystCheckChoice;
            this.ComplianceAnalystCheckChoice = complianceAnalystCheckChoice;
            this.EmailDateCheckChoice = emailDateCheckChoice;
            this.EmailFromAddressCheckChoice = emailFromAddressCheckChoice;
            this.SubjectLineCheckChoice = subjectLineCheckChoice;
            this.StatusCheckChoice = statusCheckChoice;
            this.CertusFileIDCheckChoice = certusFileIDCheckChoice;
            this.FileNameCheckChoice = fileNameCheckChoice;
            this.FileURLCheckChoice = fileURLCheckChoice;
            this.FileSizeCheckChoice = fileSizeCheckChoice;
            this.FileMIMECheckChoice = fileMIMECheckChoice;
            this.AssignedToCheckChoice = assignedToCheckChoice;
            this.AssignedToComboBoxSelectedIndex = assignedToComboBoxSelectedIndex;
            this.DisplayColorCheckChoice = displayColorCheckChoice;
            this.ItemsAttachedCheckChoice = itemsAttachedCheckChoice;
            this.NoteCheckChoice = noteCheckChoice;
            this.PresetsComboBoxSelectedIndex = presetsComboBoxSelectedIndex;
        }
        
        //
        // return methods
        public Export ReturnExport()
        {
            return this.CurrentExport;
        }
        private string GenerateToString()
        {
            string s = "";

            if (this.PresetsComboBoxSelectedIndex == 0) s = "Default";
            else if (this.PresetsComboBoxSelectedIndex == 1) s = "IDs Only";
            else if (this.PresetsComboBoxSelectedIndex == 2) s = "Item Assignment";
            else s = "Custom";

            return s;
        }
        public override string ToString()
        {
            return GenerateToString();
        }
    }
}
