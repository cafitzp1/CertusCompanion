using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertusCompanion
{
    public class Export
    {
        // data
        bool documentWorkflowItemIDCheckChoice;
        bool contractIDCheckChoice;
        bool companyNameCheckChoice;
        bool activeCheckChoice;
        bool compliantCheckChoice;
        bool certificateDateCheckChoice;
        bool workflowAnalystCheckChoice;
        bool complianceAnalystCheckChoice;
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

        // properties
        public bool DocumentWorkflowItemIDCheckChoice { get => documentWorkflowItemIDCheckChoice; set => documentWorkflowItemIDCheckChoice = value; }
        public bool ContractIDCheckChoice { get => contractIDCheckChoice; set => contractIDCheckChoice = value; }
        public bool CompanyNameCheckChoice { get => companyNameCheckChoice; set => companyNameCheckChoice = value; }
        public bool ActiveCheckChoice { get => activeCheckChoice; set => activeCheckChoice = value; }
        public bool CompliantCheckChoice { get => compliantCheckChoice; set => compliantCheckChoice = value; }
        public bool CertificateDateCheckChoice { get => certificateDateCheckChoice; set => certificateDateCheckChoice = value; }
        public bool WorkflowAnalystCheckChoice { get => workflowAnalystCheckChoice; set => workflowAnalystCheckChoice = value; }
        public bool ComplianceAnalystCheckChoice { get => complianceAnalystCheckChoice; set => complianceAnalystCheckChoice = value; }
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

        // constructors
        public Export()
        {

        }

        // methods
        public void ResetExport()
        {
            this.CurrentExport = new Export();
        }

        public void SaveExport
            (
                bool documentWorkflowItemIDCheckChoice,
                bool contractIDCheckChoice,
                bool companyNameCheckChoice,
                bool activeCheckChoice,
                bool compliantCheckChoice,
                bool certificateDateCheckChoice,
                bool workflowAnalystCheckChoice,
                bool complianceAnalystCheckChoice,
                bool emailDateCheckChoice,
                bool emailFromAddressCheckChoice,
                bool subjectLineCheckChoice,
                bool statusCheckChoice,
                bool certusFileIDCheckChoice,
                bool fileNameCheckChoice,
                bool fileURLCheckChoice,
                bool fileSizeCheckChoice,
                bool fileMIMECheckChoice,
                bool assignedToCheckChoice,
                int assignedToComboBoxSelectedIndex,
                bool displayColorCheckChoice,
                bool itemsAttachedCheckChoice,
                bool noteCheckChoice,
                int presetsComboBoxSelectedIndex
            )
        {
            this.CurrentExport = new Export();

            this.DocumentWorkflowItemIDCheckChoice = documentWorkflowItemIDCheckChoice;
            this.ContractIDCheckChoice = contractIDCheckChoice;
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
