using System;
using TechTalk.SpecFlow;

namespace SpringCM.Automation.Core
{
    public static class ApplicationContextExtensions
    {
        private static Guid GetAppKey(this FeatureContext featureContext)
        {
            string key = ApplicationInstanceManager.Instance.InstanceKey;
            if (!featureContext.ContainsKey(key))
            {
                featureContext.Add(key, Guid.NewGuid());
            }

            return (Guid)featureContext[key];
        }

        public static SpringCMApplication Application(this FeatureContext featureContext)
        {
            if (featureContext == null)
                throw new ArgumentNullException(nameof(featureContext));

            ApplicationCache.Instance["featureName"] = featureContext.FeatureInfo.Title;

            return ApplicationInstanceManager.Instance.Get(GetAppKey(featureContext));
        }

        public static void DetachApplication(this FeatureContext featureContext)
        {
            if (featureContext == null)
                throw new ArgumentNullException(nameof(featureContext));

            ApplicationInstanceManager.Instance.Remove(GetAppKey(featureContext));
        }

        public static bool HasBackgroundRun(this FeatureContext featureContext)
        {
            if (featureContext == null)
                throw new ArgumentNullException(nameof(featureContext));

            string key = ApplicationInstanceManager.Instance.InfoKey;
            if (!featureContext.ContainsKey(key))
            {
                featureContext.Add(key, false);
            }

            return (bool)featureContext[key];
        }

        internal static void SetBackgroundRun(this FeatureContext featureContext)
        {
            string key = ApplicationInstanceManager.Instance.InfoKey;
            featureContext[key] = true;
        }
    }
}