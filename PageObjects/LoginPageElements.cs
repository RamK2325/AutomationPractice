using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using AutomationPractice.BaseClass;
using System.Threading;
using OpenQA.Selenium.Interactions;
using TechTalk.SpecFlow;

namespace AutomationPractice.PageObjects
{
    public class LoginPageElements : PageBase
    {
        private IWebDriver driver;

        public LoginPageElements(IWebDriver _driver)
            : base(_driver)
        {
            this.driver = _driver;
        }

        #region Login Page WebElement
        //[FindsBy(How = How.XPath, Using = "//span[contains(.,'')]")]
        //private IWebElement;

        //[FindsBy(How = How.XPath, Using = "//span[contains(.,'')]")]
        //private IWebElement;

        #endregion
    }
}
