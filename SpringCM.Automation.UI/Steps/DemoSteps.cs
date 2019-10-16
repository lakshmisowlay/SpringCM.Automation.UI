using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpringCM.Automation.UI.Steps
{
    [Binding, Scope(Feature = "Demo")]
    public class DemoSteps: BaseSteps
    {

        public DemoSteps(FeatureContext featureContext) : base(featureContext)
        {
        }

        [Given(@"The '(.*)' is dispalyed in search results")]
        public void GivenTheIsDispalyedInSearchResults(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I click on '(.*)'Contract management Software \| SpringCM' link")]
        public void WhenIClickOnContractManagementSoftwareSpringCMLink(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The Contract Management page is displayed")]
        public void ThenTheContractManagementPageIsDisplayed()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I click on the '(.*)' button")]
        public void WhenIClickOnTheButton(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The Contract Management Demo page is displayed")]
        public void ThenTheContractManagementDemoPageIsDisplayed()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The validation messages are displayed")]
        public void ThenTheValidationMessagesAreDisplayed()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I fill in the required fields and click '(.*)' button")]
        public void WhenIFillInTheRequiredFieldsAndClickButton(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The video player for the product demo displayed")]
        public void ThenTheVideoPlayerForTheProductDemoDisplayed()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
