using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace RegistrationDemo.Tests.Base
{
    public abstract partial class PageBase : CommonBase
    {
        public string BaseURL { get; set; }
        public virtual string DefaultTitle { get { return string.Empty; } }

        protected TPage GetInstance<TPage>(IWebDriver driver = null, string expected = "") where TPage : PageBase, new()
        {
            return GetInstance<TPage>(driver ?? Driver, BaseURL, expected);
        }

        protected static TPage GetInstance<TPage>(IWebDriver driver, string baseUrl, string expected = "") where TPage : PageBase, new()
        {
            TPage page = new TPage()
            {
                Driver = driver,
                BaseURL = baseUrl
            };

            PageFactory.InitElements(driver, page);

            if (string.IsNullOrWhiteSpace(expected))
                expected = page.DefaultTitle;

            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until<OpenQA.Selenium.IWebElement>((d) =>
            {
                return d.FindElement(ByChained.TagName("body"));
            });

            AssertIsEqual(expected, driver.Title, "Page Title");
            return page;
        }

        public void Is<TPage>() where TPage : PageBase, new()
        {
            if (!(this is TPage))
                throw new AssertionException(string.Format("Page Type Mismatch: Current page is not a '{0}'", typeof(TPage).Name));
        }

        public TPage As<TPage>() where TPage : PageBase, new()
        {
            return (TPage)this;
        }

        public bool IsTextOnPage(string text)
        {
            return Driver.PageSource.Contains(text);
        }
    }
}
