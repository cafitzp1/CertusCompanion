namespace CertusCompanion
{
    partial class LoadingForm
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
            this.headerPanel = new System.Windows.Forms.Panel();
            this.headerLabel = new System.Windows.Forms.Label();
            this.loadBackgroundPanel = new System.Windows.Forms.Panel();
            this.loadForegroundPanel = new System.Windows.Forms.Panel();
            this.borderPanel = new CertusCompanion.BorderPanel();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.optionsComboBox = new System.Windows.Forms.ComboBox();
            this.radioButtonsPanel = new System.Windows.Forms.Panel();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.closeBtn = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.headerPanel.SuspendLayout();
            this.loadBackgroundPanel.SuspendLayout();
            this.borderPanel.SuspendLayout();
            this.radioButtonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.headerPanel.Controls.Add(this.headerLabel);
            this.headerPanel.Location = new System.Drawing.Point(2, 1);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(797, 42);
            this.headerPanel.TabIndex = 0;
            // 
            // headerLabel
            // 
            this.headerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.headerLabel.AutoSize = true;
            this.headerLabel.ForeColor = System.Drawing.Color.DimGray;
            this.headerLabel.Location = new System.Drawing.Point(22, 10);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(89, 25);
            this.headerLabel.TabIndex = 0;
            this.headerLabel.Text = "Loading";
            this.headerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // loadBackgroundPanel
            // 
            this.loadBackgroundPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loadBackgroundPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.loadBackgroundPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.loadBackgroundPanel.Controls.Add(this.loadForegroundPanel);
            this.loadBackgroundPanel.Location = new System.Drawing.Point(29, 144);
            this.loadBackgroundPanel.Name = "loadBackgroundPanel";
            this.loadBackgroundPanel.Size = new System.Drawing.Size(742, 30);
            this.loadBackgroundPanel.TabIndex = 0;
            // 
            // loadForegroundPanel
            // 
            this.loadForegroundPanel.BackColor = System.Drawing.Color.Lime;
            this.loadForegroundPanel.Location = new System.Drawing.Point(1, 0);
            this.loadForegroundPanel.Name = "loadForegroundPanel";
            this.loadForegroundPanel.Size = new System.Drawing.Size(96, 36);
            this.loadForegroundPanel.TabIndex = 0;
            // 
            // borderPanel
            // 
            this.borderPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.borderPanel.Controls.Add(this.cancelBtn);
            this.borderPanel.Controls.Add(this.optionsComboBox);
            this.borderPanel.Controls.Add(this.radioButtonsPanel);
            this.borderPanel.Controls.Add(this.closeBtn);
            this.borderPanel.Controls.Add(this.statusLabel);
            this.borderPanel.Location = new System.Drawing.Point(-1, -1);
            this.borderPanel.Name = "borderPanel";
            this.borderPanel.Size = new System.Drawing.Size(802, 273);
            this.borderPanel.TabIndex = 0;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.cancelBtn.Location = new System.Drawing.Point(554, 207);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(100, 35);
            this.cancelBtn.TabIndex = 1;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Visible = false;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // optionsComboBox
            // 
            this.optionsComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.optionsComboBox.DropDownHeight = 70;
            this.optionsComboBox.DropDownWidth = 400;
            this.optionsComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.optionsComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optionsComboBox.ForeColor = System.Drawing.SystemColors.Control;
            this.optionsComboBox.FormattingEnabled = true;
            this.optionsComboBox.IntegralHeight = false;
            this.optionsComboBox.Location = new System.Drawing.Point(32, 142);
            this.optionsComboBox.Name = "optionsComboBox";
            this.optionsComboBox.Size = new System.Drawing.Size(375, 37);
            this.optionsComboBox.TabIndex = 0;
            this.optionsComboBox.TabStop = false;
            this.optionsComboBox.Text = "Select one...";
            this.optionsComboBox.Visible = false;
            // 
            // radioButtonsPanel
            // 
            this.radioButtonsPanel.Controls.Add(this.radioButton3);
            this.radioButtonsPanel.Controls.Add(this.radioButton2);
            this.radioButtonsPanel.Controls.Add(this.radioButton1);
            this.radioButtonsPanel.Location = new System.Drawing.Point(13, 141);
            this.radioButtonsPanel.Name = "radioButtonsPanel";
            this.radioButtonsPanel.Size = new System.Drawing.Size(652, 113);
            this.radioButtonsPanel.TabIndex = 0;
            this.radioButtonsPanel.Visible = false;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.radioButton3.Location = new System.Drawing.Point(357, 7);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(124, 29);
            this.radioButton3.TabIndex = 0;
            this.radioButton3.Text = "Option 3";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.radioButton2.Location = new System.Drawing.Point(187, 7);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(124, 29);
            this.radioButton2.TabIndex = 0;
            this.radioButton2.Text = "Option 2";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.radioButton1.Location = new System.Drawing.Point(17, 7);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(124, 29);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Text = "Option 1";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // closeBtn
            // 
            this.closeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.closeBtn.Location = new System.Drawing.Point(671, 207);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(100, 35);
            this.closeBtn.TabIndex = 0;
            this.closeBtn.Text = "Close";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Visible = false;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.statusLabel.Location = new System.Drawing.Point(25, 90);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(747, 121);
            this.statusLabel.TabIndex = 0;
            this.statusLabel.Text = "Loading...";
            // 
            // LoadingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(800, 271);
            this.Controls.Add(this.loadBackgroundPanel);
            this.Controls.Add(this.headerPanel);
            this.Controls.Add(this.borderPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoadingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "LoadingForm";
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.loadBackgroundPanel.ResumeLayout(false);
            this.borderPanel.ResumeLayout(false);
            this.radioButtonsPanel.ResumeLayout(false);
            this.radioButtonsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Panel loadBackgroundPanel;
        private System.Windows.Forms.Panel loadForegroundPanel;
        private BorderPanel borderPanel;
        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Panel radioButtonsPanel;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.ComboBox optionsComboBox;
    }
}