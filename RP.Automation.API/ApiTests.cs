using FluentAssertions;
using RP.Automation.API.Models;
using RP.Automation.Core.Utilities;
using System;
using Xunit;

namespace RP.Automation.API
{
    public class ApiTests : IDisposable
    {
        public DashboardService _dashboardService;
        public WidgetService _widgetService;
        public int _dashboardId;
        public int _widgetId;

        public ApiTests()
        {
            _dashboardService = new DashboardService();
            _widgetService = new WidgetService();
        }

        [Fact]
        public void CreateDashboard()
        {       
            var createDashboardData = new CreateDashboardData();
            createDashboardData.Description = "description";
            createDashboardData.Name = $"TestDashboard{Randomizer.RandomDigits()}";
            createDashboardData.Share = true;

            _dashboardId = _dashboardService.CreateDashboard(createDashboardData);
            _dashboardId.Should().BeGreaterThan(0);
        }

        [Fact]
        public void ModifyDashboard()
        {
            _dashboardId = CreateTestDashboard();
            var updateDashboardData = new UpdateDashboardData();
            updateDashboardData.name = $"UpdatedTestDashboard{Randomizer.RandomDigits()}";
            var message = _dashboardService.ModifyDashboard(updateDashboardData);
            message.Should().ContainEquivalentOf("successfully updated");
        }

        [Fact]
        public void RemoveDashboard()
        {
            _dashboardId = CreateTestDashboard();
            var message = _dashboardService.RemoveDashboard();
            message.Should().ContainEquivalentOf("successfully deleted");
        }

        [Fact]
        public void CreateWidget()
        {
            var createWidgetData = new CreateWidgetData();
            createWidgetData.description = "description";
            createWidgetData.name = $"TestWidget{Randomizer.RandomDigits()}";
            createWidgetData.share = true;

            _widgetId = _widgetService.CreateWidget(createWidgetData);
            _widgetId.Should().BeGreaterThan(0);
        }

        [Fact]
        public void ModifyWidget()
        {
            _widgetId = CreateTestWidget();
            var updateWidgetData = new CreateWidgetData();
            updateWidgetData.description = "updated description";
            var message = _widgetService.ModifyWidget(updateWidgetData);
            message.Should().ContainEquivalentOf("successfully updated");
        }

        [Fact]
        public void RemoveWidget()
        {
            _widgetId = CreateTestWidget();
            var message = _widgetService.RemoveWidget();
            message.Should().ContainEquivalentOf("successfully deleted");
        }

        public int CreateTestDashboard()
        {
            var createDashboardData = new CreateDashboardData();
            createDashboardData.Name = $"TestDashboard{Randomizer.RandomDigits()}";
            _dashboardId = _dashboardService.CreateDashboard(createDashboardData);
            _dashboardId.Should().BeGreaterThan(0);
            return _dashboardId;
        }

        public int CreateTestWidget()
        {
            var createWidgetData = new CreateWidgetData();
            createWidgetData.name = $"TestWidget{Randomizer.RandomDigits()}";
            _widgetId = _widgetService.CreateWidget(createWidgetData);
            _widgetId.Should().BeGreaterThan(0);
            return _widgetId;
        }

        public void Dispose()
        {
        }
    }
}
