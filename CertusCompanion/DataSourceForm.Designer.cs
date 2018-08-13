namespace CertusCompanion
{
    partial class DataSourceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataSourceForm));
            this.cancelBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.sourcesLbx = new System.Windows.Forms.ListBox();
            this.removeSourceBtn = new System.Windows.Forms.Button();
            this.addSourceBtn = new System.Windows.Forms.Button();
            this.sourcesLbl = new System.Windows.Forms.Label();
            this.itemsLbl = new System.Windows.Forms.Label();
            this.searchTbxActiveBorder = new System.Windows.Forms.Panel();
            this.searchTbxInactiveBorder = new System.Windows.Forms.Panel();
            this.searchTbx = new System.Windows.Forms.TextBox();
            this.removeItemBtn = new System.Windows.Forms.Button();
            this.addItemBtn = new System.Windows.Forms.Button();
            this.itemsLbx = new System.Windows.Forms.ListBox();
            this.itemsPanel = new System.Windows.Forms.Panel();
            this.tbxContainerSplitterPanel = new System.Windows.Forms.Panel();
            this.tbxPanel2 = new System.Windows.Forms.Panel();
            this.bindedPanel = new System.Windows.Forms.Panel();
            this.bindedTbx = new System.Windows.Forms.TextBox();
            this.bindedComboBox = new System.Windows.Forms.ComboBox();
            this.itemsTbxPanel = new System.Windows.Forms.Panel();
            this.itemsTbx = new System.Windows.Forms.TextBox();
            this.itemsMoreBtn = new System.Windows.Forms.Button();
            this.lastUpdatedTbx = new System.Windows.Forms.TextBox();
            this.nameTbx = new System.Windows.Forms.TextBox();
            this.typePanel = new System.Windows.Forms.Panel();
            this.typeTbx = new System.Windows.Forms.TextBox();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tbxPanel1 = new System.Windows.Forms.Panel();
            this.nameFocusBtn = new System.Windows.Forms.Button();
            this.typeFocusBtn = new System.Windows.Forms.Button();
            this.dateCreatedFocusBtn = new System.Windows.Forms.Button();
            this.lastUpdatedFocusBtn = new System.Windows.Forms.Button();
            this.itemsFocusBtn = new System.Windows.Forms.Button();
            this.itemsListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sortNumericallyBtn = new System.Windows.Forms.Button();
            this.sortAlphabeticallyBtn = new System.Windows.Forms.Button();
            this.importFromDBBtn = new System.Windows.Forms.Button();
            this.importFromCSVBtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.importDSBtn = new System.Windows.Forms.Button();
            this.buttonDescToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.searchTbxActiveBorder.SuspendLayout();
            this.searchTbxInactiveBorder.SuspendLayout();
            this.itemsPanel.SuspendLayout();
            this.tbxContainerSplitterPanel.SuspendLayout();
            this.tbxPanel2.SuspendLayout();
            this.bindedPanel.SuspendLayout();
            this.itemsTbxPanel.SuspendLayout();
            this.typePanel.SuspendLayout();
            this.tbxPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.cancelBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.cancelBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.cancelBtn.Location = new System.Drawing.Point(452, 371);
            this.cancelBtn.Margin = new System.Windows.Forms.Padding(2);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(50, 18);
            this.cancelBtn.TabIndex = 5;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveBtn.Enabled = false;
            this.saveBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.saveBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.saveBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.saveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.saveBtn.Location = new System.Drawing.Point(395, 371);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(2);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(50, 18);
            this.saveBtn.TabIndex = 0;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // sourcesLbx
            // 
            this.sourcesLbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.sourcesLbx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.sourcesLbx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sourcesLbx.ForeColor = System.Drawing.SystemColors.Control;
            this.sourcesLbx.FormattingEnabled = true;
            this.sourcesLbx.Location = new System.Drawing.Point(0, 0);
            this.sourcesLbx.Name = "sourcesLbx";
            this.sourcesLbx.Size = new System.Drawing.Size(166, 247);
            this.sourcesLbx.TabIndex = 0;
            this.sourcesLbx.TabStop = false;
            this.sourcesLbx.SelectedIndexChanged += new System.EventHandler(this.sourcesLbx_SelectedIndexChanged);
            // 
            // removeSourceBtn
            // 
            this.removeSourceBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.removeSourceBtn.Enabled = false;
            this.removeSourceBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.removeSourceBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.removeSourceBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.removeSourceBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeSourceBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeSourceBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.removeSourceBtn.Location = new System.Drawing.Point(79, 290);
            this.removeSourceBtn.Margin = new System.Windows.Forms.Padding(2);
            this.removeSourceBtn.Name = "removeSourceBtn";
            this.removeSourceBtn.Size = new System.Drawing.Size(50, 18);
            this.removeSourceBtn.TabIndex = 2;
            this.removeSourceBtn.Text = "&Remove";
            this.removeSourceBtn.UseVisualStyleBackColor = true;
            this.removeSourceBtn.Click += new System.EventHandler(this.removeSourceBtn_Click);
            // 
            // addSourceBtn
            // 
            this.addSourceBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addSourceBtn.Enabled = false;
            this.addSourceBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.addSourceBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.addSourceBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.addSourceBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addSourceBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addSourceBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.addSourceBtn.Location = new System.Drawing.Point(22, 290);
            this.addSourceBtn.Margin = new System.Windows.Forms.Padding(2);
            this.addSourceBtn.Name = "addSourceBtn";
            this.addSourceBtn.Size = new System.Drawing.Size(50, 18);
            this.addSourceBtn.TabIndex = 1;
            this.addSourceBtn.Text = "&Add";
            this.addSourceBtn.UseVisualStyleBackColor = true;
            this.addSourceBtn.Click += new System.EventHandler(this.addSourceBtn_Click);
            // 
            // sourcesLbl
            // 
            this.sourcesLbl.AutoSize = true;
            this.sourcesLbl.ForeColor = System.Drawing.SystemColors.Control;
            this.sourcesLbl.Location = new System.Drawing.Point(20, 15);
            this.sourcesLbl.Name = "sourcesLbl";
            this.sourcesLbl.Size = new System.Drawing.Size(49, 13);
            this.sourcesLbl.TabIndex = 0;
            this.sourcesLbl.Text = "&Sources:";
            // 
            // itemsLbl
            // 
            this.itemsLbl.AutoSize = true;
            this.itemsLbl.ForeColor = System.Drawing.SystemColors.Control;
            this.itemsLbl.Location = new System.Drawing.Point(220, 15);
            this.itemsLbl.Name = "itemsLbl";
            this.itemsLbl.Size = new System.Drawing.Size(35, 13);
            this.itemsLbl.TabIndex = 0;
            this.itemsLbl.Text = "&Items:";
            // 
            // searchTbxActiveBorder
            // 
            this.searchTbxActiveBorder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchTbxActiveBorder.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.searchTbxActiveBorder.Controls.Add(this.searchTbxInactiveBorder);
            this.searchTbxActiveBorder.Location = new System.Drawing.Point(345, 35);
            this.searchTbxActiveBorder.Name = "searchTbxActiveBorder";
            this.searchTbxActiveBorder.Size = new System.Drawing.Size(157, 19);
            this.searchTbxActiveBorder.TabIndex = 0;
            // 
            // searchTbxInactiveBorder
            // 
            this.searchTbxInactiveBorder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchTbxInactiveBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.searchTbxInactiveBorder.Controls.Add(this.searchTbx);
            this.searchTbxInactiveBorder.Location = new System.Drawing.Point(1, 1);
            this.searchTbxInactiveBorder.Name = "searchTbxInactiveBorder";
            this.searchTbxInactiveBorder.Size = new System.Drawing.Size(155, 17);
            this.searchTbxInactiveBorder.TabIndex = 0;
            // 
            // searchTbx
            // 
            this.searchTbx.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchTbx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.searchTbx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchTbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchTbx.ForeColor = System.Drawing.Color.Gray;
            this.searchTbx.Location = new System.Drawing.Point(4, 2);
            this.searchTbx.Margin = new System.Windows.Forms.Padding(15);
            this.searchTbx.Name = "searchTbx";
            this.searchTbx.Size = new System.Drawing.Size(147, 13);
            this.searchTbx.TabIndex = 0;
            this.searchTbx.TabStop = false;
            this.searchTbx.Text = "Search Items (Ctrl+F)";
            this.searchTbx.TextChanged += new System.EventHandler(this.searchTbx_TextChanged);
            this.searchTbx.Enter += new System.EventHandler(this.searchTbx_Enter);
            this.searchTbx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchTbx_KeyDown);
            this.searchTbx.Leave += new System.EventHandler(this.searchTbx_Leave);
            this.searchTbx.MouseLeave += new System.EventHandler(this.searchTbx_MouseLeave);
            this.searchTbx.MouseHover += new System.EventHandler(this.searchTbx_MouseHover);
            this.searchTbx.MouseMove += new System.Windows.Forms.MouseEventHandler(this.searchTbx_MouseMove);
            // 
            // removeItemBtn
            // 
            this.removeItemBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.removeItemBtn.Enabled = false;
            this.removeItemBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.removeItemBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.removeItemBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.removeItemBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeItemBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeItemBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.removeItemBtn.Location = new System.Drawing.Point(279, 318);
            this.removeItemBtn.Margin = new System.Windows.Forms.Padding(2);
            this.removeItemBtn.Name = "removeItemBtn";
            this.removeItemBtn.Size = new System.Drawing.Size(50, 18);
            this.removeItemBtn.TabIndex = 4;
            this.removeItemBtn.Text = "&Remove";
            this.removeItemBtn.UseVisualStyleBackColor = true;
            // 
            // addItemBtn
            // 
            this.addItemBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addItemBtn.Enabled = false;
            this.addItemBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.addItemBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.addItemBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.addItemBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addItemBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addItemBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.addItemBtn.Location = new System.Drawing.Point(222, 318);
            this.addItemBtn.Margin = new System.Windows.Forms.Padding(2);
            this.addItemBtn.Name = "addItemBtn";
            this.addItemBtn.Size = new System.Drawing.Size(50, 18);
            this.addItemBtn.TabIndex = 3;
            this.addItemBtn.Text = "&Add";
            this.addItemBtn.UseVisualStyleBackColor = true;
            // 
            // itemsLbx
            // 
            this.itemsLbx.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemsLbx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.itemsLbx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.itemsLbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemsLbx.ForeColor = System.Drawing.SystemColors.Control;
            this.itemsLbx.FormattingEnabled = true;
            this.itemsLbx.Location = new System.Drawing.Point(83, 349);
            this.itemsLbx.Name = "itemsLbx";
            this.itemsLbx.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.itemsLbx.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.itemsLbx.Size = new System.Drawing.Size(107, 39);
            this.itemsLbx.TabIndex = 0;
            this.itemsLbx.TabStop = false;
            this.itemsLbx.Visible = false;
            // 
            // itemsPanel
            // 
            this.itemsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.itemsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.itemsPanel.Controls.Add(this.tbxContainerSplitterPanel);
            this.itemsPanel.Controls.Add(this.itemsListView);
            this.itemsPanel.Location = new System.Drawing.Point(222, 58);
            this.itemsPanel.Name = "itemsPanel";
            this.itemsPanel.Size = new System.Drawing.Size(280, 254);
            this.itemsPanel.TabIndex = 0;
            // 
            // tbxContainerSplitterPanel
            // 
            this.tbxContainerSplitterPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxContainerSplitterPanel.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.tbxContainerSplitterPanel.Controls.Add(this.tbxPanel2);
            this.tbxContainerSplitterPanel.Controls.Add(this.splitter1);
            this.tbxContainerSplitterPanel.Controls.Add(this.tbxPanel1);
            this.tbxContainerSplitterPanel.Location = new System.Drawing.Point(0, 0);
            this.tbxContainerSplitterPanel.Name = "tbxContainerSplitterPanel";
            this.tbxContainerSplitterPanel.Size = new System.Drawing.Size(278, 96);
            this.tbxContainerSplitterPanel.TabIndex = 0;
            // 
            // tbxPanel2
            // 
            this.tbxPanel2.Controls.Add(this.bindedPanel);
            this.tbxPanel2.Controls.Add(this.itemsTbxPanel);
            this.tbxPanel2.Controls.Add(this.lastUpdatedTbx);
            this.tbxPanel2.Controls.Add(this.nameTbx);
            this.tbxPanel2.Controls.Add(this.typePanel);
            this.tbxPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxPanel2.Location = new System.Drawing.Point(123, 0);
            this.tbxPanel2.Name = "tbxPanel2";
            this.tbxPanel2.Size = new System.Drawing.Size(155, 96);
            this.tbxPanel2.TabIndex = 0;
            // 
            // bindedPanel
            // 
            this.bindedPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bindedPanel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.bindedPanel.Controls.Add(this.bindedTbx);
            this.bindedPanel.Controls.Add(this.bindedComboBox);
            this.bindedPanel.Location = new System.Drawing.Point(-1, 38);
            this.bindedPanel.Name = "bindedPanel";
            this.bindedPanel.Size = new System.Drawing.Size(156, 18);
            this.bindedPanel.TabIndex = 2;
            // 
            // bindedTbx
            // 
            this.bindedTbx.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bindedTbx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.bindedTbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bindedTbx.ForeColor = System.Drawing.SystemColors.Control;
            this.bindedTbx.Location = new System.Drawing.Point(-1, -1);
            this.bindedTbx.Name = "bindedTbx";
            this.bindedTbx.ReadOnly = true;
            this.bindedTbx.Size = new System.Drawing.Size(139, 20);
            this.bindedTbx.TabIndex = 1;
            this.bindedTbx.TabStop = false;
            this.bindedTbx.Click += new System.EventHandler(this.tbxCmbxTextBox_Click);
            this.bindedTbx.Enter += new System.EventHandler(this.tbxCmbxTextBox_Enter);
            // 
            // bindedComboBox
            // 
            this.bindedComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bindedComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.bindedComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bindedComboBox.DropDownWidth = 70;
            this.bindedComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bindedComboBox.ForeColor = System.Drawing.SystemColors.Control;
            this.bindedComboBox.FormattingEnabled = true;
            this.bindedComboBox.ItemHeight = 13;
            this.bindedComboBox.Items.AddRange(new object[] {
            "",
            "True",
            "False"});
            this.bindedComboBox.Location = new System.Drawing.Point(1, -2);
            this.bindedComboBox.Name = "bindedComboBox";
            this.bindedComboBox.Size = new System.Drawing.Size(155, 21);
            this.bindedComboBox.TabIndex = 0;
            this.bindedComboBox.TabStop = false;
            this.bindedComboBox.SelectedIndexChanged += new System.EventHandler(this.tbxCmbxComboBox_SelectedIndexChanged);
            this.bindedComboBox.Leave += new System.EventHandler(this.tbxCmbxComboBox_Leave);
            // 
            // itemsTbxPanel
            // 
            this.itemsTbxPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemsTbxPanel.BackColor = System.Drawing.Color.Red;
            this.itemsTbxPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.itemsTbxPanel.Controls.Add(this.itemsTbx);
            this.itemsTbxPanel.Controls.Add(this.itemsMoreBtn);
            this.itemsTbxPanel.Location = new System.Drawing.Point(-1, 75);
            this.itemsTbxPanel.Name = "itemsTbxPanel";
            this.itemsTbxPanel.Size = new System.Drawing.Size(157, 21);
            this.itemsTbxPanel.TabIndex = 1;
            // 
            // itemsTbx
            // 
            this.itemsTbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemsTbx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.itemsTbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.itemsTbx.ForeColor = System.Drawing.SystemColors.Control;
            this.itemsTbx.Location = new System.Drawing.Point(-1, -1);
            this.itemsTbx.Multiline = true;
            this.itemsTbx.Name = "itemsTbx";
            this.itemsTbx.ReadOnly = true;
            this.itemsTbx.Size = new System.Drawing.Size(139, 21);
            this.itemsTbx.TabIndex = 0;
            this.itemsTbx.TabStop = false;
            // 
            // itemsMoreBtn
            // 
            this.itemsMoreBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemsMoreBtn.BackColor = System.Drawing.SystemColors.Menu;
            this.itemsMoreBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("itemsMoreBtn.BackgroundImage")));
            this.itemsMoreBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.itemsMoreBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.itemsMoreBtn.FlatAppearance.BorderSize = 0;
            this.itemsMoreBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Menu;
            this.itemsMoreBtn.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Menu;
            this.itemsMoreBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.itemsMoreBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemsMoreBtn.ForeColor = System.Drawing.Color.DimGray;
            this.itemsMoreBtn.Location = new System.Drawing.Point(137, 0);
            this.itemsMoreBtn.Margin = new System.Windows.Forms.Padding(2);
            this.itemsMoreBtn.Name = "itemsMoreBtn";
            this.itemsMoreBtn.Size = new System.Drawing.Size(18, 19);
            this.itemsMoreBtn.TabIndex = 0;
            this.itemsMoreBtn.TabStop = false;
            this.buttonDescToolTip.SetToolTip(this.itemsMoreBtn, "Expand Items (Not recommended for a large amount)");
            this.itemsMoreBtn.UseVisualStyleBackColor = false;
            this.itemsMoreBtn.Click += new System.EventHandler(this.itemsMoreBtn_Click);
            // 
            // lastUpdatedTbx
            // 
            this.lastUpdatedTbx.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lastUpdatedTbx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.lastUpdatedTbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lastUpdatedTbx.ForeColor = System.Drawing.SystemColors.Control;
            this.lastUpdatedTbx.Location = new System.Drawing.Point(-1, 56);
            this.lastUpdatedTbx.Name = "lastUpdatedTbx";
            this.lastUpdatedTbx.ReadOnly = true;
            this.lastUpdatedTbx.Size = new System.Drawing.Size(157, 20);
            this.lastUpdatedTbx.TabIndex = 0;
            this.lastUpdatedTbx.TabStop = false;
            // 
            // nameTbx
            // 
            this.nameTbx.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameTbx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.nameTbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nameTbx.ForeColor = System.Drawing.SystemColors.Control;
            this.nameTbx.Location = new System.Drawing.Point(-1, -1);
            this.nameTbx.Name = "nameTbx";
            this.nameTbx.Size = new System.Drawing.Size(157, 20);
            this.nameTbx.TabIndex = 0;
            this.nameTbx.TabStop = false;
            // 
            // typePanel
            // 
            this.typePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.typePanel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.typePanel.Controls.Add(this.typeTbx);
            this.typePanel.Controls.Add(this.typeComboBox);
            this.typePanel.Location = new System.Drawing.Point(-1, 19);
            this.typePanel.Name = "typePanel";
            this.typePanel.Size = new System.Drawing.Size(156, 18);
            this.typePanel.TabIndex = 0;
            // 
            // typeTbx
            // 
            this.typeTbx.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.typeTbx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.typeTbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.typeTbx.ForeColor = System.Drawing.SystemColors.Control;
            this.typeTbx.Location = new System.Drawing.Point(-1, -1);
            this.typeTbx.Name = "typeTbx";
            this.typeTbx.ReadOnly = true;
            this.typeTbx.Size = new System.Drawing.Size(139, 20);
            this.typeTbx.TabIndex = 0;
            this.typeTbx.TabStop = false;
            this.typeTbx.Click += new System.EventHandler(this.tbxCmbxTextBox_Click);
            this.typeTbx.Enter += new System.EventHandler(this.tbxCmbxTextBox_Enter);
            // 
            // typeComboBox
            // 
            this.typeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.typeComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.typeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeComboBox.DropDownWidth = 70;
            this.typeComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typeComboBox.ForeColor = System.Drawing.SystemColors.Control;
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.ItemHeight = 13;
            this.typeComboBox.Items.AddRange(new object[] {
            "Clients",
            "Companies",
            "Contracts",
            "Analysts",
            "Market Assignments"});
            this.typeComboBox.Location = new System.Drawing.Point(1, -2);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(155, 21);
            this.typeComboBox.TabIndex = 0;
            this.typeComboBox.TabStop = false;
            this.typeComboBox.SelectedIndexChanged += new System.EventHandler(this.tbxCmbxComboBox_SelectedIndexChanged);
            this.typeComboBox.Leave += new System.EventHandler(this.tbxCmbxComboBox_Leave);
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.splitter1.Location = new System.Drawing.Point(122, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1, 96);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // tbxPanel1
            // 
            this.tbxPanel1.Controls.Add(this.nameFocusBtn);
            this.tbxPanel1.Controls.Add(this.typeFocusBtn);
            this.tbxPanel1.Controls.Add(this.dateCreatedFocusBtn);
            this.tbxPanel1.Controls.Add(this.lastUpdatedFocusBtn);
            this.tbxPanel1.Controls.Add(this.itemsFocusBtn);
            this.tbxPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbxPanel1.Location = new System.Drawing.Point(0, 0);
            this.tbxPanel1.Name = "tbxPanel1";
            this.tbxPanel1.Size = new System.Drawing.Size(122, 96);
            this.tbxPanel1.TabIndex = 0;
            // 
            // nameFocusBtn
            // 
            this.nameFocusBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameFocusBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.nameFocusBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.nameFocusBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.nameFocusBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.nameFocusBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nameFocusBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.nameFocusBtn.Location = new System.Drawing.Point(-6, -4);
            this.nameFocusBtn.Name = "nameFocusBtn";
            this.nameFocusBtn.Size = new System.Drawing.Size(130, 23);
            this.nameFocusBtn.TabIndex = 0;
            this.nameFocusBtn.TabStop = false;
            this.nameFocusBtn.Text = "Name";
            this.nameFocusBtn.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.nameFocusBtn.UseVisualStyleBackColor = false;
            // 
            // typeFocusBtn
            // 
            this.typeFocusBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.typeFocusBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.typeFocusBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.typeFocusBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.typeFocusBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.typeFocusBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.typeFocusBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.typeFocusBtn.Location = new System.Drawing.Point(-6, 15);
            this.typeFocusBtn.Name = "typeFocusBtn";
            this.typeFocusBtn.Size = new System.Drawing.Size(130, 23);
            this.typeFocusBtn.TabIndex = 0;
            this.typeFocusBtn.TabStop = false;
            this.typeFocusBtn.Text = "Type";
            this.typeFocusBtn.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.typeFocusBtn.UseVisualStyleBackColor = false;
            // 
            // dateCreatedFocusBtn
            // 
            this.dateCreatedFocusBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateCreatedFocusBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.dateCreatedFocusBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.dateCreatedFocusBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.dateCreatedFocusBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.dateCreatedFocusBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dateCreatedFocusBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.dateCreatedFocusBtn.Location = new System.Drawing.Point(-6, 34);
            this.dateCreatedFocusBtn.Name = "dateCreatedFocusBtn";
            this.dateCreatedFocusBtn.Size = new System.Drawing.Size(130, 23);
            this.dateCreatedFocusBtn.TabIndex = 0;
            this.dateCreatedFocusBtn.TabStop = false;
            this.dateCreatedFocusBtn.Text = "Binded";
            this.dateCreatedFocusBtn.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.dateCreatedFocusBtn.UseVisualStyleBackColor = false;
            // 
            // lastUpdatedFocusBtn
            // 
            this.lastUpdatedFocusBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lastUpdatedFocusBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.lastUpdatedFocusBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.lastUpdatedFocusBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.lastUpdatedFocusBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.lastUpdatedFocusBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lastUpdatedFocusBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.lastUpdatedFocusBtn.Location = new System.Drawing.Point(-6, 53);
            this.lastUpdatedFocusBtn.Name = "lastUpdatedFocusBtn";
            this.lastUpdatedFocusBtn.Size = new System.Drawing.Size(130, 23);
            this.lastUpdatedFocusBtn.TabIndex = 0;
            this.lastUpdatedFocusBtn.TabStop = false;
            this.lastUpdatedFocusBtn.Text = "Last Updated";
            this.lastUpdatedFocusBtn.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lastUpdatedFocusBtn.UseVisualStyleBackColor = false;
            // 
            // itemsFocusBtn
            // 
            this.itemsFocusBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemsFocusBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.itemsFocusBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.itemsFocusBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.itemsFocusBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.itemsFocusBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.itemsFocusBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.itemsFocusBtn.Location = new System.Drawing.Point(-6, 72);
            this.itemsFocusBtn.Name = "itemsFocusBtn";
            this.itemsFocusBtn.Size = new System.Drawing.Size(130, 24);
            this.itemsFocusBtn.TabIndex = 1;
            this.itemsFocusBtn.TabStop = false;
            this.itemsFocusBtn.Text = "Items";
            this.itemsFocusBtn.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.itemsFocusBtn.UseVisualStyleBackColor = false;
            // 
            // itemsListView
            // 
            this.itemsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemsListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.itemsListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.itemsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.itemsListView.ForeColor = System.Drawing.SystemColors.Control;
            this.itemsListView.FullRowSelect = true;
            this.itemsListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.itemsListView.Location = new System.Drawing.Point(0, 96);
            this.itemsListView.Name = "itemsListView";
            this.itemsListView.Size = new System.Drawing.Size(278, 156);
            this.itemsListView.TabIndex = 0;
            this.itemsListView.TabStop = false;
            this.itemsListView.UseCompatibleStateImageBehavior = false;
            this.itemsListView.View = System.Windows.Forms.View.Details;
            this.itemsListView.VirtualListSize = 100;
            this.itemsListView.VirtualMode = true;
            this.itemsListView.Visible = false;
            this.itemsListView.VisibleChanged += new System.EventHandler(this.itemsListView_VisibleChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 278;
            // 
            // sortNumericallyBtn
            // 
            this.sortNumericallyBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.sortNumericallyBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("sortNumericallyBtn.BackgroundImage")));
            this.sortNumericallyBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sortNumericallyBtn.FlatAppearance.BorderSize = 0;
            this.sortNumericallyBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.sortNumericallyBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.sortNumericallyBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sortNumericallyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sortNumericallyBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.sortNumericallyBtn.Location = new System.Drawing.Point(222, 35);
            this.sortNumericallyBtn.Margin = new System.Windows.Forms.Padding(2);
            this.sortNumericallyBtn.Name = "sortNumericallyBtn";
            this.sortNumericallyBtn.Size = new System.Drawing.Size(20, 20);
            this.sortNumericallyBtn.TabIndex = 0;
            this.sortNumericallyBtn.TabStop = false;
            this.buttonDescToolTip.SetToolTip(this.sortNumericallyBtn, "Sort by primary key");
            this.sortNumericallyBtn.UseVisualStyleBackColor = false;
            this.sortNumericallyBtn.Click += new System.EventHandler(this.sortNumericallyBtn_Click);
            // 
            // sortAlphabeticallyBtn
            // 
            this.sortAlphabeticallyBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.sortAlphabeticallyBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("sortAlphabeticallyBtn.BackgroundImage")));
            this.sortAlphabeticallyBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sortAlphabeticallyBtn.FlatAppearance.BorderSize = 0;
            this.sortAlphabeticallyBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.sortAlphabeticallyBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.sortAlphabeticallyBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sortAlphabeticallyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sortAlphabeticallyBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.sortAlphabeticallyBtn.Location = new System.Drawing.Point(246, 35);
            this.sortAlphabeticallyBtn.Margin = new System.Windows.Forms.Padding(2);
            this.sortAlphabeticallyBtn.Name = "sortAlphabeticallyBtn";
            this.sortAlphabeticallyBtn.Size = new System.Drawing.Size(20, 20);
            this.sortAlphabeticallyBtn.TabIndex = 0;
            this.sortAlphabeticallyBtn.TabStop = false;
            this.buttonDescToolTip.SetToolTip(this.sortAlphabeticallyBtn, "Sort alphabetically");
            this.sortAlphabeticallyBtn.UseVisualStyleBackColor = false;
            this.sortAlphabeticallyBtn.Click += new System.EventHandler(this.sortAlphabeticallyBtn_Click);
            // 
            // importFromDBBtn
            // 
            this.importFromDBBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.importFromDBBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.importFromDBBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("importFromDBBtn.BackgroundImage")));
            this.importFromDBBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.importFromDBBtn.Enabled = false;
            this.importFromDBBtn.FlatAppearance.BorderSize = 0;
            this.importFromDBBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.importFromDBBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.importFromDBBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.importFromDBBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importFromDBBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.importFromDBBtn.Location = new System.Drawing.Point(481, 316);
            this.importFromDBBtn.Margin = new System.Windows.Forms.Padding(2);
            this.importFromDBBtn.Name = "importFromDBBtn";
            this.importFromDBBtn.Size = new System.Drawing.Size(20, 20);
            this.importFromDBBtn.TabIndex = 0;
            this.importFromDBBtn.TabStop = false;
            this.buttonDescToolTip.SetToolTip(this.importFromDBBtn, "Import from DB");
            this.importFromDBBtn.UseVisualStyleBackColor = false;
            this.importFromDBBtn.Click += new System.EventHandler(this.importFromDBBtn_Click);
            // 
            // importFromCSVBtn
            // 
            this.importFromCSVBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.importFromCSVBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.importFromCSVBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("importFromCSVBtn.BackgroundImage")));
            this.importFromCSVBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.importFromCSVBtn.Enabled = false;
            this.importFromCSVBtn.FlatAppearance.BorderSize = 0;
            this.importFromCSVBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.importFromCSVBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.importFromCSVBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.importFromCSVBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importFromCSVBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.importFromCSVBtn.Location = new System.Drawing.Point(457, 316);
            this.importFromCSVBtn.Margin = new System.Windows.Forms.Padding(2);
            this.importFromCSVBtn.Name = "importFromCSVBtn";
            this.importFromCSVBtn.Size = new System.Drawing.Size(20, 20);
            this.importFromCSVBtn.TabIndex = 0;
            this.importFromCSVBtn.TabStop = false;
            this.buttonDescToolTip.SetToolTip(this.importFromCSVBtn, "Import from CSV");
            this.importFromCSVBtn.UseVisualStyleBackColor = false;
            this.importFromCSVBtn.Click += new System.EventHandler(this.importFromCSVBtn_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.sourcesLbx);
            this.panel2.Location = new System.Drawing.Point(22, 35);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(168, 249);
            this.panel2.TabIndex = 6;
            // 
            // importDSBtn
            // 
            this.importDSBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.importDSBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.MenuHighlight;
            this.importDSBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.importDSBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.importDSBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.importDSBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importDSBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.importDSBtn.Location = new System.Drawing.Point(23, 371);
            this.importDSBtn.Margin = new System.Windows.Forms.Padding(2);
            this.importDSBtn.Name = "importDSBtn";
            this.importDSBtn.Size = new System.Drawing.Size(50, 18);
            this.importDSBtn.TabIndex = 0;
            this.importDSBtn.TabStop = false;
            this.importDSBtn.Text = "Import DS";
            this.buttonDescToolTip.SetToolTip(this.importDSBtn, "Import a new DataSources file");
            this.importDSBtn.UseVisualStyleBackColor = true;
            this.importDSBtn.Click += new System.EventHandler(this.importDSBtn_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // DataSourceForm
            // 
            this.AcceptButton = this.saveBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(526, 400);
            this.Controls.Add(this.itemsLbx);
            this.Controls.Add(this.importDSBtn);
            this.Controls.Add(this.importFromCSVBtn);
            this.Controls.Add(this.importFromDBBtn);
            this.Controls.Add(this.sortAlphabeticallyBtn);
            this.Controls.Add(this.sortNumericallyBtn);
            this.Controls.Add(this.removeItemBtn);
            this.Controls.Add(this.addItemBtn);
            this.Controls.Add(this.searchTbxActiveBorder);
            this.Controls.Add(this.itemsLbl);
            this.Controls.Add(this.sourcesLbl);
            this.Controls.Add(this.removeSourceBtn);
            this.Controls.Add(this.addSourceBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.itemsPanel);
            this.Controls.Add(this.panel2);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(480, 350);
            this.Name = "DataSourceForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Data Sources";
            this.Load += new System.EventHandler(this.DataSources_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DataSourceForm_KeyDown);
            this.Resize += new System.EventHandler(this.DataSourceForm_Resize);
            this.searchTbxActiveBorder.ResumeLayout(false);
            this.searchTbxInactiveBorder.ResumeLayout(false);
            this.searchTbxInactiveBorder.PerformLayout();
            this.itemsPanel.ResumeLayout(false);
            this.tbxContainerSplitterPanel.ResumeLayout(false);
            this.tbxPanel2.ResumeLayout(false);
            this.tbxPanel2.PerformLayout();
            this.bindedPanel.ResumeLayout(false);
            this.bindedPanel.PerformLayout();
            this.itemsTbxPanel.ResumeLayout(false);
            this.itemsTbxPanel.PerformLayout();
            this.typePanel.ResumeLayout(false);
            this.typePanel.PerformLayout();
            this.tbxPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.ListBox sourcesLbx;
        private System.Windows.Forms.Button removeSourceBtn;
        private System.Windows.Forms.Button addSourceBtn;
        private System.Windows.Forms.Label sourcesLbl;
        private System.Windows.Forms.Label itemsLbl;
        private System.Windows.Forms.Panel searchTbxActiveBorder;
        private System.Windows.Forms.Panel searchTbxInactiveBorder;
        private System.Windows.Forms.TextBox searchTbx;
        private System.Windows.Forms.Button removeItemBtn;
        private System.Windows.Forms.Button addItemBtn;
        private System.Windows.Forms.ListBox itemsLbx;
        private System.Windows.Forms.Panel itemsPanel;
        private System.Windows.Forms.Panel tbxContainerSplitterPanel;
        private System.Windows.Forms.Panel tbxPanel2;
        private System.Windows.Forms.TextBox typeTbx;
        private System.Windows.Forms.TextBox nameTbx;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel tbxPanel1;
        private System.Windows.Forms.Button sortNumericallyBtn;
        private System.Windows.Forms.Button sortAlphabeticallyBtn;
        private System.Windows.Forms.Button importFromDBBtn;
        private System.Windows.Forms.Button importFromCSVBtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox lastUpdatedTbx;
        private System.Windows.Forms.Panel typePanel;
        private System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.Button nameFocusBtn;
        private System.Windows.Forms.Button typeFocusBtn;
        private System.Windows.Forms.Button dateCreatedFocusBtn;
        private System.Windows.Forms.Button lastUpdatedFocusBtn;
        private System.Windows.Forms.Button importDSBtn;
        private System.Windows.Forms.Button itemsFocusBtn;
        private System.Windows.Forms.Panel itemsTbxPanel;
        private System.Windows.Forms.TextBox itemsTbx;
        private System.Windows.Forms.Button itemsMoreBtn;
        private System.Windows.Forms.Panel bindedPanel;
        private System.Windows.Forms.TextBox bindedTbx;
        private System.Windows.Forms.ComboBox bindedComboBox;
        private System.Windows.Forms.ToolTip buttonDescToolTip;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ListView itemsListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}