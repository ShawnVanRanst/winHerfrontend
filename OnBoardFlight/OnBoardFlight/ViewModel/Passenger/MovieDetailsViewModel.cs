using OnBoardFlight.Model.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlight.ViewModel.Passenger
{
    public class MovieDetailsViewModel
    {
        public Movie Movie { get; set; }

        public MovieDetailsViewModel(Movie movie)
        {
            Movie = movie;
        }
    }
}
