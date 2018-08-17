using System;

namespace CertusCompanion
{
    [Serializable]
    public class Certificate : IEquatable<Certificate>, IComparable<Certificate>
    {
        #region Certificate Data
        public string BcsCertificateID { get; set; }
        public string CertificateName { get; set; }
        public string CertificateIdentityField { get; set; }
        public string CompanyName { get; set; }
        public string BcsCompanyID { get; set; }
        public string ClientID { get; set; }
        public string InsReqCategory { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? NextPolicyExpirationDate { get; set; }
        public bool? CertificateActive { get; set; }
        public bool? CertificateCompliant { get; set; }
        public string BackToClientStatus { get; set; }
        public string Buildings { get; set; }
        public DateTime? LastNoteDate { get; set; }
        public string Source { get; set; }
        public string Market { get; set; }
        public string ServiceType { get; set; }
        #endregion
        //
        // constructors
        public Certificate()
        {
            CertificateIdentityField = String.Empty;
            CompanyName = String.Empty;
            BcsCompanyID = String.Empty;
            ClientID = String.Empty;
            InsReqCategory = String.Empty;
            IssueDate = null;
            NextPolicyExpirationDate = null;
            CertificateActive = null;
            CertificateCompliant = null;
            BackToClientStatus = String.Empty;
            Buildings = String.Empty;
            LastNoteDate = null;
            Source = String.Empty;
            Market = String.Empty;
            ServiceType = String.Empty;
        }
        public Certificate(string certificateName)
        {
            CertificateIdentityField = String.Empty;
            CertificateName = certificateName;
            BcsCompanyID = String.Empty;
            ClientID = String.Empty;
            InsReqCategory = String.Empty;
            IssueDate = null;
            NextPolicyExpirationDate = null;
            CertificateActive = null;
            CertificateCompliant = null;
            BackToClientStatus = String.Empty;
            Buildings = String.Empty;
            LastNoteDate = null;
            Source = String.Empty;
            Market = String.Empty;
            ServiceType = String.Empty;
        }
        public Certificate(string bcsCertificateID, string certificateName, string certificateIdentityField, string clientID)
        {
            BcsCertificateID = bcsCertificateID;
            CertificateName = certificateName;
            CertificateIdentityField = certificateIdentityField;
            CompanyName = String.Empty;
            BcsCompanyID = String.Empty;
            ClientID = clientID;
            InsReqCategory = String.Empty;
            IssueDate = null;
            NextPolicyExpirationDate = null;
            CertificateActive = null;
            CertificateCompliant = null;
            BackToClientStatus = String.Empty;
            Buildings = String.Empty;
            LastNoteDate = null;
            Source = String.Empty;
            Market = String.Empty;
            ServiceType = String.Empty;
        }
        public Certificate(string bcsCertificateID, string certificateName, string certificateIdentityField, string companyName, string bcsCompanyID, string clientID, string insReqCategory, DateTime? issueDate, DateTime? nextPolicyExpirationDate, bool? certificateActive, bool? certificateCompliant, string backToClientStatus, string buildings, DateTime? lastNoteDate, string source, string market, string serviceType)
        {
            BcsCertificateID = bcsCertificateID;
            CertificateName = certificateName;
            CertificateIdentityField = certificateIdentityField;
            CompanyName = companyName;
            BcsCompanyID = bcsCompanyID;
            ClientID = clientID;
            InsReqCategory = insReqCategory;
            IssueDate = issueDate;
            NextPolicyExpirationDate = nextPolicyExpirationDate;
            CertificateActive = certificateActive;
            CertificateCompliant = certificateCompliant;
            BackToClientStatus = backToClientStatus;
            Buildings = buildings;
            LastNoteDate = lastNoteDate;
            Source = source;
            Market = market;
            ServiceType = serviceType;
        }
        
        //
        // interfaces
        public bool Equals(Certificate other)
        {
            if (other == null) return false;
            return (this.BcsCertificateID.Equals(other.BcsCertificateID)); // object id
        }
        public int CompareTo(Certificate other)
        {
            if (other == null) return 1;
            else return this.CertificateName.CompareTo(other.CertificateName); // attribute to compare
        }
        
        //
        // overrides
        public override int GetHashCode()
        {
            return Convert.ToInt32(BcsCertificateID); // object id
        }
        public override string ToString()
        {
            return $"{CertificateName} <{BcsCertificateID}> : {CertificateIdentityField}";
        }
    }
}
