namespace TimeTracker
{
    partial class TimeTracker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimeTracker));
            this.userIDLabel = new System.Windows.Forms.Label();
            this.userIDBox = new System.Windows.Forms.TextBox();
            this.startTimeBox = new System.Windows.Forms.ComboBox();
            this.startTimeLabel = new System.Windows.Forms.Label();
            this.group1 = new System.Windows.Forms.GroupBox();
            this.expressSubjects = new System.Windows.Forms.ComboBox();
            this.appDatePick = new System.Windows.Forms.Panel();
            this.todayDate = new System.Windows.Forms.Label();
            this.embedEndTime = new System.Windows.Forms.Panel();
            this.endHr = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.endAM = new System.Windows.Forms.RadioButton();
            this.endPM = new System.Windows.Forms.RadioButton();
            this.endMin = new System.Windows.Forms.ComboBox();
            this.embedStartTime = new System.Windows.Forms.Panel();
            this.startHr = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.startAM = new System.Windows.Forms.RadioButton();
            this.startPM = new System.Windows.Forms.RadioButton();
            this.startMin = new System.Windows.Forms.ComboBox();
            this.optionPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.twoHRApp = new System.Windows.Forms.CheckBox();
            this.noShow = new System.Windows.Forms.CheckBox();
            this.specProgLabel = new System.Windows.Forms.Label();
            this.specProgCheckBox = new System.Windows.Forms.CheckedListBox();
            this.typePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.appointmentCheck = new System.Windows.Forms.RadioButton();
            this.expressCheck = new System.Windows.Forms.RadioButton();
            this.embedCheck = new System.Windows.Forms.RadioButton();
            this.appSubjects = new System.Windows.Forms.ComboBox();
            this.subjectLabel = new System.Windows.Forms.Label();
            this.ttLogo = new System.Windows.Forms.PictureBox();
            this.appDateLabel = new System.Windows.Forms.Label();
            this.endTimeLabel = new System.Windows.Forms.Label();
            this.endTimeBox = new System.Windows.Forms.ComboBox();
            this.logoutButton = new System.Windows.Forms.Button();
            this.tuteeIDBox = new System.Windows.Forms.TextBox();
            this.tuteeIDLabel = new System.Windows.Forms.Label();
            this.submitButton = new System.Windows.Forms.Button();
            this.multEntriesBox = new System.Windows.Forms.CheckBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.logoPic = new System.Windows.Forms.PictureBox();
            this.clockPanel = new System.Windows.Forms.Panel();
            this.clockOUT = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.clockIN = new System.Windows.Forms.Button();
            this.clearkLoginClock = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.group1.SuspendLayout();
            this.appDatePick.SuspendLayout();
            this.embedEndTime.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.embedStartTime.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.optionPanel.SuspendLayout();
            this.typePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ttLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoPic)).BeginInit();
            this.clockPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // userIDLabel
            // 
            this.userIDLabel.AutoSize = true;
            this.userIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userIDLabel.Location = new System.Drawing.Point(231, 705);
            this.userIDLabel.Name = "userIDLabel";
            this.userIDLabel.Size = new System.Drawing.Size(86, 26);
            this.userIDLabel.TabIndex = 0;
            this.userIDLabel.Text = "User ID";
            // 
            // userIDBox
            // 
            this.userIDBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userIDBox.Location = new System.Drawing.Point(231, 734);
            this.userIDBox.MaxLength = 7;
            this.userIDBox.Name = "userIDBox";
            this.userIDBox.Size = new System.Drawing.Size(175, 56);
            this.userIDBox.TabIndex = 1;
            // 
            // startTimeBox
            // 
            this.startTimeBox.FormattingEnabled = true;
            this.startTimeBox.Location = new System.Drawing.Point(435, 25);
            this.startTimeBox.Name = "startTimeBox";
            this.startTimeBox.Size = new System.Drawing.Size(121, 21);
            this.startTimeBox.TabIndex = 2;
            this.startTimeBox.Text = "Select Time";
            // 
            // startTimeLabel
            // 
            this.startTimeLabel.AutoSize = true;
            this.startTimeLabel.Location = new System.Drawing.Point(435, 9);
            this.startTimeLabel.Name = "startTimeLabel";
            this.startTimeLabel.Size = new System.Drawing.Size(55, 13);
            this.startTimeLabel.TabIndex = 3;
            this.startTimeLabel.Text = "Start Time";
            // 
            // group1
            // 
            this.group1.AutoSize = true;
            this.group1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.group1.Controls.Add(this.expressSubjects);
            this.group1.Controls.Add(this.appDatePick);
            this.group1.Controls.Add(this.embedEndTime);
            this.group1.Controls.Add(this.embedStartTime);
            this.group1.Controls.Add(this.optionPanel);
            this.group1.Controls.Add(this.typePanel);
            this.group1.Controls.Add(this.appSubjects);
            this.group1.Controls.Add(this.subjectLabel);
            this.group1.Controls.Add(this.ttLogo);
            this.group1.Controls.Add(this.appDateLabel);
            this.group1.Controls.Add(this.endTimeLabel);
            this.group1.Controls.Add(this.endTimeBox);
            this.group1.Controls.Add(this.logoutButton);
            this.group1.Controls.Add(this.tuteeIDBox);
            this.group1.Controls.Add(this.tuteeIDLabel);
            this.group1.Controls.Add(this.submitButton);
            this.group1.Controls.Add(this.multEntriesBox);
            this.group1.Controls.Add(this.loginButton);
            this.group1.Controls.Add(this.logoPic);
            this.group1.Controls.Add(this.startTimeLabel);
            this.group1.Controls.Add(this.startTimeBox);
            this.group1.Controls.Add(this.userIDBox);
            this.group1.Controls.Add(this.userIDLabel);
            this.group1.Controls.Add(this.clockPanel);
            this.group1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.group1.Location = new System.Drawing.Point(0, 0);
            this.group1.Name = "group1";
            this.group1.Size = new System.Drawing.Size(800, 800);
            this.group1.TabIndex = 0;
            this.group1.TabStop = false;
            this.group1.Text = "Version:";
            // 
            // expressSubjects
            // 
            this.expressSubjects.FormattingEnabled = true;
            this.expressSubjects.Location = new System.Drawing.Point(435, 131);
            this.expressSubjects.Name = "expressSubjects";
            this.expressSubjects.Size = new System.Drawing.Size(121, 21);
            this.expressSubjects.TabIndex = 42;
            this.expressSubjects.Text = "Select One";
            // 
            // appDatePick
            // 
            this.appDatePick.Controls.Add(this.todayDate);
            this.appDatePick.Location = new System.Drawing.Point(566, 88);
            this.appDatePick.Name = "appDatePick";
            this.appDatePick.Size = new System.Drawing.Size(227, 162);
            this.appDatePick.TabIndex = 40;
            // 
            // todayDate
            // 
            this.todayDate.AutoSize = true;
            this.todayDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.todayDate.Location = new System.Drawing.Point(15, 58);
            this.todayDate.Name = "todayDate";
            this.todayDate.Size = new System.Drawing.Size(196, 46);
            this.todayDate.TabIndex = 0;
            this.todayDate.Text = "7/10/2017";
            // 
            // embedEndTime
            // 
            this.embedEndTime.Controls.Add(this.endHr);
            this.embedEndTime.Controls.Add(this.label1);
            this.embedEndTime.Controls.Add(this.flowLayoutPanel2);
            this.embedEndTime.Controls.Add(this.endMin);
            this.embedEndTime.Location = new System.Drawing.Point(563, 47);
            this.embedEndTime.Name = "embedEndTime";
            this.embedEndTime.Size = new System.Drawing.Size(185, 30);
            this.embedEndTime.TabIndex = 37;
            // 
            // endHr
            // 
            this.endHr.FormattingEnabled = true;
            this.endHr.Location = new System.Drawing.Point(3, 3);
            this.endHr.Name = "endHr";
            this.endHr.Size = new System.Drawing.Size(35, 21);
            this.endHr.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = ":";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.endAM);
            this.flowLayoutPanel2.Controls.Add(this.endPM);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(87, 2);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(95, 22);
            this.flowLayoutPanel2.TabIndex = 34;
            // 
            // endAM
            // 
            this.endAM.AutoSize = true;
            this.endAM.Location = new System.Drawing.Point(3, 3);
            this.endAM.Name = "endAM";
            this.endAM.Size = new System.Drawing.Size(41, 17);
            this.endAM.TabIndex = 0;
            this.endAM.TabStop = true;
            this.endAM.Text = "AM";
            this.endAM.UseVisualStyleBackColor = true;
            // 
            // endPM
            // 
            this.endPM.AutoSize = true;
            this.endPM.Location = new System.Drawing.Point(50, 3);
            this.endPM.Name = "endPM";
            this.endPM.Size = new System.Drawing.Size(41, 17);
            this.endPM.TabIndex = 1;
            this.endPM.TabStop = true;
            this.endPM.Text = "PM";
            this.endPM.UseVisualStyleBackColor = true;
            // 
            // endMin
            // 
            this.endMin.FormattingEnabled = true;
            this.endMin.Location = new System.Drawing.Point(47, 3);
            this.endMin.Name = "endMin";
            this.endMin.Size = new System.Drawing.Size(35, 21);
            this.endMin.TabIndex = 28;
            // 
            // embedStartTime
            // 
            this.embedStartTime.Controls.Add(this.startHr);
            this.embedStartTime.Controls.Add(this.label2);
            this.embedStartTime.Controls.Add(this.flowLayoutPanel1);
            this.embedStartTime.Controls.Add(this.startMin);
            this.embedStartTime.Location = new System.Drawing.Point(563, 12);
            this.embedStartTime.Name = "embedStartTime";
            this.embedStartTime.Size = new System.Drawing.Size(185, 30);
            this.embedStartTime.TabIndex = 36;
            // 
            // startHr
            // 
            this.startHr.FormattingEnabled = true;
            this.startHr.Location = new System.Drawing.Point(3, 3);
            this.startHr.Name = "startHr";
            this.startHr.Size = new System.Drawing.Size(35, 21);
            this.startHr.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = ":";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.startAM);
            this.flowLayoutPanel1.Controls.Add(this.startPM);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(87, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(95, 22);
            this.flowLayoutPanel1.TabIndex = 34;
            // 
            // startAM
            // 
            this.startAM.AutoSize = true;
            this.startAM.Location = new System.Drawing.Point(3, 3);
            this.startAM.Name = "startAM";
            this.startAM.Size = new System.Drawing.Size(41, 17);
            this.startAM.TabIndex = 0;
            this.startAM.TabStop = true;
            this.startAM.Text = "AM";
            this.startAM.UseVisualStyleBackColor = true;
            // 
            // startPM
            // 
            this.startPM.AutoSize = true;
            this.startPM.Location = new System.Drawing.Point(50, 3);
            this.startPM.Name = "startPM";
            this.startPM.Size = new System.Drawing.Size(41, 17);
            this.startPM.TabIndex = 1;
            this.startPM.TabStop = true;
            this.startPM.Text = "PM";
            this.startPM.UseVisualStyleBackColor = true;
            // 
            // startMin
            // 
            this.startMin.FormattingEnabled = true;
            this.startMin.Location = new System.Drawing.Point(47, 3);
            this.startMin.Name = "startMin";
            this.startMin.Size = new System.Drawing.Size(35, 21);
            this.startMin.TabIndex = 28;
            // 
            // optionPanel
            // 
            this.optionPanel.Controls.Add(this.twoHRApp);
            this.optionPanel.Controls.Add(this.noShow);
            this.optionPanel.Controls.Add(this.specProgLabel);
            this.optionPanel.Controls.Add(this.specProgCheckBox);
            this.optionPanel.Location = new System.Drawing.Point(277, 85);
            this.optionPanel.Name = "optionPanel";
            this.optionPanel.Size = new System.Drawing.Size(130, 183);
            this.optionPanel.TabIndex = 26;
            // 
            // twoHRApp
            // 
            this.twoHRApp.AutoSize = true;
            this.twoHRApp.Location = new System.Drawing.Point(3, 3);
            this.twoHRApp.Name = "twoHRApp";
            this.twoHRApp.Size = new System.Drawing.Size(120, 17);
            this.twoHRApp.TabIndex = 9;
            this.twoHRApp.Text = "2-Hour Appintment?";
            this.twoHRApp.UseVisualStyleBackColor = true;
            // 
            // noShow
            // 
            this.noShow.AutoSize = true;
            this.noShow.Location = new System.Drawing.Point(3, 26);
            this.noShow.Name = "noShow";
            this.noShow.Size = new System.Drawing.Size(74, 17);
            this.noShow.TabIndex = 10;
            this.noShow.Text = "No show?";
            this.noShow.UseVisualStyleBackColor = true;
            // 
            // specProgLabel
            // 
            this.specProgLabel.AutoSize = true;
            this.specProgLabel.Location = new System.Drawing.Point(3, 46);
            this.specProgLabel.Name = "specProgLabel";
            this.specProgLabel.Size = new System.Drawing.Size(89, 13);
            this.specProgLabel.TabIndex = 12;
            this.specProgLabel.Text = "Special Programs";
            // 
            // specProgCheckBox
            // 
            this.specProgCheckBox.FormattingEnabled = true;
            this.specProgCheckBox.Items.AddRange(new object[] {
            "EOPS",
            "SSS",
            "DRC",
            "CalWorks",
            "Puente",
            "T3P",
            "STEM"});
            this.specProgCheckBox.Location = new System.Drawing.Point(3, 62);
            this.specProgCheckBox.Name = "specProgCheckBox";
            this.specProgCheckBox.Size = new System.Drawing.Size(120, 109);
            this.specProgCheckBox.TabIndex = 11;
            // 
            // typePanel
            // 
            this.typePanel.Controls.Add(this.appointmentCheck);
            this.typePanel.Controls.Add(this.expressCheck);
            this.typePanel.Controls.Add(this.embedCheck);
            this.typePanel.Location = new System.Drawing.Point(559, 256);
            this.typePanel.Name = "typePanel";
            this.typePanel.Size = new System.Drawing.Size(235, 24);
            this.typePanel.TabIndex = 25;
            // 
            // appointmentCheck
            // 
            this.appointmentCheck.AutoSize = true;
            this.appointmentCheck.Location = new System.Drawing.Point(3, 3);
            this.appointmentCheck.Name = "appointmentCheck";
            this.appointmentCheck.Size = new System.Drawing.Size(84, 17);
            this.appointmentCheck.TabIndex = 35;
            this.appointmentCheck.TabStop = true;
            this.appointmentCheck.Text = "Appointment";
            this.appointmentCheck.UseVisualStyleBackColor = true;
            this.appointmentCheck.CheckedChanged += new System.EventHandler(this.appointmentCheck_CheckedChanged);
            // 
            // expressCheck
            // 
            this.expressCheck.AutoSize = true;
            this.expressCheck.Location = new System.Drawing.Point(93, 3);
            this.expressCheck.Name = "expressCheck";
            this.expressCheck.Size = new System.Drawing.Size(62, 17);
            this.expressCheck.TabIndex = 34;
            this.expressCheck.TabStop = true;
            this.expressCheck.Text = "Express";
            this.expressCheck.UseVisualStyleBackColor = true;
            this.expressCheck.CheckedChanged += new System.EventHandler(this.expressCheck_CheckedChanged);
            // 
            // embedCheck
            // 
            this.embedCheck.AutoSize = true;
            this.embedCheck.Location = new System.Drawing.Point(161, 3);
            this.embedCheck.Name = "embedCheck";
            this.embedCheck.Size = new System.Drawing.Size(70, 17);
            this.embedCheck.TabIndex = 34;
            this.embedCheck.TabStop = true;
            this.embedCheck.Text = "Embeded";
            this.embedCheck.UseVisualStyleBackColor = true;
            this.embedCheck.CheckedChanged += new System.EventHandler(this.embedCheck_CheckedChanged);
            // 
            // appSubjects
            // 
            this.appSubjects.FormattingEnabled = true;
            this.appSubjects.Location = new System.Drawing.Point(435, 104);
            this.appSubjects.Name = "appSubjects";
            this.appSubjects.Size = new System.Drawing.Size(121, 21);
            this.appSubjects.TabIndex = 23;
            this.appSubjects.Text = "Select One";
            // 
            // subjectLabel
            // 
            this.subjectLabel.AutoSize = true;
            this.subjectLabel.Location = new System.Drawing.Point(435, 88);
            this.subjectLabel.Name = "subjectLabel";
            this.subjectLabel.Size = new System.Drawing.Size(43, 13);
            this.subjectLabel.TabIndex = 22;
            this.subjectLabel.Text = "Subject";
            // 
            // ttLogo
            // 
            this.ttLogo.Image = ((System.Drawing.Image)(resources.GetObject("ttLogo.Image")));
            this.ttLogo.Location = new System.Drawing.Point(12, 12);
            this.ttLogo.Name = "ttLogo";
            this.ttLogo.Size = new System.Drawing.Size(256, 256);
            this.ttLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ttLogo.TabIndex = 21;
            this.ttLogo.TabStop = false;
            // 
            // appDateLabel
            // 
            this.appDateLabel.AutoSize = true;
            this.appDateLabel.Location = new System.Drawing.Point(563, 77);
            this.appDateLabel.Name = "appDateLabel";
            this.appDateLabel.Size = new System.Drawing.Size(40, 13);
            this.appDateLabel.TabIndex = 20;
            this.appDateLabel.Text = "Today:";
            // 
            // endTimeLabel
            // 
            this.endTimeLabel.AutoSize = true;
            this.endTimeLabel.Location = new System.Drawing.Point(274, 9);
            this.endTimeLabel.Name = "endTimeLabel";
            this.endTimeLabel.Size = new System.Drawing.Size(52, 13);
            this.endTimeLabel.TabIndex = 19;
            this.endTimeLabel.Text = "End Time";
            // 
            // endTimeBox
            // 
            this.endTimeBox.FormattingEnabled = true;
            this.endTimeBox.Location = new System.Drawing.Point(277, 25);
            this.endTimeBox.Name = "endTimeBox";
            this.endTimeBox.Size = new System.Drawing.Size(121, 21);
            this.endTimeBox.TabIndex = 18;
            // 
            // logoutButton
            // 
            this.logoutButton.Location = new System.Drawing.Point(358, 52);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(75, 23);
            this.logoutButton.TabIndex = 16;
            this.logoutButton.Text = "Logout";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // tuteeIDBox
            // 
            this.tuteeIDBox.Location = new System.Drawing.Point(435, 65);
            this.tuteeIDBox.MaxLength = 7;
            this.tuteeIDBox.MinimumSize = new System.Drawing.Size(4, 21);
            this.tuteeIDBox.Name = "tuteeIDBox";
            this.tuteeIDBox.Size = new System.Drawing.Size(121, 20);
            this.tuteeIDBox.TabIndex = 15;
            this.tuteeIDBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tuteeIDBox_KeyPress);
            // 
            // tuteeIDLabel
            // 
            this.tuteeIDLabel.AutoSize = true;
            this.tuteeIDLabel.Location = new System.Drawing.Point(435, 49);
            this.tuteeIDLabel.Name = "tuteeIDLabel";
            this.tuteeIDLabel.Size = new System.Drawing.Size(49, 13);
            this.tuteeIDLabel.TabIndex = 14;
            this.tuteeIDLabel.Text = "Tutee ID";
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(277, 52);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(75, 23);
            this.submitButton.TabIndex = 13;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // multEntriesBox
            // 
            this.multEntriesBox.AutoSize = true;
            this.multEntriesBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.multEntriesBox.Location = new System.Drawing.Point(412, 706);
            this.multEntriesBox.Name = "multEntriesBox";
            this.multEntriesBox.Size = new System.Drawing.Size(180, 30);
            this.multEntriesBox.TabIndex = 8;
            this.multEntriesBox.Text = "Multiple Entries";
            this.multEntriesBox.UseVisualStyleBackColor = true;
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(412, 753);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(113, 41);
            this.loginButton.TabIndex = 6;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // logoPic
            // 
            this.logoPic.Image = ((System.Drawing.Image)(resources.GetObject("logoPic.Image")));
            this.logoPic.Location = new System.Drawing.Point(6, 706);
            this.logoPic.Name = "logoPic";
            this.logoPic.Size = new System.Drawing.Size(219, 88);
            this.logoPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.logoPic.TabIndex = 4;
            this.logoPic.TabStop = false;
            // 
            // clockPanel
            // 
            this.clockPanel.Controls.Add(this.clockOUT);
            this.clockPanel.Controls.Add(this.cancelButton);
            this.clockPanel.Controls.Add(this.clockIN);
            this.clockPanel.Controls.Add(this.clearkLoginClock);
            this.clockPanel.Controls.Add(this.label3);
            this.clockPanel.Location = new System.Drawing.Point(12, 291);
            this.clockPanel.Name = "clockPanel";
            this.clockPanel.Size = new System.Drawing.Size(600, 250);
            this.clockPanel.TabIndex = 39;
            // 
            // clockOUT
            // 
            this.clockOUT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clockOUT.Location = new System.Drawing.Point(93, 173);
            this.clockOUT.Name = "clockOUT";
            this.clockOUT.Size = new System.Drawing.Size(135, 60);
            this.clockOUT.TabIndex = 41;
            this.clockOUT.Text = "Clock Out";
            this.clockOUT.UseVisualStyleBackColor = true;
            this.clockOUT.Click += new System.EventHandler(this.clockOUT_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(366, 173);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(135, 60);
            this.cancelButton.TabIndex = 41;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // clockIN
            // 
            this.clockIN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clockIN.Location = new System.Drawing.Point(93, 173);
            this.clockIN.Name = "clockIN";
            this.clockIN.Size = new System.Drawing.Size(135, 60);
            this.clockIN.TabIndex = 40;
            this.clockIN.Text = "Clock In";
            this.clockIN.UseVisualStyleBackColor = true;
            this.clockIN.Click += new System.EventHandler(this.clockIN_Click);
            // 
            // clearkLoginClock
            // 
            this.clearkLoginClock.AutoSize = true;
            this.clearkLoginClock.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearkLoginClock.Location = new System.Drawing.Point(85, 78);
            this.clearkLoginClock.Name = "clearkLoginClock";
            this.clearkLoginClock.Size = new System.Drawing.Size(430, 46);
            this.clearkLoginClock.TabIndex = 38;
            this.clearkLoginClock.Text = "7/7/2017 05:05:05 PM";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(164, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(272, 51);
            this.label3.TabIndex = 40;
            this.label3.Text = "Current Time";
            // 
            // TimeTracker
            // 
            this.AcceptButton = this.loginButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 800);
            this.Controls.Add(this.group1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TimeTracker";
            this.Text = "Time Tracker";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.appDatePick.ResumeLayout(false);
            this.appDatePick.PerformLayout();
            this.embedEndTime.ResumeLayout(false);
            this.embedEndTime.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.embedStartTime.ResumeLayout(false);
            this.embedStartTime.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.optionPanel.ResumeLayout(false);
            this.optionPanel.PerformLayout();
            this.typePanel.ResumeLayout(false);
            this.typePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ttLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoPic)).EndInit();
            this.clockPanel.ResumeLayout(false);
            this.clockPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label userIDLabel;
        private System.Windows.Forms.TextBox userIDBox;
        private System.Windows.Forms.ComboBox startTimeBox;
        private System.Windows.Forms.Label startTimeLabel;
        private System.Windows.Forms.GroupBox group1;
        private System.Windows.Forms.PictureBox logoPic;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.CheckBox multEntriesBox;
        private System.Windows.Forms.CheckedListBox specProgCheckBox;
        private System.Windows.Forms.CheckBox noShow;
        private System.Windows.Forms.CheckBox twoHRApp;
        private System.Windows.Forms.Label specProgLabel;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.TextBox tuteeIDBox;
        private System.Windows.Forms.Label tuteeIDLabel;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.ComboBox endTimeBox;
        private System.Windows.Forms.Label endTimeLabel;
        private System.Windows.Forms.Label appDateLabel;
        private System.Windows.Forms.PictureBox ttLogo;
        private System.Windows.Forms.ComboBox appSubjects;
        private System.Windows.Forms.Label subjectLabel;
        private System.Windows.Forms.FlowLayoutPanel typePanel;
        private System.Windows.Forms.FlowLayoutPanel optionPanel;
        private System.Windows.Forms.ComboBox startHr;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox startMin;
        private System.Windows.Forms.RadioButton expressCheck;
        private System.Windows.Forms.RadioButton embedCheck;
        private System.Windows.Forms.Panel embedEndTime;
        private System.Windows.Forms.ComboBox endHr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.RadioButton endAM;
        private System.Windows.Forms.RadioButton endPM;
        private System.Windows.Forms.ComboBox endMin;
        private System.Windows.Forms.Panel embedStartTime;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton startAM;
        private System.Windows.Forms.RadioButton startPM;
        private System.Windows.Forms.RadioButton appointmentCheck;
        private System.Windows.Forms.Label clearkLoginClock;
        private System.Windows.Forms.Panel clockPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button clockIN;
        private System.Windows.Forms.Button clockOUT;
        private System.Windows.Forms.Panel appDatePick;
        private System.Windows.Forms.Label todayDate;
        private System.Windows.Forms.ComboBox expressSubjects;
    }
}

