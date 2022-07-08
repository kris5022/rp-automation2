using RestSharp;
using RP.Automation.API.Models;

namespace RP.Automation.API
{
    public class WidgetService : BaseService
    {
        private readonly ConfigSettings _configSettings;
        private int _widgetId;

        public WidgetService()
        {
            _configSettings = new ConfigSettings();
        }

        public string _widgetPath => $"{_configSettings.BaseUrl}/v1/superadmin_personal/widget";

        public int CreateWidget(CreateWidgetData createWidgetData)
        {
            var request = new RequestFactory().CreateRequest(_widgetPath, Method.Post, createWidgetData);
            var response = CreateClient().Post(request);
            _widgetId = response.Content.Deserialize<CreateWidgetResponse>().Id;
            return _widgetId;
        }

        public string ModifyWidget(CreateWidgetData createWidgetData)
        {
            var request = new RequestFactory().CreateRequest($"{_widgetPath}{_widgetId}", Method.Put, createWidgetData);
            var response = CreateClient().Post(request);
            var message = response.Content.Deserialize<UpdateWidgetResponse>().message;
            return message;
        }

        public string RemoveWidget(int dashboardId = 0)
        {
            var request = new RequestFactory().CreateRequest($"{_configSettings.BaseUrl}/dashboard/{dashboardId}/{_widgetId}", Method.Delete);
            var response = CreateClient().Post(request);
            var message = response.Content.Deserialize<UpdateDashboardResponse>().message;
            return message;
        }
    }
}
