using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;


namespace OrangeHRM.pageObjects
{
    public class LoginPage
    {
        private readonly IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver,this);
        }

        [FindsBy(How = How.Id, Using = "txtUsername")]
        private readonly IWebElement username;

        [FindsBy(How = How.Id, Using = "txtPassword")]
        private readonly IWebElement password;

        [FindsBy(How = How.Id, Using = "btnLogin")]
        private readonly IWebElement loginbutton;

        [FindsBy(How = How.XPath, Using = "//*[@id='divLogo']/img")]
        private readonly IWebElement loginpagelogo;

        public DashboardPage ValidLogin(string userId,string pass)
        {
            username.SendKeys(userId);
            password.SendKeys(pass);
            loginbutton.Click();
            return new DashboardPage(driver);
        }
        public IWebElement LoginWebPage()
        {
            return loginpagelogo;
        }

        public IWebElement GetUserName()
        {
            return username;
        }
        public IWebElement GetPassword()
        {
            return password;
        }
        public IWebElement LoginButton()
        {
            return loginbutton;
        }
    }
}
