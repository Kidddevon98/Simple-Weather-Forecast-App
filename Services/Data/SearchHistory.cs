using System;

namespace WeatherApp.Services.Data
{
    public class SearchHistory
    {
        public int Id { get; set; }
        public string? CityName { get; set; } // Nullable
        public DateTime SearchDate { get; set; }
    }
}

