# Test Cases

![ZoomCare Logo](https://avatars0.githubusercontent.com/u/48925141?s=150)

- Check if Clinic Care appointment is available at specific hour
- Validate I can see more options after search
- Validate Clinic Care appointment is available
- Validate Video Care appointment is available
- Validate provider page


# Automation Instructions
This project is an automation project using Selenium WebDriver and SpecFlow in .NET 6.0.

## Installation
To use this project, you must have .NET 6.0 and Chrome browser installed. This project is tested and supported only on Windows.

After cloning the project, run the following commands:
```bash
dotnet restore
dotnet build
```

Please note that the chromedriver version should match the Chrome browser version installed on your machine.

## Dependencies
This project uses the following dependencies:

- DotNetSeleniumExtras.WaitHelpers 3.11.0
- FluentAssertions 6.10.0
- Microsoft.Extensions.Configuration 5.0.0
- Microsoft.Extensions.Configuration.Json 5.0.0
- Microsoft.NET.Test.Sdk 17.5.0
- NUnit 3.13.3
- NUnit3TestAdapter 4.4.2
- Selenium.WebDriver 4.8.2
- Selenium.WebDriver.ChromeDriver 112.0.5615.49
- SpecFlow.NUnit 3.9.74
- SpecFlow.Plus.LivingDocPlugin 3.9.*

## Usage
This project is a starting point for building a fast test automation Framework using Selenium WebDriver and SpecFlow.
After running restore and build, just run:
```bash
dotnet run
```

## Support
This project is tested and supported only on Windows. There is no support for Mono or Linux.


## Comments
Video run:

[![IMAGE ALT TEXT](http://img.youtube.com/vi/JgEzIXbzO_I/0.jpg)](http://www.youtube.com/watch?v=JgEzIXbzO_I "SpecFlow run (Zoom)")

- The test run result is:
```bash
Passed!  - Failed:     0, Passed:     8, Skipped:     0, Total:     8, Duration: 3 m 37 s - ZoomAutomation.dll (net6.0)
```
- In the video it look like it freezes when testing the "Show More" button, the reason is because I didn't scrolled the elements into view (it felt unnecessary);
- I Decided to close the browser after each scenario run because just going back to the home page kept the options selected;
- The last button for the date picker loads different so there is a few workarounds for it;
- Same for the 'Show More', in this case I decided to wait for the loader disappear;
- I decided to emulate an end to end scenario using examples table, today (11/04/2023) it works, tomorrow it will break because of the dates and the feature file might need to be updated. It is possible to work using more generic dates (based on todays date);
