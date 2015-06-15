using Baseclass.Contrib.SpecFlow.Selenium.NUnit.Bindings;
using OpenQA.Selenium;
using RegistrationDemo.Tests.Pages;
using System.Configuration;

namespace RegistrationDemo.Tests.Base
{
    public abstract partial class PageBase
    {
        public static string BaseUrl
        {
            get { return ConfigurationManager.AppSettings["seleniumBaseUrl"]; }
        }

        public static IndexPage LoadIndexPage(IWebDriver driver, string baseURL)
        {
            if (driver == null)
                driver = Browser.Current;

            driver.Navigate().GoToUrl(baseURL.TrimEnd(new char[] { '/' }) + IndexPage.URL);
            driver.Manage().Window.Maximize();

            return GetInstance<IndexPage>(driver, baseURL, string.Empty);
        }
    }
}
