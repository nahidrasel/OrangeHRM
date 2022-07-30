using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OrangeHRM.PageObjects;
using OrangeHRM.utilities;
using System.Configuration;
using WebDriverManager.DriverConfigs.Impl;


namespace OrangeHRM.Tests
{
    public  class BaseTest
    {
        public ExtentReports extent;
        public ExtentTest reportTest;

        public Logger logger;
        public IWebDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            var reportPath = projectDirectory + "//External Reports/index.html";

            /*
             var DatedLog = $"Index_{DateTime.Now.ToString("yyyy-MM-dd_HH-mm")}";
             var filePath = Path.Combine(reportPath, DatedLog);
             reportPath = filePath + "/index.html";
            */

            var htmlReporter = new ExtentHtmlReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Host Name", "Local host");
            extent.AddSystemInfo("Environment", "Test");
            extent.AddSystemInfo("User Rights", "Admin");      
        }
        
        [SetUp]
        public void StartBrowser()
        {
            var testName = TestContext.CurrentContext.Test.Name;
            logger = new Logger(testName);
            reportTest = extent.CreateTest(testName);

            //Browser Configuration
            String browserName = ConfigurationManager.AppSettings["browser"];
            driver = InitialiseBrowser(browserName);

            LaunchSite("https://opensource-demo.orangehrmlive.com/");
            //move lauch site from basetest to other files maybe in page object model
        }

        private void LaunchSite(string testUrl, int waitSeconds = 5)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(waitSeconds);
            driver.Manage().Window.Maximize();
            driver.Url = testUrl;
        }

        public IWebDriver InitialiseBrowser(string browserName)
        {
            switch(browserName)
            {
                case "Firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    return new FirefoxDriver();

                case "Chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    return new ChromeDriver();

                case "Edge":
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    return  new EdgeDriver();

                default:
                    throw new InvalidOperationException($"Undefined browser name {browserName}");
            }
        }
        

        public static JsonReader GetDataParser()
        {
            return new JsonReader();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {

            extent.Flush();
        }

        [TearDown]
        public void AfterTest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;

            DateTime time = DateTime.Now;
            String fileName = "Screenshot_" + time.ToString("yyyy_MM_dd_HH_mm_ss") + ".png";
            var  screenshotSaveLocation = "C:/nahidpractice/OrangeHRM/OrangeHRM/External Reports/";
            if (status == TestStatus.Failed)
            {
                var bytes = CaptureScreenShot(driver, fileName);
                reportTest.Fail("Test failed", CaptureScreenShot(driver, fileName));
                reportTest.Log(Status.Fail, "test failed with logtrace" + stackTrace);
                Screenshot image = ((ITakesScreenshot)driver).GetScreenshot();
                image.SaveAsFile(screenshotSaveLocation+fileName);
            }
            else if (status == TestStatus.Passed)
            {
                reportTest.Pass("Test Passed", CaptureScreenShot(driver, fileName));
                Screenshot image = ((ITakesScreenshot)driver).GetScreenshot();
                image.SaveAsFile(screenshotSaveLocation+fileName);
            }
            driver.Quit();
        }

        public static MediaEntityModelProvider CaptureScreenShot(IWebDriver driver, String screenShotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            var screenshot = ts.GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, screenShotName).Build();
            //use hooks and cooks 
            //also add one time teardown
            //Serial the execution one by one like as give order in the setup
        }
    }
}
