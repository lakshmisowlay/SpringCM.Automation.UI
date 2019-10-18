using OpenQA.Selenium;

namespace SpringCM.Automation.PageObjects
{
    public class ContractManagementPage : BasePage
    {
        private IWebElement DemoLink => GetByLinkText("WATCH OUR PRODUCT DEMO");
        public ContractManagementPage(IWebDriver webDriver) : base(webDriver)
        {
            PageIdentifier = "Contract Management";
        }

        public void OpenDemo()
        {
            DemoLink.Click();
        }
    }
}