using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RP.Automation.UI.BasePage;

namespace RP.Automation.Tests.Pages
{
    public class LaunchesPage : BasePage<LaunchesPage>
    {
        private readonly UserSettings _userSettings;

        private readonly WebDriverWait _wait;

        public LaunchesPage(IWebDriver driver) : base(driver)
        {
            _userSettings = new UserSettings();
            _wait = new WebDriverWait(WebDriver, _userSettings.DefaultExplicitWaitTimeout);
        }

        private IWebElement LaunchNameInput =>
            WebDriver.FindElement(By.XPath(".//input[@class='inputConditional__input--1ZRQE inputConditional__touched--3gPX5']"));
        private IWebElement SaveButton =>
            WebDriver.FindElement(By.XPath(".//div[@class='filterControls__filter-controls--3Nox0']/div[4]"));
        private IWebElement EditButton =>
            WebDriver.FindElement(By.XPath(".//div[@class='filterControls__control-button--Xx8z7'][3]"));

        public override string BaseUrl => _userSettings.BaseUrl;
        public override string RelativePath => "/ui/#default_personal/launches";

        public override LaunchesPage VerifyPageLoaded()
        {
            _wait.Until(_ => LaunchNameInput.Displayed);
            return base.VerifyPageLoaded();
        }

        public LaunchesPage SaveFilter()
        {
            LaunchNameInput.SendKeys("TestLaunch");
            SaveButton.Click();
            return this;
        }

        public LaunchesPage EditFilter()
        {
            EditButton.Click();
            return this;
        }
    }
}
