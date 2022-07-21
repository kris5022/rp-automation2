using RestSharp;

namespace RP.Automation.API
{
    public class BaseService
    {
        protected RestClient _client { get; set; }

        public RestClient CreateClient()
        {
            _client = new RestClientFactory().CreateRestClient();
            return _client;
        }
    }
}
