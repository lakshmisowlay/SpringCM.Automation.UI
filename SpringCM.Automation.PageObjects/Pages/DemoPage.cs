using OpenQA.Selenium;
using System.Collections.Generic;

namespace SpringCM.Automation.PageObjects
{
    public class DemoPage : BasePage
    {
        private IWebElement PlayDemoButton => GetByCss("input[type=submit]");
        private readonly VideoForm _videoForm;


        public DemoPage(IWebDriver webDriver) : base(webDriver)
        {
            Name = "Demo";
            _videoForm = new VideoForm(WebDriver);
        }

        public void PlayDemo()
        {
            PlayDemoButton.Click();
        }

        public void ClearForm()
        {
            _videoForm.ClearFields();
        }

        public string RequiredFieldValidationMessage()
        {
            return _videoForm.RequiredFieldValidationMessage;
        }

        public void FillFormAndPlay(UserInfo userInfo)
        {
            _videoForm.FirstName.SendKeys(userInfo.FirstName);
            _videoForm.LastName.SendKeys(userInfo.LastName);
            _videoForm.Email.SendKeys(userInfo.Email);
            _videoForm.Phone.SendKeys(userInfo.Phone);
            _videoForm.Company.SendKeys(userInfo.CompanyName);
            _videoForm.Country.SendKeys(userInfo.Country);

            PlayDemo();
        }
    }
}