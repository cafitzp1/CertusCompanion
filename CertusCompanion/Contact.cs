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
        #region Contact Data
        public string ContactID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public string CompanyID { get; set; }
        #endregion
        //
        // constructors
        public Contact()
        {
            ContactID = String.Empty;
            Name = String.Empty;
            Title = String.Empty;
            Email = String.Empty;
            CompanyID = String.Empty;
        }
        public Contact(string contactID, string name, string title, string email, string companyID)
        {
            ContactID = contactID;
            Name = name;
            Title = title;
            Email = email;
            CompanyID = companyID;
        }
        //
        // methods
        public override string ToString()
        {
            return $"{Name} <{ContactID}>";
        }
    }
}
