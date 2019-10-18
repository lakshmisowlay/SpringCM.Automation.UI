using SpringCM.Automation.Core;
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

    }
}