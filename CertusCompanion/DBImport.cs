using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace CertusCompanion
{
    [Serializable]
    class DBImport : Import
    {
        //
        // data declaration
        public List<string> TotalItemsOnImport { get; set; }
        private List<WorkflowItem> currentImportItems;
        private int itemCount;
        private string clientID;
        private string workflowItemSelection;

        //
        // constructor
        public DBImport()
        {
            this.ImportDate = DateTime.Now;
            this.ImportName = String.Empty;
            this.ImportType = String.Empty;
            this.ItemsAdded = new List<string>();
            this.ItemsUpdated = new List<string>();
            TotalItemsOnImport = new List<string>();

            currentImportItems = new List<WorkflowItem>();
        }

        //
        // import workflow items process
        private void WorkflowImportRouter(int i)
        {
            switch (i)
            {
                case 1:
                    SettupWorkflowImport();
                    break;
                case 2:
                    GenerateWorkflowItemList();
                    break;
                case 3:
                    SaveWorkflowImportData();
                    break;
                default:
                    break;
            }
        }
        public void InitiateWorkflowImport(string clientID, string importType, int itemCount = 0)
        {
            this.itemCount = itemCount;
            this.clientID = clientID;
            this.workflowItemSelection = importType;

            this.ImportType = "DB Import";

            WorkflowImportRouter(1);
        }
        private void SettupWorkflowImport()
        {
            // test DB connection
            #region TestConn
            string connectionString = ConfigurationManager.ConnectionStrings["CertusDB"].ToString();
            string query;

            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand command = conn.CreateCommand();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
            }
            #endregion

            // if there is a LoadingForm, report progress
            if (WorkflowManager.CheckIfFormIsOpened("LoadingForm"))
            {
                if (Application.OpenForms[0].InvokeRequired) Application.OpenForms[0].Invoke(new Action(() =>
                {
                    (Application.OpenForms["LoadingForm"] as LoadingForm).ChangeLabel($"Executing query...");
                    (Application.OpenForms["LoadingForm"] as LoadingForm).MoveBar(25);
                    (Application.OpenForms["LoadingForm"] as LoadingForm).HideCloseBtn();
                    (Application.OpenForms["LoadingForm"] as LoadingForm).Refresh();
                }));
                else
                {
                    (Application.OpenForms["LoadingForm"] as LoadingForm).ChangeLabel($"Executing query...");
                    (Application.OpenForms["LoadingForm"] as LoadingForm).MoveBar(25);
                    (Application.OpenForms["LoadingForm"] as LoadingForm).HideCloseBtn();
                    (Application.OpenForms["LoadingForm"] as LoadingForm).Refresh();
                }
            }

            // generate items
            WorkflowImportRouter(2);
        }
        private void GenerateWorkflowItemList()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["CertusDB"].ToString();
            string query;

            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand command = conn.CreateCommand();

            // get query
            using (Stream strm = Assembly.GetExecutingAssembly().GetManifestResourceStream("CertusCompanion.ImportQueries.WIR4.0_DS.sql"))
            {
                using (StreamReader sr = new StreamReader(strm))
                {
                    query = sr.ReadToEnd();
                }
            }

            // manipulate query
            if (workflowItemSelection == "Non-completed")
            {
                query = query.Replace("TOP", "--TOP");
                query = query.Replace("0--<cl>", $"{clientID}--<cl>");
                query = query.Replace("AND DocumentWorkflowStatus.DocumentWorkflowStatusID > 3--<c2>", "--AND DocumentWorkflowStatus.DocumentWorkflowStatusID > 3--<c2>");
            }
            else if (workflowItemSelection == "Most Recent...")
            {
                query = query.Replace("TOP 0", $"TOP {itemCount}");
                query = query.Replace("0--<cl>", $"{clientID}--<cl>");
                query = query.Replace("AND DocumentWorkflowStatus.DocumentWorkflowStatusID <= 3--<c1>", "--AND DocumentWorkflowStatus.DocumentWorkflowStatusID <= 3--<c1>");
                query = query.Replace("AND DocumentWorkflowStatus.DocumentWorkflowStatusID > 3--<c2>", "--AND DocumentWorkflowStatus.DocumentWorkflowStatusID > 3--<c2>");
            }
            else if (workflowItemSelection == "Most Recent (Non-completed)...")
            {
                query = query.Replace("TOP 0", $"TOP {itemCount}");
                query = query.Replace("0--<cl>", $"{clientID}--<cl>");
                query = query.Replace("AND DocumentWorkflowStatus.DocumentWorkflowStatusID > 3--<c2>", "--AND DocumentWorkflowStatus.DocumentWorkflowStatusID > 3--<c2>");
            }
            else if (workflowItemSelection == "Most Recent (Completed)...")
            {
                query = query.Replace("TOP 0", $"TOP {itemCount}");
                query = query.Replace("0--<cl>", $"{clientID}--<cl>");
                query = query.Replace("AND DocumentWorkflowStatus.DocumentWorkflowStatusID <= 3--<c1>", "--AND DocumentWorkflowStatus.DocumentWorkflowStatusID <= 3--<c1>");
            }

            // execute query
            command.CommandText = query;
            command.CommandType = CommandType.Text;
            command.CommandTimeout = 450;

            SqlDataAdapter wiAdapter = new SqlDataAdapter(command);
            DataTable wiTable = new DataTable();
            wiAdapter.Fill(wiTable);

            // if there is a LoadingForm, report progress
            if (WorkflowManager.CheckIfFormIsOpened("LoadingForm"))
            {
                if (Application.OpenForms[0].InvokeRequired) Application.OpenForms[0].Invoke(new Action(() =>
                {
                    (Application.OpenForms["LoadingForm"] as LoadingForm).ChangeLabel($"Generating items...");
                    (Application.OpenForms["LoadingForm"] as LoadingForm).MoveBar(25);
                    (Application.OpenForms["LoadingForm"] as LoadingForm).Refresh();
                }));
                else
                {
                    (Application.OpenForms["LoadingForm"] as LoadingForm).ChangeLabel($"Generating items...");
                    (Application.OpenForms["LoadingForm"] as LoadingForm).MoveBar(25);
                    (Application.OpenForms["LoadingForm"] as LoadingForm).Refresh();
                }
            }

            // add to WI
            foreach (DataRow row in wiTable.Rows)
            {
                string documentWorkflowItemID = row[0].ToString();
                string contractID = row[1].ToString();
                string vendorName = row[2].ToString();
                string vendorID = row[3].ToString();
                string clID = row[4].ToString();
                string workflowAnalyst = row[5].ToString();
                string workflowAnalystID = row[6].ToString();
                string companyAnalyst = row[7].ToString();
                string companyAnalystID = row[8].ToString();
                DateTime parsedDateTimeValue;
                DateTime? emailDate = null;
                DateTime.TryParse(row[9].ToString(), out parsedDateTimeValue);
                emailDate = parsedDateTimeValue;
                string emailFromAddress = row[10].ToString();
                string subjectLine = row[11].ToString();
                string status = row[12].ToString();
                string certusFileID = row[13].ToString();
                string fileName = row[14].ToString();
                string fileSize = row[15].ToString();
                string fileMIME = row[16].ToString();
                string fileURL = row[17].ToString();

                WorkflowItem wi = new WorkflowItem
                (
                    documentWorkflowItemID,
                    contractID,
                    vendorName,
                    vendorID,
                    clID,
                    null,
                    null,
                    null,
                    null,
                    workflowAnalyst,
                    workflowAnalystID,
                    companyAnalyst,
                    companyAnalystID,
                    emailDate,
                    emailFromAddress,
                    subjectLine,
                    null,
                    status,
                    certusFileID,
                    fileName,
                    fileURL,
                    fileSize,
                    fileMIME,
                    null
                );

                this.currentImportItems.Add(wi);
            }

            // if there is a LoadingForm, report progress
            if (WorkflowManager.CheckIfFormIsOpened("LoadingForm"))
            {
                if (Application.OpenForms[0].InvokeRequired) Application.OpenForms[0].Invoke(new Action(() =>
                {
                    (Application.OpenForms["LoadingForm"] as LoadingForm).ChangeLabel($"Saving item data...");
                    (Application.OpenForms["LoadingForm"] as LoadingForm).MoveBar(25);
                    (Application.OpenForms["LoadingForm"] as LoadingForm).Refresh();
                }));
                else
                {
                    (Application.OpenForms["LoadingForm"] as LoadingForm).ChangeLabel($"Saving item data...");
                    (Application.OpenForms["LoadingForm"] as LoadingForm).MoveBar(25);
                    (Application.OpenForms["LoadingForm"] as LoadingForm).Refresh();
                }
            }

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
                    updateList[indx].Note += $"<item added as completed/trash via DB Import {ImportDate.ToShortDateString()} > ";
                }
                else
                {
                    updateList[indx].Note += $"<added via DB Import {ImportDate.ToShortDateString()}> ";
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
        // return methods
        public DBImport ReturnDBImport()
        {
            DBImport i = new DBImport();

            i.ImportDate = this.ImportDate;
            i.ImportName = this.ImportName;
            i.ImportType = this.ImportType;
            i.ItemsAdded = this.ItemsAdded;
            i.TotalItemsOnImport = this.TotalItemsOnImport;

            return i;
        }
        public List<WorkflowItem> ReturnWorkflowItems()
        {
            return this.currentImportItems;
        }
        public override string ToString()
        {
            return $"{this.ImportType} - {this.ImportDate}";
        }
    }
}
