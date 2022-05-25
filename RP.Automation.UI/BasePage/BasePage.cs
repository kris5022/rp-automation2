using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RP.Automation.UI.Extensions;
using System;

namespace RP.Automation.UI.BasePage
{
    public abstract class BasePage<T> : IPage
        where T : BasePage<T>
    {
        protected const int DefaultTimeout = 60;

        protected BasePage(IWebDriver driver)
        {
            Timeout = DefaultTimeout;
            WebDriver = driver;
        }

        public abstract string BaseUrl { get; }

        public abstract string RelativePath { get; }

        public int Timeout { get; set; }

        public IWebDriver WebDriver { get; }

        public virtual TPage VerifyPage<TPage>() where TPage : BasePage<TPage>
        {
            return WebDriver.VerifyPage<TPage>();
        }

        IPage IPage.VerifyPageUrl()
        {
            return VerifyPageUrl();
        }

        IPage IPage.WaitUntil(Func<IWebDriver, bool> waitUntil)
        {
            return WaitUntil(waitUntil);
        }

        public virtual T VerifyPageLoaded()
        {
            var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(Timeout));
            wait.Until(d => d.Url.ToLower().Contains(RelativePath.ToLower()));
            return (T)this;
        }

        public virtual T VerifyPageUrl()
        {
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(Timeout)).Until(d =>
                d.Url.ToLower().Contains(RelativePath.ToLower()));
            return (T)this;
        }

        public virtual T GoTo()
        {
            WebDriver.GoTo(BaseUrl, RelativePath);
            return (T)this;
        }

        private T WaitUntil(Func<IWebDriver, bool> waitUntil)
        {
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(Timeout)).Until(_ => waitUntil(WebDriver));
            return (T)this;
        }
    }
}
