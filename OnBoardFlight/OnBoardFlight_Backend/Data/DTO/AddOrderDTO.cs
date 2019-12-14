using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardFlight_Backend.Data.DTO
{
    public class AddOrderDTO
    {

        public string SeatNumber { get; set; }

        public DateTime Time { get; set; }

        public IEnumerable<AddOrderlineDTO> OrderlineDTOs{ get; set; }
    }
}
