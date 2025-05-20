using Newtonsoft.Json;

namespace WeatherManCLICSharp;

public class WeatherResult
{
    [JsonProperty("coord")]
    public required Coord Coord { get; set; }

    [JsonProperty("weather")]
    public required List<Weather> Weather { get; set; }

    [JsonProperty("base")]
    public required string Base { get; set; }

    [JsonProperty("main")]
    public required Main Main { get; set; }

    [JsonProperty("visibility")]
    public required int Visibility { get; set; }

    [JsonProperty("wind")]
    public Wind? Wind { get; set; }

    [JsonProperty("clouds")]
    public required Clouds Clouds { get; set; }

    [JsonProperty("dt")]
    public required int Dt { get; set; }

    [JsonProperty("sys")]
    public required Sys Sys { get; set; }

    [JsonProperty("timezone")]
    public required int Timezone { get; set; }

    [JsonProperty("id")]
    public required int Id { get; set; }

    [JsonProperty("name")]
    public required string Name { get; set; }

    [JsonProperty("cod")]
    public required int Cod { get; set; }
}