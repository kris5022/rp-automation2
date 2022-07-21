using RestSharp;

namespace RP.Automation.API
{
    public class RestClientFactory
    {
        public RestClient _restClient;
        private readonly ConfigSettings _configSettings;

        public RestClientFactory()
        {
            _configSettings = new ConfigSettings();
        }

        public RestClient CreateRestClient()
        {
            var client = new RestClient(_configSettings.BaseUrl);
            return client;
        }
    }
}
