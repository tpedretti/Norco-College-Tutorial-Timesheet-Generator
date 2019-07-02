using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

//Should make a log service so I don't need this...
using System.Windows.Forms;

using iText.Forms;
using iText.Forms.Fields;
using iText.Kernel.Pdf;

namespace TS_Master_Budget_App.Services
{
    class PDFManagement
    {
        List<budgetCodes> budgetList = new List<budgetCodes>();
        List<string> budFilesNames = new List<string>();
        List<string> folderList = new List<string>();
        DBConnect dBConnect = new DBConnect();
        ProgramSettings settings = new ProgramSettings();
        const string srcCover = "pdf\\Timesheet_Clean_Cover.pdf";
        //const string srcTimeSheet = "pdf\\Timesheet_Clean_Budget.pdf";
        const string srcTimeSheetHourly = "pdf\\Timesheet_Clean_Budget_Hourly.pdf";
        const string srcTimeSheetStudent = "pdf\\Timesheet_Clean_Budget_Student.pdf";

        //Function the start of creating time sheets.
        //userInfo user - Info about the selected user
        //List<userAppointment> appLog - App. Log of user
        //DateTime startD - The first day of said month
        //DateTime endD - The last day of said month
        //1. Gets the selected users appointments for that month which is selected.    
        //2. Calls fillUserHours(); - Pass DB Connect, User Object, User Appointments for the month, CoverFields of coversheet, and the out object to write to Coversheet.
        //3. Calls calcTotlas() - Calcs total for each budget.
        public virtual void createTimeSheet(userInfo user, List<userAppointment> appLog, DateTime startD, DateTime endD)
        {
            folderList = getFolderList(user);
            settings.Load(ref settings);

            //This is all for filling out the cover sheet.
            if (checkAvailability(user, appLog) == true)
            {
                PdfFormField toSet = null;
                PdfDocument pdfCover = new PdfDocument(new PdfReader(srcCover),
                                                       new PdfWriter(folderList[1] + (user.lastName + ", " + user.firstName + " - " +
                                                                     startD.ToString("MMMM yyyy") + " Budget Cover" + ".pdf")));
                PdfAcroForm form = PdfAcroForm.GetAcroForm(pdfCover, false);
                IDictionary<string, PdfFormField> coverFields = form.GetFormFields();
                appLog = appLog.OrderBy(x => x.appointmentDate).ToList();

                fillTimeSheetCoverPG(coverFields, user);
                calcHoursForDay(user, appLog, startD, endD, coverFields, toSet);
                calcTotals(user, startD, endD, coverFields, toSet);

                pdfCover.Close();
            }
            else
            {
                if (user.userType.Contains("D") || user.userType.Contains("SE"))
                    MessageBox.Show($"User: {user.fullnameWComma()}, {user.userID} doesn't have enough hours left to be paid with.", 
                        "No Availability", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (user.userType.Contains("SWF"))
                    MessageBox.Show($"User: {user.fullnameWComma()}, {user.userID} doesn't have enough FWS funds to be paid with.", 
                        "No Availability", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        //Calc how much they worked this month to check if they have enough hours/money to be paid.
        private bool checkAvailability(userInfo user, List<userAppointment> appLog)
        {
            double totalHRS = 0.0;

            foreach(userAppointment app in appLog)
                totalHRS += (app.endTime - app.startTime).TotalHours;


            if(settings.overwrite == true)
            {
                return true;
            }
            else if(settings.FWSWT5 == true)
            {
                return true;
            }
            else if(user.userType.Contains("D") || user.userType.Contains("SE"))
            {
                if (user.budget.currentHR < totalHRS)
                    return false;
            }
            else if(user.userType.Contains("SWF"))
            {
                if (user.budget.currentMoney < (totalHRS * user.payRate))
                    return false;
            }

            return true;
        }

        //Function that fills in the users info and each budget header with the correct info for the Cover sheet.
        private void fillTimeSheetCoverPG(IDictionary<string, PdfFormField> coverFields, userInfo user)
        {
            PdfFormField toSet = null;

            coverFields.TryGetValue("Employee Name", out toSet);
            toSet.SetValue(user.lastName + ", " + user.firstName);

            coverFields.TryGetValue("Last 4 Digits SS#", out toSet);
            toSet.SetValue($"{user.lastSSN}");

            coverFields.TryGetValue("Department / Site", out toSet);
            toSet.SetValue($"{user.department}");

            coverFields.TryGetValue("Job Title", out toSet);
            toSet.SetValue($"{user.jobTitle}");

            //Used for filling out Budget Code Headers            
            //Call for getting the correct budget codes used for this user
            using (DBConnect cmdDB = new DBConnect())
                budgetList = cmdDB.getBudgetCodes(user);

            //Fill out budget code info
            foreach (budgetCodes code in budgetList)
            {
                switch (code.budgetName)
                {
                    case "District":
                        coverFields.TryGetValue("PG1_Budget Code 1", out toSet);
                        toSet.SetValue(code.budgetCode).SetFontSize(6.0f);

                        coverFields.TryGetValue("PG1_Budget Code 2", out toSet);
                        toSet.SetValue(code.budgetName).SetFontSize(12.0f);
                        break;

                    case "FWS":
                        coverFields.TryGetValue("PG2_Budget Code 1", out toSet);
                        toSet.SetValue(code.budgetCode).SetFontSize(6.0f);

                        coverFields.TryGetValue("PG2_Budget Code 2", out toSet);
                        toSet.SetValue(code.budgetName).SetFontSize(12.0f).SetJustification(1);
                        break;

                    /* Used when EOPS had a budget to pay no longer used for now.
                    case "EOPS":
                        coverFields.TryGetValue("PG3_Budget Code 1", out toSet);
                        toSet.SetValue(code.budgetCode).SetFontSize(6.0f);

                        coverFields.TryGetValue("PG3_Budget Code 2", out toSet);
                        toSet.SetValue(code.budgetName).SetFontSize(12.0f);
                        break;
                    */

                    case "Title V":
                        coverFields.TryGetValue("PG4_Budget Code 1", out toSet);
                        toSet.SetValue(code.budgetCode).SetFontSize(6.0f);

                        coverFields.TryGetValue("PG4_Budget Code 2", out toSet);
                        toSet.SetValue(code.budgetName).SetFontSize(12.0f);
                        break;

                    /* Used when Basic Skills had a budget. No longer used for now. 
                        
                        case "Basic Skills":
                        coverFields.TryGetValue("PG5_Budget Code 1", out toSet);
                        toSet.SetValue(code.budgetCode).SetFontSize(6.0f);

                        coverFields.TryGetValue("PG5_Budget Code 2", out toSet);
                        toSet.SetValue(code.budgetName).SetFontSize(12.0f);
                        break;
                    */
                }
            }
        }

        //Takes users Appointments from DB and breaks each appointment down
        //and fills in the hours into the right budget for each day.
        private void calcHoursForDay(userInfo user, List<userAppointment> appLog, DateTime startD, 
            DateTime endD, IDictionary<string, PdfFormField> coverFields, PdfFormField toSet)
        {
            foreach (DateTime appDate in AllDatesInMonth(startD.Year, startD.Month))
            {
                double noShow = 0.0;
                double FWSHRs = 0.0;
                double titleVHRs = 0.0;
                double distractHRs = 0.0;

                List<userAppointment> appDay = new List<userAppointment>();
                appDay = appLog.FindAll(x => (x.appointmentDate.Day == appDate.Day)).ToList();

                //Remove one person from appDay if the tutor has two people in one appointment
                List<userAppointment> tempList = new List<userAppointment>();
                foreach (userAppointment app in appDay)
                {
                    List<userAppointment> temp = appDay.FindAll(x => (x.startTime == app.startTime));

                    if(temp.Count == 1)
                    {
                        tempList.Add(app);
                    }
                    else if(temp.Count >= 2)
                    {
                        temp.RemoveRange((temp.Count - 1), 1);
                        tempList.AddRange(temp);
                    }
                }

                tempList = tempList.Distinct().ToList();
                appDay = tempList;                

                //All the logic that is used to figure out where what hour goes for each budget
                //Does have errors still needs to be worked on.
                if (appDay.Count >= 1)
                {
                    //bool bugFix - used to fix user error if they entered a two hour appointment as two different appointments.
                    bool bugFix = false;

                    using (DBConnect cmdDB = new DBConnect())
                    {
                        foreach (userAppointment app in appDay)
                        {
                            //Used to check if the second hour is EOPS or DRC and if so Title V pays for the second hour
                            if ((app.specialProgram.Contains("EOPS") || (app.specialProgram.Contains("DRC"))) && !app.specialProgram.Contains("NoShow"))
                            {
                                if ((app.endTime - app.startTime).TotalHours >= 2.00)
                                {
                                    distractHRs += 1.00;
                                    titleVHRs += 1.00;
                                }
                                else if (cmdDB.EOPSAppointmentCheck(app, user) == "2ND1HR")
                                {
                                    titleVHRs += 1.00;
                                }
                                else if (cmdDB.EOPSAppointmentCheck(app, user) == "ERRORENT" && bugFix == false)
                                {
                                    bugFix = true;
                                    titleVHRs += 1.00;
                                }
                                else if (cmdDB.EOPSAppointmentCheck(app, user) == "ERRORENT" && bugFix == true)
                                {
                                    distractHRs += 1.00;
                                }
                                else
                                {
                                    distractHRs += 1.00;
                                }
                            }
                            else if(app.subject.Contains("EXP"))
                            {
                                titleVHRs += (app.endTime - app.startTime).TotalHours;
                            }
                            else if (app.specialProgram.Contains("NoShow"))
                            {
                                noShow += 0.25;
                            }
                            else
                            {
                                distractHRs += (app.endTime - app.startTime).TotalHours;
                            }
                        }
                    }

                    bugFix = false;
                    distractHRs += noShow;

                    fillHRSForDay(ref user, ref coverFields, appDate, toSet, ref distractHRs, ref titleVHRs);
                }
            }
        }

        //Fills in the hours for the day on the time sheet.
        private void fillHRSForDay(ref userInfo user, ref IDictionary<string, PdfFormField> coverFields,
            DateTime appDate, PdfFormField toSet, ref double distractHRs, ref double titleVHRs)
        {
            //SWF = Student Employee that has FWS
            //SE = Student Employee that doesn't have FWS (Acts a lot like D, so uses all of D functions)
            //D = Distract Employee
            if (user.userType.Contains("SE") || user.userType.Contains("D") || user.userType.Contains("SWF"))
            {
                if (user.userType.Contains("D") || user.userType.Contains("SE"))
                {
                    //Fill in Distract total hours for that day.
                    if (distractHRs != 0.00)
                    {
                        coverFields.TryGetValue("PG1_Hours" + (appDate.Day), out toSet);
                        toSet.SetValue(distractHRs.ToString("F2"));
                    }

                    if (titleVHRs != 0.00)
                    {
                        //Fill in Title V hours for that day.
                        coverFields.TryGetValue("PG4_Hours" + (appDate.Day), out toSet);
                        toSet.SetValue(titleVHRs.ToString("F2"));
                    }

                    //Update the current user Hours left if they're district.
                    user.budget.currentHR -= (distractHRs + titleVHRs);
                    dBConnect.updateUserBudget(user);
                }
                else if (user.userType.Contains("SWF"))
                {
                    if (settings.FWSWT5 != true)
                    {
                        //Fill in FWS total hours for that day.
                        if (distractHRs != 0.00)
                        {
                            coverFields.TryGetValue("PG2_Hours" + (appDate.Day), out toSet);
                            toSet.SetValue(distractHRs.ToString("F2"));
                        }

                        if (titleVHRs != 0.00)
                        {
                            //Fill in Title V hours for that day.
                            coverFields.TryGetValue("PG4_Hours" + (appDate.Day), out toSet);
                            toSet.SetValue(titleVHRs.ToString("F2"));
                        }

                        //Update the current user Hours left if they're district.
                        user.budget.currentMoney -= (user.payRate * (distractHRs + titleVHRs));
                        dBConnect.updateUserBudget(user);
                    }
                    else
                    {
                        if (titleVHRs != 0.00 || distractHRs != 0.00)
                        {
                            //Fill in Title V hours for that day.
                            coverFields.TryGetValue("PG4_Hours" + (appDate.Day), out toSet);
                            toSet.SetValue((titleVHRs + distractHRs).ToString("F2"));
                        }
                    }
                }
            }
        }

        //Function that takes info from coversheet and fill in a PDF for
        //the budget time sheets that the tutor signs. Number of this sheets are created if there
        //were any special budget codes used for the tutor while tutoring during the month.
        private void createSignTimeSheet(userInfo user, DateTime startD, DateTime endD, int budIndex, string budFilename, IDictionary<string, PdfFormField> coverFields)
        {
            if (budFilename != null || budFilename != "")
            {
                PdfFormField setVal;                
                PdfFormField coverVal;

                PdfDocument pdfTimeSheet = (user.userType == "D") ? new PdfDocument(new PdfReader(srcTimeSheetHourly), new PdfWriter(folderList[1] + budFilename)) :
                                                                    new PdfDocument(new PdfReader(srcTimeSheetStudent), new PdfWriter(folderList[1] + budFilename));

                //PdfDocument pdfTimeSheet = new PdfDocument(new PdfReader(srcTimeSheet), new PdfWriter(folderList[1] + budFilename));
                PdfAcroForm pdfForms = PdfAcroForm.GetAcroForm(pdfTimeSheet, false);
                IDictionary<string, PdfFormField> sheetFields = pdfForms.GetFormFields();

                sheetFields.TryGetValue("Employee Name", out setVal);
                setVal.SetValue(user.lastName + ", " + user.firstName);

                sheetFields.TryGetValue("Last 4 Digits SS#", out setVal);
                setVal.SetValue($"{user.lastSSN}");

                sheetFields.TryGetValue("Department / Site", out setVal);
                setVal.SetValue($"{user.department}");

                sheetFields.TryGetValue("Job Title", out setVal);
                setVal.SetValue($"{user.jobTitle}");

                sheetFields.TryGetValue("Employee Number", out setVal);
                setVal.SetValue(user.userID.ToString());                

                sheetFields.TryGetValue("MonthDay", out setVal);
                setVal.SetValue(startD.ToString("MM/dd"));

                sheetFields.TryGetValue("MonthDay_2", out setVal);
                setVal.SetValue(endD.ToString("MM/dd"));

                sheetFields.TryGetValue("Year", out setVal);
                setVal.SetValue(startD.ToString("yy"));

                coverFields.TryGetValue("PG" + budIndex + "_Budget Code 2", out coverVal);
                List<budgetCodes> budCode = budgetList.Where(x => x.budgetName == coverVal.GetValueAsString()).ToList();

                //Fills in the budget code
                if (budCode.Count == 1)
                {
                    sheetFields.TryGetValue("PG1_Budget Code 1", out setVal);
                    setVal.SetValue(budCode[0].budgetCode.ToString());

                    sheetFields.TryGetValue("PG1_Split Funded %1", out setVal);
                    setVal.SetValue("100");

                    sheetFields.TryGetValue("PG1_Budget Code 2", out setVal);
                    setVal.SetValue(budCode[0].budgetName.ToString());
                }
                else if (budCode.Count == 2)
                {
                    sheetFields.TryGetValue("PG1_Budget Code 1", out setVal);
                    setVal.SetValue(budCode[0].budgetCode.ToString());
                    sheetFields.TryGetValue("PG1_Split Funded %1", out setVal);
                    setVal.SetValue(budCode[0].budgetDescription.ToString());

                    sheetFields.TryGetValue("PG1_Budget Code 2", out setVal);
                    setVal.SetValue(budCode[1].budgetCode.ToString());
                    sheetFields.TryGetValue("PG1_Split Funded %1", out setVal);
                    setVal.SetValue(budCode[1].budgetDescription.ToString());

                    sheetFields.TryGetValue("PG1_Budget Code 3", out setVal);
                    setVal.SetValue(budCode[0].budgetName.ToString());
                }

                //Takes the hours in the Coversheets for each budget that isn't = 0 and fills
                //It in on the timesheet the person needs to sign.
                for (int i = 1; i <= 31; i++)
                {
                    coverFields.TryGetValue("PG" + budIndex + "_Hours" + i, out coverVal);
                    sheetFields.TryGetValue("PG1_Hours" + i, out setVal);
                    string temp = coverVal.GetValueAsString();

                    if (temp != null || temp != "")
                    {
                        setVal.SetValue(temp.ToString());
                    }

                    coverFields.TryGetValue("sumpage" + budIndex, out coverVal);
                    sheetFields.TryGetValue("PG1_Total Hours", out setVal);
                    setVal.SetValue(coverVal.GetValueAsString());
                }

                pdfTimeSheet.Close();
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------
        List<string> getFolderList(userInfo user)
        {
            List<string> folders = new List<string>();
            checkDic(user);
            folders.Add(Directory.GetCurrentDirectory());
            folders.Add(folders[0] + "\\users\\" + (user.lastName + ", " + user.firstName + " - " + user.userID) + "\\");

            return folders;
        }

        void checkDic(userInfo user)
        {
            List<string> dicNames = new List<string>();

            foreach (var dic in Directory.GetDirectories(Directory.GetCurrentDirectory() + "\\users"))
            {
                var temp = new DirectoryInfo(dic).Name;
                dicNames.Add(temp);
            }

            if (!dicNames.Contains(user.lastName + ", " + user.firstName + " - " + user.userID))
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + " \\users\\" + (user.lastName + ", " + user.firstName + " - " + user.userID));
        }

        string createPDFFileName(userInfo user, string budName, DateTime startD)
        {
            string pdfName = user.lastName + ", " + user.firstName + " - " + budName + " - " + startD.ToString("MMMM yyyy") + ".pdf";
            return pdfName;
        }

        //Calc totals for each budget sheet
        void calcTotals(userInfo user, DateTime startD, DateTime endD, IDictionary<string, PdfFormField> coverFields, PdfFormField toSet)
        {
            //Fill in the sums
            for (int i = 1; i <= 7; i++)
            {
                double totalSum = 0.0;
                for (int j = 1; j <= 31; j++)
                {
                    coverFields.TryGetValue("PG" + i + "_Hours" + j, out toSet);
                    var tempVal = toSet.GetValue();
                    if (tempVal != null)
                    {
                        totalSum += Convert.ToDouble(tempVal.ToString());
                    }
                }

                coverFields.TryGetValue("sumpage" + i, out toSet);
                toSet.SetValue(totalSum.ToString("F2"));
            }

            //Fill SumTotal field
            double total = 0.0;
            for (int i = 1; i <= 31; i++)
            {
                coverFields.TryGetValue("SumRow" + i, out toSet);
                var temp = toSet.GetValue();
                if (temp != null)
                {
                    total += Convert.ToDouble(temp.ToString());
                }
            }

            coverFields.TryGetValue("SumTotal", out toSet);
            toSet.SetValue(total.ToString("F2"));

            for (int i = 1; i <= 5; i++)
            {
                coverFields.TryGetValue("sumpage" + i, out toSet);
                string val = toSet.GetValueAsString();

                if (!(val == "" || val == "0.00"))
                {
                    coverFields.TryGetValue("PG" + i + "_Budget Code 2", out toSet);
                    string budFileName = toSet.GetValueAsString();

                    if (!(budFileName == null || budFileName == ""))
                    {
                        budFileName = createPDFFileName(user, budFileName, startD);
                        createSignTimeSheet(user, startD, endD, i, budFileName, coverFields);
                    }
                }
            }
        }

        public static IEnumerable<DateTime> AllDatesInMonth(int year, int month)
        {
            int days = DateTime.DaysInMonth(year, month);
            for (int day = 1; day <= days; day++)
            {
                yield return new DateTime(year, month, day);
            }
        }
    }
}