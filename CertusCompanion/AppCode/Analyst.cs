using System;

namespace CertusCompanion
{
    [Serializable]
    public class Analyst : IEquatable<Analyst>, IComparable<Analyst>
    {
        #region Analyst Data
        public string SystemUserID { get; set; }
        public string ClientID { get; set; }
        public string Name { get; set; }
        #endregion
        
        //
        // constructors
        public Analyst()
        {

        }
        public Analyst(string systemUserID, string clientID, string name)
        {
            SystemUserID = systemUserID;
            ClientID = clientID;
            Name = name;
        }
        
        //
        // interfaces
        public bool Equals(Analyst other)
        {
            if (other == null) return false;
            return (this.SystemUserID.Equals(other.SystemUserID)); // object id
        }
        public int CompareTo(Analyst other)
        {
            if (other == null) return 1;
            else return this.Name.CompareTo(other.Name); // attribute to compare
        }
        
        //
        // overrides
        public override int GetHashCode()
        {
            return Convert.ToInt32(SystemUserID); // object id
        }
        public override string ToString()
        {
            return $"{Name} <{SystemUserID}>";
        }
    }
}