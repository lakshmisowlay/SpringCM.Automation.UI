using OpenQA.Selenium;

namespace SpringCM.Automation.PageObjects
{
    public class VideoPage : BasePage
    {
        public bool VideoDispalyed => GetById("w-vulcan-v2-30").Displayed;

        public VideoPage(IWebDriver webDriver) : base(webDriver)
        {
            Name = "Video";
        }

    }
}