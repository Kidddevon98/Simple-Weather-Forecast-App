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

            var response = await _httpClient.GetStringAsync(apiUrl);
            return JsonConvert.DeserializeObject<WeatherData>(response);
        }
    }
}
