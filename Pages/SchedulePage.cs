using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Microsoft.Extensions.Configuration;
using ZoomAutomation.Drivers;
using System;
using System.Linq;

namespace ZoomAutomation.Pages
{
    [Binding]
    public class SchedulePage
    {
        private readonly IWebDriver _driver;
        private readonly IConfiguration _configuration;

        public SchedulePage(IConfiguration configuration)
        {
            _configuration = configuration;
            _driver = Driver.GetDriver();
        }

        private IWebElement pageTitle => _driver.FindElement(By.TagName("title"));
        private IWebElement locationSelector => _driver.FindElement(By.CssSelector("[data-testid='quickSelector.locationSelector']"));
        private IWebElement serviceSelector => _driver.FindElement(By.CssSelector("[data-testid='quickSelector.serviceSelector']"));
        private IWebElement dateSelector => _driver.FindElement(By.CssSelector("[data-testid='quickSelector.dateSelector']"));
        private IWebElement searchButton => _driver.FindElement(By.CssSelector("[data-testid='button-quickSelector.searchButton']"));
        private IWebElement virtualClinicBoxButton => _driver.FindElement(By.CssSelector("[data-testid='virtualClinicBox']"));
        private IWebElement virtualVideoBoxButton => _driver.FindElement(By.CssSelector("[data-testid='virtualVideoBox']"));
        private IWebElement showMoreButton => _driver.FindElement(By.CssSelector("[data-testid='text-Show More']"));

        public void Navigate()
        {
            _driver.Navigate().GoToUrl(_configuration["SchedulePageUrl"]);
            WaitForElementByTestId("virtualClinicBox");
        }

        private void WaitForElementByTestId(string testId)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector($"[data-testid='{testId}']")));
        }

        private void WaitForProgressbarToDisappear()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            wait.Until(driver => !driver.FindElements(By.CssSelector("[role='progressbar']")).Any());
        }


        public void SetLocation(string location)
        {
            WaitForClickableElement(locationSelector);
            locationSelector.Click();
            ClickDivByText(location);
        }

        public void SetService(string service)
        {
            WaitForClickableElement(serviceSelector);
            serviceSelector.Click();
            ClickDivByText(service);
        }

        public void SetDate(string date)
        {
            WaitForClickableElement(dateSelector);
            WaitForDivWithSvgForChooseDate();
            WaitForDivByText("Choose Date");
            dateSelector.Click();
            ClickDivByText(date);
        }

        public void ClickSearchButton()
        {
            WaitForClickableElement(searchButton);
            searchButton.Click();
            WaitForElementByTestId("ServiceLine.1");
        }

        public bool IsHourAvailable(string hour)
        {
            var timeElements = _driver.FindElements(By.TagName("div"));
            foreach (var time in timeElements)
            {
                if (time.Text.Contains(hour))
                {
                    return true;
                }
            }
            return false;
        }


        public string GetTitle()
        {
            return _driver.Title;
        }

        public string GetUrl()
        {
            return _driver.Url;
        }

        public string GetHeader()
        {
            return _driver.FindElement(By.TagName("h1")).Text;
        }

        public void WaitForDivWithSvgForChooseDate()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            var div = _driver.FindElement(By.CssSelector("[data-testid='quickSelector.date.popover']"));
            wait.Until(driver => div.FindElement(By.TagName("svg")));
        }

        public void WaitForDivByText(string text)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            var divElements = _driver.FindElements(By.TagName("div"));
            foreach (var div in divElements)
            {
                if (div.Text.Trim().Equals(text))
                {
                    wait.Until(ExpectedConditions.ElementToBeClickable(div));
                    break;
                }
            }
        }

        public void ClickShowMoreButton()
        {
            showMoreButton.Click();
            WaitForProgressbarToDisappear();
        }

        public int CountClinicLocationRows()
        {
            var elements = _driver.FindElements(By.CssSelector("[data-testid^='ServiceLine.1.Clinic.'][data-testid$='.LocationRow']"));
            return elements.Count;
        }

        public bool VirtualClinicBoxExists()
        {
            return virtualClinicBoxButton.Displayed;
        }

        public bool VirtualVideoBoxExists()
        {
            return virtualVideoBoxButton.Displayed;
        }

        public void ClickDivByText(string text)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            var divElements = wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.TagName("div")));
            foreach (var div in divElements)
            {
                if (div.Text.Trim().Equals(text))
                {
                    div.Click();
                    break;
                }
            }
        }

        public void ClickProviderByCssSelector(string selector)
        {
            var div = _driver.FindElement(By.CssSelector(selector));
            div.Click();
        }

        public void WaitForClickableElement(IWebElement element)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }

        public void WaitForUrlContains(string partialUrl)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.UrlContains(partialUrl));
        }
    }
}
