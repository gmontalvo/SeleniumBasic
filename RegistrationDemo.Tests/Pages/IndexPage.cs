using NUnit.Framework;
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
    public class IndexPage : PageBase
    {
        public static string URL = "/";
        public override string DefaultTitle
        {
            get { return "Home Page - My ASP.NET Application"; }
        }

        [FindsBy(How = How.Id, Using = "loginLink")]
        public IWebElement LoginLink;

        internal void IsLoginLinkAvailable()
        {
            if (LoginLink == null)
                throw new Exception("Unable to find the login link on the page");

            AssertElementText(LoginLink, "Log in", "login link");
        }

        [FindsBy(How = How.LinkText, Using = "Log off")]
        public IWebElement LogoutLink;

        internal void IsLogoutLinkAvaliable()
        {
            if (LogoutLink == null)
                throw new Exception("Unable to find the logout link on the page");

            Assert.AreEqual("Log off", LogoutLink.Text);
        }

        [FindsBy(How = How.Id, Using = "registerLink")]
        public IWebElement RegisterLink;

        internal RegistrationPage ClickRegisterLink()
        {
            RegisterLink.Click();
            return GetInstance<RegistrationPage>(Driver);
        }
    }
}
