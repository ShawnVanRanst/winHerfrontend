using OnBoardFlight.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlight.DTO
{
   public class CompleteOrderDTO
    {
        public int OrderId { get; set; }

        public CompleteOrderDTO(Order order)
        {
            OrderId = order.OrderId;
        }
    }
}
