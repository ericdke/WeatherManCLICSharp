using System.Reflection;
using MatthiWare.CommandLine;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

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
        
        var configBuilder = new ConfigurationBuilder()
            .SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        var config = configBuilder.Build();

        var down = new Downloader(options.City, options.Country, config);
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
                var printer = new WeatherPrinter(options, result);
                printer.Print();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
           
        }
    }
}