using Newtonsoft.Json;
using OnBoardFlight.Model;
using OnBoardFlight.Model.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlight.ViewModel.Passenger
{
    public class NavigationPassengerViewModel
    {
        public Model.Passenger Passenger { get; set; }

        public GeneralLogin GeneralLogin { get; set; }

        public NavigationPassengerViewModel(GeneralLogin login)
        {
            GeneralLogin = login;
        }
    }
}
