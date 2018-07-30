using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertusCompanion
{
    [Serializable]
    public class Company
    {
        string companyName;
        string bcsCompanyID;
        string vendorID = "";
        string dba = "";
        string address1 = "";
        string address2 = "";
        string city = "";
        string state = "";
        string zip = "";
        string country = "";
        string phone = "";
        string emailAddress = "";
        bool? companyActive;
        string companyComplianceLevel = "";
        string analyst = "";
        string companyLastNoteDate = "";
        //Contact mainContact;
        List<Contact> contacts;

        public string CompanyName { get => companyName; set => companyName = value; }
        public string BcsCompanyID { get => bcsCompanyID; set => bcsCompanyID = value; }
        public string VendorID { get => vendorID; set => vendorID = value; }
        public string DBA { get => dba; set => dba = value; }
        public string Address1 { get => address1; set => address1 = value; }
        public string Address2 { get => address2; set => address2 = value; }
        public string City { get => city; set => city = value; }
        public string State { get => state; set => state = value; }
        public string Zip { get => zip; set => zip = value; }
        public string Country { get => country; set => country = value; }
        public string Phone { get => phone; set => phone = value; }
        public string EmailAddress { get => emailAddress; set => emailAddress = value; }
        public bool? CompanyActive { get => companyActive; set => companyActive = value; }
        public string CompanyComplianceLevel { get => companyComplianceLevel; set => companyComplianceLevel = value; }
        public string Analyst { get => analyst; set => analyst = value; }
        public string CompanyLastNoteDate { get => companyLastNoteDate; set => companyLastNoteDate = value; }
        //internal Contact MainContact { get => mainContact; set => mainContact = value; }
        internal List<Contact> Contacts { get => contacts; set => contacts = value; }

        public Company()
        {

        }

        public Company(string companyName, string bcsCompanyID, string vendorID, string dba, string address1, 
            string address2, string city, string state, string zip, string country, string phone, string emailAddress, 
            bool? companyActive, string companyComplianceLevel, string analyst, string companyLastNoteDate, 
            List<Contact> contacts)
        {
            CompanyName = companyName;
            BcsCompanyID = bcsCompanyID;
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

        public override string ToString()
        {
            if (VendorID != String.Empty && CompanyComplianceLevel != String.Empty)
                return $"{CompanyName} - {VendorID} - {CompanyComplianceLevel}";
            else
                return CompanyName;
        }
    }
}
