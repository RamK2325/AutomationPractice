using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace AutomationPractice.StepDefinitions
{
    [Binding]
    public  class LoginPageStepDefinition
    {
        const string EmailAddress = "test121239@test.com";
        const string Password = "Welcome1";

        private IWebDriver _driver;


        [Given(@"I am on the automation practice page")]
        public void GivenIAmOnTheAutomationPracticePage()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(ConfigurationSettings.AppSettings["Website"]);
        }


        [Given(@"I click on Sign in button")]
        public void GivenIClickOnSignInButton()
        {
            var signIn = _driver.FindElement(By.XPath("/html/body/div/div[1]/header/div[2]/div/div/nav/div[1]/a"));
            signIn.Click();
        }

        [Then(@"I enter Email address")]
        public void ThenIEnterEmailAddress()
        {
            var userName= _driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/div/div[2]/form/div/div[1]/input"));
            userName.SendKeys(EmailAddress);
        }


        [Then(@"I enter my Password")]
        public void ThenIEnterMyPassword()
        {
            var password = _driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/div/div[2]/form/div/div[2]/span/input"));
            password.SendKeys(Password);
        }

        [Then(@"I click on Sign in Button")]
        public void ThenIClickOnSignInButton()
        {
            var SignInBtn = _driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/div/div[2]/form/div/p[2]/button"));
            SignInBtn.Click();
            _driver.Quit();
        }


    }
}
