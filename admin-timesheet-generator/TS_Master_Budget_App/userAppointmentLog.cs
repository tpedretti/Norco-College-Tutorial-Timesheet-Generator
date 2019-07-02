using System;

namespace TS_Master_Budget_App
{
    public struct userAppointment
    {
        public int dbID;
        public int userID;
        public int studentID;
        public DateTime appointmentDate;
        public string subject;        
        public DateTime startTime;
        public DateTime endTime;
        public DateTime loggedTime;
        public string specialProgram;
    };

    public struct appInfo
    {
        public string userID;
        public string tuteeID;
        public string startTime;
        public string endTime;
        public string subject;
    };
}
