using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;

namespace RP.Automation.Driver.Factories
{
    public class FirefoxFactory : IWebDriverFactory
    {
        public Type DriverType => typeof(FirefoxDriver);
        private FirefoxDriverService _service;

        public virtual bool IsMatch(string driverName)
        {
            return driverName?.Equals("firefox", StringComparison.InvariantCultureIgnoreCase) ?? false;
        }

        public IWebDriver Create()
        {
            _service = FirefoxDriverService.CreateDefaultService();
            var driver = new FirefoxDriver(_service);
            WebDriverProcessRegistry.Current.Add(driver, _service.ProcessId);
            return driver;
        }

        public void Destroy(IWebDriver webDriver)
        {
            WebDriverProcessRegistry.Current.Remove(webDriver, _service.ProcessId);
        }
    }
}
