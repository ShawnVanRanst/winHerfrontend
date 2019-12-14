using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlight.DTO
{
    public class OrderDTO
    {

        public int OrderId { get; set; }

        public string SeatNumber { get; set; }

        public DateTime Time { get; set; }

        public double TotalPrice { get; set; }

        public IEnumerable<OrderlineDTO> OrderlineDTOs { get; set; }
    }
}
