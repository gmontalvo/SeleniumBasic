using Baseclass.Contrib.SpecFlow.Selenium.NUnit.Bindings;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Drawing.Imaging;

namespace RegistrationDemo.Tests.Base
{
    public class TestFixtureBase
    {
        protected IWebDriver CurrentDriver { get; set; }

        [SetUp]
        public void Test_Setup()
        {
            try { CurrentDriver = Browser.Current; } catch { }
        }

        [TearDown]
        public void Test_Teardown()
        {
            try
            {
                if (TestContext.CurrentContext.Result.Status == TestStatus.Failed && CurrentDriver is ITakesScreenshot)
                    ((ITakesScreenshot)CurrentDriver).GetScreenshot().SaveAsFile(TestContext.CurrentContext.Test.FullName + ".jpg", ImageFormat.Jpeg);
            }
            catch
            {
            }

            try
            {
                CurrentDriver.Quit();
                CurrentDriver.Dispose();
            }
            catch
            {
            }
        }
    }
}
