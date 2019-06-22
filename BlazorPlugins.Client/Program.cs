using Microsoft.AspNetCore.Blazor.Hosting;
using System;
using System.Linq;

namespace BlazorPlugins.Client
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //if(AppDomain.CurrentDomain.IsDefaultAppDomain())
            //{
                var builder = CreateHostBuilder(args);
                var host = builder.Build();
                host.Run();
            //    return;
            //}

            //// bootstrap plugins inside seperate appdomain.
            //var assembly = AppDomain.CurrentDomain.GetAssemblies()
            //  .Where(a => a
            //  .FullName.StartsWith("BlazorMVVM.Client"))
            //  .First();
            //var classes = assembly.ExportedTypes
            //   .Where(a => a.FullName.Contains("_Model"));
            //foreach (Type t in classes)
            //{
            //    foreach (Type i in t.GetInterfaces())
            //    {
            //        services.AddTransient(i, t);
            //    }
            //}

        }

        public static IWebAssemblyHostBuilder CreateHostBuilder(string[] args) =>
            BlazorWebAssemblyHost.CreateDefaultBuilder()
                .UseBlazorStartup<Startup>();
    }
}
