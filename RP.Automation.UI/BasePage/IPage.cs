using OpenQA.Selenium;
using System;

namespace RP.Automation.UI.BasePage
{
    public interface IPage
    {
        string BaseUrl { get; }

        string RelativePath { get; }

        int Timeout { get; set; }

        //IWebDriver WebDriver { get; }

        IPage VerifyPageUrl();

        IPage WaitUntil(Func<IWebDriver, bool> waitUntil);

        TPage VerifyPage<TPage>() where TPage : BasePage<TPage>;
    }
}
