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
    public partial class BrowserConfigForm : Form
    {
        #region BrowserConfiguration Data

        #endregion

        //
        // form startup
        public BrowserConfigForm()
        {
            InitializeComponent();
        }
        private void BrowserConfiguration_Load(object sender, EventArgs e)
        {
            // set values
            homePageTbx.Text = Properties.Settings.Default.HomePage;
            usernameTbx.Text = Properties.Settings.Default.Username;
            passwordTbx.Text = Properties.Settings.Default.Password;
            completeIDNumUpDown.Value = Properties.Settings.Default.CompleteID;
            distributeIDNumUpDown.Value = Properties.Settings.Default.DistributeID;
            customScript1Tbx.Text = Properties.Settings.Default.CustomScript1;
            customScript2Tbx.Text = Properties.Settings.Default.CustomScript2;
            customScript3Tbx.Text = Properties.Settings.Default.CustomScript3;
        }
        //
        // form functionality
        private void saveBtn_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.HomePage = homePageTbx.Text;
            Properties.Settings.Default.Username = usernameTbx.Text;
            Properties.Settings.Default.Password = passwordTbx.Text;
            Properties.Settings.Default.CompleteID = Convert.ToInt32(completeIDNumUpDown.Value);
            Properties.Settings.Default.DistributeID = Convert.ToInt32(distributeIDNumUpDown.Value);
            Properties.Settings.Default.CustomScript1 = customScript1Tbx.Text;
            Properties.Settings.Default.CustomScript2 = customScript2Tbx.Text;
            Properties.Settings.Default.CustomScript3 = customScript3Tbx.Text;

            Properties.Settings.Default.Save();

            CloseForm();
        }
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            CloseForm();
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
        private void BrowserConfigForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.F4)
            {
                this.CloseForm();
            }
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
    }
}
