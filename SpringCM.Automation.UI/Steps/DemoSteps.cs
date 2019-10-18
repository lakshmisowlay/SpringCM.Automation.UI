using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpringCM.Automation.PageObjects;
using TechTalk.SpecFlow;

namespace SpringCM.Automation.UI.Steps
{
    [Binding, Scope(Feature = "Demo")]
    public class DemoSteps : BaseSteps
    {
        private HomePage _homePage;
        private DemoPage _demoPage;

        public DemoSteps(FeatureContext featureContext) : base(featureContext)
        {
        }

        [Given(@"The application running")]
        public void GivenIHaveTheApplicationRunning()
        {
            _homePage = (HomePage)Application.GoTo(Pages.Home, true);

        }

        [Given(@"The '(.*)' is dispalyed in search results")]
        public void GivenTheIsDispalyedInSearchResults(string searchText)
        {
            _homePage.Search(searchText);
        }

        [When(@"I click on The '(.*)' result")]
        public void WhenIClickOnTheLink(string result)
        {
            _homePage.OpenSearchResultItem(result);
        }


        [Then(@"The '(.*)' page is displayed")]
        public void ThenTheContractManagementPageIsDisplayed(string pageName)
        {
            Assert.AreEqual(Application.CurrentPage.Name, pageName);
        }

        [When(@"I click on the Watch Our Product Demo button")]
        public void WhenIClickOnTheButton()
        {
            ((ContractManagementPage)Application.CurrentPage).OpenDemo();
        }

        [Then(@"The Contract Management Demo page is displayed")]
        public void ThenTheContractManagementDemoPageIsDisplayed()
        {
            Application.SwitchToLatestHandle();
            _demoPage = ((DemoPage)Application.CurrentPage);
            Assert.AreEqual(_demoPage.Name, "Demo");
        }

        [When(@"I play the demo by clearing the fields")]
        public void WhenIPlayTheDemo()
        {
            _demoPage.ClearForm();
            _demoPage.PlayDemo();
        }

        [Then(@"The validation messages are displayed")]
        public void ThenTheValidationMessagesAreDisplayed()
        {
            Assert.AreEqual(_demoPage.RequiredFieldValidationMessage(), $"Please complete this required field.");
        }

        [When(@"I fill in the required fields and play video")]
        public void WhenIFillInTheRequiredFieldsAndClickButton(Table fieldInfo)
        {
            UserInfo userInfo = new UserInfo
            {
                FirstName = fieldInfo.Rows[0]["FirstName"],
                LastName = fieldInfo.Rows[0]["LastName"],
                Email = fieldInfo.Rows[0]["Email"],
                Phone = fieldInfo.Rows[0]["Phone"],
                CompanyName = fieldInfo.Rows[0]["CompanyName"],
                Country = fieldInfo.Rows[0]["Country"]
            };
            _demoPage.FillFormAndPlay(userInfo);
        }

        [Then(@"The video player for the product demo displayed")]
        public void ThenTheVideoPlayerForTheProductDemoDisplayed()
        {
            Assert.IsTrue(((VideoPage)Application.CurrentPage).VideoDispalyed);
        }

    }


}
