using OpenQA.Selenium;

namespace SpringCM.Automation.PageObjects
{
    public class SearchResultPage : BasePage
    {

        public SearchResultPage(IWebDriver webDriver) : base(webDriver)
        {
        }

        public bool HasResults(string linkText)
        {
            var lnkResult = GetByLinkText(linkText);
            return lnkResult.Displayed;
        }
    }
}