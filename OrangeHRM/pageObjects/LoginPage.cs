﻿
using OpenQA.Selenium;
using OrangeHRM.PageObjects;

namespace OrangeHRM.PageObjects
{
    public class LoginPage:BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }
        private IWebElement Username => Driver.FindElement(By.Id("txtUsername"));
        private IWebElement Password => Driver.FindElement(By.XPath("//input[@id='txtPassword']"));
        private IWebElement LoginButton => Driver.FindElement(By.CssSelector("#btnLogin"));
        private IWebElement LoginPageLogo => Driver.FindElement(By.XPath("//input[@id='txtPassword']"));
        
        //make dynamic xpath

        public void Login(string userId,string pass, Logger logger)
        {
            Username.SendKeys(userId);
            Password.SendKeys(pass);
            LoginButton.Click();
            logger.Info("[INFO] User logged in.");
            //this dashboard page only reside with its page objcet
            // login page will have only login pages functionality.
        }
        
        public IWebElement LoginWebPage() => LoginPageLogo;
    }
}
