using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;

namespace AutomationPractice.BaseClass
{
    public class PageBase
    {

        private IWebDriver driver;

        [FindsBy(How = How.LinkText, Using = "Home")]
        private IWebElement HomeLink;


        public PageBase(IWebDriver _driver)
        {
            PageFactory.InitElements(_driver, this);
            this.driver = _driver;

        }

        public static string generateRandomStringForGivenLength(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 1; i < size + 1; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            else
                return builder.ToString();
        }

        public void JSClick(IWebElement element)
        {
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;

            if (js != null)
            {
                js.ExecuteScript("arguments[0].click();", element);
            }
        }

        [TearDown]
        public void Teardown()
        {
            driver?.Quit();
        }

    }

}