using System.Security;
using System.Security.Permissions;
using BlazorPlugins.Shared;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorPlugins.Client
{

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<INavService, NavService>();

            // register the default clock plugin
            services.AddSingleton<ClockPlugin>();

            // IPlugin[] defaultPlugins = new IPlugin[] { new ClockPlugin() };
            services.AddSingleton<IPluginHost>(sp => new PluginHost(services, sp, sp.GetRequiredService<ClockPlugin>()));
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
