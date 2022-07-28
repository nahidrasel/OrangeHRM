using NUnit.Framework;
using OrangeHRM.PageObjects;

namespace OrangeHRM.Tests
{
    public class ValidLoginTest : BaseTest
    {
        public LoginPage LoginPage { get; private set; }

        [Test, TestCaseSource("AddTestDataConfig")]
        //[TestCase("Admin","admin123")]
        public void Login(string username,string password)
        {
            LoginPage = new LoginPage(driver) ;
            Assert.IsTrue(LoginPage.LoginWebPage().Displayed, "OrangeHRM Website Page is not visible");
            LoginPage.Login(username, password,logger);
            Assert.IsTrue(new DashboardPage(driver).ValidDashboardPage().Displayed, "Dashboard is not displayed");
        }
        public static IEnumerable <TestCaseData> AddTestDataConfig()
        {
            yield return new TestCaseData(GetDataParser().ExtractData("username"), GetDataParser().ExtractData("password"));

        }
    }
}