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
    public partial class InsertManagement : Form
    {
        public InsertManagement()
        {
            InitializeComponent();
            ShowDialog();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            using (DBConnect db = new DBConnect())
            {
                //Get all Appoint Info from the data controls
                userAppointment app = new userAppointment();

                app.userID = Convert.ToInt32(employeeIDBox.Text);
                app.studentID = Convert.ToInt32(studentIDBox.Text);
                app.subject = subjectBox.Text;

                StringBuilder sb = new StringBuilder();
                if (specProgCheckbox.Items.Count >= 1)
                {
                    for(int i = 0; i < specProgCheckbox.CheckedItems.Count; i++)
                    {
                        if (i == specProgCheckbox.CheckedItems.Count - 1)
                            sb.Append(specProgCheckbox.CheckedItems[i]);
                        else
                            sb.Append(specProgCheckbox.CheckedItems[i] + ",");
                    }
                    app.specialProgram = sb.ToString();
                }
                else
                    app.specialProgram = null;

                if (noShowCheckBox.Checked == true)
                {
                    if (app.specialProgram == null || app.specialProgram == "")
                        app.specialProgram = "NoShow";
                    else
                        app.specialProgram += ",NoSow";
                }

                app.appointmentDate = appointmentDate.SelectionStart;
                app.startTime = startTimePicker.Value;
                app.endTime = endTimePicker.Value;

                db.InsertAppointmentAdmin(app);
            }
        }

        private void userSubmitButton_Click(object sender, EventArgs e)
        {
            using (DBConnect db = new DBConnect())
            {
                userInfo uInfo = new userInfo();

                uInfo.firstName = firstNameTextBox.Text;
                uInfo.lastName = lastNameTextBox.Text;
                uInfo.userID = Convert.ToInt32(userIDBox.Text);
                uInfo.userEmail = emailTextBox.Text;
                uInfo.userPhoneNum = userPhoneNumber.Text;
                uInfo.lastSSN = last4SSNBox.Text;

                if (jobTitleRadioButton1.Checked == true)
                    uInfo.jobTitle = jobTitleRadioButton1.Text;
                else if (jobTitleRadioButton2.Checked == true)
                    uInfo.jobTitle = jobTitleRadioButton2.Text;
                else if (jobTitleRadioButton3.Checked == true)
                    uInfo.jobTitle = jobTitleRadioButton3.Text;
                else
                    uInfo.jobTitle = "";

                if (workerTypeRadioButton1.Checked == true)
                    uInfo.userTitle = workerTypeRadioButton1.Text;
                else if (workerTypeRadioButton2.Checked == true)
                    uInfo.userTitle = workerTypeRadioButton2.Text;
                else
                    uInfo.userTitle = "";

                if (departmentRadioButton1.Checked == true)
                    uInfo.department = departmentRadioButton1.Text;
                else
                    uInfo.department = "";

                db.InsertUserAdmin(uInfo);
            }
        }

        private void getAppInfoButton_Click(object sender, EventArgs e)
        {
            if (databaseID.Text != "")
            {
                bool isNumeric = int.TryParse(databaseID.Text, out int n);

                if (isNumeric == true)
                {
                    using (DBConnect dbC = new DBConnect())
                    {
                        if (dbC.isAppointmentThere(Convert.ToInt32(databaseID.Text)))
                        {
                            userAppointment userApp = dbC.getAppointment(Convert.ToInt32(databaseID.Text));
                            //EnabledControls();

                            employeeIDBox.Text = userApp.userID.ToString();
                            userApp.dbID = Convert.ToInt32(databaseID.Text);
                            appointmentDate.SetSelectionRange(userApp.appointmentDate, userApp.appointmentDate);
                            startTimePicker.Value = userApp.startTime;
                            endTimePicker.Value = userApp.endTime;
                            studentIDBox.Text = Convert.ToString(userApp.studentID);
                            subjectBox.Text = userApp.subject;

                            if (userApp.specialProgram != null)
                            {
                                List<string> spPro = userApp.specialProgram.Split(',').ToList();

                                foreach (string sp in spPro)
                                {
                                    switch (sp)
                                    {
                                        case "NoShow":
                                            specProgCheckbox.SetItemChecked(0, true);
                                            break;
                                        case "EOPS":
                                            specProgCheckbox.SetItemChecked(1, true);
                                            break;
                                        case "SSS":
                                            specProgCheckbox.SetItemChecked(2, true);
                                            break;
                                        case "DRC":
                                            specProgCheckbox.SetItemChecked(3, true);
                                            break;
                                        case "CalWorks":
                                            specProgCheckbox.SetItemChecked(4, true);
                                            break;
                                        case "Puente":
                                            specProgCheckbox.SetItemChecked(5, true);
                                            break;
                                        case "R3P":
                                            specProgCheckbox.SetItemChecked(6, true);
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Non-Numeric value entered into textbox!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter in an database ID, to look up.", "Enter Database ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editAppButton_Click(object sender, EventArgs e)
        {
            using (DBConnect db = new DBConnect())
            {
                userAppointment app = new userAppointment();

                app.dbID = Convert.ToInt32(databaseID.Text);
                app.appointmentDate = appointmentDate.SelectionRange.Start;
                app.startTime = startTimePicker.Value;
                app.endTime = endTimePicker.Value;
                app.studentID = Convert.ToInt32(studentIDBox.Text);
                app.subject = subjectBox.Text;

                //Special Programs -- Really should just write a function in userappointment for this crap
                string temp = "";
                foreach (Object item in specProgCheckbox.CheckedItems)
                {
                    temp += item.ToString() + ",";
                }
                temp = (temp.EndsWith(",")) ? temp.Remove((temp.Length - 1), 1) : temp;

                bool appointmentUpdated = db.updateAppointment(app);

                if (appointmentUpdated)
                    MessageBox.Show("Updated appointment successfully!", "Updated Appointment", MessageBoxButtons.OK, MessageBoxIcon.None);
                else
                    MessageBox.Show("Failed to update appointment!", "Failed to update!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteAppointment_Click(object sender, EventArgs e)
        {
            using (DBConnect dbCMD = new DBConnect())
            {
                dbCMD.deleteAppointment(Convert.ToInt32(databaseID.Text));
            }
        }
    }
}
