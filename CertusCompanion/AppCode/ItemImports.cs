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
        internal List<Import> ItemImportsList { get; set; }
        internal Import ItemImportBeingAdded { get; set; }
        internal List<Import> ItemImportListBeingAdded { get; set; }

        //
        // constructors
        public ItemImports()
        {
            this.ItemImportsList = new List<Import>();
            //this.ItemImportBeingAdded = new ItemImport();
            //this.ItemImportListBeingAdded = new List<ItemImport>();
        }
        public ItemImports(List<Import> itemImportsList)
        {
            this.ItemImportsList = itemImportsList;
            //this.ItemImportBeingAdded = new ItemImport();
            //this.ItemImportListBeingAdded = new List<ItemImport>();
        }

        //
        // methods
        public void AddImport(Import itemImportToAdd)
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
        public void AddImportList(List<Import> itemImportListToAdd)
        {
            this.ItemImportListBeingAdded = itemImportListToAdd;

            foreach (Import import in ItemImportListBeingAdded)
            {
                this.AddImport(import);
            }
        }
        public List<Import> ReturnAllImports()
        {
            List<Import> imports = new List<Import>();

            foreach (Import import in ItemImportsList)
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
