using System;

namespace CertusCompanion
{
    [Serializable]
    public class Location
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
        // methods
        public override string ToString()
        {
            return $"{Name} <{LocationID}>";
        }
    }
}