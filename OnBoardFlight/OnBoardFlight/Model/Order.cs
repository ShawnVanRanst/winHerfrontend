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

        public double TotalPrice { get; set; }

        public ICollection<Orderline> Orderlines { get; set; }


        public void AddOrderline(Orderline orderline)
        {
            Orderlines.Add(orderline);
        }
    }
}
