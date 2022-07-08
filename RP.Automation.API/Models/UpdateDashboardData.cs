using Newtonsoft.Json;
using System.Collections.Generic;

namespace RP.Automation.API.Models
{
    public class UpdateDashboardData
    {
        [JsonProperty("description")]
        public string description { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("share")]
        public bool share { get; set; }

        [JsonProperty("updateWidgets")]
        public List<UpdateWidget> updateWidgets { get; set; }
    }

    public class UpdateWidget
    {
        [JsonProperty("share")]
        public bool share { get; set; }

        [JsonProperty("widgetId")]
        public int widgetId { get; set; }

        [JsonProperty("widgetName")]
        public string widgetName { get; set; }

        [JsonProperty("widgetPosition")]
        public WidgetPosition widgetPosition { get; set; }

        [JsonProperty("widgetSize")]
        public WidgetSize widgetSize { get; set; }

        [JsonProperty("widgetType")]
        public string widgetType { get; set; }
    }

    public class WidgetPosition
    {
        [JsonProperty("positionX")]
        public int positionX { get; set; }

        [JsonProperty("positionY")]
        public int positionY { get; set; }
    }

    public class WidgetSize
    {
        [JsonProperty("height")]
        public int height { get; set; }

        [JsonProperty("width")]
        public int width { get; set; }
    }
}
