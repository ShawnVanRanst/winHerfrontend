using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardFlight_Backend.Data.DTO
{
    public class ChangeSeatsDTO
    {
        public string Seat1 { get; set; }
        public string Seat2 { get; set; }
        public bool TwoPassengers { get; set; }
    }
}