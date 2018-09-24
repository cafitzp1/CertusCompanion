using System;
using System.Collections.Generic;

namespace CertusCompanion
{
    [Serializable]
    public class WorkflowItem
    {
        #region Workflow Item Data
        public string DocumentWorkflowItemID { get; set; }
        public string CertificateName { get; set; }
        public string VendorName { get; set; }
        public string VendorID { get; set; }
        public string ClientID { get; set; }
        public bool? Active { get; set; }
        public bool? Compliant { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? NextExpirationDate { get; set; }
        public string WorkflowAnalyst { get; set; }
        public string WorkflowAnalystID { get; set; }
        public string CompanyAnalyst { get; set; }
        public string CompanyAnalystID { get; set; }
        public DateTime? EmailDate { get; set; }
        public string EmailFromAddress { get; set; }
        public string SubjectLine { get; set; }
        public string EmailBody { get; set; }
        public string Status { get; set; }
        public string CertusFileID { get; set; }
        public string FileName { get; set; }
        public string FileURL { get; set; }
        public string FileSize { get; set; }
        public string FileMIME { get; set; }
        public bool? FileExtracted { get; set; }
        public string AssignedToName { get; set; }
        public string AssignedToID { get; set; }
        public string DisplayColor { get; set; }
        public List<string> ItemsAttached { get; set; }
        public int ItemsWithThisFileSize { get; set; }
        public int ItemsWithThisFileName { get; set; }
        public int AllAttachmentsSize { get; set; }
        public bool? Excluded { get; set; }
        public string Note { get; set; }
        public DateTime? DateCompleted { get; set; }
        public string StatusChanges { get; set; }
        public string ItemType { get; set; }
        public bool CertificateIdOverridden { get; set; }
        public bool WorkflowItemInformationDifferentThanCertus { get; set; }
        public bool CertificateInformationUpdated { get; set; }
        public bool CompanyUpdated { get; set; }
        public bool ItemHasPriority { get; set; }
        #endregion

        // 
        // blank constructor for instantiating new items
        public WorkflowItem()
        {

        }
        //
        // parameterized constructor for instantiating existing items
        public WorkflowItem ( string documentWorkflowItemID, string certificateName, string vendorName, string vendorID, string clientID, bool? active, bool? compliant, DateTime? issueDate, DateTime? nextExpirationDate, string workflowAnalyst, string workflowAnalystID, string companyAnalyst, string companyAnalystID, DateTime? emailDate, string emailFromAddress, string subjectLine, string emailBody, string status, string certusFileID, string fileName, string fileURL, string fileSize, string fileMime, bool? fileExtracted)
        {
            this.DocumentWorkflowItemID = documentWorkflowItemID;
            this.CertificateName = certificateName;
            this.VendorName = vendorName;
            this.ClientID = clientID;
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
            this.AssignedToName = ReturnAssignedName(status);
            this.AssignedToID = ReturnAssignedID(status);
            this.DisplayColor = "Default";
        }

        //
        // methods and return data
        private string ReturnAssignedName(string status)
        {
            switch (status)
            {
                case "Documentation Analyst":
                    return WorkflowAnalyst;
                case "Compliance Analyst":
                    return CompanyAnalyst;
                default:
                    return "(Unassigned)";
            }
        }
        private string ReturnAssignedID(string status)
        {
            switch (status)
            {
                case "Documentation Analyst":
                    return WorkflowAnalystID;
                case "Compliance Analyst":
                    return CompanyAnalystID;
                default:
                    return String.Empty;
            }
        }
        public override string ToString()
        {
            string dateToDisplay = "";
            if (EmailDate != null) dateToDisplay = EmailDate.Value.ToShortDateString();

            return $"{DocumentWorkflowItemID} - {dateToDisplay} - {EmailFromAddress} - {SubjectLine}";
        }
    }
}
