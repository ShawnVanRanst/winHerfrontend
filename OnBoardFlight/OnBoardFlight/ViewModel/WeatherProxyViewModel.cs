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
            var response = await http.GetAsync("http://api.openweathermap.org/data/2.5/forecast?q=" + flight.Destination.City + "," + flight.Destination.CountryIso + "&APPID=2cdd81f58ad3cba16057c6ce550e242d");
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(RootObject));

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            RootObject weatherData = (RootObject)serializer.ReadObject(ms);

            FillWeatherList(weatherData);
        }

        private void FillWeatherList(RootObject weatherData)
        {
            WeatherList.Add(new Model.Weather()
            {
                When = "Now",
                Icon = new BitmapImage(new Uri(string.Format("http://openweathermap.org/img/w/{0}.png", weatherData.list[0].weather[0].icon), UriKind.Absolute)),
                Description = weatherData.list[0].weather[0].description,
                Temp = (int)Math.Round(weatherData.list[0].main.temp - 273.15),
                WindSpeed = weatherData.list[0].wind.speed * 3.6,
                WindOrientation = weatherData.list[0].wind.deg
            });

            foreach (List list in weatherData.list)
            {
                if (list.dt_txt.Contains("12:00:00"))
                {
                    WeatherList.Add(new Model.Weather()
                    {
                        When = DateTime.Parse(list.dt_txt).DayOfWeek.ToString(),
                        Icon = new BitmapImage(new Uri(string.Format("http://openweathermap.org/img/w/{0}.png", list.weather[0].icon), UriKind.Absolute)),
                        Description = list.weather[0].description,
                        Temp = (int)Math.Round(list.main.temp_max - 273.15),
                        WindSpeed = list.wind.speed * 3.6,
                        WindOrientation = list.wind.deg
                    });
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
