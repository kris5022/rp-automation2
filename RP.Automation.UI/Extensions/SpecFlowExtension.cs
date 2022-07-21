using System;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace RP.Automation.UI.Extensions
{
    public static class SpecFlowExtension
    {
        private const string WebDriverKey = "WEBDRIVER";

        public static IWebDriver WebDriver(this ScenarioContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            if (!context.ContainsKey(WebDriverKey) || context[WebDriverKey] is not IWebDriver result)
                throw new NotFoundException("Web driver was not set in this context.");
            return result;
        }

        public static IWebDriver GoTo(this ScenarioContext context, string baseUrl,
            string relativeUrl)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            if (baseUrl == null) throw new ArgumentNullException(nameof(baseUrl));
            if (relativeUrl == null) throw new ArgumentNullException(nameof(relativeUrl));

            context.WebDriver().GoTo(baseUrl, relativeUrl);
            return context.WebDriver();
        }
    }
}
