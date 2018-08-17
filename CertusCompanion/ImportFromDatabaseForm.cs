using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CertusCompanion
{
    public partial class ImportFromDatabaseForm : Form
    {
        public string ClientIDSelection { get; set; }
        public string WorkflowItemsSelection { get; set; }
        public int WorkflowItemsAmount { get; set; }
        public bool AddAndUpdate { get; set; }
        private List<Client> clients;

        //
        // constructor
        public ImportFromDatabaseForm(List<Client> clients)
        {
            InitializeComponent();

            this.clients = clients;

            PopulateSources();
        }

        //
        // methods
        private void PopulateSources()
        {
            // --- CLIENTS DDL --- //
            clientComboBox.Items.Clear();

            foreach (Client o in clients)
            {
                clientComboBox.Items.Add($"{o.Name} <{o.ClientID}>");
            }
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            tickCountLbl1.Text = (trackBar1.Value * 5000).ToString();
        }
        private void clearBtn_Click(object sender, EventArgs e)
        {
            this.clientComboBox.SelectedIndex = -1;
            this.workflowItemsComboBox.SelectedIndex = -1;

            this.trackBar1.Value = 0;

            this.tickCountLbl1.Text = "0";

        }
        private void importBtn_Click(object sender, EventArgs e)
        {
            if (clientComboBox.SelectedIndex < 0 || (workflowItemsComboBox.SelectedIndex < 0))
            {
                statusLbl.Visible = true;
                return;
            }

            // extract client id
            string clientSel = this.clientComboBox.SelectedItem.ToString();
            int delim1 = clientSel.IndexOf('<');
            int delim2 = clientSel.IndexOf('>');
            string clientID = clientSel.Substring(delim1+1, delim2 - delim1-1);

            ClientIDSelection = clientID;
            WorkflowItemsSelection = this.workflowItemsComboBox.SelectedItem.ToString();
            WorkflowItemsAmount = Convert.ToInt32(this.tickCountLbl1.Text);
            AddAndUpdate = addAndUpdateCheckBox.Checked;

            this.DialogResult = DialogResult.OK;

            CloseForm();
        }
        private void workflowItemsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (workflowItemsComboBox.SelectedIndex == 0)
            {
                trackBar1.Enabled = false;
                tickCountLbl1.Visible = false;
            }
            else
            {
                trackBar1.Enabled = true;
                tickCountLbl1.Visible = true;
            }
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
