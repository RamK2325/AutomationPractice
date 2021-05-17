using AutomationPractice.BaseClass;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace AutomationPractice.StepDefinitions
{
    [Binding]
    public  class CreateNewAccountStepDefinition 
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef


        private IWebDriver _driver;

        #region TestData

        const string FirstName = "Audi";
        const string LastName = "A";
        const string EmailAddress = "test121239@test.com";
        const string Password = "Welcome1";
        const string Address = "12 London Road";
        const string City = "london";
        const string State = "Alaska";
        const string PostCode = "00000";
        const string Mobile = "07889865432";
        string randomString = PageBase.generateRandomStringForGivenLength(5, true);
        #endregion

        public CreateNewAccountStepDefinition()
        {
           
        }

        [Given(@"i am on the webpage")]
        public void GivenIAmOnTheWebpage()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(ConfigurationSettings.AppSettings["Website"]);
        }

        [Given(@"I click on sign in button")]
        public void GivenIClickOnSignInButton()
        {
           var signIn = _driver.FindElement(By.XPath("/html/body/div/div[1]/header/div[2]/div/div/nav/div[1]/a"));
            signIn.Click();
        }

        [Then(@"I enter email address under create an account field")]
        public void ThenIEnterEmailAddressUnderCreateAnAccountField()
        {
            var enterEmail = _driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/div/div[1]/form/div/div[2]/input"));
            enterEmail.SendKeys("FirstName"+randomString+"@test.com");
            Thread.Sleep(3000);
        }

        [Then(@"I click on Create an Account button")]
        public void ThenIClickOnCreateAnAccountButton()
        {
            var createAccount = _driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/div/div[1]/form/div/div[3]/button"));
            createAccount.Click();
            Thread.Sleep(3000);
        }

        [Then(@"I update Personal information")]
        public void ThenIUpdatePersonalInformation()
        {
            
            var title = _driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/div/form/div[1]/div[1]/div[1]/label/div/span/input"));
            title.Click();
            Thread.Sleep(3000);


            var firstName = _driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/div/form/div[1]/div[2]/input"));
            firstName.SendKeys(FirstName);
            Thread.Sleep(3000);

            var lastName = _driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/div/form/div[1]/div[3]/input"));
            lastName.SendKeys(LastName);
            Thread.Sleep(3000);

            var password = _driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/div/form/div[1]/div[5]/input"));
            password.SendKeys(Password);
            Thread.Sleep(3000);


        }

        [Then(@"I update Address information")]
        public void ThenIUpdateAddressInformation()
        {
            var address = _driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/div/form/div[2]/p[4]/input"));
            address.SendKeys(Address);
            Thread.Sleep(3000);

            var city = _driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/div/form/div[2]/p[6]/input"));
            city.SendKeys(City);
            Thread.Sleep(3000);

            var state = _driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/div/form/div[2]/p[7]/div/select"));
            var selectElement = new SelectElement(state);
            //select by value
            selectElement.SelectByText(State);
            Thread.Sleep(3000);

            var postcode = _driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/div/form/div[2]/p[8]/input"));
            postcode.SendKeys(PostCode);
            Thread.Sleep(3000);


            var mobile = _driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/div/form/div[2]/p[13]/input"));
            mobile.SendKeys(Mobile);
            Thread.Sleep(3000);
        }

        [Then(@"I click on Register Button")]
        public void ThenIClickOnRegisterButton()
        {
            var register = _driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/div/form/div[4]/button"));
            register.Click();
            _driver.Quit();
        }

    }
}
