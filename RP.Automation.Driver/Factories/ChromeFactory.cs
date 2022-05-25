using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace RP.Automation.Driver.Factories
{
    public class ChromeFactory : IWebDriverFactory
    {
        public Type DriverType => typeof(ChromeDriver);
        private ChromeDriverService _service;

        public virtual bool IsMatch(string driverName)
        {
            return driverName?.Equals("chrome", StringComparison.InvariantCultureIgnoreCase) ?? false;
        }

        public IWebDriver Create()
        {
            _service = ChromeDriverService.CreateDefaultService();
            var driver = new ChromeDriver(_service);
            WebDriverProcessRegistry.Current.Add(driver, _service.ProcessId);
            return driver; 
        }

        public void Destroy(IWebDriver webDriver)
        {
            WebDriverProcessRegistry.Current.Remove(webDriver, _service.ProcessId);
        }
    }
}
