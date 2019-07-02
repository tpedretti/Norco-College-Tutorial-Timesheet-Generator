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
    public partial class EditWindow : Form
    {
        public EditWindow()
        {
            InitializeComponent();
            ShowDialog();
            DisbledControls();
        }

        //Enabled Controls to be active
        private void EnabledControls()
        {
            dateBox.Enabled = true;
            startTime.Enabled = true;
            endTime.Enabled = true;
            studentIDBox.Enabled = true;
            subjectBox.Enabled = true;
            specialProgramsList.Enabled = true;
            saveButton.Enabled = true;
            deleteButton.Enabled = true;
        }

        //Disable controls to be unactive
        private void DisbledControls()
        {
            dateBox.Enabled = false;
            startTime.Enabled = false;
            endTime.Enabled = false;
            studentIDBox.Enabled = false;
            subjectBox.Enabled = false;
            specialProgramsList.Enabled = false;
            saveButton.Enabled = false;
            deleteButton.Enabled = false;
        }

        //Clear all fields and boxes
        private void clearAll()
        {
            dateBox.Value.ToLocalTime();
            startTime.Value.ToLocalTime();
            endTime.Value.ToLocalTime();
            studentIDBox.Text = "";
            subjectBox.Text = "";
            employeeIDBox.Text = "";

            for(int i = 0; i < specialProgramsList.Items.Count; i++)
            {
                specialProgramsList.SetItemChecked(i, false);
            }
        }

        //Look up button to look up a appointment by Database ID.
        private void lookupApp_Click(object sender, EventArgs e)
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
                            EnabledControls();

                            employeeIDBox.Text = userApp.userID.ToString();
                            userApp.dbID = Convert.ToInt32(databaseID.Text);
                            dateBox.Value = userApp.appointmentDate;
                            startTime.Value = userApp.startTime;
                            endTime.Value = userApp.endTime;
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
                                            specialProgramsList.SetItemChecked(0, true);
                                            break;
                                        case "EOPS":
                                            specialProgramsList.SetItemChecked(1, true);
                                            break;
                                        case "SSS":
                                            specialProgramsList.SetItemChecked(2, true);
                                            break;
                                        case "DRC":
                                            specialProgramsList.SetItemChecked(3, true);
                                            break;
                                        case "CalWorks":
                                            specialProgramsList.SetItemChecked(4, true);
                                            break;
                                        case "Puente":
                                            specialProgramsList.SetItemChecked(5, true);
                                            break;
                                        case "R3P":
                                            specialProgramsList.SetItemChecked(6, true);
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

        //Save button to save updated info for a database ID.
        private void saveButton_Click(object sender, EventArgs e)
        {
            using (DBConnect db = new DBConnect())
            {
                userAppointment app = new userAppointment();

                app.dbID = Convert.ToInt32(databaseID.Text);
                app.appointmentDate = dateBox.Value;
                app.startTime = startTime.Value;
                app.endTime = endTime.Value;
                app.studentID = Convert.ToInt32(studentIDBox.Text);
                app.subject = subjectBox.Text;

                //Special Programs -- Really should just write a function in userappointment for this crap
                string temp = "";
                foreach (Object item in specialProgramsList.CheckedItems)
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

        //Delete button to delete a appointment by database ID.
        private void deleteButton_Click(object sender, EventArgs e)
        {
            using (DBConnect dbCMD = new DBConnect())
            {
                dbCMD.deleteAppointment(Convert.ToInt32(databaseID.Text));
            }
        }
    }
}
