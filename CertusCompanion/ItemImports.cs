using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertusCompanion
{
    [Serializable]
    class ItemImports
    {
        // data
        private List<WorkflowItemCSVImport> itemImportsList;
        private WorkflowItemCSVImport itemImportBeingAdded;
        private List<WorkflowItemCSVImport> itemImportListBeingAdded;

        internal List<WorkflowItemCSVImport> ItemImportsList { get => itemImportsList; set => itemImportsList = value; }
        internal WorkflowItemCSVImport ItemImportBeingAdded { get => itemImportBeingAdded; set => itemImportBeingAdded = value; }
        internal List<WorkflowItemCSVImport> ItemImportListBeingAdded { get => itemImportListBeingAdded; set => itemImportListBeingAdded = value; }

        // constructors
        public ItemImports()
        {
            this.ItemImportsList = new List<WorkflowItemCSVImport>();
            //this.ItemImportBeingAdded = new ItemImport();
            //this.ItemImportListBeingAdded = new List<ItemImport>();
        }

        public ItemImports(List<WorkflowItemCSVImport> itemImportsList)
        {
            this.ItemImportsList = itemImportsList;
            //this.ItemImportBeingAdded = new ItemImport();
            //this.ItemImportListBeingAdded = new List<ItemImport>();
        }

        // methods
        public void AddImport(WorkflowItemCSVImport itemImportToAdd)
        {
            this.ItemImportBeingAdded = itemImportToAdd;

            // check if it already exists. add if it doesn't
            if(!ItemImportsList.Contains(ItemImportBeingAdded))
            {
                ItemImportsList.Add(ItemImportBeingAdded);
            }
            else
            {
                //throw new ItemImportAlreadyAddedException("This import has already been added");
            }
        }

        public void AddImportList(List<WorkflowItemCSVImport> itemImportListToAdd)
        {
            this.ItemImportListBeingAdded = itemImportListToAdd;

            foreach (WorkflowItemCSVImport import in ItemImportListBeingAdded)
            {
                this.AddImport(import);
            }
        }

        public List<WorkflowItemCSVImport> ReturnAllImports()
        {
            List<WorkflowItemCSVImport> imports = new List<WorkflowItemCSVImport>();

            foreach (WorkflowItemCSVImport import in ItemImportsList)
            {
                imports.Add(import);
            }

            return imports;
        }

        public int CountOfImportsInList()
        {
            int count;

            count = this.ItemImportsList.Count();

            return count;
        }
    }
}
