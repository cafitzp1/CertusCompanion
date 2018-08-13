using System;

namespace CertusCompanion
{
    [Serializable]
    internal class AppData
    {
        #region AppData Data
        public WorkflowItemDatabase WorkflowItemDatabase { get; set; }
        internal ItemImports ItemImportsList { get; set; }
        internal ItemsCompletedReports ItemsCompletedReportsList { get; set; }
        internal AppSave AppSave { get; set; }
        #endregion

        //
        // Constructors
        public AppData()
        {

        }
        public AppData(WorkflowItemDatabase workflowItemDatabase, ItemImports itemImportsList, ItemsCompletedReports itemsCompletedReportsList)
        {
            this.WorkflowItemDatabase = workflowItemDatabase;
            this.ItemImportsList = itemImportsList;
            this.ItemsCompletedReportsList = itemsCompletedReportsList;
        }
        //
        // Return data
        private void Save(string fileName)
        {
            string saveName = fileName;

            this.AppSave = new AppSave();
            this.AppSave.AddSave(this);
            this.AppSave.Save(fileName);
        }
    }
}
