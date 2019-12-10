using Newtonsoft.Json;
using OnBoardFlight.Model;
using OnBoardFlight.ViewModel.Commands.Media;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlight.ViewModel.Passenger
{
    public class SerieDetailViewModel : INotifyPropertyChanged
    {
        private Serie _serie;

        public Serie Serie
        {
            get { return _serie; }
            set { _serie = value; RaisePropertyChanged("Serie"); }
        }

        public SerieDetailViewModel(int serieId)
        {
            LoadSerie(serieId);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async void LoadSerie(int serieId)
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:5000/api/Media/serie/" + serieId));
            Serie = JsonConvert.DeserializeObject<Serie>(json);
        }
    }
}
