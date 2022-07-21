using Newtonsoft.Json;
using RestSharp;
using RP.Automation.API.Models;

namespace RP.Automation.API
{
    public class DashboardService : BaseService
    {
        private readonly ConfigSettings _configSettings;
        private static int _dashboardId;

        public DashboardService()
        {
            _configSettings = new ConfigSettings();
        }

        public string _dashboardPath => $"{_configSettings.BaseUrl}/v1/superadmin_personal/dashboard";

        public int CreateDashboard(CreateDashboardData createDashboardData)
        {
            var request = new RequestFactory().CreateRequest(_dashboardPath, Method.Post, createDashboardData);
            var response = CreateClient().Post(request);
            _dashboardId = JsonConvert.DeserializeObject<CreateDashboardResponse>(response.Content).Id;
            return _dashboardId;
        }

        public string ModifyDashboard(UpdateDashboardData updateDashboardData)
        {
            var request = new RequestFactory().CreateRequest($"{_dashboardPath}/{_dashboardId}", Method.Put, updateDashboardData);
            var response = CreateClient().Put(request);
            var message = JsonConvert.DeserializeObject<UpdateDashboardResponse>(response.Content).Message;
            return message;
        }

        public string RemoveDashboard()
        {
            var request = new RequestFactory().CreateRequest($"{_dashboardPath}/{_dashboardId}", Method.Delete);
            var response = CreateClient().Delete(request);
            var message = JsonConvert.DeserializeObject<UpdateDashboardResponse>(response.Content).Message;
            return message;
        }
    }
}
