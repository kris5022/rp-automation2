using Newtonsoft.Json;

namespace RP.Automation.API.Models
{
    public class UpdateDashboardResponse
    {
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
