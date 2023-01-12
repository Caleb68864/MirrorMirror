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
<<<<<<< HEAD
            //WeatherData data = await OpenWeatherAPI.GetWeatherData("68944");
            //Console.WriteLine($"Temperature in {data.Name} is {data.Temperature} C");
=======
            WeatherData data = await OpenWeatherAPI.GetWeatherData("68944");
            Console.WriteLine($"Temperature in {data.Name} is {data.Temperature} C");
>>>>>>> d0f9fcb (	new file:   .vscode/launch.json)
            // Add any other initialization code that should be performed after the weather data has been fetched here
            InitializeComponent();
        }
    }
}
