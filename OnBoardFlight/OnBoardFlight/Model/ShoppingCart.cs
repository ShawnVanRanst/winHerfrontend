using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlight.Model
{
    public class ShoppingCart: INotifyPropertyChanged
    {

        public string SeatNumber { get; set; }

        private Order _order;

        public Order Order
        {
            get { return _order; }
            set
            {
                _order = value;
                RaisePropertyChanged("Order");
            }
        }


        public ShoppingCart(string seatNumber)
        {
            SeatNumber = seatNumber;
            Order = new Order(SeatNumber)
            {
                Orderlines = new ObservableCollection<Orderline>(),
                Time = DateTime.Now
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddOrderline(Orderline orderline)
        {
            Order.Orderlines.Add(orderline);
        }


    }
}
