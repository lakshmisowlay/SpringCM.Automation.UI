using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpringCM.Automation.PageObjects;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpringCM.Automation.UI.Steps
{
    [Binding, Scope(Feature = "ResourceLibrary")]
    public class ResourceLibrary : BaseSteps
    {
        private HomePage _homePage;

        public ResourceLibrary(FeatureContext featureContext) : base(featureContext)
        {
        }

        [Given(@"I have the application running")]
        public void GivenIHaveTheApplicationRunning()
        {
            _homePage = (HomePage)Application.GoTo(Pages.Home);
        }

        [When(@"I select the '(.*)' from the navigation")]
        public void WhenISelectTheMenu(string item)
        {
            _homePage.OpenMenuItem(item);
        }

        [Then(@"The '(.*)' menu is displayed")]
        public void ThenTheMenuIsDisplayed(string item)
        {
            Assert.IsTrue(_homePage.MenuItemDispalyed(item));
        }

        [When(@"I select the '(.*)' sub menu from the '(.*)' menu")]
        public void WhenISelectTheSubMenuFromTheMenu(string subMenuItem, string mainMenuItem)
        {
            _homePage.SelectSubMenu(mainMenuItem, subMenuItem);
        }

        [Then(@"The defualt page content is displayed on the '(.*)' page")]
        public void ThenTheDefualtPageContentIsDisplayedOnThePage(string pageName)
        {
            Assert.AreEqual(pageName, Application.CurrentPage.PageIdentifier);
        }

        [Then(@"The '(.*)' dropdown list is displayed")]
        public void ThenTheDropdownListIsDisplayed(string dropdown)
        {
            var resourcesPage = (ResourceLibrayPage)Application.GetPage(Pages.ResourceLibrary);
            Assert.IsTrue(resourcesPage.DropdownPresent(dropdown));
        }

        [When(@"I select '(.*)' from the '(.*)' dropdown list")]
        public void WhenISelectFromTheDropdownList(string option, string dropdown)
        {
            var resourcesPage = (ResourceLibrayPage)Application.GetPage(Pages.ResourceLibrary);
            resourcesPage.SelectOption(dropdown, option);
        }

        [Then(@"The '(.*)' content is displayed on the Resources page")]
        public void ThenTheReportContentIsDisplayedOnThePage(string contentType)
        {
            var resourcesPage = (ResourceLibrayPage)Application.GetPage(Pages.ResourceLibrary);
            var resourceContents = resourcesPage.GetResourceContents();

            foreach (var resourceContent in resourceContents)
            {
                Assert.IsTrue(string.Equals(resourceContent.ContentType, contentType,
                    StringComparison.InvariantCultureIgnoreCase));
            }
        }

    }
}
