using System;
using System.Collections.Generic;

namespace CertusCompanion
{
    [Serializable]
    class Import
    {
        //
        // data
        public DateTime ImportDate { get; set; }
        public string ImportName { get; set; } 
        public string ImportType { get; set; }
        public List<string> ItemsAdded { get; set; }
        public List<string> ItemsUpdated { get; set; }

        //
        // default constructor
        public Import()
        {

        }
    }
}
