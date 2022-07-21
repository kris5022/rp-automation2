using RP.Automation.Tests;
using System;

namespace RP.Automation.UI.Fixtures
{
    public class FiltersFixture : IDisposable
    {
        private readonly UserSettings _userSettings;

        public FiltersFixture()
        {
            _userSettings = new UserSettings();
        }

        public void Dispose()
        {
        }
    }
}
