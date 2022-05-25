using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RP.Automation.Tests;
using RP.Automation.UI.BasePage;

namespace RP.Automation.UI.Dialogs
{
    public class DeleteFilterDialog : BasePage<DeleteFilterDialog>
    {
        private readonly UserSettings _userSettings;

        private readonly WebDriverWait _wait;

        public DeleteFilterDialog(IWebDriver driver) : base(driver)
        {
            _userSettings = new UserSettings();
            _wait = new WebDriverWait(WebDriver, _userSettings.DefaultExplicitWaitTimeout);
        }

        private IWebElement DeleteButton =>
            WebDriver.FindElement(By.XPath(".//div[@class='modalFooter__button-container--2RXFR'][2]/button"));
        
        public override string BaseUrl => _userSettings.BaseUrl;
        public override string RelativePath => string.Empty;

        public override DeleteFilterDialog VerifyPageLoaded()
        {
            _wait.Until(_ => DeleteButton.Displayed);
            return base.VerifyPageLoaded();
        }

        public DeleteFilterDialog Delete()
        {
            DeleteButton.Click();
            return this;
        }
    }
}
