using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
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
            using var response = await http.GetAsync("custom.json");
            using var stream = await response.Content.ReadAsStreamAsync();
            builder.Configuration.AddJsonStream(stream);

            var vehicleData = new Dictionary<string, string>()
            {
                { "color", "blue" },
                { "type", "car" },
                { "wheels:count", "3" },
                { "wheels:brand", "Blazin" },
                { "wheels:brand:type", "rally" },
                { "wheels:year", "2008" },
            };
            var memoryConfig = new MemoryConfigurationSource { InitialData = vehicleData };
            builder.Configuration.Add(memoryConfig);

            builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));

            var host = builder.Build();
            var blazorService = host.Services.GetRequiredService<IBlazorService>();
            blazorService.Init();
            await blazorService.InitAsync();

            await host.RunAsync();
        }
    }
}
