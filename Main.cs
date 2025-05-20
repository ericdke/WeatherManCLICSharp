using Newtonsoft.Json;

namespace WeatherManCLICSharp;

public class Main
{
    [JsonProperty("temp")]
    public required double Temp { get; set; }

    [JsonProperty("feels_like")]
    public required double FeelsLike { get; set; }

    [JsonProperty("temp_min")]
    public required double TempMin { get; set; }

    [JsonProperty("temp_max")]
    public required double TempMax { get; set; }

    [JsonProperty("pressure")]
    public required int Pressure { get; set; }

    [JsonProperty("humidity")]
    public required int Humidity { get; set; }

    [JsonProperty("sea_level")]
    public required int SeaLevel { get; set; }

    [JsonProperty("grnd_level")]
    public required int GrndLevel { get; set; }
}