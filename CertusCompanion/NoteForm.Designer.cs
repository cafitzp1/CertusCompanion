namespace CertusCompanion
{
    partial class NoteForm
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
            this.noteComboBox = new System.Windows.Forms.ComboBox();
            this.notePanel = new CertusCompanion.CustomPanel();
            this.noteTbx = new System.Windows.Forms.TextBox();
            this.notePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // noteComboBox
            // 
            this.noteComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.noteComboBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.noteComboBox.FormattingEnabled = true;
            this.noteComboBox.Items.AddRange(new object[] {
            "Default",
            "Original File",
            "Newer File",
            "Revisions"});
            this.noteComboBox.Location = new System.Drawing.Point(138, 22);
            this.noteComboBox.Name = "noteComboBox";
            this.noteComboBox.Size = new System.Drawing.Size(229, 33);
            this.noteComboBox.TabIndex = 10;
            this.noteComboBox.SelectedIndexChanged += new System.EventHandler(this.noteComboBox_SelectedIndexChanged);
            // 
            // notePanel
            // 
            this.notePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.notePanel.Controls.Add(this.noteTbx);
            this.notePanel.Location = new System.Drawing.Point(12, 75);
            this.notePanel.Name = "notePanel";
            this.notePanel.Size = new System.Drawing.Size(480, 242);
            this.notePanel.TabIndex = 14;
            // 
            // noteTbx
            // 
            this.noteTbx.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.noteTbx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.noteTbx.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.noteTbx.Location = new System.Drawing.Point(0, 0);
            this.noteTbx.Multiline = true;
            this.noteTbx.Name = "noteTbx";
            this.noteTbx.Size = new System.Drawing.Size(476, 238);
            this.noteTbx.TabIndex = 0;
            // 
            // NoteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ClientSize = new System.Drawing.Size(504, 329);
            this.Controls.Add(this.notePanel);
            this.Controls.Add(this.noteComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NoteForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Note";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.NoteForm_FormClosed);
            this.Shown += new System.EventHandler(this.NoteForm_Shown);
            this.notePanel.ResumeLayout(false);
            this.notePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox noteComboBox;
        private CustomPanel notePanel;
        private System.Windows.Forms.TextBox noteTbx;
    }
}