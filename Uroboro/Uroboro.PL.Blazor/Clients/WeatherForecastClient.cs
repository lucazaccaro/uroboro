using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Uroboro.PL.Blazor.Models;

namespace Uroboro.PL.Blazor.Clients
{
    public class WeatherForecastHttpClient
    {
        private readonly HttpClient http;

        public WeatherForecastHttpClient(HttpClient http)
        {
            this.http = http;
        }

        public async Task<WeatherForecast[]> GetForecastAsync()
        {
            var forecasts = new WeatherForecast[0];

            try
            {
                // This project does not directly expose REST APIs
                // forecasts = await http.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast");
                forecasts = await http.GetFromJsonAsync<WeatherForecast[]>("sample-data/weather.json");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

            return forecasts;
        }
    }
}
