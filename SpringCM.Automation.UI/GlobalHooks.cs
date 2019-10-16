using SpringCM.Automation.Core;
using TechTalk.SpecFlow;

namespace SpringCM.Automation.UI
{
    [Binding]
    public class GlobalHooks
    {  
        [AfterFeature]
        public static void CloseApplication(FeatureContext featureContext)
        {
            var application = featureContext.Application();
            application.Exit();
            featureContext.DetachApplication();
        }
    }
}
