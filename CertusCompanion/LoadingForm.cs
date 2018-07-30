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
    public partial class LoadingForm : Form
    {
        double barPercentage = 0.00;
        int barWidth = 0;

        public LoadingForm()
        {
            InitializeComponent();

            // code to appear in the center of the form
            int x = Application.OpenForms[0].Location.X + (Application.OpenForms[0].Bounds.Width / 2 - this.Width / 2);
            int y = Application.OpenForms[0].Location.Y + (Application.OpenForms[0].Bounds.Height / 2 - this.Height / 2);
            this.Location = new Point(x, y);

            this.ShowInTaskbar = false;
            this.loadForegroundPanel.Width = 0;
            this.barWidth = this.loadBackgroundPanel.Width-1;
        }

        public void ChangeLabel(string label)
        {
            this.statusLabel.Text = label;   
        }

        public void ChangeHeaderLabel(string label)
        {
            this.headerLabel.Text = label;
        }

        public void MoveBar(int incrementPercent)
        {
            barPercentage += (incrementPercent * .01);

            this.loadForegroundPanel.Width = (int)(barPercentage * barWidth);
        }

        public void ReplaceBar(int incrementPercent)
        {
            barPercentage = (incrementPercent * .01);

            this.loadForegroundPanel.Width = (int)(barPercentage * barWidth);
        }

        public void CompleteProgress()
        {
            barPercentage = 1.00;
            this.loadForegroundPanel.Width = (int)(barPercentage * barWidth);
            this.headerLabel.Text = "Complete";
        }

        public void ResetBar()
        {
            barPercentage = 0.00;
        }

        public void HideBar()
        {
            this.loadBackgroundPanel.Visible = false;
        }

        public void ShowCloseBtn()
        {
            closeBtn.Visible = true;
        }

        public void FormatForReport(int pixelsToMove)
        {
            int fix = pixelsToMove;

            this.loadBackgroundPanel.Visible = false;
            this.Top -= fix;
            this.Height += fix;
            this.statusLabel.Top -= fix;
            this.statusLabel.Height += fix;
        }

        public void FormatForDialog(string option1)
        {
            this.loadBackgroundPanel.Visible = false;
            this.closeBtn.Visible = true;
            this.panel1.Visible = true;
            this.radioButton1.Text = option1;
            this.radioButton2.Visible = false;
            this.radioButton3.Visible = false;
            this.closeBtn.Text = "Save";
            this.closeBtn.Click -= closeBtn_Click;
            this.closeBtn.Click += saveBtn_Click;
        }

        public void FormatForDialog(string option1, string option2)
        {
            this.loadBackgroundPanel.Visible = false;
            this.closeBtn.Visible = true;
            this.panel1.Visible = true;
            this.radioButton1.Text = option1;
            this.radioButton2.Text = option2;
            this.radioButton3.Visible = false;
            this.closeBtn.Text = "Save";
            this.closeBtn.Click -= closeBtn_Click;
            this.closeBtn.Click += saveBtn_Click;
        }

        public void FormatForDialog(string option1, string option2, string option3)
        {
            this.loadBackgroundPanel.Visible = false;
            this.closeBtn.Visible = true;
            this.panel1.Visible = true;
            this.radioButton1.Text = option1;
            this.radioButton2.Text = option2;
            this.radioButton3.Text = option3;
            this.closeBtn.Text = "Save";
            this.closeBtn.Click -= closeBtn_Click;
            this.closeBtn.Click += saveBtn_Click;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.OpenForms["Transparent Form"].Close();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            Application.OpenForms["Transparent Form"].Close();

            if(radioButton1.Checked)
                this.DialogResult = DialogResult.None;
            else if (radioButton2.Checked)
                this.DialogResult = DialogResult.OK;
            else if (radioButton3.Checked)
                this.DialogResult = DialogResult.Cancel;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.OpenForms["Transparent Form"].Close();

            this.DialogResult = DialogResult.Abort;
        }
    }
}
