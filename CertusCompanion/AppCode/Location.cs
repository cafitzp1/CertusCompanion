using System;

namespace CertusCompanion
{
    [Serializable]
    public class Location : IEquatable<Location>, IComparable<Location>
    {
        #region Location Data
        public string LocationID { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        #endregion

        //
        // constructors
        public Location()
        {

        }
        public Location(string locationID, string name, string address1, string address2)
        {
            LocationID = locationID;
            Name = name;
            Address1 = address1;
            Address2 = address2;
        }

        //
        // interfaces
        public bool Equals(Location other)
        {
            if (other == null) return false;
            return (this.LocationID.Equals(other.LocationID)); // object id
        }
        public int CompareTo(Location other)
        {
            if (other == null) return 1;
            else return this.Name.CompareTo(other.Name); // attribute to compare
        }

        //
        // overrides
        public override int GetHashCode()
        {
            return Convert.ToInt32(LocationID); // object id
        }
        public override string ToString()
        {
            return $"{Name} <{LocationID}>";
        }
    }
}