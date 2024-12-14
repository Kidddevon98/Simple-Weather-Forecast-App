using System;

namespace WeatherApp.Services.Data
{
    /// <summary>
    /// Represents a record of a weather search performed by the user.
    /// </summary>
    public class SearchHistory
    {
        /// <summary>
        /// Gets or sets the unique identifier for the search history entry.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the city and state searched by the user.
        /// Nullable to handle cases where the city name might not be provided.
        /// </summary>
        public string? CityName { get; set; } // Nullable

        /// <summary>
        /// Gets or sets the date and time when the search was performed.
        /// </summary>
        public DateTime SearchDate { get; set; }
    }
}
