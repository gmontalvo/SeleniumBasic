using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace RegistrationDemo.Tests.Base
{
    public abstract class CommonBase
    {
        public IWebDriver Driver { get; set; }

        public void ClearAndType(IWebElement element, string value)
        {
            element.Clear();
            element.SendKeys(value);
        }

        public void WaitUpTo(int milliseconds, Func<bool> Condition, string description)
        {
            int elapsed = 0;

            while (!Condition() && elapsed < milliseconds)
            {
                Thread.Sleep(100);
                elapsed += 100;
            }

            if (elapsed >= milliseconds || !Condition())
                throw new AssertionException("Timed out while waiting for: " + description);
        }

        public static void AssertIsEqual(string expected, string actual, string description)
        {
            if (expected != actual)
                throw new AssertionException(String.Format("AssertIsEqual Failed: '{0}' didn't match expectations. Expected [{1}], Actual [{2}]", description, expected, actual));
        }

        public static bool IsElementPresent(IWebElement element)
        {
            try
            {
                bool b = element.Displayed;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void AssertElementPresent(IWebElement element, string description)
        {
            if (!IsElementPresent(element))
                throw new AssertionException(String.Format("AssertElementPresent Failed: Could not find '{0}'", description));
        }

        public static bool IsElementPresent(ISearchContext context, By searchBy)
        {
            try
            {
                bool b = context.FindElement(searchBy).Displayed;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void AssertElementPresent(ISearchContext context, By searchBy, string description)
        {
            if (!IsElementPresent(context, searchBy))
                throw new AssertionException(String.Format("AssertElementPresent Failed: Could not find '{0}'", description));
        }

        public static void AssertElementsPresent(IWebElement[] elements, string description)
        {
            if (elements.Length == 0)
                throw new AssertionException(String.Format("AssertElementsPresent Failed: Could not find '{0}'", description));
        }

        public static void AssertElementText(IWebElement element, string expected, string description)
        {
            AssertElementPresent(element, description);

            if (string.Compare(element.Text, expected) != 0)
                throw new AssertionException(String.Format("AssertElementText Failed: Value for '{0}' did not match expectations. Expected: [{1}], Actual: [{2}]", description, expected, element.Text));
        }
    }
}
