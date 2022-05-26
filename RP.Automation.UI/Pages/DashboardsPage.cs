using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RP.Automation.UI.BasePage;
using RP.Automation.UI.Extensions;
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
        private List<IWebElement> ResizeButtonsList =>
            WebDriver.FindElements(By.XPath(".//span[@class='react-resizable-handle react-resizable-handle-se']")).ToList();

        public override string BaseUrl => _userSettings.BaseUrl;
        public override string RelativePath => "/ui/#default_personal/dashboard";

        public override DashboardsPage VerifyPageLoaded()
        {
            _wait.Until(_ => AddNewDashboardButton.Displayed);
            return base.VerifyPageLoaded();
        }

        public DashboardsPage AddNewDashboard()
        {
            _wait.Until(driver => AddNewDashboardButton.Displayed);
            AddNewDashboardButton.JSClick(WebDriver);
            return this;
        }

        public DashboardsPage AddNewWidget()
        {
            _wait.Until(driver => AddNewWidgetButton.Displayed);
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

        public DashboardsPage ScrollToWidget(string name)
        {
            var widget = WidgetsList.Where(n => n.Text.StartsWith(name)).First();
            widget.ScrollTo(WebDriver);
            return this;
        }

        public DashboardsPage DragAndDropWidget(string name)
        {
            var widget = WidgetsList.Where(n => n.Text.StartsWith(name)).First();
            widget.DragAndDrop(WebDriver, 150, 150);
            return this;
        }

        public DashboardsPage ResizeWidget()
        {
            ResizeButtonsList[0].DragAndDrop(WebDriver, 300, 300);
            return this;
        }
    }
}
