using Newtonsoft.Json;

namespace RP.Automation.API.Models
{
    public class CreateWidgetResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
