using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertusCompanion
{
    [Serializable]
    public class Contact
    {
        string name;
        string title = "";
        string phone = "";
        string email = "";

        public string Name { get => name; set => name = value; }
        public string Title { get => title; set => title = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }

        public Contact()
        {

        }

        public Contact(string name, string title, string phone, string email)
        {
            Name = name;
            Title = title;
            Phone = phone;
            Email = email;
        }

        public override string ToString()
        {
            return $"{Name} - {Title} - {Email}";
        }
    }
}
