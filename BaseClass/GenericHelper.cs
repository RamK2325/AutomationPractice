using System;
using System.Linq;
using System.Text;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.Diagnostics;
using OpenQA.Selenium;


namespace AutomationPractice.BaseClass
{
    public class GenericHelper
    {
        private static IWebDriver _driver;
        private static IWebDriver WebDriver;
        private static object ExceptionConditions;

        private static Func<IWebDriver, bool> WaitForWebElementFunc(By locator)
        {
            return ((x) =>
            {
                if (x.FindElements(locator).Count == 1)
                    return true;
                return false;
            });
        }

        public static void WaitForElementVisible(By locator, TimeSpan timeout)
        {
            var wait = new WebDriverWait(_driver, timeout);
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }


        private static Func<IWebDriver, IWebElement> WaitForWebElementInPageFunc(By locator)
        {
            return ((x) =>
            {
                if (x.FindElements(locator).Count == 1)
                    return x.FindElement(locator);
                return null;
            });
        }

       
    }
}




          