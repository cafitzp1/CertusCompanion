namespace CertusCompanion
{
    partial class ExportForm
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
            this.complianceAnalystCheckBox = new System.Windows.Forms.CheckBox();
            this.clearBtn = new System.Windows.Forms.Button();
            this.emailDateCheckBox = new System.Windows.Forms.CheckBox();
            this.workflowAnalystCheckBox = new System.Windows.Forms.CheckBox();
            this.certificateDateCheckBox = new System.Windows.Forms.CheckBox();
            this.compliantCheckBox = new System.Windows.Forms.CheckBox();
            this.activeCheckBox = new System.Windows.Forms.CheckBox();
            this.contractIDCheckBox = new System.Windows.Forms.CheckBox();
            this.documentWorkflowItemIDCheckBox = new System.Windows.Forms.CheckBox();
            this.exportBtn = new System.Windows.Forms.Button();
            this.fieldsLbl = new System.Windows.Forms.Label();
            this.dividerPanel = new System.Windows.Forms.Panel();
            this.dividerLbl = new System.Windows.Forms.Label();
            this.presetsLbl = new System.Windows.Forms.Label();
            this.presetsComboBox = new System.Windows.Forms.ComboBox();
            this.subjectLineCheckBox = new System.Windows.Forms.CheckBox();
            this.emailFromCheckBox = new System.Windows.Forms.CheckBox();
            this.fileSizeCheckBox = new System.Windows.Forms.CheckBox();
            this.fileMIMECheckBox = new System.Windows.Forms.CheckBox();
            this.fileURLCheckBox = new System.Windows.Forms.CheckBox();
            this.certusFileIDCheckBox = new System.Windows.Forms.CheckBox();
            this.fileNameCheckBox = new System.Windows.Forms.CheckBox();
            this.statusCheckBox = new System.Windows.Forms.CheckBox();
            this.noteCheckBox = new System.Windows.Forms.CheckBox();
            this.displayColorCheckBox = new System.Windows.Forms.CheckBox();
            this.itemsAttachedCheckBox = new System.Windows.Forms.CheckBox();
            this.assignedToCheckBox = new System.Windows.Forms.CheckBox();
            this.assignedToComboBox = new System.Windows.Forms.ComboBox();
            this.companyNameCheckBox = new System.Windows.Forms.CheckBox();
            this.statusLbl = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dividerPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // complianceAnalystCheckBox
            // 
            this.complianceAnalystCheckBox.AutoSize = true;
            this.complianceAnalystCheckBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.complianceAnalystCheckBox.Location = new System.Drawing.Point(43, 420);
            this.complianceAnalystCheckBox.Name = "complianceAnalystCheckBox";
            this.complianceAnalystCheckBox.Size = new System.Drawing.Size(234, 29);
            this.complianceAnalystCheckBox.TabIndex = 7;
            this.complianceAnalystCheckBox.TabStop = false;
            this.complianceAnalystCheckBox.Tag = "CompanyAnalyst";
            this.complianceAnalystCheckBox.Text = "Compliance Analyst";
            this.complianceAnalystCheckBox.UseVisualStyleBackColor = true;
            // 
            // clearBtn
            // 
            this.clearBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.clearBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.clearBtn.Location = new System.Drawing.Point(533, 640);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(100, 35);
            this.clearBtn.TabIndex = 2;
            this.clearBtn.Text = "Clear";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // emailDateCheckBox
            // 
            this.emailDateCheckBox.AutoSize = true;
            this.emailDateCheckBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.emailDateCheckBox.Location = new System.Drawing.Point(43, 465);
            this.emailDateCheckBox.Name = "emailDateCheckBox";
            this.emailDateCheckBox.Size = new System.Drawing.Size(148, 29);
            this.emailDateCheckBox.TabIndex = 8;
            this.emailDateCheckBox.TabStop = false;
            this.emailDateCheckBox.Tag = "EmailDate";
            this.emailDateCheckBox.Text = "Email Date";
            this.emailDateCheckBox.UseVisualStyleBackColor = true;
            // 
            // workflowAnalystCheckBox
            // 
            this.workflowAnalystCheckBox.AutoSize = true;
            this.workflowAnalystCheckBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.workflowAnalystCheckBox.Location = new System.Drawing.Point(43, 375);
            this.workflowAnalystCheckBox.Name = "workflowAnalystCheckBox";
            this.workflowAnalystCheckBox.Size = new System.Drawing.Size(209, 29);
            this.workflowAnalystCheckBox.TabIndex = 6;
            this.workflowAnalystCheckBox.TabStop = false;
            this.workflowAnalystCheckBox.Tag = "WorkflowAnalyst";
            this.workflowAnalystCheckBox.Text = "Workflow Analyst";
            this.workflowAnalystCheckBox.UseVisualStyleBackColor = true;
            // 
            // certificateDateCheckBox
            // 
            this.certificateDateCheckBox.AutoSize = true;
            this.certificateDateCheckBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.certificateDateCheckBox.Location = new System.Drawing.Point(43, 330);
            this.certificateDateCheckBox.Name = "certificateDateCheckBox";
            this.certificateDateCheckBox.Size = new System.Drawing.Size(146, 29);
            this.certificateDateCheckBox.TabIndex = 5;
            this.certificateDateCheckBox.TabStop = false;
            this.certificateDateCheckBox.Tag = "IssueDate";
            this.certificateDateCheckBox.Text = "Issue Date";
            this.certificateDateCheckBox.UseVisualStyleBackColor = true;
            // 
            // compliantCheckBox
            // 
            this.compliantCheckBox.AutoSize = true;
            this.compliantCheckBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.compliantCheckBox.Location = new System.Drawing.Point(43, 285);
            this.compliantCheckBox.Name = "compliantCheckBox";
            this.compliantCheckBox.Size = new System.Drawing.Size(140, 29);
            this.compliantCheckBox.TabIndex = 4;
            this.compliantCheckBox.TabStop = false;
            this.compliantCheckBox.Tag = "Compliant";
            this.compliantCheckBox.Text = "Compliant";
            this.compliantCheckBox.UseVisualStyleBackColor = true;
            // 
            // activeCheckBox
            // 
            this.activeCheckBox.AutoSize = true;
            this.activeCheckBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.activeCheckBox.Location = new System.Drawing.Point(43, 240);
            this.activeCheckBox.Name = "activeCheckBox";
            this.activeCheckBox.Size = new System.Drawing.Size(103, 29);
            this.activeCheckBox.TabIndex = 3;
            this.activeCheckBox.TabStop = false;
            this.activeCheckBox.Tag = "Active";
            this.activeCheckBox.Text = "Active";
            this.activeCheckBox.UseVisualStyleBackColor = true;
            // 
            // contractIDCheckBox
            // 
            this.contractIDCheckBox.AutoSize = true;
            this.contractIDCheckBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.contractIDCheckBox.Location = new System.Drawing.Point(43, 150);
            this.contractIDCheckBox.Name = "contractIDCheckBox";
            this.contractIDCheckBox.Size = new System.Drawing.Size(151, 29);
            this.contractIDCheckBox.TabIndex = 2;
            this.contractIDCheckBox.TabStop = false;
            this.contractIDCheckBox.Tag = "ContractID";
            this.contractIDCheckBox.Text = "Contract ID";
            this.contractIDCheckBox.UseVisualStyleBackColor = true;
            // 
            // documentWorkflowItemIDCheckBox
            // 
            this.documentWorkflowItemIDCheckBox.AutoCheck = false;
            this.documentWorkflowItemIDCheckBox.AutoSize = true;
            this.documentWorkflowItemIDCheckBox.Checked = true;
            this.documentWorkflowItemIDCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.documentWorkflowItemIDCheckBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.documentWorkflowItemIDCheckBox.Location = new System.Drawing.Point(43, 105);
            this.documentWorkflowItemIDCheckBox.Name = "documentWorkflowItemIDCheckBox";
            this.documentWorkflowItemIDCheckBox.Size = new System.Drawing.Size(307, 29);
            this.documentWorkflowItemIDCheckBox.TabIndex = 0;
            this.documentWorkflowItemIDCheckBox.TabStop = false;
            this.documentWorkflowItemIDCheckBox.Tag = "DocumentWorkflowItemID";
            this.documentWorkflowItemIDCheckBox.Text = "Document Workflow Item ID";
            this.documentWorkflowItemIDCheckBox.UseVisualStyleBackColor = true;
            // 
            // exportBtn
            // 
            this.exportBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exportBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.exportBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exportBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.exportBtn.Location = new System.Drawing.Point(648, 640);
            this.exportBtn.Name = "exportBtn";
            this.exportBtn.Size = new System.Drawing.Size(100, 35);
            this.exportBtn.TabIndex = 1;
            this.exportBtn.Text = "Export";
            this.exportBtn.UseVisualStyleBackColor = true;
            this.exportBtn.Click += new System.EventHandler(this.exportBtn_Click);
            // 
            // fieldsLbl
            // 
            this.fieldsLbl.AutoSize = true;
            this.fieldsLbl.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.fieldsLbl.Location = new System.Drawing.Point(36, 30);
            this.fieldsLbl.Name = "fieldsLbl";
            this.fieldsLbl.Size = new System.Drawing.Size(175, 25);
            this.fieldsLbl.TabIndex = 0;
            this.fieldsLbl.Text = "Fields to Include:";
            // 
            // dividerPanel
            // 
            this.dividerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dividerPanel.Controls.Add(this.dividerLbl);
            this.dividerPanel.ForeColor = System.Drawing.Color.Transparent;
            this.dividerPanel.Location = new System.Drawing.Point(30, 70);
            this.dividerPanel.Name = "dividerPanel";
            this.dividerPanel.Size = new System.Drawing.Size(730, 20);
            this.dividerPanel.TabIndex = 0;
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
            this.dividerLbl.Size = new System.Drawing.Size(702, 3);
            this.dividerLbl.TabIndex = 0;
            // 
            // presetsLbl
            // 
            this.presetsLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.presetsLbl.AutoSize = true;
            this.presetsLbl.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.presetsLbl.Location = new System.Drawing.Point(423, 30);
            this.presetsLbl.Name = "presetsLbl";
            this.presetsLbl.Size = new System.Drawing.Size(91, 25);
            this.presetsLbl.TabIndex = 0;
            this.presetsLbl.Text = "Presets:";
            // 
            // presetsComboBox
            // 
            this.presetsComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.presetsComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.presetsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.presetsComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.presetsComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.presetsComboBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.presetsComboBox.FormattingEnabled = true;
            this.presetsComboBox.Items.AddRange(new object[] {
            "Default",
            "Item IDs Only",
            "Item Assignment"});
            this.presetsComboBox.Location = new System.Drawing.Point(520, 27);
            this.presetsComboBox.Name = "presetsComboBox";
            this.presetsComboBox.Size = new System.Drawing.Size(229, 33);
            this.presetsComboBox.TabIndex = 0;
            this.presetsComboBox.TabStop = false;
            this.presetsComboBox.SelectedIndexChanged += new System.EventHandler(this.presetsComboBox_SelectedIndexChanged);
            // 
            // subjectLineCheckBox
            // 
            this.subjectLineCheckBox.AutoSize = true;
            this.subjectLineCheckBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.subjectLineCheckBox.Location = new System.Drawing.Point(43, 555);
            this.subjectLineCheckBox.Name = "subjectLineCheckBox";
            this.subjectLineCheckBox.Size = new System.Drawing.Size(163, 29);
            this.subjectLineCheckBox.TabIndex = 10;
            this.subjectLineCheckBox.TabStop = false;
            this.subjectLineCheckBox.Tag = "SubjectLine";
            this.subjectLineCheckBox.Text = "Subject Line";
            this.subjectLineCheckBox.UseVisualStyleBackColor = true;
            // 
            // emailFromCheckBox
            // 
            this.emailFromCheckBox.AutoSize = true;
            this.emailFromCheckBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.emailFromCheckBox.Location = new System.Drawing.Point(43, 510);
            this.emailFromCheckBox.Name = "emailFromCheckBox";
            this.emailFromCheckBox.Size = new System.Drawing.Size(237, 29);
            this.emailFromCheckBox.TabIndex = 9;
            this.emailFromCheckBox.TabStop = false;
            this.emailFromCheckBox.Tag = "EmailFromAddress";
            this.emailFromCheckBox.Text = "Email From Address";
            this.emailFromCheckBox.UseVisualStyleBackColor = true;
            // 
            // fileSizeCheckBox
            // 
            this.fileSizeCheckBox.AutoSize = true;
            this.fileSizeCheckBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.fileSizeCheckBox.Location = new System.Drawing.Point(430, 285);
            this.fileSizeCheckBox.Name = "fileSizeCheckBox";
            this.fileSizeCheckBox.Size = new System.Drawing.Size(127, 29);
            this.fileSizeCheckBox.TabIndex = 15;
            this.fileSizeCheckBox.TabStop = false;
            this.fileSizeCheckBox.Tag = "FileSize";
            this.fileSizeCheckBox.Text = "File Size";
            this.fileSizeCheckBox.UseVisualStyleBackColor = true;
            // 
            // fileMIMECheckBox
            // 
            this.fileMIMECheckBox.AutoSize = true;
            this.fileMIMECheckBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.fileMIMECheckBox.Location = new System.Drawing.Point(430, 330);
            this.fileMIMECheckBox.Name = "fileMIMECheckBox";
            this.fileMIMECheckBox.Size = new System.Drawing.Size(140, 29);
            this.fileMIMECheckBox.TabIndex = 16;
            this.fileMIMECheckBox.TabStop = false;
            this.fileMIMECheckBox.Tag = "FileMIME";
            this.fileMIMECheckBox.Text = "File MIME";
            this.fileMIMECheckBox.UseVisualStyleBackColor = true;
            // 
            // fileURLCheckBox
            // 
            this.fileURLCheckBox.AutoSize = true;
            this.fileURLCheckBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.fileURLCheckBox.Location = new System.Drawing.Point(430, 240);
            this.fileURLCheckBox.Name = "fileURLCheckBox";
            this.fileURLCheckBox.Size = new System.Drawing.Size(127, 29);
            this.fileURLCheckBox.TabIndex = 14;
            this.fileURLCheckBox.TabStop = false;
            this.fileURLCheckBox.Tag = "FileURL";
            this.fileURLCheckBox.Text = "File URL";
            this.fileURLCheckBox.UseVisualStyleBackColor = true;
            // 
            // certusFileIDCheckBox
            // 
            this.certusFileIDCheckBox.AutoSize = true;
            this.certusFileIDCheckBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.certusFileIDCheckBox.Location = new System.Drawing.Point(430, 150);
            this.certusFileIDCheckBox.Name = "certusFileIDCheckBox";
            this.certusFileIDCheckBox.Size = new System.Drawing.Size(174, 29);
            this.certusFileIDCheckBox.TabIndex = 12;
            this.certusFileIDCheckBox.TabStop = false;
            this.certusFileIDCheckBox.Tag = "CertusFileID";
            this.certusFileIDCheckBox.Text = "Certus File ID";
            this.certusFileIDCheckBox.UseVisualStyleBackColor = true;
            // 
            // fileNameCheckBox
            // 
            this.fileNameCheckBox.AutoSize = true;
            this.fileNameCheckBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.fileNameCheckBox.Location = new System.Drawing.Point(430, 195);
            this.fileNameCheckBox.Name = "fileNameCheckBox";
            this.fileNameCheckBox.Size = new System.Drawing.Size(141, 29);
            this.fileNameCheckBox.TabIndex = 13;
            this.fileNameCheckBox.TabStop = false;
            this.fileNameCheckBox.Tag = "FileName";
            this.fileNameCheckBox.Text = "File Name";
            this.fileNameCheckBox.UseVisualStyleBackColor = true;
            // 
            // statusCheckBox
            // 
            this.statusCheckBox.AutoSize = true;
            this.statusCheckBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.statusCheckBox.Location = new System.Drawing.Point(430, 105);
            this.statusCheckBox.Name = "statusCheckBox";
            this.statusCheckBox.Size = new System.Drawing.Size(105, 29);
            this.statusCheckBox.TabIndex = 11;
            this.statusCheckBox.TabStop = false;
            this.statusCheckBox.Tag = "Status";
            this.statusCheckBox.Text = "Status";
            this.statusCheckBox.UseVisualStyleBackColor = true;
            // 
            // noteCheckBox
            // 
            this.noteCheckBox.AutoSize = true;
            this.noteCheckBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.noteCheckBox.Location = new System.Drawing.Point(430, 510);
            this.noteCheckBox.Name = "noteCheckBox";
            this.noteCheckBox.Size = new System.Drawing.Size(89, 29);
            this.noteCheckBox.TabIndex = 20;
            this.noteCheckBox.TabStop = false;
            this.noteCheckBox.Tag = "Note";
            this.noteCheckBox.Text = "Note";
            this.noteCheckBox.UseVisualStyleBackColor = true;
            // 
            // displayColorCheckBox
            // 
            this.displayColorCheckBox.AutoSize = true;
            this.displayColorCheckBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.displayColorCheckBox.Location = new System.Drawing.Point(430, 420);
            this.displayColorCheckBox.Name = "displayColorCheckBox";
            this.displayColorCheckBox.Size = new System.Drawing.Size(172, 29);
            this.displayColorCheckBox.TabIndex = 18;
            this.displayColorCheckBox.TabStop = false;
            this.displayColorCheckBox.Tag = "DisplayColor";
            this.displayColorCheckBox.Text = "Display Color";
            this.displayColorCheckBox.UseVisualStyleBackColor = true;
            // 
            // itemsAttachedCheckBox
            // 
            this.itemsAttachedCheckBox.AutoSize = true;
            this.itemsAttachedCheckBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.itemsAttachedCheckBox.Location = new System.Drawing.Point(430, 465);
            this.itemsAttachedCheckBox.Name = "itemsAttachedCheckBox";
            this.itemsAttachedCheckBox.Size = new System.Drawing.Size(186, 29);
            this.itemsAttachedCheckBox.TabIndex = 19;
            this.itemsAttachedCheckBox.TabStop = false;
            this.itemsAttachedCheckBox.Tag = "ItemsAttached";
            this.itemsAttachedCheckBox.Text = "Items Attached";
            this.itemsAttachedCheckBox.UseVisualStyleBackColor = true;
            // 
            // assignedToCheckBox
            // 
            this.assignedToCheckBox.AutoSize = true;
            this.assignedToCheckBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.assignedToCheckBox.Location = new System.Drawing.Point(430, 375);
            this.assignedToCheckBox.Name = "assignedToCheckBox";
            this.assignedToCheckBox.Size = new System.Drawing.Size(164, 29);
            this.assignedToCheckBox.TabIndex = 17;
            this.assignedToCheckBox.TabStop = false;
            this.assignedToCheckBox.Tag = "AssignedTo";
            this.assignedToCheckBox.Text = "Assigned To";
            this.assignedToCheckBox.UseVisualStyleBackColor = true;
            // 
            // assignedToComboBox
            // 
            this.assignedToComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.assignedToComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.assignedToComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.assignedToComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.assignedToComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.assignedToComboBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.assignedToComboBox.FormattingEnabled = true;
            this.assignedToComboBox.Items.AddRange(new object[] {
            "Name",
            "ID"});
            this.assignedToComboBox.Location = new System.Drawing.Point(600, 373);
            this.assignedToComboBox.Name = "assignedToComboBox";
            this.assignedToComboBox.Size = new System.Drawing.Size(149, 33);
            this.assignedToComboBox.TabIndex = 0;
            this.assignedToComboBox.TabStop = false;
            // 
            // companyNameCheckBox
            // 
            this.companyNameCheckBox.AutoSize = true;
            this.companyNameCheckBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.companyNameCheckBox.Location = new System.Drawing.Point(43, 195);
            this.companyNameCheckBox.Name = "companyNameCheckBox";
            this.companyNameCheckBox.Size = new System.Drawing.Size(197, 29);
            this.companyNameCheckBox.TabIndex = 1;
            this.companyNameCheckBox.TabStop = false;
            this.companyNameCheckBox.Tag = "Vendor";
            this.companyNameCheckBox.Text = "Company Name";
            this.companyNameCheckBox.UseVisualStyleBackColor = true;
            // 
            // statusLbl
            // 
            this.statusLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.statusLbl.AutoSize = true;
            this.statusLbl.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.statusLbl.Location = new System.Drawing.Point(36, 643);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(79, 25);
            this.statusLbl.TabIndex = 119;
            this.statusLbl.Text = "Status:";
            this.statusLbl.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label1);
            this.panel1.ForeColor = System.Drawing.Color.Transparent;
            this.panel1.Location = new System.Drawing.Point(30, 602);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(730, 20);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Gray;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Location = new System.Drawing.Point(14, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(702, 3);
            this.label1.TabIndex = 0;
            // 
            // ExportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(790, 703);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusLbl);
            this.Controls.Add(this.companyNameCheckBox);
            this.Controls.Add(this.assignedToComboBox);
            this.Controls.Add(this.noteCheckBox);
            this.Controls.Add(this.displayColorCheckBox);
            this.Controls.Add(this.itemsAttachedCheckBox);
            this.Controls.Add(this.assignedToCheckBox);
            this.Controls.Add(this.fileSizeCheckBox);
            this.Controls.Add(this.fileMIMECheckBox);
            this.Controls.Add(this.fileURLCheckBox);
            this.Controls.Add(this.certusFileIDCheckBox);
            this.Controls.Add(this.fileNameCheckBox);
            this.Controls.Add(this.statusCheckBox);
            this.Controls.Add(this.subjectLineCheckBox);
            this.Controls.Add(this.emailFromCheckBox);
            this.Controls.Add(this.presetsComboBox);
            this.Controls.Add(this.presetsLbl);
            this.Controls.Add(this.dividerPanel);
            this.Controls.Add(this.fieldsLbl);
            this.Controls.Add(this.complianceAnalystCheckBox);
            this.Controls.Add(this.clearBtn);
            this.Controls.Add(this.emailDateCheckBox);
            this.Controls.Add(this.workflowAnalystCheckBox);
            this.Controls.Add(this.certificateDateCheckBox);
            this.Controls.Add(this.compliantCheckBox);
            this.Controls.Add(this.activeCheckBox);
            this.Controls.Add(this.contractIDCheckBox);
            this.Controls.Add(this.documentWorkflowItemIDCheckBox);
            this.Controls.Add(this.exportBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExportForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Export Options";
            this.dividerPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox complianceAnalystCheckBox;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.CheckBox emailDateCheckBox;
        private System.Windows.Forms.CheckBox workflowAnalystCheckBox;
        private System.Windows.Forms.CheckBox certificateDateCheckBox;
        private System.Windows.Forms.CheckBox compliantCheckBox;
        private System.Windows.Forms.CheckBox activeCheckBox;
        private System.Windows.Forms.CheckBox contractIDCheckBox;
        private System.Windows.Forms.CheckBox documentWorkflowItemIDCheckBox;
        private System.Windows.Forms.Button exportBtn;
        private System.Windows.Forms.Label fieldsLbl;
        private System.Windows.Forms.Panel dividerPanel;
        private System.Windows.Forms.Label dividerLbl;
        private System.Windows.Forms.Label presetsLbl;
        private System.Windows.Forms.ComboBox presetsComboBox;
        private System.Windows.Forms.CheckBox subjectLineCheckBox;
        private System.Windows.Forms.CheckBox emailFromCheckBox;
        private System.Windows.Forms.CheckBox fileSizeCheckBox;
        private System.Windows.Forms.CheckBox fileMIMECheckBox;
        private System.Windows.Forms.CheckBox fileURLCheckBox;
        private System.Windows.Forms.CheckBox certusFileIDCheckBox;
        private System.Windows.Forms.CheckBox fileNameCheckBox;
        private System.Windows.Forms.CheckBox statusCheckBox;
        private System.Windows.Forms.CheckBox noteCheckBox;
        private System.Windows.Forms.CheckBox displayColorCheckBox;
        private System.Windows.Forms.CheckBox itemsAttachedCheckBox;
        private System.Windows.Forms.CheckBox assignedToCheckBox;
        private System.Windows.Forms.ComboBox assignedToComboBox;
        private System.Windows.Forms.CheckBox companyNameCheckBox;
        private System.Windows.Forms.Label statusLbl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}