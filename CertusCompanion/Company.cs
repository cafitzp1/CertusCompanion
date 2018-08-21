using System;
using System.Collections.Generic;

namespace CertusCompanion
{
    [Serializable]
    public class Company : IEquatable<Company>, IComparable<Company>
    {
        #region Company Data
        public string CompanyName { get; set; }
        public string BcsCompanyID { get; set; }
        public string ClientID { get; set; }
        public string VendorID { get; set; }
        public string DBA { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string EmailAddress { get; set; }
        public bool? CompanyActive { get; set; }
        public string CompanyComplianceLevel { get; set; }
        public string Analyst { get; set; }
        public string AnalystID { get; set; }
        public string CompanyLastNoteDate { get; set; }
        internal List<Contact> Contacts { get; set; }
        #endregion

        //
        // blank constructor
        public Company()
        {

        }
        //
        // for constructing from the DB
        public Company(string companyName, string bcsCompanyID, string clientID, string anaystID, string city, string state)
        {
            CompanyName = companyName;
            BcsCompanyID = bcsCompanyID;
            ClientID = clientID;
            AnalystID = anaystID;
            City = city;
            State = state;
        }
        //
        // for constructing via CSV
        public Company(string companyName, string bcsCompanyID, string clientID, string vendorID, string dba, string address1, string address2, string city, string state, string zip, string country, string phone, string emailAddress, bool? companyActive, string companyComplianceLevel, string analyst, string companyLastNoteDate, List<Contact> contacts)
        {
            CompanyName = companyName;
            BcsCompanyID = bcsCompanyID;
            ClientID = clientID;
            VendorID = vendorID;
            DBA = dba;
            Address1 = address1;
            Address2 = address2;
            City = city;
            State = state;
            Zip = zip;
            Country = country;
            Phone = phone;
            EmailAddress = emailAddress;
            CompanyActive = companyActive;
            CompanyComplianceLevel = companyComplianceLevel;
            Analyst = analyst;
            AnalystID = null;
            CompanyLastNoteDate = companyLastNoteDate;
            //MainContact = mainContact;
            Contacts = contacts;
        }
        //
        // full constructor
        public Company(string companyName, string bcsCompanyID, string clientID, string vendorID, string dBA, string address1, string address2, string city, string state, string zip, string country, string phone, string emailAddress, bool? companyActive, string companyComplianceLevel, string analyst, string analystID, string companyLastNoteDate, List<Contact> contacts)
        {
            CompanyName = companyName;
            BcsCompanyID = bcsCompanyID;
            ClientID = clientID;
            VendorID = vendorID;
            DBA = dBA;
            Address1 = address1;
            Address2 = address2;
            City = city;
            State = state;
            Zip = zip;
            Country = country;
            Phone = phone;
            EmailAddress = emailAddress;
            CompanyActive = companyActive;
            CompanyComplianceLevel = companyComplianceLevel;
            Analyst = analyst;
            AnalystID = analystID;
            CompanyLastNoteDate = companyLastNoteDate;
            Contacts = contacts;
        }

        //
        // interfaces
        public bool Equals(Company other)
        {
            if (other == null) return false;
            return (this.BcsCompanyID.Equals(other.BcsCompanyID)); // object id
        }
        public int CompareTo(Company other)
        {
            if (other == null) return 1;
            else return this.CompanyName.CompareTo(other.CompanyName); // attribute to compare
        }

        //
        // overrides
        public override int GetHashCode()
        {
            return Convert.ToInt32(BcsCompanyID); // object id
        }
        public override string ToString()
        {
            return $"{CompanyName} <{BcsCompanyID}>";
        }
    }
}
