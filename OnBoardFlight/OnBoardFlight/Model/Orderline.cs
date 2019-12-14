using OnBoardFlight.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlight.Model
{
    public class Orderline: INotifyPropertyChanged
    {

        public int OrderlineId { get; set; }

        private int _number;

        public int Number
        {
            get { return _number; }
            set
            {
                _number = value;
                RaisePropertyChanged("Number");
            }
        }


        private Product _product;

        public Product Product
        {
            get { return _product; }
            set
            {
                _product = value;
                RaisePropertyChanged("Product");
            }
        }


        private double _totalPrice;

        public double TotalPrice
        {
            get
            {
                _totalPrice = Number * Product.Price;
                return _totalPrice;
            }
            set
            {
                RaisePropertyChanged("TotalPrice");
            }
        }



        public Orderline(Product product)
        {
            Product = product;
            Number = 1;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
