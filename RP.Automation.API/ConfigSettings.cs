using Microsoft.Extensions.Configuration;
using RP.Automation.Core;
using System.Collections.Generic;
using System.Linq;

namespace RP.Automation.API
{
    public class ConfigSettings
    {
        private readonly IEnumerable<IConfigurationSection> _configSection;

        public ConfigSettings()
        {
            var configManager = new ConfigManager("appsettings.json");
            _configSection = configManager.Configuration.GetSection("UserConfiguration").GetChildren();
        }

        public string BaseUrl => _configSection.FirstOrDefault(k => k.Key.Equals("BaseUrl"))?.Value;
        public string Token => _configSection.FirstOrDefault(k => k.Key.Equals("Token"))?.Value;
        public string Username => _configSection.FirstOrDefault(k => k.Key.Equals("Username"))?.Value;
        public string Password => _configSection.FirstOrDefault(k => k.Key.Equals("Password"))?.Value;
    }
}
