using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

using System.Data;

namespace TS_Master_Budget_App.Services
{
    //mySQL Connector
    class DBConnect : IDisposable
    {
		//Bad way to do change later
        public static string fileName { get; set; } = "sqlInfo.json";
        //public string ipAddr { get; set; } = "192.168.1.116";
        public string ipAddr { get; set; } = "";
        public string ipPort { get; set; } = "";
        public string tsDatabase { get; set; } = "tsDB";
        public string userName { get; set; } = "tsUser";
        //public string password { get; set; } = "TempPass1";
        public string password { get; set; } = "";

        //myJson jsonInfo;
        public MySqlConnection sqlConn = new MySqlConnection();
        MySqlConnectionStringBuilder connString = new MySqlConnectionStringBuilder();
        //MySqlCommand cmd = new MySqlCommand();

        private bool disposed = false;
        private Component component = new Component();
        private IntPtr handle;

        [System.Runtime.InteropServices.DllImport("Kernel32")]
        private extern static Boolean CloseHandle(IntPtr handle);

        public DBConnect()
        {
            Initialize();
        }

        ~DBConnect() { this.CloseConnect(); Dispose(false); }

        private void Initialize()
        {
            this.handle = handle;
            connString.Server = ipAddr;
            connString.Port = 3306;
            connString.Database = tsDatabase;
            connString.UserID = userName;
            connString.Password = password;
            connString.SslMode = 0;
            connString.AllowPublicKeyRetrieval = true;
            sqlConn.ConnectionString = connString.ConnectionString;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                    component.Dispose();

                CloseHandle(handle);
                disposed = true;
            }
        }

        private bool OpenConnection()
        {
            try
            {
                sqlConn.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show($"Cannot connect to server. Contact Adminisrator.\nError Code: {ex.Number}\nError Message: { ex.Message }");
                        break;
                    case 1045:
                        MessageBox.Show("Invalid username/password while connecting to DB Server, Please Contract Administrator!");
                        break;
                }

                return false;
            }
        }

        private bool CloseConnect()
        {
            try
            {
                sqlConn.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        //Gets all users within the DB.
        public List<userInfo> getUsers()
        {
            List<userInfo> users = new List<userInfo>();

            if (this.OpenConnection() == true)
            {
                using (MySqlCommand dbCMD = new MySqlCommand())
                {
                    dbCMD.Connection = this.sqlConn;
                    dbCMD.CommandText = "SELECT * FROM userInfo WHERE 1";
                    using (MySqlDataReader rdr = dbCMD.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            userInfo curUser = new userInfo();

                            curUser.userID = Convert.ToInt32(rdr[1].ToString());
                            curUser.lastName = rdr[3].ToString();
                            curUser.firstName = rdr[4].ToString();
                            curUser.userEmail = rdr[5].ToString();
                            curUser.userPhoneNum = rdr[6].ToString();
                            //curUser.accountActive = Convert.ToBoolean(Convert.ToInt32(rdr[7].ToString()));
                            curUser.premissionLvL = (rdr[8] == DBNull.Value) ? 0 : Convert.ToInt32(rdr[8]);
                            curUser.userType = rdr[9].ToString();
                            curUser.userTitle = rdr[10].ToString();
                            curUser.department = rdr[11].ToString();
                            curUser.lastSSN = (rdr[12] == DBNull.Value) ? "NOTinDB" : (rdr[12].ToString());
                            curUser.jobTitle = rdr[13].ToString();
                            curUser.payRate = (rdr[14] == DBNull.Value) ? 0 : Convert.ToDouble(rdr[14]);

                            users.Add(curUser);
                        }
                    }

                    this.CloseConnect();
                }

                for (int i = 0; i < users.Count; i++)
                    users[i] = getUserBudget(users[i]);

                this.CloseConnect();
                return users;
            }

            this.CloseConnect();
            return users;
        }

        public loginUser login(int userID, string userPW)
        {
            loginUser user = new loginUser();

            if (this.OpenConnection() == true)
            {
                using (MySqlCommand dbCMD = new MySqlCommand())
                {
                    dbCMD.Connection = this.sqlConn;
                    dbCMD.CommandText = $"SELECT COUNT(*) FROM `userInfo` WHERE `userID`={userID} AND `password`=\"{userPW}\"";

                    if (Convert.ToInt32(dbCMD.ExecuteScalar()) == 1)
                    {
                        dbCMD.CommandText = $"SELECT `workerTitle`, `permissionLvL` FROM `userInfo` WHERE `userID`={userID} AND `password`=\"{userPW}\"";
                        using (MySqlDataReader rdr = dbCMD.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                user.userID = userID;
                                user.userTitle = rdr[0].ToString();
                                user.premissionLvL = Convert.ToInt32(rdr[1]);
                                user.isLogin = true;
                            }
                        }

                        this.CloseConnect();
                        return user;
                    }
                }
            }

            user.isLogin = false;
            this.CloseConnect();
            return user;
        }

        //Gets user appointment info from supplyed Month. - Working again.
        public List<userAppointment> getUserLog(userInfo user, DateTime startOfMonth, DateTime endOfMonth)
        {
            List<userAppointment> appRows = new List<userAppointment>();

            if (this.OpenConnection() == true)
            {
                using (MySqlCommand dbCMD = new MySqlCommand())
                {
                    dbCMD.Connection = sqlConn;
                    dbCMD.CommandText = $"SELECT COUNT(*) FROM appointmentLog WHERE userID={user.userID} AND " +
                                            $"(appointmentDate BETWEEN '{startOfMonth.ToString("yyyy-MM-dd")}' AND '{endOfMonth.ToString("yyyy-MM-dd")}')";

                    if (Convert.ToInt32(dbCMD.ExecuteScalar().ToString()) >= 1)
                    {
                        dbCMD.Connection = sqlConn;
                        dbCMD.CommandText = $"SELECT * FROM appointmentLog WHERE userID={user.userID} AND " +
                                            $"(appointmentDate BETWEEN '{startOfMonth.ToString("yyyy-MM-dd")}' AND '{endOfMonth.ToString("yyyy-MM-dd")}')";

                        using (MySqlDataReader rdr = dbCMD.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                userAppointment tempRow = new userAppointment();

                                tempRow.dbID = Convert.ToInt32(rdr[0]);
                                tempRow.userID = Convert.ToInt32(rdr[1]);
                                tempRow.appointmentDate = new DateTime(Convert.ToDateTime(rdr[2].ToString()).Year, Convert.ToDateTime(rdr[2].ToString()).Month,
                                                                       Convert.ToDateTime(rdr[2].ToString()).Day, TimeSpan.Parse(rdr[5].ToString()).Hours,
                                                                       TimeSpan.Parse(rdr[5].ToString()).Minutes, TimeSpan.Parse(rdr[5].ToString()).Seconds);
                                tempRow.subject = rdr[3].ToString();
                                tempRow.studentID = (rdr[4] == DBNull.Value) ? 0 : Convert.ToInt32(rdr[4]); //Crashing here~
                                tempRow.startTime = Convert.ToDateTime(rdr[5].ToString());
                                tempRow.endTime =  (rdr[6].ToString() == "") ? Convert.ToDateTime(rdr[5].ToString()) : Convert.ToDateTime(rdr[6].ToString());
                                tempRow.loggedTime = Convert.ToDateTime(rdr[7].ToString());
                                tempRow.specialProgram = rdr[8].ToString();

                                appRows.Add(tempRow);
                            }
                        }
                        this.CloseConnect();
                        return appRows;
                    }
                    else
                    {
                        userAppointment tempRow = new userAppointment();
                        tempRow.subject = "No Appointments for the month";
                        appRows.Add(tempRow);
                        this.CloseConnect();
                        return appRows;
                    }
                }
            }
            else
            {
                MessageBox.Show("Couldn't Connect to datebase!");
                userAppointment tempRow = new userAppointment();
                tempRow.subject = "Couldn't connect to Datebase.";
                appRows.Add(tempRow);
                this.CloseConnect();
                return appRows;
            }
        }

        //Used to get all the different types of budget code form the DB
        public List<budgetCodes> getBudgetCodes(userInfo user)
        {
            List<budgetCodes> budgetInfo = new List<budgetCodes>();

            if (this.OpenConnection() == true)
            {
                using (MySqlCommand dbCMD = new MySqlCommand())
                {
                    dbCMD.Connection = sqlConn;

                    if (user.userType.Contains("SWF") || user.userType.Contains("SE"))
                        dbCMD.CommandText = "SELECT * FROM budgetInfo WHERE districtCode=0 ";
                    else
                        dbCMD.CommandText = "SELECT * FROM budgetInfo WHERE districtCode=1 ";

                    dbCMD.ExecuteNonQuery();

                    using (MySqlDataReader rdr = dbCMD.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            budgetCodes tempCode = new budgetCodes();

                            tempCode.budgetName = rdr[0].ToString();
                            tempCode.budgetCode = rdr[1].ToString();
                            tempCode.budgetDescription = rdr[2].ToString();
                            tempCode.district = rdr[3].ToString();
                            budgetInfo.Add(tempCode);
                        }
                    }
                }
                this.CloseConnect();
                return budgetInfo;
            }
            else
            {
                this.CloseConnect();
                MessageBox.Show("Error connecting to DB. Contact Admin");
            }

            return budgetInfo;
        }

        //Checking to see if current tutor being checked was the first one to have an appointment with a tutee
        //Maybe change from bool to something else cuz if their the only person to have appointment with tutee
        //But different times can't really show that on budget report correctly.
        //Returns a string with True/false: (and if they are second appoint in the day)
        //A true return means they get paid by EOPS.
        public string EOPSAppointmentCheck(userAppointment app, userInfo user)
        {
            List<userAppointment> checkHrLog = new List<userAppointment>();

            if (this.OpenConnection() == true)
            {
                //Added DRC to this becuase DRC acts as EOPS now too.
                if (app.specialProgram.Contains("EOPS") || app.specialProgram.Contains("DRC"))
                {
                    //Checking to see if tutee had only one appointment for a subject in a day MM/dd/yyyy
                    using (MySqlCommand dbCMD = new MySqlCommand())
                    {
                        string tempS = app.appointmentDate.ToString("yyyy-MM-dd");
                        dbCMD.Connection = sqlConn;
                        dbCMD.CommandText = $"SELECT COUNT(*) FROM `appointmentLog` WHERE `studentID`={app.studentID}" +
                            $" AND `subject`=\"{app.subject}\" AND `appointmentDate`=\"{app.appointmentDate.ToString("yyyy-MM-dd")}\"" +
                            $" AND `specialProgram` LIKE \"%{app.specialProgram}%\"";

                        if (Convert.ToInt32(dbCMD.ExecuteScalar()) >= 1)
                        {
                            dbCMD.Connection = sqlConn;
                            dbCMD.CommandText = $"SELECT * FROM `appointmentLog` WHERE `studentID`={app.studentID}" +
                                $" AND `subject`=\"{app.subject}\" AND `appointmentDate`=\"{app.appointmentDate.ToString("yyyy-MM-dd")}\"" +
                                $" AND `specialProgram` LIKE \"%{app.specialProgram}%\"";

                            using (MySqlDataReader rdr = dbCMD.ExecuteReader())
                            {
                                while (rdr.Read())
                                {
                                    userAppointment tempRow = new userAppointment();

                                    tempRow.userID = Convert.ToInt32(rdr[1]);
                                    tempRow.appointmentDate = new DateTime(Convert.ToDateTime(rdr[2].ToString()).Year, Convert.ToDateTime(rdr[2].ToString()).Month,
                                                                       Convert.ToDateTime(rdr[2].ToString()).Day, TimeSpan.Parse(rdr[5].ToString()).Hours,
                                                                       TimeSpan.Parse(rdr[5].ToString()).Minutes, TimeSpan.Parse(rdr[5].ToString()).Seconds);
                                    tempRow.subject = rdr[3].ToString();
                                    tempRow.studentID = (rdr[4] == null) ? 0 : Convert.ToInt32(rdr[4]);
                                    tempRow.startTime = Convert.ToDateTime(rdr[5].ToString());
                                    tempRow.endTime = Convert.ToDateTime(rdr[6].ToString());

                                    tempRow.loggedTime = Convert.ToDateTime(rdr[7].ToString());
                                    tempRow.specialProgram = rdr[8].ToString();

                                    checkHrLog.Add(tempRow);
                                }
                            }

                            checkHrLog.Sort((x, y) => DateTime.Compare(x.appointmentDate, y.appointmentDate));

                            //Logic the check who gets paid by EOPS
                            /*
                             * Return String meanings
                             *  1ST2HR - First appointment for tutee of day was a 2hr appointment EOPS.
                             *  2ND2HR - Second appointment for tutee of day was 2hr appointment with EOPS.
                             *  2ND1HR - Tutor was the second appointment for tutee for the day. Gets paid by EOPS. 
                             *  ERRORENT - Used if the tutor logged time in and didn't do a 2hr appoint and logged a 2hr as two different appointments.
                             */
                            if (checkHrLog.Count >= 3)
                            {
                                if (checkHrLog[1].userID == user.userID)
                                {
                                    this.CloseConnect();
                                    return "2ND1HR";
                                }
                            }
                            else if (checkHrLog.Count == 2)
                            {
                                if ((checkHrLog[0].userID == checkHrLog[1].userID) && (checkHrLog[0].studentID == checkHrLog[1].studentID))
                                {
                                    this.CloseConnect();
                                    return "ERRORENT";
                                }

                                else if (checkHrLog[1].userID == user.userID)
                                {
                                    this.CloseConnect();
                                    return "2ND1HR";
                                }
                            }
                        }
                    }
                }
            }

            this.CloseConnect();
            return "FAILED TO CONNECT TO DB!";
        }

        //-----------------------------------------------------------------------------------
        //FUNCTIONS TO DEAL WITH THE USER BUDGET TO UPDATE THE AMOUNTS LEFT OR INCEASTING

        //Gets the amount of hours or money left a user has in their budget to work
        public userInfo getUserBudget(userInfo user)
        {
            if (this.OpenConnection() == true)
            {
                using (MySqlCommand dbCMD = new MySqlCommand())
                {
                    dbCMD.Connection = this.sqlConn;
                    dbCMD.CommandText = $"SELECT COUNT(*) FROM `userBudgets` WHERE `userID`={user.userID};";

                    if (Convert.ToInt32(dbCMD.ExecuteScalar()) == 1)
                    {
                        if (user.userType.Contains("D") || user.userType.Contains("SE"))
                        {
                            dbCMD.CommandText = $"SELECT startingHrs, hoursLeft FROM userBudgets WHERE userID={user.userID};";

                            using (MySqlDataReader rdr = dbCMD.ExecuteReader())
                            {
                                while (rdr.Read())
                                {
                                    user.budget.startHR = Convert.ToDouble(rdr[0]);
                                    user.budget.currentHR = Convert.ToDouble(rdr[1]);
                                }
                            }

                        }
                        else if(user.userType.Contains("SWF"))
                        {
                            dbCMD.CommandText = $"SELECT moneyStart, moneyLeft FROM userBudgets WHERE userID={user.userID};";

                            using (MySqlDataReader rdr = dbCMD.ExecuteReader())
                            {
                                while (rdr.Read())
                                {
                                    user.budget.startMoney = Convert.ToDouble(rdr[0]);
                                    user.budget.currentMoney = Convert.ToDouble(rdr[1]);
                                }
                            }
                        }
                    }
                    else
                    {
                        dbCMD.CommandText = $"INSERT INTO userBudgets (userID, startingHrs, hoursLeft, moneyStart, moneyLeft)" +
                            $" VALUES ({user.userID}, 900, 900, 20000, 20000);";
                        dbCMD.ExecuteNonQuery();

                        MessageBox.Show($"User: {user.userID} wasn't found in userBudget database, inserted dummy values. Please edit for correct amounts.", 
                            "User not found", MessageBoxButtons.OK);
                    }
                }                
            }

            this.CloseConnect();
            return user;
        }

        //Updates user budget to correct amount
        public void updateUserBudget(userInfo user)
        {
            if (this.OpenConnection() == true)
            {
                using (MySqlCommand dbCMD = new MySqlCommand())
                {
                    dbCMD.Connection = this.sqlConn;

                    if (user.userType.Contains("D") || user.userType.Contains("SE"))
                    {
                        dbCMD.CommandText = $"UPDATE `userBudgets` SET `hoursLeft`={user.budget.currentHR} WHERE `userID`={user.userID}";
                        dbCMD.ExecuteNonQuery();
                    }
                    else if(user.userType.Contains("SWF"))
                    {
                        dbCMD.CommandText = $"UPDATE `userBudgets` SET `moneyLeft`={user.budget.currentMoney} WHERE `userID`={user.userID}";
                        dbCMD.ExecuteNonQuery();
                    }
                }
            }

            this.CloseConnect();
        }

        //-----------------------------------------------------------------------------------
        //ALL FUNCTIONS FOR EDITING, INSERTING, DELETEING AND UPDATING USERS AND APPOINTMENTS

        //Insert new Appointment from Admin program
        public bool InsertAppointmentAdmin(userAppointment userApp)
        {
            if(this.OpenConnection() == true)
            {
                using (MySqlCommand dbCMD = new MySqlCommand())
                {
                    dbCMD.Connection = sqlConn;
                    dbCMD.CommandText = "INSERT INTO `appointmentLog`(`userID`, `appointmentDate`, `subject`, `studentID`, `startTime`, `endTime`, `specialProgram`, `adminInsert`) " +
                                                            $"VALUES (\"{userApp.userID}\",\"{userApp.appointmentDate.ToString("yyyy-MM-dd")}\",\"{userApp.subject}\",\"{userApp.studentID}\"," +
                                                            $"\"{userApp.startTime.ToString("HH:mm:ss")}\",\"{userApp.endTime.ToString("HH:mm:ss")}\",\"{userApp.specialProgram}\",1)";

                    dbCMD.ExecuteNonQuery();
                }

                return true;
            }

            return false;
        }
        
        //Insert new User from Admin Program
        public bool InsertUserAdmin(userInfo newUser)
        {
            if(this.OpenConnection() == true)
            {
                using (MySqlCommand dbCMD = new MySqlCommand())
                {
                    dbCMD.Connection = sqlConn;
                    dbCMD.CommandText = "INSERT INTO `userInfo`(`userID`, `userLastName`, `userFirstName`, `userEmail`, `userPhoneNumber`, `accountActive`, `workerType`, `department`, `lastSSN`, `jobTitle`) " + 
                                                      $"VALUES (\"{newUser.userID}\",\"{newUser.lastName}\",\"{newUser.firstName}\",\"{newUser.userEmail}\",\"{newUser.userPhoneNum}\",1,\"{newUser.userType}\",\"{newUser.department}\",\"{newUser.lastSSN}\",\"{newUser.jobTitle}\")";

                    dbCMD.ExecuteNonQuery();
                }

                return true;
            }

            return false;
        }

        //Check if appoint is there
        public bool isAppointmentThere(int dbID)
        {
            if (this.OpenConnection() == true)
            {
                using (MySqlCommand dbCMD = new MySqlCommand())
                {
                    dbCMD.Connection = sqlConn;
                    dbCMD.CommandText = $"SELECT COUNT(*) FROM `appointmentLog` WHERE `id`={dbID}";

                    if (Convert.ToInt32(dbCMD.ExecuteScalar().ToString()) >= 1)
                    {
                        this.CloseConnect();
                        return true;
                    }

                    else
                    {
                        this.CloseConnect();
                        return false;
                    }
                }
            }

            this.CloseConnect();
            return false;
        }

        //Get a single appointment by ID
        public userAppointment getAppointment(int dbID)
        {
            userAppointment userApp = new userAppointment();

            if (this.OpenConnection() == true)
            {
                using (MySqlCommand dbCMD = new MySqlCommand())
                {
                    dbCMD.Connection = sqlConn;
                    dbCMD.CommandText = $"SELECT `userID`,`appointmentDate`,`startTime`,`endTime`,`studentID`,`subject`,`specialProgram` FROM `appointmentLog` WHERE `id`={dbID}";

                    using (MySqlDataReader rdr = dbCMD.ExecuteReader())
                    {
                        rdr.Read();
                        userApp.dbID = dbID;
                        userApp.userID = Convert.ToInt32(rdr[0]);
                        userApp.appointmentDate = Convert.ToDateTime(rdr[1]);
                        userApp.startTime = Convert.ToDateTime(rdr[2].ToString());
                        userApp.endTime = Convert.ToDateTime(rdr[3].ToString());
                        userApp.studentID = (rdr[4] == DBNull.Value) ? 0 : Convert.ToInt32(rdr[4].ToString());
                        userApp.subject = (rdr[5] == DBNull.Value) ? "NO SUBJECT ENTERED" : Convert.ToString(rdr[5].ToString());
                        userApp.specialProgram = rdr[6].ToString();
                    }
                }
            }

            this.CloseConnect();
            return userApp;
        }

        //Update a single appointment by ID
        public bool updateAppointment(userAppointment app)
        {
            bool successfulInsert = false;

            if (this.OpenConnection() == true)
            {
                using (MySqlCommand dbCMD = new MySqlCommand())
                {
                    dbCMD.Connection = sqlConn;
                    dbCMD.CommandText = $"UPDATE `appointmentLog` SET " +
                                        $"`appointmentDate`=\"{app.appointmentDate.Date.ToString("yyyy-MM-dd")}\", `startTime`=\"{app.startTime.ToString("HH:mm:ss")}\", `endTime`=\"{app.endTime.ToString("HH:mm:ss")}\"," +
                                        $"`studentID`=\"{app.studentID}\", `subject`=\"{app.subject}\", `specialProgram`=\"{app.specialProgram}\" " +
                                        $"WHERE `id`={app.dbID}";

                    dbCMD.ExecuteNonQuery();
                    return true;
                }

            }

            return successfulInsert;
        }

        //Delete a appointment by databaseID
        public bool deleteAppointment(int dbID)
        {
            bool deletedApp = false;

            if (this.OpenConnection() == true)
            {
                using (MySqlCommand dbCMD = new MySqlCommand())
                {
                    dbCMD.Connection = sqlConn;
                    //To totally delete an appointment from the Database but we only want to mark it "deleted"
                    //dbCMD.CommandText = $"DELETE FROM `appointmentLog` WHERE `id`={dbID}";

                    //Mark it "deleted"
                    dbCMD.CommandText = $"UPDATE `appointmentLog` SET `deleted`={1} WHERE `id`={dbID}";

                    dbCMD.ExecuteNonQuery();

                    return true;
                }
            }

            return deletedApp;
        }

    }

    public class myJson
    {
        public string ipAddr { get; set; }
        public string ipPort { get; set; }
        public string tsDatabase { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
    }
}