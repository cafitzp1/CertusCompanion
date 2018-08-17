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
            this.clearBtn = new System.Windows.Forms.Button();
            this.importBtn = new System.Windows.Forms.Button();
            this.addAndUpdateCheckBox = new System.Windows.Forms.CheckBox();
            this.tickCountLbl1 = new System.Windows.Forms.Label();
            this.statusLbl = new System.Windows.Forms.Label();
            this.clientPanel = new System.Windows.Forms.Panel();
            this.clientComboBox = new System.Windows.Forms.ComboBox();
            this.workflowItemsPanel = new System.Windows.Forms.Panel();
            this.workflowItemsComboBox = new System.Windows.Forms.ComboBox();
            this.dividerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.clientPanel.SuspendLayout();
            this.workflowItemsPanel.SuspendLayout();
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
            this.workflowItemsLbl.Location = new System.Drawing.Point(35, 59);
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
            this.dividerPanel.Location = new System.Drawing.Point(11, 36);
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
            this.dividerLbl.Size = new System.Drawing.Size(394, 3);
            this.dividerLbl.TabIndex = 0;
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar1.AutoSize = false;
            this.trackBar1.LargeChange = 2;
            this.trackBar1.Location = new System.Drawing.Point(290, 55);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(2);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(122, 16);
            this.trackBar1.TabIndex = 2;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // clearBtn
            // 
            this.clearBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.clearBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.clearBtn.Location = new System.Drawing.Point(304, 123);
            this.clearBtn.Margin = new System.Windows.Forms.Padding(2);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(50, 18);
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
            this.importBtn.Location = new System.Drawing.Point(362, 123);
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
            this.addAndUpdateCheckBox.Location = new System.Drawing.Point(18, 122);
            this.addAndUpdateCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.addAndUpdateCheckBox.Name = "addAndUpdateCheckBox";
            this.addAndUpdateCheckBox.Size = new System.Drawing.Size(104, 17);
            this.addAndUpdateCheckBox.TabIndex = 7;
            this.addAndUpdateCheckBox.Tag = "ContractID";
            this.addAndUpdateCheckBox.Text = "Add and Update";
            this.addAndUpdateCheckBox.UseVisualStyleBackColor = true;
            // 
            // tickCountLbl1
            // 
            this.tickCountLbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tickCountLbl1.ForeColor = System.Drawing.Color.Gray;
            this.tickCountLbl1.Location = new System.Drawing.Point(358, 72);
            this.tickCountLbl1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.tickCountLbl1.Name = "tickCountLbl1";
            this.tickCountLbl1.Size = new System.Drawing.Size(48, 12);
            this.tickCountLbl1.TabIndex = 18;
            this.tickCountLbl1.Text = "0";
            this.tickCountLbl1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // statusLbl
            // 
            this.statusLbl.AutoSize = true;
            this.statusLbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.statusLbl.ForeColor = System.Drawing.Color.Gray;
            this.statusLbl.Location = new System.Drawing.Point(142, 159);
            this.statusLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(136, 13);
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
            this.clientComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.clientComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            // workflowItemsPanel
            // 
            this.workflowItemsPanel.BackColor = System.Drawing.Color.Red;
            this.workflowItemsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.workflowItemsPanel.Controls.Add(this.workflowItemsComboBox);
            this.workflowItemsPanel.Location = new System.Drawing.Point(133, 54);
            this.workflowItemsPanel.Name = "workflowItemsPanel";
            this.workflowItemsPanel.Size = new System.Drawing.Size(139, 21);
            this.workflowItemsPanel.TabIndex = 23;
            // 
            // workflowItemsComboBox
            // 
            this.workflowItemsComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.workflowItemsComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.workflowItemsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.workflowItemsComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.workflowItemsComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.workflowItemsComboBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.workflowItemsComboBox.FormattingEnabled = true;
            this.workflowItemsComboBox.Items.AddRange(new object[] {
            "Non-completed",
            "Most Recent...",
            "Most Recent (Non-completed)...",
            "Most Recent (Completed)..."});
            this.workflowItemsComboBox.Location = new System.Drawing.Point(-1, -1);
            this.workflowItemsComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.workflowItemsComboBox.Name = "workflowItemsComboBox";
            this.workflowItemsComboBox.Size = new System.Drawing.Size(138, 21);
            this.workflowItemsComboBox.TabIndex = 1;
            this.workflowItemsComboBox.SelectedIndexChanged += new System.EventHandler(this.workflowItemsComboBox_SelectedIndexChanged);
            // 
            // ImportFromDatabaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(430, 154);
            this.Controls.Add(this.workflowItemsPanel);
            this.Controls.Add(this.clientPanel);
            this.Controls.Add(this.statusLbl);
            this.Controls.Add(this.tickCountLbl1);
            this.Controls.Add(this.addAndUpdateCheckBox);
            this.Controls.Add(this.clearBtn);
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
            this.workflowItemsPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label clientLbl;
        private System.Windows.Forms.Label workflowItemsLbl;
        private System.Windows.Forms.Panel dividerPanel;
        private System.Windows.Forms.Label dividerLbl;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.Button importBtn;
        private System.Windows.Forms.CheckBox addAndUpdateCheckBox;
        private System.Windows.Forms.Label tickCountLbl1;
        private System.Windows.Forms.Label statusLbl;
        private System.Windows.Forms.Panel clientPanel;
        private System.Windows.Forms.ComboBox clientComboBox;
        private System.Windows.Forms.Panel workflowItemsPanel;
        private System.Windows.Forms.ComboBox workflowItemsComboBox;
    }
}