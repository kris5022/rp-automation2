using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace RP.Automation.API
{
    public static class ProjectService
    {
        public static async Task<List<string>> GetProjectsAsync(this HttpClient _client, string path = "/v1/settings")
        {
            HttpResponseMessage response = await _client.GetAsync(path);
            return null;
        }
    }
}
