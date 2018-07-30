using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertusCompanion
{
    [Serializable]
    public class ItemsCompletedReport
    {
        // data
        DateTime date;
        string itemListDetails;
        string statusChangedTo;
        List<WorkflowItem> workflowItems;

        // properties
        public DateTime Date { get => date; set => date = value; }
        public string ItemListDetails { get => itemListDetails; set => itemListDetails = value; }
        public string StatusChangedTo { get => statusChangedTo; set => statusChangedTo = value; }
        public List<WorkflowItem> WorkflowItems { get => workflowItems; set => workflowItems = value; }

        // constructors
        public ItemsCompletedReport()
        {
            this.Date = new DateTime();
            this.ItemListDetails = "";
            this.StatusChangedTo = "";
            this.WorkflowItems = new List<WorkflowItem>();
        }

        public ItemsCompletedReport(DateTime date, string itemListDetails, string statusChangedTo, List<WorkflowItem> workflowItems)
        {
            this.Date = date;
            this.ItemListDetails = itemListDetails;
            this.StatusChangedTo = statusChangedTo;
            this.WorkflowItems = workflowItems;
        }

        // method for Completing on Certus
        // ...
        public void Complete()
        {
            
        }

        // to string
        public override string ToString()
        {
            return $"{Date.ToString()} - {WorkflowItems.Count().ToString()} - {StatusChangedTo}";
        }
    }
}
