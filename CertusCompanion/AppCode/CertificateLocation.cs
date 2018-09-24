using System;

namespace CertusCompanion
{
    [Serializable]
    public class CertificateLocation : IEquatable<CertificateLocation>, IComparable<CertificateLocation>
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
        // interfaces
        public bool Equals(CertificateLocation other)
        {
            if (other == null) return false;
            return (this.CertificateLocationID.Equals(other.CertificateLocationID)); // object id
        }
        public int CompareTo(CertificateLocation other)
        {
            if (other == null) return 1;
            else return this.CertificateID.CompareTo(other.CertificateID); // attribute to compare
        }

        //
        // overrides
        public override int GetHashCode()
        {
            return Convert.ToInt32(CertificateLocationID); // object id
        }
        public override string ToString()
        {
            return $"{CertificateLocationID}\t<{CertificateID}>\t<{LocationID}>";
        }
    }
}