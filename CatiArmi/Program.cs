using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using CatiArmi;
using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using CatiArmi.Scripts;
using System.Timers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


// Startup
GameManager.InitializeTimers();
GlobalTimer.TickTimer.Elapsed += Inventory.IdleMoneyGain;
GlobalTimer.TickTimer.Elapsed += BoardManager.PachiTicks;
GlobalTimer.RefreshTimer.Elapsed += (Object source, ElapsedEventArgs e) => BoardManager.BoardRefresh?.Invoke();
GlobalTimer.StartRefreshTimer();
GlobalTimer.StartTickTimer();
StoreManager.Setup();
BoardManager.Setup();


// Blazorise
builder.Services
    .AddBlazorise(options =>
    {
        options.Immediate = true;
    })
    .AddBootstrap5Providers()
    .AddFontAwesomeIcons();

await builder.Build().RunAsync();
