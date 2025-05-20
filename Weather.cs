using Newtonsoft.Json;

namespace WeatherManCLICSharp;

public class Weather
{
    [JsonProperty("id")]
    public required int Id { get; set; }

    [JsonProperty("main")]
    public required string Main { get; set; }

    [JsonProperty("description")]
    public required string Description { get; set; }

    [JsonProperty("icon")]
    public required string Icon { get; set; }
}