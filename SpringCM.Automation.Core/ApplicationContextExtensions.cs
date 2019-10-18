using System;
using TechTalk.SpecFlow;

namespace SpringCM.Automation.Core
{
    public static class ApplicationContextExtensions
    {
        public static SpringCMApplication Application(this ScenarioContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            return ApplicationInstanceManager.Instance.Get(GetAppKey(context));
        }

        public static void DetachApplication(this ScenarioContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            ApplicationInstanceManager.Instance.Remove(GetAppKey(context));
        }

        private static Guid GetAppKey(this ScenarioContext context)
        {
            string key = ApplicationInstanceManager.Instance.InstanceKey;
            if (!context.ContainsKey(key))
            {
                context.Add(key, Guid.NewGuid());
            }

            return (Guid)context[key];
        }

    }
}