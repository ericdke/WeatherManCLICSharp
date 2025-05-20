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
                    Console.WriteLine(result.Main.Temp);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
           
        }
    }
}