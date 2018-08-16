using System;

namespace CertusCompanion
{
    [Serializable]
    public class Analyst
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
        // methods
        public override string ToString()
        {
            return $"{Name} <{SystemUserID}>";
        }
    }
}