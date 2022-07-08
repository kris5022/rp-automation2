using Newtonsoft.Json;

namespace RP.Automation.API.Models
{
    public class UpdateWidgetResponse
    {
        [JsonProperty("message")]
        public string message { get; set; }
    }
}
