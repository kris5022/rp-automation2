using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RP.Automation.Tests;
using RP.Automation.UI.BasePage;

namespace RP.Automation.UI.Dialogs
{
    public class Sidebar : BasePage<Sidebar>
    {
        private readonly UserSettings _userSettings;

        private readonly WebDriverWait _wait;

        public Sidebar(IWebDriver driver) : base(driver)
        {
            _userSettings = new UserSettings();
            _wait = new WebDriverWait(WebDriver, _userSettings.DefaultExplicitWaitTimeout);
        }

        private IWebElement DashboardsButton =>
            WebDriver.FindElement(By.XPath(".//a[@href='#default_personal/filters']"));
        private IWebElement FiltersButton =>
            WebDriver.FindElement(By.XPath(".//a[@href='#default_personal/filters']"));
        private IWebElement LaunchesButton =>
            WebDriver.FindElement(By.XPath(".//a[@href='#default_personal/launches']"));

        public override string BaseUrl => _userSettings.BaseUrl;
        public override string RelativePath => "/ui/#default_personal";

        public override Sidebar VerifyPageLoaded()
        {
            _wait.Until(_ => FiltersButton.Displayed);
            return base.VerifyPageLoaded();
        }

        public Sidebar OpenFilters()
        {
            FiltersButton.Click();
            return this;
        }

        public Sidebar OpenDashboards()
        {
            DashboardsButton.Click();
            return this;
        }

        public Sidebar OpenLaunches()
        {
            LaunchesButton.Click();
            return this;
        }
    }
}
