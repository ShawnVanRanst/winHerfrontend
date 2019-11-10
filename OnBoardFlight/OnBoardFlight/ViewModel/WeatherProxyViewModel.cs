using OnBoardFlight.Model;
using OnBoardFlight.Model.WeatherApi;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

// Request the weather from openweathermap api, has to be moved to repository
namespace OnBoardFlight.ViewModel
{
    public class WeatherProxyViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Model.Weather> WeatherList { get; set; }
        public WeatherProxyViewModel()
        {
            WeatherList = new ObservableCollection<Model.Weather>();
            GetWeatherData();
        }

        // Get the Weather from the API
        private async void GetWeatherData()
        {
            var http = new HttpClient();
            Flight flight = DummyDataSource.Flight; // BACKEND CALL
            var response = await http.GetAsync("http://api.openweathermap.org/data/2.5/forecast?q=Barcelona,spa&APPID=2cdd81f58ad3cba16057c6ce550e242d");
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(RootObject));

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            RootObject weatherData = (RootObject)serializer.ReadObject(ms);

            string icon = string.Format("http://openweathermap.org/img/w/{0}.png", weatherData.list[0].weather[0].icon);
            WeatherList.Add(new Model.Weather()
            {
                When = "Now",
                Icon = new BitmapImage(new Uri(string.Format("http://openweathermap.org/img/w/{0}.png", weatherData.list[0].weather[0].icon), UriKind.Absolute)),
                Description = weatherData.list[0].weather[0].description,
                MaxTemp = (int)Math.Round(weatherData.list[0].main.temp_max - 273.15),
                MinTemp = (int)Math.Round(weatherData.list[0].main.temp_min - 273.15),
                WindSpeed = weatherData.list[0].wind.speed * 3.6,
                WindOrientation = weatherData.list[0].wind.deg
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
