using HtmlElements.Elements;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace RP.Automation.UI.Dialogs
{
    public class Sidebar2 : HtmlPage
    {
        public Sidebar2(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.XPath, Using = ".//a[@href='#default_personal/filters']")]
        public HtmlElement DashboardsButton { get; private set; }

        [FindsBy(How = How.XPath, Using = ".//a[@href='#default_personal/filters']")]
        public HtmlElement FiltersButton { get; private set; }

        public Sidebar2 OpenFilters()
        {
            FiltersButton.Click();
            return this;
        }

        public Sidebar2 OpenDashboards()
        {
            DashboardsButton.Click();
            return this;
        }
    }
}
