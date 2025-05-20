using Newtonsoft.Json;

namespace WeatherManCLICSharp;

public class Sys
{
    [JsonProperty("type")]
    public required int Type { get; set; }

    [JsonProperty("id")]
    public required int Id { get; set; }

    [JsonProperty("country")]
    public required string Country { get; set; }

    [JsonProperty("sunrise")]
    public required int Sunrise { get; set; }

    [JsonProperty("sunset")]
    public required int Sunset { get; set; }
}