namespace CertusCompanion
{
    partial class ImportFromDatabaseForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.clientLbl = new System.Windows.Forms.Label();
            this.workflowItemsLbl = new System.Windows.Forms.Label();
            this.dividerPanel = new System.Windows.Forms.Panel();
            this.dividerLbl = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.importBtn = new System.Windows.Forms.Button();
            this.addAndUpdateCheckBox = new System.Windows.Forms.CheckBox();
            this.tickCountLbl = new System.Windows.Forms.Label();
            this.statusLbl = new System.Windows.Forms.Label();
            this.clientPanel = new System.Windows.Forms.Panel();
            this.clientComboBox = new System.Windows.Forms.ComboBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dividerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.clientPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // clientLbl
            // 
            this.clientLbl.AutoSize = true;
            this.clientLbl.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.clientLbl.Location = new System.Drawing.Point(18, 16);
            this.clientLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.clientLbl.Name = "clientLbl";
            this.clientLbl.Size = new System.Drawing.Size(36, 13);
            this.clientLbl.TabIndex = 3;
            this.clientLbl.Text = "Client:";
            // 
            // workflowItemsLbl
            // 
            this.workflowItemsLbl.AutoSize = true;
            this.workflowItemsLbl.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.workflowItemsLbl.Location = new System.Drawing.Point(18, 59);
            this.workflowItemsLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.workflowItemsLbl.Name = "workflowItemsLbl";
            this.workflowItemsLbl.Size = new System.Drawing.Size(83, 13);
            this.workflowItemsLbl.TabIndex = 4;
            this.workflowItemsLbl.Text = "Workflow Items:";
            // 
            // dividerPanel
            // 
            this.dividerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dividerPanel.Controls.Add(this.dividerLbl);
            this.dividerPanel.ForeColor = System.Drawing.Color.Transparent;
            this.dividerPanel.Location = new System.Drawing.Point(11, 37);
            this.dividerPanel.Margin = new System.Windows.Forms.Padding(2);
            this.dividerPanel.Name = "dividerPanel";
            this.dividerPanel.Size = new System.Drawing.Size(408, 10);
            this.dividerPanel.TabIndex = 10;
            // 
            // dividerLbl
            // 
            this.dividerLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dividerLbl.BackColor = System.Drawing.Color.Gray;
            this.dividerLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dividerLbl.ForeColor = System.Drawing.Color.Lime;
            this.dividerLbl.Location = new System.Drawing.Point(7, 5);
            this.dividerLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.dividerLbl.Name = "dividerLbl";
            this.dividerLbl.Size = new System.Drawing.Size(394, 2);
            this.dividerLbl.TabIndex = 0;
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar1.AutoSize = false;
            this.trackBar1.Enabled = false;
            this.trackBar1.LargeChange = 2;
            this.trackBar1.Location = new System.Drawing.Point(13, 154);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(2);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(406, 22);
            this.trackBar1.TabIndex = 2;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.cancelBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.cancelBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.cancelBtn.Location = new System.Drawing.Point(362, 210);
            this.cancelBtn.Margin = new System.Windows.Forms.Padding(2);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(50, 18);
            this.cancelBtn.TabIndex = 9;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // importBtn
            // 
            this.importBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.importBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.importBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.importBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.importBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.importBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.importBtn.Location = new System.Drawing.Point(304, 210);
            this.importBtn.Margin = new System.Windows.Forms.Padding(2);
            this.importBtn.Name = "importBtn";
            this.importBtn.Size = new System.Drawing.Size(50, 18);
            this.importBtn.TabIndex = 8;
            this.importBtn.Text = "Import";
            this.importBtn.UseVisualStyleBackColor = true;
            this.importBtn.Click += new System.EventHandler(this.importBtn_Click);
            // 
            // addAndUpdateCheckBox
            // 
            this.addAndUpdateCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addAndUpdateCheckBox.AutoSize = true;
            this.addAndUpdateCheckBox.Checked = true;
            this.addAndUpdateCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.addAndUpdateCheckBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.addAndUpdateCheckBox.Location = new System.Drawing.Point(18, 211);
            this.addAndUpdateCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.addAndUpdateCheckBox.Name = "addAndUpdateCheckBox";
            this.addAndUpdateCheckBox.Size = new System.Drawing.Size(104, 17);
            this.addAndUpdateCheckBox.TabIndex = 7;
            this.addAndUpdateCheckBox.Tag = "ContractID";
            this.addAndUpdateCheckBox.Text = "Add and Update";
            this.addAndUpdateCheckBox.UseVisualStyleBackColor = true;
            // 
            // tickCountLbl
            // 
            this.tickCountLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tickCountLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tickCountLbl.ForeColor = System.Drawing.Color.Gray;
            this.tickCountLbl.Location = new System.Drawing.Point(346, 141);
            this.tickCountLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.tickCountLbl.Name = "tickCountLbl";
            this.tickCountLbl.Size = new System.Drawing.Size(69, 12);
            this.tickCountLbl.TabIndex = 18;
            this.tickCountLbl.Text = "0";
            this.tickCountLbl.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.tickCountLbl.Visible = false;
            // 
            // statusLbl
            // 
            this.statusLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.statusLbl.AutoSize = true;
            this.statusLbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.statusLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLbl.ForeColor = System.Drawing.Color.Gray;
            this.statusLbl.Location = new System.Drawing.Point(124, 212);
            this.statusLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(119, 12);
            this.statusLbl.TabIndex = 21;
            this.statusLbl.Text = "Required Fields are Missing";
            this.statusLbl.Visible = false;
            // 
            // clientPanel
            // 
            this.clientPanel.BackColor = System.Drawing.Color.Red;
            this.clientPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.clientPanel.Controls.Add(this.clientComboBox);
            this.clientPanel.Location = new System.Drawing.Point(58, 11);
            this.clientPanel.Name = "clientPanel";
            this.clientPanel.Size = new System.Drawing.Size(162, 21);
            this.clientPanel.TabIndex = 22;
            // 
            // clientComboBox
            // 
            this.clientComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clientComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.clientComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.clientComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.clientComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clientComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientComboBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.clientComboBox.FormattingEnabled = true;
            this.clientComboBox.Location = new System.Drawing.Point(-1, -1);
            this.clientComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.clientComboBox.Name = "clientComboBox";
            this.clientComboBox.Size = new System.Drawing.Size(161, 21);
            this.clientComboBox.TabIndex = 0;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.ForeColor = System.Drawing.SystemColors.Control;
            this.radioButton1.Location = new System.Drawing.Point(114, 57);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(97, 17);
            this.radioButton1.TabIndex = 24;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Non-completed";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.ForeColor = System.Drawing.SystemColors.Control;
            this.radioButton2.Location = new System.Drawing.Point(114, 80);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(95, 17);
            this.radioButton2.TabIndex = 25;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Most Recent...";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.ForeColor = System.Drawing.SystemColors.Control;
            this.radioButton3.Location = new System.Drawing.Point(114, 103);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(176, 17);
            this.radioButton3.TabIndex = 26;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Most Recent (Non-completed)...";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.ForeColor = System.Drawing.SystemColors.Control;
            this.radioButton4.Location = new System.Drawing.Point(114, 126);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(154, 17);
            this.radioButton4.TabIndex = 27;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Most Recent (Completed)...";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label1);
            this.panel1.ForeColor = System.Drawing.Color.Transparent;
            this.panel1.Location = new System.Drawing.Point(11, 173);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(408, 10);
            this.panel1.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Gray;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Location = new System.Drawing.Point(7, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(394, 2);
            this.label1.TabIndex = 0;
            // 
            // ImportFromDatabaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(430, 241);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.radioButton4);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.clientPanel);
            this.Controls.Add(this.statusLbl);
            this.Controls.Add(this.tickCountLbl);
            this.Controls.Add(this.addAndUpdateCheckBox);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.importBtn);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.dividerPanel);
            this.Controls.Add(this.workflowItemsLbl);
            this.Controls.Add(this.clientLbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImportFromDatabaseForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Import From Database";
            this.dividerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.clientPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label clientLbl;
        private System.Windows.Forms.Label workflowItemsLbl;
        private System.Windows.Forms.Panel dividerPanel;
        private System.Windows.Forms.Label dividerLbl;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button importBtn;
        private System.Windows.Forms.CheckBox addAndUpdateCheckBox;
        private System.Windows.Forms.Label tickCountLbl;
        private System.Windows.Forms.Label statusLbl;
        private System.Windows.Forms.Panel clientPanel;
        private System.Windows.Forms.ComboBox clientComboBox;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}