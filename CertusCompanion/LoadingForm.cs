﻿using System;
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
        #region LoadingForm Data
        double barPercentage = 0.00;
        int barWidth = 0;
        string dialogFormat;

        public string SelectedComboBoxText { get; set; }
        public int SelectedRadioButton { get; set; }
        #endregion  

        //
        // blank constructor
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

        //
        // loading form manipulation
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
            this.loadForegroundPanel.Width = 0;
            barPercentage = 0.00;
        }
        public void HideBar()
        {
            this.loadBackgroundPanel.Visible = false;
        }
        public void ShowBar()
        {
            this.loadBackgroundPanel.Visible = true;
        }
        public void ShowCloseBtn(string btnText = "Close")
        {
            closeBtn.Text = btnText;
            closeBtn.Visible = true;
            closeBtn.Focus();
        }
        public void HideCloseBtn()
        {
            closeBtn.Visible = false;
        }

        //
        // form style changes
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
            dialogFormat = "radioButtons";

            this.loadBackgroundPanel.Visible = false;
            this.closeBtn.Visible = true;
            this.radioButtonsPanel.Visible = true;
            this.radioButton1.Text = option1;
            this.radioButton2.Visible = false;
            this.radioButton3.Visible = false;

            saveBtn.Visible = true;
        }
        public void FormatForDialog(string option1, string option2)
        {
            dialogFormat = "radioButtons";

            this.loadBackgroundPanel.Visible = false;
            this.closeBtn.Visible = true;
            this.radioButtonsPanel.Visible = true;
            this.radioButton1.Text = option1;
            this.radioButton2.Text = option2;
            this.radioButton3.Visible = false;

            saveBtn.Visible = true;
        }
        public void FormatForDialog(string option1, string option2, string option3)
        {
            dialogFormat = "radioButtons";

            this.loadBackgroundPanel.Visible = false;
            this.closeBtn.Visible = true;
            this.radioButtonsPanel.Visible = true;
            this.radioButton1.Text = option1;
            this.radioButton2.Text = option2;
            this.radioButton3.Text = option3;

            saveBtn.Visible = true;
        }
        public void FormatForDialog(List<string> options)
        {
            dialogFormat = "comboBox";

            this.loadBackgroundPanel.Visible = false;
            this.closeBtn.Visible = true;
            this.optionsComboBox.Visible = true;
            this.optionsComboBox.DropDownWidth = this.optionsComboBox.Width;
            this.optionsComboBox.DropDownHeight = 550;
            this.optionsComboBox.TabIndex = 0;
            this.optionsComboBox.TabStop = true;
            this.optionsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            foreach (string option in options)
            {
                this.optionsComboBox.Items.Add(option);
            }

            saveBtn.Visible = true;
        }

        //
        // functionality
        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

            CloseForm();
        }
        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (dialogFormat == "comboBox")
            {
                if (optionsComboBox.Text == "Select one..." || optionsComboBox.Text == String.Empty)
                {
                    statusLabel.Text = "You must select an option first...";
                    return;
                }
                else this.SelectedComboBoxText = optionsComboBox.SelectedItem.ToString();
            }
            else if (dialogFormat == "radioButtons")
            {
                if (!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked)
                {
                    statusLabel.Text = "You must select an option first";
                    return;
                }
                else if (radioButton1.Checked) this.SelectedRadioButton = 1;
                else if (radioButton2.Checked) this.SelectedRadioButton = 2;
                else if (radioButton3.Checked) this.SelectedRadioButton = 3;
            }

            this.DialogResult = DialogResult.OK;

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
        private void LoadingForm_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.F4)
            {
                this.CloseForm();
            }
            else if (e.KeyCode==Keys.Enter)
            {
                if (saveBtn.Visible) saveBtn.PerformClick();
                else closeBtn.PerformClick();
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
        private void saveBtn_VisibleChanged(object sender, EventArgs e)
        {
            //
        }
    }
}
