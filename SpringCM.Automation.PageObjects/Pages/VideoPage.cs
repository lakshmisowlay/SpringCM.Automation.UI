using OpenQA.Selenium;

namespace SpringCM.Automation.PageObjects
{
    public class VideoPage : BasePage
    {
        public bool VideoDispalyed => GetById("w-vulcan-v2-30",1000).Displayed;

        public VideoPage(IWebDriver webDriver) : base(webDriver)
        {
            PageIdentifier = "Video";
        }

    }
}