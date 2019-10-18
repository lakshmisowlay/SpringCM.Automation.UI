using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpringCM.Automation.PageObjects;
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
            Assert.AreEqual(_homePage.SearchFieldPlaceholder, placeHolder);
        }

        [When(@"I enter '(.*)' on the search field")]
        public void WhenIEnterOnTheSearchField(string searchText)
        {
            _homePage.Search(searchText);
        }

        [Then(@"'(.*)' is displayed on the search field")]
        public void ThenIsDisplayedOnTheSearchField(string searchText)
        {
            Assert.AreEqual(_homePage.SearchText.ToLower(), searchText.ToLower());
        }

        [When(@"I scroll to the bottom of the search results")]
        public void WhenIScrollToTheBottomOfTheSearchResults()
        {
            var searchResultPage = (SearchResultPage)Application.CurrentPage;
            Assert.IsNotNull(searchResultPage);

            searchResultPage.ScrollToEnd();
        }

        [Then(@"The '(.*)' link is visible")]
        public void ThenTheLinkIsVisible(string linkText)
        {
            var searchResultPage = (SearchResultPage)Application.CurrentPage;
            Assert.IsNotNull(searchResultPage);
            Assert.IsTrue(searchResultPage.HasResults(linkText));
        }
    }
}
