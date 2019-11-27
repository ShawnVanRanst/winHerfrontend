using OnBoardFlight.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlight.ViewModel.Passenger
{
    public class SerieDetailViewModel
    {
        public Serie Serie { get; set; }

        public SerieDetailViewModel(Serie serie)
        {
            Serie = serie;
        }
    }
}
