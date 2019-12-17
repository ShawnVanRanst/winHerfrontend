using Newtonsoft.Json;
using OnBoardFlight.Model;
using OnBoardFlight.Model.Helper;
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
using Windows.Web.Http;

namespace OnBoardFlight.ViewModel
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        private Flight _flight;

        public Flight Flight
        {
            get { return _flight; }
            set { _flight = value; RaisePropertyChanged("Flight"); }
        }


        public ObservableCollection<Model.Weather> WeatherList { get; set; }

        public HomeViewModel(GeneralLogin generalLogin)
        {
            Flight = new Flight();
            if(generalLogin.GetType() == typeof(CabinCrewLogin))
            {
                LoadCabinMember((CabinCrewLogin)generalLogin);
            }
            else
            {
                LoadPassenger(generalLogin);
            }
            WeatherList = new ObservableCollection<Model.Weather>();
            GetWeatherData();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Get the Weather from the API
        private async void GetWeatherData()
        {
            var http = new System.Net.Http.HttpClient();
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

        public async void LoadCabinMember(CabinCrewLogin cabinCrewLogin)
        {
            var cabinCrewJson = JsonConvert.SerializeObject(cabinCrewLogin);
            Windows.Web.Http.HttpClient client = new Windows.Web.Http.HttpClient();
            var res = await client.PostAsync(new Uri("http://localhost:5000/api/User/cabincrew/login"), new HttpStringContent(cabinCrewJson, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json"));

            if (res.IsSuccessStatusCode)
            {
                Model.CabinCrew cr = JsonConvert.DeserializeObject<Model.CabinCrew>(res.Content.ToString());
                if (cr != null)
                {
                    Flight = cr.Flight;
                }
            }
        }

        public async void LoadPassenger(GeneralLogin generalLogin)
        {
            Windows.Web.Http.HttpClient client = new Windows.Web.Http.HttpClient();
            try
            {
                var json = await client.GetStringAsync(new Uri("http://localhost:5000/api/User/passenger/" + generalLogin.Login));
                var passenger = JsonConvert.DeserializeObject<Model.Passenger>(json);
                if (passenger != null)
                {
                    Flight = passenger.Flight;
                }
            }
            catch (Exception){};
        }
    }
}
