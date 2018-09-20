using System;

namespace CertusCompanion
{
    [Serializable]
    public class Contact : IEquatable<Contact>, IComparable<Contact>
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
        // interfaces
        public bool Equals(Contact other)
        {
            if (other == null) return false;
            return (this.ContactID.Equals(other.ContactID)); // object id
        }
        public int CompareTo(Contact other)
        {
            if (other == null) return 1;
            else return this.Name.CompareTo(other.Name); // attribute to compare
        }

        //
        // overrides
        public override int GetHashCode()
        {
            return Convert.ToInt32(ContactID); // object id
        }
        public override string ToString()
        {
            return $"{Name} - {Title} <{ContactID}>";
        }
    }
}
