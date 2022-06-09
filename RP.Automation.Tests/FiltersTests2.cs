using HtmlElements;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RP.Automation.Tests.Pages;
using RP.Automation.Tests.Pages2;
using RP.Automation.UI.Dialogs;
using RP.Automation.UI.Extensions;
using System;
using Xunit;

namespace RP.Automation.Tests
{
    public class FiltersTests2 : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly UserSettings _userSettings;
        private static LoginPage2 LoginPage;
        private static DashboardsPage2 DashboardsPage;
        private static Sidebar2 Sidebar;
        private static FiltersPage2 FiltersPage;
        private static LaunchesPage2 LaunchesPage;
        private static AddDashboardPopup2 AddDashboardPopup;
        private static AddNewWidgetDialog2 AddNewWidgetDialog;
        private static AddFilterPopup2 AddFilterPopup;
        private static EditFilterPopup2 EditFilterPopup;
        private readonly string relativeUrl = string.Empty;
        private static string _filterName = string.Empty;
        private static string _newFilterName = string.Empty;
        private string filterName;
        protected readonly IPageObjectFactory PageFactory;

        public FiltersTests2()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            _userSettings = new UserSettings();
            PageFactory = new PageObjectFactory();
        }

        [Fact]
        public void AddFilter()
        {
            _driver.GoTo(_userSettings.BaseUrl, relativeUrl);
            LoginPage.Login(_userSettings.Username, _userSettings.Password);
            Sidebar.OpenFilters();
            FiltersPage.AddFilter();
            LaunchesPage.SaveFilter();

            _filterName = AddFilterPopup.AddFilter();
            Sidebar.OpenFilters();
            FiltersPage.VerifyFilterAdded(_filterName);
        }

        [Fact]
        public void UpdateFilter()
        {
            _driver.GoTo(_userSettings.BaseUrl, relativeUrl);
            LoginPage.Login(_userSettings.Username, _userSettings.Password);
            Sidebar.OpenFilters();
            FiltersPage.AddFilter();
            LaunchesPage.SaveFilter();

            _filterName = AddFilterPopup.AddFilter();
            Sidebar.OpenFilters();
            FiltersPage.VerifyFilterAdded(_filterName);
            FiltersPage.EditFilter(_filterName);
            LaunchesPage.EditFilter();

            _newFilterName = EditFilterPopup.EditFilterName(_filterName);

            Sidebar.OpenFilters();
            FiltersPage.VerifyFilterAdded(_newFilterName);
        }

        [Fact]
        public void DeleteFilter()
        {
            _driver.GoTo(_userSettings.BaseUrl, relativeUrl);
            LoginPage.Login(_userSettings.Username, _userSettings.Password);
            Sidebar.OpenFilters();
            FiltersPage.AddFilter();
            LaunchesPage.SaveFilter();

            _filterName = AddFilterPopup.AddFilter();
            Sidebar.OpenFilters();
            FiltersPage.VerifyFilterAdded(_filterName);
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
            LoginPage = PageFactory.Create<LoginPage2>(_driver);
            DashboardsPage = PageFactory.Create<DashboardsPage2>(_driver);
            AddDashboardPopup = PageFactory.Create<AddDashboardPopup2>(_driver);
            AddNewWidgetDialog = PageFactory.Create<AddNewWidgetDialog2>(_driver);

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
            DashboardsPage.VerifyAddedWidget(filterName);
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
