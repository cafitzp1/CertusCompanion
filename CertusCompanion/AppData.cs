using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertusCompanion
{
    [Serializable]
    internal class AppData
    {
        private WorkflowItemDatabase workflowItemDatabase;
        private ItemImports itemImportsList;
        private ItemsCompletedReports itemsCompletedReportsList;
        private AppSave appSave;

        public WorkflowItemDatabase WorkflowItemDatabase { get => workflowItemDatabase; set => workflowItemDatabase = value; }
        internal ItemImports ItemImportsList { get => itemImportsList; set => itemImportsList = value; }
        internal ItemsCompletedReports ItemsCompletedReportsList { get => itemsCompletedReportsList; set => itemsCompletedReportsList = value; }
        internal AppSave AppSave { get => appSave; set => appSave = value; }

        public AppData()
        {

        }

        // constructor for loading data
        //public AppData(WorkflowItemDatabase workflowItemDatabase, WorkflowItemDatabase backupWorkflowItemDatabase,
        //    ItemImports itemImportsList, ItemsCompletedReports itemsCompletedReportsList)

        public AppData(WorkflowItemDatabase workflowItemDatabase,
            ItemImports itemImportsList, ItemsCompletedReports itemsCompletedReportsList)
        {
            this.WorkflowItemDatabase = workflowItemDatabase;
            this.ItemImportsList = itemImportsList;
            this.ItemsCompletedReportsList = itemsCompletedReportsList;
        }

        // constructor for saving data
        //public AppData(WorkflowItemDatabase workflowItemDatabase,
        //    ItemImports itemImportsList, ItemsCompletedReports itemsCompletedReportsList)
        //{
        //    this.BackupWorkflowItemDatabase = this.WorkflowItemDatabase; // if there's already a db loaded, the loaded one should be saved as the backup database
        //    this.WorkflowItemDatabase = workflowItemDatabase;
        //    this.ItemImportsList = itemImportsList;
        //    this.ItemsCompletedReportsList = itemsCompletedReportsList;
        //}

        // save  method

        private void Save(string fileName)
        {
            string saveName = fileName;

            this.AppSave = new AppSave();
            this.AppSave.AddSave(this);
            this.AppSave.Save(fileName);
        }
    }
}
