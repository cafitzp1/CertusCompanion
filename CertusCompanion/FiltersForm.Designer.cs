namespace CertusCompanion
{
    partial class FiltersForm
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
            this.saveBtn = new System.Windows.Forms.Button();
            this.colorComboBox = new System.Windows.Forms.ComboBox();
            this.analystComboBox = new System.Windows.Forms.ComboBox();
            this.statusComboBox = new System.Windows.Forms.ComboBox();
            this.startDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.senderTbxPanel = new System.Windows.Forms.Panel();
            this.button102 = new System.Windows.Forms.Button();
            this.senderEmailTbx = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.companyTbxPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.companyTbx = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.startDateLbl = new System.Windows.Forms.Label();
            this.endDateLbl = new System.Windows.Forms.Label();
            this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.colorCheckBox = new System.Windows.Forms.CheckBox();
            this.analystCheckBox = new System.Windows.Forms.CheckBox();
            this.statusCheckBox = new System.Windows.Forms.CheckBox();
            this.queriedCheckBox = new System.Windows.Forms.CheckBox();
            this.companyCheckBox = new System.Windows.Forms.CheckBox();
            this.senderCheckBox = new System.Windows.Forms.CheckBox();
            this.dateCheckBox = new System.Windows.Forms.CheckBox();
            this.queriedComboBox = new System.Windows.Forms.ComboBox();
            this.clearBtn = new System.Windows.Forms.Button();
            this.statusLbl = new System.Windows.Forms.Label();
            this.subjectCheckBox = new System.Windows.Forms.CheckBox();
            this.subjectTbxPanel = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.subjectTbx = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.senderTbxPanel.SuspendLayout();
            this.companyTbxPanel.SuspendLayout();
            this.subjectTbxPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.saveBtn.Location = new System.Drawing.Point(532, 600);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(100, 35);
            this.saveBtn.TabIndex = 90;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // colorComboBox
            // 
            this.colorComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.colorComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.colorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colorComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colorComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colorComboBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.colorComboBox.FormattingEnabled = true;
            this.colorComboBox.Items.AddRange(new object[] {
            "Default",
            "Teal",
            "Blue",
            "Navy",
            "Aqua",
            "Green",
            "Lime",
            "Yellow",
            "Purple",
            "Red",
            "Gray",
            "Silver",
            "SpringGreen",
            "Black",
            "All Colors",
            "Active Colors",
            "Inactive Colors"});
            this.colorComboBox.Location = new System.Drawing.Point(378, 28);
            this.colorComboBox.Name = "colorComboBox";
            this.colorComboBox.Size = new System.Drawing.Size(253, 33);
            this.colorComboBox.TabIndex = 96;
            // 
            // analystComboBox
            // 
            this.analystComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.analystComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.analystComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.analystComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.analystComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.analystComboBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.analystComboBox.FormattingEnabled = true;
            this.analystComboBox.Items.AddRange(new object[] {
            "(Unassigned)",
            "Antunes, Alec",
            "Ausman, Ralph",
            "Barker, Patty",
            "Barrett, Anne",
            "Bobo, David",
            "Bowen, Tom",
            "Brown, Avery",
            "Brown, Doreen",
            "Burns, Jonathan",
            "Burns, Louise",
            "Byer, Sherwin",
            "Cacoilo, Alex",
            "Campbell, Theresa",
            "Chang, Justin",
            "Christatos, Peter",
            "Connolly, Matthew",
            "Cooper, Robert",
            "Covert, Amy",
            "Cowan, Joseph",
            "Danyo, Kevin",
            "DeSimone, Lisa",
            "Doyle, Dan",
            "Ellis, Richard",
            "Ferrara, Lauren",
            "Fiorito, Crystal",
            "Fitzpatrick, Connor",
            "Fonseca, Jennifer",
            "Gallagher, Susan",
            "Gast, Michael",
            "Gomez, Anthony",
            "Goodwin, Linda",
            "Helmer, Stephanie",
            "Hurston, Jazmin",
            "Iizuka, Ria",
            "Jennings, Brent",
            "Johnson, Kyle",
            "Johnston, Crystal",
            "Juvonen, Patty",
            "Keenan, Russell",
            "Kishyk, Gregory",
            "Kosik, Stephen",
            "Kostiw, Daniel",
            "Kostiw, Kevin",
            "Leta, Dane",
            "Luizza, Chris",
            "Luizza, Vincent",
            "Mahet, Jennifer",
            "Marie, Louise",
            "Marques, Marta",
            "Mayovskyy, Yuriy",
            "McCann, James",
            "McMillen, Lauri",
            "McNamara, Sean",
            "McPhail, Anna Marie",
            "Monteleone, Steven",
            "Nguyen, Thai",
            "O\'Neill, Rose",
            "Osborne, Bruce",
            "Patel, Roshni",
            "Reynera, Gino",
            "Ristovska, Kristina",
            "Salerno, Mark",
            "Saracco, Cindy",
            "Schweighardt, Daniel",
            "Skibniewski, Adrian",
            "Spinelli, Benjamin",
            "Steele, Daniel",
            "Stepanian, Richard",
            "Swaminathan, Sheetal",
            "Tischler, Gray",
            "Turcios-Diaz, Nancy",
            "Wilson, Kevin"});
            this.analystComboBox.Location = new System.Drawing.Point(378, 81);
            this.analystComboBox.Name = "analystComboBox";
            this.analystComboBox.Size = new System.Drawing.Size(253, 33);
            this.analystComboBox.TabIndex = 97;
            // 
            // statusComboBox
            // 
            this.statusComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.statusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statusComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.statusComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusComboBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.statusComboBox.FormattingEnabled = true;
            this.statusComboBox.Items.AddRange(new object[] {
            "All",
            "Email Received",
            "Documentation Analyst",
            "Compliance Analyst",
            "Completed",
            "Trash",
            "Completed/Trash",
            "Current"});
            this.statusComboBox.Location = new System.Drawing.Point(378, 130);
            this.statusComboBox.Name = "statusComboBox";
            this.statusComboBox.Size = new System.Drawing.Size(253, 33);
            this.statusComboBox.TabIndex = 99;
            // 
            // startDateTimePicker
            // 
            this.startDateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.startDateTimePicker.CalendarForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.startDateTimePicker.Location = new System.Drawing.Point(378, 460);
            this.startDateTimePicker.Name = "startDateTimePicker";
            this.startDateTimePicker.Size = new System.Drawing.Size(253, 31);
            this.startDateTimePicker.TabIndex = 102;
            // 
            // senderTbxPanel
            // 
            this.senderTbxPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.senderTbxPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.senderTbxPanel.Controls.Add(this.button102);
            this.senderTbxPanel.Controls.Add(this.senderEmailTbx);
            this.senderTbxPanel.Controls.Add(this.button2);
            this.senderTbxPanel.Location = new System.Drawing.Point(240, 320);
            this.senderTbxPanel.Name = "senderTbxPanel";
            this.senderTbxPanel.Size = new System.Drawing.Size(390, 31);
            this.senderTbxPanel.TabIndex = 103;
            // 
            // button102
            // 
            this.button102.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button102.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.button102.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button102.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.button102.Location = new System.Drawing.Point(355, -2);
            this.button102.Name = "button102";
            this.button102.Size = new System.Drawing.Size(35, 35);
            this.button102.TabIndex = 10;
            this.button102.UseVisualStyleBackColor = false;
            // 
            // senderEmailTbx
            // 
            this.senderEmailTbx.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.senderEmailTbx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.senderEmailTbx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.senderEmailTbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.senderEmailTbx.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.senderEmailTbx.HideSelection = false;
            this.senderEmailTbx.Location = new System.Drawing.Point(33, 2);
            this.senderEmailTbx.Name = "senderEmailTbx";
            this.senderEmailTbx.Size = new System.Drawing.Size(324, 24);
            this.senderEmailTbx.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.button2.Location = new System.Drawing.Point(-2, -2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(35, 35);
            this.button2.TabIndex = 9;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // companyTbxPanel
            // 
            this.companyTbxPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.companyTbxPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.companyTbxPanel.Controls.Add(this.button1);
            this.companyTbxPanel.Controls.Add(this.companyTbx);
            this.companyTbxPanel.Controls.Add(this.button3);
            this.companyTbxPanel.Location = new System.Drawing.Point(239, 270);
            this.companyTbxPanel.Name = "companyTbxPanel";
            this.companyTbxPanel.Size = new System.Drawing.Size(392, 31);
            this.companyTbxPanel.TabIndex = 105;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.button1.Location = new System.Drawing.Point(357, -2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 35);
            this.button1.TabIndex = 10;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // companyTbx
            // 
            this.companyTbx.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.companyTbx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.companyTbx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.companyTbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.companyTbx.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.companyTbx.HideSelection = false;
            this.companyTbx.Location = new System.Drawing.Point(33, 2);
            this.companyTbx.Name = "companyTbx";
            this.companyTbx.Size = new System.Drawing.Size(326, 24);
            this.companyTbx.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.button3.Location = new System.Drawing.Point(-2, -2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(35, 35);
            this.button3.TabIndex = 9;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // startDateLbl
            // 
            this.startDateLbl.AutoSize = true;
            this.startDateLbl.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.startDateLbl.Location = new System.Drawing.Point(222, 460);
            this.startDateLbl.Name = "startDateLbl";
            this.startDateLbl.Size = new System.Drawing.Size(63, 25);
            this.startDateLbl.TabIndex = 106;
            this.startDateLbl.Text = "Start:";
            // 
            // endDateLbl
            // 
            this.endDateLbl.AutoSize = true;
            this.endDateLbl.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.endDateLbl.Location = new System.Drawing.Point(222, 510);
            this.endDateLbl.Name = "endDateLbl";
            this.endDateLbl.Size = new System.Drawing.Size(56, 25);
            this.endDateLbl.TabIndex = 107;
            this.endDateLbl.Text = "End:";
            // 
            // endDateTimePicker
            // 
            this.endDateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.endDateTimePicker.CalendarForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.endDateTimePicker.Location = new System.Drawing.Point(379, 510);
            this.endDateTimePicker.Name = "endDateTimePicker";
            this.endDateTimePicker.Size = new System.Drawing.Size(253, 31);
            this.endDateTimePicker.TabIndex = 108;
            // 
            // colorCheckBox
            // 
            this.colorCheckBox.AutoSize = true;
            this.colorCheckBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.colorCheckBox.Location = new System.Drawing.Point(41, 30);
            this.colorCheckBox.Name = "colorCheckBox";
            this.colorCheckBox.Size = new System.Drawing.Size(101, 29);
            this.colorCheckBox.TabIndex = 109;
            this.colorCheckBox.Text = "Color:";
            this.colorCheckBox.UseVisualStyleBackColor = true;
            // 
            // analystCheckBox
            // 
            this.analystCheckBox.AutoSize = true;
            this.analystCheckBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.analystCheckBox.Location = new System.Drawing.Point(41, 83);
            this.analystCheckBox.Name = "analystCheckBox";
            this.analystCheckBox.Size = new System.Drawing.Size(121, 29);
            this.analystCheckBox.TabIndex = 110;
            this.analystCheckBox.Text = "Analyst:";
            this.analystCheckBox.UseVisualStyleBackColor = true;
            // 
            // statusCheckBox
            // 
            this.statusCheckBox.AutoSize = true;
            this.statusCheckBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.statusCheckBox.Location = new System.Drawing.Point(41, 132);
            this.statusCheckBox.Name = "statusCheckBox";
            this.statusCheckBox.Size = new System.Drawing.Size(111, 29);
            this.statusCheckBox.TabIndex = 111;
            this.statusCheckBox.Text = "Status:";
            this.statusCheckBox.UseVisualStyleBackColor = true;
            // 
            // queriedCheckBox
            // 
            this.queriedCheckBox.AutoSize = true;
            this.queriedCheckBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.queriedCheckBox.Location = new System.Drawing.Point(41, 182);
            this.queriedCheckBox.Name = "queriedCheckBox";
            this.queriedCheckBox.Size = new System.Drawing.Size(126, 29);
            this.queriedCheckBox.TabIndex = 112;
            this.queriedCheckBox.Text = "Queried:";
            this.queriedCheckBox.UseVisualStyleBackColor = true;
            // 
            // companyCheckBox
            // 
            this.companyCheckBox.AutoSize = true;
            this.companyCheckBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.companyCheckBox.Location = new System.Drawing.Point(41, 273);
            this.companyCheckBox.Name = "companyCheckBox";
            this.companyCheckBox.Size = new System.Drawing.Size(141, 29);
            this.companyCheckBox.TabIndex = 113;
            this.companyCheckBox.Text = "Company:";
            this.companyCheckBox.UseVisualStyleBackColor = true;
            // 
            // senderCheckBox
            // 
            this.senderCheckBox.AutoSize = true;
            this.senderCheckBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.senderCheckBox.Location = new System.Drawing.Point(41, 323);
            this.senderCheckBox.Name = "senderCheckBox";
            this.senderCheckBox.Size = new System.Drawing.Size(178, 29);
            this.senderCheckBox.TabIndex = 114;
            this.senderCheckBox.Text = "Sender Email:";
            this.senderCheckBox.UseVisualStyleBackColor = true;
            // 
            // dateCheckBox
            // 
            this.dateCheckBox.AutoSize = true;
            this.dateCheckBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.dateCheckBox.Location = new System.Drawing.Point(41, 459);
            this.dateCheckBox.Name = "dateCheckBox";
            this.dateCheckBox.Size = new System.Drawing.Size(95, 29);
            this.dateCheckBox.TabIndex = 115;
            this.dateCheckBox.Text = "Date:";
            this.dateCheckBox.UseVisualStyleBackColor = true;
            // 
            // queriedComboBox
            // 
            this.queriedComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.queriedComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.queriedComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.queriedComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.queriedComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.queriedComboBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.queriedComboBox.FormattingEnabled = true;
            this.queriedComboBox.Location = new System.Drawing.Point(378, 180);
            this.queriedComboBox.Name = "queriedComboBox";
            this.queriedComboBox.Size = new System.Drawing.Size(253, 33);
            this.queriedComboBox.TabIndex = 116;
            // 
            // clearBtn
            // 
            this.clearBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clearBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.clearBtn.Location = new System.Drawing.Point(417, 600);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(100, 35);
            this.clearBtn.TabIndex = 117;
            this.clearBtn.Text = "Clear";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // statusLbl
            // 
            this.statusLbl.AutoSize = true;
            this.statusLbl.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.statusLbl.Location = new System.Drawing.Point(32, 610);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(79, 25);
            this.statusLbl.TabIndex = 118;
            this.statusLbl.Text = "Status:";
            this.statusLbl.Visible = false;
            // 
            // subjectCheckBox
            // 
            this.subjectCheckBox.AutoSize = true;
            this.subjectCheckBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.subjectCheckBox.Location = new System.Drawing.Point(40, 373);
            this.subjectCheckBox.Name = "subjectCheckBox";
            this.subjectCheckBox.Size = new System.Drawing.Size(181, 29);
            this.subjectCheckBox.TabIndex = 120;
            this.subjectCheckBox.Text = "Email Subject:";
            this.subjectCheckBox.UseVisualStyleBackColor = true;
            // 
            // subjectTbxPanel
            // 
            this.subjectTbxPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.subjectTbxPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.subjectTbxPanel.Controls.Add(this.button4);
            this.subjectTbxPanel.Controls.Add(this.subjectTbx);
            this.subjectTbxPanel.Controls.Add(this.button5);
            this.subjectTbxPanel.Location = new System.Drawing.Point(240, 370);
            this.subjectTbxPanel.Name = "subjectTbxPanel";
            this.subjectTbxPanel.Size = new System.Drawing.Size(390, 31);
            this.subjectTbxPanel.TabIndex = 119;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.button4.Location = new System.Drawing.Point(355, -2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(35, 35);
            this.button4.TabIndex = 10;
            this.button4.UseVisualStyleBackColor = false;
            // 
            // subjectTbx
            // 
            this.subjectTbx.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.subjectTbx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.subjectTbx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.subjectTbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subjectTbx.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.subjectTbx.HideSelection = false;
            this.subjectTbx.Location = new System.Drawing.Point(33, 2);
            this.subjectTbx.Name = "subjectTbx";
            this.subjectTbx.Size = new System.Drawing.Size(324, 24);
            this.subjectTbx.TabIndex = 1;
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.button5.Location = new System.Drawing.Point(-2, -2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(35, 35);
            this.button5.TabIndex = 9;
            this.button5.UseVisualStyleBackColor = false;
            // 
            // FiltersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(674, 669);
            this.Controls.Add(this.subjectCheckBox);
            this.Controls.Add(this.subjectTbxPanel);
            this.Controls.Add(this.statusLbl);
            this.Controls.Add(this.clearBtn);
            this.Controls.Add(this.queriedComboBox);
            this.Controls.Add(this.dateCheckBox);
            this.Controls.Add(this.senderCheckBox);
            this.Controls.Add(this.companyCheckBox);
            this.Controls.Add(this.queriedCheckBox);
            this.Controls.Add(this.statusCheckBox);
            this.Controls.Add(this.analystCheckBox);
            this.Controls.Add(this.colorCheckBox);
            this.Controls.Add(this.endDateTimePicker);
            this.Controls.Add(this.endDateLbl);
            this.Controls.Add(this.startDateLbl);
            this.Controls.Add(this.companyTbxPanel);
            this.Controls.Add(this.senderTbxPanel);
            this.Controls.Add(this.startDateTimePicker);
            this.Controls.Add(this.statusComboBox);
            this.Controls.Add(this.analystComboBox);
            this.Controls.Add(this.colorComboBox);
            this.Controls.Add(this.saveBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FiltersForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Filter Options";
            this.senderTbxPanel.ResumeLayout(false);
            this.senderTbxPanel.PerformLayout();
            this.companyTbxPanel.ResumeLayout(false);
            this.companyTbxPanel.PerformLayout();
            this.subjectTbxPanel.ResumeLayout(false);
            this.subjectTbxPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.ComboBox colorComboBox;
        private System.Windows.Forms.ComboBox analystComboBox;
        private System.Windows.Forms.ComboBox statusComboBox;
        private System.Windows.Forms.DateTimePicker startDateTimePicker;
        private System.Windows.Forms.Panel senderTbxPanel;
        private System.Windows.Forms.Button button102;
        private System.Windows.Forms.TextBox senderEmailTbx;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel companyTbxPanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox companyTbx;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label startDateLbl;
        private System.Windows.Forms.Label endDateLbl;
        private System.Windows.Forms.DateTimePicker endDateTimePicker;
        private System.Windows.Forms.CheckBox colorCheckBox;
        private System.Windows.Forms.CheckBox analystCheckBox;
        private System.Windows.Forms.CheckBox statusCheckBox;
        private System.Windows.Forms.CheckBox queriedCheckBox;
        private System.Windows.Forms.CheckBox companyCheckBox;
        private System.Windows.Forms.CheckBox senderCheckBox;
        private System.Windows.Forms.CheckBox dateCheckBox;
        private System.Windows.Forms.ComboBox queriedComboBox;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.Label statusLbl;
        private System.Windows.Forms.CheckBox subjectCheckBox;
        private System.Windows.Forms.Panel subjectTbxPanel;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox subjectTbx;
        private System.Windows.Forms.Button button5;
    }
}