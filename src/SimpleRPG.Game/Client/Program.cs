using Blazorise;
using Blazorise.Bootstrap;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using SimpleRPG.Game.Client;
using SimpleRPG.Game.Engine;
using SimpleRPG.Game.Engine.ViewModels;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddBlazorise(o =>
{
    o.ChangeTextOnKeyPress = false;
})
.AddBootstrapProviders();

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

ConfigureServices(builder.Services);

await builder.Build().RunAsync();


void ConfigureServices(IServiceCollection services)
{
    services.AddScoped(sp => new HttpClient
    {
        BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
    });

    services.AddSingleton<IGameSession, GameSession>();
}