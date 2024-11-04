using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using WeatherApp.Services;

namespace WeatherApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly WeatherService _weatherService;

        public IndexModel(WeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        // Properties to store the weather data
        public string? Temperature { get; set; }
        public string? FeelsLike { get; set; }
        public string? Description { get; set; }
        public string? Humidity { get; set; }

        public async Task OnPostSearchAsync(string city)
        {
            try
            {
                var weatherData = await _weatherService.GetWeatherAsync(city);

                if (weatherData?["main"] != null && weatherData["weather"] != null)
                {
                    // Parse and assign the weather data with additional null checks
                    Temperature = weatherData["main"]?["temp"]?.ToString() ?? "N/A";
                    FeelsLike = weatherData["main"]?["feels_like"]?.ToString() ?? "N/A";
                    Description = weatherData["weather"]?[0]?["description"]?.ToString() ?? "N/A";
                    Humidity = weatherData["main"]?["humidity"]?.ToString() ?? "N/A";
                }
                else
                {
                    // Fallback values if data is not available
                    Temperature = "N/A";
                    FeelsLike = "N/A";
                    Description = "N/A";
                    Humidity = "N/A";
                }
            }
            catch
            {
                // Handle errors, if any
                Temperature = "N/A";
                FeelsLike = "N/A";
                Description = "N/A";
                Humidity = "N/A";
            }
        }
    }
}
