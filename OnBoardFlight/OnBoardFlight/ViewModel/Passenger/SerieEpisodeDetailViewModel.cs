using Newtonsoft.Json;
using OnBoardFlight.Model;
using OnBoardFlight.ViewModel.Commands.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlight.ViewModel.Passenger
{
    public class SerieEpisodeDetailViewModel
    {
        public SerieEpisode SerieEpisode { get; set; }

        public PlaySerieCommand PlaySerieCommand { get; set; }

        public SerieEpisodeDetailViewModel(int episodeId)
        {
            PlaySerieCommand = new PlaySerieCommand(this);
            LoadData(episodeId);
        }

        private async void LoadData(int episode)
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:5000/api/Media/serie/episode/" + episode));
            SerieEpisode = JsonConvert.DeserializeObject<SerieEpisode>(json);
        }
    }
}
