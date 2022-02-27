using Blazorise;
using Blazorise.Bootstrap;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using SimpleRPG.Game.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddBlazorise(o =>
{
    o.ChangeTextOnKeyPress = false;
})
.AddBootstrapProviders();

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient 
{ 
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) 
});

await builder.Build().RunAsync();
