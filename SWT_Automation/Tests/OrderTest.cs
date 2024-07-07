using OpenQA.Selenium;
using System.Threading;
using TechTalk.SpecFlow;
using Ecommerce_Automation.Steps;

namespace Ecommerce_Automation.Tests
{
    [Binding]
    public class OrderTest
    {
        private readonly LoginTest _loginTest;


        public OrderTest(LoginTest loginTest)
        {
            _loginTest = loginTest;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            WebDriverUtility.Initialize(); // Khởi tạo WebDriver trước khi mỗi kịch bản bắt đầu
        }

        [Given(@"the user has logged in")]
        public void GivenTheUserHasLoggedIn()
        {
            _loginTest.SetUp();
            _loginTest.ImportAccount("Info.xlsx");
            _loginTest.Login();
            _loginTest.Submit();
        }

        [When(@"the user navigates to men's page")]
        public void NavigateMenPage()
        {
            WebDriverUtility.GetDriver().Navigate().GoToUrl("https://magento.softwaretestingboard.com");
            var field = WebDriverUtility.GetDriver().FindElement(By.XPath("//a[@id='ui-id-5']"));
            field.Click();
        }

        [When(@"user chooses an item")]
        public void ChooseItem()
        {
            var titleField = WebDriverUtility.GetDriver().FindElement(By.XPath("//body/div[@class='page-wrapper']/main[@id='maincontent']/div[@class='columns']/div[@class='column main']/div[@class='widget block block-static-block']/div[@class='block widget block-products-list grid']/div[@class='block-content']/div[@class='products-grid grid']/ol[@class='product-items widget-product-grid']/li[2]/div[1]/a[1]"));
            titleField.Click();

        }

        [When(@"user adds to cart")]
        public void AddToCart()
        {
            var size = WebDriverUtility.GetDriver().FindElement(By.XPath("//div[@id='option-label-size-143-item-168']"));
            var colour = WebDriverUtility.GetDriver().FindElement(By.XPath("//div[@id='option-label-color-93-item-49']"));
            var add = WebDriverUtility.GetDriver().FindElement(By.XPath("//button[@id='product-addtocart-button']"));
            size.Click();
            colour.Click();
            add.Click();
            Thread.Sleep(4000);
        }

        [Then(@"user places order")]
        public void PlaceOrder()
        {
            var cart = WebDriverUtility.GetDriver().FindElement(By.XPath("//a[@class='action showcart']"));
            cart.Click();
            var checkOut = WebDriverUtility.GetDriver().FindElement(By.XPath("//button[@id='top-cart-btn-checkout']"));
            checkOut.Click();
            Thread.Sleep(4000);
            WebDriverUtility.GetDriver().FindElement(By.XPath("//button[@class='action action-select-shipping-item']")).Click();
            Thread.Sleep(3000);
            WebDriverUtility.GetDriver().FindElement(By.XPath("//button[@class='button action continue primary']")).Click();
            Thread.Sleep(5000);
            WebDriverUtility.GetDriver().FindElement(By.XPath("//button[@title='Place Order']")).Click();
            Thread.Sleep(5000);
        }


        //WebDriverUtility.GetDriver().FindElement(By.XPath(""));
        [AfterScenario]
        public void AfterScenario()
        {
            WebDriverUtility.QuitDriver(); // Dọn dẹp WebDriver sau khi kết thúc mỗi kịch bản
        }


    }
}
