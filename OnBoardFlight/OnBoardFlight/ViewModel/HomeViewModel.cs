using OnBoardFlight.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlight.ViewModel
{
    public class HomeViewModel
    {
        public Flight Flight { get; set; }

        public HomeViewModel()
        {
            //call naar api
            Flight = DummyDataSource.Flight;
        }
    }
}
