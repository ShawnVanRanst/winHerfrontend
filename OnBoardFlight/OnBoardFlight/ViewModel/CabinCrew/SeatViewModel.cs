using OnBoardFlight.ViewModel.Commands.CabinCrew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlight.ViewModel.CabinCrew
{
    public class SeatViewModel
    {


        public Model.Passenger Passenger1 { get; set; }

        public Model.Passenger Passenger2 { get; set; }

        public string SeatPassenger1 { get; set; }

        public string SeatPassenger2 { get; set; }


        public SearchPassengerCommand SearchPassengerCommand{ get; set; }


        public SeatViewModel()
        {
            SearchPassengerCommand = new SearchPassengerCommand(this);
        }


        public void SearchPassenger()
        {

        }
    }
}
