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

    }
}
