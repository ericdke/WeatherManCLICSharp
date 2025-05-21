using System.Diagnostics;
using Microsoft.Extensions.Configuration;

namespace WeatherManCLICSharp;

public class Downloader(string city, string? country, IConfigurationRoot config)
{
    public async Task<string?> Download()
    {
        var units = config.GetValue<string>("units");
        var lang = config.GetValue<string>("lang");

        string url;
        if (country == null)
        {
            url =
                $"http://api.openweathermap.org/data/2.5/weather?q={city}&appid=d21991d7851f849bfe8cc24d12c795d0&units={units}&lang={lang}";
        }
        else
        {
            url =
                $"http://api.openweathermap.org/data/2.5/weather?q={city},{country}&appid=d21991d7851f849bfe8cc24d12c795d0&units={units}&lang={lang}";
        }
        var client = new HttpClient();
        try
        {
            var response = await client.GetAsync(url);
            return await response.Content.ReadAsStringAsync();;
        }
        catch (Exception ex)
        {
            await Console.Error.WriteLineAsync(ex.Message);
            return null;
        }
        finally
        {
            client.Dispose();
        }
    }
}