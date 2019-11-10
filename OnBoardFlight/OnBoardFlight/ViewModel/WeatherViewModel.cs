using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlight.ViewModel
{
    public class WeatherViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Model.Weather> WeatherList { get; set; }
        private WeatherProxyViewModel WeatherProxyViewModel { get; set; }

        public WeatherViewModel()
        {
            WeatherProxyViewModel = new WeatherProxyViewModel();
            
            WeatherList = new ObservableCollection<Model.Weather>();
            //Task.Run(() => this.LoadWeather()).Wait();
            //Model.Weather w = new Model.Weather() { Description = "test" };
            //List<Model.Weather> test = new List<Model.Weather>();
            //test.Add(w);
            //WeatherList = new ObservableCollection<Model.Weather>(test);
        }

        //private async void LoadWeather()
        //{
        //    List<Model.Weather> list = await WeatherProxyViewModel.ConvertToWeatherList();
        //    WeatherList = new ObservableCollection<Model.Weather>(list);
        //}

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
