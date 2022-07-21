using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RP.Automation.Tests;
using RP.Automation.UI.BasePage;

namespace RP.Automation.UI.Pages
{
    public class LoginPage : BasePage<LoginPage>
    {
        private readonly UserSettings _userSettings;
        private readonly WebDriverWait _wait;

        public LoginPage(IWebDriver driver) : base(driver)
        {
            _userSettings = new UserSettings();
            _wait = new WebDriverWait(WebDriver, _userSettings.DefaultExplicitWaitTimeout);
        }

        private IWebElement UsernameInput =>
            WebDriver.FindElement(By.XPath(".//input[@placeholder='Login']"));
        private IWebElement PasswordInput =>
            WebDriver.FindElement(By.XPath(".//input[@placeholder='Password']"));
        private IWebElement LoginButton =>
            WebDriver.FindElement(By.XPath(".//div[@class='loginForm__login-button-container--1mHGW']/button"));

        public override string BaseUrl => _userSettings.BaseUrl;
        public override string RelativePath => "/ui/#login";

        public override LoginPage VerifyPageLoaded()
        {
            _wait.Until(_ => UsernameInput.Displayed);
            return base.VerifyPageLoaded();
        }

        public LoginPage Login(string username, string password)
        {
            UsernameInput.SendKeys(username);
            PasswordInput.SendKeys(password); 
            LoginButton.Click();
            return this;
        }
    }
}
