using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;

        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WeatherData> GetWeatherAsync(string city)
        {
            string apiKey = "eeec0a18c71c6b5670b043cc5fcf2f25";
            string apiUrl = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=imperial";

            try
            {
                var response = await _httpClient.GetAsync(apiUrl);

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    throw new Exception($"City '{city}' not found. Please check the spelling and try again.");
                }

                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();
                var weatherData = JsonConvert.DeserializeObject<WeatherData>(responseContent);

                if (weatherData == null)
                {
                    throw new Exception("Weather data could not be parsed. Please try again later.");
                }

                return weatherData;
            }
            catch (HttpRequestException httpEx)
            {
                throw new Exception("Network error: Unable to reach the weather API. Please check your internet connection.", httpEx);
            }
            catch (JsonException jsonEx)
            {
                throw new Exception("Error: Unable to process weather data. Please try again later.", jsonEx);
            }
            catch (Exception ex)
            {
                throw new Exception($"An unexpected error occurred: {ex.Message}", ex);
            }
        }
    }
}
