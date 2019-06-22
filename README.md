# BlazorPlugins
 A work in progress, experimenting with loading plugins into a blazor application at runtime.

 1. Build the "Plugin.Weather" project. This spits out a plugin assembly to `[Your-Project-Path\bin\Debug\netstandard2.0\dist\_framework\_bin\Plugin.Weather.dll`
 2. Launch the blazor app, click on the "Load" button to load the weather plugin from the server.
 3. Click on the "Reload" button to bootstrap all the plugins.

 Note this is very much a work in progress, still lots of things to address:

 1. How to unload a plugin?
 2. Hot can the plugin include it's own page / components?