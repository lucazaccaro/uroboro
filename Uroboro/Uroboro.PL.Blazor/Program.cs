using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Uroboro.PL.Blazor.Clients;
using Uroboro.PL.Blazor.Models;
using Uroboro.PL.Blazor.Services;

namespace Uroboro.PL.Blazor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");            

            builder.Services.AddSingleton<IBlazorService, BlazorService>();

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddHttpClient("ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

            builder.Services.AddHttpClient<WeatherForecastHttpClient>(client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

            var http = new HttpClient()
            {
                BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
            };
            builder.Services.AddScoped(sp => http);

            // Add external JSON file to loaded configuration sources
            using var customSettingsResponse = await http.GetAsync("customsettings.json");
            using var customSettingsStream = await customSettingsResponse.Content.ReadAsStreamAsync();
            builder.Configuration.AddJsonStream(customSettingsStream);
            // Add in-memory Dictionary to loaded configuration sources
            var inMemoryConfig = new MemoryConfigurationSource { InitialData = BlazorService.InMemoryDictionarySettings };
            builder.Configuration.Add(inMemoryConfig);
            // Register custom classes to handle config values in a type safety way
            builder.Services.AddOptions();
            builder.Services.Configure<UroboroSettings>(builder.Configuration.GetSection("Uroboro"));
            builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

            builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));

            var host = builder.Build();
            var blazorService = host.Services.GetRequiredService<IBlazorService>();
            blazorService.Init();
            await blazorService.InitAsync();

            await host.RunAsync();
        }
    }
}
