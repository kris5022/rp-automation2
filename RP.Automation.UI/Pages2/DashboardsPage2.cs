using HtmlElements.Elements;
using OpenQA.Selenium;
using RP.Automation.UI.Extensions;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RP.Automation.UI.Pages2
{
    public class DashboardsPage2 : HtmlPage
    {
        private readonly IWebDriver _driver;

        public DashboardsPage2(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        [FindsBy(How = How.XPath, Using = ".//span[@class='ghostButton__text--eUa9T']")]
        public HtmlElement AddNewDashboardButton { get; private set; }

        [FindsBy(How = How.XPath, Using = ".//div[@class='dashboardItemPage__buttons-block---uDIb'][1]/button[1]")]
        public HtmlElement AddNewWidgetButton { get; private set; }

        [FindsBy(How = How.XPath, Using = ".//div[@class='widgetHeader__widget-name-block--7fZoV']")]
        public List<HtmlElement> WidgetsList { get; private set; }
        [FindsBy(How = How.XPath, Using = ".//span[@class='react-resizable-handle react-resizable-handle-se']")]
        public List<HtmlElement> ResizeButtonsList { get; private set; }


        public DashboardsPage2 AddNewDashboard()
        {
            AddNewDashboardButton.JSClick(_driver);
            return this;
        }

        public DashboardsPage2 AddNewWidget()
        {
            AddNewWidgetButton.Click();
            return this;
        }

        public DashboardsPage2 VerifyAddedWidget(string name)
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

        public DashboardsPage2 ScrollToWidget(string name)
        {
            var widget = WidgetsList.Where(n => n.Text.StartsWith(name)).First();
            widget.ScrollTo(_driver);
            return this;
        }

        public DashboardsPage2 DragAndDropWidget(string name)
        {
            var widget = WidgetsList.Where(n => n.Text.StartsWith(name)).First();
            widget.DragAndDrop(_driver, 150, 150);
            return this;
        }

        public DashboardsPage2 ResizeWidget()
        {
            ResizeButtonsList.FirstOrDefault().DragAndDrop(_driver, 300, 300);
            return this;
        }
    }
}
