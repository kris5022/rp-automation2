using OpenQA.Selenium;
using RP.Automation.Driver.Factories;
using RP.Automation.UI.Dialogs;
using RP.Automation.UI.Extensions;
using RP.Automation.UI.Fixtures;
using RP.Automation.UI.Pages;
using Xunit;

namespace RP.Automation.Tests
{
    public class SmokeTests : IClassFixture<FiltersFixture>
    {
        private readonly IWebDriver _driver;
        private readonly UserSettings _userSettings;
        private readonly string relativeUrl = string.Empty;
        private static string _filterName = string.Empty;

        public SmokeTests()
        {
            _driver = WebDriverFactory.Create(_userSettings.Browser);
            _userSettings = new UserSettings();
        }
        
        [Fact]
        public void AddFilter()
        {
            _driver.GoTo(_userSettings.BaseUrl, relativeUrl)
                .VerifyPage<LoginPage>()
                .Login(_userSettings.Username, _userSettings.Password)
                .VerifyPage<DashboardsPage>()
                .VerifyPage<Sidebar>()
                .OpenFilters()
                .VerifyPage<FiltersPage>()
                .AddFilter()
                .VerifyPage<LaunchesPage>()
                .SaveFilter();

            _filterName = _driver.VerifyPage<AddFilterPopup>()
                .AddFilter();

            _driver.VerifyPage<LaunchesPage>();
            _driver.VerifyPage<Sidebar>()
                .OpenFilters()
                .VerifyPage<FiltersPage>()
                .VerifyFilterAdded(_filterName);

            _driver.VerifyPage<FiltersPage>()
                .DeleteFilter(_filterName)
                .VerifyPage<DeleteFilterDialog>()
                .Delete()
                .VerifyPage<FiltersPage>()
                .VerifyFilterDeleted(_filterName);
        }
    }
}
