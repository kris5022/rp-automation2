using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RP.Automation.Tests;
using RP.Automation.UI.BasePage;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RP.Automation.UI.Pages
{
    public class LaunchSuitePage : BasePage<LaunchSuitePage>
    {
        private readonly UserSettings _userSettings;

        private readonly WebDriverWait _wait;

        public LaunchSuitePage(IWebDriver driver) : base(driver)
        {
            _userSettings = new UserSettings();
            _wait = new WebDriverWait(WebDriver, _userSettings.DefaultExplicitWaitTimeout);
        }

        private List<IWebElement> SuiteNames =>
            WebDriver.FindElements(By.XPath(".//div[@class='tooltip__tooltip-trigger--3Z4Hc itemInfo__name--27fwI']")).ToList();
        private List<IWebElement> LaunchNumbers =>
            WebDriver.FindElements(By.XPath(".//span[@class='itemInfo__edit-number-box--24FEN']/a/span")).ToList();
        private List<IWebElement> TotalSigns =>
            WebDriver.FindElements(By.XPath(".//div[@class='launchSuiteGrid__total-col--1zT8z gridCell__grid-cell--3e2mS gridCell__align-left--2beIG']//a")).ToList();
        private List<IWebElement> PassedSigns =>
            WebDriver.FindElements(By.XPath(".//div[@class='launchSuiteGrid__passed-col--2EZNC gridCell__grid-cell--3e2mS gridCell__align-left--2beIG']//a")).ToList();
        private List<IWebElement> FailedSigns =>
            WebDriver.FindElements(By.XPath(".//div[@class='launchSuiteGrid__failed-col--1LKOb gridCell__grid-cell--3e2mS gridCell__align-left--2beIG']//a")).ToList();
        private List<IWebElement> SkippedSigns =>
            WebDriver.FindElements(By.XPath(".//div[@class='launchSuiteGrid__skipped-col--1zvap gridCell__grid-cell--3e2mS gridCell__align-left--2beIG']//a")).ToList();
        private List<IWebElement> ProductBugSigns =>
            WebDriver.FindElements(By.XPath(".//div[@class='launchSuiteGrid__pb-col---Q-5f gridCell__grid-cell--3e2mS gridCell__align-left--2beIG']//a/div[2]")).ToList();
        private List<IWebElement> AutoBugSigns =>
            WebDriver.FindElements(By.XPath(".//div[@class='launchSuiteGrid__ab-col--1e3O7 gridCell__grid-cell--3e2mS gridCell__align-left--2beIG']//a/div[2]")).ToList();
        private List<IWebElement> SystemIssueSigns =>
            WebDriver.FindElements(By.XPath(".//div[@class='launchSuiteGrid__si-col--1selD gridCell__grid-cell--3e2mS gridCell__align-left--2beIG']//a/div[2]")).ToList();
        private List<IWebElement> ToInverstigateSigns =>
            WebDriver.FindElements(By.XPath(".//div[@class='launchSuiteGrid__ti-col--33O72 gridCell__grid-cell--3e2mS gridCell__align-left--2beIG']//a/div[2]")).ToList();

        public override string BaseUrl => _userSettings.BaseUrl;
        public override string RelativePath => "/ui/#default_personal/launches";

        public override LaunchSuitePage VerifyPageLoaded()
        {
            _wait.Until(_ => SuiteNames.First().Displayed);
            return base.VerifyPageLoaded();
        }

        public LaunchSuitePage VerifyLaunchSuiteCount(string launchName, int expTotal, int expPassed, int expFailed, int expSkipped,
            int expProductBug, int expAutoBug, int expSystemIssue, int expToInvestigate)
        {
            VerifyElementCount(launchName, TotalSigns, expTotal);
            VerifyElementCount(launchName, PassedSigns, expPassed);
            VerifyElementCount(launchName, FailedSigns, expFailed);
            VerifyElementCount(launchName, SkippedSigns, expSkipped);
            VerifyElementCount(launchName, ProductBugSigns, expProductBug);
            VerifyElementCount(launchName, AutoBugSigns, expAutoBug);
            VerifyElementCount(launchName, SystemIssueSigns, expSystemIssue);
            VerifyElementCount(launchName, ToInverstigateSigns, expToInvestigate);
            return this;
        }

        public void VerifyElementCount(string launchName, List<IWebElement> list, int expCount)
        {
            var i = GetListNumber(launchName);
            var actCount = 0;

            try
            {
                actCount = Convert.ToInt32(list[i].Text);
                Assert.Equal(expCount, actCount);
            }
            catch (ArgumentOutOfRangeException)
            {
                Assert.Equal(0, expCount);
            }
        }

        public int GetListNumber(string launchName)
        {
            var j = 0;

            for (int i = 0; i < SuiteNames.Count; i++)
            {
                var name = $"{SuiteNames[i].Text} {LaunchNumbers[i].Text}";
                if (name == launchName)
                {
                    j = i;
                    break;
                }
            }
            return j;
        }

        public void OpenLaunceSuite(string suiteName)
        {
            for (int i = 0; i < SuiteNames.Count; i++)
            {
                var name = $"{SuiteNames[i].Text} {LaunchNumbers[i].Text}";
                if (name == suiteName)
                {
                    SuiteNames[i].Click();
                    break;
                }
            }
        }
    }
}
