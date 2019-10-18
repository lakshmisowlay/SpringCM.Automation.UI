using System;
using TechTalk.SpecFlow;

namespace SpringCM.Automation.Core
{
    public static class ApplicationContextExtensions
    {
        public static SpringCMApplication Application(this FeatureContext featureContext)
        {
            if (featureContext == null)
                throw new ArgumentNullException(nameof(featureContext));

            return ApplicationInstanceManager.Instance.Get(GetAppKey(featureContext));
        }

        public static void DetachApplication(this FeatureContext featureContext)
        {
            if (featureContext == null)
                throw new ArgumentNullException(nameof(featureContext));

            ApplicationInstanceManager.Instance.Remove(GetAppKey(featureContext));
        }

        private static Guid GetAppKey(this FeatureContext featureContext)
        {
            string key = ApplicationInstanceManager.Instance.InstanceKey;
            if (!featureContext.ContainsKey(key))
            {
                featureContext.Add(key, Guid.NewGuid());
            }

            return (Guid)featureContext[key];
        }

    }
}