using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

class WeatherData
{
    public string Name { get; set; }
    public WeatherData()
    {
        Name = "";
    }

    public string? NameLine
    {
        get
        {
            return "Today's Forecast for " + Name;
        }
    }

    // public Weather? Weather { get; set; }
    public Main? Main { get; set; }
    public Wind? Wind { get; set; }
}

class Weather
{
    // public string? Main { get; set; }
    public string? Description { get; set; }
    public string? Icon { get; set; }
    public string? IconUrl
    {
        get
        {
            return "http://openweathermap.org/img/wn/" + Icon + "@2x.png";
        }
    }
}

class Main
{
    public double? Temp { get; set; }

    public string GetDegree(double? t)
    {
        return t + " °F";
    }
    public double? Feels_Like { get; set; }
    public double? Temp_Max { get; set; }
    public double? Temp_Min { get; set; }
    public double? Humidity { get; set; }
    public string TempDegree
    {
        get
        {
            return GetDegree(Temp);
        }
    }
    public string FeelsLikeDegree
    {
        get
        {
            return GetDegree(Feels_Like);
        }
    }
    public string HighDegree
    {
        get
        {
            return GetDegree(Temp_Max);
        }
    }
    public string LowDegree
    {
        get
        {
            return GetDegree(Temp_Min);
        }
    }
    public string HumidityPercent
    {
        get
        {
            return Humidity + "%";
        }
    }
}

class Wind
{
    public double? Speed { get; set; }
    public double? Deg { get; set; }
    public string WindSpeed
    {
        get
        {
            return GetDirection() + " " + Speed + " MPH";
        }
    }

    public string GetDirection()
    {
        if (Deg >= 337.5 || Deg < 22.5)
            return "N";
        if (Deg >= 22.5 && Deg < 67.5)
            return "NE";
        if (Deg >= 67.5 && Deg < 112.5)
            return "E";
        if (Deg >= 112.5 && Deg < 157.5)
            return "SE";
        if (Deg >= 157.5 && Deg < 202.5)
            return "S";
        if (Deg >= 202.5 && Deg < 247.5)
            return "SW";
        if (Deg >= 247.5 && Deg < 292.5)
            return "W";
        if (Deg >= 292.5 && Deg < 337.5)
            return "NW";
        return "Invalid degree input";
    }
}

class OpenWeatherAPI
{
    private const string API_KEY = "bddf0cd56c584112a50d217a543ee815";
    private const string API_URL = "https://api.openweathermap.org/data/2.5/weather";

    public static async Task<WeatherData> GetWeatherData(string city)
    {
        using (HttpClient client = new HttpClient())
        {
            string url = $"{API_URL}?q={city}&appid={API_KEY}&units=imperial";
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
                // Console.WriteLine(json);
                WeatherData wd = new WeatherData();
                wd = JsonConvert.DeserializeObject<WeatherData>(json);
                // Console.WriteLine(wd);
                // Console.WriteLine(wd.Name);
                // Console.WriteLine(wd.Main.Temp);
                // Console.WriteLine(wd.Wind.Speed);
                return wd;
            }
        }
    }
}