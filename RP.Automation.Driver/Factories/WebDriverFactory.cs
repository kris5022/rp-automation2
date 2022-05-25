using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RP.Automation.Driver.Factories
{
    public static class WebDriverFactory
    {
        private static readonly IList<IWebDriverFactory> Factories =
            new List<IWebDriverFactory>
            {
                new ChromeFactory(),
                new FirefoxFactory()
            };

        public static IWebDriver Create(string driverName)
        {
            var factory = Factories.FirstOrDefault(f => f.IsMatch(driverName));
            return factory.Create();
        }

        public static void TerminateWebDriver(IWebDriver webDriver)
        {
            var factory = Factories.FirstOrDefault(f => f.DriverType == webDriver.GetType());
            try
            {
                webDriver.Quit();
                webDriver.Dispose();
            }
            catch (Exception)
            {
                factory.Destroy(webDriver);
            }
        }
    }
}
