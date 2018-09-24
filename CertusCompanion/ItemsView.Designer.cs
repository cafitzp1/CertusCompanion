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
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.viewColorsCheckBox = new System.Windows.Forms.CheckBox();
            this.itemsListView = new CertusCompanion.ListViewNF();
            this.viewColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.viewColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.viewColumnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.viewColumnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.viewColumnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.viewColumnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.viewColumnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.viewColumnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.headerPanel = new System.Windows.Forms.Panel();
            this.searchTbxActiveBorder = new System.Windows.Forms.Panel();
            this.searchTbxInactiveBorder = new System.Windows.Forms.Panel();
            this.searchTbx = new System.Windows.Forms.TextBox();
            this.headerLabel = new System.Windows.Forms.Label();
            this.btnsPanel = new System.Windows.Forms.Panel();
            this.exportBtn = new System.Windows.Forms.Button();
            this.footerPanel = new System.Windows.Forms.Panel();
            this.toolStripStatusLabel = new System.Windows.Forms.Label();
            this.headerPanel.SuspendLayout();
            this.searchTbxActiveBorder.SuspendLayout();
            this.searchTbxInactiveBorder.SuspendLayout();
            this.btnsPanel.SuspendLayout();
            this.footerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Interval = 10000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // viewColorsCheckBox
            // 
            this.viewColorsCheckBox.AutoSize = true;
            this.viewColorsCheckBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.viewColorsCheckBox.Location = new System.Drawing.Point(27, 22);
            this.viewColorsCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.viewColorsCheckBox.Name = "viewColorsCheckBox";
            this.viewColorsCheckBox.Size = new System.Drawing.Size(81, 17);
            this.viewColorsCheckBox.TabIndex = 0;
            this.viewColorsCheckBox.TabStop = false;
            this.viewColorsCheckBox.Text = "View Colors";
            this.viewColorsCheckBox.UseVisualStyleBackColor = true;
            this.viewColorsCheckBox.Visible = false;
            this.viewColorsCheckBox.CheckedChanged += new System.EventHandler(this.viewColorsCheckBox_CheckedChanged);
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
            this.viewColumnHeader7,
            this.viewColumnHeader8});
            this.itemsListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemsListView.ForeColor = System.Drawing.SystemColors.Control;
            this.itemsListView.FullRowSelect = true;
            this.itemsListView.HideSelection = false;
            this.itemsListView.LabelWrap = false;
            this.itemsListView.Location = new System.Drawing.Point(28, 40);
            this.itemsListView.Margin = new System.Windows.Forms.Padding(2);
            this.itemsListView.MultiSelect = false;
            this.itemsListView.Name = "itemsListView";
            this.itemsListView.OwnerDraw = true;
            this.itemsListView.Size = new System.Drawing.Size(746, 352);
            this.itemsListView.TabIndex = 0;
            this.itemsListView.TabStop = false;
            this.itemsListView.UseCompatibleStateImageBehavior = false;
            this.itemsListView.View = System.Windows.Forms.View.Details;
            this.itemsListView.VirtualListSize = 100000;
            this.itemsListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.itemsListView_ColumnClick);
            this.itemsListView.ColumnWidthChanged += new System.Windows.Forms.ColumnWidthChangedEventHandler(this.itemsListView_ColumnWidthChanged);
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
            this.viewColumnHeader1.Width = 70;
            // 
            // viewColumnHeader2
            // 
            this.viewColumnHeader2.Text = "";
            this.viewColumnHeader2.Width = 70;
            // 
            // viewColumnHeader3
            // 
            this.viewColumnHeader3.Text = "";
            this.viewColumnHeader3.Width = 70;
            // 
            // viewColumnHeader4
            // 
            this.viewColumnHeader4.Text = "";
            this.viewColumnHeader4.Width = 70;
            // 
            // viewColumnHeader5
            // 
            this.viewColumnHeader5.Text = "";
            this.viewColumnHeader5.Width = 70;
            // 
            // viewColumnHeader6
            // 
            this.viewColumnHeader6.Text = "";
            this.viewColumnHeader6.Width = 70;
            // 
            // viewColumnHeader7
            // 
            this.viewColumnHeader7.Text = "";
            this.viewColumnHeader7.Width = 70;
            // 
            // viewColumnHeader8
            // 
            this.viewColumnHeader8.Text = "";
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.headerPanel.Controls.Add(this.searchTbxActiveBorder);
            this.headerPanel.Controls.Add(this.headerLabel);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Margin = new System.Windows.Forms.Padding(2);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(800, 20);
            this.headerPanel.TabIndex = 128;
            // 
            // searchTbxActiveBorder
            // 
            this.searchTbxActiveBorder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchTbxActiveBorder.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.searchTbxActiveBorder.Controls.Add(this.searchTbxInactiveBorder);
            this.searchTbxActiveBorder.Location = new System.Drawing.Point(617, 1);
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
            // headerLabel
            // 
            this.headerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLabel.ForeColor = System.Drawing.Color.DimGray;
            this.headerLabel.Location = new System.Drawing.Point(10, 3);
            this.headerLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(60, 15);
            this.headerLabel.TabIndex = 2;
            this.headerLabel.Text = "Item View";
            this.headerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnsPanel
            // 
            this.btnsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnsPanel.Controls.Add(this.exportBtn);
            this.btnsPanel.Location = new System.Drawing.Point(6, 398);
            this.btnsPanel.Margin = new System.Windows.Forms.Padding(2);
            this.btnsPanel.Name = "btnsPanel";
            this.btnsPanel.Size = new System.Drawing.Size(788, 29);
            this.btnsPanel.TabIndex = 0;
            this.btnsPanel.TabStop = true;
            // 
            // exportBtn
            // 
            this.exportBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exportBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.exportBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exportBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.exportBtn.Location = new System.Drawing.Point(716, 6);
            this.exportBtn.Margin = new System.Windows.Forms.Padding(2);
            this.exportBtn.Name = "exportBtn";
            this.exportBtn.Size = new System.Drawing.Size(50, 18);
            this.exportBtn.TabIndex = 0;
            this.exportBtn.Text = "Export";
            this.exportBtn.UseVisualStyleBackColor = false;
            this.exportBtn.Click += new System.EventHandler(this.exportBtn_Click);
            this.exportBtn.Enter += new System.EventHandler(this.optionBtn_Enter);
            this.exportBtn.Leave += new System.EventHandler(this.optionBtn_Leave);
            // 
            // footerPanel
            // 
            this.footerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.footerPanel.Controls.Add(this.toolStripStatusLabel);
            this.footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerPanel.Location = new System.Drawing.Point(0, 429);
            this.footerPanel.Margin = new System.Windows.Forms.Padding(2);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Size = new System.Drawing.Size(800, 21);
            this.footerPanel.TabIndex = 126;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStripStatusLabel.AutoSize = true;
            this.toolStripStatusLabel.ForeColor = System.Drawing.Color.DimGray;
            this.toolStripStatusLabel.Location = new System.Drawing.Point(11, 5);
            this.toolStripStatusLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(16, 13);
            this.toolStripStatusLabel.TabIndex = 2;
            this.toolStripStatusLabel.Text = "   ";
            this.toolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ItemsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.viewColorsCheckBox);
            this.Controls.Add(this.itemsListView);
            this.Controls.Add(this.headerPanel);
            this.Controls.Add(this.btnsPanel);
            this.Controls.Add(this.footerPanel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ItemsView";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Items View";
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.searchTbxActiveBorder.ResumeLayout(false);
            this.searchTbxInactiveBorder.ResumeLayout(false);
            this.searchTbxInactiveBorder.PerformLayout();
            this.btnsPanel.ResumeLayout(false);
            this.footerPanel.ResumeLayout(false);
            this.footerPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.CheckBox viewColorsCheckBox;
        private ListViewNF itemsListView;
        private System.Windows.Forms.ColumnHeader viewColumnHeader1;
        private System.Windows.Forms.ColumnHeader viewColumnHeader2;
        private System.Windows.Forms.ColumnHeader viewColumnHeader3;
        private System.Windows.Forms.ColumnHeader viewColumnHeader4;
        private System.Windows.Forms.ColumnHeader viewColumnHeader5;
        private System.Windows.Forms.ColumnHeader viewColumnHeader6;
        private System.Windows.Forms.ColumnHeader viewColumnHeader7;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.Panel btnsPanel;
        private System.Windows.Forms.Button exportBtn;
        private System.Windows.Forms.Panel footerPanel;
        private System.Windows.Forms.Label toolStripStatusLabel;
        private System.Windows.Forms.Panel searchTbxActiveBorder;
        private System.Windows.Forms.Panel searchTbxInactiveBorder;
        private System.Windows.Forms.TextBox searchTbx;
        private System.Windows.Forms.ColumnHeader viewColumnHeader8;
    }
}