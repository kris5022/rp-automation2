using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RP.Automation.Core.Utilities;
using RP.Automation.Tests;
using RP.Automation.UI.Extensions;
using RP.Automation.UI.BasePage;
using System.Threading;

namespace RP.Automation.UI.Dialogs
{
    public class AddDashboardPopup : BasePage<AddDashboardPopup>
    {
        private readonly UserSettings _userSettings;
        private readonly WebDriverWait _wait;

        public AddDashboardPopup(IWebDriver driver) : base(driver)
        {
            _userSettings = new UserSettings();
            _wait = new WebDriverWait(WebDriver, _userSettings.DefaultExplicitWaitTimeout);
        }

        private IWebElement NameInput =>
            WebDriver.FindElement(By.XPath(".//div[@class='fieldErrorHint__field-error-hint--1LHfk fieldErrorHint__type-bottom--2DLal']/input"));
        private IWebElement DescriptionInput =>
            WebDriver.FindElement(By.XPath(".//div[@class='CodeMirror cm-s-paper CodeMirror-wrap CodeMirror-empty']"));
        private IWebElement AddButton =>
            WebDriver.FindElement(By.XPath(".//button[@class='bigButton__big-button--ivY7j bigButton__color-booger--2IfQT']"));

        public override string BaseUrl => _userSettings.BaseUrl;
        public override string RelativePath => string.Empty;

        public override AddDashboardPopup VerifyPageLoaded()
        {
            _wait.Until(_ => DescriptionInput.Displayed);
            return base.VerifyPageLoaded();
        }

        public string AddDashboard()
        {
            var filterName = $"TestDashboard{Randomizer.RandomDigits()}";
            NameInput.ClearInput().SendKeys(filterName);
            AddButton.Click();
            Thread.Sleep(1500);
            return filterName;
        }
    }
}
