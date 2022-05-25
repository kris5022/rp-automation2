using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace RP.Automation.Core
{
    public class ConfigManager
    {
        private readonly Lazy<IConfiguration> _configuration;
        private readonly string _configurationFile;

        public ConfigManager(string configurationFile)
        {
            _configurationFile = configurationFile;
            _configuration = new Lazy<IConfiguration>(GetConfiguration);
        }

        public IConfiguration Configuration => _configuration.Value;

        private IConfiguration GetConfiguration()
        {
            var configurationBuilder = new ConfigurationBuilder();
            var directoryName = Path.GetDirectoryName(typeof(ConfigManager).Assembly.Location);
            configurationBuilder.AddJsonFile(Path.Combine(
                directoryName ?? throw new InvalidOperationException("No browser capabilities found"),
                _configurationFile));
            return configurationBuilder.Build();
        }
    }
}
