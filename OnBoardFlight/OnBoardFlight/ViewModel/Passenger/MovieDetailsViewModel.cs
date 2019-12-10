using Newtonsoft.Json;
using OnBoardFlight.Model.Media;
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
    public class MovieDetailsViewModel : INotifyPropertyChanged
    {
        private Movie _movie;

        public Movie Movie
        {
            get { return _movie; }
            set { _movie = value; RaisePropertyChanged("Movie"); }
        }

        public PlayMovieCommand PlayMovie { get; set; }

        public MovieDetailsViewModel(int movieId)
        {
            LoadMovie(movieId);
            //Movie = (Movie)DummyDataSource.MovieList().First();
            PlayMovie = new PlayMovieCommand(this);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async void LoadMovie(int movieId)
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:5000/api/Media/movie/" + movieId));
            Movie = JsonConvert.DeserializeObject<Movie>(json);
        }
    }
}
