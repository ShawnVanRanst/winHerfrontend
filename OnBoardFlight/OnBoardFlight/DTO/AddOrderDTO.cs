using OnBoardFlight.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlight.DTO
{
    public class AddOrderDTO
    {

        public string SeatNumber { get; set; }

        public DateTime Time { get; set; }

        public IEnumerable<AddOrderlineDTO> OrderlineDTOs { get; set; }


        public AddOrderDTO(Order order)
        {
            ICollection<AddOrderlineDTO> olDTOs = new List<AddOrderlineDTO>();
            SeatNumber = order.SeatNumber;
            Time = order.Time;
            foreach(Orderline ol in order.Orderlines)
            {
                AddOrderlineDTO olDTO = new AddOrderlineDTO(ol);
                olDTOs.Add(olDTO);
            }
            OrderlineDTOs = olDTOs;
        }
    }
}
