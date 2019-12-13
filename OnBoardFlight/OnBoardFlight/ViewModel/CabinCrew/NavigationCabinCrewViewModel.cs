using Newtonsoft.Json;
using OnBoardFlight.Model;
using OnBoardFlight.Model.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace OnBoardFlight.ViewModel.CabinCrew
{
    public class NavigationCabinCrewViewModel
    {
        public CabinCrewLogin CabinCrewLogin { get; set; }

        public NavigationCabinCrewViewModel(CabinCrewLogin cabinCrewLogin)
        {
            CabinCrewLogin = cabinCrewLogin;
        }
    }
}
