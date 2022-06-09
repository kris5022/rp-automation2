using HtmlElements.Elements;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace RP.Automation.Tests.Pages
{
    public class LaunchesPage2 : HtmlPage
    {
        public LaunchesPage2(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.XPath, Using = ".//input[@class='inputConditional__input--1ZRQE inputConditional__touched--3gPX5']")]
        public HtmlElement LaunchNameInput { get; private set; }

        [FindsBy(How = How.XPath, Using = ".//div[@class='filterControls__filter-controls--3Nox0']/div[4]")]
        public HtmlElement SaveButton { get; private set; }

        [FindsBy(How = How.XPath, Using = ".//div[@class='filterControls__control-button--Xx8z7'][3]")]
        public HtmlElement EditButton { get; private set; }
        

        public LaunchesPage2 SaveFilter()
        {
            LaunchNameInput.SendKeys("TestLaunch");
            SaveButton.Click();
            return this;
        }

        public LaunchesPage2 EditFilter()
        {
            EditButton.Click();
            return this;
        }
    }
}
