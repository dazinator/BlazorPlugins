# BlazorPlugins
 A work in progress, experimenting with loading plugins into a blazor application at runtime.

 1. Build the "Plugin.Weather" project. This spits out a plugin assembly to `[Your-Project-Path\bin\Debug\netstandard2.0\dist\_framework\_bin\Plugin.Weather.dll`
 2. Launch the blazor app, click on the button next to the plugin to load it from the server.

 ![Click Add](./img/clickadd.PNG)

 3. The app loads the plugin from the server, and then executes it. The plugin adds a `NavItem` to the `NavMenu`.

 ![Click Add](./img/weatherplugin.PNG)

 Note this is very much a work in progress, still lots of things to address:

 1. How to unload / reload a plugin?
 2. Hot can the plugin include it's own page / components?
