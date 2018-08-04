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
            this.clientComboBox = new System.Windows.Forms.ComboBox();
            this.clientLbl = new System.Windows.Forms.Label();
            this.workflowItemsLbl = new System.Windows.Forms.Label();
            this.certificatesLbl = new System.Windows.Forms.Label();
            this.companiesLbl = new System.Windows.Forms.Label();
            this.workflowItemsComboBox = new System.Windows.Forms.ComboBox();
            this.certificatesComboBox = new System.Windows.Forms.ComboBox();
            this.companiesComboBox = new System.Windows.Forms.ComboBox();
            this.dividerPanel = new System.Windows.Forms.Panel();
            this.dividerLbl = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.trackBar3 = new System.Windows.Forms.TrackBar();
            this.clearBtn = new System.Windows.Forms.Button();
            this.importBtn = new System.Windows.Forms.Button();
            this.addAndUpdateCheckBox = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.tickCountLbl1 = new System.Windows.Forms.Label();
            this.tickCountLbl2 = new System.Windows.Forms.Label();
            this.tickCountLbl3 = new System.Windows.Forms.Label();
            this.statusLbl = new System.Windows.Forms.Label();
            this.dividerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // clientComboBox
            // 
            this.clientComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.clientComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clientComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clientComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientComboBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.clientComboBox.FormattingEnabled = true;
            this.clientComboBox.Items.AddRange(new object[] {
            "CBRE <36>"});
            this.clientComboBox.Location = new System.Drawing.Point(114, 27);
            this.clientComboBox.Name = "clientComboBox";
            this.clientComboBox.Size = new System.Drawing.Size(250, 33);
            this.clientComboBox.TabIndex = 0;
            // 
            // clientLbl
            // 
            this.clientLbl.AutoSize = true;
            this.clientLbl.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.clientLbl.Location = new System.Drawing.Point(35, 30);
            this.clientLbl.Name = "clientLbl";
            this.clientLbl.Size = new System.Drawing.Size(73, 25);
            this.clientLbl.TabIndex = 3;
            this.clientLbl.Text = "Client:";
            // 
            // workflowItemsLbl
            // 
            this.workflowItemsLbl.AutoSize = true;
            this.workflowItemsLbl.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.workflowItemsLbl.Location = new System.Drawing.Point(70, 108);
            this.workflowItemsLbl.Name = "workflowItemsLbl";
            this.workflowItemsLbl.Size = new System.Drawing.Size(163, 25);
            this.workflowItemsLbl.TabIndex = 4;
            this.workflowItemsLbl.Text = "Workflow Items:";
            // 
            // certificatesLbl
            // 
            this.certificatesLbl.AutoSize = true;
            this.certificatesLbl.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.certificatesLbl.Location = new System.Drawing.Point(70, 163);
            this.certificatesLbl.Name = "certificatesLbl";
            this.certificatesLbl.Size = new System.Drawing.Size(126, 25);
            this.certificatesLbl.TabIndex = 5;
            this.certificatesLbl.Text = "Certificates:";
            // 
            // companiesLbl
            // 
            this.companiesLbl.AutoSize = true;
            this.companiesLbl.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.companiesLbl.Location = new System.Drawing.Point(70, 218);
            this.companiesLbl.Name = "companiesLbl";
            this.companiesLbl.Size = new System.Drawing.Size(126, 25);
            this.companiesLbl.TabIndex = 6;
            this.companiesLbl.Text = "Companies:";
            // 
            // workflowItemsComboBox
            // 
            this.workflowItemsComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.workflowItemsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.workflowItemsComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.workflowItemsComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.workflowItemsComboBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.workflowItemsComboBox.FormattingEnabled = true;
            this.workflowItemsComboBox.Items.AddRange(new object[] {
            "All",
            "Current",
            "Most Recent...",
            "Curent & Most Recent..."});
            this.workflowItemsComboBox.Location = new System.Drawing.Point(270, 105);
            this.workflowItemsComboBox.Name = "workflowItemsComboBox";
            this.workflowItemsComboBox.Size = new System.Drawing.Size(270, 33);
            this.workflowItemsComboBox.TabIndex = 1;
            // 
            // certificatesComboBox
            // 
            this.certificatesComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.certificatesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.certificatesComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.certificatesComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.certificatesComboBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.certificatesComboBox.FormattingEnabled = true;
            this.certificatesComboBox.Items.AddRange(new object[] {
            "All",
            "Active",
            "Most Recent..."});
            this.certificatesComboBox.Location = new System.Drawing.Point(270, 160);
            this.certificatesComboBox.Name = "certificatesComboBox";
            this.certificatesComboBox.Size = new System.Drawing.Size(270, 33);
            this.certificatesComboBox.TabIndex = 3;
            // 
            // companiesComboBox
            // 
            this.companiesComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.companiesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.companiesComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.companiesComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.companiesComboBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.companiesComboBox.FormattingEnabled = true;
            this.companiesComboBox.Items.AddRange(new object[] {
            "All",
            "Active",
            "Most Recent..."});
            this.companiesComboBox.Location = new System.Drawing.Point(270, 215);
            this.companiesComboBox.Name = "companiesComboBox";
            this.companiesComboBox.Size = new System.Drawing.Size(270, 33);
            this.companiesComboBox.TabIndex = 5;
            // 
            // dividerPanel
            // 
            this.dividerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dividerPanel.Controls.Add(this.dividerLbl);
            this.dividerPanel.ForeColor = System.Drawing.Color.Transparent;
            this.dividerPanel.Location = new System.Drawing.Point(22, 70);
            this.dividerPanel.Name = "dividerPanel";
            this.dividerPanel.Size = new System.Drawing.Size(808, 20);
            this.dividerPanel.TabIndex = 10;
            // 
            // dividerLbl
            // 
            this.dividerLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dividerLbl.BackColor = System.Drawing.Color.Gray;
            this.dividerLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dividerLbl.ForeColor = System.Drawing.Color.Lime;
            this.dividerLbl.Location = new System.Drawing.Point(14, 9);
            this.dividerLbl.Name = "dividerLbl";
            this.dividerLbl.Size = new System.Drawing.Size(780, 3);
            this.dividerLbl.TabIndex = 0;
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar1.AutoSize = false;
            this.trackBar1.LargeChange = 2;
            this.trackBar1.Location = new System.Drawing.Point(581, 104);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(237, 30);
            this.trackBar1.TabIndex = 2;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // trackBar2
            // 
            this.trackBar2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar2.AutoSize = false;
            this.trackBar2.LargeChange = 2;
            this.trackBar2.Location = new System.Drawing.Point(581, 159);
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(237, 30);
            this.trackBar2.TabIndex = 4;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // trackBar3
            // 
            this.trackBar3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar3.AutoSize = false;
            this.trackBar3.LargeChange = 2;
            this.trackBar3.Location = new System.Drawing.Point(581, 211);
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.Size = new System.Drawing.Size(237, 30);
            this.trackBar3.TabIndex = 6;
            this.trackBar3.Scroll += new System.EventHandler(this.trackBar3_Scroll);
            // 
            // clearBtn
            // 
            this.clearBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.clearBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.clearBtn.Location = new System.Drawing.Point(601, 302);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(100, 35);
            this.clearBtn.TabIndex = 9;
            this.clearBtn.Text = "Clear";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // importBtn
            // 
            this.importBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.importBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.importBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.importBtn.Location = new System.Drawing.Point(716, 302);
            this.importBtn.Name = "importBtn";
            this.importBtn.Size = new System.Drawing.Size(100, 35);
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
            this.addAndUpdateCheckBox.Location = new System.Drawing.Point(36, 303);
            this.addAndUpdateCheckBox.Name = "addAndUpdateCheckBox";
            this.addAndUpdateCheckBox.Size = new System.Drawing.Size(199, 29);
            this.addAndUpdateCheckBox.TabIndex = 7;
            this.addAndUpdateCheckBox.Tag = "ContractID";
            this.addAndUpdateCheckBox.Text = "Add and Update";
            this.addAndUpdateCheckBox.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label4);
            this.panel1.ForeColor = System.Drawing.Color.Transparent;
            this.panel1.Location = new System.Drawing.Point(22, 267);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(808, 20);
            this.panel1.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.BackColor = System.Drawing.Color.Gray;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.ForeColor = System.Drawing.Color.Lime;
            this.label4.Location = new System.Drawing.Point(14, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(780, 3);
            this.label4.TabIndex = 0;
            // 
            // tickCountLbl1
            // 
            this.tickCountLbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tickCountLbl1.ForeColor = System.Drawing.Color.Gray;
            this.tickCountLbl1.Location = new System.Drawing.Point(717, 136);
            this.tickCountLbl1.Name = "tickCountLbl1";
            this.tickCountLbl1.Size = new System.Drawing.Size(95, 23);
            this.tickCountLbl1.TabIndex = 18;
            this.tickCountLbl1.Text = "0";
            this.tickCountLbl1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tickCountLbl2
            // 
            this.tickCountLbl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tickCountLbl2.ForeColor = System.Drawing.Color.Gray;
            this.tickCountLbl2.Location = new System.Drawing.Point(717, 191);
            this.tickCountLbl2.Name = "tickCountLbl2";
            this.tickCountLbl2.Size = new System.Drawing.Size(95, 23);
            this.tickCountLbl2.TabIndex = 19;
            this.tickCountLbl2.Text = "0";
            this.tickCountLbl2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tickCountLbl3
            // 
            this.tickCountLbl3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tickCountLbl3.ForeColor = System.Drawing.Color.Gray;
            this.tickCountLbl3.Location = new System.Drawing.Point(717, 242);
            this.tickCountLbl3.Name = "tickCountLbl3";
            this.tickCountLbl3.Size = new System.Drawing.Size(95, 23);
            this.tickCountLbl3.TabIndex = 20;
            this.tickCountLbl3.Text = "0";
            this.tickCountLbl3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // statusLbl
            // 
            this.statusLbl.AutoSize = true;
            this.statusLbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.statusLbl.ForeColor = System.Drawing.Color.Gray;
            this.statusLbl.Location = new System.Drawing.Point(283, 306);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(280, 25);
            this.statusLbl.TabIndex = 21;
            this.statusLbl.Text = "Required Fields are Missing";
            this.statusLbl.Visible = false;
            // 
            // ImportFromDatabaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(852, 361);
            this.Controls.Add(this.statusLbl);
            this.Controls.Add(this.tickCountLbl3);
            this.Controls.Add(this.tickCountLbl2);
            this.Controls.Add(this.tickCountLbl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.addAndUpdateCheckBox);
            this.Controls.Add(this.clearBtn);
            this.Controls.Add(this.importBtn);
            this.Controls.Add(this.trackBar3);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.dividerPanel);
            this.Controls.Add(this.companiesComboBox);
            this.Controls.Add(this.certificatesComboBox);
            this.Controls.Add(this.workflowItemsComboBox);
            this.Controls.Add(this.companiesLbl);
            this.Controls.Add(this.certificatesLbl);
            this.Controls.Add(this.workflowItemsLbl);
            this.Controls.Add(this.clientComboBox);
            this.Controls.Add(this.clientLbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImportFromDatabaseForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Import From Database";
            this.dividerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox clientComboBox;
        private System.Windows.Forms.Label clientLbl;
        private System.Windows.Forms.Label workflowItemsLbl;
        private System.Windows.Forms.Label certificatesLbl;
        private System.Windows.Forms.Label companiesLbl;
        private System.Windows.Forms.ComboBox workflowItemsComboBox;
        private System.Windows.Forms.ComboBox certificatesComboBox;
        private System.Windows.Forms.ComboBox companiesComboBox;
        private System.Windows.Forms.Panel dividerPanel;
        private System.Windows.Forms.Label dividerLbl;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.TrackBar trackBar3;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.Button importBtn;
        private System.Windows.Forms.CheckBox addAndUpdateCheckBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label tickCountLbl1;
        private System.Windows.Forms.Label tickCountLbl2;
        private System.Windows.Forms.Label tickCountLbl3;
        private System.Windows.Forms.Label statusLbl;
    }
}