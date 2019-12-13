using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardFlight_Backend.Model
{
    public class Order
    {

        #region Properties

        public int OrderId { get; set; }

        public Passenger Passenger { get; set; }

        public DateTime Time { get; set; }

        public double TotalPrice { get; set; }
        #endregion

        #region Collections

        public ICollection<Orderline> Orderlines{ get; set; }
        #endregion

        #region Constructors
        public Order()
        {
            Orderlines = new List<Orderline>();
        }

        public Order(Passenger passenger, DateTime time)
        {
            Passenger = passenger;
            Time = time;
            Orderlines = new List<Orderline>();
            if (Orderlines.Count > 0)
            {
                CalculateTotalPrice();
            }
        }


        #endregion

        #region Methods

        public void CalculateTotalPrice()
        {
            double total = 0.0;
            foreach(Orderline line in Orderlines)
            {
                total += line.CalculateTotalPrice();
            }
            TotalPrice = total;
        }

        public void AddOrderline(Orderline orderline)
        {
                Orderlines.Add(orderline);
        }
        #endregion
    }
}
