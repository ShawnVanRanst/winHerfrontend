using OnBoardFlight.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlight.ViewModel.CabinCrew
{
    public class NavigationCabinCrewViewModel
    {
        public Model.CabinCrew CabinCrew { get; set; }

        public NavigationCabinCrewViewModel(Model.CabinCrew cabinCrew)
        {
            CabinCrew = cabinCrew;
        }
    }
}
