using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM.pageObjects
{
    public class DashboardPage
    {

        private IWebDriver driver;
        public DashboardPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "welcome")]
        private IWebElement dashboardPage;

        public IWebElement validDashboardPage()
        {
            return dashboardPage;
        }

    }
}
