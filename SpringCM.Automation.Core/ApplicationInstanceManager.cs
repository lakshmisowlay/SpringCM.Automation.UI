using System;
using System.Collections.Concurrent;

namespace SpringCM.Automation.Core
{
    internal class ApplicationInstanceManager
    {
        internal static ApplicationInstanceManager Instance { get; }
        internal readonly string InstanceKey = $"{Guid.NewGuid().ToString()}_Hash";

        private ConcurrentDictionary<Guid, SpringCMApplication> _instanceStore;

        static ApplicationInstanceManager()
        {
            Instance = new ApplicationInstanceManager();
            Instance._instanceStore = new ConcurrentDictionary<Guid, SpringCMApplication>();
        }

        internal SpringCMApplication Get(Guid guid)
        {
            return _instanceStore.GetOrAdd(guid, _ => new SpringCMApplication());
        }

        internal void Remove(Guid guid)
        {
            _instanceStore.TryRemove(guid, out _);
        }
    }
}