using Newtonsoft.Json;

namespace RP.Automation.API.Models
{
    public class CreateDashboardResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
