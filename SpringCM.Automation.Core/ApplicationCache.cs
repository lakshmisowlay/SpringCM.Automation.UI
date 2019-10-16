using System;
using System.Collections.Concurrent;

namespace SpringCM.Automation.Core
{
    public class ApplicationCache
    {
        public static ApplicationCache Instance { get; } = new ApplicationCache
        {
            _cache = new ConcurrentDictionary<string, object>()
        };

        private ConcurrentDictionary<string, object> _cache;

        public object this[string key]
        {
            get => this._cache[key];
            set => this._cache[key] = value;
        }

        public T Get<T>(string key)
        {
            object obj = this._cache[key];
            return (T)Convert.ChangeType(obj, typeof(T), System.Globalization.CultureInfo.InvariantCulture);
        }

        public void Remove(string key)
        {
            this._cache.TryRemove(key, out object _);
        }

        public bool Contains(string key)
        {
            return this._cache.ContainsKey(key);
        }
    }
}