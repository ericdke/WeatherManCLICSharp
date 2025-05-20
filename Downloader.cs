namespace WeatherManCLICSharp;

public class Downloader
{
    private string city;
    private string country;
    public Downloader(string city, string country)
    {
        this.city = city;
        this.country = country;
    }
    
    public async Task<string?> Download()
    {
        var url =
            $"http://api.openweathermap.org/data/2.5/weather?q={city},{country}&appid=d21991d7851f849bfe8cc24d12c795d0&units=metric&lang=fr";
        var client = new HttpClient();
        try
        {
            var response = await client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }
}