using System;
using System.Collections.Generic;
using System.Linq;

namespace CertusCompanion
{
    [Serializable]
    class ItemImports
    {
        //
        // data
        internal List<CSVImport> ItemImportsList { get; set; }
        internal CSVImport ItemImportBeingAdded { get; set; }
        internal List<CSVImport> ItemImportListBeingAdded { get; set; }

        //
        // constructors
        public ItemImports()
        {
            this.ItemImportsList = new List<CSVImport>();
            //this.ItemImportBeingAdded = new ItemImport();
            //this.ItemImportListBeingAdded = new List<ItemImport>();
        }
        public ItemImports(List<CSVImport> itemImportsList)
        {
            this.ItemImportsList = itemImportsList;
            //this.ItemImportBeingAdded = new ItemImport();
            //this.ItemImportListBeingAdded = new List<ItemImport>();
        }
        //
        // methods
        public void AddImport(CSVImport itemImportToAdd)
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
        public void AddImportList(List<CSVImport> itemImportListToAdd)
        {
            this.ItemImportListBeingAdded = itemImportListToAdd;

            foreach (CSVImport import in ItemImportListBeingAdded)
            {
                this.AddImport(import);
            }
        }
        public List<CSVImport> ReturnAllImports()
        {
            List<CSVImport> imports = new List<CSVImport>();

            foreach (CSVImport import in ItemImportsList)
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
