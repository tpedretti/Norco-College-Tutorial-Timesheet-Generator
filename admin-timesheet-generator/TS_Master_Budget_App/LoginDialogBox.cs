using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using TS_Master_Budget_App.Services;

namespace TS_Master_Budget_App
{
    public partial class LoginDialogBox : Form
    {
        public LoginDialogBox()
        {
            InitializeComponent();
        }

        //private void loginButton_Click(object sender, EventArgs e)
        //{
        //    DBConnect db = new DBConnect();
        //    loginUser loginUser = new loginUser();
                        
        //    loginUser = db.login(Convert.ToInt32(userIDLogin.Text), userPWBox.Text);

        //    if (loginUser.isLogin == true)
        //    {
        //        this.Hide();

        //        //MainWindow mWin = new MainWindow(loginUser);
        //        mWin.ShowDialog();

        //        this.Close();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Invaild User ID or Password. Please try again.", "No user found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //    }
        //}
    }
}
