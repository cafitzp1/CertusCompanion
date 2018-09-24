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
        public string Note { get; set; }

        //
        // startup
        public NoteForm()
        {
            InitializeComponent();
        }
        private void NoteForm_Load(object sender, EventArgs e)
        {
            noteTbx.Focus();
        }
        public void Populate(WorkflowItem item)
        {
            this.Note = item.Note;

            this.noteTbx.Text = item.Note;
        }

        //
        // form functionality
        private void saveBtn_Click(object sender, EventArgs e)
        {
            this.Note = noteTbx.Text;

            this.DialogResult = DialogResult.OK;

            CloseForm();
        }
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

            CloseForm();
        }

        //
        // form behavior
        private void NoteForm_Shown(object sender, EventArgs e)
        {
            noteTbx.Focus();
            noteTbx.SelectAll();
        }
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
