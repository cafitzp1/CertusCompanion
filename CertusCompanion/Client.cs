using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertusCompanion
{
    [Serializable]
    public class Client
    {
        public string ClientID { get; set; }
        public string Name { get; set; }

        public Client()
        {

        }

        public Client(string clientID, string name)
        {
            ClientID = clientID;
            Name = name;
        }

        public override string ToString()
        {
            return $"{Name} <{ClientID}>";
        }
    }
}