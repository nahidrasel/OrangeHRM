using OpenQA.Selenium;

namespace OrangeHRM.PageObjects
{
    public class DashboardPage:BasePage
    {
        public DashboardPage(IWebDriver driver) : base(driver)
        {
        }
        private IWebElement DashboardPageLogo => Driver.FindElement(By.Id("welcome"));
        private IWebElement WelcomeMenuButton => Driver.FindElement(By.XPath("//a[@id='welcome']"));
        private IWebElement LogoutButton => Driver.FindElement(By.LinkText("Logout"));
        /*
        [FindsBy(How = How.Id, Using = "welcome")]
        private readonly IWebElement dashboardPage;

        public DashboardPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        */

        public void Logout(Logger logger)
        {
            WelcomeMenuButton.Click();
            LogoutButton.Click();
            logger.Info("[INFO] User logged out successfully.");
        }

        public IWebElement ValidDashboardPage() => DashboardPageLogo;



    }
}
