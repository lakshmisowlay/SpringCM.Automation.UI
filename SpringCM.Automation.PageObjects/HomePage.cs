using OpenQA.Selenium;

namespace SpringCM.Automation.PageObjects
{
    public class HomePage : BasePage
    {
        private IWebElement BtnSearch => GetByClass("fa fa-search");
        private IWebElement TxtSearchField => GetByClass("hs-search-field__input");

        public HomePage(IWebDriver webDriver) : base(webDriver)
        {

        }

        public string SearchFieldPlaceholder => TxtSearchField.GetProperty("Placeholder");
        public string SearchText => TxtSearchField.Text;


        public void OpenSearchField()
        {
            BtnSearch.Click();
        }

        public void Search(string searchText)
        {
            TxtSearchField.SendKeys(searchText);
            TxtSearchField.SendKeys(Keys.Enter);
        }
    }
}