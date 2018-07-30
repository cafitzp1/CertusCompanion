using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertusCompanion
{
    public class Filter
    {
        // data
        bool colorCheckChoice;
        bool analystCheckChoice;
        bool statusCheckChoice;
        bool queriedCheckChoice;
        bool companyCheckChoice;
        bool senderCheckChoice;
        bool subjectCheckChoice; //
        bool dateCheckChoice;
        string colorSelection;
        string analystSelection;
        string statusSelection;
        string queriedSelection;
        string companySelection;
        string senderSelection;
        string subjectSelection; //
        DateTime startDate;
        DateTime endDate;
        Filter currentFilter;

        // properties
        public bool ColorCheckChoice { get => colorCheckChoice; set => colorCheckChoice = value; }
        public bool AnalystCheckChoice { get => analystCheckChoice; set => analystCheckChoice = value; }
        public bool StatusCheckChoice { get => statusCheckChoice; set => statusCheckChoice = value; }
        public bool QueriedCheckChoice { get => queriedCheckChoice; set => queriedCheckChoice = value; }
        public bool CompanyCheckChoice { get => companyCheckChoice; set => companyCheckChoice = value; }
        public bool SenderCheckChoice { get => senderCheckChoice; set => senderCheckChoice = value; }
        public bool SubjectCheckChoice { get => subjectCheckChoice; set => subjectCheckChoice = value; } //
        public bool DateCheckChoice { get => dateCheckChoice; set => dateCheckChoice = value; }
        public string ColorSelection { get => colorSelection; set => colorSelection = value; }
        public string AnalystSelection { get => analystSelection; set => analystSelection = value; }
        public string StatusSelection { get => statusSelection; set => statusSelection = value; }
        public string QueriedSelection { get => queriedSelection; set => queriedSelection = value; }
        public string CompanySelection { get => companySelection; set => companySelection = value; }
        public string SenderSelection { get => senderSelection; set => senderSelection = value; }
        public string SubjectSelection { get => subjectSelection; set => subjectSelection = value; } //
        public DateTime StartDate { get => startDate; set => startDate = value; }
        public DateTime EndDate { get => endDate; set => endDate = value; }
        internal Filter CurrentFilter { get => currentFilter; set => currentFilter = value; }


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

        // methods
        public void ResetFilter()
        {
            this.CurrentFilter = new Filter();
        }

        public void SaveFilter(
            bool colorCheckChoice, bool analystCheckChoice, bool statusCheckChoice,
            bool queriedCheckChoice, bool companyCheckChoice, bool senderCheckChoice, bool subjectCheckChoice,
            bool dateCheckChoice, string colorSelection, string analystSelection,
            string statusSelection, string queriedSelection, string companySelection,
            string senderSelection, string subjectSelection, DateTime startDate, DateTime endDate)
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
