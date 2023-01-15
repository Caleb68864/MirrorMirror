namespace MirrorMirrorMvvm.ViewModels;
using System.Threading.Tasks;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Avalonia.Threading;
using System.Threading;


class MainWindowViewModel : ViewModelBase
{
    // public string Greeting => GetGreeting();
    private readonly Timer _timer1;
    private readonly Timer _timer15;
    public string? _greeting;
    public string? Greeting
    {
        get
        {
            return _greeting;
        }
        set
        {
            // _greeting = GetGreeting();
            _greeting = value;
            OnPropertyChanged(nameof(Greeting));
        }
    }
    // public Task<WeatherData> Weather = OpenWeatherAPI.GetWeatherData("68944");
    public Task<WeatherData> _weather;
    public Task<WeatherData> Weather
    {
        get
        {
            return _weather;
        }
        set
        {
            _weather = value;
            OnPropertyChanged(nameof(Weather));
        }
    }

    public MainWindowViewModel()
    {
        Greeting = GetGreeting();
        Weather = OpenWeatherAPI.GetWeatherData("68944");
        _timer1 = new Timer(Minute_1_Tick, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
        _timer15 = new Timer(Minute_15_Tick, null, TimeSpan.Zero, TimeSpan.FromMinutes(15));
    }

    private void Minute_1_Tick(object state)
    {
        Greeting = GetGreeting();
        // Console.WriteLine(Greeting);
    }

    private void Minute_15_Tick(object state)
    {
        Weather = OpenWeatherAPI.GetWeatherData("68944");
    }

    public string GetGreeting()
    {
        int hour = DateTime.Now.Hour;
        string time = DateTime.Now.ToString("h:mm tt");
        // Console.WriteLine(hour);
        if (hour >= 0 && hour < 12)
        {
            return "Good Morning, It's " + time;
        }
        else if (hour >= 12 && hour < 18)
        {
            return "Good Afternoon, It's " + time;
        }
        else
        {
            return "Good Evening, It's " + time;
        }
    }


}
