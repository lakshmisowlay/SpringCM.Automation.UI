using OpenQA.Selenium;
using SpringCM.Automation.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpringCM.Automation.Core
{
    public class SpringCMApplication
    {
        private static string BaseUrl => ApplicationConfigManager.Instance.GetConfig("base_url");

        private static string Browser => ApplicationConfigManager.Instance.GetConfig("browser");
        public IPage CurrentPage => GetCurrentPage();

        

        private readonly IWebDriver _webDriver;
        private Dictionary<Pages, string> _pages;

        public SpringCMApplication()
        {
            var implicitWait = int.Parse(ApplicationConfigManager.Instance.GetConfig("implicit_wait_in_ms"));
            var pageWait = int.Parse(ApplicationConfigManager.Instance.GetConfig("page_wait_in_ms"));
            _webDriver = DriverFactory.Instance.GetDriver(Browser);
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(implicitWait);
            _webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromMilliseconds(pageWait);
            InitializePages();
        }

        private void InitializePages()
        {
            _pages = new Dictionary<Pages, string>
            {
                {Pages.Home, BaseUrl},
                {Pages.Demo, BaseUrl},
                {Pages.ResourceLibrary, BaseUrl + "resources"}
            };
        }

        public IPage GoTo(Pages page, bool waitForPageLoad = false)
        {
            var url = _pages.First(p => p.Key == page).Value;
            var uri = new Uri(url);
            if (_webDriver.Url != url)
            {
                _webDriver.Navigate().GoToUrl(uri);
            }

            return GetPage(page);
        }

        public IPage GetPage(Pages page)
        {
            switch (page)
            {
                case Pages.Home:
                    return new HomePage(_webDriver);
                case Pages.Demo:
                    return new DemoPage(_webDriver);
                case Pages.ResourceLibrary:
                    return new ResourceLibrayPage(_webDriver);
                case Pages.SearchResult:
                    return new SearchResultPage(_webDriver);
               
            }

            return null;
        }

        public void Exit()
        {
            _webDriver.Close();
            _webDriver.Quit();
        }

        private IPage GetCurrentPage()
        {
            var currentUrl = _webDriver.Url;
            string urlWithoutQueryString = currentUrl.Substring(0, currentUrl.IndexOf("?"));
            var page = _pages.FirstOrDefault(p => p.Value == currentUrl).Key;
            return GetPage(page);
        }
    }
}
