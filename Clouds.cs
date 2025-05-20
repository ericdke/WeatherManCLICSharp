using Newtonsoft.Json;

namespace WeatherManCLICSharp;

public class Clouds
{
    [JsonProperty("all")]
    public int All { get; set; }
}