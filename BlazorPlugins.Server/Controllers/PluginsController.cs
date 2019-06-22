using BlazorPlugins.Shared;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPlugins.Server.Controllers
{

    [Route("api/[controller]")]
    public class PluginsController : Controller
    {

        [HttpGet()]
        public IEnumerable<PluginInfo> Plugins()
        {
            return new PluginInfo[] { new PluginInfo() { Name = "weather", Description = "Plugin that adds a weather page to the menu." } };

        }

        [HttpGet("weather")]
        public IActionResult GetWeatherPlugin([FromServices]IWebHostEnvironment env)
        {
            var appPath = env.ContentRootPath;
            var pluginPath = Path.Combine(appPath, @"..\Plugin.Weather\bin\Debug\netstandard2.0\dist\_framework\_bin\");

            var physicalFileProvider = new PhysicalFileProvider(pluginPath);
            var assemblyFile = physicalFileProvider.GetFileInfo("Plugin.Weather.dll");
            var memoryStream = new MemoryStream();
            assemblyFile.CreateReadStream().CopyTo(memoryStream);
            var bytes = memoryStream.ToArray();
            return new FileContentResult(bytes, "application/octet-stream");

        }
    }
}
