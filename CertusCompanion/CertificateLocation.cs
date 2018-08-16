using System;

namespace CertusCompanion
{
    [Serializable]
    public class CertificateLocation
    {
        #region CertificateLocation Data
        public string CertificateLocationID { get; set; }
        public string CertificateID { get; set; }
        public string LocationID { get; set; }
        public DateTime DateCreated { get; set; }
        #endregion
        //
        // constructors
        public CertificateLocation()
        {

        }
        public CertificateLocation(string certificateLocationID, string certificateID, string locationID, DateTime dateCreated)
        {
            CertificateLocationID = certificateLocationID;
            CertificateID = certificateID;
            LocationID = locationID;
            DateCreated = dateCreated;
        }
        //
        // methods
        public override string ToString()
        {
            return $"{CertificateLocationID}";
        }
    }
}