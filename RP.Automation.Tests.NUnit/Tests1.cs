using NUnit.Framework;
using RP.Automation.UI.Dialogs;
using HtmlElements;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using RP.Automation.UI.Extensions;
using RP.Automation.UI.Pages;


namespace RP.Automation.Tests.NUnit
{
    [TestFixture]
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    [Parallelizable(scope: ParallelScope.Fixtures)]
    public class Tests1
    {
        private IWebDriver? _driver;
        private UserSettings? _userSettings;
        private LoginPage? LoginPage;
        private LaunchesPage? LaunchesPage;
        private LaunchSuitePage? LaunchSuitePage;
        private Sidebar? Sidebar;
        protected IPageObjectFactory? PageFactory;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            _userSettings = new UserSettings();
            PageFactory = new PageObjectFactory();
            LoginPage = new LoginPage(_driver);
            LaunchesPage = new LaunchesPage(_driver);
            LaunchSuitePage = new LaunchSuitePage(_driver);
            Sidebar = new Sidebar(_driver);
        }

        [TestCase("Demo Api Tests #9", 25, 20, 5, 0, 4, 1, 0, 2)]
        [TestCase("Demo Api Tests #8", 20, 10, 8, 2, 4, 4, 0, 10)]
        [TestCase("Demo Api Tests #7", 15, 5, 9, 1, 1, 5, 4, 8)]
        [TestCase("Demo Api Tests #6", 10, 1, 9, 0, 0, 1, 8, 5)]
        [TestCase("Demo Api Tests #4", 25, 20, 5, 0, 4, 1, 0, 2)]
        public void VerifyLaunchData(string launchName, int expTotal, int expPassed, int expFailed, int expSkipped,
            int expProductBug, int expAutoBug, int expSystemIssue, int expToInvestigate)
        {
            _driver.GoTo(_userSettings?.BaseUrl, string.Empty);
            LoginPage?.Login(_userSettings?.Username, _userSettings?.Password);
            Sidebar?.OpenLaunches();
            LaunchesPage?.VerifyLaunchCount(launchName, expTotal, expPassed, expFailed, expSkipped,
            expProductBug, expAutoBug, expSystemIssue, expToInvestigate);
        }

        [TestCase("Suite with nested steps", 1, 0, 1, 0, 0, 1, 0, 0)]
        [TestCase("Filtering Launch Tests", 8, 8, 0, 0, 0, 0, 0, 0)]
        [TestCase("Launch Tests", 5, 5, 0, 0, 0, 0, 0, 0)]
        [TestCase("Test entity tests", 5, 5, 0, 0, 0, 0, 0, 0)]
        [TestCase("Permission tests", 5, 2, 3, 0, 3, 0, 0, 1)]
        public void VerifyLaunchSuiteData(string launchSuiteName, int expTotal, int expPassed, int expFailed, int expSkipped,
            int expProductBug, int expAutoBug, int expSystemIssue, int expToInvestigate)
        {
            _driver.GoTo(_userSettings?.BaseUrl, string.Empty);
            LoginPage?.Login(_userSettings?.Username, _userSettings?.Password);
            Sidebar?.OpenLaunches();
            LaunchesPage?.OpenLaunceSuite("Demo Api Tests #9");
            LaunchSuitePage?.VerifyLaunchSuiteCount(launchSuiteName, expTotal, expPassed, expFailed, expSkipped,
            expProductBug, expAutoBug, expSystemIssue, expToInvestigate);
        }


        [TearDown]
        public void TearDown()
        {
            _driver?.Quit();
            _driver?.Dispose();
        }
    }
}