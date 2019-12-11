using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlight.Model
{
    public class ShoppingCart
    {

        public Passenger Passenger { get; set; }

        public Order Order { get; set; }

        public ShoppingCart(Passenger passenger)
        {
            Passenger = passenger;
            Order = new Order
            {
                Passenger = Passenger,
                Orderlines = new List<Orderline>(),
                Time = DateTime.Now
            };
        }

        public void AddOrderline(Orderline orderline)
        {
            Order.Orderlines.Add(orderline);
        }


    }
}
