using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertusCompanion
{
    [Serializable]
    public class Client : IEquatable<Client>, IComparable<Client>
    {
        public string ClientID { get; set; }
        public string Name { get; set; }

        //
        // constructors
        public Client()
        {

        }
        public Client(string clientID, string name)
        {
            ClientID = clientID;
            Name = name;
        }
        
        //
        // interfaces
        public bool Equals(Client other)
        {
            if (other == null) return false;
            return (this.ClientID.Equals(other.ClientID)); // object id
        }
        public int CompareTo(Client other)
        {
            if (other == null) return 1;
            else return this.Name.CompareTo(other.Name); // attribute to compare
        }

        //
        // overrides
        public override int GetHashCode()
        {
            return Convert.ToInt32(ClientID); // object id
        }
        public override string ToString()
        {
            return $"{Name} <{ClientID}>";
        }
    }
}