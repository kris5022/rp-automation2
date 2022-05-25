using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RP.Automation.Core.Utilities;
using RP.Automation.Tests;
using RP.Automation.UI.Extensions;
using RP.Automation.UI.BasePage;
using RP.Automation.UI.Enums;
using System.Threading;

namespace RP.Automation.UI.Dialogs
{
    public class AddNewWidgetDialog : BasePage<AddNewWidgetDialog>
    {
        private readonly UserSettings _userSettings;
        private readonly WebDriverWait _wait;

        public AddNewWidgetDialog(IWebDriver driver) : base(driver)
        {
            _userSettings = new UserSettings();
            _wait = new WebDriverWait(WebDriver, _userSettings.DefaultExplicitWaitTimeout);
        }

        private IWebElement LaunchStatisticsChartCheckbox =>
            WebDriver.FindElement(By.XPath(".//div[@class='widget-type-selector']/div[2]"));
        private IWebElement OverallStatisticsCheckbox =>
            WebDriver.FindElement(By.XPath(".//div[@class='widget-type-selector']/div[3]"));
        private IWebElement LaunchesDurationChartCheckbox =>
            WebDriver.FindElement(By.XPath(".//div[@class='widget-type-selector']/div[4]"));
        private IWebElement NextStepButton =>
            WebDriver.FindElement(By.XPath(".//div[@class='wizardControlsSection__button--1hxmV']"));
        private IWebElement AddFilterButton =>
            WebDriver.FindElement(By.XPath(".//div[@class='filtersActionPanel__filters-header--36O6-']//i[@class='ghostButton__icon--2rRly']"));
        private IWebElement FilterNameInput =>
            WebDriver.FindElement(By.XPath(".//input[@placeholder='Input filter name']"));
        private IWebElement LaunchNameInput =>
            WebDriver.FindElement(By.XPath(".//input[@placeholder='Enter name']"));
        private IWebElement SubmitButton =>
            WebDriver.FindElement(By.XPath(".//div[@class='addEditFilter__filter-buttons-block--3qyUs']/button[2]"));
        private IWebElement NextButton =>
            WebDriver.FindElement(By.XPath(".//div[@class='wizardControlsSection__buttons-block--1F7VD']/div[2]"));
        private IWebElement AddButton =>
            WebDriver.FindElement(By.XPath(".//div[@class='wizardControlsSection__buttons-block--1F7VD']/div[2]"));

        public override string BaseUrl => _userSettings.BaseUrl;
        public override string RelativePath => string.Empty;

        public override AddNewWidgetDialog VerifyPageLoaded()
        {
            _wait.Until(_ => LaunchStatisticsChartCheckbox.Displayed);
            return base.VerifyPageLoaded();
        }

        public AddNewWidgetDialog SelectWidgetType(string type)
        {
            switch (type)
            {
                case "Launch statistics chart":
                    LaunchStatisticsChartCheckbox.Click();
                    break;
                case "Overall statistics":
                    OverallStatisticsCheckbox.Click();
                    break;
                case "Launches duration chart":
                    LaunchesDurationChartCheckbox.Click();
                    break;

            }
            return this;
        }

        public AddNewWidgetDialog GoToNextStep()
        {
            NextStepButton.Click();
            return this;
        }

        public string AddNewFilter()
        {
            AddFilterButton.Click();
            var name = $"TestFilter{Randomizer.RandomDigits()}";
            FilterNameInput.ClearInput().SendKeys(name);
            LaunchNameInput.ClearInput().SendKeys(name);
            SubmitButton.Click();
            NextButton.Click();
            return name;
        }

        public AddNewWidgetDialog AddWidget()
        {
            AddButton.Click();
            Thread.Sleep(1500);
            return this;
        }
    }
}
