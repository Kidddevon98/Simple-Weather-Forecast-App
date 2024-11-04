using System.Collections.Generic;

namespace WeatherApp.Models
{
    // Root model class that maps to the OpenWeatherMap API response
   public class WeatherData
{
    public Main Main { get; set; } = new Main(); // Initialize with default object
    public List<Weather> Weather { get; set; } = new List<Weather>();
    public Wind Wind { get; set; } = new Wind();
    public Sys Sys { get; set; } = new Sys();
    public int Visibility { get; set; }
}

public class Main
{
    public float Temp { get; set; }
    public float Feels_Like { get; set; }
    public int Humidity { get; set; }
    public int Pressure { get; set; }
}

public class Weather
{
    public string Description { get; set; } = string.Empty; // Initialize as empty string
}

public class Wind
{
    public float Speed { get; set; }
}

public class Sys
{
    public long Sunrise { get; set; }
    public long Sunset { get; set; }
}

}
