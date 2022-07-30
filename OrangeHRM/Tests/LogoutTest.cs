using NUnit.Framework;
using OrangeHRM.PageObjects;

namespace OrangeHRM.Tests
{
        public class LogoutTest : BaseTest
        {
        public LoginPage LoginPage { get; private set; }
        public DashboardPage DashboardPage { get; private set; } 

       [Test, TestCaseSource("AddTestDataConfig")]
            public void LoginAndLogout(string username, string password)
            {
                LoginPage = new LoginPage(driver);
                Assert.IsTrue(LoginPage.LoginWebPage().Displayed, "OrangeHRM Website Page is not visible");
                LoginPage.Login(username, password, logger);
                DashboardPage = new DashboardPage(driver);
                Assert.IsTrue(DashboardPage.ValidDashboardPage().Displayed, "Dashboard is not displayed");
                DashboardPage.Logout(logger);
                Assert.IsTrue(LoginPage.LoginWebPage().Displayed, "OrangeHRM Website Page is not visible");
        }
            public static IEnumerable<TestCaseData> AddTestDataConfig()
            {
                yield return new TestCaseData(GetDataParser().ExtractData("username"), GetDataParser().ExtractData("password"));
            }
        }
    }
