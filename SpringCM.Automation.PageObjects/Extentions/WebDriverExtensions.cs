using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SpringCM.Automation.PageObjects
{
    public static class WebDriverExtensions
    {
        private static WebDriverWait wait;

        /// <summary>
        /// Initializes wait for driver
        /// </summary>
        /// <param name="driver"></param>
        /// <returns>Updated Webdriver</returns>
        public static IWebDriver Wait(this IWebDriver driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            return driver;
        }

        /// <summary>
        /// Adds duration for wait
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="timeout"></param>
        /// <returns>Updated Webdriver</returns>
        public static IWebDriver ForDuration(this IWebDriver driver, TimeSpan timeout)
        {
            wait.Timeout = timeout;
            return driver;
        }

        /// <summary>
        /// Checks for element
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="locator"></param>
        /// <returns>Updated Webdriver</returns>
        public static IWebDriver ForElementIsVisible(this IWebDriver driver, By locator)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
            return driver;
        }

        public static IWebDriver ForElementIsClickable(this IWebDriver driver, By locator)
        {
            wait.Until(ExpectedConditions.ElementIsClickable(locator));
            return driver;
        }
        public static void ScrollToBottom(this IWebDriver driver)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
        }
       
    }
}