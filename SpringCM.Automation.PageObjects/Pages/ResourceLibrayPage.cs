using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace SpringCM.Automation.PageObjects
{
    public class ResourceLibrayPage : BasePage
    {
        private IWebElement MeadiaTypesDropDown => GetByLinkText("Media Types");

        public ResourceLibrayPage(IWebDriver webDriver) : base(webDriver)
        {
            PageIdentifier = "Resources";
        }

        public bool DropdownPresent(string dropDown)
        {
            if (dropDown == "Media Types")
            {
                return MeadiaTypesDropDown.Displayed;
            }

            return false;
        }

        public void SelectOption(string dropdown, string option)
        {
            MeadiaTypesDropDown.Click();
            var parentNode = MeadiaTypesDropDown.FindElement(By.XPath("./.."));
            var optionLink = parentNode.FindElement(By.LinkText(option));
            optionLink.Click();
        }

        public List<RecourceContent> GetResourceContents()
        {
            var resourceContents = new List<RecourceContent>();
            var portfolioItems = WebDriver.FindElements(By.ClassName("portfolio-item"));
            foreach (var portfolioItem in portfolioItems.Where(p => p.Displayed))
            {
                resourceContents.Add(new RecourceContent
                {
                    Title = portfolioItem.FindElement(By.TagName("h4")).Text,
                    Link = portfolioItem.FindElement(By.TagName("a")).GetAttribute("href"),
                    ContentType = portfolioItem.FindElement(By.TagName("p")).Text
                });
            }

            return resourceContents;
        }
    }

    public class RecourceContent
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string ContentType { get; set; }
    }
}