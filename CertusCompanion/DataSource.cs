using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertusCompanion
{
    [Serializable]
    public class DataSource
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? LastUpdated { get; set; }
        public List<object> Items { get; set; }
        public bool? Binded { get; set; }

        public DataSource()
        {
            Name = "";
            Type = "";
            DateCreated = DateTime.Now;
            LastUpdated = DateTime.Now;
            Items = new List<object>();
            Binded = null;
        }

        public DataSource(string name)
        {
            Name = name;
            Type = "";
            DateCreated = DateTime.Now;
            LastUpdated = DateTime.Now;
            Items = new List<object>();
            Binded = null;
        }

        public DataSource(string name, string type)
        {
            Name = name;
            Type = type;
            DateCreated = DateTime.Now;
            LastUpdated = DateTime.Now;
            Items = new List<object>();
            Binded = null;
        }

        public DataSource(string name, string type, bool? binded)
        {
            Name = name;
            Type = type;
            DateCreated = DateTime.Now;
            LastUpdated = DateTime.Now;
            Items = new List<object>();
            Binded = binded;
        }

        public DataSource(string name, string type, List<object> items, bool binded)
        {
            Name = name;
            Type = type;
            DateCreated = DateTime.Now;
            LastUpdated = DateTime.Now;
            Items = items;
            Binded = binded;
        }

        public DataSource(string name, string type, DateTime dateCreated, DateTime? lastUpdated, List<object> items, bool? binded)
        {
            Name = name;
            Type = type;
            DateCreated = DateTime.Now;
            LastUpdated = lastUpdated;
            Items = items;
            Binded = binded;
        }

        public override string ToString()
        {
            return $"{Type} - {Name}";
        }
    }
}
