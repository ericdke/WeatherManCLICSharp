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
        }
    }
    
    private string CapitalizeFirstLetter(string s) {
        if (String.IsNullOrEmpty(s))
            return s;
        if (s.Length == 1)
            return s.ToUpper();
        return s.Remove(1).ToUpper() + s.Substring(1);
    }
}