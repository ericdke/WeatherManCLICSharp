using Microsoft.Extensions.Configuration;

namespace WeatherManCLICSharp;

public class WeatherPrinter(OptionsModel options, WeatherResult? result) 
{
    public void Print()
    {
        if (result == null)
        {
            Console.WriteLine("Couldn't parse content");
        }
        else
        {
            var city = CapitalizeFirstLetter(options.City.ToLower());
            if (options.Country != null)
            {
                Console.WriteLine($"{city}, {CapitalizeFirstLetter(options.Country.ToLower())}");
            }
            else
            {
                Console.WriteLine($"{city}, {result.Sys.Country}");
            }
                    
            var dt = DateTimeOffset.FromUnixTimeSeconds(result.Dt).LocalDateTime;
            Console.WriteLine(dt);
                    
            Console.WriteLine($"{result.Main.Temp} ºC");
                    
            var desc = CapitalizeFirstLetter(result.Weather[0].Description);
            Console.WriteLine(desc);

            if (result.Wind != null)
            {
                Console.Write(DegreesToCompass(result.Wind.Deg) + " ");
                Console.WriteLine(result.Wind.Speed + " km/h");
            }
        }
    }
    
    private string CapitalizeFirstLetter(string s) {
        if (String.IsNullOrEmpty(s))
            return s;
        if (s.Length == 1)
            return s.ToUpper();
        return s.Remove(1).ToUpper() + s.Substring(1);
    }

    private string DegreesToCompass(int degrees)
    {
        List<string> compass =
            ["Nord", "Nord Nord-Est", "Nord-Est", "Est Nord-Est", "Est", "Est Sud-Est", "Sud-Est", "Sud Sud-Est", "Sud", "Sud Sud-Ouest", "Sud-Ouest", "Ouest Sud-Ouest", "Ouest", "Ouest Nord-Ouest", "Nord-Ouest", "Nord Nord-Ouest"];
        var i = ((degrees / 22.5) + 0.5) % 16;
        return compass[(int)i];
    }
}