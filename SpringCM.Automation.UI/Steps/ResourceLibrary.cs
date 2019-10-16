using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpringCM.Automation.UI.Steps
{
    [Binding, Scope(Feature = "ResourceLibrary")]
    public class ResourceLibrary: BaseSteps
    {

        public ResourceLibrary(FeatureContext featureContext) : base(featureContext)
        {
        }

        [Given(@"I have the application running")]
        public void GivenIHaveTheApplicationRunning()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I select the '(.*)' menu")]
        public void WhenISelectTheMenu(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The '(.*)' menu is displayed")]
        public void ThenTheMenuIsDisplayed(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I select the '(.*)' sub menu from the '(.*)' menu")]
        public void WhenISelectTheSubMenuFromTheMenu(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The defualt page content is displayed on the '(.*)' page")]
        public void ThenTheDefualtPageContentIsDisplayedOnThePage(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The '(.*)' dropdown list is displayed")]
        public void ThenTheDropdownListIsDisplayed(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I select '(.*)' from the '(.*)' dropdown list")]
        public void WhenISelectFromTheDropdownList(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The report content is displayed on the '(.*)' page")]
        public void ThenTheReportContentIsDisplayedOnThePage(string p0)
        {
            ScenarioContext.Current.Pending();
        }

    }
}
