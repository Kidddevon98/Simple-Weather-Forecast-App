using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using WeatherApp.Services;
using WeatherApp.Services.Data;


namespace WeatherApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly WeatherService _weatherService;

        public IndexModel(WeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        // Existing properties
        public string? Temperature { get; set; }
        public string? FeelsLike { get; set; }
        public string? Description { get; set; }
        public string? Humidity { get; set; }

        // New properties
        public string? WindSpeed { get; set; }
        public string? Visibility { get; set; }
        public string? Pressure { get; set; }
        public string? Sunrise { get; set; }
        public string? Sunset { get; set; }

        // Recent searches
        public List<SearchHistory>? RecentSearches { get; set; }

        public async Task OnPostSearchAsync(string city)
        {
            try
            {
                var weatherData = await _weatherService.GetWeatherAsync(city);

                // Check for valid data and assign values
                if (weatherData?["main"] != null && weatherData["weather"] != null)
                {
                    Temperature = $"{weatherData["main"]["temp"]}°F";
                    FeelsLike = $"{weatherData["main"]["feels_like"]}°F";
                    Description = weatherData["weather"]?[0]?["description"]?.ToString();
                    Humidity = $"{weatherData["main"]["humidity"]}%";

                    // Assign new properties
                    WindSpeed = $"{weatherData["wind"]?["speed"]} m/s";
                    Visibility = $"{weatherData["visibility"]} m";
                    Pressure = $"{weatherData["main"]?["pressure"]} hPa";
                    
                    // Convert UNIX timestamps to readable times for Sunrise and Sunset
                    var sunriseUnix = (long?)weatherData["sys"]?["sunrise"];
                    var sunsetUnix = (long?)weatherData["sys"]?["sunset"];
                    if (sunriseUnix.HasValue && sunsetUnix.HasValue)
                    {
                        Sunrise = DateTimeOffset.FromUnixTimeSeconds(sunriseUnix.Value).ToLocalTime().ToString("h:mm tt");
                        Sunset = DateTimeOffset.FromUnixTimeSeconds(sunsetUnix.Value).ToLocalTime().ToString("h:mm tt");
                    }
                }
                else
                {
                    // Handle missing data
                    Temperature = "N/A";
                    FeelsLike = "N/A";
                    Description = "N/A";
                    Humidity = "N/A";
                    WindSpeed = "N/A";
                    Visibility = "N/A";
                    Pressure = "N/A";
                    Sunrise = "N/A";
                    Sunset = "N/A";
                }

                // Fetch recent searches from the database
                RecentSearches = await _weatherService.GetRecentSearchesAsync();
            }
            catch
            {
                // Handle errors
                Temperature = "N/A";
                FeelsLike = "N/A";
                Description = "N/A";
                Humidity = "N/A";
                WindSpeed = "N/A";
                Visibility = "N/A";
                Pressure = "N/A";
                Sunrise = "N/A";
                Sunset = "N/A";
            }
        }
    }
}
