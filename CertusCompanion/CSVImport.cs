using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace CertusCompanion
{
    [Serializable]
    class CSVImport : Import
    {
        //
        // data declaration
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public List<string> TotalItemsOnImport { get; set; }
        private List<WorkflowItem> currentImportItems;
        private List<Certificate> currentImportCertificates;
        private List<Company> currentImportCompanies;
        private string csvFileHeaderLine;
        private ItemImports itemImportsList;
        private List<Tuple<int, string>> acceptableHeaderValuesAndTheirIndexes;
        private StreamReader sr;

        //
        // constructors
        public CSVImport()
        {
            this.ImportDate = DateTime.Now;
            this.ImportName = String.Empty;
            this.ImportType = String.Empty;
            this.ItemsAdded = new List<string>();
            this.ItemsUpdated = new List<string>();
            this.FilePath = String.Empty;
            this.FileName = String.Empty;
            this.TotalItemsOnImport = new List<string>();

            this.currentImportItems = new List<WorkflowItem>();
            this.currentImportCertificates = new List<Certificate>();
            this.currentImportCompanies = new List<Company>();
        }
        public CSVImport(DateTime importDate, string importName, string importType, List<string> newItemsAdded, List<string> itemsUpdated, string fileName, string filePath, List<string> totalItemsOnImport)
        {
            this.ImportDate = importDate;
            this.ImportName = importName;
            this.ImportType = importType;
            this.ItemsAdded = newItemsAdded;
            this.ItemsUpdated = itemsUpdated;
            this.FilePath = filePath;
            this.FileName = fileName;
            this.TotalItemsOnImport = totalItemsOnImport;

            this.currentImportItems = new List<WorkflowItem>();
            this.currentImportCertificates = new List<Certificate>();
            this.currentImportCompanies = new List<Company>();
        }
        
        //
        // workflow Import
        private void WorkflowImportRouter(int i)
        {
            switch (i)
            {
                case 1: SettupWorkflowImport();
                    break;
                case 2: GenerateWorkflowItemList();
                    break;
                case 3: SaveWorkflowImportData();
                    break;
                default:
                    break;
            }
        }
        public void InitiateWorkflowImport(string csvFileName)
        {
            this.ImportType = "WorkflowCSV";
            this.FilePath = csvFileName;

            // get filename from filepath
            char[] charArray = FilePath.ToCharArray();
            Array.Reverse(charArray);
            string revFileName = new string(charArray);
            int indx = revFileName.IndexOf(@"\");
            FileName = FilePath.Substring(FilePath.Length - indx);

            WorkflowImportRouter(1);
        }
        private void SettupWorkflowImport()
        {
            string csvFileHeaderLine;
            string[] csvFileHeaderValues;

            #region Instantiate Acceptable Headers and Indexes List
            acceptableHeaderValuesAndTheirIndexes = new List<Tuple<int, string>>();

            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "DocumentWorkflowItemID"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "CertificateID"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Vendor"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Company")); //same as above
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "VendorID"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "CompanyID")); // same as above
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "ClientID"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Active"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Compliant"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "IssueDate"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "NextPolicyExpirationDate"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "WorkflowAnalyst"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "WorkflowAnalystID"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "CompanyAnalyst"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "CompanyAnalystID"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "EmailDate"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "EmailFromAddress"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "SubjectLine"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "EmailBody"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Status"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "CertusFileID"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "FileName"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "FileSize"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "FileMIME"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "FileURL"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Extracted"));
            #endregion Instantiate Acceptable Headers and Indexes List

            // Open streamreader
            sr = new StreamReader(FilePath);

            // Save file length data for reporting progress
            Stream baseStream = sr.BaseStream;
            long length = baseStream.Length;

            #region Save Header
            csvFileHeaderLine = sr.ReadLine();
            csvFileHeaderValues = Regex.Split(csvFileHeaderLine, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");

            // remove paranthesis if comma is in value
            for (int i = 0; i < csvFileHeaderValues.Length; i++)
            {
                if (csvFileHeaderValues[i].Contains(',') == true)
                {
                    csvFileHeaderValues[i] = csvFileHeaderValues[i].Remove(0, 1);
                    csvFileHeaderValues[i] = csvFileHeaderValues[i].Remove(csvFileHeaderValues[i].Length - 1, 1);
                }
            }

            // store header indexes if string values match any of the acceptable header values
            for (int i = 0; i < csvFileHeaderValues.Length; i++)
            {
                for (int j = 0; j < acceptableHeaderValuesAndTheirIndexes.Count; j++)
                {
                    string csvHeaderValForComparison = new String(csvFileHeaderValues[i].Where(c => Char.IsLetter(c) || Char.IsNumber(c)).ToArray()).ToLower();
                    string accHeaderValForComparison = new String(acceptableHeaderValuesAndTheirIndexes[j].Item2.Where(c => Char.IsLetter(c) || Char.IsNumber(c)).ToArray()).ToLower();

                    if (csvHeaderValForComparison == (accHeaderValForComparison))
                    {
                        // save new tuple which contains the correct index location for the header 
                        Tuple<int, string> newTuple;
                        int index = acceptableHeaderValuesAndTheirIndexes.IndexOf(acceptableHeaderValuesAndTheirIndexes[j]);
                        string accHeader = acceptableHeaderValuesAndTheirIndexes[j].Item2;
                        newTuple = new Tuple<int, string>(i, accHeader);

                        // replace old tuple with the new one
                        acceptableHeaderValuesAndTheirIndexes[index] = newTuple;
                    }
                }
            }

            // right now, return if DocumentWorkflowItemID is not in index 0
            if (acceptableHeaderValuesAndTheirIndexes[0].Item1 != 0)
            {
                throw new WorkflowItemImportNotCorrectFormatException("CSV file is not recognized as an acceptable Workflow Item Export. 'DocumentWorkflowItemID' must be in the first column.");
            }
            #endregion Save Header

            #region Append Import Type
            if
                (
                    csvFileHeaderLine ==
                    "DocumentWorkflowItemID," +
                    "CertificateID," +
                    "CompanyName," +
                    "Active," +
                    "Compliant," +
                    "NextPolicyExpirationDate," +
                    "WorkflowAnalyst," +
                    "CompanyAnalyst," +
                    "EmailDate," +
                    "EmailFromAddress," +
                    "SubjectLine," +
                    "Status," +
                    "CertusFileID," +
                    "FileName," +
                    "FileURL"
                )
            {
                this.ImportType += " (WIR 1.0)";
            }
            else if
                (
                    csvFileHeaderLine ==
                    "DocumentWorkflowItemID," +
                    "CertificateID," +
                    "SubjectLine," +
                    "Active," +
                    "Compliant," +
                    "NextPolicyExpirationDate," +
                    "WorkflowAnalyst," +
                    "CompanyAnalyst," +
                    "EmailDate," +
                    "EmailFromAddress," +
                    "SubjectLine1," +
                    "Status," +
                    "CertusFileID," +
                    "FileName," +
                    "FileSize," +
                    "FileMIME," +
                    "FileURL"
                )
            {
                this.ImportType += " (WIR 2.0)";
            }
            else if
                (
                    csvFileHeaderLine ==
                    "DocumentWorkflowItemID," +
                    "CertificateID," +
                    "Vendor," +
                    "Active," +
                    "Compliant," +
                    "NextPolicyExpirationDate," +
                    "WorkflowAnalyst," +
                    "CompanyAnalyst," +
                    "EmailDate," +
                    "EmailFromAddress," +
                    "SubjectLine," +
                    "Status," +
                    "CertusFileID," +
                    "FileName," +
                    "FileSize," +
                    "FileMIME," +
                    "FileURL"
                )
            {
                this.ImportType += " (WIR 2.1)";
            }
            else if
                (
                    csvFileHeaderLine ==
                    "DocumentWorkflowItemID," +
                    "CertificateID," +
                    "Vendor," +
                    "Active," +
                    "Compliant," +
                    "IssueDate," +
                    "NextPolicyExpirationDate," +
                    "WorkflowAnalyst," +
                    "WorkflowAnalystID," +
                    "CompanyAnalyst," +
                    "CompanyAnalystID," +
                    "EmailDate," +
                    "EmailFromAddress," +
                    "SubjectLine," +
                    "EmailBody," +
                    "Status," +
                    "CertusFileID," +
                    "FileName," +
                    "FileSize," +
                    "FileMIME," +
                    "FileURL," +
                    "Extracted"
                )
            {
                this.ImportType += " (WIR 3.0)";
            }
            else if
                (
                    csvFileHeaderLine ==
                    "DocumentWorkflowItemID," +
                    "CertificateID," +
                    "Vendor," +
                    "VendorID," +
                    "WorkflowAnalyst," +
                    "WorkflowAnalystID," +
                    "CompanyAnalyst," +
                    "CompanyAnalystID," +
                    "EmailDate," +
                    "EmailFromAddress," +
                    "SubjectLine," +
                    "Status," +
                    "CertusFileID," +
                    "FileName," +
                    "FileSize," +
                    "FileMIME," +
                    "FileURL"
                )
            {
                this.ImportType += " (WIR 3.1)";
            }
            else if
                (
                    csvFileHeaderLine ==
                    "DocumentWorkflowItemID," +
                    "CertificateID," +
                    "Vendor," +
                    "VendorID," +
                    "ClientID," +
                    "WorkflowAnalyst," +
                    "WorkflowAnalystID," +
                    "CompanyAnalyst," +
                    "CompanyAnalystID," +
                    "EmailDate," +
                    "EmailFromAddress," +
                    "SubjectLine," +
                    "Status," +
                    "CertusFileID," +
                    "FileName," +
                    "FileSize," +
                    "FileMIME," +
                    "FileURL"
                )
            {
                this.ImportType += " (WIR 4.0)";
            }
            else
            {
                this.ImportType = "(Unrecognized)";
            }
            #endregion Append Import Type

            // generate items
            WorkflowImportRouter(2);
        }
        private void GenerateWorkflowItemList()
        {
            string csvLine;
            Boolean parsedBoolValue;
            Int32 parsedIntValue;
            DateTime parsedDateTimeValue;
            WorkflowItem itemToImport;

            // generate items list
            while ((csvLine = sr.ReadLine()) != null)
            {
                // return fields in a string array split by commas
                string[] result = Regex.Split(csvLine, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");

                // remove paranthesis if comma is in value
                for (int i = 0; i < result.Length; i++)
                {
                    if (result[i].Contains(',') == true)
                    {
                        result[i] = result[i].Remove(0, 1);
                        result[i] = result[i].Remove(result[i].Length - 1, 1);
                    }
                }

                #region Read And Store Data Per Line

                // --- DocumentWorkflowItemID --- //
                int indx = 0;
                string documentWorkflowItemID = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];

                // --- CertificateID --- //
                ++indx;
                string CertificateID = "";
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                    CertificateID = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];

                // --- Vendor --- //
                ++indx;
                string vendorName = "";
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                    vendorName = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];

                // --- Company --- // (same as above)
                ++indx;
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                    vendorName = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];

                // --- VendorID --- //
                ++indx;
                string vendorID = "";
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                    vendorID = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];

                // --- CompanyID --- // (same as above)
                ++indx;
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                    vendorID = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];

                // --- Client ID --- //
                ++indx;
                string clientID = "";
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                    clientID = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];

                // --- Active --- //
                ++indx;
                bool? active = null;
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                {
                    if (result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] == null || result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] == String.Empty) active = null;
                    else if (Char.IsNumber(result[acceptableHeaderValuesAndTheirIndexes[indx].Item1][0]))
                    {
                        if (Int32.TryParse(result[acceptableHeaderValuesAndTheirIndexes[indx].Item1], out parsedIntValue))
                        {
                            if (parsedIntValue == 0) active = false;
                            else if (parsedIntValue == 1) active = true;
                        }
                        else
                        {
                            active = null;
                        }
                    }
                    else
                    {
                        if (Boolean.TryParse(result[acceptableHeaderValuesAndTheirIndexes[indx].Item1], out parsedBoolValue))
                        {
                            if (!parsedBoolValue) active = false;
                            else if (parsedBoolValue) active = true;
                        }
                        else
                        {
                            active = null;
                        }
                    }
                }

                // --- Compliant --- //
                ++indx;
                bool? compliant = null;
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                {
                    if (result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] == null || result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] == String.Empty) compliant = null;
                    else if (Char.IsNumber(result[acceptableHeaderValuesAndTheirIndexes[indx].Item1][0]))
                    {
                        if (Int32.TryParse(result[acceptableHeaderValuesAndTheirIndexes[indx].Item1], out parsedIntValue))
                        {
                            if (parsedIntValue == 0) compliant = false;
                            else if (parsedIntValue == 1) compliant = true;
                        }
                        else
                        {
                            compliant = null;
                        }
                    }
                    else
                    {
                        if (Boolean.TryParse(result[acceptableHeaderValuesAndTheirIndexes[indx].Item1], out parsedBoolValue))
                        {
                            if (!parsedBoolValue) compliant = false;
                            else if (parsedBoolValue) compliant = true;
                        }
                        else
                        {
                            compliant = null;
                        }
                    }
                }

                // --- IssueDate --- //
                ++indx;
                DateTime? issueDate = null;
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                {
                    if (DateTime.TryParse(result[acceptableHeaderValuesAndTheirIndexes[indx].Item1], out parsedDateTimeValue))
                    {
                        issueDate = parsedDateTimeValue;
                    }
                    else
                    {
                        issueDate = null;
                    }
                }

                // --- NextPolicyExpirationDate --- //
                ++indx;
                DateTime? nextPolicyExpirationDate = null;
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                {
                    if (DateTime.TryParse(result[acceptableHeaderValuesAndTheirIndexes[indx].Item1], out parsedDateTimeValue))
                    {
                        nextPolicyExpirationDate = parsedDateTimeValue;
                    }
                    else
                    {
                        nextPolicyExpirationDate = null;
                    }
                }

                // --- WorkflowAnalyst --- //
                ++indx;
                string workflowAnalyst = "";
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                    workflowAnalyst = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];

                // --- WorkflowAnalystID --- //
                ++indx;
                string workflowAnalystID = "";
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                    workflowAnalystID = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];

                // --- CompanyAnalyst --- //
                ++indx;
                string companyAnalyst = "";
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                    companyAnalyst = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];

                // --- CompanyAnalystID --- //
                ++indx;
                string companyAnalystID = "";
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                    companyAnalystID = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];

                // --- EmailDate --- //
                ++indx;
                DateTime? emailDate = null;
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                {
                    DateTime.TryParse(result[acceptableHeaderValuesAndTheirIndexes[indx].Item1], out parsedDateTimeValue);
                    emailDate = parsedDateTimeValue;
                }

                // --- EmailFromAddress --- //
                ++indx;
                string emailFromAddress = "";
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                    emailFromAddress = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];

                // --- SubjectLine --- //
                ++indx;
                string subjectLine = "";
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                    subjectLine = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];

                // --- EmailBody --- //
                ++indx;
                string emailBody = "";
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                    emailBody = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];

                // --- Status --- //
                ++indx;
                string status = "";
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                    status = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];

                // --- CertusFileID --- //
                ++indx;
                string certusFileID = "";
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                    certusFileID = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];

                // --- FileName --- //
                ++indx;
                string fileName = "";
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                    fileName = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];

                // --- FileSize --- //
                ++indx;
                string fileSize = "";
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                    fileSize = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];

                // --- FileMIME --- //
                ++indx;
                string fileMIME = "";
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                    fileMIME = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];

                // --- FileURL --- //
                ++indx;
                string fileURL = "";
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                    fileURL = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];

                // --- Extracted --- //
                ++indx;
                bool? fileExtracted = null;
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                {
                    if (result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] == null || result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] == String.Empty) fileExtracted = null;
                    else if (Char.IsNumber(result[acceptableHeaderValuesAndTheirIndexes[indx].Item1][0]))
                    {
                        if (Int32.TryParse(result[acceptableHeaderValuesAndTheirIndexes[indx].Item1], out parsedIntValue))
                        {
                            if (parsedIntValue == 0) fileExtracted = false;
                            else if (parsedIntValue == 1) fileExtracted = true;
                        }
                        else
                        {
                            fileExtracted = null;
                        }
                    }
                    else
                    {
                        if (Boolean.TryParse(result[acceptableHeaderValuesAndTheirIndexes[indx].Item1], out parsedBoolValue))
                        {
                            if (!parsedBoolValue) fileExtracted = false;
                            else if (parsedBoolValue) fileExtracted = true;
                        }
                        else
                        {
                            fileExtracted = null;
                        }
                    }
                }

                // --- CONSTRUCTING THE OBJECT --- //
                itemToImport = new WorkflowItem
                    (
                        documentWorkflowItemID,
                        CertificateID,
                        vendorName,
                        vendorID,
                        clientID,
                        active,
                        compliant,
                        issueDate,
                        nextPolicyExpirationDate,
                        workflowAnalyst,
                        workflowAnalystID,
                        companyAnalyst,
                        companyAnalystID,
                        emailDate,
                        emailFromAddress,
                        subjectLine,
                        emailBody,
                        status,
                        certusFileID,
                        fileName,
                        fileURL,
                        fileSize,
                        fileMIME,
                        fileExtracted
                        );

                this.currentImportItems.Add(itemToImport);

                #endregion Read And Store Data Per Line
            }
            sr.Dispose();

            WorkflowImportRouter(3);
        }
        private void SaveWorkflowImportData()
        {
            List<string> itemsOnImport = new List<string>();
            List<string> itemsAdded = new List<string>();
            List<string> itemsCompleted = new List<string>();
            List<string> importItemsInDB = new List<string>();
            List<WorkflowItem> updateList = new List<WorkflowItem>();
            int indx = 0;

            // edit WFM data
            foreach (WorkflowItem item in currentImportItems)
            {
                // add to new list
                updateList.Add(item);

                // edit
                if (updateList[indx].Status == "Completed/Trash" || updateList[indx].Status == "Completed" || updateList[indx].Status == "Trash")
                {
                    updateList[indx].DisplayColor = "Gray";
                    updateList[indx].Note += $"<item added as completed/trash via '{FileName}' > ";
                }
                else
                {
                    updateList[indx].Note += $"<added via '{FileName}'> ";
                }

                itemsOnImport.Add(updateList[indx].ToString());
                ++indx;
            }

            // replace lists
            currentImportItems = updateList;

            // save items on import
            TotalItemsOnImport.AddRange(itemsOnImport);
        }
        //
        // certificate Import
        private void CertificateImportRouter(int i)
        {
            switch (i)
            {
                case 1:
                    SettupCertificateImport();
                    break;
                case 2:
                    GenerateCertificateItemList();
                    break;
                case 3:
                    SaveCertificateImportData();
                    break;
                default:
                    break;
            }
        }
        public void InitiateCertificateImport(string csvFileName)
        {
            this.ImportType = "CertifacteCSV";
            this.FilePath = csvFileName;

            // get filename from filepath
            char[] charArray = FilePath.ToCharArray();
            Array.Reverse(charArray);
            string revFileName = new string(charArray);
            int indx = revFileName.IndexOf(@"\");
            FileName = FilePath.Substring(FilePath.Length - indx);

            CertificateImportRouter(1);
        }
        private void SettupCertificateImport()
        {
            string csvFileHeaderLine;
            string[] csvFileHeaderValues;

            #region Instantiate Acceptable Headers and Indexes List
            List<Tuple<int, string>> acceptableHeaderValuesAndTheirIndexes = new List<Tuple<int, string>>();

            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "BCS Certificate ID"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Certificate ID")); // same as above
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Certificate Name"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Certificate Identity Field"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Identity Field")); // same as above
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Certificate ID")); // same as above
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Company Name"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "BCS Company ID"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Company ID")); // same as above
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Client ID"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Ins. Req. Category"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Issue Date"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Next Policy Expiration Date"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Certificate Active"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Certificate Compliant"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Back To Client Status"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Buildings"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Certificate Last Note Date"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Client"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Market"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Service Type"));
            #endregion Instantiate Acceptable Headers and Indexes List

            // Open streamreader
            sr = new StreamReader(FilePath);

            // Save file length data for reporting progress
            Stream baseStream = sr.BaseStream;
            long length = baseStream.Length;

            #region Save Header
            // Reads header first and stores it as array of strings
            csvFileHeaderLine = sr.ReadLine();
            csvFileHeaderValues = Regex.Split(csvFileHeaderLine, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");

            // remove paranthesis if comma is in value
            for (int i = 0; i < csvFileHeaderValues.Length; i++)
            {
                if (csvFileHeaderValues[i].Contains(',') == true)
                {
                    csvFileHeaderValues[i] = csvFileHeaderValues[i].Remove(0, 1);
                    csvFileHeaderValues[i] = csvFileHeaderValues[i].Remove(csvFileHeaderValues[i].Length - 1, 1);
                }
            }

            // store header indexes if string values match any of the acceptable header values
            for (int i = 0; i < csvFileHeaderValues.Length; i++)
            {
                for (int j = 0; j < acceptableHeaderValuesAndTheirIndexes.Count; j++)
                {
                    string csvHeaderValForComparison = new String(csvFileHeaderValues[i].Where(c => Char.IsLetter(c) || Char.IsNumber(c)).ToArray()).ToLower();
                    string accHeaderValForComparison = new String(acceptableHeaderValuesAndTheirIndexes[j].Item2.Where(c => Char.IsLetter(c) || Char.IsNumber(c)).ToArray()).ToLower();

                    if (csvHeaderValForComparison == (accHeaderValForComparison))
                    {
                        // save new tuple which contains the correct index location for the header 
                        Tuple<int, string> newTuple;
                        int index = acceptableHeaderValuesAndTheirIndexes.IndexOf(acceptableHeaderValuesAndTheirIndexes[j]);
                        string accHeader = acceptableHeaderValuesAndTheirIndexes[j].Item2;
                        newTuple = new Tuple<int, string>(i, accHeader);

                        // replace old tuple with the new one
                        acceptableHeaderValuesAndTheirIndexes[index] = newTuple;
                    }
                }
            }

            // right now, return if BCS ID and Certificate Name are not in their correct places
            if (acceptableHeaderValuesAndTheirIndexes[0].Item1 != 0 && acceptableHeaderValuesAndTheirIndexes[1].Item1 != 1)
            {
                throw new CertificateImportNotCorrectFormatException("CSV file is not recognized as an acceptable Certificate Export. BCS Certificate ID must be in the first column followed by the Certificate Name in the second column.");
            }
            #endregion Save Header

            GenerateCertificateItemList();
        }
        private void GenerateCertificateItemList()
        {
            string csvLine = "";
            Boolean parsedBoolValue;
            DateTime parsedDateTimeValue;
            Certificate certificateToImport;

            // generate items list
            while ((csvLine = sr.ReadLine()) != null)
            {
                // return fields in a string array split by commas
                string[] result = Regex.Split(csvLine, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");

                // remove paranthesis if comma is in value
                for (int i = 0; i < result.Length; i++)
                {
                    if (result[i].Contains(',') == true)
                    {
                        result[i] = result[i].Remove(0, 1);
                        result[i] = result[i].Remove(result[i].Length - 1, 1);
                    }
                }

                #region Read And Store Data Per Line
                //
                int indx = 0;
                string bcsCertificateID = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];
                // --- Certificate ID --- // (same as above)
                ++indx;
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                    bcsCertificateID = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];
                // --- Certificate Name --- //
                ++indx;
                string certificateName = "";
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                    certificateName = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];
                // --- Certificate Identity Field --- //
                ++indx;
                string certificateIdentityField = "";
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                    certificateIdentityField = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];
                // --- Identity Field --- // (same as above)
                ++indx;
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                    certificateIdentityField = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];
                // --- Certificate ID --- // (same as above)
                ++indx;
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                    certificateIdentityField = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];
                // --- Company Name --- //
                ++indx;
                string companyName = "";
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                    companyName = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];
                // --- BCS Company ID --- //
                ++indx;
                string bcsCompanyID = "";
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                    bcsCompanyID = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];
                // --- Company ID --- // (same as above)
                ++indx;
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                    bcsCompanyID = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];
                // --- Client ID --- //
                ++indx;
                string clientID = "";
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                    clientID = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];
                // --- Ins Req Category --- //
                ++indx;
                string insReqCategory = "";
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                    insReqCategory = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];
                // --- Issue Date --- //
                ++indx;
                DateTime? issueDate = null;
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                {
                    if (DateTime.TryParse(result[acceptableHeaderValuesAndTheirIndexes[indx].Item1], out parsedDateTimeValue)) issueDate = parsedDateTimeValue;
                    else issueDate = null;
                }
                // --- Next Policy Expiration --- //
                ++indx;
                DateTime? nextPolicyExpirationDate = null;
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                {
                    if (DateTime.TryParse(result[acceptableHeaderValuesAndTheirIndexes[indx].Item1], out parsedDateTimeValue)) nextPolicyExpirationDate = parsedDateTimeValue;
                    else nextPolicyExpirationDate = null;
                }
                // --- Certificate Active --- //
                ++indx;
                bool? certificateActive = null;
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                {
                    if (Boolean.TryParse(result[acceptableHeaderValuesAndTheirIndexes[indx].Item1], out parsedBoolValue))
                    {
                        if (parsedBoolValue) certificateActive = parsedBoolValue;
                        else certificateActive = parsedBoolValue;
                    }
                    else certificateActive = null;
                }
                // --- Certificate Compliant --- //
                ++indx;
                bool? certificateCompliant = null;
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                {
                    if (Boolean.TryParse(result[acceptableHeaderValuesAndTheirIndexes[indx].Item1], out parsedBoolValue))
                    {
                        if (parsedBoolValue) certificateCompliant = parsedBoolValue;
                        else certificateCompliant = parsedBoolValue;
                    }
                    else certificateCompliant = null;
                }
                // --- Back to Client Status --- //
                ++indx;
                string backToClientStatus = "";
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                    backToClientStatus = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];
                // --- Buildings --- //
                ++indx;
                string buildings = "";
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                    buildings = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];
                // --- Certificate Last Note Date --- //
                ++indx;
                DateTime? lastNoteDate = null;
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                {
                    if (DateTime.TryParse(result[acceptableHeaderValuesAndTheirIndexes[indx].Item1], out parsedDateTimeValue)) lastNoteDate = parsedDateTimeValue;
                    else issueDate = null;
                }
                // --- Source --- //
                ++indx;
                string source = "";
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                    source = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];
                // --- market --- //
                ++indx;
                string market = "";
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                    market = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];
                // --- Service Type --- //
                ++indx;
                string serviceType = "";
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                    serviceType = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];

                // construct the certificate from the line item and whatever was extracted
                certificateToImport = new Certificate(bcsCertificateID, certificateName, certificateIdentityField, companyName, bcsCompanyID, clientID, insReqCategory, issueDate, nextPolicyExpirationDate, certificateActive, certificateCompliant, backToClientStatus, buildings, lastNoteDate, source, market, serviceType);

                // add to certificates
                this.currentImportCertificates.Add(certificateToImport);

                #endregion Read And Store Data Per Line
            }
            sr.Dispose();
        }
        private void SaveCertificateImportData()
        {
            //...
        }
        //
        // company Import
        private void CompanyImportRouter(int i)
        {
            switch (i)
            {
                case 1:
                    SettupCompanyImport();
                    break;
                case 2:
                    GenerateCompanyItemList();
                    break;
                case 3:
                    SaveCompanyImportData();
                    break;
                default:
                    break;
            }
        }
        public void InitiateCompanyImport(string csvFileName)
        {
            this.ImportType = "CompanyCSV";
            this.FilePath = csvFileName;

            // get filename from filepath
            char[] charArray = FilePath.ToCharArray();
            Array.Reverse(charArray);
            string revFileName = new string(charArray);
            int indx = revFileName.IndexOf(@"\");
            FileName = FilePath.Substring(FilePath.Length - indx);

            CompanyImportRouter(1);
        }
        private void SettupCompanyImport()
        {
            string csvFileHeaderLine;
            string[] csvFileHeaderValues;
            int otherContactHeaders = 0;
            bool stopSettingIndex = false;

            #region Instantiate Acceptable Headers and Indexes List
            List<Tuple<int, string>> acceptableHeaderValuesAndTheirIndexes = new List<Tuple<int, string>>();

            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "BCS Company ID"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Company ID")); // same as above
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Company Name"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Client ID"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Vendor ID"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "DBA"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Address 1"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Address 2"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "City"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "State"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Zip"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Country"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Phone #"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Email Address"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Company Active"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Company Compliance Level"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Analyst"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Company Last Note Date"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Main Contact"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Other Contact"));
            #endregion Instantiate Acceptable Headers and Indexes List

            // Open streamreader
            sr = new StreamReader(FilePath);

            // Save file length data for reporting progress
            Stream baseStream = sr.BaseStream;
            long length = baseStream.Length;

            #region Save Header
            // Read header first and store
            csvFileHeaderLine = sr.ReadLine();
            csvFileHeaderValues = Regex.Split(csvFileHeaderLine, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");

            // remove paranthesis if comma is in value
            for (int i = 0; i < csvFileHeaderValues.Length; i++)
            {
                if (csvFileHeaderValues[i].Contains(',') == true)
                {
                    csvFileHeaderValues[i] = csvFileHeaderValues[i].Remove(0, 1);
                    csvFileHeaderValues[i] = csvFileHeaderValues[i].Remove(csvFileHeaderValues[i].Length - 1, 1);
                }
            }

            // store header indexes if string values match any of the acceptable header values
            for (int i = 0; i < csvFileHeaderValues.Length; i++)
            {
                for (int j = 0; j < acceptableHeaderValuesAndTheirIndexes.Count; j++)
                {
                    string csvHeaderValForComparison = new String(csvFileHeaderValues[i].Where(c => Char.IsLetter(c) || Char.IsNumber(c)).ToArray()).ToLower();
                    string accHeaderValForComparison = new String(acceptableHeaderValuesAndTheirIndexes[j].Item2.Where(c => Char.IsLetter(c) || Char.IsNumber(c)).ToArray()).ToLower();

                    if (csvHeaderValForComparison == (accHeaderValForComparison))
                    {
                        // save new tuple which contains the correct index location for the header 
                        Tuple<int, string> newTuple;
                        int index = acceptableHeaderValuesAndTheirIndexes.IndexOf(acceptableHeaderValuesAndTheirIndexes[j]);
                        string accHeader = acceptableHeaderValuesAndTheirIndexes[j].Item2;
                        newTuple = new Tuple<int, string>(i, accHeader);

                        // this will only affect anything if there's ever header values listed after the other contacts
                        if (!stopSettingIndex)
                        {
                            // replace old tuple with the new one
                            acceptableHeaderValuesAndTheirIndexes[index] = newTuple;
                        }
                        stopSettingIndex = false;

                        // if this is the main contact header, we want to skip the next 3 indexes
                        if (accHeader == "Main Contact")
                        {
                            i += 3;
                        }

                        // if this is an other contact header, we want to skip 3 indexes (theres 4 indexes for each contact - 
                        // name, title, phone, and email) and save how many other contacts we find. We also want to ignore setting
                        // the index for the additional other contacts because this will be done through using the other countacts
                        // int value
                        if (accHeader == "Other Contact")
                        {
                            stopSettingIndex = true;
                            ++otherContactHeaders;
                            i += 3;
                        }
                    }
                }
            }

            // right now, return if BCS id and Company Name are not in their correct places
            if (acceptableHeaderValuesAndTheirIndexes[0].Item1 != 0 && acceptableHeaderValuesAndTheirIndexes[1].Item1 != 1)
            {
                throw new CompanyImportNotCorrectFormatException("CSV file is not recognized as an acceptable Company Export. BCS Company ID must be in the first column followed by the Company Name in the second column.");
            }
            #endregion Save Header

            GenerateCompanyItemList();
        }
        private void GenerateCompanyItemList()
        {
            string csvLine = "";
            Boolean parsedBoolValue;
            Company companyToImport;

            // generate items list
            while ((csvLine = sr.ReadLine()) != null)
            {
                // return fields in a string array split by commas
                string[] result = Regex.Split(csvLine, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");

                // remove paranthesis if comma is in value
                for (int i = 0; i < result.Length; i++)
                {
                    if (result[i].Contains(',') == true)
                    {
                        result[i] = result[i].Remove(0, 1);
                        result[i] = result[i].Remove(result[i].Length - 1, 1);
                    }
                }

                #region Read And Store Data Per Line
                //
                // BCS Company ID has to be there and has to be first***
                int indx = 0;
                string bcsCompanyID = "";
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                {
                    bcsCompanyID = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];
                }

                //
                // --- Company ID --- // (same as above)
                ++indx;
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                {
                    bcsCompanyID = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];
                }
                if (bcsCompanyID == null || bcsCompanyID == String.Empty) throw new Exception("BCS Company ID must be in the first column.");
                //
                // Company Name has to be second
                indx++;
                string companyName = "";
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                {
                    companyName = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];
                }
                if (companyName == null || companyName == String.Empty) throw new Exception("Company Name must be in the second column.");
                indx++;
                string clientID = "";
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                {
                    clientID = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];
                }
                //
                // for the rest, let the default data populate if index wasn't found (-1), the result values aren't this long, or the result value is null
                indx++;
                string vendorID = "";
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                {
                    vendorID = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];
                }
                indx++;
                string dba = "";
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                {
                    dba = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];
                }
                indx++;
                string address1 = "";
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                {
                    address1 = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];
                }
                indx++;
                string address2 = "";
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                {
                    address2 = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];
                }
                indx++;
                string city = "";
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                {
                    city = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];
                }
                indx++;
                string state = "";
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                {
                    state = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];
                }
                indx++;
                string zip = "";
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                {
                    zip = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];
                }
                indx++;
                string country = "";
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                {
                    country = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];
                }
                indx++;
                string phone = "";
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                {
                    phone = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];
                }
                indx++;
                string emailAddress = "";
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                {
                    emailAddress = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];
                }
                indx++;
                bool? companyActive = null;
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                {
                    if (Boolean.TryParse(result[acceptableHeaderValuesAndTheirIndexes[indx].Item1], out parsedBoolValue))
                    {
                        if (parsedBoolValue)
                        {
                            companyActive = parsedBoolValue;
                        }
                        else
                        {
                            companyActive = parsedBoolValue;
                        }
                    }
                    else
                    {
                        companyActive = null;
                    }
                }
                indx++;
                string companyComplianceLevel = "";
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                {
                    companyComplianceLevel = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];
                }
                indx++;
                string analyst = "";
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                {
                    analyst = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];
                }
                indx++;
                string companyLastNoteDate = "";
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                {
                    companyLastNoteDate = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];
                }
                //
                // for each contact, instantiate contacts
                List<Contact> contacts = new List<Contact>();
                indx++;
                Contact mainContact = new Contact();
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                {
                    mainContact.Name = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];
                    mainContact.Title = result[(acceptableHeaderValuesAndTheirIndexes[indx].Item1) + 1];
                    //mainContact.Phone = result[(acceptableHeaderValuesAndTheirIndexes[indx].Item1) + 2];
                    mainContact.Email = result[(acceptableHeaderValuesAndTheirIndexes[indx].Item1) + 3];

                    if (mainContact.Name != String.Empty) contacts.Add(mainContact);
                }
                indx++;
                if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                {
                    int index = acceptableHeaderValuesAndTheirIndexes[indx].Item1; // should be 17?

                    while (result[index] != null && result[index] != String.Empty)
                    {
                        Contact otherContact = new Contact();

                        otherContact.Name = result[index];
                        otherContact.Title = result[++index];
                        //otherContact.Phone = result[++index];
                        ++index;
                        otherContact.Email = result[++index];

                        ++index;

                        contacts.Add(otherContact);
                    }
                }
                //
                // construct the company from the line item and whatever was extracted
                companyToImport = new Company(companyName, bcsCompanyID, clientID, vendorID, dba, address1, address2, city, state,
                    zip, country, phone, emailAddress, companyActive, companyComplianceLevel, analyst, companyLastNoteDate,
                    contacts);

                // add to lists
                this.currentImportCompanies.Add(companyToImport);

                #endregion Read And Store Data Per Line
            }
            sr.Dispose();
        }
        private void SaveCompanyImportData()
        {
            //...
        }

        //
        // return data
        public CSVImport ReturnCSVImport()
        {
            CSVImport i = new CSVImport();

            i.ImportDate = this.ImportDate;
            i.ImportName = this.ImportName;
            i.ImportType = this.ImportType;
            i.ItemsAdded = this.ItemsAdded;
            i.FilePath = this.FilePath;
            i.FileName = this.FileName;
            i.TotalItemsOnImport = this.TotalItemsOnImport;

            return i;
        }
        public List<WorkflowItem> ReturnWorkflowItems()
        {
            return this.currentImportItems;
        }
        public List<Certificate> ReturnCertificates()
        {
            return this.currentImportCertificates;
        }
        public List<Company> ReturnCompanies()
        {
            return this.currentImportCompanies;
        }
        public override string ToString()
        {
            return $"{this.ImportType} - {this.ImportDate}";
        }
    }
}
