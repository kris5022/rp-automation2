using OpenQA.Selenium;
using RP.Automation.UI.BasePage;
using System;

namespace RP.Automation.UI.Extensions
{
    public static class WebDriverExtension
    {
        public static IWebDriver GoTo(this IWebDriver driver, string baseUrl,
            string relativeUrl)
        {
            var baseUri = new Uri(baseUrl);
            var uri = new Uri(baseUri, relativeUrl);
            driver.Manage().Window.Maximize();
            driver.Navigate()?.GoToUrl(uri);
            return driver;
        }

        public static T VerifyPage<T>(this IWebDriver driver) where T : BasePage<T>
        {
            return driver.InitPage<T>()
                .VerifyPageUrl()
                .VerifyPageLoaded();
        }

        public static T InitPage<T>(this IWebDriver driver) where T : BasePage<T>
        {
            var constructorInfo = typeof(T).GetConstructor(new[]{typeof(IWebDriver)});
            return (T)constructorInfo.Invoke(new object[] { driver });
        }
    }
}
