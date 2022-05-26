using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RP.Automation.Tests.Pages;
using RP.Automation.UI.Dialogs;
using RP.Automation.UI.Extensions;
using System;
using Xunit;

namespace RP.Automation.Tests
{
    public class FiltersTests : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly UserSettings _userSettings;
        private static LoginPage LoginPage;
        private static Sidebar Sidebar;
        private static FiltersPage FiltersPage;
        private static LaunchesPage LaunchesPage;
        private static DashboardsPage DashboardsPage;
        private static AddDashboardPopup AddDashboardPopup;
        private static AddNewWidgetDialog AddNewWidgetDialog;
        private readonly string relativeUrl = string.Empty;
        private static string _filterName = string.Empty;
        private static string _newFilterName = string.Empty;
        private string filterName;

        public FiltersTests()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            _userSettings = new UserSettings();
            LoginPage = new LoginPage(_driver);
            Sidebar = new Sidebar(_driver);
            FiltersPage = new FiltersPage(_driver);
            LaunchesPage = new LaunchesPage(_driver);
            DashboardsPage = new DashboardsPage(_driver);
            AddDashboardPopup = new AddDashboardPopup(_driver);
            AddNewWidgetDialog = new AddNewWidgetDialog(_driver);
        }
        
        [Fact]
        public void AddFilter()
        {
            _driver.GoTo(_userSettings.BaseUrl, relativeUrl);
            LoginPage.Login(_userSettings.Username, _userSettings.Password);
            Sidebar.OpenFilters();
            FiltersPage.AddFilter();
            LaunchesPage.SaveFilter();

            _filterName = _driver.VerifyPage<AddFilterPopup>()
                .AddFilter();

            _driver.VerifyPage<LaunchesPage>();
            _driver.VerifyPage<Sidebar>()
                .OpenFilters()
                .VerifyPage<FiltersPage>()
                .VerifyFilterAdded(_filterName);
        }

        [Fact]
        public void UpdateFilter()
        {
            AddFilter();
            _driver.VerifyPage<FiltersPage>()
                .EditFilter(_filterName)
                .VerifyPage<LaunchesPage>()
                .EditFilter();

            _newFilterName = _driver.VerifyPage<EditFilterPopup>()
                .EditFilterName(_filterName);

            _driver.VerifyPage<Sidebar>()
                .OpenFilters()
                .VerifyPage<FiltersPage>()
                .VerifyFilterAdded(_newFilterName);
        }

        [Fact]
        public void DeleteFilter()
        {
            AddFilter();
            _driver.VerifyPage<FiltersPage>()
                .DeleteFilter(_filterName)
                .VerifyPage<DeleteFilterDialog>()
                .Delete()
                .VerifyPage<FiltersPage>()
                .VerifyFilterDeleted(_filterName);
        }

        [Fact]
        public void AddWidget()
        {
            _driver.GoTo(_userSettings.BaseUrl, relativeUrl);
            LoginPage.Login(_userSettings.Username, _userSettings.Password);
            DashboardsPage.AddNewDashboard();
            AddDashboardPopup.AddDashboard();

            DashboardsPage.AddNewWidget();
            AddNewWidgetDialog.SelectWidgetType("Launch statistics chart");
            AddNewWidgetDialog.GoToNextStep();
            filterName = AddNewWidgetDialog.AddNewFilter();
            AddNewWidgetDialog.AddWidget();

            DashboardsPage.AddNewWidget();
            AddNewWidgetDialog.SelectWidgetType("Overall statistics");
            AddNewWidgetDialog.GoToNextStep();
            AddNewWidgetDialog.AddNewFilter();
            AddNewWidgetDialog.AddWidget();

            DashboardsPage.ScrollToWidget(filterName);
            DashboardsPage.DragAndDropWidget(filterName);
            DashboardsPage.ResizeWidget();
            //DashboardsPage.VerifyAddedWidget(filterName);
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
