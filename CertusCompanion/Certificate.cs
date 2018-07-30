using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertusCompanion
{
    [Serializable]
    public class Certificate
    {
        string bcsCertificateID;
        string certificateName;
        string companyName = "";
        string bcsCompanyID;
        string insReqCategory = "";
        DateTime? issueDate;
        DateTime? nextPolicyExpirationDate;
        bool? certificateActive;
        bool? certificateCompliant;
        string backToClientStatus = "";
        string buildings = "";
        DateTime? lastNoteDate;
        string client = "";
        string market = "";
        string serviceType = "";

        public string BcsCertificateID { get => bcsCertificateID; set => bcsCertificateID = value; }
        public string CertificateName { get => certificateName; set => certificateName = value; }
        public string CompanyName { get => companyName; set => companyName = value; }
        public string BcsCompanyID { get => bcsCompanyID; set => bcsCompanyID = value; }
        public string InsReqCategory { get => insReqCategory; set => insReqCategory = value; }
        public DateTime? IssueDate { get => issueDate; set => issueDate = value; }
        public DateTime? NextPolicyExpirationDate { get => nextPolicyExpirationDate; set => nextPolicyExpirationDate = value; }
        public bool? CertificateActive { get => certificateActive; set => certificateActive = value; }
        public bool? CertificateCompliant { get => certificateCompliant; set => certificateCompliant = value; }
        public string BackToClientStatus { get => backToClientStatus; set => backToClientStatus = value; }
        public string Buildings { get => buildings; set => buildings = value; }
        public DateTime? LastNoteDate { get => lastNoteDate; set => lastNoteDate = value; }
        public string Client { get => client; set => client = value; }
        public string Market { get => market; set => market = value; }
        public string ServiceType { get => serviceType; set => serviceType = value; }

        public Certificate()
        {

        }

        public Certificate(string certificateName)
        {
            CertificateName = certificateName;
        }

        public Certificate(string bcsCertificateID, string certificateName, string companyName, string bcsCompanyID, string insReqCategory, DateTime? issueDate, DateTime? nextPolicyExpirationDate, bool? certificateActive, bool? certificateCompliant, string backToClientStatus, string buildings, DateTime? lastNoteDate, string client, string market, string serviceType)
        {
            BcsCertificateID = bcsCertificateID;
            CertificateName = certificateName;
            CompanyName = companyName;
            BcsCompanyID = bcsCompanyID;
            InsReqCategory = insReqCategory;
            IssueDate = issueDate;
            NextPolicyExpirationDate = nextPolicyExpirationDate;
            CertificateActive = certificateActive;
            CertificateCompliant = certificateCompliant;
            BackToClientStatus = backToClientStatus;
            Buildings = buildings;
            LastNoteDate = lastNoteDate;
            Client = client;
            Market = market;
            ServiceType = serviceType;
        }

        public override string ToString()
        {
            if (CompanyName != String.Empty & InsReqCategory != String.Empty && CertificateCompliant != null)
                return $"{CertificateName} - {CompanyName} - {InsReqCategory} - {CertificateCompliant}";
            else if (CompanyName != String.Empty)
                return $"{CertificateName} - {CompanyName}";
            else
                return CertificateName;
        }
    }
}
