using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CertusCompanion
{
    public delegate void FilterEventHandler(object sender, Filter filter);

    public partial class FiltersForm : Form
    {
        public event FilterEventHandler SaveFilter;

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

        public FiltersForm()
        {
            InitializeComponent();
        }

        public FiltersForm(Filter filter)
        {
            InitializeComponent();

            this.currentFilter = filter;
        }

        public void Populate()
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
            this.queriedComboBox.Text = currentFilter.QueriedSelection;
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
            this.queriedSelection = this.queriedComboBox.Text;
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
            this.queriedComboBox.SelectedIndex = -1;
            this.companyTbx.Text = "";
            this.senderEmailTbx.Text = "";
            this.subjectTbx.Text = ""; //
            this.startDateTimePicker.Value = DateTime.Now;
            this.endDateTimePicker.Value = DateTime.Now;
        }
    }
}
