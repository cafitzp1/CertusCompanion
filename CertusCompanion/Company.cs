using System;
using System.Collections.Generic;

namespace CertusCompanion
{
    [Serializable]
    public class Company
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
        public string CompanyLastNoteDate { get; set; }
        internal List<Contact> Contacts { get; set; }
        #endregion

        //
        // constructors
        public Company()
        {

        }
        public Company(string companyName, string bcsCompanyID, string clientID)
        {
            CompanyName = companyName;
            BcsCompanyID = bcsCompanyID;
            ClientID = clientID;
        }
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
            CompanyLastNoteDate = companyLastNoteDate;
            //MainContact = mainContact;
            Contacts = contacts;
        }

        //
        // return data
        public override string ToString()
        {
            return $"{CompanyName} <{BcsCompanyID}>";
        }
    }
}
