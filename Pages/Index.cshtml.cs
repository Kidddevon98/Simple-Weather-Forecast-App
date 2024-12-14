using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Services;
using WeatherApp.Services.Data;

namespace WeatherApp.Pages
{
    /// <summary>
    /// Represents the model for the Index page, managing weather data and search history.
    /// </summary>
    public class IndexModel : PageModel
    {
        private readonly WeatherService _weatherService; // Service to fetch weather data
        private readonly WeatherAppDbContext _context; // Database context for search history

        /// <summary>
        /// Constructor for IndexModel to inject WeatherService and WeatherAppDbContext.
        /// </summary>
        /// <param name="weatherService">Service to fetch weather data from the API.</param>
        /// <param name="context">Database context for storing and retrieving search history.</param>
        public IndexModel(WeatherService weatherService, WeatherAppDbContext context)
        {
            _weatherService = weatherService;
            _context = context;
        }

        // Properties to hold weather information
        public string Temperature { get; set; } = "N/A"; // Current temperature
        public string FeelsLike { get; set; } = "N/A"; // Feels-like temperature
        public string Description { get; set; } = "N/A"; // Weather description
        public string Humidity { get; set; } = "N/A"; // Humidity level
        public string WindSpeed { get; set; } = "N/A"; // Wind speed
        public string Visibility { get; set; } = "N/A"; // Visibility distance
        public string Pressure { get; set; } = "N/A"; // Atmospheric pressure
        public string Sunrise { get; set; } = "N/A"; // Sunrise time
        public string Sunset { get; set; } = "N/A"; // Sunset time

        /// <summary>
        /// A list to store the recent search history for display on the page.
        /// </summary>
        public List<SearchHistory> RecentSearches { get; set; } = new();

        /// <summary>
        /// Handles the search functionality when a city name and state are provided.
        /// </summary>
        /// <param name="city">Name of the city to fetch weather data for.</param>
        /// <param name="state">State code for the city (e.g., KY).</param>
        /// <param name="unit">Temperature unit ('imperial' for Fahrenheit, 'metric' for Celsius).</param>
        public async Task OnPostSearchAsync(string city, string state, string unit = "imperial")
        {
            var weatherData = await _weatherService.GetWeatherAsync(city, state, unit); // Fetch weather data with city, state, and unit

            if (weatherData != null)
            {
                // Determine the unit symbol
                string tempUnit = unit == "imperial" ? "°F" : "°C";

                // Assign values if data is retrieved successfully
                Temperature = $"{weatherData.Main.Temp} {tempUnit}";
                FeelsLike = $"{weatherData.Main.Feels_Like} {tempUnit}";
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
                    CityName = $"{city}, {state}",
                    SearchDate = DateTime.Now
                };
                _context.SearchHistories.Add(searchHistory);
                await _context.SaveChangesAsync(); // Persist the search history

                // Retrieve the latest five recent searches, sorted by date
                RecentSearches = _context.SearchHistories
                                         .OrderByDescending(s => s.SearchDate)
                                         .Take(5)
                                         .ToList();
            }
        }

        /// <summary>
        /// Converts a Unix timestamp to a DateTime object.
        /// </summary>
        /// <param name="unixTime">Unix timestamp to convert.</param>
        /// <returns>A DateTime object representing the converted timestamp.</returns>
        private DateTime ConvertUnixTimeToDateTime(long unixTime)
        {
            // Convert Unix timestamp to UTC DateTime
            var utcDateTime = DateTimeOffset.FromUnixTimeSeconds(unixTime).UtcDateTime;

            // Adjust to local timezone using TimeZoneInfo
            var localTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"); // Replace with your timezone
            var localDateTime = TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, localTimeZone);

            return localDateTime;
        }
    }
}
