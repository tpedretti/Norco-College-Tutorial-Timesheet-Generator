using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MySql.Data;
using MySql.Data.MySqlClient;

using TS_Master_Budget_App.Services;
using System.Security.Cryptography;
using System.Data;

namespace TS_Master_Budget_App
{
    public partial class MainWindow : Form
    {
        ProgramSettings settings = new ProgramSettings();
        List<userInfo> users = new List<userInfo>();
        List<userAppointment> userAppLog = new List<userAppointment>();

        public MainWindow()
        {
            InitializeComponent();
            settings.Load(ref settings);
        }

        //Get all users from the DB.
        private void getUsers_Click(object sender, EventArgs e)
        {
            using (DBConnect GetUserInfo = new DBConnect())
            {
                users = GetUserInfo.getUsers();

                users.Sort((x, y) => String.Compare(x.lastName, y.lastName));

                foreach (userInfo tempU in users)
                {
                    userListBox.Items.Add(tempU.fullnameWComma());
                }
            }
        }

        //Only use if you want to do something once something is selected.
        private void userListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //List<userAppointment> userAppLog = new List<userAppointment>();

            //if (checkedListBox1.CheckedItems.Count == 1)
            //{
            //    //foreach (string checkedUser in checkedListBox1.CheckedItems)
            //    //{
            //    //dataGridView1.Rows.Add(checkedUser.firstName.ToString());
            //    //string[] tempU = checkedUser.Split(',');
            //    //tempU[1] = tempU[1].Remove(0,1);

            //    string tempU = checkedListBox1.CheckedItems[0].ToString();
            //    string[] tempUT = tempU.Split(',');
            //    tempUT[1] = tempUT[1].Remove(0, 1);

            //    int uIndex = users.FindIndex(x => x.firstName.Contains(tempUT[0]) && x.lastName.Contains(tempUT[1]));

            //    using (DBConnect dbC = new DBConnect())
            //    {
            //        userAppLog = dbC.getUserLog(users[uIndex]);
            //        //dataGridView1.Rows.Add(appRows.Count);

            //        foreach(userAppointment user in userAppLog)
            //        {
            //            DataGridViewRow newR = (DataGridViewRow)dataGridView1.Rows[0].Clone();
            //            newR.Cells[0].Value = user.userID;
            //            newR.Cells[1].Value = user.studentID;
            //            newR.Cells[2].Value = user.subject;
            //            newR.Cells[3].Value = user.startTime;
            //            newR.Cells[4].Value = user.endTime;      
            //        }

            //for(int i = 0; i < userAppLog.Count; i++)
            //{
            //    DataGridViewRow newR = (DataGridViewRow)dataGridView1.Rows[i].Clone();
            //    newR.Cells[0].Value = userAppLog[i].userID;
            //    newR.Cells[1].Value = userAppLog[i].studentID;
            //    newR.Cells[2].Value = userAppLog[i].subject;
            //    newR.Cells[3].Value = userAppLog[i].startTime;
            //    newR.Cells[4].Value = userAppLog[i].endTime;
            //    dataGridView1.Rows.Add(newR);
            //}


            //foreach (userAppointment appR in appRows)
            //appRows = dbC.getUserLog(users[uIndex]);
            //dataGridView1.Rows.Add(appRows.Count);

            //for(int i = 0; i < appRows.Count; i++)
            //{
            //    DataGridViewRow newR = (DataGridViewRow)dataGridView1.Rows[i].Clone();
            //    newR.Cells[0].Value = appRows[i].userID;
            //    newR.Cells[1].Value = appRows[i].userID;
            //    newR.Cells[2].Value = appRows[i].userID;
            //    newR.Cells[3].Value = appRows[i].userID;
            //    newR.Cells[4].Value = appRows[i].userID;
            //    dataGridView1.Rows.Add(newR);
            //}


            //foreach (appointmentRow appR in appRows)
            //{
            //dataGridView1.Rows.Add(appR.userID.ToString());
            //DataGridViewRow newRow = (DataGridView)dataGridView1.Rows[0].Clone();

            //newRow.Cells["appDate"].Value = appR.appointmentDate;
            //newRow.Cells["studentID"].Value = appR.studentID;
            //newRow.Cells["subject"].Value = appR.subject;
            //newRow.Cells["startTime"].Value = appR.startTime;
            //newRow.Cells["endTime"].Value = appR.endTime;

            //dataGridView1.Rows.Add(newRow);
            //int rowIndex = this.dataGridView1.Rows.Add();
            //var row = this.dataGridView1.Rows[rowIndex];

            //row.Cells["appDate"].Value = appR.appointmentDate;
            //row.Cells["studentID"].Value = appR.studentID;
            //row.Cells["subject"].Value = appR.subject;
            //row.Cells["startTime"].Value = appR.startTime;
            //row.Cells["endTime"].Value = appR.endTime;

            //dataGridView1.Rows.Add(appRows.Count);
            //}
            //}
        }

        //Button to that is used to get the a users log once their selected.
        private void getUserLogButton_Click(object sender, EventArgs e)
        {
            string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            DateTime startOfMonth = new DateTime(Convert.ToInt32(yearCombo.Text), (Array.IndexOf(months,monthCombo.Text) + 1), 1);
            DateTime endOfMonth = new DateTime(Convert.ToInt32(yearCombo.Text), (Array.IndexOf(months, monthCombo.Text) + 1), DateTime.DaysInMonth(Convert.ToInt32(yearCombo.Text), (Array.IndexOf(months, monthCombo.Text) + 1)));          

            if (userListBox.CheckedItems.Count == 1)
            {
                using (DBConnect dbC = new DBConnect())
                {
                    List<string> spPro = new List<string>();
                    string temp = userListBox.CheckedItems[0].ToString();
                    string[] nameSplit = temp.Split(',');
                    nameSplit[1] = nameSplit[1].Remove(0, 1);                    

                    int uIndex = users.FindIndex(x => (x.lastName.Contains(nameSplit[0]) && x.firstName.Contains(nameSplit[1])));
                    userAppLog = dbC.getUserLog(users[uIndex], startOfMonth, endOfMonth);
                    userAppLog.Sort((x, y) => DateTime.Compare(x.appointmentDate, y.appointmentDate));

                    //Clear appGrid to remove old data
                    appGrid.Rows.Clear();
                    appGrid.Refresh();

                    //CODE WORKS JUST GOING TO TRY AND REWRITE TO SOMETHING ELSE. TESTING
                    foreach (userAppointment user in userAppLog)
                    {
                        DataGridViewRow newR = (DataGridViewRow)appGrid.Rows[0].Clone();
                        newR.Cells[0].Value = user.dbID;
                        newR.Cells[1].Value = user.appointmentDate.ToString("MM/dd/yyyy");
                        newR.Cells[2].Value = user.studentID;
                        newR.Cells[3].Value = user.subject;
                        newR.Cells[4].Value = user.startTime.ToString("hh:mm tt");

                        if (user.specialProgram.Contains("NoShow"))
                        {
                            newR.Cells[5].Value = (user.startTime.AddMinutes(15)).ToString("hh:mm tt");
                            newR.Cells[6].Value = (user.startTime.AddMinutes(15) - user.startTime).TotalHours.ToString("00.00");
                        }
                        else
                        {
                            newR.Cells[5].Value = user.endTime.ToString("hh:mm tt");
                            newR.Cells[6].Value = (user.endTime - user.startTime).TotalHours.ToString("00.00");
                        }

                        //Calc total hours for said appointment
                        //newR.Cells[5].Value = (user.endTime - user.startTime).TotalHours.ToString("00.00");

                        if (user.specialProgram != null)
                        {
                            spPro = user.specialProgram.Split(',').ToList();

                            //Loops though speacial programs return and marks what is there
                            foreach (string sp in spPro)
                            {
                                if (sp == null || sp == "")
                                    break;

                                switch (sp)
                                {
                                    case "NoShow":
                                        newR.Cells[7].Value = "X";
                                        break;
                                    case "EOPS":
                                        newR.Cells[8].Value = "X";
                                        break;
                                    case "SSS":
                                        newR.Cells[9].Value = "X";
                                        break;
                                    case "DRC":
                                        newR.Cells[10].Value = "X";
                                        break;
                                    case "CalWorks":
                                        newR.Cells[11].Value = "X";
                                        break;
                                    case "Puente":
                                        newR.Cells[12].Value = "X";
                                        break;
                                    case "R3P":
                                        newR.Cells[13].Value = "X";
                                        break;
                                }
                            }
                        }

                        appGrid.Rows.Add(newR);
                    }
                }
            }
        }

        //button to create the time sheet for a user by the month and year they were selected.
        private void timesheetPDF_Click(object sender, EventArgs e)
        {
            PDFManagement makePDF = new PDFManagement();
            //List<userAppointment> userAppLog = new List<userAppointment>();

            string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            DateTime startOfMonth = new DateTime(Convert.ToInt32(yearCombo.Text), (Array.IndexOf(months, monthCombo.Text) + 1), 1);
            DateTime endOfMonth = new DateTime(Convert.ToInt32(yearCombo.Text), (Array.IndexOf(months, monthCombo.Text) + 1), DateTime.DaysInMonth(Convert.ToInt32(yearCombo.Text), (Array.IndexOf(months, monthCombo.Text) + 1)));

            int uIndex = 0;

            for (int i = 0; i < userListBox.Items.Count; i++)
            {
                if(userListBox.Items[i] == userListBox.CheckedItems[0])
                {
                    uIndex = i;
                }
            }
            
            makePDF.createTimeSheet(users[uIndex], userAppLog, startOfMonth, endOfMonth);
        }

        private static string getSH1Hash(SHA1 sh1hash, string temp)
        {
            byte[] data = sh1hash.ComputeHash(Encoding.UTF8.GetBytes(temp));

            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        //Reloads the settings file and settings once the Settings Windows closes.
        private void settingWindowClosing(object sender, FormClosedEventArgs e)
        {
            settings.Load(ref settings);
        }

        private void insertInfoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            InsertManagement insertAppWindow = new InsertManagement();
        }

        private void programOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Options optionWindow = new Options();
            //optionWindow.FormClosed += new FormClosedEventHandler(settingWindowClosing);
            //optionWindow.ShowDialog();
            this.FormClosed += new FormClosedEventHandler(settingWindowClosing);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditWindow editWindow = new EditWindow();
        }
    }
}
