using Newtonsoft.Json;

namespace WeatherManCLICSharp;

public class Clouds
{
    [JsonProperty("all")]
    public required int All { get; set; }
}