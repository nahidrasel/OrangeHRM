using NUnit.Framework;
using OrangeHRM.utilities;
using OrangeHRM.pageObjects;

namespace OrangeHRM
{
    public class LoginTest : Base
    {
        //UserData admin = TestUserProvider.TestUsers.AdminUser;

        [Test, TestCaseSource("AddTestDataConfig")]
        //[TestCase("Admin","admin123")]
        public void Login(String username,string password)
        {

            //Log.Info("Username Input");
            LoginPage loginpage = new(GetDriver());
            Assert.IsTrue(loginpage.LoginWebPage().Displayed, "ORM Website");
            DashboardPage dashboardPage = loginpage.ValidLogin(username, password);

            //Log.Info("click on the login button and verify dashboard page");
            Assert.IsTrue(dashboardPage.validDashboardPage().Displayed, "Dashboard is displayed");

        }
        public static IEnumerable <TestCaseData> AddTestDataConfig()
        {
            yield return new TestCaseData(GetDataParser().extractData("username"), GetDataParser().extractData("password"));
            yield return new TestCaseData(GetDataParser().extractData("username_invalid"), GetDataParser().extractData("password"));
        }
    }
}
    
