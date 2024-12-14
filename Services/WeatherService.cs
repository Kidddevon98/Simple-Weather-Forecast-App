using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    /// <summary>
    /// Provides functionality to fetch and process weather data from OpenWeatherMap API.
    /// </summary>
    public class WeatherService
    {
        // HttpClient instance for making API requests.
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Constructor that initializes the WeatherService with an HttpClient instance.
        /// </summary>
        /// <param name="httpClient">HttpClient instance for making requests.</param>
        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Fetches weather data for a specific city and state from the OpenWeatherMap API.
        /// </summary>
        /// <param name="city">The city for which to fetch weather data.</param>
        /// <param name="state">The state code (e.g., KY for Kentucky).</param>
        /// <param name="unit">The unit system for temperature (imperial for Fahrenheit, metric for Celsius).</param>
        /// <returns>WeatherData object containing weather information for the city.</returns>
        /// <exception cref="Exception">Thrown when the city or state is not found, data is invalid, or other errors occur.</exception>
        public async Task<WeatherData> GetWeatherAsync(string city, string state, string unit = "imperial")
        {
            // API key for OpenWeatherMap (replace with a secure configuration in production).
            string apiKey = "eeec0a18c71c6b5670b043cc5fcf2f25";

            // API endpoint for fetching weather data with the specified city, state, and unit system.
            string apiUrl = $"https://api.openweathermap.org/data/2.5/weather?q={city},{state},US&appid={apiKey}&units={unit}";

            try
            {
                // Sends a GET request to the API endpoint.
                var response = await _httpClient.GetAsync(apiUrl);

                // Checks if the response indicates the city or state was not found.
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    throw new Exception($"Location '{city}, {state}' not found. Please check the spelling and try again.");
                }

                // Ensures the response status code indicates success.
                response.EnsureSuccessStatusCode();

                // Reads the response content as a string.
                var responseContent = await response.Content.ReadAsStringAsync();

                // Deserializes the JSON response into a WeatherData object.
                var weatherData = JsonConvert.DeserializeObject<WeatherData>(responseContent);

                // Checks if the weather data could not be parsed.
                if (weatherData == null)
                {
                    throw new Exception("Weather data could not be parsed. Please try again later.");
                }

                return weatherData;
            }
            catch (HttpRequestException httpEx)
            {
                // Handles network-related exceptions.
                throw new Exception("Network error: Unable to reach the weather API. Please check your internet connection.", httpEx);
            }
            catch (JsonException jsonEx)
            {
                // Handles exceptions related to JSON deserialization.
                throw new Exception("Error: Unable to process weather data. Please try again later.", jsonEx);
            }
            catch (Exception ex)
            {
                // Catches all other exceptions.
                throw new Exception($"An unexpected error occurred: {ex.Message}", ex);
            }
        }
    }
}
