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
        private readonly string relativeUrl = string.Empty;
        private static string _filterName = string.Empty;
        private static string _newFilterName = string.Empty;

        public FiltersTests()
        {
            _driver = new ChromeDriver();
            _userSettings = new UserSettings();
            LoginPage = new LoginPage(_driver);
            Sidebar = new Sidebar(_driver);
            FiltersPage = new FiltersPage(_driver);
            LaunchesPage = new LaunchesPage(_driver);
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

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
