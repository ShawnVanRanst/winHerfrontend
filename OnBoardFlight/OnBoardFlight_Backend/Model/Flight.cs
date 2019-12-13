using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardFlight.Model
{
    public class Flight
    {
        public int FlightId { get; set; }

        public Location Origin { get; set; }

        public Location Destination { get; set; }
    }
}
