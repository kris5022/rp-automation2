using HtmlElements.Elements;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RP.Automation.Tests.Pages
{
    public class FiltersPage2 : HtmlPage
    {
        public FiltersPage2(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.XPath, Using = ".//span[@class='ghostButton__text--eUa9T']")]
        public HtmlElement AddFilterButton { get; private set; }

        [FindsBy(How = How.XPath, Using = ".//div[@class='grid__grid--utIJA']/div//span[@class='filterName__name-wrapper--27aDE']/a/span")]
        public List<HtmlElement> FiltersList { get; private set; }

        [FindsBy(How = How.XPath, Using = ".//span[@class='ghostButton__text--eUa9T']")]
        public HtmlElement EditFilterButton { get; private set; }

        [FindsBy(How = How.XPath, Using = ".//div[@class='deleteFilterButton__bin-icon--3aWi9']")]
        public List<HtmlElement> DeleteButtonsList { get; private set; }


        public FiltersPage2 AddFilter()
        {
            AddFilterButton.Click();
            return this;
        }

        public FiltersPage2 VerifyFilterAdded(string filterName)
        {
            var filterCount = FiltersList.Where(f => f.Text == filterName).Count();
            Assert.True(filterCount == 1);
            return this;
        }

        public FiltersPage2 EditFilter(string filterName)
        {
            FiltersList.Where(f => f.Text == filterName).ToList()[0].Click();
            return this;
        }

        public FiltersPage2 DeleteFilter(string filterName)
        {
            var filter = FiltersList.Where(f => f.Text == filterName).ToList()[0];
            var filterIndex = FiltersList.IndexOf(filter);
            DeleteButtonsList[filterIndex].Click();
            return this;
        }

        public FiltersPage2 VerifyFilterDeleted(string filterName)
        {
            var filterCount = FiltersList.Where(f => f.Text == filterName).Count();
            Assert.True(filterCount == 0);
            return this;
        }
    }
}
