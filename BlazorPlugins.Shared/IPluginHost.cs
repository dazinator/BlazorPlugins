using System;

namespace BlazorPlugins.Shared
{
    public interface IPluginHost
    {
        IServiceProvider HostServiceProvider { get; }
        IServiceProvider PluginServiceProvider { get; }

        void AddPlugin(IPlugin plugin);

        void AddPluginsFromAssembly(byte[] bytes);

        void Reload();

    }
}
