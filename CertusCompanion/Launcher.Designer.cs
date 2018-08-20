namespace CertusCompanion
{
    partial class Launcher
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
            this.loadBackgroundPanel = new System.Windows.Forms.Panel();
            this.loadBottomMarginPanel = new System.Windows.Forms.Panel();
            this.loadRightMarginPanel = new System.Windows.Forms.Panel();
            this.loadForegroundPanel = new System.Windows.Forms.Panel();
            this.loadLeftMarginPanel = new System.Windows.Forms.Panel();
            this.loadTopMarginPanel = new System.Windows.Forms.Panel();
            this.CertusCompanionLbl = new System.Windows.Forms.Label();
            this.statusLbl = new System.Windows.Forms.Label();
            this.loadBackgroundPanel.SuspendLayout();
            this.loadForegroundPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // loadBackgroundPanel
            // 
            this.loadBackgroundPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.loadBackgroundPanel.Controls.Add(this.loadBottomMarginPanel);
            this.loadBackgroundPanel.Controls.Add(this.loadRightMarginPanel);
            this.loadBackgroundPanel.Controls.Add(this.loadForegroundPanel);
            this.loadBackgroundPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.loadBackgroundPanel.Location = new System.Drawing.Point(0, 175);
            this.loadBackgroundPanel.Margin = new System.Windows.Forms.Padding(2);
            this.loadBackgroundPanel.Name = "loadBackgroundPanel";
            this.loadBackgroundPanel.Size = new System.Drawing.Size(444, 15);
            this.loadBackgroundPanel.TabIndex = 3;
            // 
            // loadBottomMarginPanel
            // 
            this.loadBottomMarginPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.loadBottomMarginPanel.Location = new System.Drawing.Point(0, 14);
            this.loadBottomMarginPanel.Margin = new System.Windows.Forms.Padding(2);
            this.loadBottomMarginPanel.Name = "loadBottomMarginPanel";
            this.loadBottomMarginPanel.Size = new System.Drawing.Size(444, 3);
            this.loadBottomMarginPanel.TabIndex = 5;
            // 
            // loadRightMarginPanel
            // 
            this.loadRightMarginPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.loadRightMarginPanel.Location = new System.Drawing.Point(443, 0);
            this.loadRightMarginPanel.Margin = new System.Windows.Forms.Padding(2);
            this.loadRightMarginPanel.Name = "loadRightMarginPanel";
            this.loadRightMarginPanel.Size = new System.Drawing.Size(10, 20);
            this.loadRightMarginPanel.TabIndex = 6;
            // 
            // loadForegroundPanel
            // 
            this.loadForegroundPanel.BackColor = System.Drawing.Color.Lime;
            this.loadForegroundPanel.Controls.Add(this.loadLeftMarginPanel);
            this.loadForegroundPanel.Controls.Add(this.loadTopMarginPanel);
            this.loadForegroundPanel.Location = new System.Drawing.Point(0, 0);
            this.loadForegroundPanel.Margin = new System.Windows.Forms.Padding(2);
            this.loadForegroundPanel.Name = "loadForegroundPanel";
            this.loadForegroundPanel.Size = new System.Drawing.Size(163, 19);
            this.loadForegroundPanel.TabIndex = 0;
            // 
            // loadLeftMarginPanel
            // 
            this.loadLeftMarginPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.loadLeftMarginPanel.Location = new System.Drawing.Point(-9, 0);
            this.loadLeftMarginPanel.Margin = new System.Windows.Forms.Padding(2);
            this.loadLeftMarginPanel.Name = "loadLeftMarginPanel";
            this.loadLeftMarginPanel.Size = new System.Drawing.Size(10, 20);
            this.loadLeftMarginPanel.TabIndex = 5;
            // 
            // loadTopMarginPanel
            // 
            this.loadTopMarginPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.loadTopMarginPanel.Location = new System.Drawing.Point(0, -2);
            this.loadTopMarginPanel.Margin = new System.Windows.Forms.Padding(2);
            this.loadTopMarginPanel.Name = "loadTopMarginPanel";
            this.loadTopMarginPanel.Size = new System.Drawing.Size(444, 3);
            this.loadTopMarginPanel.TabIndex = 4;
            // 
            // CertusCompanionLbl
            // 
            this.CertusCompanionLbl.AutoSize = true;
            this.CertusCompanionLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CertusCompanionLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.CertusCompanionLbl.Location = new System.Drawing.Point(58, 74);
            this.CertusCompanionLbl.Name = "CertusCompanionLbl";
            this.CertusCompanionLbl.Size = new System.Drawing.Size(329, 42);
            this.CertusCompanionLbl.TabIndex = 2;
            this.CertusCompanionLbl.Text = "Certus Companion";
            // 
            // statusLbl
            // 
            this.statusLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.statusLbl.AutoSize = true;
            this.statusLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLbl.ForeColor = System.Drawing.Color.Gray;
            this.statusLbl.Location = new System.Drawing.Point(8, 155);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(32, 12);
            this.statusLbl.TabIndex = 4;
            this.statusLbl.Text = "Status";
            // 
            // Launcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(444, 190);
            this.Controls.Add(this.statusLbl);
            this.Controls.Add(this.loadBackgroundPanel);
            this.Controls.Add(this.CertusCompanionLbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Launcher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Launcher";
            this.loadBackgroundPanel.ResumeLayout(false);
            this.loadForegroundPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel loadBackgroundPanel;
        private System.Windows.Forms.Panel loadForegroundPanel;
        private System.Windows.Forms.Label CertusCompanionLbl;
        private System.Windows.Forms.Label statusLbl;
        private System.Windows.Forms.Panel loadRightMarginPanel;
        private System.Windows.Forms.Panel loadBottomMarginPanel;
        private System.Windows.Forms.Panel loadTopMarginPanel;
        private System.Windows.Forms.Panel loadLeftMarginPanel;
    }
}