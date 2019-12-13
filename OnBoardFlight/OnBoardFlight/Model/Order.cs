using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlight.Model
{
    public class Order
    {

        public string SeatNumber { get; set; }

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

        public ObservableCollection<Orderline> Orderlines { get; set; }


        public Order(string seatNumber)
        {
            SeatNumber = seatNumber;
            Time = DateTime.Now;
            Orderlines = new ObservableCollection<Orderline>();
        }

        public void AddOrderline(Orderline orderline)
        {
            Orderlines.Add(orderline);
        }
    }
}
