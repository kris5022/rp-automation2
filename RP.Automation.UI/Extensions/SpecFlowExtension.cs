using System;
using OpenQA.Selenium;
//using Pmi.Web.Ui.Framework.Factories;
//using Pmi.Web.Ui.Framework.Page;
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

        //public static void SetWebDriver(this ScenarioContext context, IWebDriver driver)
        //{
        //    if (context == null) throw new ArgumentNullException(nameof(context));
        //    if (context.ContainsKey(WebDriverKey))
        //    {
        //        var old = context[WebDriverKey] as IWebDriver;
        //        context.Remove(WebDriverKey);
        //        Dispose(old);
        //    }

        //    if (driver != null) context.Add(WebDriverKey, driver);
        //}

        //public static void TerminateWebDriver(this ScenarioContext context)
        //{
        //    if (context == null) throw new ArgumentNullException(nameof(context));
        //    WebDriverFactory.TerminateWebDriver(WebDriver(context));
        //    context.SetWebDriver(null);
        //}

        public static IWebDriver GoTo(this ScenarioContext context, string baseUrl,
            string relativeUrl)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            if (baseUrl == null) throw new ArgumentNullException(nameof(baseUrl));
            if (relativeUrl == null) throw new ArgumentNullException(nameof(relativeUrl));

            context.WebDriver().GoTo(baseUrl, relativeUrl);
            return context.WebDriver();
        }

        //public static T InitPage<T>(this ScenarioContext context) where T : BasePage<T>
        //{
        //    if (context == null) throw new ArgumentNullException(nameof(context));
        //    return context.WebDriver().InitPage<T>();
        //}

        //public static T VerifyPage<T>(this ScenarioContext context) where T : BasePage<T>
        //{
        //    if (context == null) throw new ArgumentNullException(nameof(context));
        //    return context.WebDriver().VerifyPage<T>();
        //}

        //private static void Dispose(IWebDriver webDriver)
        //{
        //    if (webDriver == null) return;
        //    using (webDriver)
        //    {
        //        WebDriverFactory.TerminateWebDriver(webDriver);
        //    }
        //}
    }
}
