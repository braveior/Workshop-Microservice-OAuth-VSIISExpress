using Blazored.LocalStorage;
using Braveior.BuddyRewards.web.Client.Providers;
using Braveior.BuddyRewards.web.Client.Services;
using Fluxor;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Braveior.BuddyRewards.web.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            //Adds the dependency injection for the LoginService and Singleton instance for HttpClient
            builder.Services.AddSingleton<HttpClient>();
            builder.Services.AddHttpClient<ILoginService, LoginService>();
            builder.Services.AddHttpClient<IDataService, DataService>();
            //Adds the LocalStorage support to Blazor
            builder.Services.AddBlazoredLocalStorage();
            //Adds the Authorization support to Blazor
            builder.Services.AddAuthorizationCore();
            //Adds the Authentication State Provider Support
            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
            //Adds the Fluxor State Management support to Blazor
            builder.Services.AddFluxor(o => o
            .ScanAssemblies(typeof(Program).Assembly).UseRouting());
            //Adds the Mud Blazor support to Blazor
            builder.Services.AddMudServices();

            await builder.Build().RunAsync();
        }
    }
}
