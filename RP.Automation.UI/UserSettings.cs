using Microsoft.Extensions.Configuration;
using RP.Automation.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RP.Automation.Tests
{
    public class UserSettings
    {
        private readonly IEnumerable<IConfigurationSection> _configSection;

        public UserSettings()
        {
            var configManager = new ConfigManager("appsettings.json");
            _configSection = configManager.Configuration.GetSection("UserConfiguration").GetChildren();
        }

        public string BaseUrl => _configSection.FirstOrDefault(k => k.Key.Equals("BaseUrl"))?.Value;
        public string Browser => _configSection.FirstOrDefault(k => k.Key.Equals("Browser"))?.Value;
        public string Username => _configSection.FirstOrDefault(k => k.Key.Equals("Username"))?.Value;
        public string Password => _configSection.FirstOrDefault(k => k.Key.Equals("Password"))?.Value;

        public TimeSpan DefaultExplicitWaitTimeout => TimeSpan.FromSeconds(
            Convert.ToDouble(_configSection.FirstOrDefault(k => k.Key.Equals("DefaultExplicitWaitTimeout"))?.Value));
    }
}
