using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RP.Automation.UI.BasePage;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RP.Automation.Tests.Pages
{
    public class DashboardsPage : BasePage<DashboardsPage>
    {
        private readonly UserSettings _userSettings;
        private readonly WebDriverWait _wait;

        public DashboardsPage(IWebDriver driver) : base(driver)
        {
            _userSettings = new UserSettings();
            _wait = new WebDriverWait(WebDriver, _userSettings.DefaultExplicitWaitTimeout);
        }

        private IWebElement AddNewDashboardButton =>
            WebDriver.FindElement(By.XPath(".//span[@class='ghostButton__text--eUa9T']"));
        private IWebElement AddNewWidgetButton =>
            WebDriver.FindElement(By.XPath(".//div[@class='dashboardItemPage__buttons-block---uDIb'][1]/button[1]"));
        private List<IWebElement> WidgetsList =>
            WebDriver.FindElements(By.XPath(".//div[@class='widgetHeader__widget-name-block--7fZoV']")).ToList();

        public override string BaseUrl => _userSettings.BaseUrl;
        public override string RelativePath => "/ui/#default_personal/dashboard";

        public override DashboardsPage VerifyPageLoaded()
        {
            _wait.Until(_ => AddNewDashboardButton.Displayed);
            return base.VerifyPageLoaded();
        }

        public DashboardsPage AddNewDashboard()
        {
            AddNewDashboardButton.Click();
            return this;
        }

        public DashboardsPage AddNewWidget()
        {
            AddNewWidgetButton.Click();
            return this;
        }

        public DashboardsPage VerifyAddedWidget(string name)
        {
            var nameList = new List<string>();
            foreach (var widget in WidgetsList)
            {
                var text = widget.Text;
                nameList.Add(text.Substring(0, text.Length - 4));
            }
            Assert.Contains(name, nameList);
            return this;
        }
    }
}
