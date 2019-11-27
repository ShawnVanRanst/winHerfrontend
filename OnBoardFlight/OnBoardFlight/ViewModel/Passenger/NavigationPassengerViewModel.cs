using OnBoardFlight.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlight.ViewModel.Passenger
{
    public class NavigationPassengerViewModel
    {
        public Model.Passenger Passenger { get; set; }

        public NavigationPassengerViewModel(Model.Passenger passenger)
        {
            Passenger = passenger;
        }
    }
}
