namespace CertusCompanion
{
    partial class CertusBrowser
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
            this.statusLbl = new System.Windows.Forms.Label();
            this.browserPanel = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.copyLogBtn = new System.Windows.Forms.Button();
            this.clearLogBtn = new System.Windows.Forms.Button();
            this.testBtn = new System.Windows.Forms.Button();
            this.menuBtn = new System.Windows.Forms.Button();
            this.customScript3Btn = new System.Windows.Forms.Button();
            this.customScript2Btn = new System.Windows.Forms.Button();
            this.customScript1Btn = new System.Windows.Forms.Button();
            this.viewItemsBtn = new System.Windows.Forms.Button();
            this.distributeItemsScriptBtn = new System.Windows.Forms.Button();
            this.completeItemsScriptBtn = new System.Windows.Forms.Button();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.openCompanyBtn = new System.Windows.Forms.Button();
            this.openCertificateBtn = new System.Windows.Forms.Button();
            this.authenticateBtn = new System.Windows.Forms.Button();
            this.homePageBtn = new System.Windows.Forms.Button();
            this.previousBtn = new System.Windows.Forms.Button();
            this.nextBtn = new System.Windows.Forms.Button();
            this.dividerPanel = new System.Windows.Forms.Panel();
            this.dividerLbl = new System.Windows.Forms.Label();
            this.navBarPanel = new System.Windows.Forms.Panel();
            this.navBarSearchBtn = new System.Windows.Forms.Button();
            this.navigationComboBox = new System.Windows.Forms.ComboBox();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.scriptOptionsPanel = new System.Windows.Forms.Panel();
            this.intputTbx = new System.Windows.Forms.TextBox();
            this.consoleInputPanel = new System.Windows.Forms.Panel();
            this.browserPanelContainer = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.consoleOutputPanel = new System.Windows.Forms.Panel();
            this.outputTbx = new System.Windows.Forms.TextBox();
            this.consoleOutputOptionsPanel = new System.Windows.Forms.Panel();
            this.consoleSplitter = new System.Windows.Forms.Splitter();
            this.distributeItemsBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.completeItemsBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.certInputContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.certInputContextMenuTbx = new System.Windows.Forms.ToolStripTextBox();
            this.statusLblTimer = new System.Windows.Forms.Timer(this.components);
            this.companyInputContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.companyInputContextMenuStripTbx = new System.Windows.Forms.ToolStripTextBox();
            this.customScript1BackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.customScript2BackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.customScript3BackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.browserSettingsContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showConsoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.browserPanel.SuspendLayout();
            this.dividerPanel.SuspendLayout();
            this.navBarPanel.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.scriptOptionsPanel.SuspendLayout();
            this.consoleInputPanel.SuspendLayout();
            this.browserPanelContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.consoleOutputPanel.SuspendLayout();
            this.consoleOutputOptionsPanel.SuspendLayout();
            this.certInputContextMenuStrip.SuspendLayout();
            this.companyInputContextMenuStrip.SuspendLayout();
            this.browserSettingsContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusLbl
            // 
            this.statusLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.statusLbl.AutoSize = true;
            this.statusLbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.statusLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLbl.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.statusLbl.Location = new System.Drawing.Point(1, 481);
            this.statusLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(70, 13);
            this.statusLbl.TabIndex = 2;
            this.statusLbl.Text = "   Status Text";
            this.statusLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.statusLbl.Visible = false;
            this.statusLbl.TextChanged += new System.EventHandler(this.statusLbl_TextChanged);
            // 
            // browserPanel
            // 
            this.browserPanel.Controls.Add(this.statusLbl);
            this.browserPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browserPanel.Location = new System.Drawing.Point(0, 0);
            this.browserPanel.Margin = new System.Windows.Forms.Padding(2);
            this.browserPanel.Name = "browserPanel";
            this.browserPanel.Size = new System.Drawing.Size(669, 495);
            this.browserPanel.TabIndex = 21;
            // 
            // copyLogBtn
            // 
            this.copyLogBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.copyLogBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.copyLogBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.copyLogBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.copyLogBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.copyLogBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.copyLogBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.copyLogBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.copyLogBtn.Location = new System.Drawing.Point(66, 5);
            this.copyLogBtn.Margin = new System.Windows.Forms.Padding(2);
            this.copyLogBtn.Name = "copyLogBtn";
            this.copyLogBtn.Size = new System.Drawing.Size(54, 20);
            this.copyLogBtn.TabIndex = 0;
            this.copyLogBtn.TabStop = false;
            this.copyLogBtn.Text = "Copy";
            this.toolTip1.SetToolTip(this.copyLogBtn, "Copy Console Log");
            this.copyLogBtn.UseVisualStyleBackColor = false;
            this.copyLogBtn.Click += new System.EventHandler(this.copyLogBtn_Click);
            // 
            // clearLogBtn
            // 
            this.clearLogBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clearLogBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.clearLogBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.clearLogBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.clearLogBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.clearLogBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearLogBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearLogBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.clearLogBtn.Location = new System.Drawing.Point(127, 5);
            this.clearLogBtn.Margin = new System.Windows.Forms.Padding(2);
            this.clearLogBtn.Name = "clearLogBtn";
            this.clearLogBtn.Size = new System.Drawing.Size(54, 20);
            this.clearLogBtn.TabIndex = 0;
            this.clearLogBtn.TabStop = false;
            this.clearLogBtn.Text = "Clear Log";
            this.toolTip1.SetToolTip(this.clearLogBtn, "Clear Console Log");
            this.clearLogBtn.UseVisualStyleBackColor = false;
            this.clearLogBtn.Click += new System.EventHandler(this.clearLogBtn_Click);
            // 
            // testBtn
            // 
            this.testBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.testBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.testBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight;
            this.testBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.testBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.testBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.testBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.testBtn.Location = new System.Drawing.Point(103, 38);
            this.testBtn.Margin = new System.Windows.Forms.Padding(2);
            this.testBtn.Name = "testBtn";
            this.testBtn.Size = new System.Drawing.Size(50, 18);
            this.testBtn.TabIndex = 5;
            this.testBtn.TabStop = false;
            this.testBtn.Text = "Test";
            this.toolTip1.SetToolTip(this.testBtn, "Test Console Output");
            this.testBtn.UseVisualStyleBackColor = false;
            this.testBtn.Click += new System.EventHandler(this.testBtn_Click);
            // 
            // menuBtn
            // 
            this.menuBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.menuBtn.BackgroundImage = global::CertusCompanion.Properties.Resources.menuIcon;
            this.menuBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.menuBtn.FlatAppearance.BorderSize = 0;
            this.menuBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.menuBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuBtn.ImageKey = "icons8-close-window-50 (1).png";
            this.menuBtn.Location = new System.Drawing.Point(827, 7);
            this.menuBtn.Margin = new System.Windows.Forms.Padding(2);
            this.menuBtn.Name = "menuBtn";
            this.menuBtn.Size = new System.Drawing.Size(20, 20);
            this.menuBtn.TabIndex = 0;
            this.menuBtn.TabStop = false;
            this.toolTip1.SetToolTip(this.menuBtn, "Show Console Panel");
            this.menuBtn.UseVisualStyleBackColor = true;
            this.menuBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.menuBtn_MouseDown);
            // 
            // customScript3Btn
            // 
            this.customScript3Btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.customScript3Btn.BackgroundImage = global::CertusCompanion.Properties.Resources.placeHolderIcon;
            this.customScript3Btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.customScript3Btn.Enabled = false;
            this.customScript3Btn.FlatAppearance.BorderSize = 0;
            this.customScript3Btn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.customScript3Btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.customScript3Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.customScript3Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customScript3Btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(200)))), ((int)(((byte)(150)))));
            this.customScript3Btn.Location = new System.Drawing.Point(111, 1);
            this.customScript3Btn.Margin = new System.Windows.Forms.Padding(2);
            this.customScript3Btn.Name = "customScript3Btn";
            this.customScript3Btn.Size = new System.Drawing.Size(20, 20);
            this.customScript3Btn.TabIndex = 11;
            this.customScript3Btn.Text = "3";
            this.toolTip1.SetToolTip(this.customScript3Btn, "Run custom script 3");
            this.customScript3Btn.UseVisualStyleBackColor = false;
            this.customScript3Btn.Click += new System.EventHandler(this.customScript3Btn_Click);
            // 
            // customScript2Btn
            // 
            this.customScript2Btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.customScript2Btn.BackgroundImage = global::CertusCompanion.Properties.Resources.placeHolderIcon;
            this.customScript2Btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.customScript2Btn.Enabled = false;
            this.customScript2Btn.FlatAppearance.BorderSize = 0;
            this.customScript2Btn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.customScript2Btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.customScript2Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.customScript2Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customScript2Btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(200)))), ((int)(((byte)(150)))));
            this.customScript2Btn.Location = new System.Drawing.Point(89, 1);
            this.customScript2Btn.Margin = new System.Windows.Forms.Padding(2);
            this.customScript2Btn.Name = "customScript2Btn";
            this.customScript2Btn.Size = new System.Drawing.Size(20, 20);
            this.customScript2Btn.TabIndex = 10;
            this.customScript2Btn.Text = "2";
            this.toolTip1.SetToolTip(this.customScript2Btn, "Run custom script 2");
            this.customScript2Btn.UseVisualStyleBackColor = false;
            this.customScript2Btn.Click += new System.EventHandler(this.customScript2Btn_Click);
            // 
            // customScript1Btn
            // 
            this.customScript1Btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.customScript1Btn.BackgroundImage = global::CertusCompanion.Properties.Resources.placeHolderIcon;
            this.customScript1Btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.customScript1Btn.Enabled = false;
            this.customScript1Btn.FlatAppearance.BorderSize = 0;
            this.customScript1Btn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.customScript1Btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.customScript1Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.customScript1Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customScript1Btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(200)))), ((int)(((byte)(150)))));
            this.customScript1Btn.Location = new System.Drawing.Point(67, 1);
            this.customScript1Btn.Margin = new System.Windows.Forms.Padding(2);
            this.customScript1Btn.Name = "customScript1Btn";
            this.customScript1Btn.Size = new System.Drawing.Size(20, 20);
            this.customScript1Btn.TabIndex = 9;
            this.customScript1Btn.Text = "1";
            this.toolTip1.SetToolTip(this.customScript1Btn, "Run custom script 1");
            this.customScript1Btn.UseVisualStyleBackColor = false;
            this.customScript1Btn.Click += new System.EventHandler(this.customScript1Btn_Click);
            // 
            // viewItemsBtn
            // 
            this.viewItemsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.viewItemsBtn.BackgroundImage = global::CertusCompanion.Properties.Resources.viewDetailsIcon;
            this.viewItemsBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.viewItemsBtn.Enabled = false;
            this.viewItemsBtn.FlatAppearance.BorderSize = 0;
            this.viewItemsBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.viewItemsBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.viewItemsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewItemsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewItemsBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(200)))), ((int)(((byte)(150)))));
            this.viewItemsBtn.Location = new System.Drawing.Point(2, 1);
            this.viewItemsBtn.Margin = new System.Windows.Forms.Padding(2);
            this.viewItemsBtn.Name = "viewItemsBtn";
            this.viewItemsBtn.Size = new System.Drawing.Size(20, 20);
            this.viewItemsBtn.TabIndex = 6;
            this.viewItemsBtn.Text = "3";
            this.toolTip1.SetToolTip(this.viewItemsBtn, "View items loaded into the browser");
            this.viewItemsBtn.UseVisualStyleBackColor = false;
            this.viewItemsBtn.Click += new System.EventHandler(this.viewItemsBtn_Click);
            // 
            // distributeItemsScriptBtn
            // 
            this.distributeItemsScriptBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.distributeItemsScriptBtn.BackgroundImage = global::CertusCompanion.Properties.Resources.batchAssignIcon;
            this.distributeItemsScriptBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.distributeItemsScriptBtn.FlatAppearance.BorderSize = 0;
            this.distributeItemsScriptBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.distributeItemsScriptBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.distributeItemsScriptBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.distributeItemsScriptBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.distributeItemsScriptBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(200)))), ((int)(((byte)(150)))));
            this.distributeItemsScriptBtn.Location = new System.Drawing.Point(46, 1);
            this.distributeItemsScriptBtn.Margin = new System.Windows.Forms.Padding(2);
            this.distributeItemsScriptBtn.Name = "distributeItemsScriptBtn";
            this.distributeItemsScriptBtn.Size = new System.Drawing.Size(20, 20);
            this.distributeItemsScriptBtn.TabIndex = 8;
            this.toolTip1.SetToolTip(this.distributeItemsScriptBtn, "Run \'Distribute Items\' script");
            this.distributeItemsScriptBtn.UseVisualStyleBackColor = false;
            this.distributeItemsScriptBtn.Click += new System.EventHandler(this.distributeItemsScriptBtn_Click);
            // 
            // completeItemsScriptBtn
            // 
            this.completeItemsScriptBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.completeItemsScriptBtn.BackgroundImage = global::CertusCompanion.Properties.Resources.tickBoxIcon;
            this.completeItemsScriptBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.completeItemsScriptBtn.FlatAppearance.BorderSize = 0;
            this.completeItemsScriptBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.completeItemsScriptBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.completeItemsScriptBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.completeItemsScriptBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.completeItemsScriptBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(200)))), ((int)(((byte)(150)))));
            this.completeItemsScriptBtn.Location = new System.Drawing.Point(24, 1);
            this.completeItemsScriptBtn.Margin = new System.Windows.Forms.Padding(2);
            this.completeItemsScriptBtn.Name = "completeItemsScriptBtn";
            this.completeItemsScriptBtn.Size = new System.Drawing.Size(20, 20);
            this.completeItemsScriptBtn.TabIndex = 7;
            this.toolTip1.SetToolTip(this.completeItemsScriptBtn, "Run \'Complete Items\' script");
            this.completeItemsScriptBtn.UseVisualStyleBackColor = false;
            this.completeItemsScriptBtn.Click += new System.EventHandler(this.completeItemsScriptBtn_Click);
            // 
            // refreshBtn
            // 
            this.refreshBtn.BackgroundImage = global::CertusCompanion.Properties.Resources.refreshIcon1;
            this.refreshBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.refreshBtn.FlatAppearance.BorderSize = 0;
            this.refreshBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.refreshBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.refreshBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshBtn.ImageKey = "icons8-close-window-50 (1).png";
            this.refreshBtn.Location = new System.Drawing.Point(56, 7);
            this.refreshBtn.Margin = new System.Windows.Forms.Padding(2);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(20, 20);
            this.refreshBtn.TabIndex = 0;
            this.refreshBtn.TabStop = false;
            this.toolTip1.SetToolTip(this.refreshBtn, "Refresh");
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // openCompanyBtn
            // 
            this.openCompanyBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.openCompanyBtn.BackgroundImage = global::CertusCompanion.Properties.Resources.findCompanyIcon;
            this.openCompanyBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.openCompanyBtn.FlatAppearance.BorderSize = 0;
            this.openCompanyBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.openCompanyBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.openCompanyBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openCompanyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openCompanyBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(200)))), ((int)(((byte)(150)))));
            this.openCompanyBtn.Location = new System.Drawing.Point(77, 37);
            this.openCompanyBtn.Margin = new System.Windows.Forms.Padding(2);
            this.openCompanyBtn.Name = "openCompanyBtn";
            this.openCompanyBtn.Size = new System.Drawing.Size(20, 20);
            this.openCompanyBtn.TabIndex = 5;
            this.toolTip1.SetToolTip(this.openCompanyBtn, "Navigate to a company (by company name)");
            this.openCompanyBtn.UseVisualStyleBackColor = false;
            this.openCompanyBtn.Click += new System.EventHandler(this.openCompanyBtn_Click);
            // 
            // openCertificateBtn
            // 
            this.openCertificateBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.openCertificateBtn.BackgroundImage = global::CertusCompanion.Properties.Resources.searchDocumentIcon;
            this.openCertificateBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.openCertificateBtn.FlatAppearance.BorderSize = 0;
            this.openCertificateBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.openCertificateBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.openCertificateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openCertificateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openCertificateBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(200)))), ((int)(((byte)(150)))));
            this.openCertificateBtn.Location = new System.Drawing.Point(55, 37);
            this.openCertificateBtn.Margin = new System.Windows.Forms.Padding(2);
            this.openCertificateBtn.Name = "openCertificateBtn";
            this.openCertificateBtn.Size = new System.Drawing.Size(20, 20);
            this.openCertificateBtn.TabIndex = 4;
            this.toolTip1.SetToolTip(this.openCertificateBtn, "Navigate to a certificate (by certificate name)");
            this.openCertificateBtn.UseVisualStyleBackColor = false;
            this.openCertificateBtn.Click += new System.EventHandler(this.openCertificate_Click);
            // 
            // authenticateBtn
            // 
            this.authenticateBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.authenticateBtn.BackgroundImage = global::CertusCompanion.Properties.Resources.signInIcon;
            this.authenticateBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.authenticateBtn.FlatAppearance.BorderSize = 0;
            this.authenticateBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.authenticateBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.authenticateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.authenticateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.authenticateBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(200)))), ((int)(((byte)(150)))));
            this.authenticateBtn.Location = new System.Drawing.Point(33, 37);
            this.authenticateBtn.Margin = new System.Windows.Forms.Padding(2);
            this.authenticateBtn.Name = "authenticateBtn";
            this.authenticateBtn.Size = new System.Drawing.Size(20, 20);
            this.authenticateBtn.TabIndex = 3;
            this.toolTip1.SetToolTip(this.authenticateBtn, "Authenticate automatically from the sign-in page");
            this.authenticateBtn.UseVisualStyleBackColor = false;
            this.authenticateBtn.Click += new System.EventHandler(this.authenticateBtn_Click);
            // 
            // homePageBtn
            // 
            this.homePageBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.homePageBtn.BackgroundImage = global::CertusCompanion.Properties.Resources.homeIcon;
            this.homePageBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.homePageBtn.FlatAppearance.BorderSize = 0;
            this.homePageBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.homePageBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.homePageBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.homePageBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.homePageBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(200)))), ((int)(((byte)(150)))));
            this.homePageBtn.Location = new System.Drawing.Point(11, 37);
            this.homePageBtn.Margin = new System.Windows.Forms.Padding(2);
            this.homePageBtn.Name = "homePageBtn";
            this.homePageBtn.Size = new System.Drawing.Size(20, 20);
            this.homePageBtn.TabIndex = 2;
            this.toolTip1.SetToolTip(this.homePageBtn, "Go to the home page");
            this.homePageBtn.UseVisualStyleBackColor = false;
            this.homePageBtn.Click += new System.EventHandler(this.homePageBtn_Click);
            // 
            // previousBtn
            // 
            this.previousBtn.BackgroundImage = global::CertusCompanion.Properties.Resources.backIcon;
            this.previousBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.previousBtn.FlatAppearance.BorderSize = 0;
            this.previousBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.previousBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.previousBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.previousBtn.ImageKey = "icons8-close-window-50 (1).png";
            this.previousBtn.Location = new System.Drawing.Point(11, 7);
            this.previousBtn.Margin = new System.Windows.Forms.Padding(2);
            this.previousBtn.Name = "previousBtn";
            this.previousBtn.Size = new System.Drawing.Size(20, 20);
            this.previousBtn.TabIndex = 0;
            this.previousBtn.TabStop = false;
            this.toolTip1.SetToolTip(this.previousBtn, "Go Back");
            this.previousBtn.UseVisualStyleBackColor = true;
            this.previousBtn.Click += new System.EventHandler(this.previousBtn_Click);
            // 
            // nextBtn
            // 
            this.nextBtn.BackgroundImage = global::CertusCompanion.Properties.Resources.nextIcon;
            this.nextBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.nextBtn.FlatAppearance.BorderSize = 0;
            this.nextBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.nextBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.nextBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextBtn.ImageKey = "icons8-close-window-50 (1).png";
            this.nextBtn.Location = new System.Drawing.Point(34, 7);
            this.nextBtn.Margin = new System.Windows.Forms.Padding(2);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(20, 20);
            this.nextBtn.TabIndex = 0;
            this.nextBtn.TabStop = false;
            this.toolTip1.SetToolTip(this.nextBtn, "Go Forward");
            this.nextBtn.UseVisualStyleBackColor = true;
            this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
            // 
            // dividerPanel
            // 
            this.dividerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dividerPanel.Controls.Add(this.dividerLbl);
            this.dividerPanel.ForeColor = System.Drawing.Color.Transparent;
            this.dividerPanel.Location = new System.Drawing.Point(0, 31);
            this.dividerPanel.Margin = new System.Windows.Forms.Padding(2);
            this.dividerPanel.Name = "dividerPanel";
            this.dividerPanel.Size = new System.Drawing.Size(859, 7);
            this.dividerPanel.TabIndex = 7;
            // 
            // dividerLbl
            // 
            this.dividerLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dividerLbl.BackColor = System.Drawing.Color.Gray;
            this.dividerLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dividerLbl.ForeColor = System.Drawing.Color.Lime;
            this.dividerLbl.Location = new System.Drawing.Point(0, 2);
            this.dividerLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.dividerLbl.Name = "dividerLbl";
            this.dividerLbl.Size = new System.Drawing.Size(860, 2);
            this.dividerLbl.TabIndex = 0;
            // 
            // navBarPanel
            // 
            this.navBarPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.navBarPanel.BackColor = System.Drawing.SystemColors.Window;
            this.navBarPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.navBarPanel.Controls.Add(this.navBarSearchBtn);
            this.navBarPanel.Controls.Add(this.navigationComboBox);
            this.navBarPanel.Location = new System.Drawing.Point(87, 6);
            this.navBarPanel.Margin = new System.Windows.Forms.Padding(2);
            this.navBarPanel.Name = "navBarPanel";
            this.navBarPanel.Size = new System.Drawing.Size(728, 23);
            this.navBarPanel.TabIndex = 0;
            this.navBarPanel.TabStop = true;
            // 
            // navBarSearchBtn
            // 
            this.navBarSearchBtn.BackgroundImage = global::CertusCompanion.Properties.Resources.searchIcon;
            this.navBarSearchBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.navBarSearchBtn.Enabled = false;
            this.navBarSearchBtn.FlatAppearance.BorderSize = 0;
            this.navBarSearchBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.navBarSearchBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.navBarSearchBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navBarSearchBtn.Location = new System.Drawing.Point(1, 0);
            this.navBarSearchBtn.Margin = new System.Windows.Forms.Padding(2);
            this.navBarSearchBtn.Name = "navBarSearchBtn";
            this.navBarSearchBtn.Size = new System.Drawing.Size(20, 19);
            this.navBarSearchBtn.TabIndex = 3;
            this.navBarSearchBtn.UseVisualStyleBackColor = true;
            // 
            // navigationComboBox
            // 
            this.navigationComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.navigationComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.navigationComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllUrl;
            this.navigationComboBox.BackColor = System.Drawing.SystemColors.Window;
            this.navigationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.navigationComboBox.DropDownWidth = 900;
            this.navigationComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navigationComboBox.FormattingEnabled = true;
            this.navigationComboBox.Location = new System.Drawing.Point(20, -1);
            this.navigationComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.navigationComboBox.Name = "navigationComboBox";
            this.navigationComboBox.Size = new System.Drawing.Size(705, 24);
            this.navigationComboBox.TabIndex = 0;
            this.navigationComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.navigationComboBox_KeyDown);
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.headerPanel.Controls.Add(this.menuBtn);
            this.headerPanel.Controls.Add(this.scriptOptionsPanel);
            this.headerPanel.Controls.Add(this.refreshBtn);
            this.headerPanel.Controls.Add(this.testBtn);
            this.headerPanel.Controls.Add(this.openCompanyBtn);
            this.headerPanel.Controls.Add(this.openCertificateBtn);
            this.headerPanel.Controls.Add(this.authenticateBtn);
            this.headerPanel.Controls.Add(this.homePageBtn);
            this.headerPanel.Controls.Add(this.navBarPanel);
            this.headerPanel.Controls.Add(this.dividerPanel);
            this.headerPanel.Controls.Add(this.previousBtn);
            this.headerPanel.Controls.Add(this.nextBtn);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Margin = new System.Windows.Forms.Padding(2);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(859, 60);
            this.headerPanel.TabIndex = 1;
            // 
            // scriptOptionsPanel
            // 
            this.scriptOptionsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.scriptOptionsPanel.Controls.Add(this.customScript3Btn);
            this.scriptOptionsPanel.Controls.Add(this.customScript2Btn);
            this.scriptOptionsPanel.Controls.Add(this.customScript1Btn);
            this.scriptOptionsPanel.Controls.Add(this.viewItemsBtn);
            this.scriptOptionsPanel.Controls.Add(this.distributeItemsScriptBtn);
            this.scriptOptionsPanel.Controls.Add(this.completeItemsScriptBtn);
            this.scriptOptionsPanel.Location = new System.Drawing.Point(716, 36);
            this.scriptOptionsPanel.Name = "scriptOptionsPanel";
            this.scriptOptionsPanel.Size = new System.Drawing.Size(135, 22);
            this.scriptOptionsPanel.TabIndex = 23;
            // 
            // intputTbx
            // 
            this.intputTbx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.intputTbx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.intputTbx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.intputTbx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.intputTbx.Location = new System.Drawing.Point(0, 0);
            this.intputTbx.Margin = new System.Windows.Forms.Padding(2);
            this.intputTbx.Multiline = true;
            this.intputTbx.Name = "intputTbx";
            this.intputTbx.Size = new System.Drawing.Size(188, 118);
            this.intputTbx.TabIndex = 0;
            this.intputTbx.Text = "\r\nFor custom scripts... call function \'transferArray();\' to get transferred workf" +
    "low items (returns array of IDs)\r\n\r\n         - - - - - - - - - - - - - - - - - -" +
    " - - - - \r\n\r\n\r\n";
            // 
            // consoleInputPanel
            // 
            this.consoleInputPanel.Controls.Add(this.intputTbx);
            this.consoleInputPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.consoleInputPanel.Location = new System.Drawing.Point(0, 0);
            this.consoleInputPanel.Margin = new System.Windows.Forms.Padding(2);
            this.consoleInputPanel.Name = "consoleInputPanel";
            this.consoleInputPanel.Size = new System.Drawing.Size(188, 118);
            this.consoleInputPanel.TabIndex = 24;
            // 
            // browserPanelContainer
            // 
            this.browserPanelContainer.Controls.Add(this.splitContainer1);
            this.browserPanelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browserPanelContainer.Location = new System.Drawing.Point(0, 60);
            this.browserPanelContainer.Margin = new System.Windows.Forms.Padding(2);
            this.browserPanelContainer.Name = "browserPanelContainer";
            this.browserPanelContainer.Size = new System.Drawing.Size(859, 495);
            this.browserPanelContainer.TabIndex = 22;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.browserPanel);
            this.splitContainer1.Panel1MinSize = 500;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.consoleOutputPanel);
            this.splitContainer1.Panel2.Controls.Add(this.consoleSplitter);
            this.splitContainer1.Panel2.Controls.Add(this.consoleInputPanel);
            this.splitContainer1.Panel2MinSize = 2;
            this.splitContainer1.Size = new System.Drawing.Size(859, 495);
            this.splitContainer1.SplitterDistance = 669;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 0;
            // 
            // consoleOutputPanel
            // 
            this.consoleOutputPanel.Controls.Add(this.outputTbx);
            this.consoleOutputPanel.Controls.Add(this.consoleOutputOptionsPanel);
            this.consoleOutputPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consoleOutputPanel.Location = new System.Drawing.Point(0, 120);
            this.consoleOutputPanel.Margin = new System.Windows.Forms.Padding(2);
            this.consoleOutputPanel.Name = "consoleOutputPanel";
            this.consoleOutputPanel.Size = new System.Drawing.Size(188, 375);
            this.consoleOutputPanel.TabIndex = 26;
            // 
            // outputTbx
            // 
            this.outputTbx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.outputTbx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.outputTbx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputTbx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.outputTbx.Location = new System.Drawing.Point(0, 0);
            this.outputTbx.Margin = new System.Windows.Forms.Padding(2);
            this.outputTbx.Multiline = true;
            this.outputTbx.Name = "outputTbx";
            this.outputTbx.ReadOnly = true;
            this.outputTbx.Size = new System.Drawing.Size(188, 345);
            this.outputTbx.TabIndex = 28;
            // 
            // consoleOutputOptionsPanel
            // 
            this.consoleOutputOptionsPanel.Controls.Add(this.clearLogBtn);
            this.consoleOutputOptionsPanel.Controls.Add(this.copyLogBtn);
            this.consoleOutputOptionsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.consoleOutputOptionsPanel.Location = new System.Drawing.Point(0, 345);
            this.consoleOutputOptionsPanel.Margin = new System.Windows.Forms.Padding(2);
            this.consoleOutputOptionsPanel.Name = "consoleOutputOptionsPanel";
            this.consoleOutputOptionsPanel.Size = new System.Drawing.Size(188, 30);
            this.consoleOutputOptionsPanel.TabIndex = 27;
            // 
            // consoleSplitter
            // 
            this.consoleSplitter.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.consoleSplitter.Dock = System.Windows.Forms.DockStyle.Top;
            this.consoleSplitter.Location = new System.Drawing.Point(0, 118);
            this.consoleSplitter.Margin = new System.Windows.Forms.Padding(2);
            this.consoleSplitter.Name = "consoleSplitter";
            this.consoleSplitter.Size = new System.Drawing.Size(188, 2);
            this.consoleSplitter.TabIndex = 25;
            this.consoleSplitter.TabStop = false;
            // 
            // distributeItemsBackgroundWorker
            // 
            this.distributeItemsBackgroundWorker.WorkerReportsProgress = true;
            this.distributeItemsBackgroundWorker.WorkerSupportsCancellation = true;
            this.distributeItemsBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.distributeItemsBackgroundWorker_DoWork);
            this.distributeItemsBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.distributeItemsBackgroundWorker_RunWorkerCompleted);
            // 
            // completeItemsBackgroundWorker
            // 
            this.completeItemsBackgroundWorker.WorkerReportsProgress = true;
            this.completeItemsBackgroundWorker.WorkerSupportsCancellation = true;
            this.completeItemsBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.completeItemsBackgroundWorker_DoWork);
            this.completeItemsBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.completeItemsBackgroundWorker_RunWorkerCompleted);
            // 
            // certInputContextMenuStrip
            // 
            this.certInputContextMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.certInputContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.certInputContextMenuTbx});
            this.certInputContextMenuStrip.Name = "inputContextMenuStrip";
            this.certInputContextMenuStrip.Size = new System.Drawing.Size(161, 29);
            // 
            // certInputContextMenuTbx
            // 
            this.certInputContextMenuTbx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.certInputContextMenuTbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.certInputContextMenuTbx.ForeColor = System.Drawing.SystemColors.Control;
            this.certInputContextMenuTbx.Name = "certInputContextMenuTbx";
            this.certInputContextMenuTbx.Size = new System.Drawing.Size(100, 23);
            this.certInputContextMenuTbx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputContextMenuTextBox_KeyDown);
            // 
            // statusLblTimer
            // 
            this.statusLblTimer.Interval = 5000;
            this.statusLblTimer.Tick += new System.EventHandler(this.statusLblTimer_Tick);
            // 
            // companyInputContextMenuStrip
            // 
            this.companyInputContextMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.companyInputContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.companyInputContextMenuStripTbx});
            this.companyInputContextMenuStrip.Name = "inputContextMenuStrip";
            this.companyInputContextMenuStrip.Size = new System.Drawing.Size(161, 29);
            // 
            // companyInputContextMenuStripTbx
            // 
            this.companyInputContextMenuStripTbx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.companyInputContextMenuStripTbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.companyInputContextMenuStripTbx.ForeColor = System.Drawing.SystemColors.Control;
            this.companyInputContextMenuStripTbx.Name = "companyInputContextMenuStripTbx";
            this.companyInputContextMenuStripTbx.Size = new System.Drawing.Size(100, 23);
            this.companyInputContextMenuStripTbx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.companyInputContextMenuTbx_KeyDown);
            // 
            // customScript1BackgroundWorker
            // 
            this.customScript1BackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.customScript1BackgroundWorker_DoWork);
            this.customScript1BackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.customScriptBackgroundWorker_RunWorkerCompleted);
            // 
            // customScript2BackgroundWorker
            // 
            this.customScript2BackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.customScript2BackgroundWorker_DoWork);
            this.customScript2BackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.customScriptBackgroundWorker_RunWorkerCompleted);
            // 
            // customScript3BackgroundWorker
            // 
            this.customScript3BackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.customScript3BackgroundWorker_DoWork);
            this.customScript3BackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.customScriptBackgroundWorker_RunWorkerCompleted);
            // 
            // browserSettingsContextMenuStrip
            // 
            this.browserSettingsContextMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.browserSettingsContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.showConsoleToolStripMenuItem});
            this.browserSettingsContextMenuStrip.Name = "contextMenuStrip1";
            this.browserSettingsContextMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.browserSettingsContextMenuStrip.ShowImageMargin = false;
            this.browserSettingsContextMenuStrip.Size = new System.Drawing.Size(164, 48);
            this.browserSettingsContextMenuStrip.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.browserSettingsContextMenuStrip_Closed);
            this.browserSettingsContextMenuStrip.Opened += new System.EventHandler(this.browserSettingsContextMenuStrip_Opened);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.settingsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Overflow = System.Windows.Forms.ToolStripItemOverflow.AsNeeded;
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // showConsoleToolStripMenuItem
            // 
            this.showConsoleToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.showConsoleToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.showConsoleToolStripMenuItem.Name = "showConsoleToolStripMenuItem";
            this.showConsoleToolStripMenuItem.Overflow = System.Windows.Forms.ToolStripItemOverflow.AsNeeded;
            this.showConsoleToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.showConsoleToolStripMenuItem.Text = "Console Panel             ";
            this.showConsoleToolStripMenuItem.Click += new System.EventHandler(this.showConsoleToolStripMenuItem_Click);
            // 
            // CertusBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(859, 555);
            this.Controls.Add(this.browserPanelContainer);
            this.Controls.Add(this.headerPanel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CertusBrowser";
            this.ShowIcon = false;
            this.Text = "Certus Browser";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BetterBrowser_FormClosing);
            this.Load += new System.EventHandler(this.BetterBrowser_Load);
            this.browserPanel.ResumeLayout(false);
            this.browserPanel.PerformLayout();
            this.dividerPanel.ResumeLayout(false);
            this.navBarPanel.ResumeLayout(false);
            this.headerPanel.ResumeLayout(false);
            this.scriptOptionsPanel.ResumeLayout(false);
            this.consoleInputPanel.ResumeLayout(false);
            this.consoleInputPanel.PerformLayout();
            this.browserPanelContainer.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.consoleOutputPanel.ResumeLayout(false);
            this.consoleOutputPanel.PerformLayout();
            this.consoleOutputOptionsPanel.ResumeLayout(false);
            this.certInputContextMenuStrip.ResumeLayout(false);
            this.certInputContextMenuStrip.PerformLayout();
            this.companyInputContextMenuStrip.ResumeLayout(false);
            this.companyInputContextMenuStrip.PerformLayout();
            this.browserSettingsContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label statusLbl;
        private System.Windows.Forms.Panel browserPanel;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button refreshBtn;
        private System.Windows.Forms.Button nextBtn;
        private System.Windows.Forms.Button previousBtn;
        private System.Windows.Forms.Panel dividerPanel;
        private System.Windows.Forms.Label dividerLbl;
        private System.Windows.Forms.Panel navBarPanel;
        private System.Windows.Forms.ComboBox navigationComboBox;
        private System.Windows.Forms.Button homePageBtn;
        private System.Windows.Forms.Button authenticateBtn;
        private System.Windows.Forms.Button openCertificateBtn;
        private System.Windows.Forms.Button openCompanyBtn;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Button testBtn;
        private System.Windows.Forms.Button copyLogBtn;
        private System.Windows.Forms.TextBox intputTbx;
        private System.Windows.Forms.Panel consoleInputPanel;
        private System.Windows.Forms.Panel browserPanelContainer;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel consoleOutputPanel;
        private System.Windows.Forms.Splitter consoleSplitter;
        private System.Windows.Forms.Panel consoleOutputOptionsPanel;
        private System.Windows.Forms.Button clearLogBtn;
        private System.Windows.Forms.TextBox outputTbx;
        private System.ComponentModel.BackgroundWorker distributeItemsBackgroundWorker;
        private System.ComponentModel.BackgroundWorker completeItemsBackgroundWorker;
        private System.Windows.Forms.Button navBarSearchBtn;
        private System.Windows.Forms.Panel scriptOptionsPanel;
        private System.Windows.Forms.Button customScript3Btn;
        private System.Windows.Forms.Button customScript2Btn;
        private System.Windows.Forms.Button customScript1Btn;
        private System.Windows.Forms.Button viewItemsBtn;
        private System.Windows.Forms.Button distributeItemsScriptBtn;
        private System.Windows.Forms.Button completeItemsScriptBtn;
        private System.Windows.Forms.ContextMenuStrip certInputContextMenuStrip;
        private System.Windows.Forms.ToolStripTextBox certInputContextMenuTbx;
        private System.Windows.Forms.Timer statusLblTimer;
        private System.Windows.Forms.ContextMenuStrip companyInputContextMenuStrip;
        private System.Windows.Forms.ToolStripTextBox companyInputContextMenuStripTbx;
        private System.ComponentModel.BackgroundWorker customScript1BackgroundWorker;
        private System.ComponentModel.BackgroundWorker customScript2BackgroundWorker;
        private System.ComponentModel.BackgroundWorker customScript3BackgroundWorker;
        private System.Windows.Forms.Button menuBtn;
        private System.Windows.Forms.ContextMenuStrip browserSettingsContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showConsoleToolStripMenuItem;
    }
}