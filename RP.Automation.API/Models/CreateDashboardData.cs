using Newtonsoft.Json;

namespace RP.Automation.API.Models
{
    public class CreateDashboardData
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("share")]
        public bool Share { get; set; }
    }
}
