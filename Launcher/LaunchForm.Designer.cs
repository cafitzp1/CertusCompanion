namespace Launcher
{
    partial class LaunchForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.loadBackgroundPanel = new System.Windows.Forms.Panel();
            this.loadForegroundPanel = new System.Windows.Forms.Panel();
            this.loadBackgroundPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(50, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(329, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Certus Companion";
            // 
            // loadBackgroundPanel
            // 
            this.loadBackgroundPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.loadBackgroundPanel.Controls.Add(this.loadForegroundPanel);
            this.loadBackgroundPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.loadBackgroundPanel.Location = new System.Drawing.Point(0, 161);
            this.loadBackgroundPanel.Margin = new System.Windows.Forms.Padding(2);
            this.loadBackgroundPanel.Name = "loadBackgroundPanel";
            this.loadBackgroundPanel.Size = new System.Drawing.Size(428, 17);
            this.loadBackgroundPanel.TabIndex = 1;
            // 
            // loadForegroundPanel
            // 
            this.loadForegroundPanel.BackColor = System.Drawing.Color.Lime;
            this.loadForegroundPanel.Location = new System.Drawing.Point(0, 0);
            this.loadForegroundPanel.Margin = new System.Windows.Forms.Padding(2);
            this.loadForegroundPanel.Name = "loadForegroundPanel";
            this.loadForegroundPanel.Size = new System.Drawing.Size(48, 19);
            this.loadForegroundPanel.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(428, 178);
            this.Controls.Add(this.loadBackgroundPanel);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.loadBackgroundPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel loadBackgroundPanel;
        private System.Windows.Forms.Panel loadForegroundPanel;
    }
}

