using OnBoardFlight.ViewModel.Commands.Passenger.Shop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace OnBoardFlight.Model
{
    public class Product : INotifyPropertyChanged
    {
        public int ProductId { get; set; }

        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; RaisePropertyChanged("Description"); }
        }

        public string ImageLink { get; set; }

        private double _price;

        public double Price
        {
            get { return _price; }
            set { _price = value; RaisePropertyChanged("Price"); }
        }

        public ProductCategory Category { get; set; }

        private bool _discount;

        public bool Discount
        {
            get { return _discount; }
            set { _discount = value; RaisePropertyChanged("Discount"); }
        }

        private double? _oldPrice;

        public double? OldPrice
        {
            get { return _oldPrice; }
            set { _oldPrice = value; RaisePropertyChanged("OldPrice"); }
        }

        public Visibility PromotedDisplay
        {
            get{
                if (Discount)
                {
                    return Visibility.Visible;
                }
                else
                {
                    return Visibility.Collapsed;
                }
            }
        }

        public Visibility NotPromotedDisplay
        {
            get
            {
                if (Discount)
                {
                    return Visibility.Collapsed;
                }
                else
                {
                    return Visibility.Visible;
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
