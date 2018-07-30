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
    public partial class NoteForm : Form
    {
        WorkflowItem item;

        public NoteForm()
        {
            InitializeComponent();
        }

        public void Populate(WorkflowItem item)
        {
            this.item = item;
            noteComboBox.SelectedIndex = 2;
        }

        private void GenerateDefaultNote()
        {
            noteTbx.Text =
                $"Duplicate file;\r\n" +
                $"See \"{item.SubjectLine}\" \r\n" +
                $"Sent: {item.EmailDate} \r\n" +
                $"By: {item.EmailFromAddress}";
        }

        private void GenerateOriginalItemNote()
        {
            noteTbx.Text =
                $"Duplicate file;\r\n" +
                $"Original sent as \"{item.SubjectLine}\" \r\n" +
                $"Sent: {item.EmailDate} \r\n" +
                $"By: {item.EmailFromAddress}";
        }

        private void GenerateNewerItemNote()
        {
            noteTbx.Text =
                $"File resent;\r\n" +
                $"See \"{item.SubjectLine}\" \r\n" +
                $"Sent: {item.EmailDate} \r\n" +
                $"By: {item.EmailFromAddress}";
        }

        private void GenerateNewerItemWithRevisionsNote()
        {
            noteTbx.Text =
                $"File resent with revisions / newer issue date;\r\n" +
                $"See \"{item.SubjectLine}\" \r\n" +
                $"Sent: {item.EmailDate} \r\n" +
                $"By: {item.EmailFromAddress}";
        }

        private void noteComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (noteComboBox.SelectedIndex == 0)
            {
                GenerateDefaultNote();
            }
            else if (noteComboBox.SelectedIndex == 1)
            {
                GenerateOriginalItemNote();
            }
            else if (noteComboBox.SelectedIndex == 2)
            {
                GenerateNewerItemNote();
            }
            else if (noteComboBox.SelectedIndex == 3)
            {
                GenerateNewerItemWithRevisionsNote();
            }

            noteTbx.Focus();
            noteTbx.SelectAll();
        }

        private void NoteForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            (Application.OpenForms[0] as WorkflowManager).Focus();
        }

        private void NoteForm_Shown(object sender, EventArgs e)
        {
            noteTbx.Focus();
            noteTbx.SelectAll();
        }
    }
}
