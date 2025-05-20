using Newtonsoft.Json;

namespace WeatherManCLICSharp;

public class Wind
{
    [JsonProperty("speed")]
    public required double Speed { get; set; }

    [JsonProperty("deg")]
    public required int Deg { get; set; }

    [JsonProperty("gust")]
    public required double Gust { get; set; }
}