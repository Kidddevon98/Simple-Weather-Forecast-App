using System.Collections.Generic;

namespace WeatherApp.Models
{
    /// <summary>
    /// Root model class that maps to the OpenWeatherMap API response.
    /// </summary>
    public class WeatherData
    {
        /// <summary>
        /// Represents the main weather details such as temperature, humidity, and pressure.
        /// </summary>
        public Main Main { get; set; } = new Main(); // Initialize with default object

        /// <summary>
        /// List of weather descriptions (e.g., "clear sky", "rain").
        /// </summary>
        public List<Weather> Weather { get; set; } = new List<Weather>();

        /// <summary>
        /// Represents wind details such as speed.
        /// </summary>
        public Wind Wind { get; set; } = new Wind();

        /// <summary>
        /// Represents system-level details like sunrise and sunset times.
        /// </summary>
        public Sys Sys { get; set; } = new Sys();

        /// <summary>
        /// Represents the visibility level in meters.
        /// </summary>
        public int Visibility { get; set; }
    }

    /// <summary>
    /// Represents the main weather metrics such as temperature, humidity, and pressure.
    /// </summary>
    public class Main
    {
        /// <summary>
        /// The current temperature in Fahrenheit.
        /// </summary>
        public float Temp { get; set; }

        /// <summary>
        /// The "feels like" temperature in Fahrenheit.
        /// </summary>
        public float Feels_Like { get; set; }

        /// <summary>
        /// The humidity percentage.
        /// </summary>
        public int Humidity { get; set; }

        /// <summary>
        /// The atmospheric pressure in hPa.
        /// </summary>
        public int Pressure { get; set; }
    }

    /// <summary>
    /// Represents weather descriptions provided by the API.
    /// </summary>
    public class Weather
    {
        /// <summary>
        /// A brief description of the weather (e.g., "clear sky").
        /// </summary>
        public string Description { get; set; } = string.Empty; // Initialize as empty string
    }

    /// <summary>
    /// Represents wind details such as speed.
    /// </summary>
    public class Wind
    {
        /// <summary>
        /// The wind speed in meters per second.
        /// </summary>
        public float Speed { get; set; }
    }

    /// <summary>
    /// Represents system-level details such as sunrise and sunset times.
    /// </summary>
    public class Sys
    {
        /// <summary>
        /// The Unix timestamp for sunrise.
        /// </summary>
        public long Sunrise { get; set; }

        /// <summary>
        /// The Unix timestamp for sunset.
        /// </summary>
        public long Sunset { get; set; }
    }
}
