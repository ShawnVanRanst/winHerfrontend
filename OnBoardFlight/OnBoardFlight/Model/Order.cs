using OnBoardFlight.DTO;
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
    public class Order: INotifyPropertyChanged
    {

        public int OrderId { get; set; }

        public string SeatNumber { get; set; }

        public DateTime Time { get; set; }

        private double _totalPrice;
        public double TotalPrice
        {
            get
            {
                _totalPrice = 0.0;
                foreach(Orderline ol in Orderlines)
                {
                    _totalPrice += ol.TotalPrice;
                }
                return _totalPrice;
            }
            set
            {
                RaisePropertyChanged("TotalPrice");
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
