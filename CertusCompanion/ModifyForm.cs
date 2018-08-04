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
    public partial class ModifyForm : Form
    {
        #region Data Instantiation
        public string SelectedCompany { get; set; }
        public string SelectedContract { get; set; }
        public string SelectedAssignment { get; set; }
        public string SelectedStatus { get; set; }
        public string Note { get; set; }
        public bool AppendNote { get; set; }
        #endregion

        public ModifyForm()
        {
            InitializeComponent();

            // code to appear in the center of the form
            int x = Application.OpenForms[0].Location.X + (Application.OpenForms[0].Bounds.Width / 2 - this.Width / 2);
            int y = Application.OpenForms[0].Location.Y + (Application.OpenForms[0].Bounds.Height / 2 - this.Height / 2);
            this.Location = new Point(x, y);

            this.ShowInTaskbar = false;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            this.SelectedCompany = this.companyComboBox.Text;
            this.SelectedContract = this.contractComboBox.Text;
            this.SelectedAssignment = this.assignmentComboBox.Text;
            this.SelectedStatus = this.statusComboBox.Text;
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
