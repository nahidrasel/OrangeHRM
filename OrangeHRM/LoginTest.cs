using NUnit.Framework;
using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools;

namespace OrangeHRM
{
    public class LoginTest:BaseTest
    {
        [Test]
        public void Login()
        {
            //start the browser
            
            // Log.info("Start the Driver");

            //Go to Url
            string Url = driver.Url = "https://opensource-demo.orangehrmlive.com/";
            Assert.IsTrue(driver.FindElement(By.XPath("//*[@id='divLogo']/img")).Displayed, "ORM Website");
            //Username input
            driver.FindElement(By.Id("txtUsername")).SendKeys("Admin");
            Thread.Sleep(1000);
            //Password input
            driver.FindElement(By.Id("txtPassword")).SendKeys("admin123");
            Thread.Sleep(1000);

            //click on the login button and verify dashboard page
            driver.FindElement(By.Id("btnLogin")).Click();
            Assert.IsTrue(driver.FindElement(By.Id("welcome")).Displayed, "Dashboard is displayed");

            QuitDriver();
        }

    }
}
