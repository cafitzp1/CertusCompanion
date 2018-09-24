using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace CertusCompanion
{
    public partial class ModifyForm : Form
    {
        #region ModifyForm Data
        public string SelectedCompany { get; set; }
        public string SelectedCertificate { get; set; }
        public string SelectedAssignment { get; set; }
        public string SelectedAssignmentID { get; set; }
        public string SelectedStatus { get; set; }
        public string Note { get; set; }
        public bool AppendNote { get; set; }
        private List<Analyst> analystList;
        private HashSet<string> analystNames;
        private bool enterIDManuallyActive;
        #endregion

        //
        // constructor for no data sources
        public ModifyForm()
        {
            InitializeComponent();
        }
        //
        // constructor for data sources
        public ModifyForm(List<Company> companiesDS, List<Certificate> CertificatesDS, List<Analyst> analysts, List<string> statuses)
        {
            InitializeComponent();

            AutoCompleteStringCollection companiesCll = new AutoCompleteStringCollection();
            AutoCompleteStringCollection CertificatesCll = new AutoCompleteStringCollection();
            AutoCompleteStringCollection assignmentsCll = new AutoCompleteStringCollection();
            AutoCompleteStringCollection statusesCll = new AutoCompleteStringCollection();

            // --- COMPANIES --- //
            List<string> companies = companiesDS.Select(i => i.CompanyName).ToList();
            if (companies != null && companies.Count != 0)
            {
                foreach (string item in companies)
                {
                    companiesCll.Add(item);
                }
            }

            // --- CertificateS --- //
            List<string> Certificates = CertificatesDS.Select(i => i.CertificateName).ToList();
            if (Certificates != null && Certificates.Count != 0)
            {
                foreach (string item in Certificates)
                {
                    CertificatesCll.Add(item);
                }
            }

            // --- ANALYSTS --- //
            if (analysts != null && analysts.Count != 0)
            {
                analystList = analysts;
                analysts.Sort();
                anDDLComboBox.Items.Clear();
                anDDLComboBox.Items.Add("");
                List<string> anNames = analysts.Select(i => i.Name).ToList();
                analystNames = new HashSet<string>();
                analystNames.UnionWith(anNames);
                foreach (string item in analystNames)
                {
                    assignmentsCll.Add(item);
                    anDDLComboBox.Items.Add(item);
                }
            }

            // --- STATUSES --- //
            stDDLComboBox.Items.Clear();
            stDDLComboBox.Items.Add("");
            foreach (string item in statuses)
            {
                statusesCll.Add(item);
                stDDLComboBox.Items.Add(item);
            }

            coTbx.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            coTbx.AutoCompleteCustomSource = companiesCll;
            coTbx.AutoCompleteSource = AutoCompleteSource.CustomSource;
            ctTbx.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            ctTbx.AutoCompleteCustomSource = CertificatesCll;
            ctTbx.AutoCompleteSource = AutoCompleteSource.CustomSource;

            // code to appear in the center of the form
            int x = Application.OpenForms[0].Location.X + (Application.OpenForms[0].Bounds.Width / 2 - this.Width / 2);
            int y = Application.OpenForms[0].Location.Y + (Application.OpenForms[0].Bounds.Height / 2 - this.Height / 2);
            this.Location = new Point(x, y);

            this.ShowInTaskbar = false;
        }
        private void ModifyForm_Load(object sender, EventArgs e)
        {
            this.cancelBtn.Focus();
        }

        //
        // form functionality
        private void anTbx_TextChanged(object sender, EventArgs e)
        {
            if (analystNames == null || analystNames.Count == 0) return;
            if (analystNames.Contains(anTbx.Text) && !this.enterIDManuallyActive)
            {
                analystIDTbx.Text = (analystList.Where(i => i.Name == anTbx.Text).FirstOrDefault() as Analyst).SystemUserID;
            }
            else analystIDTbx.Text = "NULL";
        }
        private void enterIDManuallyBtn_Click(object sender, EventArgs e)
        {
            if (!enterIDManuallyActive)
            {
                enterIDManuallyActive = true;
                analystIDTbx.BackColor = Color.FromArgb(20, 20, 20);
                enterIDManuallyBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(20, 20, 20);
                enterIDManuallyBtn.BackColor = Color.FromArgb(20, 20, 20);
                analystIDTbx.ReadOnly = false;
                analystIDTbx.Focus();
                analystIDTbx.SelectAll();
            }
            else
            {
                enterIDManuallyActive = false;
                analystIDTbx.BackColor = Color.FromArgb(27, 27, 27);
                enterIDManuallyBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(27, 27, 27);
                enterIDManuallyBtn.BackColor = Color.FromArgb(27, 27, 27);
                analystIDTbx.ReadOnly = true;
                anTbx_TextChanged(this, null);
            }
        }
        private void saveBtn_Click(object sender, EventArgs e)
        {
            this.SelectedCompany = this.coTbx.Text;
            this.SelectedCertificate = this.ctTbx.Text;
            this.SelectedAssignment = this.anTbx.Text;
            this.SelectedAssignmentID = this.analystIDTbx.Text;
            this.SelectedStatus = this.stTbx.Text;
            this.Note = this.noteTbx.Text;
            this.AppendNote = this.appendRadioButton.Checked;

            this.DialogResult = DialogResult.OK;

            CloseForm();
        }
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

            CloseForm();
        }
        private void tbxCmbxComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (Control c in (sender as ComboBox).Parent.Controls)
                {
                    if (c is TextBox) (c as TextBox).Text = (sender as ComboBox).SelectedItem.ToString();
                    else if (c is Panel)
                    {
                        foreach (Control cc in (c as Panel).Controls)
                        {
                            if (cc is TextBox) (cc as TextBox).Text = (sender as ComboBox).SelectedItem.ToString();
                            else if (cc is Panel)
                            {
                                foreach (Control ccc in (cc as Panel).Controls)
                                {
                                    if (ccc is TextBox) (ccc as TextBox).Text = (sender as ComboBox).SelectedItem.ToString();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception) { }
        }

        //
        // form behavior
        private void optionBtn_Enter(object sender, EventArgs e)
        {
            (sender as Button).FlatAppearance.BorderColor = Color.FromKnownColor(KnownColor.Highlight);
        }
        private void optionBtn_Leave(object sender, EventArgs e)
        {
            (sender as Button).FlatAppearance.BorderColor = Color.FromKnownColor(KnownColor.WindowFrame);
        }

        //
        // form accessibility
        private void CloseForm()
        {
            try
            {
                foreach (Form frm in Application.OpenForms)
                {
                    if (frm.Name == "Transparent Form")
                    {
                        Application.OpenForms["Transparent Form"].Close();
                        return;
                    }
                }
                this.Close();
            }
            catch (Exception) { }
        }
    }
}
