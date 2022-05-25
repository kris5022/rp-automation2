using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RP.Automation.UI.BasePage;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RP.Automation.Tests.Pages
{
    public class FiltersPage : BasePage<FiltersPage>
    {
        private readonly UserSettings _userSettings;

        private readonly WebDriverWait _wait;

        public FiltersPage(IWebDriver driver) : base(driver)
        {
            _userSettings = new UserSettings();
            _wait = new WebDriverWait(WebDriver, _userSettings.DefaultExplicitWaitTimeout);
        }

        private IWebElement AddFilterButton =>
            WebDriver.FindElement(By.XPath(".//span[@class='ghostButton__text--eUa9T']"));
        private List<IWebElement> FiltersList =>
            WebDriver.FindElements(By.XPath(".//div[@class='grid__grid--utIJA']/div//span[@class='filterName__name-wrapper--27aDE']/a/span")).ToList();
        private IWebElement EditFilterButton =>
            WebDriver.FindElement(By.XPath(".//span[@class='ghostButton__text--eUa9T']"));
        private List<IWebElement> DeleteButtonsList =>
            WebDriver.FindElements(By.XPath(".//div[@class='deleteFilterButton__bin-icon--3aWi9']")).ToList();

        public override string BaseUrl => _userSettings.BaseUrl;
        public override string RelativePath => "/ui/#default_personal/filters";

        public override FiltersPage VerifyPageLoaded()
        {
            _wait.Until(_ => AddFilterButton.Displayed);
            return base.VerifyPageLoaded();
        }

        public FiltersPage AddFilter()
        {
            AddFilterButton.Click();
            return this;
        }

        public FiltersPage VerifyFilterAdded(string filterName)
        {
            var filterCount = FiltersList.Where(f => f.Text == filterName).Count();
            Assert.True(filterCount == 1);
            return this;
        }

        public FiltersPage EditFilter(string filterName)
        {
            FiltersList.Where(f => f.Text == filterName).ToList()[0].Click();
            return this;
        }

        public FiltersPage DeleteFilter(string filterName)
        {
            var filter = FiltersList.Where(f => f.Text == filterName).ToList()[0];
            var filterIndex = FiltersList.IndexOf(filter);
            DeleteButtonsList[filterIndex].Click();
            return this;
        }

        public FiltersPage VerifyFilterDeleted(string filterName)
        {
            var filterCount = FiltersList.Where(f => f.Text == filterName).Count();
            Assert.True(filterCount == 0);
            return this;
        }
    }
}
