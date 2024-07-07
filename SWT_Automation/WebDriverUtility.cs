using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace Ecommerce_Automation
{
    public static class WebDriverUtility
    {
        private static IWebDriver _webDriver;

        public static void Initialize()
        {
            _webDriver = new EdgeDriver();
        }

        public static IWebDriver GetDriver()
        {
            if (_webDriver == null)
            {
                Initialize();
            }
            return _webDriver;
        }

        public static void QuitDriver()
        {
            if (_webDriver != null)
            {
                _webDriver.Quit();
                _webDriver = null;
            }
        }
    }
}
