using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

class WeatherData
{
    public string Name { get; set; }
    public double Temperature { get; set; }
    public double Humidity { get; set; }
    public double WindSpeed { get; set; }
}

class OpenWeatherAPI
{
    private const string API_KEY = "bddf0cd56c584112a50d217a543ee815";
    private const string API_URL = "https://api.openweathermap.org/data/2.5/weather";

    public static async Task<WeatherData> GetWeatherData(string city)
    {
        using (HttpClient client = new HttpClient())
        {
            string url = $"{API_URL}?q={city}&appid={API_KEY}&units=metric";
            // string url = "https://random-data-api.com/api/v2/users?size=2&is_xml=true";
            // Console.WriteLine(url);
            // string json = await client.GetStringAsync(url);
            // Console.WriteLine(json);
            // return JsonConvert.DeserializeObject<WeatherData>(json);
            using (var response = await client.GetAsync(url))
            {
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Error: " + response.ReasonPhrase);
                    return null;
                }
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<WeatherData>(json);
            }
        }
    }
}