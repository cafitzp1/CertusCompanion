using System;
using System.Collections.Generic;
using System.Linq;

namespace CertusCompanion
{
    [Serializable]
    class WorkflowItemDatabase
    {
        #region WorkflowItemDatabase Data
        private List<WorkflowItem> workflowItemDatabase;
        private WorkflowItem itemBeingAdded;
        private List<WorkflowItem> itemListBeingAdded;
        private bool updateDuplicateItems;
        #endregion

        //
        // constructors
        public WorkflowItemDatabase()
        {
            this.workflowItemDatabase = new List<WorkflowItem>();
            this.itemBeingAdded = new WorkflowItem();
            this.itemListBeingAdded = new List<WorkflowItem>();
        }
        public WorkflowItemDatabase(List<WorkflowItem> workflowItemDatabase)
        {
            this.workflowItemDatabase = workflowItemDatabase;
            //this.itemBeingAdded = new WorkflowItem();
            //this.itemListBeingAdded = new List<WorkflowItem>();
        }

        //
        // methods
        public void AddWorkflowItem(WorkflowItem itemToAdd, bool updateDuplicates)
        {
            this.itemBeingAdded = itemToAdd;
            this.updateDuplicateItems = updateDuplicates;

            // if the item exists in the database
            if (this.workflowItemDatabase.Exists(i => i.DocumentWorkflowItemID == itemBeingAdded.DocumentWorkflowItemID))
            {
                WorkflowItem existingItem = new WorkflowItem();
                var item = (this.workflowItemDatabase.First(i => i.DocumentWorkflowItemID == itemBeingAdded.DocumentWorkflowItemID));
                existingItem = item as WorkflowItem;

                // if user wants to add and update (if check box is not checked, item will not be added if there is one existing with the same id)
                if (updateDuplicateItems)
                {
                    // if the new item was updated
                    if (CheckIfItemWasUpdated(existingItem, itemBeingAdded))
                    {
                        // replace new with old
                        this.workflowItemDatabase[this.workflowItemDatabase.IndexOf(existingItem)] = itemBeingAdded;
                        return;
                    }
                }
            }
            else // item doesn't exist in the list so add it
            {
                workflowItemDatabase.Add(itemBeingAdded);
            }
        }
        public void AddWorkflowItemList(List<WorkflowItem> itemListToAdd, bool updateDuplicates)
        {
            this.itemListBeingAdded = itemListToAdd;

            if (workflowItemDatabase != null && workflowItemDatabase.Count > 0)
            {
                workflowItemDatabase.Clear();
            }

            foreach (WorkflowItem wi in itemListBeingAdded)
            {
                this.workflowItemDatabase.Add(wi);
            }

            itemListBeingAdded.Clear();

            // sort list by ID (case if older items get added after newer items)
            this.workflowItemDatabase = this.workflowItemDatabase.OrderBy(i => i.DocumentWorkflowItemID).ToList();
        }
        private bool CheckIfItemWasUpdated(WorkflowItem currentItemInDB, WorkflowItem importItem)
        {
            // if any data is not the same, item was changed. return true for check if item was updated 
            if (currentItemInDB.CertificateName != importItem.CertificateName || currentItemInDB.Active != importItem.Active ||
                currentItemInDB.Compliant != importItem.Compliant || currentItemInDB.NextExpirationDate != importItem.NextExpirationDate ||
                currentItemInDB.WorkflowAnalyst != importItem.WorkflowAnalyst || currentItemInDB.CompanyAnalyst != importItem.CompanyAnalyst ||
                currentItemInDB.Status != importItem.Status || currentItemInDB.FileSize != importItem.FileSize ||
                currentItemInDB.FileMIME != importItem.FileMIME || currentItemInDB.AssignedToName != importItem.AssignedToName)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void AddWorkflowItem(string documentWorkflowItemID, string CertificateID, string companyName, string companyID, string clientID, bool? active, bool? compliant, DateTime? issueDate, DateTime? nextExpirationDate, string workflowAnalyst, string workflowAnalystID, string companyAnalyst, string companyAnalystID, DateTime? emailDate, string emailFromAddress, string subjectLine, string emailBody, string status, string certusFileID, string fileName, string fileURL, string fileSize, string fileMime, bool? fileExtracted )
        {
            WorkflowItem wi = new WorkflowItem
                (
                    documentWorkflowItemID,
                    CertificateID,
                    companyName,
                    companyID,
                    clientID,
                    active,
                    compliant,
                    issueDate,
                    nextExpirationDate,
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
                    fileMime,
                    fileExtracted
                );

            workflowItemDatabase.Add(wi);
        }
        public void RemoveWorkflowItem(string id)
        {
            workflowItemDatabase.Remove(GetItemFromDatabase(id));
        }
        public void RemoveWorkflowItem(WorkflowItem item)
        {
            workflowItemDatabase.Remove(item);
        }
        public void RemoveAllWorkflowItems()
        {
            workflowItemDatabase.Clear();
        }
        public void Sort()
        {
            workflowItemDatabase = workflowItemDatabase.OrderBy(i => i.DocumentWorkflowItemID).ToList();
        }
        public int CountOfItemsInDB()
        {
            int count;

            count = this.workflowItemDatabase.Count();

            return count;
        }
        public bool CheckDatabaseForItem(string id)
        {
            if(this.workflowItemDatabase.Exists(i => i.DocumentWorkflowItemID == id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public WorkflowItem GetItemFromDatabase(string id)
        {
            WorkflowItem itemToReturn = new WorkflowItem();

            var query = from item in workflowItemDatabase
                        where item.DocumentWorkflowItemID == id
                        select item as WorkflowItem;

            foreach (var item in query)
            {
                itemToReturn = item;
            }

            return itemToReturn;
        }
        public List<string> GetAllIdsFromDatabase()
        {
            List<string> idsList = new List<string>();

            foreach (WorkflowItem item in workflowItemDatabase)
            {
                string id = "";

                id=item.DocumentWorkflowItemID;
            }

            return idsList;
        }
        public List<WorkflowItem> ReturnAllItemsFromDatabase()
        {
            List<WorkflowItem> items = new List<WorkflowItem>();

            foreach (WorkflowItem item in workflowItemDatabase)
            {
                items.Add(item);
            }

            return items;
        }
        public void UpdateItem(string id, WorkflowItem updateItem)
        {
            int index = workflowItemDatabase.FindIndex(i => i.DocumentWorkflowItemID == id);
            workflowItemDatabase[index] = updateItem;
        }
        public void ChangeItemStatus(string id, string status)
        {
            int index = workflowItemDatabase.FindIndex(i => i.DocumentWorkflowItemID == id);
            workflowItemDatabase[index].Status = status;
        }
        public void ChangeItemColor(string id, string color)
        {
            int index = workflowItemDatabase.FindIndex(i => i.DocumentWorkflowItemID == id);
            workflowItemDatabase[index].DisplayColor = color;
        }
    }
}
