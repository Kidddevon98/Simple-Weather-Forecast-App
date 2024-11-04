using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApp.Services;
using WeatherApp.Services.Data; // Include your data namespace

namespace WeatherApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly WeatherService _weatherService;
        private readonly WeatherAppDbContext _context; // For accessing the database

        public IndexModel(WeatherService weatherService, WeatherAppDbContext context)
        {
            _weatherService = weatherService;
            _context = context;
        }

        // Properties to hold weather information
        public string Temperature { get; set; } = "N/A";
        public string FeelsLike { get; set; } = "N/A";
        public string Description { get; set; } = "N/A";
        public string Humidity { get; set; } = "N/A";
        public string WindSpeed { get; set; } = "N/A";
        public string Visibility { get; set; } = "N/A";
        public string Pressure { get; set; } = "N/A";
        public string Sunrise { get; set; } = "N/A";
        public string Sunset { get; set; } = "N/A";

        // Add RecentSearches property
        public List<SearchHistory> RecentSearches { get; set; } = new();

        public async Task OnPostSearchAsync(string city)
        {
            var weatherData = await _weatherService.GetWeatherAsync(city);

            if (weatherData != null)
            {
                // Assign values if data is retrieved
                Temperature = $"{weatherData.Main.Temp} °F";
                FeelsLike = $"{weatherData.Main.Feels_Like} °F";
                Description = weatherData.Weather[0].Description;
                Humidity = $"{weatherData.Main.Humidity} %";
                WindSpeed = $"{weatherData.Wind.Speed} m/s";
                Visibility = $"{weatherData.Visibility} m";
                Pressure = $"{weatherData.Main.Pressure} hPa";
                Sunrise = ConvertUnixTimeToDateTime(weatherData.Sys.Sunrise).ToString("h:mm tt");
                Sunset = ConvertUnixTimeToDateTime(weatherData.Sys.Sunset).ToString("h:mm tt");

                // Save the search history to the database
                var searchHistory = new SearchHistory
                {
                    CityName = city,
                    SearchDate = DateTime.Now
                };
                _context.SearchHistories.Add(searchHistory);
                await _context.SaveChangesAsync();

                // Retrieve recent searches
                RecentSearches = _context.SearchHistories.OrderByDescending(s => s.SearchDate).Take(5).ToList();
            }
        }

        private DateTime ConvertUnixTimeToDateTime(long unixTime)
        {
            // Convert Unix timestamp to DateTime
            return DateTimeOffset.FromUnixTimeSeconds(unixTime).DateTime;
        }
    }
}
