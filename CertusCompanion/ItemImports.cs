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
        private List<ItemImport> itemImportsList;
        private ItemImport itemImportBeingAdded;
        private List<ItemImport> itemImportListBeingAdded;

        internal List<ItemImport> ItemImportsList { get => itemImportsList; set => itemImportsList = value; }
        internal ItemImport ItemImportBeingAdded { get => itemImportBeingAdded; set => itemImportBeingAdded = value; }
        internal List<ItemImport> ItemImportListBeingAdded { get => itemImportListBeingAdded; set => itemImportListBeingAdded = value; }

        // constructors
        public ItemImports()
        {
            this.ItemImportsList = new List<ItemImport>();
            //this.ItemImportBeingAdded = new ItemImport();
            //this.ItemImportListBeingAdded = new List<ItemImport>();
        }

        public ItemImports(List<ItemImport> itemImportsList)
        {
            this.ItemImportsList = itemImportsList;
            //this.ItemImportBeingAdded = new ItemImport();
            //this.ItemImportListBeingAdded = new List<ItemImport>();
        }

        // methods
        public void AddImport(ItemImport itemImportToAdd)
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

        public void AddImportList(List<ItemImport> itemImportListToAdd)
        {
            this.ItemImportListBeingAdded = itemImportListToAdd;

            foreach (ItemImport import in ItemImportListBeingAdded)
            {
                this.AddImport(import);
            }
        }

        public List<ItemImport> ReturnAllImports()
        {
            List<ItemImport> imports = new List<ItemImport>();

            foreach (ItemImport import in ItemImportsList)
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
