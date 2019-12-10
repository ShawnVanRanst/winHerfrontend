using OnBoardFlight.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlight.ViewModel.Passenger
{
    public class EpisodeDetailsViewModel
    {
        public SerieEpisode SerieEpisode { get; set; }

        public EpisodeDetailsViewModel(int episodeId)
        {

        }

        private async void LoadData(int episodeId)
        {

        }
    }
}
