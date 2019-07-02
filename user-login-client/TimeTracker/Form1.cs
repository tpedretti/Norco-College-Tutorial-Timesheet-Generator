using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using TimeTracker.Services;

namespace TimeTracker
{
    public partial class TimeTracker : Form
    {
        private int formWidth;
        private int formHeight;
        private int userID;

        private List<string> tutorStartHRs = new List<string>();
        private List<string> tutorEndHRs = new List<string>();
        private List<string> embedHRs = new List<string>();

        private List<string> emHR = new List<string>();
        private List<string> emMin = new List<string>();

        private RadioButton[] appType = new RadioButton[3];
        private RadioButton[] embedRadStart = new RadioButton[2];
        private RadioButton[] embedRadEnd = new RadioButton[2];

        private List<string> expressSubs = new List<string>{"Study Group", "ACC EXP", "ANATOMY EXP", "BIO EXP", "COM EXP",
            "ECO EXP", "FRE EXP", "HIS EXP", "STATS EXP", "CHE EXP", "CIS/GAM EXP", "ESL EXP", "MAT EXP", "PSY EXP", "SPA EXP",
            "WRT EXP", "STEM EXP", "LRC WORK" };
        //private List<string> normSubs = new List<string> {"ACC-1A", "ACC-1B", "ACC-200", "ACC-55", "ACC-61", "ACC-62", "ACC-63",
        //    "ACC-65", "ACC-66", "ACCT-38", "AMY-10","AMY-2A","AMY-2B","AMY-10","AMY-2A","AMY-2B","ANT-1","ANT-10","ANT-2","ANT-3"
        //    ,"ANT-4","ANT-5","ANT-6","ANT-7","ANT-8","ARE-24","ARE-25","ARE-26","ARE-28","ARE-35","ARE-36","ARE-37","ART-1","ART-10",
        //    "ART-11","ART-17","ART-18","ART-19","ART-2","ART-20","ART-23","ART-24","ART-25","ART-26","ART-27","ART-28","ART-3","ART-30",
        //    "ART-34","ART-35","ART-36","ART-38","ART-39","ART-40","ART-41","ART-42","ART-43","ART-44","ART-48","ART-49","ART-5","ART-50",
        //    "ART-51","ART-6","ART-6H","ART-7","ART-8","ART-9","BIO-1","BIO-10","BIO-11","BIO-12","BIO-17","BIO-2A","BIO-2B","BIO-3","BIO-30",
        //    "BIO-31A","BIO-31B","BIO-34","BIO-36","BIO-5","BIO-6","BIO-7","BIO-8","BIO-9","BUS-10","BUS-18A","BUS-20","BUS-200","BUS-22",
        //    "BUS-3","BUS-30","BUS-43","BUS-47","BUS-53","BUS-70","BUS-80","BUS-82","BUS-83","BUS-85","BUS-86","BUS-87","BUS-90","CAT-3",
        //    "CAT-31","CAT-54A","CAT-56A","CAT-65","CAT-76A","CAT-76B","CAT-78A","CAT-78B","CAT-79","CAT-80","CAT-81","CAT-93","CAT-95A",
        //    "CAT-98A","CAT-98B","CHE-10","CHE-12A","CHE-12B","CHE-1A","CHE-1B","CHE-2A","CHE-2B","CHE-3","CHI-1","CHI-2","CIS-21","CIS-23",
        //    "CIS-5","CIS-72A","CIS-98A","CIS-11","CIS-12","CIS-14A","CIS-14B","CIS-16A","CIS-17A","CIS-17B", "CIS-17C", "CIS-18A","CIS-18B",
        //    "CIS-18C","CIS-18D","CIS-1A","CIS-1B","CIS-2","CIS-200","CIS-3","CIS-35","CIS-37","CIS-38A","CIS-38B","CIS-38C","CIS-39","CIS-40",
        //    "CIS-54A","CIS-54B","CIS-56A","CIS-61","CIS-63","CIS-65","CIS-66","CIS-72B","CIS-72C","CIS-76A","CIS-76B","CIS-78A","CIS-78B",
        //    "CIS-79","CIS-80","CIS-81","CIS-93","CIS-95A","CIS-98A","CIS-98B","COM-1","COM-11","COM-12","COM-13","COM-19","COM-1H","COM-2",
        //    "COM-3","COM-5","COM-6","COM-7","COM-9","COM-9H","CSC-11","CSC-12","CSC-14A","CSC-16A","CSC-17A","CSC-17B","CSC-17C","CSC-18A",
        //    "CSC-18B","CSC-18C","CSC-18D","CSC-2","CSC-21","CSC-5","CSC-6","CSC-61","CSC-63","ECO-4","ECO-7","ECO-7H","ECO-8","ELE-13",
        //    "ELE-21","ELE-64","ENE-21","ENE-22","ENE-30","ENE-42","ENE-51","ENE-52","ENE-60","ENG-11","ENG-14","ENG-1A","ENG-1B","ENG-50",
        //    "ENG-60A","ENG-60B","ENG-80","EOPS","ESL-51","ESL-52","ESL-53","ESL-54","ESL-55","ESL-91","FRE-1","FRE-2","GAM-21","GAM-22",
        //    "GAM-23","GAM-31","GAM-32","GAM-35","GAM-37","GAM-38A","GAM-38B","GAM-42","GAM-45","GAM-46","GAM-48","GAM-49","GAM-50","GEG 1",
        //    "GEG 1L","GUI 48","GUI-45","HES-1","HIS-1","HIS-2","HIS-31","HIS-5","HIS-6","HIS-7","HUM-10","ITA-1","ITA-2","JPN-1","JPN-2",
        //    "JPN-3","JPN-4","MAG-47","MAT-10","MAT-11","MAT-12","MAT-1A","MAT-1B","MAT-1C","MAT-2","MAT-25","MAT-3","MAT-32","MAT-35",
        //    "MAT-36","MAT-4","MAT-5","MAT-50","MAT-51","MAT-52","MAT-53","MAT-63","MAT-64","MAT-65","MAT-7","MIC-1","MUC-1","MUC-10",
        //    "MUC-11","MUC-2","MUC-3","MUC-4","MUC-5","MUC-6","MUC-7","MUC-8","MUC-9","MUS 5","MUS-1","MUS-19","MUS-3","MUS-32","MUS-37",
        //    "MUS-4","MUS-5","MUS-8A","MUS-8B","MUS-9","NRN-50","NRN-51","NRN-52","PHI-10","PHI-11","PHY-10","PHY-4A","PHY-4B","PHY-4C",
        //    "POL-1","POL-2","PSY-1","PSY-33","PSY-35","PSY-50","PSY-9","READ","RUS-1","SOC-1","SOC-12","SOC-2","SPA-1","SPA-1A","SPA-1B",
        //    "SPA-2","SPA-3","SPA-4","SPA-51","SPA-53","SPA-8","SPE-1","SPE-9","WSL-92","Writing" };

        private List<string> normSubs = new List<string> { "CHE-2A", "CHE-2B", "CHE-3", "CHE-1A", "CHE-1B", "CHE-12A", "CHE-12B", "CHE-10",
            "MAT-3", "MAT-2", "MAT-1C", "MAT-1B", "MAT-1A", "MAT-5", "MAT-10", "MAT-12", "MAT-11", "MAT-36", "MAT-25", "MAT-53", "MAT-35",
            "MAT-52", "MAT-42", "MAT-65", "MAT-64", "MAT-63", "Writing", "ENG-1A", "ENG-1B", "ENG-4", "ENG-8", "ENG-11", "ENG-14", "ENG-15",
            "ENG-16", "ENG-17A", "ENG-17B", "ENG-17C", "ENG-20", "ENG-23", "ENG-30", "ENG-35", "ENG-40", "ENG-41", "ENG-44", "ENG-45", "ENG-47",
            "ENG-48", "ENG-50", "ENG-60A", "ENG-60B", "ENG-70", "ENG-80", "ENG-85", "ENG-91", "BIO-1", "BIO-3", "BIO-4", "BIO-5", "BIO-7", "BIO-8",
            "BIO-10", "BIO-11", "BIO-12", "BIO-16", "BIO-17", "BIO-18", "BIO-19", "BIO-30", "BIO-34", "BIO-35", "BIO-36", "BIO-45", "BIO-50A", "BIO-50B",
            "BIO-55", "BIO-60", "BIO-61", "ACC-1A", "ACC-1B", "ACC-55", "ACC-61", "ACC-62", "ACC-63", "ACC-65", "ACC-66", "ACC-67", "ACC-200", "ADJ-1",
            "ADJ-2", "ADJ-3", "ADJ-4", "ADJ-5", "ADJ-6", "ADJ-7", "ADJ-8", "ADJ-9", "ADJ-13", "ADJ-14", "ADJ-16", "ADJ-23", "ANT-1", "ANT-2", "AND-3", "AND-4",
            "ANT-5", "ANT-6", "ANT-7", "ANT-8", "ANT-10", "ARE-24", "ARE-25", "ARE-35", "ARE-36", "ARE-37", "ARE-200", "ART-1", "ART-2", "ART-5", "ART-6", "ART-7",
            "ART-9", "ART-10", "ART-11", "ART-12", "ART-13", "ART-14", "ART-17", "ART-18", "ART-19", "ART-20", "ART-22", "ART-23", "ART-24", "ART-25A", "ART-26",
            "ART-27", "ART-28A", "ART-36A", "ART-39", "ART-40A", "ART-40B", "ART-48A", "ART-200", "BUS-3", "BUS-10", "BUS-12", "BUS-13", "BUS-14", "BUS-18A", "BUS-18B",
            "BUS-20", "BUS-22", "BUS-24", "BUS-30", "BUS-31", "BUS-33", "BUS-47", "BUS-80", "BUS-82", "BUS-83", "BUS-85", "BUS-86", "BUS-87", "BUS-90", "BUS-200", "CAT-1A",
            "CAT-3", "CAT-31", "CAT-51", "CAT-65", "CAT-78A", "CAT-79", "CAT-80", "CAT-90", "CAT-93", "CAT-95A", "CAT-95B", "CAT-98A", "CAT-98B", "CIS-1A", "CIS-1B", "CIS-2",
            "CIS-3", "CIS-5", "CIS-7", "CIS-11", "CIS-12", "CIS-14A", "CIS-17A", "CIS-17B", "CIS-17C", "CIS-18A", "CIS-18B", "CIS-18C", "CIS-21", "CIS-37", "CIS-38A", "CIS-38A",
            "CIS-39", "CIS-44", "CIS-54B", "CIS-56A", "CIS-59", "CIS-65", "CIS-66", "CIS-67", "CIS-68", "CIS-69", "CIS-72A", "CIS-72B", "CIS-74", "CIS-75", "CIS-76B", "CIS-77",
            "CIS-78A", "CIS-78B", "CIS-79", "CIS-80", "CIS-81", "CIS-90", "CIS-93", "CIS-95A", "CIS-98A", "CIS-98B", "CIS-200", "CSC-2", "CSC-5", "CSC-7", "CSC-11", "CSC-12",
            "CSC-14A", "CSC-17A", "CSC-18A", "COM-1", "COM-2", "COM-3", "COM-6", "COM-7", "COM-9", "COM-11", "COM-12", "COM-13", "COM-20", "CON-60", "CON-61", "CON-62", "CON-63A",
            "CON-63B", "CON-63C", "CON-63D", "CON-64", "CON-65", "CON-66", "CON-67", "CON-68", "CON-70", "CON-71", "CON-72", "CON-73", "CON-74", "CON-80", "CON-200", "DAN-6",
            "DFT-21", "DFT-22", "DFT-23", "DFT-24", "DFT-27", "DFT-30", "DFT-42", "DFT-42B", "DFT-51", "DFT-52", "DFT-60", "DFT-200", "EAR-19", "EAR-20", "EAR-24", "EAR-25",
            "EAR-26", "EAR-28", "EAR-30", "EAR-33", "EAR-34", "EAR-35", "EAR-38", "EAR-40", "EAR-41", "EAR-42", "EAR-43", "EAR-44", "EAR-45", "EAR-46", "EAR-47", "EAR-200",
            "ECON-4", "ECON-7", "ECON-8", "ELE-10", "ELE-11", "ELE-13", "ELE-23", "ELE-25", "ELE-26", "ELE-27", "ELE-28", "ELE-55", "ELE-61", "ELE-63", "ELE-64", "ELE-66",
            "ELE-71", "ELE-72", "ELE-73", "ELE-74", "ELE-75", "ELE-76", "ELE-77", "ELE-91", "ELE-400", "ELE-401", "ELE-402", "ELE-403", "ELE-404", "ELE-405", "ELE-406",
            "ELE-407", "ELE-408", "ELE-409", "ELE-420", "ELE-421", "ELE-422", "ELE-423", "ELE-424", "ELE-425", "ELE-499", "ENE-10", "ENE-21", "ENE-22", "ENE-23", "ENE-27",
            "ENE-28", "ENE-30", "ENE-35", "ENE-38", "ENE-39", "ENE-40", "ENE-41", "ENE-42", "ENE-42B", "ENE-51", "ENE-52", "ENE-60", "ENE-62", "ENE-200", "ESL-51", "ESL-52",
            "ESL-53", "ESL-54", "ESL-55", "ESL-71", "ESL-72", "ESL-73", "ESL-90D", "ESL-90L", "ESL-90M", "ESL-90P", "ESL-91", "ESL-92", "ESL-93", "ESL-95", "FRE-1", "FRE-2",
            "FRE-8", "GAM-21", "GAM-22", "GAM-23", "GAM-24", "GAM-32", "GAM-33", "GAM-35", "GAM-39", "GAM-41", "GAM-44", "GAM-46", "GAM-50", "GAM-51", "GAM-52", "GAM-53",
            "GAM-70", "GAM-71", "GAM-72", "GAM-73", "GAM-79B", "GAM-79C", "GAM-79D", "GAM-79E", "GAM-79F", "GAM-80", "GAM-81", "GAM-82", "GAM-200", "GEG-1", "GEG-2", "GEG-3",
            "GEG-4", "GEG-5", "GEG-6", "GUI-45", "GUI-46", "GUI-47", "GUI-48", "HES-1", "HIS-1", "HIS-2", "HIS-6", "HIS-7", "HIS-14", "HIS-25", "HIS-26", "HIS-31", "HIS-34",
            "HUM-4", "HUM-5", "HUM-8", "HUM-9", "HUM-10", "HUM-11", "HUM-18", "HUM-20C", "HUM-23", "HUM-35", "ILA-1", "JPN-1", "JPN-2", "JOU-7", "JOU-20A", "JOU-20B", "JOU-20C",
            "JOU-20D", "KIN-4", "KIN-10", "KIN-16", "KIN-30", "KIN-35", "KIN-36", "KIN-38", "KIN-A03", "KING-A20", "KIN-A21", "KIN-A40", "KIN-A41", "KIN-A46", "KIN-A47",
            "KIN-A55", "KIN-A64", "KIN-A71", "KIN-A75A", "KIN-A75B", "KIN-A77A", "KIN-A77B", "KIN-A77C", "KIN-A81A", "KIN-A81B", "KIN-A83", "KIN-A90A", "KIN-A90B", "KIN-A90B",
            "KIN-A90C", "KIN-V01", "KIN-V10", "KIN-V12", "KIN-V25", "KIN-V71", "KIN-V78", "KIN-V94", "KIN-V95", "LIB-1", "MAG-44", "MAG-47", "MAG-51", "MAG-53", "MAG-54",
            "MAG-56", "MAG-200", "MAN-35", "MAN-38", "MAN-39", "MAN-55", "MAN-56", "MAN-57", "MAN-60", "MAN-61", "MAN-63", "MAN-64", "MAN-68", "MAN-69", "MAN-72", "MAN-73",
            "MAN-74", "MAN-77", "MAN-200MIS-1A", "MIS-1B", "MIS-1C", "MIS-2", "MIS-3", "MIS-4", "MIS-7", "MIS-10A", "MIS-10B", "MIS-11A", "MIS-11B", "MIS-12", "MIS-13", "MIS-200",
            "MKT-20", "MKT-40", "MKT-41", "MKT-42", "MUS-3", "MUS-4", "MUS-5", "MUS-6", "MUS-19", "MUS-23", "MUS-25", "MUS-30", "MUS-31", "MUS-32A", "MUS-32B", "MUS-32C",
            "MUS-32D", "MUS-33", "MUS-37", "MUS-38", "MUS-39", "MUS-41", "MUS-52", "MUS-53", "MUS-65", "MUS-67", "MUS-70", "MUS-75", "MUS-78", "MUS-79", "MUS-81", "MUS-87",
            "MUS-89", "MUS-92", "MUS-93", "MUS-96A", "MUS-200PHI-10", "PHI-11", "PHI-12", "PHI-15", "PHI-19", "PHI-22", "PHI-32", "PHI-33", "PHI-35", "PHO-20", "PHS-1", "PHY-2A",
            "PHY-2B", "PHY-4A", "PHY-4B", "PHY-4C", "PHY-10", "PHY-11", "POL-1", "POL-2", "POL-4", "POL-5", "POL-7A", "POL-11", "POL-13", "POL-14", "PSY-1", "PSY-2", "PSY-8",
            "PSY-9", "PSY-33", "PSY-35", "PSY-48", "PSY-50", "REA-2", "REA-3", "REA-4", "REA-80", "REA-81", "REA-82", "REA-83", "REA-85", "REA-86", "REA-200", "RLE-80", "RLE-81",
            "RLE-82", "RLE-83", "SOC-1", "SOC-2", "SOC-3", "SOC-10", "SOC-12", "SOC-15", "SOC-20", "SOC-48", "SOC-50", "SPA-1", "SPA-2", "SPA-3", "SPA-4", "SPA-8", "SPA-11",
            "SPA-12", "SCT-1", "SCT-200", "THE-2", "THE-3", "THE-5", "THE-29", "THE-32", "THE-33", "THE-34", "THE-35", "THE-39", "THE-41", "THE-44", "THE-46", "THE-48", "WEL-34",
            "WKX-200", "WKX-201" };




        System.Windows.Forms.Timer t = null;

        //private List<string> 

        public TimeTracker()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            formHeight = this.ClientRectangle.Height;
            formWidth = this.ClientRectangle.Width;

            //What version the program is on
            group1.Text = "Version: 0.0.1.10";

            createHRs();
            StartTimer();
            formLayoutStart();

            embedRadStart[0] = startAM;
            embedRadStart[1] = startPM;

            embedRadEnd[0] = endAM;
            embedRadEnd[1] = endPM;

            appType[0] = appointmentCheck;
            appType[1] = expressCheck;
            appType[2] = embedCheck;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {       
            if (userIDBox.Text.Count() == 7)
            {
                userID = Convert.ToInt32(userIDBox.Text);

                using (DBConnect db = new DBConnect())
                {
                    string chkUser = db.checkID(userID);

                    if (chkUser != null)
                    {
                        frontPageVisible(false);

                        if (chkUser.Contains("Clerk"))
                        {
                            bool isLoggedIn = db.checkLogin(userID);

                            if(isLoggedIn == true)
                                clerkWindowVisible(true, true);
                            else
                                clerkWindowVisible(true, false);
                        }
                        else
                        {
                            appType[0].Checked = true;
                            allVisible(true);
                            appIsVisible(true);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No user found by that ID.", "No user found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        //Have to format the postion of things before making it not visible or it wont get formatted.
        private void formLayoutStart()
        {
            frontPageFormat();
            formatTutorWindow();
            formatClearkWindow();
            tutorWindowVisible(false);
            clerkWindowVisible(false);
        }

        private void frontPageFormat()
        {
            //Format front page for logging in
            logoPic.Location = new Point(((formWidth / 2) - (logoPic.Size.Width / 2)), ((formHeight / 2) - 250));

            userIDLabel.Location = new Point(((formWidth / 2) - (userIDLabel.Width)), ((formHeight / 2) - (userIDLabel.Height)));

            userIDBox.Location = new Point(((formWidth / 2) - (userIDBox.Width / 2)), (formHeight / 2));

            multEntriesBox.Location = new Point(((formWidth / 2) - (multEntriesBox.Size.Width / 2)), (formHeight / 2) + userIDBox.Height + 10);

            loginButton.Location = new Point(((formWidth / 2) - (loginButton.Size.Width / 2)), (formHeight / 2) + multEntriesBox.Height * 3 + 20);

            //Temo disable
            multEntriesBox.Enabled = false;
        }

        private void frontPageVisible(bool isVisble)
        {
            logoPic.Visible = isVisble;
            userIDLabel.Visible = isVisble;
            userIDBox.Visible = isVisble;
            multEntriesBox.Visible = isVisble;
            loginButton.Visible = isVisble;
            loginButton.Enabled = isVisble;

            if (isVisble == true)
            {
                userIDBox.Text = "";
                multEntriesBox.Checked = false;
            }
        }

        private void formatTutorWindow()
        {
            ttLogo.Location = new Point((formWidth / 2) - ttLogo.Width / 2, (formHeight / 2) - (ttLogo.Height + ttLogo.Height/2));
            typePanel.Location = new Point((formWidth / 2) - (typePanel.Width / 2), (formHeight / 2) - (appDatePick.Height / 2));

            //Things that never change
            startTimeLabel.Location = new Point((formWidth / 2) - (startTimeBox.Width * 2), (formHeight / 2) - (startTimeBox.Height));

            //Layout if they had an appointment/Express
            //----------------------------------------------------------------------------
            startTimeBox.Location = new Point((formWidth / 2) - (startTimeBox.Width * 2), (formHeight / 2) - (startTimeBox.Height / 2 - 5));
            tuteeIDLabel.Location = new Point((formWidth / 2) - (tuteeIDBox.Size.Width * 2), (startTimeBox.Location.Y + 25));
            tuteeIDBox.Location = new Point((formWidth / 2) - (tuteeIDBox.Width * 2), (tuteeIDLabel.Location.Y) + 15);            

            //End time for express, tutor endtime is calc'd before DB insert
            endTimeLabel.Location = new Point((formWidth / 2) - (endTimeBox.Width * 2), (startTimeBox.Location.Y + 25));
            endTimeBox.Location = new Point((formWidth / 2) - (endTimeBox.Width * 2), (endTimeLabel.Location.Y) + 15);

            subjectLabel.Location = new Point((formWidth / 2) - (appSubjects.Width * 2), tuteeIDBox.Location.Y + 25);
            appSubjects.Location = new Point((formWidth / 2) - (appSubjects.Width * 2), subjectLabel.Location.Y + 15);
            expressSubjects.Location = new Point((formWidth / 2) - (appSubjects.Width * 2), subjectLabel.Location.Y + 15);

            optionPanel.Location = new Point(appSubjects.Location.X, (appSubjects.Location.Y + 25));
            //----------------------------------------------------------------------------

            //Layout for Embeded Tutors/SI
            //----------------------------------------------------------------------------
            embedStartTime.Location = new Point((formWidth / 2) - (startTimeBox.Width * 2) - 5, (formHeight / 2) - (startTimeBox.Height / 2 - 5));
            embedEndTime.Location = new Point((formWidth / 2) - (endTimeBox.Width * 2) - 5, (endTimeLabel.Location.Y) + 15);
            //----------------------------------------------------------------------------

            //Things that never move need to active or disable for the tutor
            appDateLabel.Location = new Point(((formWidth / 2) - (appDatePick.Width / 3) + 20), (startTimeLabel.Location.Y));
            appDatePick.Location = new Point((formWidth / 2) - (startTimeBox.Width / 2), (startTimeBox.Location.Y));

            submitButton.Location = new Point((formWidth / 2 - (specProgCheckBox.Width / 2)), (formHeight / 2) + 180);
            logoutButton.Location = new Point((formWidth / 2 + specProgCheckBox.Width - 28), (formHeight / 2) + 180);

            //appointmentCheck.Checked = true;
            //appIsVisible(true);
            //expressIsVisible(false);
            //embedIsVisible(false);
        }

        private void formatClearkWindow()
        {
            clockPanel.Location = new Point((formWidth / 2) - (clockPanel.Width / 2), (formHeight / 2) - (clockPanel.Height / 2));
        }

        //Used for just hiding the panel as a whole.
        private void clerkWindowVisible(bool isVisble)
        {
            clockPanel.Visible = isVisble;
            clockIN.Visible = false;
            clockOUT.Visible = false;
        }

        private void clerkWindowVisible(bool isVisble, bool isLoggedIn)
        {
            clockPanel.Visible = isVisble;
            clockIN.Visible = (isLoggedIn == false) ? true : false;
            clockOUT.Visible = (isLoggedIn == true) ? true : false;
        }

        private void tutorWindowVisible(bool isVisble)
        {
            ttLogo.Visible = isVisble;
            typePanel.Visible = isVisble;

            //Appointment/Express
            startTimeLabel.Visible = isVisble;
            startTimeBox.Visible = isVisble;
            endTimeBox.Visible = isVisble;
            endTimeLabel.Visible = isVisble;
            subjectLabel.Visible = isVisble;

            //Appointment
            appSubjects.Visible = isVisble;
            appSubjects.DataSource = normSubs;
            tuteeIDBox.Visible = isVisble;
            tuteeIDLabel.Visible = isVisble;
            optionPanel.Visible = isVisble;

            //Express
            expressSubjects.Visible = isVisble;
            expressSubjects.DataSource = expressSubs;

            //Embeded
            embedStartTime.Visible = isVisble;
            embedEndTime.Visible = isVisble;

            //All
            appDateLabel.Visible = isVisble;
            todayDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
            appDatePick.Visible = isVisble;
            submitButton.Visible = isVisble;
            logoutButton.Visible = isVisble;
        }

        private void allVisible(bool isVisble)
        {
            ttLogo.Visible = isVisble;
            typePanel.Visible = isVisble;

            //All
            appDateLabel.Visible = isVisble;
            todayDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
            appDatePick.Visible = isVisble;
            submitButton.Visible = isVisble;
            logoutButton.Visible = isVisble;
        }
            
        private void appIsVisible(bool isVisble)
        {
            //Appointment
            startTimeLabel.Visible = isVisble;
            startTimeBox.Visible = isVisble;
            subjectLabel.Visible = isVisble;

            //Appointment
            appSubjects.Visible = isVisble;
            appSubjects.DataSource = normSubs;
            tuteeIDBox.Visible = isVisble;
            tuteeIDLabel.Visible = isVisble;
            optionPanel.Visible = isVisble;
            appSubjects.Visible = isVisble;
            appSubjects.DataSource = normSubs;
        }

        private void expressIsVisible(bool isVisble)
        {
            //Appointment/Express
            startTimeLabel.Visible = isVisble;
            startTimeBox.Visible = isVisble;
            endTimeBox.Visible = isVisble;
            endTimeLabel.Visible = isVisble;
            subjectLabel.Visible = isVisble;

            //Express
            expressSubjects.Visible = isVisble;
            expressSubjects.DataSource = expressSubs;
        }

        private void embedIsVisible(bool isVisble)
        {
            //Embeded
            embedStartTime.Visible = isVisble;
            embedEndTime.Visible = isVisble;

            appSubjects.Visible = isVisble;
            appSubjects.DataSource = normSubs;
        }

        private void resetOptions()
        {
            tuteeIDBox.Text = "";
            twoHRApp.Checked = false;
            noShow.Checked = false;
            foreach(int i in specProgCheckBox.CheckedIndices)
            {
                specProgCheckBox.SetItemCheckState(i, CheckState.Unchecked);
            }

            startTimeBox.SelectedIndex = -1;
            startTimeBox.Text = "Select One";

            endTimeBox.SelectedIndex = -1;
            endTimeBox.Text = "Select One";

            appSubjects.SelectedIndex = -1;
            appSubjects.Text = "Select One";

            expressSubjects.SelectedIndex = -1;
            expressSubjects.Text = "Select One";

            startHr.SelectedIndex = -1;
            endHr.SelectedIndex = -1;
            startMin.SelectedIndex = -1;
            endMin.SelectedIndex = -1;
        }

        private void createHRs()
        {
            DateTime tutorLRCHR = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 7, 45, 0);
            DateTime tutorLRCHR2 = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 8, 0, 0);

            while (tutorLRCHR.Hour <= 18)
            {
                tutorStartHRs.Add(tutorLRCHR.ToString("hh:mm tt"));
                tutorLRCHR = tutorLRCHR.AddMinutes(15);
                tutorEndHRs.Add(tutorLRCHR2.ToString("hh:mm tt"));
                tutorLRCHR2 = tutorLRCHR2.AddMinutes(15);

                startTimeBox.Items.Add(tutorLRCHR.ToString("hh:mm tt"));
                endTimeBox.Items.Add(tutorLRCHR2.ToString("hh:mm tt"));
            }

            endTimeBox.Items.RemoveAt(endTimeBox.Items.Count - 1);            
            //Lazy man way to end it at the right time... dont care anymoreeee about the loop.... ><
            //tutorStartHRs.Add(tutorLRCHR.ToString("hh:mm tt"));
            //tutorLRCHR = tutorLRCHR.AddMinutes(15);
            //startTimeBox.Items.Add(tutorLRCHR.ToString("hh:mm tt"));
            //tutorEndHRs.Add(tutorLRCHR2.ToString("hh:mm tt"));
            //tutorLRCHR2 = tutorLRCHR2.AddMinutes(15);
            //endTimeBox.Items.Add(tutorLRCHR2.ToString("hh:mm tt"));

            //For Embed times
            for (int i = 1; i <= 12; i++)
                emHR.Add($"{i}");

            int tempMin = 0;
            for (int i = 0; i <= 11; i++)
            {                
                emMin.Add($"{tempMin}");
                tempMin += 5;
            }

            foreach(string temp in emHR)
            {
                startHr.Items.Add(temp.PadLeft(2, '0'));
                endHr.Items.Add(temp.PadLeft(2, '0'));
            }

            foreach(string temp in emMin)
            {
                startMin.Items.Add(temp.PadLeft(2, '0'));
                endMin.Items.Add(temp.PadLeft(2, '0'));
            }
        }

        private void tuteeIDBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void userIDBox_KeyPress(object sender, KeyPressEventArgs e)
        {            
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            DBConnect db = new DBConnect();
            appInfo userInfo = new appInfo();
            bool dbReturn = false;

            userInfo = getUserData();

            DialogResult diaResult = MessageBox.Show($"You are about to sumbit this info:\n" +
                            $"Start Time: " + userInfo.startTime + "\n" +
                            $"End Time: " + userInfo.endTime + "\n" +
                            $"Subject: " + userInfo.subject + "\n" +
                            $"Date: " + userInfo.appDate + "",
                "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (diaResult == DialogResult.Yes)
            {                
                dbReturn = db.insertApp(userInfo);
            }

            if (dbReturn == true)
            {
                MessageBox.Show($"Data inserted into database.", "Successful", MessageBoxButtons.OK);
                frontPageVisible(true);
                tutorWindowVisible(false);
            }
            else
            {
                MessageBox.Show($"Failed to insert data into database. Please contact admin!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                frontPageVisible(true);
                tutorWindowVisible(false);
            }

            resetOptions();
        }

        private void appointmentCheck_CheckedChanged(object sender, EventArgs e)
        {
            //if ((expressCheck.Checked == true) || (embedCheck.Checked == true))
            //{

            expressIsVisible(false);
            embedIsVisible(false);
            appIsVisible(true);

            appSubjects.ResetText();
            appSubjects.Text = "Select One";
            appSubjects.DataSource = normSubs;
            //}
        }

        private void expressCheck_CheckedChanged(object sender, EventArgs e)
        {
            //if ((embedCheck.Checked == true) || (appointmentCheck.Checked == true))
            //{
                
            embedIsVisible(false);
            appIsVisible(false);
            expressIsVisible(true);

            appSubjects.ResetText();
            appSubjects.Text = "Select One";
            expressSubjects.DataSource = expressSubs;
            //}
        }

        private void embedCheck_CheckedChanged(object sender, EventArgs e)
        {
            //if ((expressCheck.Checked == true) || (appointmentCheck.Checked == true))
            //{
                expressIsVisible(false);                
                appIsVisible(false);
            embedIsVisible(true);

            appSubjects.ResetText();
                appSubjects.Text = "Select One";
                appSubjects.DataSource = normSubs;
            //}
        }

        private appInfo getUserData()
        {
            appInfo user = new appInfo();

            user.userID = userIDBox.Text;

            if (appointmentCheck.Checked ==  true)
            {
                if (tuteeIDBox.Text == null)
                    user.tuteeID = "0000000";
                else if (tuteeIDBox.Text == "")
                    user.tuteeID = "0000000";
                else
                    user.tuteeID = tuteeIDBox.Text;
                //user.tuteeID = (tuteeIDBox.Text == (null) || "") ? "0000000" : tuteeIDBox.Text;
                DateTime startTime = new DateTime();                
                startTime = Convert.ToDateTime(startTimeBox.Text);
                user.startTime = startTime.ToString("HH:mm:ss");

                //Figure out endtime for an appointment
                if (twoHRApp.Checked == true)
                {
                    DateTime endtime = new DateTime();

                    endtime = Convert.ToDateTime(startTimeBox.Text);
                    endtime = endtime.AddHours(2);

                    user.endTime = endtime.ToString("HH:mm:ss");
                }
                else
                {
                    DateTime endtime = new DateTime();
                    endtime = Convert.ToDateTime(startTimeBox.Text);
                    endtime = endtime.AddHours(1);

                    user.endTime = endtime.ToString("HH:mm:ss");
                }

                StringBuilder sb = new StringBuilder();
                if (specProgCheckBox.Items.Count >= 1)
                {
                    for (int i = 0; i < specProgCheckBox.CheckedItems.Count; i++)
                    {
                        if (i == specProgCheckBox.CheckedItems.Count - 1)
                            sb.Append(specProgCheckBox.CheckedItems[i]);
                        else
                            sb.Append(specProgCheckBox.CheckedItems[i] + ",");
                    }
                    user.specPro = sb.ToString();
                }
                else
                    user.specPro = null;

                if (noShow.Checked == true)
                {
                    if (user.specPro == null || user.specPro == "")
                        user.specPro = "NoShow";
                    else
                        user.specPro += ",NoSow";
                }

                user.appDate = DateTime.Now.ToString("yyyy-MM-dd");
                user.isEmbeded = false;
                user.subject = appSubjects.Text;
            }
            else if(expressCheck.Checked == true)
            {
                DateTime startTime = new DateTime();
                startTime = Convert.ToDateTime(startTimeBox.Text);
                user.startTime = startTime.ToString("HH:mm:ss");

                DateTime endTime = new DateTime();
                endTime = Convert.ToDateTime(endTimeBox.Text);
                user.endTime = endTime.ToString("HH:mm:ss");

                user.appDate = DateTime.Now.ToString("yyyy-MM-dd");
                user.isEmbeded = false;
                user.subject = expressSubjects.Text;
            }
            else if(embedCheck.Checked == true)
            {
                System.Text.StringBuilder startSB = new StringBuilder();
                System.Text.StringBuilder endSB = new StringBuilder();

                startSB.Append(startHr.Text + ":" + startMin.Text + ":00");
                endSB.Append(endHr.Text + ":" + endMin.Text + ":00");

                if (embedRadStart[0].Checked == true)
                    startSB.Append(" AM");
                else
                    startSB.Append(" PM");

                if (embedRadEnd[0].Checked == true)
                    endSB.Append(" AM");
                else
                    endSB.Append(" PM");

                user.startTime = DateTime.ParseExact(startSB.ToString(), "HH:mm:ss tt", CultureInfo.InvariantCulture).ToString("HH:mm:ss");
                user.endTime = DateTime.ParseExact(endSB.ToString(), "hh:mm:ss tt", CultureInfo.InvariantCulture).ToString("HH:mm:ss");
                user.appDate = DateTime.Now.ToString("yyyy-MM-dd");
                user.isEmbeded = true;
                user.subject = appSubjects.Text;
            }

            //user.subject = appSubjects.Text;

            return user;
        }

        private void StartTimer()
        {
            t = new System.Windows.Forms.Timer();
            t.Interval = 500;
            t.Tick += new EventHandler(t_Tick);
            t.Enabled = true;
        }

        void t_Tick(object sender, EventArgs e)
        {
            clearkLoginClock.Text = DateTime.Now.ToString();
        }

        private void clockIN_Click(object sender, EventArgs e)
        {
            using (DBConnect cmdDC = new DBConnect())
            {
                bool result = cmdDC.clockIn(userID);

                if (result == true)
                {
                    clerkWindowVisible(false);
                    frontPageVisible(true);
                }
            }
        }

        private void clockOUT_Click(object sender, EventArgs e)
        {
            using (DBConnect cmdDC = new DBConnect())
            {
                bool result = cmdDC.clockOut(userID);

                if (result == true)
                {
                    clerkWindowVisible(false);
                    frontPageVisible(true);
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            clerkWindowVisible(false);
            frontPageVisible(true);
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            tutorWindowVisible(false);
            frontPageVisible(true);
        }

        //private void appType_CheckedChanged(object sender, EventArgs e)
        //{
        //    if(((RadioButton)sender).Checked)
        //    {
        //        RadioButton rb = (RadioButton)sender;

        //        if(rb.Name == "appointmentCheck")
        //        {
        //            appIsVisible(true);
        //            expressIsVisible(false);
        //            embedIsVisible(false);
        //        }
        //        else if(rb.Name == "expressCheck")
        //        {
        //            appIsVisible(false);
        //            expressIsVisible(true);
        //            embedIsVisible(false);
        //        }
        //        else if(rb.Name == "embedCheck")
        //        {
        //            appIsVisible(false);
        //            expressIsVisible(false);
        //            embedIsVisible(true);
        //        }
        //    }
        //}
    }
}
