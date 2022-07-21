using RestSharp;
using RP.Automation.API.Models;

namespace RP.Automation.API
{
    public class RequestFactory
    {
        private readonly ConfigSettings _configSettings;

        public RequestFactory()
        {
            _configSettings = new ConfigSettings();
        }

        public RestRequest CreateRequest(string resource, Method method, object data = null)
        {
            var request = new RestRequest();
            request.Method = method;
            request.Resource = resource;
            request.AddHeader("Authorization", _configSettings.Token);
            request.AddHeader("Accept", "application/json");

            if (method != Method.Delete)
                request.AddJsonBody(data);

            return request;
        }
    }
}
