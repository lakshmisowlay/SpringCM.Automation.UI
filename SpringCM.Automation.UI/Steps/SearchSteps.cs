using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpringCM.Automation.PageObjects;
using System;
using TechTalk.SpecFlow;

namespace SpringCM.Automation.UI
{
    [Binding, Scope(Feature = "Search")]
    public class SearchSteps : BaseSteps
    {
        private HomePage _homePage;
        public SearchSteps(FeatureContext featureContext) : base(featureContext)
        {
        }
        [Given(@"The application running")]
        public void GivenIHaveTheApplicationRunning()
        {
            _homePage = (HomePage)Application.GoTo(Pages.Home, true);
        }

        [When(@"I click on search button")]
        public void WhenIClickOnSearchButton()
        {
            _homePage.OpenSearchField();
        }

        [Then(@"Search field with '(.*)' is displayed")]
        public void ThenSearchFieldWithIsDisplayed(string placeHolder)
        {
            Assert.AreEqual(placeHolder, _homePage.SearchFieldPlaceholder);
        }

        [When(@"I enter '(.*)' on the search field")]
        public void WhenIEnterOnTheSearchField(string searchText)
        {
            _homePage.Search(searchText);
        }

        [Then(@"'(.*)' is displayed on the search field")]
        public void ThenIsDisplayedOnTheSearchField(string searchText)
        {
            Assert.IsTrue(searchText.Equals(_homePage.SearchText, StringComparison.InvariantCultureIgnoreCase));
        }

        [When(@"I scroll to the bottom of the search results")]
        public void WhenIScrollToTheBottomOfTheSearchResults()
        {
            try
            {
                var searchResultPage = (SearchResultPage)Application.CurrentPage;

                //TODO: Not required
                searchResultPage.ScrollToEnd();
            }
            catch (Exception e)
            {
                Logger.Error(e);
                Assert.Fail();
            }

        }

        [Then(@"The '(.*)' link is visible")]
        public void ThenTheLinkIsVisible(string linkText)
        {
            try
            {
                var searchResultPage = (SearchResultPage)Application.CurrentPage;
                Assert.IsTrue(searchResultPage.HasResults(linkText));
            }
            catch (Exception e)
            {
                Logger.Error(e);
                Assert.Fail();
            }
        }
    }
}
