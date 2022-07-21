using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;

namespace RP.Automation.UI.Extensions
{
    public static class WebElementExtension
    {
        private static readonly TimeSpan DefaultTimeout = new(0, 0, 5);

        public static IWebElement ClearInput(this IWebElement element)
        {
            if (element == null) return null;
            element.Clear();
            return element;
        }

        public static IWebElement ScrollToElement(this IWebElement element, IWebDriver driver)
        {
            const string script =
                "var viewPortHeight = Math.max(document.documentElement.clientHeight, window.innerHeight || 0);"
                + "var elementTop = arguments[0].getBoundingClientRect().top;"
                + "window.scrollBy(0, elementTop-(viewPortHeight/2));";
            script.ExecuteScript(driver, element);
            return element;
        }

        public static IWebElement HoverOver(this IWebElement element, IWebDriver driver)
        {
            new Actions(driver).MoveToElement(element).Build().Perform();
            return element;
        }

        public static IWebElement DragAndDrop(this IWebElement element, IWebDriver driver, int x, int y)
        {
            new Actions(driver).DragAndDropToOffset(element, x, y).Build().Perform();
            return element;
        }

        public static IWebElement JSClick(this IWebElement element, IWebDriver driver)
        {
            const string script = "var elem=arguments[0]; setTimeout(function() {elem.click();}, 100)";
            script.ExecuteScript(driver, element);
            return element;
        }

        public static IWebElement ScrollTo(this IWebElement element, IWebDriver driver)
        {
            const string script = "arguments[0].scrollIntoView(true); ";
            script.ExecuteScript(driver, element);
            return element;
        }

        public static object ExecuteScript(this string script, IWebDriver driver, IWebElement element = null)
        {
            var executor = (IJavaScriptExecutor)driver;
            return element == null ? executor.ExecuteScript(script) : executor.ExecuteScript(script, element);
        }
    }
}
