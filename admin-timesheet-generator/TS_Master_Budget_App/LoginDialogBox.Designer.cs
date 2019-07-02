namespace TS_Master_Budget_App
{
    partial class LoginDialogBox
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
            this.userIDLoginLab = new System.Windows.Forms.Label();
            this.userLoginPWLab = new System.Windows.Forms.Label();
            this.loginButton = new System.Windows.Forms.Button();
            this.userIDLogin = new System.Windows.Forms.TextBox();
            this.userPWBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // userIDLoginLab
            // 
            this.userIDLoginLab.AutoSize = true;
            this.userIDLoginLab.Location = new System.Drawing.Point(71, 83);
            this.userIDLoginLab.Name = "userIDLoginLab";
            this.userIDLoginLab.Size = new System.Drawing.Size(46, 13);
            this.userIDLoginLab.TabIndex = 0;
            this.userIDLoginLab.Text = "User ID:";
            // 
            // userLoginPWLab
            // 
            this.userLoginPWLab.AutoSize = true;
            this.userLoginPWLab.Location = new System.Drawing.Point(61, 115);
            this.userLoginPWLab.Name = "userLoginPWLab";
            this.userLoginPWLab.Size = new System.Drawing.Size(56, 13);
            this.userLoginPWLab.TabIndex = 1;
            this.userLoginPWLab.Text = "Password:";
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(111, 162);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(75, 23);
            this.loginButton.TabIndex = 2;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            // 
            // userIDLogin
            // 
            this.userIDLogin.Location = new System.Drawing.Point(124, 76);
            this.userIDLogin.Name = "userIDLogin";
            this.userIDLogin.Size = new System.Drawing.Size(100, 20);
            this.userIDLogin.TabIndex = 3;
            // 
            // userPWBox
            // 
            this.userPWBox.Location = new System.Drawing.Point(124, 112);
            this.userPWBox.Name = "userPWBox";
            this.userPWBox.PasswordChar = '*';
            this.userPWBox.Size = new System.Drawing.Size(100, 20);
            this.userPWBox.TabIndex = 4;
            // 
            // LoginDialogBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.userPWBox);
            this.Controls.Add(this.userIDLogin);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.userLoginPWLab);
            this.Controls.Add(this.userIDLoginLab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginDialogBox";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label userIDLoginLab;
        private System.Windows.Forms.Label userLoginPWLab;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.TextBox userIDLogin;
        private System.Windows.Forms.TextBox userPWBox;
    }
}