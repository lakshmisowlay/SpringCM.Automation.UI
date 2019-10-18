using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;

namespace SpringCM.Automation.PageObjects
{
    public class BasePage : IPage
    {
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        public string PageIdentifier { get; set; }
        public IWebDriver WebDriver { get; }

        public BasePage(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }

        public void ScrollToEnd()
        {
            //WebDriver.ScrollToBottom();
        }
        public void MouseHover(IWebElement menuItem)
        {
            Actions action = new Actions(WebDriver);
            action.MoveToElement(menuItem).Perform();
        }

        protected IWebElement GetByLinkText(string linkText)
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
        protected IWebElement GetById(string automationId)
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
        protected IWebElement GetByCss(string cssSelector)
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
        protected IWebElement GetByXPath(string xPath)
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
    }
}
