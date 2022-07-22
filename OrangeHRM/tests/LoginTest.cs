using NUnit.Framework;
using OrangeHRM.utilities;
using OrangeHRM.pageObjects;
using OrangeHRM.utilities.mylogger;
using OpenQA.Selenium;

namespace OrangeHRM
{
    public class LoginTest : Base
    {
        
        [Test, TestCaseSource("AddTestDataConfig")]
        //[TestCase("Admin","admin123")]
        public void Login(string username,string password)
        {
            //var logger = new SimpleLogger();
            var logger = new Logger();
            logger.Log("Username and password Input");

            LoginPage loginpage = new(GetDriver());

            logger.Log("Login Page Validation");
            Assert.IsTrue(loginpage.LoginWebPage().Displayed, "ORM Website");
            DashboardPage dashboardPage = loginpage.ValidLogin(username, password);

            logger.Log("Dashboard page Validation");
            Assert.IsTrue(dashboardPage.validDashboardPage().Displayed, "Dashboard is displayed");

        }
        public static IEnumerable <TestCaseData> AddTestDataConfig()
        {
            yield return new TestCaseData(GetDataParser().extractData("username"), GetDataParser().extractData("password"));
            yield return new TestCaseData(GetDataParser().extractData("username_invalid"), GetDataParser().extractData("password"));
        }
    }
}
    
