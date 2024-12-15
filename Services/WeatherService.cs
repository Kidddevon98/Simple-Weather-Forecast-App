using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    /// <summary>
    /// Service for fetching weather data from the OpenWeatherMap API.
    /// </summary>
    public class WeatherService
    {
        private readonly HttpClient _httpClient;
        private const string ApiKey = "eeec0a18c71c6b5670b043cc5fcf2f25"; // Replace this with secure storage for production.

        /// <summary>
        /// Initializes the WeatherService with an HttpClient.
        /// </summary>
        /// <param name="httpClient">The HttpClient instance for API requests.</param>
        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Fetches weather data for a specified city and state.
        /// </summary>
        /// <param name="city">The city name (e.g., "Lexington").</param>
        /// <param name="state">The state code (e.g., "KY").</param>
        /// <param name="unit">Unit system ("imperial" for Fahrenheit, "metric" for Celsius).</param>
        /// <returns>WeatherData object containing weather details.</returns>
        public async Task<WeatherData> GetWeatherAsync(string city, string state, string unit = "imperial")
        {
            string apiUrl = $"https://api.openweathermap.org/data/2.5/weather?q={city},{state},US&appid={ApiKey}&units={unit}";

            try
            {
                var response = await _httpClient.GetAsync(apiUrl);

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    throw new Exception($"Location '{city}, {state}' not found. Please verify your input.");
                }

                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var weatherData = JsonConvert.DeserializeObject<WeatherData>(content);

                if (weatherData == null)
                {
                    throw new Exception("Unable to parse weather data. Please try again later.");
                }

                Logger.LogInfo($"Weather data retrieved for {city}, {state}.");
                return weatherData;
            }
            catch (HttpRequestException httpEx)
            {
                Logger.LogError("Network error occurred while fetching weather data.", httpEx);
                throw new Exception("Network error: Unable to reach the weather API. Please check your connection.", httpEx);
            }
            catch (JsonException jsonEx)
            {
                Logger.LogError("Failed to process weather data response.", jsonEx);
                throw new Exception("Error processing weather data. Please try again later.", jsonEx);
            }
            catch (Exception ex)
            {
                Logger.LogError("An unexpected error occurred in GetWeatherAsync.", ex);
                throw;
            }
        }
    }
}
