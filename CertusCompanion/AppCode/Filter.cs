using System;
using System.Linq;

namespace CertusCompanion
{
    public class Filter
    {
        //
        // properties
        public bool ColorCheckChoice { get; set; }
        public bool AnalystCheckChoice { get; set; }
        public bool StatusCheckChoice { get; set; }
        public bool QueriedCheckChoice { get; set; }
        public bool CompanyCheckChoice { get; set; }
        public bool SenderCheckChoice { get; set; }
        public bool SubjectCheckChoice { get; set; } //
        public bool DateCheckChoice { get; set; }
        public string ColorSelection { get; set; }
        public string AnalystSelection { get; set; }
        public string StatusSelection { get; set; }
        public string QueriedSelection { get; set; }
        public string CompanySelection { get; set; }
        public string SenderSelection { get; set; }
        public string SubjectSelection { get; set; } //
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        internal Filter CurrentFilter { get; set; }

        //
        // constructors
        public Filter()
        {
            this.ColorCheckChoice = false;
            this.AnalystCheckChoice = false;
            this.StatusCheckChoice = false;
            this.QueriedCheckChoice = false;
            this.CompanyCheckChoice = false;
            this.SenderCheckChoice = false;
            this.SubjectCheckChoice = false; //
            this.DateCheckChoice = false;
            this.ColorSelection = "";
            this.AnalystSelection = "";
            this.StatusSelection = "";
            this.QueriedSelection = "";
            this.CompanySelection = "";
            this.SenderSelection = "";
            this.SubjectSelection = ""; //
            this.StartDate = DateTime.Now;
            this.EndDate = DateTime.Now;
        }

        //
        // methods
        public void ResetFilter()
        {
            this.CurrentFilter = new Filter();
        }
        public void SaveFilter(bool colorCheckChoice, bool analystCheckChoice, bool statusCheckChoice, bool queriedCheckChoice, bool companyCheckChoice, bool senderCheckChoice, bool subjectCheckChoice, bool dateCheckChoice, string colorSelection, string analystSelection, string statusSelection, string queriedSelection, string companySelection, string senderSelection, string subjectSelection, DateTime startDate, DateTime endDate)
        {
            this.CurrentFilter = new Filter();

            this.ColorCheckChoice = colorCheckChoice;
            this.AnalystCheckChoice = analystCheckChoice;
            this.StatusCheckChoice = statusCheckChoice;
            this.QueriedCheckChoice = queriedCheckChoice;
            this.CompanyCheckChoice = companyCheckChoice;
            this.SenderCheckChoice = senderCheckChoice;
            this.SubjectCheckChoice = subjectCheckChoice; //
            this.DateCheckChoice = dateCheckChoice;
            this.ColorSelection = colorSelection;
            this.AnalystSelection = analystSelection;
            this.StatusSelection = statusSelection;
            this.QueriedSelection = queriedSelection;
            this.CompanySelection = companySelection;
            this.SenderSelection = senderSelection;
            this.SubjectSelection = subjectSelection; //
            this.StartDate = startDate;
            this.EndDate = endDate;
        }
        
        //
        // export
        public Filter ReturnFilter()
        {
            return this.CurrentFilter;
        }
        private string GenerateToString()
        {
            string s = "";

            if (this.ColorCheckChoice == true)
            {
                s += $"{ColorSelection}, ";
            }
            if (this.AnalystCheckChoice == true)
            {
                s += $"{AnalystSelection}, ";
            }
            if (this.StatusCheckChoice == true)
            {
                s += $"{StatusSelection}, ";
            }
            if (this.QueriedCheckChoice == true)
            {
                s += "Queried, ";
            }
            if (this.CompanyCheckChoice == true)
            {
                s += $"{CompanySelection}, ";
            }
            if (this.SenderCheckChoice == true)
            {
                s += $"{SenderSelection}, ";
            }
            if (this.SubjectCheckChoice == true) //
            {
                s += $"'{SubjectSelection}', ";
            }
            if (this.DateCheckChoice == true)
            {
                s += $"{StartDate.ToShortDateString()}-{EndDate.ToShortDateString()}, ";
            }

            // remove the comma and space
            if(s.Count()>1)
            {
                s = s.Substring(0,s.Count()-2);
            }

            return s;
        }
        public override string ToString()
        {
            return GenerateToString();
        }
    }
}
