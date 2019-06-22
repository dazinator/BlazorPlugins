using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BlazorPlugins.Shared;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace BlazorPlugins.Client
{
    public class PluginHost : IPluginHost
    {

        //PermissionSet permissions = new PermissionSet(PermissionState.Unrestricted);
        //AppDomainSetup setup = new AppDomainSetup()
        //{ ApplicationBase = Environment.CurrentDirectory };

        List<Assembly> _pluginAssemblies = new List<Assembly>();
     //   AppDomain _pluginDomain = AppDomain.CreateDomain("Friendly");

        private readonly IServiceCollection _defaultServices;
        private IServiceProvider _serviceProvider;
        private IServiceScope _pluginScope;


        private List<IPlugin> _plugins;

        public PluginHost(IServiceCollection defaultServices, IServiceProvider serviceProvider, params IPlugin[] plugins)
        {
            _defaultServices = defaultServices;
            _serviceProvider = serviceProvider;
            LoadPlugins(plugins);
        }

        private void LoadPlugins(IPlugin[] plugins)
        {
            _plugins = plugins.ToList();
            Reload();
        }

        public void Reload()
        {
            if (_pluginScope != null)
            {
                _pluginScope.Dispose();
                _pluginScope = null;
            }

            _pluginScope = _serviceProvider.CreateScope();

            var pluginServices = new ServiceCollection();
            if (_defaultServices != null)
            {
                foreach (var item in _defaultServices)
                {
                    Console.WriteLine("Adding default service: " + item.ToString());
                    pluginServices.Add(item);
                }
            }
            foreach (var item in _plugins)
            {
                Console.WriteLine("Adding plugin: " + item.ToString());
                item.ConfigureServices(pluginServices);
            }
            var pluginServiceProvider = pluginServices.BuildServiceProvider();
            PluginServiceProvider = pluginServiceProvider;


            //  var existingApp = _serviceProvider.GetRequiredService<IComponentsApplicationBuilder>();
            // existingApp.
        }

        public IServiceProvider HostServiceProvider { get { return _serviceProvider; } }

        public IServiceProvider PluginServiceProvider { get; private set; }

        public void AddPlugin(IPlugin plugin)
        {
            _plugins.Add(plugin);
        }

        public void AddPluginsFromAssembly(byte[] bytes)
        {
            //load assembly
            //var assembly = System.Reflection.Assembly.Load(bytes);
            var reflectionOnlyAssy = Assembly.Load(bytes);
            var types = ScanAssemblyForPluginTypes<IPlugin>(reflectionOnlyAssy);
            foreach (var pluginType in types)
            {
                var plugin = (IPlugin)ActivatorUtilities.CreateInstance(_serviceProvider, pluginType);
                this.AddPlugin(plugin);
            }
            
        }


        public IEnumerable<Type> ScanAssemblyForPluginTypes<TPluginType>(Assembly assy)
        {
            var type = typeof(TPluginType);
            var types = assy.GetTypes()
                .Where(p => type.IsAssignableFrom(p));

            return types;

        }

    }
}
