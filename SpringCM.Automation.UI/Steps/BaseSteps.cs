using NLog;
using SpringCM.Automation.Core;
using TechTalk.SpecFlow;

namespace SpringCM.Automation.UI
{
    [Binding]
    public class BaseSteps
    {
        public readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        protected FeatureContext FeatureContext { get; }
        protected SpringCMApplication Application { get; }

        public BaseSteps(FeatureContext featureContext)
        {
            FeatureContext = featureContext;
            Application = featureContext.Application();
        }

    }
}