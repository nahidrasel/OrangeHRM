using NUnit.Framework;
using OrangeHRM.PageObjects;

namespace OrangeHRM.Tests
{
    public class InvalidLoginTest : BaseTest
    {
        private LoginPage _loginPage;

        [Test, TestCaseSource("AddTestDataConfig")]
        //[TestCase("Admin","admin123")]
        public void Login(string username,string password)
        {
            _loginPage = new LoginPage(driver) ;
            Assert.IsTrue(_loginPage.LoginWebPage().Displayed, "OrangeHRM Website Page is not visible");
            _loginPage.Login(username, password,logger);
            Assert.IsTrue(_loginPage.LoginError().Displayed, "Invalid Credentials is not displayed");
        }
        public static IEnumerable <TestCaseData> AddTestDataConfig()
        {
            yield return new TestCaseData(GetDataParser().ExtractData("username_invalid"), GetDataParser().ExtractData("password"));
        }
    }
}
