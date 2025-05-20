namespace WeatherManCLICSharp;

public class Downloader(string city, string? country)
{
    public async Task<string?> Download()
    {
        string url;
        if (country == null)
        {
            url =
                $"http://api.openweathermap.org/data/2.5/weather?q={city}&appid=d21991d7851f849bfe8cc24d12c795d0&units=metric&lang=fr";
        }
        else
        {
            url =
                $"http://api.openweathermap.org/data/2.5/weather?q={city},{country}&appid=d21991d7851f849bfe8cc24d12c795d0&units=metric&lang=fr";
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