using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace WeatherApp.Services
{
   public class WeatherService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<WeatherService> _logger;

    public WeatherService(HttpClient httpClient, ILogger<WeatherService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<JObject> GetWeatherAsync(string city)
    {
        try
        {
            _logger.LogInformation($"Fetching weather data for {city}.");
            var response = await _httpClient.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={_apiKey}&units=imperial");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            _logger.LogInformation("Weather data successfully fetched.");
            return JObject.Parse(content);
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError($"Error fetching weather data for {city}: {ex.Message}");
            throw new Exception("Failed to fetch weather data. Please try again later.", ex);
        }
    }
}
