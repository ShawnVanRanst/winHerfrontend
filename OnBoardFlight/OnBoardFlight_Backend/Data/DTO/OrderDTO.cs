using OnBoardFlight_Backend.Model;
using System;
using System.Collections.Generic;

namespace OnBoardFlight_Backend.Data.DTO
{
    public class OrderDTO
    {

        public int OrderId { get; set; }

        public string SeatNumber { get; set; }

        public DateTime Time { get; set; }

        public double TotalPrice { get; set; }

        public ICollection<OrderlineDTO> Orderlines { get; set; }


        public OrderDTO(Order order)
        {
            OrderId = order.OrderId;
            SeatNumber = order.SeatNumber;
            Time = order.Time;
            TotalPrice = order.TotalPrice;
            ICollection<OrderlineDTO> orderlineDTOs = new List<OrderlineDTO>();
            foreach (Orderline ol in order.Orderlines)
            {
                OrderlineDTO dto = new OrderlineDTO(ol);
                orderlineDTOs.Add(dto);
            }
            Orderlines = orderlineDTOs;
        }
    }
}