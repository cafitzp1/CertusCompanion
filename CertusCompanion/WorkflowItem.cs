// Certus Companion v3

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CertusCompanion
{
    [Serializable]
    public class WorkflowItem
    {
        // --- FIELDS --- //
        string documentWorkflowItemID;
        string contractID;
        string vendorName;
        string vendorID;
        bool? active;
        bool? compliant;
        [OptionalField]
            DateTime? issueDate = null; 
        [OptionalField]
            DateTime? nextExpirationDate = null;
        string workflowAnalyst;
        string workflowAnalystID; 
        string companyAnalyst;
        string companyAnalystID; 
        [OptionalField]
            DateTime? emailDate = null; 
        string emailFromAddress;
        string subjectLine;
        string emailBody; 
        string status;
        string certusFileID;
        string fileName;
        string fileURL;
        string fileSize;
        string fileMIME;
        bool? fileExtracted; 
        string assignedToName;
        string assignedToID; 
        string displayColor;
        List<string> itemsAttached;
        int itemsWithSameFileSize = 0;
        int itemsWithSameFileName = 0;
        int allAttachmentsSize = 0;
        bool? excluded;
        string note = "";
        DateTime? dateCompleted = null;
        string statusChanges = "";
        string itemType = "";
        bool contractIdOverridden = false;
        bool workflowItemInformationDifferentThanCertus = false;
        bool contractInformationUpdated = false;
        bool companyUpdated = false;
        bool itemHasPriority = false;

        //[OnDeserializing]
        //private void SetEmailDateDefault(StreamingContext sc)
        //{
        //    issueDate = DateTime.MinValue;
        //    nextExpirationDate = DateTime.MinValue;
        //    nextExpirationDate = DateTime.MinValue;
        //}

        // --- PROPERTIES --- //
        public string DocumentWorkflowItemID { get => documentWorkflowItemID; set => documentWorkflowItemID = value; }
        public string ContractID { get => contractID; set => contractID = value; }
        public string VendorName { get => vendorName; set => vendorName = value; }
        public string VendorID { get => vendorID; set => vendorID = value; }
        public bool? Active { get => active; set => active = value; }
        public bool? Compliant { get => compliant; set => compliant = value; }
        public DateTime? IssueDate { get => issueDate; set => issueDate = value; }
        public DateTime? NextExpirationDate { get => nextExpirationDate; set => nextExpirationDate = value; }
        public string WorkflowAnalyst { get => workflowAnalyst; set => workflowAnalyst = value; }
        public string WorkflowAnalystID { get => workflowAnalystID; set => workflowAnalystID = value; }
        public string CompanyAnalyst { get => companyAnalyst; set => companyAnalyst = value; }
        public string CompanyAnalystID { get => companyAnalystID; set => companyAnalystID = value; }
        public DateTime? EmailDate { get => emailDate; set => emailDate = value; }
        public string EmailFromAddress { get => emailFromAddress; set => emailFromAddress = value; }
        public string SubjectLine { get => subjectLine; set => subjectLine = value; }
        public string EmailBody { get => emailBody; set => emailBody = value; }
        public string Status { get => status; set => status = value; }
        public string CertusFileID { get => certusFileID; set => certusFileID = value; }
        public string FileName { get => fileName; set => fileName = value; }
        public string FileURL { get => fileURL; set => fileURL = value; }
        public string FileSize { get => fileSize; set => fileSize = value; }
        public string FileMIME { get => fileMIME; set => fileMIME = value; }
        public bool? FileExtracted { get => fileExtracted; set => fileExtracted = value; }
        public string AssignedToName { get => assignedToName; set => assignedToName = value; }
        public string AssignedToID { get => assignedToID; set => assignedToID = value; }
        public string DisplayColor { get => displayColor; set => displayColor = value; }
        public List<string> ItemsAttached { get => itemsAttached; set => itemsAttached = value; }
        public int ItemsWithThisFileSize { get => itemsWithSameFileSize; set => itemsWithSameFileSize = value; }
        public int ItemsWithThisFileName { get => itemsWithSameFileName; set => itemsWithSameFileName = value; }
        public int AllAttachmentsSize { get => allAttachmentsSize; set => allAttachmentsSize = value; }
        public bool? Excluded { get => excluded; set => excluded = value; }
        public string Note { get => note; set => note = value; }
        public DateTime? DateCompleted { get => dateCompleted; set => dateCompleted = value; }
        public string StatusChanges { get => statusChanges; set => statusChanges = value; }
        public string ItemType { get => itemType; set => itemType = value; }
        public bool ContractIdOverridden { get => contractIdOverridden; set => contractIdOverridden = value; }
        public bool WorkflowItemInformationDifferentThanCertus { get => workflowItemInformationDifferentThanCertus; set => workflowItemInformationDifferentThanCertus = value; }
        public bool ContractInformationUpdated { get => contractInformationUpdated; set => contractInformationUpdated = value; }
        public bool CompanyUpdated { get => companyUpdated; set => companyUpdated = value; }
        public bool ItemHasPriority { get => itemHasPriority; set => itemHasPriority = value; }

        // --- CONSTRUCTORS --- //
        public WorkflowItem()
        {

        }

        public WorkflowItem
            (
                string documentWorkflowItemID,
                string contractID,
                string vendorName,
                string vendorID,
                bool? active,
                bool? compliant,
                DateTime? issueDate,
                DateTime? nextExpirationDate,
                string workflowAnalyst,
                string workflowAnalystID,
                string companyAnalyst,
                string companyAnalystID,
                DateTime? emailDate,
                string emailFromAddress,
                string subjectLine,
                string emailBody,
                string status,
                string certusFileID,
                string fileName,
                string fileURL,
                string fileSize,
                string fileMime,
                bool? fileExtracted
            )
        {
            this.DocumentWorkflowItemID = documentWorkflowItemID;
            this.ContractID = contractID;
            this.VendorName = vendorName;
            this.Active = active;
            this.Compliant = compliant;
            this.IssueDate = issueDate;
            this.NextExpirationDate = nextExpirationDate;
            this.WorkflowAnalyst = workflowAnalyst;
            this.WorkflowAnalystID = workflowAnalystID;
            this.CompanyAnalyst = companyAnalyst;
            this.CompanyAnalystID = companyAnalystID;
            this.EmailDate = emailDate;
            this.EmailFromAddress = emailFromAddress;
            this.SubjectLine = subjectLine;
            this.EmailBody = emailBody;
            this.Status = status;
            this.CertusFileID = certusFileID;
            this.FileName = fileName;
            this.FileURL = fileURL;
            this.FileSize = fileSize;
            this.FileMIME = fileMime;
            this.FileExtracted = fileExtracted;
            switch (Status)
            {
                case "Documentation Analyst":
                    this.AssignedToName = WorkflowAnalyst;
                    this.AssignedToID = WorkflowAnalystID;
                    break;
                case "Compliance Analyst":
                    this.AssignedToName = CompanyAnalyst;
                    this.AssignedToID = CompanyAnalystID;
                    break;
                default:
                    this.AssignedToName = "(Unassigned)";
                    break;
            }
            this.DisplayColor = "Default";
        }

        // --- METHODS --- //
        public override string ToString()
        {
            string dateToDisplay = "";
            if (EmailDate != null) dateToDisplay = EmailDate.Value.ToShortDateString();

            return $"{DocumentWorkflowItemID} - {dateToDisplay} - {EmailFromAddress} - {SubjectLine}";
        }
    }
}
