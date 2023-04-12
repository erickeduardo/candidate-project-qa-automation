using Microsoft.Extensions.Configuration;
using TechTalk.SpecFlow;
using NUnit.Framework;
using ZoomAutomation.Pages;

namespace ZoomAutomation.Steps
{
    [Binding]
    public class ScheduleSteps
    {
        private readonly SchedulePage _schedulePage;

        public ScheduleSteps()
        {
            var basePath = System.AppContext.BaseDirectory;
            var configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");
            var configuration = configurationBuilder.Build();
            _schedulePage = new SchedulePage(configuration);
        }

        [Given(@"I am on the Schedule Page")]
        public void GivenIAmOnTheSchedulePage()
        {
            _schedulePage.Navigate();
        }

        [When(@"I select location as '(.*)'")]
        public void WhenISelectLocation(string location)
        {
            _schedulePage.SetLocation(location);
        }

        [When(@"I select service as '(.*)'")]
        public void WhenISelectService(string service)
        {
            _schedulePage.SetService(service);
        }

        [When(@"I select date as '(.*)'")]
        public void WhenISelectDate(string date)
        {
            _schedulePage.SetDate(date);
        }

        [When(@"I click search button")]
        public void WhenIClickSearchButton()
        {
            _schedulePage.ClickSearchButton();
        }

        [When(@"I click Show More button")]
        public void WhenIClickShowMoreButton()
        {
            _schedulePage.ClickShowMoreButton();
        }

        [Then(@"I should see page title '(.*)'")]
        public void ThenIShouldSeePageTitle(string expectedTitle)
        {
            string actualTitle = _schedulePage.GetTitle();
            Assert.AreEqual(expectedTitle, actualTitle);
        }

        [Then(@"I should see '(.*)' header")]
        public void ThenIShouldSeeHeader(string expectedHeader)
        {
            string actualHeader = _schedulePage.GetHeader();
            Assert.IsTrue(actualHeader.Contains(expectedHeader), $"Expected header '{expectedHeader}' was not found on the page.");
        }

        [Then(@"I should see '(.*)' hour is available")]
        public void ThenIShouldSeeHourIsAvailable(string hour)
        {
            bool isHourAvailable = _schedulePage.IsHourAvailable(hour);
            Assert.IsTrue(isHourAvailable, $"{hour} is not available.");
        }

        [Then(@"I should see Virtual Clinic button exists")]
        public void ThenIShouldSeeVirtualClinicButtonExists()
        {
            bool isVirtualClinicButtonExists = _schedulePage.VirtualClinicBoxExists();
            Assert.IsTrue(isVirtualClinicButtonExists, "Virtual Clinic button does not exist.");
        }

        [Then(@"I should see Virtual Video button exists")]
        public void ThenIShouldSeeVirtualVideoButtonExists()
        {
            bool isVirtualVideoButtonExists = _schedulePage.VirtualVideoBoxExists();
            Assert.IsTrue(isVirtualVideoButtonExists, "Virtual Video button does not exist.");
        }

        [Then(@"I should see '(.*)' clinics available")]
        public void ThenIShouldSeeClinicsAvailable(int expectedCount)
        {
            int actualCount = _schedulePage.CountClinicLocationRows();
            Assert.AreEqual(expectedCount, actualCount, $"Expected {expectedCount} clinics but found {actualCount}.");
        }

        [When(@"I click the '(.*)' provider on the list")]
        public void WhenIClickTheProviderOnTheList(string providerId)
        {
            //link-ServiceLine.1.Clinic.1.Provider.1.ProviderName
            string selector = $"[data-testid='link-ServiceLine.1.Clinic.{providerId}.Provider.1.ProviderName']";
            _schedulePage.ClickProviderByCssSelector(selector);
        }

        [Then(@"I should see the url changed to '\/provider\/'")]
        public void ThenIShouldSeeUrlChangedToProvider()
        {
            _schedulePage.WaitForUrlContains("/provider/");
            Assert.IsTrue(_schedulePage.GetUrl().Contains("/provider/"), "URL does not contain '/provider/'.");
        }

    }
}
