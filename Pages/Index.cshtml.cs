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
        public string Temperature { get; set; } = "N/A";
        public string FeelsLike { get; set; } = "N/A";
        public string Description { get; set; } = "N/A";
        public string Humidity { get; set; } = "N/A";
        public string WindSpeed { get; set; } = "N/A";
        public string Visibility { get; set; } = "N/A";
        public string Pressure { get; set; } = "N/A";
        public string Sunrise { get; set; } = "N/A";
        public string Sunset { get; set; } = "N/A";

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
            try
            {
                var weatherData = await _weatherService.GetWeatherAsync(city, state, unit); // Fetch weather data

                if (weatherData != null)
                {
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
                    await _context.SaveChangesAsync();

                    // Retrieve the latest five recent searches
                    RecentSearches = _context.SearchHistories
                                             .OrderByDescending(s => s.SearchDate)
                                             .Take(5)
                                             .ToList();
                }
            }
            catch (Exception ex)
            {
                // Log the exception and reset the weather data
                Logger.LogError("An error occurred", ex);
                Temperature = "N/A";
                FeelsLike = "N/A";
                Description = "Error fetching data. Please try again.";
                Humidity = "N/A";
                WindSpeed = "N/A";
                Visibility = "N/A";
                Pressure = "N/A";
                Sunrise = "N/A";
                Sunset = "N/A";
            }
        }

        /// <summary>
        /// Converts a Unix timestamp to a DateTime object.
        /// </summary>
        /// <param name="unixTime">Unix timestamp to convert.</param>
        /// <returns>A DateTime object representing the converted timestamp.</returns>
        private DateTime ConvertUnixTimeToDateTime(long unixTime)
        {
            var utcDateTime = DateTimeOffset.FromUnixTimeSeconds(unixTime).UtcDateTime;
            var localTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            return TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, localTimeZone);
        }
    }
}
