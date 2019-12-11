using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlight.Model
{
    public class Order
    {

        public Passenger Passenger { get; set; }

        public DateTime Time { get; set; }

        public double TotalPrice
        {
            get
            {
                double total = 0.0;
                foreach(Orderline ol in Orderlines)
                {
                    total += ol.TotalPrice;
                }
                return total;
            }
        }

        public ICollection<Orderline> Orderlines { get; set; }


        public Order(Passenger passenger)
        {
            Passenger = passenger;
            Time = DateTime.Now;
            Orderlines = new List<Orderline>();
        }

        public void AddOrderline(Orderline orderline)
        {
            Orderlines.Add(orderline);
        }
    }
}
