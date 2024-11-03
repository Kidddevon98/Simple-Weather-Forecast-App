using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using WeatherApp.Services;


namespace WeatherApp.Pages;

public class IndexModel : PageModel
{
    private readonly WeatherService _weatherService;

    public IndexModel(WeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    public string WeatherData { get; set; } = string.Empty;

    public async Task OnPostSearchAsync(string city)
    {
        var weather = await _weatherService.GetWeatherAsync(city);

    // Extract specific details from the JSON
    var temperature = weather["main"]["temp"];
    var feelsLike = weather["main"]["feels_like"];
    var description = weather["weather"][0]["description"];
    var humidity = weather["main"]["humidity"];

    // Format the weather data as a string
    WeatherData = $"Temperature: {temperature}°F\n" +
                  $"Feels Like: {feelsLike}°F\n" +
                  $"Description: {description}\n" +
                  $"Humidity: {humidity}%";
    }
}

