using System;
using BlazorPlugins.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorPlugins.Client
{

    public class ClockPlugin : IPlugin
    {
        private readonly INavService _navService;

        public ClockPlugin(INavService navService)
        {
            _navService = navService;
            _navService.AddItem(new NavItem() { DisplayName = "Clock Plugin", Url = "clock" });
        }

        public class Clock
        {
            public DateTime GetDateTime()
            {
                return System.DateTime.UtcNow;
            }
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<Clock>();
        }
    }
}
