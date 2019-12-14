using OnBoardFlight_Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardFlight_Backend.Data.DTO
{
    public class GetAllOrdersDTO
    {

        public ICollection<OrderDTO> OrderDTOs { get; set; }

        public GetAllOrdersDTO(IEnumerable<Order> orders)
        {
            ICollection<OrderDTO> orderDTOs = new List<OrderDTO>();
            foreach(Order o in orders)
            {
                OrderDTO dto = new OrderDTO(o);
                orderDTOs.Add(dto);
            }
            OrderDTOs = orderDTOs;
        }
    }
}
