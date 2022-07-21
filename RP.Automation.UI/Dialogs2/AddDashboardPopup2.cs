using OpenQA.Selenium;
using RP.Automation.Core.Utilities;
using RP.Automation.UI.Extensions;
using HtmlElements.Elements;
using SeleniumExtras.PageObjects;

namespace RP.Automation.UI.Dialogs
{
    public class AddDashboardPopup2 : HtmlPage
    {
        public AddDashboardPopup2(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.XPath, Using = ".//div[@class='fieldErrorHint__field-error-hint--1LHfk fieldErrorHint__type-bottom--2DLal']/input")]
        public HtmlElement NameInput { get; private set; }

        [FindsBy(How = How.XPath, Using = ".//div[@class='CodeMirror cm-s-paper CodeMirror-wrap CodeMirror-empty']")]
        public HtmlElement DescriptionInput { get; private set; }

        [FindsBy(How = How.XPath, Using = ".//button[@class='bigButton__big-button--ivY7j bigButton__color-booger--2IfQT']")]
        public HtmlElement AddButton { get; private set; }
        

        public string AddDashboard()
        {
            var filterName = $"TestDashboard{Randomizer.RandomDigits()}";
            NameInput.ClearInput().SendKeys(filterName);
            AddButton.Click();
            return filterName;
        }
    }
}
