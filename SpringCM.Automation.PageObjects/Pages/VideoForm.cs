using OpenQA.Selenium;

namespace SpringCM.Automation.PageObjects
{
    internal class VideoForm
    {
        private readonly IWebDriver _driver;
        public IWebElement FirstName => _driver.FindElement(By.Name("firstname"));
        public IWebElement LastName => _driver.FindElement(By.Name("lastname"));
        public IWebElement Email => _driver.FindElement(By.Name("email"));
        public IWebElement Phone => _driver.FindElement(By.Name("phone"));
        public IWebElement Company => _driver.FindElement(By.Name("company"));
        public IWebElement Country => _driver.FindElement(By.Name("country"));
        public string RequiredFieldValidationMessage => _driver.FindElement(By.ClassName("hs-error-msg")).Text;

        public VideoForm(IWebDriver driver)
        {
            _driver = driver;
        }

        public void ClearFields()
        {
            FirstName.Clear();
            LastName.Clear();
            Email.Clear();
            Phone.Clear();
            Company.Clear();
            Country.Clear();
        }

      
    }
}