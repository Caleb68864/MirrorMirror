namespace MirrorMirrorMvvm.ViewModels;
using System.Threading.Tasks;
using System;

class MainWindowViewModel : ViewModelBase
{
    string GetGreeting() {
    int hour = DateTime.Now.Hour;
    if (hour >= 0 && hour < 6) {
        return "Good Morning,";
    } else if (hour >= 12 && hour < 18) {
        return "Good Afternoon,";
    } else {
        return "Good Evening,";
    }
}
    public string Greeting => GetGreeting();
    public Task<WeatherData> Weather => OpenWeatherAPI.GetWeatherData("68944");
}
