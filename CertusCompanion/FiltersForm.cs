using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CertusCompanion
{
    public delegate void FilterEventHandler(object sender, Filter filter);

    public partial class FiltersForm : Form
    {
        public event FilterEventHandler SaveFilter;

        #region FiltersForm Data
        bool colorCheckChoice;
        bool analystCheckChoice;
        bool statusCheckChoice;
        bool queriedCheckChoice;
        bool companyCheckChoice;
        bool senderCheckChoice;
        bool subjectCheckChoice; 
        bool dateCheckChoice;
        string colorSelection;
        string analystSelection;
        string statusSelection;
        string queriedSelection;
        string companySelection;
        string senderSelection;
        string subjectSelection; 
        DateTime startDate;
        DateTime endDate;
        Filter currentFilter;
        List<string> colors;
        List<string> analysts;
        List<string> statuses;
        List<string> companies;
        HashSet<string> emails;
        #endregion

        //
        // constructors
        public FiltersForm(List<string> colors, List<string> analysts, List<string> statuses, List<string> companies, HashSet<string> emails)
        {
            InitializeComponent();

            this.colors = colors;
            this.analysts = analysts;
            this.statuses = statuses;
            this.companies = companies;
            this.emails = emails;

            //AnalystsSubSource.OrderBy(i => i.ToString());
            if(this.analysts!=null&&this.analysts.Count>0) this.analysts.Sort();

            PopulateSources();
        }
        public FiltersForm(Filter filter, List<string> colors, List<string> analysts, List<string> statuses, List<string> companies, HashSet<string> emails)
        {
            InitializeComponent();

            this.currentFilter = filter;
            this.colors = colors;
            this.analysts = analysts;
            this.statuses = statuses;
            this.companies = companies;
            this.emails = emails;

            if (this.analysts != null && this.analysts.Count > 0) this.analysts.Sort();

            PopulateSources();
        }
        //
        // methods
        private void FiltersForm_Load(object sender, EventArgs e)
        {
            this.startDateTimePicker.Value = DateTime.Now.Date.AddDays(-1);
        }
        private void PopulateSources()
        {
            // --- COLORS DDL --- //
            colorComboBox.Items.Clear();

            foreach (string i in colors)
            {
                colorComboBox.Items.Add(i);
            }

            colorComboBox.Items.Add("All Colors");
            colorComboBox.Items.Add("Active Colors");
            colorComboBox.Items.Add("Inactive Colors");

            // --- STATUSES DDL --- //
            statusComboBox.Items.Clear();

            foreach (string i in statuses)
            {
                statusComboBox.Items.Add(i);
            }
            
            statusComboBox.Items.Add("All");
            statusComboBox.Items.Add("Completed/Trash");
            statusComboBox.Items.Add("Current");


            // --- ANALYSTS DDL --- //
            analystComboBox.Items.Clear();

            if (analysts != null && analysts.Count != 0)
            {
                foreach (string i in analysts)
                {
                    analystComboBox.Items.Add(i);
                }

                analystComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
                analystComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            }

            // --- COMPANIES TBX --- //
            AutoCompleteStringCollection companyACS = new AutoCompleteStringCollection();

            if (companies != null && companies.Count != 0)
            {
                foreach (string i in companies)
                {
                    companyACS.Add(i);
                }

                companyTbx.AutoCompleteSource = AutoCompleteSource.CustomSource;
                companyTbx.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                companyTbx.AutoCompleteCustomSource = companyACS;
            }

            // --- EMAILS TBX --- //
            AutoCompleteStringCollection emailsACS = new AutoCompleteStringCollection();

            if (emails != null && emails.Count != 0)
            {
                foreach (string i in emails)
                {
                    emailsACS.Add(i);
                }

                senderEmailTbx.AutoCompleteSource = AutoCompleteSource.CustomSource;
                senderEmailTbx.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                senderEmailTbx.AutoCompleteCustomSource = emailsACS;
            }
        }
        public void PopulateCurrentFilter()
        {
            this.colorCheckBox.Checked = currentFilter.ColorCheckChoice;
            this.analystCheckBox.Checked = currentFilter.AnalystCheckChoice;
            this.statusCheckBox.Checked = currentFilter.StatusCheckChoice;
            this.queriedCheckBox.Checked = currentFilter.QueriedCheckChoice;
            this.companyCheckBox.Checked = currentFilter.CompanyCheckChoice;
            this.senderCheckBox.Checked = currentFilter.SenderCheckChoice;
            this.subjectCheckBox.Checked = currentFilter.SubjectCheckChoice; //
            this.dateCheckBox.Checked = currentFilter.DateCheckChoice;
            this.colorComboBox.Text = currentFilter.ColorSelection;
            this.analystComboBox.Text = currentFilter.AnalystSelection;
            this.statusComboBox.Text = currentFilter.StatusSelection;
            this.companyTbx.Text = currentFilter.CompanySelection;
            this.senderEmailTbx.Text = currentFilter.SenderSelection;
            this.subjectTbx.Text = currentFilter.SubjectSelection; //
            this.startDateTimePicker.Value = currentFilter.StartDate;
            this.endDateTimePicker.Value = currentFilter.EndDate;
        }
        private void Save()
        {
            this.colorCheckChoice = this.colorCheckBox.Checked;
            this.analystCheckChoice = this.analystCheckBox.Checked;
            this.statusCheckChoice = this.statusCheckBox.Checked;
            this.queriedCheckChoice = this.queriedCheckBox.Checked;
            this.companyCheckChoice = this.companyCheckBox.Checked;
            this.senderCheckChoice = this.senderCheckBox.Checked;
            this.subjectCheckChoice = this.subjectCheckBox.Checked; //
            this.dateCheckChoice = this.dateCheckBox.Checked;
            this.colorSelection = this.colorComboBox.Text;
            this.analystSelection = this.analystComboBox.Text;
            this.statusSelection = this.statusComboBox.Text;
            this.companySelection = this.companyTbx.Text;
            this.senderSelection = this.senderEmailTbx.Text;
            this.subjectSelection = this.subjectTbx.Text; //
            this.startDate = this.startDateTimePicker.Value;
            this.endDate = this.endDateTimePicker.Value;
        }
        private bool FieldCheck()
        {
            if (this.colorCheckBox.Checked == true && colorSelection==String.Empty)
            {
                this.statusLbl.Text = "You must select a color";
                statusLbl.Visible = true;
                return false;
            }
            else if (this.analystCheckBox.Checked == true && analystSelection == String.Empty)
            {
                this.statusLbl.Text = "You must select an analyst";
                statusLbl.Visible = true;
                return false;
            }
            else if (this.statusCheckBox.Checked == true && statusSelection == String.Empty)
            {
                this.statusLbl.Text = "You must select a status";
                statusLbl.Visible = true;
                return false;
            }
            else if (this.companyCheckBox.Checked == true && companySelection == String.Empty)
            {
                this.statusLbl.Text = "You must enter company data";
                statusLbl.Visible = true;
                return false;
            }
            else if (this.senderCheckBox.Checked == true && senderSelection == String.Empty)
            {
                this.statusLbl.Text = "You must enter a sender";
                statusLbl.Visible = true;
                return false;
            }
            else if (this.subjectCheckBox.Checked == true && subjectSelection == String.Empty) //
            {
                this.statusLbl.Text = "You must enter an email subject";
                statusLbl.Visible = true;
                return false;
            }
            else if (this.dateCheckBox.Checked == true && startDate.Ticks>endDate.Ticks)
            {
                this.statusLbl.Text = "Start date cannot be more recent than end date";
                statusLbl.Visible = true;
                return false;
            }
            else
            {
                return true;
            }
        }
        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // save form changes
                this.Save();

                // create filter
                currentFilter = new Filter();
                currentFilter.SaveFilter(
                    this.colorCheckChoice,
                    this.analystCheckChoice,
                    this.statusCheckChoice,
                    this.queriedCheckChoice,
                    this.companyCheckChoice,
                    this.senderCheckChoice,
                    this.subjectCheckChoice,
                    this.dateCheckChoice,
                    this.colorSelection,
                    this.analystSelection,
                    this.statusSelection,
                    this.queriedSelection,
                    this.companySelection,
                    this.senderSelection,
                    this.subjectSelection,
                    this.startDate,
                    this.endDate);

                // return if field check does not pass
                if (!FieldCheck())
                {
                    return;
                }

                // pass filter to full form
                if (SaveFilter != null)
                    SaveFilter(this, currentFilter);

                // close form
                this.Close();
                this.DialogResult = DialogResult.OK;
            }
            catch
            {
                statusLbl.Text = "Error saving filter.";
            }
        }
        private void clearBtn_Click(object sender, EventArgs e)
        {
            // clear data
            this.colorCheckBox.Checked = false;
            this.analystCheckBox.Checked = false;
            this.statusCheckBox.Checked = false;
            this.queriedCheckBox.Checked = false;
            this.companyCheckBox.Checked = false;
            this.senderCheckBox.Checked = false;
            this.subjectCheckBox.Checked = false; //
            this.dateCheckBox.Checked = false;
            this.colorComboBox.SelectedIndex = -1;
            this.analystComboBox.SelectedIndex = -1;
            this.statusComboBox.SelectedIndex = -1;
            this.companyTbx.Text = "";
            this.senderEmailTbx.Text = "";
            this.subjectTbx.Text = ""; //
            this.startDateTimePicker.Value = DateTime.Now;
            this.endDateTimePicker.Value = DateTime.Now;
        }

        #region Enable/Disable Tab Stops
        private void colorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.colorCheckBox.Checked) colorComboBox.TabStop = true;
            else colorComboBox.TabStop = false;
        }
        private void analystCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.analystCheckBox.Checked) analystComboBox.TabStop = true;
            else analystComboBox.TabStop = false;
        }
        private void dateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.dateCheckBox.Checked)
            {
                startDateTimePicker.TabStop = true;
                endDateTimePicker.TabStop = true;
            }
            else
            {
                startDateTimePicker.TabStop = true;
                endDateTimePicker.TabStop = true;
            }
        }
        private void subjectCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.subjectCheckBox.Checked) subjectTbx.TabStop = true;
            else subjectTbx.TabStop = false;
        }
        private void companyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.companyCheckBox.Checked) companyTbx.TabStop = true;
            else companyTbx.TabStop = false;
        }
        private void queriedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //
        }
        private void statusCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.statusCheckBox.Checked) statusComboBox.TabStop = true;
            else statusComboBox.TabStop = false;
        }
        private void senderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.senderCheckBox.Checked) senderEmailTbx.TabStop = true;
            else senderEmailTbx.TabStop = false;
        }
        #endregion
    }
}
