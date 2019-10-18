using Microsoft.Extensions.Configuration;
using NLog;
using System;

namespace SpringCM.Automation.Core
{
    public sealed class ApplicationConfigManager
    {
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        private static ApplicationConfigManager _instance;
        private readonly IConfigurationRoot _configuration;

        public static ApplicationConfigManager Instance => _instance ?? (_instance = new ApplicationConfigManager());

        private ApplicationConfigManager()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .Build();
        }

        public string GetConfig(string key)
        {
            try
            {
                return _configuration[key];
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

    }
}
