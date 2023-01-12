using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Avalonia.Controls;

namespace MirrorMirror
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponentAsync().Wait();
        }

        private async Task InitializeComponentAsync()
        {
            WeatherData data = await OpenWeatherAPI.GetWeatherData("68944");
            Console.WriteLine($"Temperature in {data.Name} is {data.Temperature} C");
            // Add any other initialization code that should be performed after the weather data has been fetched here
            InitializeComponent();
        }
    }
}
