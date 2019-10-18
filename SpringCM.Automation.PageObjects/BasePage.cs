using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;

namespace SpringCM.Automation.PageObjects
{
    public class BasePage : IPage
    {
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        public IWebDriver WebDriver { get; }

        public BasePage(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }

        public void ScrollToEnd()
        {
            WebDriver.ScrollToBottom();
        }

        protected IWebElement GetByLinkText(string linkText, int waitTimeInSeconds = 10)
        {
            try
            {
                return WebDriver.FindElement(By.LinkText(linkText));
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return default;
            }
        }
        protected IWebElement GetById(string automationId, int waitTimeInSeconds = 10)
        {
            try
            {
                return WebDriver.FindElement(By.Id(automationId));
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return default;
            }
        }
        protected IWebElement GetByCss(string cssSelector, int waitTimeInSeconds = 10)
        {
            try
            {
                return WebDriver.FindElement(By.CssSelector(cssSelector));
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return default;
            }
        }
        protected IWebElement GetByClass(string automationClass, int waitTimeInSeconds = 10)
        {
            try
            {
                return WebDriver.FindElement(By.ClassName(automationClass));
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return default;
            }
        }

        protected IWebElement GetByXPath(string xPath, int waitTimeInSeconds = 10)
        {
            try
            {
                return WebDriver.FindElement(By.XPath(xPath));
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return default;
            }
        }

        public void MouseHover(IWebElement menuItem)
        {
            Actions action = new Actions(WebDriver);
            action.MoveToElement(menuItem).Perform();
        }

        public string Name { get; set; }
    }
}
