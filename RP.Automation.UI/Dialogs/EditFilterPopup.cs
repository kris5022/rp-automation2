using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RP.Automation.Tests;
using RP.Automation.UI.Extensions;
using RP.Automation.UI.BasePage;

namespace RP.Automation.UI.Dialogs
{
    public class EditFilterPopup : BasePage<EditFilterPopup>
    {
        private readonly UserSettings _userSettings;

        private readonly WebDriverWait _wait;

        public EditFilterPopup(IWebDriver driver) : base(driver)
        {
            _userSettings = new UserSettings();
            _wait = new WebDriverWait(WebDriver, _userSettings.DefaultExplicitWaitTimeout);
        }

        private IWebElement NameInput =>
            WebDriver.FindElement(By.XPath(".//div[@class='fieldErrorHint__field-error-hint--1LHfk fieldErrorHint__type-bottom--2DLal']/input"));
        private IWebElement DescriptionInput =>
            WebDriver.FindElement(By.XPath(".//div[@class='CodeMirror cm-s-paper CodeMirror-wrap CodeMirror-empty']"));
        private IWebElement EditButton =>
            WebDriver.FindElement(By.XPath(".//button[@class='bigButton__big-button--ivY7j bigButton__color-booger--2IfQT']"));

        public override string BaseUrl => _userSettings.BaseUrl;
        public override string RelativePath => string.Empty;

        public override EditFilterPopup VerifyPageLoaded()
        {
            _wait.Until(_ => DescriptionInput.Displayed);
            return base.VerifyPageLoaded();
        }

        public string EditFilterName(string filterName)
        {
            var newFilterName = $"Updated{filterName}";
            NameInput.ClearInput().SendKeys(newFilterName);
            EditButton.Click();
            return newFilterName;
        }
    }
}
