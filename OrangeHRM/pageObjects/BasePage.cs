using OpenQA.Selenium;

namespace OrangeHRM.PageObjects
{
    public class BasePage
    {
        protected IWebDriver Driver;

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public Logger logger;
    }
}
