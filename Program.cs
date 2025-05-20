using Newtonsoft.Json;
using MatthiWare.CommandLine;

namespace WeatherManCLICSharp;

class Program
{
    public static async Task Main(string[] args)
    {
        var parser = new CommandLineParser<OptionsModel>();
        var parsedResult = await parser.ParseAsync(args);
        if (parsedResult.HasErrors)
        {
            foreach (var error in parsedResult.Errors)
            {
                await Console.Error.WriteLineAsync(error.Message);
            }
            return;
        }
        var options = parsedResult.Result;
        
        var down = new Downloader(options.City, options.Country);
        var content = await down.Download();
        if (content == null)
        {
            Console.WriteLine("Couldn't download content");
        }
        else
        {
            try
            {
                WeatherResult? result = JsonConvert.DeserializeObject<WeatherResult>(content);
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
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
           
        }
    }
    
    static string CapitalizeFirstLetter(string s) {
        if (String.IsNullOrEmpty(s))
            return s;
        if (s.Length == 1)
            return s.ToUpper();
        return s.Remove(1).ToUpper() + s.Substring(1);
    }
}