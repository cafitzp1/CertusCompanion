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
            this.loadForegroundPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.loadBackgroundPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // loadBackgroundPanel
            // 
            this.loadBackgroundPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.loadBackgroundPanel.Controls.Add(this.loadForegroundPanel);
            this.loadBackgroundPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.loadBackgroundPanel.Location = new System.Drawing.Point(0, 158);
            this.loadBackgroundPanel.Margin = new System.Windows.Forms.Padding(2);
            this.loadBackgroundPanel.Name = "loadBackgroundPanel";
            this.loadBackgroundPanel.Size = new System.Drawing.Size(444, 17);
            this.loadBackgroundPanel.TabIndex = 3;
            // 
            // loadForegroundPanel
            // 
            this.loadForegroundPanel.BackColor = System.Drawing.Color.Lime;
            this.loadForegroundPanel.Location = new System.Drawing.Point(0, 0);
            this.loadForegroundPanel.Margin = new System.Windows.Forms.Padding(2);
            this.loadForegroundPanel.Name = "loadForegroundPanel";
            this.loadForegroundPanel.Size = new System.Drawing.Size(163, 19);
            this.loadForegroundPanel.TabIndex = 0;
            this.loadForegroundPanel.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(58, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(329, 42);
            this.label1.TabIndex = 2;
            this.label1.Text = "Certus Companion";
            // 
            // Launcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(444, 175);
            this.Controls.Add(this.loadBackgroundPanel);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Launcher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Launcher";
            this.loadBackgroundPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel loadBackgroundPanel;
        private System.Windows.Forms.Panel loadForegroundPanel;
        private System.Windows.Forms.Label label1;
    }
}