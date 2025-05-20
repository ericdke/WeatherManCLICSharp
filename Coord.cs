using Newtonsoft.Json;

namespace WeatherManCLICSharp;

public class Coord
{
    [JsonProperty("lon")]
    public required double Lon { get; set; }

    [JsonProperty("lat")]
    public required double Lat { get; set; }
}