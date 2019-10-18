using OpenQA.Selenium;

namespace SpringCM.Automation.PageObjects
{
    public class HomePage : BasePage
    {
        private IWebElement BtnSearch => GetByCss(".span10 > #slide-menu .fa");
        private IWebElement TxtSearchField => GetByXPath("(//input[@name='term'])[2]");

        public HomePage(IWebDriver webDriver) : base(webDriver)
        {
            Name = "Home";
        }

        public string SearchFieldPlaceholder => TxtSearchField.GetProperty("placeholder");
        public string SearchText => TxtSearchField.GetProperty("value");


        public void OpenSearchField()
        {
            BtnSearch.Click();
        }

        public void Search(string searchText)
        {
            TxtSearchField.SendKeys(searchText);
            TxtSearchField.SendKeys(Keys.Enter);
        }

        public void OpenMenuItem(string item)
        {
            var menuItem = WebDriver.FindElement(By.LinkText(item));
            MouseHover(menuItem);
        }

        public bool MenuItemDispalyed(string item)
        {
            var menuItem = WebDriver.FindElement(By.LinkText(item));
            return menuItem.Displayed;
        }

        public void SelectSubMenu(string mainMenuItem, string subMenuItem)
        {
            OpenMenuItem(mainMenuItem);
            WebDriver.FindElement(By.LinkText(subMenuItem)).Click();
        }

        public void OpenSearchResultItem(string resultItem)
        {
            WebDriver.FindElement(By.LinkText(resultItem)).Click();
        }
    }
}