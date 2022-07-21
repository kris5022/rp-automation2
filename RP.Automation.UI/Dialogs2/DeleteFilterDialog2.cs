using HtmlElements.Elements;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace RP.Automation.UI.Dialogs
{
    public class DeleteFilterDialog2 : HtmlPage
    {
        public DeleteFilterDialog2(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.XPath, Using = ".//div[@class='modalFooter__button-container--2RXFR'][2]/button")]
        public HtmlElement DeleteButton { get; private set; }


        public DeleteFilterDialog2 Delete()
        {
            DeleteButton.Click();
            return this;
        }
    }
}
