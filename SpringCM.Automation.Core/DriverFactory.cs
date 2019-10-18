using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace SpringCM.Automation.Core
{
    public sealed class DriverFactory
    {
        public static DriverFactory Instance { get; }

        static DriverFactory()
        {
            Instance = new DriverFactory();
        }

        private DriverFactory() { }

        public IWebDriver GetDriver(string browser)
        {
            switch (browser.ToLowerInvariant())
            {
                case "chrome":
                    return new ChromeDriver();
                case "firefox":
                    return new FirefoxDriver();
                case "ie":
                    return new InternetExplorerDriver();
            }

            return null;
        }
        
    }
}