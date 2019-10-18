using OpenQA.Selenium;
using SpringCM.Automation.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpringCM.Automation.Core
{
    public class SpringCMApplication
    {
        public IPage CurrentPage => GetCurrentPage();

        private static string BaseUrl => ApplicationConfigManager.Instance.GetConfig("base_url");
        private static string Browser => ApplicationConfigManager.Instance.GetConfig("browser");
        private IWebDriver _webDriver;
        private Dictionary<Pages, string> _pages;

        public SpringCMApplication()
        {
            var implicitWait = int.Parse(ApplicationConfigManager.Instance.GetConfig("implicit_wait_in_ms"));
            var pageWait = int.Parse(ApplicationConfigManager.Instance.GetConfig("page_wait_in_ms"));

            _webDriver = DriverFactory.Instance.GetDriver(Browser);
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(implicitWait);
            _webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromMilliseconds(pageWait);

            InitializePageRoutes();
        }

        private void InitializePageRoutes()
        {
            //TODO: Move to routes.json
            _pages = new Dictionary<Pages, string>
            {
                {Pages.Home, BaseUrl},
                {Pages.Demo, BaseUrl + "video-springcm-in-action-demo-lp"},
                {Pages.ResourceLibrary, BaseUrl + "resources"},
                {Pages.SearchResult, BaseUrl + "hs-search-results" },
                {Pages.ContractManagement, BaseUrl+"products/contract-management" },
                {Pages.Video,BaseUrl+"video-see-springcm-in-action-thank-you" }
            };
        }

        public IPage GoTo(Pages page, bool waitForPageLoad = false)
        {
            var url = _pages[page];

            var uri = new Uri(url);
            if (_webDriver.Url != url)
            {
                _webDriver.Navigate().GoToUrl(uri);
            }

            AcceptCookiesDialog(true);

            return GetPage(page);
        }

        private void AcceptCookiesDialog(bool accept)
        {
            if (accept)
            {
                _webDriver.FindElement(By.Id("hs-eu-confirmation-button")).Click();
            }
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
                case Pages.ContractManagement:
                    return new ContractManagementPage(_webDriver);
                case Pages.Video:
                    return new VideoPage(_webDriver);
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
            var hasParameters = currentUrl.IndexOf("?") > 0;
            var urlWithoutQueryString = hasParameters ? currentUrl.Substring(0, currentUrl.IndexOf("?")) : currentUrl;
            var page = _pages.FirstOrDefault(p => p.Value == urlWithoutQueryString).Key;
            return GetPage(page);
        }

        public void SwitchToLatestHandle()
        {
            var count = _webDriver.WindowHandles.Count;
            if (count > 1)
            {
                var newHandle = _webDriver.WindowHandles[count - 1];
                if (newHandle != _webDriver.CurrentWindowHandle)
                {
                    _webDriver = _webDriver.SwitchTo().Window(newHandle);
                }
            }
        }
    }
}
