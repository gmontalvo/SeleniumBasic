using RegistrationDemo.Tests.Base;
using RegistrationDemo.Tests.Pages;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace RegistrationDemo.Tests.Steps
{
    [Binding]
    public class UserRegsitration : StepsBase
    {
        [Given(@"I am on the home page")]
        public void GivenIAmOnTheHomePage()
        {
            CurrentPage = (PageBase)PageBase.LoadIndexPage(CurrentDriver, PageBase.BaseUrl);
        }

        [Given(@"I am not logged in")]
        public void GivenIAmNotLoggedIn()
        {
            CurrentPage.As<IndexPage>().IsLoginLinkAvailable();
        }

        [When(@"I click the register button")]
        public void WhenIClickTheRegisterButton()
        {
            NextPage = CurrentPage.As<IndexPage>().ClickRegisterLink();
        }

        [When(@"fill of the registration form with the following details")]
        public void WhenFillOfTheRegistrationFormWithTheFollowingDetails(Table table)
        {
            // used to obtain form data from gherkin
            dynamic form = table.CreateDynamicInstance();

            // insert a random value between 0 and 9999, so multiple runs
            // of the test are less likely to incur name collisions
            Random random = new Random(DateTime.Now.Second + DateTime.Now.Minute);
            string user = string.Format(form.UserName, Convert.ToString(random.Next(0, 9999)));

            CurrentPage.As<RegistrationPage>().PopulateEmailTextBox(user);
            CurrentPage.As<RegistrationPage>().PopulatePasswordTextBox(form.Password);
            CurrentPage.As<RegistrationPage>().PopulateConfirmPasswordTextBox(form.ConfirmPassword);
        }

        [When(@"I submit the form")]
        public void WhenISubmitTheForm()
        {
            CurrentPage = CurrentPage.As<RegistrationPage>().SubmitForm();
        }

        [Then(@"I am redirected to the home page")]
        public void ThenIRedirectedToTheHomePage()
        {
            CurrentPage.Is<IndexPage>();
        }

        [Then(@"I will be logged in")]
        public void ThenIWillBeLoggedIn()
        {
            CurrentPage.As<IndexPage>().IsLoginLinkAvailable();
        }

        [Then(@"I will see the message (.*)")]
        public void ThenIWillSeeTheMessage(string message)
        {
            CurrentPage.IsTextOnPage(message);
        }
    }
}
