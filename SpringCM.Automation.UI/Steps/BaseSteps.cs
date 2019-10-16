using SpringCM.Automation.Core;
using SpringCM.Automation.PageObjects;
using TechTalk.SpecFlow;

namespace SpringCM.Automation.UI
{
    [Binding]
    public class BaseSteps
    {
        protected FeatureContext FeatureContext { get; }
        protected SpringCMApplication Application { get; }

        public BaseSteps(FeatureContext featureContext)
        {
            FeatureContext = featureContext;
            Application = featureContext.Application();
        }

        [Given(@"The application running")]
        public void GivenIHaveTheApplicationRunning()
        {
            Application.GoTo(Pages.Home);
        }
    }
}