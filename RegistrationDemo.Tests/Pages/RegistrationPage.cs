using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using RegistrationDemo.Tests.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationDemo.Tests.Pages
{
    class RegistrationPage : PageBase
    {
        public override string DefaultTitle
        {
            get { return "Register - My ASP.NET Application"; }
        }

        [FindsBy(How = How.Id, Using = "Email")]
        public IWebElement Email;

        internal void PopulateEmailTextBox(string email)
        {
            Email.SendKeys(email);
        }

        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement Password;

        internal void PopulatePasswordTextBox(string name)
        {
            Password.SendKeys(name);
        }

        [FindsBy(How = How.Id, Using = "ConfirmPassword")]
        public IWebElement ConfirmPassword;

        internal void PopulateConfirmPasswordTextBox(string confirm)
        {
            ConfirmPassword.SendKeys(confirm);
        }

        [FindsBy(How = How.XPath, Using = "//input[@type='submit']")]
        public IWebElement SubmitButton;

        internal PageBase SubmitForm()
        {
            SubmitButton.Click();
            PageBase page;

            try
            {
                page = GetInstance<IndexPage>(Driver);
            }
            catch
            {
                page = GetInstance<RegistrationPage>(Driver);
            }

            return page;
        }
    }
}
