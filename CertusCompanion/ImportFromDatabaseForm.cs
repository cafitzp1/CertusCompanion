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
    public partial class ImportFromDatabaseForm : Form
    {
        public string ClientSelection { get; set; }
        public string WorkflowItemsSelection { get; set; }
        public string CertificatesSelection { get; set; }
        public string CompaniesSelection { get; set; }
        public int WorkflowItemsAmount { get; set; }
        public int CertificatesAmount { get; set; }
        public int CompaniesAmount { get; set; }
        public bool AddAndUpdate { get; set; }

        public ImportFromDatabaseForm()
        {
            InitializeComponent();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            tickCountLbl1.Text = (trackBar1.Value * 5000).ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            tickCountLbl2.Text = (trackBar2.Value * 5000).ToString();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            tickCountLbl3.Text = (trackBar3.Value * 5000).ToString();
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            this.clientComboBox.SelectedIndex = -1;
            this.workflowItemsComboBox.SelectedIndex = -1;
            this.certificatesComboBox.SelectedIndex = -1;
            this.companiesComboBox.SelectedIndex = -1;
            this.trackBar1.Value = 0;
            this.trackBar2.Value = 0;
            this.trackBar3.Value = 0;
            this.tickCountLbl1.Text = "0";
            this.tickCountLbl2.Text = "0";
            this.tickCountLbl3.Text = "0";
        }

        private void importBtn_Click(object sender, EventArgs e)
        {
            /*
            if (clientComboBox.SelectedIndex < 0 || (workflowItemsComboBox.SelectedIndex < 0 &&
                certificatesComboBox.SelectedIndex < 0 && companiesComboBox.SelectedIndex < 0))
            {
                statusLbl.Visible = true;
                return;
            }

            ClientSelection = this.clientComboBox.SelectedItem.ToString();
            WorkflowItemsSelection = this.workflowItemsComboBox.SelectedItem.ToString();
            CertificatesSelection = this.certificatesComboBox.SelectedItem.ToString();
            CompaniesSelection = this.companiesComboBox.SelectedItem.ToString();
            WorkflowItemsAmount = Convert.ToInt32(this.tickCountLbl1);
            CertificatesAmount = Convert.ToInt32(this.tickCountLbl2);
            CompaniesAmount = Convert.ToInt32(this.tickCountLbl3);
            AddAndUpdate = addAndUpdateCheckBox.Checked;
            */

            this.DialogResult = DialogResult.OK;

            CloseForm();
        }

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
