using NLog;
using SpringCM.Automation.Core;
using TechTalk.SpecFlow;

namespace SpringCM.Automation.UI
{
    [Binding]
    public class BaseSteps
    {
        public readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        protected ScenarioContext ScenarioContext { get; }
        protected SpringCMApplication Application { get; }

        public BaseSteps(ScenarioContext context)
        {
            ScenarioContext = context;
            Application = context.Application();
        }

    }
}