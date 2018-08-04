using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertusCompanion
{
    [Serializable]
    class Import
    {
        // data
        public DateTime importDate { get; set; }
        public string importType { get; set; } // CSV (WI, CT, CT) or DB
        public int totalItemsOnImport { get; set; }

        public Import()
        {

        }
    }
}
