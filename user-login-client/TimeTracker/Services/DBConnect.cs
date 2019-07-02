using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System.ComponentModel;
using System.Windows.Forms;

namespace TimeTracker.Services
{
    class DBConnect : IDisposable
    {
        public static string fileName { get; set; } = "sqlInfo.json";
        //public string ipAddr { get; set; } = "192.168.111.128";
        public string ipAddr { get; set; } = "10.56.100.248";
        public string ipPort { get; set; } = "3306";
        public string tsDatabase { get; set; } = "tsDB";
        public string userName { get; set; } = "tsUser";
        //public string password { get; set; } = "TempPass1";
        public string password { get; set; } = "DBUserServices#NCC!2017";

        //myJson jsonInfo;
        public MySqlConnection sqlConn = new MySqlConnection();
        MySqlConnectionStringBuilder connString = new MySqlConnectionStringBuilder();

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
            //Settings for NCC Tutor server
            connString.Server = "10.56.100.248";
            connString.Database = "tsDB";
            connString.UserID = "tsUser";
            connString.Password = "DBUserServices#NCC!2017";

            this.handle = handle;
            //connString.Server = ipAddr;
            connString.Port = 3306;
            ////connString.Port = Convert.ToUInt16(ipPort);
            //connString.Database = tsDatabase;
            //connString.UserID = userName;
            //connString.Password = password;
            sqlConn.ConnectionString = connString.ConnectionString;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this.disposed)
            {
                // If disposing equals true, dispose all managed
                // and unmanaged resources.
                if (disposing)
                {
                    // Dispose managed resources.
                    component.Dispose();
                }

                // Call the appropriate methods to clean up
                // unmanaged resources here.
                // If disposing is false,
                // only the following code is executed.
                CloseHandle(handle);
                handle = IntPtr.Zero;

                // Note disposing has been done.
                disposed = true;

            }
        }        

        private bool openConn()
        {
            try
            {
                sqlConn.OpenAsync();
                return true;
            }
            catch(MySqlException ex)
            {
                switch(ex.Number)
                {
                    case 0:
                        break;
                    case 1045:
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

        //Check to see if ID is connected to user
        public string checkID(int userID)
        {
            string userType = null;

            if(this.openConn() == true)
            {
                using (MySqlCommand dbCMD = new MySqlCommand())
                {
                    dbCMD.Connection = this.sqlConn;
                    dbCMD.CommandText = $"SELECT COUNT(*) FROM `userInfo` WHERE `userID`={userID}";

                    if (Convert.ToInt32(dbCMD.ExecuteScalar()) == 1)
                    {
                        dbCMD.CommandText = $"SELECT * FROM `userInfo` WHERE `userID`={userID}";

                        using (MySqlDataReader rdr = dbCMD.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                userType = rdr[10].ToString();
                            }

                            rdr.Close();
                        }

                        this.CloseConnect();
                        return userType;
                    }
                    else if(Convert.ToInt32(dbCMD.ExecuteScalar()) >= 2)
                    {
                        //If this returns false then there are two people with the same Id
                        //Which SHOULDN'T HAPPEN!
                        this.CloseConnect();
                        return userType;
                    }
                    else
                    {
                        //No one on DB by that ID
                        this.CloseConnect();
                        return userType;
                    }
                }                
            }

            //Failed to connect to DB!
            return userType;
        }        

        public bool checkLogin(int userID)
        {
            if (this.openConn() == true)
            {
                using (MySqlCommand dbCMD = new MySqlCommand())
                {
                    dbCMD.Connection = this.sqlConn;
                    dbCMD.CommandText = $"SELECT COUNT(*) FROM `appointmentLog` WHERE `userID`={userID} AND " +
                        $"`appointmentDate` LIKE \"{DateTime.Today.ToString("yyyy-MM-dd")}%\" AND `subject` LIKE \"Clerk\"" +
                        $" AND `endTime` IS NULL";

                    if (Convert.ToInt32(dbCMD.ExecuteScalar()) == 0)
                    {
                        this.CloseConnect();
                        return false;
                    }
                    else
                    {
                        this.CloseConnect();
                        return true;
                    }
                }
            }

            this.CloseConnect();
            return false;
        }

        public bool clockIn(int userID)
        {
            if(this.openConn() == true)
            {
                using (MySqlCommand dbCMD = new MySqlCommand())
                {
                    dbCMD.Connection = this.sqlConn;
                    dbCMD.CommandText = $"INSERT INTO `appointmentLog`(`userID`, `appointmentDate`, `subject`, `startTime`)" +
                        $"VALUES({userID}, \"{DateTime.Now.ToString("yyyy-MM-dd")}\", \"Clerk\", \"{DateTime.Now.ToString("HH:mm:ss")}\")";
                    dbCMD.ExecuteNonQuery();
                }

                this.CloseConnect();
                return true;
            }

            return false;
        }

        public bool clockOut(int userID)
        {
            if(this.openConn() ==  true)
            {
                using (MySqlCommand dbCMD = new MySqlCommand())
                {
                    dbCMD.Connection = this.sqlConn;
                    dbCMD.CommandText = $"UPDATE `appointmentLog` SET `endTime`=\"{DateTime.Now.ToString("HH:mm:ss")}\" WHERE `userID`={userID}" +
                        $" AND `subject`=\"Clerk\" AND `appointmentDate` LIKE \"{DateTime.Now.ToString("yyyy-MM-dd")}\"" +
                        $" AND `startTime` IS NOT NULL AND `endTime` IS NULL";
                    dbCMD.ExecuteNonQuery();

                    this.CloseConnect();
                    return true;
                }
            }

            this.CloseConnect();
            return false;
        }

        public bool insertApp(appInfo app)
        {
            if(this.openConn() == true)
            {
                using (MySqlCommand dbCMD = new MySqlCommand())
                {
                    dbCMD.Connection = this.sqlConn;

                    //For inserting appointments

                    if(app.tuteeID != null)
                    {
                            dbCMD.CommandText = $"INSERT INTO `appointmentLog`(`userID`, `studentID`, `appointmentDate`," +
                                           $" `subject`, `startTime`, `endTime`, `specialProgram`) " +
                                           $"VALUES({Convert.ToInt32(app.userID)}, {Convert.ToInt32(app.tuteeID)}, \"{app.appDate}\", \"{app.subject}\", \"{app.startTime}\", " +
                                                  $"\"{app.endTime}\", \"{app.specPro}\")";
                    }
                    //For inserting embeded
                    else if(app.isEmbeded == true)
                    {
                        dbCMD.CommandText = $"INSERT INTO `appointmentLog`(`userID`, `appointmentDate`," +
                            $" `subject`, `startTime`, `endTime`) " +
                            $"VALUES({Convert.ToInt32(app.userID)}, \"{app.appDate}\", \"{app.subject} - Embeded\", \"{app.startTime}\", " +
                            $"\"{app.endTime}\")";
                    }
                    //For inserting express
                    else
                    {
                        dbCMD.CommandText = $"INSERT INTO `appointmentLog`(`userID`, `appointmentDate`," +
                            $" `subject`, `startTime`, `endTime`) " +
                            $"VALUES({Convert.ToInt32(app.userID)}, \"{app.appDate}\", \"{app.subject}\", \"{app.startTime}\", " +
                            $"\"{app.endTime}\")";
                    }

                    dbCMD.ExecuteNonQuery();
                }

                this.CloseConnect();
                return true;
            }

            return false;
        }
    }
}
