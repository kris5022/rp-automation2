using HtmlElements.Elements;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace RP.Automation.UI.Pages2
{
    public class LoginPage2 : HtmlPage
    {
        public LoginPage2(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.XPath, Using = ".//input[@placeholder='Login']")]
        public HtmlElement UsernameInput { get; private set; }

        [FindsBy(How = How.XPath, Using = ".//input[@placeholder='Password']")]
        public HtmlElement PasswordInput { get; private set; }

        [FindsBy(How = How.XPath, Using = ".//div[@class='loginForm__login-button-container--1mHGW']/button")]
        public HtmlElement LoginButton { get; private set; }

        public LoginPage2 Login(string username, string password)
        {
            UsernameInput.EnterText(username);
            PasswordInput.EnterText(password);
            LoginButton.Click();
            return this;
        }
    }
}