using NUnit.Framework;
using OpenQA.Selenium;
using Ecommerce_Automation;
using TechTalk.SpecFlow;

namespace Ecommerce_Automation.Steps
{
    [Binding]
    public class LoginTest
    {
        private string username;
        private string password;

        [BeforeScenario]
        public void BeforeScenario()
        {
            WebDriverUtility.Initialize();
        }


        [Given(@"the user navigates to the login page")]
        public void SetUp()
        {
            WebDriverUtility.GetDriver().Navigate().GoToUrl("https://magento.softwaretestingboard.com");
            WebDriverUtility.GetDriver().FindElement(By.XPath("//div[@class='panel header']//a[contains(text(),'Sign In')]")).Click();
        }

        [Given(@"the user has valid credentials from file ""(.*)""")]
        public void ImportAccount(string filePath)
        {
            var credentials = ExcelReader.ReadExcel(filePath);
            foreach (var credential in credentials)
            {
                username = credential[0].ToString();
                password = credential[1].ToString();
            }
        }

        [When(@"the user enters valid credentials")]
        public void Login()
        {
            var usernameField = WebDriverUtility.GetDriver().FindElement(By.XPath("//input[@id='email']"));
            var passwordField = WebDriverUtility.GetDriver().FindElement(By.XPath("//input[@id='pass']"));
            usernameField.SendKeys(username);
            passwordField.SendKeys(password);
        }

        [When(@"the user submits the login form")]
        public void Submit() 
        {
            WebDriverUtility.GetDriver().FindElement(By.XPath("//fieldset[@class='fieldset login']//button[@id='send2']")).Click();
        }

        [Then(@"the user should be redirected to the homepage")]
        public void HomePage()
        {
            var currentUrl = WebDriverUtility.GetDriver().Url;
            Assert.AreEqual("https://magento.softwaretestingboard.com/", currentUrl);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            WebDriverUtility.QuitDriver();
        }
    }
}
