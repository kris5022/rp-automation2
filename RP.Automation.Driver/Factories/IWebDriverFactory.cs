using OpenQA.Selenium;
using System;

namespace RP.Automation.Driver.Factories
{
    public interface IWebDriverFactory
    {
        Type DriverType { get; }

        bool IsMatch(string driverName);

        IWebDriver Create();

        void Destroy(IWebDriver webDriver);
    }
}
