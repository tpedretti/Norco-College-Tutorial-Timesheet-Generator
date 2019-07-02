namespace TS_Master_Budget_App
{
    partial class MainWindow
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
            this.getUsers = new System.Windows.Forms.Button();
            this.appGrid = new System.Windows.Forms.DataGridView();
            this.dbID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.appDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noShow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eops = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sss = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.drc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calworks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.puente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.t3p = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monthCombo = new System.Windows.Forms.ComboBox();
            this.yearCombo = new System.Windows.Forms.ComboBox();
            this.getUserLogButton = new System.Windows.Forms.Button();
            this.timesheetPDF = new System.Windows.Forms.Button();
            this.userListBox = new System.Windows.Forms.CheckedListBox();
            this.timeLogPanel = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.programOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertInfoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.appGrid)).BeginInit();
            this.timeLogPanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // getUsers
            // 
            this.getUsers.Location = new System.Drawing.Point(392, 3);
            this.getUsers.Name = "getUsers";
            this.getUsers.Size = new System.Drawing.Size(75, 23);
            this.getUsers.TabIndex = 0;
            this.getUsers.Text = "Get Users";
            this.getUsers.UseVisualStyleBackColor = true;
            this.getUsers.Click += new System.EventHandler(this.getUsers_Click);
            // 
            // appGrid
            // 
            this.appGrid.AllowUserToDeleteRows = false;
            this.appGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.appGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dbID,
            this.appDate,
            this.studentID,
            this.subject,
            this.startTime,
            this.endTime,
            this.totalHours,
            this.noShow,
            this.eops,
            this.sss,
            this.drc,
            this.calworks,
            this.puente,
            this.t3p});
            this.appGrid.Location = new System.Drawing.Point(70, 239);
            this.appGrid.Name = "appGrid";
            this.appGrid.Size = new System.Drawing.Size(1140, 350);
            this.appGrid.TabIndex = 2;
            // 
            // dbID
            // 
            this.dbID.HeaderText = "Database ID";
            this.dbID.Name = "dbID";
            // 
            // appDate
            // 
            this.appDate.HeaderText = "Date";
            this.appDate.Name = "appDate";
            // 
            // studentID
            // 
            this.studentID.HeaderText = "Student ID";
            this.studentID.Name = "studentID";
            // 
            // subject
            // 
            this.subject.HeaderText = "Subject";
            this.subject.Name = "subject";
            // 
            // startTime
            // 
            this.startTime.HeaderText = "Start";
            this.startTime.Name = "startTime";
            // 
            // endTime
            // 
            this.endTime.HeaderText = "End";
            this.endTime.Name = "endTime";
            // 
            // totalHours
            // 
            this.totalHours.HeaderText = "Hours";
            this.totalHours.Name = "totalHours";
            // 
            // noShow
            // 
            this.noShow.HeaderText = "No Show";
            this.noShow.Name = "noShow";
            this.noShow.Width = 55;
            // 
            // eops
            // 
            this.eops.HeaderText = "EOPS";
            this.eops.Name = "eops";
            this.eops.Width = 55;
            // 
            // sss
            // 
            this.sss.HeaderText = "SSS";
            this.sss.Name = "sss";
            this.sss.Width = 55;
            // 
            // drc
            // 
            this.drc.HeaderText = "DRC";
            this.drc.Name = "drc";
            this.drc.Width = 55;
            // 
            // calworks
            // 
            this.calworks.HeaderText = "CalWorks";
            this.calworks.Name = "calworks";
            this.calworks.Width = 55;
            // 
            // puente
            // 
            this.puente.HeaderText = "Puente";
            this.puente.Name = "puente";
            this.puente.Width = 55;
            // 
            // t3p
            // 
            this.t3p.HeaderText = "T3P";
            this.t3p.Name = "t3p";
            this.t3p.Width = 55;
            // 
            // monthCombo
            // 
            this.monthCombo.FormattingEnabled = true;
            this.monthCombo.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.monthCombo.Location = new System.Drawing.Point(473, 5);
            this.monthCombo.Name = "monthCombo";
            this.monthCombo.Size = new System.Drawing.Size(121, 21);
            this.monthCombo.TabIndex = 3;
            this.monthCombo.Text = "Select Month";
            // 
            // yearCombo
            // 
            this.yearCombo.FormattingEnabled = true;
            this.yearCombo.Items.AddRange(new object[] {
            "2017",
            "2018",
            "2019",
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025"});
            this.yearCombo.Location = new System.Drawing.Point(600, 5);
            this.yearCombo.Name = "yearCombo";
            this.yearCombo.Size = new System.Drawing.Size(121, 21);
            this.yearCombo.TabIndex = 4;
            this.yearCombo.Text = "Select Year";
            // 
            // getUserLogButton
            // 
            this.getUserLogButton.Location = new System.Drawing.Point(727, 3);
            this.getUserLogButton.Name = "getUserLogButton";
            this.getUserLogButton.Size = new System.Drawing.Size(121, 23);
            this.getUserLogButton.TabIndex = 5;
            this.getUserLogButton.Text = "Get User Log";
            this.getUserLogButton.UseVisualStyleBackColor = true;
            this.getUserLogButton.Click += new System.EventHandler(this.getUserLogButton_Click);
            // 
            // timesheetPDF
            // 
            this.timesheetPDF.Location = new System.Drawing.Point(558, 605);
            this.timesheetPDF.Name = "timesheetPDF";
            this.timesheetPDF.Size = new System.Drawing.Size(125, 25);
            this.timesheetPDF.TabIndex = 8;
            this.timesheetPDF.Text = "Create Timesheet";
            this.timesheetPDF.UseVisualStyleBackColor = true;
            this.timesheetPDF.Click += new System.EventHandler(this.timesheetPDF_Click);
            // 
            // userListBox
            // 
            this.userListBox.ColumnWidth = 200;
            this.userListBox.FormattingEnabled = true;
            this.userListBox.Location = new System.Drawing.Point(70, 34);
            this.userListBox.MultiColumn = true;
            this.userListBox.Name = "userListBox";
            this.userListBox.Size = new System.Drawing.Size(1140, 199);
            this.userListBox.TabIndex = 1;
            this.userListBox.UseCompatibleTextRendering = true;
            this.userListBox.SelectedIndexChanged += new System.EventHandler(this.userListBox_SelectedIndexChanged);
            // 
            // timeLogPanel
            // 
            this.timeLogPanel.Controls.Add(this.getUsers);
            this.timeLogPanel.Controls.Add(this.appGrid);
            this.timeLogPanel.Controls.Add(this.timesheetPDF);
            this.timeLogPanel.Controls.Add(this.userListBox);
            this.timeLogPanel.Controls.Add(this.monthCombo);
            this.timeLogPanel.Controls.Add(this.getUserLogButton);
            this.timeLogPanel.Controls.Add(this.yearCombo);
            this.timeLogPanel.Location = new System.Drawing.Point(12, 52);
            this.timeLogPanel.Name = "timeLogPanel";
            this.timeLogPanel.Size = new System.Drawing.Size(1240, 650);
            this.timeLogPanel.TabIndex = 9;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(1264, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertInfoToolStripMenuItem1,
            this.programOptionsToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // programOptionsToolStripMenuItem
            // 
            this.programOptionsToolStripMenuItem.Name = "programOptionsToolStripMenuItem";
            this.programOptionsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.programOptionsToolStripMenuItem.Text = "Program Options";
            this.programOptionsToolStripMenuItem.Click += new System.EventHandler(this.programOptionsToolStripMenuItem_Click);
            // 
            // insertInfoToolStripMenuItem1
            // 
            this.insertInfoToolStripMenuItem1.Name = "insertInfoToolStripMenuItem1";
            this.insertInfoToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.insertInfoToolStripMenuItem1.Text = "Management";
            this.insertInfoToolStripMenuItem1.Click += new System.EventHandler(this.insertInfoToolStripMenuItem1_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1264, 711);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.timeLogPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.RightToLeftLayout = true;
            this.Text = "TS Service Admin";
            ((System.ComponentModel.ISupportInitialize)(this.appGrid)).EndInit();
            this.timeLogPanel.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button getUsers;
        private System.Windows.Forms.DataGridView appGrid;
        private System.Windows.Forms.ComboBox monthCombo;
        private System.Windows.Forms.ComboBox yearCombo;
        private System.Windows.Forms.Button getUserLogButton;
        private System.Windows.Forms.Button timesheetPDF;
        private System.Windows.Forms.CheckedListBox userListBox;
        private System.Windows.Forms.Panel timeLogPanel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem programOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertInfoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dbID;
        private System.Windows.Forms.DataGridViewTextBoxColumn appDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn subject;
        private System.Windows.Forms.DataGridViewTextBoxColumn startTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn endTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalHours;
        private System.Windows.Forms.DataGridViewTextBoxColumn noShow;
        private System.Windows.Forms.DataGridViewTextBoxColumn eops;
        private System.Windows.Forms.DataGridViewTextBoxColumn sss;
        private System.Windows.Forms.DataGridViewTextBoxColumn drc;
        private System.Windows.Forms.DataGridViewTextBoxColumn calworks;
        private System.Windows.Forms.DataGridViewTextBoxColumn puente;
        private System.Windows.Forms.DataGridViewTextBoxColumn t3p;
    }
}

