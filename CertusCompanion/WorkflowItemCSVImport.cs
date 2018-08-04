// Certus Companion v3.0

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CertusCompanion
{
    [Serializable]
    class WorkflowItemCSVImport : Import
    {
        // data
        private string fileName;
        private List<string> newItemsAdded;
        private List<string> completedSinceLastImport;
        private List<WorkflowItem> currentImportItems;
        private string csvFileHeaderLine;
        private ItemImports itemImportsList;
        private List<WorkflowItem> currentItemsInDatabase;

        // properties
        public DateTime ImportDate { get => importDate; set => importDate = value; }
        public string FileName { get => fileName; set => fileName = value; }
        public string ImportType { get => importType; set => importType = value; }
        public int TotalItemsOnImport { get => totalItemsOnImport; set => totalItemsOnImport = value; }
        public List<string> NewItemsAdded { get => newItemsAdded; set => newItemsAdded = value; }
        public List<string> CompletedSinceLastImport { get => completedSinceLastImport; set => completedSinceLastImport = value; }
        public List<WorkflowItem> CurrentImportItems { get => currentImportItems; set => currentImportItems = value; }
        public string CsvFileHeaderLine { get => csvFileHeaderLine; set => csvFileHeaderLine = value; }
        public ItemImports ItemImportsList { get => itemImportsList; set => itemImportsList = value; }
        public List<WorkflowItem> CurrentItemsInDatabase { get => currentItemsInDatabase; set => currentItemsInDatabase = value; }

        // constructors
        public WorkflowItemCSVImport()
        {
            //this.ImportDate = DateTime.Now;
            this.FileName = "";
            this.ImportType = "";
            this.TotalItemsOnImport = 0;
            this.NewItemsAdded = new List<string>();
            this.CompletedSinceLastImport = new List<string>();
            this.CurrentImportItems = new List<WorkflowItem>();
            //this.WorkflowItemDatabase = new WorkflowItemDatabase();
            //this.ItemImportsList = new ItemImports();
        }

        public WorkflowItemCSVImport(List<WorkflowItem> currentItemsInDatabase)
        {
            this.CurrentItemsInDatabase = currentItemsInDatabase;
            //this.ImportDate = DateTime.Now;
            this.FileName = "";
            this.ImportType = "";
            this.TotalItemsOnImport = 0;
            this.NewItemsAdded = new List<string>();
            this.CompletedSinceLastImport = new List<string>();
            this.CurrentImportItems = new List<WorkflowItem>();
            //this.WorkflowItemDatabase = new WorkflowItemDatabase();
            //this.ItemImportsList = new ItemImports();
        }

        public WorkflowItemCSVImport(DateTime importDate, string fileName, string importType, int totalItemsOnImport, List<string> newItemsAdded, List<string> completedSinceLastImport)
        {
            this.ImportDate = importDate;
            this.FileName = fileName;
            this.ImportType = "";
            this.TotalItemsOnImport = totalItemsOnImport;
            this.NewItemsAdded = newItemsAdded;
            this.CompletedSinceLastImport = completedSinceLastImport;
            this.CurrentImportItems = new List<WorkflowItem>();
            //this.WorkflowItemDatabase = new WorkflowItemDatabase();
            //this.ItemImportsList = new ItemImports();
        }

        public WorkflowItemCSVImport Import(string csvFileName)
        {
            WorkflowItem itemToImport;
            this.FileName = csvFileName;
            string csvFileHeaderLine;
            string[] csvFileHeaderValues;
            string csvLine;
            Boolean parsedBoolValue;
            Int32 parsedIntValue;
            DateTime parsedDateTimeValue;

            #region Instantiate Acceptable Headers and Indexes List
            List<Tuple<int, string>> acceptableHeaderValuesAndTheirIndexes = new List<Tuple<int, string>>();

            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "DocumentWorkflowItemID"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "ContractID"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Vendor"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "Company")); //same as above
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "VendorID"));
            acceptableHeaderValuesAndTheirIndexes.Add(new Tuple<int, string>(-1, "CompanyID")); // same as above
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

            // Opens the csv file for reading
            using (StreamReader sr = new StreamReader(FileName))
            {
                // save file length data for reporting progress
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

                #region Determine Import Type
                if
                    (
                        csvFileHeaderLine == 
                        "DocumentWorkflowItemID," +
                        "ContractID," +
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
                    this.ImportType = "WIR 1.0";
                }
                else if 
                    (
                        csvFileHeaderLine == 
                        "DocumentWorkflowItemID," +
                        "ContractID," +
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
                    this.ImportType = "WIR 2.0";
                }
                else if 
                    (
                        csvFileHeaderLine == 
                        "DocumentWorkflowItemID," +
                        "ContractID," +
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
                    this.ImportType = "WIR 2.1";
                }
                else if 
                    (
                        csvFileHeaderLine ==
                        "DocumentWorkflowItemID," +
                        "ContractID," +
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
                    this.ImportType = "WIR 3.0";
                }
                else if
                    (
                        csvFileHeaderLine ==
                        "DocumentWorkflowItemID," +
                        "ContractID," +
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
                    this.ImportType = "WIR 3.1";
                }
                else
                {
                    this.ImportType = "Unrecognized";
                }
                #endregion Determine Import Type

                // Reads csv line by line
                while ((csvLine = sr.ReadLine()) != null)
                {
                    // return fields in a string array split by commas (not including those which are within quotations)
                    // CHANGE COMMA TO SEMICOLON HERE IF .SCSV
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

                    #region Read And Store Company Data Per Line

                    // --- DocumentWorkflowItemID --- //
                    int indx = 0;
                    string documentWorkflowItemID = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];

                    // --- ContractID --- //
                    ++indx;
                    string contractID = "";
                    if (acceptableHeaderValuesAndTheirIndexes[indx].Item1 > 0 && result[acceptableHeaderValuesAndTheirIndexes[indx].Item1] != null)
                        contractID = result[acceptableHeaderValuesAndTheirIndexes[indx].Item1];

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
                            contractID,
                            vendorName,
                            vendorID,
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

                    this.CurrentImportItems.Add(itemToImport);

                    #endregion Read And Store Company Data Per Line

                    // report progress
                    //if (this.InvokeRequired)
                    //{
                    //    this.Invoke(new Action(() => { importCompaniesBackgroundWorker.ReportProgress(Convert.ToInt32((baseStream.Position / (double)length) * 100)); }));
                    //}
                    //else
                    //    importCompaniesBackgroundWorker.ReportProgress(Convert.ToInt32(baseStream.Position / length * 100));
                }
            }

            // save remaining data associated with import
            SaveItemImportData();

            return this;
        }

        public void SaveItemImportData()
        {
            List<string> itemsAdded = new List<string>();
            List<string> itemsCompleted = new List<string>();
            List<string> importItemsInDB = new List<string>();
            WorkflowItem updateItem = new WorkflowItem();

            //get fileName path
            char[] charArray = FileName.ToCharArray();
            Array.Reverse(charArray);
            string revFileName = new string(charArray);
            int indx = revFileName.IndexOf(@"\");
            string filePath = FileName.Substring(FileName.Length - indx);

            this.TotalItemsOnImport = CurrentImportItems.Count();

            // if the db items are available
            if (CurrentItemsInDatabase != null && CurrentItemsInDatabase.Count > 0)
            { 
                foreach (WorkflowItem importItem in CurrentImportItems)
                {
                    // if the id doesn't exist in the db items
                    if (!CurrentItemsInDatabase.Exists(i => i.DocumentWorkflowItemID == importItem.DocumentWorkflowItemID))
                    {
                        CurrentItemsInDatabase.Add(importItem);
                        importItem.Note += $"<added via '{filePath}'> ";
                        itemsAdded.Add(importItem.DocumentWorkflowItemID);
                    }
                    // if the id does exist 
                    else 
                    {
                        try
                        {
                            string newStatus = importItem.Status;
                            string newAssignment = importItem.AssignedToName;
                            WorkflowItem wi = new WorkflowItem();
                            updateItem = CurrentItemsInDatabase.FirstOrDefault((i => i.DocumentWorkflowItemID == importItem.DocumentWorkflowItemID));
                            string oldStatus = updateItem.Status;
                            string oldAssignment = updateItem.AssignedToName;

                            // if status or assignment changed
                            if (!DoesWorkflowInformationMatch(updateItem, importItem))
                            {
                                wi = updateItem;
                                wi.WorkflowAnalyst = importItem.WorkflowAnalyst;
                                wi.CompanyAnalyst = importItem.CompanyAnalyst;
                                wi.Status = importItem.Status;
                                wi.AssignedToName = importItem.AssignedToName;
                                wi.WorkflowItemInformationDifferentThanCertus = false;

                                // if an item is yellow after the import, it means the item was never changed on certus even though it was colored as changed and should have been
                                // the item wf information is now back to reflecting certus
                                wi.DisplayColor = "Yellow";

                                wi.Note += $"<{oldStatus} : {oldAssignment}" +
                                    $" -> {newStatus} : {newAssignment} via '{filePath}'> ";

                                CurrentItemsInDatabase[CurrentItemsInDatabase.IndexOf(updateItem)] = wi;
                            }
                            else // item status/assignment did not change
                            {
                                wi = updateItem;
                                wi.WorkflowItemInformationDifferentThanCertus = false;

                                CurrentItemsInDatabase[CurrentItemsInDatabase.IndexOf(updateItem)] = wi;
                            }

                            importItemsInDB.Add(importItem.DocumentWorkflowItemID);
                            
                        }
                        catch (Exception)
                        {
                            // don't do anything, just don't crash here incase the id can't be found in the currentItemsInDb for some reason
                        }
                    }
                }

                // complete and paint items gray if they're not on the current import
                foreach (WorkflowItem item in CurrentItemsInDatabase)
                {
                    // if the item isn't on the import list, that means it was completed or trashed. importItems only included non-completed or trashed items
                    if (!CurrentImportItems.Exists(i => i.DocumentWorkflowItemID == item.DocumentWorkflowItemID))
                    {
                        if (item.Status != "Completed/Trash" && item.Status != "Completed" && item.Status != "Trash")
                        {
                            itemsCompleted.Add(item.DocumentWorkflowItemID);
                            item.Status = "Completed/Trash";
                            item.Note += $"<completed via clean-up from '{filePath}'> ";
                        }

                        // by default, these items should show the completed color which is gray. don't remove black
                        if (item.DisplayColor != "Black" && item.DisplayColor != "Gray")
                            item.DisplayColor = "Gray";
                    }
                }

                this.CompletedSinceLastImport = itemsCompleted;
                this.NewItemsAdded = itemsAdded;
                this.ImportDate = DateTime.Now;
            }
            else
            {
                // only for first imports
                CurrentItemsInDatabase = new List<WorkflowItem>();

                foreach (WorkflowItem importItem in CurrentImportItems)
                {
                    if (importItem.Status == "Completed/Trash" || importItem.Status == "Completed" || importItem.Status == "Trash")
                    {
                        importItem.DisplayColor = "Gray";
                        importItem.Note += $"<item added as completed/trash via '{filePath}' > ";
                    }
                    else
                    {
                        importItem.Note += $"<added via '{filePath}'> ";
                    }

                    CurrentItemsInDatabase.Add(importItem);
                    itemsAdded.Add(importItem.DocumentWorkflowItemID);
                }

                this.CompletedSinceLastImport.Add("n/a");
                this.NewItemsAdded = itemsAdded;
                this.ImportDate = DateTime.Now;
            }
        }

        private bool DoesWorkflowInformationMatch(WorkflowItem currentItemInDB, WorkflowItem importItem)
        {
            // if this data is different, return false
            if (currentItemInDB.AssignedToName != importItem.AssignedToName || currentItemInDB.Status != importItem.Status)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void ClearDataNotToBeSaved()
        {
            this.CurrentItemsInDatabase.Clear();
            this.CurrentImportItems.Clear();
            this.CompletedSinceLastImport.Clear();
        }

        public override string ToString()
        {
            if (this.FileName.Contains("CBRE"))
            {
                return $"{this.FileName.Substring(FileName.IndexOf("CBRE"))}, Items: {this.TotalItemsOnImport.ToString()}";
            }
            else return $"{this.FileName}, Items: {this.TotalItemsOnImport.ToString()}";
        }
    }
}
