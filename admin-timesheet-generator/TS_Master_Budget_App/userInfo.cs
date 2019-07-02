namespace TS_Master_Budget_App
{
    public struct userInfo
    {
        public int userID;
        public string lastName;
        public string firstName { get; set; }
        public string userEmail;
        public string userPhoneNum;
        public bool accountActive;
        public int premissionLvL;
        public string userType;
        public string userTitle;        
        public string department;
        public string lastSSN;
        public string jobTitle;
        public double payRate;
        public userBudget budget;

        public string fullnameWComma()
        {
            return lastName + ", " + firstName;
        }
        public int returnUserID(string fullName)
        {
            string[] splitName = fullName.Split(',');

            if (lastName == splitName[0] && firstName == splitName[1])
                return userID;

            return 0;
        }
    };
    public struct budgetCodes
    {
        public string budgetName;
        public string budgetCode;
        public string budgetDescription;
        public string district;
    };
    public struct loginUser
    {
        public int userID;
        public int premissionLvL;
        public string userTitle;
        public bool isLogin;
    };
    public struct userBudget
    {
        public int userId;
        public double startMoney;
        public double currentMoney;
        public double startHR;
        public double currentHR;
    };

    public enum districtCode { SE, D }
    public enum workerType { SE, D}
}