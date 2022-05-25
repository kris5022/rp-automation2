using OpenQA.Selenium;
using System;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace RP.Automation.Driver.Factories
{
    internal class WebDriverProcessRegistry
    {
        private WebDriverProcessRegistry()
        {
            DriverProcesses = new ConcurrentDictionary<IWebDriver, int>();
        }

        private ConcurrentDictionary<IWebDriver, int> DriverProcesses { get; }

        public static WebDriverProcessRegistry Current => new WebDriverProcessRegistry();

        public void Add(IWebDriver webDriver, int processId)
        {
            DriverProcesses.TryAdd(webDriver, processId);
        }

        public void Remove(IWebDriver webDriver, int processId)
        {
            if (!DriverProcesses.TryRemove(webDriver, out var webDriverInfo)) return;
            ManageExecution(() =>
            {
                var process = Process.GetProcessById(processId);
                process.Kill();
            });
        }

        private static void ManageExecution(Action action)
        {
            action?.Invoke();
        }
    }
}
