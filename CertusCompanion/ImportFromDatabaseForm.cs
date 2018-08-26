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
        // constructors
        public ImportFromDatabaseForm()
        {
            InitializeComponent();
        }
        public ImportFromDatabaseForm(List<Client> clients)
        {
            InitializeComponent();

            this.clients = clients;

            PopulateSources();
        }
        public ImportFromDatabaseForm(List<Client> clients, string selectedClient)
        {
            InitializeComponent();

            this.clients = clients;
            this.clientComboBox.Text = selectedClient;

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
        private void trackBar_Scroll(object sender, EventArgs e)
        {
            tickCountLbl.Text = (trackBar.Value * 5000).ToString();
        }
        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                trackBar.Enabled = false;
                tickCountLbl.Visible = false;
            }
            else
            {
                trackBar.Enabled = true;
                tickCountLbl.Visible = true;
            }
        }
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            CloseForm();
        }
        private void importBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FieldCheck()) return;

                // extract client id
                string clientSel = this.clientComboBox.Text.ToString();
                int delim1 = clientSel.IndexOf('<');
                int delim2 = clientSel.IndexOf('>');
                string clientID = clientSel.Substring(delim1 + 1, delim2 - delim1 - 1);

                ClientIDSelection = clientID;
                foreach (char c in clientID)
                {
                    if (!Char.IsDigit(c)) throw new Exception();
                }

                if (radioButton1.Checked) WorkflowItemsSelection = radioButton1.Text;
                else if (radioButton2.Checked) WorkflowItemsSelection = radioButton2.Text;
                else if (radioButton3.Checked) WorkflowItemsSelection = radioButton3.Text;
                else if (radioButton4.Checked) WorkflowItemsSelection = radioButton4.Text;

                WorkflowItemsAmount = Convert.ToInt32(this.tickCountLbl.Text);
                AddAndUpdate = addAndUpdateCheckBox.Checked;

                this.DialogResult = DialogResult.OK;
                CloseForm();
            }
            catch (Exception)
            {
                this.DialogResult = DialogResult.Abort;
                CloseForm();
            }
        }
        private bool FieldCheck()
        {
            // no client in tbx
            if (clientComboBox.Text == String.Empty || clientComboBox.Text == null)
            {
                statusLbl.Visible = true;
                statusLbl.Text = "You must select a client";
                return false;
            }

            // client invalid
            if (clientComboBox.Items != null && clientComboBox.Items.Count > 0 && !clientComboBox.Items.Contains(clientComboBox.Text))
            {
                statusLbl.Visible = true;
                statusLbl.Text = "Not a valid client";
                return false;
            }

            // invalid character in cient text
            foreach (char c in clientComboBox.Text)
            {
                if (c==';')
                {
                    statusLbl.Visible = true;
                    statusLbl.Text = "Invalid character in Cient selection";
                    return false;
                }
            }

            // client id missing
            if (!clientComboBox.Text.Contains("<") || !clientComboBox.Text.Contains(">"))
            {
                statusLbl.Visible = true;
                statusLbl.Text = "Client ID required, like so: <36>";
                return false;
            }

            // no option selected
            if (!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked && !radioButton4.Checked)
            {
                statusLbl.Visible = true;
                statusLbl.Text = "You must select an option";
                return false;
            }

            // no amount selected
            if (!radioButton1.Checked && tickCountLbl.Text == "0")
            {
                statusLbl.Visible = true;
                statusLbl.Text = "Specify an amount (greater than 0)";
                return false;
            }

            return true;
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
