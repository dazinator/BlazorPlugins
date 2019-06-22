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
            _navService.AddItem(new NavItem() { DisplayName = "Clock Plugin", Url = "clock" });
            services.AddSingleton<Clock>();
        }
    }
}
