using MatthiWare.CommandLine.Core.Attributes;

namespace WeatherManCLICSharp;

public class OptionsModel
{
    [Required, Name("c", "city"), Description("The name of the city")]
    public string City { get; set; }
    
    [Name("t", "country"), Description("The name of the country")]
    public string? Country { get; set; }
}