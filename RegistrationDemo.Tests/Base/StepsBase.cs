using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace RegistrationDemo.Tests.Base
{
    public class StepsBase : TestFixtureBase
    {
        protected PageBase NextPage { set { CurrentPage = value; } }

        protected PageBase CurrentPage
        {
            get { return (PageBase)ScenarioContext.Current["CurrentPage"]; }
            set { ScenarioContext.Current["CurrentPage"] = value; }
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            if (!ScenarioContext.Current.ContainsKey("CurrentDriver"))
            {
                Test_Setup();
                ScenarioContext.Current.Add("CurrentDriver", CurrentDriver);
            }
            else
            {
                CurrentDriver = (IWebDriver)ScenarioContext.Current["CurrentDriver"];
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (ScenarioContext.Current.ContainsKey("CurrentDriver"))
            {
                Test_Teardown();
                ScenarioContext.Current.Remove("CurrentDriver");
            }
        }
    }
}
