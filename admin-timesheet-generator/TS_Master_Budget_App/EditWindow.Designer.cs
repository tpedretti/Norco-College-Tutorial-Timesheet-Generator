namespace TS_Master_Budget_App
{
    partial class EditWindow
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
            this.lookupApp = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.databaseID = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.startTime = new System.Windows.Forms.DateTimePicker();
            this.endTime = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.studentIDBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.subjectBox = new System.Windows.Forms.TextBox();
            this.specialProgramsList = new System.Windows.Forms.CheckedListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dateBox = new System.Windows.Forms.DateTimePicker();
            this.deleteButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.employeeIDBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lookupApp
            // 
            this.lookupApp.Location = new System.Drawing.Point(119, 30);
            this.lookupApp.Name = "lookupApp";
            this.lookupApp.Size = new System.Drawing.Size(75, 23);
            this.lookupApp.TabIndex = 0;
            this.lookupApp.Text = "Look up";
            this.lookupApp.UseVisualStyleBackColor = true;
            this.lookupApp.Click += new System.EventHandler(this.lookupApp_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Database ID:";
            // 
            // databaseID
            // 
            this.databaseID.Location = new System.Drawing.Point(13, 30);
            this.databaseID.Name = "databaseID";
            this.databaseID.Size = new System.Drawing.Size(100, 20);
            this.databaseID.TabIndex = 2;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(38, 267);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Start Time:";
            // 
            // startTime
            // 
            this.startTime.Cursor = System.Windows.Forms.Cursors.Default;
            this.startTime.Enabled = false;
            this.startTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.startTime.Location = new System.Drawing.Point(13, 116);
            this.startTime.Name = "startTime";
            this.startTime.ShowUpDown = true;
            this.startTime.Size = new System.Drawing.Size(100, 20);
            this.startTime.TabIndex = 7;
            // 
            // endTime
            // 
            this.endTime.Enabled = false;
            this.endTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.endTime.Location = new System.Drawing.Point(13, 155);
            this.endTime.Name = "endTime";
            this.endTime.ShowUpDown = true;
            this.endTime.Size = new System.Drawing.Size(100, 20);
            this.endTime.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "End Time:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 183);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Student ID:";
            // 
            // studentIDBox
            // 
            this.studentIDBox.Enabled = false;
            this.studentIDBox.Location = new System.Drawing.Point(13, 199);
            this.studentIDBox.Name = "studentIDBox";
            this.studentIDBox.Size = new System.Drawing.Size(100, 20);
            this.studentIDBox.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 225);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Subject:";
            // 
            // subjectBox
            // 
            this.subjectBox.Enabled = false;
            this.subjectBox.Location = new System.Drawing.Point(13, 241);
            this.subjectBox.Name = "subjectBox";
            this.subjectBox.Size = new System.Drawing.Size(100, 20);
            this.subjectBox.TabIndex = 13;
            // 
            // specialProgramsList
            // 
            this.specialProgramsList.Enabled = false;
            this.specialProgramsList.FormattingEnabled = true;
            this.specialProgramsList.Items.AddRange(new object[] {
            "No Show",
            "EOPS",
            "SSS",
            "DRC",
            "CalWorks",
            "Puente",
            "T3P"});
            this.specialProgramsList.Location = new System.Drawing.Point(122, 116);
            this.specialProgramsList.Name = "specialProgramsList";
            this.specialProgramsList.Size = new System.Drawing.Size(120, 109);
            this.specialProgramsList.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(119, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Special Programs:";
            // 
            // dateBox
            // 
            this.dateBox.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateBox.Location = new System.Drawing.Point(13, 77);
            this.dateBox.Name = "dateBox";
            this.dateBox.ShowUpDown = true;
            this.dateBox.Size = new System.Drawing.Size(100, 20);
            this.dateBox.TabIndex = 16;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(122, 267);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 17;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(119, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Employee ID:";
            // 
            // employeeIDBox
            // 
            this.employeeIDBox.Location = new System.Drawing.Point(122, 77);
            this.employeeIDBox.Name = "employeeIDBox";
            this.employeeIDBox.Size = new System.Drawing.Size(120, 20);
            this.employeeIDBox.TabIndex = 19;
            // 
            // EditWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 299);
            this.Controls.Add(this.employeeIDBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.dateBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.specialProgramsList);
            this.Controls.Add(this.subjectBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.studentIDBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.endTime);
            this.Controls.Add(this.startTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.databaseID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lookupApp);
            this.Name = "EditWindow";
            this.Text = "EditWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button lookupApp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox databaseID;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker startTime;
        private System.Windows.Forms.DateTimePicker endTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox studentIDBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox subjectBox;
        private System.Windows.Forms.CheckedListBox specialProgramsList;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateBox;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox employeeIDBox;
    }
}