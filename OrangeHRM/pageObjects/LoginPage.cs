using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;


namespace OrangeHRM.pageObjects
{
    public class LoginPage
    {
        private IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver,this);
        }

        [FindsBy(How = How.Id, Using = "txtUsername")]
        private IWebElement username;

        [FindsBy(How = How.Id, Using = "txtPassword")]
        private IWebElement password;

        [FindsBy(How = How.Id, Using = "btnLogin")]
        private IWebElement loginbutton;

        [FindsBy(How = How.XPath, Using = "//*[@id='divLogo']/img")]
        private IWebElement loginpagelogo;

        public DashboardPage validLogin(string userId,string pass)
        {
            username.SendKeys(userId);
            password.SendKeys(pass);
            loginbutton.Click();
            return new DashboardPage(driver);
        }
        public IWebElement loginWebPage()
        {
            return loginpagelogo;
        }

        public IWebElement getUserName()
        {
            return username;
        }
        public IWebElement getPassword()
        {
            return password;
        }
        public IWebElement loginButton()
        {
            return loginbutton;
        }
    }
}
