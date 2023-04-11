using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using System;

namespace ZoomAutomation.Drivers
{
    [Binding]
    public class Driver
    {
        private static IWebDriver _driver;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");
            _driver = new ChromeDriver(options);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            _driver?.Quit();
        }

        public static IWebDriver GetDriver()
        {
            return _driver;
        }
    }
}
