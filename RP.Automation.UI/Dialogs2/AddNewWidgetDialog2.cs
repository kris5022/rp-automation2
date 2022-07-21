using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RP.Automation.Core.Utilities;
using RP.Automation.Tests;
using RP.Automation.UI.Extensions;
using RP.Automation.UI.BasePage;
using RP.Automation.UI.Enums;
using System.Threading;
using HtmlElements.Elements;
using SeleniumExtras.PageObjects;

namespace RP.Automation.UI.Dialogs
{
    public class AddNewWidgetDialog2 : HtmlPage
    {
        public AddNewWidgetDialog2(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.XPath, Using = ".//div[@class='widget-type-selector']/div[2]")]
        public HtmlElement LaunchStatisticsChartCheckbox { get; private set; }

        [FindsBy(How = How.XPath, Using = ".//div[@class='widget-type-selector']/div[3]")]
        public HtmlElement OverallStatisticsCheckbox { get; private set; }

        [FindsBy(How = How.XPath, Using = ".//div[@class='widget-type-selector']/div[4]")]
        public HtmlElement LaunchesDurationChartCheckbox { get; private set; }

        [FindsBy(How = How.XPath, Using = ".//div[@class='wizardControlsSection__button--1hxmV']")]
        public HtmlElement NextStepButton { get; private set; }

        [FindsBy(How = How.XPath, Using = ".//div[@class='filtersActionPanel__filters-header--36O6-']//i[@class='ghostButton__icon--2rRly']")]
        public HtmlElement AddFilterButton { get; private set; }

        [FindsBy(How = How.XPath, Using = ".//input[@placeholder='Input filter name']")]
        public HtmlElement FilterNameInput { get; private set; }

        [FindsBy(How = How.XPath, Using = ".//input[@placeholder='Enter name']")]
        public HtmlElement LaunchNameInput { get; private set; }

        [FindsBy(How = How.XPath, Using = ".//div[@class='addEditFilter__filter-buttons-block--3qyUs']/button[2]")]
        public HtmlElement SubmitButton { get; private set; }

        [FindsBy(How = How.XPath, Using = ".//div[@class='wizardControlsSection__buttons-block--1F7VD']/div[2]")]
        public HtmlElement NextButton { get; private set; }

        [FindsBy(How = How.XPath, Using = ".//div[@class='wizardControlsSection__buttons-block--1F7VD']/div[2]")]
        public HtmlElement AddButton { get; private set; }


        public AddNewWidgetDialog2 SelectWidgetType(string type)
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

        public AddNewWidgetDialog2 GoToNextStep()
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

        public AddNewWidgetDialog2 AddWidget()
        {
            AddButton.Click();
            return this;
        }
    }
}
