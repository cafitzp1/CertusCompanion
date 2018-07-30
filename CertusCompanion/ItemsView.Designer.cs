namespace CertusCompanion
{
    partial class ItemsView
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
            this.components = new System.ComponentModel.Container();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.searchTbx = new CertusCompanion.PlaceHolderTextBox();
            this.clearBtn = new System.Windows.Forms.Button();
            this.highlightBtn = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.btnsPanel = new System.Windows.Forms.Panel();
            this.changeColorCheckBox = new System.Windows.Forms.CheckBox();
            this.noteLbl = new System.Windows.Forms.Label();
            this.statusLbl = new System.Windows.Forms.Label();
            this.notePanel = new System.Windows.Forms.Panel();
            this.notePanelBtn2 = new System.Windows.Forms.Button();
            this.notePanelTbx = new System.Windows.Forms.TextBox();
            this.notePanelBtn1 = new System.Windows.Forms.Button();
            this.statusComboBox = new System.Windows.Forms.ComboBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.exportBtn = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.exitButton = new System.Windows.Forms.Button();
            this.headerLabel = new System.Windows.Forms.Label();
            this.borderPanel = new CertusCompanion.BorderPanel();
            this.viewColorsCheckBox = new System.Windows.Forms.CheckBox();
            this.footerPanel = new System.Windows.Forms.Panel();
            this.toolStripStatusLabel = new System.Windows.Forms.Label();
            this.itemsListView = new CertusCompanion.ListViewNF();
            this.viewColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.viewColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.viewColumnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.viewColumnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.viewColumnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.viewColumnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.viewColumnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.searchPanel.SuspendLayout();
            this.btnsPanel.SuspendLayout();
            this.notePanel.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.borderPanel.SuspendLayout();
            this.footerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchPanel
            // 
            this.searchPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.searchPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchPanel.Controls.Add(this.searchTbx);
            this.searchPanel.Controls.Add(this.clearBtn);
            this.searchPanel.Controls.Add(this.highlightBtn);
            this.searchPanel.Location = new System.Drawing.Point(1253, 6);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(273, 31);
            this.searchPanel.TabIndex = 12;
            // 
            // searchTbx
            // 
            this.searchTbx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.searchTbx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchTbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F);
            this.searchTbx.ForeColor = System.Drawing.Color.Gray;
            this.searchTbx.Location = new System.Drawing.Point(33, 2);
            this.searchTbx.Name = "searchTbx";
            this.searchTbx.PlaceHolderText = null;
            this.searchTbx.Size = new System.Drawing.Size(201, 24);
            this.searchTbx.TabIndex = 2;
            this.searchTbx.Text = "Search Item";
            this.searchTbx.TextChanged += new System.EventHandler(this.searchTbx_TextChanged);
            this.searchTbx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchTbx_KeyDown);
            // 
            // clearBtn
            // 
            this.clearBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.clearBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.clearBtn.ImageIndex = 0;
            this.clearBtn.Location = new System.Drawing.Point(236, -3);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(35, 35);
            this.clearBtn.TabIndex = 12;
            this.clearBtn.UseVisualStyleBackColor = false;
            // 
            // highlightBtn
            // 
            this.highlightBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.highlightBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.highlightBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.highlightBtn.ImageIndex = 0;
            this.highlightBtn.Location = new System.Drawing.Point(-4, -3);
            this.highlightBtn.Name = "highlightBtn";
            this.highlightBtn.Size = new System.Drawing.Size(35, 35);
            this.highlightBtn.TabIndex = 9;
            this.highlightBtn.UseVisualStyleBackColor = false;
            this.highlightBtn.Click += new System.EventHandler(this.searchHighlightBtn_Click);
            // 
            // timer
            // 
            this.timer.Interval = 10000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // btnsPanel
            // 
            this.btnsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnsPanel.Controls.Add(this.changeColorCheckBox);
            this.btnsPanel.Controls.Add(this.noteLbl);
            this.btnsPanel.Controls.Add(this.statusLbl);
            this.btnsPanel.Controls.Add(this.notePanel);
            this.btnsPanel.Controls.Add(this.statusComboBox);
            this.btnsPanel.Controls.Add(this.saveBtn);
            this.btnsPanel.Controls.Add(this.exportBtn);
            this.btnsPanel.Location = new System.Drawing.Point(12, 793);
            this.btnsPanel.Name = "btnsPanel";
            this.btnsPanel.Size = new System.Drawing.Size(1576, 58);
            this.btnsPanel.TabIndex = 16;
            // 
            // changeColorCheckBox
            // 
            this.changeColorCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.changeColorCheckBox.AutoSize = true;
            this.changeColorCheckBox.Checked = true;
            this.changeColorCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.changeColorCheckBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.changeColorCheckBox.Location = new System.Drawing.Point(370, 17);
            this.changeColorCheckBox.Name = "changeColorCheckBox";
            this.changeColorCheckBox.Size = new System.Drawing.Size(176, 29);
            this.changeColorCheckBox.TabIndex = 121;
            this.changeColorCheckBox.Text = "Change Color";
            this.changeColorCheckBox.UseVisualStyleBackColor = true;
            // 
            // noteLbl
            // 
            this.noteLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.noteLbl.AutoSize = true;
            this.noteLbl.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.noteLbl.Location = new System.Drawing.Point(581, 18);
            this.noteLbl.Name = "noteLbl";
            this.noteLbl.Size = new System.Drawing.Size(63, 25);
            this.noteLbl.TabIndex = 120;
            this.noteLbl.Text = "Note:";
            // 
            // statusLbl
            // 
            this.statusLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.statusLbl.AutoSize = true;
            this.statusLbl.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.statusLbl.Location = new System.Drawing.Point(37, 18);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(79, 25);
            this.statusLbl.TabIndex = 119;
            this.statusLbl.Text = "Status:";
            // 
            // notePanel
            // 
            this.notePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.notePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.notePanel.Controls.Add(this.notePanelBtn2);
            this.notePanel.Controls.Add(this.notePanelTbx);
            this.notePanel.Controls.Add(this.notePanelBtn1);
            this.notePanel.Location = new System.Drawing.Point(651, 15);
            this.notePanel.Name = "notePanel";
            this.notePanel.Size = new System.Drawing.Size(564, 31);
            this.notePanel.TabIndex = 118;
            // 
            // notePanelBtn2
            // 
            this.notePanelBtn2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.notePanelBtn2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.notePanelBtn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.notePanelBtn2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.notePanelBtn2.Location = new System.Drawing.Point(529, -2);
            this.notePanelBtn2.Name = "notePanelBtn2";
            this.notePanelBtn2.Size = new System.Drawing.Size(35, 35);
            this.notePanelBtn2.TabIndex = 10;
            this.notePanelBtn2.UseVisualStyleBackColor = false;
            // 
            // notePanelTbx
            // 
            this.notePanelTbx.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.notePanelTbx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.notePanelTbx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.notePanelTbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notePanelTbx.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.notePanelTbx.HideSelection = false;
            this.notePanelTbx.Location = new System.Drawing.Point(33, 2);
            this.notePanelTbx.Name = "notePanelTbx";
            this.notePanelTbx.Size = new System.Drawing.Size(498, 24);
            this.notePanelTbx.TabIndex = 1;
            // 
            // notePanelBtn1
            // 
            this.notePanelBtn1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.notePanelBtn1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.notePanelBtn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.notePanelBtn1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.notePanelBtn1.Location = new System.Drawing.Point(-2, -2);
            this.notePanelBtn1.Name = "notePanelBtn1";
            this.notePanelBtn1.Size = new System.Drawing.Size(35, 35);
            this.notePanelBtn1.TabIndex = 9;
            this.notePanelBtn1.UseVisualStyleBackColor = false;
            // 
            // statusComboBox
            // 
            this.statusComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.statusComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.statusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statusComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.statusComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusComboBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.statusComboBox.FormattingEnabled = true;
            this.statusComboBox.Items.AddRange(new object[] {
            "Email Recevied",
            "Documentation Analyst",
            "Compliance Analyst",
            "Completed",
            "Trash"});
            this.statusComboBox.Location = new System.Drawing.Point(122, 13);
            this.statusComboBox.Name = "statusComboBox";
            this.statusComboBox.Size = new System.Drawing.Size(195, 33);
            this.statusComboBox.TabIndex = 117;
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.saveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.saveBtn.Location = new System.Drawing.Point(1318, 11);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(100, 35);
            this.saveBtn.TabIndex = 17;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = false;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // exportBtn
            // 
            this.exportBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exportBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.exportBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exportBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.exportBtn.Location = new System.Drawing.Point(1433, 11);
            this.exportBtn.Name = "exportBtn";
            this.exportBtn.Size = new System.Drawing.Size(100, 35);
            this.exportBtn.TabIndex = 16;
            this.exportBtn.Text = "Export";
            this.exportBtn.UseVisualStyleBackColor = false;
            this.exportBtn.Click += new System.EventHandler(this.exportBtn_Click);
            // 
            // headerPanel
            // 
            this.headerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.headerPanel.Controls.Add(this.exitButton);
            this.headerPanel.Controls.Add(this.headerLabel);
            this.headerPanel.Controls.Add(this.searchPanel);
            this.headerPanel.Location = new System.Drawing.Point(2, 1);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1596, 42);
            this.headerPanel.TabIndex = 17;
            // 
            // exitButton
            // 
            this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.exitButton.BackgroundImage = global::CertusCompanion.Properties.Resources.icons8_close_window_48__2_;
            this.exitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.exitButton.FlatAppearance.BorderSize = 0;
            this.exitButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.exitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.exitButton.Location = new System.Drawing.Point(1554, 0);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(41, 41);
            this.exitButton.TabIndex = 18;
            this.exitButton.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // headerLabel
            // 
            this.headerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLabel.ForeColor = System.Drawing.Color.DimGray;
            this.headerLabel.Location = new System.Drawing.Point(21, 7);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(118, 29);
            this.headerLabel.TabIndex = 2;
            this.headerLabel.Text = "Item View";
            this.headerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // borderPanel
            // 
            this.borderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.borderPanel.Controls.Add(this.viewColorsCheckBox);
            this.borderPanel.Controls.Add(this.footerPanel);
            this.borderPanel.Controls.Add(this.itemsListView);
            this.borderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.borderPanel.Location = new System.Drawing.Point(0, 0);
            this.borderPanel.Name = "borderPanel";
            this.borderPanel.Size = new System.Drawing.Size(1600, 900);
            this.borderPanel.TabIndex = 18;
            // 
            // viewColorsCheckBox
            // 
            this.viewColorsCheckBox.AutoSize = true;
            this.viewColorsCheckBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.viewColorsCheckBox.Location = new System.Drawing.Point(54, 57);
            this.viewColorsCheckBox.Name = "viewColorsCheckBox";
            this.viewColorsCheckBox.Size = new System.Drawing.Size(158, 29);
            this.viewColorsCheckBox.TabIndex = 124;
            this.viewColorsCheckBox.Text = "View Colors";
            this.viewColorsCheckBox.UseVisualStyleBackColor = true;
            this.viewColorsCheckBox.Visible = false;
            this.viewColorsCheckBox.CheckedChanged += new System.EventHandler(this.viewColorsCheckBox_CheckedChanged);
            // 
            // footerPanel
            // 
            this.footerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.footerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.footerPanel.Controls.Add(this.toolStripStatusLabel);
            this.footerPanel.Location = new System.Drawing.Point(2, 853);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Size = new System.Drawing.Size(1596, 42);
            this.footerPanel.TabIndex = 18;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStripStatusLabel.AutoSize = true;
            this.toolStripStatusLabel.ForeColor = System.Drawing.Color.DimGray;
            this.toolStripStatusLabel.Location = new System.Drawing.Point(22, 10);
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(30, 25);
            this.toolStripStatusLabel.TabIndex = 2;
            this.toolStripStatusLabel.Text = "   ";
            this.toolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // itemsListView
            // 
            this.itemsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemsListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.itemsListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.itemsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.viewColumnHeader1,
            this.viewColumnHeader2,
            this.viewColumnHeader3,
            this.viewColumnHeader4,
            this.viewColumnHeader5,
            this.viewColumnHeader6,
            this.viewColumnHeader7});
            this.itemsListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemsListView.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.itemsListView.FullRowSelect = true;
            this.itemsListView.GridLines = true;
            this.itemsListView.HideSelection = false;
            this.itemsListView.LabelWrap = false;
            this.itemsListView.Location = new System.Drawing.Point(55, 99);
            this.itemsListView.MultiSelect = false;
            this.itemsListView.Name = "itemsListView";
            this.itemsListView.OwnerDraw = true;
            this.itemsListView.Size = new System.Drawing.Size(1490, 678);
            this.itemsListView.TabIndex = 2;
            this.itemsListView.UseCompatibleStateImageBehavior = false;
            this.itemsListView.View = System.Windows.Forms.View.Details;
            this.itemsListView.VirtualListSize = 100000;
            this.itemsListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.itemsListView_ColumnClick);
            this.itemsListView.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.itemsView_DrawColumnHeader);
            this.itemsListView.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.itemsView_DrawItem);
            this.itemsListView.SelectedIndexChanged += new System.EventHandler(this.itemsListView_SelectedIndexChanged);
            this.itemsListView.VisibleChanged += new System.EventHandler(this.itemsListView_VisibleChanged);
            this.itemsListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.itemsListView_KeyDown);
            this.itemsListView.Resize += new System.EventHandler(this.itemsView_Resize);
            // 
            // viewColumnHeader1
            // 
            this.viewColumnHeader1.Text = "";
            this.viewColumnHeader1.Width = 200;
            // 
            // viewColumnHeader2
            // 
            this.viewColumnHeader2.Text = "";
            this.viewColumnHeader2.Width = 200;
            // 
            // viewColumnHeader3
            // 
            this.viewColumnHeader3.Text = "";
            this.viewColumnHeader3.Width = 200;
            // 
            // viewColumnHeader4
            // 
            this.viewColumnHeader4.Text = "";
            this.viewColumnHeader4.Width = 200;
            // 
            // viewColumnHeader5
            // 
            this.viewColumnHeader5.Text = "";
            this.viewColumnHeader5.Width = 200;
            // 
            // viewColumnHeader6
            // 
            this.viewColumnHeader6.Text = "";
            this.viewColumnHeader6.Width = 200;
            // 
            // viewColumnHeader7
            // 
            this.viewColumnHeader7.Text = "";
            this.viewColumnHeader7.Width = 200;
            // 
            // ItemsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(1600, 900);
            this.Controls.Add(this.headerPanel);
            this.Controls.Add(this.btnsPanel);
            this.Controls.Add(this.borderPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ItemsView";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Items View";
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.btnsPanel.ResumeLayout(false);
            this.btnsPanel.PerformLayout();
            this.notePanel.ResumeLayout(false);
            this.notePanel.PerformLayout();
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.borderPanel.ResumeLayout(false);
            this.borderPanel.PerformLayout();
            this.footerPanel.ResumeLayout(false);
            this.footerPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel searchPanel;
        private PlaceHolderTextBox searchTbx;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.Button highlightBtn;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Panel btnsPanel;
        private System.Windows.Forms.Button exportBtn;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.ComboBox statusComboBox;
        private System.Windows.Forms.CheckBox changeColorCheckBox;
        private System.Windows.Forms.Label noteLbl;
        private System.Windows.Forms.Label statusLbl;
        private System.Windows.Forms.Panel notePanel;
        private System.Windows.Forms.Button notePanelBtn2;
        private System.Windows.Forms.TextBox notePanelTbx;
        private System.Windows.Forms.Button notePanelBtn1;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.Button exitButton;
        private BorderPanel borderPanel;
        private System.Windows.Forms.Panel footerPanel;
        private System.Windows.Forms.Label toolStripStatusLabel;
        private System.Windows.Forms.CheckBox viewColorsCheckBox;
        private ListViewNF itemsListView;
        private System.Windows.Forms.ColumnHeader viewColumnHeader1;
        private System.Windows.Forms.ColumnHeader viewColumnHeader2;
        private System.Windows.Forms.ColumnHeader viewColumnHeader3;
        private System.Windows.Forms.ColumnHeader viewColumnHeader4;
        private System.Windows.Forms.ColumnHeader viewColumnHeader5;
        private System.Windows.Forms.ColumnHeader viewColumnHeader6;
        private System.Windows.Forms.ColumnHeader viewColumnHeader7;
    }
}