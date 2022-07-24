using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM.PageObjects
{
    public class DashboardPage:BasePage
    {
        public DashboardPage(IWebDriver driver) : base(driver)
        {
        }
        private IWebElement DashboardPageLogo => Driver.FindElement(By.Id("welcome"));

        /*
        [FindsBy(How = How.Id, Using = "welcome")]
        private readonly IWebElement dashboardPage;

        public DashboardPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        */
        public IWebElement ValidDashboardPage() => DashboardPageLogo;

    }
}
