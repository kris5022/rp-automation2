using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RP.Automation.Tests;
using RP.Automation.Tests.Pages;
using RP.Automation.UI.Dialogs;
using RP.Automation.UI.Extensions;
using RP.Automation.UI.Models;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace RP.Automation.BDD.Steps
{
    [Binding]
    public class ReportPortalSteps
    {
        private readonly UserSettings _userSettings;
        private readonly IWebDriver _driver;
        private static LoginPage LoginPage;
        private static Sidebar Sidebar;
        private static DashboardsPage DashboardsPage;
        private static AddDashboardPopup AddDashboardPopup;
        private static AddNewWidgetDialog AddNewWidgetDialog;
        private string relativeUrl = string.Empty;
        private string filterName;

        public ReportPortalSteps(UserSettings userSettings)
        {
            _driver = new ChromeDriver();
            _userSettings = userSettings;
            LoginPage = new LoginPage(_driver);
            Sidebar = new Sidebar(_driver);
            DashboardsPage = new DashboardsPage(_driver);
            AddDashboardPopup = new AddDashboardPopup(_driver);
            AddNewWidgetDialog = new AddNewWidgetDialog(_driver);
        }

        [Given(@"the user opened home page")]
        public void GivenTheUserOpenedHomePage()
        {
            _driver.GoTo(_userSettings.BaseUrl, relativeUrl);
        }

        [Given(@"sucessfully logged in")]
        public void GivenTheUserSucessfullyLoggedIn()
        {
            LoginPage.Login(_userSettings.Username, _userSettings.Password);
            //DashboardsPage.VerifyPageLoaded();
        }

        [Given(@"added new dashboard")]
        public void GivenTheUserAddedNewDashboard()
        {
            DashboardsPage.AddNewDashboard();
            AddDashboardPopup.AddDashboard();
        }

        [When(@"the user add new widget (Launch statistics chart|Overall statistics|Launches duration chart)")]
        public void GivenTheUserAddNewWidget(string type)
        {
            DashboardsPage.AddNewWidget();
            AddNewWidgetDialog.SelectWidgetType(type);
            AddNewWidgetDialog.GoToNextStep();
            filterName = AddNewWidgetDialog.AddNewFilter();
            AddNewWidgetDialog.AddWidget();
        }

        [When(@"the user add new widget")]
        public void GivenTheUserAddNewWidget(Table table)
        {
            var widget = table.CreateInstance<WidgetType>();
            var a = widget.ChartType;
            DashboardsPage.AddNewWidget();
            AddNewWidgetDialog.SelectWidgetType(widget.ChartType);
            AddNewWidgetDialog.GoToNextStep();
            filterName = AddNewWidgetDialog.AddNewFilter();
            AddNewWidgetDialog.AddWidget();
        }

        [Then(@"the widget should be added to the list")]
        public void GivenTheWidgetShouldBeAddedToTheList()
        {
            DashboardsPage.VerifyAddedWidget(filterName);
        }

        [TestCleanup]
        public void AfterTestRun()
        {
            _driver?.Quit();
            _driver?.Dispose();
        }
    }
}
