namespace TS_Master_Budget_App
{
    partial class Options
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
            this.budThresholds = new System.Windows.Forms.GroupBox();
            this.stopThresText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.warningThresText = new System.Windows.Forms.TextBox();
            this.thresWarning = new System.Windows.Forms.Label();
            this.saveOptions = new System.Windows.Forms.Button();
            this.activeGroup = new System.Windows.Forms.GroupBox();
            this.noActive = new System.Windows.Forms.RadioButton();
            this.yesActive = new System.Windows.Forms.RadioButton();
            this.overwriteBox = new System.Windows.Forms.GroupBox();
            this.overwriteFunds = new System.Windows.Forms.CheckBox();
            this.FWSPaidTitleV = new System.Windows.Forms.CheckBox();
            this.overwriteTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.budThresholds.SuspendLayout();
            this.activeGroup.SuspendLayout();
            this.overwriteBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // budThresholds
            // 
            this.budThresholds.Controls.Add(this.stopThresText);
            this.budThresholds.Controls.Add(this.label1);
            this.budThresholds.Controls.Add(this.warningThresText);
            this.budThresholds.Controls.Add(this.thresWarning);
            this.budThresholds.Location = new System.Drawing.Point(12, 12);
            this.budThresholds.Name = "budThresholds";
            this.budThresholds.Size = new System.Drawing.Size(187, 78);
            this.budThresholds.TabIndex = 1;
            this.budThresholds.TabStop = false;
            this.budThresholds.Text = "Budget Thresholds";
            // 
            // stopThresText
            // 
            this.stopThresText.Location = new System.Drawing.Point(63, 43);
            this.stopThresText.Name = "stopThresText";
            this.stopThresText.Size = new System.Drawing.Size(100, 20);
            this.stopThresText.TabIndex = 3;
            this.stopThresText.Text = "100";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Stop:";
            // 
            // warningThresText
            // 
            this.warningThresText.Location = new System.Drawing.Point(63, 17);
            this.warningThresText.Name = "warningThresText";
            this.warningThresText.Size = new System.Drawing.Size(100, 20);
            this.warningThresText.TabIndex = 1;
            this.warningThresText.Text = "1000,500";
            // 
            // thresWarning
            // 
            this.thresWarning.AutoSize = true;
            this.thresWarning.Location = new System.Drawing.Point(11, 20);
            this.thresWarning.Name = "thresWarning";
            this.thresWarning.Size = new System.Drawing.Size(50, 13);
            this.thresWarning.TabIndex = 0;
            this.thresWarning.Text = "Warning:";
            // 
            // saveOptions
            // 
            this.saveOptions.Location = new System.Drawing.Point(124, 203);
            this.saveOptions.Name = "saveOptions";
            this.saveOptions.Size = new System.Drawing.Size(75, 23);
            this.saveOptions.TabIndex = 2;
            this.saveOptions.Text = "Save";
            this.saveOptions.UseVisualStyleBackColor = true;
            this.saveOptions.Click += new System.EventHandler(this.saveOptions_Click);
            // 
            // activeGroup
            // 
            this.activeGroup.Controls.Add(this.noActive);
            this.activeGroup.Controls.Add(this.yesActive);
            this.activeGroup.Location = new System.Drawing.Point(205, 12);
            this.activeGroup.Name = "activeGroup";
            this.activeGroup.Size = new System.Drawing.Size(108, 37);
            this.activeGroup.TabIndex = 3;
            this.activeGroup.TabStop = false;
            this.activeGroup.Text = "Show Inactive";
            // 
            // noActive
            // 
            this.noActive.AutoSize = true;
            this.noActive.Location = new System.Drawing.Point(63, 14);
            this.noActive.Name = "noActive";
            this.noActive.Size = new System.Drawing.Size(39, 17);
            this.noActive.TabIndex = 1;
            this.noActive.TabStop = true;
            this.noActive.Text = "No";
            this.noActive.UseVisualStyleBackColor = true;
            // 
            // yesActive
            // 
            this.yesActive.AutoSize = true;
            this.yesActive.Location = new System.Drawing.Point(6, 14);
            this.yesActive.Name = "yesActive";
            this.yesActive.Size = new System.Drawing.Size(43, 17);
            this.yesActive.TabIndex = 0;
            this.yesActive.TabStop = true;
            this.yesActive.Text = "Yes";
            this.yesActive.UseVisualStyleBackColor = true;
            // 
            // overwriteBox
            // 
            this.overwriteBox.Controls.Add(this.overwriteFunds);
            this.overwriteBox.Controls.Add(this.FWSPaidTitleV);
            this.overwriteBox.Location = new System.Drawing.Point(13, 97);
            this.overwriteBox.Name = "overwriteBox";
            this.overwriteBox.Size = new System.Drawing.Size(200, 100);
            this.overwriteBox.TabIndex = 4;
            this.overwriteBox.TabStop = false;
            this.overwriteBox.Text = "Overwrite";
            // 
            // overwriteFunds
            // 
            this.overwriteFunds.AutoSize = true;
            this.overwriteFunds.Location = new System.Drawing.Point(6, 42);
            this.overwriteFunds.Name = "overwriteFunds";
            this.overwriteFunds.Size = new System.Drawing.Size(132, 17);
            this.overwriteFunds.TabIndex = 1;
            this.overwriteFunds.Text = "Overwrite Fund Check";
            this.overwriteTooltip.SetToolTip(this.overwriteFunds, "This option ingores the check to see if the user has hours or funds to create the" +
        " time sheet for that month.");
            this.overwriteFunds.UseVisualStyleBackColor = true;
            // 
            // FWSPaidTitleV
            // 
            this.FWSPaidTitleV.AutoSize = true;
            this.FWSPaidTitleV.Location = new System.Drawing.Point(6, 19);
            this.FWSPaidTitleV.Name = "FWSPaidTitleV";
            this.FWSPaidTitleV.Size = new System.Drawing.Size(132, 17);
            this.FWSPaidTitleV.TabIndex = 0;
            this.FWSPaidTitleV.Text = "FWS Paid With Title V";
            this.FWSPaidTitleV.UseVisualStyleBackColor = true;
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 234);
            this.Controls.Add(this.overwriteBox);
            this.Controls.Add(this.activeGroup);
            this.Controls.Add(this.saveOptions);
            this.Controls.Add(this.budThresholds);
            this.Name = "Options";
            this.Text = "Options";
            this.budThresholds.ResumeLayout(false);
            this.budThresholds.PerformLayout();
            this.activeGroup.ResumeLayout(false);
            this.activeGroup.PerformLayout();
            this.overwriteBox.ResumeLayout(false);
            this.overwriteBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox budThresholds;
        private System.Windows.Forms.TextBox stopThresText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox warningThresText;
        private System.Windows.Forms.Label thresWarning;
        private System.Windows.Forms.Button saveOptions;
        private System.Windows.Forms.GroupBox activeGroup;
        private System.Windows.Forms.RadioButton noActive;
        private System.Windows.Forms.RadioButton yesActive;
        private System.Windows.Forms.GroupBox overwriteBox;
        private System.Windows.Forms.CheckBox overwriteFunds;
        private System.Windows.Forms.CheckBox FWSPaidTitleV;
        private System.Windows.Forms.ToolTip overwriteTooltip;
    }
}