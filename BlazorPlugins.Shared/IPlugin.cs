using Microsoft.Extensions.DependencyInjection;

namespace BlazorPlugins.Shared
{

    public interface IPlugin
    {
        void ConfigureServices(IServiceCollection services);
    }
}
