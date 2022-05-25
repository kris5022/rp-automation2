using OpenQA.Selenium;
using RP.Automation.Driver.Factories;
using RP.Automation.Tests;
using System;

namespace RP.Automation.UI.Fixtures
{
    public class FiltersFixture : IDisposable
    {
        //private IWebDriver _driver;
        private readonly UserSettings _userSettings;

        public FiltersFixture()
        {
            _userSettings = new UserSettings();
        }

        public void Dispose()
        {
            //try
            //{
            //    _driver.Quit();
            //    _driver.Dispose();
            //}
            //catch (Exception)
            //{
            //    WebDriverFactory.TerminateWebDriver(_driver);
            //}
        }
    }
}
