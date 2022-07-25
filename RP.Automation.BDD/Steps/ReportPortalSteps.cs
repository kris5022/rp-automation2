using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RP.Automation.Tests;
using RP.Automation.UI.Dialogs;
using RP.Automation.UI.Extensions;
using RP.Automation.UI.Models;
using RP.Automation.UI.Pages;
using System.Collections.Generic;
using System.Linq;
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
            DashboardsPage.VerifyPageLoaded();
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
            var widget = table.CreateInstance<Widget>();
            var a = widget.ChartType;
            DashboardsPage.AddNewWidget();
            AddNewWidgetDialog.SelectWidgetType(widget.ChartType);
            AddNewWidgetDialog.GoToNextStep();
            filterName = AddNewWidgetDialog.AddNewFilter();
            AddNewWidgetDialog.AddWidget();
        }

        [When(@"the user add a new widget")]
        public void GivenTheUserAAddNewWidget(Widget widget)
        {
            DashboardsPage.AddNewWidget();
            AddNewWidgetDialog.SelectWidgetType(widget.ChartType);
            AddNewWidgetDialog.GoToNextStep();
            filterName = AddNewWidgetDialog.AddNewFilter();
            AddNewWidgetDialog.AddWidget();

        }

        [When(@"user add new widget")]
        public void GivenUserAddNewWidget(List<Widget> widgetList)
        {
            DashboardsPage.AddNewWidget();
            AddNewWidgetDialog.SelectWidgetType(widgetList[0].ChartType);
            AddNewWidgetDialog.GoToNextStep();
            filterName = AddNewWidgetDialog.AddNewFilter();
            AddNewWidgetDialog.AddWidget();
        }

        [StepArgumentTransformation]
        public List<Widget> GetTestParameters(Table table)
        {
            return table.Rows.Select(row => new Widget
            {
                ChartType = row["ChartType"]
            }).ToList();
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
