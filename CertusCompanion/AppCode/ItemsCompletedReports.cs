using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertusCompanion
{
    [Serializable]
    class ItemsCompletedReports
    {
        // data
        List<ItemsCompletedReport> itemsCompletedReportsList;
        ItemsCompletedReport itemsCompletedReportBeingAdded;
        List<ItemsCompletedReport> itemsCompletedReportListBeingAdded;

        internal List<ItemsCompletedReport> ItemsCompletedReportsList { get => itemsCompletedReportsList; set => itemsCompletedReportsList = value; }
        internal ItemsCompletedReport ItemsCompletedReportBeingAdded { get => itemsCompletedReportBeingAdded; set => itemsCompletedReportBeingAdded = value; }
        internal List<ItemsCompletedReport> ItemsCompletedReportListBeingAdded { get => itemsCompletedReportListBeingAdded; set => itemsCompletedReportListBeingAdded = value; }

        // constructors
        public ItemsCompletedReports()
        {
            this.ItemsCompletedReportsList = new List<ItemsCompletedReport>();
            //this.ItemsCompletedReportListBeingAdded = new List<ItemsCompletedReport>();
            //this.ItemsCompletedReportBeingAdded = new ItemsCompletedReport();
        }

        public ItemsCompletedReports(List<ItemsCompletedReport> itemsCompletedReportsList)
        {
            this.ItemsCompletedReportsList = itemsCompletedReportsList;
            //this.ItemsCompletedReportListBeingAdded = new List<ItemsCompletedReport>();
            //this.ItemsCompletedReportBeingAdded = new ItemsCompletedReport();
        }
        
        // methods
        public void AddItemsCompletedReport(ItemsCompletedReport itemsCompletedReportToAdd)
        {
            this.ItemsCompletedReportBeingAdded = itemsCompletedReportToAdd;

            // check if it already exists. add if it doesn't
            if (!ItemsCompletedReportsList.Contains(ItemsCompletedReportBeingAdded))
            {
                ItemsCompletedReportsList.Add(ItemsCompletedReportBeingAdded);
            }
            else
            {
                //throw new ItemsCompletedReportAlreadyAddedException("This report has already been added");
            }
        }

        public void AddItemsCompletedReportList(List<ItemsCompletedReport> itemsCompletedReportListToAdd)
        {
            this.ItemsCompletedReportListBeingAdded = itemsCompletedReportListToAdd;

            foreach (ItemsCompletedReport report in ItemsCompletedReportListBeingAdded)
            {
                this.AddItemsCompletedReport(report);
            }
        }

        public List<ItemsCompletedReport> ReturnAllReports()
        {
            List<ItemsCompletedReport> reports = new List<ItemsCompletedReport>();

            foreach (ItemsCompletedReport report in ItemsCompletedReportsList)
            {
                reports.Add(report);
            }

            return reports;
        }

        public int CountOfReportsInList()
        {
            int count;

            count = this.ItemsCompletedReportsList.Count();

            return count;
        }
    }
}