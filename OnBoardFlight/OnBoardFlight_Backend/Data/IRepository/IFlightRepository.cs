using OnBoardFlight.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardFlight_Backend.Data.IRepository
{
    interface IFlightRepository
    {
        IEnumerable<Flight> GetFlights();
    }
}
