namespace CertusCompanion
{
    partial class BrowserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BrowserForm));
            this.browserSymbols = new System.Windows.Forms.ImageList(this.components);
            this.certusConnectionTimer = new System.Windows.Forms.Timer(this.components);
            this.footerPanel = new System.Windows.Forms.Panel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.statusLbl = new System.Windows.Forms.Label();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.navigationComboBox = new System.Windows.Forms.ComboBox();
            this.browserPane = new System.Windows.Forms.Panel();
            this.executeProcess1Btn = new System.Windows.Forms.Button();
            this.previousBtn = new System.Windows.Forms.Button();
            this.nextBtn = new System.Windows.Forms.Button();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.footerPanel.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.browserPane.SuspendLayout();
            this.SuspendLayout();
            // 
            // browserSymbols
            // 
            this.browserSymbols.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("browserSymbols.ImageStream")));
            this.browserSymbols.TransparentColor = System.Drawing.Color.Transparent;
            this.browserSymbols.Images.SetKeyName(0, "icons8-restore-window-50.png");
            this.browserSymbols.Images.SetKeyName(1, "icons8-minimize-window-50 (1).png");
            this.browserSymbols.Images.SetKeyName(2, "icons8-close-window-50 (1).png");
            // 
            // certusConnectionTimer
            // 
            this.certusConnectionTimer.Enabled = true;
            this.certusConnectionTimer.Interval = 3605000;
            this.certusConnectionTimer.Tick += new System.EventHandler(this.certusConnectionTimer_Tick);
            // 
            // footerPanel
            // 
            this.footerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.footerPanel.Controls.Add(this.executeProcess1Btn);
            this.footerPanel.Controls.Add(this.progressBar);
            this.footerPanel.Controls.Add(this.statusLbl);
            this.footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerPanel.Location = new System.Drawing.Point(0, 720);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Size = new System.Drawing.Size(1256, 42);
            this.footerPanel.TabIndex = 19;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.progressBar.Location = new System.Drawing.Point(1009, 9);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(214, 23);
            this.progressBar.TabIndex = 3;
            // 
            // statusLbl
            // 
            this.statusLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusLbl.AutoSize = true;
            this.statusLbl.ForeColor = System.Drawing.Color.DimGray;
            this.statusLbl.Location = new System.Drawing.Point(22, 10);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(30, 25);
            this.statusLbl.TabIndex = 2;
            this.statusLbl.Text = "   ";
            this.statusLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.headerPanel.Controls.Add(this.previousBtn);
            this.headerPanel.Controls.Add(this.nextBtn);
            this.headerPanel.Controls.Add(this.navigationComboBox);
            this.headerPanel.Controls.Add(this.refreshBtn);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1256, 94);
            this.headerPanel.TabIndex = 0;
            // 
            // navigationComboBox
            // 
            this.navigationComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.navigationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.navigationComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navigationComboBox.FormattingEnabled = true;
            this.navigationComboBox.Location = new System.Drawing.Point(174, 33);
            this.navigationComboBox.Name = "navigationComboBox";
            this.navigationComboBox.Size = new System.Drawing.Size(1049, 39);
            this.navigationComboBox.TabIndex = 2;
            this.navigationComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.navigationComboBox_KeyDown);
            // 
            // browserPane
            // 
            this.browserPane.Controls.Add(this.webBrowser);
            this.browserPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browserPane.Location = new System.Drawing.Point(0, 94);
            this.browserPane.Name = "browserPane";
            this.browserPane.Size = new System.Drawing.Size(1256, 626);
            this.browserPane.TabIndex = 20;
            // 
            // executeProcess1Btn
            // 
            this.executeProcess1Btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.executeProcess1Btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("executeProcess1Btn.BackgroundImage")));
            this.executeProcess1Btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.executeProcess1Btn.FlatAppearance.BorderSize = 0;
            this.executeProcess1Btn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.executeProcess1Btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.executeProcess1Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.executeProcess1Btn.ImageKey = "icons8-close-window-50 (1).png";
            this.executeProcess1Btn.Location = new System.Drawing.Point(607, 2);
            this.executeProcess1Btn.Name = "executeProcess1Btn";
            this.executeProcess1Btn.Size = new System.Drawing.Size(39, 39);
            this.executeProcess1Btn.TabIndex = 5;
            this.executeProcess1Btn.UseVisualStyleBackColor = true;
            this.executeProcess1Btn.Click += new System.EventHandler(this.executeProcess1Btn_Click);
            // 
            // previousBtn
            // 
            this.previousBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.previousBtn.BackgroundImage = global::CertusCompanion.Properties.Resources.icons8_back_48__2_;
            this.previousBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.previousBtn.FlatAppearance.BorderSize = 0;
            this.previousBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.previousBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.previousBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.previousBtn.ImageKey = "icons8-close-window-50 (1).png";
            this.previousBtn.Location = new System.Drawing.Point(22, 34);
            this.previousBtn.Name = "previousBtn";
            this.previousBtn.Size = new System.Drawing.Size(39, 39);
            this.previousBtn.TabIndex = 6;
            this.previousBtn.UseVisualStyleBackColor = true;
            this.previousBtn.Click += new System.EventHandler(this.previousBtn_Click);
            // 
            // nextBtn
            // 
            this.nextBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nextBtn.BackgroundImage = global::CertusCompanion.Properties.Resources.icons8_forward_48__1_;
            this.nextBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.nextBtn.FlatAppearance.BorderSize = 0;
            this.nextBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.nextBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.nextBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextBtn.ImageKey = "icons8-close-window-50 (1).png";
            this.nextBtn.Location = new System.Drawing.Point(67, 34);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(39, 39);
            this.nextBtn.TabIndex = 5;
            this.nextBtn.UseVisualStyleBackColor = true;
            this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
            // 
            // refreshBtn
            // 
            this.refreshBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.refreshBtn.BackgroundImage = global::CertusCompanion.Properties.Resources.icons8_available_updates_48__1_;
            this.refreshBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.refreshBtn.FlatAppearance.BorderSize = 0;
            this.refreshBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.refreshBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.refreshBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshBtn.ImageKey = "icons8-close-window-50 (1).png";
            this.refreshBtn.Location = new System.Drawing.Point(112, 33);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(39, 39);
            this.refreshBtn.TabIndex = 1;
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(0, 0);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(1256, 626);
            this.webBrowser.TabIndex = 0;
            // 
            // BrowserForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(1256, 762);
            this.Controls.Add(this.browserPane);
            this.Controls.Add(this.footerPanel);
            this.Controls.Add(this.headerPanel);
            this.DoubleBuffered = true;
            this.Name = "BrowserForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Certus Browser";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BrowserForm_FormClosing);
            this.Load += new System.EventHandler(this.BrowserForm_Load);
            this.footerPanel.ResumeLayout(false);
            this.footerPanel.PerformLayout();
            this.headerPanel.ResumeLayout(false);
            this.browserPane.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList browserSymbols;
        private System.Windows.Forms.Timer certusConnectionTimer;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Button previousBtn;
        private System.Windows.Forms.Button nextBtn;
        private System.Windows.Forms.ComboBox navigationComboBox;
        private System.Windows.Forms.Button refreshBtn;
        private System.Windows.Forms.Panel footerPanel;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label statusLbl;
        private System.Windows.Forms.Button executeProcess1Btn;
        private System.Windows.Forms.Panel browserPane;
        private System.Windows.Forms.WebBrowser webBrowser;
    }
}