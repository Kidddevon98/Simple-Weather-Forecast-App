using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System;
using WeatherApp.Services.Data;
using Microsoft.EntityFrameworkCore;

namespace WeatherApp.Services
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<WeatherService> _logger;
        private readonly WeatherAppDbContext _dbContext;
        private readonly string _apiKey = "eeec0a18c71c6b5670b043cc5fcf2f25"; // Replace with your OpenWeatherMap API key

        public WeatherService(HttpClient httpClient, ILogger<WeatherService> logger, WeatherAppDbContext dbContext)
        {
            _httpClient = httpClient;
            _logger = logger;
            _dbContext = dbContext;
        }

        // Method to get weather data from OpenWeatherMap API
        public async Task<JObject?> GetWeatherAsync(string city)
        {
            try
            {
                var response = await _httpClient.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={_apiKey}&units=imperial");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var weatherData = JObject.Parse(content);

                // Save the search history to the database
                var searchHistory = new SearchHistory
                {
                    CityName = city,
                    SearchDate = DateTime.Now
                };
                _dbContext.SearchHistories.Add(searchHistory);
                await _dbContext.SaveChangesAsync();

                return weatherData;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error fetching weather data: {ex.Message}");
                return null;
            }
        }

        // Method to retrieve recent searches from the database
        public async Task<List<SearchHistory>> GetRecentSearchesAsync()
        {
            return await _dbContext.SearchHistories
                .OrderByDescending(s => s.SearchDate)
                .Take(5)
                .ToListAsync();
        }
    }
}
