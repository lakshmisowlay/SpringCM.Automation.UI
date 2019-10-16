using System;
using System.Collections.Concurrent;

namespace SpringCM.Automation.Core
{
    internal class ApplicationInstanceManager
    {
        internal static ApplicationInstanceManager Instance { get; }
        internal readonly string InstanceKey = $"{Guid.NewGuid().ToString()}_Hash";
        internal readonly string InfoKey = $"{Guid.NewGuid().ToString()}_Info";

        private ConcurrentDictionary<Guid, SpringCMApplication> instanceStore;

        static ApplicationInstanceManager()
        {
            Instance = new ApplicationInstanceManager
            {
                instanceStore = new ConcurrentDictionary<Guid, SpringCMApplication>()
            };
        }

        internal SpringCMApplication Get(Guid guid)
        {
            return instanceStore.GetOrAdd(guid, _ => new SpringCMApplication());
        }

        internal void Remove(Guid guid)
        {
            instanceStore.TryRemove(guid, out _);
        }
    }
}