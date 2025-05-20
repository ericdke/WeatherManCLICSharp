using Newtonsoft.Json;

namespace WeatherManCLICSharp;

class Program
{
    public static async Task Main(string[] args)
    {
        var down = new Downloader("paris", "FR");
        var content = await down.Download();
        if (content == null)
        {
            Console.WriteLine("Couldn't download content");
        }
        else
        {
            Console.WriteLine(content);
            try
            {
                WeatherResult? result = JsonConvert.DeserializeObject<WeatherResult>(content);
                if (result == null)
                {
                    Console.WriteLine("Couldn't parse content");
                }
                else
                {
                    Console.WriteLine(result.Main?.Temp);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
           
        }
        
        
    }
}