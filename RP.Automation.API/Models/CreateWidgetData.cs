using Newtonsoft.Json;
using System.Collections.Generic;

namespace RP.Automation.API.Models
{
    public class ContentParameters
    {
        [JsonProperty("contentFields")]
        public List<string> contentFields { get; set; }

        [JsonProperty("itemsCount")]
        public int itemsCount { get; set; }

        [JsonProperty("widgetOptions")]
        public WidgetOptions widgetOptions { get; set; }
    }

    public class CreateWidgetData
    {
        [JsonProperty("contentParameters")]
        public ContentParameters contentParameters { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }

        [JsonProperty("filterIds")]
        public List<int> filterIds { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("share")]
        public bool share { get; set; }

        [JsonProperty("widgetType")]
        public string widgetType { get; set; }
    }

    public class WidgetOptions
    {
    }
}
