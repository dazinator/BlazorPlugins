using BlazorPlugins.Client;
using BlazorPlugins.Shared;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Plugin.Weather
{

    
    public class WeatherPlugin : IPlugin
    {
        private readonly INavService _navService;

        /// <summary>
        /// Can inject services from the host / shell here.
        /// </summary>
        public WeatherPlugin(INavService navService)
        {
            _navService = navService;
            _navService.AddItem(new NavItem() { DisplayName = "Weather Plugin", Url = "weather" });
        }
       
        public void ConfigureServices(IServiceCollection services)
        {
           // throw new NotImplementedException();
        }
    }
}
