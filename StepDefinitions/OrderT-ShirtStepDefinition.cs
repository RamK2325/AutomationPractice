using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using AutomationPractice.BaseClass;
using System.Threading;
using OpenQA.Selenium.Interactions;
using System.Drawing.Imaging;

namespace AutomationPractice.StepDefinitions
{
    [Binding]
    public  class OrderT_ShirtStepDefinition 
    {
        const string EmailAddress = "test121239@test.com";
        const string Password = "Welcome1";


        private IWebDriver _driver;

   
        [Given(@"I am on the Signin Page")]
        public void GivenIAmOnTheSigninPage()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(ConfigurationSettings.AppSettings["Website"]);
        }

        [Given(@"I click on Signin")]
        public void GivenIClickOnSignin()
        {
            var signIn = _driver.FindElement(By.XPath("/html/body/div/div[1]/header/div[2]/div/div/nav/div[1]/a"));
            signIn.Click();
            Thread.Sleep(3000);
        }

        [Given(@"I enter email address and password")]
        public void GivenIEnterEmailAddressAndPassword()
        {
            var userName = _driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/div/div[2]/form/div/div[1]/input"));
            userName.SendKeys(EmailAddress);
            Thread.Sleep(2000);
            var password = _driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/div/div[2]/form/div/div[2]/span/input"));
            password.SendKeys(Password);
            Thread.Sleep(3000);
        }

        [When(@"I click on login")]
        public void WhenIClickOnLogin()
        {
            var SignInBtn = _driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/div/div[2]/form/div/p[2]/button"));
            SignInBtn.Click();
            Thread.Sleep(3000);
        }

        [Then(@"I click on t-shirts")]
        public void ThenIClickOnT_Shirts()
        {
            var tshirts = _driver.FindElement(By.XPath("/html/body/div/div[1]/header/div[3]/div/div/div[6]/ul/li[3]/a"));
            tshirts.Click();
            Thread.Sleep(3000);
         
        }
        [Then(@"click on tshirt image")]
        public void ThenClickOnTshirtImage()
        {
            var tshirtsimage = _driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div[2]/ul/li/div/div[1]/div/a[1]/img"));
            tshirtsimage.Click();
            Thread.Sleep(3000);
        }

        [Then(@"click on Add to cart")]
        public void ThenClickOnAddToCart()
        {
            _driver.SwitchTo().Frame(0);
            Actions action = new Actions(_driver);
            var addtocart = _driver.FindElement(By.XPath("/html/body/div/div/div[3]/form/div/div[3]/div[1]/p/button"));
            action.MoveToElement(addtocart).Click().Perform(); 
            Thread.Sleep(4000);
        }

        [Then(@"Proceed to checkout")]
        public void ThenProceedToCheckout()
        {
            Actions action = new Actions(_driver);
            var proceedtocheckout = _driver.FindElement(By.XPath("/html/body/div/div[1]/header/div[3]/div/div/div[4]/div[1]/div[2]/div[4]/a"));
            action.MoveToElement(proceedtocheckout).Click().Perform();
            Thread.Sleep(3000);
            var proceedtocheckout1 = _driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/p[2]/a[1]"));
            proceedtocheckout1.Click();
            Thread.Sleep(3000);
            var proceedtocheckout2 = _driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/form/p/button"));
            proceedtocheckout2.Click();
            Thread.Sleep(3000);
            var tickterms = _driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/div/form/div/p[2]/div/span/input"));
            tickterms.Click();
            Thread.Sleep(3000);
            var proceedtocheckout3 = _driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/div/form/p/button"));
            proceedtocheckout3.Click();
            Thread.Sleep(3000);
        }

        [Then(@"Proceed to Payment")]
        public void ThenProceedToPayment()
        {
            var paymenttab = _driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/div/div[3]/div[1]/div/p/a"));
            paymenttab.Click();
            Thread.Sleep(4000);

            var confirmpayment = _driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/form/p/button"));
            confirmpayment.Click();
            Thread.Sleep(3000);
        }

        [Then(@"Take a screenshot")]
        public void ThenTakeAScreenshot()
        {
            string path1 = AppDomain.CurrentDomain.BaseDirectory.Replace("/bin/Debug", "");
            string path = path1 + DateTime.UtcNow.ToString("yyyy-MM-dd-hh-mm-ss") + ".jpeg";
            Screenshot screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
            screenshot.SaveAsFile(path, ScreenshotImageFormat.Jpeg);
        }


        [Then(@"I Click on logOut")]
        public void ThenIClickOnLogOut()
        {
    
            var logout = _driver.FindElement(By.XPath("/html/body/div/div[1]/header/div[2]/div/div/nav/div[2]/a"));
            logout.Click();
            Thread.Sleep(2000);
            _driver.Quit();
        }



    }
}
